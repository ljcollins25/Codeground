using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Input.Inking;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarRulerButton : InkToolbarToggleButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkPresenterRuler Ruler => (InkPresenterRuler)GetValue(RulerProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RulerProperty { get; } = DependencyProperty.Register("Ruler", typeof(InkPresenterRuler), typeof(InkToolbarRulerButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarRulerButton()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarRulerButton", "InkToolbarRulerButton.InkToolbarRulerButton()");
	}
}
