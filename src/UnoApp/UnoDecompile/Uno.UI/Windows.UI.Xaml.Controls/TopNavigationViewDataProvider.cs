using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.UI.Helpers.WinUI;

namespace Windows.UI.Xaml.Controls;

internal class TopNavigationViewDataProvider : SplitDataSourceBase<object, NavigationViewSplitVectorID, double>
{
	private SerialDisposable m_dataSourceChanged = new SerialDisposable();

	private Action<NotifyCollectionChangedEventArgs> m_dataChangeCallback;

	private IEnumerable m_dataSource;

	private object m_rawDataSource;

	private double m_overflowButtonCachedWidth;

	public TopNavigationViewDataProvider(NavigationView owner)
		: base(5)
	{
		Func<object, int> indexOfFunction = (object value) => IndexOf(value);
		SplitVector<object, NavigationViewSplitVectorID> splitVector = new SplitVector<object, NavigationViewSplitVectorID>(NavigationViewSplitVectorID.PrimaryList, indexOfFunction);
		SplitVector<object, NavigationViewSplitVectorID> splitVector2 = new SplitVector<object, NavigationViewSplitVectorID>(NavigationViewSplitVectorID.OverflowList, indexOfFunction);
		InitializeSplitVectors(splitVector, splitVector2);
	}

	public IList<object> GetPrimaryItems()
	{
		return GetVector(NavigationViewSplitVectorID.PrimaryList).GetVector();
	}

	public IList<object> GetOverflowItems()
	{
		return GetVector(NavigationViewSplitVectorID.OverflowList).GetVector();
	}

	public void SetDataSource(IEnumerable rawData)
	{
		if (ShouldChangeDataSource(rawData))
		{
			IEnumerable enumerable = null;
			if (rawData != null)
			{
				enumerable = rawData;
			}
			ChangeDataSource(enumerable);
			m_rawDataSource = rawData;
			if (enumerable != null)
			{
				MoveAllItemsToPrimaryList();
			}
		}
	}

	public bool ShouldChangeDataSource(IEnumerable rawData)
	{
		return rawData != m_rawDataSource;
	}

	public void OnRawDataChanged(Action<NotifyCollectionChangedEventArgs> dataChangeCallback)
	{
		m_dataChangeCallback = dataChangeCallback;
	}

	public override int IndexOf(object value)
	{
		IEnumerable dataSource = m_dataSource;
		if (dataSource != null)
		{
			IEnumerable items = dataSource;
			return items.IndexOf(value);
		}
		return -1;
	}

	public override object GetAt(int index)
	{
		return m_dataSource?.ElementAt(index);
	}

	public override int Size()
	{
		return m_dataSource?.Count() ?? 0;
	}

	protected override NavigationViewSplitVectorID DefaultVectorIDOnInsert()
	{
		return NavigationViewSplitVectorID.NotInitialized;
	}

	protected override double DefaultAttachedData()
	{
		return double.MinValue;
	}

	public void MoveAllItemsToPrimaryList()
	{
		for (int i = 0; i < Size(); i++)
		{
			MoveItemToVector(i, NavigationViewSplitVectorID.PrimaryList);
		}
	}

	public List<int> ConvertPrimaryIndexToIndex(List<int> indexesInPrimary)
	{
		List<int> list = new List<int>();
		if (!indexesInPrimary.Empty())
		{
			SplitVector<object, NavigationViewSplitVectorID> vector = GetVector(NavigationViewSplitVectorID.PrimaryList);
			if (vector != null)
			{
				list.AddRange(indexesInPrimary.Select((int index) => vector.IndexToIndexInOriginalVector(index)));
			}
		}
		return list;
	}

	public void MoveItemsOutOfPrimaryList(List<int> indexes)
	{
		MoveItemsToList(indexes, NavigationViewSplitVectorID.OverflowList);
	}

	public void MoveItemsToPrimaryList(List<int> indexes)
	{
		MoveItemsToList(indexes, NavigationViewSplitVectorID.PrimaryList);
	}

	public void MoveItemsToList(List<int> indexes, NavigationViewSplitVectorID vectorID)
	{
		foreach (int index in indexes)
		{
			MoveItemToVector(index, vectorID);
		}
	}

	public int GetPrimaryListSize()
	{
		return GetPrimaryItems().Count;
	}

