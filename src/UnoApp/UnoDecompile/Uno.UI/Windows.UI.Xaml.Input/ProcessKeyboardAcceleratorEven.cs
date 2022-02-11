using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.System;

namespace Windows.UI.Xaml.Input;

[NotImplemented]
public class ProcessKeyboardAcceleratorEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool Handled
	{
		get
		{
			throw new NotImplementedException("The member bool ProcessKeyboardAcceleratorEventArgs.Handled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.ProcessKeyboardAcceleratorEventArgs", "bool ProcessKeyboardAcceleratorEventArgs.Handled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public VirtualKey Key
	{
		get
		{
			throw new NotImplementedException("The member VirtualKey ProcessKeyboardAcceleratorEventArgs.Key is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public VirtualKeyModifiers Modifiers
	{
		get
		{
			throw new NotImplementedException("The member VirtualKeyModifiers ProcessKeyboardAcceleratorEventArgs.Modifiers is not implemented in Uno.");
		}
	}
}
