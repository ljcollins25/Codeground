using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml;

internal static class IFrameworkElementHelper
{
	public static void Initialize(IFrameworkElement e)
	{
		if (e is IFrameworkElement_EffectiveViewport frameworkElement_EffectiveViewport)
		{
			frameworkElement_EffectiveViewport.InitializeEffectiveViewport();
		}
	}

	public static DependencyObject GetTemplateChild(this IFrameworkElement e, string name)
	{
		return e.FindName(name) as IFrameworkElement;
	}

	public static void InvalidateMeasure(this IFrameworkElement e)
	{
		Window.InvalidateMeasure();
	}

	public static IFrameworkElement FindName(IFrameworkElement e, IEnumerable<UIElement> subviews, string name)
	{
		if (string.Equals(e.Name, name, StringComparison.Ordinal))
		{
			return e;
		}
		IFrameworkElement[] array = subviews.Safe().OfType<IFrameworkElement>().Reverse()
			.ToArray();
		if (array.Length == 0)
		{
			IFrameworkElement frameworkElement = ((e as ContentControl)?.Content as IFrameworkElement) ?? ((e as Popup)?.Child as IFrameworkElement);
			if (frameworkElement != null)
			{
				array = new IFrameworkElement[1] { frameworkElement };
			}
		}
		IFrameworkElement[] array2 = array;
		foreach (IFrameworkElement frameworkElement2 in array2)
		{
			if (string.Equals(frameworkElement2.Name, name, StringComparison.Ordinal))
			{
				return frameworkElement2.ConvertFromStubToElement(e, name);
			}
		}
		IFrameworkElement[] array3 = array;
		foreach (IFrameworkElement frameworkElement3 in array3)
		{
			if (frameworkElement3.FindName(name) is IFrameworkElement element)
			{
				return element.ConvertFromStubToElement(e, name);
			}
		}
		if (e is UIElement uIElement)
		{
			FlyoutBase contextFlyout = uIElement.ContextFlyout;
			if (contextFlyout != null)
			{
				return FindInFlyout(name, contextFlyout);
			}
		}
		if (e is Button button)
		{
			FlyoutBase flyout = button.Flyout;
			if (flyout != null)
			{
				return FindInFlyout(name, flyout);
			}
		}
		return null;
	}

	private static IFrameworkElement FindInFlyout(string name, FlyoutBase flyoutBase)
	{
		if (!(flyoutBase is MenuFlyout menuFlyout))
		{
			if (flyoutBase != null)
			{
				return flyoutBase.GetPresenter()?.FindName(name) as IFrameworkElement;
			}
			throw new InvalidOperationException();
		}
		return menuFlyout.Items.Select((MenuFlyoutItemBase i) => i.FindName(name) as IFrameworkElement).Trim().FirstOrDefault();
	}

	public static Size Measure(this IFrameworkElement element, Size availableSize)
	{
		return default(Size);
	}

	public static Size SizeThatFits(IFrameworkElement e, Size size)
	{
		if (e.Visibility == Visibility.Collapsed)
		{
			return new Size(0.0, 0.0);
		}
		(Size min, Size max) minMax = e.GetMinMax();
		Size item = minMax.min;
		Size item2 = minMax.max;
		double width = size.Width.NumberOrDefault(double.PositiveInfinity).LocalMin(item2.Width).LocalMax(item.Width);
		double height = size.Height.NumberOrDefault(double.PositiveInfinity).LocalMin(item2.Height).LocalMax(item.Height);
		return new Size(width, height);
	}

	private static double LocalMin(this double left, double right)
	{
		return Math.Min(left, right);
	}

	private static double LocalMax(this double left, double right)
	{
		return Math.Max(left, right);
	}

	private static IFrameworkElement ConvertFromStubToElement(this IFrameworkElement element, IFrameworkElement originalRootElement, string name)
	{
		if (element is ElementStub elementStub)
		{
			elementStub.Materialize();
			element = originalRootElement.FindName(name) as IFrameworkElement;
		}
		return element;
	}

	private static double NumberOrDefault(this double number, double defaultValue)
	{
		if (!double.IsNaN(number))
		{
			return number;
		}
		return defaultValue;
	}

	public static void MaybeOrNot<TInstance>(this TInstance instance, Action nonNullAction, Action nullAction)
	{
		if (instance != null)
		{
			nonNullAction();
		}
		else
		{
			nullAction();
		}
	}

	public static bool? IsWidthConstrainedSimple(this IFrameworkElement element)
	{
		if (!double.IsNaN(element.Width) && !double.IsPositiveInfinity(element.Width))
		{
			return true;
		}
		if (element.HorizontalAlignment != HorizontalAlignment.Stretch)
		{
			return false;
		}
		return null;
	}

	public static bool? IsHeightConstrainedSimple(this IFrameworkElement element)
	{
		if (!double.IsNaN(element.Height) && !double.IsPositiveInfinity(element.Height))
		{
			return true;
		}
		if (element.VerticalAlignment != VerticalAlignment.Stretch)
		{
			return false;
		}
		return null;
	}
}
