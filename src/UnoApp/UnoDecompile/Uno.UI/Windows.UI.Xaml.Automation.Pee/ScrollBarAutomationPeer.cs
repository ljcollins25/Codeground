using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ScrollBarAutomationPeer : RangeBaseAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ScrollBarAutomationPeer(ScrollBar owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ScrollBarAutomationPeer", "ScrollBarAutomationPeer.ScrollBarAutomationPeer(ScrollBar owner)");
	}
}
