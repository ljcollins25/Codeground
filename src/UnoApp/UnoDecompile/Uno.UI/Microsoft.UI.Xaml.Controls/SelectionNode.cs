using System.Collections.Generic;
using System.Collections.Specialized;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

internal class SelectionNode
{
	private SelectionModel m_manager;

	private List<SelectionNode> m_childrenNodes = new List<SelectionNode>();

	private SelectionNode m_parent;

	private List<IndexRange> m_selected = new List<IndexRange>();

	private object m_source;

	private ItemsSourceView m_dataSource;

	private int m_selectedCount;

	private List<int> m_selectedIndicesCached = new List<int>();

	private bool m_selectedIndicesCacheIsValid;

	private int m_realizedChildrenNodeCount;

	internal object Source
	{
		get
		{
			return m_source;
		}
		set
		{
			if (m_source != value)
			{
				ClearSelection();
				UnhookCollectionChangedHandler();
				m_source = value;
				ItemsSourceView itemsSourceView = value as ItemsSourceView;
				if (value != null && itemsSourceView == null)
				{
					itemsSourceView = new InspectingDataSource(value);
				}
				m_dataSource = itemsSourceView;
				HookupCollectionChangedHandler();
				OnSelectionChanged();
			}
		}
	}

	internal ItemsSourceView ItemsSourceView => m_dataSource;

	internal int DataCount
	{
		get
		{
			if (m_dataSource != null)
			{
				return m_dataSource.Count;
			}
			return 0;
		}
	}

	internal int ChildrenNodeCount => m_childrenNodes.Count;

	internal int AnchorIndex { get; set; } = -1;


	private IndexPath IndexPath
	{
		get
		{
			List<int> list = new List<int>();
			SelectionNode parent = m_parent;
			SelectionNode item = this;
			while (parent != null)
			{
				List<SelectionNode> childrenNodes = parent.m_childrenNodes;
				int num = childrenNodes.IndexOf(item);
				int item2 = num;
				list.Insert(0, item2);
				item = parent;
				parent = parent.m_parent;
			}
			return new IndexPath(list);
		}
	}

	internal int SelectedCount => m_selectedCount;

	private int SelectedIndex
	{
		get
		{
			if (SelectedCount <= 0)
			{
				return -1;
			}
			return SelectedIndices[0];
		}
		set
		{
			if (IsValidIndex(value) && (SelectedCount != 1 || !IsSelected(value)))
			{
				ClearSelection();
				if (value != -1)
				{
					Select(value, select: true);
				}
			}
		}
	}

	internal IList<int> SelectedIndices
	{
		get
		{
			if (!m_selectedIndicesCacheIsValid)
			{
				m_selectedIndicesCacheIsValid = true;
				foreach (IndexRange item in m_selected)
				{
					for (int i = item.Begin; i <= item.End; i++)
					{
						if (m_selectedIndicesCached.IndexOf(i) == -1)
						{
							m_selectedIndicesCached.Add(i);
						}
					}
				}
				m_selectedIndicesCached.Sort();
			}
			return m_selectedIndicesCached;
		}
	}

	internal SelectionNode(SelectionModel manager, SelectionNode parent)
	{
		m_manager = manager;
		m_parent = parent;
		m_source = null;
		m_dataSource = null;
	}

	~SelectionNode()
	{
		UnhookCollectionChangedHandler();
	}

	private int RealizedChildrenNodeCount()
	{
		return m_realizedChildrenNodeCount;
	}

