using System;
using System.Collections;
using System.Collections.Generic;
using Uno;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls;

public class RowDefinitionCollection : IList<RowDefinition>, ICollection<RowDefinition>, IEnumerable<RowDefinition>, IEnumerable, DefinitionCollectionBase
{
	private readonly DependencyObjectCollection<RowDefinition> _inner = new DependencyObjectCollection<RowDefinition>();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint RowDefinitionCollection.Size is not implemented in Uno.");
		}
	}

	public RowDefinition this[int index]
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

	public bool IsReadOnly => false;

	internal List<RowDefinition> InnerList => _inner.Items;

	internal event VectorChangedEventHandler<RowDefinition> CollectionChanged;

	public RowDefinitionCollection()
	{
		_inner.VectorChanged += delegate(IObservableVector<RowDefinition> s, IVectorChangedEventArgs e)
		{
			this.CollectionChanged?.Invoke(s, e);
		};
	}

	internal RowDefinitionCollection(DependencyObject owner)
		: this()
	{
		_inner.IsAutoPropertyInheritanceEnabled = false;
		_inner.SetParent(owner);
	}

	public int IndexOf(RowDefinition item)
	{
		return _inner.IndexOf(item);
	}

	public void Insert(int index, RowDefinition item)
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

	public void Add(RowDefinition item)
	{
		_inner.Add(item);
	}

	public void Clear()
	{
		_inner.Clear();
	}

	public bool Contains(RowDefinition item)
	{
		return _inner.Contains(item);
	}

	public void CopyTo(RowDefinition[] array, int arrayIndex)
	{
		_inner.CopyTo(array, arrayIndex);
	}

	public bool Remove(RowDefinition item)
	{
		return _inner.Remove(item);
	}

	public IEnumerator<RowDefinition> GetEnumerator()
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
