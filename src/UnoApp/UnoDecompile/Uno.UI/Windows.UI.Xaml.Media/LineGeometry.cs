using System;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class LineGeometry : Geometry
{
	private SvgElement? _svgElement;

	public static DependencyProperty StartPointProperty { get; } = DependencyProperty.Register("StartPoint", typeof(Point), typeof(LineGeometry), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


	public static DependencyProperty EndPointProperty { get; } = DependencyProperty.Register("EndPoint", typeof(Point), typeof(LineGeometry), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));


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

	public LineGeometry()
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
			if (property == StartPointProperty)
			{
				Point startPoint = StartPoint;
				_svgElement!.SetAttribute(("x1", startPoint.X.ToStringInvariant()), ("y1", startPoint.Y.ToStringInvariant()));
			}
			else if (property == EndPointProperty)
			{
				Point endPoint = EndPoint;
				_svgElement!.SetAttribute(("x2", endPoint.X.ToStringInvariant()), ("y2", endPoint.Y.ToStringInvariant()));
			}
		}
	}

	internal override SvgElement GetSvgElement()
	{
		if (_svgElement == null)
		{
			_svgElement = new SvgElement("line");
			OnPropertyChanged(null, StartPointProperty, null);
			OnPropertyChanged(null, EndPointProperty, null);
		}
		return _svgElement;
	}

	internal override IFormattable ToPathData()
	{
		Point startPoint = StartPoint;
		Point endPoint = EndPoint;
		return $"M {startPoint.X},{startPoint.Y} L {endPoint.X}, {endPoint.Y} Z";
	}
}
