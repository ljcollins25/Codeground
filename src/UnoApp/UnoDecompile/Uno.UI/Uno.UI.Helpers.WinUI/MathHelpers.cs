using Windows.Foundation;

namespace Uno.UI.Helpers.WinUI;

internal static class MathHelpers
{
	internal static bool DoRectsIntersect(Rect a, Rect b)
	{
		if (a.Left < b.Right && a.Top < b.Bottom && a.Right > b.Left)
		{
			return a.Bottom > b.Top;
		}
		return false;
	}

	internal static bool IsEmptyRect(Rect rect)
	{
		if (!rect.IsEmpty && !(rect.Width <= 0.0))
		{
			return rect.Height <= 0.0;
		}
		return true;
	}

	internal static double DotProduct(Point vecA, Point vecB)
	{
		return vecA.X * vecB.X + vecA.Y * vecB.Y;
	}

	internal static bool DoesRectContainRect(Rect container, Rect contained)
	{
		if (container.Left <= contained.Left && container.Top <= contained.Top && container.Right >= contained.Right)
		{
			return container.Bottom >= contained.Bottom;
		}
		return false;
	}

	internal static Point[] RectToPoints(Rect rect)
	{
		Point[] array = new Point[4];
		array[0].X = rect.Left;
		array[0].Y = rect.Top;
		array[1].X = rect.Left;
		array[1].Y = rect.Bottom;
		array[2].X = rect.Right;
		array[2].Y = rect.Bottom;
		array[3].X = rect.Right;
		array[3].Y = rect.Top;
		EnsureCounterClockwiseWindingOrder(array);
		return array;
	}

	internal static bool DoPolygonsIntersect(Point[] pPtPolyA, Point[] pPtPolyB)
	{
		int num = pPtPolyA.Length;
		for (int i = 0; i < pPtPolyA.Length; i++)
		{
			Point vecEdge = pPtPolyA[(i + 1) % num] - pPtPolyA[i];
			if (WhichSide(pPtPolyB, pPtPolyA[i], vecEdge) < 0)
			{
				return false;
			}
		}
		int num2 = pPtPolyB.Length;
		for (int j = 0; j < num2; j++)
		{
			Point vecEdge2 = pPtPolyB[(j + 1) % num2] - pPtPolyB[j];
			if (WhichSide(pPtPolyA, pPtPolyB[j], vecEdge2) < 0)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool IsEntirelyContained(Point[] pPtPolyA, Point[] pPtPolyB)
	{
		int num = pPtPolyB.Length;
		for (uint num2 = 0u; num2 < num; num2++)
		{
			Point vecEdge = pPtPolyB[(long)(num2 + 1) % (long)num] - pPtPolyB[num2];
			if (WhichSide(pPtPolyA, pPtPolyB[num2], vecEdge) <= 0)
			{
				return false;
			}
		}
		return true;
	}

	private static int WhichSide(Point[] pPtPoly, Point ptCurrent, Point vecEdge)
	{
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		Point zero = Point.Zero;
		zero.X = vecEdge.Y;
		zero.Y = 0.0 - vecEdge.X;
		int num4 = pPtPoly.Length;
		for (uint num5 = 0u; num5 < num4; num5++)
		{
			Point vecA = PointSubtract(ptCurrent, pPtPoly[num5]);
			double num6 = DotProduct(vecA, zero);
			if (num6 > 0.0)
			{
				num++;
			}
			else if (num6 < 0.0)
			{
				num2++;
			}
			else
			{
				num3++;
			}
			if ((num != 0 && num2 != 0) || num3 != 0)
			{
				return 0;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return 1;
	}

	private static Point PointSubtract(Point from, Point to)
	{
		return to - from;
	}

	private static bool EnsureCounterClockwiseWindingOrder(Point[] points)
	{
		if (points.Length > 2)
		{
			Point point = PointSubtract(points[0], points[1]);
			Point point2 = PointSubtract(points[1], points[2]);
			int num = points.Length - 1;
			if (point.X * point2.Y - point2.X * point.Y > 0.0)
			{
				for (int i = 0; i < points.Length / 2; i++)
				{
					Point point3 = points[i];
					points[i] = points[num - i];
					points[num - i] = point3;
				}
				return true;
			}
		}
		return false;
	}
}
