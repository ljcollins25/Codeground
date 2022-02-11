namespace Windows.UI.Xaml.Controls.Primitives;

public class DragCompletedEventArgs : RoutedEventArgs
{
	public bool Canceled { get; }

	public double HorizontalChange { get; }

	public double VerticalChange { get; }

	internal double TotalHorizontalChange { get; }

	internal double TotalVerticalChange { get; }

	public DragCompletedEventArgs(double horizontalChange, double verticalChange, bool canceled)
	{
		Canceled = canceled;
		HorizontalChange = horizontalChange;
		VerticalChange = verticalChange;
	}

	public DragCompletedEventArgs(object originalSource, double horizontalChange, double verticalChange, double totalHorizontalChange, double totalVerticalChange, bool canceled)
		: base(originalSource)
	{
		Canceled = canceled;
		HorizontalChange = horizontalChange;
		VerticalChange = verticalChange;
		TotalHorizontalChange = totalHorizontalChange;
		TotalVerticalChange = totalVerticalChange;
	}
}
