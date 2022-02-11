using System;
using Uno;
using Uno.Collections;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls.Primitives;

public class LayoutInformation
{
	private static readonly UnsafeWeakAttachedDictionary<object, string> _layoutProperties = new UnsafeWeakAttachedDictionary<object, string>();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static UIElement GetLayoutExceptionElement(object dispatcher)
	{
		throw new NotImplementedException("The member UIElement LayoutInformation.GetLayoutExceptionElement(object dispatcher) is not implemented in Uno.");
	}

	public static Size GetAvailableSize(UIElement element)
	{
		return element.LastAvailableSize;
	}

	internal static Size GetAvailableSize(object view)
	{
		if (!(view is IUIElement iUIElement))
		{
			return _layoutProperties.GetValue(view, "availablesize", () => default(Size));
		}
		return iUIElement.LastAvailableSize;
	}

	internal static void SetAvailableSize(object view, Size value)
	{
		if (view is IUIElement iUIElement)
		{
			iUIElement.LastAvailableSize = value;
		}
		else
		{
			_layoutProperties.SetValue(view, "availablesize", value);
		}
	}

	public static Rect GetLayoutSlot(FrameworkElement element)
	{
		return element.LayoutSlot;
	}

	internal static Rect GetLayoutSlot(object view)
	{
		if (!(view is IUIElement iUIElement))
		{
			return _layoutProperties.GetValue(view, "layoutslot", () => default(Rect));
		}
		return iUIElement.LayoutSlot;
	}

	internal static void SetLayoutSlot(object view, Rect value)
	{
		if (view is IUIElement iUIElement)
		{
			iUIElement.LayoutSlot = value;
		}
		else
		{
			_layoutProperties.SetValue(view, "layoutslot", value);
		}
	}

	internal static Size GetDesiredSize(UIElement element)
	{
		return element.DesiredSize;
	}

	internal static Size GetDesiredSize(object view)
	{
		if (view is IUIElement iUIElement)
		{
			return iUIElement.DesiredSize;
		}
		return _layoutProperties.GetValue(view, "desiredSize", () => default(Size));
	}

	internal static void SetDesiredSize(object view, Size desiredSize)
	{
		if (view is IUIElement iUIElement)
		{
			iUIElement.DesiredSize = desiredSize;
			return;
		}
		_layoutProperties.GetValue(view, "desiredSize", () => default(Size));
	}
}
