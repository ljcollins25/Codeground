using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ListViewHeaderItemAutomationPeer : ListViewBaseHeaderItemAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListViewHeaderItemAutomationPeer(ListViewHeaderItem owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListViewHeaderItemAutomationPeer", "ListViewHeaderItemAutomationPeer.ListViewHeaderItemAutomationPeer(ListViewHeaderItem owner)");
	}
}
