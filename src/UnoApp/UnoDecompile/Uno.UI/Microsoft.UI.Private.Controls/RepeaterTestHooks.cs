using System;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.UI.Private.Controls;

internal class RepeaterTestHooks
{
	public static event EventHandler BuildTreeCompleted;

	public static void NotifyBuildTreeCompleted()
	{
		RepeaterTestHooks.BuildTreeCompleted?.Invoke(null, null);
	}

	public static int GetElementFactoryElementIndex(object getArgs)
	{
		ElementFactoryGetArgs elementFactoryGetArgs = getArgs as ElementFactoryGetArgs;
		return elementFactoryGetArgs.Index;
	}

	public static object CreateRepeaterElementFactoryGetArgs()
	{
		return new ElementFactoryGetArgs();
	}

	public static object CreateRepeaterElementFactoryRecycleArgs()
	{
		return new ElementFactoryRecycleArgs();
	}

	public static string GetLayoutId(object layout)
	{
		if (layout is Layout layout2)
		{
			return layout2.LayoutId;
		}
		return "";
	}

	public static void SetLayoutId(object layout, string id)
	{
		if (layout is Layout layout2)
		{
			layout2.LayoutId = id;
		}
	}
}
