using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal class TrackerView<T> : IVectorView<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
{
	private IVector<T> _collection;

	public uint Size => (uint)Count;

	public int Count => _collection.Count;

	public T this[int index] => _collection[index];

	public void SetCollection(IVector<T> collection)
	{
		_collection = collection;
	}

	public T GetAt(uint index)
	{
		return _collection[(int)index];
	}

	public bool IndexOf(T value, out uint index)
	{
		int num = _collection.IndexOf(value);
		if (num == -1)
		{
			index = 0u;
			return false;
		}
		index = (uint)num;
		return true;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _collection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_collection).GetEnumerator();
	}
}
