using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls.Primitives;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItem : NavigationViewItemBase
{
	private enum PointerStateValue
	{
		Normal,
		PointerOver,
		Pressed
	}

	private enum ChevronStateValue
	{
		ChevronHidden,
		ChevronVisibleOpen,
		ChevronVisibleClosed
	}

	private const string c_navigationViewItemPresenterName = "NavigationViewItemPresenter";

	private const string c_repeater = "NavigationViewItemMenuItemsHost";

	private const string c_rootGrid = "NVIRootGrid";

	private const string c_flyoutContentGrid = "FlyoutContentGrid";

	private const string c_pressedSelected = "PressedSelected";

	private const string c_pointerOverSelected = "PointerOverSelected";

	private const string c_selected = "Selected";

	private const string c_pressed = "Pressed";

	private const string c_pointerOver = "PointerOver";

	private const string c_disabled = "Disabled";

	private const string c_enabled = "Enabled";

	private const string c_normal = "Normal";

	private const string c_chevronHidden = "ChevronHidden";

	private const string c_chevronVisibleOpen = "ChevronVisibleOpen";

	private const string c_chevronVisibleClosed = "ChevronVisibleClosed";

	private const string c_normalChevronHidden = "NormalChevronHidden";

	private const string c_normalChevronVisibleOpen = "NormalChevronVisibleOpen";

	private const string c_normalChevronVisibleClosed = "NormalChevronVisibleClosed";

	private const string c_pointerOverChevronHidden = "PointerOverChevronHidden";

	private const string c_pointerOverChevronVisibleOpen = "PointerOverChevronVisibleOpen";

	private const string c_pointerOverChevronVisibleClosed = "PointerOverChevronVisibleClosed";

	private const string c_pressedChevronHidden = "PressedChevronHidden";

	private const string c_pressedChevronVisibleOpen = "PressedChevronVisibleOpen";

	private const string c_pressedChevronVisibleClosed = "PressedChevronVisibleClosed";

	private readonly SerialDisposable m_splitViewIsPaneOpenChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewDisplayModeChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_splitViewCompactPaneLengthChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerPressedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerEnteredRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerMovedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerReleasedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerExitedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerCanceledRevoker = new SerialDisposable();

	private readonly SerialDisposable m_presenterPointerCaptureLostRevoker = new SerialDisposable();

	private readonly SerialDisposable m_repeaterElementPreparedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_repeaterElementClearingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_itemsSourceViewCollectionChangedRevoker = new SerialDisposable();

	private readonly SerialDisposable m_flyoutClosingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_isEnabledChangedRevoker = new SerialDisposable();

	private ToolTip m_toolTip;

	private NavigationViewItemHelper<NavigationViewItem> backing_m_helper;

	private Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter m_navigationViewItemPresenter;

	private object m_suggestedToolTipContent;

	private ItemsRepeater m_repeater;

	private Grid m_flyoutContentGrid;

	private Grid m_rootGrid;

	private bool m_isClosedCompact;

	private bool m_appliedTemplate;

	private bool m_hasKeyboardFocus;

	private Pointer m_capturedPointer;

	private uint m_trackedPointerId;

	private bool m_isPressed;

	private bool m_isPointerOver;

	private bool m_isRepeaterParentedToFlyout;

	private bool _uno_isDefferingOverState;

	private bool _uno_isDefferingPressedState;

	private DispatcherQueueTimer _uno_pointerDeferring;

	internal SerialDisposable EventRevoker { get; } = new SerialDisposable();


	private NavigationViewItemHelper<NavigationViewItem> m_helper => backing_m_helper ?? (backing_m_helper = new NavigationViewItemHelper<NavigationViewItem>(this));

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

	public static DependencyProperty CompactPaneLengthProperty { get; } = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(NavigationViewItem), new FrameworkPropertyMetadata(48.0));


	public bool HasUnrealizedChildren
	{
		get
		{
			return (bool)GetValue(HasUnrealizedChildrenProperty);
		}
		set
		{
			SetValue(HasUnrealizedChildrenProperty, value);
		}
	}

	public static DependencyProperty HasUnrealizedChildrenProperty { get; } = DependencyProperty.Register("HasUnrealizedChildren", typeof(bool), typeof(NavigationViewItem), new FrameworkPropertyMetadata(false, OnHasUnrealizedChildrenPropertyChanged));


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

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(NavigationViewItem), new FrameworkPropertyMetadata(null, OnIconPropertyChanged));


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

	public static DependencyProperty InfoBadgeProperty { get; } = DependencyProperty.Register("InfoBadge", typeof(InfoBadge), typeof(NavigationViewItem), new FrameworkPropertyMetadata(null, OnInfoBadgePropertyChanged));


	public bool IsChildSelected
	{
		get
		{
			return (bool)GetValue(IsChildSelectedProperty);
		}
		set
		{
			SetValue(IsChildSelectedProperty, value);
		}
	}

	public static DependencyProperty IsChildSelectedProperty { get; } = DependencyProperty.Register("IsChildSelected", typeof(bool), typeof(NavigationViewItem), new FrameworkPropertyMetadata(false));


	public bool IsExpanded
	{
		get
		{
			return (bool)GetValue(IsExpandedProperty);
		}
		set
		{
			SetValue(IsExpandedProperty, value);
		}
	}

	public static DependencyProperty IsExpandedProperty { get; } = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(NavigationViewItem), new FrameworkPropertyMetadata(false, OnIsExpandedPropertyChanged));


	public IList<object> MenuItems
	{
		get
		{
			return (IList<object>)GetValue(MenuItemsProperty);
		}
		set
		{
			SetValue(MenuItemsProperty, value);
		}
	}

	public static DependencyProperty MenuItemsProperty { get; } = DependencyProperty.Register("MenuItems", typeof(IList<object>), typeof(NavigationViewItem), new FrameworkPropertyMetadata(null, OnMenuItemsPropertyChanged));


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

	public static DependencyProperty MenuItemsSourceProperty { get; } = DependencyProperty.Register("MenuItemsSource", typeof(object), typeof(NavigationViewItem), new FrameworkPropertyMetadata(null, OnMenuItemsSourcePropertyChanged));


	public bool SelectsOnInvoked
	{
		get
		{
			return (bool)GetValue(SelectsOnInvokedProperty);
		}
		set
		{
			SetValue(SelectsOnInvokedProperty, value);
		}
	}

	public static DependencyProperty SelectsOnInvokedProperty { get; } = DependencyProperty.Register("SelectsOnInvoked", typeof(bool), typeof(NavigationViewItem), new FrameworkPropertyMetadata(true));


	public NavigationViewItem()
	{
		base.DefaultStyleKey = typeof(NavigationViewItem);
		SetValue(MenuItemsProperty, new List<object>());
	}

	internal void UpdateVisualStateNoTransition()
	{
		UpdateVisualState(useTransitions: false);
	}

	protected override void OnNavigationViewItemBaseDepthChanged()
	{
		UpdateItemIndentation();
		PropagateDepthToChildren(base.Depth + 1);
	}

	protected override void OnNavigationViewItemBaseIsSelectedChanged()
	{
		UpdateVisualStateForPointer();
	}

	protected override void OnNavigationViewItemBasePositionChanged()
	{
		UpdateVisualStateNoTransition();
		ReparentRepeater();
	}

	protected override void OnApplyTemplate()
	{
		if (GetNavigationView() == null)
		{
			return;
		}
		m_appliedTemplate = false;
		UnhookEventsAndClearFields();
		base.OnApplyTemplate();
		m_helper.Init(this);
		if (GetTemplateChild("NVIRootGrid") is Grid grid)
		{
			m_rootGrid = grid;
			FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(grid);
			if (flyoutBase != null)
			{
				flyoutBase.Closing += OnFlyoutClosing;
				m_flyoutClosingRevoker.Disposable = Disposable.Create(delegate
				{
					flyoutBase.Closing -= OnFlyoutClosing;
				});
			}
		}
		HookInputEvents();
		base.IsEnabledChanged += OnIsEnabledChanged;
		m_isEnabledChangedRevoker.Disposable = Disposable.Create(delegate
		{
			base.IsEnabledChanged -= OnIsEnabledChanged;
		});
		m_toolTip = (ToolTip)GetTemplateChild("ToolTip");
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			PrepNavigationViewItem(splitView);
		}
		else
		{
			base.Loaded -= OnLoaded;
			base.Loaded += OnLoaded;
		}
		NavigationView nvImpl = GetNavigationView();
		if (nvImpl != null)
		{
			ItemsRepeater repeater = GetTemplateChild("NavigationViewItemMenuItemsHost") as ItemsRepeater;
			if (repeater != null)
			{
				m_repeater = repeater;
				repeater.ElementPrepared += nvImpl.OnRepeaterElementPrepared;
				m_repeaterElementPreparedRevoker.Disposable = Disposable.Create(delegate
				{
					repeater.ElementPrepared -= nvImpl.OnRepeaterElementPrepared;
				});
				repeater.ElementClearing += nvImpl.OnRepeaterElementClearing;
				m_repeaterElementClearingRevoker.Disposable = Disposable.Create(delegate
				{
					repeater.ElementClearing -= nvImpl.OnRepeaterElementClearing;
				});
				repeater.ItemTemplate = nvImpl.GetNavigationViewItemsFactory();
			}
			UpdateRepeaterItemsSource();
		}
		m_flyoutContentGrid = (Grid)GetTemplateChild("FlyoutContentGrid");
		m_appliedTemplate = true;
		UpdateItemIndentation();
		UpdateVisualStateNoTransition();
		ReparentRepeater();
		if (!ShouldRepeaterShowInFlyout())
		{
			ShowHideChildren();
		}
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(this);
		NavigationView.CreateAndAttachHeaderAnimation(elementVisual);
		_fullyInitialized = true;
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			PrepNavigationViewItem(splitView);
		}
	}

	private void UpdateRepeaterItemsSource()
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			object itemsSource = GetItemsSource();
			m_itemsSourceViewCollectionChangedRevoker.Disposable = null;
			repeater.ItemsSource = itemsSource;
			repeater.ItemsSourceView.CollectionChanged += OnItemsSourceViewChanged;
			m_itemsSourceViewCollectionChangedRevoker.Disposable = Disposable.Create(delegate
			{
				repeater.ItemsSourceView.CollectionChanged -= OnItemsSourceViewChanged;
			});
		}
		object GetItemsSource()
		{
			object menuItemsSource = MenuItemsSource;
			if (menuItemsSource != null)
			{
				return menuItemsSource;
			}
			return MenuItems;
		}
	}

	private void OnItemsSourceViewChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		UpdateVisualStateForChevron();
	}

	internal UIElement GetSelectionIndicator()
	{
		UIElement selectionIndicator = m_helper.GetSelectionIndicator();
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter presenter = GetPresenter();
		if (presenter != null)
		{
			selectionIndicator = presenter.GetSelectionIndicator();
		}
		return selectionIndicator;
	}

	private void OnSplitViewPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		if (args == SplitView.CompactPaneLengthProperty)
		{
			UpdateCompactPaneLength();
		}
		else if (args == SplitView.IsPaneOpenProperty || args == SplitView.DisplayModeProperty)
		{
			UpdateIsClosedCompact();
			ReparentRepeater();
		}
	}

	private void UpdateCompactPaneLength()
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			SetValue(CompactPaneLengthProperty, splitView.CompactPaneLength);
			GetPresenter()?.UpdateCompactPaneLength(splitView.CompactPaneLength, IsOnLeftNav());
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

	private void UpdateNavigationViewItemToolTip()
	{
		object toolTip = ToolTipService.GetToolTip(this);
		if (toolTip != null && toolTip != m_suggestedToolTipContent)
		{
			return;
		}
		if (ShouldEnableToolTip())
		{
			if (toolTip != m_suggestedToolTipContent)
			{
				ToolTipService.SetToolTip(this, m_suggestedToolTipContent);
			}
		}
		else
		{
			ToolTipService.SetToolTip(this, null);
		}
	}

	private void SuggestedToolTipChanged(object newContent)
	{
		bool flag = newContent != null && newContent is string value && !string.IsNullOrEmpty(value);
		object suggestedToolTipContent = null;
		if (flag)
		{
			suggestedToolTipContent = newContent;
		}
		object toolTip = ToolTipService.GetToolTip(this);
		object suggestedToolTipContent2 = m_suggestedToolTipContent;
		if (suggestedToolTipContent2 != null && suggestedToolTipContent2 == toolTip)
		{
			ToolTipService.SetToolTip(this, null);
		}
		m_suggestedToolTipContent = suggestedToolTipContent;
	}

	private void OnIsExpandedPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		AutomationPeer automationPeer = FrameworkElementAutomationPeer.FromElement(this);
		if (automationPeer != null)
		{
			Microsoft.UI.Xaml.Automation.Peers.NavigationViewItemAutomationPeer navigationViewItemAutomationPeer = (Microsoft.UI.Xaml.Automation.Peers.NavigationViewItemAutomationPeer)automationPeer;
			navigationViewItemAutomationPeer.RaiseExpandCollapseAutomationEvent(IsExpanded ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
		}
		UpdateVisualState(useTransitions: true);
	}

	private void OnIconPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualStateNoTransition();
	}

	private void OnInfoBadgePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualStateForInfoBadge();
	}

	private void OnMenuItemsPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateRepeaterItemsSource();
		UpdateVisualStateForChevron();
	}

	private void OnMenuItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateRepeaterItemsSource();
		UpdateVisualStateForChevron();
	}

	private void OnHasUnrealizedChildrenPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateVisualStateForChevron();
	}

	private void ShowSelectionIndicator(bool visible)
	{
		UIElement selectionIndicator = GetSelectionIndicator();
		if (selectionIndicator != null)
		{
			selectionIndicator.Opacity = (visible ? 1.0 : 0.0);
		}
	}

	private void UpdateVisualStateForIconAndContent(bool showIcon, bool showContent)
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			string stateName = ((!showIcon) ? "ContentOnly" : (showContent ? "IconOnLeft" : "IconOnly"));
			VisualStateManager.GoToState(navigationViewItemPresenter, stateName, useTransitions: false);
		}
	}

	private void UpdateVisualStateForInfoBadge()
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			string stateName = (ShouldShowInfoBadge() ? "InfoBadgeVisible" : "InfoBadgeCollapsed");
			VisualStateManager.GoToState(navigationViewItemPresenter, stateName, useTransitions: false);
		}
	}

	private void UpdateVisualStateForClosedCompact()
	{
		GetPresenter()?.UpdateClosedCompactVisualState(base.IsTopLevelItem, m_isClosedCompact);
	}

	private void UpdateVisualStateForNavigationViewPositionChange()
	{
		NavigationViewRepeaterPosition position = base.Position;
		string stateName = "OnLeftNavigation";
		bool flag = false;
		switch (position)
		{
		case NavigationViewRepeaterPosition.LeftNav:
		case NavigationViewRepeaterPosition.LeftFooter:
			if (SharedHelpers.IsRS4OrHigher() && Application.Current.FocusVisualKind == FocusVisualKind.Reveal && VisualStateManager.GoToState(this, "OnLeftNavigationReveal", useTransitions: false))
			{
				flag = true;
			}
			break;
		case NavigationViewRepeaterPosition.TopPrimary:
		case NavigationViewRepeaterPosition.TopFooter:
			stateName = "OnTopNavigationPrimary";
			if (SharedHelpers.IsRS4OrHigher() && Application.Current.FocusVisualKind == FocusVisualKind.Reveal && VisualStateManager.GoToState(this, "OnTopNavigationPrimaryReveal", useTransitions: false))
			{
				flag = true;
			}
			break;
		case NavigationViewRepeaterPosition.TopOverflow:
			stateName = "OnTopNavigationOverflow";
			break;
		}
		if (!flag)
		{
			VisualStateManager.GoToState(this, stateName, useTransitions: false);
		}
	}

	private void UpdateVisualStateForKeyboardFocusedState()
	{
		string stateName = "KeyboardNormal";
		if (m_hasKeyboardFocus)
		{
			stateName = "KeyboardFocused";
		}
		VisualStateManager.GoToState(this, stateName, useTransitions: false);
	}

	private void UpdateVisualStateForToolTip()
	{
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			bool flag = ShouldEnableToolTip();
			object suggestedToolTipContent = m_suggestedToolTipContent;
			if (flag && suggestedToolTipContent != null)
			{
				toolTip.Content = suggestedToolTipContent;
				toolTip.IsEnabled = true;
			}
			else
			{
				toolTip.Content = null;
				toolTip.IsEnabled = false;
			}
		}
		else
		{
			UpdateNavigationViewItemToolTip();
		}
	}

	private void UpdateVisualStateForPointer()
	{
		bool isEnabled2 = base.IsEnabled;
		string stateName = (isEnabled2 ? "Enabled" : "Disabled");
		string stateName2 = GetSelectedStateValue(isEnabled2, base.IsSelected);
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			VisualStateManager.GoToState(navigationViewItemPresenter, stateName, useTransitions: true);
			VisualStateManager.GoToState(navigationViewItemPresenter, stateName2, useTransitions: true);
		}
		else
		{
			VisualStateManager.GoToState(this, stateName, useTransitions: true);
			VisualStateManager.GoToState(this, stateName2, useTransitions: true);
		}
		string GetSelectedStateValue(bool isEnabled, bool isSelected)
		{
			if (isEnabled)
			{
				if (isSelected)
				{
					if (m_isPressed && !_uno_isDefferingPressedState)
					{
						return "PressedSelected";
					}
					if (m_isPointerOver && !_uno_isDefferingOverState)
					{
						return "PointerOverSelected";
					}
					return "Selected";
				}
				if (m_isPointerOver && !_uno_isDefferingOverState)
				{
					if (m_isPressed && !_uno_isDefferingPressedState)
					{
						return "Pressed";
					}
					return "PointerOver";
				}
				if (m_isPressed && !_uno_isDefferingPressedState)
				{
					return "Pressed";
				}
			}
			else if (isSelected)
			{
				return "Selected";
			}
			return "Normal";
		}
	}

	internal override void UpdateVisualState(bool useTransitions)
	{
		if (!m_appliedTemplate)
		{
			return;
		}
		UpdateVisualStateForPointer();
		UpdateVisualStateForNavigationViewPositionChange();
		bool flag = ShouldShowIcon();
		bool showContent = ShouldShowContent();
		if (IsOnLeftNav())
		{
			Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
			if (navigationViewItemPresenter != null)
			{
				VisualStateManager.GoToState(navigationViewItemPresenter, flag ? "IconVisible" : "IconCollapsed", useTransitions);
			}
			UpdateVisualStateForClosedCompact();
		}
		UpdateVisualStateForToolTip();
		UpdateVisualStateForIconAndContent(flag, showContent);
		UpdateVisualStateForInfoBadge();
		UpdateVisualStateForKeyboardFocusedState();
		UpdateVisualStateForChevron();
	}

	private void UpdateVisualStateForChevron()
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			PointerStateValue pointerStateValue2 = GetPointerStateValue(base.IsEnabled, base.IsSelected);
			ChevronStateValue chevronStateValue = ((HasChildren() && (!m_isClosedCompact || !ShouldRepeaterShowInFlyout())) ? (IsExpanded ? ChevronStateValue.ChevronVisibleOpen : ChevronStateValue.ChevronVisibleClosed) : ChevronStateValue.ChevronHidden);
			string stateName = GetPointerChevronState(pointerStateValue2, chevronStateValue);
			VisualStateManager.GoToState(navigationViewItemPresenter, stateName, useTransitions: true);
			switch (chevronStateValue)
			{
			case ChevronStateValue.ChevronHidden:
				VisualStateManager.GoToState(navigationViewItemPresenter, "ChevronHidden", useTransitions: true);
				break;
			case ChevronStateValue.ChevronVisibleOpen:
				VisualStateManager.GoToState(navigationViewItemPresenter, "ChevronVisibleOpen", useTransitions: true);
				break;
			case ChevronStateValue.ChevronVisibleClosed:
				VisualStateManager.GoToState(navigationViewItemPresenter, "ChevronVisibleClosed", useTransitions: true);
				break;
			}
		}
		static string GetPointerChevronState(PointerStateValue pointerStateValue, ChevronStateValue chevronState)
		{
			switch (chevronState)
			{
			case ChevronStateValue.ChevronHidden:
				switch (pointerStateValue)
				{
				case PointerStateValue.Normal:
					return "NormalChevronHidden";
				case PointerStateValue.PointerOver:
					return "PointerOverChevronHidden";
				case PointerStateValue.Pressed:
					return "PressedChevronHidden";
				}
				break;
			case ChevronStateValue.ChevronVisibleOpen:
				switch (pointerStateValue)
				{
				case PointerStateValue.Normal:
					return "NormalChevronVisibleOpen";
				case PointerStateValue.PointerOver:
					return "PointerOverChevronVisibleOpen";
				case PointerStateValue.Pressed:
					return "PressedChevronVisibleOpen";
				}
				break;
			case ChevronStateValue.ChevronVisibleClosed:
				switch (pointerStateValue)
				{
				case PointerStateValue.Normal:
					return "NormalChevronVisibleClosed";
				case PointerStateValue.PointerOver:
					return "PointerOverChevronVisibleClosed";
				case PointerStateValue.Pressed:
					return "PressedChevronVisibleClosed";
				}
				break;
			}
			return "NormalChevronHidden";
		}
		PointerStateValue GetPointerStateValue(bool isEnabled, bool isSelected)
		{
			if (isEnabled)
			{
				if (m_isPointerOver)
				{
					if (m_isPressed)
					{
						return PointerStateValue.Pressed;
					}
					return PointerStateValue.PointerOver;
				}
				if (m_isPressed)
				{
					return PointerStateValue.Pressed;
				}
			}
			return PointerStateValue.Normal;
		}
	}

	internal bool HasChildren()
	{
		if (MenuItems.Count <= 0 && (MenuItemsSource == null || m_repeater == null || m_repeater.ItemsSourceView.Count <= 0))
		{
			return HasUnrealizedChildren;
		}
		return true;
	}

	private bool ShouldShowIcon()
	{
		return Icon != null;
	}

	private bool ShouldShowInfoBadge()
	{
		return InfoBadge != null;
	}

	private bool ShouldEnableToolTip()
	{
		if (IsOnLeftNav())
		{
			return m_isClosedCompact;
		}
		return false;
	}

	private bool ShouldShowContent()
	{
		return Content != null;
	}

	public bool IsOnLeftNav()
	{
		NavigationViewRepeaterPosition position = base.Position;
		if (position != 0)
		{
			return position == NavigationViewRepeaterPosition.LeftFooter;
		}
		return true;
	}

	private bool IsOnTopPrimary()
	{
		return base.Position == NavigationViewRepeaterPosition.TopPrimary;
	}

	private UIElement GetPresenterOrItem()
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			return navigationViewItemPresenter;
		}
		return this;
	}

	private Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter GetPresenter()
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter result = null;
		if (m_navigationViewItemPresenter != null)
		{
			result = m_navigationViewItemPresenter;
		}
		return result;
	}

	internal void ShowHideChildren()
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater == null)
		{
			return;
		}
		bool isExpanded = IsExpanded;
		Visibility visibility2 = (repeater.Visibility = ((!isExpanded) ? Visibility.Collapsed : Visibility.Visible));
		if (!ShouldRepeaterShowInFlyout())
		{
			return;
		}
		if (isExpanded)
		{
			if (!m_isRepeaterParentedToFlyout)
			{
				ReparentRepeater();
			}
			FlyoutBase.ShowAttachedFlyout(m_rootGrid);
		}
		else
		{
			FlyoutBase.GetAttachedFlyout(m_rootGrid)?.Hide();
		}
	}

	private void ReparentRepeater()
	{
		if (!HasChildren())
		{
			return;
		}
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			if (ShouldRepeaterShowInFlyout() && !m_isRepeaterParentedToFlyout)
			{
				m_rootGrid.Children.RemoveAt(m_rootGrid.Children.Count - 1);
				m_flyoutContentGrid.Children.Add(repeater);
				m_isRepeaterParentedToFlyout = true;
				PropagateDepthToChildren(0);
			}
			else if (!ShouldRepeaterShowInFlyout() && m_isRepeaterParentedToFlyout)
			{
				m_flyoutContentGrid.Children.RemoveAt(m_flyoutContentGrid.Children.Count - 1);
				m_rootGrid.Children.Add(repeater);
				m_isRepeaterParentedToFlyout = false;
				PropagateDepthToChildren(1);
			}
		}
	}

	internal bool ShouldRepeaterShowInFlyout()
	{
		if (!m_isClosedCompact || !base.IsTopLevelItem)
		{
			return IsOnTopPrimary();
		}
		return true;
	}

	internal bool IsRepeaterVisible()
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater != null)
		{
			return repeater.Visibility == Visibility.Visible;
		}
		return false;
	}

	private void UpdateItemIndentation()
	{
		Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter = m_navigationViewItemPresenter;
		if (navigationViewItemPresenter != null)
		{
			int num = base.Depth * 31;
			navigationViewItemPresenter.UpdateContentLeftIndentation(num);
		}
	}

	internal void PropagateDepthToChildren(int depth)
	{
		ItemsRepeater repeater = m_repeater;
		if (repeater == null)
		{
			return;
		}
		int count = repeater.ItemsSourceView.Count;
		for (int i = 0; i < count; i++)
		{
			UIElement uIElement = repeater.TryGetElement(i);
			if (uIElement != null && uIElement is NavigationViewItemBase navigationViewItemBase)
			{
				navigationViewItemBase.Depth = depth;
			}
		}
	}

	internal void OnExpandCollapseChevronTapped(object sender, TappedRoutedEventArgs args)
	{
		IsExpanded = !IsExpanded;
		args.Handled = true;
	}

	private void OnFlyoutClosing(object sender, FlyoutBaseClosingEventArgs args)
	{
		IsExpanded = false;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new Microsoft.UI.Xaml.Automation.Peers.NavigationViewItemAutomationPeer(this);
	}

	protected override void OnContentChanged(object oldContent, object newContent)
	{
		base.OnContentChanged(oldContent, newContent);
		SuggestedToolTipChanged(newContent);
		UpdateVisualStateNoTransition();
		if (!IsOnLeftNav())
		{
			GetNavigationView()?.TopNavigationViewItemContentChanged();
		}
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		base.OnGotFocus(e);
		if (e.OriginalSource is Control control)
		{
			FocusState focusState = control.FocusState;
			if (focusState == FocusState.Keyboard)
			{
				m_hasKeyboardFocus = true;
				UpdateVisualStateNoTransition();
			}
		}
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		base.OnLostFocus(e);
		if (m_hasKeyboardFocus)
		{
			m_hasKeyboardFocus = false;
			UpdateVisualStateNoTransition();
		}
	}

	private void ResetTrackedPointerId()
	{
		m_trackedPointerId = 0u;
	}

	private bool IgnorePointerId(PointerRoutedEventArgs args)
	{
		uint pointerId = args.Pointer.PointerId;
		if (m_trackedPointerId == 0)
		{
			m_trackedPointerId = pointerId;
		}
		else if (m_trackedPointerId != pointerId)
		{
			return true;
		}
		return false;
	}

	private void OnPresenterPointerPressed(object sender, PointerRoutedEventArgs args)
	{
		if (!IgnorePointerId(args))
		{
			PointerPointProperties properties = args.GetCurrentPoint(this).Properties;
			m_isPressed = properties.IsLeftButtonPressed || properties.IsRightButtonPressed;
			Pointer pointer = args.Pointer;
			UIElement presenterOrItem = GetPresenterOrItem();
			if (presenterOrItem.CapturePointer(pointer))
			{
				m_capturedPointer = pointer;
			}
			UpdateVisualState(useTransitions: true);
		}
	}

	private void OnPresenterPointerReleased(object sender, PointerRoutedEventArgs args)
	{
		if (!IgnorePointerId(args) && m_isPressed)
		{
			m_isPressed = false;
			if (m_capturedPointer != null)
			{
				UIElement presenterOrItem = GetPresenterOrItem();
				presenterOrItem.ReleasePointerCapture(m_capturedPointer);
			}
			UpdateVisualState(useTransitions: true);
		}
	}

	private void OnPresenterPointerEntered(object sender, PointerRoutedEventArgs args)
	{
		ProcessPointerOver(args);
	}

	private void OnPresenterPointerMoved(object sender, PointerRoutedEventArgs args)
	{
		ProcessPointerOver(args);
	}

	private void OnPresenterPointerExited(object sender, PointerRoutedEventArgs args)
	{
		if (!IgnorePointerId(args))
		{
			m_isPointerOver = false;
			if (m_capturedPointer == null)
			{
				ResetTrackedPointerId();
			}
			UpdateVisualState(useTransitions: true);
		}
	}

	private void OnPresenterPointerCanceled(object sender, PointerRoutedEventArgs args)
	{
		ProcessPointerCanceled(args);
	}

	private void OnPresenterPointerCaptureLost(object sender, PointerRoutedEventArgs args)
	{
		ProcessPointerCanceled(args);
	}

	private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs args)
	{
		if (!base.IsEnabled)
		{
			m_isPressed = false;
			m_isPointerOver = false;
			if (m_capturedPointer != null)
			{
				UIElement presenterOrItem = GetPresenterOrItem();
				presenterOrItem.ReleasePointerCapture(m_capturedPointer);
				m_capturedPointer = null;
			}
			ResetTrackedPointerId();
		}
		UpdateVisualState(useTransitions: true);
	}

	internal void RotateExpandCollapseChevron(bool isExpanded)
	{
		GetPresenter()?.RotateExpandCollapseChevron(isExpanded);
	}

	private void ProcessPointerCanceled(PointerRoutedEventArgs args)
	{
		if (!IgnorePointerId(args))
		{
			_uno_isDefferingPressedState = false;
			_uno_isDefferingOverState = false;
			_uno_pointerDeferring?.Stop();
			m_isPressed = false;
			if (IsOutOfControlBounds(args.GetCurrentPoint(this).Position))
			{
				m_isPointerOver = false;
			}
			m_capturedPointer = null;
			ResetTrackedPointerId();
			UpdateVisualState(useTransitions: true);
		}
	}

	private bool IsOutOfControlBounds(Point point)
	{
		double num = 1.0;
		double actualWidth = base.ActualWidth;
		double actualHeight = base.ActualHeight;
		if (!(point.X < num) && !(point.X > actualWidth - num) && !(point.Y < num))
		{
			return point.Y > actualHeight - num;
		}
		return true;
	}

	private void ProcessPointerOver(PointerRoutedEventArgs args)
	{
		if (!IgnorePointerId(args) && !m_isPointerOver)
		{
			m_isPointerOver = true;
			UpdateVisualState(useTransitions: true);
		}
	}

	private void HookInputEvents()
	{
		UIElement presenter = GetPresenter();
		presenter.PointerPressed += OnPresenterPointerPressed;
		m_presenterPointerPressedRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.PointerPressed -= OnPresenterPointerPressed;
		});
		presenter.PointerEntered += OnPresenterPointerEntered;
		m_presenterPointerEnteredRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.PointerEntered -= OnPresenterPointerEntered;
		});
		presenter.PointerMoved += OnPresenterPointerMoved;
		m_presenterPointerMovedRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.PointerMoved -= OnPresenterPointerMoved;
		});
		PointerEventHandler pointerReleasedHandler = OnPresenterPointerReleased;
		presenter.AddHandler(UIElement.PointerReleasedEvent, pointerReleasedHandler, handledEventsToo: true);
		m_presenterPointerReleasedRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.RemoveHandler(UIElement.PointerReleasedEvent, pointerReleasedHandler);
		});
		PointerEventHandler pointerExitedHandler = OnPresenterPointerExited;
		presenter.AddHandler(UIElement.PointerExitedEvent, pointerExitedHandler, handledEventsToo: true);
		m_presenterPointerExitedRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.RemoveHandler(UIElement.PointerExitedEvent, pointerExitedHandler);
		});
		PointerEventHandler pointerCanceledHandler = OnPresenterPointerCanceled;
		presenter.AddHandler(UIElement.PointerCanceledEvent, pointerCanceledHandler, handledEventsToo: true);
		m_presenterPointerCanceledRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.RemoveHandler(UIElement.PointerCanceledEvent, pointerCanceledHandler);
		});
		PointerEventHandler pointerCaptureLostHandler = OnPresenterPointerCaptureLost;
		presenter.AddHandler(UIElement.PointerCaptureLostEvent, pointerCaptureLostHandler, handledEventsToo: true);
		m_presenterPointerCaptureLostRevoker.Disposable = Disposable.Create(delegate
		{
			presenter.RemoveHandler(UIElement.PointerCaptureLostEvent, pointerCaptureLostHandler);
		});
		UIElement GetPresenter()
		{
			if (GetTemplateChild("NavigationViewItemPresenter") is Microsoft.UI.Xaml.Controls.Primitives.NavigationViewItemPresenter navigationViewItemPresenter)
			{
				m_navigationViewItemPresenter = navigationViewItemPresenter;
				return navigationViewItemPresenter;
			}
			return this;
		}
	}

	private void UnhookInputEvents()
	{
		m_presenterPointerPressedRevoker.Disposable = null;
		m_presenterPointerEnteredRevoker.Disposable = null;
		m_presenterPointerMovedRevoker.Disposable = null;
		m_presenterPointerReleasedRevoker.Disposable = null;
		m_presenterPointerExitedRevoker.Disposable = null;
		m_presenterPointerCanceledRevoker.Disposable = null;
		m_presenterPointerCaptureLostRevoker.Disposable = null;
	}

	private void UnhookEventsAndClearFields()
	{
		UnhookInputEvents();
		m_flyoutClosingRevoker.Disposable = null;
		m_splitViewIsPaneOpenChangedRevoker.Disposable = null;
		m_splitViewDisplayModeChangedRevoker.Disposable = null;
		m_splitViewCompactPaneLengthChangedRevoker.Disposable = null;
		m_repeaterElementPreparedRevoker.Disposable = null;
		m_repeaterElementClearingRevoker.Disposable = null;
		m_isEnabledChangedRevoker.Disposable = null;
		m_itemsSourceViewCollectionChangedRevoker.Disposable = null;
		m_rootGrid = null;
		m_navigationViewItemPresenter = null;
		m_toolTip = null;
		m_repeater = null;
		m_flyoutContentGrid = null;
	}

	private void PrepNavigationViewItem(SplitView splitView)
	{
		long splitViewIsPaneOpenChangedSubscription = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewPropertyChanged);
		m_splitViewIsPaneOpenChangedRevoker.Disposable = Disposable.Create(delegate
		{
			splitView.UnregisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, splitViewIsPaneOpenChangedSubscription);
		});
		long splitViewDisplayModeChangedSubscription = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewPropertyChanged);
		m_splitViewDisplayModeChangedRevoker.Disposable = Disposable.Create(delegate
		{
			splitView.UnregisterPropertyChangedCallback(SplitView.DisplayModeProperty, splitViewDisplayModeChangedSubscription);
		});
		long splitViewCompactPaneLengthSubsctiption = splitView.RegisterPropertyChangedCallback(SplitView.CompactPaneLengthProperty, OnSplitViewPropertyChanged);
		m_splitViewCompactPaneLengthChangedRevoker.Disposable = Disposable.Create(delegate
		{
			splitView.UnregisterPropertyChangedCallback(SplitView.CompactPaneLengthProperty, splitViewCompactPaneLengthSubsctiption);
		});
		UpdateCompactPaneLength();
		UpdateIsClosedCompact();
	}

	internal ItemsRepeater GetRepeater()
	{
		return m_repeater;
	}

	private static void OnHasUnrealizedChildrenPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnHasUnrealizedChildrenPropertyChanged(args);
	}

	private static void OnIconPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnIconPropertyChanged(args);
	}

	private static void OnInfoBadgePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnInfoBadgePropertyChanged(args);
	}

	private static void OnIsExpandedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnIsExpandedPropertyChanged(args);
	}

	private static void OnMenuItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnMenuItemsPropertyChanged(args);
	}

	private static void OnMenuItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		NavigationViewItem navigationViewItem = (NavigationViewItem)sender;
		navigationViewItem.OnMenuItemsSourcePropertyChanged(args);
	}

	private void DeferUpdateVisualStateForPointer()
	{
		if (!_uno_isDefferingOverState && !_uno_isDefferingPressedState)
		{
			return;
		}
		if (_uno_pointerDeferring == null)
		{
			_uno_pointerDeferring = DispatcherQueue.GetForCurrentThread().CreateTimer();
			_uno_pointerDeferring.Interval = TimeSpan.FromMilliseconds(200.0);
			_uno_pointerDeferring.IsRepeating = false;
			_uno_pointerDeferring.Tick += delegate
			{
				if (_uno_isDefferingOverState || _uno_isDefferingPressedState)
				{
					_uno_isDefferingOverState = false;
					_uno_isDefferingPressedState = false;
					UpdateVisualStateForPointer();
				}
			};
		}
		if (!_uno_pointerDeferring.IsRunning)
		{
			_uno_pointerDeferring.Start();
		}
	}
}
