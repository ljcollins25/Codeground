using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

public class NavigationViewItemPresenter : ContentControl
{
	private NavigationViewItemHelper<NavigationViewItemPresenter> m_helper = new NavigationViewItemHelper<NavigationViewItemPresenter>();

	public IconElement Icon
	{
		get
		{
			return (IconElement)GetValue(IconProperty);
		}
		set
		{
			SetValue(IconProperty, value);
		}
	}

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(NavigationViewItemPresenter), new FrameworkPropertyMetadata((object)null));


	public NavigationViewItemPresenter()
	{
		base.DefaultStyleKey = typeof(NavigationViewItemPresenter);
	}

	protected override void OnApplyTemplate()
	{
		m_helper.Init(this);
		GetNavigationViewItem()?.UpdateVisualStateNoTransition();
	}

	internal UIElement GetSelectionIndicator()
	{
		return m_helper.GetSelectionIndicator();
	}

	protected override bool GoToElementStateCore(string state, bool useTransitions)
	{
		if (state == NavigationViewItemHelper.c_OnLeftNavigation || state == NavigationViewItemHelper.c_OnLeftNavigationReveal || state == NavigationViewItemHelper.c_OnTopNavigationPrimary || state == NavigationViewItemHelper.c_OnTopNavigationPrimaryReveal || state == NavigationViewItemHelper.c_OnTopNavigationOverflow)
		{
			return base.GoToElementStateCore(state, useTransitions);
		}
		return VisualStateManager.GoToState(this, state, useTransitions);
	}

	private NavigationViewItem GetNavigationViewItem()
	{
		NavigationViewItem result = null;
		NavigationViewItem ancestorOfType = SharedHelpers.GetAncestorOfType<NavigationViewItem>(VisualTreeHelper.GetParent(this));
		if (ancestorOfType != null)
		{
			result = ancestorOfType;
		}
		return result;
	}
}