	internal SelectionNode GetAt(int index, bool realizeChild)
	{
		SelectionNode selectionNode = null;
		if (realizeChild)
		{
			if (m_childrenNodes.Count == 0 && m_dataSource != null)
			{
				for (int i = 0; i < m_dataSource.Count; i++)
				{
					m_childrenNodes.Add(null);
				}
			}
			if (m_childrenNodes[index] == null)
			{
				object at = m_dataSource.GetAt(index);
				if (at != null)
				{
					IndexPath dataIndexPath = IndexPath.CloneWithChildIndex(index);
					object obj = m_manager.ResolvePath(at, dataIndexPath);
					if (obj != null)
					{
						selectionNode = new SelectionNode(m_manager, this);
						selectionNode.Source = obj;
					}
					else
					{
						selectionNode = m_manager.SharedLeafNode;
					}
				}
				else
				{
					selectionNode = m_manager.SharedLeafNode;
				}
				m_childrenNodes[index] = selectionNode;
				m_realizedChildrenNodeCount++;
			}
			else
			{
				selectionNode = m_childrenNodes[index];
			}
		}
		else if (m_childrenNodes.Count > 0)
		{
			selectionNode = m_childrenNodes[index];
		}
		return selectionNode;
	}

	internal bool IsSelected(int index)
	{
		bool result = false;
		foreach (IndexRange item in m_selected)
		{
			if (item.Contains(index))
			{
				return true;
			}
		}
		return result;
	}

	internal bool? IsSelectedWithPartial()
	{
		bool? result = (bool?)PropertyValue.CreateBoolean(value: false);
		if (m_parent != null)
		{
			List<SelectionNode> childrenNodes = m_parent.m_childrenNodes;
			int num = childrenNodes.IndexOf(this);
			if (num >= 0)
			{
				int index = num;
				result = m_parent.IsSelectedWithPartial(index);
			}
		}
		return result;
	}

	internal bool? IsSelectedWithPartial(int index)
	{
		SelectionState selectionState = SelectionState.NotSelected;
		if (m_childrenNodes.Count == 0 || m_childrenNodes.Count <= index || m_childrenNodes[index] == null || m_childrenNodes[index] == m_manager.SharedLeafNode)
		{
			selectionState = ((!IsSelected(index)) ? SelectionState.NotSelected : SelectionState.Selected);
		}
		else
		{
			SelectionNode selectionNode = m_childrenNodes[index];
			selectionState = selectionNode.EvaluateIsSelectedBasedOnChildrenNodes();
		}
		return ConvertToNullableBool(selectionState);
	}

	internal bool Select(int index, bool select)
	{
		return Select(index, select, raiseOnSelectionChanged: true);
	}

	private bool ToggleSelect(int index)
	{
		return Select(index, !IsSelected(index));
	}

	internal void SelectAll()
	{
		if (m_dataSource != null)
		{
			int count = m_dataSource.Count;
			if (count > 0)
			{
				SelectRange(new IndexRange(0, count - 1), select: true);
			}
		}
	}

	internal void Clear()
	{
		ClearSelection();
	}

	internal bool SelectRange(IndexRange range, bool select)
	{
		if (IsValidIndex(range.Begin) && IsValidIndex(range.End))
		{
			if (select)
			{
				AddRange(range, raiseOnSelectionChanged: true);
			}
			else
			{
				RemoveRange(range, raiseOnSelectionChanged: true);
			}
			return true;
		}
		return false;
	}

	private void HookupCollectionChangedHandler()
	{
		if (m_dataSource != null)
		{
			m_dataSource.CollectionChanged += OnSourceListChanged;
		}
	}

	private void UnhookCollectionChangedHandler()
	{
		if (m_dataSource != null)
		{
			m_dataSource.CollectionChanged -= OnSourceListChanged;
		}
	}

	private bool IsValidIndex(int index)
	{
		if (ItemsSourceView != null)
		{
			if (index >= 0)
			{
				return index < ItemsSourceView.Count;
			}
			return false;
		}
		return true;
	}

	private void AddRange(IndexRange addRange, bool raiseOnSelectionChanged)
	{
		int selectedCount = SelectedCount;
		for (int i = addRange.Begin; i <= addRange.End; i++)
		{
			if (!IsSelected(i))
			{
				m_selectedCount++;
			}
		}
		if (selectedCount != m_selectedCount)
		{
			m_selected.Add(addRange);
			if (raiseOnSelectionChanged)
			{
				OnSelectionChanged();
			}
		}
	}

