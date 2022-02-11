using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItemHeader : NavigationViewItemBase
{
	private Grid m_rootGrid;

	private bool m_isClosedCompact;

	private const string c_rootGrid = "NavigationViewItemHeaderRootGrid";

	public NavigationViewItemHeader()
	{
		base.DefaultStyleKey = typeof(NavigationViewItemHeader);
	}

	protected override void OnApplyTemplate()
	{
		if (GetNavigationView() != null)
		{
			SplitView splitView = GetSplitView();
			if (splitView != null)
			{
				splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewPropertyChanged);
				splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewPropertyChanged);
				UpdateIsClosedCompact();
			}
			if (GetTemplateChild("NavigationViewItemHeaderRootGrid") is Grid rootGrid)
			{
				m_rootGrid = rootGrid;
			}
			UpdateVisualState(useTransitions: false);
			UpdateItemIndentation();
			Visual elementVisual = ElementCompositionPreview.GetElementVisual(this);
			NavigationView.CreateAndAttachHeaderAnimation(elementVisual);
			_fullyInitialized = true;
		}
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
			UpdateVisualState(useTransitions: true);
		}
	}

	private new void UpdateVisualState(bool useTransitions)
	{
		VisualStateManager.GoToState(this, (m_isClosedCompact && base.IsTopLevelItem) ? "HeaderTextCollapsed" : "HeaderTextVisible", useTransitions);
		NavigationView navigationView = GetNavigationView();
		if (navigationView != null)
		{
			VisualStateManager.GoToState(this, (navigationView.PaneDisplayMode == NavigationViewPaneDisplayMode.Top) ? "TopMode" : "LeftMode", useTransitions);
		}
	}

	protected override void OnNavigationViewItemBaseDepthChanged()
	{
		UpdateItemIndentation();
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
}
