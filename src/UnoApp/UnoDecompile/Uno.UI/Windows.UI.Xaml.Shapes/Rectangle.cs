using Uno.Extensions;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Rectangle : Shape
{
	private readonly SvgElement _rectangle = new SvgElement("rect");

	public static DependencyProperty RadiusYProperty { get; } = DependencyProperty.Register("RadiusY", typeof(double), typeof(Rectangle), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Rectangle)s).OnRadiusYChangedPartial();
	}));


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

	public static DependencyProperty RadiusXProperty { get; } = DependencyProperty.Register("RadiusX", typeof(double), typeof(Rectangle), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Rectangle)s).OnRadiusXChangedPartial();
	}));


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

	private void OnRadiusXChangedPartial()
	{
		_rectangle.SetAttribute("rx", RadiusX.ToStringInvariant());
	}

	private void OnRadiusYChangedPartial()
	{
		_rectangle.SetAttribute("ry", RadiusY.ToStringInvariant());
	}

	public Rectangle()
	{
		base.SvgChildren.Add(_rectangle);
		InitCommonShapeProperties();
		OnRadiusXChangedPartial();
		OnRadiusYChangedPartial();
	}

	protected override SvgElement GetMainSvgElement()
	{
		return _rectangle;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		double actualStrokeThickness = base.ActualStrokeThickness;
		Rect rect = new Rect(actualStrokeThickness / 2.0, actualStrokeThickness / 2.0, finalSize.Width - actualStrokeThickness, finalSize.Height - actualStrokeThickness).AtLeast(new Size(0.0, 0.0));
		_rectangle.Arrange(rect);
		WindowManagerInterop.SetSvgElementRect(_rectangle.HtmlId, rect);
		_rectangle.Clip = new RectangleGeometry
		{
			Rect = new Rect(0.0, 0.0, finalSize.Width, finalSize.Height)
		};
		return finalSize;
	}
}
