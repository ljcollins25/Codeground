using System;

namespace Windows.UI.Xaml.Media.Animation;

internal interface IValueAnimator : IDisposable
{
	object AnimatedValue { get; }

	long CurrentPlayTime { get; set; }

	bool IsRunning { get; }

	long StartDelay { get; set; }

	long Duration { get; }

	event EventHandler Update;

	event EventHandler AnimationEnd;

	event EventHandler AnimationPause;

	event EventHandler AnimationCancel;

	event EventHandler AnimationFailed;

	void Start();

	void Pause();

	void Resume();

	void Cancel();

	void SetDuration(long duration);

	void SetEasingFunction(IEasingFunction easingFunction);
}
