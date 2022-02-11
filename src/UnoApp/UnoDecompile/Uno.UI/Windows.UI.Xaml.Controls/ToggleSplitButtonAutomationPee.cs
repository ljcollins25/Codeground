using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Controls;

[Obsolete("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.ToggleSplitButton instead.")]
public class ToggleSplitButtonAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider, IToggleProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			throw new NotImplementedException("The member ExpandCollapseState ToggleSplitButtonAutomationPeer.ExpandCollapseState is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ToggleState ToggleState
	{
		get
		{
			throw new NotImplementedException("The member ToggleState ToggleSplitButtonAutomationPeer.ToggleState is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Collapse()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButtonAutomationPeer", "void ToggleSplitButtonAutomationPeer.Collapse()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Expand()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButtonAutomationPeer", "void ToggleSplitButtonAutomationPeer.Expand()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Toggle()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ToggleSplitButtonAutomationPeer", "void ToggleSplitButtonAutomationPeer.Toggle()");
	}

	public ToggleSplitButtonAutomationPeer(ToggleSplitButton owner)
		: base(owner)
	{
		throw new NotImplementedException("The Windows.UI.Xaml.Controls version of this control is not supported. Please use Microsoft.UI.Xaml.Controls.ToggleSplitButton instead.");
	}
}
