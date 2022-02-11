using System;
using System.Collections;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace DirectUI;

internal class ValueTypeCollection<T> : ValueTypeView<T>, IVector<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public bool IsReadOnly { get; }

	public new T this[int index]
	{
		get
		{
			return GetAt((uint)index);
		}
		set
		{
			SetAt((uint)index, value);
		}
	}

	internal ValueTypeCollection()
	{
	}

	public virtual void SetAt(uint index, T item)
	{
		CheckThread();
		if (index < m_vector.Count)
		{
			m_vector[(int)index] = item;
			RaiseVectorChanged(CollectionChange.ItemChanged, index);
			return;
		}
		throw new InvalidOperationException();
	}

	public virtual void InsertAt(uint index, T item)
	{
		CheckThread();
		m_vector.Insert((int)index, item);
		RaiseVectorChanged(CollectionChange.ItemInserted, index);
	}

	public virtual void RemoveAt(uint index)
	{
		CheckThread();
		m_vector.RemoveAt((int)index);
		RaiseVectorChanged(CollectionChange.ItemRemoved, index);
	}

	public virtual void Append(T item)
	{
		CheckThread();
		m_vector.Add(item);
		RaiseVectorChanged(CollectionChange.ItemInserted, (uint)(m_vector.Count - 1));
	}

	public void RemoveAtEnd()
	{
		uint count = (uint)m_vector.Count;
		RemoveAt(count - 1);
	}

	public virtual void Clear()
	{
		CheckThread();
		ClearView();
		RaiseVectorChanged(CollectionChange.Reset, 0u);
	}

	private protected virtual void RaiseVectorChanged(CollectionChange action, uint index)
	{
	}

	public void Add(T item)
	{
		Append(item);
	}

	public void Insert(int index, T item)
	{
		InsertAt((uint)index, item);
	}

	public bool Contains(T item)
	{
		uint index;
		return IndexOf(item, out index);
	}

	public int IndexOf(T item)
	{
		if (!IndexOf(item, out var index))
		{
			return -1;
		}
		return (int)index;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		m_vector.CopyTo(array, arrayIndex);
	}

	public void RemoveAt(int index)
	{
		RemoveAt((uint)index);
	}

	public bool Remove(T item)
	{
		if (IndexOf(item, out var index))
		{
			RemoveAt(index);
			return true;
		}
		return false;
	}
}
