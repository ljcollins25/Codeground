using System;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Microsoft.UI.Xaml.Media;

[ContentProperty(Name = "GradientStops")]
public sealed class RadialGradientBrush : GradientBrush
{
	public static DependencyProperty CenterProperty { get; } = DependencyProperty.Register("Center", typeof(Point), typeof(RadialGradientBrush), new FrameworkPropertyMetadata(new Point(0.5, 0.5)));


	public Point Center
	{
		get
		{
			return (Point)GetValue(CenterProperty);
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	public static DependencyProperty RadiusXProperty { get; } = DependencyProperty.Register("RadiusX", typeof(double), typeof(RadialGradientBrush), new FrameworkPropertyMetadata(0.5));


	public double RadiusX
	{
		get
		{
			return (double)GetValue(RadiusXProperty);
		}
		set
		{
			SetValue(RadiusXProperty, value);
		}
	}

	public static DependencyProperty RadiusYProperty { get; } = DependencyProperty.Register("RadiusY", typeof(double), typeof(RadialGradientBrush), new FrameworkPropertyMetadata(0.5));


	public double RadiusY
	{
		get
		{
			return (double)GetValue(RadiusYProperty);
		}
		set
		{
			SetValue(RadiusYProperty, value);
		}
	}

	public static DependencyProperty GradientOriginProperty { get; } = DependencyProperty.Register("GradientOrigin", typeof(Point), typeof(RadialGradientBrush), new FrameworkPropertyMetadata(new Point(0.5, 0.5)));


	[NotImplemented]
	public Point GradientOrigin
	{
		get
		{
			return (Point)GetValue(GradientOriginProperty);
		}
		set
		{
			SetValue(GradientOriginProperty, value);
		}
	}

	public static DependencyProperty InterpolationSpaceProperty { get; } = DependencyProperty.Register("InterpolationSpace", typeof(CompositionColorSpace), typeof(RadialGradientBrush), new FrameworkPropertyMetadata(CompositionColorSpace.Auto));


	[NotImplemented]
	public CompositionColorSpace InterpolationSpace
	{
		get
		{
			return (CompositionColorSpace)GetValue(InterpolationSpaceProperty);
		}
		set
		{
			SetValue(InterpolationSpaceProperty, value);
		}
	}

	internal override string ToCssString(Size size)
	{
		Point point = Center;
		double num = RadiusX;
		double num2 = RadiusY;
		if (base.MappingMode != BrushMappingMode.RelativeToBoundingBox)
		{
			point = new Point(point.X * size.Width, Center.Y * size.Height);
			num *= size.Width;
			num2 *= size.Height;
		}
		string arg = string.Join(",", base.GradientStops.Select((GradientStop p) => GetColorWithOpacity(p.Color).ToHexString() + " " + (p.Offset * 100.0).ToStringInvariant() + "%"));
		return $"radial-gradient(ellipse farthest-side at {num * 100.0}% {num2 * 100.0}%, {arg})";
	}

	internal override UIElement ToSvgElement()
	{
		Point center = Center;
		double radiusX = RadiusX;
		double radiusY = RadiusY;
		_ = base.MappingMode;
		_ = 1;
		SvgElement svgElement = new SvgElement("radialGradient");
		double number = (radiusX + radiusY) / 2.0;
		svgElement.SetAttribute(("cx", center.X.ToStringInvariant()), ("cy", center.Y.ToStringInvariant()), ("r", number.ToStringInvariant()));
		IEnumerable<string> values = base.GradientStops.Select((GradientStop stop) => "<stop offset=\"" + stop.Offset.ToStringInvariant() + "\" style=\"stop-color:" + stop.Color.ToHexString() + "\" />");
		svgElement.SetHtmlContent(string.Join(Environment.NewLine, values));
		return svgElement;
	}
}
