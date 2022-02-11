using Uno.UI.Xaml.Input;

namespace Windows.UI.Xaml.Input;

public class NoFocusCandidateFoundEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	public FocusNavigationDirection Direction { get; }

	public FocusInputDeviceKind InputDevice { get; }

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

	internal NoFocusCandidateFoundEventArgs(FocusNavigationDirection direction, FocusInputDeviceKind inputDevice)
	{
		Direction = direction;
		InputDevice = inputDevice;
	}
}
