using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ItemsControlAutomationPeer : FrameworkElementAutomationPeer, IItemContainerProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemsControlAutomationPeer(ItemsControl owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ItemsControlAutomationPeer", "ItemsControlAutomationPeer.ItemsControlAutomationPeer(ItemsControl owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ItemAutomationPeer CreateItemAutomationPeer(object item)
	{
		throw new NotImplementedException("The member ItemAutomationPeer ItemsControlAutomationPeer.CreateItemAutomationPeer(object item) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual ItemAutomationPeer OnCreateItemAutomationPeer(object item)
	{
		throw new NotImplementedException("The member ItemAutomationPeer ItemsControlAutomationPeer.OnCreateItemAutomationPeer(object item) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple FindItemByProperty(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, object value)
	{
		throw new NotImplementedException("The member IRawElementProviderSimple ItemsControlAutomationPeer.FindItemByProperty(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, object value) is not implemented in Uno.");
	}

	public ItemsControlAutomationPeer(FrameworkElement e)
	{
		throw new NotImplementedException();
	}

	public ItemsControlAutomationPeer(object e)
	{
		throw new NotImplementedException();
	}
}
