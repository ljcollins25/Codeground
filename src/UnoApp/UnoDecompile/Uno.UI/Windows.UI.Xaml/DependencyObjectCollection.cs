using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml;

public class DependencyObjectCollection : DependencyObjectCollection<DependencyObject>, DependencyObject, IObservableVector<DependencyObject>, IList<DependencyObject>, ICollection<DependencyObject>, IEnumerable<DependencyObject>, IEnumerable
{
	public DependencyObjectCollection()
	{
	}

	internal DependencyObjectCollection(DependencyObject parent, bool isAutoPropertyInheritanceEnabled = true)
		: base(parent, isAutoPropertyInheritanceEnabled)
	{
	}
}
public class DependencyObjectCollection<T> : DependencyObjectCollectionBase, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IObservableVector<T> where T : DependencyObject
{
	private readonly List<T> _list = new List<T>();

	private int _isLocked;

	internal List<T> Items => _list;

	public uint Size => (uint)_list.Count;

	public int Count => _list.Count;

	public bool IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

	public T this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			T val = _list[index];
			if ((object)val != (object)value)
			{
				EnsureNotLocked();
				OnRemoved(val);
				_list[index] = value;
				OnAdded(value);
				RaiseVectorChanged(CollectionChange.ItemChanged, index);
			}
		}
	}

	public event VectorChangedEventHandler<T> VectorChanged;

	internal void Lock()
	{
		_isLocked++;
	}

	internal void Unlock()
	{
		_isLocked--;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void EnsureNotLocked()
	{
		if (_isLocked > 0)
		{
			throw new InvalidOperationException("Collection is locked.");
		}
	}

	public DependencyObjectCollection()
	{
		Initialize();
	}

	internal DependencyObjectCollection(DependencyObject parent, bool isAutoPropertyInheritanceEnabled = true)
	{
		base.IsAutoPropertyInheritanceEnabled = isAutoPropertyInheritanceEnabled;
		Initialize();
		this.SetParent(parent);
	}

	private void Initialize()
	{
		((IDependencyObjectStoreProvider)this).Store.RegisterSelfParentChangedCallback(delegate(object instance, object? k, DependencyObjectParentChangedEventArgs handler)
		{
			UpdateParent(handler.NewParent);
		});
		VectorChanged += delegate
		{
			OnCollectionChanged();
		};
	}

	internal void UpdateParent(object parent)
	{
		object parent2 = parent ?? this;
		for (int i = 0; i < _list.Count; i++)
		{
			T val = _list[i];
			val.SetParent(parent2);
		}
	}

	public int IndexOf(T item)
	{
		return _list.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		EnsureNotLocked();
		_list.Insert(index, item);
		OnAdded(item);
		RaiseVectorChanged(CollectionChange.ItemInserted, index);
	}

	public void RemoveAt(int index)
	{
		EnsureNotLocked();
		OnRemoved(_list[index]);
		_list.RemoveAt(index);
		RaiseVectorChanged(CollectionChange.ItemRemoved, index);
	}

	public void Add(T item)
	{
		EnsureNotLocked();
		_list.Add(item);
		OnAdded(item);
		RaiseVectorChanged(CollectionChange.ItemInserted, _list.Count - 1);
	}

	public void Clear()
	{
		EnsureNotLocked();
		for (int i = 0; i < _list.Count; i++)
		{
			OnRemoved(_list[i]);
		}
		_list.Clear();
		RaiseVectorChanged(CollectionChange.Reset, 0);
	}

	public bool Contains(T item)
	{
		return _list.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		EnsureNotLocked();
		int num = _list.IndexOf(item);
		if (num != -1)
		{
			RemoveAt(num);
			return true;
		}
		return false;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	private void RaiseVectorChanged(CollectionChange change, int index)
	{
		this.VectorChanged?.Invoke(this, new VectorChangedEventArgs(change, (uint)index));
	}

	private protected virtual void OnAdded(T d)
	{
		d.SetParent(this.GetParent() ?? this);
	}

	private protected virtual void OnRemoved(T d)
	{
		d.SetParent(null);
	}

	private protected virtual void OnCollectionChanged()
	{
	}
}
