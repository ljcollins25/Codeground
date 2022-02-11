using System;
using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

public class BindableProperty : IBindableProperty
{
	public PropertyGetterHandler? Getter { get; }

	public PropertySetterHandler? Setter { get; }

	public Type PropertyType { get; }

	public DependencyProperty? DependencyProperty { get; }

	public BindableProperty(DependencyProperty property)
	{
		DependencyProperty = property;
		PropertyType = property.Type;
	}

	public BindableProperty(Type propertyType, PropertyGetterHandler getter, PropertySetterHandler? setter)
	{
		Getter = getter;
		Setter = setter;
		PropertyType = propertyType;
	}
}
