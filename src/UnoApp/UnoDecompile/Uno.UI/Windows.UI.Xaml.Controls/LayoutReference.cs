using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal struct LayoutReference
{
	internal ReferenceIdentity RelativeLocation { get; set; }

	internal Rect ReferenceBounds { get; set; }

	private Rect HeaderBounds { get; set; }

	private bool ReferenceIsHeader { get; set; }
}
