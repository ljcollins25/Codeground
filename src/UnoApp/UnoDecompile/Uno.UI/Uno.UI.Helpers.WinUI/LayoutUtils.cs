using Windows.Foundation;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers.WinUI;

internal class LayoutUtils
{
	public static double MeasureAndGetDesiredWidthFor(UIElement element, Size availableSize)
	{
		double result = 0.0;
		if (element != null)
		{
			element.Measure(availableSize);
			result = element.DesiredSize.Width;
		}
		return result;
	}

	public static double GetActualWidthFor(UIElement element)
	{
		if (element == null)
		{
			return 0.0;
		}
		return (element as FrameworkElement).ActualWidth;
	}
}
