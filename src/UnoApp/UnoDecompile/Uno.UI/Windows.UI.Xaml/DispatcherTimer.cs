using System;
using System.Threading;
using Uno;

namespace Windows.UI.Xaml;

public class DispatcherTimer : IDispatcherTimer
{
	private static class States
	{
		public const int Idle = 0;

		public const int Running = 1;
	}

	private int _state;

	private TimeSpan _interval;

	private DateTimeOffset _lastTick;

	private Timer _timer;

	public TimeSpan Interval
	{
		get
		{
			return _interval;
		}
		set
		{
			if (_interval != value)
			{
				_interval = value;
				if (IsEnabled)
				{
					Restart(value);
				}
			}
		}
	}

	public bool IsEnabled => _state == 1;

	public event EventHandler<object> Tick;

	public void Start()
	{
		if (Interlocked.CompareExchange(ref _state, 1, 0) == 0)
		{
			StartNative(Interval);
			return;
		}
		StopNative();
		StartNative(Interval);
	}

	public void Stop()
	{
		if (Interlocked.Exchange(ref _state, 0) == 1)
		{
			StopNative();
		}
	}

	private void Restart(TimeSpan interval)
	{
		DateTimeOffset now = DateTimeOffset.Now;
		StopNative();
		TimeSpan timeSpan = now - _lastTick;
		if (timeSpan >= interval)
		{
			RaiseTick();
			if (IsEnabled)
			{
				StartNative(interval);
			}
		}
		else
		{
			StartNative(interval - timeSpan, interval);
		}
	}

	private void RaiseTick()
	{
		if (IsEnabled)
		{
			_lastTick = DateTimeOffset.UtcNow;
			this.Tick?.Invoke(this, null);
		}
	}

	private void StartNative(TimeSpan interval)
	{
		if (_timer == null)
		{
			_timer = new Timer(delegate
			{
				RaiseTick();
			});
		}
		_timer.Change(interval, interval);
	}

	private void StartNative(TimeSpan dueTime, TimeSpan interval)
	{
		if (_timer == null)
		{
			_timer = new Timer(delegate
			{
				RaiseTick();
			});
		}
		_timer.Change(dueTime, interval);
	}

	private void StopNative()
	{
		_timer.Dispose();
		_timer = null;
	}
}
