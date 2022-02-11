using System;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class TabViewAutomationPeer : FrameworkElementAutomationPeer, ISelectionProvider
{
	bool ISelectionProvider.CanSelectMultiple => false;

	bool ISelectionProvider.IsSelectionRequired => true;

	public TabViewAutomationPeer(TabView owner)
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

	protected override string GetClassNameCore()
	{
		return "TabView";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Tab;
	}

	IRawElementProviderSimple[] ISelectionProvider.GetSelection()
	{
		if (base.Owner is TabView tabView && tabView.ContainerFromIndex(tabView.SelectedIndex) is TabViewItem element)
		{
			AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(element);
			if (automationPeer != null)
			{
				return new IRawElementProviderSimple[1] { ProviderFromPeer(automationPeer) };
			}
		}
		return Array.Empty<IRawElementProviderSimple>();
	}
}
