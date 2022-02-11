using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal class IterableWrappedCollection<T> : IVector<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IIterable<T>
{
	protected IVector<T> m_tpWrappedCollection;

	public T this[int index]
	{
		get
		{
			return GetAt(index);
		}
		set
		{
			SetAt(index, value);
		}
	}

	public int Count => m_tpWrappedCollection.Count;

	public bool IsReadOnly => m_tpWrappedCollection.IsReadOnly;

	public virtual void SetWrappedCollection(IVector<T> collection)
	{
		m_tpWrappedCollection = collection;
	}

	public void Add(T item)
	{
		m_tpWrappedCollection.Add(item);
	}

	public void Clear()
	{
		m_tpWrappedCollection?.Clear();
	}

	public bool Contains(T item)
	{
		return m_tpWrappedCollection.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		m_tpWrappedCollection.CopyTo(array, arrayIndex);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return m_tpWrappedCollection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IIterator<T> GetIterator()
	{
		return new UnoEnumeratorToIteratorAdapter<T>(GetEnumerator());
	}

	public int IndexOf(T item)
	{
		return m_tpWrappedCollection.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		m_tpWrappedCollection.Insert(index, item);
	}

	public bool Remove(T item)
	{
		return m_tpWrappedCollection.Remove(item);
	}

	public void RemoveAt(int index)
	{
		m_tpWrappedCollection.RemoveAt(index);
	}

	private T GetAt(int index)
	{
		return m_tpWrappedCollection[index];
	}

	private void SetAt(int index, T value)
	{
		m_tpWrappedCollection[index] = value;
	}
}
