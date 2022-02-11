using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

internal class TreeViewViewModel : ObservableVector<object>
{
	private class TreeViewViewModelEnumerator : IEnumerator<object>, IEnumerator, IDisposable
	{
		private readonly TreeViewViewModel _treeViewViewModel;

		private int _currentIndex = -1;

		public object Current => _treeViewViewModel[_currentIndex];

		public TreeViewViewModelEnumerator(TreeViewViewModel treeViewViewModel)
		{
			_treeViewViewModel = treeViewViewModel;
		}

		public bool MoveNext()
		{
			_currentIndex++;
			return _currentIndex < _treeViewViewModel.Count;
		}

		public void Reset()
		{
			_currentIndex = -1;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}

	private readonly SelectedTreeNodeVector m_selectedNodes;

	private readonly SelectedItemsVector m_selectedItems;

	private readonly Dictionary<object, TreeViewNode> m_itemToNodeMap;

	private TreeViewNode m_originNode;

	private TreeViewList m_TreeViewList;

	private TreeView m_TreeView;

	private bool m_isContentMode;

	private int m_selectionTrackingCounter;

	private readonly List<WeakReference<object>> m_addedSelectedItems = new List<WeakReference<object>>();

	private List<object> m_removedSelectedItems = new List<object>();

	public override object this[int index]
	{
		get
		{
			return GetAt(index);
		}
		set
		{
			SetAt(index, value);
		}
	}

	internal TreeViewList ListControl => m_TreeViewList;

	internal IList<TreeViewNode> SelectedNodes => m_selectedNodes;

	internal IList<object> SelectedItems => m_selectedItems;

	public bool IsContentMode
	{
		get
		{
			return m_isContentMode;
		}
		set
		{
			m_isContentMode = value;
		}
	}

	internal event TypedEventHandler<TreeViewNode, object> NodeExpanding;

	internal event TypedEventHandler<TreeViewNode, object> NodeCollapsed;

	public TreeViewViewModel()
	{
		SelectedTreeNodeVector selectedTreeNodeVector = new SelectedTreeNodeVector();
		selectedTreeNodeVector.SetViewModel(this);
		m_selectedNodes = selectedTreeNodeVector;
		SelectedItemsVector selectedItemsVector = new SelectedItemsVector();
		selectedItemsVector.SetViewModel(this);
		m_selectedItems = selectedItemsVector;
		m_itemToNodeMap = new Dictionary<object, TreeViewNode>();
	}

	~TreeViewViewModel()
	{
		TreeViewNode originNode = m_originNode;
		if (originNode != null)
		{
			originNode.ChildrenChanged -= TreeViewNodeVectorChanged;
		}
		ClearEventTokenVectors();
	}

	internal void ExpandNode(TreeViewNode value)
	{
		value.IsExpanded = true;
	}

	internal void CollapseNode(TreeViewNode value)
	{
		value.IsExpanded = false;
	}

	internal void SelectAll()
	{
		try
		{
			BeginSelectionChanges();
			UpdateSelection(m_originNode, TreeNodeSelectionState.Selected);
		}
		finally
		{
			EndSelectionChanges();
		}
	}

	internal void SelectSingleItem(object item)
	{
		try
		{
			BeginSelectionChanges();
			IList<object> selectedItems = SelectedItems;
			if (selectedItems.Count > 0)
			{
				selectedItems.Clear();
			}
			if (item != null)
			{
				selectedItems.Add(item);
			}
		}
		finally
		{
			EndSelectionChanges();
		}
	}

	internal void SelectNode(TreeViewNode node, bool isSelected)
	{
		try
		{
			BeginSelectionChanges();
			IList<TreeViewNode> selectedNodes = SelectedNodes;
			int index;
			if (isSelected)
			{
				if (IsInSingleSelectionMode() && selectedNodes.Count > 0)
				{
					selectedNodes.Clear();
				}
				selectedNodes.Add(node);
			}
			else if ((index = selectedNodes.IndexOf(node)) > -1)
			{
				selectedNodes.RemoveAt(index);
			}
		}
		finally
		{
			EndSelectionChanges();
		}
	}

	internal void SelectByIndex(int index, TreeNodeSelectionState state)
	{
		try
		{
			BeginSelectionChanges();
			TreeViewNode nodeAt = GetNodeAt(index);
			UpdateSelection(nodeAt, state);
		}
		finally
		{
			EndSelectionChanges();
		}
	}

