using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

[NotImplemented]
public class SemanticZoomAutomationPeer : FrameworkElementAutomationPeer, IToggleProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ToggleState ToggleState
	{
		get
		{
			throw new NotImplementedException("The member ToggleState SemanticZoomAutomationPeer.ToggleState is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SemanticZoomAutomationPeer(SemanticZoom owner)
		: base(owner)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SemanticZoomAutomationPeer", "SemanticZoomAutomationPeer.SemanticZoomAutomationPeer(SemanticZoom owner)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Toggle()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.SemanticZoomAutomationPeer", "void SemanticZoomAutomationPeer.Toggle()");
	}
}
