using System;

namespace Windows.UI.Xaml;

public class RoutedEventArgs : EventArgs
{
	public object OriginalSource { get; internal set; }

	public bool CanBubbleNatively { get; internal set; }

	public RoutedEventArgs()
	{
	}

	internal RoutedEventArgs(object originalSource)
	{
		OriginalSource = originalSource;
	}
}
