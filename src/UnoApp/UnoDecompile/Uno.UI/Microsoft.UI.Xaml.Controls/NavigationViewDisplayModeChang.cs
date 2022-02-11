namespace Microsoft.UI.Xaml.Controls;

public sealed class NavigationViewDisplayModeChangedEventArgs
{
	public NavigationViewDisplayMode DisplayMode { get; }

	internal NavigationViewDisplayModeChangedEventArgs(NavigationViewDisplayMode displayMode)
	{
		DisplayMode = displayMode;
	}
}
