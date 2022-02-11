using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Uno.Foundation;

namespace Windows.UI.Xaml;

internal class SpecializedResourceDictionary
{
	[DebuggerDisplay("Key={Key}")]
	public readonly struct ResourceKey
	{
		public readonly string Key;

		public readonly Type TypeKey;

		public readonly uint HashCode;

		public static ResourceKey Empty { get; } = new ResourceKey(dummy: false);


		public bool IsEmpty => Key == null;

		private ResourceKey(bool dummy)
		{
			Key = null;
			TypeKey = null;
			HashCode = 0u;
		}

		public ResourceKey(object key)
		{
			if (key is string text)
			{
				Key = text;
				TypeKey = null;
				HashCode = (uint)(text.GetHashCode() ^ TypeKey?.GetHashCode()).GetValueOrDefault();
				return;
			}
			if (key is Type type)
			{
				Key = type.ToString();
				TypeKey = type;
				HashCode = (uint)(type.GetHashCode() ^ TypeKey?.GetHashCode()).GetValueOrDefault();
				return;
			}
			if (key is ResourceKey)
			{
				throw new InvalidOperationException("Received ResourceKey wrapped as object.");
			}
			Key = key.ToString();
			TypeKey = null;
			HashCode = (uint)(key.GetHashCode() ^ TypeKey?.GetHashCode()).GetValueOrDefault();
		}

		public ResourceKey(string key)
		{
			Key = key;
			TypeKey = null;
			HashCode = (uint)(key.GetHashCode() ^ TypeKey?.GetHashCode()).GetValueOrDefault();
		}

		public ResourceKey(Type key)
		{
			Key = key.ToString();
			TypeKey = key;
			HashCode = (uint)(key.GetHashCode() ^ TypeKey?.GetHashCode()).GetValueOrDefault();
		}

		public bool Equals(ResourceKey other)
		{
			if (TypeKey == other.TypeKey)
			{
				return Key == other.Key;
			}
			return false;
		}

		public static implicit operator ResourceKey(string key)
		{
			return new ResourceKey(key);
		}

		public static implicit operator ResourceKey(Type key)
		{
			return new ResourceKey(key);
		}
	}

	private struct Entry
	{
		public uint hashCode;

		public int next;

		public ResourceKey key;

		public object value;
	}

	public struct Enumerator : IEnumerator<KeyValuePair<ResourceKey, object>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private readonly SpecializedResourceDictionary _dictionary;

		private readonly int _version;

		private int _index;

		private KeyValuePair<ResourceKey, object> _current;

		private readonly int _getEnumeratorRetType;

		internal const int DictEntry = 1;

		internal const int KeyValuePair = 2;

		public KeyValuePair<ResourceKey, object> Current => _current;

		object IEnumerator.Current
		{
			get
			{
				if (_index == 0 || _index == _dictionary._count + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
				}
				if (_getEnumeratorRetType == 1)
				{
					return new DictionaryEntry(_current.Key, _current.Value);
				}
				return new KeyValuePair<object, object>(_current.Key, _current.Value);
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (_index == 0 || _index == _dictionary._count + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
				}
				return new DictionaryEntry(_current.Key, _current.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (_index == 0 || _index == _dictionary._count + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
				}
				return _current.Key;
			}
		}

		object IDictionaryEnumerator.Value
		{
			get
			{
				if (_index == 0 || _index == _dictionary._count + 1)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
				}
				return _current.Value;
			}
		}

		internal Enumerator(SpecializedResourceDictionary dictionary, int getEnumeratorRetType)
		{
			_dictionary = dictionary;
			_version = dictionary._version;
			_index = 0;
			_getEnumeratorRetType = getEnumeratorRetType;
			_current = default(KeyValuePair<ResourceKey, object>);
		}

