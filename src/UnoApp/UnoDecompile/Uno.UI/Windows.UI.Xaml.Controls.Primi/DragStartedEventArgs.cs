namespace Windows.UI.Xaml.Controls.Primitives;

public class DragStartedEventArgs : RoutedEventArgs
{
	public double HorizontalOffset { get; }

	public double VerticalOffset { get; }

	public DragStartedEventArgs(double horizontalOffset, double verticalOffset)
	{
		HorizontalOffset = horizontalOffset;
		VerticalOffset = verticalOffset;
	}

	internal DragStartedEventArgs(object originalSource, double horizontalOffset, double verticalOffset)
		: base(originalSource)
	{
		HorizontalOffset = horizontalOffset;
		VerticalOffset = verticalOffset;
	}
}
