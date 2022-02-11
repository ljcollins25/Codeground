using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace Uno.UI.Helpers.WinUI;

internal static class CppWinRTHelpers
{
	public static bool SetFocus(DependencyObject obj, FocusState focusState)
	{
		if (obj != null)
		{
			if (obj is Control control)
			{
				return control.Focus(focusState);
			}
			if (obj is Hyperlink hyperlink)
			{
				return hyperlink.Focus(focusState);
			}
			if (obj is ContentLink contentLink)
			{
				return contentLink.Focus(focusState);
			}
			if (obj is WebView webView)
			{
				return webView.Focus(focusState);
			}
		}
		return false;
	}
}
