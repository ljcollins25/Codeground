using System;
using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

internal class BindablePropertyDescriptor
{
	public IBindableType OwnerType { get; }

	public IBindableProperty Property { get; private set; }

	private BindablePropertyDescriptor(IBindableType ownerType, IBindableProperty property)
	{
		OwnerType = ownerType;
		Property = property;
	}

	internal static BindablePropertyDescriptor GetPropertByBindableMetadataProvider(Type originalType, string property)
	{
		IBindableType bindableTypeByType = BindingPropertyHelper.BindableMetadataProvider!.GetBindableTypeByType(originalType);
		if (bindableTypeByType != null)
		{
			IBindableProperty property2 = bindableTypeByType.GetProperty(property);
			if (property2 != null)
			{
				return new BindablePropertyDescriptor(bindableTypeByType, property2);
			}
			DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.Parse(property);
			if (dependencyPropertyDescriptor != null)
			{
				bindableTypeByType = BindingPropertyHelper.BindableMetadataProvider!.GetBindableTypeByType(dependencyPropertyDescriptor.OwnerType);
				if (bindableTypeByType != null)
				{
					return new BindablePropertyDescriptor(bindableTypeByType, bindableTypeByType.GetProperty(dependencyPropertyDescriptor.Name));
				}
			}
		}
		return new BindablePropertyDescriptor(null, null);
	}
}
