using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Uno;
using Uno.Collections;
using Uno.Extensions;
using Uno.UI.Helpers;

namespace Windows.UI.Xaml;

[DebuggerDisplay("Name={Name}, Type={Type.FullName}, Owner={OwnerType.FullName}")]
public sealed class DependencyProperty
{
	private class FrameworkPropertiesForTypeDictionary
	{
		private readonly HashtableEx _entries = new HashtableEx();

		internal bool TryGetValue(CachedTuple<Type, FrameworkPropertyMetadataOptions> key, out DependencyProperty[]? result)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				result = (DependencyProperty[])value;
				return true;
			}
			result = null;
			return false;
		}

		internal void Add(CachedTuple<Type, FrameworkPropertyMetadataOptions> key, DependencyProperty[] value)
		{
			_entries.Add(key, value);
		}

		internal void Clear()
		{
			_entries.Clear();
		}
	}

	private class NameToPropertyDictionary
	{
		private readonly HashtableEx _entries = new HashtableEx(PropertyCacheEntry.DefaultComparer);

		internal int Count => _entries.Count;

		internal bool TryGetValue(PropertyCacheEntry key, out DependencyProperty? result)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				result = (DependencyProperty)value;
				return true;
			}
			result = null;
			return false;
		}

		internal void Add(PropertyCacheEntry key, DependencyProperty dependencyProperty)
		{
			_entries.Add(key, dependencyProperty);
		}

		internal void Remove(PropertyCacheEntry propertyCacheEntry)
		{
			_entries.Remove(propertyCacheEntry);
		}

		internal void Clear()
		{
			_entries.Clear();
		}
	}

	private class DependencyPropertyRegistry
	{
		private readonly HashtableEx _entries = new HashtableEx(FastTypeComparer.Default);

		internal bool TryGetValue(Type type, string name, out DependencyProperty? result)
		{
			if (TryGetTypeTable(type, out var table) && table.TryGetValue(name, out var value))
			{
				result = (DependencyProperty)value;
				return true;
			}
			result = null;
			return false;
		}

		internal void Clear()
		{
			_entries.Clear();
		}

		internal void Add(Type type, string name, DependencyProperty property)
		{
			if (!TryGetTypeTable(type, out var table))
			{
				table = new HashtableEx();
				_entries[type] = table;
			}
			table.Add(name, property);
		}

		internal void AppendPropertiesForType(Type type, List<DependencyProperty> properties)
		{
			if (!TryGetTypeTable(type, out var table))
			{
				return;
			}
			foreach (object value in table.Values)
			{
				properties.Add((DependencyProperty)value);
			}
		}

		private bool TryGetTypeTable(Type type, out HashtableEx? table)
		{
			if (_entries.TryGetValue(type, out var value))
			{
				table = (HashtableEx)value;
				return true;
			}
			table = null;
			return false;
		}
	}

	private class TypeNullableDictionary
	{
		private readonly HashtableEx _entries = new HashtableEx(FastTypeComparer.Default);

		internal bool TryGetValue(Type key, out bool result)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				result = (bool)value;
				return true;
			}
			result = false;
			return false;
		}

		internal void Add(Type key, bool isNullable)
		{
			_entries.Add(key, isNullable);
		}

		internal void Clear()
		{
			_entries.Clear();
		}
	}

	private class TypeToPropertiesDictionary
	{
		private readonly HashtableEx _entries = new HashtableEx(FastTypeComparer.Default);

		internal bool TryGetValue(Type key, out DependencyProperty[]? result)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				result = (DependencyProperty[])value;
				return true;
			}
			result = null;
			return false;
		}

		internal void Add(Type key, DependencyProperty[] dependencyProperty)
		{
			_entries.Add(key, dependencyProperty);
		}

		internal void Clear()
		{
			_entries.Clear();
		}
	}

	private static readonly DependencyPropertyRegistry _registry = new DependencyPropertyRegistry();

	private static readonly TypeToPropertiesDictionary _getPropertiesForType = new TypeToPropertiesDictionary();

	private static readonly NameToPropertyDictionary _getPropertyCache = new NameToPropertyDictionary();

	private static readonly FrameworkPropertiesForTypeDictionary _getFrameworkPropertiesForType = new FrameworkPropertiesForTypeDictionary();

	private readonly PropertyMetadata _ownerTypeMetadata;

	private readonly PropertyMetadataDictionary _metadata = new PropertyMetadataDictionary();

	private string _name;

	private Type _propertyType;

	private Type _ownerType;

	private readonly bool _isAttached;

	private readonly bool _isTypeNullable;

	private readonly int _uniqueId;

	private readonly bool _isDependencyObjectCollection;

	private readonly bool _hasWeakStorage;

	private object _fallbackDefaultValue;

	private static int _globalId;

	private static readonly TypeNullableDictionary _isTypeNullableDictionary = new TypeNullableDictionary();

	internal int UniqueId => _uniqueId;

	internal bool HasWeakStorage => _hasWeakStorage;

	internal bool IsDependencyObjectCollection => _isDependencyObjectCollection;

	internal int CachedHashCode
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public static object UnsetValue { get; } = Windows.UI.Xaml.UnsetValue.Instance;


	internal Type OwnerType => _ownerType;

	internal Type Type => _propertyType;

	internal bool IsTypeNullable => _isTypeNullable;

	internal string Name => _name;

	internal bool IsAttached => _isAttached;

	private DependencyProperty(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata, bool attached)
	{
		_name = name;
		_propertyType = propertyType;
		_ownerType = ownerType;
		_isAttached = attached;
		_isDependencyObjectCollection = typeof(DependencyObjectCollection).IsAssignableFrom(propertyType);
		_isTypeNullable = GetIsTypeNullable(propertyType);
		_uniqueId = Interlocked.Increment(ref _globalId);
		_hasWeakStorage = (defaultMetadata as FrameworkPropertyMetadata)?.Options.HasWeakStorage() ?? false;
		_ownerTypeMetadata = defaultMetadata ?? new FrameworkPropertyMetadata(null);
		_metadata.Add(_ownerType, _ownerTypeMetadata);
		CachedHashCode = _name.GetHashCode() ^ ownerType.GetHashCode();
	}

	public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
	{
		DependencyProperty dependencyProperty = new DependencyProperty(name, propertyType, ownerType, typeMetadata, attached: false);
		try
		{
			RegisterProperty(ownerType, name, dependencyProperty);
			return dependencyProperty;
		}
		catch (ArgumentException innerException)
		{
			throw new InvalidOperationException("The dependency property {0} already exists in type {1}".InvariantCultureFormat(name, ownerType), innerException);
		}
	}

	internal static DependencyProperty Register(string name, Type propertyType, Type ownerType, FrameworkPropertyMetadata typeMetadata)
	{
		return Register(name, propertyType, ownerType, (PropertyMetadata)typeMetadata);
	}

	public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
	{
		DependencyProperty dependencyProperty = new DependencyProperty(name, propertyType, ownerType, typeMetadata, attached: true);
		try
		{
			RegisterProperty(ownerType, name, dependencyProperty);
			return dependencyProperty;
		}
		catch (ArgumentException innerException)
		{
			throw new InvalidOperationException("The dependency property {0} already exists in type {1}".InvariantCultureFormat(name, ownerType), innerException);
		}
	}

	internal static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, FrameworkPropertyMetadata typeMetadata)
	{
		return RegisterAttached(name, propertyType, ownerType, (PropertyMetadata)typeMetadata);
	}

	public PropertyMetadata GetMetadata(Type forType)
	{
		if (forType == _ownerType)
		{
			return _ownerTypeMetadata;
		}
		PropertyMetadata metadata = null;
		if (!_metadata.TryGetValue(forType, out metadata))
		{
			if (!IsTypeDependencyObject(forType) && OwnerType != typeof(AttachedDependencyObject))
			{
				throw new ArgumentException($"'{forType}' type must derive from DependencyObject.", "forType");
			}
			Type baseType = (forType.IsSubclassOf(_ownerType) ? forType.BaseType : _ownerType);
			ForceInitializeTypeConstructor(forType);
			metadata = _metadata.FindOrCreate(forType, () => GetMetadata(baseType));
		}
		return metadata;
	}

	private static bool IsTypeDependencyObject(Type forType)
	{
		return typeof(DependencyObject).IsAssignableFrom(forType);
	}

	internal void OverrideMetadata(Type forType, PropertyMetadata typeMetadata)
	{
		ForceInitializeTypeConstructor(forType);
		if (forType == null)
		{
			throw new ArgumentNullException("forType", "Value cannot be null.");
		}
		if (typeMetadata == null)
		{
			throw new ArgumentNullException("typeMetadata");
		}
		if (!typeof(DependencyObject).IsAssignableFrom(forType))
		{
			throw new ArgumentException($"'{forType}' type must derive from DependencyObject.", "forType");
		}
		if (_metadata.ContainsKey(forType))
		{
			throw new ArgumentException($"PropertyMetadata is already registered for type '{forType}'.", "forType");
		}
		if (_metadata.ContainsValue(typeMetadata))
		{
			throw new ArgumentException("Metadata is already associated with a type and property. A new one must be created.", "typeMetadata");
		}
		PropertyMetadata metadata = GetMetadata(forType.BaseType);
		if (!metadata.GetType().IsAssignableFrom(typeMetadata.GetType()))
		{
			throw new ArgumentException("Metadata override and base metadata must be of the same type or derived type.", "typeMetadata");
		}
		typeMetadata.Merge(metadata, this);
		_metadata.Add(forType, typeMetadata);
	}

	internal object GetFallbackDefaultValue()
	{
		if (_fallbackDefaultValue == null)
		{
			return _fallbackDefaultValue = Activator.CreateInstance(Type);
		}
		return _fallbackDefaultValue;
	}

	internal static DependencyProperty GetProperty(Type type, string name)
	{
		DependencyProperty result = null;
		PropertyCacheEntry key = new PropertyCacheEntry(type, name);
		if (!_getPropertyCache.TryGetValue(key, out result))
		{
			_getPropertyCache.Add(key, result = InternalGetProperty(type, name));
		}
		return result;
	}

	private static void ResetGetPropertyCache(Type ownerType, string name)
	{
		if (_getPropertyCache.Count != 0)
		{
			_getPropertyCache.Remove(new PropertyCacheEntry(ownerType, name));
		}
	}

	private static DependencyProperty InternalGetProperty(Type type, string name)
	{
		ForceInitializeTypeConstructor(type);
		DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.Parse(name);
		if (dependencyPropertyDescriptor != null)
		{
			type = dependencyPropertyDescriptor.OwnerType;
			name = dependencyPropertyDescriptor.Name;
		}
		do
		{
			if (_registry.TryGetValue(type, name, out var result))
			{
				return result;
			}
			type = type.BaseType;
		}
		while (type != typeof(object) && type != null);
		return null;
	}

	internal static DependencyProperty[] GetPropertiesForType(Type type)
	{
		DependencyProperty[] result = null;
		if (!_getPropertiesForType.TryGetValue(type, out result))
		{
			_getPropertiesForType.Add(type, result = InternalGetPropertiesForType(type));
		}
		return result;
	}

	internal static DependencyProperty[] GetFrameworkPropertiesForType(Type type, FrameworkPropertyMetadataOptions options)
	{
		DependencyProperty[] result = null;
		CachedTuple<Type, FrameworkPropertyMetadataOptions> key = CachedTuple.Create(type, options);
		if (!_getFrameworkPropertiesForType.TryGetValue(key, out result))
		{
			_getFrameworkPropertiesForType.Add(key, result = InternalGetFrameworkPropertiesForType(type, options));
		}
		return result;
	}

	internal static void ClearRegistry()
	{
		_registry.Clear();
		_getPropertiesForType.Clear();
		_getPropertyCache.Clear();
		_getFrameworkPropertiesForType.Clear();
	}

	private static void RegisterProperty(Type ownerType, string name, DependencyProperty newProperty)
	{
		ResetGetPropertyCache(ownerType, name);
		_registry.Add(ownerType, name, newProperty);
	}

	private static DependencyProperty[] InternalGetPropertiesForType(Type type)
	{
		ForceInitializeTypeConstructor(type);
		List<DependencyProperty> list = new List<DependencyProperty>();
		do
		{
			_registry.AppendPropertiesForType(type, list);
			type = type.BaseType;
		}
		while (type != typeof(object) && type != null);
		DependencyProperty[] array = list.ToArray();
		Array.Sort(array, (DependencyProperty l, DependencyProperty r) => l.UniqueId - r.UniqueId);
		return array;
	}

	private static void ForceInitializeTypeConstructor(Type type)
	{
		do
		{
			RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			type = type.BaseType;
		}
		while (type != null);
	}

	private static DependencyProperty[] InternalGetFrameworkPropertiesForType(Type type, FrameworkPropertyMetadataOptions options)
	{
		List<DependencyProperty> list = new List<DependencyProperty>();
		DependencyProperty[] propertiesForType = GetPropertiesForType(type);
		foreach (DependencyProperty dependencyProperty in propertiesForType)
		{
			FrameworkPropertyMetadataOptions? frameworkPropertyMetadataOptions = (dependencyProperty.GetMetadata(type) as FrameworkPropertyMetadata)?.Options;
			if (frameworkPropertyMetadataOptions.HasValue && (frameworkPropertyMetadataOptions & options) != 0)
			{
				list.Add(dependencyProperty);
			}
		}
		return list.ToArray();
	}

	private static DependencyProperty[] InternalGetDependencyObjectPropertiesForType(Type type)
	{
		List<DependencyProperty> list = new List<DependencyProperty>();
		DependencyProperty[] propertiesForType = GetPropertiesForType(type);
		foreach (DependencyProperty dependencyProperty in propertiesForType)
		{
			FrameworkPropertyMetadataOptions options = (dependencyProperty.GetMetadata(type) as FrameworkPropertyMetadata)?.Options ?? FrameworkPropertyMetadataOptions.None;
			if (options.HasValueInheritsDataContext() && !options.HasValueDoesNotInheritDataContext())
			{
				list.Add(dependencyProperty);
			}
		}
		return list.ToArray();
	}

	internal static DependencyProperty Register(string v, Type type1, Type type2, PropertyMetadata propertyMetadata, object updateSourceOnChanged)
	{
		throw new NotImplementedException();
	}

	private bool GetIsTypeNullable(Type type)
	{
		if (!_isTypeNullableDictionary.TryGetValue(type, out var result))
		{
			_isTypeNullableDictionary.Add(type, result = type.IsNullable());
		}
		return result;
	}
}