		public bool MoveNext()
		{
			if (_version != _dictionary._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
			}
			while ((uint)_index < (uint)_dictionary._count)
			{
				ref Entry reference = ref _dictionary._entries[_index++];
				if (reference.next >= -1)
				{
					_current = new KeyValuePair<ResourceKey, object>(reference.key, reference.value);
					return true;
				}
			}
			_index = _dictionary._count + 1;
			_current = default(KeyValuePair<ResourceKey, object>);
			return false;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			if (_version != _dictionary._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
			}
			_index = 0;
			_current = default(KeyValuePair<ResourceKey, object>);
		}
	}

	public sealed class KeyCollection : ICollection<ResourceKey>, IEnumerable<ResourceKey>, IEnumerable, ICollection, IReadOnlyCollection<ResourceKey>
	{
		public struct Enumerator : IEnumerator<ResourceKey>, IEnumerator, IDisposable
		{
			private readonly SpecializedResourceDictionary _dictionary;

			private int _index;

			private readonly int _version;

			private ResourceKey _currenobject;

			public ResourceKey Current => _currenobject;

			object IEnumerator.Current
			{
				get
				{
					if (_index == 0 || _index == _dictionary._count + 1)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
					}
					return _currenobject;
				}
			}

			internal Enumerator(SpecializedResourceDictionary dictionary)
			{
				_dictionary = dictionary;
				_version = dictionary._version;
				_index = 0;
				_currenobject = default(ResourceKey);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (_version != _dictionary._version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
				}
				while ((uint)_index < (uint)_dictionary._count)
				{
					ref Entry reference = ref _dictionary._entries[_index++];
					if (reference.next >= -1)
					{
						_currenobject = reference.key;
						return true;
					}
				}
				_index = _dictionary._count + 1;
				_currenobject = default(ResourceKey);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (_version != _dictionary._version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
				}
				_index = 0;
				_currenobject = default(ResourceKey);
			}
		}

		private readonly SpecializedResourceDictionary _dictionary;

		public int Count => _dictionary.Count;

		bool ICollection<ResourceKey>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

		public KeyCollection(SpecializedResourceDictionary dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("ExceptionArgument.dictionary");
			}
			_dictionary = dictionary;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		public void CopyTo(ResourceKey[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("ExceptionArgument.array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("NeedNonNegNumException");
			}
			if (array.Length - index < _dictionary.Count)
			{
				throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
			}
			int count = _dictionary._count;
			Entry[] entries = _dictionary._entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].next >= -1)
				{
					array[index++] = entries[i].key;
				}
			}
		}

		void ICollection<ResourceKey>.Add(ResourceKey item)
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");
		}

		void ICollection<ResourceKey>.Clear()
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");
		}

		bool ICollection<ResourceKey>.Contains(ResourceKey item)
		{
			return _dictionary.ContainsKey(in item);
		}

		bool ICollection<ResourceKey>.Remove(ResourceKey item)
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_KeyCollectionSet");
		}

		IEnumerator<ResourceKey> IEnumerable<ResourceKey>.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("ExceptionArgument.array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException("ExceptionResource.Arg_RankMultiDimNotSupported");
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new ArgumentException("ExceptionResource.Arg_NonZeroLowerBound");
			}
			if ((uint)index > (uint)array.Length)
			{
				throw new ArgumentOutOfRangeException("NeedNonNegNumException()");
			}
			if (array.Length - index < _dictionary.Count)
			{
				throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
			}
			if (array is ResourceKey[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (!(array is object[] objects))
			{
				throw new ArgumentException("Argument_InvalidArrayType()");
			}
			int count = _dictionary._count;
			Entry[] entries = _dictionary._entries;
			index = MoveKeys(index, objects, count, entries);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int MoveKeys(int index, object[] objects, int count, Entry[] entries)
		{
			try
			{
				for (int i = 0; i < count; i++)
				{
					if (entries[i].next >= -1)
					{
						objects[index++] = entries[i].key;
					}
				}
				return index;
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Argument_InvalidArrayType()");
			}
		}
	}

	public sealed class ValueCollection : ICollection<object>, IEnumerable<object>, IEnumerable, ICollection, IReadOnlyCollection<object>
	{
		public struct Enumerator : IEnumerator<object>, IEnumerator, IDisposable
		{
			private readonly SpecializedResourceDictionary _dictionary;

			private int _index;

			private readonly int _version;

			private object _currenobject;

			public object Current => _currenobject;

			object IEnumerator.Current
			{
				get
				{
					if (_index == 0 || _index == _dictionary._count + 1)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen()");
					}
					return _currenobject;
				}
			}

			internal Enumerator(SpecializedResourceDictionary dictionary)
			{
				_dictionary = dictionary;
				_version = dictionary._version;
				_index = 0;
				_currenobject = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (_version != _dictionary._version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
				}
				while ((uint)_index < (uint)_dictionary._count)
				{
					ref Entry reference = ref _dictionary._entries[_index++];
					if (reference.next >= -1)
					{
						_currenobject = reference.value;
						return true;
					}
				}
				_index = _dictionary._count + 1;
				_currenobject = null;
				return false;
			}

			void IEnumerator.Reset()
			{
				if (_version != _dictionary._version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion()");
				}
				_index = 0;
				_currenobject = null;
			}
		}

		private readonly SpecializedResourceDictionary _dictionary;

		public int Count => _dictionary.Count;

		bool ICollection<object>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

		public ValueCollection(SpecializedResourceDictionary dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("ExceptionArgument.dictionary");
			}
			_dictionary = dictionary;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		public void CopyTo(object[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("ExceptionArgument.array");
			}
			if ((uint)index > array.Length)
			{
				throw new ArgumentOutOfRangeException("NeedNonNegNumException()");
			}
			if (array.Length - index < _dictionary.Count)
			{
				throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
			}
			int count = _dictionary._count;
			Entry[] entries = _dictionary._entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].next >= -1)
				{
					array[index++] = entries[i].value;
				}
			}
		}

		void ICollection<object>.Add(object item)
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");
		}

		bool ICollection<object>.Remove(object item)
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");
		}

		void ICollection<object>.Clear()
		{
			throw new NotSupportedException("ExceptionResource.NotSupported_ValueCollectionSet");
		}

		bool ICollection<object>.Contains(object item)
		{
			return _dictionary.ContainsValue(item);
		}

		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("ExceptionArgument.array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException("ExceptionResource.Arg_RankMultiDimNotSupported");
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new ArgumentException("ExceptionResource.Arg_NonZeroLowerBound");
			}
			if ((uint)index > (uint)array.Length)
			{
				throw new ArgumentOutOfRangeException("eedNonNegNumException()");
			}
			if (array.Length - index < _dictionary.Count)
			{
				throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
			}
			if (array is object[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (!(array is object[] objects))
			{
				throw new ArgumentException("Argument_InvalidArrayType()");
			}
			int count = _dictionary._count;
			Entry[] entries = _dictionary._entries;
			index = MoveValues(index, objects, count, entries);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int MoveValues(int index, object[] objects, int count, Entry[] entries)
		{
			try
			{
				for (int i = 0; i < count; i++)
				{
					if (entries[i].next >= -1)
					{
						objects[index++] = entries[i].value;
					}
				}
				return index;
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Argument_InvalidArrayType()");
			}
		}
	}

	private int[] _buckets;

	private Entry[] _entries;

	private ulong _fastModMultiplier;

	private static bool Is64Bits = IntPtr.Size >= 8 || WebAssemblyRuntime.IsWebAssembly;

	private int _count;

	private int _freeList;

	private int _freeCount;

	private int _version;

	private KeyCollection _keys;

	private ValueCollection _values;

	private const int StartOfFreeList = -3;

	public int Count => _count - _freeCount;

	public KeyCollection Keys => _keys ?? (_keys = new KeyCollection(this));

	public ValueCollection Values => _values ?? (_values = new ValueCollection(this));

	public object this[in ResourceKey key]
	{
		get
		{
			ref object reference = ref FindValue(in key);
			if (!IsNullRef(ref reference))
			{
				return reference;
			}
			throw new KeyNotFoundException("key");
		}
		set
		{
			bool flag = TryInsert(in key, value, InsertionBehavior.OverwriteExisting);
		}
	}

	public SpecializedResourceDictionary()
		: this(0)
	{
	}

	public SpecializedResourceDictionary(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");
		}
		if (capacity > 0)
		{
			Initialize(capacity);
		}
	}

	public void AddRange(SpecializedResourceDictionary source)
	{
		foreach (KeyValuePair<ResourceKey, object> item in source)
		{
			ResourceKey key = item.Key;
			Add(in key, item.Value);
		}
	}

	public void Add(in ResourceKey key, object value)
	{
		bool flag = TryInsert(in key, value, InsertionBehavior.ThrowOnExisting);
	}

	public void Clear()
	{
		int count = _count;
		if (count > 0)
		{
			Array.Clear(_buckets, 0, _buckets.Length);
			_count = 0;
			_freeList = -1;
			_freeCount = 0;
			Array.Clear(_entries, 0, count);
		}
	}

	public bool ContainsKey(in ResourceKey key)
	{
		return !IsNullRef(ref FindValue(in key));
	}

	public bool ContainsValue(object value)
	{
		Entry[] entries = _entries;
		if (value == null)
		{
			for (int i = 0; i < _count; i++)
			{
				if (entries[i].next >= -1 && entries[i].value == null)
				{
					return true;
				}
			}
		}
		else if (typeof(object).IsValueType)
		{
			for (int j = 0; j < _count; j++)
			{
				if (entries[j].next >= -1 && EqualityComparer<object>.Default.Equals(entries[j].value, value))
				{
					return true;
				}
			}
		}
		else
		{
			EqualityComparer<object> @default = EqualityComparer<object>.Default;
			for (int k = 0; k < _count; k++)
			{
				if (entries[k].next >= -1 && @default.Equals(entries[k].value, value))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void CopyTo(KeyValuePair<object, object>[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("ExceptionArgument.array");
		}
		if ((uint)index > (uint)array.Length)
		{
			throw new IndexOutOfRangeException("IndexArgumentOutOfRange_NeedNonNegNumException");
		}
		if (array.Length - index < Count)
		{
			throw new ArgumentException("ExceptionResource.Arg_ArrayPlusOffTooSmall");
		}
		int count = _count;
		Entry[] entries = _entries;
		for (int i = 0; i < count; i++)
		{
			if (entries[i].next >= -1)
			{
				array[index++] = new KeyValuePair<object, object>(entries[i].key, entries[i].value);
			}
		}
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	private ref object FindValue(in ResourceKey key)
	{
		ref Entry reference = ref NullRef<Entry>();
		if (_buckets != null)
		{
			uint hashCode = key.HashCode;
			int bucket = GetBucket(hashCode);
			Entry[] entries = _entries;
			uint num = (uint)entries.Length;
			uint num2 = 0u;
			bucket--;
			while ((uint)bucket < num)
			{
				reference = ref entries[bucket];
				if (reference.hashCode != hashCode || !reference.key.Equals(key))
				{
					bucket = reference.next;
					num2++;
					if (num2 > num)
					{
						throw new InvalidOperationException("ConcurrentOperationsNotSupported");
					}
					continue;
				}
				return ref reference.value;
			}
		}
		return ref NullRef<object>();
	}

	private int Initialize(int capacity)
	{
		int prime = HashHelpers.GetPrime(capacity);
		int[] buckets = new int[prime];
		Entry[] entries = new Entry[prime];
		_freeList = -1;
		if (Is64Bits)
		{
			_fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)prime);
		}
		_buckets = buckets;
		_entries = entries;
		return prime;
	}

	private bool TryInsert(in ResourceKey key, object value, InsertionBehavior behavior)
	{
		if (_buckets == null)
		{
			Initialize(0);
		}
		Entry[] entries = _entries;
		uint hashCode = key.HashCode;
		uint num = 0u;
		ref int bucket = ref GetBucket(hashCode);
		int num2 = bucket - 1;
		while ((uint)num2 < (uint)entries.Length)
		{
			if (entries[num2].hashCode == hashCode && entries[num2].key.Equals(key))
			{
				switch (behavior)
				{
				case InsertionBehavior.OverwriteExisting:
					entries[num2].value = value;
					return true;
				case InsertionBehavior.ThrowOnExisting:
					throw new InvalidOperationException("AddingDuplicateWithKeyArgumentException(key)");
				default:
					return false;
				}
			}
			num2 = entries[num2].next;
			num++;
			if (num > (uint)entries.Length)
			{
				throw new InvalidOperationException("ConcurrentOperationsNotSupported");
			}
		}
		int num3;
		if (_freeCount > 0)
		{
			num3 = _freeList;
			_freeList = -3 - entries[_freeList].next;
			_freeCount--;
		}
		else
		{
			int count = _count;
			if (count == entries.Length)
			{
				Resize();
				bucket = ref GetBucket(hashCode);
			}
			num3 = count;
			_count = count + 1;
			entries = _entries;
		}
		ref Entry reference = ref entries[num3];
		reference.hashCode = hashCode;
		reference.next = bucket - 1;
		reference.key = key;
		reference.value = value;
		bucket = num3 + 1;
		_version++;
		return true;
	}

	private void Resize()
	{
		Resize(HashHelpers.ExpandPrime(_count), forceNewHashCodes: false);
	}

	private void Resize(int newSize, bool forceNewHashCodes)
	{
		Entry[] array = new Entry[newSize];
		int count = _count;
		Array.Copy(_entries, array, count);
		_buckets = new int[newSize];
		if (Is64Bits)
		{
			_fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)newSize);
		}
		for (int i = 0; i < count; i++)
		{
			if (array[i].next >= -1)
			{
				ref int bucket = ref GetBucket(array[i].hashCode);
				array[i].next = bucket - 1;
				bucket = i + 1;
			}
		}
		_entries = array;
	}

	public bool Remove(in ResourceKey key)
	{
		if (_buckets != null)
		{
			uint num = 0u;
			uint hashCode = key.HashCode;
			ref int bucket = ref GetBucket(hashCode);
			Entry[] entries = _entries;
			int num2 = -1;
			int num3 = bucket - 1;
			while (num3 >= 0)
			{
				ref Entry reference = ref entries[num3];
				if (reference.hashCode == hashCode && reference.key.Equals(key))
				{
					if (num2 < 0)
					{
						bucket = reference.next + 1;
					}
					else
					{
						entries[num2].next = reference.next;
					}
					reference.next = -3 - _freeList;
					reference.key = default(ResourceKey);
					reference.value = null;
					_freeList = num3;
					_freeCount++;
					return true;
				}
				num2 = num3;
				num3 = reference.next;
				num++;
				if (num > (uint)entries.Length)
				{
					throw new InvalidOperationException("ConcurrentOperationsNotSupported");
				}
			}
		}
		return false;
	}

	public bool Remove(in ResourceKey key, out object value)
	{
		if (_buckets != null)
		{
			uint num = 0u;
			uint hashCode = key.HashCode;
			ref int bucket = ref GetBucket(hashCode);
			Entry[] entries = _entries;
			int num2 = -1;
			int num3 = bucket - 1;
			while (num3 >= 0)
			{
				ref Entry reference = ref entries[num3];
				if (reference.hashCode == hashCode && reference.key.Equals(key))
				{
					if (num2 < 0)
					{
						bucket = reference.next + 1;
					}
					else
					{
						entries[num2].next = reference.next;
					}
					value = reference.value;
					reference.next = -3 - _freeList;
					reference.key = default(ResourceKey);
					reference.value = null;
					_freeList = num3;
					_freeCount++;
					return true;
				}
				num2 = num3;
				num3 = reference.next;
				num++;
				if (num > (uint)entries.Length)
				{
					throw new InvalidOperationException("ConcurrentOperationsNotSupported()");
				}
			}
		}
		value = null;
		return false;
	}

	public bool TryGetValue(in ResourceKey key, out object value)
	{
		ref object reference = ref FindValue(in key);
		if (!IsNullRef(ref reference))
		{
			value = reference;
			return true;
		}
		value = null;
		return false;
	}

	public bool TryAdd(in ResourceKey key, object value)
	{
		return TryInsert(in key, value, InsertionBehavior.None);
	}

	public int EnsureCapacity(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");
		}
		int num = ((_entries != null) ? _entries.Length : 0);
		if (num >= capacity)
		{
			return num;
		}
		_version++;
		if (_buckets == null)
		{
			return Initialize(capacity);
		}
		int prime = HashHelpers.GetPrime(capacity);
		Resize(prime, forceNewHashCodes: false);
		return prime;
	}

	public void TrimExcess()
	{
		TrimExcess(Count);
	}

	public void TrimExcess(int capacity)
	{
		if (capacity < Count)
		{
			throw new ArgumentOutOfRangeException("ExceptionArgument.capacity");
		}
		int prime = HashHelpers.GetPrime(capacity);
		Entry[] entries = _entries;
		int num = ((entries != null) ? entries.Length : 0);
		if (prime < num)
		{
			int count = _count;
			_version++;
			Initialize(prime);
			CopyEntries(entries, count);
		}
	}

	private void CopyEntries(Entry[] entries, int count)
	{
		Entry[] entries2 = _entries;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			uint hashCode = entries[i].hashCode;
			if (entries[i].next >= -1)
			{
				ref Entry reference = ref entries2[num];
				reference = entries[i];
				ref int bucket = ref GetBucket(hashCode);
				reference.next = bucket - 1;
				bucket = num + 1;
				num++;
			}
		}
		_count = num;
		_freeCount = 0;
	}

	private static bool IsCompatibleKey(object key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("ExceptionArgument.key");
		}
		return key != null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ref int GetBucket(uint hashCode)
	{
		int[] buckets = _buckets;
		if (Is64Bits)
		{
			return ref buckets[HashHelpers.FastMod(hashCode, (uint)buckets.Length, _fastModMultiplier)];
		}
		return ref buckets[hashCode % (uint)buckets.Length];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static bool IsNullRef<T>(ref T source)
	{
		return Unsafe.AsPointer(ref source) == null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static ref T NullRef<T>()
	{
		return ref Unsafe.AsRef<T>(null);
	}
}
