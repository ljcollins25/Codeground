using System;
using System.Linq;
using Uno;
using Uno.Diagnostics.Eventing;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media.Animation;

[ContentProperty(Name = "KeyFrames")]
public sealed class ObjectAnimationUsingKeyFrames : Timeline, ITimeline, IDisposable
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{9EBBD06A-ADA3-464F-93C6-C850AB62A41D}");

		public const int Start = 1;

		public const int Stop = 2;

		public const int Pause = 3;

		public const int Resume = 4;
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private EventActivity _traceActivity;

	private KeyFrameScheduler<object> _frameScheduler;

	private (int count, TimeSpan time) _playStatus;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EnableDependentAnimationProperty { get; } = DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(ObjectAnimationUsingKeyFrames), new FrameworkPropertyMetadata(false));


	public ObjectKeyFrameCollection KeyFrames
	{
		get
		{
			return (ObjectKeyFrameCollection)GetValue(KeyFramesProperty);
		}
		internal set
		{
			SetValue(KeyFramesProperty, value);
		}
	}

	internal static DependencyProperty KeyFramesProperty { get; } = DependencyProperty.Register("KeyFrames", typeof(ObjectKeyFrameCollection), typeof(ObjectAnimationUsingKeyFrames), new FrameworkPropertyMetadata((object)null));


	public ObjectAnimationUsingKeyFrames()
	{
		KeyFrames = new ObjectKeyFrameCollection(this, isAutoPropertyInheritanceEnabled: false);
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
			return KeyFrames.Max((ObjectKeyFrame kf) => kf.KeyTime)!.TimeSpan;
		}
		return base.GetCalculatedDuration();
	}

	void ITimeline.Begin()
	{
		if (_trace.IsEnabled)
		{
			IEventProvider trace = _trace;
			object[] traceProperties = GetTraceProperties();
			_traceActivity = trace.WriteEventActivity(1, EventOpcode.Start, traceProperties);
		}
		Reset();
		base.State = TimelineState.Active;
		_playStatus = default((int, TimeSpan));
		_frameScheduler = new KeyFrameScheduler<object>(base.BeginTime, base.Duration.HasTimeSpan ? new TimeSpan?(base.Duration.TimeSpan) : null, null, KeyFrames, new KeyFrameScheduler<object>.OnFrame(OnFrame), new Action<KeyFrameScheduler<object>.EndReason>(OnFramesEnd));
		_frameScheduler.Start();
	}

	void ITimeline.Stop()
	{
		if (_trace.IsEnabled)
		{
			IEventProvider trace = _trace;
			object[] traceProperties = GetTraceProperties();
			_traceActivity = trace.WriteEventActivity(2, EventOpcode.Stop, traceProperties);
		}
		_frameScheduler?.Stop();
		Reset();
		ClearValue();
	}

	void ITimeline.Resume()
	{
		if (base.State == TimelineState.Paused)
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				object[] traceProperties = GetTraceProperties();
				_traceActivity = trace.WriteEventActivity(4, EventOpcode.Send, traceProperties);
			}
			base.State = TimelineState.Active;
			_frameScheduler.Resume();
		}
	}

	void ITimeline.Pause()
	{
		if (base.State == TimelineState.Active)
		{
			if (_trace.IsEnabled)
			{
				IEventProvider trace = _trace;
				object[] traceProperties = GetTraceProperties();
				_traceActivity = trace.WriteEventActivity(3, EventOpcode.Send, traceProperties);
			}
			base.State = TimelineState.Paused;
			_frameScheduler.Pause();
		}
	}

	void ITimeline.Seek(TimeSpan offset)
	{
		_frameScheduler?.Seek(offset);
	}

	void ITimeline.SeekAlignedToLastTick(TimeSpan offset)
	{
		((ITimeline)this).Seek(offset);
	}

	void ITimeline.SkipToFill()
	{
		_frameScheduler?.Dispose();
		_frameScheduler = null;
		ObjectKeyFrame objectKeyFrame = KeyFrames.OrderBy((ObjectKeyFrame k) => k.KeyTime.TimeSpan).Last();
		SetValue(objectKeyFrame.Value);
		base.State = TimelineState.Stopped;
	}

	void ITimeline.Deactivate()
	{
		Reset();
	}

	private void Reset()
	{
		_frameScheduler?.Dispose();
		_frameScheduler = null;
		base.State = TimelineState.Stopped;
	}

	private IDisposable OnFrame(object currentValue, IKeyFrame<object> frame, TimeSpan duration)
	{
		SetValue(frame.Value);
		return null;
	}

	private void OnFramesEnd(KeyFrameScheduler<object>.EndReason endReason)
	{
		_playStatus = (_playStatus.count + 1, _playStatus.time + _frameScheduler.Elapsed);
		if (endReason != 0)
		{
			return;
		}
		if (base.RepeatBehavior.ShouldRepeat(_playStatus.time, _playStatus.count))
		{
			Replay();
			return;
		}
		if (base.FillBehavior == FillBehavior.HoldEnd)
		{
			Fill();
		}
		else
		{
			Reset();
			ClearValue();
		}
		OnCompleted();
	}

	private void Fill()
	{
		TimeSpan lastTime = KeyFrames.Max((ObjectKeyFrame k) => k.KeyTime.TimeSpan);
		ObjectKeyFrame objectKeyFrame = KeyFrames.First((ObjectKeyFrame k) => k.KeyTime.TimeSpan.Equals(lastTime));
		_frameScheduler?.Dispose();
		_frameScheduler = null;
		base.State = TimelineState.Filling;
		SetValue(objectKeyFrame.Value);
	}

	private void Replay()
	{
		_frameScheduler?.Dispose();
		ClearValue();
		_frameScheduler = new KeyFrameScheduler<object>(base.BeginTime, base.Duration.HasTimeSpan ? new TimeSpan?(base.Duration.TimeSpan) : null, null, KeyFrames, new KeyFrameScheduler<object>.OnFrame(OnFrame), new Action<KeyFrameScheduler<object>.EndReason>(OnFramesEnd));
		_frameScheduler.Start();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (_frameScheduler != null)
		{
			_frameScheduler.Dispose();
			_frameScheduler = null;
		}
	}
}
