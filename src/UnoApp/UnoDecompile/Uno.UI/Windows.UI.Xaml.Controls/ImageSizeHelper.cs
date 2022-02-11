using System;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

internal static class ImageSizeHelper
{
	public static Size MeasureSource(this Image image, Size finalSize, Size imageSize)
	{
		switch (image.Stretch)
		{
		case Stretch.UniformToFill:
		{
			double num3 = imageSize.AspectRatio();
			double num4 = finalSize.AspectRatio();
			if (num3 <= num4)
			{
				imageSize.Width = finalSize.Width;
				imageSize.Height = finalSize.Width / num3;
			}
			else
			{
				imageSize.Width = finalSize.Height * num3;
				imageSize.Height = finalSize.Height;
			}
			break;
		}
		case Stretch.Uniform:
		{
			double num = imageSize.AspectRatio();
			double num2 = finalSize.AspectRatio();
			if (num <= num2)
			{
				imageSize.Width = finalSize.Height * num;
				imageSize.Height = finalSize.Height;
			}
			else
			{
				imageSize.Width = finalSize.Width;
				imageSize.Height = finalSize.Width / num;
			}
			break;
		}
		case Stretch.Fill:
			imageSize = finalSize;
			break;
		}
		return imageSize;
	}

	public static Rect ArrangeSource(this Image image, Size finalSize, Size containerSize)
	{
		Rect result = new Rect(default(Point), containerSize);
		Stretch stretch = image.Stretch;
		HorizontalAlignment horizontalAlignment = image.HorizontalAlignment;
		if ((stretch == Stretch.None || stretch == Stretch.UniformToFill) && finalSize.Width <= result.Width && horizontalAlignment == HorizontalAlignment.Stretch)
		{
			horizontalAlignment = HorizontalAlignment.Left;
		}
		if (horizontalAlignment == HorizontalAlignment.Stretch && result.Width < finalSize.Width)
		{
			horizontalAlignment = HorizontalAlignment.Center;
		}
		switch (horizontalAlignment)
		{
		case HorizontalAlignment.Left:
			result.X = 0.0;
			break;
		case HorizontalAlignment.Right:
			result.X = finalSize.Width - result.Width;
			break;
		case HorizontalAlignment.Center:
		case HorizontalAlignment.Stretch:
			result.X = (finalSize.Width - result.Width) * 0.5;
			break;
		}
		VerticalAlignment verticalAlignment = image.VerticalAlignment;
		if ((stretch == Stretch.None || stretch == Stretch.UniformToFill) && finalSize.Height <= result.Height && verticalAlignment == VerticalAlignment.Stretch)
		{
			verticalAlignment = VerticalAlignment.Top;
		}
		if (verticalAlignment == VerticalAlignment.Stretch && result.Height < finalSize.Height)
		{
			verticalAlignment = VerticalAlignment.Center;
		}
		switch (verticalAlignment)
		{
		case VerticalAlignment.Top:
			result.Y = 0.0;
			break;
		case VerticalAlignment.Bottom:
			result.Y = finalSize.Height - result.Height;
			break;
		case VerticalAlignment.Center:
		case VerticalAlignment.Stretch:
			result.Y = (finalSize.Height - result.Height) * 0.5;
			break;
		}
		return result;
	}

	public static (double x, double y) BuildScale(this Image image, Size destinationSize, Size sourceSize)
	{
		return BuildScale(image.Stretch, destinationSize, sourceSize);
	}

	internal static (double x, double y) BuildScale(Stretch stretch, Size destinationSize, Size sourceSize)
	{
		if (stretch != 0)
		{
			(double, double) tuple = (destinationSize.Width / sourceSize.Width, destinationSize.Height / sourceSize.Height);
			if (double.IsInfinity(tuple.Item1))
			{
				if (double.IsInfinity(tuple.Item2))
				{
					return (1.0, 1.0);
				}
				tuple.Item1 = tuple.Item2;
			}
			else if (double.IsInfinity(tuple.Item2))
			{
				(tuple.Item2, _) = tuple;
			}
			switch (stretch)
			{
			case Stretch.UniformToFill:
			{
				double num2 = Math.Max(tuple.Item1, tuple.Item2);
				tuple = (num2, num2);
				break;
			}
			case Stretch.Uniform:
			{
				double num = Math.Min(tuple.Item1, tuple.Item2);
				tuple = (num, num);
				break;
			}
			}
			double num3;
			if (!double.IsNaN(tuple.Item1))
			{
				(num3, _) = tuple;
			}
			else
			{
				num3 = 1.0;
			}
			double item = num3;
			double item2 = (double.IsNaN(tuple.Item2) ? 1.0 : tuple.Item2);
			return (item, item2);
		}
		return (1.0, 1.0);
	}

	public static Size AdjustSize(this Image image, Size availableSize, Size measuredSize)
	{
		return AdjustSize(image.Stretch, image.ApplySizeConstraints(availableSize), measuredSize);
	}

	internal static Size AdjustSize(Stretch stretch, Size availableSize, Size measuredSize)
	{
		(double, double) tuple = BuildScale(stretch, availableSize, measuredSize);
		Size value = new Size(measuredSize.Width * tuple.Item1, measuredSize.Height * tuple.Item2);
		return value.AtMost(availableSize);
	}
}
