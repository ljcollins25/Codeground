using System;

namespace Windows.UI.Xaml.Resources;

public class CustomXamlResourceLoader
{
	public static CustomXamlResourceLoader Current { get; set; }

	protected virtual object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
	{
		throw new NotImplementedException();
	}

	internal object GetResourceInternal(string resourceId, string objectType, string propertyName, string propertyType)
	{
		return GetResource(resourceId, objectType, propertyName, propertyType);
	}
}
