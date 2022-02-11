using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class InkToolbarFlyoutItem : ButtonBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarFlyoutItemKind Kind
	{
		get
		{
			return (InkToolbarFlyoutItemKind)GetValue(KindProperty);
		}
		set
		{
			SetValue(KindProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsChecked
	{
		get
		{
			return (bool)GetValue(IsCheckedProperty);
		}
		set
		{
			SetValue(IsCheckedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsCheckedProperty { get; } = DependencyProperty.Register("IsChecked", typeof(bool), typeof(InkToolbarFlyoutItem), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KindProperty { get; } = DependencyProperty.Register("Kind", typeof(InkToolbarFlyoutItemKind), typeof(InkToolbarFlyoutItem), new FrameworkPropertyMetadata(InkToolbarFlyoutItemKind.Simple));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbarFlyoutItem, object> Checked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarFlyoutItem", "event TypedEventHandler<InkToolbarFlyoutItem, object> InkToolbarFlyoutItem.Checked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarFlyoutItem", "event TypedEventHandler<InkToolbarFlyoutItem, object> InkToolbarFlyoutItem.Checked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<InkToolbarFlyoutItem, object> Unchecked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarFlyoutItem", "event TypedEventHandler<InkToolbarFlyoutItem, object> InkToolbarFlyoutItem.Unchecked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarFlyoutItem", "event TypedEventHandler<InkToolbarFlyoutItem, object> InkToolbarFlyoutItem.Unchecked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public InkToolbarFlyoutItem()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.InkToolbarFlyoutItem", "InkToolbarFlyoutItem.InkToolbarFlyoutItem()");
	}
}
