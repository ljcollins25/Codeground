using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class TreeViewDragItemsStartingEventArgs
{
	private readonly DragItemsStartingEventArgs _dragItemsStartingEventArgs;

	public bool Cancel { get; set; }

	public DataPackage Data => _dragItemsStartingEventArgs.Data;

	public IList<object> Items => _dragItemsStartingEventArgs.Items;

	public TreeViewDragItemsStartingEventArgs(DragItemsStartingEventArgs args)
	{
		_dragItemsStartingEventArgs = args;
	}
}
