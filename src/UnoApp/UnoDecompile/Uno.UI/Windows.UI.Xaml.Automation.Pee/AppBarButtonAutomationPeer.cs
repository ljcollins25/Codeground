using DirectUI;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class AppBarButtonAutomationPeer : ButtonAutomationPeer, IExpandCollapseProvider
{
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			bool flag = false;
			AppBarButton owningAppBarButton = GetOwningAppBarButton();
			CascadingMenuHelper menuHelper = owningAppBarButton.MenuHelper;
			if (menuHelper != null)
			{
				flag = ((ISubMenuOwner)owningAppBarButton).IsSubMenuOpen;
			}
			if (!flag)
			{
				return ExpandCollapseState.Collapsed;
			}
			return ExpandCollapseState.Expanded;
		}
	}

	public AppBarButtonAutomationPeer(AppBarButton owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		AppBarButton owningAppBarButton = GetOwningAppBarButton();
		object result = null;
		if (patternInterface == PatternInterface.ExpandCollapse)
		{
			CascadingMenuHelper menuHelper = owningAppBarButton.MenuHelper;
			if (menuHelper != null)
			{
				result = this;
			}
		}
		else
		{
			result = base.GetPatternCore(patternInterface);
		}
		return result;
	}

	protected override string GetClassNameCore()
	{
		return "AppBarButton";
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrWhiteSpace(text))
		{
			AppBarButton owningAppBarButton = GetOwningAppBarButton();
			text = owningAppBarButton.Label;
		}
		return text;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_AP_APPBAR_BUTTON");
	}

	protected override string GetAcceleratorKeyCore()
	{
		string text = base.GetAcceleratorKeyCore();
		if (!string.IsNullOrWhiteSpace(text))
		{
			AppBarButton owningAppBarButton = GetOwningAppBarButton();
			text = owningAppBarButton.KeyboardAcceleratorTextOverride?.Trim();
		}
		return text;
	}

	public void Collapse()
	{
		AppBarButton owningAppBarButton = GetOwningAppBarButton();
		owningAppBarButton.MenuHelper?.CloseSubMenu();
	}

	public void Expand()
	{
		AppBarButton owningAppBarButton = GetOwningAppBarButton();
		owningAppBarButton.MenuHelper?.OpenSubMenu();
	}

	public void RaiseExpandCollapseAutomationEvent(bool isOpen)
	{
	}

	private AppBarButton GetOwningAppBarButton()
	{
		return base.Owner as AppBarButton;
	}
}
