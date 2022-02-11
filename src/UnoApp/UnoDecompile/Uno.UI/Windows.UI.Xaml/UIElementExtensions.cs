namespace Windows.UI.Xaml;

public static class UIElementExtensions
{
	public static UIElement GetVisualTreeParent(this UIElement uiElement)
	{
		return (uiElement as FrameworkElement)?.VisualParent;
	}
}
