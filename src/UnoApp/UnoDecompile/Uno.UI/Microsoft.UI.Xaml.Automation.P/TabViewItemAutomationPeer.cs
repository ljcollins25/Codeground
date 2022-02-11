using Microsoft.UI.Xaml.Controls;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class TabViewItemAutomationPeer : ListViewItemAutomationPeer, ISelectionItemProvider
{
	public bool IsSelected
	{
		get
		{
			if (base.Owner is TabViewItem tabViewItem)
			{
				return tabViewItem.IsSelected;
			}
			return false;
		}
	}

	public IRawElementProviderSimple SelectionContainer
	{
		get
		{
			TabView parentTabView = GetParentTabView();
			if (parentTabView != null)
			{
				AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(parentTabView);
				if (automationPeer != null)
				{
					return ProviderFromPeer(automationPeer);
				}
			}
			return null;
		}
	}

	public TabViewItemAutomationPeer(TabViewItem owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.SelectionItem)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "TabViewItem";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.TabItem;
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrEmpty(text) && base.Owner is TabViewItem tabViewItem)
		{
			text = SharedHelpers.TryGetStringRepresentationFromObject(tabViewItem.Header);
		}
		return text;
	}

	public void AddToSelection()
	{
		Select();
	}

	public void RemoveFromSelection()
	{
	}

	public void Select()
	{
		if (base.Owner is TabViewItem tabViewItem)
		{
			tabViewItem.IsSelected = true;
		}
	}

	private TabView GetParentTabView()
	{
		TabView result = null;
		if (base.Owner is TabViewItem tabViewItem)
		{
			result = tabViewItem.GetParentTabView();
		}
		return result;
	}
}
