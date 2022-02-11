using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

internal class CachedVisualTreeHelpers
{
	public static Rect GetLayoutSlot(FrameworkElement element)
	{
		return LayoutInformation.GetLayoutSlot(element);
	}

	public static DependencyObject GetParent(DependencyObject child)
	{
		return VisualTreeHelper.GetParent(child);
	}

	public static IDataTemplateComponent GetDataTemplateComponent(UIElement element)
	{
		return XamlBindingHelper.GetDataTemplateComponent(element);
	}
}
