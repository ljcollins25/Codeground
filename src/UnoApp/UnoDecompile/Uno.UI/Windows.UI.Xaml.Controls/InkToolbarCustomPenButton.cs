using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarCustomPenButton : InkToolbarPenButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarCustomPen CustomPen
	{
		get
		{
			return (InkToolbarCustomPen)GetValue(CustomPenProperty);
		}
		set
		{
			SetValue(CustomPenProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement ConfigurationContent
	{
		get
		{
			return (UIElement)GetValue(ConfigurationContentProperty);
		}
		set
		{
			SetValue(ConfigurationContentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ConfigurationContentProperty { get; } = DependencyProperty.Register("ConfigurationContent", typeof(UIElement), typeof(InkToolbarCustomPenButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CustomPenProperty { get; } = DependencyProperty.Register("CustomPen", typeof(InkToolbarCustomPen), typeof(InkToolbarCustomPenButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarCustomPenButton()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarCustomPenButton", "InkToolbarCustomPenButton.InkToolbarCustomPenButton()");
	}
}
