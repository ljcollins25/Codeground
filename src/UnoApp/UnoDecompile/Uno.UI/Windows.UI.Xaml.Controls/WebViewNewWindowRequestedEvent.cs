using System;

namespace Windows.UI.Xaml.Controls;

public sealed class WebViewNewWindowRequestedEventArgs
{
	public bool Handled { get; set; }

	public Uri Referrer { get; private set; }

	public Uri Uri { get; private set; }

	internal WebViewNewWindowRequestedEventArgs(Uri referrer, Uri uri)
	{
		Referrer = referrer;
		Uri = uri;
	}
}
