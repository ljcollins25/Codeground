using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;

namespace Windows.UI.Xaml.Controls;

public class DragItemsCompletedEventArgs
{
	public DataPackageOperation DropResult { get; }

	public IReadOnlyList<object> Items { get; }

	internal DragItemsCompletedEventArgs(DropCompletedEventArgs inner, IReadOnlyList<object> items)
	{
		DropResult = inner.DropResult;
		Items = items;
	}
}
