using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class TreeViewListAutomationPeer : SelectorAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TreeViewListAutomationPeer(TreeViewList owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.TreeViewListAutomationPeer", "TreeViewListAutomationPeer.TreeViewListAutomationPeer(TreeViewList owner)");
	}
}