	private void RemoveRange(IndexRange removeRange, bool raiseOnSelectionChanged)
	{
		int selectedCount = m_selectedCount;
		for (int i = removeRange.Begin; i <= removeRange.End; i++)
		{
			if (IsSelected(i))
			{
				m_selectedCount--;
			}
		}
		if (selectedCount == m_selectedCount)
		{
			return;
		}
		List<IndexRange> list = new List<IndexRange>();
		List<IndexRange> list2 = new List<IndexRange>();
		foreach (IndexRange item in m_selected)
		{
			if (removeRange.Intersects(item))
			{
				IndexRange before = new IndexRange(-1, -1);
				IndexRange after = new IndexRange(-1, -1);
				IndexRange after2 = new IndexRange(-1, -1);
				if (item.Contains(removeRange.Begin - 1))
				{
					item.Split(removeRange.Begin - 1, ref before, ref after);
					list2.Add(before);
				}
				if (item.Contains(removeRange.End) && item.Split(removeRange.End, ref after, ref after2))
				{
					list2.Add(after2);
				}
				list.Add(item);
			}
		}
		if (list.Count <= 0 && list2.Count <= 0)
		{
			return;
		}
		foreach (IndexRange item2 in list)
		{
			m_selected.Remove(item2);
		}
		foreach (IndexRange item3 in list2)
		{
			m_selected.Add(item3);
		}
		if (raiseOnSelectionChanged)
		{
			OnSelectionChanged();
		}
	}

	private void ClearSelection()
	{
		if (m_selected.Count > 0)
		{
			m_selected.Clear();
			OnSelectionChanged();
		}
		m_selectedCount = 0;
		AnchorIndex = -1;
		m_childrenNodes.Clear();
	}

	private bool Select(int index, bool select, bool raiseOnSelectionChanged)
	{
		if (IsValidIndex(index))
		{
			if (IsSelected(index) == select)
			{
				return true;
			}
			IndexRange indexRange = new IndexRange(index, index);
			if (select)
			{
				AddRange(indexRange, raiseOnSelectionChanged);
			}
			else
			{
				RemoveRange(indexRange, raiseOnSelectionChanged);
			}
			return true;
		}
		return false;
	}

