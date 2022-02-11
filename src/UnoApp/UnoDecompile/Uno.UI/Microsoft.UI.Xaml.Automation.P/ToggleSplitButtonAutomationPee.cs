using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class ToggleSplitButtonAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider, IToggleProvider
{
	private readonly ToggleSplitButton _owner;

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			ExpandCollapseState result = ExpandCollapseState.Collapsed;
			ToggleSplitButton impl = GetImpl();
			if (impl != null && impl.IsFlyoutOpen)
			{
				result = ExpandCollapseState.Expanded;
			}
			return result;
		}
	}

	public ToggleState ToggleState
	{
		get
		{
			ToggleState result = ToggleState.Off;
			ToggleSplitButton impl = GetImpl();
			if (impl != null && impl.IsChecked)
			{
				result = ToggleState.On;
			}
			return result;
		}
	}

	public ToggleSplitButtonAutomationPeer(ToggleSplitButton owner)
		: base(owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse || patternInterface == PatternInterface.Toggle)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "ToggleSplitButton";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.SplitButton;
	}

	private ToggleSplitButton GetImpl()
	{
		return _owner;
	}

	public void Expand()
	{
		GetImpl()?.OpenFlyout();
	}

	public void Collapse()
	{
		GetImpl()?.CloseFlyout();
	}

	public void Toggle()
	{
		GetImpl()?.Toggle();
	}
}
