using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ColorPickerSliderAutomationPeer : SliderAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorPickerSliderAutomationPeer(ColorPickerSlider owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ColorPickerSliderAutomationPeer", "ColorPickerSliderAutomationPeer.ColorPickerSliderAutomationPeer(ColorPickerSlider owner)");
	}
}
