using System;
using System.Diagnostics;

namespace Windows.UI.Xaml.Media.Animation;

internal abstract class CPUBoundAnimator<T> : IValueAnimator, IDisposable where T : struct
{
	private readonly T _from;

	private readonly T _to;

	private readonly Stopwatch _elapsed;

	private T _currentValue;

	protected IEasingFunction _easing = LinearEase.Instance;

	private bool _isDisposed;

	private bool _isDelaying;

	public object AnimatedValue => _currentValue;

	public long CurrentPlayTime { get; set; }

	public bool IsRunning { get; private set; }

	public long StartDelay { get; set; }

	public long Duration { get; private set; }

	public event EventHandler Update;

	public event EventHandler AnimationEnd;

	public event EventHandler AnimationPause;

	public event EventHandler AnimationCancel;

	public event EventHandler AnimationFailed;

	protected CPUBoundAnimator(T from, T to)
	{
		_from = from;
		_to = to;
		_elapsed = new Stopwatch();
	}

	public void SetDuration(long duration)
	{
		Duration = duration;
	}

	public void SetEasingFunction(IEasingFunction easingFunction)
	{
		_easing = easingFunction ?? LinearEase.Instance;
	}

	public IEasingFunction GetEasingFunction()
	{
		return _easing;
	}

	public void Start()
	{
		CheckDisposed();
		ConfigureStartInterval(0L);
		IsRunning = true;
		_elapsed.Restart();
		EnableFrameReporting();
	}

	public void Pause()
	{
		CheckDisposed();
		IsRunning = false;
		_elapsed.Stop();
		DisableFrameReporting();
		this.AnimationPause?.Invoke(this, EventArgs.Empty);
	}

	public void Resume()
	{
		CheckDisposed();
		ConfigureStartInterval(_elapsed.ElapsedMilliseconds);
		IsRunning = true;
		_elapsed.Start();
		EnableFrameReporting();
	}

	public void Cancel()
	{
		CheckDisposed();
		IsRunning = false;
		_elapsed.Stop();
		DisableFrameReporting();
		this.AnimationCancel?.Invoke(this, EventArgs.Empty);
	}

	protected abstract void EnableFrameReporting();

	protected abstract void DisableFrameReporting();

	protected virtual void SetStartFrameDelay(long delayMs)
	{
	}

	protected virtual void SetAnimationFramesInterval()
	{
	}

	protected void OnFrame(object sender, object e)
	{
		long elapsedMilliseconds = _elapsed.ElapsedMilliseconds;
		if (elapsedMilliseconds < StartDelay)
		{
			ConfigureStartInterval(elapsedMilliseconds);
			CurrentPlayTime = 0L;
			_currentValue = _from;
			return;
		}
		if (elapsedMilliseconds >= StartDelay + Duration)
		{
			IsRunning = false;
			DisableFrameReporting();
			_elapsed.Stop();
			CurrentPlayTime = Duration;
			_currentValue = _to;
			this.Update?.Invoke(this, EventArgs.Empty);
			this.AnimationEnd?.Invoke(this, EventArgs.Empty);
			return;
		}
		if (_isDelaying)
		{
			ConfigureAnimationInterval();
		}
		long frame = elapsedMilliseconds - StartDelay;
		T updatedValue = GetUpdatedValue(frame, _from, _to);
		CurrentPlayTime = elapsedMilliseconds;
		_currentValue = updatedValue;
		this.Update?.Invoke(this, EventArgs.Empty);
	}

	protected abstract T GetUpdatedValue(long frame, T from, T to);

	private void ConfigureStartInterval(long elapsed)
	{
		if (StartDelay > 0)
		{
			_isDelaying = true;
			SetStartFrameDelay(StartDelay - elapsed);
		}
		else
		{
			ConfigureAnimationInterval();
		}
	}

	private void ConfigureAnimationInterval()
	{
		_isDelaying = false;
		SetAnimationFramesInterval();
	}

	private void CheckDisposed()
	{
		if (_isDisposed)
		{
			throw new ObjectDisposedException("CPUBoundAnimator");
		}
	}

	public void Dispose()
	{
		_isDisposed = true;
		IsRunning = false;
		DisableFrameReporting();
		_elapsed.Stop();
	}
}
