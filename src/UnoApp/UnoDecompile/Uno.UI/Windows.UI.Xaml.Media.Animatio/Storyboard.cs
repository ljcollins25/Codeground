using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media.Animation;

[ContentProperty(Name = "Children")]
public sealed class Storyboard : Timeline, ITimeline, IDisposable, IAdditionalChildrenProvider, IThemeChangeAware
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{57A7F5D4-8AA9-453F-A2D5-9F9DCA48BF54}");

		public const int StoryBoard_Start = 1;

		public const int StoryBoard_Stop = 2;

		public const int StoryBoard_Pause = 3;

		public const int StoryBoard_Resume = 4;
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private EventActivity _traceActivity;

	private readonly Stopwatch _activeDuration = new Stopwatch();

	private int _replayCount = 1;

	private int _runningChildren;

	private bool _hasFillingChildren;

	private Dictionary<ITimeline, IDisposable> _childrenSubscriptions = new Dictionary<ITimeline, IDisposable>();

	public TimelineCollection Children { get; }

	public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.RegisterAttached("TargetName", typeof(string), typeof(Storyboard), new FrameworkPropertyMetadata(null));


	public static DependencyProperty TargetPropertyProperty { get; } = DependencyProperty.RegisterAttached("TargetProperty", typeof(string), typeof(Storyboard), new FrameworkPropertyMetadata(null));


	public Storyboard()
	{
		Children = new TimelineCollection(this, isAutoPropertyInheritanceEnabled: false);
	}

	public static string GetTargetName(Timeline timeline)
	{
		return (string)timeline.GetValue(TargetNameProperty);
	}

	public static void SetTargetName(Timeline timeline, string value)
	{
		timeline.SetValue(TargetNameProperty, value);
	}

	public static string GetTargetProperty(Timeline timeline)
	{
		return (string)timeline.GetValue(TargetPropertyProperty);
	}

	public static void SetTargetProperty(Timeline timeline, string value)
	{
		timeline.SetValue(TargetPropertyProperty, value);
	}

	public static void SetTarget(Timeline timeline, DependencyObject target)
	{
		timeline.Target = target;
	}

	public static void SetTarget(Timeline timeline, ElementNameSubject target)
	{
		timeline.SetElementNameTarget(target);
	}

	private void DisposeChildRegistrations(ITimeline child)
	{
		if (_childrenSubscriptions.TryGetValue(child, out var value))
		{
			value.Dispose();
			_childrenSubscriptions.Remove(child);
		}
	}

	private void Replay()
	{
		_replayCount++;
		Play();
	}

	public void Begin()
	{
		if (_trace.IsEnabled)
		{
			IEventProvider trace = _trace;
			object[] payload = new string[2]
			{
				this.GetParent()?.GetType().Name,
				this.GetParent()?.GetDependencyObjectId().ToString()
			};
			_traceActivity = trace.WriteEventActivity(1, EventOpcode.Start, payload);
		}
		base.State = TimelineState.Active;
		_hasFillingChildren = false;
		_replayCount = 1;
		_activeDuration.Restart();
		Play();
	}

	private void Play()
	{
		if (Children != null && Children.Count > 0)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline child = Children[i];
				DisposeChildRegistrations(child);
				_runningChildren++;
				child.Completed += Child_Completed;
				child.Failed += Child_Failed;
				_childrenSubscriptions.Add(child, Disposable.Create(delegate
				{
					child.Completed -= Child_Completed;
					child.Failed -= Child_Failed;
				}));
				child.Begin();
			}
		}
		else
		{
			base.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				base.State = TimelineState.Stopped;
				OnCompleted();
			});
		}
	}

	public void Stop()
	{
		if (_trace.IsEnabled)
		{
			_trace.WriteEventActivity(2, EventOpcode.Stop, _traceActivity, new object[2]
			{
				base.Target?.GetType().ToString(),
				base.PropertyInfo?.Path
			});
		}
		base.State = TimelineState.Stopped;
		_hasFillingChildren = false;
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.Stop();
				DisposeChildRegistrations(timeline);
			}
		}
		_runningChildren = 0;
	}

	public void Resume()
	{
		if (_trace.IsEnabled)
		{
			_trace.WriteEventActivity(4, EventOpcode.Send, _traceActivity, new object[2]
			{
				base.Target?.GetType().ToString(),
				base.PropertyInfo?.Path
			});
		}
		if (Children != null && Children.Count > 0)
		{
			base.State = TimelineState.Active;
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.Resume();
			}
		}
	}

	public void Pause()
	{
		if (_trace.IsEnabled)
		{
			_trace.WriteEventActivity(3, EventOpcode.Send, _traceActivity, new object[2]
			{
				base.Target?.GetType().ToString(),
				base.PropertyInfo?.Path
			});
		}
		base.State = TimelineState.Paused;
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.Pause();
			}
		}
	}

	public void Seek(TimeSpan offset)
	{
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.Seek(offset);
			}
		}
	}

	public void SeekAlignedToLastTick(TimeSpan offset)
	{
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.SeekAlignedToLastTick(offset);
			}
		}
	}

	public void SkipToFill()
	{
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.SkipToFill();
			}
		}
	}

	internal void Deactivate()
	{
		base.State = TimelineState.Stopped;
		_hasFillingChildren = false;
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ITimeline timeline = Children[i];
				timeline.Deactivate();
				DisposeChildRegistrations(timeline);
			}
			_runningChildren = 0;
		}
	}

	internal void TurnOverAnimationsTo(Storyboard storyboard)
	{
		string[] targetedProperties = storyboard.Children.TargetedProperties;
		for (int i = 0; i < Children.Count; i++)
		{
			Timeline timeline = Children[i];
			string timelineTargetFullName = timeline.GetTimelineTargetFullName();
			if (targetedProperties.Contains(timelineTargetFullName))
			{
				((ITimeline)timeline).Deactivate();
			}
			else
			{
				((ITimeline)timeline).Stop();
			}
		}
		base.State = TimelineState.Stopped;
	}

	public ClockState GetCurrentState()
	{
		return base.State switch
		{
			TimelineState.Filling => ClockState.Filling, 
			TimelineState.Stopped => ClockState.Stopped, 
			_ => ClockState.Active, 
		};
	}

	public TimeSpan GetCurrentTime()
	{
		throw new NotImplementedException();
	}

	private void Child_Failed(object sender, object e)
	{
		if (sender is Timeline child)
		{
			DisposeChildRegistrations(child);
			Interlocked.Decrement(ref _runningChildren);
		}
	}

	private void Child_Completed(object sender, object e)
	{
		if (!(sender is Timeline timeline))
		{
			return;
		}
		DisposeChildRegistrations(timeline);
		Interlocked.Decrement(ref _runningChildren);
		_hasFillingChildren |= timeline.FillBehavior != FillBehavior.Stop;
		if (_runningChildren != 0)
		{
			return;
		}
		if (NeedsRepeat(_activeDuration, _replayCount))
		{
			Replay();
			return;
		}
		if (base.State == TimelineState.Active)
		{
			base.State = (_hasFillingChildren ? TimelineState.Filling : TimelineState.Stopped);
		}
		OnCompleted();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (Children != null)
		{
			for (int i = 0; i < Children.Count; i++)
			{
				Children[i].Dispose();
			}
		}
	}

	IEnumerable<DependencyObject> IAdditionalChildrenProvider.GetAdditionalChildObjects()
	{
		return Children;
	}

	void IThemeChangeAware.OnThemeChanged()
	{
		if (base.State == TimelineState.Filling)
		{
			SkipToFill();
		}
	}
}
