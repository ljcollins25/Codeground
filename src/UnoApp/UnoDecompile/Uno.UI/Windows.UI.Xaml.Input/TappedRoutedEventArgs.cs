using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public sealed class TappedRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly UIElement _originalSource;

	private readonly Point _position;

	public bool Handled { get; set; }

	public PointerDeviceType PointerDeviceType { get; }

	public TappedRoutedEventArgs()
	{
	}

	internal TappedRoutedEventArgs(UIElement originalSource, TappedEventArgs args)
		: base(originalSource)
	{
		_originalSource = originalSource;
		_position = args.Position;
		PointerDeviceType = args.PointerDeviceType;
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
