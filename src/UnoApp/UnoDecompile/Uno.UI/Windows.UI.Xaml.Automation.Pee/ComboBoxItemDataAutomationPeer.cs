using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ComboBoxItemDataAutomationPeer : SelectorItemAutomationPeer, IScrollItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ComboBoxItemDataAutomationPeer(object item, ComboBoxAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxItemDataAutomationPeer", "ComboBoxItemDataAutomationPeer.ComboBoxItemDataAutomationPeer(object item, ComboBoxAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ComboBoxItemDataAutomationPeer", "void ComboBoxItemDataAutomationPeer.ScrollIntoView()");
	}
}
