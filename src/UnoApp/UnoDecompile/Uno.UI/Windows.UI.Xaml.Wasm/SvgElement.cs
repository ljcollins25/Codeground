namespace Windows.UI.Xaml.Wasm;

public class SvgElement : UIElement
{
	public SvgElement(string svgTag)
		: base(svgTag, isSvg: true)
	{
	}
}
