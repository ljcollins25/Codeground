using System;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Web.Http;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WebViewWebResourceRequestedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HttpResponseMessage Response
	{
		get
		{
			throw new NotImplementedException("The member HttpResponseMessage WebViewWebResourceRequestedEventArgs.Response is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewWebResourceRequestedEventArgs", "HttpResponseMessage WebViewWebResourceRequestedEventArgs.Response");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public HttpRequestMessage Request
	{
		get
		{
			throw new NotImplementedException("The member HttpRequestMessage WebViewWebResourceRequestedEventArgs.Request is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Deferral GetDeferral()
	{
		throw new NotImplementedException("The member Deferral WebViewWebResourceRequestedEventArgs.GetDeferral() is not implemented in Uno.");
	}
}
