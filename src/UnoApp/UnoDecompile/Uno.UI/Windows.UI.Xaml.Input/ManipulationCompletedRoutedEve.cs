using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class ManipulationCompletedRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	internal PointerIdentifier[] Pointers { get; set; }

	public bool Handled { get; set; }

	public UIElement Container { get; }

	public PointerDeviceType PointerDeviceType { get; }

	public Point Position { get; }

	public ManipulationDelta Cumulative { get; }

	public ManipulationVelocities Velocities { get; }

	public bool IsInertial { get; }

	public ManipulationCompletedRoutedEventArgs()
	{
	}

	internal ManipulationCompletedRoutedEventArgs(UIElement container, ManipulationCompletedEventArgs args)
		: base(container)
	{
		Container = container;
		Pointers = args.Pointers;
		PointerDeviceType = args.PointerDeviceType;
		Position = args.Position;
		Cumulative = args.Cumulative;
		Velocities = args.Velocities;
		IsInertial = args.IsInertial;
	}
}
