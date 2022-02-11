using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class TextBlockAutomationPeer : FrameworkElementAutomationPeer
{
	public TextBlockAutomationPeer(TextBlock owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return base.GetClassNameCore();
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Text;
	}
}
