using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;

namespace Windows.UI.Xaml;

public class DropCompletedEventArgs : RoutedEventArgs
{
	internal CoreDragInfo Info { get; }

	public DataPackageOperation DropResult { get; }

	internal DropCompletedEventArgs(UIElement originalSource, CoreDragInfo info, DataPackageOperation result)
		: base(originalSource)
	{
		Info = info;
		DropResult = result;
		base.CanBubbleNatively = false;
	}
}
