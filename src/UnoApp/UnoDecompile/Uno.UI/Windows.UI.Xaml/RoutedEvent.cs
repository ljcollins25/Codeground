using System.Diagnostics;
using System.Runtime.CompilerServices;
using Uno.UI.Xaml;

namespace Windows.UI.Xaml;

[DebuggerDisplay("{Name}")]
public class RoutedEvent
{
	internal string Name { get; }

	internal RoutedEventFlag Flag { get; }

	internal bool IsAlwaysBubbled { get; }

	internal bool IsPointerEvent { get; }

	internal bool IsKeyEvent { get; }

	internal bool IsFocusEvent { get; }

	internal bool IsManipulationEvent { get; }

	internal bool IsGestureEvent { get; }

	internal bool IsDragAndDropEvent { get; }

	internal RoutedEvent(RoutedEventFlag flag, [CallerMemberName] string name = null)
	{
		Flag = flag;
		Name = name;
		IsPointerEvent = flag.IsPointerEvent();
		IsKeyEvent = flag.IsKeyEvent();
		IsFocusEvent = flag.IsFocusEvent();
		IsManipulationEvent = flag.IsManipulationEvent();
		IsGestureEvent = flag.IsGestureEvent();
		IsDragAndDropEvent = flag.IsDragAndDropEvent();
		IsAlwaysBubbled = IsPointerEvent || IsGestureEvent || IsManipulationEvent || IsDragAndDropEvent;
	}
}
