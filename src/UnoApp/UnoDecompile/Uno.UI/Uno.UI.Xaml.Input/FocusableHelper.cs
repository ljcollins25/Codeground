using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;

namespace Uno.UI.Xaml.Input;

internal class FocusableHelper : IFocusable
{
	private readonly Hyperlink _hyperlink;

	internal FocusableHelper(Hyperlink hyperlink)
	{
		_hyperlink = hyperlink;
	}

	internal static IFocusable? GetIFocusableForDO(DependencyObject? dependencyObject)
	{
		return (dependencyObject as Hyperlink)?.GetIFocusable();
	}

	internal static bool IsFocusableDO(DependencyObject cdo)
	{
		return cdo is Hyperlink;
	}

	internal static FrameworkElement? GetContainingFrameworkElementIfFocusable(DependencyObject dependencyObject)
	{
		if (dependencyObject is Hyperlink hyperlink)
		{
			TextPointer contentStart = hyperlink.ContentStart;
			FrameworkElement visualParent = contentStart.VisualParent;
			if (visualParent != null)
			{
				return visualParent;
			}
			return hyperlink.GetContainingFrameworkElement();
		}
		return dependencyObject as FrameworkElement;
	}

	public bool IsFocusable()
	{
		return _hyperlink.IsFocusable();
	}

	public int GetTabIndex()
	{
		return _hyperlink.TabIndex;
	}

	public DependencyProperty GetXYFocusDownPropertyIndex()
	{
		return Hyperlink.XYFocusDownProperty;
	}

	public DependencyProperty GetXYFocusDownNavigationStrategyPropertyIndex()
	{
		return Hyperlink.XYFocusDownNavigationStrategyProperty;
	}

	public DependencyProperty GetXYFocusLeftPropertyIndex()
	{
		return Hyperlink.XYFocusLeftProperty;
	}

	public DependencyProperty GetXYFocusLeftNavigationStrategyPropertyIndex()
	{
		return Hyperlink.XYFocusLeftNavigationStrategyProperty;
	}

	public DependencyProperty GetXYFocusRightPropertyIndex()
	{
		return Hyperlink.XYFocusRightProperty;
	}

	public DependencyProperty GetXYFocusRightNavigationStrategyPropertyIndex()
	{
		return Hyperlink.XYFocusRightNavigationStrategyProperty;
	}

	public DependencyProperty GetXYFocusUpPropertyIndex()
	{
		return Hyperlink.XYFocusUpProperty;
	}

	public DependencyProperty GetXYFocusUpNavigationStrategyPropertyIndex()
	{
		return Hyperlink.XYFocusUpNavigationStrategyProperty;
	}

	public DependencyProperty GetFocusStatePropertyIndex()
	{
		return Hyperlink.FocusStateProperty;
	}

	public void OnGotFocus(RoutedEventArgs args)
	{
		_hyperlink.OnGotFocus(args);
	}

	public void OnLostFocus(RoutedEventArgs args)
	{
		_hyperlink.OnLostFocus(args);
	}
}
