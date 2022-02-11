using System.Numerics;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Primitives;

[NotImplemented]
public class ColorSpectrum : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrumShape Shape
	{
		get
		{
			return (ColorSpectrumShape)GetValue(ShapeProperty);
		}
		set
		{
			SetValue(ShapeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MinValue
	{
		get
		{
			return (int)GetValue(MinValueProperty);
		}
		set
		{
			SetValue(MinValueProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MinSaturation
	{
		get
		{
			return (int)GetValue(MinSaturationProperty);
		}
		set
		{
			SetValue(MinSaturationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MinHue
	{
		get
		{
			return (int)GetValue(MinHueProperty);
		}
		set
		{
			SetValue(MinHueProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MaxValue
	{
		get
		{
			return (int)GetValue(MaxValueProperty);
		}
		set
		{
			SetValue(MaxValueProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MaxSaturation
	{
		get
		{
			return (int)GetValue(MaxSaturationProperty);
		}
		set
		{
			SetValue(MaxSaturationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int MaxHue
	{
		get
		{
			return (int)GetValue(MaxHueProperty);
		}
		set
		{
			SetValue(MaxHueProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector4 HsvColor
	{
		get
		{
			return (Vector4)GetValue(HsvColorProperty);
		}
		set
		{
			SetValue(HsvColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrumComponents Components
	{
		get
		{
			return (ColorSpectrumComponents)GetValue(ComponentsProperty);
		}
		set
		{
			SetValue(ComponentsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(ColorSpectrum), new FrameworkPropertyMetadata(default(Color)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ComponentsProperty { get; } = DependencyProperty.Register("Components", typeof(ColorSpectrumComponents), typeof(ColorSpectrum), new FrameworkPropertyMetadata(ColorSpectrumComponents.HueValue));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HsvColorProperty { get; } = DependencyProperty.Register("HsvColor", typeof(Vector4), typeof(ColorSpectrum), new FrameworkPropertyMetadata(default(Vector4)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxHueProperty { get; } = DependencyProperty.Register("MaxHue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxSaturationProperty { get; } = DependencyProperty.Register("MaxSaturation", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxValueProperty { get; } = DependencyProperty.Register("MaxValue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinHueProperty { get; } = DependencyProperty.Register("MinHue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinSaturationProperty { get; } = DependencyProperty.Register("MinSaturation", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinValueProperty { get; } = DependencyProperty.Register("MinValue", typeof(int), typeof(ColorSpectrum), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShapeProperty { get; } = DependencyProperty.Register("Shape", typeof(ColorSpectrumShape), typeof(ColorSpectrum), new FrameworkPropertyMetadata(ColorSpectrumShape.Box));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ColorSpectrum, ColorChangedEventArgs> ColorChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.ColorSpectrum", "event TypedEventHandler<ColorSpectrum, ColorChangedEventArgs> ColorSpectrum.ColorChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.ColorSpectrum", "event TypedEventHandler<ColorSpectrum, ColorChangedEventArgs> ColorSpectrum.ColorChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrum()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.ColorSpectrum", "ColorSpectrum.ColorSpectrum()");
	}
}