	internal void BeginSelectionChanges()
	{
		if (!IsInSingleSelectionMode())
		{
			m_selectionTrackingCounter++;
			if (m_selectionTrackingCounter == 1)
			{
				m_addedSelectedItems.Clear();
				m_removedSelectedItems.Clear();
			}
		}
	}

	internal void EndSelectionChanges()
	{
		if (IsInSingleSelectionMode())
		{
			return;
		}
		m_selectionTrackingCounter--;
		if (m_selectionTrackingCounter != 0 || (m_addedSelectedItems.Count <= 0 && m_removedSelectedItems.Count <= 0))
		{
			return;
		}
		TreeView treeView = m_TreeView;
		List<object> list = new List<object>();
		for (int i = 0; i < m_addedSelectedItems.Count; i++)
		{
			WeakReference<object> weakReference = m_addedSelectedItems[i];
			if (weakReference.TryGetTarget(out var target))
			{
				list.Add(target);
			}
		}
		List<object> list2 = new List<object>();
		for (int j = 0; j < m_removedSelectedItems.Count; j++)
		{
			object item = m_removedSelectedItems[j];
			list2.Add(item);
		}
		treeView.RaiseSelectionChanged(list, list2);
	}

	private object GetAt(int index)
	{
		TreeViewNode nodeAt = GetNodeAt(index);
		if (!IsContentMode)
		{
			return nodeAt;
		}
		return nodeAt.Content;
	}

	private object[] GetMany(int startIndex)
	{
		if (IsContentMode)
		{
			List<object> list = new List<object>();
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(GetNodeAt(i).Content);
			}
			return list.Skip(startIndex).ToArray();
		}
		List<object> list2 = new List<object>();
		for (int j = startIndex; j < base.Count; j++)
		{
			list2.Add(base[j]);
		}
		return list2.ToArray();
	}

	internal TreeViewNode GetNodeAt(int index)
	{
		return (TreeViewNode)base[index];
	}

	private void SetAt(int index, object value)
	{
		TreeViewNode treeViewNode = (TreeViewNode)base[index];
		base[index] = value;
		TreeViewNode treeViewNode2 = (TreeViewNode)value;
		TreeViewNode treeViewNode3 = treeViewNode;
		treeViewNode3.ChildrenChanged -= TreeViewNodeVectorChanged;
		treeViewNode3.ExpandedChanged -= TreeViewNodePropertyChanged;
		TreeViewNode treeViewNode4 = treeViewNode2;
		treeViewNode4.ChildrenChanged += TreeViewNodeVectorChanged;
		treeViewNode4.ExpandedChanged += TreeViewNodePropertyChanged;
	}

	internal void InsertAt(int index, object value)
	{
		base.Insert(index, value);
		TreeViewNode treeViewNode = (TreeViewNode)value;
		TreeViewNode treeViewNode2 = treeViewNode;
		treeViewNode2.ChildrenChanged += TreeViewNodeVectorChanged;
		treeViewNode2.ExpandedChanged += TreeViewNodePropertyChanged;
	}

	public override void Insert(int index, object item)
	{
		InsertAt(index, item);
	}

	public override void RemoveAt(int index)
	{
		TreeViewNode treeViewNode = (TreeViewNode)base[index];
		base.RemoveAt(index);
		TreeViewNode treeViewNode2 = treeViewNode;
		treeViewNode2.ChildrenChanged -= TreeViewNodeVectorChanged;
		treeViewNode2.ExpandedChanged -= TreeViewNodePropertyChanged;
	}

	private void Append(object value)
	{
		base.Add(value);
		TreeViewNode treeViewNode = (TreeViewNode)value;
		TreeViewNode treeViewNode2 = treeViewNode;
		treeViewNode2.ChildrenChanged += TreeViewNodeVectorChanged;
		treeViewNode2.ExpandedChanged += TreeViewNodePropertyChanged;
	}

	public override void Add(object item)
	{
		Append(item);
	}

	private void RemoveAtEnd()
	{
		TreeViewNode treeViewNode = (TreeViewNode)base[base.Count - 1];
		base.RemoveAt(base.Count - 1);
		TreeViewNode treeViewNode2 = treeViewNode;
		treeViewNode2.ChildrenChanged -= TreeViewNodeVectorChanged;
		treeViewNode2.ExpandedChanged -= TreeViewNodePropertyChanged;
	}

	public override void Clear()
	{
		for (int num = base.Count; num != 0; num--)
		{
			RemoveAtEnd();
		}
	}

