using System;
using System.Collections.Generic;
using System.Linq;
using Uno.UI.Xaml.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Xaml.Input;

internal static class FocusProperties
{
	internal static DependencyObject[] GetFocusChildren(DependencyObject? dependencyObject)
	{
		if (dependencyObject is RichTextBlock)
		{
			return Array.Empty<DependencyObject>();
		}
		if (dependencyObject is RichTextBlockOverflow)
		{
			return Array.Empty<DependencyObject>();
		}
		if (dependencyObject is TextBlock view)
		{
			return VisualTreeHelper.GetChildren(view).ToArray();
		}
		if (dependencyObject is UIElement view2)
		{
			return VisualTreeHelper.GetChildren(view2).ToArray();
		}
		return Array.Empty<DependencyObject>();
	}

	internal static bool IsVisible(DependencyObject? dependencyObject)
	{
		bool result = true;
		if (dependencyObject is UIElement uIElement)
		{
			result = uIElement.Visibility == Visibility.Visible;
		}
		return result;
	}

	internal static bool AreAllAncestorsVisible(DependencyObject? dependencyObject)
	{
		if (dependencyObject is UIElement uIElement)
		{
			return uIElement.AreAllAncestorsVisible();
		}
		if (dependencyObject is TextElement textElement)
		{
			FrameworkElement containingFrameworkElement = textElement.GetContainingFrameworkElement();
			return AreAllAncestorsVisible(containingFrameworkElement);
		}
		return true;
	}

	internal static bool IsEnabled(DependencyObject? dependencyObject)
	{
		bool result = true;
		if (dependencyObject is Control control)
		{
			result = control.IsEnabled;
		}
		return result;
	}

	internal static bool IsFocusable(DependencyObject? dependencyObject)
	{
		bool result = false;
		UIElement uIElement = dependencyObject as UIElement;
		if (uIElement != null && uIElement.SkipFocusSubtree)
		{
			return false;
		}
		if (dependencyObject is Control control)
		{
			result = control.IsFocusable;
		}
		else
		{
			IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(dependencyObject);
			if (iFocusableForDO != null)
			{
				result = iFocusableForDO.IsFocusable();
			}
			else if (uIElement != null)
			{
				result = uIElement.IsFocusable;
			}
		}
		return result;
	}

	internal static bool IsPotentialTabStop(DependencyObject? dependencyObject)
	{
		if (dependencyObject != null)
		{
			if (dependencyObject is Control || FocusableHelper.IsFocusableDO(dependencyObject))
			{
				return true;
			}
			if (dependencyObject is TextBlock || dependencyObject is RichTextBlock)
			{
				if (!GetCaretBrowsingModeEnable())
				{
					return (dependencyObject as UIElement)?.IsTabStop ?? false;
				}
				return true;
			}
			if (dependencyObject is UIElement uIElement && uIElement.IsTabStop)
			{
				return true;
			}
		}
		return false;
	}

	private static bool GetCaretBrowsingModeEnable()
	{
		return false;
	}

	internal static bool CanHaveFocusableChildren(DependencyObject? parent)
	{
		bool flag = false;
		if (parent == null)
		{
			return false;
		}
		if (parent is UIElement uIElement && uIElement.SkipFocusSubtree)
		{
			return false;
		}
		DependencyObject[] focusChildren = GetFocusChildren(parent);
		if (focusChildren != null)
		{
			int num = focusChildren.Length;
			for (int i = 0; i < num; i++)
			{
				if (flag)
				{
					break;
				}
				DependencyObject dependencyObject = focusChildren[i];
				if (dependencyObject == null || !IsVisible(dependencyObject))
				{
					continue;
				}
				if (dependencyObject is TextBlock || dependencyObject is RichTextBlock || dependencyObject is RichTextBlockOverflow)
				{
					if (IsFocusable(dependencyObject) && IsPotentialTabStop(dependencyObject))
					{
						flag = true;
					}
					else if (CanHaveFocusableChildren(dependencyObject))
					{
						flag = true;
					}
				}
				else if (IsFocusable(dependencyObject))
				{
					flag = true;
				}
				else if (CanHaveFocusableChildren(dependencyObject))
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	internal static bool IsFocusEngagementEnabled(DependencyObject dependencyObject)
	{
		Control control = dependencyObject as Control;
		bool result = false;
		if (control != null)
		{
			result = control.IsFocusEngagementEnabled;
		}
		return result;
	}

	internal static bool IsFocusEngaged(DependencyObject dependencyObject)
	{
		Control control = dependencyObject as Control;
		bool result = false;
		if (control != null)
		{
			result = control.IsFocusEngaged;
		}
		return result;
	}

	internal static bool IsGamepadFocusCandidate(DependencyObject dependencyObject)
	{
		return (dependencyObject as UIElement)?.IsGamepadFocusCandidate ?? true;
	}

	internal static bool ShouldSkipFocusSubTree(DependencyObject parent)
	{
		if (parent is UIElement uIElement)
		{
			return uIElement.SkipFocusSubtree;
		}
		return false;
	}

	internal static bool HasFocusedElement(DependencyObject element)
	{
		if (element == VisualTree.GetFocusManagerForElement(element)?.FocusedElement)
		{
			return true;
		}
		DependencyObject[] focusChildren = GetFocusChildren(element);
		if (focusChildren != null && focusChildren.Length != 0)
		{
			foreach (DependencyObject dependencyObject in focusChildren)
			{
				if (dependencyObject != null && HasFocusedElement(dependencyObject))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static IEnumerable<DependencyObject?> GetFocusChildrenInTabOrder(DependencyObject parent)
	{
		if (parent is UIElement uIElement)
		{
			return uIElement.GetChildrenInTabFocusOrderInternal() ?? Array.Empty<DependencyObject>();
		}
		return GetFocusChildren(parent);
	}

	internal static void IsScrollable(DependencyObject element, ref bool horizontally, ref bool vertically)
	{
		if (element is ScrollContentPresenter)
		{
			horizontally = false;
			vertically = false;
		}
		else if (element is UIElement uIElement && uIElement is ScrollViewer scrollViewer)
		{
			horizontally = scrollViewer.HorizontalScrollMode == ScrollMode.Enabled;
			vertically = scrollViewer.VerticalScrollMode == ScrollMode.Enabled;
		}
	}
}
