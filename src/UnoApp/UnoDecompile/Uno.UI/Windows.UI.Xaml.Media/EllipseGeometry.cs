using System;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class EllipseGeometry : Geometry
{
	private SvgElement? _svgElement;

	public static DependencyProperty CenterProperty { get; } = DependencyProperty.Register("Center", typeof(Point), typeof(EllipseGeometry), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public static DependencyProperty RadiusXProperty { get; } = DependencyProperty.Register("RadiusX", typeof(double), typeof(EllipseGeometry), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public static DependencyProperty RadiusYProperty { get; } = DependencyProperty.Register("RadiusY", typeof(double), typeof(EllipseGeometry), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));


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

	public EllipseGeometry()
	{
		InitPartials();
	}

	private void InitPartials()
	{
		this.RegisterDisposablePropertyChangedCallback(OnPropertyChanged);
	}

	private void OnPropertyChanged(ManagedWeakReference? instance, DependencyProperty property, DependencyPropertyChangedEventArgs? args)
	{
		if (_svgElement != null)
		{
			if (property == CenterProperty)
			{
				Point center = Center;
				_svgElement!.SetAttribute(("cx", center.X.ToStringInvariant()), ("cy", center.Y.ToStringInvariant()));
				_svgElement!.InvalidateMeasure();
			}
			else if (property == RadiusXProperty)
			{
				_svgElement!.SetAttribute("rx", RadiusX.ToStringInvariant());
				_svgElement!.InvalidateMeasure();
			}
			else if (property == RadiusYProperty)
			{
				_svgElement!.SetAttribute("ry", RadiusY.ToStringInvariant());
				_svgElement!.InvalidateMeasure();
			}
		}
	}

	internal override SvgElement GetSvgElement()
	{
		if (_svgElement == null)
		{
			_svgElement = new SvgElement("ellipse");
			OnPropertyChanged(null, CenterProperty, null);
			OnPropertyChanged(null, RadiusXProperty, null);
			OnPropertyChanged(null, RadiusYProperty, null);
		}
		return _svgElement;
	}

	internal override IFormattable ToPathData()
	{
		double x = Center.X;
		double y = Center.Y;
		double radiusX = RadiusX;
		double radiusY = RadiusY;
		return $"M{x},{y - radiusY} A{radiusX},{radiusY} 0 0 0 {x},{y + radiusY} A{radiusX},{radiusY} 0 0 0 {x},{y - radiusY} Z";
	}
}
