using Windows.System;

namespace Windows.UI.Xaml.Controls;

internal class KeyPressMenuFlyoutPresenter
{
	internal static bool KeyDown(VirtualKey key, MenuFlyoutPresenter control)
	{
		bool result = false;
		switch (key)
		{
		case VirtualKey.Up:
		case VirtualKey.GamepadDPadUp:
		case VirtualKey.GamepadLeftThumbstickUp:
			control.HandleUpOrDownKey(isDownKey: false);
			result = true;
			break;
		case VirtualKey.Down:
		case VirtualKey.GamepadDPadDown:
		case VirtualKey.GamepadLeftThumbstickDown:
			control.HandleUpOrDownKey(isDownKey: true);
			result = true;
			break;
		case VirtualKey.Tab:
			result = true;
			break;
		case VirtualKey.Escape:
		case VirtualKey.Left:
			if (control.IsSubPresenter)
			{
				control.HandleKeyDownLeftOrEscape();
				result = true;
			}
			else
			{
				result = false;
			}
			break;
		}
		return result;
	}
}
