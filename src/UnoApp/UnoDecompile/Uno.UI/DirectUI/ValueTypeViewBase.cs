using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Core;

namespace DirectUI;

internal class ValueTypeViewBase<T> : IVectorView<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IIterable<T>
{
	protected List<T> m_vector = new List<T>();

	public int Count => (int)Size;

	public T this[int index] => GetAt((uint)index);

	public uint Size
	{
		get
		{
			CheckThread();
			return (uint)m_vector.Count;
		}
	}

	protected ValueTypeViewBase()
	{
	}

	~ValueTypeViewBase()
	{
		ClearView();
	}

	protected void CheckThread()
	{
		CoreDispatcher.CheckThreadAccess();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return m_vector.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IIterator<T> GetIterator()
	{
		return new UnoEnumeratorToIteratorAdapter<T>(GetEnumerator());
	}

	public bool IndexOf(T value, out uint index)
	{
		return (int)(index = (uint)m_vector.IndexOf(value)) >= 0;
	}

	protected virtual void ClearView()
	{
		m_vector.Clear();
	}

	internal void SetView(IIterator<T> view)
	{
		ClearView();
		bool flag = false;
		flag = view.HasCurrent;
		while (flag)
		{
			T current = view.Current;
			m_vector.Add(current);
			flag = view.MoveNext();
		}
	}

	internal void SetView(List<T> items)
	{
		m_vector = items;
	}

	public T GetAt(uint index)
	{
		CheckThread();
		if (index < m_vector.Count)
		{
			return m_vector[(int)index];
		}
		throw new InvalidOperationException();
	}
}
