using System;
using System.Collections.Generic;
using Uno.Extensions;
using Uno.Media;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

internal static class GeometryHelper
{
	public static StreamGeometry ToStreamGeometry(this Geometry geometry)
	{
		if (!(geometry is StreamGeometry result))
		{
			StreamGeometry streamGeometry = new StreamGeometry();
			if (!(geometry is GeometryGroup geometryGroup))
			{
				if (geometry is PathGeometry pathGeometry)
				{
					streamGeometry.FillRule = pathGeometry.FillRule;
				}
			}
			else
			{
				streamGeometry.FillRule = geometryGroup.FillRule;
			}
			using StreamGeometryContext ctx = streamGeometry.Open();
			ctx.Write(geometry);
			return streamGeometry;
		}
		return result;
	}

	public static void Write(this StreamGeometryContext ctx, Geometry geometry)
	{
		if (!(geometry is GeometryGroup geometryGroup))
		{
			if (!(geometry is PathGeometry pathGeometry))
			{
				if (!(geometry is LineGeometry lineGeometry))
				{
					if (!(geometry is RectangleGeometry rectangleGeometry))
					{
						if (geometry is EllipseGeometry ellipseGeometry)
						{
							ctx.Write(ellipseGeometry);
						}
					}
					else
					{
						ctx.Write(rectangleGeometry);
					}
				}
				else
				{
					ctx.Write(lineGeometry);
				}
			}
			else
			{
				ctx.Write(pathGeometry);
			}
		}
		else
		{
			ctx.Write(geometryGroup);
		}
	}

	public static void Write(this StreamGeometryContext ctx, GeometryGroup geometryGroup)
	{
		geometryGroup.Children?.ForEach((Action<Geometry>)ctx.Write);
	}

	public static void Write(this StreamGeometryContext ctx, PathGeometry pathGeometry)
	{
		((IEnumerable<PathFigure>)pathGeometry.Figures).ForEach((Action<PathFigure>)ctx.Write);
	}

	public static void Write(this StreamGeometryContext ctx, LineGeometry lineGeometry)
	{
		ctx.BeginFigure(lineGeometry.StartPoint, isFilled: false, isClosed: false);
		ctx.LineTo(lineGeometry.EndPoint, isStroked: true, isSmoothJoin: false);
		ctx.SetClosedState(closed: true);
	}

	public static void Write(this StreamGeometryContext ctx, RectangleGeometry rectangleGeometry)
	{
		Rect rect = rectangleGeometry.Rect;
		Point location = rect.Location;
		Point point = new Point(rect.Right, rect.Top);
		Point point2 = new Point(rect.Left, rect.Bottom);
		Point point3 = new Point(rect.Right, rect.Bottom);
		ctx.BeginFigure(location, isFilled: true, isClosed: true);
		ctx.LineTo(point, isStroked: true, isSmoothJoin: false);
		ctx.LineTo(point3, isStroked: true, isSmoothJoin: false);
		ctx.LineTo(point2, isStroked: true, isSmoothJoin: false);
		ctx.LineTo(location, isStroked: true, isSmoothJoin: false);
		ctx.SetClosedState(closed: true);
	}

	public static void Write(this StreamGeometryContext ctx, EllipseGeometry ellipseGeometry)
	{
	}

	public static void Write(this StreamGeometryContext ctx, PathFigure pathFigure)
	{
		ctx.BeginFigure(pathFigure.StartPoint, pathFigure.IsFilled, pathFigure.IsClosed);
		((IEnumerable<PathSegment>)pathFigure.Segments).ForEach((Action<PathSegment>)ctx.Write);
		ctx.SetClosedState(pathFigure.IsClosed);
	}

	public static void Write(this StreamGeometryContext ctx, PathSegment pathSegment)
	{
		if (!(pathSegment is ArcSegment arcSegment))
		{
			if (!(pathSegment is BezierSegment bezierSegment))
			{
				if (!(pathSegment is PolyBezierSegment polyBezierSegment))
				{
					if (!(pathSegment is PolyLineSegment polyLineSegment))
					{
						if (!(pathSegment is QuadraticBezierSegment quadraticBezierSegment))
						{
							if (!(pathSegment is PolyQuadraticBezierSegment polyQuadraticBezierSegment))
							{
								if (pathSegment is LineSegment lineSegment)
								{
									ctx.LineTo(lineSegment.Point, isStroked: false, isSmoothJoin: false);
								}
							}
							else
							{
								ctx.PolyQuadraticBezierTo(polyQuadraticBezierSegment.Points, isStroked: false, isSmoothJoin: false);
							}
						}
						else
						{
							ctx.QuadraticBezierTo(quadraticBezierSegment.Point1, quadraticBezierSegment.Point2, isStroked: false, isSmoothJoin: false);
						}
					}
					else
					{
						ctx.PolyLineTo(polyLineSegment.Points, isStroked: false, isSmoothJoin: false);
					}
				}
				else
				{
					ctx.PolyBezierTo(polyBezierSegment.Points, isStroked: false, isSmoothJoin: false);
				}
			}
			else
			{
				ctx.BezierTo(bezierSegment.Point1, bezierSegment.Point2, bezierSegment.Point3, isStroked: false, isSmoothJoin: false);
			}
		}
		else
		{
			ctx.ArcTo(arcSegment.Point, arcSegment.Size, arcSegment.RotationAngle, arcSegment.IsLargeArc, arcSegment.SweepDirection, isStroked: false, isSmoothJoin: false);
		}
	}
}
