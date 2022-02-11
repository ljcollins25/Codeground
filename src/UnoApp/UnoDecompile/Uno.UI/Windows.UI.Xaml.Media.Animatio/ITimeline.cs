using System;

namespace Windows.UI.Xaml.Media.Animation;

internal interface ITimeline : IDisposable
{
	event EventHandler<object> Completed;

	event EventHandler<object> Failed;

	void Begin();

	void Stop();

	void Resume();

	void Pause();

	void Seek(TimeSpan offset);

	void SeekAlignedToLastTick(TimeSpan offset);

	void SkipToFill();

	void Deactivate();
}
