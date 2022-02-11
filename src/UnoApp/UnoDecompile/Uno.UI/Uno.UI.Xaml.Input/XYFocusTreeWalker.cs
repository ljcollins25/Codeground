using System.Collections.Generic;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal static class XYFocusTreeWalker
{
	internal const int InitialCandidateListCapacity = 50;

	internal static List<XYFocus.XYFocusParameters> FindElements(DependencyObject? startRoot, DependencyObject? currentElement, DependencyObject? activeScroller, bool ignoreClipping, bool shouldConsiderXYFocusKeyboardNavigation)
	{
		bool flag = activeScroller != null;
		List<XYFocus.XYFocusParameters> list = new List<XYFocus.XYFocusParameters>(50);
		DependencyObject[] focusChildren = FocusProperties.GetFocusChildren(startRoot);
		if (focusChildren == null)
		{
			return list;
		}
		int num = focusChildren.Length;
		for (uint num2 = 0u; num2 < num; num2++)
		{
			DependencyObject dependencyObject = focusChildren[num2];
			if (dependencyObject == null)
			{
				continue;
			}
			bool flag2 = FocusProperties.IsFocusEngagementEnabled(dependencyObject) && !FocusProperties.IsFocusEngaged(dependencyObject);
			if (dependencyObject != currentElement && XYFocusFocusability.IsValidCandidate(dependencyObject))
			{
				XYFocus.XYFocusParameters item = default(XYFocus.XYFocusParameters);
				if (flag)
				{
					DependencyObject dependencyObject2 = dependencyObject;
					Rect boundsForRanking = GetBoundsForRanking(dependencyObject2, ignoreClipping);
					if (IsCandidateParticipatingInScroll(dependencyObject2, activeScroller) || !IsOccluded(dependencyObject2, boundsForRanking) || IsCandidateChildOfAncestorScroller(dependencyObject2, activeScroller))
					{
						item.Element = dependencyObject2;
						item.Bounds = boundsForRanking;
						list.Add(item);
					}
				}
				else
				{
					Rect boundsForRanking2 = GetBoundsForRanking(dependencyObject, ignoreClipping);
					item.Element = dependencyObject;
					item.Bounds = boundsForRanking2;
					list.Add(item);
				}
			}
			if (IsValidFocusSubtree(dependencyObject, shouldConsiderXYFocusKeyboardNavigation) && !flag2)
			{
				List<XYFocus.XYFocusParameters> collection = FindElements(dependencyObject, currentElement, activeScroller, ignoreClipping, shouldConsiderXYFocusKeyboardNavigation);
				list.AddRange(collection);
			}
		}
		return list;
	}

	private static bool IsValidFocusSubtree(DependencyObject element, bool shouldConsiderXYFocusKeyboardNavigation)
	{
		bool flag = shouldConsiderXYFocusKeyboardNavigation && element is UIElement && IsDirectionalRegion(element);
		if (FocusProperties.IsVisible(element) && FocusProperties.IsEnabled(element) && !FocusProperties.ShouldSkipFocusSubTree(element))
		{
			return !shouldConsiderXYFocusKeyboardNavigation || flag;
		}
		return false;
	}

	private static bool IsCandidateParticipatingInScroll(DependencyObject candidate, DependencyObject? activeScroller)
	{
		if (activeScroller == null)
		{
			return false;
		}
		for (DependencyObject dependencyObject = candidate; dependencyObject != null; dependencyObject = dependencyObject.GetParent() as DependencyObject)
		{
			if (dependencyObject is UIElement uIElement && uIElement.IsScroller())
			{
				return dependencyObject == activeScroller;
			}
		}
		return false;
	}

	private static bool IsCandidateChildOfAncestorScroller(DependencyObject candidate, DependencyObject? activeScroller)
	{
		if (activeScroller == null)
		{
			return false;
		}
		for (DependencyObject dependencyObject = activeScroller.GetParent() as DependencyObject; dependencyObject != null; dependencyObject = dependencyObject.GetParent() as DependencyObject)
		{
			if (dependencyObject is UIElement uIElement && uIElement.IsScroller() && dependencyObject.IsAncestorOf(candidate))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsDirectionalRegion(DependencyObject element)
	{
		if (!(element is UIElement uIElement))
		{
			return false;
		}
		XYFocusKeyboardNavigationMode xYFocusKeyboardNavigationMode = (XYFocusKeyboardNavigationMode)uIElement.GetValue(UIElement.XYFocusKeyboardNavigationProperty);
		return xYFocusKeyboardNavigationMode != XYFocusKeyboardNavigationMode.Disabled;
	}

	internal static Rect GetBoundsForRanking(DependencyObject? element, bool ignoreClipping)
	{
		if (element is Hyperlink hyperlink)
		{
			element = hyperlink.GetContainingFrameworkElement();
		}
		return (element as UIElement)?.GetGlobalBoundsLogical(ignoreClipping) ?? Rect.Infinite;
	}

	internal static bool IsOccluded(DependencyObject? element, Rect elementBounds)
	{
		if (element is Hyperlink hyperlink)
		{
			element = hyperlink.GetContainingFrameworkElement();
		}
		UIElement rootOrIslandForElement = VisualTree.GetRootOrIslandForElement(element);
		try
		{
			return rootOrIslandForElement?.IsOccluded(element as UIElement, elementBounds) ?? true;
		}
		catch
		{
			return true;
		}
	}
}
