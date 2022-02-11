using System;
using Uno;
using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation.Metadata;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class ManipulationStartingRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly ManipulationStartingEventArgs _args;

	private ManipulationModes _mode;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ManipulationPivot Pivot
	{
		get
		{
			throw new NotImplementedException("The member ManipulationPivot ManipulationStartingRoutedEventArgs.Pivot is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Input.ManipulationStartingRoutedEventArgs", "ManipulationPivot ManipulationStartingRoutedEventArgs.Pivot");
		}
	}

	internal PointerIdentifier Pointer { get; }

	public bool Handled { get; set; }

	public UIElement Container { get; set; }

	public ManipulationModes Mode
	{
		get
		{
			return _mode;
		}
		set
		{
			_mode = value;
			if (_args != null)
			{
				_args.Settings = value.ToGestureSettings();
			}
		}
	}

	public ManipulationStartingRoutedEventArgs()
	{
	}

	internal ManipulationStartingRoutedEventArgs(UIElement container, ManipulationStartingEventArgs args)
		: base(container)
	{
		Container = container;
		_args = args;
		_mode = container.ManipulationMode;
		Pointer = args.Pointer;
	}
}
