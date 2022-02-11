using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public sealed class TabViewTabDragStartingEventArgs
{
	private readonly DragItemsStartingEventArgs _args;

	public DataPackage Data => _args.Data;

	public object Item { get; }

	public TabViewItem Tab { get; }

	public bool Cancel
	{
		get
		{
			return _args.Cancel;
		}
		set
		{
			_args.Cancel = value;
		}
	}

	internal TabViewTabDragStartingEventArgs(DragItemsStartingEventArgs args, object item, TabViewItem tab)
	{
		_args = args;
		Item = item;
		Tab = tab;
	}
}
