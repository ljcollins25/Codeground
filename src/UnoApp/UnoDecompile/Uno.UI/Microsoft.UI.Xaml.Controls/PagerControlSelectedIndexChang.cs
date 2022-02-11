namespace Microsoft.UI.Xaml.Controls;

public class PagerControlSelectedIndexChangedEventArgs
{
	public int PreviousPageIndex { get; }

	public int NewPageIndex { get; }

	public PagerControlSelectedIndexChangedEventArgs(int previousIndex, int newIndex)
	{
		PreviousPageIndex = previousIndex;
		NewPageIndex = newIndex;
	}
}
