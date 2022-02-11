using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ColorPicker : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Color? PreviousColor
	{
		get
		{
			return (Color?)GetValue(PreviousColorProperty);
		}
		set
		{
			SetValue(PreviousColorProperty, value);
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
	public bool IsMoreButtonVisible
	{
		get
		{
			return (bool)GetValue(IsMoreButtonVisibleProperty);
		}
		set
		{
			SetValue(IsMoreButtonVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHexInputVisible
	{
		get
		{
			return (bool)GetValue(IsHexInputVisibleProperty);
		}
		set
		{
			SetValue(IsHexInputVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorSpectrumVisible
	{
		get
		{
			return (bool)GetValue(IsColorSpectrumVisibleProperty);
		}
		set
		{
			SetValue(IsColorSpectrumVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorSliderVisible
	{
		get
		{
			return (bool)GetValue(IsColorSliderVisibleProperty);
		}
		set
		{
			SetValue(IsColorSliderVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorPreviewVisible
	{
		get
		{
			return (bool)GetValue(IsColorPreviewVisibleProperty);
		}
		set
		{
			SetValue(IsColorPreviewVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorChannelTextInputVisible
	{
		get
		{
			return (bool)GetValue(IsColorChannelTextInputVisibleProperty);
		}
		set
		{
			SetValue(IsColorChannelTextInputVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAlphaTextInputVisible
	{
		get
		{
			return (bool)GetValue(IsAlphaTextInputVisibleProperty);
		}
		set
		{
			SetValue(IsAlphaTextInputVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAlphaSliderVisible
	{
		get
		{
			return (bool)GetValue(IsAlphaSliderVisibleProperty);
		}
		set
		{
			SetValue(IsAlphaSliderVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAlphaEnabled
	{
		get
		{
			return (bool)GetValue(IsAlphaEnabledProperty);
		}
		set
		{
			SetValue(IsAlphaEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrumShape ColorSpectrumShape
	{
		get
		{
			return (ColorSpectrumShape)GetValue(ColorSpectrumShapeProperty);
		}
		set
		{
			SetValue(ColorSpectrumShapeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrumComponents ColorSpectrumComponents
	{
		get
		{
			return (ColorSpectrumComponents)GetValue(ColorSpectrumComponentsProperty);
		}
		set
		{
			SetValue(ColorSpectrumComponentsProperty, value);
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
	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new FrameworkPropertyMetadata(default(Color)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorSpectrumComponentsProperty { get; } = DependencyProperty.Register("ColorSpectrumComponents", typeof(ColorSpectrumComponents), typeof(ColorPicker), new FrameworkPropertyMetadata(ColorSpectrumComponents.HueValue));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorSpectrumShapeProperty { get; } = DependencyProperty.Register("ColorSpectrumShape", typeof(ColorSpectrumShape), typeof(ColorPicker), new FrameworkPropertyMetadata(ColorSpectrumShape.Box));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAlphaEnabledProperty { get; } = DependencyProperty.Register("IsAlphaEnabled", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAlphaSliderVisibleProperty { get; } = DependencyProperty.Register("IsAlphaSliderVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAlphaTextInputVisibleProperty { get; } = DependencyProperty.Register("IsAlphaTextInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorChannelTextInputVisibleProperty { get; } = DependencyProperty.Register("IsColorChannelTextInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorPreviewVisibleProperty { get; } = DependencyProperty.Register("IsColorPreviewVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorSliderVisibleProperty { get; } = DependencyProperty.Register("IsColorSliderVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorSpectrumVisibleProperty { get; } = DependencyProperty.Register("IsColorSpectrumVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHexInputVisibleProperty { get; } = DependencyProperty.Register("IsHexInputVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsMoreButtonVisibleProperty { get; } = DependencyProperty.Register("IsMoreButtonVisible", typeof(bool), typeof(ColorPicker), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxHueProperty { get; } = DependencyProperty.Register("MaxHue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxSaturationProperty { get; } = DependencyProperty.Register("MaxSaturation", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxValueProperty { get; } = DependencyProperty.Register("MaxValue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinHueProperty { get; } = DependencyProperty.Register("MinHue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinSaturationProperty { get; } = DependencyProperty.Register("MinSaturation", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MinValueProperty { get; } = DependencyProperty.Register("MinValue", typeof(int), typeof(ColorPicker), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PreviousColorProperty { get; } = DependencyProperty.Register("PreviousColor", typeof(Color?), typeof(ColorPicker), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ColorPicker, ColorChangedEventArgs> ColorChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ColorPicker", "event TypedEventHandler<ColorPicker, ColorChangedEventArgs> ColorPicker.ColorChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ColorPicker", "event TypedEventHandler<ColorPicker, ColorChangedEventArgs> ColorPicker.ColorChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorPicker()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ColorPicker", "ColorPicker.ColorPicker()");
	}
}
