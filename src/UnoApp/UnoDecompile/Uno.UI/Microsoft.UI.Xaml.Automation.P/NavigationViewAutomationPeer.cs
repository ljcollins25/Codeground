using System;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class NavigationViewAutomationPeer : FrameworkElementAutomationPeer, ISelectionProvider
{
	bool ISelectionProvider.CanSelectMultiple => false;

	bool ISelectionProvider.IsSelectionRequired => false;

	public NavigationViewAutomationPeer(NavigationView owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.Selection)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	IRawElementProviderSimple[] ISelectionProvider.GetSelection()
	{
		if (base.Owner is NavigationView navigationView)
		{
			NavigationViewItem selectedContainer = navigationView.GetSelectedContainer();
			if (selectedContainer != null)
			{
				AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(selectedContainer);
				if (automationPeer != null)
				{
					return new IRawElementProviderSimple[1] { ProviderFromPeer(automationPeer) };
				}
			}
		}
		return Array.Empty<IRawElementProviderSimple>();
	}

	internal void RaiseSelectionChangedEvent(object oldSelection, object newSelecttion)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.SelectionPatternOnInvalidated) && base.Owner is NavigationView navigationView)
		{
			NavigationViewItem selectedContainer = navigationView.GetSelectedContainer();
			if (selectedContainer != null)
			{
				FrameworkElementAutomationPeer.CreatePeerForElement(selectedContainer)?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementSelected);
			}
		}
	}
}
