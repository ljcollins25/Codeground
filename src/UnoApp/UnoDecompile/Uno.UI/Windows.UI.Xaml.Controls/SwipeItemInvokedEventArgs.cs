namespace Windows.UI.Xaml.Controls;

public class SwipeItemInvokedEventArgs
{
	public SwipeControl SwipeControl { get; }

	internal SwipeItemInvokedEventArgs(SwipeControl swipeControl)
	{
		SwipeControl = swipeControl;
	}
}
