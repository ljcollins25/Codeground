using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Input;

[NotImplemented]
public class ContextRequestedEventArgs : RoutedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool Handled
	{
		get
		{
			throw new NotImplementedException("The member bool ContextRequestedEventArgs.Handled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.ContextRequestedEventArgs", "bool ContextRequestedEventArgs.Handled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ContextRequestedEventArgs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.ContextRequestedEventArgs", "ContextRequestedEventArgs.ContextRequestedEventArgs()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool TryGetPosition(UIElement relativeTo, out Point point)
	{
		throw new NotImplementedException("The member bool ContextRequestedEventArgs.TryGetPosition(UIElement relativeTo, out Point point) is not implemented in Uno.");
	}
}
