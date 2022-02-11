using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class NavigationView : ContentControl
{
	private enum TopNavigationViewLayoutState
	{
		InitStep1,
		InitStep2,
		InitStep3,
		Normal,
		Overflow,
		OverflowNoChange
	}

	private enum NavigationRecommendedTransitionDirection
	{
		FromOverflow,
		FromLeft,
		FromRight,
		Default
	}

	private static string c_togglePaneButtonName = "TogglePaneButton";

	private static string c_paneTitleTextBlock = "PaneTitleTextBlock";

	private static string c_rootSplitViewName = "RootSplitView";

	private static string c_menuItemsHost = "MenuItemsHost";

	private static string c_settingsName = "SettingsNavPaneItem";

	private static string c_settingsNameTopNav = "SettingsTopNavPaneItem";

	private static string c_paneContentGridName = "PaneContentGrid";

	private static string c_rootGridName = "RootGrid";

	private static string c_contentGridName = "ContentGrid";

	private static string c_searchButtonName = "PaneAutoSuggestButton";

	private static string c_togglePaneTopPadding = "TogglePaneTopPadding";

	private static string c_contentPaneTopPadding = "ContentPaneTopPadding";

	private static string c_headerContent = "HeaderContent";

	private static string c_navViewBackButton = "NavigationViewBackButton";

	private static string c_navViewBackButtonToolTip = "NavigationViewBackButtonToolTip";

	private static string c_buttonHolderGrid = "ButtonHolderGrid";

	private static string c_topNavMenuItemsHost = "TopNavMenuItemsHost";

	private static string c_topNavOverflowButton = "TopNavOverflowButton";

	private static string c_topNavMenuItemsOverflowHost = "TopNavMenuItemsOverflowHost";

	private static string c_topNavGrid = "TopNavGrid";

	private static string c_topNavContentOverlayAreaGrid = "TopNavContentOverlayAreaGrid";

	private static string c_leftNavPaneAutoSuggestBoxPresenter = "PaneAutoSuggestBoxPresenter";

	private static string c_topNavPaneAutoSuggestBoxPresenter = "TopPaneAutoSuggestBoxPresenter";

	private static string c_leftNavFooterContentBorder = "FooterContentBorder";

	private static string c_leftNavPaneHeaderContentBorder = "PaneHeaderContentBorder";

	private static string c_leftNavPaneCustomContentBorder = "PaneCustomContentBorder";

	private static string c_paneHeaderOnTopPane = "PaneHeaderOnTopPane";

	private static string c_paneCustomContentOnTopPane = "PaneCustomContentOnTopPane";

	private static string c_paneFooterOnTopPane = "PaneFooterOnTopPane";

	private static int c_backButtonHeight = 44;

	private static int c_backButtonWidth = 48;

	private static int c_paneToggleButtonWidth = 48;

	private static int c_toggleButtonHeightWhenShouldPreserveNavigationViewRS3Behavior = 56;

	private static int c_backButtonRowDefinition = 1;

	private int s_measureOnInitStep2CountThreshold = 4;

	private static Size c_infSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

	private SerialDisposable _settingsItemSubscriptions = new SerialDisposable();

	private Vector2 c_frame1point1 = new Vector2(0.9f, 0.1f);

	private Vector2 c_frame1point2 = new Vector2(1f, 0.2f);

	private Vector2 c_frame2point1 = new Vector2(0.1f, 0.9f);

	private Vector2 c_frame2point2 = new Vector2(0.2f, 1f);

	private ApplicationView m_applicationView;

	private UIViewSettings m_uiViewSettings;

	private Button m_paneToggleButton;

	private SplitView m_rootSplitView;

	private NavigationViewItem m_settingsItem;

	private UIElement m_paneContentGrid;

	private Button m_paneSearchButton;

	private Button m_backButton;

	private TextBlock m_paneTitleTextBlock;

	private Grid m_buttonHolderGrid;

	private ListView m_leftNavListView;

	private ListView m_topNavListView;

	private Button m_topNavOverflowButton;

	private ListView m_topNavListOverflowView;

	private Grid m_topNavGrid;

	private Border m_topNavContentOverlayAreaGrid;

	private UIElement m_prevIndicator;

	private UIElement m_nextIndicator;

	private FrameworkElement m_togglePaneTopPadding;

	private FrameworkElement m_contentPaneTopPadding;

	private FrameworkElement m_headerContent;

	private CoreApplicationViewTitleBar m_coreTitleBar;

	private ContentControl m_leftNavPaneAutoSuggestBoxPresenter;

	private ContentControl m_topNavPaneAutoSuggestBoxPresenter;

	private ContentControl m_leftNavPaneHeaderContentBorder;

	private ContentControl m_leftNavPaneCustomContentBorder;

	private ContentControl m_leftNavFooterContentBorder;

	private ContentControl m_paneHeaderOnTopPane;

	private ContentControl m_paneCustomContentOnTopPane;

	private ContentControl m_paneFooterOnTopPane;

	private int m_indexOfLastSelectedItemInTopNav;

	private object m_lastSelectedItemPendingAnimationInTopNav;

	private List<int> m_itemsRemovedFromMenuFlyout = new List<int>();

	private SerialDisposable m_layoutUpdatedToken = new SerialDisposable();

	private bool m_wasForceClosed;

	private bool m_isClosedCompact;

	private bool m_blockNextClosingEvent;

	private bool m_initialListSizeStateSet;

	private TopNavigationViewDataProvider m_topDataProvider;

	private bool m_appliedTemplate;

	private bool m_shouldIgnoreNextSelectionChange;

	private bool m_shouldRaiseInvokeItemInSelectionChange;

	private bool m_shouldInvalidateMeasureOnNextLayoutUpdate;

	private bool m_shouldIgnoreOverflowItemSelectionChange;

	private bool m_shouldIgnoreNextMeasureOverride;

	private bool m_selectionChangeFromOverflowMenu;

	private TopNavigationViewLayoutState m_topNavigationMode;

	private double m_topNavigationRecoveryGracePeriodWidth = 5.0;

	private int m_measureOnInitStep2Count;

	private bool m_isOpenPaneForInteraction;

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

	public double OpenPaneLength
	{
		get
		{
			return (double)GetValue(OpenPaneLengthProperty);
		}
		set
		{
			SetValue(OpenPaneLengthProperty, value);
		}
	}

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

	public double CompactPaneLength
	{
		get
		{
			return (double)GetValue(CompactPaneLengthProperty);
		}
		set
		{
			SetValue(CompactPaneLengthProperty, value);
		}
	}

	public double CompactModeThresholdWidth
	{
		get
		{
			return (double)GetValue(CompactModeThresholdWidthProperty);
		}
		set
		{
			SetValue(CompactModeThresholdWidthProperty, value);
		}
	}

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

	public NavigationViewDisplayMode DisplayMode
	{
		get
		{
			return (NavigationViewDisplayMode)GetValue(DisplayModeProperty);
		}
		internal set
		{
			SetValue(DisplayModeProperty, value);
		}
	}

	public IList<object> MenuItems => (IList<object>)GetValue(MenuItemsProperty);

	public object SettingsItem => GetValue(SettingsItemProperty);

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

	public NavigationViewTemplateSettings TemplateSettings => (NavigationViewTemplateSettings)GetValue(TemplateSettingsProperty);

	public static DependencyProperty IsPaneVisibleProperty { get; } = DependencyProperty.Register("IsPaneVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty OverflowLabelModeProperty { get; } = DependencyProperty.Register("OverflowLabelMode", typeof(NavigationViewOverflowLabelMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewOverflowLabelMode.MoreLabel, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty PaneCustomContentProperty { get; } = DependencyProperty.Register("PaneCustomContent", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty PaneDisplayModeProperty { get; } = DependencyProperty.Register("PaneDisplayMode", typeof(NavigationViewPaneDisplayMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewPaneDisplayMode.Auto, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty PaneHeaderProperty { get; } = DependencyProperty.Register("PaneHeader", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty SelectionFollowsFocusProperty { get; } = DependencyProperty.Register("SelectionFollowsFocus", typeof(NavigationViewSelectionFollowsFocus), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewSelectionFollowsFocus.Disabled, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty ShoulderNavigationEnabledProperty { get; } = DependencyProperty.Register("ShoulderNavigationEnabled", typeof(NavigationViewShoulderNavigationEnabled), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewShoulderNavigationEnabled.Never, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(NavigationViewTemplateSettings), typeof(NavigationView), new FrameworkPropertyMetadata(null));


	public static DependencyProperty ContentOverlayProperty { get; } = DependencyProperty.Register("ContentOverlay", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null));


	public static DependencyProperty AlwaysShowHeaderProperty { get; } = DependencyProperty.Register("AlwaysShowHeader", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty AutoSuggestBoxProperty { get; } = DependencyProperty.Register("AutoSuggestBox", typeof(AutoSuggestBox), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty CompactModeThresholdWidthProperty { get; } = DependencyProperty.Register("CompactModeThresholdWidth", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(641.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged_CoerceToGreaterThanZero(e);
	}));


	public static DependencyProperty CompactPaneLengthProperty { get; } = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(48.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged_CoerceToGreaterThanZero(e);
	}));


	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(NavigationViewDisplayMode), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewDisplayMode.Minimal, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty ExpandedModeThresholdWidthProperty { get; } = DependencyProperty.Register("ExpandedModeThresholdWidth", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(1008.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged_CoerceToGreaterThanZero(e);
	}));


	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty IsPaneOpenProperty { get; } = DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty IsPaneToggleButtonVisibleProperty { get; } = DependencyProperty.Register("IsPaneToggleButtonVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty IsSettingsVisibleProperty { get; } = DependencyProperty.Register("IsSettingsVisible", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(true, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemContainerStyleProperty { get; } = DependencyProperty.Register("MenuItemContainerStyle", typeof(Style), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemContainerStyleSelectorProperty { get; } = DependencyProperty.Register("MenuItemContainerStyleSelector", typeof(StyleSelector), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemTemplateProperty { get; } = DependencyProperty.Register("MenuItemTemplate", typeof(DataTemplate), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemTemplateSelectorProperty { get; } = DependencyProperty.Register("MenuItemTemplateSelector", typeof(DataTemplateSelector), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemsProperty { get; } = DependencyProperty.Register("MenuItems", typeof(IList<object>), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty MenuItemsSourceProperty { get; } = DependencyProperty.Register("MenuItemsSource", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty OpenPaneLengthProperty { get; } = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(NavigationView), new FrameworkPropertyMetadata(320.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged_CoerceToGreaterThanZero(e);
	}));


	public static DependencyProperty PaneFooterProperty { get; } = DependencyProperty.Register("PaneFooter", typeof(UIElement), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty PaneToggleButtonStyleProperty { get; } = DependencyProperty.Register("PaneToggleButtonStyle", typeof(Style), typeof(NavigationView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty SelectedItemProperty { get; } = DependencyProperty.Register("SelectedItem", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty SettingsItemProperty { get; } = DependencyProperty.Register("SettingsItem", typeof(object), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty IsBackButtonVisibleProperty { get; } = DependencyProperty.Register("IsBackButtonVisible", typeof(NavigationViewBackButtonVisible), typeof(NavigationView), new FrameworkPropertyMetadata(NavigationViewBackButtonVisible.Auto, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty IsBackEnabledProperty { get; } = DependencyProperty.Register("IsBackEnabled", typeof(bool), typeof(NavigationView), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public static DependencyProperty PaneTitleProperty { get; } = DependencyProperty.Register("PaneTitle", typeof(string), typeof(NavigationView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as NavigationView)?.OnPropertyChanged(e);
	}));


	public event TypedEventHandler<NavigationView, NavigationViewDisplayModeChangedEventArgs> DisplayModeChanged;

	public event TypedEventHandler<NavigationView, NavigationViewItemInvokedEventArgs> ItemInvoked;

	public event TypedEventHandler<NavigationView, NavigationViewSelectionChangedEventArgs> SelectionChanged;

	public event TypedEventHandler<NavigationView, NavigationViewBackRequestedEventArgs> BackRequested;

	public event TypedEventHandler<NavigationView, object> PaneClosed;

	public event TypedEventHandler<NavigationView, NavigationViewPaneClosingEventArgs> PaneClosing;

	public event TypedEventHandler<NavigationView, object> PaneOpened;

	public event TypedEventHandler<NavigationView, object> PaneOpening;

	~NavigationView()
	{
	}

	private void UnhookEventsAndClearFields(bool isFromDestructor = false)
	{
	}

	public NavigationView()
	{
		SetValue(TemplateSettingsProperty, new NavigationViewTemplateSettings());
		base.DefaultStyleKey = typeof(NavigationView);
		m_topDataProvider = new TopNavigationViewDataProvider(this);
		base.SizeChanged += OnSizeChanged;
		ObservableVector<object> value = new ObservableVector<object>();
		SetValue(MenuItemsProperty, value);
		m_topDataProvider.OnRawDataChanged(delegate(NotifyCollectionChangedEventArgs args)
		{
			OnTopNavDataSourceChanged(args);
		});
		base.Unloaded += OnUnloaded;
	}

	protected override void OnApplyTemplate()
	{
		m_appliedTemplate = false;
		UnhookEventsAndClearFields();
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		CoreApplicationViewTitleBar titleBar = CoreApplication.GetCurrentView().TitleBar;
		if (titleBar != null)
		{
			m_coreTitleBar = titleBar;
			titleBar.LayoutMetricsChanged += OnTitleBarMetricsChanged;
			titleBar.IsVisibleChanged += OnTitleBarIsVisibleChanged;
			m_headerContent = GetTemplateChild(c_headerContent) as FrameworkElement;
			if (ShouldPreserveNavigationViewRS4Behavior())
			{
				m_togglePaneTopPadding = GetTemplateChild(c_togglePaneTopPadding) as FrameworkElement;
				m_contentPaneTopPadding = GetTemplateChild(c_contentPaneTopPadding) as FrameworkElement;
			}
		}
		else
		{
			m_coreTitleBar = null;
			m_headerContent = null;
			m_togglePaneTopPadding = null;
			m_contentPaneTopPadding = null;
		}
		if (GetTemplateChild(c_togglePaneButtonName) is Button button)
		{
			m_paneToggleButton = button;
			button.Click += OnPaneToggleButtonClick;
			SetPaneToggleButtonAutomationName();
			if (SharedHelpers.IsRS3OrHigher())
			{
				KeyboardAccelerator keyboardAccelerator = new KeyboardAccelerator();
				keyboardAccelerator.Key = VirtualKey.Back;
				keyboardAccelerator.Modifiers = VirtualKeyModifiers.Windows;
				button.KeyboardAccelerators.Add(keyboardAccelerator);
			}
		}
		if (GetTemplateChild(c_leftNavPaneHeaderContentBorder) is ContentControl leftNavPaneHeaderContentBorder)
		{
			m_leftNavPaneHeaderContentBorder = leftNavPaneHeaderContentBorder;
		}
		if (GetTemplateChild(c_leftNavPaneCustomContentBorder) is ContentControl leftNavPaneCustomContentBorder)
		{
			m_leftNavPaneCustomContentBorder = leftNavPaneCustomContentBorder;
		}
		if (GetTemplateChild(c_leftNavFooterContentBorder) is ContentControl leftNavFooterContentBorder)
		{
			m_leftNavFooterContentBorder = leftNavFooterContentBorder;
		}
		if (GetTemplateChild(c_paneHeaderOnTopPane) is ContentControl paneHeaderOnTopPane)
		{
			m_paneHeaderOnTopPane = paneHeaderOnTopPane;
		}
		if (GetTemplateChild(c_paneCustomContentOnTopPane) is ContentControl paneCustomContentOnTopPane)
		{
			m_paneCustomContentOnTopPane = paneCustomContentOnTopPane;
		}
		if (GetTemplateChild(c_paneFooterOnTopPane) is ContentControl paneFooterOnTopPane)
		{
			m_paneFooterOnTopPane = paneFooterOnTopPane;
		}
		if (GetTemplateChild(c_paneTitleTextBlock) is TextBlock paneTitleTextBlock)
		{
			m_paneTitleTextBlock = paneTitleTextBlock;
			UpdatePaneTitleMargins();
		}
		if (GetTemplateChild(c_rootSplitViewName) is SplitView splitView)
		{
			m_rootSplitView = splitView;
			long num = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewClosedCompactChanged);
			long num2 = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewClosedCompactChanged);
			if (SharedHelpers.IsRS3OrHigher())
			{
				splitView.PaneClosed += OnSplitViewPaneClosed;
				splitView.PaneClosing += OnSplitViewPaneClosing;
				splitView.PaneOpened += OnSplitViewPaneOpened;
				splitView.PaneOpening += OnSplitViewPaneOpening;
			}
			UpdateIsClosedCompact();
		}
		if (GetTemplateChild(c_menuItemsHost) is ListView listView)
		{
			m_leftNavListView = listView;
			listView.Loaded += OnLoaded;
			listView.SelectionChanged += OnSelectionChanged;
			listView.ItemClick += OnItemClick;
			SetNavigationViewListPosition(listView, NavigationViewListPosition.LeftNav);
		}
		if (GetTemplateChild(c_topNavMenuItemsHost) is ListView listView2)
		{
			m_topNavListView = listView2;
			listView2.Loaded += OnLoaded;
			listView2.SelectionChanged += OnSelectionChanged;
			listView2.ItemClick += OnItemClick;
			SetNavigationViewListPosition(listView2, NavigationViewListPosition.TopPrimary);
		}
		if (GetTemplateChild(c_topNavMenuItemsOverflowHost) is ListView listView3)
		{
			m_topNavListOverflowView = listView3;
			listView3.SelectionChanged += OnOverflowItemSelectionChanged;
			SetNavigationViewListPosition(listView3, NavigationViewListPosition.TopOverflow);
		}
		if (GetTemplateChild(c_topNavOverflowButton) is Button button2)
		{
			m_topNavOverflowButton = button2;
			AutomationProperties.SetName(button2, ResourceAccessor.GetLocalizedStringResource("NavigationOverflowButtonText"));
			button2.Content = ResourceAccessor.GetLocalizedStringResource("NavigationOverflowButtonText");
			Visual elementVisual = ElementCompositionPreview.GetElementVisual(button2);
			CreateAndAttachHeaderAnimation(elementVisual);
		}
		if (GetTemplateChild(c_topNavGrid) is Grid topNavGrid)
		{
			m_topNavGrid = topNavGrid;
		}
		if (GetTemplateChild(c_topNavContentOverlayAreaGrid) is Border topNavContentOverlayAreaGrid)
		{
			m_topNavContentOverlayAreaGrid = topNavContentOverlayAreaGrid;
		}
		if (GetTemplateChild(c_leftNavPaneAutoSuggestBoxPresenter) is ContentControl leftNavPaneAutoSuggestBoxPresenter)
		{
			m_leftNavPaneAutoSuggestBoxPresenter = leftNavPaneAutoSuggestBoxPresenter;
		}
		if (GetTemplateChild(c_topNavPaneAutoSuggestBoxPresenter) is ContentControl topNavPaneAutoSuggestBoxPresenter)
		{
			m_topNavPaneAutoSuggestBoxPresenter = topNavPaneAutoSuggestBoxPresenter;
		}
		m_paneContentGrid = GetTemplateChild(c_paneContentGridName) as UIElement;
		if (GetTemplateChild(c_searchButtonName) is Button button3)
		{
			m_paneSearchButton = button3;
			button3.Click += OnPaneSearchButtonClick;
			string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("NavigationViewSearchButtonName");
			AutomationProperties.SetName(button3, localizedStringResource);
		}
		if (GetTemplateChild(c_navViewBackButton) is Button button4)
		{
			m_backButton = button4;
			button4.Click += OnBackButtonClicked;
			string localizedStringResource2 = ResourceAccessor.GetLocalizedStringResource("NavigationBackButtonName");
			AutomationProperties.SetName(button4, localizedStringResource2);
		}
		if (GetTemplateChild(c_navViewBackButtonToolTip) is ToolTip toolTip)
		{
			string text = (string)(toolTip.Content = ResourceAccessor.GetLocalizedStringResource("NavigationBackButtonToolTip"));
		}
		if (GetTemplateChild(c_buttonHolderGrid) is Grid grid)
		{
			grid.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled;
			grid.TabFocusNavigation = KeyboardNavigationMode.Once;
			grid.GettingFocus += OnButtonHolderGridGettingFocus;
		}
		if (SharedHelpers.IsRS2OrHigher())
		{
			if (GetTemplateChild(c_rootGridName) is Grid grid2)
			{
				grid2.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Enabled;
			}
			if (GetTemplateChild(c_contentGridName) is Grid grid3)
			{
				grid3.XYFocusKeyboardNavigation = XYFocusKeyboardNavigationMode.Disabled;
			}
		}
		if (SharedHelpers.IsRS1OrHigher() && ShouldPreserveNavigationViewRS4Behavior() && m_leftNavListView != null)
		{
			m_leftNavListView.SingleSelectionFollowsFocus = false;
		}
		base.AccessKeyInvoked += OnAccessKeyInvoked;
		m_appliedTemplate = true;
		UpdatePaneDisplayMode();
		UpdateHeaderVisibility();
		UpdateTitleBarPadding();
		UpdatePaneTabFocusNavigation();
		UpdateBackButtonVisibility();
		UpdateSingleSelectionFollowsFocusTemplateSetting();
		UpdateNavigationViewUseSystemVisual();
		PropagateNavigationViewAsParent();
		UpdateLocalVisualState();
	}

	private void CreateAndHookEventsToSettings(string settingsName)
	{
		NavigationViewItem settingsItem = GetTemplateChild(settingsName) as NavigationViewItem;
		if (settingsItem != null && settingsItem != m_settingsItem)
		{
			object selectedItem = SelectedItem;
			bool flag = selectedItem != null && IsSettingsItem(selectedItem);
			if (flag)
			{
				SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(null);
			}
			_settingsItemSubscriptions.Disposable = null;
			CompositeDisposable disposable = new CompositeDisposable();
			m_settingsItem = settingsItem;
			settingsItem.Tapped += OnSettingsTapped;
			disposable.Add(delegate
			{
				settingsItem.Tapped -= OnSettingsTapped;
			});
			settingsItem.KeyDown += OnSettingsKeyDown;
			disposable.Add(delegate
			{
				settingsItem.KeyDown -= OnSettingsKeyDown;
			});
			settingsItem.KeyUp += OnSettingsKeyUp;
			disposable.Add(delegate
			{
				settingsItem.KeyUp -= OnSettingsKeyUp;
			});
			string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("SettingsButtonName");
			AutomationProperties.SetName(settingsItem, localizedStringResource);
			UpdateSettingsItemToolTip();
			if (!IsTopNavigationView())
			{
				settingsItem.Content = localizedStringResource;
			}
			SetValue(SettingsItemProperty, settingsItem);
			if (flag)
			{
				SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(m_settingsItem);
			}
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (!ShouldIgnoreMeasureOverride())
		{
			try
			{
				m_shouldIgnoreOverflowItemSelectionChange = true;
				m_shouldIgnoreNextSelectionChange = true;
				if (IsTopNavigationView() && IsTopPrimaryListVisible())
				{
					if (double.IsInfinity(availableSize.Width))
					{
						m_topDataProvider.MoveAllItemsToPrimaryList();
					}
					else
					{
						HandleTopNavigationMeasureOverride(availableSize);
						if (m_topNavigationMode != TopNavigationViewLayoutState.Normal && m_topNavigationMode != TopNavigationViewLayoutState.Overflow)
						{
							RequestInvalidateMeasureOnNextLayoutUpdate();
						}
					}
				}
				m_layoutUpdatedToken.Disposable = null;
				base.LayoutUpdated += OnLayoutUpdated;
				m_layoutUpdatedToken.Disposable = Disposable.Create(delegate
				{
					base.LayoutUpdated -= OnLayoutUpdated;
				});
			}
			finally
			{
				m_shouldIgnoreOverflowItemSelectionChange = false;
				m_shouldIgnoreNextSelectionChange = false;
			}
		}
		else
		{
			RequestInvalidateMeasureOnNextLayoutUpdate();
		}
		return base.MeasureOverride(availableSize);
	}

	private void OnLayoutUpdated(object sender, object e)
	{
		m_layoutUpdatedToken.Disposable = null;
		if (m_shouldInvalidateMeasureOnNextLayoutUpdate)
		{
			m_shouldInvalidateMeasureOnNextLayoutUpdate = false;
			InvalidateMeasure();
			return;
		}
		object selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(selectedItem);
			if (navigationViewItem != null && !navigationViewItem.IsSelected && navigationViewItem.SelectsOnInvoked)
			{
				navigationViewItem.IsSelected = true;
			}
		}
		if (m_lastSelectedItemPendingAnimationInTopNav != null)
		{
			AnimateSelectionChanged(m_lastSelectedItemPendingAnimationInTopNav, selectedItem);
		}
		else
		{
			AnimateSelectionChanged(null, selectedItem);
		}
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		double width = args.NewSize.Width;
		UpdateAdaptiveLayout(width);
		UpdateTitleBarPadding();
		UpdateBackButtonVisibility();
		UpdatePaneTitleMargins();
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
			else if (width < CompactModeThresholdWidth)
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
			throw new InvalidOperationException();
		}
		SetDisplayMode(navigationViewDisplayMode, forceSetDisplayMode);
		if (navigationViewDisplayMode == NavigationViewDisplayMode.Expanded && !m_wasForceClosed)
		{
			OpenPane();
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

	private void OnButtonHolderGridGettingFocus(UIElement sender, GettingFocusEventArgs args)
	{
		Button backButton = m_backButton;
		if (backButton != null)
		{
			Button paneToggleButton = m_paneToggleButton;
			if (paneToggleButton != null && paneToggleButton.Visibility == Visibility.Visible && args.NewFocusedElement == backButton && (args.Direction == FocusNavigationDirection.Previous || args.Direction == FocusNavigationDirection.Next))
			{
				args.TrySetNewFocusedElement(paneToggleButton);
			}
		}
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
				navigationViewPaneClosingEventArgs.SplitViewClosingArgs = args;
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
			ListView leftNavListView = m_leftNavListView;
			if (leftNavListView != null && (rootSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay || rootSplitView.DisplayMode == SplitViewDisplayMode.CompactInline))
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
		if (m_leftNavListView != null)
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
			UpdateBackButtonVisibility();
			UpdatePaneTitleMargins();
			UpdatePaneToggleSize();
		}
	}

	private void OnBackButtonClicked(object sender, RoutedEventArgs args)
	{
		this.BackRequested?.Invoke(this, new NavigationViewBackRequestedEventArgs());
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
			return IsBackButtonVisible switch
			{
				NavigationViewBackButtonVisible.Auto => !SharedHelpers.IsOnXbox(), 
				NavigationViewBackButtonVisible.Visible => true, 
				_ => false, 
			};
		}
		return false;
	}

	private void SetPaneToggleButtonAutomationName()
	{
		string value = ((!IsPaneOpen) ? ResourceAccessor.GetLocalizedStringResource("NavigationButtonClosedName") : ResourceAccessor.GetLocalizedStringResource("NavigationButtonOpenName"));
		Button paneToggleButton = m_paneToggleButton;
		if (paneToggleButton != null)
		{
			AutomationProperties.SetName(paneToggleButton, value);
		}
	}

	private void UpdateSettingsItemToolTip()
	{
		NavigationViewItem settingsItem = m_settingsItem;
		if (settingsItem != null && !IsTopNavigationView() && IsPaneOpen)
		{
			ToolTipService.SetToolTip(settingsItem, null);
		}
	}

	private void OnSettingsTapped(object sender, TappedRoutedEventArgs args)
	{
		OnSettingsInvoked();
	}

	private void OnSettingsKeyDown(object sender, KeyRoutedEventArgs args)
	{
		VirtualKey key = args.Key;
		if (key == VirtualKey.Space || key == VirtualKey.Enter)
		{
			args.Handled = true;
			OnSettingsInvoked();
		}
	}

	private void OnSettingsKeyUp(object sender, KeyRoutedEventArgs args)
	{
		if (!args.Handled && args.OriginalKey == VirtualKey.GamepadA)
		{
			args.Handled = true;
			OnSettingsInvoked();
		}
	}

	private void OnSettingsInvoked()
	{
		object selectedItem = SelectedItem;
		NavigationViewItem settingsItem = m_settingsItem;
		if (IsSettingsItem(selectedItem))
		{
			RaiseItemInvoked(settingsItem, isSettings: true);
		}
		else if (settingsItem != null)
		{
			SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(settingsItem);
		}
	}

	private void AnimateSelectionChangedToItem(object selectedItem)
	{
		if (selectedItem != null && !IsSelectionSuppressed(selectedItem))
		{
			AnimateSelectionChanged(null, selectedItem);
		}
	}

	private void AnimateSelectionChanged(object prevItem, object nextItem)
	{
		UIElement uIElement = FindSelectionIndicator(prevItem);
		UIElement uIElement2 = FindSelectionIndicator(nextItem);
		bool flag = false;
		if (m_prevIndicator != null || m_nextIndicator != null)
		{
			if (uIElement2 != null && m_nextIndicator == uIElement2)
			{
				if (uIElement != null && uIElement != m_prevIndicator)
				{
					ResetElementAnimationProperties(uIElement, 0f);
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
		if (prevItem != nextItem && paneContentGrid != null && uIElement != null && uIElement2 != null && SharedHelpers.IsAnimationsEnabled())
		{
			ResetElementAnimationProperties(uIElement, 1f);
			ResetElementAnimationProperties(uIElement2, 1f);
			Point point = new Point(0.0, 0.0);
			Point point2 = uIElement.TransformToVisual(paneContentGrid).TransformPoint(point);
			Point point3 = uIElement2.TransformToVisual(paneContentGrid).TransformPoint(point);
			if (IsTopNavigationView())
			{
				double x = point2.X;
				double x2 = point3.X;
			}
			else
			{
				double x = point2.Y;
				double x2 = point3.Y;
			}
			m_prevIndicator = uIElement;
			m_nextIndicator = uIElement2;
			OnAnimationComplete(null, null);
		}
		else
		{
			ResetElementAnimationProperties(uIElement, 0f);
			ResetElementAnimationProperties(uIElement2, 1f);
		}
		if (m_lastSelectedItemPendingAnimationInTopNav != null && (nextItem == null || uIElement2 != null))
		{
			m_lastSelectedItemPendingAnimationInTopNav = null;
		}
	}

	private void PlayIndicatorAnimations(UIElement indicator, float from, float to, bool isOutgoing)
	{
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(indicator);
		Compositor compositor = elementVisual.Compositor;
		Size renderSize = indicator.RenderSize;
		double num = (IsTopNavigationView() ? renderSize.Width : renderSize.Height);
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
		scalarKeyFrameAnimation2.InsertKeyFrame(0f, from);
		scalarKeyFrameAnimation2.InsertKeyFrame(0.333f, to, stepEasingFunction);
		scalarKeyFrameAnimation2.Duration = TimeSpan.FromMilliseconds(600.0);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation3 = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation3.InsertKeyFrame(0f, 1f);
		scalarKeyFrameAnimation3.InsertKeyFrame(0.333f, (float)((double)Math.Abs(to - from) / num + 1.0), compositor.CreateCubicBezierEasingFunction(c_frame1point1, c_frame1point2));
		scalarKeyFrameAnimation3.InsertKeyFrame(1f, 1f, compositor.CreateCubicBezierEasingFunction(c_frame2point1, c_frame2point2));
		scalarKeyFrameAnimation3.Duration = TimeSpan.FromMilliseconds(600.0);
		ScalarKeyFrameAnimation scalarKeyFrameAnimation4 = compositor.CreateScalarKeyFrameAnimation();
		scalarKeyFrameAnimation4.InsertKeyFrame(0f, (float)((from < to) ? 0.0 : num));
		scalarKeyFrameAnimation4.InsertKeyFrame(1f, (float)((from < to) ? num : 0.0), stepEasingFunction);
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
				return navigationViewItem.GetSelectionIndicator();
			}
		}
		return null;
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		if (m_shouldIgnoreNextSelectionChange)
		{
			return;
		}
		object obj = null;
		object obj2 = null;
		if (args.RemovedItems.Count > 0)
		{
			obj = args.RemovedItems[0];
		}
		if (args.AddedItems.Count > 0)
		{
			obj2 = args.AddedItems[0];
		}
		if (obj != null && obj2 == null && !IsSettingsItem(obj))
		{
			if (obj is NavigationViewItem navigationViewItem)
			{
				navigationViewItem.IsSelected = true;
			}
		}
		else
		{
			SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(obj2);
		}
	}

	private void OnOverflowItemSelectionChanged(object sender, SelectionChangedEventArgs args)
	{
		if (m_shouldIgnoreNextMeasureOverride || m_shouldIgnoreOverflowItemSelectionChange)
		{
			return;
		}
		try
		{
			m_shouldIgnoreNextMeasureOverride = true;
			m_selectionChangeFromOverflowMenu = true;
			if (args.AddedItems.Count <= 0)
			{
				return;
			}
			object obj = args.AddedItems[0];
			if (obj != null)
			{
				CloseTopNavigationViewFlyout();
				if (!IsSelectionSuppressed(obj))
				{
					SelectOverflowItem(obj);
				}
				else
				{
					RaiseItemInvoked(obj, isSettings: false);
				}
			}
		}
		finally
		{
			m_shouldIgnoreNextMeasureOverride = false;
			m_selectionChangeFromOverflowMenu = false;
		}
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
		object obj = nextItem;
		if (m_shouldIgnoreNextSelectionChange)
		{
			return;
		}
		try
		{
			m_shouldIgnoreNextSelectionChange = true;
			bool flag = IsSettingsItem(obj);
			if (IsSelectionSuppressed(obj))
			{
				UndoSelectionAndRevertSelectionTo(prevItem, obj);
				RaiseItemInvoked(obj, flag);
				return;
			}
			NavigationRecommendedTransitionDirection recommendedDirection = NavigationRecommendedTransitionDirection.Default;
			if (IsTopNavigationView())
			{
				if (m_selectionChangeFromOverflowMenu)
				{
					recommendedDirection = NavigationRecommendedTransitionDirection.FromOverflow;
				}
				else if (!flag && prevItem != null && obj != null)
				{
					recommendedDirection = GetRecommendedTransitionDirection(NavigationViewItemBaseOrSettingsContentFromData(prevItem), NavigationViewItemBaseOrSettingsContentFromData(obj));
				}
			}
			if (m_shouldRaiseInvokeItemInSelectionChange)
			{
				RaiseItemInvoked(obj, flag, null, recommendedDirection);
				object selectedItem = SelectedItem;
				if (obj != selectedItem)
				{
					object obj2 = obj;
					obj = selectedItem;
					flag = IsSettingsItem(obj);
					recommendedDirection = NavigationRecommendedTransitionDirection.Default;
					if (obj2 != null && obj == null)
					{
						UnselectPrevItem(obj2, obj);
					}
				}
			}
			UnselectPrevItem(prevItem, obj);
			ChangeSelectStatusForItem(obj, selected: true);
			RaiseSelectionChangedEvent(obj, flag, recommendedDirection);
			AnimateSelectionChanged(prevItem, obj);
			if (IsPaneOpen && DisplayMode != NavigationViewDisplayMode.Expanded)
			{
				ClosePane();
			}
		}
		finally
		{
			m_shouldIgnoreNextSelectionChange = false;
		}
	}

	private void OnItemClick(object sender, ItemClickEventArgs args)
	{
		object clickedItem = args.ClickedItem;
		NavigationViewItemBase containerForClickedItem = GetContainerForClickedItem(clickedItem);
		object selectedItem = SelectedItem;
		if (!m_shouldIgnoreNextSelectionChange && DoesSelectedItemContainContent(clickedItem, containerForClickedItem) && !IsSelectionSuppressed(selectedItem))
		{
			RaiseItemInvoked(selectedItem, isSettings: false, containerForClickedItem);
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
		if (forceSetDisplayMode || DisplayMode != displayMode)
		{
			UpdateVisualStateForDisplayModeGroup(displayMode);
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
		if (ShouldShowBackButton())
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
			SplitViewDisplayMode displayMode2 = SplitViewDisplayMode.CompactOverlay;
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
			bool flag = false;
			if (text == text2 && IsTopNavigationView())
			{
				flag = VisualStateManager.GoToState(this, "TopNavigationMinimal", useTransitions: false);
			}
			if (!flag)
			{
				VisualStateManager.GoToState(this, text, useTransitions: false);
			}
			rootSplitView.DisplayMode = displayMode2;
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs e)
	{
		VirtualKey key = e.Key;
		bool handled = false;
		switch (key)
		{
		case VirtualKey.GamepadView:
			if (!IsPaneOpen)
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
		if (!IsTopNavigationView() || !IsNavigationViewListSingleSelectionFollowsFocus() || flag)
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
				int num = m_topDataProvider.IndexOf(selectedItem, NavigationViewSplitVectorID.PrimaryList);
				if (num >= 0)
				{
					ListView topNavListView = m_topNavListView;
					ItemCollection items = topNavListView.Items;
					int primaryListSize = m_topDataProvider.GetPrimaryListSize();
					for (num += offset; num > -1 && num < primaryListSize; num += offset)
					{
						object obj = items[num];
						if (obj is NavigationViewItem navigationViewItem2 && navigationViewItem2.SelectsOnInvoked)
						{
							topNavListView.SelectedItem = obj;
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	private object MenuItemFromContainer(DependencyObject container)
	{
		if (container != null)
		{
			if (IsTopNavigationView())
			{
				object obj = null;
				ListView topNavListView = m_topNavListView;
				if (topNavListView != null)
				{
					obj = topNavListView.ItemFromContainer(container);
					if (obj != null)
					{
						return obj;
					}
				}
				ListView topNavListOverflowView = m_topNavListOverflowView;
				if (topNavListOverflowView != null)
				{
					obj = topNavListOverflowView.ItemFromContainer(container);
				}
				return obj;
			}
			ListView leftNavListView = m_leftNavListView;
			if (leftNavListView != null)
			{
				return leftNavListView.ItemFromContainer(container);
			}
		}
		return null;
	}

	private DependencyObject ContainerFromMenuItem(object item)
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
			try
			{
				m_shouldIgnoreOverflowItemSelectionChange = true;
				m_topDataProvider.MoveAllItemsToPrimaryList();
			}
			finally
			{
				m_shouldIgnoreOverflowItemSelectionChange = false;
			}
			SetTopNavigationViewNextMode(TopNavigationViewLayoutState.InitStep2);
			InvalidateTopNavPrimaryLayout();
		}
		m_indexOfLastSelectedItemInTopNav = 0;
		m_lastSelectedItemPendingAnimationInTopNav = null;
		m_itemsRemovedFromMenuFlyout.Clear();
	}

	private int GetNavigationViewItemCountInPrimaryList()
	{
		return m_topDataProvider.GetNavigationViewItemCountInPrimaryList();
	}

	private int GetNavigationViewItemCountInTopNav()
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
			if (ShouldIgnoreMeasureOverride())
			{
				RequestInvalidateMeasureOnNextLayoutUpdate();
			}
			else
			{
				InvalidateMeasure();
			}
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
			SlideNavigationTransitionEffect slideNavigationTransitionEffect2 = (slideNavigationTransitionInfo.Effect = ((recommendedTransitionDirection != NavigationRecommendedTransitionDirection.FromRight) ? SlideNavigationTransitionEffect.FromLeft : SlideNavigationTransitionEffect.FromRight));
			return slideNavigationTransitionInfo;
		}
		return new EntranceNavigationTransitionInfo();
	}

	private NavigationRecommendedTransitionDirection GetRecommendedTransitionDirection(DependencyObject prev, DependencyObject next)
	{
		NavigationRecommendedTransitionDirection result = NavigationRecommendedTransitionDirection.Default;
		ListView topNavListView = m_topNavListView;
		if (topNavListView != null)
		{
			int num = topNavListView.IndexFromContainer(prev);
			int num2 = topNavListView.IndexFromContainer(next);
			if (num == -1 || num2 == -1)
			{
				result = NavigationRecommendedTransitionDirection.Default;
			}
			else if (num < num2)
			{
				result = NavigationRecommendedTransitionDirection.FromRight;
			}
			else if (num > num2)
			{
				result = NavigationRecommendedTransitionDirection.FromLeft;
			}
		}
		return result;
	}

	private NavigationViewItemBase GetContainerForClickedItem(object itemData)
	{
		NavigationViewItemBase navigationViewItemBase = null;
		ListView listView = (IsTopNavigationView() ? m_topNavListView : m_leftNavListView);
		if (listView is NavigationViewList navigationViewList)
		{
			navigationViewItemBase = navigationViewList.GetLastItemCalledInIsItemItsOwnContainerOverride();
		}
		if (navigationViewItemBase == null && itemData != null)
		{
			navigationViewItemBase = listView.ContainerFromItem(itemData) as NavigationViewItemBase;
		}
		return navigationViewItemBase;
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

	private void OnSelectedItemPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		object newValue = args.NewValue;
		ChangeSelection(args.OldValue, newValue);
		if (m_appliedTemplate && IsTopNavigationView() && ((m_shouldInvalidateMeasureOnNextLayoutUpdate && m_layoutUpdatedToken == null) || (newValue != null && m_topDataProvider.IndexOf(newValue) != -1 && m_topDataProvider.IndexOf(newValue, NavigationViewSplitVectorID.PrimaryList) == -1)))
		{
			InvalidateTopNavPrimaryLayout();
		}
	}

	private void SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(object item)
	{
		bool shouldIgnoreNextSelectionChange = m_shouldIgnoreNextSelectionChange;
		if (!shouldIgnoreNextSelectionChange)
		{
			m_shouldRaiseInvokeItemInSelectionChange = true;
		}
		if (IsTopNavigationView())
		{
			bool flag = true;
			foreach (int item2 in m_itemsRemovedFromMenuFlyout)
			{
				if (item2 == m_indexOfLastSelectedItemInTopNav)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				m_lastSelectedItemPendingAnimationInTopNav = SelectedItem;
			}
			else
			{
				m_lastSelectedItemPendingAnimationInTopNav = null;
			}
			m_indexOfLastSelectedItemInTopNav = m_topDataProvider.IndexOf(item);
		}
		SelectedItem = item;
		if (!shouldIgnoreNextSelectionChange)
		{
			m_shouldRaiseInvokeItemInSelectionChange = false;
		}
	}

	private bool DoesSelectedItemContainContent(object item, NavigationViewItemBase itemContainer)
	{
		bool result = false;
		object selectedItem = SelectedItem;
		if (selectedItem != null && (item != null || itemContainer != null))
		{
			if (item != null && item == selectedItem)
			{
				result = true;
			}
			else if (selectedItem is NavigationViewItemBase navigationViewItemBase)
			{
				result = navigationViewItemBase == itemContainer;
			}
			else
			{
				NavigationViewItemBase navigationViewItemBase2 = NavigationViewItemBaseOrSettingsContentFromData(selectedItem);
				if (navigationViewItemBase2 != null && itemContainer != null)
				{
					result = navigationViewItemBase2 == itemContainer;
				}
			}
		}
		return result;
	}

	private void ChangeSelectStatusForItem(object item, bool selected)
	{
		NavigationViewItem navigationViewItem = NavigationViewItemOrSettingsContentFromData(item);
		if (navigationViewItem != null)
		{
			navigationViewItem.IsSelected = selected;
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
		if (prevItem != null && prevItem != nextItem && (IsSettingsItem(prevItem) || (nextItem != null && IsSettingsItem(nextItem)) || nextItem == null))
		{
			ChangeSelectStatusForItem(prevItem, selected: false);
		}
	}

	private void UndoSelectionAndRevertSelectionTo(object prevSelectedItem, object nextItem)
	{
		object selectedItem = null;
		if (prevSelectedItem != null)
		{
			if (IsSelectionSuppressed(prevSelectedItem))
			{
				AnimateSelectionChanged(prevSelectedItem, null);
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

	private void UpdateLocalVisualState(bool useTransitions = false)
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
		VisualStateManager.GoToState(this, isPaneToggleButtonVisible ? "TogglePaneButtonVisible" : "TogglePaneButtonCollapsed", useTransitions: false);
	}

	private void UpdateNavigationViewUseSystemVisual()
	{
		if (SharedHelpers.IsRS1OrHigher() && !ShouldPreserveNavigationViewRS4Behavior() && m_appliedTemplate)
		{
			bool showFocusVisual = SelectionFollowsFocus == NavigationViewSelectionFollowsFocus.Disabled;
			PropagateChangeToNavigationViewLists(NavigationViewPropagateTarget.LeftListView, delegate(NavigationViewList list)
			{
				list.SetShowFocusVisual(showFocusVisual);
			});
			PropagateChangeToNavigationViewLists(NavigationViewPropagateTarget.TopListView, delegate(NavigationViewList list)
			{
				list.SetShowFocusVisual(showFocusVisual);
			});
		}
	}

	private void SetNavigationViewListPosition(ListView listView, NavigationViewListPosition position)
	{
		if (listView != null && listView is NavigationViewList navigationViewList)
		{
			navigationViewList.SetNavigationViewListPosition(position);
		}
	}

	private void PropagateNavigationViewAsParent()
	{
		PropagateChangeToNavigationViewLists(NavigationViewPropagateTarget.All, delegate(NavigationViewList list)
		{
			list.SetNavigationViewParent(this);
		});
	}

	private void PropagateChangeToNavigationViewLists(NavigationViewPropagateTarget target, Action<NavigationViewList> function)
	{
		if (target == NavigationViewPropagateTarget.LeftListView || NavigationViewPropagateTarget.All == target)
		{
			PropagateChangeToNavigationViewList(m_leftNavListView, function);
		}
		if (NavigationViewPropagateTarget.TopListView == target || NavigationViewPropagateTarget.All == target)
		{
			PropagateChangeToNavigationViewList(m_topNavListView, function);
		}
		if (NavigationViewPropagateTarget.OverflowListView == target || NavigationViewPropagateTarget.All == target)
		{
			PropagateChangeToNavigationViewList(m_topNavListOverflowView, function);
		}
	}

	private void PropagateChangeToNavigationViewList(ListView listView, Action<NavigationViewList> function)
	{
		if (listView != null && listView is NavigationViewList navigationViewList)
		{
			NavigationViewList obj = navigationViewList;
			function(obj);
		}
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
		double num = 0.0;
		num += LayoutUtils.MeasureAndGetDesiredWidthFor(m_buttonHolderGrid, availableSize);
		return num + LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavGrid, availableSize);
	}

	private double MeasureTopNavMenuItemsHostDesiredWidth(Size availableSize)
	{
		return LayoutUtils.MeasureAndGetDesiredWidthFor(m_topNavListView, availableSize);
	}

	private double GetTopNavigationViewActualWidth()
	{
		double num = 0.0;
		num += LayoutUtils.GetActualWidthFor(m_buttonHolderGrid);
		return num + LayoutUtils.GetActualWidthFor(m_topNavGrid);
	}

	private bool IsTopNavigationFirstMeasure()
	{
		bool result = false;
		ListView topNavListView = m_topNavListView;
		if (topNavListView != null)
		{
			int primaryListSize = m_topDataProvider.GetPrimaryListSize();
			if (primaryListSize > 1)
			{
				DependencyObject dependencyObject = topNavListView.ContainerFromIndex(1);
				result = dependencyObject == null;
			}
		}
		return result;
	}

	private void RequestInvalidateMeasureOnNextLayoutUpdate()
	{
		m_shouldInvalidateMeasureOnNextLayoutUpdate = true;
	}

	private bool HasTopNavigationViewItemNotInPrimaryList()
	{
		return m_topDataProvider.GetPrimaryListSize() != m_topDataProvider.Size();
	}

	private void HandleTopNavigationMeasureOverride(Size availableSize)
	{
		switch (m_topNavigationMode)
		{
		case TopNavigationViewLayoutState.InitStep1:
			if (HasTopNavigationViewItemNotInPrimaryList())
			{
				m_topDataProvider.MoveAllItemsToPrimaryList();
			}
			else
			{
				ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState.InitStep2, availableSize);
			}
			break;
		case TopNavigationViewLayoutState.InitStep2:
			if (m_measureOnInitStep2Count >= s_measureOnInitStep2CountThreshold || !IsTopNavigationFirstMeasure())
			{
				m_measureOnInitStep2Count = 0;
				ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState.InitStep3, availableSize);
			}
			else
			{
				m_measureOnInitStep2Count++;
			}
			break;
		case TopNavigationViewLayoutState.InitStep3:
			HandleTopNavigationMeasureOverrideStep3(availableSize);
			break;
		case TopNavigationViewLayoutState.Normal:
			HandleTopNavigationMeasureOverrideNormal(availableSize);
			break;
		case TopNavigationViewLayoutState.Overflow:
			HandleTopNavigationMeasureOverrideOverflow(availableSize);
			break;
		case TopNavigationViewLayoutState.OverflowNoChange:
			SetTopNavigationViewNextMode(TopNavigationViewLayoutState.Overflow);
			break;
		}
	}

	private void HandleTopNavigationMeasureOverrideNormal(Size availableSize)
	{
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (num > availableSize.Width)
		{
			ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState.InitStep3, availableSize);
		}
	}

	private void HandleTopNavigationMeasureOverrideOverflow(Size availableSize)
	{
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (num > availableSize.Width)
		{
			ShrinkTopNavigationSize(num, availableSize);
		}
		else
		{
			if (!(num < availableSize.Width))
			{
				return;
			}
			double num2 = m_topDataProvider.WidthRequiredToRecoveryAllItemsToPrimary();
			if (availableSize.Width >= num + num2 + m_topNavigationRecoveryGracePeriodWidth)
			{
				ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState.InitStep1, availableSize);
				return;
			}
			m_topDataProvider.InvalidWidthCacheIfOverflowItemContentChanged();
			List<int> list = FindMovableItemsRecoverToPrimaryList(availableSize.Width - num, new List<int>());
			m_topDataProvider.MoveItemsToPrimaryList(list);
			if (m_topDataProvider.HasInvalidWidth(list))
			{
				m_topDataProvider.ResetAttachedData();
				RequestInvalidateMeasureOnNextLayoutUpdate();
			}
		}
	}

	private void ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState nextMode, Size availableSize)
	{
		SetTopNavigationViewNextMode(nextMode);
		HandleTopNavigationMeasureOverride(availableSize);
	}

	private void HandleTopNavigationMeasureOverrideStep3(Size availableSize)
	{
		SetOverflowButtonVisibility(Visibility.Collapsed);
		double num = MeasureTopNavigationViewDesiredWidth(c_infSize);
		if (num < availableSize.Width)
		{
			ContinueHandleTopNavigationMeasureOverride(TopNavigationViewLayoutState.Normal, availableSize);
			return;
		}
		SetOverflowButtonVisibility(Visibility.Visible);
		double num2 = MeasureTopNavigationViewDesiredWidth(c_infSize);
		m_topDataProvider.OverflowButtonWidth(num2 - num);
		ShrinkTopNavigationSize(num2, availableSize);
	}

	private void SetOverflowButtonVisibility(Visibility visibility)
	{
		if (visibility != TemplateSettings.OverflowButtonVisibility)
		{
			GetTemplateSettings().OverflowButtonVisibility = visibility;
		}
	}

	private void SetTopNavigationViewNextMode(TopNavigationViewLayoutState nextMode)
	{
		m_topNavigationMode = nextMode;
	}

	private void SelectOverflowItem(object item)
	{
		int num = m_topDataProvider.IndexOf(item);
		double widthForItem = m_topDataProvider.GetWidthForItem(num);
		bool flag = !m_topDataProvider.IsValidWidthForItem(num);
		if (!flag)
		{
			double topNavigationViewActualWidth = GetTopNavigationViewActualWidth();
			double num2 = MeasureTopNavigationViewDesiredWidth(c_infSize);
			int num3 = -1;
			double num4 = 0.0;
			object selectedItem = SelectedItem;
			if (selectedItem != null)
			{
				num3 = m_topDataProvider.IndexOf(selectedItem);
				if (num3 != -1)
				{
					num4 = m_topDataProvider.GetWidthForItem(num3);
				}
			}
			double num5 = num2 + widthForItem - topNavigationViewActualWidth;
			List<int> list = (m_itemsRemovedFromMenuFlyout = FindMovableItemsToBeRemovedFromPrimaryList(num5, null));
			double num6 = m_topDataProvider.CalculateWidthForItems(list);
			double availableWidth = num6 - num5;
			List<int> list2 = FindMovableItemsRecoverToPrimaryList(availableWidth, new List<int> { num });
			if (!list2.Contains(num))
			{
				list2.Add(num);
			}
			if (m_topDataProvider.HasInvalidWidth(list2))
			{
				flag = true;
			}
			else
			{
				try
				{
					m_shouldIgnoreNextSelectionChange = true;
					m_topDataProvider.MoveItemsToPrimaryList(list2);
					m_topDataProvider.MoveItemsOutOfPrimaryList(list);
				}
				finally
				{
					m_shouldIgnoreNextSelectionChange = false;
				}
				SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
				SetTopNavigationViewNextMode(TopNavigationViewLayoutState.OverflowNoChange);
				InvalidateMeasure();
			}
		}
		if (flag || m_shouldInvalidateMeasureOnNextLayoutUpdate)
		{
			m_topDataProvider.MoveAllItemsToPrimaryList();
			SetTopNavigationViewNextMode(TopNavigationViewLayoutState.InitStep2);
			SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(item);
			InvalidateTopNavPrimaryLayout();
		}
	}

	private void ShrinkTopNavigationSize(double desiredWidth, Size availableSize)
	{
		UpdateTopNavigationWidthCache();
		SetTopNavigationViewNextMode(TopNavigationViewLayoutState.Overflow);
		int selectedItemIndex = GetSelectedItemIndex();
		double num = MeasureTopNavMenuItemsHostDesiredWidth(c_infSize) - (desiredWidth - availableSize.Width);
		if (num >= 0.0)
		{
			List<int> list = FindMovableItemsBeyondAvailableWidth(num);
			KeepAtLeastOneItemInPrimaryList(list, shouldKeepFirst: true);
			m_topDataProvider.MoveItemsOutOfPrimaryList(list);
		}
		desiredWidth = MeasureTopNavigationViewDesiredWidth(c_infSize);
		double num2 = desiredWidth - availableSize.Width;
		if (num2 > 0.0)
		{
			List<int> list2 = FindMovableItemsToBeRemovedFromPrimaryList(num2, new List<int> { selectedItemIndex });
			KeepAtLeastOneItemInPrimaryList(list2, shouldKeepFirst: false);
			m_topDataProvider.MoveItemsOutOfPrimaryList(list2);
		}
	}

	private List<int> FindMovableItemsRecoverToPrimaryList(double availableWidth, List<int> includeItems)
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
		if (i == num && !list.Empty())
		{
			list.RemoveAt(list.Count - 1);
		}
		return list;
	}

	private List<int> FindMovableItemsToBeRemovedFromPrimaryList(double widthAtLeastToBeRemoved, List<int> excludeItems)
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

	private List<int> FindMovableItemsBeyondAvailableWidth(double availableWidth)
	{
		List<int> list = new List<int>();
		ListView topNavListView = m_topNavListView;
		if (topNavListView != null)
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
					DependencyObject dependencyObject = topNavListView.ContainerFromIndex(i);
					if (dependencyObject != null && dependencyObject is UIElement uIElement)
					{
						double width = uIElement.DesiredSize.Width;
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

	private void KeepAtLeastOneItemInPrimaryList(List<int> itemInPrimaryToBeRemoved, bool shouldKeepFirst)
	{
		if (!itemInPrimaryToBeRemoved.Empty() && itemInPrimaryToBeRemoved.Count == m_topDataProvider.GetPrimaryListSize())
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

	private void UpdateTopNavigationWidthCache()
	{
		int primaryListSize = m_topDataProvider.GetPrimaryListSize();
		ListView topNavListView = m_topNavListView;
		if (topNavListView == null)
		{
			return;
		}
		for (int i = 0; i < primaryListSize; i++)
		{
			DependencyObject dependencyObject = topNavListView.ContainerFromIndex(i);
			if (dependencyObject != null)
			{
				if (dependencyObject is UIElement uIElement)
				{
					double width = uIElement.DesiredSize.Width;
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
		if (m_topNavListView != null)
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
			UpdatePaneToggleSize();
		}
		else if (property == IsBackButtonVisibleProperty)
		{
			UpdateBackButtonVisibility();
			UpdateAdaptiveLayout(base.ActualWidth);
			if (IsTopNavigationView())
			{
				InvalidateTopNavPrimaryLayout();
			}
		}
		else if (property == MenuItemsSourceProperty)
		{
			UpdateListViewItemSource();
		}
		else if (property == MenuItemsProperty)
		{
			UpdateListViewItemSource();
		}
		else if (property == PaneDisplayModeProperty)
		{
			m_wasForceClosed = false;
			UpdatePaneDisplayMode((NavigationViewPaneDisplayMode)args.OldValue, (NavigationViewPaneDisplayMode)args.NewValue);
			UpdatePaneToggleButtonVisibility();
			UpdatePaneVisibility();
			UpdateLocalVisualState();
		}
		else if (property == IsPaneVisibleProperty)
		{
			UpdatePaneVisibility();
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
		}
		else if (property == SelectionFollowsFocusProperty)
		{
			UpdateSingleSelectionFollowsFocusTemplateSetting();
			UpdateNavigationViewUseSystemVisual();
		}
		else if (property == IsPaneToggleButtonVisibleProperty)
		{
			UpdatePaneToggleButtonVisibility();
			UpdateLocalVisualState();
		}
		else if (property == IsSettingsVisibleProperty)
		{
			UpdateLocalVisualState();
		}
	}

	private void OnPropertyChanged_CoerceToGreaterThanZero(DependencyPropertyChangedEventArgs args)
	{
		object newValue = args.NewValue;
		if (newValue is double)
		{
			double num = (double)newValue;
			double value = num;
			CoerceToGreaterThanZero(ref value);
			SetValue(args.Property, value);
			OnPropertyChanged(args);
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		object selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			if (!IsSelectionSuppressed(selectedItem) && !SharedHelpers.IsRS3OrHigher() && selectedItem is NavigationViewItem navigationViewItem)
			{
				navigationViewItem.IsSelected = true;
			}
			AnimateSelectionChanged(null, selectedItem);
		}
	}

	private void OnUnloaded(object sender, RoutedEventArgs args)
	{
		UnhookEventsAndClearFields();
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
			if (rootSplitView != null && rootSplitView.IsPaneOpen)
			{
				m_wasForceClosed = true;
			}
		}
		SetPaneToggleButtonAutomationName();
		UpdateBackButtonVisibility();
		UpdatePaneTabFocusNavigation();
		UpdateSettingsItemToolTip();
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
			CreateAndHookEventsToSettings(c_settingsName);
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
			CreateAndHookEventsToSettings(c_settingsNameTopNav);
			Button topNavOverflowButton = m_topNavOverflowButton;
			if (topNavOverflowButton != null)
			{
				base.KeyTipTarget = topNavOverflowButton;
			}
		}
		UpdateContentBindingsForPaneDisplayMode();
		UpdateListViewItemSource();
	}

	private void UpdatePaneDisplayMode(NavigationViewPaneDisplayMode oldDisplayMode, NavigationViewPaneDisplayMode newDisplayMode)
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		UpdatePaneDisplayMode();
		if (!IsTopNavigationView())
		{
			bool isPaneOpen = IsPaneOpen;
			if (newDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal && isPaneOpen)
			{
				ClosePane();
			}
			else if (oldDisplayMode == NavigationViewPaneDisplayMode.LeftMinimal && !isPaneOpen && newDisplayMode != 0)
			{
				OpenPane();
			}
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
		}
		else
		{
			templateSettings.TopPaneVisibility = Visibility.Collapsed;
			templateSettings.LeftPaneVisibility = Visibility.Collapsed;
		}
	}

	private void SwapPaneHeaderContent(ContentControl newParentTrackRef, ContentControl oldParentTrackRef, string propertyPathName)
	{
		if (newParentTrackRef != null)
		{
			oldParentTrackRef?.ClearValue(ContentControl.ContentProperty);
			Binding binding = new Binding();
			PropertyPath propertyPath2 = (binding.Path = new PropertyPath(propertyPathName));
			binding.Source = this;
			BindingOperations.SetBinding(newParentTrackRef, ContentControl.ContentProperty, binding);
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
			Binding binding = new Binding();
			PropertyPath propertyPath2 = (binding.Path = new PropertyPath("AutoSuggestBox"));
			binding.Source = this;
			BindingOperations.SetBinding(uIElement, ContentControl.ContentProperty, binding);
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
		bool flag = AlwaysShowHeader || displayMode == NavigationViewDisplayMode.Minimal;
		if (!ShouldPreserveNavigationViewRS4Behavior())
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
		double num = ResourceResolver.ResolveTopLevelResourceDouble("PaneToggleButtonWidth", c_paneToggleButtonWidth);
		double width = num;
		if (ShouldShowBackButton() && rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
		{
			double num2 = c_backButtonWidth;
			Button backButton = m_backButton;
			if (backButton != null)
			{
				num2 = backButton.Width;
			}
			num += num2;
		}
		if (!m_isClosedCompact)
		{
			string paneTitle = PaneTitle;
			if (paneTitle != null && paneTitle.Length > 0)
			{
				bool flag = (m_isOpenPaneForInteraction ? IsPaneOpen : rootSplitView.IsPaneOpen);
				if (rootSplitView.DisplayMode == SplitViewDisplayMode.Overlay && flag)
				{
					num = OpenPaneLength;
					width = OpenPaneLength - (double)(ShouldShowBackButton() ? c_backButtonWidth : 0);
				}
				else if (rootSplitView.DisplayMode != 0 || flag)
				{
					num = OpenPaneLength;
					width = OpenPaneLength;
				}
			}
		}
		Grid buttonHolderGrid = m_buttonHolderGrid;
		if (buttonHolderGrid != null)
		{
			buttonHolderGrid.Width = num;
		}
		Button paneToggleButton = m_paneToggleButton;
		if (paneToggleButton != null)
		{
			paneToggleButton.Width = width;
		}
	}

	private void UpdateBackButtonVisibility()
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		bool flag = ShouldShowBackButton();
		Visibility visibility = Util.VisibilityFromBool(flag);
		GetTemplateSettings().BackButtonVisibility = visibility;
		Button backButton = m_backButton;
		if (backButton != null && ShouldPreserveNavigationViewRS4Behavior())
		{
			backButton.Visibility = visibility;
		}
		UIElement paneContentGrid = m_paneContentGrid;
		if (paneContentGrid != null && paneContentGrid is Grid grid)
		{
			RowDefinitionCollection rowDefinitions = grid.RowDefinitions;
			RowDefinition rowDefinition = rowDefinitions[c_backButtonRowDefinition];
			int num = 0;
			if (!IsOverlay() && ShouldShowBackButton())
			{
				num = c_backButtonHeight;
			}
			else if (ShouldPreserveNavigationViewRS3Behavior())
			{
				num = c_toggleButtonHeightWhenShouldPreserveNavigationViewRS3Behavior;
			}
			GridLength gridLength2 = (rowDefinition.Height = GridLengthHelper.FromPixels(num));
		}
		if (!ShouldPreserveNavigationViewRS4Behavior())
		{
			VisualStateManager.GoToState(this, flag ? "BackButtonVisible" : "BackButtonCollapsed", useTransitions: false);
		}
		UpdateTitleBarPadding();
	}

	private void UpdatePaneTitleMargins()
	{
		TextBlock paneTitleTextBlock = m_paneTitleTextBlock;
		if (paneTitleTextBlock != null)
		{
			double num = 0.0;
			double num2 = ResourceResolver.ResolveTopLevelResourceDouble("PaneToggleButtonWidth", c_paneToggleButtonWidth);
			num += num2;
			if (ShouldShowBackButton() && IsOverlay())
			{
				num += (double)c_backButtonWidth;
			}
			paneTitleTextBlock.Margin = new Thickness(num, 0.0, 0.0, 0.0);
		}
	}

	private void UpdateLeftNavListViewItemSource(object items)
	{
		UpdateListViewItemsSource(m_leftNavListView, items);
	}

	private void UpdateTopNavListViewItemSource(IEnumerable items)
	{
		if (m_topDataProvider.ShouldChangeDataSource(items))
		{
			UpdateListViewItemsSource(m_topNavListView, null);
			UpdateListViewItemsSource(m_topNavListOverflowView, null);
			m_topDataProvider.SetDataSource(items);
			if (items != null)
			{
				UpdateListViewItemsSource(m_topNavListView, m_topDataProvider.GetPrimaryItems());
				UpdateListViewItemsSource(m_topNavListOverflowView, m_topDataProvider.GetOverflowItems());
			}
			else
			{
				UpdateListViewItemsSource(m_topNavListView, null);
				UpdateListViewItemsSource(m_topNavListOverflowView, null);
			}
		}
	}

	private void UpdateListViewItemSource()
	{
		if (m_appliedTemplate)
		{
			object obj = MenuItemsSource;
			if (obj == null)
			{
				obj = MenuItems;
			}
			if (IsTopNavigationView())
			{
				UpdateLeftNavListViewItemSource(null);
				UpdateTopNavListViewItemSource(obj as IEnumerable);
			}
			else
			{
				UpdateTopNavListViewItemSource(null);
				UpdateLeftNavListViewItemSource(obj as IEnumerable);
			}
			if (IsTopNavigationView())
			{
				InvalidateTopNavPrimaryLayout();
				UpdateSelectedItem();
			}
		}
	}

	private void UpdateListViewItemsSource(ListView listView, object itemsSource)
	{
		if (listView != null)
		{
			object itemsSource2 = listView.ItemsSource;
			if (itemsSource2 != itemsSource)
			{
				listView.ItemsSource = itemsSource;
			}
		}
	}

	private void OnTitleBarMetricsChanged(object sender, object args)
	{
		UpdateTitleBarPadding();
	}

	private void OnTitleBarIsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
	{
		UpdateTitleBarPadding();
	}

	private bool ShouldIgnoreMeasureOverride()
	{
		if (!m_shouldIgnoreNextMeasureOverride && !m_shouldIgnoreOverflowItemSelectionChange)
		{
			return m_shouldIgnoreNextSelectionChange;
		}
		return true;
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
			if (ShouldPreserveNavigationViewRS3Behavior() || ((!ShouldPreserveNavigationViewRS4Behavior()) ? NeedTopPaddingForRS5OrHigher(coreTitleBar) : (!coreTitleBar.ExtendViewIntoTitleBar)))
			{
				num = coreTitleBar.Height;
				UIElement content = Window.Current.Content;
				GeneralTransform generalTransform = TransformToVisual(content);
				if (generalTransform.TransformPoint(new Point(0.0, 0.0)).Y != 0.0)
				{
					num = 0.0;
				}
				NavigationViewBackButtonVisible isBackButtonVisible = IsBackButtonVisible;
				if (ShouldPreserveNavigationViewRS4Behavior())
				{
					FrameworkElement togglePaneTopPadding = m_togglePaneTopPadding;
					if (togglePaneTopPadding != null)
					{
						togglePaneTopPadding.Height = num;
					}
					FrameworkElement contentPaneTopPadding = m_contentPaneTopPadding;
					if (contentPaneTopPadding != null)
					{
						contentPaneTopPadding.Height = num;
					}
				}
			}
			Button paneToggleButton = m_paneToggleButton;
			if (paneToggleButton != null)
			{
				Thickness margin = ThicknessHelper.FromLengths(0.0, 0.0, 0.0, 0.0);
				if (ShouldShowBackButton())
				{
					margin = ((!IsOverlay()) ? ThicknessHelper.FromLengths(0.0, c_backButtonHeight, 0.0, 0.0) : ThicknessHelper.FromLengths(c_backButtonWidth, 0.0, 0.0, 0.0));
				}
				paneToggleButton.Margin = margin;
			}
		}
		NavigationViewTemplateSettings templateSettings = TemplateSettings;
		if (templateSettings != null && Math.Abs(templateSettings.TopPadding - num) > 0.1)
		{
			GetTemplateSettings().TopPadding = num;
		}
	}

	private void UpdateSelectedItem()
	{
		object selectedItem = SelectedItem;
		NavigationViewItem settingsItem = m_settingsItem;
		if (settingsItem != null && selectedItem == settingsItem)
		{
			OnSettingsInvoked();
			return;
		}
		ListView listView = m_leftNavListView;
		if (IsTopNavigationView())
		{
			listView = m_topNavListView;
		}
		if (listView != null)
		{
			listView.SelectedItem = selectedItem;
		}
	}

	private void RaiseDisplayModeChanged(NavigationViewDisplayMode displayMode)
	{
		SetValue(DisplayModeProperty, displayMode);
		NavigationViewDisplayModeChangedEventArgs navigationViewDisplayModeChangedEventArgs = new NavigationViewDisplayModeChangedEventArgs();
		navigationViewDisplayModeChangedEventArgs.DisplayMode = displayMode;
		this.DisplayModeChanged?.Invoke(this, navigationViewDisplayModeChangedEventArgs);
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
		ListView listView = (IsTopNavigationView() ? m_topNavListView : m_leftNavListView);
		if (listView != null)
		{
			DependencyObject dependencyObject = listView.ContainerFromItem(data);
			if (dependencyObject != null)
			{
				return dependencyObject as T;
			}
		}
		NavigationViewItem settingsItem = m_settingsItem;
		if (settingsItem != null && (settingsItem == data || settingsItem.Content == data))
		{
			return settingsItem as T;
		}
		return null;
	}
}
