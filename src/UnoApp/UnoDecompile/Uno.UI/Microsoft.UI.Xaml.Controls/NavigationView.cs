using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Numerics;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls.AnimatedVisuals;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.System.Profile;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationView : ContentControl
{
	private enum TopNavigationViewLayoutState
	{
		Uninitialized,
		Initialized
	}

	private enum NavigationRecommendedTransitionDirection
	{
		FromOverflow,
		FromLeft,
		FromRight,
		Default
	}

	private const string c_togglePaneButtonName = "TogglePaneButton";

	private const string c_paneTitleHolderFrameworkElement = "PaneTitleHolder";

	private const string c_paneTitleFrameworkElement = "PaneTitleTextBlock";

	private const string c_rootSplitViewName = "RootSplitView";

	private const string c_menuItemsHost = "MenuItemsHost";

	private const string c_footerMenuItemsHost = "FooterMenuItemsHost";

	private const string c_selectionIndicatorName = "SelectionIndicator";

	private const string c_paneContentGridName = "PaneContentGrid";

	private const string c_rootGridName = "RootGrid";

	private const string c_contentGridName = "ContentGrid";

	private const string c_searchButtonName = "PaneAutoSuggestButton";

	private const string c_paneToggleButtonIconGridColumnName = "PaneToggleButtonIconWidthColumn";

	private const string c_togglePaneTopPadding = "TogglePaneTopPadding";

	private const string c_contentPaneTopPadding = "ContentPaneTopPadding";

	private const string c_contentLeftPadding = "ContentLeftPadding";

	private const string c_navViewBackButton = "NavigationViewBackButton";

	private const string c_navViewBackButtonToolTip = "NavigationViewBackButtonToolTip";

	private const string c_navViewCloseButton = "NavigationViewCloseButton";

	private const string c_navViewCloseButtonToolTip = "NavigationViewCloseButtonToolTip";

	private const string c_paneShadowReceiverCanvas = "PaneShadowReceiver";

	private const string c_flyoutRootGrid = "FlyoutRootGrid";

	private const string c_topNavMenuItemsHost = "TopNavMenuItemsHost";

	private const string c_topNavFooterMenuItemsHost = "TopFooterMenuItemsHost";

	private const string c_topNavOverflowButton = "TopNavOverflowButton";

	private const string c_topNavMenuItemsOverflowHost = "TopNavMenuItemsOverflowHost";

	private const string c_topNavGrid = "TopNavGrid";

	private const string c_topNavContentOverlayAreaGrid = "TopNavContentOverlayAreaGrid";

	private const string c_leftNavPaneAutoSuggestBoxPresenter = "PaneAutoSuggestBoxPresenter";

	private const string c_topNavPaneAutoSuggestBoxPresenter = "TopPaneAutoSuggestBoxPresenter";

	private const string c_paneTitlePresenter = "PaneTitlePresenter";

	private const string c_leftNavFooterContentBorder = "FooterContentBorder";

	private const string c_leftNavPaneHeaderContentBorder = "PaneHeaderContentBorder";

	private const string c_leftNavPaneCustomContentBorder = "PaneCustomContentBorder";

	private const string c_itemsContainer = "ItemsContainerGrid";

	private const string c_itemsContainerRow = "ItemsContainerRow";

	private const string c_menuItemsScrollViewer = "MenuItemsScrollViewer";

	private const string c_footerItemsScrollViewer = "FooterItemsScrollViewer";

	private const string c_paneHeaderOnTopPane = "PaneHeaderOnTopPane";

	private const string c_paneTitleOnTopPane = "PaneTitleOnTopPane";

	private const string c_paneCustomContentOnTopPane = "PaneCustomContentOnTopPane";

	private const string c_paneFooterOnTopPane = "PaneFooterOnTopPane";

	private const string c_paneHeaderCloseButtonColumn = "PaneHeaderCloseButtonColumn";

	private const string c_paneHeaderToggleButtonColumn = "PaneHeaderToggleButtonColumn";

	private const string c_paneHeaderContentBorderRow = "PaneHeaderContentBorderRow";

	private const string c_separatorVisibleStateName = "SeparatorVisible";

	private const string c_separatorCollapsedStateName = "SeparatorCollapsed";

	private const int c_backButtonHeight = 40;

	private const int c_backButtonWidth = 40;

	private const int c_paneToggleButtonHeight = 40;

	private const int c_paneToggleButtonWidth = 40;

	private const int c_toggleButtonHeightWhenShouldPreserveNavigationViewRS3Behavior = 56;

	private const int c_backButtonRowDefinition = 1;

	private const float c_paneElevationTranslationZ = 32f;

	private const int c_mainMenuBlockIndex = 0;

	private const int c_footerMenuBlockIndex = 1;

	private const string c_shadowCaster = "ShadowCaster";

	private const string c_shadowCasterEaseOutStoryboard = "ShadowCasterEaseOutStoryboard";

	private int itemNotFound = -1;

	private static Size c_infSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

	private readonly Vector2 c_frame1point1 = new Vector2(0.9f, 0.1f);

	private readonly Vector2 c_frame1point2 = new Vector2(1f, 0.2f);

	private readonly Vector2 c_frame2point1 = new Vector2(0.1f, 0.9f);

	private readonly Vector2 c_frame2point2 = new Vector2(0.2f, 1f);

	private Grid m_paneHeaderContentBorderWrapper;

	private bool m_InitialNonForcedModeUpdate = true;

	private ApplicationView m_applicationView;

	private UIViewSettings m_uiViewSettings;

	private NavigationViewItemsFactory m_navigationViewItemsFactory;

	private Button m_paneToggleButton;

	private SplitView m_rootSplitView;

	private NavigationViewItem m_settingsItem;

	private RowDefinition m_itemsContainerRow;

	private FrameworkElement m_menuItemsScrollViewer;

	private FrameworkElement m_footerItemsScrollViewer;

	private UIElement m_paneContentGrid;

	private FrameworkElement m_paneTitleHolderFrameworkElement;

	private FrameworkElement m_paneTitleFrameworkElement;

	private Button m_paneSearchButton;

	private Button m_backButton;

	private Button m_closeButton;

	private ItemsRepeater m_leftNavRepeater;

	private ItemsRepeater m_topNavRepeater;

	private ItemsRepeater m_leftNavFooterMenuRepeater;

	private ItemsRepeater m_topNavFooterMenuRepeater;

	private Button m_topNavOverflowButton;

	private ItemsRepeater m_topNavRepeaterOverflowView;

	private Grid m_topNavGrid;

	private Border m_topNavContentOverlayAreaGrid;

	private Grid m_shadowCaster;

	private Storyboard m_shadowCasterEaseOutStoryboard;

	private UIElement m_prevIndicator;

	private UIElement m_nextIndicator;

	private UIElement m_activeIndicator;

	private object m_lastSelectedItemPendingAnimationInTopNav;

	private FrameworkElement m_togglePaneTopPadding;

	private FrameworkElement m_contentPaneTopPadding;

	private FrameworkElement m_contentLeftPadding;

	private CoreApplicationViewTitleBar m_coreTitleBar;

	private ContentControl m_leftNavPaneAutoSuggestBoxPresenter;

	private ContentControl m_topNavPaneAutoSuggestBoxPresenter;

	private ContentControl m_leftNavPaneHeaderContentBorder;

	private ContentControl m_leftNavPaneCustomContentBorder;

	private ContentControl m_leftNavFooterContentBorder;

	private ContentControl m_paneHeaderOnTopPane;

	private ContentControl m_paneTitleOnTopPane;

	private ContentControl m_paneCustomContentOnTopPane;

	private ContentControl m_paneFooterOnTopPane;

	private ContentControl m_paneTitlePresenter;

	private ColumnDefinition m_paneHeaderCloseButtonColumn;

	private ColumnDefinition m_paneHeaderToggleButtonColumn;

	private RowDefinition m_paneHeaderContentBorderRow;

	private FrameworkElement m_itemsContainer;

	private NavigationViewItem m_lastItemExpandedIntoFlyout;

	private readonly SerialDisposable m_paneToggleButtonClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_paneSearchButtonClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_titleBarMetricsChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_titleBarIsVisibleChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_backButtonClickedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_closeButtonClickedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewIsPaneOpenChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewDisplayModeChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewPaneClosedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewPaneClosingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewPaneOpenedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewPaneOpeningRevoker = new SerialDisposable();

	private readonly SerialDisposable m_layoutUpdatedToken = new SerialDisposable();

	private readonly SerialDisposable m_accessKeyInvokedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_paneTitleHolderFrameworkElementSizeChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_itemsContainerSizeChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_autoSuggestBoxQuerySubmittedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavItemsRepeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavItemsRepeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavRepeaterLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavRepeaterGettingFocusRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavItemsRepeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavItemsRepeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavRepeaterLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavRepeaterGettingFocusRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavFooterMenuItemsRepeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavFooterMenuItemsRepeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavFooterMenuRepeaterLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavFooterMenuRepeaterGettingFocusRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavFooterMenuItemsRepeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavFooterMenuItemsRepeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavFooterMenuRepeaterLoadedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavFooterMenuRepeaterGettingFocusRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavOverflowItemsRepeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavOverflowItemsRepeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_selectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_childrenRequestedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_menuItemsCollectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_footerItemsCollectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavOverflowItemsCollectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_flyoutClosingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_shadowCasterEaseOutStoryboardRevoker = new SerialDisposable();

	private bool m_wasForceClosed;

	private bool m_isClosedCompact;

	private bool m_blockNextClosingEvent;

	private bool m_initialListSizeStateSet;

	private TopNavigationViewDataProvider m_topDataProvider;

	private SelectionModel m_selectionModel = new SelectionModel();

	private IList<object> m_selectionModelSource;

	private ItemsSourceView m_menuItemsSource;

	private ItemsSourceView m_footerItemsSource;

	private bool m_appliedTemplate;

	private bool m_fromOnApplyTemplate;

	private bool m_updateVisualStateForDisplayModeFromOnLoaded;

	private bool m_shouldIgnoreNextSelectionChange;

	private bool m_selectionChangeFromOverflowMenu;

	private bool m_shouldRaiseItemInvokedAfterSelection;

	private TopNavigationViewLayoutState m_topNavigationMode;

	private readonly List<NavigationViewItem> m_itemsWithRevokerObjects = new List<NavigationViewItem>();

	private float m_topNavigationRecoveryGracePeriodWidth = 5f;

	private bool m_isOpenPaneForInteraction;

	private bool m_moveTopNavOverflowItemOnFlyoutClose;

	private bool m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise;

	private bool m_OrientationChangedPendingAnimation;

	private bool m_TabKeyPrecedesFocusChange;

	private bool m_isLeftPaneTitleEmpty;

	private double m_openPaneWidth = 320.0;

	private readonly SerialDisposable m_leftNavItemsRepeaterUnoBeforeElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavItemsRepeaterUnoBeforeElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_leftNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_topNavOverflowItemsRepeaterUnoBeforeElementPreparedRevoker = new SerialDisposable();

	public static readonly DependencyProperty PaneTitleProperty = DependencyProperty.Register("PaneTitle", typeof(string), typeof(NavigationView), new FrameworkPropertyMetadata(string.Empty, OnPropertyChanged));

	private ItemsRepeater LeftNavRepeater => m_leftNavRepeater;

	public bool AlwaysShowHeader
	{
		get
		{
			return (bool)GetValue(AlwaysShowHeaderProperty);
		}
		set
		{
			SetValue(AlwaysShowHeaderProperty, value);
		}
	}

	public static DependencyProperty AlwaysShowHeaderProperty { get; } = DependencyProperty.Register("AlwaysShowHeader", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public AutoSuggestBox AutoSuggestBox
	{
		get
		{
			return (AutoSuggestBox)GetValue(AutoSuggestBoxProperty);
		}
		set
		{
			SetValue(AutoSuggestBoxProperty, value);
		}
	}

	public static DependencyProperty AutoSuggestBoxProperty { get; } = DependencyProperty.Register("AutoSuggestBox", typeof(AutoSuggestBox), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public double CompactModeThresholdWidth
	{
		get
		{
			return (double)GetValue(CompactModeThresholdWidthProperty);
		}
		set
		{
			double value2 = value;
			CoerceToGreaterThanZero(ref value2);
			SetValue(CompactModeThresholdWidthProperty, value2);
		}
	}

	public static DependencyProperty CompactModeThresholdWidthProperty { get; } = DependencyProperty.Register("CompactModeThresholdWidth", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(641.0, OnCompactModeThresholdWidthPropertyChanged));


	public double CompactPaneLength
	{
		get
		{
			return (double)GetValue(CompactPaneLengthProperty);
		}
		set
		{
			double value2 = value;
			CoerceToGreaterThanZero(ref value2);
			SetValue(CompactPaneLengthProperty, value2);
		}
	}

	public static DependencyProperty CompactPaneLengthProperty { get; } = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(48.0, OnCompactPaneLengthPropertyChanged));


	public UIElement ContentOverlay
	{
		get
		{
			return (UIElement)GetValue(ContentOverlayProperty);
		}
		set
		{
			SetValue(ContentOverlayProperty, value);
		}
	}

	public static DependencyProperty ContentOverlayProperty { get; } = DependencyProperty.Register("ContentOverlay", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public NavigationViewDisplayMode DisplayMode
	{
		get
		{
			return (NavigationViewDisplayMode)GetValue(DisplayModeProperty);
		}
		private set
		{
			SetValue(DisplayModeProperty, value);
		}
	}

	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(NavigationViewDisplayMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewDisplayMode.Minimal, OnPropertyChanged));


	public double ExpandedModeThresholdWidth
	{
		get
		{
			return (double)GetValue(ExpandedModeThresholdWidthProperty);
		}
		set
		{
			SetValue(ExpandedModeThresholdWidthProperty, value);
		}
	}

	public static DependencyProperty ExpandedModeThresholdWidthProperty { get; } = DependencyProperty.Register("ExpandedModeThresholdWidth", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(1008.0, OnExpandedModeThresholdWidthPropertyChanged));


	public IList<object> FooterMenuItems
	{
		get
		{
			return (IList<object>)GetValue(FooterMenuItemsProperty);
		}
		private set
		{
			SetValue(FooterMenuItemsProperty, value);
		}
	}

	public static DependencyProperty FooterMenuItemsProperty { get; } = DependencyProperty.Register("FooterMenuItems", typeof(IList<object>), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public object FooterMenuItemsSource
	{
		get
		{
			return GetValue(FooterMenuItemsSourceProperty);
		}
		set
		{
			SetValue(FooterMenuItemsSourceProperty, value);
		}
	}

	public static DependencyProperty FooterMenuItemsSourceProperty { get; } = DependencyProperty.Register("FooterMenuItemsSource", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public NavigationViewBackButtonVisible IsBackButtonVisible
	{
		get
		{
			return (NavigationViewBackButtonVisible)GetValue(IsBackButtonVisibleProperty);
		}
		set
		{
			SetValue(IsBackButtonVisibleProperty, value);
		}
	}

	public static DependencyProperty IsBackButtonVisibleProperty { get; } = DependencyProperty.Register("IsBackButtonVisible", typeof(NavigationViewBackButtonVisible), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewBackButtonVisible.Auto, OnPropertyChanged));


	public bool IsBackEnabled
	{
		get
		{
			return (bool)GetValue(IsBackEnabledProperty);
		}
		set
		{
			SetValue(IsBackEnabledProperty, value);
		}
	}

	public static DependencyProperty IsBackEnabledProperty { get; } = DependencyProperty.Register("IsBackEnabled", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(false, OnPropertyChanged));


	public bool IsPaneOpen
	{
		get
		{
			return (bool)GetValue(IsPaneOpenProperty);
		}
		set
		{
			SetValue(IsPaneOpenProperty, value);
		}
	}

	public static DependencyProperty IsPaneOpenProperty { get; } = DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public bool IsPaneToggleButtonVisible
	{
		get
		{
			return (bool)GetValue(IsPaneToggleButtonVisibleProperty);
		}
		set
		{
			SetValue(IsPaneToggleButtonVisibleProperty, value);
		}
	}

	public static DependencyProperty IsPaneToggleButtonVisibleProperty { get; } = DependencyProperty.Register("IsPaneToggleButtonVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public bool IsPaneVisible
	{
		get
		{
			return (bool)GetValue(IsPaneVisibleProperty);
		}
		set
		{
			SetValue(IsPaneVisibleProperty, value);
		}
	}

	public static DependencyProperty IsPaneVisibleProperty { get; } = DependencyProperty.Register("IsPaneVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public bool IsSettingsVisible
	{
		get
		{
			return (bool)GetValue(IsSettingsVisibleProperty);
		}
		set
		{
			SetValue(IsSettingsVisibleProperty, value);
		}
	}

	public static DependencyProperty IsSettingsVisibleProperty { get; } = DependencyProperty.Register("IsSettingsVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public bool IsTitleBarAutoPaddingEnabled
	{
		get
		{
			return (bool)GetValue(IsTitleBarAutoPaddingEnabledProperty);
		}
		set
		{
			SetValue(IsTitleBarAutoPaddingEnabledProperty, value);
		}
	}

	public static DependencyProperty IsTitleBarAutoPaddingEnabledProperty { get; } = DependencyProperty.Register("IsTitleBarAutoPaddingEnabled", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, OnPropertyChanged));


	public Style MenuItemContainerStyle
	{
		get
		{
			return (Style)GetValue(MenuItemContainerStyleProperty);
		}
		set
		{
			SetValue(MenuItemContainerStyleProperty, value);
		}
	}

	public static DependencyProperty MenuItemContainerStyleProperty { get; } = DependencyProperty.Register("MenuItemContainerStyle", typeof(Style), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public StyleSelector MenuItemContainerStyleSelector
	{
		get
		{
			return (StyleSelector)GetValue(MenuItemContainerStyleSelectorProperty);
		}
		set
		{
			SetValue(MenuItemContainerStyleSelectorProperty, value);
		}
	}

	public static DependencyProperty MenuItemContainerStyleSelectorProperty { get; } = DependencyProperty.Register("MenuItemContainerStyleSelector", typeof(StyleSelector), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public IList<object> MenuItems
	{
		get
		{
			return (IList<object>)GetValue(MenuItemsProperty);
		}
		private set
		{
			SetValue(MenuItemsProperty, value);
		}
	}

	public static DependencyProperty MenuItemsProperty { get; } = DependencyProperty.Register("MenuItems", typeof(IList<object>), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public object MenuItemsSource
	{
		get
		{
			return GetValue(MenuItemsSourceProperty);
		}
		set
		{
			SetValue(MenuItemsSourceProperty, value);
		}
	}

	public static DependencyProperty MenuItemsSourceProperty { get; } = DependencyProperty.Register("MenuItemsSource", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public DataTemplate MenuItemTemplate
	{
		get
		{
			return (DataTemplate)GetValue(MenuItemTemplateProperty);
		}
		set
		{
			SetValue(MenuItemTemplateProperty, value);
		}
	}

	public static DependencyProperty MenuItemTemplateProperty { get; } = DependencyProperty.Register("MenuItemTemplate", typeof(DataTemplate), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public DataTemplateSelector MenuItemTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)GetValue(MenuItemTemplateSelectorProperty);
		}
		set
		{
			SetValue(MenuItemTemplateSelectorProperty, value);
		}
	}

	public static DependencyProperty MenuItemTemplateSelectorProperty { get; } = DependencyProperty.Register("MenuItemTemplateSelector", typeof(DataTemplateSelector), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public double OpenPaneLength
	{
		get
		{
			return (double)GetValue(OpenPaneLengthProperty);
		}
		set
		{
			double value2 = value;
			CoerceToGreaterThanZero(ref value2);
			SetValue(OpenPaneLengthProperty, value2);
		}
	}

	public static DependencyProperty OpenPaneLengthProperty { get; } = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(320.0, OnOpenPaneLengthPropertyChanged));


	public NavigationViewOverflowLabelMode OverflowLabelMode
	{
		get
		{
			return (NavigationViewOverflowLabelMode)GetValue(OverflowLabelModeProperty);
		}
		set
		{
			SetValue(OverflowLabelModeProperty, value);
		}
	}

	public static DependencyProperty OverflowLabelModeProperty { get; } = DependencyProperty.Register("OverflowLabelMode", typeof(NavigationViewOverflowLabelMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewOverflowLabelMode.MoreLabel, OnPropertyChanged));


	public UIElement PaneCustomContent
	{
		get
		{
			return (UIElement)GetValue(PaneCustomContentProperty);
		}
		set
		{
			SetValue(PaneCustomContentProperty, value);
		}
	}

	public static DependencyProperty PaneCustomContentProperty { get; } = DependencyProperty.Register("PaneCustomContent", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null));


	public NavigationViewPaneDisplayMode PaneDisplayMode
	{
		get
		{
			return (NavigationViewPaneDisplayMode)GetValue(PaneDisplayModeProperty);
		}
		set
		{
			SetValue(PaneDisplayModeProperty, value);
		}
	}

	public static DependencyProperty PaneDisplayModeProperty { get; } = DependencyProperty.Register("PaneDisplayMode", typeof(NavigationViewPaneDisplayMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewPaneDisplayMode.Auto, OnPropertyChanged));


	public UIElement PaneFooter
	{
		get
		{
			return (UIElement)GetValue(PaneFooterProperty);
		}
		set
		{
			SetValue(PaneFooterProperty, value);
		}
	}

	public static DependencyProperty PaneFooterProperty { get; } = DependencyProperty.Register("PaneFooter", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public UIElement PaneHeader
	{
		get
		{
			return (UIElement)GetValue(PaneHeaderProperty);
		}
		set
		{
			SetValue(PaneHeaderProperty, value);
		}
	}

	public static DependencyProperty PaneHeaderProperty { get; } = DependencyProperty.Register("PaneHeader", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null));


	public string PaneTitle
	{
		get
		{
			return (string)GetValue(PaneTitleProperty);
		}
		set
		{
			SetValue(PaneTitleProperty, value);
		}
	}

	public Style PaneToggleButtonStyle
	{
		get
		{
			return (Style)GetValue(PaneToggleButtonStyleProperty);
		}
		set
		{
			SetValue(PaneToggleButtonStyleProperty, value);
		}
	}

	public static DependencyProperty PaneToggleButtonStyleProperty { get; } = DependencyProperty.Register("PaneToggleButtonStyle", typeof(Style), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, OnPropertyChanged));


	public object SelectedItem
	{
		get
		{
			return GetValue(SelectedItemProperty);
		}
		set
		{
			SetValue(SelectedItemProperty, value);
		}
	}

	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public NavigationViewSelectionFollowsFocus SelectionFollowsFocus
	{
		get
		{
			return (NavigationViewSelectionFollowsFocus)GetValue(SelectionFollowsFocusProperty);
		}
		set
		{
			SetValue(SelectionFollowsFocusProperty, value);
		}
	}

	public static DependencyProperty SelectionFollowsFocusProperty { get; } = DependencyProperty.Register("SelectionFollowsFocus", typeof(NavigationViewSelectionFollowsFocus), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewSelectionFollowsFocus.Disabled, OnPropertyChanged));


	public object SettingsItem
	{
		get
		{
			return GetValue(SettingsItemProperty);
		}
		set
		{
			SetValue(SettingsItemProperty, value);
		}
	}

	public static DependencyProperty SettingsItemProperty { get; } = DependencyProperty.Register("SettingsItem", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public NavigationViewShoulderNavigationEnabled ShoulderNavigationEnabled
	{
		get
		{
			return (NavigationViewShoulderNavigationEnabled)GetValue(ShoulderNavigationEnabledProperty);
		}
		set
		{
			SetValue(ShoulderNavigationEnabledProperty, value);
		}
	}

	public static DependencyProperty ShoulderNavigationEnabledProperty { get; } = DependencyProperty.Register("ShoulderNavigationEnabled", typeof(NavigationViewShoulderNavigationEnabled), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewShoulderNavigationEnabled.Never, OnPropertyChanged));


	public NavigationViewTemplateSettings TemplateSettings
	{
		get
		{
			return (NavigationViewTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(NavigationViewTemplateSettings), typeof(NavigationView), new FrameworkPropertyMetadata(null));


	public event TypedEventHandler<NavigationView, NavigationViewBackRequestedEventArgs> BackRequested;

	public event TypedEventHandler<NavigationView, NavigationViewItemCollapsedEventArgs> Collapsed;

	public event TypedEventHandler<NavigationView, NavigationViewDisplayModeChangedEventArgs> DisplayModeChanged;

	public event TypedEventHandler<NavigationView, NavigationViewItemExpandingEventArgs> Expanding;

	public event TypedEventHandler<NavigationView, NavigationViewItemInvokedEventArgs> ItemInvoked;

	public event TypedEventHandler<NavigationView, object> PaneClosed;

	public event TypedEventHandler<NavigationView, NavigationViewPaneClosingEventArgs> PaneClosing;

	public event TypedEventHandler<NavigationView, object> PaneOpened;

	public event TypedEventHandler<NavigationView, object> PaneOpening;

	public event TypedEventHandler<NavigationView, NavigationViewSelectionChangedEventArgs> SelectionChanged;

	~NavigationView()
	{
		UnhookEventsAndClearFields(isFromDestructor: true);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new NavigationViewAutomationPeer(this);
	}

	internal void UnhookEventsAndClearFields(bool isFromDestructor = false)
	{
		m_titleBarMetricsChangedRevoker.Disposable = null;
		m_titleBarIsVisibleChangedRevoker.Disposable = null;
		m_paneToggleButtonClickRevoker.Disposable = null;
		m_settingsItem = null;
		m_paneSearchButtonClickRevoker.Disposable = null;
		m_paneSearchButton = null;
		m_paneHeaderOnTopPane = null;
		m_paneTitleOnTopPane = null;
		m_itemsContainerSizeChangedRevoker.Disposable = null;
		m_paneTitleHolderFrameworkElementSizeChangedRevoker.Disposable = null;
		m_paneTitleHolderFrameworkElement = null;
		m_paneTitleFrameworkElement = null;
		m_paneTitlePresenter = null;
		m_paneHeaderCloseButtonColumn = null;
		m_paneHeaderToggleButtonColumn = null;
		m_paneHeaderContentBorderRow = null;
		m_leftNavItemsRepeaterElementPreparedRevoker.Disposable = null;
		m_leftNavItemsRepeaterElementClearingRevoker.Disposable = null;
		m_leftNavRepeaterLoadedRevoker.Disposable = null;
		m_leftNavRepeaterGettingFocusRevoker.Disposable = null;
		m_leftNavRepeater = null;
		m_topNavItemsRepeaterElementPreparedRevoker.Disposable = null;
		m_topNavItemsRepeaterElementClearingRevoker.Disposable = null;
		m_topNavRepeaterLoadedRevoker.Disposable = null;
		m_topNavRepeaterGettingFocusRevoker.Disposable = null;
		m_topNavRepeater = null;
		m_leftNavFooterMenuItemsRepeaterElementPreparedRevoker.Disposable = null;
		m_leftNavFooterMenuItemsRepeaterElementClearingRevoker.Disposable = null;
		m_leftNavFooterMenuRepeaterLoadedRevoker.Disposable = null;
		m_leftNavFooterMenuRepeaterGettingFocusRevoker.Disposable = null;
		m_leftNavFooterMenuRepeater = null;
		m_topNavFooterMenuItemsRepeaterElementPreparedRevoker.Disposable = null;
		m_topNavFooterMenuItemsRepeaterElementClearingRevoker.Disposable = null;
		m_topNavFooterMenuRepeaterLoadedRevoker.Disposable = null;
		m_topNavFooterMenuRepeaterGettingFocusRevoker.Disposable = null;
		m_topNavFooterMenuRepeater = null;
		m_footerItemsCollectionChangedRevoker.Disposable = null;
		m_menuItemsCollectionChangedRevoker.Disposable = null;
		m_topNavOverflowItemsRepeaterElementPreparedRevoker.Disposable = null;
		m_topNavOverflowItemsRepeaterElementClearingRevoker.Disposable = null;
		m_topNavRepeaterOverflowView = null;
		m_topNavOverflowItemsCollectionChangedRevoker.Disposable = null;
		m_shadowCasterEaseOutStoryboardRevoker.Disposable = null;
		m_leftNavItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = null;
		m_leftNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = null;
		m_topNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = null;
		m_topNavItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = null;
		m_topNavOverflowItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = null;
		if (isFromDestructor)
		{
			m_selectionChangedRevoker.Disposable = null;
			m_autoSuggestBoxQuerySubmittedRevoker.Disposable = null;
			ClearAllNavigationViewItemRevokers();
		}
	}

	public NavigationView()
	{
		m_topDataProvider = new TopNavigationViewDataProvider(this);
		SetValue(TemplateSettingsProperty, new NavigationViewTemplateSettings());
		base.DefaultStyleKey = typeof(NavigationView);
		base.SizeChanged += OnSizeChanged;
		m_selectionModelSource = new ObservableCollection<object>();
		m_selectionModelSource.Add(null);
		m_selectionModelSource.Add(null);
		ObservableCollection<object> value = new ObservableCollection<object>();
		SetValue(MenuItemsProperty, value);
		ObservableCollection<object> value2 = new ObservableCollection<object>();
		SetValue(FooterMenuItemsProperty, value2);
		WeakReference<NavigationView> weakThis = new WeakReference<NavigationView>(this);
		m_topDataProvider.OnRawDataChanged(delegate(NotifyCollectionChangedEventArgs args)
		{
			if (weakThis.TryGetTarget(out var target))
			{
				target.OnTopNavDataSourceChanged(args);
			}
		});
		base.Unloaded += OnUnloaded;
		base.Loaded += OnLoaded;
		m_selectionModel.SingleSelect = true;
		m_selectionModel.Source = m_selectionModelSource;
		m_selectionModel.SelectionChanged += OnSelectionModelSelectionChanged;
		m_selectionChangedRevoker.Disposable = Disposable.Create(delegate
		{
			m_selectionModel.SelectionChanged -= OnSelectionModelSelectionChanged;
		});
		m_selectionModel.ChildrenRequested += OnSelectionModelChildrenRequested;
		m_childrenRequestedRevoker.Disposable = Disposable.Create(delegate
		{
			m_selectionModel.ChildrenRequested -= OnSelectionModelChildrenRequested;
		});
		m_navigationViewItemsFactory = new NavigationViewItemsFactory();
	}

	private void OnSelectionModelChildrenRequested(SelectionModel selectionModel, SelectionModelChildrenRequestedEventArgs e)
	{
		if (e.SourceIndex.GetSize() == 1)
		{
			e.Children = e.Source;
			return;
		}
		if (e.Source is NavigationViewItem nvi)
		{
			e.Children = GetChildren(nvi);
			return;
		}
		object childrenForItemInIndexPath = GetChildrenForItemInIndexPath(e.SourceIndex, forceRealize: true);
		if (childrenForItemInIndexPath != null)
		{
			e.Children = childrenForItemInIndexPath;
		}
	}

	private void OnFooterItemsSourceCollectionChanged(object sender, object args)
	{
		UpdateFooterRepeaterItemsSource(sourceCollectionReset: false, sourceCollectionChanged: true);
		UpdatePaneLayout();
	}

	private void OnOverflowItemsSourceCollectionChanged(object sender, object args)
	{
		if (m_topNavRepeaterOverflowView.ItemsSourceView.Count == 0)
		{
			SetOverflowButtonVisibility(Visibility.Collapsed);
		}
	}

	private void OnSelectionModelSelectionChanged(SelectionModel selectionModel, SelectionModelSelectionChangedEventArgs e)
	{
		object selectedItem = selectionModel.SelectedItem;
		if (m_shouldIgnoreNextSelectionChange || selectedItem == SelectedItem || !m_appliedTemplate)
		{
			return;
		}
		bool flag = true;
		IndexPath selectedIndex2 = selectionModel.SelectedIndex;
		if (IsTopNavigationView() && selectedIndex2 != null && selectedIndex2.GetSize() > 1 && selectedIndex2.GetAt(0) == 0 && !m_topDataProvider.IsItemInPrimaryList(selectedIndex2.GetAt(1)))
		{
			if (GetItemShouldBeMoved(selectedIndex2))
			{
				SelectandMoveOverflowItem(selectedItem, selectedIndex2, closeFlyout: true);
				flag = false;
			}
			else
			{
				m_moveTopNavOverflowItemOnFlyoutClose = true;
			}
		}
		if (flag)
		{
			SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(selectedItem);
		}
		bool GetItemShouldBeMoved(IndexPath selectedIndex)
		{
			NavigationViewItemBase containerForIndexPath = GetContainerForIndexPath(selectedIndex);
			if (containerForIndexPath != null && containerForIndexPath is NavigationViewItem nvi && DoesNavigationViewItemHaveChildren(nvi))
			{
				return false;
			}
			return true;
		}
	}

	private void SelectandMoveOverflowItem(object selectedItem, IndexPath selectedIndex, bool closeFlyout)
	{
		try
		{
			m_selectionChangeFromOverflowMenu = true;
			if (closeFlyout)
			{
				CloseTopNavigationViewFlyout();
			}
			if (!IsSelectionSuppressed(selectedItem))
			{
				SelectOverflowItem(selectedItem, selectedIndex);
			}
		}
		finally
		{
			m_selectionChangeFromOverflowMenu = false;
		}
	}

	private void CloseFlyoutIfRequired(NavigationViewItem selectedItem)
	{
		IndexPath selectedIndex = m_selectionModel.SelectedIndex;
		if (!GetIsInModeWithFlyout() || selectedIndex == null || DoesNavigationViewItemHaveChildren(selectedItem))
		{
			return;
		}
		UIElement containerForIndex = GetContainerForIndex(selectedIndex.GetAt(1), selectedIndex.GetAt(0) == 1);
		if (containerForIndex != null && containerForIndex is NavigationViewItem navigationViewItem)
		{
			NavigationViewItem navigationViewItem2 = navigationViewItem;
			if (navigationViewItem2.ShouldRepeaterShowInFlyout())
			{
				navigationViewItem.IsExpanded = false;
			}
		}
		bool GetIsInModeWithFlyout()
		{
			SplitView rootSplitView = m_rootSplitView;
			if (rootSplitView != null)
			{
				SplitViewDisplayMode displayMode = rootSplitView.DisplayMode;
				if (rootSplitView.IsPaneOpen || (displayMode != SplitViewDisplayMode.CompactOverlay && displayMode != SplitViewDisplayMode.CompactInline))
				{
					return PaneDisplayMode == NavigationViewPaneDisplayMode.Top;
				}
				return true;
			}
			return false;
		}
	}

	protected override void OnApplyTemplate()
	{
		m_appliedTemplate = false;
		try
		{
			m_fromOnApplyTemplate = true;
			UnhookEventsAndClearFields();
			Button paneToggleButton = GetTemplateChild("TogglePaneButton") as Button;
			if (paneToggleButton != null)
			{
				m_paneToggleButton = paneToggleButton;
				paneToggleButton.Click += OnPaneToggleButtonClick;
				m_paneToggleButtonClickRevoker.Disposable = Disposable.Create(delegate
				{
					paneToggleButton.Click -= OnPaneToggleButtonClick;
				});
				SetPaneToggleButtonAutomationName();
				if (SharedHelpers.IsRS3OrHigher())
				{
					KeyboardAccelerator keyboardAccelerator = new KeyboardAccelerator();
					keyboardAccelerator.Key = VirtualKey.Back;
					keyboardAccelerator.Modifiers = VirtualKeyModifiers.Windows;
					paneToggleButton.KeyboardAccelerators.Add(keyboardAccelerator);
				}
			}
			m_leftNavPaneHeaderContentBorder = (ContentControl)GetTemplateChild("PaneHeaderContentBorder");
			m_leftNavPaneCustomContentBorder = (ContentControl)GetTemplateChild("PaneCustomContentBorder");
			m_leftNavFooterContentBorder = (ContentControl)GetTemplateChild("FooterContentBorder");
			m_paneHeaderOnTopPane = (ContentControl)GetTemplateChild("PaneHeaderOnTopPane");
			m_paneTitleOnTopPane = (ContentControl)GetTemplateChild("PaneTitleOnTopPane");
			m_paneCustomContentOnTopPane = (ContentControl)GetTemplateChild("PaneCustomContentOnTopPane");
			m_paneFooterOnTopPane = (ContentControl)GetTemplateChild("PaneFooterOnTopPane");
			SplitView splitView = GetTemplateChild("RootSplitView") as SplitView;
			if (splitView != null)
			{
				m_rootSplitView = splitView;
				long splitViewIsPaneOpenSubscription = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewClosedCompactChanged);
				m_splitViewIsPaneOpenChangedRevoker.Disposable = Disposable.Create(delegate
				{
					splitView.UnregisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, splitViewIsPaneOpenSubscription);
				});
				long splitViewDisplayModeChangedSubscription = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewClosedCompactChanged);
				m_splitViewDisplayModeChangedRevoker.Disposable = Disposable.Create(delegate
				{
					splitView.UnregisterPropertyChangedCallback(SplitView.DisplayModeProperty, splitViewDisplayModeChangedSubscription);
				});
				if (SharedHelpers.IsRS3OrHigher())
				{
					splitView.PaneClosed += OnSplitViewPaneClosed;
					m_splitViewPaneClosedRevoker.Disposable = Disposable.Create(delegate
					{
						splitView.PaneClosed -= OnSplitViewPaneClosed;
					});
					splitView.PaneClosing += OnSplitViewPaneClosing;
					m_splitViewPaneClosingRevoker.Disposable = Disposable.Create(delegate
					{
						splitView.PaneClosing -= OnSplitViewPaneClosing;
					});
					splitView.PaneOpened += OnSplitViewPaneOpened;
					m_splitViewPaneOpenedRevoker.Disposable = Disposable.Create(delegate
					{
						splitView.PaneOpened -= OnSplitViewPaneOpened;
					});
					splitView.PaneOpening += OnSplitViewPaneOpening;
					m_splitViewPaneOpeningRevoker.Disposable = Disposable.Create(delegate
					{
						splitView.PaneOpening -= OnSplitViewPaneOpening;
					});
				}
				UpdateIsClosedCompact();
			}
			m_topNavGrid = (Grid)GetTemplateChild("TopNavGrid");
			ItemsRepeater leftNavRepeater = GetTemplateChild("MenuItemsHost") as ItemsRepeater;
			if (leftNavRepeater != null)
			{
				m_leftNavRepeater = leftNavRepeater;
				if (leftNavRepeater.Layout is StackLayout stackLayout)
				{
					StackLayout stackLayout2 = stackLayout;
					stackLayout2.DisableVirtualization = true;
				}
				leftNavRepeater.UnoBeforeElementPrepared += OnRepeaterUnoBeforeElementPrepared;
				m_leftNavItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					leftNavRepeater.UnoBeforeElementPrepared -= OnRepeaterUnoBeforeElementPrepared;
				});
				leftNavRepeater.ElementPrepared += OnRepeaterElementPrepared;
				m_leftNavItemsRepeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					leftNavRepeater.ElementPrepared -= OnRepeaterElementPrepared;
				});
				leftNavRepeater.ElementClearing += OnRepeaterElementClearing;
				m_leftNavItemsRepeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					leftNavRepeater.ElementClearing -= OnRepeaterElementClearing;
				});
				leftNavRepeater.Loaded += OnRepeaterLoaded;
				m_leftNavRepeaterLoadedRevoker.Disposable = Disposable.Create(delegate
				{
					leftNavRepeater.Loaded -= OnRepeaterLoaded;
				});
				leftNavRepeater.GettingFocus += OnRepeaterGettingFocus;
				m_leftNavRepeaterGettingFocusRevoker.Disposable = Disposable.Create(delegate
				{
					leftNavRepeater.GettingFocus -= OnRepeaterGettingFocus;
				});
				leftNavRepeater.ItemTemplate = m_navigationViewItemsFactory;
			}
			ItemsRepeater topNavRepeater = GetTemplateChild("TopNavMenuItemsHost") as ItemsRepeater;
			if (topNavRepeater != null)
			{
				m_topNavRepeater = topNavRepeater;
				if (topNavRepeater.Layout is StackLayout stackLayout3)
				{
					StackLayout stackLayout4 = stackLayout3;
					stackLayout4.DisableVirtualization = true;
				}
				topNavRepeater.UnoBeforeElementPrepared += OnRepeaterUnoBeforeElementPrepared;
				m_topNavItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topNavRepeater.UnoBeforeElementPrepared -= OnRepeaterUnoBeforeElementPrepared;
				});
				topNavRepeater.ElementPrepared += OnRepeaterElementPrepared;
				m_topNavItemsRepeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topNavRepeater.ElementPrepared -= OnRepeaterElementPrepared;
				});
				topNavRepeater.ElementClearing += OnRepeaterElementClearing;
				m_topNavItemsRepeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					topNavRepeater.ElementClearing -= OnRepeaterElementClearing;
				});
				topNavRepeater.Loaded += OnRepeaterLoaded;
				m_topNavRepeaterLoadedRevoker.Disposable = Disposable.Create(delegate
				{
					topNavRepeater.Loaded -= OnRepeaterLoaded;
				});
				topNavRepeater.GettingFocus += OnRepeaterGettingFocus;
				m_topNavRepeaterGettingFocusRevoker.Disposable = Disposable.Create(delegate
				{
					topNavRepeater.GettingFocus -= OnRepeaterGettingFocus;
				});
				topNavRepeater.ItemTemplate = m_navigationViewItemsFactory;
			}
			ItemsRepeater topNavListOverflowRepeater = GetTemplateChild("TopNavMenuItemsOverflowHost") as ItemsRepeater;
			if (topNavListOverflowRepeater != null)
			{
				m_topNavRepeaterOverflowView = topNavListOverflowRepeater;
				if (topNavListOverflowRepeater.Layout is StackLayout stackLayout5)
				{
					StackLayout stackLayout6 = stackLayout5;
					stackLayout6.DisableVirtualization = true;
				}
				topNavListOverflowRepeater.UnoBeforeElementPrepared += OnRepeaterUnoBeforeElementPrepared;
				m_topNavOverflowItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topNavListOverflowRepeater.UnoBeforeElementPrepared -= OnRepeaterUnoBeforeElementPrepared;
				});
				topNavListOverflowRepeater.ElementPrepared += OnRepeaterElementPrepared;
				m_topNavOverflowItemsRepeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topNavListOverflowRepeater.ElementPrepared -= OnRepeaterElementPrepared;
				});
				topNavListOverflowRepeater.ElementClearing += OnRepeaterElementClearing;
				m_topNavOverflowItemsRepeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					topNavListOverflowRepeater.ElementClearing -= OnRepeaterElementClearing;
				});
				topNavListOverflowRepeater.ItemTemplate = m_navigationViewItemsFactory;
			}
			if (GetTemplateChild("TopNavOverflowButton") is Button button2)
			{
				m_topNavOverflowButton = button2;
				AutomationProperties.SetName(button2, ResourceAccessor.GetLocalizedStringResource("NavigationOverflowButtonName"));
				button2.Content = ResourceAccessor.GetLocalizedStringResource("NavigationOverflowButtonText");
				Visual elementVisual = ElementCompositionPreview.GetElementVisual(button2);
				CreateAndAttachHeaderAnimation(elementVisual);
				object toolTip = ToolTipService.GetToolTip(button2);
				if (toolTip == null)
				{
					ToolTip toolTip2 = new ToolTip();
					toolTip2.Content = ResourceAccessor.GetLocalizedStringResource("NavigationOverflowButtonToolTip");
					ToolTipService.SetToolTip(button2, toolTip2);
				}
				FlyoutBase flyoutBase = button2.Flyout;
				if (flyoutBase != null)
				{
					FlyoutBase flyoutBase2 = flyoutBase;
					if (flyoutBase2 != null)
					{
						flyoutBase2.ShouldConstrainToRootBounds = false;
					}
					flyoutBase.Closing += OnFlyoutClosing;
					m_flyoutClosingRevoker.Disposable = Disposable.Create(delegate
					{
						flyoutBase.Closing -= OnFlyoutClosing;
					});
				}
			}
			ItemsRepeater leftFooterMenuNavRepeater = GetTemplateChild("FooterMenuItemsHost") as ItemsRepeater;
			if (leftFooterMenuNavRepeater != null)
			{
				m_leftNavFooterMenuRepeater = leftFooterMenuNavRepeater;
				if (leftFooterMenuNavRepeater.Layout is StackLayout stackLayout7)
				{
					StackLayout stackLayout8 = stackLayout7;
					stackLayout8.DisableVirtualization = true;
				}
				leftFooterMenuNavRepeater.UnoBeforeElementPrepared += OnRepeaterUnoBeforeElementPrepared;
				m_leftNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					leftFooterMenuNavRepeater.UnoBeforeElementPrepared -= OnRepeaterUnoBeforeElementPrepared;
				});
				leftFooterMenuNavRepeater.ElementPrepared += OnRepeaterElementPrepared;
				m_leftNavFooterMenuItemsRepeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					leftFooterMenuNavRepeater.ElementPrepared -= OnRepeaterElementPrepared;
				});
				leftFooterMenuNavRepeater.ElementClearing += OnRepeaterElementClearing;
				m_leftNavFooterMenuItemsRepeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					leftFooterMenuNavRepeater.ElementClearing -= OnRepeaterElementClearing;
				});
				leftFooterMenuNavRepeater.Loaded += OnRepeaterLoaded;
				m_leftNavFooterMenuRepeaterLoadedRevoker.Disposable = Disposable.Create(delegate
				{
					leftFooterMenuNavRepeater.Loaded -= OnRepeaterLoaded;
				});
				leftFooterMenuNavRepeater.GettingFocus += OnRepeaterGettingFocus;
				m_leftNavFooterMenuRepeaterGettingFocusRevoker.Disposable = Disposable.Create(delegate
				{
					leftFooterMenuNavRepeater.GettingFocus -= OnRepeaterGettingFocus;
				});
				leftFooterMenuNavRepeater.ItemTemplate = m_navigationViewItemsFactory;
			}
			ItemsRepeater topFooterMenuNavRepeater = GetTemplateChild("TopFooterMenuItemsHost") as ItemsRepeater;
			if (topFooterMenuNavRepeater != null)
			{
				m_topNavFooterMenuRepeater = topFooterMenuNavRepeater;
				if (topFooterMenuNavRepeater.Layout is StackLayout stackLayout9)
				{
					StackLayout stackLayout10 = stackLayout9;
					stackLayout10.DisableVirtualization = true;
				}
				topFooterMenuNavRepeater.UnoBeforeElementPrepared += OnRepeaterUnoBeforeElementPrepared;
				m_topNavFooterMenuItemsRepeaterUnoBeforeElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topFooterMenuNavRepeater.UnoBeforeElementPrepared -= OnRepeaterUnoBeforeElementPrepared;
				});
				topFooterMenuNavRepeater.ElementPrepared += OnRepeaterElementPrepared;
				m_topNavFooterMenuItemsRepeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					topFooterMenuNavRepeater.ElementPrepared -= OnRepeaterElementPrepared;
				});
				topFooterMenuNavRepeater.ElementClearing += OnRepeaterElementClearing;
				m_topNavFooterMenuItemsRepeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					topFooterMenuNavRepeater.ElementClearing -= OnRepeaterElementClearing;
				});
				topFooterMenuNavRepeater.Loaded += OnRepeaterLoaded;
				m_topNavFooterMenuRepeaterLoadedRevoker.Disposable = Disposable.Create(delegate
				{
					topFooterMenuNavRepeater.Loaded -= OnRepeaterLoaded;
				});
				topFooterMenuNavRepeater.GettingFocus += OnRepeaterGettingFocus;
				m_topNavFooterMenuRepeaterGettingFocusRevoker.Disposable = Disposable.Create(delegate
				{
					topFooterMenuNavRepeater.GettingFocus -= OnRepeaterGettingFocus;
				});
				topFooterMenuNavRepeater.ItemTemplate = m_navigationViewItemsFactory;
			}
			m_topNavContentOverlayAreaGrid = (Border)GetTemplateChild("TopNavContentOverlayAreaGrid");
			m_leftNavPaneAutoSuggestBoxPresenter = (ContentControl)GetTemplateChild("PaneAutoSuggestBoxPresenter");
			m_topNavPaneAutoSuggestBoxPresenter = (ContentControl)GetTemplateChild("TopPaneAutoSuggestBoxPresenter");
			m_paneContentGrid = (UIElement)GetTemplateChild("PaneContentGrid");
			m_contentLeftPadding = (FrameworkElement)GetTemplateChild("ContentLeftPadding");
			m_paneHeaderCloseButtonColumn = (ColumnDefinition)GetTemplateChild("PaneHeaderCloseButtonColumn");
			m_paneHeaderToggleButtonColumn = (ColumnDefinition)GetTemplateChild("PaneHeaderToggleButtonColumn");
			m_paneHeaderContentBorderRow = (RowDefinition)GetTemplateChild("PaneHeaderContentBorderRow");
			m_paneTitleFrameworkElement = (FrameworkElement)GetTemplateChild("PaneTitleTextBlock");
			m_paneTitlePresenter = (ContentControl)GetTemplateChild("PaneTitlePresenter");
			FrameworkElement paneTitleHolderFrameworkElement = GetTemplateChild("PaneTitleHolder") as FrameworkElement;
			if (paneTitleHolderFrameworkElement != null)
			{
				m_paneTitleHolderFrameworkElement = paneTitleHolderFrameworkElement;
				paneTitleHolderFrameworkElement.SizeChanged += OnPaneTitleHolderSizeChanged;
				m_paneTitleHolderFrameworkElementSizeChangedRevoker.Disposable = Disposable.Create(delegate
				{
					paneTitleHolderFrameworkElement.SizeChanged -= OnPaneTitleHolderSizeChanged;
				});
			}
			Button button = GetTemplateChild("PaneAutoSuggestButton") as Button;
			if (button != null)
			{
				m_paneSearchButton = button;
				button.Click += OnPaneSearchButtonClick;
				m_paneSearchButtonClickRevoker.Disposable = Disposable.Create(delegate
				{
					button.Click -= OnPaneSearchButtonClick;
				});
				string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("NavigationViewSearchButtonName");
				AutomationProperties.SetName(button, localizedStringResource);
				ToolTip toolTip3 = new ToolTip();
				toolTip3.Content = localizedStringResource;
				ToolTipService.SetToolTip(button, toolTip3);
			}
			Button backButton = GetTemplateChild("NavigationViewBackButton") as Button;
			if (backButton != null)
			{
				m_backButton = backButton;
				backButton.Click += OnBackButtonClicked;
				m_backButtonClickedRevoker.Disposable = Disposable.Create(delegate
				{
					backButton.Click -= OnBackButtonClicked;
				});
				string localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("NavigationBackButtonName");
				AutomationProperties.SetName(backButton, localizedStringResource2);
			}
			CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
			if (coreTitleBar != null)
			{
				m_coreTitleBar = coreTitleBar;
				coreTitleBar.LayoutMetricsChanged += OnTitleBarMetricsChanged;
				m_titleBarMetricsChangedRevoker.Disposable = Disposable.Create(delegate
				{
					coreTitleBar.LayoutMetricsChanged -= OnTitleBarMetricsChanged;
				});
				coreTitleBar.IsVisibleChanged += OnTitleBarIsVisibleChanged;
				m_titleBarIsVisibleChangedRevoker.Disposable = Disposable.Create(delegate
				{
					coreTitleBar.IsVisibleChanged -= OnTitleBarIsVisibleChanged;
				});
				if (ShouldPreserveNavigationViewRS4Behavior())
				{
					m_togglePaneTopPadding = (FrameworkElement)GetTemplateChild("TogglePaneTopPadding");
					m_contentPaneTopPadding = (FrameworkElement)GetTemplateChild("ContentPaneTopPadding");
				}
			}
			if (GetTemplateChild("NavigationViewBackButtonToolTip") is ToolTip toolTip4)
			{
				string text = (string)(toolTip4.Content = ResourceAccessor.GetLocalizedStringResource("NavigationBackButtonToolTip"));
			}
			Button closeButton = GetTemplateChild("NavigationViewCloseButton") as Button;
			if (closeButton != null)
			{
				m_closeButton = closeButton;
				closeButton.Click += OnPaneToggleButtonClick;
				m_closeButtonClickedRevoker.Disposable = Disposable.Create(delegate
				{
					closeButton.Click -= OnPaneToggleButtonClick;
				});
				string localizedStringResource4 = ResourceAccessor.GetLocalizedStringResource("NavigationCloseButtonName");
				AutomationProperties.SetName(closeButton, localizedStringResource4);
			}
			if (GetTemplateChild("NavigationViewCloseButtonToolTip") is ToolTip toolTip5)
			{
				string text2 = (string)(toolTip5.Content = ResourceAccessor.GetLocalizedStringResource("NavigationButtonOpenName"));
			}
			m_itemsContainerRow = (RowDefinition)GetTemplateChild("ItemsContainerRow");
			m_menuItemsScrollViewer = (FrameworkElement)GetTemplateChild("MenuItemsScrollViewer");
			m_footerItemsScrollViewer = (FrameworkElement)GetTemplateChild("FooterItemsScrollViewer");
			m_itemsContainerSizeChangedRevoker.Disposable = null;
			FrameworkElement templateChild = GetTemplateChild<FrameworkElement>("ItemsContainerGrid");
			if (templateChild != null)
			{
				m_itemsContainer = templateChild;
				m_itemsContainer.SizeChanged += OnItemsContainerSizeChanged;
				m_itemsContainerSizeChangedRevoker.Disposable = Disposable.Create(delegate
				{
					m_itemsContainer.SizeChanged -= OnItemsContainerSizeChanged;
				});
			}
			if (SharedHelpers.IsRS2OrHigher())
			{
				if (GetTemplateChild("RootGrid") is Grid grid)
				{
					grid.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled;
				}
				if (GetTemplateChild("ContentGrid") is Grid grid2)
				{
					grid2.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Disabled;
				}
			}
			base.AccessKeyInvoked += OnAccessKeyInvoked;
			m_accessKeyInvokedRevoker.Disposable = Disposable.Create(delegate
			{
				base.AccessKeyInvoked -= OnAccessKeyInvoked;
			});
			if (SharedHelpers.Is21H1OrHigher())
			{
				m_shadowCaster = GetTemplateChild<Grid>("ShadowCaster");
				m_shadowCasterEaseOutStoryboard = GetTemplateChild<Storyboard>("ShadowCasterEaseOutStoryboard");
			}
			else
			{
				UpdatePaneShadow();
			}
			m_appliedTemplate = true;
			UpdatePaneDisplayMode();
			UpdateHeaderVisibility();
			UpdatePaneTitleFrameworkElementParents();
			UpdateTitleBarPadding();
			UpdatePaneTabFocusNavigation();
			UpdateBackAndCloseButtonsVisibility();
			UpdateSingleSelectionFollowsFocusTemplateSetting();
			UpdatePaneVisibility();
			UpdateVisualState();
			UpdatePaneTitleMargins();
			UpdatePaneLayout();
			UpdatePaneOverlayGroup();
		}
		finally
		{
			m_fromOnApplyTemplate = false;
		}
	}

	private void UpdateRepeaterItemsSource(bool forceSelectionModelUpdate)
	{
		object obj = GetItemsSource();
		if (forceSelectionModelUpdate)
		{
			m_selectionModelSource[0] = obj;
		}
		m_menuItemsCollectionChangedRevoker.Disposable = null;
		m_menuItemsSource = new InspectingDataSource(obj);
		m_menuItemsSource.CollectionChanged += OnMenuItemsSourceCollectionChanged;
		m_menuItemsCollectionChangedRevoker.Disposable = Disposable.Create(delegate
		{
			m_menuItemsSource.CollectionChanged -= OnMenuItemsSourceCollectionChanged;
		});
		if (IsTopNavigationView())
		{
			UpdateLeftRepeaterItemSource(null);
			UpdateTopNavRepeatersItemSource(obj);
			InvalidateTopNavPrimaryLayout();
		}
		else
		{
			UpdateTopNavRepeatersItemSource(null);
			UpdateLeftRepeaterItemSource(obj);
		}
		object GetItemsSource()
		{
			object menuItemsSource = MenuItemsSource;
			if (menuItemsSource != null)
			{
				return menuItemsSource;
			}
			UpdateSelectionForMenuItems();
			return MenuItems;
		}
	}

	private void UpdateLeftRepeaterItemSource(object items)
	{
		UpdateItemsRepeaterItemsSource(m_leftNavRepeater, items);
		UpdatePaneLayout();
	}

	private void UpdateTopNavRepeatersItemSource(object items)
	{
		m_topDataProvider.SetDataSource(items);
		UpdateTopNavPrimaryRepeaterItemsSource(items);
		UpdateTopNavOverflowRepeaterItemsSource(items);
	}

	private void UpdateTopNavPrimaryRepeaterItemsSource(object items)
	{
		if (items != null)
		{
			UpdateItemsRepeaterItemsSource(m_topNavRepeater, m_topDataProvider.GetPrimaryItems());
		}
		else
		{
			UpdateItemsRepeaterItemsSource(m_topNavRepeater, null);
		}
	}

	private void UpdateTopNavOverflowRepeaterItemsSource(object items)
	{
		m_topNavOverflowItemsCollectionChangedRevoker.Disposable = null;
		ItemsRepeater overflowRepeater = m_topNavRepeaterOverflowView;
		if (overflowRepeater == null)
		{
			return;
		}
		if (items != null)
		{
			IList<object> overflowItems = m_topDataProvider.GetOverflowItems();
			overflowRepeater.ItemsSource = overflowItems;
			overflowRepeater.ItemsSourceView.CollectionChanged += OnOverflowItemsSourceCollectionChanged;
			m_topNavOverflowItemsCollectionChangedRevoker.Disposable = Disposable.Create(delegate
			{
				overflowRepeater.ItemsSourceView.CollectionChanged -= OnOverflowItemsSourceCollectionChanged;
			});
		}
		else
		{
			overflowRepeater.ItemsSource = null;
		}
	}

	private void UpdateItemsRepeaterItemsSource(ItemsRepeater ir, object itemsSource)
	{
		if (ir != null)
		{
			ir.ItemsSource = itemsSource;
		}
	}

	private void UpdateFooterRepeaterItemsSource(bool sourceCollectionReset, bool sourceCollectionChanged)
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		object source = GetItemsSource();
		UpdateItemsRepeaterItemsSource(m_leftNavFooterMenuRepeater, null);
		UpdateItemsRepeaterItemsSource(m_topNavFooterMenuRepeater, null);
		if (m_settingsItem == null || sourceCollectionChanged || sourceCollectionReset)
		{
			List<object> list = new List<object>();
			if (m_settingsItem == null)
			{
				m_settingsItem = new NavigationViewItem();
				NavigationViewItem settingsItem = m_settingsItem;
				settingsItem.Name("SettingsItem");
				m_navigationViewItemsFactory.SettingsItem(settingsItem);
			}
			if (sourceCollectionReset)
			{
				m_footerItemsCollectionChangedRevoker.Disposable = null;
				m_footerItemsSource = null;
			}
			if (m_footerItemsSource == null)
			{
				m_footerItemsSource = new InspectingDataSource(source);
				m_footerItemsSource.CollectionChanged += OnFooterItemsSourceCollectionChanged;
				m_footerItemsCollectionChangedRevoker.Disposable = Disposable.Create(delegate
				{
					m_footerItemsSource.CollectionChanged -= OnFooterItemsSourceCollectionChanged;
				});
			}
			if (m_footerItemsSource != null)
			{
				NavigationViewItem settingsItem2 = m_settingsItem;
				int count = m_footerItemsSource.Count;
				for (int i = 0; i < count; i++)
				{
					object at = m_footerItemsSource.GetAt(i);
					list.Add(at);
				}
				if (IsSettingsVisible)
				{
					CreateAndHookEventsToSettings();
					list.Add(settingsItem2);
				}
			}
			m_selectionModelSource[1] = list;
		}
		if (IsTopNavigationView())
		{
			UpdateItemsRepeaterItemsSource(m_topNavFooterMenuRepeater, m_selectionModelSource[1]);
			return;
		}
		ItemsRepeater leftNavFooterMenuRepeater = m_leftNavFooterMenuRepeater;
		if (leftNavFooterMenuRepeater != null)
		{
			UpdateItemsRepeaterItemsSource(m_leftNavFooterMenuRepeater, m_selectionModelSource[1]);
			leftNavFooterMenuRepeater.InvalidateMeasure();
			leftNavFooterMenuRepeater.UpdateLayout();
			UpdatePaneLayout();
		}
		m_settingsItem?.StartBringIntoView();
		object GetItemsSource()
		{
			object footerMenuItemsSource = FooterMenuItemsSource;
			if (footerMenuItemsSource != null)
			{
				return footerMenuItemsSource;
			}
			UpdateSelectionForMenuItems();
			return FooterMenuItems;
		}
	}

	private void OnFlyoutClosing(object sender, FlyoutBaseClosingEventArgs args)
	{
		if (!m_moveTopNavOverflowItemOnFlyoutClose || m_selectionChangeFromOverflowMenu)
		{
			return;
		}
		m_moveTopNavOverflowItemOnFlyoutClose = false;
		IndexPath selectedIndex = m_selectionModel.SelectedIndex;
		if (selectedIndex.GetSize() > 0)
		{
			UIElement containerForIndex = GetContainerForIndex(selectedIndex.GetAt(1), inFooter: false);
			if (containerForIndex != null && containerForIndex is NavigationViewItem navigationViewItem)
			{
				navigationViewItem.IsExpanded = false;
			}
			SelectandMoveOverflowItem(SelectedItem, selectedIndex, closeFlyout: false);
		}
	}

	private void OnNavigationViewItemIsSelectedPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		if (!(sender is NavigationViewItem navigationViewItem))
		{
			return;
		}
		bool flag = IsContainerTheSelectedItemInTheSelectionModel(navigationViewItem);
		bool isSelected = navigationViewItem.IsSelected;
		if (isSelected && !flag)
		{
			IndexPath indexPathForContainer = GetIndexPathForContainer(navigationViewItem);
			UpdateSelectionModelSelection(indexPathForContainer);
		}
		else if (!isSelected && flag)
		{
			IndexPath indexPathForContainer2 = GetIndexPathForContainer(navigationViewItem);
			IndexPath selectedIndex = m_selectionModel.SelectedIndex;
			if (selectedIndex != null && indexPathForContainer2.CompareTo(selectedIndex) == 0)
			{
				m_selectionModel.DeselectAt(indexPathForContainer2);
			}
		}
		if (isSelected)
		{
			navigationViewItem.IsChildSelected = false;
		}
	}

	private void OnNavigationViewItemExpandedPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		if (sender is NavigationViewItem navigationViewItem)
		{
			if (navigationViewItem.IsExpanded)
			{
				RaiseExpandingEvent(navigationViewItem);
			}
			ShowHideChildrenItemsRepeater(navigationViewItem);
			if (!navigationViewItem.IsExpanded)
			{
				RaiseCollapsedEvent(navigationViewItem);
			}
		}
	}

	private void RaiseItemInvokedForNavigationViewItem(NavigationViewItem nvi)
	{
		object item = null;
		object selectedItem = SelectedItem;
		ItemsRepeater parentItemsRepeaterForContainer = GetParentItemsRepeaterForContainer(nvi);
		ItemsSourceView itemsSourceView = parentItemsRepeaterForContainer.ItemsSourceView;
		if (itemsSourceView != null)
		{
			InspectingDataSource inspectingDataSource = (InspectingDataSource)itemsSourceView;
			int elementIndex = parentItemsRepeaterForContainer.GetElementIndex(nvi);
			if (elementIndex != -1)
			{
				item = inspectingDataSource.GetAt(elementIndex);
			}
		}
		NavigationRecommendedTransitionDirection recommendedDirection = GetRecommendedDirection(selectedItem, nvi, parentItemsRepeaterForContainer);
		RaiseItemInvoked(item, IsSettingsItem(nvi), nvi, recommendedDirection);
		NavigationRecommendedTransitionDirection GetRecommendedDirection(object prevItem, NavigationViewItem nvi, object parentIR)
		{
			if (IsTopNavigationView() && nvi.SelectsOnInvoked)
			{
				if (parentIR == m_topNavRepeaterOverflowView)
				{
					return NavigationRecommendedTransitionDirection.FromOverflow;
				}
				if (prevItem != null)
				{
					return GetRecommendedTransitionDirection(NavigationViewItemBaseOrSettingsContentFromData(prevItem), nvi);
				}
			}
			return NavigationRecommendedTransitionDirection.Default;
		}
	}

	internal void OnNavigationViewItemInvoked(NavigationViewItem nvi)
	{
		m_shouldRaiseItemInvokedAfterSelection = true;
		object selectedItem = SelectedItem;
		bool flag = m_selectionModel != null && nvi.SelectsOnInvoked;
		if (flag)
		{
			IndexPath indexPathForContainer = GetIndexPathForContainer(nvi);
			if (DoesNavigationViewItemHaveChildren(nvi))
			{
				m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise = true;
			}
			UpdateSelectionModelSelection(indexPathForContainer);
		}
		if (selectedItem == SelectedItem)
		{
			RaiseItemInvokedForNavigationViewItem(nvi);
		}
		ToggleIsExpandedNavigationViewItem(nvi);
		ClosePaneIfNeccessaryAfterItemIsClicked(nvi);
		if (flag)
		{
			CloseFlyoutIfRequired(nvi);
		}
	}

	private bool IsRootItemsRepeater(DependencyObject element)
	{
		if (element != null)
		{
			if (element != m_topNavRepeater && element != m_leftNavRepeater && element != m_topNavRepeaterOverflowView && element != m_leftNavFooterMenuRepeater)
			{
				return element == m_topNavFooterMenuRepeater;
			}
			return true;
		}
		return false;
	}

	private bool IsRootGridOfFlyout(DependencyObject element)
	{
		if (element is Grid grid)
		{
			return grid.Name == "FlyoutRootGrid";
		}
		return false;
	}

	private ItemsRepeater GetParentRootItemsRepeaterForContainer(NavigationViewItemBase nvib)
	{
		ItemsRepeater parentItemsRepeaterForContainer = GetParentItemsRepeaterForContainer(nvib);
		NavigationViewItemBase navigationViewItemBase = nvib;
		while (!IsRootItemsRepeater(parentItemsRepeaterForContainer))
		{
			navigationViewItemBase = GetParentNavigationViewItemForContainer(navigationViewItemBase);
			if (navigationViewItemBase == null)
			{
				return null;
			}
			parentItemsRepeaterForContainer = GetParentItemsRepeaterForContainer(navigationViewItemBase);
		}
		return parentItemsRepeaterForContainer;
	}

	internal ItemsRepeater GetParentItemsRepeaterForContainer(NavigationViewItemBase nvib)
	{
		DependencyObject parent = VisualTreeHelper.GetParent(nvib);
		if (parent != null && parent is ItemsRepeater result)
		{
			return result;
		}
		return null;
	}

	private NavigationViewItem GetParentNavigationViewItemForContainer(NavigationViewItemBase nvib)
	{
		DependencyObject dependencyObject = GetParentItemsRepeaterForContainer(nvib);
		if (!IsRootItemsRepeater(dependencyObject))
		{
			while (dependencyObject != null)
			{
				dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
				if (dependencyObject is NavigationViewItem result)
				{
					return result;
				}
			}
		}
		return null;
	}

	internal IndexPath GetIndexPathForContainer(NavigationViewItemBase nvib)
	{
		List<int> list = new List<int>();
		bool flag = false;
		DependencyObject dependencyObject = nvib;
		DependencyObject dependencyObject2 = VisualTreeHelper.GetParent(dependencyObject);
		if (dependencyObject2 == null)
		{
			return IndexPath.CreateFromIndices(list);
		}
		while (dependencyObject2 != null && !IsRootItemsRepeater(dependencyObject2) && !IsRootGridOfFlyout(dependencyObject2))
		{
			if (dependencyObject2 is ItemsRepeater itemsRepeater && dependencyObject is UIElement element)
			{
				list.Insert(0, itemsRepeater.GetElementIndex(element));
			}
			dependencyObject = dependencyObject2;
			dependencyObject2 = VisualTreeHelper.GetParent(dependencyObject2);
		}
		if (IsRootGridOfFlyout(dependencyObject2))
		{
			NavigationViewItem lastItemExpandedIntoFlyout = m_lastItemExpandedIntoFlyout;
			if (lastItemExpandedIntoFlyout != null)
			{
				dependencyObject = lastItemExpandedIntoFlyout;
				dependencyObject2 = (IsTopNavigationView() ? m_topNavRepeater : m_leftNavRepeater);
			}
		}
		if (dependencyObject2 == m_topNavRepeaterOverflowView)
		{
			int elementIndex = m_topNavRepeaterOverflowView.GetElementIndex(dependencyObject as UIElement);
			object value = m_topDataProvider.GetOverflowItems()[elementIndex];
			int item = m_topDataProvider.IndexOf(value);
			list.Insert(0, item);
		}
		else if (dependencyObject2 == m_topNavRepeater)
		{
			int elementIndex2 = m_topNavRepeater.GetElementIndex(dependencyObject as UIElement);
			object value2 = m_topDataProvider.GetPrimaryItems()[elementIndex2];
			int item2 = m_topDataProvider.IndexOf(value2);
			list.Insert(0, item2);
		}
		else if (dependencyObject2 is ItemsRepeater itemsRepeater2)
		{
			list.Insert(0, itemsRepeater2.GetElementIndex(dependencyObject as UIElement));
		}
		flag = dependencyObject2 == m_leftNavFooterMenuRepeater || dependencyObject2 == m_topNavFooterMenuRepeater;
		list.Insert(0, flag ? 1 : 0);
		return IndexPath.CreateFromIndices(list);
	}

	internal void OnRepeaterElementPrepared(ItemsRepeater ir, ItemsRepeaterElementPreparedEventArgs args)
	{
		if (args.Element is Windows.UI.Xaml.Controls.NavigationViewItemBase)
		{
			throw new InvalidOperationException("MenuItems contains a Windows.UI.Xaml.Controls.NavigationViewItem. This control requires that the NavigationViewItems be of type Microsoft.UI.Xaml.Controls.NavigationViewItem.");
		}
		if (args.Element is NavigationViewItemBase navigationViewItemBase)
		{
			NavigationViewItemBase navigationViewItemBase2 = navigationViewItemBase;
			navigationViewItemBase2.SetNavigationViewParent(this);
			navigationViewItemBase2.IsTopLevelItem = IsTopLevelItem(navigationViewItemBase);
			NavigationViewRepeaterPosition position2 = (navigationViewItemBase2.Position = GetPosition(ir));
			NavigationViewItem parentNavigationViewItemForContainer = GetParentNavigationViewItemForContainer(navigationViewItemBase);
			if (parentNavigationViewItemForContainer != null)
			{
				NavigationViewItem navigationViewItem = parentNavigationViewItemForContainer;
				int num2 = (navigationViewItemBase2.Depth = ((!navigationViewItem.ShouldRepeaterShowInFlyout()) ? (navigationViewItem.Depth + 1) : 0));
			}
			else
			{
				navigationViewItemBase2.Depth = 0;
			}
			ApplyCustomMenuItemContainerStyling(navigationViewItemBase, ir, args.Index);
			if (args.Element is NavigationViewItem navigationViewItem2)
			{
				int depth = GetChildDepth(position2, navigationViewItemBase2);
				navigationViewItem2.PropagateDepthToChildren(depth);
				SetNavigationViewItemRevokers(navigationViewItem2);
			}
			navigationViewItemBase2.Reinitialize();
			AnimateSelectionChanged(SelectedItem);
		}
		static int GetChildDepth(NavigationViewRepeaterPosition position, NavigationViewItemBase nvibImpl)
		{
			if (position == NavigationViewRepeaterPosition.TopPrimary)
			{
				return 0;
			}
			return nvibImpl.Depth + 1;
		}
		NavigationViewRepeaterPosition GetPosition(ItemsRepeater ir)
		{
			if (IsTopNavigationView())
			{
				if (ir == m_topNavRepeater)
				{
					return NavigationViewRepeaterPosition.TopPrimary;
				}
				if (ir == m_topNavFooterMenuRepeater)
				{
					return NavigationViewRepeaterPosition.TopFooter;
				}
				return NavigationViewRepeaterPosition.TopOverflow;
			}
			if (ir == m_leftNavFooterMenuRepeater)
			{
				return NavigationViewRepeaterPosition.LeftFooter;
			}
			return NavigationViewRepeaterPosition.LeftNav;
		}
	}

	private void ApplyCustomMenuItemContainerStyling(NavigationViewItemBase nvib, ItemsRepeater ir, int index)
	{
		Style menuItemContainerStyle = MenuItemContainerStyle;
		StyleSelector menuItemContainerStyleSelector = MenuItemContainerStyleSelector;
		if (menuItemContainerStyle != null)
		{
			nvib.Style = menuItemContainerStyle;
		}
		else
		{
			if (menuItemContainerStyleSelector == null)
			{
				return;
			}
			ItemsSourceView itemsSourceView = ir.ItemsSourceView;
			if (itemsSourceView == null)
			{
				return;
			}
			object at = itemsSourceView.GetAt(index);
			if (at != null)
			{
				Style style = menuItemContainerStyleSelector.SelectStyle(at, nvib);
				if (style != null)
				{
					nvib.Style = style;
				}
			}
		}
	}

	internal void OnRepeaterElementClearing(ItemsRepeater ir, ItemsRepeaterElementClearingEventArgs args)
	{
		if (args.Element is NavigationViewItemBase navigationViewItemBase)
		{
			NavigationViewItemBase navigationViewItemBase2 = navigationViewItemBase;
			navigationViewItemBase2.Depth = 0;
			navigationViewItemBase2.IsTopLevelItem = false;
			if (navigationViewItemBase is NavigationViewItem navigationViewItem)
			{
				navigationViewItem.EventRevoker.Disposable = null;
			}
		}
	}

	private void CreateAndHookEventsToSettings()
	{
		if (m_settingsItem != null)
		{
			NavigationViewItem settingsItem = m_settingsItem;
			AnimatedIcon animatedIcon = new AnimatedIcon();
			animatedIcon.Source = new AnimatedSettingsVisualSource();
			SymbolIconSource symbolIconSource = new SymbolIconSource();
			symbolIconSource.Symbol = Symbol.Setting;
			animatedIcon.FallbackIconSource = symbolIconSource;
			settingsItem.Icon = animatedIcon;
			string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("SettingsButtonName");
			AutomationProperties.SetName(settingsItem, localizedStringResource);
			settingsItem.Tag = localizedStringResource;
			UpdateSettingsItemToolTip();
			if (!IsTopNavigationView())
			{
				settingsItem.Content = localizedStringResource;
			}
			else
			{
				settingsItem.Content = null;
			}
			SetValue(SettingsItemProperty, settingsItem);
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (IsTopNavigationView() && IsTopPrimaryListVisible())
		{
			if (availableSize.Width == double.PositiveInfinity)
			{
				m_topDataProvider.MoveAllItemsToPrimaryList();
			}
			else
			{
				HandleTopNavigationMeasureOverride(availableSize);
			}
		}
		m_layoutUpdatedToken.Disposable = null;
		base.LayoutUpdated += OnLayoutUpdated;
		m_layoutUpdatedToken.Disposable = Disposable.Create(delegate
		{
			base.LayoutUpdated -= OnLayoutUpdated;
		});
		return base.MeasureOverride(availableSize);
	}

	private void OnLayoutUpdated(object sender, object e)
	{
		m_layoutUpdatedToken.Disposable = null;
		object lastSelectedItemPendingAnimationInTopNav = m_lastSelectedItemPendingAnimationInTopNav;
		if (lastSelectedItemPendingAnimationInTopNav != null)
		{
			m_lastSelectedItemPendingAnimationInTopNav = null;
			AnimateSelectionChanged(lastSelectedItemPendingAnimationInTopNav);
		}
		if (m_OrientationChangedPendingAnimation)
		{
			m_OrientationChangedPendingAnimation = false;
			AnimateSelectionChanged(SelectedItem);
		}
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		double width = args.NewSize.Width;
		UpdateOpenPaneWidth(width);
		UpdateAdaptiveLayout(width);
		UpdateTitleBarPadding();
		UpdateBackAndCloseButtonsVisibility();
		UpdatePaneLayout();
	}

	private void UpdateOpenPaneWidth(double width)
	{
		if (!IsTopNavigationView() && m_rootSplitView != null)
		{
			m_openPaneWidth = Math.Max(0.0, Math.Min(width, OpenPaneLength));
			NavigationViewTemplateSettings templateSettings = GetTemplateSettings();
			templateSettings.OpenPaneWidth = m_openPaneWidth;
		}
	}

	private void OnItemsContainerSizeChanged(object sender, SizeChangedEventArgs args)
	{
		UpdatePaneLayout();
	}

	private void UpdateAdaptiveLayout(double width, bool forceSetDisplayMode = false)
	{
		if (IsTopNavigationView() || m_rootSplitView == null)
		{
			return;
		}
		m_initialListSizeStateSet = false;
		NavigationViewDisplayMode navigationViewDisplayMode = NavigationViewDisplayMode.Compact;
		switch (PaneDisplayMode)
		{
		case NavigationViewPaneDisplayMode.Auto:
			if (width >= ExpandedModeThresholdWidth)
			{
				navigationViewDisplayMode = NavigationViewDisplayMode.Expanded;
			}
			else if (width > 0.0 && width < CompactModeThresholdWidth)
			{
				navigationViewDisplayMode = NavigationViewDisplayMode.Minimal;
			}
			break;
		case NavigationViewPaneDisplayMode.Left:
			navigationViewDisplayMode = NavigationViewDisplayMode.Expanded;
			break;
		case NavigationViewPaneDisplayMode.LeftCompact:
			navigationViewDisplayMode = NavigationViewDisplayMode.Compact;
			break;
		case NavigationViewPaneDisplayMode.LeftMinimal:
			navigationViewDisplayMode = NavigationViewDisplayMode.Minimal;
			break;
		default:
			throw new InvalidOperationException("Invalid pane display mode");
		}
		if (!forceSetDisplayMode && m_InitialNonForcedModeUpdate)
		{
			if (navigationViewDisplayMode == NavigationViewDisplayMode.Minimal || navigationViewDisplayMode == NavigationViewDisplayMode.Compact)
			{
				ClosePane();
			}
			m_InitialNonForcedModeUpdate = false;
		}
		NavigationViewDisplayMode displayMode = DisplayMode;
		SetDisplayMode(navigationViewDisplayMode, forceSetDisplayMode);
		if (navigationViewDisplayMode == NavigationViewDisplayMode.Expanded && IsPaneVisible && !m_wasForceClosed)
		{
			OpenPane();
		}
		if (displayMode == NavigationViewDisplayMode.Expanded && navigationViewDisplayMode == NavigationViewDisplayMode.Compact)
		{
			m_initialListSizeStateSet = false;
			ClosePane();
		}
		if (navigationViewDisplayMode == NavigationViewDisplayMode.Minimal)
		{
			ClosePane();
		}
	}

	private void UpdatePaneLayout()
	{
		if (IsTopNavigationView())
		{
			return;
		}
		double num = GetTotalAvailableHeight();
		if (num > 0.0)
		{
			double totalAvailableHeightHalf2 = num / 2.0;
			double maxHeight = GetHeightForMenuItems(num, totalAvailableHeightHalf2);
			FrameworkElement menuItemsScrollViewer = m_menuItemsScrollViewer;
			if (menuItemsScrollViewer != null)
			{
				menuItemsScrollViewer.MaxHeight = maxHeight;
			}
		}
		static double GetFootersActualHeight(ItemsRepeater footerItemsRepeater)
		{
			double num4 = 0.0;
			if (footerItemsRepeater.Visibility == Visibility.Visible)
			{
				Thickness margin3 = footerItemsRepeater.Margin;
				num4 = margin3.Top + margin3.Bottom;
			}
			return footerItemsRepeater.ActualHeight + num4;
		}
		double GetHeightForMenuItems(double totalAvailableHeight, double totalAvailableHeightHalf)
		{
			FrameworkElement footerItemsScrollViewer = m_footerItemsScrollViewer;
			if (footerItemsScrollViewer != null)
			{
				ItemsRepeater leftNavFooterMenuRepeater = m_leftNavFooterMenuRepeater;
				if (leftNavFooterMenuRepeater != null)
				{
					ItemsRepeater leftNavRepeater = m_leftNavRepeater;
					if (leftNavRepeater != null)
					{
						double footersActualHeight = GetFootersActualHeight(leftNavFooterMenuRepeater);
						double paneFooterActualHeight = GetPaneFooterActualHeight();
						double height = leftNavRepeater.DesiredSize.Height;
						double menuItemsActualHeight = GetMenuItemsActualHeight(leftNavRepeater);
						double num5 = footersActualHeight + paneFooterActualHeight;
						if (m_footerItemsSource.Count == 0 && !IsSettingsVisible)
						{
							VisualStateManager.GoToState(this, "SeparatorCollapsed", useTransitions: false);
							return totalAvailableHeight;
						}
						if (m_menuItemsSource.Count == 0)
						{
							footerItemsScrollViewer.MaxHeight = totalAvailableHeight;
							VisualStateManager.GoToState(this, "SeparatorCollapsed", useTransitions: false);
							return 0.0;
						}
						if (totalAvailableHeight >= height + footersActualHeight)
						{
							footerItemsScrollViewer.MaxHeight = footersActualHeight;
							VisualStateManager.GoToState(this, "SeparatorCollapsed", useTransitions: false);
							return totalAvailableHeight - num5;
						}
						if (height <= totalAvailableHeightHalf)
						{
							footerItemsScrollViewer.MaxHeight = totalAvailableHeight - menuItemsActualHeight;
							VisualStateManager.GoToState(this, "SeparatorVisible", useTransitions: false);
							return menuItemsActualHeight;
						}
						if (num5 <= totalAvailableHeightHalf)
						{
							footerItemsScrollViewer.MaxHeight = footersActualHeight;
							VisualStateManager.GoToState(this, "SeparatorVisible", useTransitions: false);
							return totalAvailableHeight - num5;
						}
						footerItemsScrollViewer.MaxHeight = totalAvailableHeightHalf;
						VisualStateManager.GoToState(this, "SeparatorVisible", useTransitions: false);
						return totalAvailableHeightHalf;
					}
					return totalAvailableHeight - leftNavFooterMenuRepeater.ActualHeight;
				}
				footerItemsScrollViewer.MaxHeight = totalAvailableHeightHalf;
			}
			return totalAvailableHeightHalf;
		}
		double GetItemsContainerMargin()
		{
			FrameworkElement itemsContainer = m_itemsContainer;
			if (itemsContainer != null)
			{
				Thickness margin4 = itemsContainer.Margin;
				return margin4.Top + margin4.Bottom;
			}
			return 0.0;
		}
		static double GetMenuItemsActualHeight(ItemsRepeater menuItems)
		{
			double num2 = 0.0;
			if (menuItems.Visibility == Visibility.Visible)
			{
				Thickness margin = menuItems.Margin;
				num2 = margin.Top + margin.Bottom;
			}
			return menuItems.ActualHeight + num2;
		}
		double GetPaneFooterActualHeight()
		{
			ContentControl leftNavFooterContentBorder = m_leftNavFooterContentBorder;
			if (leftNavFooterContentBorder != null)
			{
				double num3 = 0.0;
				if (leftNavFooterContentBorder.Visibility == Visibility.Visible)
				{
					Thickness margin2 = leftNavFooterContentBorder.Margin;
					num3 = margin2.Top + margin2.Bottom;
				}
				return leftNavFooterContentBorder.ActualHeight + num3;
			}
			return 0.0;
		}
		double GetTotalAvailableHeight()
		{
			RowDefinition itemsContainerRow = m_itemsContainerRow;
			if (itemsContainerRow != null)
			{
				double itemsContainerMargin = GetItemsContainerMargin();
				return itemsContainerRow.ActualHeight - itemsContainerMargin;
			}
			return 0.0;
		}
	}

	private void OnPaneToggleButtonClick(object sender, RoutedEventArgs args)
	{
		if (IsPaneOpen)
		{
			m_wasForceClosed = true;
			ClosePane();
		}
		else
		{
			m_wasForceClosed = false;
			OpenPane();
		}
	}

	private void OnPaneSearchButtonClick(object sender, RoutedEventArgs args)
	{
		m_wasForceClosed = false;
		OpenPane();
		AutoSuggestBox?.Focus(FocusState.Keyboard);
	}

	private void OnPaneTitleHolderSizeChanged(object sender, SizeChangedEventArgs args)
	{
		UpdateBackAndCloseButtonsVisibility();
	}

	private void OpenPane()
	{
		try
		{
			m_isOpenPaneForInteraction = true;
			IsPaneOpen = true;
		}
		finally
		{
			m_isOpenPaneForInteraction = false;
		}
	}

	private void ClosePane()
	{
		CollapseMenuItemsInRepeater(m_leftNavRepeater);
		try
		{
			m_isOpenPaneForInteraction = true;
			IsPaneOpen = false;
		}
		finally
		{
			m_isOpenPaneForInteraction = false;
		}
	}

	private bool AttemptClosePaneLightly()
	{
		bool flag = false;
		if (SharedHelpers.IsRS3OrHigher())
		{
			NavigationViewPaneClosingEventArgs navigationViewPaneClosingEventArgs = new NavigationViewPaneClosingEventArgs();
			this.PaneClosing?.Invoke(this, navigationViewPaneClosingEventArgs);
			flag = navigationViewPaneClosingEventArgs.Cancel;
		}
		if (!flag || m_wasForceClosed)
		{
			m_blockNextClosingEvent = true;
			ClosePane();
			return true;
		}
		return false;
	}

	private void OnSplitViewClosedCompactChanged(DependencyObject sender, DependencyProperty args)
	{
		if (args == SplitView.IsPaneOpenProperty || args == SplitView.DisplayModeProperty)
		{
			UpdateIsClosedCompact();
		}
	}

	private void OnSplitViewPaneClosed(DependencyObject sender, object obj)
	{
		this.PaneClosed?.Invoke(this, null);
	}

	private void OnSplitViewPaneClosing(DependencyObject sender, SplitViewPaneClosingEventArgs args)
	{
		bool flag = false;
		if (this.PaneClosing != null)
		{
			if (!m_blockNextClosingEvent)
			{
				NavigationViewPaneClosingEventArgs navigationViewPaneClosingEventArgs = new NavigationViewPaneClosingEventArgs();
				navigationViewPaneClosingEventArgs.SplitViewClosingArgs(args);
				this.PaneClosing?.Invoke(this, navigationViewPaneClosingEventArgs);
				flag = navigationViewPaneClosingEventArgs.Cancel;
			}
			else
			{
				m_blockNextClosingEvent = false;
			}
		}
		if (flag)
		{
			return;
		}
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			ItemsRepeater leftNavRepeater = m_leftNavRepeater;
			if (leftNavRepeater != null && (rootSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || rootSplitView.DisplayMode == SplitViewDisplayMode.CompactInline))
			{
				VisualStateManager.GoToState(this, "ListSizeCompact", useTransitions: true);
				UpdatePaneToggleSize();
			}
		}
	}

	private void OnSplitViewPaneOpened(DependencyObject sender, object obj)
	{
		this.PaneOpened?.Invoke(this, null);
	}

	private void OnSplitViewPaneOpening(DependencyObject sender, object obj)
	{
		if (m_leftNavRepeater != null)
		{
			VisualStateManager.GoToState(this, "ListSizeFull", useTransitions: true);
		}
		this.PaneOpening?.Invoke(this, null);
	}

	private void UpdateIsClosedCompact()
	{
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			SplitViewDisplayMode displayMode = rootSplitView.DisplayMode;
			m_isClosedCompact = !rootSplitView.IsPaneOpen && (displayMode == SplitViewDisplayMode.CompactOverlay || displayMode == SplitViewDisplayMode.CompactInline);
			VisualStateManager.GoToState(this, m_isClosedCompact ? "ClosedCompact" : "NotClosedCompact", useTransitions: true);
			if (!m_initialListSizeStateSet)
			{
				m_initialListSizeStateSet = true;
				VisualStateManager.GoToState(this, m_isClosedCompact ? "ListSizeCompact" : "ListSizeFull", useTransitions: true);
			}
			else if (!SharedHelpers.IsRS3OrHigher())
			{
				VisualStateManager.GoToState(this, m_isClosedCompact ? "ListSizeCompact" : "ListSizeFull", useTransitions: true);
			}
			UpdateTitleBarPadding();
			UpdateBackAndCloseButtonsVisibility();
			UpdatePaneTitleMargins();
			UpdatePaneToggleSize();
		}
	}

	private void UpdatePaneButtonsWidths()
	{
		NavigationViewTemplateSettings templateSettings = GetTemplateSettings();
		double num = (templateSettings.PaneToggleButtonWidth = CompactPaneLength);
		templateSettings.SmallerPaneToggleButtonWidth = Math.Max(0.0, num - 8.0);
	}

	private void OnBackButtonClicked(object sender, RoutedEventArgs args)
	{
		NavigationViewBackRequestedEventArgs args2 = new NavigationViewBackRequestedEventArgs();
		this.BackRequested?.Invoke(this, args2);
	}

	private bool IsOverlay()
	{
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			return rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay;
		}
		return false;
	}

	private bool IsLightDismissible()
	{
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			if (rootSplitView.DisplayMode != SplitViewDisplayMode.Inline)
			{
				return rootSplitView.DisplayMode != SplitViewDisplayMode.CompactInline;
			}
			return false;
		}
		return false;
	}

	private bool ShouldShowBackButton()
	{
		if (m_backButton != null && !ShouldPreserveNavigationViewRS3Behavior())
		{
			if (DisplayMode == NavigationViewDisplayMode.Minimal && IsPaneOpen)
			{
				return false;
			}
			return ShouldShowBackOrCloseButton();
		}
		return false;
	}

	private bool ShouldShowCloseButton()
	{
		if (m_backButton != null && !ShouldPreserveNavigationViewRS3Behavior() && m_closeButton != null)
		{
			if (!IsPaneOpen)
			{
				return false;
			}
			NavigationViewPaneDisplayMode paneDisplayMode = PaneDisplayMode;
			if (paneDisplayMode != NavigationViewPaneDisplayMode.LeftMinimal && (paneDisplayMode != 0 || DisplayMode != 0))
			{
				return false;
			}
			return ShouldShowBackOrCloseButton();
		}
		return false;
	}

	private bool ShouldShowBackOrCloseButton()
	{
		NavigationViewBackButtonVisible isBackButtonVisible = IsBackButtonVisible;
		bool flag = AnalyticsInfo.VersionInfo.DeviceFamily.StartsWith("Android", StringComparison.InvariantCultureIgnoreCase);
		switch (isBackButtonVisible)
		{
		case NavigationViewBackButtonVisible.Auto:
			if (!SharedHelpers.IsOnXbox())
			{
				return !flag;
			}
			return false;
		default:
			return false;
		case NavigationViewBackButtonVisible.Visible:
			return true;
		}
	}

	private void SetPaneToggleButtonAutomationName()
	{
		string text = ((!IsPaneOpen) ? ResourceAccessor.GetLocalizedStringResource("NavigationButtonClosedName") : ResourceAccessor.GetLocalizedStringResource("NavigationButtonOpenName"));
		Button paneToggleButton = m_paneToggleButton;
		if (paneToggleButton != null)
		{
			AutomationProperties.SetName(paneToggleButton, text);
			ToolTip toolTip = new ToolTip();
			toolTip.Content = text;
			ToolTipService.SetToolTip(paneToggleButton, toolTip);
		}
	}

	private void UpdateSettingsItemToolTip()
	{
		NavigationViewItem settingsItem = m_settingsItem;
		if (settingsItem != null)
		{
			if (!IsTopNavigationView() && IsPaneOpen)
			{
				ToolTipService.SetToolTip(settingsItem, null);
				return;
			}
			string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("SettingsButtonName");
			ToolTip toolTip = new ToolTip();
			toolTip.Content = localizedStringResource;
			ToolTipService.SetToolTip(settingsItem, toolTip);
		}
	}

	private void UpdatePaneTitleFrameworkElementParents()
	{
		FrameworkElement paneTitleHolderFrameworkElement = m_paneTitleHolderFrameworkElement;
		if (paneTitleHolderFrameworkElement == null)
		{
			return;
		}
		bool isPaneToggleButtonVisible = IsPaneToggleButtonVisible;
		bool flag = IsTopNavigationView();
		int num = PaneTitle?.Length ?? 0;
		m_isLeftPaneTitleEmpty = isPaneToggleButtonVisible || flag || num == 0 || (PaneDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal && !IsPaneOpen);
		paneTitleHolderFrameworkElement.Visibility = (m_isLeftPaneTitleEmpty ? Visibility.Collapsed : Visibility.Visible);
		FrameworkElement paneTitleFrameworkElement = m_paneTitleFrameworkElement;
		if (paneTitleFrameworkElement != null)
		{
			ContentControl paneTitleOnTopPane = m_paneTitleOnTopPane;
			Action action = SetPaneTitleFrameworkElementParent(m_paneToggleButton, paneTitleFrameworkElement, flag || !isPaneToggleButtonVisible);
			Action action2 = SetPaneTitleFrameworkElementParent(m_paneTitlePresenter, paneTitleFrameworkElement, flag || isPaneToggleButtonVisible);
			Action action3 = SetPaneTitleFrameworkElementParent(paneTitleOnTopPane, paneTitleFrameworkElement, !flag || isPaneToggleButtonVisible);
			if (action != null)
			{
				action();
			}
			else if (action2 != null)
			{
				action2();
			}
			else
			{
				action3?.Invoke();
			}
			if (paneTitleOnTopPane != null)
			{
				paneTitleOnTopPane.Visibility = ((action3 == null || num == 0) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
	}

	private Action SetPaneTitleFrameworkElementParent(ContentControl parent, FrameworkElement paneTitle, bool shouldNotContainPaneTitle)
	{
		if (parent != null && parent.Content == paneTitle == shouldNotContainPaneTitle)
		{
			if (!shouldNotContainPaneTitle)
			{
				return delegate
				{
					parent.Content = paneTitle;
				};
			}
			parent.Content = null;
		}
		return null;
	}

	private void AnimateSelectionChangedToItem(object selectedItem)
	{
		if (selectedItem != null && !IsSelectionSuppressed(selectedItem))
		{
			AnimateSelectionChanged(selectedItem);
		}
	}

	private void AnimateSelectionChanged(object nextItem)
	{
		if (m_lastSelectedItemPendingAnimationInTopNav != null)
		{
			return;
		}
		UIElement activeIndicator = m_activeIndicator;
		UIElement uIElement = FindSelectionIndicator(nextItem);
		bool flag = false;
		if (m_prevIndicator != null || m_nextIndicator != null)
		{
			if (uIElement != null && m_nextIndicator == uIElement)
			{
				if (activeIndicator != null && activeIndicator != m_prevIndicator)
				{
					ResetElementAnimationProperties(activeIndicator, 0f);
				}
				flag = true;
			}
			else
			{
				OnAnimationComplete(null, null);
			}
		}
		if (flag)
		{
			return;
		}
		UIElement paneContentGrid = m_paneContentGrid;
		if (activeIndicator != uIElement && paneContentGrid != null && activeIndicator != null && uIElement != null && SharedHelpers.IsAnimationsEnabled())
		{
			ResetElementAnimationProperties(activeIndicator, 1f);
			ResetElementAnimationProperties(uIElement, 1f);
			Point point = new Point(0.0, 0.0);
			Point point2 = activeIndicator.TransformToVisual(paneContentGrid).TransformPoint(point);
			Point point3 = uIElement.TransformToVisual(paneContentGrid).TransformPoint(point);
			Size renderSize = activeIndicator.RenderSize;
			Size renderSize2 = uIElement.RenderSize;
			bool flag2 = false;
			if (IsTopNavigationView())
			{
				double x = point2.X;
				double x2 = point3.X;
				flag2 = point2.Y == point3.Y;
			}
			else
			{
				double x = point2.Y;
				double x2 = point3.Y;
				flag2 = point2.X == point3.X;
			}
			m_prevIndicator = activeIndicator;
			m_nextIndicator = uIElement;
			OnAnimationComplete(null, null);
		}
		else
		{
			ResetElementAnimationProperties(activeIndicator, 0f);
			ResetElementAnimationProperties(uIElement, 1f);
		}
		m_activeIndicator = uIElement;
	}

	private void PlayIndicatorNonSameLevelAnimations(UIElement indicator, bool isOutgoing, bool fromTop)
	{
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(indicator);
		Compositor compositor = elementVisual.Compositor;
		float value = (isOutgoing ? 1f : 0f);
		float value2 = (isOutgoing ? 0f : 1f);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation.InsertKeyFrame(0f, value);
		scalarKeyFrameAnimation.InsertKeyFrame(1f, value2);
		scalarKeyFrameAnimation.Duration = TimeSpan.FromMilliseconds(600.0);
		Size renderSize = indicator.RenderSize;
		double num = (IsTopNavigationView() ? renderSize.Width : renderSize.Height);
		double num2 = (fromTop ? 0.0 : num);
		Vector3 centerPoint = elementVisual.CenterPoint;
		centerPoint.Y = (float)num2;
		elementVisual.CenterPoint = centerPoint;
		elementVisual.StartAnimation("Scale.Y", scalarKeyFrameAnimation);
	}

	private void PlayIndicatorNonSameLevelTopPrimaryAnimation(UIElement indicator, bool isOutgoing)
	{
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(indicator);
		Compositor compositor = elementVisual.Compositor;
		float value = (isOutgoing ? 1f : 0f);
		float value2 = (isOutgoing ? 0f : 1f);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation.InsertKeyFrame(0f, value);
		scalarKeyFrameAnimation.InsertKeyFrame(1f, value2);
		scalarKeyFrameAnimation.Duration = TimeSpan.FromMilliseconds(600.0);
		double num = indicator.RenderSize.Width / 2.0;
		Vector3 centerPoint = elementVisual.CenterPoint;
		centerPoint.Y = (float)num;
		elementVisual.CenterPoint = centerPoint;
		elementVisual.StartAnimation("Scale.X", scalarKeyFrameAnimation);
	}

	private void PlayIndicatorAnimations(UIElement indicator, float from, float to, Size beginSize, Size endSize, bool isOutgoing)
	{
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(indicator);
		Compositor compositor = elementVisual.Compositor;
		Size renderSize = indicator.RenderSize;
		float num = (IsTopNavigationView() ? ((float)renderSize.Width) : ((float)renderSize.Height));
		float num2 = 1f;
		float num3 = 1f;
		if (IsTopNavigationView() && Math.Abs(renderSize.Width) > 0.0010000000474974513)
		{
			num2 = (float)(beginSize.Width / renderSize.Width);
			num3 = (float)(endSize.Width / renderSize.Width);
		}
		StepEasingFunction stepEasingFunction = compositor.CreateStepEasingFunction();
		stepEasingFunction.IsFinalStepSingleFrame = true;
		if (isOutgoing)
		{
			ScalarKeyFrameAnimation scalarKeyFrameAnimation = compositor.CreateScalarKeyFrameAnimation();
			scalarKeyFrameAnimation.InsertKeyFrame(0f, 1f);
			scalarKeyFrameAnimation.InsertKeyFrame(0.333f, 1f, stepEasingFunction);
			scalarKeyFrameAnimation.InsertKeyFrame(1f, 0f, compositor.CreateCubicBezierEasingFunction(c_frame2point1, c_frame2point2));
			scalarKeyFrameAnimation.Duration = TimeSpan.FromMilliseconds(600.0);
			elementVisual.StartAnimation("Opacity", scalarKeyFrameAnimation);
		}
		ScalarKeyFrameAnimation scalarKeyFrameAnimation2 = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation2.InsertKeyFrame(0f, (from < to) ? from : (from + num * (num2 - 1f)));
		scalarKeyFrameAnimation2.InsertKeyFrame(0.333f, (from < to) ? (to + num * (num3 - 1f)) : to, stepEasingFunction);
		scalarKeyFrameAnimation2.Duration = TimeSpan.FromMilliseconds(600.0);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation3 = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation3.InsertKeyFrame(0f, num2);
		scalarKeyFrameAnimation3.InsertKeyFrame(0.333f, Math.Abs(to - from) / num + ((from < to) ? num3 : num2), compositor.CreateCubicBezierEasingFunction(c_frame1point1, c_frame1point2));
		scalarKeyFrameAnimation3.InsertKeyFrame(1f, num3, compositor.CreateCubicBezierEasingFunction(c_frame2point1, c_frame2point2));
		scalarKeyFrameAnimation3.Duration = TimeSpan.FromMilliseconds(600.0);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation4 = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation4.InsertKeyFrame(0f, (from < to) ? 0f : num);
		scalarKeyFrameAnimation4.InsertKeyFrame(1f, (from < to) ? num : 0f, stepEasingFunction);
		scalarKeyFrameAnimation4.Duration = TimeSpan.FromMilliseconds(200.0);
		if (IsTopNavigationView())
		{
			elementVisual.StartAnimation("Offset.X", scalarKeyFrameAnimation2);
			elementVisual.StartAnimation("Scale.X", scalarKeyFrameAnimation3);
			elementVisual.StartAnimation("CenterPoint.X", scalarKeyFrameAnimation4);
		}
		else
		{
			elementVisual.StartAnimation("Offset.Y", scalarKeyFrameAnimation2);
			elementVisual.StartAnimation("Scale.Y", scalarKeyFrameAnimation3);
			elementVisual.StartAnimation("CenterPoint.Y", scalarKeyFrameAnimation4);
		}
	}

	private void OnAnimationComplete(object sender, CompositionBatchCompletedEventArgs args)
	{
		UIElement prevIndicator = m_prevIndicator;
		ResetElementAnimationProperties(prevIndicator, 0f);
		m_prevIndicator = null;
		prevIndicator = m_nextIndicator;
		ResetElementAnimationProperties(prevIndicator, 1f);
		m_nextIndicator = null;
	}

	private void ResetElementAnimationProperties(UIElement element, float desiredOpacity)
	{
		if (element != null)
		{
			element.Opacity = desiredOpacity;
			Visual elementVisual = ElementCompositionPreview.GetElementVisual(element);
			if (elementVisual != null)
			{
				elementVisual.Offset = new Vector3(0f, 0f, 0f);
				elementVisual.Scale = new Vector3(1f, 1f, 1f);
				elementVisual.Opacity = desiredOpacity;
			}
		}
	}

	private NavigationViewItemBase NavigationViewItemBaseOrSettingsContentFromData(object data)
	{
		return GetContainerForData<NavigationViewItemBase>(data);
	}

	private NavigationViewItem NavigationViewItemOrSettingsContentFromData(object data)
	{
		return GetContainerForData<NavigationViewItem>(data);
	}

	private bool IsSelectionSuppressed(object item)
	{
		if (item != null)
		{
			NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(item);
			if (navigationViewItem != null)
			{
				return !navigationViewItem.SelectsOnInvoked;
			}
		}
		return false;
	}

	private bool ShouldPreserveNavigationViewRS4Behavior()
	{
		return m_topNavGrid == null;
	}

	private bool ShouldPreserveNavigationViewRS3Behavior()
	{
		return m_backButton == null;
	}

	private UIElement FindSelectionIndicator(object item)
	{
		if (item != null)
		{
			NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(item);
			if (navigationViewItem != null)
			{
				UIElement selectionIndicator = navigationViewItem.GetSelectionIndicator();
				if (selectionIndicator != null)
				{
					return selectionIndicator;
				}
				navigationViewItem.UpdateLayout();
				return navigationViewItem.GetSelectionIndicator();
			}
		}
		return null;
	}

	private void RaiseSelectionChangedEvent(object nextItem, bool isSettingsItem, NavigationRecommendedTransitionDirection recommendedDirection)
	{
		NavigationViewSelectionChangedEventArgs navigationViewSelectionChangedEventArgs = new NavigationViewSelectionChangedEventArgs();
		navigationViewSelectionChangedEventArgs.SelectedItem = nextItem;
		navigationViewSelectionChangedEventArgs.IsSettingsSelected = isSettingsItem;
		NavigationViewItemBase navigationViewItemBase = NavigationViewItemBaseOrSettingsContentFromData(nextItem);
		if (navigationViewItemBase != null)
		{
			navigationViewSelectionChangedEventArgs.SelectedItemContainer = navigationViewItemBase;
		}
		navigationViewSelectionChangedEventArgs.RecommendedNavigationTransitionInfo = CreateNavigationTransitionInfo(recommendedDirection);
		this.SelectionChanged?.Invoke(this, navigationViewSelectionChangedEventArgs);
	}

	private void ChangeSelection(object prevItem, object nextItem)
	{
		bool flag = IsSettingsItem(nextItem);
		if (IsSelectionSuppressed(nextItem))
		{
			UndoSelectionAndRevertSelectionTo(prevItem, nextItem);
			RaiseItemInvoked(nextItem, flag);
			return;
		}
		NavigationRecommendedTransitionDirection recommendedDirection = GetRecommendedDirection(prevItem, nextItem);
		object selectedItem = SelectedItem;
		if (m_shouldRaiseItemInvokedAfterSelection)
		{
			m_shouldRaiseItemInvokedAfterSelection = false;
			RaiseItemInvoked(nextItem, flag, NavigationViewItemOrSettingsContentFromData(nextItem), recommendedDirection);
		}
		if (selectedItem != SelectedItem)
		{
			return;
		}
		UnselectPrevItem(prevItem, nextItem);
		ChangeSelectStatusForItem(nextItem, selected: true);
		try
		{
			if (!m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise)
			{
				AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
				if (automationPeer != null)
				{
					NavigationViewAutomationPeer navigationViewAutomationPeer = (NavigationViewAutomationPeer)automationPeer;
					navigationViewAutomationPeer.RaiseSelectionChangedEvent(prevItem, nextItem);
				}
			}
		}
		finally
		{
			m_shouldIgnoreUIASelectionRaiseAsExpandCollapseWillRaise = false;
		}
		RaiseSelectionChangedEvent(nextItem, flag, recommendedDirection);
		AnimateSelectionChanged(nextItem);
		NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(nextItem);
		if (navigationViewItem != null)
		{
			ClosePaneIfNeccessaryAfterItemIsClicked(navigationViewItem);
		}
		NavigationRecommendedTransitionDirection GetRecommendedDirection(object prevItem, object nextItem)
		{
			if (IsTopNavigationView())
			{
				if (m_selectionChangeFromOverflowMenu)
				{
					return NavigationRecommendedTransitionDirection.FromOverflow;
				}
				if (prevItem != null && nextItem != null)
				{
					return GetRecommendedTransitionDirection(NavigationViewItemBaseOrSettingsContentFromData(prevItem), NavigationViewItemBaseOrSettingsContentFromData(nextItem));
				}
			}
			return NavigationRecommendedTransitionDirection.Default;
		}
	}

	private void UpdateSelectionModelSelection(IndexPath ip)
	{
		IndexPath selectedIndex = m_selectionModel.SelectedIndex;
		m_selectionModel.SelectAt(ip);
		UpdateIsChildSelected(selectedIndex, ip);
	}

	private void UpdateIsChildSelected(IndexPath prevIP, IndexPath nextIP)
	{
		if (prevIP != null && prevIP.GetSize() > 0)
		{
			UpdateIsChildSelectedForIndexPath(prevIP, isChildSelected: false);
		}
		if (nextIP != null && nextIP.GetSize() > 0)
		{
			UpdateIsChildSelectedForIndexPath(nextIP, isChildSelected: true);
		}
	}

	private void UpdateIsChildSelectedForIndexPath(IndexPath ip, bool isChildSelected)
	{
		UIElement uIElement = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == 1);
		int num = 2;
		while (uIElement != null)
		{
			if (uIElement is NavigationViewItem navigationViewItem)
			{
				navigationViewItem.IsChildSelected = isChildSelected;
				ItemsRepeater repeater = navigationViewItem.GetRepeater();
				if (repeater != null && num < ip.GetSize() - 1)
				{
					uIElement = repeater.TryGetElement(ip.GetAt(num));
					num++;
					continue;
				}
			}
			uIElement = null;
		}
	}

	private void RaiseItemInvoked(object item, bool isSettings, NavigationViewItemBase container = null, NavigationRecommendedTransitionDirection recommendedDirection = NavigationRecommendedTransitionDirection.Default)
	{
		object invokedItem = item;
		NavigationViewItemBase invokedItemContainer = container;
		NavigationViewItemInvokedEventArgs navigationViewItemInvokedEventArgs = new NavigationViewItemInvokedEventArgs();
		if (container != null)
		{
			invokedItem = container.Content;
		}
		else if (!isSettings)
		{
			NavigationViewItemBase navigationViewItemBase = NavigationViewItemBaseOrSettingsContentFromData(item);
			if (navigationViewItemBase != null)
			{
				invokedItem = navigationViewItemBase.Content;
				invokedItemContainer = navigationViewItemBase;
			}
		}
		else
		{
			invokedItemContainer = item as NavigationViewItemBase;
		}
		navigationViewItemInvokedEventArgs.InvokedItem = invokedItem;
		navigationViewItemInvokedEventArgs.InvokedItemContainer = invokedItemContainer;
		navigationViewItemInvokedEventArgs.IsSettingsInvoked = isSettings;
		navigationViewItemInvokedEventArgs.RecommendedNavigationTransitionInfo = CreateNavigationTransitionInfo(recommendedDirection);
		this.ItemInvoked?.Invoke(this, navigationViewItemInvokedEventArgs);
	}

	private void SetDisplayMode(NavigationViewDisplayMode displayMode, bool forceSetDisplayMode)
	{
		UpdateVisualStateForDisplayModeGroup(displayMode);
		if (forceSetDisplayMode || DisplayMode != displayMode)
		{
			UpdateHeaderVisibility(displayMode);
			UpdatePaneTabFocusNavigation();
			UpdatePaneToggleSize();
			RaiseDisplayModeChanged(displayMode);
		}
	}

	private NavigationViewVisualStateDisplayMode GetVisualStateDisplayMode(NavigationViewDisplayMode displayMode)
	{
		NavigationViewPaneDisplayMode paneDisplayMode = PaneDisplayMode;
		if (IsTopNavigationView())
		{
			return NavigationViewVisualStateDisplayMode.Minimal;
		}
		if (paneDisplayMode == NavigationViewPaneDisplayMode.Left || (paneDisplayMode == NavigationViewPaneDisplayMode.Auto && displayMode == NavigationViewDisplayMode.Expanded))
		{
			return NavigationViewVisualStateDisplayMode.Expanded;
		}
		if (paneDisplayMode == NavigationViewPaneDisplayMode.LeftCompact || (paneDisplayMode == NavigationViewPaneDisplayMode.Auto && displayMode == NavigationViewDisplayMode.Compact))
		{
			return NavigationViewVisualStateDisplayMode.Compact;
		}
		if (ShouldShowBackButton() || ShouldShowCloseButton())
		{
			return NavigationViewVisualStateDisplayMode.MinimalWithBackButton;
		}
		return NavigationViewVisualStateDisplayMode.Minimal;
	}

	private void UpdateVisualStateForDisplayModeGroup(NavigationViewDisplayMode displayMode)
	{
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			NavigationViewVisualStateDisplayMode visualStateDisplayMode = GetVisualStateDisplayMode(displayMode);
			string text = "";
			SplitViewDisplayMode displayMode2 = SplitViewDisplayMode.Overlay;
			string text2 = "Minimal";
			switch (visualStateDisplayMode)
			{
			case NavigationViewVisualStateDisplayMode.MinimalWithBackButton:
				text = "MinimalWithBackButton";
				displayMode2 = SplitViewDisplayMode.Overlay;
				break;
			case NavigationViewVisualStateDisplayMode.Minimal:
				text = text2;
				displayMode2 = SplitViewDisplayMode.Overlay;
				break;
			case NavigationViewVisualStateDisplayMode.Compact:
				text = "Compact";
				displayMode2 = SplitViewDisplayMode.CompactOverlay;
				break;
			case NavigationViewVisualStateDisplayMode.Expanded:
				text = "Expanded";
				displayMode2 = SplitViewDisplayMode.CompactInline;
				break;
			}
			if (!IsPaneVisible)
			{
				displayMode2 = SplitViewDisplayMode.CompactOverlay;
			}
			bool flag = false;
			if (text == text2 && IsTopNavigationView())
			{
				flag = VisualStateManager.GoToState(this, "TopNavigationMinimal", useTransitions: false);
			}
			if (!flag)
			{
				VisualStateManager.GoToState(this, text, useTransitions: false);
			}
			if (m_fromOnApplyTemplate)
			{
				m_updateVisualStateForDisplayModeFromOnLoaded = true;
			}
			else
			{
				rootSplitView.DisplayMode = displayMode2;
			}
		}
	}

	private void OnNavigationViewItemTapped(object sender, TappedRoutedEventArgs args)
	{
		if (sender is NavigationViewItem navigationViewItem)
		{
			OnNavigationViewItemInvoked(navigationViewItem);
			navigationViewItem.Focus(FocusState.Pointer);
			args.Handled = true;
		}
	}

	private void OnNavigationViewItemKeyDown(object sender, KeyRoutedEventArgs args)
	{
		if (args.OriginalKey == VirtualKey.GamepadA || args.Key == VirtualKey.Enter || args.Key == VirtualKey.Space)
		{
			if (!args.KeyStatus.WasKeyDown && sender is NavigationViewItem nvi)
			{
				HandleKeyEventForNavigationViewItem(nvi, args);
			}
		}
		else if (sender is NavigationViewItem nvi2)
		{
			HandleKeyEventForNavigationViewItem(nvi2, args);
		}
	}

	private void HandleKeyEventForNavigationViewItem(NavigationViewItem nvi, KeyRoutedEventArgs args)
	{
		switch (args.Key)
		{
		case VirtualKey.Enter:
		case VirtualKey.Space:
			args.Handled = true;
			OnNavigationViewItemInvoked(nvi);
			break;
		case VirtualKey.Home:
			args.Handled = true;
			KeyboardFocusFirstItemFromItem(nvi);
			break;
		case VirtualKey.End:
			args.Handled = true;
			KeyboardFocusLastItemFromItem(nvi);
			break;
		case VirtualKey.Down:
			FocusNextDownItem(nvi, args);
			break;
		case VirtualKey.Up:
			FocusNextUpItem(nvi, args);
			break;
		}
	}

	private void FocusNextUpItem(NavigationViewItem nvi, KeyRoutedEventArgs args)
	{
		if (args.OriginalSource != nvi)
		{
			return;
		}
		bool flag = true;
		UIElement uIElement = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Up);
		if (uIElement is NavigationViewItem navigationViewItem)
		{
			NavigationViewItem navigationViewItem2 = navigationViewItem;
			if (navigationViewItem2.Depth == nvi.Depth)
			{
				if (DoesNavigationViewItemHaveChildren(navigationViewItem))
				{
					ItemsRepeater repeater = navigationViewItem2.GetRepeater();
					if (repeater != null)
					{
						DependencyObject dependencyObject = FocusManager.FindLastFocusableElement(repeater);
						if (dependencyObject != null)
						{
							if (dependencyObject is Control control)
							{
								args.Handled = control.Focus(FocusState.Keyboard);
							}
						}
						else
						{
							args.Handled = navigationViewItem2.Focus(FocusState.Keyboard);
						}
					}
				}
				else
				{
					flag = false;
				}
			}
		}
		if (flag && !args.Handled && nvi.Depth > 0)
		{
			NavigationViewItem parentNavigationViewItemForContainer = GetParentNavigationViewItemForContainer(nvi);
			if (parentNavigationViewItemForContainer != null)
			{
				args.Handled = parentNavigationViewItemForContainer.Focus(FocusState.Keyboard);
			}
		}
	}

	private void FocusNextDownItem(NavigationViewItem nvi, KeyRoutedEventArgs args)
	{
		if (args.OriginalSource != nvi || !DoesNavigationViewItemHaveChildren(nvi))
		{
			return;
		}
		ItemsRepeater repeater = nvi.GetRepeater();
		if (repeater != null)
		{
			DependencyObject dependencyObject = FocusManager.FindFirstFocusableElement(repeater);
			if (dependencyObject is Control control)
			{
				args.Handled = control.Focus(FocusState.Keyboard);
			}
		}
	}

	private void KeyboardFocusFirstItemFromItem(NavigationViewItemBase nvib)
	{
		ItemsRepeater parentRootItemsRepeaterForContainer = GetParentRootItemsRepeaterForContainer(nvib);
		UIElement uIElement = parentRootItemsRepeaterForContainer.TryGetElement(0);
		if (uIElement is Control control)
		{
			control.Focus(FocusState.Keyboard);
		}
	}

	private void KeyboardFocusLastItemFromItem(NavigationViewItemBase nvib)
	{
		ItemsRepeater parentRootItemsRepeaterForContainer = GetParentRootItemsRepeaterForContainer(nvib);
		ItemsSourceView itemsSourceView = parentRootItemsRepeaterForContainer.ItemsSourceView;
		if (itemsSourceView != null)
		{
			int index = itemsSourceView.Count - 1;
			UIElement uIElement = parentRootItemsRepeaterForContainer.TryGetElement(index);
			if (uIElement != null && uIElement is Control control)
			{
				control.Focus(FocusState.Programmatic);
			}
		}
	}

	private void OnRepeaterGettingFocus(object sender, GettingFocusEventArgs args)
	{
		if (m_TabKeyPrecedesFocusChange && args.InputDevice == FocusInputDeviceKind.Keyboard && m_selectionModel.SelectedIndex != null)
		{
			DependencyObject oldFocusedElement2 = args.OldFocusedElement;
			if (oldFocusedElement2 != null && sender is ItemsRepeater itemsRepeater)
			{
				bool flag = GetIsFocusOutsideCurrentRootRepeater(oldFocusedElement2, itemsRepeater);
				ItemsRepeater itemsRepeater2 = GetRootRepeaterForSelectedItem();
				if (args != null)
				{
					if (itemsRepeater == itemsRepeater2 && flag)
					{
						NavigationViewItemBase containerForIndexPath = GetContainerForIndexPath(m_selectionModel.SelectedIndex, lastVisible: true);
						if (args.TrySetNewFocusedElement(containerForIndexPath))
						{
							args.Handled = true;
						}
					}
				}
			}
		}
		m_TabKeyPrecedesFocusChange = false;
		bool GetIsFocusOutsideCurrentRootRepeater(DependencyObject oldFocusedElement, ItemsRepeater newRootItemsRepeater)
		{
			bool result = true;
			for (DependencyObject dependencyObject = oldFocusedElement; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
			{
				if (dependencyObject is NavigationViewItemBase nvib)
				{
					ItemsRepeater parentRootItemsRepeaterForContainer = GetParentRootItemsRepeaterForContainer(nvib);
					result = parentRootItemsRepeaterForContainer != newRootItemsRepeater;
					break;
				}
			}
			return result;
		}
		ItemsRepeater GetRootRepeaterForSelectedItem()
		{
			if (IsTopNavigationView())
			{
				if (m_selectionModel.SelectedIndex.GetAt(0) != 0)
				{
					return m_topNavFooterMenuRepeater;
				}
				return m_topNavRepeater;
			}
			if (m_selectionModel.SelectedIndex.GetAt(0) != 0)
			{
				return m_leftNavFooterMenuRepeater;
			}
			return m_leftNavRepeater;
		}
	}

	private void OnNavigationViewItemOnGotFocus(object sender, RoutedEventArgs e)
	{
		if (!(sender is NavigationViewItem navigationViewItem) || !IsNavigationViewListSingleSelectionFollowsFocus() || !navigationViewItem.SelectsOnInvoked || navigationViewItem.IsSelected)
		{
			return;
		}
		if (IsTopNavigationView())
		{
			ItemsRepeater parentItemsRepeaterForContainer = GetParentItemsRepeaterForContainer(navigationViewItem);
			if (parentItemsRepeaterForContainer != null && parentItemsRepeaterForContainer != m_topNavRepeaterOverflowView)
			{
				OnNavigationViewItemInvoked(navigationViewItem);
			}
		}
		else
		{
			OnNavigationViewItemInvoked(navigationViewItem);
		}
	}

	internal void OnSettingsInvoked()
	{
		NavigationViewItem settingsItem = m_settingsItem;
		if (settingsItem != null)
		{
			OnNavigationViewItemInvoked(settingsItem);
		}
	}

	protected override void OnPreviewKeyDown(KeyRoutedEventArgs e)
	{
		m_TabKeyPrecedesFocusChange = false;
		base.OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs e)
	{
		VirtualKey key = e.Key;
		bool handled = false;
		m_TabKeyPrecedesFocusChange = false;
		switch (key)
		{
		case VirtualKey.GamepadView:
			if (!IsPaneOpen && !IsTopNavigationView())
			{
				OpenPane();
				handled = true;
			}
			break;
		case VirtualKey.XButton1:
		case VirtualKey.GoBack:
			if (IsPaneOpen && IsLightDismissible())
			{
				handled = AttemptClosePaneLightly();
			}
			break;
		case VirtualKey.GamepadLeftShoulder:
			handled = BumperNavigation(-1);
			break;
		case VirtualKey.GamepadRightShoulder:
			handled = BumperNavigation(1);
			break;
		case VirtualKey.Tab:
			m_TabKeyPrecedesFocusChange = true;
			break;
		case VirtualKey.Left:
		{
			CoreVirtualKeyStates keyState = CoreWindow.GetForCurrentThread()!.GetKeyState(VirtualKey.Menu);
			if ((keyState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down && IsPaneOpen && IsLightDismissible())
			{
				handled = AttemptClosePaneLightly();
			}
			break;
		}
		}
		e.Handled = handled;
		base.OnKeyDown(e);
	}

	private bool BumperNavigation(int offset)
	{
		NavigationViewShoulderNavigationEnabled shoulderNavigationEnabled = ShoulderNavigationEnabled;
		bool flag = shoulderNavigationEnabled == NavigationViewShoulderNavigationEnabled.Never;
		bool flag2 = shoulderNavigationEnabled == NavigationViewShoulderNavigationEnabled.WhenSelectionFollowsFocus && SelectionFollowsFocus == NavigationViewSelectionFollowsFocus.Disabled;
		if (!IsTopNavigationView() || flag2 || flag)
		{
			return false;
		}
		if ((SelectionFollowsFocus != NavigationViewSelectionFollowsFocus.Enabled || shoulderNavigationEnabled != 0) && shoulderNavigationEnabled != NavigationViewShoulderNavigationEnabled.Always)
		{
			return false;
		}
		object selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(selectedItem);
			if (navigationViewItem != null)
			{
				IndexPath indexPathForContainer = GetIndexPathForContainer(navigationViewItem);
				bool flag3 = indexPathForContainer.GetAt(0) == 1;
				int num = (flag3 ? (-1) : indexPathForContainer.GetAt(1));
				int num2 = (flag3 ? indexPathForContainer.GetAt(1) : (-1));
				ItemsRepeater topNavRepeater = m_topNavRepeater;
				int primaryListSize = m_topDataProvider.GetPrimaryListSize();
				ItemsRepeater topNavFooterMenuRepeater = m_topNavFooterMenuRepeater;
				int num3 = FooterMenuItems.Count;
				if (IsSettingsVisible)
				{
					num3++;
				}
				if (num >= 0)
				{
					if (SelectSelectableItemWithOffset(num, offset, topNavRepeater, primaryListSize))
					{
						return true;
					}
					if (offset > 0)
					{
						return SelectSelectableItemWithOffset(-1, offset, topNavFooterMenuRepeater, num3);
					}
					return false;
				}
				if (num2 >= 0)
				{
					if (SelectSelectableItemWithOffset(num2, offset, topNavFooterMenuRepeater, num3))
					{
						return true;
					}
					if (offset < 0)
					{
						return SelectSelectableItemWithOffset(primaryListSize, offset, topNavRepeater, primaryListSize);
					}
				}
			}
		}
		return false;
	}

	private bool SelectSelectableItemWithOffset(int startIndex, int offset, ItemsRepeater repeater, int repeaterCollectionSize)
	{
		startIndex += offset;
		while (startIndex > -1 && startIndex < repeaterCollectionSize)
		{
			UIElement uIElement = repeater.TryGetElement(startIndex);
			if (uIElement is NavigationViewItem navigationViewItem && navigationViewItem.SelectsOnInvoked)
			{
				navigationViewItem.IsSelected = true;
				return true;
			}
			startIndex += offset;
		}
		return false;
	}

	public object MenuItemFromContainer(DependencyObject container)
	{
		if (container != null && container is NavigationViewItemBase navigationViewItemBase)
		{
			ItemsRepeater parentItemsRepeaterForContainer = GetParentItemsRepeaterForContainer(navigationViewItemBase);
			if (parentItemsRepeaterForContainer != null)
			{
				int elementIndex = parentItemsRepeaterForContainer.GetElementIndex(navigationViewItemBase);
				if (elementIndex >= 0)
				{
					return GetItemFromIndex(parentItemsRepeaterForContainer, elementIndex);
				}
			}
		}
		return null;
	}

	public DependencyObject ContainerFromMenuItem(object item)
	{
		if (item != null)
		{
			return NavigationViewItemBaseOrSettingsContentFromData(item);
		}
		return null;
	}

	private void OnTopNavDataSourceChanged(NotifyCollectionChangedEventArgs args)
	{
		CloseTopNavigationViewFlyout();
		if (m_topNavigationMode != 0)
		{
			m_topDataProvider.MoveAllItemsToPrimaryList();
		}
		m_lastSelectedItemPendingAnimationInTopNav = null;
	}

	internal int GetNavigationViewItemCountInPrimaryList()
	{
		return m_topDataProvider.GetNavigationViewItemCountInPrimaryList();
	}

	internal int GetNavigationViewItemCountInTopNav()
	{
		return m_topDataProvider.GetNavigationViewItemCountInTopNav();
	}

	internal SplitView GetSplitView()
	{
		return m_rootSplitView;
	}

	internal void TopNavigationViewItemContentChanged()
	{
		if (m_appliedTemplate)
		{
			if (MenuItemsSource == null)
			{
				m_topDataProvider.InvalidWidthCache();
			}
			InvalidateMeasure();
		}
	}

	private void OnAccessKeyInvoked(object sender, AccessKeyInvokedEventArgs args)
	{
		if (!args.Handled)
		{
			Button button = (IsTopNavigationView() ? m_topNavOverflowButton : m_paneToggleButton);
			if (button != null && FrameworkElementAutomationPeer.FromElement(button) is ButtonAutomationPeer buttonAutomationPeer)
			{
				buttonAutomationPeer.Invoke();
				args.Handled = true;
			}
		}
	}

	private NavigationTransitionInfo CreateNavigationTransitionInfo(NavigationRecommendedTransitionDirection recommendedTransitionDirection)
	{
		if (recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromOverflow)
		{
			recommendedTransitionDirection = NavigationRecommendedTransitionDirection.FromRight;
		}
		if ((recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromLeft || recommendedTransitionDirection == NavigationRecommendedTransitionDirection.FromRight) && SharedHelpers.IsRS5OrHigher())
		{
			SlideNavigationTransitionInfo slideNavigationTransitionInfo = new SlideNavigationTransitionInfo();
			SlideNavigationTransitionEffect effect = ((recommendedTransitionDirection != NavigationRecommendedTransitionDirection.FromRight) ? SlideNavigationTransitionEffect.FromLeft : SlideNavigationTransitionEffect.FromRight);
			if (slideNavigationTransitionInfo != null)
			{
				SlideNavigationTransitionInfo slideNavigationTransitionInfo2 = slideNavigationTransitionInfo;
				slideNavigationTransitionInfo.Effect = effect;
			}
			return slideNavigationTransitionInfo;
		}
		return new EntranceNavigationTransitionInfo();
	}

	private NavigationRecommendedTransitionDirection GetRecommendedTransitionDirection(DependencyObject prev, DependencyObject next)
	{
		NavigationRecommendedTransitionDirection result = NavigationRecommendedTransitionDirection.Default;
		ItemsRepeater topNavRepeater = m_topNavRepeater;
		if (prev != null && next != null && topNavRepeater != null)
		{
			IndexPath indexPathForContainer = GetIndexPathForContainer(prev as NavigationViewItemBase);
			IndexPath indexPathForContainer2 = GetIndexPathForContainer(next as NavigationViewItemBase);
			result = indexPathForContainer.CompareTo(indexPathForContainer2) switch
			{
				-1 => NavigationRecommendedTransitionDirection.FromRight, 
				1 => NavigationRecommendedTransitionDirection.FromLeft, 
				_ => NavigationRecommendedTransitionDirection.Default, 
			};
		}
		return result;
	}

	private NavigationViewTemplateSettings GetTemplateSettings()
	{
		return TemplateSettings;
	}

	private bool IsNavigationViewListSingleSelectionFollowsFocus()
	{
		return SelectionFollowsFocus == NavigationViewSelectionFollowsFocus.Enabled;
	}

	private void UpdateSingleSelectionFollowsFocusTemplateSetting()
	{
		GetTemplateSettings().SingleSelectionFollowsFocus = IsNavigationViewListSingleSelectionFollowsFocus();
	}

	private void OnMenuItemsSourceCollectionChanged(object sender, object args)
	{
		if (!IsTopNavigationView())
		{
			m_leftNavRepeater?.UpdateLayout();
			UpdatePaneLayout();
		}
	}

	private void OnSelectedItemPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		object newValue = args.NewValue;
		object oldValue = args.OldValue;
		ChangeSelection(oldValue, newValue);
		if (m_appliedTemplate && IsTopNavigationView() && (m_layoutUpdatedToken.Disposable == null || (newValue != null && m_topDataProvider.IndexOf(newValue) != itemNotFound && m_topDataProvider.IndexOf(newValue, NavigationViewSplitVectorID.PrimaryList) == itemNotFound)))
		{
			InvalidateTopNavPrimaryLayout();
		}
	}

	private void SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(object item)
	{
		SelectedItem = item;
	}

	private void ChangeSelectStatusForItem(object item, bool selected)
	{
		NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(item);
		if (navigationViewItem != null)
		{
			navigationViewItem.IsSelected = selected;
		}
		else
		{
			if (!selected)
			{
				return;
			}
			IndexPath indexPathOfItem = GetIndexPathOfItem(item);
			if (indexPathOfItem != null && indexPathOfItem.GetSize() > 0)
			{
				try
				{
					m_shouldIgnoreNextSelectionChange = true;
					UpdateSelectionModelSelection(indexPathOfItem);
				}
				finally
				{
					m_shouldIgnoreNextSelectionChange = false;
				}
			}
		}
	}

	private bool IsSettingsItem(object item)
	{
		bool result = false;
		if (item != null)
		{
			NavigationViewItem settingsItem = m_settingsItem;
			if (settingsItem != null)
			{
				result = settingsItem == item || settingsItem.Content == item;
			}
		}
		return result;
	}

	private void UnselectPrevItem(object prevItem, object nextItem)
	{
		if (prevItem == null || prevItem == nextItem)
		{
			return;
		}
		bool flag = !m_shouldIgnoreNextSelectionChange;
		try
		{
			m_shouldIgnoreNextSelectionChange = true;
			ChangeSelectStatusForItem(prevItem, selected: false);
		}
		finally
		{
			if (flag)
			{
				m_shouldIgnoreNextSelectionChange = false;
			}
		}
	}

	private void UndoSelectionAndRevertSelectionTo(object prevSelectedItem, object nextItem)
	{
		object selectedItem = null;
		if (prevSelectedItem != null)
		{
			if (IsSelectionSuppressed(prevSelectedItem))
			{
				AnimateSelectionChanged(null);
			}
			else
			{
				ChangeSelectStatusForItem(prevSelectedItem, selected: true);
				AnimateSelectionChangedToItem(prevSelectedItem);
				selectedItem = prevSelectedItem;
			}
		}
		else
		{
			ChangeSelectStatusForItem(nextItem, selected: false);
		}
		SelectedItem = selectedItem;
	}

	private void CloseTopNavigationViewFlyout()
	{
		m_topNavOverflowButton?.Flyout?.Hide();
	}

	private new void UpdateVisualState(bool useTransitions = false)
	{
		if (m_appliedTemplate)
		{
			AutoSuggestBox autoSuggestBox = AutoSuggestBox;
			VisualStateManager.GoToState(this, (autoSuggestBox != null) ? "AutoSuggestBoxVisible" : "AutoSuggestBoxCollapsed", useTransitions: false);
			bool isSettingsVisible = IsSettingsVisible;
			VisualStateManager.GoToState(this, isSettingsVisible ? "SettingsVisible" : "SettingsCollapsed", useTransitions: false);
			if (IsTopNavigationView())
			{
				UpdateVisualStateForOverflowButton();
			}
			else
			{
				UpdateLeftNavigationOnlyVisualState(useTransitions);
			}
		}
	}

	private void UpdateVisualStateForOverflowButton()
	{
		string stateName = ((OverflowLabelMode == NavigationViewOverflowLabelMode.MoreLabel) ? "OverflowButtonWithLabel" : "OverflowButtonNoLabel");
		VisualStateManager.GoToState(this, stateName, useTransitions: false);
	}

	private void UpdateLeftNavigationOnlyVisualState(bool useTransitions)
	{
		bool isPaneToggleButtonVisible = IsPaneToggleButtonVisible;
		VisualStateManager.GoToState(this, (isPaneToggleButtonVisible || !m_isLeftPaneTitleEmpty) ? "TogglePaneButtonVisible" : "TogglePaneButtonCollapsed", useTransitions: false);
	}

	private void SetNavigationViewItemRevokers(NavigationViewItem nvi)
	{
		nvi.Tapped += OnNavigationViewItemTapped;
		nvi.KeyDown += OnNavigationViewItemKeyDown;
		nvi.GotFocus += OnNavigationViewItemOnGotFocus;
		long isSelectedSubscription = nvi.RegisterPropertyChangedCallback(NavigationViewItemBase.IsSelectedProperty, OnNavigationViewItemIsSelectedPropertyChanged);
		long isExpandedSubscription = nvi.RegisterPropertyChangedCallback(NavigationViewItem.IsExpandedProperty, OnNavigationViewItemExpandedPropertyChanged);
		nvi.EventRevoker.Disposable = Disposable.Create(delegate
		{
			nvi.Tapped -= OnNavigationViewItemTapped;
			nvi.KeyDown -= OnNavigationViewItemKeyDown;
			nvi.GotFocus -= OnNavigationViewItemOnGotFocus;
			nvi.UnregisterPropertyChangedCallback(NavigationViewItemBase.IsSelectedProperty, isSelectedSubscription);
			nvi.UnregisterPropertyChangedCallback(NavigationViewItem.IsExpandedProperty, isExpandedSubscription);
		});
		m_itemsWithRevokerObjects.Add(nvi);
	}

	private void ClearNavigationViewItemRevokers(NavigationViewItem nvi)
	{
		nvi.EventRevoker.Disposable = null;
		m_itemsWithRevokerObjects.Remove(nvi);
	}

	private void ClearAllNavigationViewItemRevokers()
	{
		foreach (NavigationViewItem itemsWithRevokerObject in m_itemsWithRevokerObjects)
		{
			itemsWithRevokerObject.EventRevoker.Disposable = null;
		}
		m_itemsWithRevokerObjects.Clear();
	}

	private void InvalidateTopNavPrimaryLayout()
	{
		if (m_appliedTemplate && IsTopNavigationView())
		{
			InvalidateMeasure();
		}
	}

	private double MeasureTopNavigationViewDesiredWidth(Size availableSize)
	{
		return LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavGrid, availableSize);
	}

	private double MeasureTopNavMenuItemsHostDesiredWidth(Size availableSize)
	{
		return LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavRepeater, availableSize);
	}

	private double GetTopNavigationViewActualWidth()
	{
		double actualWidthFor = LayoutUtils.GetActualWidthFor(m_topNavGrid);
		return actualWidthFor;
	}

	private bool HasTopNavigationViewItemNotInPrimaryList()
	{
		return m_topDataProvider.GetPrimaryListSize() != m_topDataProvider.Size();
	}

	private void ResetAndRearrangeTopNavItems(Size availableSize)
	{
		if (HasTopNavigationViewItemNotInPrimaryList())
		{
			m_topDataProvider.MoveAllItemsToPrimaryList();
		}
		ArrangeTopNavItems(availableSize);
	}

	private void HandleTopNavigationMeasureOverride(Size availableSize)
	{
		if (HasTopNavigationViewItemNotInPrimaryList())
		{
			HandleTopNavigationMeasureOverrideOverflow(availableSize);
		}
		else
		{
			HandleTopNavigationMeasureOverrideNormal(availableSize);
		}
		if (m_topNavigationMode == TopNavigationViewLayoutState.Uninitialized)
		{
			m_topNavigationMode = TopNavigationViewLayoutState.Initialized;
		}
	}

	private void HandleTopNavigationMeasureOverrideNormal(Size availableSize)
	{
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (num > availableSize.Width)
		{
			ResetAndRearrangeTopNavItems(availableSize);
		}
	}

	private void HandleTopNavigationMeasureOverrideOverflow(Size availableSize)
	{
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (num > availableSize.Width)
		{
			ShrinkTopNavigationSize(num, availableSize);
		}
		else if (num < availableSize.Width)
		{
			double num2 = m_topDataProvider.WidthRequiredToRecoveryAllItemsToPrimary();
			if (availableSize.Width >= num + num2 + (double)m_topNavigationRecoveryGracePeriodWidth)
			{
				ResetAndRearrangeTopNavItems(availableSize);
				return;
			}
			IList<int> indexes = FindMovableItemsRecoverToPrimaryList(availableSize.Width - num, Array.Empty<int>());
			m_topDataProvider.MoveItemsToPrimaryList(indexes);
		}
	}

	private void ArrangeTopNavItems(Size availableSize)
	{
		SetOverflowButtonVisibility(Visibility.Collapsed);
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (!(num < availableSize.Width))
		{
			SetOverflowButtonVisibility(Visibility.Visible);
			double num2 = MeasureTopNavigationViewDesiredWidth(c_infSize);
			m_topDataProvider.OverflowButtonWidth = num2 - num;
			ShrinkTopNavigationSize(num2, availableSize);
		}
	}

	private void SetOverflowButtonVisibility(Visibility visibility)
	{
		if (visibility != TemplateSettings.OverflowButtonVisibility)
		{
			GetTemplateSettings().OverflowButtonVisibility = visibility;
		}
	}

	private void SelectOverflowItem(object item, IndexPath ip)
	{
		object obj = GetItemBeingMoved(item, ip);
		int num = m_topDataProvider.IndexOf(obj);
		double widthForItem = m_topDataProvider.GetWidthForItem(num);
		bool flag = !m_topDataProvider.IsValidWidthForItem(num);
		if (!flag)
		{
			double topNavigationViewActualWidth = GetTopNavigationViewActualWidth();
			double num2 = MeasureTopNavigationViewDesiredWidth(c_infSize);
			int num3 = itemNotFound;
			double num4 = 0.0;
			object selectedItem = SelectedItem;
			if (selectedItem != null)
			{
				num3 = m_topDataProvider.IndexOf(selectedItem);
				if (num3 != itemNotFound)
				{
					num4 = m_topDataProvider.GetWidthForItem(num3);
				}
			}
			double num5 = num2 + widthForItem - topNavigationViewActualWidth;
			IList<int> list = FindMovableItemsToBeRemovedFromPrimaryList(num5, Array.Empty<int>());
			double num6 = m_topDataProvider.CalculateWidthForItems(list);
			double availableWidth = num6 - num5;
			IList<int> list2 = FindMovableItemsRecoverToPrimaryList(availableWidth, new int[1] { num });
			CollectionHelper.UniquePushBack(list2, num);
			m_lastSelectedItemPendingAnimationInTopNav = obj;
			if (ip != null && ip.GetSize() > 0)
			{
				foreach (int item2 in list)
				{
					if (item2 == ip.GetAt(1))
					{
						UIElement activeIndicator = m_activeIndicator;
						if (activeIndicator != null)
						{
							AnimateSelectionChanged(null);
						}
						break;
					}
				}
			}
			if (m_topDataProvider.HasInvalidWidth(list2))
			{
				flag = true;
			}
			else
			{
				m_topDataProvider.MoveItemsToPrimaryList(list2);
				m_topDataProvider.MoveItemsOutOfPrimaryList(list);
				if (NeedRearrangeOfTopElementsAfterOverflowSelectionChanged(num))
				{
					flag = true;
				}
				if (!flag)
				{
					SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
					InvalidateMeasure();
				}
			}
		}
		if (flag)
		{
			m_topDataProvider.MoveAllItemsToPrimaryList();
			SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
			InvalidateTopNavPrimaryLayout();
		}
		object GetItemBeingMoved(object item, IndexPath ip)
		{
			if (ip.GetSize() > 2)
			{
				return GetItemFromIndex(m_topNavRepeaterOverflowView, m_topDataProvider.ConvertOriginalIndexToIndex(ip.GetAt(1)));
			}
			return item;
		}
	}

	private bool NeedRearrangeOfTopElementsAfterOverflowSelectionChanged(int selectedOriginalIndex)
	{
		bool flag = false;
		IList<object> primaryItems = m_topDataProvider.GetPrimaryItems();
		int count = primaryItems.Count;
		int num = m_topDataProvider.ConvertOriginalIndexToIndex(selectedOriginalIndex);
		if (num < count - 1)
		{
			int num2 = num + 1;
			int num3 = selectedOriginalIndex + 1;
			int num4 = selectedOriginalIndex - 1;
			if (num > 0)
			{
				List<int> list = new List<int>();
				list.Add(num2 - 1);
				IList<int> list2 = m_topDataProvider.ConvertPrimaryIndexToIndex(list);
				if (list2[0] != num4)
				{
					flag = true;
				}
			}
			while (!flag && num2 < count)
			{
				List<int> list3 = new List<int>();
				list3.Add(num2);
				IList<int> list4 = m_topDataProvider.ConvertPrimaryIndexToIndex(list3);
				if (num3 != list4[0])
				{
					flag = true;
					break;
				}
				num2++;
				num3++;
			}
		}
		return flag;
	}

	private void ShrinkTopNavigationSize(double desiredWidth, Size availableSize)
	{
		UpdateTopNavigationWidthCache();
		int selectedItemIndex = GetSelectedItemIndex();
		double num = MeasureTopNavMenuItemsHostDesiredWidth(c_infSize) - (desiredWidth - availableSize.Width);
		if (num >= 0.0)
		{
			IList<int> list = FindMovableItemsBeyondAvailableWidth(num);
			KeepAtLeastOneItemInPrimaryList(list, shouldKeepFirst: true);
			m_topDataProvider.MoveItemsOutOfPrimaryList(list);
		}
		desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
		double num2 = desiredWidth - availableSize.Width;
		if (num2 > 0.0)
		{
			IList<int> list2 = FindMovableItemsToBeRemovedFromPrimaryList(num2, new int[1] { selectedItemIndex });
			KeepAtLeastOneItemInPrimaryList(list2, shouldKeepFirst: false);
			m_topDataProvider.MoveItemsOutOfPrimaryList(list2);
		}
	}

	private IList<int> FindMovableItemsRecoverToPrimaryList(double availableWidth, IList<int> includeItems)
	{
		List<int> list = new List<int>();
		int num = m_topDataProvider.Size();
		foreach (int includeItem in includeItems)
		{
			double widthForItem = m_topDataProvider.GetWidthForItem(includeItem);
			list.Add(includeItem);
			availableWidth -= widthForItem;
		}
		int i;
		for (i = 0; i < num; i++)
		{
			if (!(availableWidth > 0.0))
			{
				break;
			}
			if (!m_topDataProvider.IsItemInPrimaryList(i) && !includeItems.Contains(i))
			{
				double widthForItem2 = m_topDataProvider.GetWidthForItem(i);
				if (!(availableWidth >= widthForItem2))
				{
					break;
				}
				list.Add(i);
				availableWidth -= widthForItem2;
			}
		}
		if (i == num && list.Count > 0)
		{
			list.Remove(list.Count - 1);
		}
		return list;
	}

	private IList<int> FindMovableItemsToBeRemovedFromPrimaryList(double widthAtLeastToBeRemoved, IList<int> excludeItems)
	{
		List<int> list = new List<int>();
		int num = m_topDataProvider.Size() - 1;
		while (num >= 0 && widthAtLeastToBeRemoved > 0.0)
		{
			if (m_topDataProvider.IsItemInPrimaryList(num) && !excludeItems.Contains(num))
			{
				double widthForItem = m_topDataProvider.GetWidthForItem(num);
				list.Add(num);
				widthAtLeastToBeRemoved -= widthForItem;
			}
			num--;
		}
		return list;
	}

	private IList<int> FindMovableItemsBeyondAvailableWidth(double availableWidth)
	{
		List<int> list = new List<int>();
		ItemsRepeater topNavRepeater = m_topNavRepeater;
		if (topNavRepeater != null)
		{
			int num = m_topDataProvider.IndexOf(SelectedItem, NavigationViewSplitVectorID.PrimaryList);
			int primaryListSize = m_topDataProvider.GetPrimaryListSize();
			double num2 = 0.0;
			for (int i = 0; i < primaryListSize; i++)
			{
				if (i == num)
				{
					continue;
				}
				bool flag = true;
				if (num2 <= availableWidth)
				{
					UIElement uIElement = topNavRepeater.TryGetElement(i);
					if (uIElement != null && uIElement != null)
					{
						UIElement uIElement2 = uIElement;
						double width = uIElement2.DesiredSize.Width;
						num2 += width;
						flag = num2 > availableWidth;
					}
				}
				if (flag)
				{
					list.Add(i);
				}
			}
		}
		return m_topDataProvider.ConvertPrimaryIndexToIndex(list);
	}

	private void KeepAtLeastOneItemInPrimaryList(IList<int> itemInPrimaryToBeRemoved, bool shouldKeepFirst)
	{
		if (itemInPrimaryToBeRemoved.Count > 0 && itemInPrimaryToBeRemoved.Count == m_topDataProvider.GetPrimaryListSize())
		{
			if (shouldKeepFirst)
			{
				itemInPrimaryToBeRemoved.RemoveAt(0);
			}
			else
			{
				itemInPrimaryToBeRemoved.RemoveAt(itemInPrimaryToBeRemoved.Count - 1);
			}
		}
	}

	private int GetSelectedItemIndex()
	{
		return m_topDataProvider.IndexOf(SelectedItem);
	}

	private double GetPaneToggleButtonWidth()
	{
		return Convert.ToDouble(SharedHelpers.FindInApplicationResources("PaneToggleButtonWidth", 40));
	}

	private double GetPaneToggleButtonHeight()
	{
		return Convert.ToDouble(SharedHelpers.FindInApplicationResources("PaneToggleButtonHeight", 40));
	}

	private void UpdateTopNavigationWidthCache()
	{
		int primaryListSize = m_topDataProvider.GetPrimaryListSize();
		ItemsRepeater topNavRepeater = m_topNavRepeater;
		if (topNavRepeater == null)
		{
			return;
		}
		for (int i = 0; i < primaryListSize; i++)
		{
			UIElement uIElement = topNavRepeater.TryGetElement(i);
			if (uIElement != null)
			{
				if (uIElement != null)
				{
					UIElement uIElement2 = uIElement;
					double width = uIElement2.DesiredSize.Width;
					m_topDataProvider.UpdateWidthForPrimaryItem(i, width);
				}
				continue;
			}
			break;
		}
	}

	private bool IsTopNavigationView()
	{
		return PaneDisplayMode == NavigationViewPaneDisplayMode.Top;
	}

	private bool IsTopPrimaryListVisible()
	{
		if (m_topNavRepeater != null)
		{
			return TemplateSettings.TopPaneVisibility == Visibility.Visible;
		}
		return false;
	}

	private void CoerceToGreaterThanZero(ref double value)
	{
		value = Math.Max(value, 0.0);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == IsPaneOpenProperty)
		{
			OnIsPaneOpenChanged();
			UpdateVisualStateForDisplayModeGroup(DisplayMode);
		}
		else if (property == CompactModeThresholdWidthProperty || property == ExpandedModeThresholdWidthProperty)
		{
			UpdateAdaptiveLayout(base.ActualWidth);
		}
		else if (property == AlwaysShowHeaderProperty || property == HeaderProperty)
		{
			UpdateHeaderVisibility();
		}
		else if (property == SelectedItemProperty)
		{
			OnSelectedItemPropertyChanged(args);
		}
		else if (property == PaneTitleProperty)
		{
			UpdatePaneTitleFrameworkElementParents();
			UpdateBackAndCloseButtonsVisibility();
			UpdatePaneToggleSize();
		}
		else if (property == IsBackButtonVisibleProperty)
		{
			UpdateBackAndCloseButtonsVisibility();
			UpdateAdaptiveLayout(base.ActualWidth);
			if (IsTopNavigationView())
			{
				InvalidateTopNavPrimaryLayout();
			}
			m_backButton?.UpdateLayout();
			UpdatePaneLayout();
		}
		else if (property == MenuItemsSourceProperty)
		{
			UpdateRepeaterItemsSource(forceSelectionModelUpdate: true);
		}
		else if (property == MenuItemsProperty)
		{
			UpdateRepeaterItemsSource(forceSelectionModelUpdate: true);
		}
		else if (property == FooterMenuItemsSourceProperty)
		{
			UpdateFooterRepeaterItemsSource(sourceCollectionReset: true, sourceCollectionChanged: true);
		}
		else if (property == FooterMenuItemsProperty)
		{
			UpdateFooterRepeaterItemsSource(sourceCollectionReset: true, sourceCollectionChanged: true);
		}
		else if (property == PaneDisplayModeProperty)
		{
			m_wasForceClosed = false;
			CollapseTopLevelMenuItems((NavigationViewPaneDisplayMode)args.OldValue);
			UpdatePaneToggleButtonVisibility();
			UpdatePaneDisplayMode((NavigationViewPaneDisplayMode)args.OldValue, (NavigationViewPaneDisplayMode)args.NewValue);
			UpdatePaneTitleFrameworkElementParents();
			UpdatePaneVisibility();
			UpdateVisualState();
			UpdatePaneButtonsWidths();
		}
		else if (property == IsPaneVisibleProperty)
		{
			UpdatePaneVisibility();
			UpdateVisualStateForDisplayModeGroup(DisplayMode);
			if (!IsPaneVisible && IsPaneOpen)
			{
				ClosePane();
			}
			if (IsPaneVisible && DisplayMode == NavigationViewDisplayMode.Expanded && !IsPaneOpen)
			{
				OpenPane();
			}
		}
		else if (property == OverflowLabelModeProperty)
		{
			if (m_appliedTemplate)
			{
				UpdateVisualStateForOverflowButton();
				InvalidateTopNavPrimaryLayout();
			}
		}
		else if (property == AutoSuggestBoxProperty)
		{
			InvalidateTopNavPrimaryLayout();
			if (args.OldValue != null)
			{
				m_autoSuggestBoxQuerySubmittedRevoker.Disposable = null;
			}
			object newValue = args.NewValue;
			AutoSuggestBox newAutoSuggestBox = newValue as AutoSuggestBox;
			if (newAutoSuggestBox != null)
			{
				newAutoSuggestBox.QuerySubmitted += OnAutoSuggestBoxQuerySubmitted;
				m_autoSuggestBoxQuerySubmittedRevoker.Disposable = Disposable.Create(delegate
				{
					newAutoSuggestBox.QuerySubmitted -= OnAutoSuggestBoxQuerySubmitted;
				});
			}
			UpdateVisualState();
		}
		else if (property == SelectionFollowsFocusProperty)
		{
			UpdateSingleSelectionFollowsFocusTemplateSetting();
		}
		else if (property == IsPaneToggleButtonVisibleProperty)
		{
			UpdatePaneTitleFrameworkElementParents();
			UpdateBackAndCloseButtonsVisibility();
			UpdatePaneToggleButtonVisibility();
			UpdateVisualState();
		}
		else if (property == IsSettingsVisibleProperty)
		{
			UpdateFooterRepeaterItemsSource(sourceCollectionReset: false, sourceCollectionChanged: true);
		}
		else if (property == CompactPaneLengthProperty)
		{
			if (!SharedHelpers.Is21H1OrHigher())
			{
				UpdatePaneShadow();
			}
			UpdatePaneButtonsWidths();
		}
		else if (property == IsTitleBarAutoPaddingEnabledProperty)
		{
			UpdateTitleBarPadding();
		}
		else if (property == MenuItemTemplateProperty || property == MenuItemTemplateSelectorProperty)
		{
			SyncItemTemplates();
		}
		else if (property == PaneFooterProperty)
		{
			UpdatePaneLayout();
		}
		else if (property == OpenPaneLengthProperty)
		{
			UpdateOpenPaneWidth(base.ActualWidth);
		}
	}

	private void UpdateNavigationViewItemsFactory()
	{
		object obj = MenuItemTemplate;
		if (obj == null)
		{
			obj = MenuItemTemplateSelector;
		}
		m_navigationViewItemsFactory.UserElementFactory(obj);
	}

	private void SyncItemTemplates()
	{
		UpdateNavigationViewItemsFactory();
	}

	private void OnRepeaterLoaded(object sender, RoutedEventArgs args)
	{
		object selectedItem = SelectedItem;
		if (selectedItem == null)
		{
			return;
		}
		if (!IsSelectionSuppressed(selectedItem))
		{
			NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(selectedItem);
			if (navigationViewItem != null)
			{
				navigationViewItem.IsSelected = true;
			}
		}
		AnimateSelectionChanged(selectedItem);
	}

	private void OnUnloaded(object sender, RoutedEventArgs args)
	{
		CoreApplicationViewTitleBar coreTitleBar = m_coreTitleBar;
		if (coreTitleBar != null)
		{
			coreTitleBar.LayoutMetricsChanged += OnTitleBarMetricsChanged;
			coreTitleBar.IsVisibleChanged += OnTitleBarIsVisibleChanged;
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		if (m_updateVisualStateForDisplayModeFromOnLoaded)
		{
			m_updateVisualStateForDisplayModeFromOnLoaded = false;
			UpdateVisualStateForDisplayModeGroup(DisplayMode);
		}
		CoreApplicationViewTitleBar coreTitleBar = m_coreTitleBar;
		if (coreTitleBar != null)
		{
			coreTitleBar.LayoutMetricsChanged += OnTitleBarMetricsChanged;
			coreTitleBar.IsVisibleChanged += OnTitleBarIsVisibleChanged;
		}
		UpdatePaneButtonsWidths();
	}

	private void OnIsPaneOpenChanged()
	{
		bool isPaneOpen = IsPaneOpen;
		if (isPaneOpen && m_wasForceClosed)
		{
			m_wasForceClosed = false;
		}
		else if (!m_isOpenPaneForInteraction && !isPaneOpen)
		{
			SplitView rootSplitView = m_rootSplitView;
			if (rootSplitView != null)
			{
				m_wasForceClosed = rootSplitView.IsPaneOpen;
			}
			else
			{
				m_wasForceClosed = true;
			}
		}
		SetPaneToggleButtonAutomationName();
		UpdatePaneTabFocusNavigation();
		UpdateSettingsItemToolTip();
		UpdatePaneTitleFrameworkElementParents();
		UpdatePaneOverlayGroup();
		UpdatePaneButtonsWidths();
		if (!SharedHelpers.IsThemeShadowAvailable())
		{
			return;
		}
		if (SharedHelpers.Is21H1OrHigher())
		{
			if (IsPaneOpen)
			{
				SetDropShadow();
			}
			else
			{
				UnsetDropShadow();
			}
			return;
		}
		SplitView rootSplitView2 = m_rootSplitView;
		if (rootSplitView2 != null)
		{
			SplitViewDisplayMode displayMode = rootSplitView2.DisplayMode;
			bool flag = displayMode == SplitViewDisplayMode.Overlay || displayMode == SplitViewDisplayMode.CompactOverlay;
			UIElement pane = rootSplitView2.Pane;
			if (pane != null)
			{
				Vector3 translation = pane.Translation;
				Vector3 vector2 = (pane.Translation = new Vector3(translation.X, translation.Y, (IsPaneOpen && flag) ? 32f : 0f));
			}
		}
	}

	private void UpdatePaneToggleButtonVisibility()
	{
		bool visible = IsPaneToggleButtonVisible && !IsTopNavigationView();
		GetTemplateSettings().PaneToggleButtonVisibility = Util.VisibilityFromBool(visible);
	}

	private void UpdatePaneDisplayMode()
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		if (!IsTopNavigationView())
		{
			UpdateAdaptiveLayout(base.ActualWidth, forceSetDisplayMode: true);
			SwapPaneHeaderContent(m_leftNavPaneHeaderContentBorder, m_paneHeaderOnTopPane, "PaneHeader");
			SwapPaneHeaderContent(m_leftNavPaneCustomContentBorder, m_paneCustomContentOnTopPane, "PaneCustomContent");
			SwapPaneHeaderContent(m_leftNavFooterContentBorder, m_paneFooterOnTopPane, "PaneFooter");
			CreateAndHookEventsToSettings();
			Button paneToggleButton = m_paneToggleButton;
			if (paneToggleButton != null)
			{
				base.KeyTipTarget = paneToggleButton;
			}
		}
		else
		{
			ClosePane();
			SetDisplayMode(NavigationViewDisplayMode.Minimal, forceSetDisplayMode: true);
			SwapPaneHeaderContent(m_paneHeaderOnTopPane, m_leftNavPaneHeaderContentBorder, "PaneHeader");
			SwapPaneHeaderContent(m_paneCustomContentOnTopPane, m_leftNavPaneCustomContentBorder, "PaneCustomContent");
			SwapPaneHeaderContent(m_paneFooterOnTopPane, m_leftNavFooterContentBorder, "PaneFooter");
			CreateAndHookEventsToSettings();
			Button topNavOverflowButton = m_topNavOverflowButton;
			if (topNavOverflowButton != null)
			{
				base.KeyTipTarget = topNavOverflowButton;
			}
		}
		UpdateContentBindingsForPaneDisplayMode();
		UpdateRepeaterItemsSource(forceSelectionModelUpdate: false);
		UpdateFooterRepeaterItemsSource(sourceCollectionReset: false, sourceCollectionChanged: false);
		object selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			m_OrientationChangedPendingAnimation = true;
		}
	}

	private void UpdatePaneDisplayMode(NavigationViewPaneDisplayMode oldDisplayMode, NavigationViewPaneDisplayMode newDisplayMode)
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		UpdatePaneDisplayMode();
		if (IsTopNavigationView())
		{
			return;
		}
		if (IsPaneOpen)
		{
			if (newDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal)
			{
				ClosePane();
			}
		}
		else if (oldDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal && newDisplayMode == NavigationViewPaneDisplayMode.Left)
		{
			OpenPane();
		}
	}

	private void UpdatePaneVisibility()
	{
		NavigationViewTemplateSettings templateSettings = GetTemplateSettings();
		if (IsPaneVisible)
		{
			if (IsTopNavigationView())
			{
				templateSettings.LeftPaneVisibility = Visibility.Collapsed;
				templateSettings.TopPaneVisibility = Visibility.Visible;
			}
			else
			{
				templateSettings.TopPaneVisibility = Visibility.Collapsed;
				templateSettings.LeftPaneVisibility = Visibility.Visible;
			}
			VisualStateManager.GoToState(this, "PaneVisible", useTransitions: false);
		}
		else
		{
			templateSettings.TopPaneVisibility = Visibility.Collapsed;
			templateSettings.LeftPaneVisibility = Visibility.Collapsed;
			VisualStateManager.GoToState(this, "PaneCollapsed", useTransitions: false);
		}
	}

	private void SwapPaneHeaderContent(ContentControl newParentTrackRef, ContentControl oldParentTrackRef, string propertyPathName)
	{
		if (newParentTrackRef != null)
		{
			oldParentTrackRef?.ClearValue(ContentControl.ContentProperty);
			SharedHelpers.SetBinding(propertyPathName, newParentTrackRef, ContentControl.ContentProperty);
		}
	}

	private void UpdateContentBindingsForPaneDisplayMode()
	{
		UIElement uIElement = null;
		UIElement uIElement2 = null;
		if (!IsTopNavigationView())
		{
			uIElement = m_leftNavPaneAutoSuggestBoxPresenter;
			uIElement2 = m_topNavPaneAutoSuggestBoxPresenter;
		}
		else
		{
			uIElement = m_topNavPaneAutoSuggestBoxPresenter;
			uIElement2 = m_leftNavPaneAutoSuggestBoxPresenter;
		}
		if (uIElement != null)
		{
			uIElement2?.ClearValue(ContentControl.ContentProperty);
			SharedHelpers.SetBinding("AutoSuggestBox", uIElement, ContentControl.ContentProperty);
		}
	}

	private void UpdateHeaderVisibility()
	{
		if (m_appliedTemplate)
		{
			UpdateHeaderVisibility(DisplayMode);
		}
	}

	private void UpdateHeaderVisibility(NavigationViewDisplayMode displayMode)
	{
		bool flag = AlwaysShowHeader || (!IsTopNavigationView() && displayMode == NavigationViewDisplayMode.Minimal);
		if (SharedHelpers.IsRS5OrHigher())
		{
			flag = Header != null && flag;
		}
		VisualStateManager.GoToState(this, flag ? "HeaderVisible" : "HeaderCollapsed", useTransitions: false);
	}

	private void UpdatePaneTabFocusNavigation()
	{
		if (m_appliedTemplate && SharedHelpers.IsRS2OrHigher())
		{
			KeyboardNavigationMode tabFocusNavigation = KeyboardNavigationMode.Local;
			SplitView rootSplitView = m_rootSplitView;
			if (rootSplitView != null && IsPaneOpen && (rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay || rootSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay))
			{
				tabFocusNavigation = KeyboardNavigationMode.Cycle;
			}
			UIElement paneContentGrid = m_paneContentGrid;
			if (paneContentGrid != null)
			{
				paneContentGrid.TabFocusNavigation = tabFocusNavigation;
			}
		}
	}

	private void UpdatePaneToggleSize()
	{
		if (ShouldPreserveNavigationViewRS3Behavior())
		{
			return;
		}
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView == null)
		{
			return;
		}
		double paneToggleButtonWidth = GetTemplateSettings().PaneToggleButtonWidth;
		double width = paneToggleButtonWidth;
		if (ShouldShowBackButton() && rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
		{
			double num = 40.0;
			Button backButton = m_backButton;
			if (backButton != null)
			{
				num = backButton.Width;
			}
			paneToggleButtonWidth += num;
		}
		if (!m_isClosedCompact && !string.IsNullOrEmpty(PaneTitle))
		{
			if (rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay && IsPaneOpen)
			{
				paneToggleButtonWidth = m_openPaneWidth;
				width = m_openPaneWidth - (double)((ShouldShowBackButton() || ShouldShowCloseButton()) ? 40 : 0);
			}
			else if (rootSplitView.DisplayMode != 0 || IsPaneOpen)
			{
				paneToggleButtonWidth = m_openPaneWidth;
				width = m_openPaneWidth;
			}
		}
		Button paneToggleButton = m_paneToggleButton;
		if (paneToggleButton != null)
		{
			paneToggleButton.Width = width;
		}
	}

	private void UpdateBackAndCloseButtonsVisibility()
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		bool flag = ShouldShowBackButton();
		Visibility visibility = Util.VisibilityFromBool(flag);
		NavigationViewVisualStateDisplayMode visualStateDisplayMode = GetVisualStateDisplayMode(DisplayMode);
		bool flag2 = (visualStateDisplayMode == NavigationViewVisualStateDisplayMode.Minimal && !IsTopNavigationView()) || visualStateDisplayMode == NavigationViewVisualStateDisplayMode.MinimalWithBackButton;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		GetTemplateSettings().BackButtonVisibility = visibility;
		if (m_paneToggleButton != null && IsPaneToggleButtonVisible)
		{
			num4 = GetPaneToggleButtonHeight();
			num2 = GetPaneToggleButtonWidth();
			if (flag2)
			{
				num = num2;
			}
		}
		Button backButton = m_backButton;
		if (backButton != null)
		{
			if (ShouldPreserveNavigationViewRS4Behavior())
			{
				backButton.Visibility = visibility;
			}
			if (flag2 && visibility == Visibility.Visible)
			{
				num += backButton.Width;
			}
		}
		Button closeButton = m_closeButton;
		if (closeButton != null && (closeButton.Visibility = Util.VisibilityFromBool(ShouldShowCloseButton())) == Visibility.Visible)
		{
			num4 = Math.Max(num4, closeButton.Height);
			if (flag2)
			{
				num3 = closeButton.Width;
				num += num3;
			}
		}
		FrameworkElement contentLeftPadding = m_contentLeftPadding;
		if (contentLeftPadding != null)
		{
			contentLeftPadding.Width = num;
		}
		ColumnDefinition paneHeaderToggleButtonColumn = m_paneHeaderToggleButtonColumn;
		if (paneHeaderToggleButtonColumn != null)
		{
			paneHeaderToggleButtonColumn.Width = GridLengthHelper.FromValueAndType(num2, GridUnitType.Pixel);
		}
		ColumnDefinition paneHeaderCloseButtonColumn = m_paneHeaderCloseButtonColumn;
		if (paneHeaderCloseButtonColumn != null)
		{
			paneHeaderCloseButtonColumn.Width = GridLengthHelper.FromValueAndType(num3, GridUnitType.Pixel);
		}
		RowDefinition paneHeaderContentBorderRow = m_paneHeaderContentBorderRow;
		if (paneHeaderContentBorderRow != null)
		{
			paneHeaderContentBorderRow.MinHeight = num4;
			SetHeaderContentMinHeight(num4);
		}
		UIElement paneContentGrid = m_paneContentGrid;
		if (paneContentGrid != null && paneContentGrid is Grid grid)
		{
			RowDefinitionCollection rowDefinitions = grid.RowDefinitions;
			if (rowDefinitions.Count >= 1)
			{
				RowDefinition rowDefinition = rowDefinitions[1];
				int num5 = 0;
				if (!IsOverlay() && flag)
				{
					num5 = 40;
				}
				else if (ShouldPreserveNavigationViewRS3Behavior())
				{
					num5 = 56;
				}
				GridLength gridLength2 = (rowDefinition.Height = GridLengthHelper.FromPixels(num5));
			}
		}
		if (!ShouldPreserveNavigationViewRS4Behavior())
		{
			VisualStateManager.GoToState(this, flag ? "BackButtonVisible" : "BackButtonCollapsed", useTransitions: false);
		}
		UpdateTitleBarPadding();
	}

	private void UpdatePaneTitleMargins()
	{
		if (!ShouldPreserveNavigationViewRS4Behavior())
		{
			return;
		}
		FrameworkElement paneTitleFrameworkElement = m_paneTitleFrameworkElement;
		if (paneTitleFrameworkElement != null)
		{
			double num = GetPaneToggleButtonWidth();
			if (ShouldShowBackButton() && IsOverlay())
			{
				num += 40.0;
			}
			paneTitleFrameworkElement.Margin = new Thickness(num, 0.0, 0.0, 0.0);
		}
	}

	private void UpdateSelectionForMenuItems()
	{
		if (SelectedItem == null)
		{
			bool foundFirstSelected = false;
			IList<object> menuItems = MenuItems;
			if (menuItems != null)
			{
				foundFirstSelected = UpdateSelectedItemFromMenuItems(menuItems);
			}
			IList<object> footerMenuItems = FooterMenuItems;
			if (footerMenuItems != null)
			{
				UpdateSelectedItemFromMenuItems(footerMenuItems, foundFirstSelected);
			}
		}
	}

	private bool UpdateSelectedItemFromMenuItems(IList<object> menuItems, bool foundFirstSelected = false)
	{
		for (int i = 0; i < menuItems.Count; i++)
		{
			if (!(menuItems[i] is NavigationViewItem navigationViewItem) || !navigationViewItem.IsSelected)
			{
				continue;
			}
			if (!foundFirstSelected)
			{
				try
				{
					m_shouldIgnoreNextSelectionChange = true;
					SelectedItem = navigationViewItem;
					foundFirstSelected = true;
				}
				finally
				{
					m_shouldIgnoreNextSelectionChange = false;
				}
			}
			else
			{
				navigationViewItem.IsSelected = false;
			}
		}
		return foundFirstSelected;
	}

	private void OnTitleBarMetricsChanged(object sender, object args)
	{
		UpdateTitleBarPadding();
	}

	private void OnTitleBarIsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
	{
		UpdateTitleBarPadding();
	}

	private void ClosePaneIfNeccessaryAfterItemIsClicked(NavigationViewItem selectedContainer)
	{
		if (IsPaneOpen && DisplayMode != NavigationViewDisplayMode.Expanded && !DoesNavigationViewItemHaveChildren(selectedContainer) && !m_shouldIgnoreNextSelectionChange)
		{
			ClosePane();
		}
	}

	private bool NeedTopPaddingForRS5OrHigher(CoreApplicationViewTitleBar coreTitleBar)
	{
		if (coreTitleBar.IsVisible && coreTitleBar.ExtendViewIntoTitleBar)
		{
			return !IsFullScreenOrTabletMode();
		}
		return false;
	}

	private void UpdateTitleBarPadding()
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		double num = 0.0;
		CoreApplicationViewTitleBar coreTitleBar = m_coreTitleBar;
		if (coreTitleBar != null)
		{
			bool flag = false;
			if (IsTitleBarAutoPaddingEnabled)
			{
				flag = ShouldPreserveNavigationViewRS3Behavior() || ((!ShouldPreserveNavigationViewRS4Behavior()) ? NeedTopPaddingForRS5OrHigher(coreTitleBar) : (!coreTitleBar.ExtendViewIntoTitleBar));
			}
			if (flag)
			{
				UIElement content = Window.Current.Content;
				GeneralTransform generalTransform = TransformToVisual(content);
				if (generalTransform.TransformPoint(Point.Zero).Y == 0.0)
				{
					num = coreTitleBar.Height;
				}
			}
			if (ShouldPreserveNavigationViewRS4Behavior())
			{
				FrameworkElement togglePaneTopPadding = m_togglePaneTopPadding;
				if (togglePaneTopPadding != null)
				{
					togglePaneTopPadding.Height = num;
				}
				togglePaneTopPadding = m_contentPaneTopPadding;
				if (togglePaneTopPadding != null)
				{
					togglePaneTopPadding.Height = num;
				}
			}
			FrameworkElement paneTitleHolderFrameworkElement = m_paneTitleHolderFrameworkElement;
			Button paneToggleButton = m_paneToggleButton;
			bool flag2 = paneTitleHolderFrameworkElement != null && paneTitleHolderFrameworkElement.Visibility == Visibility.Visible;
			bool flag3 = !flag2 && paneToggleButton != null && paneToggleButton.Visibility == Visibility.Visible;
			if (flag2 || flag3)
			{
				Thickness margin = ThicknessHelper.FromLengths(0.0, 0.0, 0.0, 0.0);
				if (ShouldShowBackButton())
				{
					margin = ((!IsOverlay()) ? ThicknessHelper.FromLengths(0.0, 40.0, 0.0, 0.0) : ThicknessHelper.FromLengths(40.0, 0.0, 0.0, 0.0));
				}
				else if (ShouldShowCloseButton() && IsOverlay())
				{
					margin = ThicknessHelper.FromLengths(40.0, 0.0, 0.0, 0.0);
				}
				if (flag2)
				{
					paneTitleHolderFrameworkElement.Margin(margin);
				}
				else
				{
					paneToggleButton.Margin(margin);
				}
			}
		}
		NavigationViewTemplateSettings templateSettings = TemplateSettings;
		if (templateSettings != null && Math.Abs(templateSettings.TopPadding - num) > 0.1)
		{
			GetTemplateSettings().TopPadding = num;
		}
	}

	private void OnAutoSuggestBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
	{
		if (DisplayMode != NavigationViewDisplayMode.Expanded && args.ChosenSuggestion != null)
		{
			ClosePane();
		}
	}

	private void RaiseDisplayModeChanged(NavigationViewDisplayMode displayMode)
	{
		SetValue(DisplayModeProperty, displayMode);
		NavigationViewDisplayModeChangedEventArgs args = new NavigationViewDisplayModeChangedEventArgs(displayMode);
		this.DisplayModeChanged?.Invoke(this, args);
	}

	internal static void CreateAndAttachHeaderAnimation(Visual visual)
	{
	}

	private bool IsFullScreenOrTabletMode()
	{
		if (m_applicationView == null)
		{
			m_applicationView = ApplicationView.GetForCurrentView();
		}
		if (m_uiViewSettings == null)
		{
			m_uiViewSettings = UIViewSettings.GetForCurrentView();
		}
		bool isFullScreenMode = m_applicationView.IsFullScreenMode;
		bool flag = m_uiViewSettings.UserInteractionMode == UserInteractionMode.Touch;
		return isFullScreenMode || flag;
	}

	private void SetDropShadow()
	{
		NavigationViewDisplayMode displayMode = DisplayMode;
		if (displayMode == NavigationViewDisplayMode.Compact || displayMode == NavigationViewDisplayMode.Minimal)
		{
			Grid shadowCaster = m_shadowCaster;
			if (shadowCaster != null && IsThemeShadowSupported())
			{
				shadowCaster.Shadow = new ThemeShadow();
			}
		}
	}

	private void UnsetDropShadow()
	{
		Grid shadowCaster = m_shadowCaster;
		Storyboard shadowCasterEaseOutStoryboard = m_shadowCasterEaseOutStoryboard;
		if (shadowCasterEaseOutStoryboard != null)
		{
			shadowCasterEaseOutStoryboard.Begin();
			m_shadowCasterEaseOutStoryboardRevoker.Disposable = null;
			shadowCasterEaseOutStoryboard.Completed += Completed;
			m_shadowCasterEaseOutStoryboardRevoker.Disposable = Disposable.Create(delegate
			{
				shadowCasterEaseOutStoryboard.Completed -= Completed;
			});
		}
		void Completed(object sender, object args)
		{
			ShadowCasterEaseOutStoryboard_Completed(shadowCaster);
		}
	}

	private void ShadowCasterEaseOutStoryboard_Completed(Grid shadowCaster)
	{
		if (IsThemeShadowSupported() && shadowCaster.Shadow != null)
		{
			shadowCaster.Shadow = null;
		}
	}

	private void UpdatePaneShadow()
	{
		if (!SharedHelpers.IsThemeShadowAvailable())
		{
			return;
		}
		Canvas canvas = (Canvas)GetTemplateChild("PaneShadowReceiver");
		if (canvas == null)
		{
			canvas = new Canvas();
			canvas.Name("PaneShadowReceiver");
			if (GetTemplateChild("ContentGrid") is Grid grid)
			{
				Grid.SetRowSpan(canvas, grid.RowDefinitions.Count);
				Grid.SetRow(canvas, 0);
				if (grid.ColumnDefinitions.Count > 0)
				{
					Grid.SetColumn(canvas, 0);
					Grid.SetColumnSpan(canvas, grid.ColumnDefinitions.Count);
				}
				grid.Children.Add(canvas);
				ThemeShadow themeShadow = new ThemeShadow();
				themeShadow.Receivers.Add(canvas);
				SplitView rootSplitView = m_rootSplitView;
				if (rootSplitView != null)
				{
					UIElement pane = rootSplitView.Pane;
					if (pane != null)
					{
						pane.Shadow = themeShadow;
					}
				}
			}
		}
		Thickness margin = new Thickness(0.0, -32.0, -32.0, -32.0);
		canvas.HorizontalAlignment = HorizontalAlignment.Left;
		if (DisplayMode == NavigationViewDisplayMode.Compact)
		{
			canvas.Width = m_openPaneWidth;
		}
		else
		{
			canvas.Width = m_openPaneWidth - margin.Right;
		}
		canvas.Margin(margin);
	}

	private void UpdatePaneOverlayGroup()
	{
		SplitView rootSplitView = m_rootSplitView;
		if (rootSplitView != null)
		{
			if (IsPaneOpen && (rootSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay))
			{
				VisualStateManager.GoToState(this, "PaneOverlaying", useTransitions: true);
			}
			else
			{
				VisualStateManager.GoToState(this, "PaneNotOverlaying", useTransitions: true);
			}
		}
	}

	private T GetContainerForData<T>(object data) where T : class
	{
		if (data == null)
		{
			return null;
		}
		if (data is T result)
		{
			return result;
		}
		ItemsRepeater itemsRepeater = (IsTopNavigationView() ? m_topNavRepeater : m_leftNavRepeater);
		int indexFromItem = GetIndexFromItem(itemsRepeater, data);
		UIElement uIElement;
		if (indexFromItem >= 0)
		{
			uIElement = itemsRepeater.TryGetElement(indexFromItem);
			if (uIElement != null)
			{
				return uIElement as T;
			}
		}
		ItemsRepeater itemsRepeater2 = (IsTopNavigationView() ? m_topNavFooterMenuRepeater : m_leftNavFooterMenuRepeater);
		indexFromItem = GetIndexFromItem(itemsRepeater2, data);
		if (indexFromItem >= 0)
		{
			uIElement = itemsRepeater2.TryGetElement(indexFromItem);
			if (uIElement != null)
			{
				return uIElement as T;
			}
		}
		uIElement = SearchEntireTreeForContainer(itemsRepeater, data);
		if (uIElement != null)
		{
			return uIElement as T;
		}
		uIElement = SearchEntireTreeForContainer(itemsRepeater2, data);
		if (uIElement != null)
		{
			return uIElement as T;
		}
		return null;
	}

	private UIElement SearchEntireTreeForContainer(ItemsRepeater rootRepeater, object data)
	{
		int indexFromItem = GetIndexFromItem(rootRepeater, data);
		if (indexFromItem != -1)
		{
			return rootRepeater.TryGetElement(indexFromItem);
		}
		for (int i = 0; i < GetContainerCountInRepeater(rootRepeater); i++)
		{
			UIElement uIElement = rootRepeater.TryGetElement(i);
			if (uIElement == null || !(uIElement is NavigationViewItem navigationViewItem))
			{
				continue;
			}
			ItemsRepeater repeater = navigationViewItem.GetRepeater();
			if (repeater != null)
			{
				UIElement uIElement2 = SearchEntireTreeForContainer(repeater, data);
				if (uIElement2 != null)
				{
					return uIElement2;
				}
			}
		}
		return null;
	}

	private IndexPath SearchEntireTreeForIndexPath(ItemsRepeater rootRepeater, object data, bool isFooterRepeater)
	{
		for (int i = 0; i < GetContainerCountInRepeater(rootRepeater); i++)
		{
			UIElement uIElement = rootRepeater.TryGetElement(i);
			if (uIElement != null && uIElement is NavigationViewItem parentContainer)
			{
				IndexPath ip = new IndexPath(new List<int>
				{
					isFooterRepeater ? 1 : 0,
					i
				});
				IndexPath indexPath = SearchEntireTreeForIndexPath(parentContainer, data, ip);
				if (indexPath != null)
				{
					return indexPath;
				}
			}
		}
		return null;
	}

	private IndexPath SearchEntireTreeForIndexPath(NavigationViewItem parentContainer, object data, IndexPath ip)
	{
		bool flag = false;
		ItemsRepeater itemsRepeater = parentContainer?.GetRepeater();
		if (itemsRepeater != null && DoesRepeaterHaveRealizedContainers(itemsRepeater))
		{
			flag = true;
			for (int i = 0; i < GetContainerCountInRepeater(itemsRepeater); i++)
			{
				UIElement uIElement = itemsRepeater.TryGetElement(i);
				if (uIElement != null && uIElement is NavigationViewItem navigationViewItem)
				{
					IndexPath indexPath = ip.CloneWithChildIndex(i);
					if (navigationViewItem.Content == data)
					{
						return indexPath;
					}
					IndexPath indexPath2 = SearchEntireTreeForIndexPath(navigationViewItem, data, indexPath);
					if (indexPath2 != null)
					{
						return indexPath2;
					}
				}
			}
		}
		if (!flag)
		{
			object children = GetChildren(parentContainer);
			if (children != null)
			{
				ItemsSourceView itemsSourceView = children as ItemsSourceView;
				if (children != null && itemsSourceView == null)
				{
					itemsSourceView = new InspectingDataSource(children);
				}
				for (int j = 0; j < itemsSourceView.Count; j++)
				{
					IndexPath indexPath3 = ip.CloneWithChildIndex(j);
					object at = itemsSourceView.GetAt(j);
					if (at == data)
					{
						return indexPath3;
					}
					NavigationViewItemBase navigationViewItemBase = ResolveContainerForItem(at, j);
					if (navigationViewItemBase != null && navigationViewItemBase is NavigationViewItem navigationViewItem2)
					{
						IDataTemplateComponent dataTemplateComponent = CachedVisualTreeHelpers.GetDataTemplateComponent(navigationViewItem2);
						if (dataTemplateComponent != null)
						{
							dataTemplateComponent.Recycle();
							int nextPhase = -1;
							dataTemplateComponent.ProcessBindings(at, j, 0, out nextPhase);
						}
						IndexPath indexPath4 = SearchEntireTreeForIndexPath(navigationViewItem2, data, indexPath3);
						if (indexPath4 != null)
						{
							return indexPath4;
						}
					}
				}
			}
		}
		return null;
	}

	private NavigationViewItemBase ResolveContainerForItem(object item, int index)
	{
		ElementFactoryGetArgs elementFactoryGetArgs = new ElementFactoryGetArgs();
		elementFactoryGetArgs.Data = item;
		elementFactoryGetArgs.Index = index;
		UIElement element = m_navigationViewItemsFactory.GetElement(elementFactoryGetArgs);
		if (element != null && element is NavigationViewItemBase result)
		{
			return result;
		}
		return null;
	}

	private void RecycleContainer(UIElement container)
	{
		ElementFactoryRecycleArgs elementFactoryRecycleArgs = new ElementFactoryRecycleArgs();
		elementFactoryRecycleArgs.Element = container;
		m_navigationViewItemsFactory.RecycleElement(elementFactoryRecycleArgs);
	}

	private int GetContainerCountInRepeater(ItemsRepeater ir)
	{
		if (ir != null)
		{
			ItemsSourceView itemsSourceView = ir.ItemsSourceView;
			if (itemsSourceView != null)
			{
				return itemsSourceView.Count;
			}
		}
		return -1;
	}

	private bool DoesRepeaterHaveRealizedContainers(ItemsRepeater ir)
	{
		if (ir != null && ir.TryGetElement(0) != null)
		{
			return true;
		}
		return false;
	}

	private int GetIndexFromItem(ItemsRepeater ir, object data)
	{
		if (ir != null)
		{
			ItemsSourceView itemsSourceView = ir.ItemsSourceView;
			if (itemsSourceView != null)
			{
				return itemsSourceView.IndexOf(data);
			}
		}
		return -1;
	}

	private object GetItemFromIndex(ItemsRepeater ir, int index)
	{
		if (ir != null)
		{
			ItemsSourceView itemsSourceView = ir.ItemsSourceView;
			if (itemsSourceView != null)
			{
				return itemsSourceView.GetAt(index);
			}
		}
		return null;
	}

	private IndexPath GetIndexPathOfItem(object data)
	{
		if (data is NavigationViewItemBase nvib)
		{
			return GetIndexPathForContainer(nvib);
		}
		if (IsTopNavigationView())
		{
			IndexPath indexPath = SearchEntireTreeForIndexPath(m_topNavRepeater, data, isFooterRepeater: false);
			if (indexPath != null)
			{
				return indexPath;
			}
			indexPath = SearchEntireTreeForIndexPath(m_topNavRepeaterOverflowView, data, isFooterRepeater: false);
			if (indexPath != null)
			{
				return indexPath;
			}
			indexPath = SearchEntireTreeForIndexPath(m_topNavFooterMenuRepeater, data, isFooterRepeater: true);
			if (indexPath != null)
			{
				return indexPath;
			}
		}
		else
		{
			IndexPath indexPath2 = SearchEntireTreeForIndexPath(m_leftNavRepeater, data, isFooterRepeater: false);
			if (indexPath2 != null)
			{
				return indexPath2;
			}
			indexPath2 = SearchEntireTreeForIndexPath(m_leftNavFooterMenuRepeater, data, isFooterRepeater: true);
			if (indexPath2 != null)
			{
				return indexPath2;
			}
		}
		return new IndexPath(Array.Empty<int>());
	}

	private UIElement GetContainerForIndex(int index, bool inFooter)
	{
		if (IsTopNavigationView())
		{
			ItemsRepeater itemsRepeater = (inFooter ? m_topNavFooterMenuRepeater : (m_topDataProvider.IsItemInPrimaryList(index) ? m_topNavRepeater : m_topNavRepeaterOverflowView));
			int index2 = (inFooter ? index : m_topDataProvider.ConvertOriginalIndexToIndex(index));
			UIElement uIElement = itemsRepeater.TryGetElement(index2);
			if (uIElement != null)
			{
				return uIElement;
			}
		}
		else
		{
			UIElement uIElement2 = (inFooter ? m_leftNavFooterMenuRepeater.TryGetElement(index) : m_leftNavRepeater.TryGetElement(index));
			if (uIElement2 != null)
			{
				return uIElement2 as NavigationViewItemBase;
			}
		}
		return null;
	}

	private NavigationViewItemBase GetContainerForIndexPath(IndexPath ip, bool lastVisible = false)
	{
		if (ip != null && ip.GetSize() > 0)
		{
			UIElement containerForIndex = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == 1);
			if (containerForIndex != null)
			{
				if (lastVisible && containerForIndex is NavigationViewItem navigationViewItem && !navigationViewItem.IsExpanded)
				{
					return navigationViewItem;
				}
				return GetContainerForIndexPath(containerForIndex, ip, lastVisible);
			}
		}
		return null;
	}

	private NavigationViewItemBase GetContainerForIndexPath(UIElement firstContainer, IndexPath ip, bool lastVisible)
	{
		UIElement uIElement = firstContainer;
		if (ip.GetSize() > 2)
		{
			for (int i = 2; i < ip.GetSize(); i++)
			{
				bool flag = false;
				if (uIElement is NavigationViewItem navigationViewItem)
				{
					if (lastVisible && !navigationViewItem.IsExpanded)
					{
						return navigationViewItem;
					}
					ItemsRepeater repeater = navigationViewItem.GetRepeater();
					if (repeater != null)
					{
						UIElement uIElement2 = repeater.TryGetElement(ip.GetAt(i));
						if (uIElement2 != null)
						{
							uIElement = uIElement2;
							flag = true;
						}
					}
				}
				if (!flag)
				{
					return null;
				}
			}
		}
		return uIElement as NavigationViewItemBase;
	}

	private bool IsContainerTheSelectedItemInTheSelectionModel(NavigationViewItemBase nvib)
	{
		object selectedItem = m_selectionModel.SelectedItem;
		if (selectedItem != null)
		{
			NavigationViewItemBase navigationViewItemBase = selectedItem as NavigationViewItemBase;
			if (navigationViewItemBase == null)
			{
				navigationViewItemBase = GetContainerForIndexPath(m_selectionModel.SelectedIndex);
			}
			return navigationViewItemBase == nvib;
		}
		return false;
	}

	internal NavigationViewItem GetSelectedContainer()
	{
		object selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			if (selectedItem is NavigationViewItem result)
			{
				return result;
			}
			return NavigationViewItemOrSettingsContentFromData(selectedItem);
		}
		return null;
	}

	public void Expand(NavigationViewItem item)
	{
		ChangeIsExpandedNavigationViewItem(item, isExpanded: true);
	}

	public void Collapse(NavigationViewItem item)
	{
		ChangeIsExpandedNavigationViewItem(item, isExpanded: false);
	}

	private bool DoesNavigationViewItemHaveChildren(NavigationViewItem nvi)
	{
		if (nvi.MenuItemsSource != null)
		{
			InspectingDataSource inspectingDataSource = new InspectingDataSource(nvi.MenuItemsSource);
			return inspectingDataSource.Count > 0;
		}
		if (nvi.MenuItems.Count <= 0)
		{
			return nvi.HasUnrealizedChildren;
		}
		return true;
	}

	private void ToggleIsExpandedNavigationViewItem(NavigationViewItem nvi)
	{
		ChangeIsExpandedNavigationViewItem(nvi, !nvi.IsExpanded);
	}

	private void ChangeIsExpandedNavigationViewItem(NavigationViewItem nvi, bool isExpanded)
	{
		if (DoesNavigationViewItemHaveChildren(nvi))
		{
			nvi.IsExpanded = isExpanded;
		}
	}

	private NavigationViewItem FindLowestLevelContainerToDisplaySelectionIndicator()
	{
		int num = 1;
		IndexPath selectedIndex = m_selectionModel.SelectedIndex;
		if (selectedIndex != null && selectedIndex.GetSize() > 1)
		{
			UIElement containerForIndex = GetContainerForIndex(selectedIndex.GetAt(num), selectedIndex.GetAt(0) == 1);
			if (containerForIndex != null)
			{
				NavigationViewItem navigationViewItem = containerForIndex as NavigationViewItem;
				if (navigationViewItem != null)
				{
					NavigationViewItem navigationViewItem2 = navigationViewItem;
					bool flag = navigationViewItem2.IsRepeaterVisible();
					while (navigationViewItem != null && flag && !navigationViewItem.IsSelected && navigationViewItem.IsChildSelected)
					{
						num++;
						flag = false;
						ItemsRepeater repeater = navigationViewItem2.GetRepeater();
						if (repeater != null)
						{
							UIElement uIElement = repeater.TryGetElement(selectedIndex.GetAt(num));
							if (uIElement != null)
							{
								navigationViewItem = uIElement as NavigationViewItem;
								navigationViewItem2 = navigationViewItem;
								flag = navigationViewItem2.IsRepeaterVisible();
							}
						}
					}
					return navigationViewItem;
				}
			}
		}
		return null;
	}

	private void ShowHideChildrenItemsRepeater(NavigationViewItem nvi)
	{
		nvi.ShowHideChildren();
		if (nvi.ShouldRepeaterShowInFlyout())
		{
			if (nvi.IsExpanded)
			{
				m_lastItemExpandedIntoFlyout = nvi;
			}
			else
			{
				m_lastItemExpandedIntoFlyout = null;
			}
		}
		if (!nvi.IsSelected && nvi.IsChildSelected)
		{
			if (!nvi.IsRepeaterVisible() && nvi.IsChildSelected)
			{
				AnimateSelectionChanged(nvi);
			}
			else
			{
				AnimateSelectionChanged(FindLowestLevelContainerToDisplaySelectionIndicator());
			}
		}
		nvi.RotateExpandCollapseChevron(nvi.IsExpanded);
	}

	private object GetChildren(NavigationViewItem nvi)
	{
		if (nvi.MenuItems.Count > 0)
		{
			return nvi.MenuItems;
		}
		return nvi.MenuItemsSource;
	}

	private ItemsRepeater GetChildRepeaterForIndexPath(IndexPath ip)
	{
		if (GetContainerForIndexPath(ip) is NavigationViewItem navigationViewItem)
		{
			return navigationViewItem.GetRepeater();
		}
		return null;
	}

	private object GetChildrenForItemInIndexPath(IndexPath ip, bool forceRealize)
	{
		if (ip != null && ip.GetSize() > 1)
		{
			UIElement containerForIndex = GetContainerForIndex(ip.GetAt(1), ip.GetAt(0) == 1);
			if (containerForIndex != null)
			{
				return GetChildrenForItemInIndexPath(containerForIndex, ip, forceRealize);
			}
		}
		return null;
	}

	private object GetChildrenForItemInIndexPath(UIElement firstContainer, IndexPath ip, bool forceRealize)
	{
		UIElement uIElement = firstContainer;
		bool flag = false;
		if (ip.GetSize() > 2)
		{
			for (int i = 2; i < ip.GetSize(); i++)
			{
				bool flag2 = false;
				if (uIElement is NavigationViewItem navigationViewItem)
				{
					int at = ip.GetAt(i);
					ItemsRepeater repeater = navigationViewItem.GetRepeater();
					if (repeater != null && DoesRepeaterHaveRealizedContainers(repeater))
					{
						UIElement uIElement2 = repeater.TryGetElement(at);
						if (uIElement2 != null)
						{
							uIElement = uIElement2;
							flag2 = true;
						}
					}
					else if (forceRealize)
					{
						object children = GetChildren(navigationViewItem);
						if (children != null)
						{
							if (flag)
							{
								RecycleContainer(navigationViewItem);
								flag = false;
							}
							ItemsSourceView itemsSourceView = children as ItemsSourceView;
							if (children != null && itemsSourceView == null)
							{
								itemsSourceView = new InspectingDataSource(children);
							}
							object at2 = itemsSourceView.GetAt(at);
							if (at2 != null)
							{
								NavigationViewItemBase navigationViewItemBase = ResolveContainerForItem(at2, at);
								if (navigationViewItemBase != null && navigationViewItemBase is NavigationViewItem navigationViewItem2)
								{
									IDataTemplateComponent dataTemplateComponent = CachedVisualTreeHelpers.GetDataTemplateComponent(navigationViewItem2);
									if (dataTemplateComponent != null)
									{
										dataTemplateComponent.Recycle();
										int nextPhase = -1;
										dataTemplateComponent.ProcessBindings(at2, at, 0, out nextPhase);
									}
									uIElement = navigationViewItem2;
									flag = true;
									flag2 = true;
								}
							}
						}
					}
				}
				if (!flag2)
				{
					return null;
				}
			}
		}
		if (uIElement is NavigationViewItem navigationViewItem3)
		{
			object children2 = GetChildren(navigationViewItem3);
			if (flag)
			{
				RecycleContainer(navigationViewItem3);
			}
			return children2;
		}
		return null;
	}

	private void CollapseTopLevelMenuItems(NavigationViewPaneDisplayMode oldDisplayMode)
	{
		if (oldDisplayMode == NavigationViewPaneDisplayMode.Top)
		{
			CollapseMenuItemsInRepeater(m_topNavRepeater);
			CollapseMenuItemsInRepeater(m_topNavRepeaterOverflowView);
		}
		else
		{
			CollapseMenuItemsInRepeater(m_leftNavRepeater);
		}
	}

	private void CollapseMenuItemsInRepeater(ItemsRepeater ir)
	{
		for (int i = 0; i < GetContainerCountInRepeater(ir); i++)
		{
			UIElement uIElement = ir.TryGetElement(i);
			if (uIElement != null && uIElement is NavigationViewItem nvi)
			{
				ChangeIsExpandedNavigationViewItem(nvi, isExpanded: false);
			}
		}
	}

	private void RaiseExpandingEvent(NavigationViewItemBase container)
	{
		NavigationViewItemExpandingEventArgs navigationViewItemExpandingEventArgs = new NavigationViewItemExpandingEventArgs(this);
		navigationViewItemExpandingEventArgs.ExpandingItemContainer = container;
		this.Expanding?.Invoke(this, navigationViewItemExpandingEventArgs);
	}

	private void RaiseCollapsedEvent(NavigationViewItemBase container)
	{
		NavigationViewItemCollapsedEventArgs navigationViewItemCollapsedEventArgs = new NavigationViewItemCollapsedEventArgs(this);
		navigationViewItemCollapsedEventArgs.CollapsedItemContainer = container;
		this.Collapsed?.Invoke(this, navigationViewItemCollapsedEventArgs);
	}

	private bool IsTopLevelItem(NavigationViewItemBase nvib)
	{
		return IsRootItemsRepeater(GetParentItemsRepeaterForContainer(nvib));
	}

	private void OnRepeaterUnoBeforeElementPrepared(ItemsRepeater itemsRepeater, ItemsRepeaterElementPreparedEventArgs args)
	{
		OnRepeaterElementPrepared(itemsRepeater, args);
	}

	private void SetHeaderContentMinHeight(double minHeight)
	{
		if (m_paneHeaderContentBorderWrapper == null)
		{
			m_paneHeaderContentBorderWrapper = GetTemplateChild("PaneHeaderContentBorderWrapper") as Grid;
		}
		if (m_paneHeaderContentBorderWrapper != null)
		{
			m_paneHeaderContentBorderWrapper.MinHeight = minHeight;
		}
	}

	private bool IsThemeShadowSupported()
	{
		return ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.ThemeShadow");
	}

	internal TopNavigationViewDataProvider GetTopDataProvider()
	{
		return m_topDataProvider;
	}

	internal NavigationViewItemsFactory GetNavigationViewItemsFactory()
	{
		return m_navigationViewItemsFactory;
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationView navigationView = (NavigationView)sender;
		navigationView.OnPropertyChanged(args);
	}

	private static void OnCompactModeThresholdWidthPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationView navigationView = (NavigationView)sender;
		double num = (double)args.NewValue;
		double value = num;
		navigationView.CoerceToGreaterThanZero(ref value);
		if (Math.Abs(value - num) > 0.1)
		{
			sender.SetValue(args.Property, value);
		}
		else
		{
			navigationView.OnPropertyChanged(args);
		}
	}

	private static void OnCompactPaneLengthPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationView navigationView = (NavigationView)sender;
		double num = (double)args.NewValue;
		double value = num;
		navigationView.CoerceToGreaterThanZero(ref value);
		if (Math.Abs(value - num) > 0.1)
		{
			sender.SetValue(args.Property, value);
		}
		else
		{
			navigationView.OnPropertyChanged(args);
		}
	}

	private static void OnExpandedModeThresholdWidthPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationView navigationView = (NavigationView)sender;
		double num = (double)args.NewValue;
		double value = num;
		navigationView.CoerceToGreaterThanZero(ref value);
		if (Math.Abs(value - num) > 0.1)
		{
			sender.SetValue(args.Property, value);
		}
		else
		{
			navigationView.OnPropertyChanged(args);
		}
	}

	private static void OnOpenPaneLengthPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationView navigationView = (NavigationView)sender;
		double num = (double)args.NewValue;
		double value = num;
		navigationView.CoerceToGreaterThanZero(ref value);
		if (Math.Abs(value - num) > 0.1)
		{
			sender.SetValue(args.Property, value);
		}
		else
		{
			navigationView.OnPropertyChanged(args);
		}
	}
}
