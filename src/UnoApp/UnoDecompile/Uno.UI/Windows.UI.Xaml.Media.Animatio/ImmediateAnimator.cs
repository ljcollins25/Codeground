using System;

namespace Windows.UI.Xaml.Media.Animation;

internal sealed class ImmediateAnimator<T> : IValueAnimator, IDisposable where T : struct
{
	private T _from;

	private T _to;

	private long _duration;

	public long StartDelay { get; set; }

	public bool IsRunning { get; set; }

	public long CurrentPlayTime { get; set; }

	public object AnimatedValue { get; set; }

	public long Duration { get; internal set; }

	public event EventHandler AnimationEnd;

	public event EventHandler AnimationPause;

	public event EventHandler AnimationCancel;

	public event EventHandler AnimationFailed;

	public event EventHandler Update;

	public ImmediateAnimator(T from, T to)
	{
		_to = to;
		_from = from;
		StartDelay = 0L;
		CurrentPlayTime = 0L;
	}

	public void Start()
	{
		AnimatedValue = _to;
		this.Update?.Invoke(this, EventArgs.Empty);
		this.AnimationEnd(this, EventArgs.Empty);
		CurrentPlayTime = _duration;
	}

	public void Resume()
	{
		Start();
	}

	public void Pause()
	{
		this.AnimationPause?.Invoke(this, EventArgs.Empty);
	}

	public void Cancel()
	{
		this.AnimationCancel?.Invoke(this, EventArgs.Empty);
	}

	public void SetDuration(long duration)
	{
		_duration = duration;
	}

	public void SetEasingFunction(IEasingFunction easingFunction)
	{
	}

	public void Dispose()
	{
		this.Update = null;
		this.AnimationEnd = null;
		this.AnimationCancel = null;
	}
}
