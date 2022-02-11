using System;
using Uno.UI.Behaviors;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.__Resources;

internal class _NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC0
{
	private class _NavigationView_c5e4328787e7d47117423afa8de1d4fc_UnoUI__Resources_NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC0NavigationViewRDSC4
	{
		public UIElement Build(object __ResourceOwner_359)
		{
			NameScope nameScope = new NameScope();
			UIElement uIElement = null;
			uIElement = new ItemsStackPanel
			{
				IsParsing = true,
				Orientation = Orientation.Horizontal
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ItemsStackPanel c97)
			{
				c97.CreationComplete();
			});
			DependencyObject dependencyObject = uIElement;
			if (dependencyObject != null)
			{
				NameScope.SetNameScope(dependencyObject, nameScope);
				nameScope.Owner = dependencyObject;
				FrameworkElementHelper.AddObjectReference(dependencyObject, this);
			}
			return uIElement;
		}
	}

	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_2_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_3_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_4_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_5_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_6_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_7_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_8_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_9_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_10_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_11_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_12_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_13_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _TopNavTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonPlaceholderOnTopNavSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavLeftPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavMenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavMenuItemsOverflowHostSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavOverflowButtonSubject = new ElementNameSubject();

	private ElementNameSubject _PaneCustomContentOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _TopPaneAutoSuggestBoxPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _TopPaneAutoSuggestAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneFooterOnTopPaneSubject = new ElementNameSubject();

	private ElementNameSubject _SettingsTopNavPaneItemSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavGridSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavContentOverlayAreaGridSubject = new ElementNameSubject();

	private ElementNameSubject _TopNavAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneContentGridToggleButtonRowSubject = new ElementNameSubject();

	private ElementNameSubject _ContentPaneTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _PaneTitleTextBlockSubject = new ElementNameSubject();

	private ElementNameSubject _PaneHeaderContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAutoSuggestBoxPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _PaneAutoSuggestButtonSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestAreaSubject = new ElementNameSubject();

	private ElementNameSubject _PaneCustomContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _MenuItemsHostSubject = new ElementNameSubject();

	private ElementNameSubject _FooterContentBorderSubject = new ElementNameSubject();

	private ElementNameSubject _SettingsNavPaneItemSubject = new ElementNameSubject();

	private ElementNameSubject _PaneContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderContentSubject = new ElementNameSubject();

	private ElementNameSubject _ContentGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootSplitViewSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneTopPaddingSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationViewBackButtonSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonSubject = new ElementNameSubject();

	private ElementNameSubject _ButtonHolderGridSubject = new ElementNameSubject();

	private ElementNameSubject _PaneToggleButtonGridSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _CompactSubject = new ElementNameSubject();

	private ElementNameSubject _ExpandedSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalSubject = new ElementNameSubject();

	private ElementNameSubject _MinimalWithBackButtonSubject = new ElementNameSubject();

	private ElementNameSubject _DisplayModeGroupSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _TogglePaneGroupSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderGroupSubject = new ElementNameSubject();

	private ElementNameSubject _SettingsVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _SettingsCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _SettingsGroupSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestBoxVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestBoxCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _AutoSuggestGroupSubject = new ElementNameSubject();

	private ElementNameSubject _NotClosedCompactSubject = new ElementNameSubject();

	private ElementNameSubject _ClosedCompactSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStateGroupSubject = new ElementNameSubject();

	private ElementNameSubject _ListSizeFullSubject = new ElementNameSubject();

	private ElementNameSubject _ListSizeCompactSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStateListSizeGroupSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _TitleBarVisibilityGroupSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowButtonWithLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowButtonNoLabelSubject = new ElementNameSubject();

	private ElementNameSubject _OverflowLabelGroupSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _BackButtonGroupSubject = new ElementNameSubject();

	private ColumnDefinition _component_0
	{
		get
		{
			return (ColumnDefinition)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Button _component_1
	{
		get
		{
			return (Button)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private Grid _component_2
	{
		get
		{
			return (Grid)_component_2_Holder.Instance;
		}
		set
		{
			_component_2_Holder.Instance = value;
		}
	}

	private NavigationViewItem _component_3
	{
		get
		{
			return (NavigationViewItem)_component_3_Holder.Instance;
		}
		set
		{
			_component_3_Holder.Instance = value;
		}
	}

	private Grid _component_4
	{
		get
		{
			return (Grid)_component_4_Holder.Instance;
		}
		set
		{
			_component_4_Holder.Instance = value;
		}
	}

	private StackPanel _component_5
	{
		get
		{
			return (StackPanel)_component_5_Holder.Instance;
		}
		set
		{
			_component_5_Holder.Instance = value;
		}
	}

	private TextBlock _component_6
	{
		get
		{
			return (TextBlock)_component_6_Holder.Instance;
		}
		set
		{
			_component_6_Holder.Instance = value;
		}
	}

	private Grid _component_7
	{
		get
		{
			return (Grid)_component_7_Holder.Instance;
		}
		set
		{
			_component_7_Holder.Instance = value;
		}
	}

	private ContentControl _component_8
	{
		get
		{
			return (ContentControl)_component_8_Holder.Instance;
		}
		set
		{
			_component_8_Holder.Instance = value;
		}
	}

	private Button _component_9
	{
		get
		{
			return (Button)_component_9_Holder.Instance;
		}
		set
		{
			_component_9_Holder.Instance = value;
		}
	}

	private Grid _component_10
	{
		get
		{
			return (Grid)_component_10_Holder.Instance;
		}
		set
		{
			_component_10_Holder.Instance = value;
		}
	}

	private ContentControl _component_11
	{
		get
		{
			return (ContentControl)_component_11_Holder.Instance;
		}
		set
		{
			_component_11_Holder.Instance = value;
		}
	}

	private SplitView _component_12
	{
		get
		{
			return (SplitView)_component_12_Holder.Instance;
		}
		set
		{
			_component_12_Holder.Instance = value;
		}
	}

	private Button _component_13
	{
		get
		{
			return (Button)_component_13_Holder.Instance;
		}
		set
		{
			_component_13_Holder.Instance = value;
		}
	}

	private Grid TopNavTopPadding
	{
		get
		{
			return (Grid)_TopNavTopPaddingSubject.ElementInstance;
		}
		set
		{
			_TopNavTopPaddingSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition BackButtonPlaceholderOnTopNav
	{
		get
		{
			return (ColumnDefinition)_BackButtonPlaceholderOnTopNavSubject.ElementInstance;
		}
		set
		{
			_BackButtonPlaceholderOnTopNavSubject.ElementInstance = value;
		}
	}

	private Grid TopNavLeftPadding
	{
		get
		{
			return (Grid)_TopNavLeftPaddingSubject.ElementInstance;
		}
		set
		{
			_TopNavLeftPaddingSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneHeaderOnTopPane
	{
		get
		{
			return (ContentControl)_PaneHeaderOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderOnTopPaneSubject.ElementInstance = value;
		}
	}

	private NavigationViewList TopNavMenuItemsHost
	{
		get
		{
			return (NavigationViewList)_TopNavMenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_TopNavMenuItemsHostSubject.ElementInstance = value;
		}
	}

	private NavigationViewList TopNavMenuItemsOverflowHost
	{
		get
		{
			return (NavigationViewList)_TopNavMenuItemsOverflowHostSubject.ElementInstance;
		}
		set
		{
			_TopNavMenuItemsOverflowHostSubject.ElementInstance = value;
		}
	}

	private Button TopNavOverflowButton
	{
		get
		{
			return (Button)_TopNavOverflowButtonSubject.ElementInstance;
		}
		set
		{
			_TopNavOverflowButtonSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneCustomContentOnTopPane
	{
		get
		{
			return (ContentControl)_PaneCustomContentOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneCustomContentOnTopPaneSubject.ElementInstance = value;
		}
	}

	private ContentControl TopPaneAutoSuggestBoxPresenter
	{
		get
		{
			return (ContentControl)_TopPaneAutoSuggestBoxPresenterSubject.ElementInstance;
		}
		set
		{
			_TopPaneAutoSuggestBoxPresenterSubject.ElementInstance = value;
		}
	}

	private Grid TopPaneAutoSuggestArea
	{
		get
		{
			return (Grid)_TopPaneAutoSuggestAreaSubject.ElementInstance;
		}
		set
		{
			_TopPaneAutoSuggestAreaSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneFooterOnTopPane
	{
		get
		{
			return (ContentControl)_PaneFooterOnTopPaneSubject.ElementInstance;
		}
		set
		{
			_PaneFooterOnTopPaneSubject.ElementInstance = value;
		}
	}

	private NavigationViewItem SettingsTopNavPaneItem
	{
		get
		{
			return (NavigationViewItem)_SettingsTopNavPaneItemSubject.ElementInstance;
		}
		set
		{
			_SettingsTopNavPaneItemSubject.ElementInstance = value;
		}
	}

	private Grid TopNavGrid
	{
		get
		{
			return (Grid)_TopNavGridSubject.ElementInstance;
		}
		set
		{
			_TopNavGridSubject.ElementInstance = value;
		}
	}

	private Border TopNavContentOverlayAreaGrid
	{
		get
		{
			return (Border)_TopNavContentOverlayAreaGridSubject.ElementInstance;
		}
		set
		{
			_TopNavContentOverlayAreaGridSubject.ElementInstance = value;
		}
	}

	private StackPanel TopNavArea
	{
		get
		{
			return (StackPanel)_TopNavAreaSubject.ElementInstance;
		}
		set
		{
			_TopNavAreaSubject.ElementInstance = value;
		}
	}

	private RowDefinition PaneContentGridToggleButtonRow
	{
		get
		{
			return (RowDefinition)_PaneContentGridToggleButtonRowSubject.ElementInstance;
		}
		set
		{
			_PaneContentGridToggleButtonRowSubject.ElementInstance = value;
		}
	}

	private Grid ContentPaneTopPadding
	{
		get
		{
			return (Grid)_ContentPaneTopPaddingSubject.ElementInstance;
		}
		set
		{
			_ContentPaneTopPaddingSubject.ElementInstance = value;
		}
	}

	private TextBlock PaneTitleTextBlock
	{
		get
		{
			return (TextBlock)_PaneTitleTextBlockSubject.ElementInstance;
		}
		set
		{
			_PaneTitleTextBlockSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneHeaderContentBorder
	{
		get
		{
			return (ContentControl)_PaneHeaderContentBorderSubject.ElementInstance;
		}
		set
		{
			_PaneHeaderContentBorderSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneAutoSuggestBoxPresenter
	{
		get
		{
			return (ContentControl)_PaneAutoSuggestBoxPresenterSubject.ElementInstance;
		}
		set
		{
			_PaneAutoSuggestBoxPresenterSubject.ElementInstance = value;
		}
	}

	private Button PaneAutoSuggestButton
	{
		get
		{
			return (Button)_PaneAutoSuggestButtonSubject.ElementInstance;
		}
		set
		{
			_PaneAutoSuggestButtonSubject.ElementInstance = value;
		}
	}

	private Grid AutoSuggestArea
	{
		get
		{
			return (Grid)_AutoSuggestAreaSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestAreaSubject.ElementInstance = value;
		}
	}

	private ContentControl PaneCustomContentBorder
	{
		get
		{
			return (ContentControl)_PaneCustomContentBorderSubject.ElementInstance;
		}
		set
		{
			_PaneCustomContentBorderSubject.ElementInstance = value;
		}
	}

	private NavigationViewList MenuItemsHost
	{
		get
		{
			return (NavigationViewList)_MenuItemsHostSubject.ElementInstance;
		}
		set
		{
			_MenuItemsHostSubject.ElementInstance = value;
		}
	}

	private ContentControl FooterContentBorder
	{
		get
		{
			return (ContentControl)_FooterContentBorderSubject.ElementInstance;
		}
		set
		{
			_FooterContentBorderSubject.ElementInstance = value;
		}
	}

	private NavigationViewItem SettingsNavPaneItem
	{
		get
		{
			return (NavigationViewItem)_SettingsNavPaneItemSubject.ElementInstance;
		}
		set
		{
			_SettingsNavPaneItemSubject.ElementInstance = value;
		}
	}

	private Grid PaneContentGrid
	{
		get
		{
			return (Grid)_PaneContentGridSubject.ElementInstance;
		}
		set
		{
			_PaneContentGridSubject.ElementInstance = value;
		}
	}

	private ContentControl HeaderContent
	{
		get
		{
			return (ContentControl)_HeaderContentSubject.ElementInstance;
		}
		set
		{
			_HeaderContentSubject.ElementInstance = value;
		}
	}

	private Grid ContentGrid
	{
		get
		{
			return (Grid)_ContentGridSubject.ElementInstance;
		}
		set
		{
			_ContentGridSubject.ElementInstance = value;
		}
	}

	private SplitView RootSplitView
	{
		get
		{
			return (SplitView)_RootSplitViewSubject.ElementInstance;
		}
		set
		{
			_RootSplitViewSubject.ElementInstance = value;
		}
	}

	private Grid TogglePaneTopPadding
	{
		get
		{
			return (Grid)_TogglePaneTopPaddingSubject.ElementInstance;
		}
		set
		{
			_TogglePaneTopPaddingSubject.ElementInstance = value;
		}
	}

	private Button NavigationViewBackButton
	{
		get
		{
			return (Button)_NavigationViewBackButtonSubject.ElementInstance;
		}
		set
		{
			_NavigationViewBackButtonSubject.ElementInstance = value;
		}
	}

	private Button TogglePaneButton
	{
		get
		{
			return (Button)_TogglePaneButtonSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonSubject.ElementInstance = value;
		}
	}

	private Grid ButtonHolderGrid
	{
		get
		{
			return (Grid)_ButtonHolderGridSubject.ElementInstance;
		}
		set
		{
			_ButtonHolderGridSubject.ElementInstance = value;
		}
	}

	private Grid PaneToggleButtonGrid
	{
		get
		{
			return (Grid)_PaneToggleButtonGridSubject.ElementInstance;
		}
		set
		{
			_PaneToggleButtonGridSubject.ElementInstance = value;
		}
	}

	private Grid RootGrid
	{
		get
		{
			return (Grid)_RootGridSubject.ElementInstance;
		}
		set
		{
			_RootGridSubject.ElementInstance = value;
		}
	}

	private VisualState Compact
	{
		get
		{
			return (VisualState)_CompactSubject.ElementInstance;
		}
		set
		{
			_CompactSubject.ElementInstance = value;
		}
	}

	private VisualState Expanded
	{
		get
		{
			return (VisualState)_ExpandedSubject.ElementInstance;
		}
		set
		{
			_ExpandedSubject.ElementInstance = value;
		}
	}

	private VisualState Minimal
	{
		get
		{
			return (VisualState)_MinimalSubject.ElementInstance;
		}
		set
		{
			_MinimalSubject.ElementInstance = value;
		}
	}

	private VisualState MinimalWithBackButton
	{
		get
		{
			return (VisualState)_MinimalWithBackButtonSubject.ElementInstance;
		}
		set
		{
			_MinimalWithBackButtonSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup DisplayModeGroup
	{
		get
		{
			return (VisualStateGroup)_DisplayModeGroupSubject.ElementInstance;
		}
		set
		{
			_DisplayModeGroupSubject.ElementInstance = value;
		}
	}

	private VisualState TogglePaneButtonVisible
	{
		get
		{
			return (VisualState)_TogglePaneButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState TogglePaneButtonCollapsed
	{
		get
		{
			return (VisualState)_TogglePaneButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_TogglePaneButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup TogglePaneGroup
	{
		get
		{
			return (VisualStateGroup)_TogglePaneGroupSubject.ElementInstance;
		}
		set
		{
			_TogglePaneGroupSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderVisible
	{
		get
		{
			return (VisualState)_HeaderVisibleSubject.ElementInstance;
		}
		set
		{
			_HeaderVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderCollapsed
	{
		get
		{
			return (VisualState)_HeaderCollapsedSubject.ElementInstance;
		}
		set
		{
			_HeaderCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup HeaderGroup
	{
		get
		{
			return (VisualStateGroup)_HeaderGroupSubject.ElementInstance;
		}
		set
		{
			_HeaderGroupSubject.ElementInstance = value;
		}
	}

	private VisualState SettingsVisible
	{
		get
		{
			return (VisualState)_SettingsVisibleSubject.ElementInstance;
		}
		set
		{
			_SettingsVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState SettingsCollapsed
	{
		get
		{
			return (VisualState)_SettingsCollapsedSubject.ElementInstance;
		}
		set
		{
			_SettingsCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup SettingsGroup
	{
		get
		{
			return (VisualStateGroup)_SettingsGroupSubject.ElementInstance;
		}
		set
		{
			_SettingsGroupSubject.ElementInstance = value;
		}
	}

	private VisualState AutoSuggestBoxVisible
	{
		get
		{
			return (VisualState)_AutoSuggestBoxVisibleSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestBoxVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState AutoSuggestBoxCollapsed
	{
		get
		{
			return (VisualState)_AutoSuggestBoxCollapsedSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestBoxCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup AutoSuggestGroup
	{
		get
		{
			return (VisualStateGroup)_AutoSuggestGroupSubject.ElementInstance;
		}
		set
		{
			_AutoSuggestGroupSubject.ElementInstance = value;
		}
	}

	private VisualState NotClosedCompact
	{
		get
		{
			return (VisualState)_NotClosedCompactSubject.ElementInstance;
		}
		set
		{
			_NotClosedCompactSubject.ElementInstance = value;
		}
	}

	private VisualState ClosedCompact
	{
		get
		{
			return (VisualState)_ClosedCompactSubject.ElementInstance;
		}
		set
		{
			_ClosedCompactSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStateGroup
	{
		get
		{
			return (VisualStateGroup)_PaneStateGroupSubject.ElementInstance;
		}
		set
		{
			_PaneStateGroupSubject.ElementInstance = value;
		}
	}

	private VisualState ListSizeFull
	{
		get
		{
			return (VisualState)_ListSizeFullSubject.ElementInstance;
		}
		set
		{
			_ListSizeFullSubject.ElementInstance = value;
		}
	}

	private VisualState ListSizeCompact
	{
		get
		{
			return (VisualState)_ListSizeCompactSubject.ElementInstance;
		}
		set
		{
			_ListSizeCompactSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStateListSizeGroup
	{
		get
		{
			return (VisualStateGroup)_PaneStateListSizeGroupSubject.ElementInstance;
		}
		set
		{
			_PaneStateListSizeGroupSubject.ElementInstance = value;
		}
	}

	private VisualState TitleBarVisible
	{
		get
		{
			return (VisualState)_TitleBarVisibleSubject.ElementInstance;
		}
		set
		{
			_TitleBarVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState TitleBarCollapsed
	{
		get
		{
			return (VisualState)_TitleBarCollapsedSubject.ElementInstance;
		}
		set
		{
			_TitleBarCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup TitleBarVisibilityGroup
	{
		get
		{
			return (VisualStateGroup)_TitleBarVisibilityGroupSubject.ElementInstance;
		}
		set
		{
			_TitleBarVisibilityGroupSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowButtonWithLabel
	{
		get
		{
			return (VisualState)_OverflowButtonWithLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowButtonWithLabelSubject.ElementInstance = value;
		}
	}

	private VisualState OverflowButtonNoLabel
	{
		get
		{
			return (VisualState)_OverflowButtonNoLabelSubject.ElementInstance;
		}
		set
		{
			_OverflowButtonNoLabelSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup OverflowLabelGroup
	{
		get
		{
			return (VisualStateGroup)_OverflowLabelGroupSubject.ElementInstance;
		}
		set
		{
			_OverflowLabelGroupSubject.ElementInstance = value;
		}
	}

	private VisualState BackButtonVisible
	{
		get
		{
			return (VisualState)_BackButtonVisibleSubject.ElementInstance;
		}
		set
		{
			_BackButtonVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState BackButtonCollapsed
	{
		get
		{
			return (VisualState)_BackButtonCollapsedSubject.ElementInstance;
		}
		set
		{
			_BackButtonCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup BackButtonGroup
	{
		get
		{
			return (VisualStateGroup)_BackButtonGroupSubject.ElementInstance;
		}
		set
		{
			_BackButtonGroupSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_290)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		Grid grid = new Grid();
		grid.IsParsing = true;
		grid.Name = "RootGrid";
		grid.Children.Add(new Grid
		{
			IsParsing = true,
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				}
			},
			Children = 
			{
				(UIElement)new StackPanel
				{
					IsParsing = true,
					Name = "TopNavArea",
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Top,
					Children = 
					{
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "TopNavTopPadding"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c2)
						{
							nameScope.RegisterName("TopNavTopPadding", c2);
							TopNavTopPadding = c2;
							c2.SetBinding(FrameworkElement.HeightProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPadding"
							});
							c2.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPaneVisibility"
							});
							c2.CreationComplete();
						}),
						(UIElement)new Grid
						{
							IsParsing = true,
							Name = "TopNavGrid",
							ColumnDefinitions = 
							{
								new ColumnDefinition().NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ColumnDefinition c3)
								{
									nameScope.RegisterName("BackButtonPlaceholderOnTopNav", c3);
									BackButtonPlaceholderOnTopNav = c3;
									ResourceResolverSingleton.Instance.ApplyResource(c3, ColumnDefinition.WidthProperty, "NavigationBackButtonWidth", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
									_component_0 = c3;
									NameScope.SetNameScope(_component_0, nameScope);
								}),
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Star),
									MinWidth = 48.0
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								},
								new ColumnDefinition
								{
									Width = new GridLength(1.0, GridUnitType.Auto)
								}
							},
							Children = 
							{
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "TopNavLeftPadding",
									Width = 0.0
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c12)
								{
									nameScope.RegisterName("TopNavLeftPadding", c12);
									TopNavLeftPadding = c12;
									Grid.SetColumn(c12, 1);
									c12.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneHeaderOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c13)
								{
									nameScope.RegisterName("PaneHeaderOnTopPane", c13);
									PaneHeaderOnTopPane = c13;
									Grid.SetColumn(c13, 2);
									c13.CreationComplete();
								}),
								(UIElement)new NavigationViewList
								{
									IsParsing = true,
									Name = "TopNavMenuItemsHost",
									SelectionMode = ListViewSelectionMode.Single,
									IsItemClickEnabled = true,
									ItemsPanel = new ItemsPanelTemplate(__ResourceOwner_290, (object? __owner) => new _NavigationView_c5e4328787e7d47117423afa8de1d4fc_UnoUI__Resources_NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC0NavigationViewRDSC4().Build(__owner)),
									ItemContainerTransitions = new TransitionCollection()
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewList c14)
								{
									nameScope.RegisterName("TopNavMenuItemsHost", c14);
									TopNavMenuItemsHost = c14;
									AutomationProperties.SetLandmarkType(c14, AutomationLandmarkType.Navigation);
									Grid.SetColumn(c14, 3);
									c14.SetBinding(ItemsControl.ItemTemplateProperty, new Binding
									{
										Path = "MenuItemTemplate",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c14.SetBinding(ItemsControl.ItemTemplateSelectorProperty, new Binding
									{
										Path = "MenuItemTemplateSelector",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c14.SetBinding(ItemsControl.ItemContainerStyleProperty, new Binding
									{
										Path = "MenuItemContainerStyle",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									c14.SetBinding(ItemsControl.ItemContainerStyleSelectorProperty, new Binding
									{
										Path = "MenuItemContainerStyleSelector",
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
									});
									ScrollViewer.SetHorizontalScrollMode(c14, ScrollMode.Disabled);
									ScrollViewer.SetHorizontalScrollBarVisibility(c14, ScrollBarVisibility.Hidden);
									ScrollViewer.SetVerticalScrollMode(c14, ScrollMode.Disabled);
									ScrollViewer.SetVerticalScrollBarVisibility(c14, ScrollBarVisibility.Hidden);
									c14.SetBinding(ListViewBase.SingleSelectionFollowsFocusProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.SingleSelectionFollowsFocus"
									});
									c14.CreationComplete();
								}),
								(UIElement)new Button
								{
									IsParsing = true,
									Name = "TopNavOverflowButton",
									Content = "More",
									Flyout = new Flyout
									{
										Placement = FlyoutPlacementMode.Bottom,
										FlyoutPresenterStyle = new Style(typeof(FlyoutPresenter))
										{
											BasedOn = (Style)ResourceResolverSingleton.Instance.ResolveResourceStatic("DefaultFlyoutPresenter", typeof(Style), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_),
											Setters = 
											{
												(SetterBase)new Setter(Control.PaddingProperty, new Thickness(0.0, 8.0)),
												(SetterBase)new Setter(FrameworkElement.MarginProperty, new Thickness(0.0, -4.0, 0.0, 0.0))
											}
										},
										Content = new NavigationViewList
										{
											IsParsing = true,
											Name = "TopNavMenuItemsOverflowHost",
											SingleSelectionFollowsFocus = false,
											IsItemClickEnabled = true,
											ItemContainerTransitions = new TransitionCollection()
										}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewList c15)
										{
											nameScope.RegisterName("TopNavMenuItemsOverflowHost", c15);
											TopNavMenuItemsOverflowHost = c15;
											c15.SetBinding(ItemsControl.ItemTemplateProperty, new Binding
											{
												Path = "MenuItemTemplate",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c15.SetBinding(ItemsControl.ItemTemplateSelectorProperty, new Binding
											{
												Path = "MenuItemTemplateSelector",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c15.SetBinding(ItemsControl.ItemContainerStyleProperty, new Binding
											{
												Path = "MenuItemContainerStyle",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c15.SetBinding(ItemsControl.ItemContainerStyleSelectorProperty, new Binding
											{
												Path = "MenuItemContainerStyleSelector",
												RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
											});
											c15.CreationComplete();
										})
									}
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Button c17)
								{
									nameScope.RegisterName("TopNavOverflowButton", c17);
									TopNavOverflowButton = c17;
									Grid.SetColumn(c17, 4);
									ResourceResolverSingleton.Instance.ApplyResource(c17, FrameworkElement.StyleProperty, "LegacyNavigationViewOverflowButtonStyleWhenPaneOnTop", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
									c17.SetBinding(UIElement.VisibilityProperty, new Binding
									{
										RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
										Path = "TemplateSettings.OverflowButtonVisibility"
									});
									_component_1 = c17;
									c17.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneCustomContentOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c18)
								{
									nameScope.RegisterName("PaneCustomContentOnTopPane", c18);
									PaneCustomContentOnTopPane = c18;
									Grid.SetColumn(c18, 5);
									c18.CreationComplete();
								}),
								(UIElement)new Grid
								{
									IsParsing = true,
									Name = "TopPaneAutoSuggestArea",
									Children = { (UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "TopPaneAutoSuggestBoxPresenter",
										Margin = new Thickness(12.0, 0.0, 12.0, 0.0),
										MinWidth = 48.0,
										IsTabStop = false,
										HorizontalContentAlignment = HorizontalAlignment.Stretch,
										VerticalContentAlignment = VerticalAlignment.Center
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c19)
									{
										nameScope.RegisterName("TopPaneAutoSuggestBoxPresenter", c19);
										TopPaneAutoSuggestBoxPresenter = c19;
										c19.CreationComplete();
									}) }
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c20)
								{
									nameScope.RegisterName("TopPaneAutoSuggestArea", c20);
									TopPaneAutoSuggestArea = c20;
									ResourceResolverSingleton.Instance.ApplyResource(c20, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
									Grid.SetColumn(c20, 6);
									_component_2 = c20;
									c20.CreationComplete();
								}),
								(UIElement)new ContentControl
								{
									IsParsing = true,
									Name = "PaneFooterOnTopPane",
									IsTabStop = false,
									VerticalContentAlignment = VerticalAlignment.Stretch,
									HorizontalContentAlignment = HorizontalAlignment.Stretch
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c21)
								{
									nameScope.RegisterName("PaneFooterOnTopPane", c21);
									PaneFooterOnTopPane = c21;
									Grid.SetColumn(c21, 7);
									c21.CreationComplete();
								}),
								(UIElement)new NavigationViewItem
								{
									IsParsing = true,
									Name = "SettingsTopNavPaneItem",
									Icon = new SymbolIcon
									{
										Symbol = Symbol.Setting
									}
								}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewItem c22)
								{
									nameScope.RegisterName("SettingsTopNavPaneItem", c22);
									SettingsTopNavPaneItem = c22;
									ResourceResolverSingleton.Instance.ApplyResource(c22, FrameworkElement.StyleProperty, "NavigationViewSettingsItemStyleWhenOnTopPane", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
									Grid.SetColumn(c22, 8);
									_component_3 = c22;
									c22.CreationComplete();
								})
							}
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c23)
						{
							nameScope.RegisterName("TopNavGrid", c23);
							TopNavGrid = c23;
							ResourceResolverSingleton.Instance.ApplyResource(c23, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
							c23.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.TopPaneVisibility"
							});
							_component_4 = c23;
							c23.CreationComplete();
						}),
						(UIElement)new Border
						{
							IsParsing = true,
							Name = "TopNavContentOverlayAreaGrid"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Border c24)
						{
							nameScope.RegisterName("TopNavContentOverlayAreaGrid", c24);
							TopNavContentOverlayAreaGrid = c24;
							c24.SetBinding(Border.ChildProperty, new Binding
							{
								Path = "ContentOverlay",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							c24.CreationComplete();
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(StackPanel c25)
				{
					nameScope.RegisterName("TopNavArea", c25);
					TopNavArea = c25;
					ResourceResolverSingleton.Instance.ApplyResource(c25, FrameworkElement.BackgroundProperty, "NavigationViewTopPaneBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
					Grid.SetRow(c25, 0);
					Canvas.SetZIndex(c25, 1.0);
					_component_5 = c25;
					c25.CreationComplete();
				}),
				(UIElement)new SplitView
				{
					IsParsing = true,
					Name = "RootSplitView",
					DisplayMode = SplitViewDisplayMode.Inline,
					IsTabStop = false,
					Pane = new Grid
					{
						IsParsing = true,
						Name = "PaneContentGrid",
						RowDefinitions = 
						{
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(0.0, GridUnitType.Pixel)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(RowDefinition c28)
							{
								nameScope.RegisterName("PaneContentGridToggleButtonRow", c28);
								PaneContentGridToggleButtonRow = c28;
							}),
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(8.0, GridUnitType.Pixel)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Star)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(8.0, GridUnitType.Pixel)
							}
						},
						Children = 
						{
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "ContentPaneTopPadding"
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c36)
							{
								nameScope.RegisterName("ContentPaneTopPadding", c36);
								ContentPaneTopPadding = c36;
								c36.SetBinding(FrameworkElement.HeightProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.TopPadding"
								});
								c36.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								ColumnDefinitions = 
								{
									new ColumnDefinition
									{
										Width = new GridLength(1.0, GridUnitType.Auto)
									},
									new ColumnDefinition
									{
										Width = new GridLength(1.0, GridUnitType.Star)
									}
								},
								Children = 
								{
									(UIElement)new TextBlock
									{
										IsParsing = true,
										Name = "PaneTitleTextBlock",
										HorizontalAlignment = HorizontalAlignment.Left,
										VerticalAlignment = VerticalAlignment.Center
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(TextBlock c39)
									{
										nameScope.RegisterName("PaneTitleTextBlock", c39);
										PaneTitleTextBlock = c39;
										Grid.SetColumn(c39, 0);
										c39.SetBinding(TextBlock.TextProperty, new Binding
										{
											Path = "PaneTitle",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										ResourceResolverSingleton.Instance.ApplyResource(c39, FrameworkElement.StyleProperty, "NavigationViewItemHeaderTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
										_component_6 = c39;
										c39.CreationComplete();
									}),
									(UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "PaneHeaderContentBorder",
										IsTabStop = false,
										VerticalContentAlignment = VerticalAlignment.Stretch,
										HorizontalContentAlignment = HorizontalAlignment.Stretch
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c40)
									{
										nameScope.RegisterName("PaneHeaderContentBorder", c40);
										PaneHeaderContentBorder = c40;
										Grid.SetColumn(c40, 1);
										c40.CreationComplete();
									})
								}
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c41)
							{
								Grid.SetRow(c41, 2);
								ResourceResolverSingleton.Instance.ApplyResource(c41, FrameworkElement.HeightProperty, "PaneToggleButtonHeight", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
								_component_7 = c41;
								c41.CreationComplete();
							}),
							(UIElement)new Grid
							{
								IsParsing = true,
								Name = "AutoSuggestArea",
								VerticalAlignment = VerticalAlignment.Center,
								Children = 
								{
									(UIElement)new ContentControl
									{
										IsParsing = true,
										Name = "PaneAutoSuggestBoxPresenter",
										IsTabStop = false,
										HorizontalContentAlignment = HorizontalAlignment.Stretch,
										VerticalContentAlignment = VerticalAlignment.Center
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c42)
									{
										nameScope.RegisterName("PaneAutoSuggestBoxPresenter", c42);
										PaneAutoSuggestBoxPresenter = c42;
										ResourceResolverSingleton.Instance.ApplyResource(c42, FrameworkElement.MarginProperty, "NavigationViewAutoSuggestBoxMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
										_component_8 = c42;
										c42.CreationComplete();
									}),
									(UIElement)new Button
									{
										IsParsing = true,
										Name = "PaneAutoSuggestButton",
										Visibility = Visibility.Collapsed
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Button c43)
									{
										nameScope.RegisterName("PaneAutoSuggestButton", c43);
										PaneAutoSuggestButton = c43;
										ResourceResolverSingleton.Instance.ApplyResource(c43, FrameworkElement.StyleProperty, "LegacyNavigationViewPaneSearchButtonStyle", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
										c43.SetBinding(FrameworkElement.WidthProperty, new Binding
										{
											Path = "CompactPaneLength",
											RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
										});
										_component_9 = c43;
										c43.CreationComplete();
									})
								}
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c44)
							{
								nameScope.RegisterName("AutoSuggestArea", c44);
								AutoSuggestArea = c44;
								Grid.SetRow(c44, 3);
								ResourceResolverSingleton.Instance.ApplyResource(c44, FrameworkElement.HeightProperty, "NavigationViewTopPaneHeight", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
								_component_10 = c44;
								c44.CreationComplete();
							}),
							(UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "PaneCustomContentBorder",
								IsTabStop = false,
								VerticalContentAlignment = VerticalAlignment.Stretch,
								HorizontalContentAlignment = HorizontalAlignment.Stretch
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c45)
							{
								nameScope.RegisterName("PaneCustomContentBorder", c45);
								PaneCustomContentBorder = c45;
								Grid.SetRow(c45, 4);
								c45.CreationComplete();
							}),
							(UIElement)new NavigationViewList
							{
								IsParsing = true,
								Name = "MenuItemsHost",
								Margin = new Thickness(0.0, 0.0, 0.0, 20.0),
								SelectionMode = ListViewSelectionMode.Single,
								IsItemClickEnabled = true,
								HorizontalAlignment = HorizontalAlignment.Stretch
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewList c46)
							{
								nameScope.RegisterName("MenuItemsHost", c46);
								MenuItemsHost = c46;
								Grid.SetRow(c46, 6);
								c46.SetBinding(Selector.SelectedItemProperty, new Binding
								{
									Path = "SelectedItem",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c46.SetBinding(ItemsControl.ItemTemplateProperty, new Binding
								{
									Path = "MenuItemTemplate",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c46.SetBinding(ItemsControl.ItemTemplateSelectorProperty, new Binding
								{
									Path = "MenuItemTemplateSelector",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c46.SetBinding(ItemsControl.ItemContainerStyleProperty, new Binding
								{
									Path = "MenuItemContainerStyle",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c46.SetBinding(ItemsControl.ItemContainerStyleSelectorProperty, new Binding
								{
									Path = "MenuItemContainerStyleSelector",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c46.SetBinding(ListViewBase.SingleSelectionFollowsFocusProperty, new Binding
								{
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
									Path = "TemplateSettings.SingleSelectionFollowsFocus"
								});
								c46.CreationComplete();
							}),
							(UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "FooterContentBorder",
								IsTabStop = false,
								VerticalContentAlignment = VerticalAlignment.Stretch,
								HorizontalContentAlignment = HorizontalAlignment.Stretch
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c47)
							{
								nameScope.RegisterName("FooterContentBorder", c47);
								FooterContentBorder = c47;
								Grid.SetRow(c47, 7);
								c47.CreationComplete();
							}),
							(UIElement)new NavigationViewItem
							{
								IsParsing = true,
								Name = "SettingsNavPaneItem",
								Icon = new SymbolIcon
								{
									Symbol = Symbol.Setting
								}
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewItem c48)
							{
								nameScope.RegisterName("SettingsNavPaneItem", c48);
								SettingsNavPaneItem = c48;
								Grid.SetRow(c48, 8);
								c48.CreationComplete();
							})
						}
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c49)
					{
						nameScope.RegisterName("PaneContentGrid", c49);
						PaneContentGrid = c49;
						InternalVisibleBoundsPadding.SetPaddingMask(c49, InternalVisibleBoundsPadding.PaddingMask.All);
						c49.SetBinding(UIElement.VisibilityProperty, new Binding
						{
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
							Path = "TemplateSettings.LeftPaneVisibility"
						});
						c49.CreationComplete();
					}),
					Content = new Grid
					{
						IsParsing = true,
						Name = "ContentGrid",
						RowDefinitions = 
						{
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Auto)
							},
							new RowDefinition
							{
								Height = new GridLength(1.0, GridUnitType.Star)
							}
						},
						Children = 
						{
							(UIElement)new ContentControl
							{
								IsParsing = true,
								Name = "HeaderContent",
								IsTabStop = false,
								VerticalContentAlignment = VerticalAlignment.Stretch,
								HorizontalContentAlignment = HorizontalAlignment.Stretch
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentControl c52)
							{
								nameScope.RegisterName("HeaderContent", c52);
								HeaderContent = c52;
								ResourceResolverSingleton.Instance.ApplyResource(c52, FrameworkElement.MinHeightProperty, "PaneToggleButtonHeight", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
								c52.SetBinding(ContentControl.ContentProperty, new Binding
								{
									Path = "Header",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c52.SetBinding(ContentControl.ContentTemplateProperty, new Binding
								{
									Path = "HeaderTemplate",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								ResourceResolverSingleton.Instance.ApplyResource(c52, FrameworkElement.StyleProperty, "NavigationViewTitleHeaderContentControlTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
								_component_11 = c52;
								c52.CreationComplete();
							}),
							(UIElement)new ContentPresenter
							{
								IsParsing = true
							}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ContentPresenter c53)
							{
								AutomationProperties.SetLandmarkType(c53, AutomationLandmarkType.Main);
								Grid.SetRow(c53, 1);
								c53.SetBinding(ContentPresenter.ContentProperty, new Binding
								{
									Path = "Content",
									RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
								});
								c53.CreationComplete();
							})
						}
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c54)
					{
						nameScope.RegisterName("ContentGrid", c54);
						ContentGrid = c54;
						c54.CreationComplete();
					})
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(SplitView c55)
				{
					nameScope.RegisterName("RootSplitView", c55);
					RootSplitView = c55;
					c55.SetBinding(FrameworkElement.BackgroundProperty, new Binding
					{
						Path = "Background",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c55.SetBinding(SplitView.CompactPaneLengthProperty, new Binding
					{
						Path = "CompactPaneLength",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					c55.SetBinding(SplitView.IsPaneOpenProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "IsPaneOpen",
						Mode = BindingMode.TwoWay
					});
					c55.SetBinding(SplitView.OpenPaneLengthProperty, new Binding
					{
						Path = "OpenPaneLength",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					ResourceResolverSingleton.Instance.ApplyResource(c55, SplitView.PaneBackgroundProperty, "NavigationViewDefaultPaneBackground", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
					Grid.SetRow(c55, 1);
					_component_12 = c55;
					c55.CreationComplete();
				})
			}
		}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c56)
		{
			c56.CreationComplete();
		}));
		grid.Children.Add(new Grid
		{
			IsParsing = true,
			Name = "PaneToggleButtonGrid",
			Margin = new Thickness(0.0, 0.0, 0.0, 8.0),
			HorizontalAlignment = HorizontalAlignment.Left,
			VerticalAlignment = VerticalAlignment.Top,
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				},
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Auto)
				}
			},
			Children = 
			{
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "TogglePaneTopPadding"
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c59)
				{
					nameScope.RegisterName("TogglePaneTopPadding", c59);
					TogglePaneTopPadding = c59;
					c59.SetBinding(FrameworkElement.HeightProperty, new Binding
					{
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
						Path = "TemplateSettings.TopPadding"
					});
					c59.CreationComplete();
				}),
				(UIElement)new Grid
				{
					IsParsing = true,
					Name = "ButtonHolderGrid",
					Children = 
					{
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "NavigationViewBackButton",
							VerticalAlignment = VerticalAlignment.Top
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Button c60)
						{
							nameScope.RegisterName("NavigationViewBackButton", c60);
							NavigationViewBackButton = c60;
							ResourceResolverSingleton.Instance.ApplyResource(c60, FrameworkElement.StyleProperty, "NavigationBackButtonNormalStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
							c60.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.BackButtonVisibility"
							});
							c60.SetBinding(Control.IsEnabledProperty, new Binding
							{
								Path = "IsBackEnabled",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							_component_13 = c60;
							c60.CreationComplete();
						}),
						(UIElement)new Button
						{
							IsParsing = true,
							Name = "TogglePaneButton",
							VerticalAlignment = VerticalAlignment.Top
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Button c61)
						{
							nameScope.RegisterName("TogglePaneButton", c61);
							TogglePaneButton = c61;
							c61.SetBinding(FrameworkElement.StyleProperty, new Binding
							{
								Path = "PaneToggleButtonStyle",
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
							});
							AutomationProperties.SetLandmarkType(c61, AutomationLandmarkType.Navigation);
							c61.SetBinding(UIElement.VisibilityProperty, new Binding
							{
								RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent),
								Path = "TemplateSettings.PaneToggleButtonVisibility"
							});
							c61.CreationComplete();
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c62)
				{
					nameScope.RegisterName("ButtonHolderGrid", c62);
					ButtonHolderGrid = c62;
					Grid.SetRow(c62, 1);
					c62.CreationComplete();
				})
			}
		}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c63)
		{
			nameScope.RegisterName("PaneToggleButtonGrid", c63);
			PaneToggleButtonGrid = c63;
			Canvas.SetZIndex(c63, 100.0);
			InternalVisibleBoundsPadding.SetPaddingMask(c63, InternalVisibleBoundsPadding.PaddingMask.Top | InternalVisibleBoundsPadding.PaddingMask.Left);
			c63.CreationComplete();
		}));
		uIElement = grid.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c64)
		{
			nameScope.RegisterName("RootGrid", c64);
			RootGrid = c64;
			VisualStateManager.SetVisualStateGroups(c64, new VisualStateGroup[10]
			{
				new VisualStateGroup
				{
					Name = "DisplayModeGroup",
					States = 
					{
						new VisualState
						{
							Name = "Compact"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c65)
						{
							nameScope.RegisterName("Compact", c65);
							Compact = c65;
						}),
						new VisualState
						{
							Name = "Expanded"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c66)
						{
							nameScope.RegisterName("Expanded", c66);
							Expanded = c66;
							MarkupHelper.SetVisualStateLazy(c66, delegate
							{
								c66.Name = "Expanded";
								c66.Setters.Add(new Setter(new TargetPropertyPath(_RootSplitViewSubject, (PropertyPath)"PaneBackground"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewExpandedPaneBackground", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("NavigationViewExpandedPaneBackground", GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						}),
						new VisualState
						{
							Name = "Minimal"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c67)
						{
							nameScope.RegisterName("Minimal", c67);
							Minimal = c67;
							MarkupHelper.SetVisualStateLazy(c67, delegate
							{
								c67.Name = "Minimal";
								c67.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Margin"), "48,5,0,0"));
							});
						}),
						new VisualState
						{
							Name = "MinimalWithBackButton"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c68)
						{
							nameScope.RegisterName("MinimalWithBackButton", c68);
							MinimalWithBackButton = c68;
							MarkupHelper.SetVisualStateLazy(c68, delegate
							{
								c68.Name = "MinimalWithBackButton";
								c68.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Margin"), "104,5,0,0"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c69)
				{
					nameScope.RegisterName("DisplayModeGroup", c69);
					DisplayModeGroup = c69;
				}),
				new VisualStateGroup
				{
					Name = "TogglePaneGroup",
					States = 
					{
						new VisualState
						{
							Name = "TogglePaneButtonVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c70)
						{
							nameScope.RegisterName("TogglePaneButtonVisible", c70);
							TogglePaneButtonVisible = c70;
						}),
						new VisualState
						{
							Name = "TogglePaneButtonCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c71)
						{
							nameScope.RegisterName("TogglePaneButtonCollapsed", c71);
							TogglePaneButtonCollapsed = c71;
							MarkupHelper.SetVisualStateLazy(c71, delegate
							{
								c71.Name = "TogglePaneButtonCollapsed";
								c71.Setters.Add(new Setter(new TargetPropertyPath(_PaneContentGridToggleButtonRowSubject, (PropertyPath)"Height"), "4"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c72)
				{
					nameScope.RegisterName("TogglePaneGroup", c72);
					TogglePaneGroup = c72;
				}),
				new VisualStateGroup
				{
					Name = "HeaderGroup",
					States = 
					{
						new VisualState
						{
							Name = "HeaderVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c73)
						{
							nameScope.RegisterName("HeaderVisible", c73);
							HeaderVisible = c73;
						}),
						new VisualState
						{
							Name = "HeaderCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c74)
						{
							nameScope.RegisterName("HeaderCollapsed", c74);
							HeaderCollapsed = c74;
							MarkupHelper.SetVisualStateLazy(c74, delegate
							{
								c74.Name = "HeaderCollapsed";
								c74.Setters.Add(new Setter(new TargetPropertyPath(_HeaderContentSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c75)
				{
					nameScope.RegisterName("HeaderGroup", c75);
					HeaderGroup = c75;
				}),
				new VisualStateGroup
				{
					Name = "SettingsGroup",
					States = 
					{
						new VisualState
						{
							Name = "SettingsVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c76)
						{
							nameScope.RegisterName("SettingsVisible", c76);
							SettingsVisible = c76;
						}),
						new VisualState
						{
							Name = "SettingsCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c77)
						{
							nameScope.RegisterName("SettingsCollapsed", c77);
							SettingsCollapsed = c77;
							MarkupHelper.SetVisualStateLazy(c77, delegate
							{
								c77.Name = "SettingsCollapsed";
								c77.Setters.Add(new Setter(new TargetPropertyPath(_SettingsNavPaneItemSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c77.Setters.Add(new Setter(new TargetPropertyPath(_SettingsTopNavPaneItemSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c78)
				{
					nameScope.RegisterName("SettingsGroup", c78);
					SettingsGroup = c78;
				}),
				new VisualStateGroup
				{
					Name = "AutoSuggestGroup",
					States = 
					{
						new VisualState
						{
							Name = "AutoSuggestBoxVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c79)
						{
							nameScope.RegisterName("AutoSuggestBoxVisible", c79);
							AutoSuggestBoxVisible = c79;
						}),
						new VisualState
						{
							Name = "AutoSuggestBoxCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c80)
						{
							nameScope.RegisterName("AutoSuggestBoxCollapsed", c80);
							AutoSuggestBoxCollapsed = c80;
							MarkupHelper.SetVisualStateLazy(c80, delegate
							{
								c80.Name = "AutoSuggestBoxCollapsed";
								c80.Setters.Add(new Setter(new TargetPropertyPath(_AutoSuggestAreaSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c80.Setters.Add(new Setter(new TargetPropertyPath(_TopPaneAutoSuggestAreaSubject, (PropertyPath)"Visibility"), "Collapsed"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c81)
				{
					nameScope.RegisterName("AutoSuggestGroup", c81);
					AutoSuggestGroup = c81;
				}),
				new VisualStateGroup
				{
					Name = "PaneStateGroup",
					States = 
					{
						new VisualState
						{
							Name = "NotClosedCompact"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c82)
						{
							nameScope.RegisterName("NotClosedCompact", c82);
							NotClosedCompact = c82;
						}),
						new VisualState
						{
							Name = "ClosedCompact"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c83)
						{
							nameScope.RegisterName("ClosedCompact", c83);
							ClosedCompact = c83;
							MarkupHelper.SetVisualStateLazy(c83, delegate
							{
								c83.Name = "ClosedCompact";
								c83.Setters.Add(new Setter(new TargetPropertyPath(_PaneAutoSuggestBoxPresenterSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c83.Setters.Add(new Setter(new TargetPropertyPath(_PaneAutoSuggestButtonSubject, (PropertyPath)"Visibility"), "Visible"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c84)
				{
					nameScope.RegisterName("PaneStateGroup", c84);
					PaneStateGroup = c84;
				}),
				new VisualStateGroup
				{
					Name = "PaneStateListSizeGroup",
					States = 
					{
						new VisualState
						{
							Name = "ListSizeFull"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c85)
						{
							nameScope.RegisterName("ListSizeFull", c85);
							ListSizeFull = c85;
						}),
						new VisualState
						{
							Name = "ListSizeCompact"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c86)
						{
							nameScope.RegisterName("ListSizeCompact", c86);
							ListSizeCompact = c86;
							MarkupHelper.SetVisualStateLazy(c86, delegate
							{
								c86.Name = "ListSizeCompact";
								c86.Setters.Add(new Setter(new TargetPropertyPath(_MenuItemsHostSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_MenuItemsHostSubject, (PropertyPath)"Width"), "40"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_SettingsNavPaneItemSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_SettingsNavPaneItemSubject, (PropertyPath)"Width"), "40"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_PaneTitleTextBlockSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_PaneHeaderContentBorderSubject, (PropertyPath)"Visibility"), "Collapsed"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_PaneCustomContentBorderSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_PaneCustomContentBorderSubject, (PropertyPath)"Width"), "40"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_FooterContentBorderSubject, (PropertyPath)"HorizontalAlignment"), "Left"));
								c86.Setters.Add(new Setter(new TargetPropertyPath(_FooterContentBorderSubject, (PropertyPath)"Width"), "40"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c87)
				{
					nameScope.RegisterName("PaneStateListSizeGroup", c87);
					PaneStateListSizeGroup = c87;
				}),
				new VisualStateGroup
				{
					Name = "TitleBarVisibilityGroup",
					States = 
					{
						new VisualState
						{
							Name = "TitleBarVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c88)
						{
							nameScope.RegisterName("TitleBarVisible", c88);
							TitleBarVisible = c88;
						}),
						new VisualState
						{
							Name = "TitleBarCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c89)
						{
							nameScope.RegisterName("TitleBarCollapsed", c89);
							TitleBarCollapsed = c89;
							MarkupHelper.SetVisualStateLazy(c89, delegate
							{
								c89.Name = "TitleBarCollapsed";
								c89.Setters.Add(new Setter(new TargetPropertyPath(_PaneContentGridSubject, (PropertyPath)"Margin"), "0,32,0,0"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c90)
				{
					nameScope.RegisterName("TitleBarVisibilityGroup", c90);
					TitleBarVisibilityGroup = c90;
				}),
				new VisualStateGroup
				{
					Name = "OverflowLabelGroup",
					States = 
					{
						new VisualState
						{
							Name = "OverflowButtonWithLabel"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c91)
						{
							nameScope.RegisterName("OverflowButtonWithLabel", c91);
							OverflowButtonWithLabel = c91;
						}),
						new VisualState
						{
							Name = "OverflowButtonNoLabel"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c92)
						{
							nameScope.RegisterName("OverflowButtonNoLabel", c92);
							OverflowButtonNoLabel = c92;
							MarkupHelper.SetVisualStateLazy(c92, delegate
							{
								c92.Name = "OverflowButtonNoLabel";
								c92.Setters.Add(new Setter(new TargetPropertyPath(_TopNavOverflowButtonSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("LegacyNavigationViewOverflowButtonNoLabelStyleWhenPaneOnTop", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)).ApplyThemeResourceUpdateValues("LegacyNavigationViewOverflowButtonNoLabelStyleWhenPaneOnTop", GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_, isTheme: true, isHotReload: false));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c93)
				{
					nameScope.RegisterName("OverflowLabelGroup", c93);
					OverflowLabelGroup = c93;
				}),
				new VisualStateGroup
				{
					Name = "BackButtonGroup",
					States = 
					{
						new VisualState
						{
							Name = "BackButtonVisible"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c94)
						{
							nameScope.RegisterName("BackButtonVisible", c94);
							BackButtonVisible = c94;
						}),
						new VisualState
						{
							Name = "BackButtonCollapsed"
						}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c95)
						{
							nameScope.RegisterName("BackButtonCollapsed", c95);
							BackButtonCollapsed = c95;
							MarkupHelper.SetVisualStateLazy(c95, delegate
							{
								c95.Name = "BackButtonCollapsed";
								c95.Setters.Add(new Setter(new TargetPropertyPath(_BackButtonPlaceholderOnTopNavSubject, (PropertyPath)"Width"), "0"));
							});
						})
					}
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c96)
				{
					nameScope.RegisterName("BackButtonGroup", c96);
					BackButtonGroup = c96;
				})
			});
			c64.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
				_component_2.UpdateResourceBindings();
				_component_3.UpdateResourceBindings();
				_component_4.UpdateResourceBindings();
				_component_5.UpdateResourceBindings();
				_component_6.UpdateResourceBindings();
				_component_7.UpdateResourceBindings();
				_component_8.UpdateResourceBindings();
				_component_9.UpdateResourceBindings();
				_component_10.UpdateResourceBindings();
				_component_11.UpdateResourceBindings();
				_component_12.UpdateResourceBindings();
				_component_13.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC1
{
	private ElementNameSubject _NavigationViewItemPresenterSubject = new ElementNameSubject();

	private ElementNameSubject _OnLeftNavigationSubject = new ElementNameSubject();

	private ElementNameSubject _OnLeftNavigationRevealSubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationPrimarySubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationPrimaryRevealSubject = new ElementNameSubject();

	private ElementNameSubject _OnTopNavigationOverflowSubject = new ElementNameSubject();

	private ElementNameSubject _ItemOnNavigationViewListPositionStatesSubject = new ElementNameSubject();

	private NavigationViewItemPresenter NavigationViewItemPresenter
	{
		get
		{
			return (NavigationViewItemPresenter)_NavigationViewItemPresenterSubject.ElementInstance;
		}
		set
		{
			_NavigationViewItemPresenterSubject.ElementInstance = value;
		}
	}

	private VisualState OnLeftNavigation
	{
		get
		{
			return (VisualState)_OnLeftNavigationSubject.ElementInstance;
		}
		set
		{
			_OnLeftNavigationSubject.ElementInstance = value;
		}
	}

	private VisualState OnLeftNavigationReveal
	{
		get
		{
			return (VisualState)_OnLeftNavigationRevealSubject.ElementInstance;
		}
		set
		{
			_OnLeftNavigationRevealSubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationPrimary
	{
		get
		{
			return (VisualState)_OnTopNavigationPrimarySubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationPrimarySubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationPrimaryReveal
	{
		get
		{
			return (VisualState)_OnTopNavigationPrimaryRevealSubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationPrimaryRevealSubject.ElementInstance = value;
		}
	}

	private VisualState OnTopNavigationOverflow
	{
		get
		{
			return (VisualState)_OnTopNavigationOverflowSubject.ElementInstance;
		}
		set
		{
			_OnTopNavigationOverflowSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ItemOnNavigationViewListPositionStates
	{
		get
		{
			return (VisualStateGroup)_ItemOnNavigationViewListPositionStatesSubject.ElementInstance;
		}
		set
		{
			_ItemOnNavigationViewListPositionStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_369)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new NavigationViewItemPresenter
		{
			IsParsing = true,
			Name = "NavigationViewItemPresenter",
			IsTabStop = false
		}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(NavigationViewItemPresenter c98)
		{
			nameScope.RegisterName("NavigationViewItemPresenter", c98);
			NavigationViewItemPresenter = c98;
			c98.SetBinding(NavigationViewItemPresenter.IconProperty, new Binding
			{
				Path = "Icon",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(ContentControl.ContentTransitionsProperty, new Binding
			{
				Path = "ContentTransitions",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(ContentControl.ContentTemplateProperty, new Binding
			{
				Path = "ContentTemplate",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(FrameworkElement.MarginProperty, new Binding
			{
				Path = "Margin",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.PaddingProperty, new Binding
			{
				Path = "Padding",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.ForegroundProperty, new Binding
			{
				Path = "Foreground",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.BorderBrushProperty, new Binding
			{
				Path = "BorderBrush",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.BorderThicknessProperty, new Binding
			{
				Path = "BorderThickness",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.UseSystemFocusVisualsProperty, new Binding
			{
				Path = "UseSystemFocusVisuals",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding
			{
				Path = "VerticalAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding
			{
				Path = "HorizontalAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.VerticalContentAlignmentProperty, new Binding
			{
				Path = "VerticalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding
			{
				Path = "HorizontalContentAlignment",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(ContentControl.ContentTemplateSelectorProperty, new Binding
			{
				Path = "ContentTemplateSelector",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			c98.SetBinding(ContentControl.ContentProperty, new Binding
			{
				Path = "Content",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c98, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "ItemOnNavigationViewListPositionStates",
				States = 
				{
					new VisualState
					{
						Name = "OnLeftNavigation"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c99)
					{
						nameScope.RegisterName("OnLeftNavigation", c99);
						OnLeftNavigation = c99;
						MarkupHelper.SetVisualStateLazy(c99, delegate
						{
							c99.Name = "OnLeftNavigation";
							c99.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemPresenterStyleWhenOnLeftPane", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnLeftNavigationReveal"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c100)
					{
						nameScope.RegisterName("OnLeftNavigationReveal", c100);
						OnLeftNavigationReveal = c100;
						MarkupHelper.SetVisualStateLazy(c100, delegate
						{
							c100.Name = "OnLeftNavigationReveal";
							c100.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemPresenterStyleWhenOnLeftPaneWithRevealFocus", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationPrimary"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c101)
					{
						nameScope.RegisterName("OnTopNavigationPrimary", c101);
						OnTopNavigationPrimary = c101;
						MarkupHelper.SetVisualStateLazy(c101, delegate
						{
							c101.Name = "OnTopNavigationPrimary";
							c101.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemPresenterStyleWhenOnTopPane", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationPrimaryReveal"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c102)
					{
						nameScope.RegisterName("OnTopNavigationPrimaryReveal", c102);
						OnTopNavigationPrimaryReveal = c102;
						MarkupHelper.SetVisualStateLazy(c102, delegate
						{
							c102.Name = "OnTopNavigationPrimaryReveal";
							c102.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemPresenterStyleWhenOnTopPaneWithRevealFocus", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)));
						});
					}),
					new VisualState
					{
						Name = "OnTopNavigationOverflow"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c103)
					{
						nameScope.RegisterName("OnTopNavigationOverflow", c103);
						OnTopNavigationOverflow = c103;
						MarkupHelper.SetVisualStateLazy(c103, delegate
						{
							c103.Name = "OnTopNavigationOverflow";
							c103.Setters.Add(new Setter(new TargetPropertyPath(_NavigationViewItemPresenterSubject, (PropertyPath)"Style"), ResourceResolverSingleton.Instance.ResolveResourceStatic("NavigationViewItemPresenterStyleWhenOnTopPaneOverflow", typeof(object), GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_)));
						});
					})
				}
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c104)
			{
				nameScope.RegisterName("ItemOnNavigationViewListPositionStates", c104);
				ItemOnNavigationViewListPositionStates = c104;
			}) });
			c98.CreationComplete();
		});
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC2
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ComponentHolder _component_1_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _HeaderTextSubject = new ElementNameSubject();

	private ElementNameSubject _InnerHeaderGridSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderTextVisibleSubject = new ElementNameSubject();

	private ElementNameSubject _HeaderTextCollapsedSubject = new ElementNameSubject();

	private ElementNameSubject _PaneStatesSubject = new ElementNameSubject();

	private TextBlock _component_0
	{
		get
		{
			return (TextBlock)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Grid _component_1
	{
		get
		{
			return (Grid)_component_1_Holder.Instance;
		}
		set
		{
			_component_1_Holder.Instance = value;
		}
	}

	private TextBlock HeaderText
	{
		get
		{
			return (TextBlock)_HeaderTextSubject.ElementInstance;
		}
		set
		{
			_HeaderTextSubject.ElementInstance = value;
		}
	}

	private Grid InnerHeaderGrid
	{
		get
		{
			return (Grid)_InnerHeaderGridSubject.ElementInstance;
		}
		set
		{
			_InnerHeaderGridSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderTextVisible
	{
		get
		{
			return (VisualState)_HeaderTextVisibleSubject.ElementInstance;
		}
		set
		{
			_HeaderTextVisibleSubject.ElementInstance = value;
		}
	}

	private VisualState HeaderTextCollapsed
	{
		get
		{
			return (VisualState)_HeaderTextCollapsedSubject.ElementInstance;
		}
		set
		{
			_HeaderTextCollapsedSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup PaneStates
	{
		get
		{
			return (VisualStateGroup)_PaneStatesSubject.ElementInstance;
		}
		set
		{
			_PaneStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_375)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Children = { (UIElement)new Grid
			{
				IsParsing = true,
				Name = "InnerHeaderGrid",
				Height = 40.0,
				HorizontalAlignment = HorizontalAlignment.Left,
				Children = { (UIElement)new TextBlock
				{
					IsParsing = true,
					Name = "HeaderText",
					VerticalAlignment = VerticalAlignment.Center,
					Margin = new Thickness(0.0, -1.0, 0.0, -1.0),
					TextWrapping = TextWrapping.NoWrap
				}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(TextBlock c105)
				{
					nameScope.RegisterName("HeaderText", c105);
					HeaderText = c105;
					ResourceResolverSingleton.Instance.ApplyResource(c105, FrameworkElement.StyleProperty, "NavigationViewItemHeaderTextStyle", isThemeResourceExtension: false, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
					c105.SetBinding(TextBlock.TextProperty, new Binding
					{
						Path = "Content",
						RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
					});
					_component_0 = c105;
					c105.CreationComplete();
				}) }
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c106)
			{
				nameScope.RegisterName("InnerHeaderGrid", c106);
				InnerHeaderGrid = c106;
				ResourceResolverSingleton.Instance.ApplyResource(c106, FrameworkElement.MarginProperty, "NavigationViewItemInnerHeaderMargin", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
				_component_1 = c106;
				c106.CreationComplete();
			}) }
		}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c107)
		{
			VisualStateManager.SetVisualStateGroups(c107, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "PaneStates",
				Transitions = 
				{
					new VisualTransition
					{
						From = "HeaderTextCollapsed",
						To = "HeaderTextVisible"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualTransition c108)
					{
						MarkupHelper.SetVisualTransitionLazy(c108, delegate
						{
							c108.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "40"
										} }
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ObjectAnimationUsingKeyFrames c110)
									{
										Storyboard.SetTargetName(c110, "InnerHeaderGrid");
										Storyboard.SetTarget(c110, _InnerHeaderGridSubject);
										Storyboard.SetTargetProperty(c110, "Height");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "Visible"
										} }
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ObjectAnimationUsingKeyFrames c112)
									{
										Storyboard.SetTargetName(c112, "HeaderText");
										Storyboard.SetTarget(c112, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c112, "Visibility");
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 0.0
											},
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(1000000L),
												Value = 0.0
											},
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(2000000L),
												KeySpline = "0.0,0.35 0.15,1.0",
												Value = 1.0
											}
										}
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(DoubleAnimationUsingKeyFrames c116)
									{
										Storyboard.SetTargetName(c116, "HeaderText");
										Storyboard.SetTarget(c116, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c116, "Opacity");
									})
								}
							};
						});
					}),
					new VisualTransition
					{
						From = "HeaderTextVisible",
						To = "HeaderTextCollapsed"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualTransition c117)
					{
						MarkupHelper.SetVisualTransitionLazy(c117, delegate
						{
							c117.Storyboard = new Storyboard
							{
								Children = 
								{
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(0L),
											Value = "20"
										} }
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ObjectAnimationUsingKeyFrames c119)
									{
										Storyboard.SetTargetName(c119, "InnerHeaderGrid");
										Storyboard.SetTarget(c119, _InnerHeaderGridSubject);
										Storyboard.SetTargetProperty(c119, "Height");
									}),
									(Timeline)new ObjectAnimationUsingKeyFrames
									{
										KeyFrames = { (ObjectKeyFrame)new DiscreteObjectKeyFrame
										{
											KeyTime = TimeSpan.FromTicks(2000000L),
											Value = "Collapsed"
										} }
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(ObjectAnimationUsingKeyFrames c121)
									{
										Storyboard.SetTargetName(c121, "HeaderText");
										Storyboard.SetTarget(c121, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c121, "Visibility");
									}),
									(Timeline)new DoubleAnimationUsingKeyFrames
									{
										KeyFrames = 
										{
											(DoubleKeyFrame)new LinearDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(0L),
												Value = 1.0
											},
											(DoubleKeyFrame)new SplineDoubleKeyFrame
											{
												KeyTime = TimeSpan.FromTicks(1000000L),
												KeySpline = "0.0,0.35 0.15,1.0",
												Value = 0.0
											}
										}
									}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(DoubleAnimationUsingKeyFrames c124)
									{
										Storyboard.SetTargetName(c124, "HeaderText");
										Storyboard.SetTarget(c124, _HeaderTextSubject);
										Storyboard.SetTargetProperty(c124, "Opacity");
									})
								}
							};
						});
					})
				},
				States = 
				{
					new VisualState
					{
						Name = "HeaderTextVisible"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c125)
					{
						nameScope.RegisterName("HeaderTextVisible", c125);
						HeaderTextVisible = c125;
					}),
					new VisualState
					{
						Name = "HeaderTextCollapsed"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c126)
					{
						nameScope.RegisterName("HeaderTextCollapsed", c126);
						HeaderTextCollapsed = c126;
						MarkupHelper.SetVisualStateLazy(c126, delegate
						{
							c126.Name = "HeaderTextCollapsed";
							c126.Setters.Add(new Setter(new TargetPropertyPath(_HeaderTextSubject, (PropertyPath)"Visibility"), "Collapsed"));
							c126.Setters.Add(new Setter(new TargetPropertyPath(_InnerHeaderGridSubject, (PropertyPath)"Height"), "20"));
						});
					})
				}
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c127)
			{
				nameScope.RegisterName("PaneStates", c127);
				PaneStates = c127;
			}) });
			c107.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
				_component_1.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
internal class _NavigationView_c5e4328787e7d47117423afa8de1d4fc_NavigationViewRDSC3
{
	private ComponentHolder _component_0_Holder = new ComponentHolder(isWeak: true);

	private ElementNameSubject _SeparatorLineSubject = new ElementNameSubject();

	private ElementNameSubject _HorizontalLineSubject = new ElementNameSubject();

	private ElementNameSubject _VerticalLineSubject = new ElementNameSubject();

	private ElementNameSubject _NavigationSeparatorLineStatesSubject = new ElementNameSubject();

	private Rectangle _component_0
	{
		get
		{
			return (Rectangle)_component_0_Holder.Instance;
		}
		set
		{
			_component_0_Holder.Instance = value;
		}
	}

	private Rectangle SeparatorLine
	{
		get
		{
			return (Rectangle)_SeparatorLineSubject.ElementInstance;
		}
		set
		{
			_SeparatorLineSubject.ElementInstance = value;
		}
	}

	private VisualState HorizontalLine
	{
		get
		{
			return (VisualState)_HorizontalLineSubject.ElementInstance;
		}
		set
		{
			_HorizontalLineSubject.ElementInstance = value;
		}
	}

	private VisualState VerticalLine
	{
		get
		{
			return (VisualState)_VerticalLineSubject.ElementInstance;
		}
		set
		{
			_VerticalLineSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup NavigationSeparatorLineStates
	{
		get
		{
			return (VisualStateGroup)_NavigationSeparatorLineStatesSubject.ElementInstance;
		}
		set
		{
			_NavigationSeparatorLineStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_382)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Children = { (UIElement)new Rectangle
			{
				IsParsing = true,
				Name = "SeparatorLine",
				Height = 1.0,
				Margin = new Thickness(16.0, 10.0)
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Rectangle c128)
			{
				nameScope.RegisterName("SeparatorLine", c128);
				SeparatorLine = c128;
				ResourceResolverSingleton.Instance.ApplyResource(c128, Shape.FillProperty, "SystemControlForegroundBaseLowBrush", isThemeResourceExtension: true, isHotReloadSupported: false, GlobalStaticResources.ResourceDictionarySingleton__39.Instance.__ParseContext_);
				_component_0 = c128;
				c128.CreationComplete();
			}) }
		}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(Grid c129)
		{
			VisualStateManager.SetVisualStateGroups(c129, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "NavigationSeparatorLineStates",
				States = 
				{
					new VisualState
					{
						Name = "HorizontalLine"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c130)
					{
						nameScope.RegisterName("HorizontalLine", c130);
						HorizontalLine = c130;
					}),
					new VisualState
					{
						Name = "VerticalLine"
					}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualState c131)
					{
						nameScope.RegisterName("VerticalLine", c131);
						VerticalLine = c131;
						MarkupHelper.SetVisualStateLazy(c131, delegate
						{
							c131.Name = "VerticalLine";
							c131.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Height"), "20"));
							c131.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Width"), "1"));
							c131.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"Margin"), "10,0"));
							c131.Setters.Add(new Setter(new TargetPropertyPath(_SeparatorLineSubject, (PropertyPath)"VerticalAlignment"), "Center"));
						});
					})
				}
			}.NavigationView_c5e4328787e7d47117423afa8de1d4fc_XamlApply(delegate(VisualStateGroup c132)
			{
				nameScope.RegisterName("NavigationSeparatorLineStates", c132);
				NavigationSeparatorLineStates = c132;
			}) });
			c129.CreationComplete();
		});
		if (uIElement is FrameworkElement frameworkElement)
		{
			frameworkElement.Loading += delegate
			{
				_component_0.UpdateResourceBindings();
			};
		}
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
