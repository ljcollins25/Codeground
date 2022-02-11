namespace Microsoft.UI.Xaml.Controls;

internal class LifetimeHandler
{
	private static DisplayRegionHelper _displayRegionHelper;

	internal static DisplayRegionHelper GetDisplayRegionHelperInstance()
	{
		DisplayRegionHelper obj = _displayRegionHelper ?? new DisplayRegionHelper();
		_displayRegionHelper = obj;
		return obj;
	}
}
