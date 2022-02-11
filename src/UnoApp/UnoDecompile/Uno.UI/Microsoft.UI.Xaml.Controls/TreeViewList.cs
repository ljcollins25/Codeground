using System.Collections.Generic;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class TreeViewList : ListView
{
	private bool m_isMultiselectEnabled;

	private bool m_itemsSourceAttached;

	private string m_dropTargetDropEffectString;

	private UIElement m_draggedOverItem;

	private int m_emptySlotIndex;

	private TreeViewNode m_draggedTreeViewNode;

	private TreeView m_ancestorTreeView;

	internal TreeViewViewModel ListViewModel { get; private set; }

	internal TreeViewNode DraggedTreeViewNode { get; private set; }

	internal bool IsMultiselect => m_isMultiselectEnabled;

	internal bool IsMutiSelectWithSelectedItems
	{
		get
		{
			IList<TreeViewNode> selectedNodes = ListViewModel.SelectedNodes;
			return m_isMultiselectEnabled && selectedNodes.Count > 0;
		}
	}

	internal bool IsContentMode => ListViewModel?.IsContentMode ?? false;

	internal TreeView AncestorTreeView
	{
		get
		{
			if (m_ancestorTreeView == null)
			{
				m_ancestorTreeView = GetAncestorView<TreeView>();
			}
			return m_ancestorTreeView;
		}
	}

	public TreeViewList()
	{
		ListViewModel = new TreeViewViewModel();
		base.DragItemsStarting += new DragItemsStartingEventHandler(OnDragItemsStarting);
		base.DragItemsCompleted += new TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs>(OnDragItemsCompleted);
		base.ContainerContentChanging += OnContainerContentChanging;
	}

	private void OnDragItemsStarting(object sender, DragItemsStartingEventArgs args)
	{
		object obj = args.Items[0];
		if (obj == null)
		{
			return;
		}
		TreeViewItem treeViewItem = (TreeViewItem)ContainerFromItem(obj);
		m_draggedTreeViewNode = NodeFromContainer(treeViewItem);
		bool flag = false;
		if (IsMutiSelectWithSelectedItems)
		{
			int count = ListViewModel.SelectedNodes.Count;
			if (count > 1)
			{
				TreeViewItemTemplateSettings treeViewItemTemplateSettings = treeViewItem.TreeViewItemTemplateSettings;
				treeViewItemTemplateSettings.DragItemsCount = count;
				flag = true;
				args.Items.Clear();
				foreach (TreeViewNode selectedNode in ListViewModel.SelectedNodes)
				{
					if (IsContentMode)
					{
						args.Items.Add(selectedNode.Content);
					}
					else
					{
						args.Items.Add(selectedNode);
					}
				}
			}
		}
		else
		{
			m_draggedTreeViewNode.IsExpanded = false;
		}
		VisualStateManager.GoToState(treeViewItem, flag ? "MultipleDraggingPrimary" : "Dragging", useTransitions: false);
		UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, null);
	}

	private void OnDragItemsCompleted(object sender, DragItemsCompletedEventArgs args)
	{
		m_draggedTreeViewNode = null;
		m_emptySlotIndex = -1;
	}

	private void OnContainerContentChanging(object sender, ContainerContentChangingEventArgs args)
	{
		if (!args.InRecycleQueue)
		{
			TreeViewItem treeViewItem = (TreeViewItem)args.ItemContainer;
			TreeViewNode treeViewNode = NodeFromContainer(treeViewItem);
			TreeViewItem treeViewItem2 = treeViewItem;
			TreeViewNode treeViewNode2 = treeViewNode;
			object itemsSource = treeViewItem.ItemsSource;
			if (itemsSource != null && treeViewNode2.ItemsSource == null)
			{
				treeViewItem2.SetItemsSource(treeViewNode, itemsSource);
			}
			treeViewItem2.UpdateIndentation(treeViewNode.Depth);
			treeViewItem2.UpdateSelectionVisual(treeViewNode.SelectionState);
		}
	}

	protected override void OnDrop(DragEventArgs e)
	{
		if (e.AcceptedOperation == DataPackageOperation.Move && !e.Handled && m_draggedTreeViewNode != null && IsIndexValid(m_emptySlotIndex))
		{
			TreeViewNode insertAtNode = NodeAtFlatIndex(m_emptySlotIndex);
			if (IsMutiSelectWithSelectedItems)
			{
				IList<TreeViewNode> rootsOfSelectedSubtrees = GetRootsOfSelectedSubtrees();
				for (int num = rootsOfSelectedSubtrees.Count - 1; num >= 0; num--)
				{
					MoveNodeInto(rootsOfSelectedSubtrees[num], insertAtNode);
				}
			}
			else
			{
				MoveNodeInto(m_draggedTreeViewNode, insertAtNode);
			}
			UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, null);
			e.Handled = true;
		}
		base.OnDrop(e);
	}

	internal void OnDropInternal(DragEventArgs e)
	{
		OnDrop(e);
	}

	private void MoveNodeInto(TreeViewNode node, TreeViewNode insertAtNode)
	{
		int num = FlatIndex(node);
		if (insertAtNode != node && IsFlatIndexValid(num))
		{
			RemoveNodeFromParent(node);
			int num2 = ((num < m_emptySlotIndex) ? 1 : 0);
			if (insertAtNode.IsExpanded && num2 == 1)
			{
				((TreeViewNodeVector)insertAtNode.Children).InsertAt(0, node);
				return;
			}
			TreeViewNodeVector treeViewNodeVector = (TreeViewNodeVector)insertAtNode.Parent.Children;
			int num3 = IndexInParent(insertAtNode);
			treeViewNodeVector.InsertAt(num3 + num2, node);
		}
	}

	protected override void OnDragOver(DragEventArgs args)
	{
		if (!args.Handled)
		{
			args.AcceptedOperation = DataPackageOperation.None;
			IInsertionPanel insertionPanel = (IInsertionPanel)base.ItemsPanelRoot;
			if (insertionPanel != null && m_draggedTreeViewNode != null && base.CanReorderItems)
			{
				int first = -1;
				int second = -1;
				TreeViewViewModel listViewModel = ListViewModel;
				int count = listViewModel.Count;
				Point position = args.GetPosition((UIElement)insertionPanel);
				insertionPanel.GetInsertionIndexes(position, out first, out second);
				if (second == -1)
				{
					second = count - 1;
				}
				if (second > count - 1)
				{
					m_emptySlotIndex = count - 1;
				}
				else if (second > 0 && m_draggedTreeViewNode != null)
				{
					m_emptySlotIndex = -1;
					TreeViewNode draggedTreeViewNode = m_draggedTreeViewNode;
					if (ListViewModel.IndexOfNode(draggedTreeViewNode, out var index))
					{
						int index2 = ((index < second) ? second : (second - 1));
						DependencyObject dependencyObject = ContainerFromIndex(index2);
						if (dependencyObject != null)
						{
							TreeViewItem treeViewItem = (TreeViewItem)dependencyObject;
							if (args.GetPosition(treeViewItem).Y < treeViewItem.ActualHeight / 2.0)
							{
								m_emptySlotIndex = second - 1;
							}
							else
							{
								m_emptySlotIndex = second;
							}
						}
					}
				}
				else
				{
					m_emptySlotIndex = 0;
				}
				bool flag = true;
				if (IsFlatIndexValid(m_emptySlotIndex))
				{
					TreeViewNode treeViewNode = NodeAtFlatIndex(m_emptySlotIndex);
					if (IsMultiselect)
					{
						IList<TreeViewNode> selectedNodes = ListViewModel.SelectedNodes;
						for (int i = 0; i < selectedNodes.Count; i++)
						{
							TreeViewNode treeViewNode2 = selectedNodes[i];
							if (treeViewNode2 == treeViewNode)
							{
								flag = false;
								break;
							}
						}
					}
					else if (m_draggedTreeViewNode != null && treeViewNode != null && treeViewNode.Parent != null)
					{
						DependencyObject dependencyObject2 = ContainerFromNode(treeViewNode.Parent);
						if (dependencyObject2 != null)
						{
							flag = ((TreeViewItem)dependencyObject2).AllowDrop;
						}
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					args.AcceptedOperation = DataPackageOperation.Move;
				}
				else
				{
					m_emptySlotIndex = -1;
					args.AcceptedOperation = DataPackageOperation.None;
					args.Handled = true;
				}
			}
			UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, null);
		}
		base.OnDragOver(args);
	}

	protected override void OnDragEnter(DragEventArgs args)
	{
		if (!args.Handled)
		{
			UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: false, null);
		}
		base.OnDragEnter(args);
	}

	protected override void OnDragLeave(DragEventArgs args)
	{
		m_emptySlotIndex = -1;
		base.OnDragLeave(args);
		if (!args.Handled)
		{
			UpdateDropTargetDropEffect(forceUpdate: false, isLeaving: true, null);
		}
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		TreeViewNode itemNode = NodeFromContainer(element);
		TreeViewItem itemContainer = (TreeViewItem)element;
		TreeNodeSelectionState selectionState = itemNode.SelectionState;
		itemContainer.AllowDrop = true;
		if (IsContentMode)
		{
			bool flag = itemContainer.HasUnrealizedChildren || itemNode.HasChildren;
			itemContainer.GlyphOpacity = (flag ? 1.0 : 0.0);
			if (itemContainer.IsExpanded != itemNode.IsExpanded)
			{
				DispatcherHelper dispatcherHelper = new DispatcherHelper(this);
				dispatcherHelper.RunAsync(delegate
				{
					itemNode.IsExpanded = itemContainer.IsExpanded;
				});
			}
		}
		else
		{
			itemContainer.IsExpanded = itemNode.IsExpanded;
			itemContainer.GlyphOpacity = (itemNode.HasChildren ? 1.0 : 0.0);
		}
		TreeViewItemTemplateSettings treeViewItemTemplateSettings = itemContainer.TreeViewItemTemplateSettings;
		treeViewItemTemplateSettings.ExpandedGlyphVisibility = ((!itemNode.IsExpanded) ? Visibility.Collapsed : Visibility.Visible);
		treeViewItemTemplateSettings.CollapsedGlyphVisibility = (itemNode.IsExpanded ? Visibility.Collapsed : Visibility.Visible);
		base.PrepareContainerForItemOverride(element, item);
		if (selectionState != itemNode.SelectionState)
		{
			ListViewModel.UpdateSelection(itemNode, selectionState);
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new TreeViewItem
		{
			IsGeneratedContainer = true
		};
	}

	protected override void OnApplyTemplate()
	{
		if (!m_itemsSourceAttached)
		{
			base.ItemsSource = ListViewModel;
			base.IsItemClickEnabled = true;
			m_itemsSourceAttached = true;
		}
		base.OnApplyTemplate();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new Microsoft.UI.Xaml.Automation.Peers.TreeViewListAutomationPeer(this);
	}

	internal string GetDropTargetDropEffect()
	{
		if (string.IsNullOrEmpty(m_dropTargetDropEffectString))
		{
			UpdateDropTargetDropEffect(forceUpdate: true, isLeaving: false, null);
		}
		return m_dropTargetDropEffectString;
	}

	internal void SetDraggedOverItem(TreeViewItem newDraggedOverItem)
	{
		m_draggedOverItem = newDraggedOverItem;
	}

	internal void UpdateDropTargetDropEffect(bool forceUpdate, bool isLeaving, TreeViewItem keyboardReorderedContainer)
	{
		string dropTargetDropEffectString = m_dropTargetDropEffectString;
		TreeViewItem treeViewItem = null;
		AutomationPeer automationPeer = null;
		if (keyboardReorderedContainer != null)
		{
			treeViewItem = keyboardReorderedContainer;
		}
		else
		{
			DependencyObject dependencyObject = ContainerFromItem(m_draggedOverItem);
			if (dependencyObject != null)
			{
				treeViewItem = (TreeViewItem)dependencyObject;
			}
		}
		if (treeViewItem == null)
		{
			return;
		}
		string text = "";
		string priorString = "";
		string afterString = "";
		string dragOverString = "";
		automationPeer = FrameworkElementAutomationPeer.FromElement(treeViewItem);
		if (automationPeer != null)
		{
			text = automationPeer.GetName();
		}
		if (string.IsNullOrEmpty(text))
		{
			text = ResourceAccessor.GetLocalizedStringResource("DefaultItemString");
		}
		if (isLeaving)
		{
			m_dropTargetDropEffectString = StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("CancelDraggingString"), text);
		}
		else
		{
			if (m_draggedOverItem != null)
			{
				AutomationPeer automationPeer2 = FrameworkElementAutomationPeer.FromElement(m_draggedOverItem);
				if (automationPeer2 != null)
				{
					dragOverString = automationPeer2.GetName();
				}
			}
			else
			{
				int num = -1;
				int num2 = -1;
				int num3 = -1;
				int num4 = IndexFromContainer(treeViewItem);
				num = ((keyboardReorderedContainer == null) ? m_emptySlotIndex : num4);
				if (num != -1)
				{
					num2 = num + 1;
					num3 = num - 1;
				}
				if (num > num4)
				{
					num3++;
				}
				else if (num < num4)
				{
					num2--;
				}
				priorString = GetAutomationName(num3);
				afterString = GetAutomationName(num2);
			}
			m_dropTargetDropEffectString = BuildEffectString(priorString, afterString, text, dragOverString);
		}
		if (!forceUpdate && dropTargetDropEffectString != m_dropTargetDropEffectString)
		{
			AutomationPeer automationPeer3 = FrameworkElementAutomationPeer.FromElement(this);
			automationPeer3.RaisePropertyChangedEvent(DropTargetPatternIdentifiers.DropTargetEffectProperty, dropTargetDropEffectString, m_dropTargetDropEffectString);
		}
	}

	internal void EnableMultiselect(bool isEnabled)
	{
		m_isMultiselectEnabled = isEnabled;
	}

	internal bool IsSelected(TreeViewNode node)
	{
		bool result = false;
		IList<TreeViewNode> selectedNodes = ListViewModel.SelectedNodes;
		for (int i = 0; i < selectedNodes.Count; i++)
		{
			if (selectedNodes[i] == node)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal IList<TreeViewNode> GetRootsOfSelectedSubtrees()
	{
		List<TreeViewNode> list = new List<TreeViewNode>();
		IList<TreeViewNode> selectedNodes = ListViewModel.SelectedNodes;
		for (int i = 0; i < selectedNodes.Count; i++)
		{
			TreeViewNode node = selectedNodes[i];
			TreeViewNode rootOfSelection = GetRootOfSelection(node);
			if (!list.Contains(rootOfSelection))
			{
				list.Add(rootOfSelection);
			}
		}
		return list;
	}

	internal int FlatIndex(TreeViewNode node)
	{
		int index;
		return ListViewModel.IndexOfNode(node, out index) ? index : (-1);
	}

	internal bool IsFlatIndexValid(int index)
	{
		if (index >= 0)
		{
			return index < ListViewModel.Count;
		}
		return false;
	}

	internal int RemoveNodeFromParent(TreeViewNode node)
	{
		TreeViewNodeVector treeViewNodeVector = (TreeViewNodeVector)node.Parent.Children;
		int num = treeViewNodeVector.IndexOf(node);
		if (num > -1)
		{
			treeViewNodeVector.RemoveAt(num);
		}
		return num;
	}

	private bool IsIndexValid(int index)
	{
		if (index >= 0)
		{
			return index < base.Items.Count;
		}
		return false;
	}

	private string GetAutomationName(int index)
	{
		TreeViewItem treeViewItem = null;
		string result = "";
		if (IsIndexValid(index) && ContainerFromIndex(index) is TreeViewItem treeViewItem2)
		{
			treeViewItem = treeViewItem2;
		}
		if (treeViewItem != null)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(treeViewItem);
			if (automationPeer != null)
			{
				result = automationPeer.GetName();
			}
		}
		return result;
	}

	private string BuildEffectString(string priorString, string afterString, string dragString, string dragOverString)
	{
		if (!string.IsNullOrEmpty(priorString) && !string.IsNullOrEmpty(afterString))
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("PlaceBetweenString"), dragString, priorString, afterString);
		}
		if (!string.IsNullOrEmpty(priorString))
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("PlaceAfterString"), dragString, priorString);
		}
		if (!string.IsNullOrEmpty(afterString))
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("PlaceBeforeString"), dragString, afterString);
		}
		if (!string.IsNullOrEmpty(dragOverString))
		{
			return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("DropIntoNodeString"), dragString, dragOverString);
		}
		return StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("FallBackPlaceString"), dragString);
	}

	private int IndexInParent(TreeViewNode node)
	{
		return node.Parent.Children.IndexOf(node);
	}

	private TreeViewNode NodeAtFlatIndex(int index)
	{
		return ListViewModel.GetNodeAt(index);
	}

	private TreeViewNode GetRootOfSelection(TreeViewNode node)
	{
		TreeViewNode treeViewNode = node;
		while (treeViewNode.Parent != null && IsSelected(treeViewNode.Parent))
		{
			treeViewNode = treeViewNode.Parent;
		}
		return treeViewNode;
	}

	internal TreeViewNode NodeFromContainer(DependencyObject container)
	{
		int num = ((container != null) ? IndexFromContainer(container) : (-1));
		if (num >= 0 && num < ListViewModel.Count)
		{
			return NodeAtFlatIndex(num);
		}
		return null;
	}

	internal DependencyObject ContainerFromNode(TreeViewNode node)
	{
		if (node == null)
		{
			return null;
		}
		if (!IsContentMode)
		{
			return ContainerFromItem(node);
		}
		return ContainerFromItem(node.Content);
	}

	internal TreeViewNode NodeFromItem(object item)
	{
		if (!IsContentMode)
		{
			return item as TreeViewNode;
		}
		return ListViewModel.GetAssociatedNode(item);
	}

	internal object ItemFromNode(TreeViewNode node)
	{
		if (!IsContentMode || node == null)
		{
			return node;
		}
		return node.Content;
	}

	private T GetAncestorView<T>() where T : class
	{
		DependencyObject dependencyObject = this;
		T val = null;
		while (dependencyObject != null && val == null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			val = dependencyObject as T;
		}
		return val;
	}
}
