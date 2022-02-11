using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewSelectionChangedEventArgs
{
	public object SelectedItem { get; internal set; }

	public bool IsSettingsSelected { get; internal set; }

	public NavigationViewItemBase SelectedItemContainer { get; internal set; }

	public NavigationTransitionInfo RecommendedNavigationTransitionInfo { get; internal set; }
}
