using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class FocusMovement
{
	internal DependencyObject? Target { get; }

	internal FocusState FocusState { get; }

	internal FocusNavigationDirection Direction { get; } = FocusNavigationDirection.None;


	internal XYFocusOptions? XYFocusOptions { get; }

	internal Guid CorrelationId { get; set; } = Guid.Empty;


	internal bool ForceBringIntoView { get; set; }

	internal bool AnimateIfBringIntoView { get; set; }

	internal bool IsProcessingTab { get; set; }

	internal bool IsShiftPressed { get; set; }

	internal bool CanCancel { get; set; } = true;


	internal bool CanDepartFocus { get; set; } = true;


	internal bool CanNavigateFocus { get; set; } = true;


	internal bool RaiseGettingLosingEvents { get; set; } = true;


	internal bool ShouldCompleteAsyncOperation { get; set; }

	internal FocusMovement(XYFocusOptions xyFocusOptions, FocusNavigationDirection direction, DependencyObject? target)
	{
		XYFocusOptions = xyFocusOptions;
		Direction = direction;
		Target = target;
		ForceBringIntoView = true;
		CorrelationId = Guid.NewGuid();
		FocusState = FocusState.Programmatic;
		if (direction == FocusNavigationDirection.Down || direction == FocusNavigationDirection.Left || direction == FocusNavigationDirection.Right || direction == FocusNavigationDirection.Up)
		{
			FocusState = FocusState.Keyboard;
		}
	}

	internal FocusMovement(DependencyObject? target, FocusNavigationDirection direction, FocusState focusState)
	{
		Target = target;
		Direction = direction;
		FocusState = focusState;
		CorrelationId = Guid.NewGuid();
	}

	internal FocusMovement(DependencyObject? target, FocusMovement copy)
	{
		Target = target;
		FocusState = copy.FocusState;
		Direction = copy.Direction;
		XYFocusOptions = copy.XYFocusOptions;
		ForceBringIntoView = copy.ForceBringIntoView;
		AnimateIfBringIntoView = copy.AnimateIfBringIntoView;
		IsProcessingTab = copy.IsProcessingTab;
		IsShiftPressed = copy.IsShiftPressed;
		CanCancel = copy.CanCancel;
		CanDepartFocus = copy.CanDepartFocus;
		CanNavigateFocus = copy.CanNavigateFocus;
		RaiseGettingLosingEvents = copy.RaiseGettingLosingEvents;
		ShouldCompleteAsyncOperation = copy.ShouldCompleteAsyncOperation;
		CorrelationId = copy.CorrelationId;
	}
}
