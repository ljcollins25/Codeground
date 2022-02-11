using Uno.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class FocusEngagedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	public bool Handled { get; set; }

	bool IHandleableRoutedEventArgs.Handled
	{
		get
		{
			return Handled;
		}
		set
		{
			Handled = value;
		}
	}

	internal FocusEngagedEventArgs()
	{
	}
}
