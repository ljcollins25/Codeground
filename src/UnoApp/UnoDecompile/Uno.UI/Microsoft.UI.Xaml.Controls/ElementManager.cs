using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class ElementManager
{
	private readonly List<UIElement> m_realizedElements = new List<UIElement>();

	private readonly List<Rect> m_realizedElementLayoutBounds = new List<Rect>();

	private int m_firstRealizedDataIndex = -1;

	private VirtualizingLayoutContext m_context;

	private bool IsVirtualizingContext
	{
		get
		{
			if (m_context != null)
			{
				Rect realizationRect = m_context.RealizationRect;
				bool flag = double.IsInfinity(realizationRect.Height) || double.IsInfinity(realizationRect.Width);
				return !flag;
			}
			return false;
		}
	}

	public int GetRealizedElementCount
	{
		get
		{
			if (!IsVirtualizingContext)
			{
				return m_context.ItemCount;
			}
			return m_realizedElements.Count;
		}
	}

	public void SetContext(VirtualizingLayoutContext virtualContext)
	{
		m_context = virtualContext;
	}

	public void OnBeginMeasure(ScrollOrientation orientation)
	{
		if (m_context != null && IsVirtualizingContext)
		{
			DiscardElementsOutsideWindow(m_context.RealizationRect, orientation);
		}
	}

	public UIElement GetAt(int realizedIndex)
	{
		UIElement element;
		if (IsVirtualizingContext)
		{
			if (!m_realizedElements.TryGetElementAt(realizedIndex, out element))
			{
				int dataIndexFromRealizedRangeIndex = GetDataIndexFromRealizedRangeIndex(realizedIndex);
				element = m_context.GetOrCreateElementAt(dataIndexFromRealizedRangeIndex, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
				m_realizedElements[realizedIndex] = element;
			}
		}
		else
		{
			element = m_context.GetOrCreateElementAt(realizedIndex, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
		}
		return element;
	}

	public void Add(UIElement element, int dataIndex)
	{
		if (m_realizedElements.Count == 0)
		{
			m_firstRealizedDataIndex = dataIndex;
		}
		m_realizedElements.Add(element);
		m_realizedElementLayoutBounds.Add(default(Rect));
	}

	private void Insert(int realizedIndex, int dataIndex, UIElement element)
	{
		if (realizedIndex == 0)
		{
			m_firstRealizedDataIndex = dataIndex;
		}
		m_realizedElements.AddOrInsert(realizedIndex, element);
		m_realizedElementLayoutBounds.AddOrInsert(realizedIndex, ItemsRepeater.InvalidRect);
	}

	private void ClearRealizedRange(int realizedIndex, int count)
	{
		for (int i = 0; i < count; i++)
		{
			int index = ((realizedIndex == 0) ? (realizedIndex + i) : (realizedIndex + count - 1 - i));
			if (m_realizedElements.TryGetElementAt(index, out var element))
			{
				m_context.RecycleElement(element);
			}
		}
		m_realizedElements.RemoveRange(realizedIndex, count);
		m_realizedElementLayoutBounds.RemoveRange(realizedIndex, count);
		if (realizedIndex == 0)
		{
			m_firstRealizedDataIndex = ((m_realizedElements.Count == 0) ? (-1) : (m_firstRealizedDataIndex + count));
		}
	}

	public void DiscardElementsOutsideWindow(bool forward, int startIndex)
	{
		if (IsDataIndexRealized(startIndex))
		{
			int realizedRangeIndexFromDataIndex = GetRealizedRangeIndexFromDataIndex(startIndex);
			if (forward)
			{
				ClearRealizedRange(realizedRangeIndexFromDataIndex, GetRealizedElementCount - realizedRangeIndexFromDataIndex);
			}
			else
			{
				ClearRealizedRange(0, realizedRangeIndexFromDataIndex + 1);
			}
		}
	}

	public void ClearRealizedRange()
	{
		ClearRealizedRange(0, GetRealizedElementCount);
	}

	public Rect GetLayoutBoundsForDataIndex(int dataIndex)
	{
		int realizedRangeIndexFromDataIndex = GetRealizedRangeIndexFromDataIndex(dataIndex);
		return m_realizedElementLayoutBounds[realizedRangeIndexFromDataIndex];
	}

	public void SetLayoutBoundsForDataIndex(int dataIndex, Rect bounds)
	{
		int realizedRangeIndexFromDataIndex = GetRealizedRangeIndexFromDataIndex(dataIndex);
		m_realizedElementLayoutBounds[realizedRangeIndexFromDataIndex] = bounds;
	}

	public Rect GetLayoutBoundsForRealizedIndex(int realizedIndex)
	{
		return m_realizedElementLayoutBounds[realizedIndex];
	}

	public void SetLayoutBoundsForRealizedIndex(int realizedIndex, Rect bounds)
	{
		m_realizedElementLayoutBounds[realizedIndex] = bounds;
	}

	public bool IsDataIndexRealized(int index)
	{
		if (IsVirtualizingContext)
		{
			int getRealizedElementCount = GetRealizedElementCount;
			if (getRealizedElementCount > 0 && GetDataIndexFromRealizedRangeIndex(0) <= index)
			{
				return GetDataIndexFromRealizedRangeIndex(getRealizedElementCount - 1) >= index;
			}
			return false;
		}
		if (index >= 0)
		{
			return index < m_context.ItemCount;
		}
		return false;
	}

	public bool IsIndexValidInData(int currentIndex)
	{
		if (currentIndex >= 0)
		{
			return currentIndex < m_context.ItemCount;
		}
		return false;
	}

	public UIElement GetRealizedElement(int dataIndex)
	{
		if (!IsVirtualizingContext)
		{
			return m_context.GetOrCreateElementAt(dataIndex, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
		}
		return GetAt(GetRealizedRangeIndexFromDataIndex(dataIndex));
	}

	public void EnsureElementRealized(bool forward, int dataIndex, string layoutId)
	{
		if (!IsDataIndexRealized(dataIndex))
		{
			UIElement orCreateElementAt = m_context.GetOrCreateElementAt(dataIndex, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
			if (forward)
			{
				Add(orCreateElementAt, dataIndex);
			}
			else
			{
				Insert(0, dataIndex, orCreateElementAt);
			}
		}
	}

	public bool IsWindowConnected(Rect window, ScrollOrientation orientation, bool scrollOrientationSameAsFlow)
	{
		bool result = false;
		if (m_realizedElementLayoutBounds.Count > 0)
		{
			Rect layoutBoundsForRealizedIndex = GetLayoutBoundsForRealizedIndex(0);
			Rect layoutBoundsForRealizedIndex2 = GetLayoutBoundsForRealizedIndex(GetRealizedElementCount - 1);
			ScrollOrientation scrollOrientation = ((!scrollOrientationSameAsFlow) ? orientation : ((orientation == ScrollOrientation.Vertical) ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical));
			double num = ((scrollOrientation == ScrollOrientation.Vertical) ? window.Y : window.X);
			double num2 = ((scrollOrientation == ScrollOrientation.Vertical) ? (window.Y + window.Height) : (window.X + window.Width));
			double num3 = ((scrollOrientation == ScrollOrientation.Vertical) ? layoutBoundsForRealizedIndex.Y : layoutBoundsForRealizedIndex.X);
			double num4 = ((scrollOrientation == ScrollOrientation.Vertical) ? (layoutBoundsForRealizedIndex2.Y + layoutBoundsForRealizedIndex2.Height) : (layoutBoundsForRealizedIndex2.X + layoutBoundsForRealizedIndex2.Width));
			result = num3 <= num2 && num4 >= num;
		}
		return result;
	}

	public void DataSourceChanged(object source, NotifyCollectionChangedEventArgs args)
	{
		if (m_realizedElements.Count <= 0)
		{
			return;
		}
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
			OnItemsAdded(args.NewStartingIndex, args.NewItems!.Count);
			break;
		case NotifyCollectionChangedAction.Replace:
		{
			int count = args.OldItems!.Count;
			int count2 = args.NewItems!.Count;
			int oldStartingIndex = args.OldStartingIndex;
			int newStartingIndex = args.NewStartingIndex;
			if (count == count2 && oldStartingIndex == newStartingIndex && IsDataIndexRealized(oldStartingIndex) && IsDataIndexRealized(oldStartingIndex + count - 1))
			{
				int realizedRangeIndexFromDataIndex = GetRealizedRangeIndexFromDataIndex(oldStartingIndex);
				for (int i = realizedRangeIndexFromDataIndex; i < realizedRangeIndexFromDataIndex + count; i++)
				{
					if (m_realizedElements.TryGetElementAt(i, out var element))
					{
						m_context.RecycleElement(element);
						m_realizedElements[i] = null;
					}
				}
			}
			else
			{
				OnItemsRemoved(oldStartingIndex, count);
				OnItemsAdded(newStartingIndex, count2);
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
			OnItemsRemoved(args.OldStartingIndex, args.OldItems!.Count);
			break;
		case NotifyCollectionChangedAction.Reset:
			ClearRealizedRange();
			break;
		case NotifyCollectionChangedAction.Move:
			OnItemsRemoved(args.OldStartingIndex, args.OldItems!.Count);
			OnItemsAdded(args.NewStartingIndex, args.NewItems!.Count);
			break;
		}
	}

	private int GetElementDataIndex(UIElement suggestedAnchor)
	{
		int num = m_realizedElements.IndexOf(suggestedAnchor);
		if (num == -1)
		{
			return -1;
		}
		return GetDataIndexFromRealizedRangeIndex(num);
	}

	public int GetDataIndexFromRealizedRangeIndex(int rangeIndex)
	{
		if (!IsVirtualizingContext)
		{
			return rangeIndex;
		}
		return rangeIndex + m_firstRealizedDataIndex;
	}

	private int GetRealizedRangeIndexFromDataIndex(int dataIndex)
	{
		if (!IsVirtualizingContext)
		{
			return dataIndex;
		}
		return dataIndex - m_firstRealizedDataIndex;
	}

	private void DiscardElementsOutsideWindow(Rect window, ScrollOrientation orientation)
	{
		int getRealizedElementCount = GetRealizedElementCount;
		int num = -1;
		int num2 = getRealizedElementCount;
		for (int i = 0; i < getRealizedElementCount && !Intersects(window, m_realizedElementLayoutBounds[i], orientation); i++)
		{
			num++;
		}
		int num3 = getRealizedElementCount - 1;
		while (num3 >= 0 && !Intersects(window, m_realizedElementLayoutBounds[num3], orientation))
		{
			num2--;
			num3--;
		}
		if (num2 < getRealizedElementCount - 1)
		{
			ClearRealizedRange(num2 + 1, getRealizedElementCount - num2 - 1);
		}
		if (num > 0)
		{
			ClearRealizedRange(0, Math.Min(num, GetRealizedElementCount));
		}
	}

	private bool Intersects(Rect lhs, Rect rhs, ScrollOrientation orientation)
	{
		double num = ((orientation == ScrollOrientation.Vertical) ? lhs.Y : lhs.X);
		double num2 = ((orientation == ScrollOrientation.Vertical) ? (lhs.Y + lhs.Height) : (lhs.X + lhs.Width));
		double num3 = ((orientation == ScrollOrientation.Vertical) ? rhs.Y : rhs.X);
		double num4 = ((orientation == ScrollOrientation.Vertical) ? (rhs.Y + rhs.Height) : (rhs.X + rhs.Width));
		if (num2 >= num3)
		{
			return num <= num4;
		}
		return false;
	}

	private void OnItemsAdded(int index, int count)
	{
		int num = m_firstRealizedDataIndex + GetRealizedElementCount - 1;
		if (index >= m_firstRealizedDataIndex && index <= num)
		{
			int num2 = index - m_firstRealizedDataIndex;
			for (int i = 0; i < count; i++)
			{
				int realizedIndex = num2 + i;
				int dataIndex = index + i;
				Insert(realizedIndex, dataIndex, null);
			}
		}
		else if (index <= m_firstRealizedDataIndex)
		{
			m_firstRealizedDataIndex += count;
		}
	}

	private void OnItemsRemoved(int index, int count)
	{
		int val = m_firstRealizedDataIndex + m_realizedElements.Count - 1;
		int num = Math.Max(m_firstRealizedDataIndex, index);
		int num2 = Math.Min(val, index + count - 1);
		bool flag = index <= m_firstRealizedDataIndex;
		if (num2 >= num)
		{
			ClearRealizedRange(GetRealizedRangeIndexFromDataIndex(num), num2 - num + 1);
		}
		if (flag && m_firstRealizedDataIndex != -1)
		{
			m_firstRealizedDataIndex -= count;
		}
	}
}
