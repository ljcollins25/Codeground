using System;
using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

public interface IBindableProperty
{
	Type PropertyType { get; }

	DependencyProperty? DependencyProperty { get; }

	PropertyGetterHandler? Getter { get; }

	PropertySetterHandler? Setter { get; }
}
