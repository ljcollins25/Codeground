using Uno;
using Windows.Foundation;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media;

[ContentProperty(Name = "GradientStops")]
public abstract class GradientBrush : Brush
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorInterpolationMode ColorInterpolationMode
	{
		get
		{
			return (ColorInterpolationMode)GetValue(ColorInterpolationModeProperty);
		}
		set
		{
			SetValue(ColorInterpolationModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorInterpolationModeProperty { get; } = DependencyProperty.Register("ColorInterpolationMode", typeof(ColorInterpolationMode), typeof(GradientBrush), new FrameworkPropertyMetadata(ColorInterpolationMode.ScRgbLinearInterpolation));


	public static DependencyProperty FallbackColorProperty { get; } = DependencyProperty.Register("FallbackColor", typeof(Color), typeof(GradientBrush), new FrameworkPropertyMetadata(default(Color)));


	public Color FallbackColor
	{
		get
		{
			return (Color)GetValue(FallbackColorProperty);
		}
		set
		{
			SetValue(FallbackColorProperty, value);
		}
	}

	public static DependencyProperty GradientStopsProperty { get; } = DependencyProperty.Register("GradientStops", typeof(GradientStopCollection), typeof(GradientBrush), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext | FrameworkPropertyMetadataOptions.LogicalChild | FrameworkPropertyMetadataOptions.AffectsArrange));


	public GradientStopCollection GradientStops
	{
		get
		{
			return (GradientStopCollection)GetValue(GradientStopsProperty);
		}
		set
		{
			SetValue(GradientStopsProperty, value);
		}
	}

	public static DependencyProperty MappingModeProperty { get; } = DependencyProperty.Register("MappingMode", typeof(BrushMappingMode), typeof(GradientBrush), new FrameworkPropertyMetadata(BrushMappingMode.RelativeToBoundingBox, FrameworkPropertyMetadataOptions.AffectsRender));


	public BrushMappingMode MappingMode
	{
		get
		{
			return (BrushMappingMode)GetValue(MappingModeProperty);
		}
		set
		{
			SetValue(MappingModeProperty, value);
		}
	}

	public static DependencyProperty SpreadMethodProperty { get; } = DependencyProperty.Register("SpreadMethod", typeof(GradientSpreadMethod), typeof(GradientBrush), new FrameworkPropertyMetadata(GradientSpreadMethod.Pad, FrameworkPropertyMetadataOptions.AffectsRender));


	public GradientSpreadMethod SpreadMethod
	{
		get
		{
			return (GradientSpreadMethod)GetValue(SpreadMethodProperty);
		}
		set
		{
			SetValue(SpreadMethodProperty, value);
		}
	}

	internal Color FallbackColorWithOpacity => GetColorWithOpacity(FallbackColor);

	protected GradientBrush()
	{
		GradientStops = new GradientStopCollection();
	}

	internal abstract string ToCssString(Size size);

	internal abstract UIElement ToSvgElement();
}
