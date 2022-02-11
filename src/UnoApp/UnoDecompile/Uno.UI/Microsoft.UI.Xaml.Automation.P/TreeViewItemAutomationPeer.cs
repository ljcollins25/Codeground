using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class TreeViewItemAutomationPeer : ListViewItemAutomationPeer, IExpandCollapseProvider
{
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
			if (treeViewNode != null && treeViewNode.HasChildren)
			{
				if (treeViewNode.IsExpanded)
				{
					return ExpandCollapseState.Expanded;
				}
				return ExpandCollapseState.Collapsed;
			}
			return ExpandCollapseState.LeafNode;
		}
	}

	private bool IsSelected
	{
		get
		{
			Microsoft.UI.Xaml.Controls.TreeViewItem treeViewItem = (Microsoft.UI.Xaml.Controls.TreeViewItem)base.Owner;
			return treeViewItem.IsSelectedInternal;
		}
	}

	public TreeViewItemAutomationPeer(Microsoft.UI.Xaml.Controls.TreeViewItem owner)
		: base(owner)
	{
	}

	public void Collapse()
	{
		Microsoft.UI.Xaml.Controls.TreeView parentTreeView = GetParentTreeView();
		if (parentTreeView != null)
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
			if (treeViewNode != null)
			{
				parentTreeView.Collapse(treeViewNode);
				RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Collapsed);
			}
		}
	}

	public void Expand()
	{
		Microsoft.UI.Xaml.Controls.TreeView parentTreeView = GetParentTreeView();
		if (parentTreeView != null)
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
			if (treeViewNode != null)
			{
				parentTreeView.Expand(treeViewNode);
				RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Expanded);
			}
		}
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse)
		{
			return this;
		}
		Microsoft.UI.Xaml.Controls.TreeView parentTreeView = GetParentTreeView();
		if (parentTreeView != null && patternInterface == PatternInterface.SelectionItem && parentTreeView.SelectionMode != 0)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.TreeItem;
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrEmpty(text))
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
			if (treeViewNode != null)
			{
				text = SharedHelpers.TryGetStringRepresentationFromObject(treeViewNode.Content);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "TreeViewNode";
			}
		}
		return text;
	}

	protected override string GetClassNameCore()
	{
		return "TreeViewItem";
	}

	protected override int GetPositionInSetCore()
	{
		ListView parentListView = GetParentListView();
		Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
		int result = 0;
		if (parentListView != null && treeViewNode != null)
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode parent = treeViewNode.Parent;
			if (parent != null)
			{
				int num = parent.Children.IndexOf(treeViewNode);
				if (num != -1)
				{
					result = num + 1;
				}
			}
		}
		return result;
	}

	protected override int GetSizeOfSetCore()
	{
		ListView parentListView = GetParentListView();
		Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
		int result = 0;
		if (parentListView != null && treeViewNode != null)
		{
			Microsoft.UI.Xaml.Controls.TreeViewNode parent = treeViewNode.Parent;
			if (parent != null)
			{
				int count = parent.Children.Count;
				result = count;
			}
		}
		return result;
	}

	protected override int GetLevelCore()
	{
		ListView parentListView = GetParentListView();
		Microsoft.UI.Xaml.Controls.TreeViewNode treeViewNode = GetTreeViewNode();
		int result = -1;
		if (parentListView != null && treeViewNode != null)
		{
			result = treeViewNode.Depth;
			result++;
		}
		return result;
	}

	internal void RaiseExpandCollapseAutomationEvent(ExpandCollapseState newState)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			AutomationProperty expandCollapseStateProperty = ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty;
			ExpandCollapseState expandCollapseState = ((newState != ExpandCollapseState.Expanded) ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			RaisePropertyChangedEvent(expandCollapseStateProperty, expandCollapseState, newState);
		}
	}

	private IRawElementProviderSimple SelectionContainer()
	{
		IRawElementProviderSimple result = null;
		ListView parentListView = GetParentListView();
		if (parentListView != null)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(parentListView);
			if (automationPeer != null)
			{
				result = ProviderFromPeer(automationPeer);
			}
		}
		return result;
	}

	private void AddToSelection()
	{
		UpdateSelection(select: true);
	}

	private void RemoveFromSelection()
	{
		UpdateSelection(select: false);
	}

	private void Select()
	{
		UpdateSelection(select: true);
	}

	private ListView GetParentListView()
	{
		DependencyObject dependencyObject = base.Owner;
		ListView listView = null;
		while (dependencyObject != null && listView == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			if (dependencyObject != null)
			{
				listView = dependencyObject as ListView;
			}
		}
		return listView;
	}

	private Microsoft.UI.Xaml.Controls.TreeView GetParentTreeView()
	{
		DependencyObject dependencyObject = base.Owner;
		Microsoft.UI.Xaml.Controls.TreeView treeView = null;
		while (dependencyObject != null && treeView == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			if (dependencyObject != null)
			{
				treeView = dependencyObject as Microsoft.UI.Xaml.Controls.TreeView;
			}
		}
		return treeView;
	}

	private Microsoft.UI.Xaml.Controls.TreeViewNode GetTreeViewNode()
	{
		Microsoft.UI.Xaml.Controls.TreeViewNode result = null;
		Microsoft.UI.Xaml.Controls.TreeView parentTreeView = GetParentTreeView();
		if (parentTreeView != null)
		{
			result = parentTreeView.NodeFromContainer(base.Owner);
		}
		return result;
	}

	private void UpdateSelection(bool select)
	{
		if (base.Owner is Microsoft.UI.Xaml.Controls.TreeViewItem treeViewItem)
		{
			Microsoft.UI.Xaml.Controls.TreeViewItem treeViewItem2 = treeViewItem;
			treeViewItem2.UpdateSelection(select);
		}
	}
}
