namespace Windows.UI.Xaml.Controls;

internal interface ILayoutStrategy
{
	Orientation VirtualizationDirection { get; }

	void BeginMeasure();

	void EndMeasure();
}
