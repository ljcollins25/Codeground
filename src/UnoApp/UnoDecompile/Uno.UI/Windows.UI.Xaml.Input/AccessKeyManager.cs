using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Input;

[NotImplemented]
public class AccessKeyManager
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool IsDisplayModeEnabled
	{
		get
		{
			throw new NotImplementedException("The member bool AccessKeyManager.IsDisplayModeEnabled is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool AreKeyTipsEnabled
	{
		get
		{
			throw new NotImplementedException("The member bool AccessKeyManager.AreKeyTipsEnabled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.AccessKeyManager", "bool AccessKeyManager.AreKeyTipsEnabled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static event TypedEventHandler<object, object> IsDisplayModeEnabledChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.AccessKeyManager", "event TypedEventHandler<object, object> AccessKeyManager.IsDisplayModeEnabledChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.AccessKeyManager", "event TypedEventHandler<object, object> AccessKeyManager.IsDisplayModeEnabledChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void ExitDisplayMode()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.AccessKeyManager", "void AccessKeyManager.ExitDisplayMode()");
	}
}
