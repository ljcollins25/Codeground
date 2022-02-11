using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class ItemsRepeaterElementClearingEventArgs
{
	public UIElement Element { get; private set; }

	internal ItemsRepeaterElementClearingEventArgs(UIElement element)
	{
		Update(element);
	}

	public void Update(UIElement element)
	{
		Element = element;
	}
}
