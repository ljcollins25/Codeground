using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal static class CustomScrollInfoExtensions
{
	public static void ApplyViewport(this ICustomScrollInfo scrollInfo, ref Size size)
	{
		if (scrollInfo != null)
		{
			double? viewportWidth = scrollInfo.ViewportWidth;
			if (viewportWidth.HasValue)
			{
				double num = (size.Width = viewportWidth.GetValueOrDefault());
			}
			viewportWidth = scrollInfo.ViewportHeight;
			if (viewportWidth.HasValue)
			{
				double num2 = (size.Height = viewportWidth.GetValueOrDefault());
			}
		}
	}

	public static void ApplyViewport(this ICustomScrollInfo scrollInfo, ref Rect rect)
	{
		if (scrollInfo != null)
		{
			double? viewportWidth = scrollInfo.ViewportWidth;
			if (viewportWidth.HasValue)
			{
				double num = (rect.Width = viewportWidth.GetValueOrDefault());
			}
			viewportWidth = scrollInfo.ViewportHeight;
			if (viewportWidth.HasValue)
			{
				double num2 = (rect.Height = viewportWidth.GetValueOrDefault());
			}
		}
	}
}
