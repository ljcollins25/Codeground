using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class RepeaterAutomationPeer : FrameworkElementAutomationPeer
{
	public RepeaterAutomationPeer(ItemsRepeater owner)
		: base(owner)
	{
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		ItemsRepeater repeater = base.Owner as ItemsRepeater;
		IList<AutomationPeer> childrenCore = base.GetChildrenCore();
		int count = childrenCore.Count;
		List<KeyValuePair<int, AutomationPeer>> list = new List<KeyValuePair<int, AutomationPeer>>(count);
		for (int i = 0; i < count; i++)
		{
			AutomationPeer automationPeer = childrenCore[i];
			UIElement element = GetElement(automationPeer, repeater);
			if (element != null)
			{
				VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(element);
				if (virtualizationInfo.IsRealized)
				{
					list.Add(new KeyValuePair<int, AutomationPeer>(virtualizationInfo.Index, automationPeer));
				}
			}
		}
		list.Sort((KeyValuePair<int, AutomationPeer> lhs, KeyValuePair<int, AutomationPeer> rhs) => lhs.Key - rhs.Key);
		List<AutomationPeer> list2 = new List<AutomationPeer>(list.Count);
		foreach (KeyValuePair<int, AutomationPeer> item in list)
		{
			list2.Add(item.Value);
		}
		return list2;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Group;
	}

	private UIElement GetElement(AutomationPeer childPeer, ItemsRepeater repeater)
	{
		DependencyObject dependencyObject = (childPeer as FrameworkElementAutomationPeer).Owner;
		DependencyObject parent = CachedVisualTreeHelpers.GetParent(dependencyObject);
		while (parent != null && parent as ItemsRepeater != repeater)
		{
			dependencyObject = parent;
			parent = CachedVisualTreeHelpers.GetParent(dependencyObject);
		}
		return dependencyObject as UIElement;
	}
}
