using Windows.UI.Xaml;

namespace Uno.UI.Helpers.WinUI;

internal class Util
{
	public static Visibility VisibilityFromBool(bool visible)
	{
		if (!visible)
		{
			return Visibility.Collapsed;
		}
		return Visibility.Visible;
	}
}
