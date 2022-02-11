using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Uno.Disposables;
using Uno.UI.Dispatching;

namespace Windows.UI.Xaml.Media.Animation;

internal class DiscreteFloatValueAnimator : IValueAnimator, IDisposable
{
	private readonly SerialDisposable _scheduledFrame = new SerialDisposable();

	private readonly Stopwatch _watch = new Stopwatch();

	private float _from;

	private float _to;

	public object AnimatedValue { get; private set; }

	public long CurrentPlayTime { get; set; }

	public long Duration { get; private set; }

	public bool IsRunning { get; private set; }

	public long StartDelay { get; set; }

	public event EventHandler AnimationCancel;

	public event EventHandler AnimationEnd;

	public event EventHandler AnimationPause;

	public event EventHandler AnimationFailed;

	public event EventHandler Update;

	public DiscreteFloatValueAnimator(float from, float to)
	{
		_from = from;
		_to = to;
		AnimatedValue = from;
	}

	public void Cancel()
	{
		IsRunning = false;
		_scheduledFrame.Disposable = null;
		_watch.Reset();
		this.AnimationCancel?.Invoke(this, EventArgs.Empty);
	}

	public void Dispose()
	{
		IsRunning = false;
		_scheduledFrame.Dispose();
		_watch.Reset();
	}

	public void Pause()
	{
		IsRunning = false;
		_scheduledFrame.Disposable = null;
		_watch.Stop();
		this.AnimationPause?.Invoke(this, EventArgs.Empty);
	}

	public void Resume()
	{
		long elapsedMilliseconds = _watch.ElapsedMilliseconds;
		ScheduleCompleted(elapsedMilliseconds);
		_watch.Start();
		IsRunning = true;
	}

	private void ScheduleCompleted(long elapsed)
	{
		_scheduledFrame.Disposable = CoreDispatcher.Main.RunAsync(CoreDispatcherPriority.Normal, (DispatchedHandler)async delegate
		{
			await Task.Delay(TimeSpan.FromMilliseconds(Duration - elapsed));
			Complete();
		});
	}

	public void SetDuration(long duration)
	{
		Duration = duration;
	}

	public void SetEasingFunction(IEasingFunction easingFunction)
	{
	}

	public void Start()
	{
		this.Update?.Invoke(this, EventArgs.Empty);
		ScheduleCompleted(Duration);
		_watch.Start();
		IsRunning = true;
	}

	private void Complete()
	{
		AnimatedValue = _to;
		this.Update?.Invoke(this, EventArgs.Empty);
		this.AnimationEnd?.Invoke(this, EventArgs.Empty);
	}
}
