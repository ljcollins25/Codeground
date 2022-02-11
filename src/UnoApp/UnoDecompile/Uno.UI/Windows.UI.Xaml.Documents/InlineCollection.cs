using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Documents;

public class InlineCollection : IList<Inline>, ICollection<Inline>, IEnumerable<Inline>, IEnumerable
{
	private readonly UIElementCollection _collection;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint InlineCollection.Size is not implemented in Uno.");
		}
	}

	public int Count => _collection.Count;

	public bool IsReadOnly => false;

	public Inline this[int index]
	{
		get
		{
			return (Inline)_collection[index];
		}
		set
		{
			_collection[index] = value;
		}
	}

	internal InlineCollection(UIElement containerElement)
	{
		_collection = new UIElementCollection(containerElement);
	}

	public IEnumerator<Inline> GetEnumerator()
	{
		return _collection.OfType<Inline>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(Inline item)
	{
		_collection.Add(item);
	}

	public void Clear()
	{
		_collection.Clear();
	}

	public bool Contains(Inline item)
	{
		return _collection.Contains(item);
	}

	public void CopyTo(Inline[] array, int arrayIndex)
	{
		throw new NotSupportedException();
	}

	public bool Remove(Inline item)
	{
		return _collection.Remove(item);
	}

	public int IndexOf(Inline item)
	{
		return _collection.IndexOf(item);
	}

	public void Insert(int index, Inline item)
	{
		_collection.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		_collection.RemoveAt(index);
	}
}
