using System;
using Windows.Foundation;

namespace Windows.UI.Xaml;

public class RectHelper
{
	public static Rect Empty { get; } = new Rect(0.0, 0.0, 0.0, 0.0);


	public static Rect FromCoordinatesAndDimensions(float x, float y, float width, float height)
	{
		return new Rect(x, y, width, height);
	}

	public static Rect FromPoints(Point point1, Point point2)
	{
		return new Rect(point1, point2);
	}

	public static Rect FromLocationAndSize(Point location, Size size)
	{
		return new Rect(location, size);
	}

	public static bool GetIsEmpty(Rect target)
	{
		return target.Equals(Empty);
	}

	public static float GetBottom(Rect target)
	{
		return (float)target.Bottom;
	}

	public static float GetLeft(Rect target)
	{
		return (float)target.Left;
	}

	public static float GetRight(Rect target)
	{
		return (float)target.Right;
	}

	public static float GetTop(Rect target)
	{
		return (float)target.Top;
	}

	public static bool Contains(Rect target, Point point)
	{
		return target.Contains(point);
	}

	public static bool Equals(Rect target, Rect value)
	{
		return target.Equals(value);
	}

	public static Rect Intersect(Rect target, Rect rect)
	{
		double num = Math.Max(target.Left, rect.Left);
		double num2 = Math.Min(target.Right, rect.Right);
		if (num > num2)
		{
			return Empty;
		}
		double num3 = Math.Max(target.Top, rect.Top);
		double num4 = Math.Min(target.Bottom, rect.Bottom);
		if (num3 > num4)
		{
			return Empty;
		}
		return new Rect(num, num3, num2 - num, num4 - num3);
	}

	public static Rect Union(Rect target, Point point)
	{
		double num = Math.Min(target.Left, point.X);
		double num2 = Math.Max(target.Right, point.X);
		double num3 = Math.Min(target.Top, point.Y);
		double num4 = Math.Max(target.Bottom, point.Y);
		return new Rect(num, num3, num2 - num, num4 - num3);
	}

	public static Rect Union(Rect target, Rect rect)
	{
		double num = Math.Min(target.Left, rect.Left);
		double num2 = Math.Max(target.Right, rect.Right);
		double num3 = Math.Min(target.Top, rect.Top);
		double num4 = Math.Max(target.Bottom, rect.Bottom);
		return new Rect(num, num3, num2 - num, num4 - num3);
	}
}
