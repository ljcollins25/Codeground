using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarPenConfigurationControl : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarPenButton PenButton => (InkToolbarPenButton)GetValue(PenButtonProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PenButtonProperty { get; } = DependencyProperty.Register("PenButton", typeof(InkToolbarPenButton), typeof(InkToolbarPenConfigurationControl), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarPenConfigurationControl()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarPenConfigurationControl", "InkToolbarPenConfigurationControl.InkToolbarPenConfigurationControl()");
	}
}
