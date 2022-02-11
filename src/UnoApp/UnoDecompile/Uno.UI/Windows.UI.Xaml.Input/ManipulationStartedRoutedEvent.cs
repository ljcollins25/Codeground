using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class ManipulationStartedRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly GestureRecognizer _recognizer;

	internal PointerIdentifier[] Pointers { get; }

	public bool Handled { get; set; }

	public UIElement Container { get; }

	public PointerDeviceType PointerDeviceType { get; }

	public Point Position { get; }

	public ManipulationDelta Cumulative { get; }

	public ManipulationStartedRoutedEventArgs()
	{
	}

	internal ManipulationStartedRoutedEventArgs(UIElement container, GestureRecognizer recognizer, ManipulationStartedEventArgs args)
		: base(container)
	{
		Container = container;
		_recognizer = recognizer;
		Pointers = args.Pointers;
		PointerDeviceType = args.PointerDeviceType;
		Position = args.Position;
		Cumulative = args.Cumulative;
	}

	public void Complete()
	{
		_recognizer?.CompleteGesture();
	}
}
