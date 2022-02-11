namespace Microsoft.UI.Xaml.Controls;

public sealed class TabViewTabDroppedOutsideEventArgs
{
	public object Item { get; }

	public TabViewItem Tab { get; }

	internal TabViewTabDroppedOutsideEventArgs(object item, TabViewItem tab)
	{
		Item = item;
		Tab = tab;
	}
}
