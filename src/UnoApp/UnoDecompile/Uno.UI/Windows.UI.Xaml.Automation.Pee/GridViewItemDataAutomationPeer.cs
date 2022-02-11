using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class GridViewItemDataAutomationPeer : SelectorItemAutomationPeer, IScrollItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public GridViewItemDataAutomationPeer(object item, GridViewAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.GridViewItemDataAutomationPeer", "GridViewItemDataAutomationPeer.GridViewItemDataAutomationPeer(object item, GridViewAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.GridViewItemDataAutomationPeer", "void GridViewItemDataAutomationPeer.ScrollIntoView()");
	}
}
