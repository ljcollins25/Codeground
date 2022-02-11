using System;
using System.Collections.Generic;
using Uno;
using Uno.UI.Xaml.Core;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls.Primitives;

internal class PopupRoot : Panel
{
	internal enum PopupFilter
	{
		LightDismissOnly,
		LightDismissOrFlyout,
		All
	}

	protected override void OnChildrenChanged()
	{
		base.OnChildrenChanged();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = default(Size);
		foreach (UIElement child in base.Children)
		{
			if (child is PopupPanel)
			{
				result = MeasureElement(child, availableSize);
			}
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		foreach (UIElement child in base.Children)
		{
			if (child is PopupPanel)
			{
				ArrangeElement(child, new Rect(default(Point), finalSize));
			}
		}
		return finalSize;
	}

	[NotImplemented]
	public static Popup? GetOpenPopupForElement(UIElement uiElement)
	{
		return null;
	}

	[NotImplemented]
	internal Popup? GetTopmostPopup(PopupFilter filter)
	{
		return null;
	}

	[NotImplemented]
	internal void ClearWasOpenedDuringEngagementOnAllOpenPopups()
	{
	}

	[NotImplemented]
	internal static IList<DependencyObject> GetPopupChildrenOpenedDuringEngagement(DependencyObject element)
	{
		PopupRoot popupRootForElement = VisualTree.GetPopupRootForElement(element);
		if (popupRootForElement != null)
		{
			Popup[] openPopups = popupRootForElement.GetOpenPopups();
		}
		return new List<DependencyObject>();
	}

	[NotImplemented]
	internal Popup[] GetOpenPopups()
	{
		return Array.Empty<Popup>();
	}
}
