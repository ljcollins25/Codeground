using Windows.Foundation;

namespace Windows.UI.Xaml;

internal interface IUIElement
{
	Size LastAvailableSize { get; set; }

	Size DesiredSize { get; set; }

	Rect LayoutSlot { get; set; }
}