	private void ReplaceAll(object[] items)
	{
		base.Clear();
		foreach (object item in items)
		{
			base.Add(item);
		}
	}

	internal void PrepareView(TreeViewNode originNode)
	{
		TreeViewNode originNode2 = m_originNode;
		if (originNode2 != null)
		{
			for (int num = originNode2.Children.Count - 1; num >= 0; num--)
			{
				TreeViewNode value = originNode2.Children[num];
				RemoveNodeAndDescendantsFromView(value);
			}
			originNode2.ChildrenChanged -= TreeViewNodeVectorChanged;
		}
		m_originNode = originNode;
		originNode.ChildrenChanged += TreeViewNodeVectorChanged;
		originNode.IsExpanded = true;
		int num2 = 0;
		for (int i = 0; i < originNode.Children.Count; i++)
		{
			TreeViewNode value2 = originNode.Children[i];
			AddNodeToView(value2, i + num2);
			num2 = AddNodeDescendantsToView(value2, i, num2);
		}
	}

	internal void SetOwners(TreeViewList owningList, TreeView owningTreeView)
	{
		m_TreeViewList = owningList;
		m_TreeView = owningTreeView;
	}

	private bool IsInSingleSelectionMode()
	{
		return m_TreeViewList.SelectionMode == ListViewSelectionMode.Single;
	}

	private void AddNodeToView(TreeViewNode value, int index)
	{
		Insert(index, value);
	}

	private int AddNodeDescendantsToView(TreeViewNode value, int index, int offset)
	{
		if (value.IsExpanded)
		{
			int count = value.Children.Count;
			for (int i = 0; i < count; i++)
			{
				TreeViewNode value2 = value.Children[i];
				offset++;
				AddNodeToView(value2, offset + index);
				offset = AddNodeDescendantsToView(value2, index, offset);
			}
			return offset;
		}
		return offset;
	}

	private void RemoveNodeAndDescendantsFromView(TreeViewNode value)
	{
		if (value.IsExpanded)
		{
			int count = value.Children.Count;
			for (int i = 0; i < count; i++)
			{
				TreeViewNode value2 = value.Children[i];
				RemoveNodeAndDescendantsFromView(value2);
			}
		}
		if (IndexOfNode(value, out var index))
		{
			RemoveAt(index);
		}
	}

	private void RemoveNodesAndDescendentsWithFlatIndexRange(int lowIndex, int highIndex)
	{
		if (lowIndex > highIndex)
		{
			throw new ArgumentOutOfRangeException("lowIndex");
		}
		for (int num = highIndex; num >= lowIndex; num--)
		{
			RemoveNodeAndDescendantsFromView(GetNodeAt(num));
		}
	}

	private int GetNextIndexInFlatTree(TreeViewNode node)
	{
		if (IndexOfNode(node, out var index))
		{
			return index + 1;
		}
		return 0;
	}

	private TreeViewNode GetRemovedChildTreeViewNodeByIndex(TreeViewNode node, int childIndex)
	{
		int num = 0;
		for (int i = 0; i < childIndex; i++)
		{
			TreeViewNode treeViewNode = node.Children[i];
			if (treeViewNode.IsExpanded)
			{
				num += GetExpandedDescendantCount(treeViewNode);
			}
		}
		int index = GetNextIndexInFlatTree(node) + childIndex + num;
		return GetNodeAt(index);
	}

	private int CountDescendants(TreeViewNode value)
	{
		int num = 0;
		int count = value.Children.Count;
		for (int i = 0; i < count; i++)
		{
			TreeViewNode treeViewNode = value.Children[i];
			num++;
			if (treeViewNode.IsExpanded)
			{
				num += CountDescendants(treeViewNode);
			}
		}
		return num;
	}

	private int IndexOfNextSibling(TreeViewNode childNode)
	{
		TreeViewNode treeViewNode = childNode;
		TreeViewNode parent = treeViewNode.Parent;
		bool flag = true;
		while (parent != null && flag)
		{
			int num = parent.Children.IndexOf(treeViewNode);
			if (parent.Children.Count - 1 != num)
			{
				flag = false;
				continue;
			}
			treeViewNode = parent;
			parent = parent.Parent;
		}
		if (parent != null)
		{
			int num2 = parent.Children.IndexOf(treeViewNode);
			TreeViewNode targetNode = parent.Children[num2 + 1];
			IndexOfNode(targetNode, out var index);
			return index;
		}
		return base.Count;
	}

