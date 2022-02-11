using Uno;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class ListViewItem : SelectorItem
{
	[NotImplemented]
	public ListViewItemTemplateSettings TemplateSettings { get; } = new ListViewItemTemplateSettings();


	public ListViewItem()
	{
		base.DefaultStyleKey = typeof(ListViewItem);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ListViewItemAutomationPeer(this);
	}
}
