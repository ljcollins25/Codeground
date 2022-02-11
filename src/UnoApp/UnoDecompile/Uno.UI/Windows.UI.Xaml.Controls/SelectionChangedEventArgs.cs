using System.Collections.Generic;

namespace Windows.UI.Xaml.Controls;

public class SelectionChangedEventArgs : RoutedEventArgs
{
	public IList<object> RemovedItems { get; private set; }

	public IList<object> AddedItems { get; private set; }

	public SelectionChangedEventArgs(IList<object> removedItems, IList<object> addedItems)
	{
		RemovedItems = removedItems;
		AddedItems = addedItems;
	}

	internal SelectionChangedEventArgs(object originalSource, IList<object> removedItems, IList<object> addedItems)
		: base(originalSource)
	{
		RemovedItems = removedItems;
		AddedItems = addedItems;
	}
}
