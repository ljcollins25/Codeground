using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class InfoBarAutomationPeer : FrameworkElementAutomationPeer
{
	public InfoBarAutomationPeer(InfoBar owner)
		: base(owner)
	{
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.StatusBar;
	}

	protected override string GetClassNameCore()
	{
		return "InfoBar";
	}

	internal void RaiseOpenedEvent(InfoBarSeverity severity, string displayString)
	{
		RaiseNotificationEvent(AutomationNotificationKind.Other, GetProcessingForSeverity(severity), displayString, "InfoBarOpenedActivityId");
	}

	internal void RaiseClosedEvent(InfoBarSeverity severity, string displayString)
	{
		RaiseNotificationEvent(AutomationNotificationKind.Other, GetProcessingForSeverity(severity), displayString, "InfoBarClosedActivityId");
	}

	private AutomationNotificationProcessing GetProcessingForSeverity(InfoBarSeverity severity)
	{
		AutomationNotificationProcessing result = AutomationNotificationProcessing.CurrentThenMostRecent;
		if (severity == InfoBarSeverity.Error || severity == InfoBarSeverity.Warning)
		{
			result = AutomationNotificationProcessing.ImportantAll;
		}
		return result;
	}

	private InfoBar GetInfoBar()
	{
		UIElement owner = base.Owner;
		return (InfoBar)owner;
	}
}
