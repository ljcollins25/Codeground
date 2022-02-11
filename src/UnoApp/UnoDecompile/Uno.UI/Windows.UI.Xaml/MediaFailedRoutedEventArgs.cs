using System;
using Uno;

namespace Windows.UI.Xaml;

[NotImplemented]
public class MediaFailedRoutedEventArgs : ExceptionRoutedEventArgs
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string ErrorTrace
	{
		get
		{
			throw new NotImplementedException("The member string MediaFailedRoutedEventArgs.ErrorTrace is not implemented in Uno.");
		}
	}

	[NotImplemented]
	internal MediaFailedRoutedEventArgs(object originalSource)
		: base(originalSource, "")
	{
		throw new NotImplementedException();
	}
}
