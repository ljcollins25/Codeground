using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal interface ILayouter
{
	Size Measure(Size availableSize);

	void Arrange(Rect finalRect);

	Size MeasureChild(UIElement view, Size slotSize);

	void ArrangeChild(UIElement view, Rect frame);

	Size GetDesiredSize(UIElement view);
}
