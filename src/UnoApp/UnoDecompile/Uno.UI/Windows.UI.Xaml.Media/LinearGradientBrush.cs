using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class LinearGradientBrush : GradientBrush
{
	public Point StartPoint
	{
		get
		{
			return (Point)GetValue(StartPointProperty);
		}
		set
		{
			SetValue(StartPointProperty, value);
		}
	}

	public static DependencyProperty StartPointProperty { get; } = DependencyProperty.Register("StartPoint", typeof(Point), typeof(LinearGradientBrush), new FrameworkPropertyMetadata(default(Point)));


	public Point EndPoint
	{
		get
		{
			return (Point)GetValue(EndPointProperty);
		}
		set
		{
			SetValue(EndPointProperty, value);
		}
	}

	public static DependencyProperty EndPointProperty { get; } = DependencyProperty.Register("EndPoint", typeof(Point), typeof(LinearGradientBrush), new FrameworkPropertyMetadata(new Point(1.0, 1.0)));


	public LinearGradientBrush()
	{
	}

	public LinearGradientBrush(GradientStopCollection gradientStopCollection, double angle)
	{
		base.GradientStops = gradientStopCollection;
		double num = MathEx.ToRadians(angle);
		EndPoint = new Point(Math.Cos(num), Math.Sin(num));
	}

	internal override string ToCssString(Size size)
	{
		Point point = StartPoint;
		Point point2 = EndPoint;
		if (base.MappingMode != BrushMappingMode.RelativeToBoundingBox)
		{
			point = new Point(point.X * size.Width, point.Y * size.Height);
			point2 = new Point(point2.X * size.Width, point2.Y * size.Height);
		}
		double y = point2.X - point.X;
		double x = point.Y - point2.Y;
		string text = Math.Atan2(y, x).ToStringInvariant();
		string text2 = string.Join(",", base.GradientStops.Select((GradientStop p) => GetColorWithOpacity(p.Color).ToHexString() + " " + (p.Offset * 100.0).ToStringInvariant() + "%"));
		return "linear-gradient(" + text + "rad," + text2 + ")";
	}

	internal override UIElement ToSvgElement()
	{
		SvgElement svgElement = new SvgElement("linearGradient");
		_ = base.MappingMode;
		_ = 1;
		svgElement.SetAttribute(("x1", StartPoint.X.ToStringInvariant()), ("y1", StartPoint.Y.ToStringInvariant()), ("x2", EndPoint.X.ToStringInvariant()), ("y2", EndPoint.Y.ToStringInvariant()));
		IEnumerable<string> values = base.GradientStops.Select((GradientStop stop) => "<stop offset=\"" + stop.Offset.ToStringInvariant() + "\" style=\"stop-color:" + stop.Color.ToHexString() + "\" />");
		svgElement.SetHtmlContent(string.Join(Environment.NewLine, values));
		return svgElement;
	}
}
