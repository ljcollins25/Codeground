using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[Obsolete("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.ToggleSplitButton instead.")]
public class ToggleSplitButton : SplitButton
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsChecked
	{
		get
		{
			throw new NotImplementedException("The member bool ToggleSplitButton.IsChecked is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButton", "bool ToggleSplitButton.IsChecked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ToggleSplitButton, ToggleSplitButtonIsCheckedChangedEventArgs> IsCheckedChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButton", "event TypedEventHandler<ToggleSplitButton, ToggleSplitButtonIsCheckedChangedEventArgs> ToggleSplitButton.IsCheckedChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButton", "event TypedEventHandler<ToggleSplitButton, ToggleSplitButtonIsCheckedChangedEventArgs> ToggleSplitButton.IsCheckedChanged");
		}
	}

	public ToggleSplitButton()
	{
		throw new NotImplementedException("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.ToggleSplitButton instead.");
	}
}
