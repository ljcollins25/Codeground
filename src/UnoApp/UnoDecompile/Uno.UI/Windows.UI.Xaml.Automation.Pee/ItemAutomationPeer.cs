using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ItemAutomationPeer : AutomationPeer, IVirtualizedItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Item
	{
		get
		{
			throw new NotImplementedException("The member object ItemAutomationPeer.Item is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemsControlAutomationPeer ItemsControlAutomationPeer
	{
		get
		{
			throw new NotImplementedException("The member ItemsControlAutomationPeer ItemAutomationPeer.ItemsControlAutomationPeer is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemAutomationPeer(object item, ItemsControlAutomationPeer parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ItemAutomationPeer", "ItemAutomationPeer.ItemAutomationPeer(object item, ItemsControlAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Realize()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ItemAutomationPeer", "void ItemAutomationPeer.Realize()");
	}
}
