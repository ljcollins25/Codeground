using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace Microsoft.UI.Xaml.Controls;

internal class SelectedTreeNodeVector : ObservableVector<TreeViewNode>
{
	private TreeViewViewModel m_viewModel;

	public override TreeViewNode this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			SetAt(index, value);
		}
	}

	private void UpdateSelection(TreeViewNode node, TreeNodeSelectionState state)
	{
		if (node.SelectionState != state)
		{
			TreeViewViewModel viewModel = m_viewModel;
			if (viewModel != null)
			{
				viewModel.UpdateSelection(node, state);
				viewModel.NotifyContainerOfSelectionChange(node, state);
			}
		}
	}

	public void SetViewModel(TreeViewViewModel viewModel)
	{
		m_viewModel = viewModel;
	}

	internal void Append(TreeViewNode node)
	{
		InsertAt(base.Count, node);
	}

	public override void Add(TreeViewNode node)
	{
		Append(node);
	}

	internal void InsertAt(int index, TreeViewNode node)
	{
		if (!Contains(node))
		{
			UpdateSelection(node, TreeNodeSelectionState.Selected);
		}
	}

	public override void Insert(int index, TreeViewNode node)
	{
		InsertAt(index, node);
	}

	internal void SetAt(int index, TreeViewNode node)
	{
		RemoveAt(index);
		InsertAt(index, node);
	}

	public override void RemoveAt(int index)
	{
		TreeViewNode node = base[index];
		UpdateSelection(node, TreeNodeSelectionState.UnSelected);
	}

	internal void RemoveAtEnd()
	{
		RemoveAt(base.Count - 1);
	}

	internal void ReplaceAll(IEnumerable<TreeViewNode> nodes)
	{
		Clear();
		foreach (TreeViewNode node in nodes)
		{
			Append(node);
		}
	}

	public override void Clear()
	{
		while (base.Count > 0)
		{
			RemoveAtEnd();
		}
	}

	internal void InsertAtCore(int index, TreeViewNode node)
	{
		base.Insert(index, node);
		TreeViewViewModel viewModel = m_viewModel;
		if (viewModel == null)
		{
			return;
		}
		IList<object> selectedItems = viewModel.SelectedItems;
		if (selectedItems.Count != base.Count)
		{
			object obj = viewModel.ListControl?.ItemFromNode(node);
			if (obj != null)
			{
				selectedItems.Insert(index, obj);
				viewModel.TrackItemSelected(obj);
			}
		}
	}

	internal void RemoveAtCore(int index)
	{
		base.RemoveAt(index);
		TreeViewViewModel viewModel = m_viewModel;
		if (viewModel != null)
		{
			IList<object> selectedItems = viewModel.SelectedItems;
			if (base.Count != selectedItems.Count)
			{
				object item = selectedItems[index];
				selectedItems.RemoveAt(index);
				viewModel.TrackItemUnselected(item);
			}
		}
	}
}
