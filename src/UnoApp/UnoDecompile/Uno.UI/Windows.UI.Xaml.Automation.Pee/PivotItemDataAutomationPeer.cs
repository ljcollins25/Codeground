using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class PivotItemDataAutomationPeer : ItemAutomationPeer, IScrollItemProvider, ISelectionItemProvider, IVirtualizedItemProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSelected
	{
		get
		{
			throw new NotImplementedException("The member bool PivotItemDataAutomationPeer.IsSelected is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple SelectionContainer
	{
		get
		{
			throw new NotImplementedException("The member IRawElementProviderSimple PivotItemDataAutomationPeer.SelectionContainer is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PivotItemDataAutomationPeer(object item, PivotAutomationPeer parent)
		: base(item, parent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "PivotItemDataAutomationPeer.PivotItemDataAutomationPeer(object item, PivotAutomationPeer parent)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollIntoView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "void PivotItemDataAutomationPeer.ScrollIntoView()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void AddToSelection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "void PivotItemDataAutomationPeer.AddToSelection()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RemoveFromSelection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "void PivotItemDataAutomationPeer.RemoveFromSelection()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Select()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "void PivotItemDataAutomationPeer.Select()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public new void Realize()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotItemDataAutomationPeer", "void PivotItemDataAutomationPeer.Realize()");
	}
}
