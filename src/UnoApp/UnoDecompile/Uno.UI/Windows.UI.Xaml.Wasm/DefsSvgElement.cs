using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Wasm;

internal class DefsSvgElement : SvgElement
{
	public UIElementCollection Defs { get; }

	public DefsSvgElement()
		: base("defs")
	{
		Defs = new UIElementCollection(this);
	}
}
