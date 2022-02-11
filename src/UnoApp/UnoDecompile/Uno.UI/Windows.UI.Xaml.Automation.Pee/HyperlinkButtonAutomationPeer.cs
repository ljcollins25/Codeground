using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class HyperlinkButtonAutomationPeer : ButtonBaseAutomationPeer, IInvokeProvider
{
	public HyperlinkButtonAutomationPeer(HyperlinkButton owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "Hyperlink";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Hyperlink;
	}

	public void Invoke()
	{
		if (IsEnabled())
		{
			(base.Owner as HyperlinkButton).AutomationPeerClick();
		}
	}
}
