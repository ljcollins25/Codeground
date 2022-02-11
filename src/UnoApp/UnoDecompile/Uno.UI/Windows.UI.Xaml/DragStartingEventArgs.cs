using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml;

public class DragStartingEventArgs : RoutedEventArgs
{
	private readonly PointerRoutedEventArgs _pointer;

	public bool Cancel { get; set; }

	public DataPackage Data { get; } = new DataPackage();


	public DragUI DragUI { get; } = new DragUI();


	public DataPackageOperation AllowedOperations { get; set; } = DataPackageOperation.Copy | DataPackageOperation.Move | DataPackageOperation.Link;


	internal DragOperationDeferral? Deferral { get; private set; }

	internal DragStartingEventArgs(UIElement originalSource, PointerRoutedEventArgs pointer)
		: base(originalSource)
	{
		_pointer = pointer;
		base.CanBubbleNatively = false;
	}

	public Point GetPosition(UIElement relativeTo)
	{
		return _pointer.GetCurrentPoint(relativeTo).Position;
	}

	public DragOperationDeferral GetDeferral()
	{
		return Deferral ?? (Deferral = new DragOperationDeferral());
	}
}
