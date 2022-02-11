using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Input;

[NotImplemented]
public class KeyboardAcceleratorInvokedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool Handled
	{
		get
		{
			throw new NotImplementedException("The member bool KeyboardAcceleratorInvokedEventArgs.Handled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs", "bool KeyboardAcceleratorInvokedEventArgs.Handled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject Element
	{
		get
		{
			throw new NotImplementedException("The member DependencyObject KeyboardAcceleratorInvokedEventArgs.Element is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public KeyboardAccelerator KeyboardAccelerator
	{
		get
		{
			throw new NotImplementedException("The member KeyboardAccelerator KeyboardAcceleratorInvokedEventArgs.KeyboardAccelerator is not implemented in Uno.");
		}
	}
}
