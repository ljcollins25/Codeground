using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class ManipulationInertiaStartingRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	internal PointerIdentifier[] Pointers { get; }

	public bool Handled { get; set; }

	public UIElement Container { get; }

	public PointerDeviceType PointerDeviceType { get; }

	public ManipulationDelta Delta { get; }

	public ManipulationDelta Cumulative { get; }

	public ManipulationVelocities Velocities { get; }

	public InertiaTranslationBehavior TranslationBehavior { get; set; }

	public InertiaRotationBehavior RotationBehavior { get; set; }

	public InertiaExpansionBehavior ExpansionBehavior { get; set; }

	public ManipulationInertiaStartingRoutedEventArgs()
	{
	}

	internal ManipulationInertiaStartingRoutedEventArgs(UIElement container, ManipulationInertiaStartingEventArgs args)
		: base(container)
	{
		Container = container;
		Pointers = args.Pointers;
		PointerDeviceType = args.PointerDeviceType;
		Delta = args.Delta;
		Cumulative = args.Cumulative;
		Velocities = args.Velocities;
		TranslationBehavior = new InertiaTranslationBehavior(args.Processor);
		RotationBehavior = new InertiaRotationBehavior(args.Processor);
		ExpansionBehavior = new InertiaExpansionBehavior(args.Processor);
	}
}
