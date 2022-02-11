using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls;

public class TreeViewSelectionChangedEventArgs
{
	public IList<object> AddedItems { get; }

	public IList<object> RemovedItems { get; }

	internal TreeViewSelectionChangedEventArgs(IList<object> addedItems, IList<object> removedItems)
	{
		AddedItems = addedItems;
		RemovedItems = removedItems;
	}
}
