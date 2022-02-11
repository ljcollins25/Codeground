using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno.UI.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Uno.UI;

public static class ViewExtensions
{
	public static IEnumerable<UIElement> EnumerateAllChildren(this UIElement view, Func<UIElement, bool> selector, int maxDepth = 20)
	{
		IEnumerable<UIElement> enumerable = view.GetChildren().OfType<UIElement>();
		foreach (UIElement item in enumerable)
		{
			if (selector(item))
			{
				yield return item;
			}
			else
			{
				if (maxDepth <= 0 || item == null)
				{
					continue;
				}
				UIElement view2 = item;
				foreach (UIElement item2 in view2.EnumerateAllChildren(selector, maxDepth - 1))
				{
					yield return item2;
				}
			}
		}
	}

	public static IEnumerable<UIElement> EnumerateAllChildren(this UIElement view, int maxDepth = 20)
	{
		IEnumerable<UIElement> enumerable = view.GetChildren().OfType<UIElement>();
		foreach (UIElement child in enumerable)
		{
			yield return child;
			if (maxDepth <= 0 || child == null)
			{
				continue;
			}
			foreach (UIElement item in child.EnumerateAllChildren(maxDepth - 1))
			{
				yield return item;
			}
		}
	}

	public static T? FindFirstChild<T>(this UIElement view, int? childLevelLimit = null, bool includeCurrent = true) where T : UIElement
	{
		return view.FindFirstChild<T>(null, childLevelLimit, includeCurrent);
	}

	public static T? FindFirstChild<T>(this UIElement view, Func<T, bool>? selector, int? childLevelLimit = null, bool includeCurrent = true) where T : UIElement
	{
		Func<T, bool> selector2 = selector;
		Func<UIElement, bool> func = ((selector2 != null) ? ((Func<UIElement, bool>)((UIElement child) => child is T arg && selector2(arg))) : ((Func<UIElement, bool>)((UIElement child) => child is T)));
		if (includeCurrent && func(view))
		{
			return view as T;
		}
		int maxDepth = childLevelLimit ?? int.MaxValue;
		return (T)view.EnumerateAllChildren(func, maxDepth).FirstOrDefault();
	}

	public static string ShowDescendants(this UIElement view, StringBuilder? sb = null, string spacing = "", UIElement? viewOfInterest = null)
	{
		StringBuilder sb2 = sb;
		string spacing2 = spacing;
		UIElement viewOfInterest2 = viewOfInterest;
		sb2 = sb2 ?? new StringBuilder();
		AppendView(view);
		spacing2 += "  ";
		foreach (UIElement child in view._children)
		{
			child.ShowDescendants(sb2, spacing2, viewOfInterest2);
		}
		return sb2.ToString();
		StringBuilder AppendView(UIElement innerView)
		{
			string text = (innerView as IFrameworkElement)?.Name;
			string text2 = (string.IsNullOrEmpty(text) ? "" : ("-'" + text + "'"));
			string text3 = innerView?.DesiredSize.ToString("F1") ?? "<native/unk>";
			IFrameworkElement frameworkElement = innerView as IFrameworkElement;
			Rect layoutSlot = innerView.LayoutSlot;
			Thickness borderThickness;
			Thickness padding;
			return sb2.Append(spacing2).Append((innerView == viewOfInterest2) ? "*>" : ">").Append(innerView?.ToString() + text2)
				.Append($"-({layoutSlot.Width:F1}x{layoutSlot.Height:F1})@({layoutSlot.X:F1},{layoutSlot.Y:F1})")
				.Append(" d:" + text3)
				.Append((frameworkElement != null) ? $" HA={frameworkElement.HorizontalAlignment},VA={frameworkElement.VerticalAlignment}" : "")
				.Append((frameworkElement != null && frameworkElement.Margin != default(Thickness)) ? $" Margin={frameworkElement.Margin}" : "")
				.Append((frameworkElement != null && frameworkElement.TryGetBorderThickness(out borderThickness) && borderThickness != default(Thickness)) ? $" Border={borderThickness}" : "")
				.Append((frameworkElement != null && frameworkElement.TryGetPadding(out padding) && padding != default(Thickness)) ? $" Padding={padding}" : "")
				.Append((frameworkElement != null && frameworkElement.Visibility != 0) ? "Collapsed " : "")
				.Append((frameworkElement != null && frameworkElement.Opacity != 1.0) ? $"Opacity={frameworkElement.Opacity} " : "")
				.Append((innerView?.Clip != null) ? $" Clip={innerView.Clip.Rect}" : "")
				.Append((innerView != null && innerView.NeedsClipToSlot) ? " CLIPPED_TO_SLOT" : "")
				.Append(innerView?.GetElementSpecificDetails())
				.Append(innerView?.GetElementGridOrCanvasDetails())
				.Append(innerView?.RenderTransform.GetTransformDetails())
				.AppendLine();
		}
	}

	public static string ShowLocalVisualTree(this UIElement element, int fromHeight = 0)
	{
		UIElement uIElement = element;
		for (int i = 0; i < fromHeight; i++)
		{
			if (!(uIElement.GetParent() is UIElement uIElement2))
			{
				break;
			}
			uIElement = uIElement2;
		}
		return uIElement.ShowDescendants(null, "", element);
	}

	public static IEnumerable<object> GetChildren(this object group)
	{
		return new object[0];
	}
}
