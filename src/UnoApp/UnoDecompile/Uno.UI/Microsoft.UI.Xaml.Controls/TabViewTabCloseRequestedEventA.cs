namespace Microsoft.UI.Xaml.Controls;

public sealed class TabViewTabCloseRequestedEventArgs
{
	public object Item { get; }

	public TabViewItem Tab { get; }

	internal TabViewTabCloseRequestedEventArgs(object item, TabViewItem tab)
	{
		Item = item;
		Tab = tab;
	}
}
