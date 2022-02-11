using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Printing;

[NotImplemented]
public class GetPreviewPageEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int PageNumber
	{
		get
		{
			throw new NotImplementedException("The member int GetPreviewPageEventArgs.PageNumber is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GetPreviewPageEventArgs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Printing.GetPreviewPageEventArgs", "GetPreviewPageEventArgs.GetPreviewPageEventArgs()");
	}
}
