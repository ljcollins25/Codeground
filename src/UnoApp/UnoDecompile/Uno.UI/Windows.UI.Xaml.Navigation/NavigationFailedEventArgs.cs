using System;

namespace Windows.UI.Xaml.Navigation;

public sealed class NavigationFailedEventArgs
{
	public Exception Exception { get; }

	public bool Handled { get; set; }

	public Type SourcePageType { get; }

	internal NavigationFailedEventArgs(Type sourcePageType, Exception exception)
	{
		SourcePageType = sourcePageType;
		Exception = exception;
	}
}
