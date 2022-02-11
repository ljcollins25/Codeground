using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class FocusSelection
{
	internal struct DirectionalFocusInfo
	{
		public static DirectionalFocusInfo Default => new DirectionalFocusInfo(handled: false, shouldBubble: true, focusCandidateFound: false, directionalFocusEnabled: false);

		public bool Handled { get; set; }

		public bool ShouldBubble { get; set; }

		public bool FocusCandidateFound { get; set; }

		public bool DirectionalFocusEnabled { get; set; }

		public DirectionalFocusInfo(bool handled, bool shouldBubble, bool focusCandidateFound, bool directionalFocusEnabled)
		{
			Handled = handled;
			ShouldBubble = shouldBubble;
			FocusCandidateFound = focusCandidateFound;
			DirectionalFocusEnabled = directionalFocusEnabled;
		}
	}

	internal static bool ShouldUpdateFocus(DependencyObject element, FocusState focusState)
	{
		if (focusState == FocusState.Pointer)
		{
			return GetAllowFocusOnInteraction(element);
		}
		return true;
	}

	internal static bool GetAllowFocusOnInteraction(DependencyObject element)
	{
		if (element is TextElement textElement)
		{
			return textElement.AllowFocusOnInteraction;
		}
		if (element is FlyoutBase flyoutBase)
		{
			return flyoutBase.AllowFocusOnInteraction;
		}
		if (element is FrameworkElement frameworkElement)
		{
			return frameworkElement.AllowFocusOnInteraction;
		}
		return true;
	}

	internal static FocusNavigationDirection GetNavigationDirection(VirtualKey key)
	{
		FocusNavigationDirection result = FocusNavigationDirection.None;
		switch (key)
		{
		case VirtualKey.Up:
		case VirtualKey.GamepadDPadUp:
		case VirtualKey.GamepadLeftThumbstickUp:
			result = FocusNavigationDirection.Up;
			break;
		case VirtualKey.Down:
		case VirtualKey.GamepadDPadDown:
		case VirtualKey.GamepadLeftThumbstickDown:
			result = FocusNavigationDirection.Down;
			break;
		case VirtualKey.Left:
		case VirtualKey.GamepadDPadLeft:
		case VirtualKey.GamepadLeftThumbstickLeft:
			result = FocusNavigationDirection.Left;
			break;
		case VirtualKey.Right:
		case VirtualKey.GamepadDPadRight:
		case VirtualKey.GamepadLeftThumbstickRight:
			result = FocusNavigationDirection.Right;
			break;
		}
		return result;
	}

	internal static FocusNavigationDirection GetNavigationDirectionForKeyboardArrow(VirtualKey key)
	{
		return key switch
		{
			VirtualKey.Up => FocusNavigationDirection.Up, 
			VirtualKey.Down => FocusNavigationDirection.Down, 
			VirtualKey.Left => FocusNavigationDirection.Left, 
			VirtualKey.Right => FocusNavigationDirection.Right, 
			_ => FocusNavigationDirection.None, 
		};
	}

	internal static DirectionalFocusInfo TryDirectionalFocus(IFocusManager focusManager, FocusNavigationDirection direction, DependencyObject searchScope)
	{
		DirectionalFocusInfo @default = DirectionalFocusInfo.Default;
		if (direction == FocusNavigationDirection.Next || direction == FocusNavigationDirection.Previous || direction == FocusNavigationDirection.None)
		{
			return @default;
		}
		if (!(searchScope is UIElement uIElement))
		{
			return @default;
		}
		switch (uIElement.XYFocusKeyboardNavigation)
		{
		case XYFocusKeyboardNavigationMode.Disabled:
			@default.ShouldBubble = false;
			break;
		case XYFocusKeyboardNavigationMode.Enabled:
		{
			@default.DirectionalFocusEnabled = true;
			XYFocusOptions default2 = XYFocusOptions.Default;
			default2.SearchRoot = searchScope;
			default2.ShouldConsiderXYFocusKeyboardNavigation = true;
			DependencyObject dependencyObject = focusManager.FindNextFocus(new FindFocusOptions(direction), default2);
			if (dependencyObject != null)
			{
				FocusMovementResult focusMovementResult = focusManager.SetFocusedElement(new FocusMovement(dependencyObject, direction, FocusState.Keyboard));
				@default.Handled = focusMovementResult.WasMoved;
				@default.FocusCandidateFound = true;
			}
			break;
		}
		}
		return @default;
	}
}
