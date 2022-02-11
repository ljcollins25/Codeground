using System;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers;

public static class MarkupHelper
{
	public static void SetXUid(object target, string uid)
	{
		if (target is IXUidProvider iXUidProvider)
		{
			iXUidProvider.Uid = uid;
		}
	}

	public static string GetXUid(object target)
	{
		if (!(target is IXUidProvider iXUidProvider))
		{
			return "";
		}
		return iXUidProvider.Uid;
	}

	public static void SetVisualStateLazy(VisualState target, Action builder)
	{
		target.LazyBuilder = builder;
	}

	public static void SetVisualTransitionLazy(VisualTransition target, Action builder)
	{
		target.LazyBuilder = builder;
	}
}
