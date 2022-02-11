using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ToggleSwitchAutomationPeer : FrameworkElementAutomationPeer, IToggleProvider
{
	public ToggleState ToggleState
	{
		get
		{
			if (!((ToggleSwitch)base.Owner).IsOn)
			{
				return ToggleState.Off;
			}
			return ToggleState.On;
		}
	}

	public ToggleSwitchAutomationPeer(ToggleSwitch owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "ToggleSwitch";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Button;
	}

	public void Toggle()
	{
		if (IsEnabled())
		{
			((ToggleSwitch)base.Owner).AutomationPeerToggle();
		}
	}

	internal void RaiseToggleStatePropertyChangedEvent(object pOldValue, object pNewValue)
	{
		ToggleState toggleState = ToggleButtonAutomationPeer.ConvertToToggleState(pOldValue);
		ToggleState toggleState2 = ToggleButtonAutomationPeer.ConvertToToggleState(pNewValue);
		if (toggleState != toggleState2)
		{
			RaisePropertyChangedEvent(TogglePatternIdentifiers.ToggleStateProperty, toggleState, toggleState2);
		}
	}
}
