using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class ItemsRepeaterElementIndexChangedEventArgs
{
	public UIElement Element { get; private set; }

	public int OldIndex { get; private set; }

	public int NewIndex { get; private set; }

	internal ItemsRepeaterElementIndexChangedEventArgs(UIElement element, int oldIndex, int newIndex)
	{
		Update(element, in oldIndex, in newIndex);
	}

	public void Update(UIElement element, in int oldIndex, in int newIndex)
	{
		Element = element;
		OldIndex = oldIndex;
		NewIndex = newIndex;
	}
}
