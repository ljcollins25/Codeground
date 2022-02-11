using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class ElementFactoryRecycleArgs
{
	public UIElement Parent { get; set; }

	public UIElement Element { get; set; }
}
