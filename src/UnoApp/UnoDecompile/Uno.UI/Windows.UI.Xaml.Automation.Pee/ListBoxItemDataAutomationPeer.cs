using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ListBoxItemDataAutomationPeer : SelectorItemAutomationPeer, IScrollItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ListBoxItemDataAutomationPeer(object item, ListBoxAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListBoxItemDataAutomationPeer", "ListBoxItemDataAutomationPeer.ListBoxItemDataAutomationPeer(object item, ListBoxAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ListBoxItemDataAutomationPeer", "void ListBoxItemDataAutomationPeer.ScrollIntoView()");
	}
}
