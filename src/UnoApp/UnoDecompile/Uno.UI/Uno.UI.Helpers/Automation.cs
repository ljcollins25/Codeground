using System;
using System.Globalization;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers;

public static class Automation
{
	[Preserve]
	public static string GetDependencyPropertyValue(int handle, string propertyName)
	{
		UIElement elementFromHandle = UIElement.GetElementFromHandle(handle);
		if (elementFromHandle != null)
		{
			return Convert.ToString(UIElement.GetDependencyPropertyValueInternal(elementFromHandle, propertyName), CultureInfo.InvariantCulture);
		}
		Console.Error.WriteLine($"No UIElement found for htmlId \"{handle}\"");
		return "";
	}

	[Preserve]
	public static string SetDependencyPropertyValue(int handle, string dependencyPropertyNameAndValue)
	{
		UIElement elementFromHandle = UIElement.GetElementFromHandle(handle);
		if (elementFromHandle != null)
		{
			return UIElement.SetDependencyPropertyValueInternal(elementFromHandle, dependencyPropertyNameAndValue);
		}
		Console.Error.WriteLine($"No UIElement found for htmlId \"{handle}\"");
		return "";
	}
}