	private int GetExpandedDescendantCount(TreeViewNode parentNode)
	{
		int num = 0;
		for (int i = 0; i < parentNode.Children.Count; i++)
		{
			TreeViewNode treeViewNode = parentNode.Children[i];
			num++;
			if (treeViewNode.IsExpanded)
			{
				num += CountDescendants(treeViewNode);
			}
		}
		return num;
	}

	internal bool IsNodeSelected(TreeViewNode targetNode)
	{
		return m_selectedNodes.IndexOf(targetNode) > -1;
	}

	private TreeNodeSelectionState NodeSelectionState(TreeViewNode targetNode)
	{
		return targetNode.SelectionState;
	}

	private void UpdateNodeSelection(TreeViewNode selectNode, TreeNodeSelectionState selectionState)
	{
		if (selectionState == selectNode.SelectionState)
		{
			return;
		}
		selectNode.SelectionState = selectionState;
		SelectedTreeNodeVector selectedNodes = m_selectedNodes;
		switch (selectionState)
		{
		case TreeNodeSelectionState.Selected:
			selectedNodes.InsertAtCore(selectedNodes.Count, selectNode);
			selectNode.ChildrenChanged += SelectedNodeChildrenChanged;
			break;
		case TreeNodeSelectionState.UnSelected:
		case TreeNodeSelectionState.PartialSelected:
		{
			int num = selectedNodes.IndexOf(selectNode);
			if (num > -1)
			{
				selectedNodes.RemoveAtCore(num);
				selectNode.ChildrenChanged -= SelectedNodeChildrenChanged;
			}
			break;
		}
		}
	}

	internal void UpdateSelection(TreeViewNode selectNode, TreeNodeSelectionState selectionState)
	{
		if (NodeSelectionState(selectNode) != selectionState)
		{
			UpdateNodeSelection(selectNode, selectionState);
			if (!IsInSingleSelectionMode())
			{
				UpdateSelectionStateOfDescendants(selectNode, selectionState);
				UpdateSelectionStateOfAncestors(selectNode);
			}
		}
	}

	private void UpdateSelectionStateOfDescendants(TreeViewNode targetNode, TreeNodeSelectionState selectionState)
	{
		if (selectionState == TreeNodeSelectionState.PartialSelected)
		{
			return;
		}
		foreach (TreeViewNode child in targetNode.Children)
		{
			UpdateNodeSelection(child, selectionState);
			UpdateSelectionStateOfDescendants(child, selectionState);
			NotifyContainerOfSelectionChange(child, selectionState);
		}
	}

	private void UpdateSelectionStateOfAncestors(TreeViewNode targetNode)
	{
		TreeViewNode parent = targetNode.Parent;
		if (parent != null && parent != m_originNode)
		{
			TreeNodeSelectionState treeNodeSelectionState = NodeSelectionState(parent);
			TreeNodeSelectionState treeNodeSelectionState2 = SelectionStateBasedOnChildren(parent);
			if (treeNodeSelectionState != treeNodeSelectionState2)
			{
				UpdateNodeSelection(parent, treeNodeSelectionState2);
				NotifyContainerOfSelectionChange(parent, treeNodeSelectionState2);
				UpdateSelectionStateOfAncestors(parent);
			}
		}
	}

