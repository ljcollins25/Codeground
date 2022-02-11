using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Xaml.Core;

internal class FullWindowMediaRoot : Border
{
	public FullWindowMediaRoot()
	{
		base.VerticalAlignment = VerticalAlignment.Stretch;
		base.HorizontalAlignment = HorizontalAlignment.Stretch;
		base.Visibility = Visibility.Collapsed;
	}
}
