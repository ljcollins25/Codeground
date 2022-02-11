using System.Runtime.CompilerServices;

namespace Uno.UI.Xaml;

internal static class RoutedEventFlagExtensions
{
	private const RoutedEventFlag _isPointer = RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased | RoutedEventFlag.PointerEntered | RoutedEventFlag.PointerExited | RoutedEventFlag.PointerMoved | RoutedEventFlag.PointerCanceled | RoutedEventFlag.PointerCaptureLost | RoutedEventFlag.PointerWheelChanged;

	private const RoutedEventFlag _isKey = RoutedEventFlag.KeyDown | RoutedEventFlag.KeyUp;

	private const RoutedEventFlag _isFocus = RoutedEventFlag.GettingFocus | RoutedEventFlag.GotFocus | RoutedEventFlag.LosingFocus | RoutedEventFlag.LostFocus | RoutedEventFlag.NoFocusCandidateFound;

	private const RoutedEventFlag _isDragAndDrop = RoutedEventFlag.DragStarting | RoutedEventFlag.DragEnter | RoutedEventFlag.DragLeave | RoutedEventFlag.DragOver | RoutedEventFlag.Drop | RoutedEventFlag.DropCompleted;

	private const RoutedEventFlag _isManipulation = RoutedEventFlag.ManipulationStarting | RoutedEventFlag.ManipulationStarted | RoutedEventFlag.ManipulationDelta | RoutedEventFlag.ManipulationInertiaStarting | RoutedEventFlag.ManipulationCompleted;

	private const RoutedEventFlag _isGesture = RoutedEventFlag.Tapped | RoutedEventFlag.DoubleTapped | RoutedEventFlag.RightTapped | RoutedEventFlag.Holding;

	private const RoutedEventFlag _isContextMenu = (RoutedEventFlag)3458764513820540928uL;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPointerEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased | RoutedEventFlag.PointerEntered | RoutedEventFlag.PointerExited | RoutedEventFlag.PointerMoved | RoutedEventFlag.PointerCanceled | RoutedEventFlag.PointerCaptureLost | RoutedEventFlag.PointerWheelChanged)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsKeyEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.KeyDown | RoutedEventFlag.KeyUp)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsFocusEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.GettingFocus | RoutedEventFlag.GotFocus | RoutedEventFlag.LosingFocus | RoutedEventFlag.LostFocus | RoutedEventFlag.NoFocusCandidateFound)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsDragAndDropEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.DragStarting | RoutedEventFlag.DragEnter | RoutedEventFlag.DragLeave | RoutedEventFlag.DragOver | RoutedEventFlag.Drop | RoutedEventFlag.DropCompleted)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsManipulationEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.ManipulationStarting | RoutedEventFlag.ManipulationStarted | RoutedEventFlag.ManipulationDelta | RoutedEventFlag.ManipulationInertiaStarting | RoutedEventFlag.ManipulationCompleted)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsGestureEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag.Tapped | RoutedEventFlag.DoubleTapped | RoutedEventFlag.RightTapped | RoutedEventFlag.Holding)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsContextEvent(this RoutedEventFlag flag)
	{
		return (flag & (RoutedEventFlag)3458764513820540928uL) != 0;
	}
}
