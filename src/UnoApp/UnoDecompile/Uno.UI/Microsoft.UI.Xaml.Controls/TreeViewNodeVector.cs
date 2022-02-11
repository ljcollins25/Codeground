using System;
using System.Collections;
using Windows.Foundation.Collections;

namespace Microsoft.UI.Xaml.Controls;

internal class TreeViewNodeVector : ObservableVector<TreeViewNode>
{
	private TreeViewNode m_parent;

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

	public void SetParent(TreeViewNode value)
	{
		m_parent = value;
	}

	private IList GetWritableParentItemsSource()
	{
		IList result = null;
		if (m_parent?.ItemsSource != null)
		{
			result = m_parent?.ItemsSource as IList;
		}
		return result;
	}

	public void Append(TreeViewNode item, bool updateItemsSource = true)
	{
		InsertAt(base.Count, item, updateItemsSource);
	}

	public override void Add(TreeViewNode item)
	{
		Append(item);
	}

	public void InsertAt(int index, TreeViewNode item, bool updateItemsSource = true)
	{
		if (m_parent == null)
		{
			throw new InvalidOperationException("Parent node must be set");
		}
		if (index > base.Count)
		{
			throw new ArgumentOutOfRangeException("index", "Index out of range for Insert");
		}
		item.Parent = m_parent;
		base.Insert(index, item);
		if (updateItemsSource)
		{
			GetWritableParentItemsSource()?.Insert(index, item.Content);
		}
	}

	public override void Insert(int index, TreeViewNode item)
	{
		InsertAt(index, item);
	}

	public void SetAt(int index, TreeViewNode item, bool updateItemsSource = true)
	{
		RemoveAt(index, updateItemsSource, updateIsExpanded: false);
		InsertAt(index, item, updateItemsSource);
	}

	public void RemoveAt(int index, bool updateItemsSource = true, bool updateIsExpanded = true)
	{
		TreeViewNode treeViewNode = this[index];
		treeViewNode.Parent = null;
		base.RemoveAt(index);
		if (updateItemsSource)
		{
			GetWritableParentItemsSource()?.RemoveAt(index);
		}
		if (!updateIsExpanded || base.Count != 0)
		{
			return;
		}
		TreeViewNode parent = m_parent;
		if (parent != null)
		{
			TreeViewNode parent2 = parent.Parent;
			if (parent2 != null)
			{
				parent.IsExpanded = false;
			}
		}
	}

	public override void RemoveAt(int index)
	{
		RemoveAt(index);
	}

	public void RemoveAtEnd(bool updateItemsSource = true)
	{
		int index = base.Count - 1;
		RemoveAt(index, updateItemsSource);
	}

	public void ReplaceAll(TreeViewNode[] values, bool updateItemsSource = true)
	{
		int count = base.Count;
		if (count > 0)
		{
			Clear(updateItemsSource);
			IList writableParentItemsSource = GetWritableParentItemsSource();
			if (m_parent == null)
			{
				throw new InvalidOperationException("Parent must be set");
			}
			foreach (TreeViewNode treeViewNode in values)
			{
				treeViewNode.Parent = m_parent;
				writableParentItemsSource?.Add(treeViewNode.Content);
			}
			base.Clear();
			foreach (TreeViewNode item in values)
			{
				base.Add(item);
			}
		}
	}

	public void Clear(bool updateItemsSource = true, bool updateIsExpanded = true)
	{
		int count = base.Count;
		if (count > 0)
		{
			for (int i = 0; i < count; i++)
			{
				TreeViewNode treeViewNode = this[i];
				treeViewNode.Parent = null;
			}
			base.Clear();
			if (updateItemsSource)
			{
				GetWritableParentItemsSource()?.Clear();
			}
		}
		if (!updateIsExpanded)
		{
			return;
		}
		TreeViewNode parent = m_parent;
		if (parent != null)
		{
			TreeViewNode parent2 = parent.Parent;
			if (parent2 != null)
			{
				parent.IsExpanded = false;
			}
		}
	}

	public override void Clear()
	{
		Clear();
	}
}
