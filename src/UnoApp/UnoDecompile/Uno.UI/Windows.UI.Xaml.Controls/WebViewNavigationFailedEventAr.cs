using System;
using Uno.UI.Web;

namespace Windows.UI.Xaml.Controls;

public class WebViewNavigationFailedEventArgs
{
	public Uri Uri { get; internal set; }

	public WebErrorStatus WebErrorStatus { get; internal set; }
}
