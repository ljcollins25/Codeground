using System.Collections.Generic;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class CalendarScrollViewerAutomationPeer : ScrollViewerAutomationPeer
{
	public CalendarScrollViewerAutomationPeer(ScrollViewer owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "CalendarScrollViewer";
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		IList<AutomationPeer> result = null;
		UIElement owner = base.Owner;
		FrameworkElement frameworkElement = (FrameworkElement)owner;
		DependencyObject templatedParent = frameworkElement.TemplatedParent;
		if (templatedParent != null && templatedParent is CalendarView calendarView)
		{
			calendarView.GetActiveGeneratorHost(out var ppHost);
			CalendarPanel panel = ppHost.Panel;
			if (panel != null)
			{
				int num = -1;
				int num2 = -1;
				num = panel.FirstVisibleIndex;
				num2 = panel.LastVisibleIndex;
				if (num != -1 && num2 != -1)
				{
					List<AutomationPeer> list = new List<AutomationPeer>();
					for (int i = num; i <= num2; i++)
					{
						DependencyObject dependencyObject = panel.ContainerFromIndex(i);
						CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
						AutomationPeer automationPeer = calendarViewBaseItem.GetAutomationPeer();
						if (automationPeer != null)
						{
							list.Add(automationPeer);
						}
					}
					result = list;
				}
			}
		}
		return result;
	}
}
