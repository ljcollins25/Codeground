using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal static class XYFocusBubbling
{
	public static DependencyObject? GetDirectionOverride(DependencyObject element, DependencyObject? searchRoot, FocusNavigationDirection direction, bool ignoreFocusabililty = false)
	{
		DependencyObject dependencyObject = null;
		DependencyProperty xYFocusPropertyIndex = GetXYFocusPropertyIndex(element, direction);
		if (xYFocusPropertyIndex != null)
		{
			dependencyObject = element.GetValue(xYFocusPropertyIndex) as DependencyObject;
			if (dependencyObject != null && !ignoreFocusabililty && !XYFocusFocusability.IsValidCandidate(dependencyObject))
			{
				return null;
			}
			if (searchRoot != null && dependencyObject != null && !searchRoot.IsAncestorOf(dependencyObject))
			{
				return null;
			}
		}
		return dependencyObject;
	}

	internal static DependencyObject? TryXYFocusBubble(DependencyObject? element, DependencyObject? candidate, DependencyObject? searchRoot, FocusNavigationDirection direction)
	{
		if (candidate == null)
		{
			return null;
		}
		DependencyObject result = candidate;
		DependencyObject directionOverrideRoot = GetDirectionOverrideRoot(element, searchRoot, direction);
		if (directionOverrideRoot != null)
		{
			bool flag = directionOverrideRoot.IsAncestorOf(candidate);
			DependencyObject directionOverride = GetDirectionOverride(directionOverrideRoot, searchRoot, direction);
			if (directionOverride != null && !flag)
			{
				result = directionOverride;
			}
		}
		return result;
	}

	private static DependencyObject? GetDirectionOverrideRoot(DependencyObject? element, DependencyObject? searchRoot, FocusNavigationDirection direction)
	{
		DependencyObject dependencyObject = element;
		while (dependencyObject != null && GetDirectionOverride(dependencyObject, searchRoot, direction) == null)
		{
			dependencyObject = dependencyObject.GetParent() as DependencyObject;
		}
		return dependencyObject;
	}

	internal static XYFocusNavigationStrategy GetStrategy(DependencyObject inputElement, FocusNavigationDirection direction, XYFocusNavigationStrategyOverride navigationStrategyOverride)
	{
		DependencyObject dependencyObject = inputElement;
		bool flag = navigationStrategyOverride == XYFocusNavigationStrategyOverride.Auto;
		if (navigationStrategyOverride != 0 && !flag)
		{
			return (XYFocusNavigationStrategy)(navigationStrategyOverride - 1);
		}
		if (flag)
		{
			dependencyObject = dependencyObject.GetParent() as DependencyObject;
		}
		if (!(dependencyObject is UIElement))
		{
			return XYFocusNavigationStrategy.Projection;
		}
		UIElement uIElement = (UIElement)dependencyObject;
		DependencyProperty xYFocusNavigationStrategyPropertyIndex = GetXYFocusNavigationStrategyPropertyIndex(dependencyObject, direction);
		while (uIElement != null)
		{
			object value = uIElement.GetValue(xYFocusNavigationStrategyPropertyIndex);
			if (!(value is XYFocusNavigationStrategy))
			{
				break;
			}
			XYFocusNavigationStrategy xYFocusNavigationStrategy = (XYFocusNavigationStrategy)value;
			if (xYFocusNavigationStrategy != 0)
			{
				return xYFocusNavigationStrategy;
			}
			uIElement = uIElement.GetParent() as UIElement;
		}
		return XYFocusNavigationStrategy.Projection;
	}

	private static DependencyProperty? GetXYFocusPropertyIndex(DependencyObject element, FocusNavigationDirection direction)
	{
		DependencyProperty result = null;
		if (element.IsRightToLeft())
		{
			switch (direction)
			{
			case FocusNavigationDirection.Left:
				direction = FocusNavigationDirection.Right;
				break;
			case FocusNavigationDirection.Right:
				direction = FocusNavigationDirection.Left;
				break;
			}
		}
		switch (direction)
		{
		case FocusNavigationDirection.Left:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusLeftProperty;
				break;
			}
			IFocusable iFocusableForDO3 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO3 != null)
			{
				result = iFocusableForDO3.GetXYFocusLeftPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Right:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusRightProperty;
				break;
			}
			IFocusable iFocusableForDO4 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO4 != null)
			{
				result = iFocusableForDO4.GetXYFocusRightPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Up:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusUpProperty;
				break;
			}
			IFocusable iFocusableForDO2 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO2 != null)
			{
				result = iFocusableForDO2.GetXYFocusUpPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Down:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusDownProperty;
				break;
			}
			IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO != null)
			{
				result = iFocusableForDO.GetXYFocusDownPropertyIndex();
			}
			break;
		}
		}
		return result;
	}

	private static DependencyProperty? GetXYFocusNavigationStrategyPropertyIndex(DependencyObject element, FocusNavigationDirection direction)
	{
		DependencyProperty result = null;
		if (element.IsRightToLeft())
		{
			switch (direction)
			{
			case FocusNavigationDirection.Left:
				direction = FocusNavigationDirection.Right;
				break;
			case FocusNavigationDirection.Right:
				direction = FocusNavigationDirection.Left;
				break;
			}
		}
		switch (direction)
		{
		case FocusNavigationDirection.Left:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusLeftNavigationStrategyProperty;
				break;
			}
			IFocusable iFocusableForDO3 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO3 != null)
			{
				result = iFocusableForDO3.GetXYFocusLeftNavigationStrategyPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Right:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusRightNavigationStrategyProperty;
				break;
			}
			IFocusable iFocusableForDO4 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO4 != null)
			{
				result = iFocusableForDO4.GetXYFocusRightNavigationStrategyPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Up:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusUpNavigationStrategyProperty;
				break;
			}
			IFocusable iFocusableForDO2 = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO2 != null)
			{
				result = iFocusableForDO2.GetXYFocusUpNavigationStrategyPropertyIndex();
			}
			break;
		}
		case FocusNavigationDirection.Down:
		{
			if (element is UIElement)
			{
				result = UIElement.XYFocusDownNavigationStrategyProperty;
				break;
			}
			IFocusable iFocusableForDO = FocusableHelper.GetIFocusableForDO(element);
			if (iFocusableForDO != null)
			{
				result = iFocusableForDO.GetXYFocusDownNavigationStrategyPropertyIndex();
			}
			break;
		}
		}
		return result;
	}
}
