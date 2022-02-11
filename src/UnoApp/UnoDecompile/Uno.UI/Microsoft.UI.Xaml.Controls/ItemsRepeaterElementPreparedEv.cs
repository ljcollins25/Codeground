using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class ItemsRepeaterElementPreparedEventArgs
{
	public UIElement Element { get; private set; }

	public int Index { get; private set; }

	internal ItemsRepeaterElementPreparedEventArgs(UIElement element, int index)
	{
		Update(element, index);
	}

	public void Update(UIElement element, int index)
	{
		Element = element;
		Index = index;
	}
}