	public int GetNavigationViewItemCountInPrimaryList()
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

	public int GetNavigationViewItemCountInTopNav()
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

	public void UpdateWidthForPrimaryItem(int indexInPrimary, double width)
	{
		SplitVector<object, NavigationViewSplitVectorID> vector = GetVector(NavigationViewSplitVectorID.PrimaryList);
		if (vector != null)
		{
			int index = vector.IndexToIndexInOriginalVector(indexInPrimary);
			SetWidthForItem(index, width);
		}
	}

	public double WidthRequiredToRecoveryAllItemsToPrimary()
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

	public bool HasInvalidWidth(List<int> items)
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

	public double GetWidthForItem(int index)
	{
		double num = AttachedData(index);
		if (!IsValidWidth(num))
		{
			num = 0.0;
		}
		return num;
	}

	public double CalculateWidthForItems(List<int> items)
	{
		double num = 0.0;
		foreach (int item in items)
		{
			num += GetWidthForItem(item);
		}
		return num;
	}

	private void InvalidWidthCache()
	{
		ResetAttachedData(-1.0);
	}

	public double OverflowButtonWidth()
	{
		return m_overflowButtonCachedWidth;
	}

	public void OverflowButtonWidth(double width)
	{
		m_overflowButtonCachedWidth = width;
	}

	private bool IsItemSelectableInPrimaryList(object value)
	{
		int num = IndexOf(value);
		return num != -1;
	}

	public int IndexOf(object value, NavigationViewSplitVectorID vectorID)
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
		if (m_dataChangeCallback != null)
		{
			m_dataChangeCallback(args);
		}
	}

	private bool IsValidWidth(double width)
	{
		if (width >= 0.0)
		{
			return width < double.MaxValue;
		}
		return false;
	}

	public bool IsValidWidthForItem(int index)
	{
		double width = AttachedData(index);
		return IsValidWidth(width);
	}

	public void InvalidWidthCacheIfOverflowItemContentChanged()
	{
		bool flag = false;
		for (int i = 0; i < Size(); i++)
		{
			if (!IsItemInPrimaryList(i) && GetAt(i) is NavigationViewItem navigationViewItem)
			{
				NavigationViewItem navigationViewItem2 = navigationViewItem;
				if (navigationViewItem2.IsContentChangeHandlingDelayedForTopNav())
				{
					navigationViewItem2.ClearIsContentChangeHandlingDelayedForTopNavFlag();
					flag = true;
				}
			}
		}
		if (flag)
		{
			InvalidWidthCache();
		}
	}

	private void SetWidthForItem(int index, double width)
	{
		if (IsValidWidth(width))
		{
			AttachedData(index, width);
		}
	}

	private void ChangeDataSource(IEnumerable newValue)
	{
		IEnumerable dataSource = m_dataSource;
		if (dataSource != newValue)
		{
			if (dataSource is INotifyCollectionChanged)
			{
				m_dataSourceChanged.Disposable = null;
			}
			Clear();
			m_dataSource = newValue;
			SyncAndInitVectorFlagsWithID(NavigationViewSplitVectorID.NotInitialized, DefaultAttachedData());
			INotifyCollectionChanged newIncc = newValue as INotifyCollectionChanged;
			if (newIncc != null)
			{
				newIncc.CollectionChanged += new NotifyCollectionChangedEventHandler(OnDataSourceChanged);
				m_dataSourceChanged.Disposable = Disposable.Create(delegate
				{
					newIncc.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnDataSourceChanged);
				});
			}
		}
		MoveItemsToVector(NavigationViewSplitVectorID.NotInitialized);
	}

	public bool IsItemInPrimaryList(int index)
	{
		return GetVectorIDForItem(index) == NavigationViewSplitVectorID.PrimaryList;
	}

	private bool IsContainerNavigationViewItem(int index)
	{
		bool result = true;
		object at = GetAt(index);
		if (at != null && (at is NavigationViewItemHeader || at is NavigationViewItemSeparator))
		{
			result = false;
		}
		return result;
	}

	private bool IsContainerNavigationViewHeader(int index)
	{
		bool result = false;
		object at = GetAt(index);
		if (at != null && at is NavigationViewItemHeader)
		{
			result = true;
		}
		return result;
	}
}