	private TreeNodeSelectionState SelectionStateBasedOnChildren(TreeViewNode node)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (TreeViewNode child in node.Children)
		{
			TreeNodeSelectionState treeNodeSelectionState = NodeSelectionState(child);
			switch (treeNodeSelectionState)
			{
			case TreeNodeSelectionState.Selected:
				flag = true;
				break;
			case TreeNodeSelectionState.UnSelected:
				flag2 = true;
				break;
			}
			if ((flag && flag2) || treeNodeSelectionState == TreeNodeSelectionState.PartialSelected)
			{
				return TreeNodeSelectionState.PartialSelected;
			}
		}
		if (!flag)
		{
			return TreeNodeSelectionState.UnSelected;
		}
		return TreeNodeSelectionState.Selected;
	}

	internal void NotifyContainerOfSelectionChange(TreeViewNode targetNode, TreeNodeSelectionState selectionState)
	{
		if (m_TreeViewList != null)
		{
			DependencyObject dependencyObject = m_TreeViewList.ContainerFromNode(targetNode);
			if (dependencyObject != null)
			{
				TreeViewItem treeViewItem = (TreeViewItem)dependencyObject;
				treeViewItem.UpdateSelectionVisual(selectionState);
			}
			else if (!m_TreeViewList.IsMultiselect)
			{
				m_TreeViewList.SelectedItem = ((!IsContentMode) ? targetNode : targetNode?.Content);
			}
		}
	}

	internal void TrackItemSelected(object item)
	{
		if (m_selectionTrackingCounter > 0 && item != m_originNode)
		{
			m_addedSelectedItems.Add(new WeakReference<object>(item));
		}
	}

	internal void TrackItemUnselected(object item)
	{
		if (m_selectionTrackingCounter > 0 && item != m_originNode)
		{
			m_removedSelectedItems.Add(item);
		}
	}

	internal TreeViewNode GetAssociatedNode(object item)
	{
		return m_itemToNodeMap[item];
	}

	internal bool IndexOfNode(TreeViewNode targetNode, out int index)
	{
		index = IndexOf(targetNode);
		return index > -1;
	}

	private void TreeViewNodeVectorChanged(TreeViewNode sender, object args)
	{
		IVectorChangedEventArgs vectorChangedEventArgs = (IVectorChangedEventArgs)args;
		CollectionChange collectionChange = vectorChangedEventArgs.CollectionChange;
		int index = (int)vectorChangedEventArgs.Index;
		switch (collectionChange)
		{
		case CollectionChange.Reset:
			if (sender.IsExpanded)
			{
				int nextIndexInFlatTree = GetNextIndexInFlatTree(sender);
				int highIndex = IndexOfNextSibling(sender) - 1;
				RemoveNodesAndDescendentsWithFlatIndexRange(nextIndexInFlatTree, highIndex);
				CollapseNode(sender);
				ExpandNode(sender);
			}
			break;
		case CollectionChange.ItemInserted:
		{
			TreeViewNode treeViewNode2 = sender.Children[index];
			if (IsContentMode)
			{
				m_itemToNodeMap[treeViewNode2.Content] = treeViewNode2;
			}
			TreeViewNode parent = treeViewNode2.Parent;
			int nextIndexInFlatTree2 = GetNextIndexInFlatTree(parent);
			int num = 0;
			if (!parent.IsExpanded)
			{
				break;
			}
			for (int i = 0; i < parent.Children.Count; i++)
			{
				TreeViewNode treeViewNode3 = parent.Children[i];
				if (treeViewNode3 == treeViewNode2)
				{
					AddNodeToView(treeViewNode2, nextIndexInFlatTree2 + i + num);
					if (treeViewNode2.IsExpanded)
					{
						AddNodeDescendantsToView(treeViewNode2, nextIndexInFlatTree2 + i, num);
					}
				}
				else if (treeViewNode3.IsExpanded)
				{
					num += CountDescendants(treeViewNode3);
				}
			}
			break;
		}
		case CollectionChange.ItemRemoved:
			if (sender.IsExpanded)
			{
				TreeViewNode removedChildTreeViewNodeByIndex2 = GetRemovedChildTreeViewNodeByIndex(sender, index);
				RemoveNodeAndDescendantsFromView(removedChildTreeViewNodeByIndex2);
				if (IsContentMode)
				{
					m_itemToNodeMap.Remove(removedChildTreeViewNodeByIndex2.Content);
				}
			}
			break;
		case CollectionChange.ItemChanged:
		{
			TreeViewNode treeViewNode = sender.Children[index];
			if (sender.IsExpanded)
			{
				TreeViewNode removedChildTreeViewNodeByIndex = GetRemovedChildTreeViewNodeByIndex(sender, index);
				if (!IndexOfNode(removedChildTreeViewNodeByIndex, out var index2))
				{
					throw new InvalidOperationException("Node does not exist");
				}
				RemoveNodeAndDescendantsFromView(removedChildTreeViewNodeByIndex);
				Insert(index2, treeViewNode);
				if (IsContentMode)
				{
					m_itemToNodeMap.Remove(removedChildTreeViewNodeByIndex.Content);
					m_itemToNodeMap.Add(treeViewNode.Content, treeViewNode);
				}
			}
			break;
		}
		}
	}

	private void SelectedNodeChildrenChanged(TreeViewNode sender, object args)
	{
		IVectorChangedEventArgs vectorChangedEventArgs = (IVectorChangedEventArgs)args;
		CollectionChange collectionChange = vectorChangedEventArgs.CollectionChange;
		int index = (int)vectorChangedEventArgs.Index;
		switch (collectionChange)
		{
		case CollectionChange.ItemInserted:
		{
			TreeViewNode selectNode2 = sender.Children[index];
			if (!IsInSingleSelectionMode())
			{
				UpdateNodeSelection(selectNode2, NodeSelectionState(sender));
			}
			break;
		}
		case CollectionChange.ItemChanged:
		{
			TreeViewNode selectNode = sender.Children[index];
			UpdateNodeSelection(selectNode, NodeSelectionState(sender));
			SelectedTreeNodeVector selectedNodes2 = m_selectedNodes;
			for (int j = 0; j < selectedNodes2.Count; j++)
			{
				TreeViewNode treeViewNode2 = selectedNodes2[j];
				TreeViewNode parent2 = treeViewNode2.Parent;
				while (parent2 != null && parent2.Parent != null)
				{
					parent2 = parent2.Parent;
				}
				if (parent2 != m_originNode)
				{
					selectedNodes2.RemoveAtCore(j);
					treeViewNode2.ChildrenChanged -= SelectedNodeChildrenChanged;
				}
			}
			break;
		}
		case CollectionChange.Reset:
		case CollectionChange.ItemRemoved:
		{
			if (sender.Children.Count > 0)
			{
				TreeViewNode targetNode = sender.Children[0];
				UpdateSelectionStateOfAncestors(targetNode);
			}
			SelectedTreeNodeVector selectedNodes = m_selectedNodes;
			for (int i = 0; i < selectedNodes.Count; i++)
			{
				TreeViewNode treeViewNode = selectedNodes[i];
				TreeViewNode parent = treeViewNode.Parent;
				while (parent != null && parent.Parent != null)
				{
					parent = parent.Parent;
				}
				if (parent != m_originNode)
				{
					selectedNodes.RemoveAtCore(i);
					treeViewNode.ChildrenChanged -= SelectedNodeChildrenChanged;
				}
			}
			break;
		}
		}
	}

	private void TreeViewNodePropertyChanged(TreeViewNode sender, DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == TreeViewNode.IsExpandedProperty)
		{
			TreeViewNodeIsExpandedPropertyChanged(sender, args);
		}
		else if (property == TreeViewNode.HasChildrenProperty)
		{
			TreeViewNodeHasChildrenPropertyChanged(sender, args);
		}
	}

	private void TreeViewNodeIsExpandedPropertyChanged(TreeViewNode sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender.IsExpanded)
		{
			if (sender.Children.Count != 0)
			{
				int num = 0;
				IndexOfNode(sender, out var index);
				index++;
				for (int i = 0; i < sender.Children.Count; i++)
				{
					TreeViewNode value = sender.Children[i];
					AddNodeToView(value, index + i + num);
					num = AddNodeDescendantsToView(value, index + i, num);
				}
			}
			this.NodeExpanding?.Invoke(sender, null);
		}
		else
		{
			for (int j = 0; j < sender.Children.Count; j++)
			{
				TreeViewNode value2 = sender.Children[j];
				RemoveNodeAndDescendantsFromView(value2);
			}
			this.NodeCollapsed?.Invoke(sender, null);
		}
	}

	private void TreeViewNodeHasChildrenPropertyChanged(TreeViewNode sender, DependencyPropertyChangedEventArgs args)
	{
		if (m_TreeViewList != null)
		{
			DependencyObject dependencyObject = m_TreeViewList.ContainerFromNode(sender);
			if (dependencyObject != null)
			{
				TreeViewItem treeViewItem = (TreeViewItem)dependencyObject;
				treeViewItem.GlyphOpacity = (sender.HasChildren ? 1.0 : 0.0);
			}
		}
	}

	private void ClearEventTokenVectors()
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (i < base.Count)
			{
				object obj = base[i];
				TreeViewNode treeViewNode = (TreeViewNode)obj;
				treeViewNode.ChildrenChanged -= TreeViewNodeVectorChanged;
				treeViewNode.ExpandedChanged -= TreeViewNodePropertyChanged;
			}
		}
		SelectedTreeNodeVector selectedNodes = m_selectedNodes;
		if (selectedNodes == null)
		{
			return;
		}
		for (int j = 0; j < selectedNodes.Count; j++)
		{
			TreeViewNode treeViewNode2 = selectedNodes[j];
			if (treeViewNode2 != null)
			{
				TreeViewNode treeViewNode3 = treeViewNode2;
				treeViewNode3.ChildrenChanged -= SelectedNodeChildrenChanged;
			}
		}
	}

	public override IEnumerator<object> GetEnumerator()
	{
		return new TreeViewViewModelEnumerator(this);
	}
}
