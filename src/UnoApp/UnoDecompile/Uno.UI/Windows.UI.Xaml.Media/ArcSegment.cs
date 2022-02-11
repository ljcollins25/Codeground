using System;
using System.Collections.Generic;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class ArcSegment : PathSegment
{
	public SweepDirection SweepDirection
	{
		get
		{
			return (SweepDirection)GetValue(SweepDirectionProperty);
		}
		set
		{
			SetValue(SweepDirectionProperty, value);
		}
	}

	public static DependencyProperty SweepDirectionProperty { get; } = DependencyProperty.Register("SweepDirection", typeof(SweepDirection), typeof(ArcSegment), new FrameworkPropertyMetadata(SweepDirection.Counterclockwise, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public Size Size
	{
		get
		{
			return (Size)GetValue(SizeProperty);
		}
		set
		{
			SetValue(SizeProperty, value);
		}
	}

	public static DependencyProperty SizeProperty { get; } = DependencyProperty.Register("Size", typeof(Size), typeof(ArcSegment), new FrameworkPropertyMetadata(default(Size), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public double RotationAngle
	{
		get
		{
			return (double)GetValue(RotationAngleProperty);
		}
		set
		{
			SetValue(RotationAngleProperty, value);
		}
	}

	public static DependencyProperty RotationAngleProperty { get; } = DependencyProperty.Register("RotationAngle", typeof(double), typeof(ArcSegment), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));


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

	public static DependencyProperty PointProperty { get; } = DependencyProperty.Register("Point", typeof(Point), typeof(ArcSegment), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public bool IsLargeArc
	{
		get
		{
			return (bool)GetValue(IsLargeArcProperty);
		}
		set
		{
			SetValue(IsLargeArcProperty, value);
		}
	}

	public static DependencyProperty IsLargeArcProperty { get; } = DependencyProperty.Register("IsLargeArc", typeof(bool), typeof(ArcSegment), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));


	internal override IEnumerable<IFormattable> ToDataStream()
	{
		yield return $"A";
		yield return Size.Width;
		yield return Size.Height;
		yield return RotationAngle;
		IFormattable formattable2;
		if (!IsLargeArc)
		{
			IFormattable formattable = $"0";
			formattable2 = formattable;
		}
		else
		{
			IFormattable formattable = $"1";
			formattable2 = formattable;
		}
		yield return formattable2;
		IFormattable formattable3;
		if (SweepDirection != SweepDirection.Clockwise)
		{
			IFormattable formattable = $"0";
			formattable3 = formattable;
		}
		else
		{
			IFormattable formattable = $"1";
			formattable3 = formattable;
		}
		yield return formattable3;
		yield return Point.X;
		yield return Point.Y;
	}
}
