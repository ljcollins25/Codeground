using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ContextMenuEventArgs : RoutedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool Handled
	{
		get
		{
			throw new NotImplementedException("The member bool ContextMenuEventArgs.Handled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContextMenuEventArgs", "bool ContextMenuEventArgs.Handled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CursorLeft
	{
		get
		{
			throw new NotImplementedException("The member double ContextMenuEventArgs.CursorLeft is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CursorTop
	{
		get
		{
			throw new NotImplementedException("The member double ContextMenuEventArgs.CursorTop is not implemented in Uno.");
		}
	}
}
