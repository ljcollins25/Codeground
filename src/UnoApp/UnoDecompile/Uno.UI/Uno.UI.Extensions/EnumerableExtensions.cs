using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Extensions;

public static class EnumerableExtensions
{
	public static List<TResult> SelectToList<TResult>(this UIElementCollection source, Func<UIElement, TResult> selector)
	{
		List<TResult> list = new List<TResult>(source.Count);
		foreach (UIElement item in source)
		{
			list.Add(selector(item));
		}
		return list;
	}
}
