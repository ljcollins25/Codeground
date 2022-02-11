using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Uno.UI.Helpers.WinUI;

namespace Microsoft.UI.Xaml.Controls;

internal class TopNavigationViewDataProvider : SplitDataSourceBase<object, NavigationViewSplitVectorID, double>
{
	private ItemsSourceView m_dataSource;

	private object m_rawDataSource;

	private Action<NotifyCollectionChangedEventArgs> m_dataChangeCallback;

	private double m_overflowButtonCachedWidth;

	internal double OverflowButtonWidth
	{
		get
		{
			return m_overflowButtonCachedWidth;
		}
		set
		{
			m_overflowButtonCachedWidth = value;
		}
	}

	internal TopNavigationViewDataProvider(object m_owner)
		: base(5)
	{
		m_rawDataSource = m_owner;
		m_dataSource = m_owner as ItemsSourceView;
		Func<object, int> indexOfFunction = (object value) => IndexOf(value);
		SplitVector<object, NavigationViewSplitVectorID> splitVector = new SplitVector<object, NavigationViewSplitVectorID>(NavigationViewSplitVectorID.PrimaryList, indexOfFunction);
		SplitVector<object, NavigationViewSplitVectorID> splitVector2 = new SplitVector<object, NavigationViewSplitVectorID>(NavigationViewSplitVectorID.OverflowList, indexOfFunction);
		InitializeSplitVectors(splitVector, splitVector2);
	}

	internal IList<object> GetPrimaryItems()
	{
		return GetVector(NavigationViewSplitVectorID.PrimaryList).GetVector();
	}

	internal IList<object> GetOverflowItems()
	{
		return GetVector(NavigationViewSplitVectorID.OverflowList).GetVector();
	}

	internal void SetDataSource(object rawData)
	{
		if (ShouldChangeDataSource(rawData))
		{
			ItemsSourceView itemsSourceView = null;
			if (rawData != null)
			{
				itemsSourceView = new InspectingDataSource(rawData);
			}
			ChangeDataSource(itemsSourceView);
			m_rawDataSource = rawData;
			if (itemsSourceView != null)
			{
				MoveAllItemsToPrimaryList();
			}
		}
	}

	private bool ShouldChangeDataSource(object rawData)
	{
		return rawData != m_rawDataSource;
	}

	internal void OnRawDataChanged(Action<NotifyCollectionChangedEventArgs> dataChangeCallback)
	{
		m_dataChangeCallback = dataChangeCallback;
	}

	public override int IndexOf(object value)
	{
		return m_dataSource?.IndexOf(value) ?? (-1);
	}

	public override object GetAt(int index)
	{
		return m_dataSource?.GetAt(index);
	}

	public override int Size()
	{
		return m_dataSource?.Count ?? 0;
	}

	protected override NavigationViewSplitVectorID DefaultVectorIDOnInsert()
	{
		return NavigationViewSplitVectorID.NotInitialized;
	}

	protected override double DefaultAttachedData()
	{
		return double.MinValue;
	}

	internal void MoveAllItemsToPrimaryList()
	{
		for (int i = 0; i < Size(); i++)
		{
			MoveItemToVector(i, NavigationViewSplitVectorID.PrimaryList);
		}
	}

	internal IList<int> ConvertPrimaryIndexToIndex(IList<int> indexesInPrimary)
	{
		List<int> list = new List<int>();
		if (indexesInPrimary.Count > 0)
		{
			SplitVector<object, NavigationViewSplitVectorID> vector = GetVector(NavigationViewSplitVectorID.PrimaryList);
			if (vector != null)
			{
				foreach (int item2 in indexesInPrimary)
				{
					int item = vector.IndexToIndexInOriginalVector(item2);
					list.Add(item);
				}
				return list;
			}
		}
		return list;
	}

	internal int ConvertOriginalIndexToIndex(int originalIndex)
	{
		SplitVector<object, NavigationViewSplitVectorID> vector = GetVector(IsItemInPrimaryList(originalIndex) ? NavigationViewSplitVectorID.PrimaryList : NavigationViewSplitVectorID.OverflowList);
		return vector.IndexFromIndexInOriginalVector(originalIndex);
	}

	internal void MoveItemsOutOfPrimaryList(IList<int> indexes)
	{
		MoveItemsToList(indexes, NavigationViewSplitVectorID.OverflowList);
	}

	internal void MoveItemsToPrimaryList(IList<int> indexes)
	{
		MoveItemsToList(indexes, NavigationViewSplitVectorID.PrimaryList);
	}

	private void MoveItemsToList(IList<int> indexes, NavigationViewSplitVectorID vectorID)
	{
		foreach (int index in indexes)
		{
			MoveItemToVector(index, vectorID);
		}
	}

