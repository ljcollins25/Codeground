using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Controls;

public class DropDownButtonAutomationPeer : ButtonAutomationPeer, IExpandCollapseProvider
{
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			DropDownButton impl = GetImpl();
			if (impl == null || !impl.IsFlyoutOpen())
			{
				return ExpandCollapseState.Collapsed;
			}
			return ExpandCollapseState.Expanded;
		}
	}

	public DropDownButtonAutomationPeer(DropDownButton owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "DropDownButton";
	}

	private DropDownButton GetImpl()
	{
		return base.Owner as DropDownButton;
	}

	public void Expand()
	{
		GetImpl()?.OpenFlyout();
	}

	public void Collapse()
	{
		GetImpl()?.CloseFlyout();
	}
}
