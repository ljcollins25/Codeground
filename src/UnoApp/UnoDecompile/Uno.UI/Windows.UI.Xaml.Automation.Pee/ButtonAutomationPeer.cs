using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ButtonAutomationPeer : ButtonBaseAutomationPeer, IInvokeProvider
{
	public ButtonAutomationPeer(Button owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "Button";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Button;
	}

	public void Invoke()
	{
		if (IsEnabled())
		{
			(base.Owner as Button).AutomationPeerClick();
		}
	}
}
