using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal static class FocusConversionFunctions
{
	internal static FocusNavigationDirection GetFocusNavigationDirectionFromReason(XamlSourceFocusNavigationReason reason)
	{
		return reason switch
		{
			XamlSourceFocusNavigationReason.First => FocusNavigationDirection.Next, 
			XamlSourceFocusNavigationReason.Last => FocusNavigationDirection.Previous, 
			XamlSourceFocusNavigationReason.Left => FocusNavigationDirection.Left, 
			XamlSourceFocusNavigationReason.Right => FocusNavigationDirection.Right, 
			XamlSourceFocusNavigationReason.Up => FocusNavigationDirection.Up, 
			XamlSourceFocusNavigationReason.Down => FocusNavigationDirection.Down, 
			_ => FocusNavigationDirection.None, 
		};
	}

	internal static XamlSourceFocusNavigationReason? GetFocusNavigationReasonFromDirection(FocusNavigationDirection direction)
	{
		return direction switch
		{
			FocusNavigationDirection.Next => XamlSourceFocusNavigationReason.First, 
			FocusNavigationDirection.Previous => XamlSourceFocusNavigationReason.Last, 
			FocusNavigationDirection.None => XamlSourceFocusNavigationReason.Programmatic, 
			FocusNavigationDirection.Left => XamlSourceFocusNavigationReason.Left, 
			FocusNavigationDirection.Right => XamlSourceFocusNavigationReason.Right, 
			FocusNavigationDirection.Up => XamlSourceFocusNavigationReason.Up, 
			FocusNavigationDirection.Down => XamlSourceFocusNavigationReason.Down, 
			_ => null, 
		};
	}

	internal static InputDeviceType GetInputDeviceTypeFromDirection(FocusNavigationDirection direction)
	{
		switch (direction)
		{
		case FocusNavigationDirection.Next:
		case FocusNavigationDirection.Previous:
			return InputDeviceType.Keyboard;
		case FocusNavigationDirection.Up:
		case FocusNavigationDirection.Down:
		case FocusNavigationDirection.Left:
		case FocusNavigationDirection.Right:
			return InputDeviceType.GamepadOrRemote;
		default:
			return InputDeviceType.None;
		}
	}

	internal static FocusNavigationDirection GetReverseDirection(FocusNavigationDirection direction)
	{
		return direction switch
		{
			FocusNavigationDirection.Left => FocusNavigationDirection.Right, 
			FocusNavigationDirection.Right => FocusNavigationDirection.Left, 
			FocusNavigationDirection.Up => FocusNavigationDirection.Down, 
			FocusNavigationDirection.Down => FocusNavigationDirection.Up, 
			FocusNavigationDirection.Next => FocusNavigationDirection.Previous, 
			FocusNavigationDirection.Previous => FocusNavigationDirection.Next, 
			_ => FocusNavigationDirection.None, 
		};
	}
}
