using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class SelectorAutomationPeer : ItemsControlAutomationPeer, ISelectionProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanSelectMultiple
	{
		get
		{
			throw new NotImplementedException("The member bool SelectorAutomationPeer.CanSelectMultiple is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSelectionRequired
	{
		get
		{
			throw new NotImplementedException("The member bool SelectorAutomationPeer.IsSelectionRequired is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SelectorAutomationPeer(Selector owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SelectorAutomationPeer", "SelectorAutomationPeer.SelectorAutomationPeer(Selector owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple[] GetSelection()
	{
		throw new NotImplementedException("The member IRawElementProviderSimple[] SelectorAutomationPeer.GetSelection() is not implemented in Uno.");
	}

	public SelectorAutomationPeer(object o)
		: base(null)
	{
		throw new NotImplementedException();
	}
}
