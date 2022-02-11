using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Extensions.Specialized;
using Uno.UI.Extensions;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls;

public sealed class ItemCollection : IObservableVector<object>, IList<object>, ICollection<object>, IEnumerable<object>, IEnumerable, IObservableVector
{
	private class UntypedListWrapper : IList<object>, ICollection<object>, IEnumerable<object>, IEnumerable
	{
		private readonly IList _inner;

		public IList Original => _inner;

		public object this[int index]
		{
			get
			{
				return _inner[index];
			}
			set
			{
				_inner[index] = value;
			}
		}

		public int Count => _inner.Count;

		public bool IsReadOnly => _inner.IsReadOnly;

		public UntypedListWrapper(IList list)
		{
			_inner = list ?? throw new ArgumentNullException("list");
		}

		public void Add(object item)
		{
			_inner.Add(item);
		}

		public void Clear()
		{
			_inner.Clear();
		}

		public bool Contains(object item)
		{
			return _inner.Contains(item);
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
			_inner.CopyTo(array, arrayIndex);
		}

		public IEnumerator<object> GetEnumerator()
		{
			IEnumerator enumerator = _inner.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}

		public int IndexOf(object item)
		{
			return _inner.IndexOf(item);
		}

		public void Insert(int index, object item)
		{
			_inner.Insert(index, item);
		}

		public bool Remove(object item)
		{
			int count = _inner.Count;
			_inner.Remove(item);
			return _inner.Count < count;
		}

		public void RemoveAt(int index)
		{
			_inner.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _inner.GetEnumerator();
		}
	}

	private readonly IList<object> _inner = new List<object>();

	private IList<object> _itemsSource;

	private readonly SerialDisposable _itemsSourceCollectionChangeDisposable = new SerialDisposable();

	public int Count
	{
		get
		{
			if (_itemsSource != null)
			{
				return _itemsSource.Count();
			}
			return _inner.Count;
		}
	}

	public uint Size => (uint)Count;

	public bool IsReadOnly => _inner.IsReadOnly;

	public object this[int index]
	{
		get
		{
			if (_itemsSource != null)
			{
				return _itemsSource.ElementAt(index);
			}
			return _inner[index];
		}
		set
		{
			ThrowIfItemsSourceSet();
			_inner[index] = value;
		}
	}

	public event VectorChangedEventHandler<object> VectorChanged;

	private event VectorChangedEventHandler _untypedVectorChanged;

	event VectorChangedEventHandler IObservableVector.UntypedVectorChanged
	{
		add
		{
			_untypedVectorChanged += value;
		}
		remove
		{
			_untypedVectorChanged -= value;
		}
	}

	public IEnumerator<object> GetEnumerator()
	{
		if (_itemsSource == null)
		{
			return _inner.GetEnumerator();
		}
		return _itemsSource.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (_itemsSource == null)
		{
			return _inner.GetEnumerator();
		}
		return _itemsSource.GetEnumerator();
	}

	public void Add(object item)
	{
		ThrowIfItemsSourceSet();
		_inner.Add(item);
		(this.VectorChanged, this._untypedVectorChanged).TryRaiseInserted(this, _inner.Count - 1);
	}

	public void Clear()
	{
		ThrowIfItemsSourceSet();
		_inner.Clear();
		(this.VectorChanged, this._untypedVectorChanged).TryRaiseReseted(this);
	}

	public bool Contains(object item)
	{
		if (_itemsSource == null)
		{
			return _inner.Contains(item);
		}
		return _itemsSource.Contains(item);
	}

	public void CopyTo(object[] array, int arrayIndex)
	{
		if (_itemsSource == null)
		{
			_inner.CopyTo(array, arrayIndex);
			return;
		}
		int num = arrayIndex;
		foreach (object item in _itemsSource)
		{
			object obj = (array[num] = item);
			num++;
		}
	}

