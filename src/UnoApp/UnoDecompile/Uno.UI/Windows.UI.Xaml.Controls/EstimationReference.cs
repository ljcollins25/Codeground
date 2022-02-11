using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal struct EstimationReference
{
	private ElementType ElementType { get; set; }

	private int ElementIndex { get; set; }

	private Rect ElementBounds { get; set; }
}
