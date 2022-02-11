using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.Disposables;
using Uno.Foundation.Logging;
using Windows.UI.Core;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media.Animation;

[ContentProperty(Name = "KeyFrames")]
public class ColorAnimationUsingKeyFrames : Timeline, ITimeline, IDisposable
{
	private readonly Stopwatch _activeDuration = new Stopwatch();

	private int _replayCount = 1;

	private ColorOffset? _startingValue;

	private ColorOffset _finalValue;

	private List<IValueAnimator> _animators;

	private IValueAnimator _currentAnimator;

	private readonly CompositeDisposable _subscriptions = new CompositeDisposable();

	private bool _wasBeginScheduled;

	public static DependencyProperty EnableDependentAnimationProperty { get; } = DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(ColorAnimationUsingKeyFrames), new FrameworkPropertyMetadata(false));


	public bool EnableDependentAnimation
	{
		get
		{
			return (bool)GetValue(EnableDependentAnimationProperty);
		}
		set
		{
			SetValue(EnableDependentAnimationProperty, value);
		}
	}

	public static DependencyProperty KeyFramesProperty { get; } = DependencyProperty.Register("KeyFrames", typeof(ColorKeyFrameCollection), typeof(ColorAnimationUsingKeyFrames), new FrameworkPropertyMetadata((object)null));


	public ColorKeyFrameCollection KeyFrames
	{
		get
		{
			return (ColorKeyFrameCollection)GetValue(KeyFramesProperty);
		}
		set
		{
			SetValue(KeyFramesProperty, value);
		}
	}

	public ColorAnimationUsingKeyFrames()
	{
		KeyFrames = new ColorKeyFrameCollection(this, isAutoPropertyInheritanceEnabled: false);
	}

	internal override TimeSpan GetCalculatedDuration()
	{
		Duration duration = base.Duration;
		if (duration != Duration.Automatic)
		{
			return base.GetCalculatedDuration();
		}
		if (KeyFrames.Any())
		{
			return KeyFrames.Max((ColorKeyFrame kf) => kf.KeyTime)!.TimeSpan;
		}
		return base.GetCalculatedDuration();
	}

	void ITimeline.Begin()
	{
		if (_wasBeginScheduled)
		{
			return;
		}
		_wasBeginScheduled = true;
		base.Dispatcher.RunAsync(CoreDispatcherPriority.High, delegate
		{
			if (KeyFrames.Count >= 1)
			{
				base.PropertyInfo?.CloneShareableObjectsInPath();
				_wasBeginScheduled = false;
				_subscriptions.Clear();
				_activeDuration.Restart();
				_replayCount = 1;
				Play();
			}
		});
	}

	void ITimeline.Pause()
	{
		if (base.State != TimelineState.Paused)
		{
			_currentAnimator.Pause();
			base.State = TimelineState.Paused;
		}
	}

	void ITimeline.Resume()
	{
		if (base.State == TimelineState.Paused)
		{
			_currentAnimator.Resume();
			base.State = TimelineState.Active;
		}
	}

	void ITimeline.Seek(TimeSpan offset)
	{
		long num = (long)offset.TotalMilliseconds;
		IValueAnimator valueAnimator = null;
		foreach (IValueAnimator animator in _animators)
		{
			if (num < animator.Duration)
			{
				valueAnimator = animator;
				break;
			}
			num -= animator.Duration;
		}
		if (valueAnimator != _currentAnimator)
		{
			_currentAnimator?.Cancel();
			_currentAnimator = valueAnimator;
		}
		if (_currentAnimator == null)
		{
			return;
		}
		_currentAnimator.CurrentPlayTime = (long)offset.TotalMilliseconds;
		if (base.State == TimelineState.Active || base.State == TimelineState.Paused)
		{
			CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				OnFrame(_currentAnimator);
				_currentAnimator.Pause();
			});
		}
	}

	void ITimeline.SeekAlignedToLastTick(TimeSpan offset)
	{
		((ITimeline)this).Seek(offset);
	}

	void ITimeline.SkipToFill()
	{
		if (_currentAnimator != null && _currentAnimator.IsRunning)
		{
			_currentAnimator.Cancel();
			_startingValue = null;
		}
		SetValue(_finalValue);
		OnEnd();
	}

	void ITimeline.Deactivate()
	{
		if (_currentAnimator != null && _currentAnimator.IsRunning)
		{
			_currentAnimator.Cancel();
			_startingValue = null;
		}
		base.State = TimelineState.Stopped;
	}

	void ITimeline.Stop()
	{
		_currentAnimator?.Cancel();
		_startingValue = null;
		ClearValue();
		base.State = TimelineState.Stopped;
	}

	private void Play()
	{
		InitializeAnimators();
		if (EnableDependentAnimation || !this.GetIsDependantAnimation())
		{
			_currentAnimator = _animators.First();
			if (base.BeginTime.HasValue)
			{
				_currentAnimator.StartDelay = (long)base.BeginTime.Value.TotalMilliseconds;
			}
			_currentAnimator.Start();
			base.State = TimelineState.Active;
		}
	}

	private void InitializeAnimators()
	{
		ColorOffset colorOffset = ComputeFromValue();
		ColorOffset startingValue = colorOffset;
		TimeSpan timeSpan = TimeSpan.Zero;
		_animators = new List<IValueAnimator>(KeyFrames.Count);
		int num = 0;
		foreach (ColorKeyFrame item in KeyFrames.OrderBy((ColorKeyFrame k) => k.KeyTime.TimeSpan))
		{
			ColorOffset colorOffset2 = (ColorOffset)item.Value;
			if (num + 1 == KeyFrames.Count)
			{
				_finalValue = colorOffset2;
			}
			IValueAnimator valueAnimator = AnimatorFactory.Create(this, startingValue, colorOffset2);
			valueAnimator.SetDuration((long)(item.KeyTime.TimeSpan - timeSpan).TotalMilliseconds);
			valueAnimator.SetEasingFunction(item.GetEasingFunction());
			valueAnimator.DisposeWith(_subscriptions);
			_animators.Add(valueAnimator);
			startingValue = colorOffset2;
			timeSpan = item.KeyTime.TimeSpan;
			if (ReportEachFrame())
			{
				valueAnimator.Update += delegate(object sender, EventArgs e)
				{
					OnFrame((IValueAnimator)sender);
				};
			}
			int i = num;
			valueAnimator.AnimationEnd += delegate(object a, EventArgs _)
			{
				OnFrame((IValueAnimator)a);
				OnAnimatorEnd(i);
			};
			num++;
		}
	}

	private void OnAnimatorEnd(int i)
	{
		int num = i + 1;
		if (num == KeyFrames.Count)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("ColorAnimationUsingKeyFrames has ended.");
			}
			OnEnd();
			_startingValue = null;
		}
		else
		{
			_currentAnimator = _animators[num];
			_currentAnimator.Start();
		}
	}

	private ColorOffset ComputeFromValue()
	{
		return GetDefaultTargetValue() ?? ColorOffset.Zero;
	}

	private ColorOffset? GetDefaultTargetValue()
	{
		ColorOffset? startingValue = _startingValue;
		if (startingValue.HasValue)
		{
			return startingValue;
		}
		if (GetValue() is Color color)
		{
			return (ColorOffset)color;
		}
		return null;
	}

	private void Replay()
	{
		_replayCount++;
		Play();
	}

	private void OnEnd()
	{
		if (NeedsRepeat(_activeDuration, _replayCount))
		{
			Replay();
			return;
		}
		if (base.FillBehavior == FillBehavior.HoldEnd)
		{
			base.State = TimelineState.Filling;
		}
		else
		{
			base.State = TimelineState.Stopped;
			ClearValue();
		}
		OnCompleted();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_subscriptions.Dispose();
		}
		base.Dispose(disposing);
	}

	private void OnFrame(IValueAnimator currentAnimator)
	{
		SetValue(currentAnimator.AnimatedValue);
	}

	private bool ReportEachFrame()
	{
		return true;
	}
}
