using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class PolyQuadraticBezierSegment : PathSegment
{
	public PointCollection Points
	{
		get
		{
			return (PointCollection)GetValue(PointsProperty);
		}
		set
		{
			SetValue(PointsProperty, value);
		}
	}

	public static DependencyProperty PointsProperty { get; } = DependencyProperty.Register("Points", typeof(PointCollection), typeof(PolyQuadraticBezierSegment), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnPointsChanged));


	public PolyQuadraticBezierSegment()
	{
		Points = new PointCollection();
	}

	private static void OnPointsChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is PolyQuadraticBezierSegment @object)
		{
			if (args.OldValue is PointCollection pointCollection)
			{
				pointCollection.UnRegisterChangedListener(@object.OnPointsChanged);
			}
			if (args.NewValue is PointCollection pointCollection2)
			{
				pointCollection2.RegisterChangedListener(@object.OnPointsChanged);
			}
		}
	}

	private void OnPointsChanged()
	{
		this.InvalidateMeasure();
	}

	internal override IEnumerable<IFormattable> ToDataStream()
	{
		PointCollection points = Points;
		if (points.Count % 2 != 0)
		{
			throw new InvalidOperationException("PolyQuadraticBezierSegment points must use pair points.");
		}
		yield return $"Q";
		for (int i = 0; i < points.Count; i++)
		{
			yield return points[i].X;
			yield return points[i].Y;
		}
	}
}