	private void OnSourceListChanged(object dataSource, NotifyCollectionChangedEventArgs args)
	{
		bool flag = false;
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
			flag = OnItemsAdded(args.NewStartingIndex, args.NewItems!.Count);
			break;
		case NotifyCollectionChangedAction.Remove:
			flag = OnItemsRemoved(args.OldStartingIndex, args.OldItems!.Count);
			break;
		case NotifyCollectionChangedAction.Reset:
			ClearSelection();
			flag = true;
			break;
		case NotifyCollectionChangedAction.Replace:
			flag = OnItemsRemoved(args.OldStartingIndex, args.OldItems!.Count);
			flag |= OnItemsAdded(args.NewStartingIndex, args.NewItems!.Count);
			break;
		}
		if (flag)
		{
			OnSelectionChanged();
			m_manager.OnSelectionInvalidatedDueToCollectionChange();
		}
	}

	private bool OnItemsAdded(int index, int count)
	{
		bool flag = false;
		List<IndexRange> list = new List<IndexRange>();
		for (int i = 0; i < m_selected.Count; i++)
		{
			IndexRange indexRange = m_selected[i];
			if (indexRange.End >= index)
			{
				int num = indexRange.Begin;
				if (indexRange.Contains(index - 1))
				{
					IndexRange before = new IndexRange(-1, -1);
					IndexRange after = new IndexRange(-1, -1);
					indexRange.Split(index - 1, ref before, ref after);
					list.Add(before);
					num = index;
				}
				m_selected[i] = new IndexRange(num + count, indexRange.End + count);
				flag = true;
			}
		}
		if (list.Count > 0)
		{
			foreach (IndexRange item in list)
			{
				m_selected.Add(item);
			}
		}
		if (m_childrenNodes.Count > 0)
		{
			flag = true;
			for (int j = 0; j < count; j++)
			{
				m_childrenNodes.Insert(index, null);
			}
		}
		if (AnchorIndex >= index)
		{
			AnchorIndex += count;
		}
		if (!flag)
		{
			for (SelectionNode parent = m_parent; parent != null; parent = parent.m_parent)
			{
				bool? flag2 = parent.IsSelectedWithPartial();
				if (flag2.HasValue && flag2.Value)
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	private bool OnItemsRemoved(int index, int count)
	{
		bool flag = false;
		if (ItemsSourceView.Count > 0)
		{
			bool flag2 = false;
			for (int i = index; i <= index + count - 1; i++)
			{
				if (IsSelected(i))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				RemoveRange(new IndexRange(index, index + count - 1), raiseOnSelectionChanged: false);
				flag = true;
			}
			for (int j = 0; j < m_selected.Count; j++)
			{
				IndexRange indexRange = m_selected[j];
				if (indexRange.End > index)
				{
					m_selected[j] = new IndexRange(indexRange.Begin - count, indexRange.End - count);
					flag = true;
				}
			}
			if (m_childrenNodes.Count > 0)
			{
				flag = true;
				for (int k = 0; k < count; k++)
				{
					if (m_childrenNodes[index] != null)
					{
						m_realizedChildrenNodeCount--;
					}
					m_childrenNodes.RemoveAt(index);
				}
			}
			if (AnchorIndex >= index)
			{
				AnchorIndex -= count;
			}
		}
		else
		{
			ClearSelection();
			m_realizedChildrenNodeCount = 0;
			flag = true;
		}
		if (!flag)
		{
			for (SelectionNode parent = m_parent; parent != null; parent = parent.m_parent)
			{
				if (parent.IsSelectedWithPartial() != true)
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	private void OnSelectionChanged()
	{
		m_selectedIndicesCacheIsValid = false;
		m_selectedIndicesCached.Clear();
	}

	internal static bool? ConvertToNullableBool(SelectionState isSelected)
	{
		bool? flag = null;
		return isSelected switch
		{
			SelectionState.Selected => (bool?)PropertyValue.CreateBoolean(value: true), 
			SelectionState.NotSelected => (bool?)PropertyValue.CreateBoolean(value: false), 
			_ => flag, 
		};
	}

	internal SelectionState EvaluateIsSelectedBasedOnChildrenNodes()
	{
		SelectionState selectionState = SelectionState.NotSelected;
		int num = RealizedChildrenNodeCount();
		int selectedCount = SelectedCount;
		if (num != 0 || selectedCount != 0)
		{
			int dataCount = DataCount;
			if (num == 0 && selectedCount > 0)
			{
				selectionState = ((dataCount != selectedCount) ? SelectionState.PartiallySelected : ((dataCount != selectedCount) ? SelectionState.NotSelected : SelectionState.Selected));
			}
			else
			{
				selectedCount = 0;
				int num2 = 0;
				for (int i = 0; i < ChildrenNodeCount; i++)
				{
					SelectionNode at = GetAt(i, realizeChild: false);
					if (at != null)
					{
						bool? flag = IsSelectedWithPartial(i);
						if (!flag.HasValue)
						{
							selectionState = SelectionState.PartiallySelected;
							break;
						}
						if (flag.Value)
						{
							selectedCount++;
						}
						else
						{
							num2++;
						}
					}
					else if (IsSelected(i))
					{
						selectedCount++;
					}
					else
					{
						num2++;
					}
					if (selectedCount > 0 && num2 > 0)
					{
						selectionState = SelectionState.PartiallySelected;
						break;
					}
				}
				if (selectionState != SelectionState.PartiallySelected)
				{
					selectionState = ((selectedCount == 0 || selectedCount == dataCount) ? ((selectedCount != dataCount) ? SelectionState.NotSelected : SelectionState.Selected) : SelectionState.PartiallySelected);
				}
			}
		}
		return selectionState;
	}
}
