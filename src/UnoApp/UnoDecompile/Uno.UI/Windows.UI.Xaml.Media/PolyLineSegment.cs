using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class PolyLineSegment : PathSegment
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

	public static DependencyProperty PointsProperty { get; } = DependencyProperty.Register("Points", typeof(PointCollection), typeof(PolyLineSegment), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnPointsChanged));


	public PolyLineSegment()
	{
		Points = new PointCollection();
	}

	private static void OnPointsChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyobject is PolyLineSegment @object)
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
		yield return $"L";
		PointCollection points = Points;
		for (int i = 0; i < points.Count; i++)
		{
			yield return points[i].X;
			yield return points[i].Y;
		}
	}
}
