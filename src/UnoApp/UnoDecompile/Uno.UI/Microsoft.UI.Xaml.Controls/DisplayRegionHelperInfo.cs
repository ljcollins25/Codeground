using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

internal struct DisplayRegionHelperInfo
{
	private const int c_maxRegions = 2;

	public TwoPaneViewMode Mode { get; set; }

	public Rect[] Regions { get; set; }

	public DisplayRegionHelperInfo()
	{
		Mode = TwoPaneViewMode.SinglePane;
		Regions = new Rect[2];
	}
}
