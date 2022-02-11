using System;
using System.Collections.Generic;
using Uno.Buffers;
using Uno.Collections;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

internal class DependencyPropertyDetailsCollection : IDisposable
{
	private ImmutableList<BindingExpression> _bindings = ImmutableList<BindingExpression>.Empty;

	private ImmutableList<BindingExpression> _templateBindings = ImmutableList<BindingExpression>.Empty;

	private bool _bindingsSuspended;

	private static readonly DependencyPropertyDetails?[] Empty = new DependencyPropertyDetails[0];

	private readonly Type _ownerType;

	private readonly ManagedWeakReference _ownerReference;

	private object? _hardOwnerReference;

	private readonly DependencyProperty _dataContextProperty;

	private readonly DependencyProperty _templatedParentProperty;

	private DependencyPropertyDetails? _dataContextPropertyDetails;

	private DependencyPropertyDetails? _templatedParentPropertyDetails;

	private static readonly ArrayPool<DependencyPropertyDetails?> _pool = ArrayPool<DependencyPropertyDetails>.Create(500, 100);

	private DependencyPropertyDetails?[]? _entries;

	private int _entriesLength;

	private int _minId;

	private int _maxId;

	private List<DependencyObjectStore.DefaultValueProvider>? _defaultValueProviders;

	public bool HasBindings
	{
		get
		{
			if (_bindings == ImmutableList<BindingExpression>.Empty)
			{
				return _templateBindings != ImmutableList<BindingExpression>.Empty;
			}
			return true;
		}
	}

	private object? Owner => _hardOwnerReference ?? _ownerReference.Target;

	private DependencyPropertyDetails?[] Entries
	{
		get
		{
			EnsureEntriesInitialized();
			return _entries;
		}
	}

	public DependencyPropertyDetails DataContextPropertyDetails => _dataContextPropertyDetails ?? (_dataContextPropertyDetails = GetPropertyDetails(_dataContextProperty));

	public DependencyPropertyDetails TemplatedParentPropertyDetails => _templatedParentPropertyDetails ?? (_templatedParentPropertyDetails = GetPropertyDetails(_templatedParentProperty));

	internal void ApplyTemplatedParent(FrameworkElement templatedParent)
	{
		BindingExpression[] data = _templateBindings.Data;
		for (int i = 0; i < data.Length; i++)
		{
			ApplyBinding(data[i], templatedParent);
		}
	}

	public void ApplyDataContext(object dataContext)
	{
		BindingExpression[] data = _bindings.Data;
		for (int i = 0; i < data.Length; i++)
		{
			ApplyBinding(data[i], dataContext);
		}
	}

	internal void ApplyCompiledBindings()
	{
		BindingExpression[] data = _bindings.Data;
		for (int i = 0; i < data.Length; i++)
		{
			data[i].ApplyCompiledSource();
		}
	}

	internal void ApplyElementNameBindings()
	{
		BindingExpression[] data = _bindings.Data;
		for (int i = 0; i < data.Length; i++)
		{
			data[i].ApplyElementName();
		}
	}

	internal void SuspendBindings()
	{
		if (!_bindingsSuspended)
		{
			_bindingsSuspended = true;
			BindingExpression[] data = _bindings.Data;
			for (int i = 0; i < data.Length; i++)
			{
				data[i].SuspendBinding();
			}
		}
	}

	internal void ResumeBindings()
	{
		if (_bindingsSuspended)
		{
			_bindingsSuspended = false;
			BindingExpression[] data = _bindings.Data;
			for (int i = 0; i < data.Length; i++)
			{
				data[i].ResumeBinding();
			}
			ApplyDataContext(DataContextPropertyDetails.GetValue());
		}
	}

	internal BindingExpression FindDataContextBinding()
	{
		return DataContextPropertyDetails.GetBinding();
	}

	internal void SetBinding(DependencyProperty dependencyProperty, Binding binding, ManagedWeakReference target)
	{
		DependencyPropertyDetails propertyDetails = GetPropertyDetails(dependencyProperty);
		if (propertyDetails == null)
		{
			return;
		}
		propertyDetails.ClearBinding();
		BindingExpression bindingExpression = new BindingExpression(target, propertyDetails, binding);
		propertyDetails.SetBinding(bindingExpression);
		if (object.Equals(binding.RelativeSource, RelativeSource.TemplatedParent))
		{
			_templateBindings = _templateBindings.Add(bindingExpression);
			ApplyBinding(bindingExpression, TemplatedParentPropertyDetails.GetValue());
			return;
		}
		_bindings = _bindings.Add(bindingExpression);
		if (bindingExpression.TargetPropertyDetails.Property.UniqueId == DataContextPropertyDetails.Property.UniqueId)
		{
			bindingExpression.DataContext = propertyDetails.GetValue(DependencyPropertyValuePrecedences.Inheritance);
		}
		else
		{
			ApplyBinding(bindingExpression, DataContextPropertyDetails.GetValue());
		}
	}

	private void ApplyBinding(BindingExpression binding, object dataContext)
	{
		if (object.Equals(binding.ParentBinding.RelativeSource, RelativeSource.TemplatedParent))
		{
			binding.DataContext = dataContext;
		}
		else if (object.Equals(binding.ParentBinding.RelativeSource, RelativeSource.Self))
		{
			binding.DataContext = Owner;
		}
		else if (binding.TargetPropertyDetails.Property.UniqueId != DataContextPropertyDetails.Property.UniqueId)
		{
			binding.DataContext = dataContext;
		}
	}

