using System;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class RectangleGeometry : Geometry
{
	private SvgElement? _svgElement;

	public Rect Rect
	{
		get
		{
			return (Rect)GetValue(RectProperty);
		}
		set
		{
			SetValue(RectProperty, value);
		}
	}

	public static DependencyProperty RectProperty { get; } = DependencyProperty.Register("Rect", typeof(Rect), typeof(RectangleGeometry), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));


	public RectangleGeometry()
	{
		InitPartials();
	}

	private void InitPartials()
	{
		this.RegisterDisposablePropertyChangedCallback(OnPropertyChanged);
	}

	public override void Dispose()
	{
		throw new NotImplementedException();
	}

	private protected override Rect ComputeBounds()
	{
		return base.Transform?.TransformBounds(Rect) ?? Rect;
	}

	private void OnPropertyChanged(ManagedWeakReference instance, DependencyProperty property, DependencyPropertyChangedEventArgs args)
	{
		if (property == RectProperty)
		{
			UpdateSvg();
		}
	}

	private void UpdateSvg()
	{
		Rect rect = Rect;
		_svgElement?.SetAttribute(("x", rect.X.ToStringInvariant()), ("y", rect.Y.ToStringInvariant()), ("width", rect.Width.ToStringInvariant()), ("height", rect.Height.ToStringInvariant()));
	}

	internal override SvgElement GetSvgElement()
	{
		if (_svgElement == null)
		{
			_svgElement = new SvgElement("rect");
			UpdateSvg();
		}
		return _svgElement;
	}

	internal override IFormattable ToPathData()
	{
		Rect rect = Rect;
		return $"M{rect.Left},{rect.Top} L{rect.Right},{rect.Top} {rect.Right},{rect.Bottom} {rect.Left},{rect.Bottom} Z";
	}
}
