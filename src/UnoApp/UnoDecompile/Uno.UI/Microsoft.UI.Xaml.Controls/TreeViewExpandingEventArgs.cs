namespace Microsoft.UI.Xaml.Controls;

public class TreeViewExpandingEventArgs
{
	public TreeViewNode Node { get; }

	public object Item => Node.Content;

	internal TreeViewExpandingEventArgs(TreeViewNode node)
	{
		Node = node;
	}
}
