using System;

namespace Microsoft.UI.Xaml.Controls;

internal class ArrayList<T>
{
	private int _Capacity;

	private T[] _Array;

	internal T[] Array => _Array;

	public int Capacity
	{
		get
		{
			return _Capacity;
		}
		set
		{
			if (value < Count)
			{
				throw new IndexOutOfRangeException("Cannot resize the list smaller than its current length.");
			}
			if (value == _Capacity)
			{
				return;
			}
			_Capacity = value;
			if (value > 0)
			{
				T[] array = new T[value];
				if (Count > 0)
				{
					System.Array.Copy(_Array, 0, array, 0, Count);
				}
				_Array = array;
			}
			else
			{
				_Array = System.Array.Empty<T>();
			}
		}
	}

	public int Count { get; private set; }

	public ArrayList()
	{
		_Capacity = 0;
		_Array = System.Array.Empty<T>();
	}

	public ArrayList(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("Capacity cannot be less than zero.");
		}
		if (capacity == 0)
		{
			_Array = System.Array.Empty<T>();
		}
		else
		{
			_Array = new T[capacity];
		}
		_Capacity = capacity;
	}

	public void Add(T item)
	{
		if (Count == _Array.Length)
		{
			if (_Array.Length == 0)
			{
				_Capacity = 4;
			}
			else
			{
				_Capacity = _Array.Length * 2;
			}
			System.Array.Resize(ref _Array, _Capacity);
		}
		_Array[Count] = item;
		Count++;
	}
}
