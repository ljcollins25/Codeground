using System;
using DirectUI;
using Uno.Disposables;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Helpers.WinUI;
using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls;

public class AppBar : ContentControl
{
	private const string TEXT_HUB_SEE_MORE = "TEXT_HUB_SEE_MORE";

	private const string TEXT_HUB_SEE_LESS = "TEXT_HUB_SEE_LESS";

	private const string UIA_MORE_BUTTON = "UIA_MORE_BUTTON";

	private const string UIA_LESS_BUTTON = "UIA_LESS_BUTTON";

	protected Grid? m_tpLayoutRoot;

	protected FrameworkElement? m_tpContentRoot;

	protected ButtonBase? m_tpExpandButton;

	protected WeakReference<VisualStateGroup?>? m_tpDisplayModesStateGroupRef;

	protected double m_compactHeight;

	protected double m_minimalHeight;

	private AppBarMode m_Mode;

	private WeakReference<Page>? m_wpOwner;

	private SerialDisposable m_contentRootSizeChangedEventHandler = new SerialDisposable();

	private SerialDisposable m_windowSizeChangedEventHandler = new SerialDisposable();

	private SerialDisposable m_expandButtonClickEventHandler = new SerialDisposable();

	private SerialDisposable m_displayModeStateChangedEventHandler = new SerialDisposable();

	private FocusState m_onLoadFocusState;

	private UIElement? m_layoutTransitionElement;

	private UIElement? m_overlayLayoutTransitionElement;

	private bool _isNativeTemplate;

	private FrameworkElement? m_overlayElement;

	private SerialDisposable m_overlayElementPointerPressedEventHandler = new SerialDisposable();

	private WeakReference<DependencyObject>? m_savedFocusedElementWeakRef;

	private FocusState m_savedFocusState;

	private bool m_isInOverlayState;

	private bool m_isChangingOpenedState;

	private bool m_hasUpdatedTemplateSettings;

	private double m_contentHeight;

	private bool m_isOverlayVisible;

	private Storyboard? m_overlayOpeningStoryboard;

	private Storyboard? m_overlayClosingStoryboard;

	protected double ContentHeight => m_contentHeight;

	public bool IsSticky
	{
		get
		{
			return (bool)GetValue(IsStickyProperty);
		}
		set
		{
			SetValue(IsStickyProperty, value);
		}
	}

	public static DependencyProperty IsStickyProperty { get; } = DependencyProperty.Register("IsSticky", typeof(bool), typeof(AppBar), new FrameworkPropertyMetadata(false));


