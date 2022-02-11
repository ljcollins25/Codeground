using System;
using Uno.UI.Web;

namespace Windows.UI.Xaml.Controls;

public sealed class WebViewNavigationCompletedEventArgs
{
	public bool IsSuccess { get; internal set; }

	public Uri Uri { get; internal set; }

	public WebErrorStatus WebErrorStatus { get; internal set; }
}
