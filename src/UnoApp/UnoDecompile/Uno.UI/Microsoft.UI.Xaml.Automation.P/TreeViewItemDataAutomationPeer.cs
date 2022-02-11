using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class TreeViewItemDataAutomationPeer : ItemAutomationPeer, IExpandCollapseProvider
{
	private const string UIA_E_ELEMENTNOTENABLED = "Element not enabled";

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			TreeViewItemAutomationPeer treeViewItemAutomationPeer = GetTreeViewItemAutomationPeer();
			if (treeViewItemAutomationPeer != null)
			{
				return treeViewItemAutomationPeer.ExpandCollapseState;
			}
			throw new InvalidOperationException("Element not enabled");
		}
	}

	public TreeViewItemDataAutomationPeer(object item, ItemsControlAutomationPeer parent)
		: base(item, parent)
	{
	}

	public void Collapse()
	{
		TreeViewItemAutomationPeer treeViewItemAutomationPeer = GetTreeViewItemAutomationPeer();
		if (treeViewItemAutomationPeer != null)
		{
			treeViewItemAutomationPeer.Collapse();
			return;
		}
		throw new InvalidOperationException("Element not enabled");
	}

	public void Expand()
	{
		TreeViewItemAutomationPeer treeViewItemAutomationPeer = GetTreeViewItemAutomationPeer();
		if (treeViewItemAutomationPeer != null)
		{
			treeViewItemAutomationPeer.Expand();
			return;
		}
		throw new InvalidOperationException("Element not enabled");
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	private TreeViewItemAutomationPeer GetTreeViewItemAutomationPeer()
	{
		ItemsControlAutomationPeer itemsControlAutomationPeer = base.ItemsControlAutomationPeer;
		if (itemsControlAutomationPeer != null && itemsControlAutomationPeer.Owner is ItemsControl itemsControl && itemsControl.ContainerFromItem(base.Item) is UIElement element && FrameworkElementAutomationPeer.CreatePeerForElement(element) is TreeViewItemAutomationPeer result)
		{
			return result;
		}
		throw new InvalidOperationException("Element not enabled");
	}
}
