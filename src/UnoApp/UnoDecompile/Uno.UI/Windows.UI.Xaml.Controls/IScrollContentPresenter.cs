using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal interface IScrollContentPresenter
{
	ScrollBarVisibility NativeHorizontalScrollBarVisibility { set; }

	ScrollBarVisibility NativeVerticalScrollBarVisibility { set; }

	bool CanHorizontallyScroll { get; set; }

	bool CanVerticallyScroll { get; set; }

	Size? CustomContentExtent { get; }

	object Content { get; set; }

	bool ForceChangeToCurrentView { get; set; }

	void OnMinZoomFactorChanged(float newValue);

	void OnMaxZoomFactorChanged(float newValue);

	void ScrollTo(double? horizontalOffset, double? verticalOffset, bool disableAnimation);
}
