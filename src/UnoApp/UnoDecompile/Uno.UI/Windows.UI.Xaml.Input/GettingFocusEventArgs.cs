using System;
using Uno.UI.Xaml.Input;

namespace Windows.UI.Xaml.Input;

public class GettingFocusEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs, IChangingFocusEventArgs
{
	private bool _canCancelOrRedirectFocus;

	public FocusNavigationDirection Direction { get; }

	public FocusState FocusState { get; }

	public FocusInputDeviceKind InputDevice { get; }

	public DependencyObject? OldFocusedElement { get; }

	public Guid CorrelationId { get; }

	public DependencyObject? NewFocusedElement { get; set; }

	DependencyObject? IChangingFocusEventArgs.NewFocusedElement
	{
		get
		{
			return NewFocusedElement;
		}
		set
		{
			NewFocusedElement = value;
		}
	}

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

	public bool Cancel { get; set; }

	bool IChangingFocusEventArgs.Cancel => Cancel;

	internal GettingFocusEventArgs(DependencyObject? oldFocusedElement, DependencyObject? newFocusedElement, FocusState focusState, FocusNavigationDirection direction, FocusInputDeviceKind inputDevice, bool canCancelFocus, Guid correlationId)
	{
		OldFocusedElement = oldFocusedElement;
		NewFocusedElement = newFocusedElement;
		FocusState = focusState;
		Direction = direction;
		InputDevice = inputDevice;
		_canCancelOrRedirectFocus = canCancelFocus;
		CorrelationId = correlationId;
	}

	public bool TryCancel()
	{
		if (_canCancelOrRedirectFocus)
		{
			Cancel = true;
			return true;
		}
		return false;
	}

	public bool TrySetNewFocusedElement(DependencyObject? element)
	{
		if (_canCancelOrRedirectFocus)
		{
			NewFocusedElement = element;
			return true;
		}
		return false;
	}
}