	public bool IsOpen
	{
		get
		{
			return (bool)GetValue(IsOpenProperty);
		}
		set
		{
			SetValue(IsOpenProperty, value);
		}
	}

	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(AppBar), new FrameworkPropertyMetadata(false));


	public AppBarClosedDisplayMode ClosedDisplayMode
	{
		get
		{
			return (AppBarClosedDisplayMode)GetValue(ClosedDisplayModeProperty);
		}
		set
		{
			SetValue(ClosedDisplayModeProperty, value);
		}
	}

	public static DependencyProperty ClosedDisplayModeProperty { get; } = DependencyProperty.Register("ClosedDisplayMode", typeof(AppBarClosedDisplayMode), typeof(AppBar), new FrameworkPropertyMetadata(AppBarClosedDisplayMode.Compact));


	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(AppBar), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	public AppBarTemplateSettings TemplateSettings
	{
		get
		{
			return (AppBarTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(AppBarTemplateSettings), typeof(AppBar), new FrameworkPropertyMetadata(null));


	public event EventHandler<object>? Opened;

	public event EventHandler<object>? Opening;

	public event EventHandler<object>? Closed;

	public event EventHandler<object>? Closing;

	public AppBar()
	{
		m_Mode = AppBarMode.Inline;
		m_onLoadFocusState = FocusState.Unfocused;
		m_savedFocusState = FocusState.Unfocused;
		m_isInOverlayState = false;
		m_isChangingOpenedState = false;
		m_hasUpdatedTemplateSettings = false;
		m_compactHeight = 0.0;
		m_minimalHeight = 0.0;
		m_contentHeight = 0.0;
		m_isOverlayVisible = false;
		PrepareState();
		base.DefaultStyleKey = typeof(AppBar);
	}

	protected virtual void PrepareState()
	{
		base.SizeChanged += OnSizeChanged;
		m_windowSizeChangedEventHandler.Disposable = Window.Current.RegisterSizeChangedEvent(OnWindowSizeChanged);
		SetValue(TemplateSettingsProperty, new AppBarTemplateSettings());
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (IsOpen)
		{
			OnIsOpenChanged(isOpen: true);
		}
		UpdateVisualState();
	}

	private void OnLayoutUpdated(object? sender, object e)
	{
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		RefreshContentHeight();
		UpdateTemplateSettings();
		Page owner = GetOwner();
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsOpenProperty)
		{
			bool isOpen = (bool)args.NewValue;
			OnIsOpenChanged(isOpen);
			UpdateVisualState();
		}
		else if (args.Property == IsStickyProperty)
		{
			OnIsStickyChanged();
		}
		else if (args.Property == ClosedDisplayModeProperty)
		{
			InvalidateMeasure();
			UpdateVisualState();
		}
		else if (args.Property == LightDismissOverlayModeProperty)
		{
			ReevaluateIsOverlayVisible();
		}
		else if (args.Property == Control.IsEnabledProperty)
		{
			UpdateVisualState();
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		Page owner = GetOwner();
	}

	private void UnregisterEvents()
	{
		m_contentRootSizeChangedEventHandler.Disposable = null;
		m_windowSizeChangedEventHandler.Disposable = null;
		m_expandButtonClickEventHandler.Disposable = null;
		m_displayModeStateChangedEventHandler.Disposable = null;
		m_overlayElementPointerPressedEventHandler.Disposable = null;
		m_tpLayoutRoot = null;
		m_tpContentRoot = null;
		m_tpExpandButton = null;
		m_tpDisplayModesStateGroupRef = null;
		m_overlayClosingStoryboard = null;
		m_overlayOpeningStoryboard = null;
	}

	private protected override void OnUnloaded()
	{
		base.LayoutUpdated -= OnLayoutUpdated;
		base.SizeChanged -= OnSizeChanged;
		if (m_isInOverlayState)
		{
			TeardownOverlayState();
		}
		UnregisterEvents();
		base.OnUnloaded();
	}

	protected override void OnApplyTemplate()
	{
		UnregisterEvents();
		m_tpLayoutRoot = null;
		m_tpContentRoot = null;
		m_tpExpandButton = null;
		m_tpDisplayModesStateGroupRef = null;
		base.OnApplyTemplate();
		GetTemplatePart<Grid>("LayoutRoot", out m_tpLayoutRoot);
		GetTemplatePart<FrameworkElement>("ContentRoot", out m_tpContentRoot);
		if (m_tpContentRoot != null)
		{
			m_tpContentRoot!.SizeChanged += OnContentRootSizeChanged;
			m_contentRootSizeChangedEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpContentRoot!.SizeChanged -= OnContentRootSizeChanged;
			});
		}
		GetTemplatePart<ButtonBase>("ExpandButton", out m_tpExpandButton);
		if (m_tpExpandButton == null)
		{
			GetTemplatePart<ButtonBase>("MoreButton", out m_tpExpandButton);
		}
		if (m_tpExpandButton != null)
		{
			m_tpExpandButton!.Click += OnExpandButtonClick;
			m_expandButtonClickEventHandler.Disposable = Disposable.Create(delegate
			{
				m_tpExpandButton!.Click -= OnExpandButtonClick;
			});
			ToolTip toolTip = new ToolTip();
			toolTip.Content = DXamlCore.Current.GetLocalizedResourceString("TEXT_HUB_SEE_MORE");
			ToolTipService.SetToolTip(m_tpExpandButton, toolTip);
			string name = AutomationProperties.GetName((Button)m_tpExpandButton);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_MORE_BUTTON");
				AutomationProperties.SetName((Button)m_tpExpandButton, name);
			}
		}
		m_compactHeight = ResourceResolver.ResolveTopLevelResourceDouble("AppBarThemeCompactHeight");
		m_minimalHeight = ResourceResolver.ResolveTopLevelResourceDouble("AppBarThemeMinimalHeight");
		if (m_tpLayoutRoot != null)
		{
			ResourceDictionary resources = m_tpLayoutRoot!.Resources;
			if (resources.TryGetValue("OverlayOpeningAnimation", out var value) && value is Storyboard overlayOpeningStoryboard)
			{
				m_overlayOpeningStoryboard = overlayOpeningStoryboard;
			}
			if (resources.TryGetValue("OverlayClosingAnimation", out var value2) && value2 is Storyboard overlayClosingStoryboard)
			{
				m_overlayClosingStoryboard = overlayClosingStoryboard;
			}
		}
		ReevaluateIsOverlayVisible();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = base.MeasureOverride(availableSize);
		if (_isNativeTemplate)
		{
			return result;
		}
		if (m_Mode == AppBarMode.Top || m_Mode == AppBarMode.Bottom)
		{
			result.Width = availableSize.Width;
		}
		result.Height = ClosedDisplayMode switch
		{
			AppBarClosedDisplayMode.Compact => m_compactHeight, 
			AppBarClosedDisplayMode.Minimal => m_minimalHeight, 
			_ => 0.0, 
		};
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size size = default(Size);
		Size result = base.ArrangeOverride(new Size(height: ((m_tpLayoutRoot == null) ? finalSize : m_tpLayoutRoot!.DesiredSize).Height, width: finalSize.Width));
		result.Height = finalSize.Height;
		return result;
	}

	protected virtual void OnOpening(object e)
	{
		TryQueryDisplayModesStatesGroup();
		if (m_Mode == AppBarMode.Inline)
		{
			Popup popup = FindFirstParent<Popup>();
			if ((popup == null || popup.IsLightDismissEnabled || popup.IsSubMenu) && !m_isInOverlayState && base.IsInLiveTree)
			{
				SetupOverlayState();
				if (m_isOverlayVisible)
				{
					PlayOverlayOpeningAnimation();
				}
			}
			if (!IsSticky)
			{
				SetFocusOnAppBar();
			}
		}
		else
		{
			AppBarClosedDisplayMode closedDisplayMode = ClosedDisplayMode;
			if (closedDisplayMode == AppBarClosedDisplayMode.Hidden)
			{
				m_onLoadFocusState = FocusState.Unfocused;
			}
		}
		if (m_tpExpandButton != null)
		{
			ToolTip toolTip = new ToolTip();
			toolTip.Content = DXamlCore.Current.GetLocalizedResourceString("TEXT_HUB_SEE_LESS");
			ToolTipService.SetToolTip(m_tpExpandButton, toolTip);
			AutomationProperties.SetName(m_tpExpandButton, DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_LESS_BUTTON"));
		}
		ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Show, this);
		this.Opening?.Invoke(this, e);
	}

	protected virtual void OnOpened(object e)
	{
		this.Opened?.Invoke(this, e);
	}

	protected virtual void OnClosing(object e)
	{
		if (m_Mode == AppBarMode.Inline)
		{
			Popup popup = FindFirstParent<Popup>();
			if (popup == null || !(popup.PopupPanel is FlyoutBasePopupPanel))
			{
				RestoreSavedFocus();
			}
			if (m_isOverlayVisible && m_isInOverlayState)
			{
				PlayOverlayClosingAnimation();
			}
		}
		if (m_tpExpandButton != null)
		{
			string localizedResourceString = DXamlCore.Current.GetLocalizedResourceString("TEXT_HUB_SEE_MORE");
			ToolTip toolTip = new ToolTip();
			toolTip.Content = localizedResourceString;
			ToolTipService.SetToolTip(m_tpExpandButton, toolTip);
			AutomationProperties.SetName(m_tpExpandButton, DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_MORE_BUTTON"));
		}
		ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Hide, this);
		this.Closing?.Invoke(this, e);
	}

	protected virtual void OnClosed(object e)
	{
		if (m_Mode == AppBarMode.Inline && m_isInOverlayState)
		{
			TeardownOverlayState();
		}
		this.Closed?.Invoke(this, e);
	}

	internal override TabStopProcessingResult ProcessTabStopOverride(DependencyObject? focusedElement, DependencyObject? candidateTabStopElement, bool isBackward, bool didCycleFocusAtRootVisualScope)
	{
		TabStopProcessingResult tabStopProcessingResult = default(TabStopProcessingResult);
		tabStopProcessingResult.NewTabStop = null;
		tabStopProcessingResult.IsOverriden = false;
		TabStopProcessingResult result = tabStopProcessingResult;
		if (m_Mode == AppBarMode.Inline)
		{
			bool isOpen = IsOpen;
			bool isSticky = IsSticky;
			if (!isOpen || isSticky)
			{
				return result;
			}
			bool flag = this.IsAncestorOf(focusedElement);
			bool flag2 = this.IsAncestorOf(candidateTabStopElement);
			if (flag && !flag2)
			{
				DependencyObject dependencyObject = (isBackward ? FocusManager.FindLastFocusableElement(this) : FocusManager.FindFirstFocusableElement(this));
				if (dependencyObject != null)
				{
					result.NewTabStop = dependencyObject;
					result.IsOverriden = true;
				}
			}
		}
		return result;
	}

	private void OnContentRootSizeChanged(object sender, SizeChangedEventArgs args)
	{
		if (RefreshContentHeight())
		{
			UpdateTemplateSettings();
		}
	}

	private void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
	{
		if (m_Mode == AppBarMode.Inline)
		{
			TryDismissInlineAppBar();
		}
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		base.ChangeVisualState(useTransitions);
		bool b = false;
		bool flag = false;
		bool flag2 = false;
		AppBarClosedDisplayMode appBarClosedDisplayMode = AppBarClosedDisplayMode.Hidden;
		bool flag3 = false;
		flag = base.IsEnabled;
		flag2 = IsOpen;
		appBarClosedDisplayMode = ClosedDisplayMode;
		if (flag2)
		{
			flag3 = GetShouldOpenUp();
		}
		GoToState(useTransitions, flag ? "Normal" : "Disabled", out b);
		if (m_Mode == AppBarMode.Floating)
		{
			GoToState(useTransitions, flag2 ? "FloatingVisible" : "FloatingHidden", out b);
		}
		switch (m_Mode)
		{
		case AppBarMode.Top:
			GoToState(useTransitions, "Top", out b);
			break;
		case AppBarMode.Bottom:
			GoToState(useTransitions, "Bottom", out b);
			break;
		default:
			GoToState(useTransitions, "Undocked", out b);
			break;
		}
		string text = appBarClosedDisplayMode switch
		{
			AppBarClosedDisplayMode.Compact => "Compact", 
			AppBarClosedDisplayMode.Minimal => "Minimal", 
			_ => "Hidden", 
		};
		string text2 = (flag3 ? "Up" : "Down");
		string empty = string.Empty;
		if (flag2)
		{
			empty = "Open";
		}
		else
		{
			empty = "Closed";
			text2 = string.Empty;
		}
		b = GoToState(useTransitions, text + empty + text2);
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs e)
	{
		base.OnPointerPressed(e);
		if (IsOpen)
		{
			if (!IsSticky)
			{
				e.Handled = true;
			}
			return;
		}
		AppBarClosedDisplayMode closedDisplayMode = ClosedDisplayMode;
		if (closedDisplayMode == AppBarClosedDisplayMode.Minimal)
		{
			IsOpen = true;
			e.Handled = true;
		}
	}

	protected override void OnRightTapped(RightTappedRoutedEventArgs e)
	{
		base.OnRightTapped(e);
		if (m_Mode == AppBarMode.Inline)
		{
			return;
		}
		PointerDeviceType pointerDeviceType = e.PointerDeviceType;
		if (pointerDeviceType == PointerDeviceType.Mouse)
		{
			bool isOpen = IsOpen;
			bool handled = e.Handled;
			if (isOpen && !handled)
			{
				e.Handled = true;
			}
		}
	}

	private void OnIsStickyChanged()
	{
		_ = m_Mode;
		_ = 3;
		if (m_overlayElement != null)
		{
			bool isSticky = IsSticky;
			m_overlayElement!.IsHitTestVisible = !isSticky;
		}
	}

	private void OnIsOpenChanged(bool isOpen)
	{
		if (base.IsInLiveTree)
		{
			_ = m_Mode;
			_ = 3;
			m_isChangingOpenedState = true;
			RoutedEventArgs e = new RoutedEventArgs(this);
			if (isOpen)
			{
				OnOpening(e);
			}
			else
			{
				OnClosing(e);
			}
			if (isOpen)
			{
				OnOpened(e);
			}
			else
			{
				OnClosed(e);
			}
		}
	}

	private void OnIsOpenChangedForAutomation(DependencyPropertyChangedEventArgs args)
	{
		bool flag = (bool)args.NewValue;
		bool flag2 = false;
		if (flag)
		{
			AutomationPeer.RaiseEventIfListener(this, AutomationEvents.MenuOpened);
		}
		else
		{
			AutomationPeer.RaiseEventIfListener(this, AutomationEvents.MenuClosed);
		}
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			AutomationPeer automationPeer = GetAutomationPeer();
			if (automationPeer is AppBarAutomationPeer appBarAutomationPeer)
			{
				appBarAutomationPeer.RaiseToggleStatePropertyChangedEvent(args.OldValue, args.NewValue);
				appBarAutomationPeer.RaiseExpandCollapseAutomationEvent(flag);
			}
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		AutomationPeer automationPeer = null;
		return new AppBarAutomationPeer(this);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		bool flag = false;
		if (args.Handled)
		{
			return;
		}
		VirtualKey key = args.Key;
		if (key == VirtualKey.Escape)
		{
			bool handled = false;
			if (m_Mode == AppBarMode.Inline)
			{
				handled = TryDismissInlineAppBar();
			}
			args.Handled = handled;
		}
	}

	public void SetOwner(Page pOwner)
	{
		m_wpOwner = new WeakReference<Page>(pOwner);
	}

	public Page? GetOwner()
	{
		if (m_wpOwner != null && m_wpOwner!.TryGetTarget(out var target) && target != null)
		{
			return target;
		}
		return null;
	}

	protected virtual bool ContainsElement(DependencyObject pElement)
	{
		bool flag = false;
		return this.IsAncestorOf(pElement);
	}

	protected bool IsExpandButton(UIElement element)
	{
		if (m_tpExpandButton != null)
		{
			return element == m_tpExpandButton;
		}
		return false;
	}

	private void OnExpandButtonClick(object sender, RoutedEventArgs e)
	{
		bool flag = false;
		flag = IsOpen;
		IsOpen = !flag;
	}

	private void OnDisplayModesStateChanged(object sender, VisualStateChangedEventArgs pArgs)
	{
		if (m_isChangingOpenedState)
		{
			RoutedEventArgs e = new RoutedEventArgs(this);
			if (IsOpen)
			{
				OnOpened(e);
			}
			else
			{
				OnClosed(e);
			}
			m_isChangingOpenedState = false;
		}
	}

	protected virtual void UpdateTemplateSettings()
	{
		AppBarTemplateSettings templateSettings = TemplateSettings;
		double actualWidth = base.ActualWidth;
		double contentHeight = m_contentHeight;
		templateSettings.ClipRect = new Rect(0.0, 0.0, actualWidth, contentHeight);
		double num2 = (templateSettings.CompactVerticalDelta = m_compactHeight - contentHeight);
		templateSettings.NegativeCompactVerticalDelta = 0.0 - num2;
		double num4 = (templateSettings.MinimalVerticalDelta = m_minimalHeight - contentHeight);
		templateSettings.NegativeMinimalVerticalDelta = 0.0 - num4;
		templateSettings.HiddenVerticalDelta = 0.0 - contentHeight;
		templateSettings.NegativeHiddenVerticalDelta = contentHeight;
		if (m_hasUpdatedTemplateSettings)
		{
			UpdateVisualState();
			TryQueryDisplayModesStatesGroup();
			VisualStateGroup target = null;
			WeakReference<VisualStateGroup?>? tpDisplayModesStateGroupRef = m_tpDisplayModesStateGroupRef;
			if (tpDisplayModesStateGroupRef != null && tpDisplayModesStateGroupRef!.TryGetTarget(out target))
			{
				VisualState visualState = target?.CurrentState;
				if (visualState != null)
				{
					Storyboard storyboard = visualState.Storyboard;
					if (storyboard != null)
					{
						storyboard.Begin();
						storyboard.SkipToFill();
					}
				}
			}
		}
		m_hasUpdatedTemplateSettings = true;
	}

	protected bool GetShouldOpenUp()
	{
		bool result = m_Mode != AppBarMode.Top;
		if (m_Mode == AppBarMode.Inline)
		{
			GeneralTransform generalTransform = TransformToVisual(null);
			GetVerticalOffsetNeededToOpenUp(out var neededOffset, out var opensWindowed);
			Point point = generalTransform.TransformPoint(new Point(0.0, 0.0 - neededOffset));
			Rect rect = default(Rect);
			if (!opensWindowed)
			{
				rect = Window.Current.Bounds;
				result = point.Y >= rect.Y;
			}
		}
		return result;
	}

	protected virtual void GetVerticalOffsetNeededToOpenUp(out double neededOffset, out bool opensWindowed)
	{
		double num = 0.0;
		AppBarTemplateSettings templateSettings = TemplateSettings;
		neededOffset = 0.0 - ClosedDisplayMode switch
		{
			AppBarClosedDisplayMode.Compact => templateSettings.CompactVerticalDelta, 
			AppBarClosedDisplayMode.Minimal => templateSettings.MinimalVerticalDelta, 
			_ => templateSettings.HiddenVerticalDelta, 
		};
		opensWindowed = false;
	}

	protected bool TryDismissInlineAppBar()
	{
		bool result = false;
		if (!IsSticky)
		{
			if (IsOpen)
			{
				result = true;
			}
			IsOpen = false;
		}
		return result;
	}

	private void SetFocusOnAppBar()
	{
		DependencyObject focusedElement = this.GetFocusedElement();
		if (focusedElement != null && !this.IsAncestorOf(focusedElement))
		{
			m_savedFocusedElementWeakRef = new WeakReference<DependencyObject>(focusedElement);
			if (focusedElement is Control control && control.FocusState != 0)
			{
				m_savedFocusState = control.FocusState;
			}
			else
			{
				m_savedFocusState = FocusState.Programmatic;
			}
			DependencyObject dependencyObject = FocusManager.FindFirstFocusableElement(this);
			if (dependencyObject != null)
			{
				this.SetFocusedElement(dependencyObject, m_savedFocusState, animateIfBringIntoView: false);
			}
		}
	}

	private void RestoreSavedFocus()
	{
		DependencyObject target = null;
		m_savedFocusedElementWeakRef?.TryGetTarget(out target);
		RestoreSavedFocusImpl(target, m_savedFocusState);
		m_savedFocusedElementWeakRef = null;
		m_savedFocusState = FocusState.Unfocused;
	}

	protected virtual void RestoreSavedFocusImpl(DependencyObject? savedFocusedElement, FocusState savedFocusState)
	{
		if (savedFocusedElement != null)
		{
			this.SetFocusedElement(savedFocusedElement, m_savedFocusState, animateIfBringIntoView: false);
		}
	}

	private bool RefreshContentHeight()
	{
		double contentHeight = m_contentHeight;
		if (m_tpContentRoot != null)
		{
			m_contentHeight = m_tpContentRoot!.ActualHeight;
		}
		return contentHeight != m_contentHeight;
	}

	private void SetupOverlayState()
	{
		if (m_tpLayoutRoot != null)
		{
			if (m_overlayElement == null)
			{
				Rectangle rectangle = new Rectangle();
				rectangle.Width = 1.0;
				rectangle.Height = 1.0;
				rectangle.UseLayoutRounding = false;
				bool isSticky = IsSticky;
				rectangle.IsHitTestVisible = !isSticky;
				rectangle.PointerPressed += OnOverlayElementPointerPressed;
				m_overlayElementPointerPressedEventHandler.Disposable = Disposable.Create(delegate
				{
					rectangle.PointerPressed -= OnOverlayElementPointerPressed;
				});
				m_overlayElement = rectangle;
				UpdateOverlayElementBrush();
			}
			m_tpLayoutRoot!.Children.Insert(0, m_overlayElement);
		}
		if (m_isOverlayVisible)
		{
			UpdateTargetForOverlayAnimations();
		}
		m_isInOverlayState = true;
	}

	private void TeardownOverlayState()
	{
		if (m_tpLayoutRoot != null)
		{
			int num = m_tpLayoutRoot!.Children.IndexOf(m_overlayElement);
			if (num != -1)
			{
				m_tpLayoutRoot!.Children.RemoveAt(num);
			}
		}
		m_isInOverlayState = false;
	}

	private void OnOverlayElementPointerPressed(object sender, PointerRoutedEventArgs e)
	{
		TryDismissInlineAppBar();
		e.Handled = true;
	}

	private void TryQueryDisplayModesStatesGroup()
	{
		if (m_tpDisplayModesStateGroupRef != null)
		{
			return;
		}
		GetTemplatePart<VisualStateGroup>("DisplayModeStates", out var element);
		m_tpDisplayModesStateGroupRef?.SetTarget(element);
		VisualStateGroup group = null;
		WeakReference<VisualStateGroup?>? tpDisplayModesStateGroupRef = m_tpDisplayModesStateGroupRef;
		if (tpDisplayModesStateGroupRef != null && tpDisplayModesStateGroupRef!.TryGetTarget(out group) && group != null)
		{
			group.CurrentStateChanged += OnDisplayModesStateChanged;
			m_displayModeStateChangedEventHandler.Disposable = Disposable.Create(delegate
			{
				group.CurrentStateChanged -= OnDisplayModesStateChanged;
			});
		}
	}

	private void ReevaluateIsOverlayVisible()
	{
		bool flag = false;
		LightDismissOverlayMode lightDismissOverlayMode = LightDismissOverlayMode;
		flag = ((lightDismissOverlayMode != 0) ? (lightDismissOverlayMode == LightDismissOverlayMode.On) : SharedHelpers.IsOnXbox());
		flag = flag && m_Mode == AppBarMode.Inline;
		if (flag == m_isOverlayVisible)
		{
			return;
		}
		m_isOverlayVisible = flag;
		if (m_isOverlayVisible)
		{
			if (m_isInOverlayState)
			{
				UpdateTargetForOverlayAnimations();
			}
		}
		else
		{
			if (m_overlayOpeningStoryboard != null)
			{
				m_overlayOpeningStoryboard!.Stop();
			}
			if (m_overlayClosingStoryboard != null)
			{
				m_overlayClosingStoryboard!.Stop();
			}
		}
		if (m_overlayElement != null)
		{
			UpdateOverlayElementBrush();
		}
	}

	private void UpdateOverlayElementBrush()
	{
		if (m_isOverlayVisible)
		{
			object obj = ResourceResolver.ResolveTopLevelResource("AppBarLightDismissOverlayBackground");
			if (obj is Brush fill && m_overlayElement is Rectangle rectangle)
			{
				rectangle.Fill = fill;
			}
		}
		else
		{
			SolidColorBrush transparent = SolidColorBrushHelper.Transparent;
			if (m_overlayElement is Rectangle rectangle2)
			{
				rectangle2.Fill = transparent;
			}
		}
	}

	private void UpdateTargetForOverlayAnimations()
	{
		if (m_overlayOpeningStoryboard != null)
		{
			m_overlayOpeningStoryboard!.Stop();
			Storyboard.SetTarget(m_overlayOpeningStoryboard, m_overlayLayoutTransitionElement);
		}
		if (m_overlayClosingStoryboard != null)
		{
			m_overlayClosingStoryboard!.Stop();
			Storyboard.SetTarget(m_overlayClosingStoryboard, m_overlayLayoutTransitionElement);
		}
	}

	private void PlayOverlayOpeningAnimation()
	{
		if (m_overlayClosingStoryboard != null)
		{
			m_overlayClosingStoryboard!.Stop();
		}
		if (m_overlayOpeningStoryboard != null)
		{
			m_overlayOpeningStoryboard!.Begin();
		}
	}

	private void PlayOverlayClosingAnimation()
	{
		if (m_overlayOpeningStoryboard != null)
		{
			m_overlayOpeningStoryboard!.Stop();
		}
		if (m_overlayClosingStoryboard != null)
		{
			m_overlayClosingStoryboard!.Begin();
		}
	}

	protected void GetTemplatePart<T>(string name, out T? element) where T : class
	{
		element = GetTemplateChild(name) as T;
	}
}
