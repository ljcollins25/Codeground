using System;
using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls;

internal class SelectionTreeHelper
{
	internal struct TreeWalkNodeInfo
	{
		internal SelectionNode Node;

		internal IndexPath Path;

		internal SelectionNode ParentNode;

		internal TreeWalkNodeInfo(SelectionNode node, IndexPath indexPath, SelectionNode parent)
		{
			Node = node;
			Path = indexPath;
			ParentNode = parent;
		}

		internal TreeWalkNodeInfo(SelectionNode node, IndexPath indexPath)
		{
			Node = node;
			Path = indexPath;
			ParentNode = null;
		}
	}

	internal static void TraverseIndexPath(SelectionNode root, IndexPath path, bool realizeChildren, Action<SelectionNode, IndexPath, int, int> nodeAction)
	{
		SelectionNode selectionNode = root;
		for (int i = 0; i < path.GetSize(); i++)
		{
			int at = path.GetAt(i);
			nodeAction(selectionNode, path, i, at);
			if (i < path.GetSize() - 1)
			{
				selectionNode = selectionNode.GetAt(at, realizeChildren);
			}
		}
	}

	internal static void Traverse(SelectionNode root, bool realizeChildren, Action<TreeWalkNodeInfo> nodeAction)
	{
		List<TreeWalkNodeInfo> list = new List<TreeWalkNodeInfo>();
		IndexPath indexPath = new IndexPath(null);
		list.Add(new TreeWalkNodeInfo(root, indexPath));
		while (list.Count > 0)
		{
			TreeWalkNodeInfo obj = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			int num = (realizeChildren ? obj.Node.DataCount : obj.Node.ChildrenNodeCount);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				SelectionNode at = obj.Node.GetAt(num2, realizeChildren);
				IndexPath indexPath2 = obj.Path.CloneWithChildIndex(num2);
				if (at != null)
				{
					list.Add(new TreeWalkNodeInfo(at, indexPath2, obj.Node));
				}
			}
			nodeAction(obj);
		}
	}

	internal static void TraverseRangeRealizeChildren(SelectionNode root, IndexPath start, IndexPath end, Action<TreeWalkNodeInfo> nodeAction)
	{
		List<TreeWalkNodeInfo> pendingNodes = new List<TreeWalkNodeInfo>();
		IndexPath indexPath = start;
		TraverseIndexPath(root, start, realizeChildren: true, delegate(SelectionNode node, IndexPath path, int depth, int childIndex)
		{
			IndexPath indexPath3 = StartPath(path, depth);
			bool flag3 = IsSubSet(start, indexPath3);
			bool flag4 = IsSubSet(end, indexPath3);
			int num4 = ((depth < start.GetSize() && flag3) ? Math.Max(0, start.GetAt(depth)) : 0);
			int num5 = ((depth < end.GetSize() && flag4) ? Math.Min(node.DataCount - 1, end.GetAt(depth)) : (node.DataCount - 1));
			for (int num6 = num5; num6 >= num4; num6--)
			{
				SelectionNode at2 = node.GetAt(num6, realizeChild: true);
				if (at2 != null)
				{
					IndexPath indexPath4 = indexPath3.CloneWithChildIndex(num6);
					pendingNodes.Add(new TreeWalkNodeInfo(at2, indexPath4, node));
				}
			}
		});
		while (pendingNodes.Count > 0)
		{
			TreeWalkNodeInfo obj = pendingNodes[pendingNodes.Count - 1];
			pendingNodes.RemoveAt(pendingNodes.Count - 1);
			int size = obj.Path.GetSize();
			bool flag = IsSubSet(start, obj.Path);
			bool flag2 = IsSubSet(end, obj.Path);
			int num = ((size < start.GetSize() && flag) ? start.GetAt(size) : 0);
			int num2 = ((size < end.GetSize() && flag2) ? end.GetAt(size) : (obj.Node.DataCount - 1));
			for (int num3 = num2; num3 >= num; num3--)
			{
				SelectionNode at = obj.Node.GetAt(num3, realizeChild: true);
				if (at != null)
				{
					IndexPath indexPath2 = obj.Path.CloneWithChildIndex(num3);
					pendingNodes.Add(new TreeWalkNodeInfo(at, indexPath2, obj.Node));
				}
			}
			nodeAction(obj);
			if (obj.Path.CompareTo(end) == 0)
			{
				break;
			}
		}
	}

	private static bool IsSubSet(IndexPath path, IndexPath subset)
	{
		int size = subset.GetSize();
		if (path.GetSize() < size)
		{
			return false;
		}
		for (int i = 0; i < size; i++)
		{
			if (path.GetAt(i) != subset.GetAt(i))
			{
				return false;
			}
		}
		return true;
	}

	internal static IndexPath StartPath(IndexPath path, int length)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < length; i++)
		{
			list.Add(path.GetAt(i));
		}
		return new IndexPath(list);
	}
}
