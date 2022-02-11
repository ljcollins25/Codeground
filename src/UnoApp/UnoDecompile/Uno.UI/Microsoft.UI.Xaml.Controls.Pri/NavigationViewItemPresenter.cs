using System;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class NavigationViewItemPresenter : ContentControl
{
	private const string c_contentGrid = "PresenterContentRootGrid";

	private const string c_infoBadgePresenter = "InfoBadgePresenter";

	private const string c_expandCollapseChevron = "ExpandCollapseChevron";

	private const string c_expandCollapseRotateExpandedStoryboard = "ExpandCollapseRotateExpandedStoryboard";

	private const string c_expandCollapseRotateCollapsedStoryboard = "ExpandCollapseRotateCollapsedStoryboard";

	private const string c_iconBoxColumnDefinitionName = "IconColumn";

	private double m_compactPaneLengthValue = 40.0;

	private NavigationViewItemHelper<NavigationViewItemPresenter> m_helper;

	private Grid m_contentGrid;

	private ContentPresenter m_infoBadgePresenter;

	private Grid m_expandCollapseChevron;

	private double m_leftIndentation;

	private Storyboard m_chevronExpandedStoryboard;

	private Storyboard m_chevronCollapsedStoryboard;

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

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(NavigationViewItemPresenter), new FrameworkPropertyMetadata(null));


	public InfoBadge InfoBadge
	{
		get
		{
			return (InfoBadge)GetValue(InfoBadgeProperty);
		}
		set
		{
			SetValue(InfoBadgeProperty, value);
		}
	}

	public static DependencyProperty InfoBadgeProperty { get; } = DependencyProperty.Register("InfoBadge", typeof(InfoBadge), typeof(NavigationViewItemPresenter), new FrameworkPropertyMetadata(null));


	public NavigationViewItemPresenterTemplateSettings TemplateSettings
	{
		get
		{
			return (NavigationViewItemPresenterTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		internal set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(NavigationViewItemPresenterTemplateSettings), typeof(NavigationViewItemPresenter), new FrameworkPropertyMetadata(null));


	public NavigationViewItemPresenter()
	{
		SetValue(TemplateSettingsProperty, new NavigationViewItemPresenterTemplateSettings());
		base.DefaultStyleKey = typeof(NavigationViewItemPresenter);
	}

	protected override void OnApplyTemplate()
	{
		m_helper = new NavigationViewItemHelper<NavigationViewItemPresenter>(this);
		m_helper.Init(this);
		if (GetTemplateChild("PresenterContentRootGrid") is Grid contentGrid)
		{
			m_contentGrid = contentGrid;
		}
		m_infoBadgePresenter = GetTemplateChild("InfoBadgePresenter") as ContentPresenter;
		NavigationViewItem navigationViewItem = GetNavigationViewItem();
		if (navigationViewItem != null)
		{
			if (m_expandCollapseChevron != null)
			{
				m_expandCollapseChevron.Tapped -= navigationViewItem.OnExpandCollapseChevronTapped;
			}
			if (GetTemplateChild("ExpandCollapseChevron") is Grid grid)
			{
				m_expandCollapseChevron = grid;
				grid.Tapped += navigationViewItem.OnExpandCollapseChevronTapped;
			}
			navigationViewItem.UpdateVisualStateNoTransition();
			NavigationView navigationView = navigationViewItem.GetNavigationView();
			if (navigationView != null && navigationView.PaneDisplayMode != NavigationViewPaneDisplayMode.Top)
			{
				UpdateCompactPaneLength(m_compactPaneLengthValue, shouldUpdate: true);
			}
		}
		m_chevronExpandedStoryboard = (Storyboard)GetTemplateChild("ExpandCollapseRotateExpandedStoryboard");
		m_chevronCollapsedStoryboard = (Storyboard)GetTemplateChild("ExpandCollapseRotateCollapsedStoryboard");
		UpdateMargin();
	}

	internal void RotateExpandCollapseChevron(bool isExpanded)
	{
		if (isExpanded)
		{
			m_chevronExpandedStoryboard?.Begin();
		}
		else
		{
			m_chevronCollapsedStoryboard?.Begin();
		}
	}

	internal UIElement GetSelectionIndicator()
	{
		if (m_contentGrid == null && m_helper != null)
		{
			OnApplyTemplate();
		}
		return m_helper?.GetSelectionIndicator();
	}

	protected override bool GoToElementStateCore(string state, bool useTransitions)
	{
		switch (state)
		{
		case "OnLeftNavigation":
		case "OnLeftNavigationReveal":
		case "OnTopNavigationPrimary":
		case "OnTopNavigationPrimaryReveal":
		case "OnTopNavigationOverflow":
		{
			ContentPresenter infoBadgePresenter = m_infoBadgePresenter;
			if (infoBadgePresenter != null)
			{
				infoBadgePresenter.Content = null;
			}
			return base.GoToElementStateCore(state, useTransitions);
		}
		default:
			return VisualStateManager.GoToState(this, state, useTransitions);
		}
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

	internal void UpdateContentLeftIndentation(double leftIndentation)
	{
		m_leftIndentation = leftIndentation;
		UpdateMargin();
	}

	private void UpdateMargin()
	{
		Grid contentGrid = m_contentGrid;
		if (contentGrid != null)
		{
			Thickness margin = contentGrid.Margin;
			contentGrid.Margin = new Thickness(m_leftIndentation, margin.Top, margin.Right, margin.Bottom);
		}
	}

	internal void UpdateCompactPaneLength(double compactPaneLength, bool shouldUpdate)
	{
		m_compactPaneLengthValue = compactPaneLength;
		if (shouldUpdate)
		{
			NavigationViewItemPresenterTemplateSettings templateSettings = TemplateSettings;
			double num2 = (templateSettings.IconWidth = compactPaneLength);
			templateSettings.SmallerIconWidth = Math.Max(0.0, num2 - 8.0);
		}
	}

	internal void UpdateClosedCompactVisualState(bool isTopLevelItem, bool isClosedCompact)
	{
		string stateName = ((isClosedCompact && isTopLevelItem) ? "ClosedCompactAndTopLevelItem" : "NotClosedCompactAndTopLevelItem");
		VisualStateManager.GoToState(this, stateName, useTransitions: false);
	}
}
