namespace Microsoft.UI.Xaml.Controls;

public class TreeViewCollapsedEventArgs
{
	public TreeViewNode Node { get; }

	public object Item => Node.Content;

	internal TreeViewCollapsedEventArgs(TreeViewNode node)
	{
		Node = node;
	}
}
