namespace Windows.UI.Xaml;

internal static class DependencyPropertyFactory
{
	internal static void IsUnsetValue(object spDateFormat, out bool isUnsetValue)
	{
		isUnsetValue = spDateFormat is UnsetValue;
	}
}