	internal int GetPrimaryListSize()
	{
		return GetPrimaryItems().Count;
	}

	internal int GetNavigationViewItemCountInPrimaryList()
	{
		int num = 0;
		for (int i = 0; i < Size(); i++)
		{
			if (IsItemInPrimaryList(i) && IsContainerNavigationViewItem(i))
			{
				num++;
			}
		}
		return num;
	}

	internal int GetNavigationViewItemCountInTopNav()
	{
		int num = 0;
		for (int i = 0; i < Size(); i++)
		{
			if (IsContainerNavigationViewItem(i))
			{
				num++;
			}
		}
		return num;
	}

	internal void UpdateWidthForPrimaryItem(int indexInPrimary, double width)
	{
		SplitVector<object, NavigationViewSplitVectorID> vector = GetVector(NavigationViewSplitVectorID.PrimaryList);
		if (vector != null)
		{
			int index = vector.IndexToIndexInOriginalVector(indexInPrimary);
			SetWidthForItem(index, width);
		}
	}

	internal double WidthRequiredToRecoveryAllItemsToPrimary()
	{
		double num = 0.0;
		for (int i = 0; i < Size(); i++)
		{
			if (!IsItemInPrimaryList(i))
			{
				num += GetWidthForItem(i);
			}
		}
		num -= m_overflowButtonCachedWidth;
		return Math.Max(0.0, num);
	}

	internal bool HasInvalidWidth(IList<int> items)
	{
		bool result = false;
		foreach (int item in items)
		{
			if (!IsValidWidthForItem(item))
			{
				return true;
			}
		}
		return result;
	}

	internal double GetWidthForItem(int index)
	{
		double num = AttachedData(index);
		if (!IsValidWidth(num))
		{
			num = 0.0;
		}
		return num;
	}

	internal double CalculateWidthForItems(IList<int> items)
	{
		double num = 0.0;
		foreach (int item in items)
		{
			num += GetWidthForItem(item);
		}
		return num;
	}

	internal void InvalidWidthCache()
	{
		ResetAttachedData(-1.0);
	}

	private bool IsItemSelectableInPrimaryList(object value)
	{
		int num = IndexOf(value);
		return num != -1;
	}

	internal int IndexOf(object value, NavigationViewSplitVectorID vectorID)
	{
		return IndexOfImpl(value, vectorID);
	}

	private void OnDataSourceChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
			OnInsertAt(args.NewStartingIndex, args.NewItems!.Count);
			break;
		case NotifyCollectionChangedAction.Remove:
			OnRemoveAt(args.OldStartingIndex, args.OldItems!.Count);
			break;
		case NotifyCollectionChangedAction.Reset:
			OnClear();
			break;
		case NotifyCollectionChangedAction.Replace:
			OnRemoveAt(args.OldStartingIndex, args.OldItems!.Count);
			OnInsertAt(args.NewStartingIndex, args.NewItems!.Count);
			break;
		}
		m_dataChangeCallback?.Invoke(args);
	}

	private bool IsValidWidth(double width)
	{
		if (width >= 0.0)
		{
			return width < double.MaxValue;
		}
		return false;
	}

	internal bool IsValidWidthForItem(int index)
	{
		double width = AttachedData(index);
		return IsValidWidth(width);
	}

	private void SetWidthForItem(int index, double width)
	{
		if (IsValidWidth(width))
		{
			AttachedData(index, width);
		}
	}

	private void ChangeDataSource(ItemsSourceView newValue)
	{
		ItemsSourceView dataSource = m_dataSource;
		if (dataSource != newValue)
		{
			if (dataSource != null)
			{
				dataSource.CollectionChanged -= OnDataSourceChanged;
			}
			Clear();
			m_dataSource = newValue;
			SyncAndInitVectorFlagsWithID(NavigationViewSplitVectorID.NotInitialized, DefaultAttachedData());
			if (newValue != null)
			{
				newValue.CollectionChanged += OnDataSourceChanged;
			}
		}
		MoveItemsToVector(NavigationViewSplitVectorID.NotInitialized);
	}

	internal bool IsItemInPrimaryList(int index)
	{
		return GetVectorIDForItem(index) == NavigationViewSplitVectorID.PrimaryList;
	}

	private bool IsContainerNavigationViewItem(int index)
	{
		bool result = true;
		object at = GetAt(index);
		if (at is NavigationViewItemHeader || at is NavigationViewItemSeparator)
		{
			result = false;
		}
		return result;
	}

	private bool IsContainerNavigationViewHeader(int index)
	{
		bool result = false;
		object at = GetAt(index);
		if (at is NavigationViewItemHeader)
		{
			result = true;
		}
		return result;
	}
}
