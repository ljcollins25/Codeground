using System;

namespace Windows.UI.Xaml.Controls;

public sealed class WebViewUnsupportedUriSchemeIdentifiedEventArgs
{
	public bool Handled { get; set; }

	public Uri Uri { get; private set; }

	public WebViewUnsupportedUriSchemeIdentifiedEventArgs(Uri uri)
	{
		Uri = uri;
	}
}
