namespace Windows.UI.Xaml.Controls.Primitives;

public class ScrollEventArgs : RoutedEventArgs
{
	public double NewValue { get; internal set; }

	public ScrollEventType ScrollEventType { get; internal set; }
}
