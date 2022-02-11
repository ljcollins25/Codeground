using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class TreeViewDragItemsCompletedEventArgs
{
	private readonly DragItemsCompletedEventArgs _dragItemsCompletedEventArgs;

	public DataPackageOperation DropResult => _dragItemsCompletedEventArgs.DropResult;

	public IReadOnlyList<object> Items => _dragItemsCompletedEventArgs.Items;

	public object NewParentItem { get; }

	internal TreeViewDragItemsCompletedEventArgs(DragItemsCompletedEventArgs args, object newParentItem)
	{
		_dragItemsCompletedEventArgs = args;
		NewParentItem = newParentItem;
	}
}
