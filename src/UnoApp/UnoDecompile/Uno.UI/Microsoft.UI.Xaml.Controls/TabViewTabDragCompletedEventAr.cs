using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public sealed class TabViewTabDragCompletedEventArgs
{
	private readonly DragItemsCompletedEventArgs _args;

	public DataPackageOperation DropResult => _args.DropResult;

	public object Item { get; }

	public TabViewItem Tab { get; }

	internal TabViewTabDragCompletedEventArgs(DragItemsCompletedEventArgs args, object item, TabViewItem tab)
	{
		_args = args;
		Item = item;
		Tab = tab;
	}
}
