using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class GridViewHeaderItemAutomationPeer : ListViewBaseHeaderItemAutomationPeer
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GridViewHeaderItemAutomationPeer(GridViewHeaderItem owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.GridViewHeaderItemAutomationPeer", "GridViewHeaderItemAutomationPeer.GridViewHeaderItemAutomationPeer(GridViewHeaderItem owner)");
	}
}
