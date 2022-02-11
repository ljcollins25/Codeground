using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Buffers;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

internal class DependencyPropertyDetails : IEnumerable<object?>, IEnumerable, IDisposable
{
	[Flags]
	private enum Flags
	{
		WeakStorage = 1,
		DefaultValueSet = 2
	}

	private DependencyPropertyValuePrecedences _highestPrecedence = DependencyPropertyValuePrecedences.DefaultValue;

	private readonly Type _dependencyObjectType;

	private object? _fastLocalValue;

	private BindingExpression? _binding;

	private static readonly ArrayPool<object?> _pool;

	private object?[]? _stack;

	private PropertyMetadata? _metadata;

	private object? _defaultValue;

	private Flags _flags;

	private DependencyPropertyCallbackManager? _callbackManager;

	private const int MaxIndex = 8;

	private const int _stackLength = 9;

	private static readonly object[] _unsetStack;

	public DependencyPropertyCallbackManager CallbackManager => _callbackManager ?? (_callbackManager = new DependencyPropertyCallbackManager());

	public DependencyProperty Property { get; }

	public PropertyMetadata Metadata => _metadata ?? (_metadata = Property.GetMetadata(_dependencyObjectType));

	internal DependencyPropertyValuePrecedences CurrentHighestValuePrecedence => _highestPrecedence;

	private bool HasWeakStorage => (_flags & Flags.WeakStorage) != 0;

	private bool HasDefaultValueSet => (_flags & Flags.DefaultValueSet) != 0;

	private object?[] Stack
	{
		get
		{
			if (_stack == null)
			{
				_stack = _pool.Rent(9);
				Array.Copy(_unsetStack, _stack, 9);
				object defaultValue = GetDefaultValue();
				_stack[8] = defaultValue;
				if (_highestPrecedence == DependencyPropertyValuePrecedences.Local)
				{
					_stack[2] = _fastLocalValue;
				}
			}
			return _stack;
		}
	}

	static DependencyPropertyDetails()
	{
		_pool = ArrayPool<object>.Create(9, 100);
		_unsetStack = new object[9];
		for (int i = 0; i < 9; i++)
		{
			_unsetStack[i] = DependencyProperty.UnsetValue;
		}
	}

	public void Dispose()
	{
		CallbackManager.Dispose();
		if (_stack != null)
		{
			_pool.Return(_stack, clearArray: true);
		}
	}

	internal DependencyPropertyDetails(DependencyProperty property, Type dependencyObjectType)
	{
		Property = property;
		_dependencyObjectType = dependencyObjectType;
		if (property.HasWeakStorage)
		{
			_flags |= Flags.WeakStorage;
		}
	}

	private object? GetDefaultValue()
	{
		if (!HasDefaultValueSet)
		{
			_defaultValue = Property.GetMetadata(_dependencyObjectType).DefaultValue;
			if (_defaultValue == null && !Property.IsTypeNullable)
			{
				_defaultValue = Property.GetFallbackDefaultValue();
			}
			_flags |= Flags.DefaultValueSet;
		}
		return _defaultValue;
	}

	internal void SetValue(object? value, DependencyPropertyValuePrecedences precedence)
	{
		if (!SetValueFast(value, precedence))
		{
			SetValueFull(value, precedence);
		}
	}

	private void SetValueFull(object? value, DependencyPropertyValuePrecedences precedence)
	{
		bool flag = value is UnsetValue;
		object[] stack = Stack;
		if (HasWeakStorage)
		{
			if (stack[(int)precedence] is ManagedWeakReference managedWeakReference)
			{
				WeakReferencePool.ReturnWeakReference(this, managedWeakReference);
			}
			stack[(int)precedence] = Validate(value);
		}
		else
		{
			stack[(int)precedence] = ValidateNoWrap(value);
		}
		if (!flag && precedence < _highestPrecedence)
		{
			_highestPrecedence = precedence;
		}
		else
		{
			if (!flag || precedence != _highestPrecedence)
			{
				return;
			}
			for (int i = (int)precedence; i < 8; i++)
			{
				if (stack[i] != DependencyProperty.UnsetValue)
				{
					_highestPrecedence = (DependencyPropertyValuePrecedences)i;
					return;
				}
			}
			_highestPrecedence = DependencyPropertyValuePrecedences.DefaultValue;
		}
	}

