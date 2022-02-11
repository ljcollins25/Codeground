using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewItemInvokedEventArgs
{
	public object InvokedItem { get; internal set; }

	public bool IsSettingsInvoked { get; internal set; }

	public NavigationViewItemBase InvokedItemContainer { get; internal set; }

	public NavigationTransitionInfo RecommendedNavigationTransitionInfo { get; internal set; }
}
