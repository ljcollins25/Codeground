using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class NavigationViewItemAutomationPeer : ListViewItemAutomationPeer
{
	public NavigationViewItemAutomationPeer(NavigationViewItem owner)
		: base(owner)
	{
	}
}
