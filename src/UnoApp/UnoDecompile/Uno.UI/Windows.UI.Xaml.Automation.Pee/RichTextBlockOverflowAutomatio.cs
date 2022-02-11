using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class RichTextBlockOverflowAutomationPeer : FrameworkElementAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RichTextBlockOverflowAutomationPeer(RichTextBlockOverflow owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.RichTextBlockOverflowAutomationPeer", "RichTextBlockOverflowAutomationPeer.RichTextBlockOverflowAutomationPeer(RichTextBlockOverflow owner)");
	}
}
