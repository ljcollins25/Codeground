using System.ComponentModel;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers.Xaml;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SetterHelper
{
	public static Setter GetPropertySetterWithResourceValue(DependencyProperty dependencyProperty, object key, object context, object defaultValue)
	{
		return new Setter(dependencyProperty, new SetterValueProviderHandler(ProvideSetterValue));
		object ProvideSetterValue()
		{
			if (ResourceResolver.ResolveResourceStatic(key, out var value, context))
			{
				return value;
			}
			return defaultValue;
		}
	}
}
