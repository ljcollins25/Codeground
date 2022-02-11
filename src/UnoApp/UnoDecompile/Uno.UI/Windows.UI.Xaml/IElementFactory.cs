using Uno;

namespace Windows.UI.Xaml;

[NotImplemented]
public interface IElementFactory
{
	UIElement GetElement(ElementFactoryGetArgs args);

	void RecycleElement(ElementFactoryRecycleArgs args);
}
