using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IScrollProvider
{
	double HorizontalScrollPercent { get; }

	double HorizontalViewSize { get; }

	bool HorizontallyScrollable { get; }

	double VerticalScrollPercent { get; }

	double VerticalViewSize { get; }

	bool VerticallyScrollable { get; }

	void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);

	void SetScrollPercent(double horizontalPercent, double verticalPercent);
}
