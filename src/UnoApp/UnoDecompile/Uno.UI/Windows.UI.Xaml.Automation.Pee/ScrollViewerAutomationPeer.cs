using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class ScrollViewerAutomationPeer : FrameworkElementAutomationPeer, IScrollProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalScrollPercent
	{
		get
		{
			throw new NotImplementedException("The member double ScrollViewerAutomationPeer.HorizontalScrollPercent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalViewSize
	{
		get
		{
			throw new NotImplementedException("The member double ScrollViewerAutomationPeer.HorizontalViewSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool HorizontallyScrollable
	{
		get
		{
			throw new NotImplementedException("The member bool ScrollViewerAutomationPeer.HorizontallyScrollable is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalScrollPercent
	{
		get
		{
			throw new NotImplementedException("The member double ScrollViewerAutomationPeer.VerticalScrollPercent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalViewSize
	{
		get
		{
			throw new NotImplementedException("The member double ScrollViewerAutomationPeer.VerticalViewSize is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool VerticallyScrollable
	{
		get
		{
			throw new NotImplementedException("The member bool ScrollViewerAutomationPeer.VerticallyScrollable is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ScrollViewerAutomationPeer(ScrollViewer owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ScrollViewerAutomationPeer", "ScrollViewerAutomationPeer.ScrollViewerAutomationPeer(ScrollViewer owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ScrollViewerAutomationPeer", "void ScrollViewerAutomationPeer.Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetScrollPercent(double horizontalPercent, double verticalPercent)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ScrollViewerAutomationPeer", "void ScrollViewerAutomationPeer.SetScrollPercent(double horizontalPercent, double verticalPercent)");
	}
}
