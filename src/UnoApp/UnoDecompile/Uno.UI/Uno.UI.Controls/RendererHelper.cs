using System;
using Uno.Collections;
using Windows.UI.Xaml;

namespace Uno.UI.Controls;

internal static class RendererHelper
{
	private static readonly WeakAttachedDictionary<DependencyObject, Type> _renderers = new WeakAttachedDictionary<DependencyObject, Type>();

	public static TRenderer GetRenderer<TElement, TRenderer>(this TElement element, Func<TRenderer> rendererFactory) where TElement : DependencyObject
	{
		return _renderers.GetValue(element, typeof(TRenderer), rendererFactory);
	}

	public static TRenderer ResetRenderer<TElement, TRenderer>(this TElement element, Func<TRenderer> rendererFactory) where TElement : DependencyObject
	{
		return _renderers.GetValue(element, typeof(TRenderer), rendererFactory);
	}
}
