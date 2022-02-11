using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItemSeparator : NavigationViewItemBase
{
	private bool m_appliedTemplate;

	private bool m_isClosedCompact;

	private Grid m_rootGrid;

	private long m_splitViewIsPaneOpenChangedRevoker;

	private long m_splitViewDisplayModeChangedRevoker;

	private const string c_rootGrid = "NavigationViewItemSeparatorRootGrid";

	public NavigationViewItemSeparator()
	{
		base.DefaultStyleKey = typeof(NavigationViewItemSeparator);
	}

	private new void UpdateVisualState(bool useTransitions)
	{
		if (m_appliedTemplate)
		{
			string groupName = "NavigationSeparatorLineStates";
			string stateName = ((base.Position == NavigationViewRepeaterPosition.TopPrimary || base.Position == NavigationViewRepeaterPosition.TopFooter) ? "VerticalLine" : (m_isClosedCompact ? "HorizontalLineCompact" : "HorizontalLine"));
			VisualStateUtil.GoToStateIfGroupExists(this, groupName, stateName, useTransitions: false);
		}
	}

	protected override void OnApplyTemplate()
	{
		if (GetNavigationView() != null)
		{
			m_appliedTemplate = false;
			base.OnApplyTemplate();
			if (GetTemplateChild("NavigationViewItemSeparatorRootGrid") is Grid rootGrid)
			{
				m_rootGrid = rootGrid;
			}
			SplitView splitView = GetSplitView();
			if (splitView != null)
			{
				m_splitViewIsPaneOpenChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewPropertyChanged);
				m_splitViewDisplayModeChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewPropertyChanged);
				UpdateIsClosedCompact(updateVisualState: false);
			}
			m_appliedTemplate = true;
			UpdateVisualState(useTransitions: false);
			UpdateItemIndentation();
			_fullyInitialized = true;
		}
	}

	protected override void OnNavigationViewItemBaseDepthChanged()
	{
		UpdateItemIndentation();
	}

	protected override void OnNavigationViewItemBasePositionChanged()
	{
		UpdateVisualState(useTransitions: false);
	}

	private void OnSplitViewPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateIsClosedCompact(updateVisualState: true);
	}

	private void UpdateItemIndentation()
	{
		Grid rootGrid = m_rootGrid;
		if (rootGrid != null)
		{
			Thickness margin = rootGrid.Margin;
			int num = base.Depth * 31;
			rootGrid.Margin = new Thickness(num, margin.Top, margin.Right, margin.Bottom);
		}
	}

	private void UpdateIsClosedCompact(bool updateVisualState)
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			m_isClosedCompact = !splitView.IsPaneOpen && (splitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || splitView.DisplayMode == SplitViewDisplayMode.CompactInline);
			if (updateVisualState)
			{
				UpdateVisualState(useTransitions: false);
			}
		}
	}
}
