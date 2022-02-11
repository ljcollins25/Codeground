using Windows.System;

namespace Windows.UI.Xaml.Controls;

internal class KeyPressMenuFlyout
{
	internal static bool KeyDown(VirtualKey key, MenuFlyoutItem control)
	{
		bool result = false;
		if (control.m_bIsSpaceOrEnterKeyDown || control.m_bIsNavigationAcceptOrGamepadAKeyDown)
		{
			if (key != VirtualKey.Space && key != VirtualKey.Enter && control.m_bIsSpaceOrEnterKeyDown)
			{
				control.m_bIsSpaceOrEnterKeyDown = false;
			}
			if (control.m_bIsNavigationAcceptOrGamepadAKeyDown && key != VirtualKey.GamepadA)
			{
				control.m_bIsNavigationAcceptOrGamepadAKeyDown = false;
			}
			control.m_bIsPressed = false;
			control.UpdateVisualState();
		}
		switch (key)
		{
		case VirtualKey.Up:
		case VirtualKey.GamepadDPadUp:
		case VirtualKey.GamepadLeftThumbstickUp:
		{
			MenuFlyoutPresenter parentMenuFlyoutPresenter = control.GetParentMenuFlyoutPresenter();
			if (parentMenuFlyoutPresenter != null)
			{
				parentMenuFlyoutPresenter.HandleUpOrDownKey(isDownKey: false);
				result = true;
			}
			break;
		}
		case VirtualKey.Down:
		case VirtualKey.GamepadDPadDown:
		case VirtualKey.GamepadLeftThumbstickDown:
		{
			MenuFlyoutPresenter parentMenuFlyoutPresenter2 = control.GetParentMenuFlyoutPresenter();
			if (parentMenuFlyoutPresenter2 != null)
			{
				parentMenuFlyoutPresenter2.HandleUpOrDownKey(isDownKey: true);
				result = true;
			}
			break;
		}
		case VirtualKey.Enter:
		case VirtualKey.Space:
		case VirtualKey.GamepadA:
			control.m_bIsPressed = true;
			switch (key)
			{
			case VirtualKey.Enter:
			case VirtualKey.Space:
				control.m_bIsSpaceOrEnterKeyDown = true;
				break;
			case VirtualKey.GamepadA:
				control.m_bIsNavigationAcceptOrGamepadAKeyDown = true;
				break;
			}
			control.UpdateVisualState();
			result = true;
			break;
		}
		return result;
	}

	internal static bool KeyUp(VirtualKey key, MenuFlyoutItem control)
	{
		bool result = false;
		if (key == VirtualKey.Space || key == VirtualKey.Enter || key == VirtualKey.GamepadA)
		{
			switch (key)
			{
			case VirtualKey.Enter:
			case VirtualKey.Space:
				control.m_bIsSpaceOrEnterKeyDown = false;
				break;
			case VirtualKey.GamepadA:
				control.m_bIsNavigationAcceptOrGamepadAKeyDown = false;
				break;
			}
			if (control.m_bIsPressed && !control.m_bIsPointerLeftButtonDown)
			{
				control.m_bIsPressed = false;
				control.UpdateVisualState();
				control.Invoke();
				result = true;
			}
		}
		return result;
	}
}
