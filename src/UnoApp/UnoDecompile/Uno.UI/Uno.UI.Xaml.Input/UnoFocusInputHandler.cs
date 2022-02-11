using Uno.UI.Xaml.Core;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class UnoFocusInputHandler
{
	private readonly RootVisual _rootVisual;

	private bool _isShiftDown;

	public UnoFocusInputHandler(RootVisual rootVisual)
	{
		_rootVisual = rootVisual;
		_rootVisual.KeyDown += OnKeyDown;
		_rootVisual.KeyUp += OnKeyUp;
	}

	private void OnKeyUp(object sender, KeyRoutedEventArgs e)
	{
		if (e.OriginalKey == VirtualKey.Shift || e.OriginalKey == VirtualKey.LeftShift || e.OriginalKey == VirtualKey.RightShift)
		{
			_isShiftDown = false;
		}
	}

	private void OnKeyDown(object sender, KeyRoutedEventArgs e)
	{
		if (e.OriginalKey == VirtualKey.Shift || e.OriginalKey == VirtualKey.LeftShift || e.OriginalKey == VirtualKey.RightShift)
		{
			_isShiftDown = true;
		}
		if (!e.Handled)
		{
			if (e.OriginalKey == VirtualKey.Tab)
			{
				e.Handled = TryHandleTabFocus(_isShiftDown);
			}
			if (e.OriginalKey == VirtualKey.Up || e.OriginalKey == VirtualKey.Down || e.OriginalKey == VirtualKey.Left || e.OriginalKey == VirtualKey.Right)
			{
				e.Handled = TryHandleDirectionalFocus(e.OriginalKey);
			}
		}
	}

	internal bool TryHandleTabFocus(bool isShiftDown)
	{
		FocusNavigationDirection direction = (isShiftDown ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
		ContentRoot contentRootForElement = VisualTree.GetContentRootForElement(_rootVisual);
		if (contentRootForElement == null)
		{
			return false;
		}
		contentRootForElement.InputManager.LastInputDeviceType = InputDeviceType.Keyboard;
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(_rootVisual);
		FocusMovement focusMovement = new FocusMovement(XYFocusOptions.Default, direction, null);
		focusMovement.IsShiftPressed = _isShiftDown;
		focusMovement.IsProcessingTab = true;
		return (focusManagerForElement?.FindAndSetNextFocus(focusMovement))?.WasMoved ?? false;
	}

	internal bool TryHandleDirectionalFocus(VirtualKey originalKey)
	{
		ContentRoot contentRootForElement = VisualTree.GetContentRootForElement(_rootVisual);
		if (contentRootForElement == null)
		{
			return false;
		}
		contentRootForElement.InputManager.LastInputDeviceType = InputDeviceType.Keyboard;
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(_rootVisual);
		FocusNavigationDirection navigationDirectionForKeyboardArrow = FocusSelection.GetNavigationDirectionForKeyboardArrow(originalKey);
		if (focusManagerForElement == null || navigationDirectionForKeyboardArrow == FocusNavigationDirection.None)
		{
			return false;
		}
		DependencyObject dependencyObject = focusManagerForElement.FocusedElement;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		while (dependencyObject != null && !flag2)
		{
			FocusSelection.DirectionalFocusInfo directionalFocusInfo = FocusSelection.TryDirectionalFocus(focusManagerForElement, navigationDirectionForKeyboardArrow, dependencyObject);
			flag3 |= directionalFocusInfo.Handled;
			flag2 |= directionalFocusInfo.FocusCandidateFound;
			flag |= directionalFocusInfo.DirectionalFocusEnabled;
			if (!flag2 && directionalFocusInfo.ShouldBubble)
			{
				dependencyObject = dependencyObject.GetParent() as DependencyObject;
			}
		}
		if (flag && !flag2)
		{
			focusManagerForElement.RaiseNoFocusCandidateFoundEvent(navigationDirectionForKeyboardArrow);
		}
		return flag3;
	}
}
