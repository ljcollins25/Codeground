using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls;

internal class ListAdapter
{
	private class CastList<TSource, TTarget> : IList<TTarget>, ICollection<TTarget>, IEnumerable<TTarget>, IEnumerable
	{
		private readonly IList<TSource> _inner;

		public TTarget this[int index]
		{
			get
			{
				return To(_inner[index]);
			}
			set
			{
				_inner[index] = From(value);
			}
		}

		public int Count => _inner.Count;

		public bool IsReadOnly => _inner.IsReadOnly;

		public CastList(IList<TSource> inner)
		{
			_inner = inner;
		}

		public void Add(TTarget item)
		{
			_inner.Add(From(item));
		}

		public void Insert(int index, TTarget item)
		{
			_inner.Insert(index, From(item));
		}

		public bool Contains(TTarget item)
		{
			return _inner.Contains(From(item));
		}

		public int IndexOf(TTarget item)
		{
			return _inner.IndexOf(From(item));
		}

		public void RemoveAt(int index)
		{
			_inner.RemoveAt(index);
		}

		public bool Remove(TTarget item)
		{
			if (_inner.Contains(From(item)))
			{
				_inner.Remove(From(item));
				return true;
			}
			return false;
		}

		public void Clear()
		{
			_inner.Clear();
		}

		public void CopyTo(TTarget[] array, int arrayIndex)
		{
			int num = array.Length - arrayIndex;
			TSource[] array2 = new TSource[num];
			_inner.CopyTo(array2, 0);
			Array.Copy(array2, 0, array, arrayIndex, num);
		}

		public IEnumerator<TTarget> GetEnumerator()
		{
			return new GenericEnumerator<TTarget>(_inner.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _inner.GetEnumerator();
		}

		private static TSource From(object value)
		{
			return (TSource)value;
		}

		private static TTarget To(object value)
		{
			return (TTarget)value;
		}
	}

	private class GenericList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly IList _inner;

		public T this[int index]
		{
			get
			{
				return (T)_inner[index];
			}
			set
			{
				_inner[index] = value;
			}
		}

		public int Count => _inner.Count;

		public bool IsReadOnly => _inner.IsReadOnly;

		public GenericList(IList inner)
		{
			_inner = inner;
		}

		public void Add(T item)
		{
			_inner.Add(item);
		}

		public void Insert(int index, T item)
		{
			_inner.Insert(index, item);
		}

		public bool Contains(T item)
		{
			return _inner.Contains(item);
		}

		public int IndexOf(T item)
		{
			return _inner.IndexOf(item);
		}

		public void RemoveAt(int index)
		{
			_inner.RemoveAt(index);
		}

		public bool Remove(T item)
		{
			if (_inner.Contains(item))
			{
				_inner.Remove(item);
				return true;
			}
			return false;
		}

		public void Clear()
		{
			_inner.Clear();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_inner.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new GenericEnumerator<T>(_inner.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _inner.GetEnumerator();
		}
	}

	private class GenericEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly IEnumerator _inner;

		public T Current => (T)_inner.Current;

		object IEnumerator.Current => _inner.Current;

		public GenericEnumerator(IEnumerator inner)
		{
			_inner = inner;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return _inner.MoveNext();
		}

		public void Reset()
		{
			_inner.Reset();
		}
	}

	private class UntypedList<T> : IList, ICollection, IEnumerable
	{
		private readonly IList<T> _inner;

		public object this[int index]
		{
			get
			{
				return _inner[index];
			}
			set
			{
				_inner[index] = (T)value;
			}
		}

		public int Count => _inner.Count;

		public bool IsReadOnly => _inner.IsReadOnly;

		public bool IsFixedSize => false;

		public object SyncRoot { get; }

		public bool IsSynchronized
		{
			get
			{
				if (_inner is ICollection collection)
				{
					return collection.IsSynchronized;
				}
				return false;
			}
		}

		public UntypedList(IList<T> inner)
		{
			_inner = inner;
			SyncRoot = ((_inner is ICollection collection) ? collection.SyncRoot : new object());
		}

		public int Add(object value)
		{
			int count = _inner.Count;
			_inner.Add((T)value);
			return count;
		}

		public void Insert(int index, object value)
		{
			_inner.Insert(index, (T)value);
		}

		public bool Contains(object value)
		{
			return _inner.Contains((T)value);
		}

		public int IndexOf(object value)
		{
			return _inner.IndexOf((T)value);
		}

		public void RemoveAt(int index)
		{
			_inner.RemoveAt(index);
		}

		public void Remove(object value)
		{
			_inner.Remove((T)value);
		}

		public void Clear()
		{
			_inner.Clear();
		}

		public IEnumerator GetEnumerator()
		{
			return _inner.GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			int num = array.Length - index;
			T[] array2 = new T[num];
			_inner.CopyTo(array2, 0);
			Array.Copy(array2, 0, array, index, num);
		}
	}

	public static IList<TTarget> ChangeType<TSource, TTarget>(IList<TSource> list)
	{
		return new CastList<TSource, TTarget>(list);
	}

	public static IList<object> ToGeneric(IList list)
	{
		return new GenericList<object>(list);
	}

	public static IList<T> ToGeneric<T>(IList list)
	{
		return new GenericList<T>(list);
	}

	public static IList ToUntyped<T>(IList<T> list)
	{
		return new UntypedList<T>(list);
	}
}
