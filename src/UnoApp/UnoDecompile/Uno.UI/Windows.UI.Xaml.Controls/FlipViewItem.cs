using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class FlipViewItem : SelectorItem
{
	public FlipViewItem()
	{
		base.DefaultStyleKey = typeof(FlipViewItem);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new FlipViewItemAutomationPeer(this);
	}
}
