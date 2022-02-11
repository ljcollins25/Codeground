using System;

namespace Windows.UI.Xaml.Media;

public sealed class RenderingEventArgs
{
	public TimeSpan RenderingTime { get; }

	internal RenderingEventArgs(TimeSpan renderingTime)
	{
		RenderingTime = renderingTime;
	}
}
