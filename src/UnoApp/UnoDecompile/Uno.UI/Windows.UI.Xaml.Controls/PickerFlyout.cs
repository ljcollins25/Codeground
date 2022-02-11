using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public abstract class PickerFlyout : PickerFlyoutBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Content
	{
		get
		{
			return (UIElement)GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ConfirmationButtonsVisible
	{
		get
		{
			return (bool)GetValue(ConfirmationButtonsVisibleProperty);
		}
		set
		{
			SetValue(ConfirmationButtonsVisibleProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ConfirmationButtonsVisibleProperty { get; } = DependencyProperty.Register("ConfirmationButtonsVisible", typeof(bool), typeof(PickerFlyout), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(UIElement), typeof(PickerFlyout), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<PickerFlyout, PickerConfirmedEventArgs> Confirmed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PickerFlyout", "event TypedEventHandler<PickerFlyout, PickerConfirmedEventArgs> PickerFlyout.Confirmed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.PickerFlyout", "event TypedEventHandler<PickerFlyout, PickerConfirmedEventArgs> PickerFlyout.Confirmed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IAsyncOperation<bool> ShowAtAsync(FrameworkElement target)
	{
		throw new NotImplementedException("The member IAsyncOperation<bool> PickerFlyout.ShowAtAsync(FrameworkElement target) is not implemented in Uno.");
	}
}
