using System;
using Uno.UI.DataBinding;
using Windows.UI.Xaml;

namespace Uno.UI;

internal class RuntimeTypeMetadataUpdateHandler
{
	public static void ClearCache(Type[] types)
	{
		DependencyProperty.ClearRegistry();
		BindingPropertyHelper.ClearCaches();
	}

	public static void UpdateApplication(Type[] types)
	{
	}
}
