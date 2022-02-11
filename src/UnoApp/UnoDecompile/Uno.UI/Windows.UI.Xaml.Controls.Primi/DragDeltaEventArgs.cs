namespace Windows.UI.Xaml.Controls.Primitives;

public class DragDeltaEventArgs : RoutedEventArgs
{
	public double HorizontalChange { get; }

	public double VerticalChange { get; }

	internal double TotalHorizontalChange { get; }

	internal double TotalVerticalChange { get; }

	public DragDeltaEventArgs(double horizontalChange, double verticalChange)
	{
		HorizontalChange = horizontalChange;
		VerticalChange = verticalChange;
	}

	internal DragDeltaEventArgs(object originalSource, double horizontalChange, double verticalChange, double totalHorizontalChange, double totalVerticalChange)
		: base(originalSource)
	{
		HorizontalChange = horizontalChange;
		VerticalChange = verticalChange;
		TotalHorizontalChange = totalHorizontalChange;
		TotalVerticalChange = totalVerticalChange;
	}
}