	private bool SetValueFast(object? value, DependencyPropertyValuePrecedences precedence)
	{
		if (_stack == null && precedence == DependencyPropertyValuePrecedences.Local)
		{
			bool flag = value is UnsetValue;
			if (HasWeakStorage)
			{
				if (_fastLocalValue is ManagedWeakReference managedWeakReference)
				{
					WeakReferencePool.ReturnWeakReference(this, managedWeakReference);
				}
				_fastLocalValue = Validate(value);
			}
			else
			{
				_fastLocalValue = ValidateNoWrap(value);
			}
			_highestPrecedence = (flag ? DependencyPropertyValuePrecedences.DefaultValue : DependencyPropertyValuePrecedences.Local);
			return true;
		}
		return false;
	}

	internal void SetDefaultValue(object? defaultValue)
	{
		_defaultValue = defaultValue;
		_flags |= Flags.DefaultValueSet;
	}

	internal BindingExpression? GetBinding()
	{
		return _binding;
	}

	internal void SetBinding(BindingExpression bindingExpression)
	{
		_binding = bindingExpression;
	}

	internal void ClearBinding()
	{
		_binding?.Dispose();
		_binding = null;
	}

	internal void SetSourceValue(object value)
	{
		_binding?.SetSourceValue(value);
	}

	internal object? GetValue()
	{
		return GetValue(_highestPrecedence);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal object? GetValue(DependencyPropertyValuePrecedences precedence)
	{
		if (_stack == null)
		{
			switch (precedence)
			{
			case DependencyPropertyValuePrecedences.DefaultValue:
				return GetDefaultValue();
			case DependencyPropertyValuePrecedences.Local:
				if (_highestPrecedence == DependencyPropertyValuePrecedences.Local)
				{
					return Unwrap(_fastLocalValue);
				}
				break;
			}
			return DependencyProperty.UnsetValue;
		}
		return Unwrap(Stack[(int)precedence]);
	}

	internal (object? value, DependencyPropertyValuePrecedences precedence) GetValueUnderPrecedence(DependencyPropertyValuePrecedences precedence)
	{
		if (_stack == null)
		{
			if (_highestPrecedence == DependencyPropertyValuePrecedences.Local)
			{
				return (Unwrap(_fastLocalValue), DependencyPropertyValuePrecedences.Local);
			}
			return (GetDefaultValue(), DependencyPropertyValuePrecedences.DefaultValue);
		}
		object[] stack = Stack;
		for (int i = (int)(precedence + 1); i < 8; i++)
		{
			object obj = Unwrap(stack[i]);
			if (obj != DependencyProperty.UnsetValue)
			{
				return (obj, (DependencyPropertyValuePrecedences)i);
			}
		}
		return (stack[8], DependencyPropertyValuePrecedences.DefaultValue);
	}

	private object? Validate(object? value)
	{
		if (value != null || Property.IsTypeNullable)
		{
			return Wrap(value);
		}
		return GetDefaultValue();
	}

	private object? ValidateNoWrap(object? value)
	{
		if (value != null || Property.IsTypeNullable)
		{
			return value;
		}
		return GetDefaultValue();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private object? Wrap(object? value)
	{
		if (!HasWeakStorage || value == null || value == DependencyProperty.UnsetValue)
		{
			return value;
		}
		return WeakReferencePool.RentWeakReference(this, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private object? Unwrap(object? value)
	{
		if (!HasWeakStorage || !(value is ManagedWeakReference managedWeakReference))
		{
			return value;
		}
		return managedWeakReference.Target;
	}

	public IEnumerator<object?> GetEnumerator()
	{
		return Stack.Cast<object>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Stack.GetEnumerator();
	}

	public override string ToString()
	{
		return "DependencyPropertyDetails(" + Property.Name + ")";
	}
}
