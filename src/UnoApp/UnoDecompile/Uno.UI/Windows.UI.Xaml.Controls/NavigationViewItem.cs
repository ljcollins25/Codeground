using Uno;
using Uno.Disposables;
using Windows.UI.Composition;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewItem : NavigationViewItemBase
{
	private const string c_navigationViewItemPresenterName = "NavigationViewItemPresenter";

	private long m_splitViewIsPaneOpenChangedRevoker;

	private long m_splitViewDisplayModeChangedRevoker;

	private long m_splitViewCompactPaneLengthChangedRevoker;

	private SerialDisposable _splitViewSubscriptions = new SerialDisposable();

	private NavigationViewItemHelper<NavigationViewItem> m_helper = new NavigationViewItemHelper<NavigationViewItem>();

	private NavigationViewItemPresenter m_navigationViewItemPresenter;

	private object m_suggestedToolTipContent;

	private bool m_isClosedCompact;

	private bool m_appliedTemplate;

	private bool m_hasKeyboardFocus;

	private bool m_isContentChangeHandlingDelayedForTopNav;

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

	public double CompactPaneLength => (double)GetValue(CompactPaneLengthProperty);

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

	[NotImplemented]
	public static DependencyProperty SelectsOnInvokedProperty { get; } = DependencyProperty.Register("SelectsOnInvoked", typeof(bool), typeof(NavigationViewItem), new FrameworkPropertyMetadata(true));


	public static DependencyProperty CompactPaneLengthProperty { get; } = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(NavigationViewItem), new FrameworkPropertyMetadata(48.0));


	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(NavigationViewItem), new FrameworkPropertyMetadata((object)null));


	internal void UpdateVisualStateNoTransition()
	{
		UpdateLocalVisualState(useTransitions: false);
	}

	internal bool IsContentChangeHandlingDelayedForTopNav()
	{
		return m_isContentChangeHandlingDelayedForTopNav;
	}

	internal void ClearIsContentChangeHandlingDelayedForTopNavFlag()
	{
		m_isContentChangeHandlingDelayedForTopNav = false;
	}

	protected override void OnNavigationViewListPositionChanged()
	{
		UpdateVisualStateNoTransition();
	}

	public NavigationViewItem()
	{
		base.DefaultStyleKey = typeof(NavigationViewItem);
		base.Loaded += NavigationViewItem_Loaded;
	}

	private void NavigationViewItem_Loaded(object sender, RoutedEventArgs e)
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			_splitViewSubscriptions.Disposable = null;
			CompositeDisposable disposable = new CompositeDisposable();
			_splitViewSubscriptions.Disposable = disposable;
			m_splitViewIsPaneOpenChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, OnSplitViewPropertyChanged);
			disposable.Add(delegate
			{
				splitView.UnregisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, m_splitViewIsPaneOpenChangedRevoker);
			});
			m_splitViewDisplayModeChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, OnSplitViewPropertyChanged);
			disposable.Add(delegate
			{
				splitView.UnregisterPropertyChangedCallback(SplitView.DisplayModeProperty, m_splitViewDisplayModeChangedRevoker);
			});
			m_splitViewCompactPaneLengthChangedRevoker = splitView.RegisterPropertyChangedCallback(SplitView.CompactPaneLengthProperty, OnSplitViewPropertyChanged);
			disposable.Add(delegate
			{
				splitView.UnregisterPropertyChangedCallback(SplitView.CompactPaneLengthProperty, m_splitViewCompactPaneLengthChangedRevoker);
			});
			UpdateCompactPaneLength();
			UpdateIsClosedCompact();
		}
	}

	~NavigationViewItem()
	{
	}

	protected override void OnApplyTemplate()
	{
		m_appliedTemplate = false;
		base.OnApplyTemplate();
		m_helper.Init(this);
		m_navigationViewItemPresenter = GetTemplateChild("NavigationViewItemPresenter") as NavigationViewItemPresenter;
		m_appliedTemplate = true;
		UpdateVisualStateNoTransition();
		Visual elementVisual = ElementCompositionPreview.GetElementVisual(this);
		NavigationView.CreateAndAttachHeaderAnimation(elementVisual);
	}

	internal UIElement GetSelectionIndicator()
	{
		UIElement selectionIndicator = m_helper.GetSelectionIndicator();
		NavigationViewItemPresenter presenter = GetPresenter();
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
		}
	}

	private void UpdateCompactPaneLength()
	{
		SplitView splitView = GetSplitView();
		if (splitView != null)
		{
			SetValue(CompactPaneLengthProperty, splitView.CompactPaneLength);
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

	private void UpdateNavigationViewItemToolTip()
	{
		object toolTip = ToolTipService.GetToolTip(this);
		if (toolTip == null || toolTip == m_suggestedToolTipContent)
		{
			if (ShouldEnableToolTip())
			{
				ToolTipService.SetToolTip(this, m_suggestedToolTipContent);
			}
			else
			{
				ToolTipService.SetToolTip(this, null);
			}
		}
	}

	private void SuggestedToolTipChanged(object newContent)
	{
		bool flag = newContent is string;
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

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == IconProperty)
		{
			UpdateVisualStateNoTransition();
		}
	}

	private void UpdateVisualStateForIconAndContent(bool showIcon, bool showContent)
	{
		string stateName = ((!showIcon) ? "ContentOnly" : (showContent ? "IconOnLeft" : "IconOnly"));
		VisualStateManager.GoToState(this, stateName, useTransitions: false);
	}

	private void UpdateVisualStateForNavigationViewListPositionChange()
	{
		NavigationViewListPosition navigationViewListPosition = Position();
		string stateName = NavigationViewItemHelper.c_OnLeftNavigation;
		bool flag = false;
		switch (navigationViewListPosition)
		{
		case NavigationViewListPosition.TopPrimary:
			stateName = NavigationViewItemHelper.c_OnTopNavigationPrimary;
			break;
		case NavigationViewListPosition.TopOverflow:
			stateName = NavigationViewItemHelper.c_OnTopNavigationOverflow;
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
	}

	private void UpdateLocalVisualState(bool useTransitions)
	{
		if (m_appliedTemplate)
		{
			UpdateVisualStateForNavigationViewListPositionChange();
			bool flag = ShouldShowIcon();
			bool showContent = ShouldShowContent();
			if (IsOnLeftNav())
			{
				VisualStateManager.GoToState(this, m_isClosedCompact ? "ClosedCompact" : "NotClosedCompact", useTransitions);
				VisualStateManager.GoToState(this, flag ? "IconVisible" : "IconCollapsed", useTransitions);
			}
			UpdateVisualStateForToolTip();
			UpdateVisualStateForIconAndContent(flag, showContent);
			UpdateVisualStateForKeyboardFocusedState();
		}
	}

	private bool ShouldShowIcon()
	{
		return Icon != null;
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

	private bool IsOnLeftNav()
	{
		return Position() == NavigationViewListPosition.LeftNav;
	}

	private bool IsOnTopPrimary()
	{
		return Position() == NavigationViewListPosition.TopPrimary;
	}

	private NavigationViewItemPresenter GetPresenter()
	{
		NavigationViewItemPresenter result = null;
		if (m_navigationViewItemPresenter != null)
		{
			result = m_navigationViewItemPresenter;
		}
		return result;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new NavigationViewItemAutomationPeer(this);
	}

	protected override void OnContentChanged(object oldContent, object newContent)
	{
		base.OnContentChanged(oldContent, newContent);
		SuggestedToolTipChanged(newContent);
		UpdateVisualStateNoTransition();
		if (!IsOnLeftNav())
		{
			NavigationView navigationView = GetNavigationView();
			if (navigationView != null)
			{
				navigationView.TopNavigationViewItemContentChanged();
			}
			else
			{
				m_isContentChangeHandlingDelayedForTopNav = true;
			}
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
}
