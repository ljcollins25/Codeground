using System.Collections;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls;

public class ColumnDefinitionCollection : IList<ColumnDefinition>, ICollection<ColumnDefinition>, IEnumerable<ColumnDefinition>, IEnumerable, DefinitionCollectionBase
{
	private readonly DependencyObjectCollection<ColumnDefinition> _inner = new DependencyObjectCollection<ColumnDefinition>();

	public ColumnDefinition this[int index]
	{
		get
		{
			return _inner[index];
		}
		set
		{
			if (_inner[index] != value)
			{
				_inner[index] = value;
			}
		}
	}

	public int Count => _inner.Count;

	public uint Size => (uint)_inner.Count;

	public bool IsReadOnly => false;

	internal List<ColumnDefinition> InnerList => _inner.Items;

	internal event VectorChangedEventHandler<ColumnDefinition> CollectionChanged;

	public ColumnDefinitionCollection()
	{
		_inner.VectorChanged += delegate(IObservableVector<ColumnDefinition> s, IVectorChangedEventArgs e)
		{
			this.CollectionChanged?.Invoke(s, e);
		};
	}

	internal ColumnDefinitionCollection(DependencyObject owner)
		: this()
	{
		_inner.IsAutoPropertyInheritanceEnabled = false;
		_inner.SetParent(owner);
	}

	public int IndexOf(ColumnDefinition item)
	{
		return _inner.IndexOf(item);
	}

	public void Insert(int index, ColumnDefinition item)
	{
		_inner.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		_inner.RemoveAt(index);
	}

	IEnumerable<DefinitionBase> DefinitionCollectionBase.GetItems()
	{
		return _inner;
	}

	DefinitionBase DefinitionCollectionBase.GetItem(int index)
	{
		return _inner[index];
	}

	public void Add(ColumnDefinition item)
	{
		_inner.Add(item);
	}

	public void Clear()
	{
		_inner.Clear();
	}

	public bool Contains(ColumnDefinition item)
	{
		return _inner.Contains(item);
	}

	public void CopyTo(ColumnDefinition[] array, int arrayIndex)
	{
		_inner.CopyTo(array, arrayIndex);
	}

	public bool Remove(ColumnDefinition item)
	{
		return _inner.Remove(item);
	}

	public IEnumerator<ColumnDefinition> GetEnumerator()
	{
		return _inner.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _inner.GetEnumerator();
	}

	void DefinitionCollectionBase.Lock()
	{
		_inner.Lock();
	}

	void DefinitionCollectionBase.Unlock()
	{
		_inner.Unlock();
	}
}
