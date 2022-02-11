using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Uno.Disposables;
using Uno.Extensions;
using Windows.System;

namespace Windows.UI.Xaml.Media.Animation;

internal class KeyFrameScheduler<TValue> : IDisposable
{
	public delegate IDisposable? OnFrame(TValue current, IKeyFrame<TValue> frame, TimeSpan duration);

	private static class States
	{
		public const int NotRunning = 0;

		public const int Running = 1;

		public const int Paused = 2;

		public const int Ended = int.MaxValue;
	}

	public enum EndReason
	{
		EndOfFrames,
		Stopped,
		Disposed
	}

	private readonly Stopwatch _watch = new Stopwatch();

	private readonly OnFrame _onFrame;

	private readonly Action<EndReason> _onCompleted;

	private readonly TimeSpan? _beginTime;

	private readonly TimeSpan? _duration;

	private readonly List<IKeyFrame<TValue>> _frames;

	private DispatcherQueueTimer? _timer;

	private int _frameId = -1;

	private SerialDisposable? _frameSubscription;

	private TimeSpan _seekOffset;

	private int _state;

	public TValue CurrentValue { get; private set; }

	public TimeSpan Elapsed => _seekOffset + _watch.Elapsed;

	public KeyFrameScheduler(TimeSpan? beginTime, TimeSpan? duration, TValue initialValue, IEnumerable<IKeyFrame<TValue>>? frames, OnFrame onFrame, Action<EndReason> onCompleted)
	{
		CurrentValue = initialValue;
		if (frames == null)
		{
			frames = Enumerable.Empty<IKeyFrame<TValue>>();
		}
		frames = (IEnumerable<IKeyFrame<TValue>>?)(duration.HasValue ? ((IEnumerable<IKeyFrame>)frames.Where((IKeyFrame<TValue> k) => k != null && k.KeyTime.TimeSpan <= duration.Value)) : ((IEnumerable<IKeyFrame>)frames.Trim()));
		_frames = frames.ToList();
		_frames.Sort(KeyFrameComparer<TValue>.Instance);
		_beginTime = beginTime;
		_duration = duration;
		_onFrame = onFrame;
		_onCompleted = onCompleted;
	}

	public void Start()
	{
		if (Interlocked.CompareExchange(ref _state, 1, 0) == 0)
		{
			_watch.Restart();
			TimeSpan nextFrameDueIn = GetNextFrameDueIn();
			if (nextFrameDueIn > TimeSpan.Zero)
			{
				ScheduleNextFrame(nextFrameDueIn);
			}
			else
			{
				RunNextFrame();
			}
		}
	}

	public void Pause()
	{
		if (Interlocked.CompareExchange(ref _state, 2, 1) == 1)
		{
			_watch.Stop();
			_timer?.Stop();
		}
	}

	public void Resume()
	{
		if (Interlocked.CompareExchange(ref _state, 1, 2) == 2)
		{
			_watch.Start();
			TimeSpan nextFrameDueIn = GetNextFrameDueIn();
			if (nextFrameDueIn > TimeSpan.Zero)
			{
				ScheduleNextFrame(nextFrameDueIn);
			}
			else
			{
				RunNextFrame();
			}
		}
	}

	public void Stop()
	{
		Complete(EndReason.Stopped);
	}

	public void Seek(TimeSpan offset)
	{
		if (_state != int.MaxValue)
		{
			_seekOffset += offset;
			_frameId = 0;
			for (int i = 0; i < _frames.Count && !(_frames[i].KeyTime.TimeSpan > Elapsed); i++)
			{
				_frameId = i;
			}
			if (_state == 1)
			{
				RunNextFrame();
			}
		}
	}

	private void ScheduleNextFrame(TimeSpan delay)
	{
		if (_timer == null)
		{
			_timer = DispatcherQueue.GetForCurrentThread().CreateTimer();
			_timer!.State = this;
			_timer!.Tick += RunNextFrame;
		}
		_timer!.Interval = delay;
		_timer!.Start();
	}

	private static void RunNextFrame(DispatcherQueueTimer timer, object state)
	{
		((KeyFrameScheduler<TValue>)timer.State).RunNextFrame();
	}

	private void RunNextFrame()
	{
		_timer?.Stop();
		if (_state != 1)
		{
			return;
		}
		if (++_frameId >= _frames.Count)
		{
			Complete(EndReason.EndOfFrames);
			return;
		}
		IKeyFrame<TValue> keyFrame = _frames[_frameId];
		TimeSpan nextFrameDueIn = GetNextFrameDueIn();
		TValue currentValue = CurrentValue;
		CurrentValue = keyFrame.Value;
		IDisposable disposable = _onFrame(currentValue, keyFrame, nextFrameDueIn);
		if (disposable != null)
		{
			(_frameSubscription ?? (_frameSubscription = new SerialDisposable()))!.Disposable = disposable;
		}
		if (nextFrameDueIn > TimeSpan.Zero)
		{
			ScheduleNextFrame(nextFrameDueIn);
		}
		else
		{
			RunNextFrame();
		}
	}

	private TimeSpan GetNextFrameDueIn()
	{
		int num = _frameId + 1;
		TimeSpan timeSpan = ((num < _frames.Count) ? _frames[num].KeyTime.TimeSpan : (_duration ?? TimeSpan.Zero));
		if (_beginTime.HasValue)
		{
			timeSpan += _beginTime.Value;
		}
		return timeSpan - Elapsed;
	}

	private void Complete(EndReason reason)
	{
		DispatcherQueueTimer timer = _timer;
		if (timer != null)
		{
			timer.Stop();
			timer.State = null;
			timer.Tick -= RunNextFrame;
			_timer = null;
		}
		_watch.Stop();
		_frameSubscription?.Dispose();
		if (Interlocked.Exchange(ref _state, int.MaxValue) != int.MaxValue)
		{
			_onCompleted(reason);
		}
	}

	public void Dispose()
	{
		Complete(EndReason.Disposed);
	}
}
