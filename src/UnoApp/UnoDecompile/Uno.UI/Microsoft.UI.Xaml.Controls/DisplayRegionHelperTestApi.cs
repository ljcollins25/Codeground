namespace Microsoft.UI.Xaml.Controls;

internal static class DisplayRegionHelperTestApi
{
	public static bool SimulateDisplayRegions
	{
		get
		{
			return DisplayRegionHelper.SimulateDisplayRegions();
		}
		set
		{
			DisplayRegionHelper.SimulateDisplayRegions(value);
		}
	}

	public static TwoPaneViewMode SimulateMode
	{
		get
		{
			return DisplayRegionHelper.SimulateMode();
		}
		set
		{
			DisplayRegionHelper.SimulateMode(value);
		}
	}
}
