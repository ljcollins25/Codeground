using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class PolyBezierSegment : PathSegment
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

	public static DependencyProperty PointsProperty { get; } = DependencyProperty.Register("Points", typeof(PointCollection), typeof(PolyBezierSegment), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnPointsChanged));


	public PolyBezierSegment()
	{
		Points = new PointCollection();
	}

	private static void OnPointsChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is PolyBezierSegment @object)
		{
			if (args.OldValue is PointCollection pointCollection)
			{
				pointCollection.UnRegisterChangedListener(@object.OnPointCollectionChanged);
			}
			if (args.NewValue is PointCollection pointCollection2)
			{
				pointCollection2.RegisterChangedListener(@object.OnPointCollectionChanged);
			}
		}
	}

	private void OnPointCollectionChanged()
	{
		this.InvalidateMeasure();
	}

	internal override IEnumerable<IFormattable> ToDataStream()
	{
		PointCollection points = Points;
		if (points.Count % 3 != 0)
		{
			throw new InvalidOperationException("PolyBezierSegment points must use triplet points.");
		}
		yield return $"C";
		for (int i = 0; i < points.Count; i++)
		{
			yield return points[i].X;
			yield return points[i].Y;
		}
	}
}
