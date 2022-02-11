using System;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Navigation;

public sealed class NavigatingCancelEventArgs
{
	public bool Cancel { get; set; }

	public NavigationMode NavigationMode { get; }

	public NavigationTransitionInfo NavigationTransitionInfo { get; }

	public object Parameter { get; }

	public Type SourcePageType { get; }

	public NavigatingCancelEventArgs(NavigationMode navigationMode, NavigationTransitionInfo navigationTransitionInfo, object parameter, Type sourcePageType)
	{
		NavigationMode = navigationMode;
		NavigationTransitionInfo = navigationTransitionInfo;
		Parameter = parameter;
		SourcePageType = sourcePageType;
	}
}
