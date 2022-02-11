using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DirectUI;

internal struct FocusRectangleOptions
{
	public SolidColorBrush firstBrush;

	public SolidColorBrush secondBrush;

	public bool drawFirst;

	public bool drawSecond;

	public bool drawReveal;

	public bool isRevealBorderless;

	public uint revealColor;

	public Rect bounds;

	public Rect previousBounds;

	public Thickness firstThickness;

	public Thickness secondThickness;
}
