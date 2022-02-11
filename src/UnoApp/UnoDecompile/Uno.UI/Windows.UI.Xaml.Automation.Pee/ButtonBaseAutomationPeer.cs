using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class ButtonBaseAutomationPeer : FrameworkElementAutomationPeer
{
	protected ButtonBaseAutomationPeer(ButtonBase owner)
		: base(owner)
	{
	}

	protected ButtonBaseAutomationPeer(ButtonBaseAutomationPeer buttonBase)
		: base(buttonBase)
	{
	}

	protected override bool IsControlElementCore()
	{
		return true;
	}
}
