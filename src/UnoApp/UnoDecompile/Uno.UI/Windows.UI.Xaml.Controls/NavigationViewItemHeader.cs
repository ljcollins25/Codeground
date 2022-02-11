using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewItemHeader : NavigationViewItemBase
{
	private long m_splitViewIsPaneOpenChangedRevoker;

	private long m_splitViewDisplayModeChangedRevoker;

	private bool m_isClosedCompact;

	public NavigationViewItemHeader()
	{
		base.DefaultStyleKey = typeof(NavigationViewItemHeader);
		base.Loaded += NavigationViewItemHeader_Loaded;
	}

	private void NavigationViewItemHeader_Loaded(object sender, RoutedEventArgs e)
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			m_splitViewIsPaneOpenChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewPropertyChanged);
			m_splitViewDisplayModeChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewPropertyChanged);
			UpdateIsClosedCompact();
		}
		UpdateLocalVisualState(useTransitions: false);
	}

	protected override void OnApplyTemplate()
	{
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(this);
		NavigationView.CreateAndAttachHeaderAnimation(elementVisual);
	}

	private void OnSplitViewPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		if (args == SplitView.IsPaneOpenProperty || args == SplitView.DisplayModeProperty)
		{
			UpdateIsClosedCompact();
		}
	}

	private void UpdateIsClosedCompact()
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			m_isClosedCompact = !splitView.IsPaneOpen && (splitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || splitView.DisplayMode == SplitViewDisplayMode.CompactInline);
			UpdateLocalVisualState(useTransitions: true);
		}
	}

	private void UpdateLocalVisualState(bool useTransitions)
	{
		VisualStateManager.GoToState(this, m_isClosedCompact ? "HeaderTextCollapsed" : "HeaderTextVisible", useTransitions);
	}
}
