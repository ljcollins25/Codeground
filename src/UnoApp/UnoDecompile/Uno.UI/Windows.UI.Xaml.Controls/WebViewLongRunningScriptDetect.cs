using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class WebViewLongRunningScriptDetectedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool StopPageScriptExecution
	{
		get
		{
			throw new NotImplementedException("The member bool WebViewLongRunningScriptDetectedEventArgs.StopPageScriptExecution is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.WebViewLongRunningScriptDetectedEventArgs", "bool WebViewLongRunningScriptDetectedEventArgs.StopPageScriptExecution");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimeSpan ExecutionTime
	{
		get
		{
			throw new NotImplementedException("The member TimeSpan WebViewLongRunningScriptDetectedEventArgs.ExecutionTime is not implemented in Uno.");
		}
	}
}
