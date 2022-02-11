using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ListViewItemDataAutomationPeer : SelectorItemAutomationPeer, IScrollItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListViewItemDataAutomationPeer(object item, ListViewBaseAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListViewItemDataAutomationPeer", "ListViewItemDataAutomationPeer.ListViewItemDataAutomationPeer(object item, ListViewBaseAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListViewItemDataAutomationPeer", "void ListViewItemDataAutomationPeer.ScrollIntoView()");
	}
}