	public bool Remove(object item)
	{
		ThrowIfItemsSourceSet();
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple = (this.VectorChanged, this._untypedVectorChanged);
		(VectorChangedEventHandler<object>, VectorChangedEventHandler) tuple2 = tuple;
		if ((Delegate?)tuple2.Item1 == (Delegate?)null && (Delegate?)tuple2.Item2 == (Delegate?)null)
		{
			return _inner.Remove(item);
		}
		int num = _inner.IndexOf(item);
		if (num >= 0 && _inner.Remove(item))
		{
			tuple.TryRaiseRemoved(this, num);
			return true;
		}
		return false;
	}

	public int IndexOf(object item)
	{
		if (_itemsSource != null)
		{
			return _itemsSource.IndexOf(item);
		}
		return _inner.IndexOf(item);
	}

	public void Insert(int index, object item)
	{
		ThrowIfItemsSourceSet();
		_inner.Insert(index, item);
		(this.VectorChanged, this._untypedVectorChanged).TryRaiseInserted(this, index);
	}

	public void RemoveAt(int index)
	{
		ThrowIfItemsSourceSet();
		_inner.RemoveAt(index);
		(this.VectorChanged, this._untypedVectorChanged).TryRaiseRemoved(this, index);
	}

	internal void SetItemsSource(IEnumerable itemsSource)
	{
		if (_itemsSource == itemsSource)
		{
			return;
		}
		if (itemsSource == null)
		{
			_itemsSource = null;
			ObserveCollectionChanged(null);
		}
		else
		{
			object itemsSource2 = null;
			if (itemsSource is IList<object> list)
			{
				itemsSource2 = list;
				_itemsSource = list;
			}
			else if (itemsSource is IList list2)
			{
				itemsSource2 = list2;
				_itemsSource = new UntypedListWrapper(list2);
			}
			else
			{
				_itemsSource = itemsSource.ToObjectArray();
			}
			ObserveCollectionChanged(itemsSource2);
		}
		(this.VectorChanged, this._untypedVectorChanged).TryRaiseReseted(this);
	}

	private void ObserveCollectionChanged(object itemsSource)
	{
		if (itemsSource == null)
		{
			_itemsSourceCollectionChangeDisposable.Disposable = null;
			return;
		}
		INotifyCollectionChanged existingObservable = itemsSource as INotifyCollectionChanged;
		if (existingObservable != null)
		{
			NotifyCollectionChangedEventHandler handler = OnItemsSourceCollectionChanged;
			_itemsSourceCollectionChangeDisposable.Disposable = Disposable.Create(delegate
			{
				existingObservable.CollectionChanged -= handler;
			});
			existingObservable.CollectionChanged += handler;
			return;
		}
		IObservableVector<object> observableVector = itemsSource as IObservableVector<object>;
		if (observableVector != null)
		{
			VectorChangedEventHandler<object> handler2 = OnItemsSourceVectorChanged;
			_itemsSourceCollectionChangeDisposable.Disposable = Disposable.Create(delegate
			{
				observableVector.VectorChanged -= handler2;
			});
			observableVector.VectorChanged += handler2;
			return;
		}
		IObservableVector genericObservableVector = itemsSource as IObservableVector;
		if (genericObservableVector != null)
		{
			VectorChangedEventHandler handler3 = OnItemsSourceVectorChanged;
			_itemsSourceCollectionChangeDisposable.Disposable = Disposable.Create(delegate
			{
				genericObservableVector.UntypedVectorChanged -= handler3;
			});
			genericObservableVector.UntypedVectorChanged += handler3;
		}
		else
		{
			_itemsSourceCollectionChangeDisposable.Disposable = null;
		}
	}

	private void OnItemsSourceVectorChanged(object sender, IVectorChangedEventArgs args)
	{
		(this.VectorChanged, this._untypedVectorChanged).TryRaise(this, args);
	}

	private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		(this.VectorChanged, this._untypedVectorChanged).TryRaise(this, args.ToVectorChangedEventArgs());
	}

	private void ThrowIfItemsSourceSet()
	{
		if (_itemsSource != null)
		{
			throw new InvalidOperationException("Items cannot be modified when ItemsSource is set.");
		}
	}
}
