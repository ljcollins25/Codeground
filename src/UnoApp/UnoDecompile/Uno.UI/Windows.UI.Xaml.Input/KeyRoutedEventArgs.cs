using System;
using Uno;
using Uno.UI.Xaml.Input;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Core;

namespace Windows.UI.Xaml.Input;

public class KeyRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs, IPreventDefaultHandling
{
	private readonly CorePhysicalKeyStatus? _keyStatus;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string DeviceId
	{
		get
		{
			throw new NotImplementedException("The member string KeyRoutedEventArgs.DeviceId is not implemented in Uno.");
		}
	}

	public bool Handled { get; set; }

	public VirtualKey Key { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CorePhysicalKeyStatus KeyStatus
	{
		get
		{
			if (!_keyStatus.HasValue)
			{
				ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.KeyRoutedEventArgs", "KeyStatus");
				return default(CorePhysicalKeyStatus);
			}
			return _keyStatus.Value;
		}
	}

	public VirtualKey OriginalKey { get; }

	internal VirtualKeyModifiers KeyboardModifiers { get; }

	bool IPreventDefaultHandling.DoNotPreventDefault { get; set; }

	internal KeyRoutedEventArgs(object originalSource, VirtualKey key, CorePhysicalKeyStatus? keyStatus = null)
		: base(originalSource)
	{
		Key = key;
		OriginalKey = key;
		_keyStatus = keyStatus;
	}
}
