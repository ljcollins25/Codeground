using Uno.Foundation.Logging;
using Uno.Presentation.Resources;
using Uno.UI;
using Uno.UI.Converters;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

public static class ResourceHelper
{
	public static IResourceRegistry Registry { get; set; }

	public static IResourcesService ResourcesService { get; set; }

	static ResourceHelper()
	{
		ResourceLoader.GetStringInternal = (string key) => ResourcesService.Get(key);
	}

	public static object FindResource(string resourceName)
	{
		return Registry.FindResource(resourceName);
	}

	public static string FindResourceString(string name)
	{
		return ResourcesService.Get(name);
	}

	public static IValueConverter FindConverter(string converterName)
	{
		IValueConverter valueConverter = Registry.FindResource(converterName) as IValueConverter;
		if (valueConverter == null)
		{
			Registry.Log().ErrorFormat("Resource [{0}] does not implement IValueConverter.", converterName);
			valueConverter = new NullConverter();
		}
		return valueConverter;
	}
}
