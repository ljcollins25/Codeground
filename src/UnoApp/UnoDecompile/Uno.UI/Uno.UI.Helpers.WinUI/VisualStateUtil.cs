using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Helpers.WinUI;

internal class VisualStateUtil
{
	public static VisualStateGroup GetVisualStateGroup(FrameworkElement control, string groupName)
	{
		VisualStateGroup result = null;
		IList<VisualStateGroup> visualStateGroups = VisualStateManager.GetVisualStateGroups(control);
		if (visualStateGroups == null && control is ContentControl obj)
		{
			visualStateGroups = VisualStateManager.GetVisualStateGroups(obj);
		}
		if (visualStateGroups == null)
		{
			return result;
		}
		foreach (VisualStateGroup item in visualStateGroups)
		{
			if (item.Name == groupName)
			{
				return item;
			}
		}
		return result;
	}

	public static bool VisualStateGroupExists(FrameworkElement control, string groupName)
	{
		return GetVisualStateGroup(control, groupName) != null;
	}

	public static void GoToStateIfGroupExists(Control control, string groupName, string stateName, bool useTransitions)
	{
		VisualStateGroup visualStateGroup = GetVisualStateGroup(control, groupName);
		if (visualStateGroup != null)
		{
			VisualStateManager.GoToState(control, stateName, useTransitions);
		}
	}
}
