using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class CleanUpVirtualizedItemEventArgs : RoutedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool Cancel
	{
		get
		{
			throw new NotImplementedException("The member bool CleanUpVirtualizedItemEventArgs.Cancel is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.CleanUpVirtualizedItemEventArgs", "bool CleanUpVirtualizedItemEventArgs.Cancel");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement UIElement
	{
		get
		{
			throw new NotImplementedException("The member UIElement CleanUpVirtualizedItemEventArgs.UIElement is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Value
	{
		get
		{
			throw new NotImplementedException("The member object CleanUpVirtualizedItemEventArgs.Value is not implemented in Uno.");
		}
	}
}
