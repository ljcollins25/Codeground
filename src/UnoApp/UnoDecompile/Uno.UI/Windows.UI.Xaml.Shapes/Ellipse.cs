using Uno.Extensions;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

public class Ellipse : ArbitraryShapeBase
{
	private readonly SvgElement _ellipse = new SvgElement("ellipse");

	public Ellipse()
	{
		base.SvgChildren.Add(_ellipse);
		InitCommonShapeProperties();
		RegisterPropertyChangedCallback(Shape.StrokeProperty, OnStrokeChanged);
	}

	private void OnStrokeChanged(DependencyObject sender, DependencyProperty dp)
	{
		InvalidateArrange();
	}

	protected override SvgElement GetMainSvgElement()
	{
		return _ellipse;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size size = this.ApplySizeConstraints(finalSize);
		double num = size.Width / 2.0;
		double num2 = size.Height / 2.0;
		double num3 = base.ActualStrokeThickness / 2.0;
		_ellipse.SetAttribute(("cx", num.ToStringInvariant()), ("cy", num2.ToStringInvariant()), ("rx", (num - num3).ToStringInvariant()), ("ry", (num2 - num3).ToStringInvariant()));
		return base.ArrangeOverride(finalSize);
	}
}
