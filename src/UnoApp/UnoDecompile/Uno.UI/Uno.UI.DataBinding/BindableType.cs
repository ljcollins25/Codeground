using System;
using System.Collections;
using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

public class BindableType : IBindableType
{
	private readonly Hashtable _properties;

	private StringIndexerGetterDelegate? _stringIndexerGetter;

	private StringIndexerSetterDelegate? _stringIndexerSetter;

	private ActivatorDelegate? _activator;

	public Type Type { get; }

	public BindableType(int estimatedPropertySize, Type sourceType)
	{
		_properties = new Hashtable(estimatedPropertySize);
		Type = sourceType;
	}

	public ActivatorDelegate? CreateInstance()
	{
		return _activator;
	}

	public IBindableProperty? GetProperty(string name)
	{
		IBindableProperty bindableProperty = _properties[name] as IBindableProperty;
		if (bindableProperty == null)
		{
			DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.Parse(name);
			if (dependencyPropertyDescriptor != null && dependencyPropertyDescriptor.OwnerType.IsAssignableFrom(Type))
			{
				bindableProperty = GetProperty(dependencyPropertyDescriptor.Name);
			}
		}
		return bindableProperty;
	}

	public void AddActivator(ActivatorDelegate activator)
	{
		_activator = activator;
	}

	public void AddProperty<T>(string name, PropertyGetterHandler getter, PropertySetterHandler? setter = null)
	{
		_properties[name] = new BindableProperty(typeof(T), getter, setter);
	}

	public void AddProperty(DependencyProperty property)
	{
		_properties[property.Name] = new BindableProperty(property);
	}

	public void AddProperty(string name, Type propertyType, PropertyGetterHandler getter, PropertySetterHandler? setter = null)
	{
		_properties[name] = new BindableProperty(propertyType, getter, setter);
	}

	public void AddIndexer(StringIndexerGetterDelegate getter, StringIndexerSetterDelegate setter)
	{
		_stringIndexerGetter = getter;
		_stringIndexerSetter = setter;
	}

	public StringIndexerGetterDelegate? GetIndexerGetter()
	{
		return _stringIndexerGetter;
	}

	public StringIndexerSetterDelegate? GetIndexerSetter()
	{
		return _stringIndexerSetter;
	}
}
