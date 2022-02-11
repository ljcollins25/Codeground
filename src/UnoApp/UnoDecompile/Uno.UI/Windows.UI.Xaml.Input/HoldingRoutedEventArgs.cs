using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public class HoldingRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly UIElement _originalSource;

	private readonly Point _position;

	internal uint PointerId { get; }

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

	public PointerDeviceType PointerDeviceType { get; }

	public HoldingState HoldingState { get; }

	public HoldingRoutedEventArgs()
	{
	}

	internal HoldingRoutedEventArgs(UIElement originalSource, HoldingEventArgs args)
		: base(originalSource)
	{
		_originalSource = originalSource;
		_position = args.Position;
		PointerId = args.PointerId;
		PointerDeviceType = args.PointerDeviceType;
		HoldingState = args.HoldingState;
	}

	public Point GetPosition(UIElement relativeTo)
	{
		if (_originalSource == null)
		{
			return default(Point);
		}
		if (relativeTo == _originalSource)
		{
			return _position;
		}
		return _originalSource.GetPosition(_position, relativeTo);
	}
}
