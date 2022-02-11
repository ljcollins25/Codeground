using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class NavigationViewItemHelper
{
	internal const string c_OnLeftNavigationReveal = "OnLeftNavigationReveal";

	internal const string c_OnLeftNavigation = "OnLeftNavigation";

	internal const string c_OnTopNavigationPrimary = "OnTopNavigationPrimary";

	internal const string c_OnTopNavigationPrimaryReveal = "OnTopNavigationPrimaryReveal";

	internal const string c_OnTopNavigationOverflow = "OnTopNavigationOverflow";
}
internal class NavigationViewItemHelper<T>
{
	private object m_owner;

	private UIElement m_selectionIndicator;

	private const string c_selectionIndicatorName = "SelectionIndicator";

	internal NavigationViewItemHelper(object owner)
	{
		m_owner = owner;
	}

	internal UIElement GetSelectionIndicator()
	{
		return m_selectionIndicator;
	}

	internal void Init(FrameworkElement controlProtected)
	{
		m_selectionIndicator = controlProtected.GetTemplateChild("SelectionIndicator") as UIElement;
	}
}
