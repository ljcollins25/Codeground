using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ColorSpectrumAutomationPeer : FrameworkElementAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ColorSpectrumAutomationPeer(ColorSpectrum owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ColorSpectrumAutomationPeer", "ColorSpectrumAutomationPeer.ColorSpectrumAutomationPeer(ColorSpectrum owner)");
	}
}
