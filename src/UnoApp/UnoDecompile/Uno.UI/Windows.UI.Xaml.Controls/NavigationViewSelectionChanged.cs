using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewSelectionChangedEventArgs
{
	public bool IsSettingsSelected { get; internal set; }

	public object SelectedItem { get; internal set; }

	public NavigationTransitionInfo RecommendedNavigationTransitionInfo { get; internal set; }

	public NavigationViewItemBase SelectedItemContainer { get; internal set; }
}
