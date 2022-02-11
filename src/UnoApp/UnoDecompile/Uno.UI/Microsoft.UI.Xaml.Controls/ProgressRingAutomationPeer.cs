using Windows.UI.Xaml.Automation.Peers;

namespace Microsoft.UI.Xaml.Controls;

public class ProgressRingAutomationPeer : AutomationPeer
{
	private readonly ProgressRing _progressRing;

	public ProgressRingAutomationPeer(ProgressRing progressRing)
	{
		_progressRing = progressRing;
	}

	protected override string GetClassNameCore()
	{
		return "ProgressRing";
	}

	protected override string GetNameCore()
	{
		string nameCore = base.GetNameCore();
		ProgressRing progressRing = _progressRing;
		if (progressRing != null && progressRing.IsActive)
		{
			return "Busy" + nameCore;
		}
		return nameCore;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.ProgressBar;
	}
}
