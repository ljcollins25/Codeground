using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class ImageAutomationPeer : FrameworkElementAutomationPeer
{
	public ImageAutomationPeer(Image owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "Image";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Image;
	}
}
