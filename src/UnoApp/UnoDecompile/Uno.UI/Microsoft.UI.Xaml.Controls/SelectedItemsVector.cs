using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace Microsoft.UI.Xaml.Controls;

internal class SelectedItemsVector : ObservableVector<object>
{
	private TreeViewViewModel m_viewModel;

	public void SetViewModel(TreeViewViewModel viewModel)
	{
		m_viewModel = viewModel;
	}

	internal void Append(object item)
	{
		InsertAt(base.Count, item);
	}

	internal void InsertAt(int index, object item)
	{
		if (Contains(item))
		{
			return;
		}
		base.Insert(index, item);
		TreeViewViewModel viewModel = m_viewModel;
		if (viewModel == null)
		{
			return;
		}
		IList<TreeViewNode> selectedNodes = viewModel.SelectedNodes;
		if (selectedNodes.Count == base.Count)
		{
			return;
		}
		TreeViewList listControl = viewModel.ListControl;
		if (listControl != null)
		{
			TreeViewNode treeViewNode = listControl.NodeFromItem(item);
			if (treeViewNode != null)
			{
				selectedNodes.Insert(index, treeViewNode);
			}
		}
	}

	internal void SetAt(int index, object item)
	{
		RemoveAt(index);
		InsertAt(index, item);
	}

	public override void RemoveAt(int index)
	{
		base.RemoveAt(index);
		TreeViewViewModel viewModel = m_viewModel;
		if (viewModel != null)
		{
			IList<TreeViewNode> selectedNodes = viewModel.SelectedNodes;
			if (base.Count != selectedNodes.Count)
			{
				selectedNodes.RemoveAt(index);
			}
		}
	}

	internal void RemoveAtEnd()
	{
		RemoveAt(base.Count - 1);
	}

	internal void ReplaceAll(IEnumerable<object> items)
	{
		Clear();
		foreach (object item in items)
		{
			Append(item);
		}
	}

	public override void Clear()
	{
		while (base.Count > 0)
		{
			RemoveAtEnd();
		}
	}
}
