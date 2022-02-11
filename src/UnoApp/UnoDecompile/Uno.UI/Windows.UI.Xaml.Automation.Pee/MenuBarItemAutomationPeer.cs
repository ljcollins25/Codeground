using System;
using Uno;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class MenuBarItemAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider, IInvokeProvider
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			throw new NotImplementedException("The member ExpandCollapseState MenuBarItemAutomationPeer.ExpandCollapseState is not implemented in Uno.");
		}
	}

	private MenuBarItem MenuBarItemOwner => base.Owner as MenuBarItem;

	public MenuBarItemAutomationPeer(MenuBarItem owner)
		: base(owner)
	{
	}

	public void Invoke()
	{
		MenuBarItemOwner?.Invoke();
	}

	public void Expand()
	{
		MenuBarItemOwner?.ShowMenuFlyout();
	}

	public void Collapse()
	{
		MenuBarItemOwner?.CloseMenuFlyout();
	}
}
