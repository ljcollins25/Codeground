using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Input.Inking;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarStencilButton : InkToolbarMenuButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarStencilKind SelectedStencil
	{
		get
		{
			return (InkToolbarStencilKind)GetValue(SelectedStencilProperty);
		}
		set
		{
			SetValue(SelectedStencilProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsRulerItemVisible
	{
		get
		{
			return (bool)GetValue(IsRulerItemVisibleProperty);
		}
		set
		{
			SetValue(IsRulerItemVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsProtractorItemVisible
	{
		get
		{
			return (bool)GetValue(IsProtractorItemVisibleProperty);
		}
		set
		{
			SetValue(IsProtractorItemVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkPresenterProtractor Protractor => (InkPresenterProtractor)GetValue(ProtractorProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkPresenterRuler Ruler => (InkPresenterRuler)GetValue(RulerProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsProtractorItemVisibleProperty { get; } = DependencyProperty.Register("IsProtractorItemVisible", typeof(bool), typeof(InkToolbarStencilButton), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsRulerItemVisibleProperty { get; } = DependencyProperty.Register("IsRulerItemVisible", typeof(bool), typeof(InkToolbarStencilButton), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProtractorProperty { get; } = DependencyProperty.Register("Protractor", typeof(InkPresenterProtractor), typeof(InkToolbarStencilButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RulerProperty { get; } = DependencyProperty.Register("Ruler", typeof(InkPresenterRuler), typeof(InkToolbarStencilButton), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SelectedStencilProperty { get; } = DependencyProperty.Register("SelectedStencil", typeof(InkToolbarStencilKind), typeof(InkToolbarStencilButton), new FrameworkPropertyMetadata(InkToolbarStencilKind.Ruler));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarStencilButton()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarStencilButton", "InkToolbarStencilButton.InkToolbarStencilButton()");
	}
}
