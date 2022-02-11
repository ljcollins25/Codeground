using System;
using System.Diagnostics;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

[DebuggerDisplay("{DebuggerDisplay}")]
public sealed class Setter : SetterBase
{
	private BindingPath? _bindingPath;

	private readonly SetterValueProviderHandler? _valueProvider;

	private object? _value;

	private int _targetNameResolutionFailureCount;

	public object? Value
	{
		get
		{
			if (_valueProvider != null)
			{
				return _valueProvider!();
			}
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public TargetPropertyPath? Target { get; set; }

	public DependencyProperty? Property { get; set; }

	internal SpecializedResourceDictionary.ResourceKey? ThemeResourceKey { get; set; }

	internal XamlParseContext? ThemeResourceContext { get; set; }

	internal ResourceUpdateReason ResourceBindingUpdateReason { get; set; }

	private string DebuggerDisplay => "Property=" + (Property?.Name ?? "<null>") + ",Target=" + (Target?.Target?.ToString() ?? Target?.TargetName ?? "<null>") + ",Value=" + (Value?.ToString() ?? "<null>");

	public Setter()
	{
	}

	public Setter(DependencyProperty targetProperty, object value)
	{
		Property = targetProperty;
		_value = value;
	}

	public Setter(DependencyProperty targetProperty, SetterValueProviderHandler valueProvider)
	{
		Property = targetProperty;
		_valueProvider = valueProvider;
	}

	public Setter(DependencyProperty targetProperty, object? owner, SetterValueProviderHandlerWithOwner valueProvider)
		: base()
	{
		Property = targetProperty;
		ManagedWeakReference ownerRef = WeakReferencePool.RentWeakReference(this, owner);
		_valueProvider = () => valueProvider(ownerRef?.Target);
	}

	public Setter(TargetPropertyPath targetPath, object value)
	{
		Target = targetPath;
		Value = value;
	}

	internal override void ApplyTo(DependencyObject o)
	{
		if (Property != null)
		{
			if (ThemeResourceKey.HasValue)
			{
				ResourceResolver.ApplyResource(o, Property, ThemeResourceKey.Value, ResourceBindingUpdateReason, ThemeResourceContext, null);
				return;
			}
			object value = ((_valueProvider != null) ? _valueProvider!() : _value);
			o.SetValue(Property, BindingPropertyHelper.Convert(() => Property!.Type, value));
			return;
		}
		throw new NotSupportedException();
	}

	internal void ApplyValue(DependencyPropertyValuePrecedences precedence, IFrameworkElement owner)
	{
		BindingPath bindingPath = TryGetOrCreateBindingPath(precedence, owner);
		if (bindingPath != null && (!ThemeResourceKey.HasValue || !ResourceResolver.ApplyVisualStateSetter(ThemeResourceKey.Value, ThemeResourceContext, bindingPath, precedence, ResourceBindingUpdateReason)))
		{
			bindingPath.Value = Value;
		}
	}

	private BindingPath? TryGetOrCreateBindingPath(DependencyPropertyValuePrecedences precedence, IFrameworkElement owner)
	{
		if (_bindingPath != null)
		{
			return _bindingPath;
		}
		if (Target == null)
		{
			return null;
		}
		if (Target!.Target == null && Target!.TargetName != null)
		{
			Target!.Target = owner.FindName(Target!.TargetName);
			if (Target!.Target == null)
			{
				if (_targetNameResolutionFailureCount++ > 2 && this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Warn($"Could not find Target [{Target!.TargetName}] for Setter [{Target!.Path?.Path}] from [{owner}]. This may indicate an invalid Setter name, and can cause performance issues.");
				}
				return null;
			}
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Using Target [{Target!.Target}] for Setter [{Target!.TargetName}] from [{owner}]");
		}
		_bindingPath = new BindingPath((string)Target!.Path, null, precedence, allowPrivateMembers: false);
		if (Target!.Target is ElementNameSubject elementNameSubject)
		{
			if (elementNameSubject.ActualElementInstance is ElementStub elementStub)
			{
				elementStub.Materialize();
			}
			elementNameSubject.ElementInstanceChanged += delegate(object s, object? value)
			{
				_bindingPath!.DataContext = value;
			};
			_bindingPath!.DataContext = elementNameSubject.ElementInstance;
		}
		else
		{
			_bindingPath!.DataContext = Target!.Target;
		}
		return _bindingPath;
	}

	internal void ClearValue()
	{
		_bindingPath?.ClearValue();
	}

	internal bool HasSameTarget(Setter other, DependencyPropertyValuePrecedences precedence, IFrameworkElement owner)
	{
		BindingPath bindingPath = TryGetOrCreateBindingPath(precedence, owner);
		BindingPath bindingPath2 = other.TryGetOrCreateBindingPath(precedence, owner);
		if (bindingPath != null && bindingPath2 != null && bindingPath.Path == bindingPath2.Path)
		{
			return !DependencyObjectStore.AreDifferent(bindingPath.DataContext, bindingPath2.DataContext);
		}
		return false;
	}
}
public class Setter<T> : SetterBase, ICSharpPropertySetter
{
	public string Property { get; set; }

	public Action<T> Action { get; }

	public Setter(string property, Action<T> action)
	{
		Property = property;
		Action = action;
	}

	internal override void OnStringPropertyChanged(string name)
	{
		Property = name;
	}

	internal override void ApplyTo(DependencyObject o)
	{
		if (!(o is T))
		{
			this.Log().Error($"The provided instance [{o?.GetType()}] does not match the setter's target type [{typeof(T)}]");
		}
		else
		{
			Action?.Invoke((T)o);
		}
	}
}
