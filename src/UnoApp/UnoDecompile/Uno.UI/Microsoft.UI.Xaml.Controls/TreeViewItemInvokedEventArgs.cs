namespace Microsoft.UI.Xaml.Controls;

public class TreeViewItemInvokedEventArgs
{
	public bool Handled { get; set; }

	public object InvokedItem { get; }

	internal TreeViewItemInvokedEventArgs(object invokedItem)
	{
		InvokedItem = invokedItem;
	}
}
