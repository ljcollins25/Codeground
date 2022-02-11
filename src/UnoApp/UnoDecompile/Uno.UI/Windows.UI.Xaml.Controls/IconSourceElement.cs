using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class IconSourceElement : IconElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IconSource IconSource
	{
		get
		{
			return (IconSource)GetValue(IconSourceProperty);
		}
		set
		{
			SetValue(IconSourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(IconSourceElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IconSourceElement()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.IconSourceElement", "IconSourceElement.IconSourceElement()");
	}
}
