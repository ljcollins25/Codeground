using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Uno;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Data;

internal class CollectionView : ICollectionView, IEnumerable<object>, IEnumerable, IObservableVector<object>, IList<object>, ICollection<object>
{
	private IEnumerable _collection;

	private readonly bool _isGrouped;

	private readonly PropertyPath _itemsPath;

	public IEnumerable InnerCollection => _collection;

	object IList<object>.this[int index]
	{
		get
		{
			if (!_isGrouped)
			{
				return _collection.ElementAt(index);
			}
			return AsEnumerable.ElementAt(index);
		}
		set
		{
			((_collection as IList) ?? throw new NotSupportedException())[index] = value;
		}
	}

	private IEnumerable AsEnumerable
	{
		get
		{
			using IEnumerator<object> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}

	public object CurrentItem
	{
		get
		{
			if (!_isGrouped)
			{
				if (CurrentPosition < 0 || CurrentPosition >= Count)
				{
					return null;
				}
				return _collection.ElementAt(CurrentPosition);
			}
			return AsEnumerable.ElementAt(CurrentPosition);
		}
	}

	public int CurrentPosition { get; private set; }

	public bool HasMoreItems => false;

	public bool IsCurrentAfterLast => CurrentPosition >= Count;

	public bool IsCurrentBeforeFirst => CurrentPosition < 0;

	public int Count
	{
		get
		{
			if (!_isGrouped)
			{
				return _collection.Count();
			}
			int num = 0;
			foreach (ICollectionViewGroup collectionGroup in CollectionGroups)
			{
				num += collectionGroup.GroupItems.Count();
			}
			return num;
		}
	}

	bool ICollection<object>.IsReadOnly => false;

	public IObservableVector<object> CollectionGroups { get; }

	public event EventHandler<object> CurrentChanged;

	public event CurrentChangingEventHandler CurrentChanging;

	[NotImplemented]
	public event VectorChangedEventHandler<object> VectorChanged;

	public CollectionView(IEnumerable collection, bool isGrouped, PropertyPath itemsPath)
	{
		_collection = collection;
		_isGrouped = isGrouped;
		_itemsPath = itemsPath;
		if (!isGrouped)
		{
			return;
		}
		ObservableVector<object> observableVector = new ObservableVector<object>();
		foreach (object item in collection)
		{
			observableVector.Add(new CollectionViewGroup(item, _itemsPath));
		}
		CollectionGroups = observableVector;
		if (_collection is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChangedUpdateGroups);
		}
	}

	private void OnCollectionChangedUpdateGroups(object sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			for (int j = e.NewStartingIndex; j < e.NewStartingIndex + e.NewItems!.Count; j++)
			{
				CollectionGroups.Insert(j, new CollectionViewGroup(_collection.ElementAt(j), _itemsPath));
			}
			break;
		}
		case NotifyCollectionChangedAction.Move:
		{
			for (int num = e.OldStartingIndex + e.OldItems!.Count - 1; num >= e.OldStartingIndex; num--)
			{
				object item = CollectionGroups[num];
				CollectionGroups.RemoveAt(num);
				CollectionGroups.Insert(num, item);
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			for (int num2 = e.OldStartingIndex + e.OldItems!.Count - 1; num2 >= e.OldStartingIndex; num2--)
			{
				CollectionGroups.RemoveAt(num2);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		{
			for (int i = e.NewStartingIndex; i < e.NewStartingIndex + e.NewItems!.Count; i++)
			{
				CollectionGroups[i] = new CollectionViewGroup(_collection.ElementAt(i), _itemsPath);
			}
			break;
		}
		case NotifyCollectionChangedAction.Reset:
			CollectionGroups.Clear();
			break;
		}
	}

	public IEnumerator<object> GetEnumerator()
	{
		if (_isGrouped)
		{
			return ((_collection as IEnumerable<IEnumerable<object>>) ?? Enumerable.Empty<IEnumerable<object>>()).SelectMany((IEnumerable<object> g) => g).GetEnumerator();
		}
		return (_collection as IEnumerable<object>)?.GetEnumerator();
	}

	public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
	{
		throw new NotSupportedException();
	}

	public bool MoveCurrentTo(object item)
	{
		int index = IndexOf(item);
		return MoveCurrentToPosition(index);
	}

	public bool MoveCurrentToFirst()
	{
		int index = ((Count <= 0) ? (-1) : 0);
		return MoveCurrentToPosition(index);
	}

	public bool MoveCurrentToLast()
	{
		int index = Count - 1;
		return MoveCurrentToPosition(index);
	}

	public bool MoveCurrentToNext()
	{
		return MoveCurrentToPosition(CurrentPosition + 1);
	}

	public bool MoveCurrentToPosition(int index)
	{
		if (index != CurrentPosition)
		{
			if (index < -1 || index >= Count)
			{
				return false;
			}
			CurrentChangingEventArgs currentChangingEventArgs = new CurrentChangingEventArgs();
			this.CurrentChanging?.Invoke(this, currentChangingEventArgs);
			if (currentChangingEventArgs.Cancel)
			{
				return false;
			}
			CurrentPosition = index;
			this.CurrentChanged?.Invoke(this, null);
			return true;
		}
		return true;
	}

	public bool MoveCurrentToPrevious()
	{
		return MoveCurrentToPosition(CurrentPosition - 1);
	}

	void ICollection<object>.Add(object item)
	{
		((_collection as IList) ?? throw new NotSupportedException()).Add(item);
	}

	void ICollection<object>.Clear()
	{
		((_collection as IList) ?? throw new NotSupportedException()).Clear();
	}

	public bool Contains(object item)
	{
		return _collection?.Contains(item) ?? false;
	}

	void ICollection<object>.CopyTo(object[] array, int arrayIndex)
	{
		if (_collection is ICollection<object> collection)
		{
			collection.CopyTo(array, arrayIndex);
		}
		else if (_collection is ICollection collection2)
		{
			collection2.CopyTo(array, arrayIndex);
		}
		_collection?.ToObjectArray().CopyTo(array, arrayIndex);
	}

	IEnumerator<object> IEnumerable<object>.GetEnumerator()
	{
		IEnumerator enumerator = ((IEnumerable)this).GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (_isGrouped)
		{
			return ((_collection as IEnumerable<IEnumerable>) ?? Enumerable.Empty<IEnumerable>()).SelectManyUntyped((IEnumerable g) => g).GetEnumerator();
		}
		return _collection.GetEnumerator();
	}

	public int IndexOf(object item)
	{
		return _collection.IndexOf(item);
	}

	void IList<object>.Insert(int index, object item)
	{
		((_collection as IList) ?? throw new NotSupportedException()).Insert(index, item);
	}

	bool ICollection<object>.Remove(object item)
	{
		bool result = Contains(item);
		((_collection as IList) ?? throw new NotSupportedException()).Remove(item);
		return result;
	}

	void IList<object>.RemoveAt(int index)
	{
		((_collection as IList) ?? throw new NotSupportedException()).RemoveAt(index);
	}
}
