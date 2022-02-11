using System;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml.Media.Animation;

internal sealed class NotSupportedAnimator : IValueAnimator, IDisposable
{
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

	public void Start()
	{
		this.Log().Error("NotSupportedAnimator.Start");
	}

	public void Resume()
	{
		this.Log().Error("NotSupportedAnimator.Resume");
	}

	public void Pause()
	{
		this.Log().Error("NotSupportedAnimator.Pause");
	}

	public void Cancel()
	{
		this.Log().Error("NotSupportedAnimator.Cancel");
		IsRunning = false;
	}

	private void Stop()
	{
		this.Log().Error("NotSupportedAnimator.Stop");
	}

	public void SetDuration(long duration)
	{
		this.Log().Error("NotSupportedAnimator.SetDuration");
	}

	public void SetEasingFunction(IEasingFunction easingFunction)
	{
		this.Log().Error("NotSupportedAnimator.SetEasingFunction");
	}

	public void Dispose()
	{
	}
}
