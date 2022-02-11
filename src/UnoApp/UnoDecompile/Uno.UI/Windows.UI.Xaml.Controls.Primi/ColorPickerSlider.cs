using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls.Primitives;

[NotImplemented]
public class ColorPickerSlider : Slider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorPickerHsvChannel ColorChannel
	{
		get
		{
			return (ColorPickerHsvChannel)GetValue(ColorChannelProperty);
		}
		set
		{
			SetValue(ColorChannelProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorChannelProperty { get; } = DependencyProperty.Register("ColorChannel", typeof(ColorPickerHsvChannel), typeof(ColorPickerSlider), new FrameworkPropertyMetadata(ColorPickerHsvChannel.Hue));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorPickerSlider()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.ColorPickerSlider", "ColorPickerSlider.ColorPickerSlider()");
	}
}
