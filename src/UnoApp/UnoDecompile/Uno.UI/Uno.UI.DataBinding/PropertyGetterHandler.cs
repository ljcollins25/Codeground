using Windows.UI.Xaml;

namespace Uno.UI.DataBinding;

public delegate object PropertyGetterHandler(object instance, DependencyPropertyValuePrecedences? precedence);
