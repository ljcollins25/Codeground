using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WebViewSettings
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsJavaScriptEnabled
	{
		get
		{
			throw new NotImplementedException("The member bool WebViewSettings.IsJavaScriptEnabled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewSettings", "bool WebViewSettings.IsJavaScriptEnabled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsIndexedDBEnabled
	{
		get
		{
			throw new NotImplementedException("The member bool WebViewSettings.IsIndexedDBEnabled is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewSettings", "bool WebViewSettings.IsIndexedDBEnabled");
		}
	}
}
