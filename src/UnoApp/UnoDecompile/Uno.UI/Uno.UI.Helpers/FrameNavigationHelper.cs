using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Uno.UI.Helpers;

public static class FrameNavigationHelper
{
	public static PageStackEntry? GetCurrentEntry(Frame? frame)
	{
		return frame?.CurrentEntry;
	}

	public static Page? GetInstance(PageStackEntry? entry)
	{
		return entry?.Instance;
	}

	public static NavigationEventArgs CreateNavigationEventArgs(object? content, NavigationMode navigationMode, NavigationTransitionInfo? navigationTransitionInfo, object? parameter, Type sourcePageType, Uri? uri)
	{
		return new NavigationEventArgs(content, navigationMode, navigationTransitionInfo, parameter, sourcePageType, uri);
	}
}
