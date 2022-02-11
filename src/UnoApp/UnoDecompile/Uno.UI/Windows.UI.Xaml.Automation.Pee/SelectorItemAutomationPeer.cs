using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class SelectorItemAutomationPeer : ItemAutomationPeer, ISelectionItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSelected
	{
		get
		{
			throw new NotImplementedException("The member bool SelectorItemAutomationPeer.IsSelected is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple SelectionContainer
	{
		get
		{
			throw new NotImplementedException("The member IRawElementProviderSimple SelectorItemAutomationPeer.SelectionContainer is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SelectorItemAutomationPeer(object item, SelectorAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SelectorItemAutomationPeer", "SelectorItemAutomationPeer.SelectorItemAutomationPeer(object item, SelectorAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void AddToSelection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SelectorItemAutomationPeer", "void SelectorItemAutomationPeer.AddToSelection()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RemoveFromSelection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SelectorItemAutomationPeer", "void SelectorItemAutomationPeer.RemoveFromSelection()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Select()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SelectorItemAutomationPeer", "void SelectorItemAutomationPeer.Select()");
	}
}
