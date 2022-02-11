using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarEraserButton : InkToolbarToolButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsClearAllVisible
	{
		get
		{
			return (bool)GetValue(IsClearAllVisibleProperty);
		}
		set
		{
			SetValue(IsClearAllVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsClearAllVisibleProperty { get; } = DependencyProperty.Register("IsClearAllVisible", typeof(bool), typeof(InkToolbarEraserButton), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarEraserButton()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarEraserButton", "InkToolbarEraserButton.InkToolbarEraserButton()");
	}
}
