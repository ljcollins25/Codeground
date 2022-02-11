using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.Graphics.Printing;

namespace Windows.UI.Xaml.Printing;

[NotImplemented]
public class PaginateEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int CurrentPreviewPageNumber
	{
		get
		{
			throw new NotImplementedException("The member int PaginateEventArgs.CurrentPreviewPageNumber is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PrintTaskOptions PrintTaskOptions
	{
		get
		{
			throw new NotImplementedException("The member PrintTaskOptions PaginateEventArgs.PrintTaskOptions is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PaginateEventArgs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Printing.PaginateEventArgs", "PaginateEventArgs.PaginateEventArgs()");
	}
}