	internal void SetSourceValue(DependencyProperty property, object value)
	{
		DependencyPropertyDetails propertyDetails = GetPropertyDetails(property);
		if (propertyDetails != null)
		{
			SetSourceValue(propertyDetails, value);
		}
	}

	internal void SetSourceValue(DependencyPropertyDetails details, object value)
	{
		details.SetSourceValue(value);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("Set binding value [{0}] from [{1}].", details.Property.Name, _ownerType);
		}
	}

	internal BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return GetPropertyDetails(dependencyProperty)?.GetBinding();
	}

	public DependencyPropertyDetailsCollection(Type ownerType, ManagedWeakReference ownerReference, DependencyProperty dataContextProperty, DependencyProperty templatedParentProperty)
	{
		_ownerType = ownerType;
		_ownerReference = ownerReference;
		_dataContextProperty = dataContextProperty;
		_templatedParentProperty = templatedParentProperty;
	}

	private void EnsureEntriesInitialized()
	{
		if (_entries == null)
		{
			DependencyProperty[] propertiesForType = DependencyProperty.GetPropertiesForType(_ownerType);
			if (propertiesForType.Length != 0)
			{
				_minId = propertiesForType[0].UniqueId;
				_maxId = propertiesForType[^1].UniqueId;
				int num = _maxId - _minId + 1;
				DependencyPropertyDetails[] newEntries = _pool.Rent(num);
				AssignEntries(newEntries, num);
			}
			else
			{
				_entries = Empty;
			}
		}
	}

	public void Dispose()
	{
		for (int i = 0; i < _entriesLength; i++)
		{
			Entries[i]?.Dispose();
		}
		ReturnEntriesToPool();
	}

	public DependencyPropertyDetails GetPropertyDetails(DependencyProperty property)
	{
		return TryGetPropertyDetails(property, forceCreate: true);
	}

	public DependencyPropertyDetails FindPropertyDetails(DependencyProperty property)
	{
		return TryGetPropertyDetails(property, forceCreate: false);
	}

	private DependencyPropertyDetails? TryGetPropertyDetails(DependencyProperty property, bool forceCreate)
	{
		EnsureEntriesInitialized();
		int uniqueId = property.UniqueId;
		int num = uniqueId - _minId;
		if ((uint)num <= _maxId - _minId)
		{
			ref DependencyPropertyDetails reference = ref Entries[num];
			if (forceCreate && reference == null)
			{
				reference = new DependencyPropertyDetails(property, _ownerType);
				if (TryResolveDefaultValueFromProviders(property, out var value))
				{
					reference.SetDefaultValue(value);
				}
			}
			return reference;
		}
		if (forceCreate)
		{
			if (num < 0)
			{
				int num2 = _maxId - uniqueId + 1;
				DependencyPropertyDetails[] array = _pool.Rent(num2);
				Array.Copy(Entries, 0, array, _minId - uniqueId, _entriesLength);
				_minId = uniqueId;
				AssignEntries(array, num2);
			}
			else
			{
				int num2 = uniqueId - _minId + 1;
				DependencyPropertyDetails[] array = _pool.Rent(num2);
				Array.Copy(Entries, 0, array, 0, _entriesLength);
				AssignEntries(array, num2);
			}
			ref DependencyPropertyDetails reference2 = ref Entries[property.UniqueId - _minId];
			reference2 = new DependencyPropertyDetails(property, _ownerType);
			if (TryResolveDefaultValueFromProviders(property, out var value2))
			{
				reference2.SetValue(value2, DependencyPropertyValuePrecedences.DefaultValue);
			}
			return reference2;
		}
		return null;
	}

	private bool TryResolveDefaultValueFromProviders(DependencyProperty property, out object? value)
	{
		if (_defaultValueProviders != null)
		{
			for (int num = _defaultValueProviders!.Count - 1; num >= 0; num--)
			{
				DependencyObjectStore.DefaultValueProvider defaultValueProvider = _defaultValueProviders![num];
				if (defaultValueProvider(property, out var defaultValue))
				{
					value = defaultValue;
					return true;
				}
			}
		}
		value = null;
		return false;
	}

	private void AssignEntries(DependencyPropertyDetails?[] newEntries, int newSize)
	{
		ReturnEntriesToPool();
		_entries = newEntries;
		_entriesLength = newEntries.Length;
		_maxId = _entriesLength + _minId - 1;
	}

	private void ReturnEntriesToPool()
	{
		if (_entries != null)
		{
			_pool.Return(_entries, clearArray: true);
		}
	}

	internal DependencyPropertyDetails?[] GetAllDetails()
	{
		return Entries;
	}

	public void RegisterDefaultValueProvider(DependencyObjectStore.DefaultValueProvider provider)
	{
		if (provider == null)
		{
			throw new ArgumentNullException("provider");
		}
		if (_defaultValueProviders == null)
		{
			_defaultValueProviders = new List<DependencyObjectStore.DefaultValueProvider>(2);
		}
		_defaultValueProviders!.Add(provider);
	}

	internal void TryEnableHardReferences()
	{
		_hardOwnerReference = _ownerReference.Target;
	}

	internal void DisableHardReferences()
	{
		_hardOwnerReference = null;
	}
}
