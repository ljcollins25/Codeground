using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class CheckBoxAutomationPeer : ToggleButtonAutomationPeer
{
	public CheckBoxAutomationPeer(CheckBox owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "CheckBox";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.CheckBox;
	}
}
