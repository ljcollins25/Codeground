using System;

namespace Uno.UI.Xaml;

[Flags]
public enum RoutedEventFlag : ulong
{
	None = 0uL,
	PointerPressed = 1uL,
	PointerReleased = 2uL,
	PointerEntered = 4uL,
	PointerExited = 8uL,
	PointerMoved = 0x10uL,
	PointerCanceled = 0x20uL,
	PointerCaptureLost = 0x40uL,
	PointerWheelChanged = 0x80uL,
	KeyDown = 0x2000uL,
	KeyUp = 0x8000uL,
	GettingFocus = 0x1000000uL,
	GotFocus = 0x2000000uL,
	LosingFocus = 0x4000000uL,
	LostFocus = 0x8000000uL,
	NoFocusCandidateFound = 0x10000000uL,
	DragStarting = 0x100000000uL,
	DragEnter = 0x200000000uL,
	DragLeave = 0x400000000uL,
	DragOver = 0x800000000uL,
	Drop = 0x1000000000uL,
	DropCompleted = 0x2000000000uL,
	ManipulationStarting = 0x10000000000uL,
	ManipulationStarted = 0x20000000000uL,
	ManipulationDelta = 0x40000000000uL,
	ManipulationInertiaStarting = 0x80000000000uL,
	ManipulationCompleted = 0x100000000000uL,
	Tapped = 0x1000000000000uL,
	DoubleTapped = 0x2000000000000uL,
	RightTapped = 0x4000000000000uL,
	Holding = 0x8000000000000uL
}
