using System;
using System.Collections.Generic;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class LineSegment : PathSegment
{
	public Point Point
	{
		get
		{
			return (Point)GetValue(PointProperty);
		}
		set
		{
			SetValue(PointProperty, value);
		}
	}

	public static DependencyProperty PointProperty { get; } = DependencyProperty.Register("Point", typeof(Point), typeof(LineSegment), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	internal override IEnumerable<IFormattable> ToDataStream()
	{
		yield return $"L";
		yield return Point.X;
		yield return Point.Y;
	}
}
