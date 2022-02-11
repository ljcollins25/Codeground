using System;
using System.Collections.Generic;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class BezierSegment : PathSegment
{
	public Point Point1
	{
		get
		{
			return (Point)GetValue(Point1Property);
		}
		set
		{
			SetValue(Point1Property, value);
		}
	}

	public static DependencyProperty Point1Property { get; } = DependencyProperty.Register("Point1", typeof(Point), typeof(BezierSegment), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public Point Point2
	{
		get
		{
			return (Point)GetValue(Point2Property);
		}
		set
		{
			SetValue(Point2Property, value);
		}
	}

	public static DependencyProperty Point2Property { get; } = DependencyProperty.Register("Point2", typeof(Point), typeof(BezierSegment), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public Point Point3
	{
		get
		{
			return (Point)GetValue(Point3Property);
		}
		set
		{
			SetValue(Point3Property, value);
		}
	}

	public static DependencyProperty Point3Property { get; } = DependencyProperty.Register("Point3", typeof(Point), typeof(BezierSegment), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	internal override IEnumerable<IFormattable> ToDataStream()
	{
		yield return $"C";
		yield return Point1.X;
		yield return Point1.Y;
		yield return Point2.X;
		yield return Point2.Y;
		yield return Point3.X;
		yield return Point3.Y;
	}
}
