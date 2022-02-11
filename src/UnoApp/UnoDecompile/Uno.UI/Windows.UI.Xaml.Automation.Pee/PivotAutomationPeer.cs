using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class PivotAutomationPeer : ItemsControlAutomationPeer, ISelectionProvider, IScrollProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalScrollPercent
	{
		get
		{
			throw new NotImplementedException("The member double PivotAutomationPeer.HorizontalScrollPercent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalViewSize
	{
		get
		{
			throw new NotImplementedException("The member double PivotAutomationPeer.HorizontalViewSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool HorizontallyScrollable
	{
		get
		{
			throw new NotImplementedException("The member bool PivotAutomationPeer.HorizontallyScrollable is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalScrollPercent
	{
		get
		{
			throw new NotImplementedException("The member double PivotAutomationPeer.VerticalScrollPercent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalViewSize
	{
		get
		{
			throw new NotImplementedException("The member double PivotAutomationPeer.VerticalViewSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool VerticallyScrollable
	{
		get
		{
			throw new NotImplementedException("The member bool PivotAutomationPeer.VerticallyScrollable is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanSelectMultiple
	{
		get
		{
			throw new NotImplementedException("The member bool PivotAutomationPeer.CanSelectMultiple is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsSelectionRequired
	{
		get
		{
			throw new NotImplementedException("The member bool PivotAutomationPeer.IsSelectionRequired is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PivotAutomationPeer(Pivot owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotAutomationPeer", "PivotAutomationPeer.PivotAutomationPeer(Pivot owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple[] GetSelection()
	{
		throw new NotImplementedException("The member IRawElementProviderSimple[] PivotAutomationPeer.GetSelection() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotAutomationPeer", "void PivotAutomationPeer.Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetScrollPercent(double horizontalPercent, double verticalPercent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.PivotAutomationPeer", "void PivotAutomationPeer.SetScrollPercent(double horizontalPercent, double verticalPercent)");
	}
}
