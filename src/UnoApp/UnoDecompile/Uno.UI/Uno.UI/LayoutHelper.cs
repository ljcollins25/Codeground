using System;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uno.UI;

internal static class LayoutHelper
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void Deconstruct(this Rect rect, out double x, out double y, out double width, out double height)
	{
		x = rect.X;
		y = rect.Y;
		width = rect.Width;
		height = rect.Height;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void Deconstruct(this Size size, out double width, out double height)
	{
		width = size.Width;
		height = size.Height;
	}

	internal static Size GetMinSize(this IFrameworkElement e)
	{
		return new Size(e.MinWidth, e.MinHeight).NumberOrDefault(new Size(0.0, 0.0));
	}

	internal static Size GetMaxSize(this IFrameworkElement e)
	{
		return new Size(e.MaxWidth, e.MaxHeight).NumberOrDefault(new Size(double.PositiveInfinity, double.PositiveInfinity));
	}

	internal static (Size min, Size max) GetMinMax(this IFrameworkElement e)
	{
		Size value = new Size(e.Width, e.Height);
		Size minSize = e.GetMinSize();
		Size maxSize = e.GetMaxSize();
		minSize = value.NumberOrDefault(new Size(0.0, 0.0)).AtMost(maxSize).AtLeast(minSize);
		maxSize = value.NumberOrDefault(new Size(double.PositiveInfinity, double.PositiveInfinity)).AtMost(maxSize).AtLeast(minSize);
		return (minSize, maxSize);
	}

	internal static Size ApplySizeConstraints(this IFrameworkElement e, Size forSize)
	{
		var (least, most) = e.GetMinMax();
		return forSize.AtMost(most).AtLeast(least);
	}

	internal static Size ApplySizeConstraints(this IFrameworkElement e, Size forSize, Size extraPadding)
	{
		var (left, left2) = e.GetMinMax();
		return forSize.AtMost(left2.Subtract(extraPadding)).AtLeast(left.Subtract(extraPadding));
	}

	internal static Size GetMarginSize(this IFrameworkElement frameworkElement)
	{
		Thickness margin = frameworkElement.Margin;
		if (margin == default(Thickness))
		{
			return default(Size);
		}
		double width = margin.Left + margin.Right;
		double height = margin.Top + margin.Bottom;
		return new Size(width, height);
	}

	internal static (Point offset, bool overflow) GetAlignmentOffset(this IFrameworkElement e, Size clientSize, Size renderSize)
	{
		Point item = new Point(clientSize.Width - renderSize.Width, clientSize.Height - renderSize.Height);
		bool item2 = false;
		switch (e.HorizontalAlignment)
		{
		case HorizontalAlignment.Stretch:
			if (renderSize.Width > clientSize.Width)
			{
				item.X = 0.0;
				item2 = true;
				break;
			}
			goto case HorizontalAlignment.Center;
		case HorizontalAlignment.Left:
			item.X = 0.0;
			break;
		case HorizontalAlignment.Center:
			item.X *= 0.5;
			break;
		case HorizontalAlignment.Right:
			item.X *= 1.0;
			break;
		}
		switch (e.VerticalAlignment)
		{
		case VerticalAlignment.Stretch:
			if (renderSize.Height > clientSize.Height)
			{
				item.Y = 0.0;
				item2 = true;
				break;
			}
			goto case VerticalAlignment.Center;
		case VerticalAlignment.Top:
			item.Y = 0.0;
			break;
		case VerticalAlignment.Center:
			item.Y *= 0.5;
			break;
		case VerticalAlignment.Bottom:
			item.Y *= 1.0;
			break;
		}
		return (item, item2);
	}

	internal static Size Min(Size val1, Size val2)
	{
		return new Size(Math.Min(val1.Width, val2.Width), Math.Min(val1.Height, val2.Height));
	}

	internal static Size Max(Size val1, Size val2)
	{
		return new Size(Math.Max(val1.Width, val2.Width), Math.Max(val1.Height, val2.Height));
	}

	internal static Size Add(this Size left, Size right)
	{
		if (right == default(Size))
		{
			return left;
		}
		return new Size(left.Width + right.Width, left.Height + right.Height);
	}

	internal static Size Add(this Size left, Thickness right)
	{
		if (right == default(Thickness))
		{
			return left;
		}
		return new Size(left.Width + right.Left + right.Right, left.Height + right.Top + right.Bottom);
	}

	internal static Size Subtract(this Size left, Size right)
	{
		if (right == default(Size))
		{
			return left;
		}
		return new Size(left.Width - right.Width, left.Height - right.Height);
	}

	internal static Size Subtract(this Size left, Thickness right)
	{
		if (right == Thickness.Empty)
		{
			return left;
		}
		return new Size(left.Width - right.Left - right.Right, left.Height - right.Top - right.Bottom);
	}

	internal static Size Multiply(this Size left, double right)
	{
		return new Size(left.Width * right, left.Height * right);
	}

	internal static Size Divide(this Size left, double right)
	{
		return new Size(left.Width / right, left.Height / right);
	}

	internal static Rect InflateBy(this Rect left, Thickness right)
	{
		double val = right.Left + left.Width + right.Right;
		double val2 = right.Top + left.Height + right.Bottom;
		double x = left.X - right.Left;
		double y = left.Y - right.Top;
		return new Rect(x, y, Math.Max(val, 0.0), Math.Max(val2, 0.0));
	}

	internal static Rect DeflateBy(this Rect left, Thickness right)
	{
		return left.InflateBy(right.GetInverse());
	}

	internal static double NumberOrDefault(this double value, double defaultValue)
	{
		if (!double.IsNaN(value))
		{
			return value;
		}
		return defaultValue;
	}

	internal static Size NumberOrDefault(this Size value, Size defaultValue)
	{
		return new Size(value.Width.NumberOrDefault(defaultValue.Width), value.Height.NumberOrDefault(defaultValue.Height));
	}

	internal static double FiniteOrDefault(this double value, double defaultValue)
	{
		if (!double.IsInfinity(value) && !double.IsNaN(value))
		{
			return value;
		}
		return defaultValue;
	}

	internal static Point FiniteOrDefault(this Point value, Point defaultValue)
	{
		return new Point(value.X.FiniteOrDefault(defaultValue.X), value.Y.FiniteOrDefault(defaultValue.Y));
	}

	internal static Size FiniteOrDefault(this Size value, Size defaultValue)
	{
		return new Size(value.Width.FiniteOrDefault(defaultValue.Width), value.Height.FiniteOrDefault(defaultValue.Height));
	}

	internal static Rect FiniteOrDefault(this Rect value, Rect defaultValue)
	{
		return new Rect(value.X.FiniteOrDefault(defaultValue.X), value.Y.FiniteOrDefault(defaultValue.Y), value.Width.FiniteOrDefault(defaultValue.Width), value.Height.FiniteOrDefault(defaultValue.Height));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double AtMost(this double value, double most)
	{
		return Math.Min(value, most);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Size AtMost(this Size value, Size most)
	{
		return new Size(value.Width.AtMost(most.Width), value.Height.AtMost(most.Height));
	}

	internal static Rect AtMost(this Rect value, Size most)
	{
		return new Rect(value.Location, value.Size.AtMost(most));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static double AtLeast(this double value, double least)
	{
		return Math.Max(value, least);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Size AtLeast(this Size value, Size least)
	{
		return new Size(value.Width.AtLeast(least.Width), value.Height.AtLeast(least.Height));
	}

	internal static Rect AtLeast(this Rect value, Size least)
	{
		return new Rect(value.Location, value.Size.AtLeast(least));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Size AtLeastZero(this Size value)
	{
		return new Size(value.Width.AtLeast(0.0), value.Height.AtLeast(0.0));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Rect? IntersectWith(this Rect rect1, Rect rect2)
	{
		if (rect1.Equals(rect2))
		{
			return rect1;
		}
		double num = Math.Max(rect1.Left, rect2.Left);
		double num2 = Math.Min(rect1.Right, rect2.Right);
		double num3 = Math.Max(rect1.Top, rect2.Top);
		double num4 = Math.Min(rect1.Bottom, rect2.Bottom);
		if (num2 >= num && num4 >= num3)
		{
			return new Rect(num, num3, num2 - num, num4 - num3);
		}
		return null;
	}

	internal static Rect UnionWith(this Rect rect1, Rect rect2)
	{
		rect1.Union(rect2);
		return rect1;
	}

	internal static bool IsEnclosedBy(this Rect enclosee, Rect encloser)
	{
		if (enclosee.Equals(encloser))
		{
			return true;
		}
		if (enclosee.Left >= encloser.Left && enclosee.Right <= encloser.Right && enclosee.Top >= encloser.Top)
		{
			return enclosee.Bottom <= encloser.Bottom;
		}
		return false;
	}

	internal static double AspectRatio(this Rect rect)
	{
		return rect.Size.AspectRatio();
	}

	internal static double AspectRatio(this Size size)
	{
		double width = size.Width;
		double height = size.Height;
		if (width <= 0.0)
		{
			if (width == double.NegativeInfinity)
			{
				return -1.0;
			}
			if (width == 0.0)
			{
				return 1.0;
			}
		}
		else
		{
			if (width == double.PositiveInfinity)
			{
				return 1.0;
			}
			if (double.IsNaN(width))
			{
				return 1.0;
			}
		}
		if (height <= 0.0)
		{
			if (height == double.NegativeInfinity)
			{
				return -1.0;
			}
			if (height == 0.0)
			{
				return 1.0;
			}
		}
		else
		{
			if (height == 1.0)
			{
				return width;
			}
			if (height == double.PositiveInfinity)
			{
				return 1.0;
			}
			if (double.IsNaN(height))
			{
				return 1.0;
			}
		}
		return width / height;
	}

	internal static Rect GetBoundsRectRelativeTo(this FrameworkElement element, FrameworkElement relativeTo)
	{
		GeneralTransform generalTransform = element.TransformToVisual(relativeTo);
		Rect rect = new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight);
		return generalTransform.TransformBounds(rect);
	}

	internal static Rect GetAbsoluteBoundsRect(this FrameworkElement element)
	{
		FrameworkElement relativeTo = Window.Current.Content as FrameworkElement;
		return element.GetBoundsRectRelativeTo(relativeTo);
	}
}
