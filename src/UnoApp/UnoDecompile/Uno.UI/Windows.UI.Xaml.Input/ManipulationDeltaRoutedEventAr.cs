using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class ManipulationDeltaRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly GestureRecognizer _recognizer;

	internal PointerIdentifier[] Pointers { get; }

	public bool Handled { get; set; }

	public UIElement Container { get; }

	public PointerDeviceType PointerDeviceType { get; }

	public Point Position { get; }

	public ManipulationDelta Delta { get; }

	public ManipulationDelta Cumulative { get; }

	public ManipulationVelocities Velocities { get; }

	public bool IsInertial { get; }

	public ManipulationDeltaRoutedEventArgs()
	{
	}

	internal ManipulationDeltaRoutedEventArgs(UIElement container, GestureRecognizer recognizer, ManipulationUpdatedEventArgs args)
		: base(container)
	{
		Container = container;
		_recognizer = recognizer;
		Pointers = args.Pointers;
		PointerDeviceType = args.PointerDeviceType;
		Position = args.Position;
		Delta = args.Delta;
		Cumulative = args.Cumulative;
		Velocities = args.Velocities;
		IsInertial = args.IsInertial;
	}

	public void Complete()
	{
		_recognizer?.CompleteGesture();
	}
}
