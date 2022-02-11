using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Uno.Media;

internal class PathStreamGeometryContext : StreamGeometryContext
{
	private readonly List<Point> _points = new List<Point>();

	private readonly StreamGeometry _owner;

	private object bezierPath = new object();

	internal PathStreamGeometryContext(StreamGeometry owner)
	{
		_owner = owner;
	}

	public override void BeginFigure(Point startPoint, bool isFilled, bool isClosed)
	{
		_points.Add(startPoint);
	}

	public override void LineTo(Point point, bool isStroked, bool isSmoothJoin)
	{
		_points.Add(point);
	}

	public override void BezierTo(Point point1, Point point2, Point point3, bool isStroked, bool isSmoothJoin)
	{
		_points.Add(point3);
	}

	public override void QuadraticBezierTo(Point point1, Point point2, bool isStroked, bool isSmoothJoin)
	{
		_points.Add(point2);
	}

	public override void ArcTo(Point point, Size size, double rotationAngle, bool isLargeArc, SweepDirection sweepDirection, bool isStroked, bool isSmoothJoin)
	{
		if (size.Width != size.Height)
		{
			throw new NotImplementedException("The arc must be based on a circle, not an ellipse.");
		}
		Point point2 = _points.Last();
		Point point3 = point;
		double width = size.Width;
		bool sign = isLargeArc != (sweepDirection == SweepDirection.Clockwise);
		Point point4 = CenterFromPointsAndRadius(point2, point3, width, sign);
		double num = Math.Atan2(point2.Y - point4.Y, point2.X - point4.X);
		double num2 = Math.Atan2(point3.Y - point4.Y, point3.X - point4.X);
		Rect rect = new Rect(point4.X - width, point4.Y - width, width * 2.0, width * 2.0);
		_points.Add(point);
	}

	private static Point CenterFromPointsAndRadius(Point point1, Point point2, double radius, bool sign)
	{
		double x = point1.X;
		double y = point1.Y;
		double x2 = point2.X;
		double y2 = point2.Y;
		double num = Math.Sqrt(Math.Pow(x2 - x, 2.0) + Math.Pow(y - y2, 2.0));
		double num2 = (y + y2) / 2.0;
		double num3 = (x + x2) / 2.0;
		double x3 = (sign ? (num3 + Math.Sqrt(Math.Max(0.0, Math.Pow(radius, 2.0) - Math.Pow(num / 2.0, 2.0))) * (y - y2) / num) : (num3 - Math.Sqrt(Math.Max(0.0, Math.Pow(radius, 2.0) - Math.Pow(num / 2.0, 2.0))) * (y - y2) / num));
		double y3 = (sign ? (num2 + Math.Sqrt(Math.Max(0.0, Math.Pow(radius, 2.0) - Math.Pow(num / 2.0, 2.0))) * (x2 - x) / num) : (num2 - Math.Sqrt(Math.Max(0.0, Math.Pow(radius, 2.0) - Math.Pow(num / 2.0, 2.0))) * (x2 - x) / num));
		return new Point(x3, y3);
	}

	public override void PolyLineTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
	{
		foreach (Point point in points)
		{
			LineTo(point, isStroked, isSmoothJoin);
		}
	}

	public override void PolyBezierTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
	{
		throw new NotImplementedException();
	}

	public override void PolyQuadraticBezierTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
	{
		throw new NotImplementedException();
	}

	public override void SetClosedState(bool closed)
	{
		if (bezierPath == null)
		{
		}
	}

	public override void Dispose()
	{
		_owner.Close(bezierPath);
	}
}
