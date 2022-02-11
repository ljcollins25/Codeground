using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

public delegate void PropertySetterHandler(object instance, object? value, DependencyPropertyValuePrecedences? precedence);
