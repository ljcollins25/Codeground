using Windows.UI.Xaml;

namespace Uno.UI.Helpers;

internal static class RootScale
{
	internal static double GetRasterizationScaleForElement(DependencyObject element)
	{
		return GetRootScaleForElement(element) ?? 1.0;
	}

	internal static double? GetRootScaleForElement(DependencyObject element)
	{
		if (element is FrameworkElement frameworkElement)
		{
			return frameworkElement.GetScaleFactorForLayoutRounding();
		}
		return null;
	}
}
