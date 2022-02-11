namespace Windows.UI.Xaml.Controls;

public class NavigationViewItemHelper
{
	public static readonly string c_OnLeftNavigationReveal = "OnLeftNavigationReveal";

	public static readonly string c_OnLeftNavigation = "OnLeftNavigation";

	public static readonly string c_OnTopNavigationPrimary = "OnTopNavigationPrimary";

	public static readonly string c_OnTopNavigationPrimaryReveal = "OnTopNavigationPrimaryReveal";

	public static readonly string c_OnTopNavigationOverflow = "OnTopNavigationOverflow";
}
public class NavigationViewItemHelper<T> where T : Control
{
	private static string c_selectionIndicatorName = "SelectionIndicator";

	private UIElement m_selectionIndicator;

	public UIElement GetSelectionIndicator()
	{
		return m_selectionIndicator;
	}

	public void Init(T item)
	{
		m_selectionIndicator = item.GetTemplateChild(c_selectionIndicatorName) as UIElement;
	}
}
