using System;

namespace Windows.UI.Xaml.Controls;

public sealed class WebViewNavigationStartingEventArgs
{
	public bool Cancel { get; set; }

	public Uri Uri { get; internal set; }
}
