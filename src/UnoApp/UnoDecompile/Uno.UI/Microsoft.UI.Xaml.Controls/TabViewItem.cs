using System.Numerics;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class TabViewItem : ListViewItem
{
	private const string c_overlayCornerRadiusKey = "OverlayCornerRadius";

	private Button m_closeButton;

	private ToolTip m_toolTip;

	private ContentPresenter m_headerContentPresenter;

	private TabViewWidthMode m_tabViewWidthMode;

	private TabViewCloseButtonOverlayMode m_closeButtonOverlayMode;

	private bool m_firstTimeSettingToolTip = true;

	private readonly SerialDisposable m_closeButtonClickRevoker = new SerialDisposable();

	private readonly SerialDisposable m_tabDragStartingRevoker = new SerialDisposable();

	private readonly SerialDisposable m_tabDragCompletedRevoker = new SerialDisposable();

	private bool m_hasPointerCapture;

	private bool m_isMiddlePointerButtonPressed;

	private bool m_isDragging;

	private bool m_isPointerOver;

	private object m_shadow;

	private TabView m_parentTabView;

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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(TabViewItem), new FrameworkPropertyMetadata(null, OnHeaderPropertyChanged));


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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(TabViewItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public IconSource IconSource
	{
		get
		{
			return (IconSource)GetValue(IconSourceProperty);
		}
		set
		{
			SetValue(IconSourceProperty, value);
		}
	}

	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(TabViewItem), new FrameworkPropertyMetadata(null, OnIconSourcePropertyChanged));


	public bool IsClosable
	{
		get
		{
			return (bool)GetValue(IsClosableProperty);
		}
		set
		{
			SetValue(IsClosableProperty, value);
		}
	}

	public static DependencyProperty IsClosableProperty { get; } = DependencyProperty.Register("IsClosable", typeof(bool), typeof(TabViewItem), new FrameworkPropertyMetadata(true, OnIsClosablePropertyChanged));


	public TabViewItemTemplateSettings TabViewTemplateSettings => (TabViewItemTemplateSettings)GetValue(TabViewTemplateSettingsProperty);

	public static DependencyProperty TabViewTemplateSettingsProperty { get; } = DependencyProperty.Register("TabViewTemplateSettings", typeof(TabViewItemTemplateSettings), typeof(TabViewItem), new FrameworkPropertyMetadata(null));


	public event TypedEventHandler<TabViewItem, TabViewTabCloseRequestedEventArgs> CloseRequested;

	public TabViewItem()
	{
		base.DefaultStyleKey = typeof(TabViewItem);
		SetValue(TabViewTemplateSettingsProperty, new TabViewItemTemplateSettings());
		base.Loaded += OnLoaded;
		RegisterPropertyChangedCallback(SelectorItem.IsSelectedProperty, OnIsSelectedPropertyChanged);
		RegisterPropertyChangedCallback(Control.ForegroundProperty, OnForegroundPropertyChanged);
	}

	protected override void OnApplyTemplate()
	{
		CornerRadius cornerRadius = (CornerRadius)ResourceAccessor.ResourceLookup(this, "OverlayCornerRadius");
		m_headerContentPresenter = GetTemplateChild<ContentPresenter>("ContentPresenter");
		TabView ancestorOfType = SharedHelpers.GetAncestorOfType<TabView>(VisualTreeHelper.GetParent(this));
		TabView tabView = ancestorOfType ?? null;
		m_closeButton = GetCloseButton(tabView);
		OnHeaderChanged();
		OnIconSourceChanged();
		if (ancestorOfType != null)
		{
			if (SharedHelpers.IsThemeShadowAvailable() && tabView != null)
			{
				ThemeShadow themeShadow = new ThemeShadow();
				if (!SharedHelpers.Is21H1OrHigher())
				{
					UIElement shadowReceiver = tabView.GetShadowReceiver();
					if (shadowReceiver != null)
					{
						themeShadow.Receivers.Add(shadowReceiver);
					}
				}
				m_shadow = themeShadow;
				double num = (double)SharedHelpers.FindInApplicationResources("TabViewShadowDepth", 16.0);
				Vector3 translation = base.Translation;
				Vector3 vector2 = (base.Translation = new Vector3(translation.X, translation.Y, (float)num));
				UpdateShadow();
			}
			ancestorOfType.TabDragStarting += OnTabDragStarting;
			ancestorOfType.TabDragCompleted += OnTabDragCompleted;
		}
		UpdateCloseButton();
		UpdateForeground();
		UpdateWidthModeVisualState();
		Button GetCloseButton(TabView internalTabView)
		{
			Button button = (Button)GetTemplateChild("CloseButton");
			if (button != null)
			{
				if (string.IsNullOrEmpty(AutomationProperties.GetName(button)))
				{
					string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("TabViewCloseButtonName");
					AutomationProperties.SetName(button, localizedStringResource);
				}
				if (internalTabView != null)
				{
					ToolTipService.SetToolTip(button, new ToolTip
					{
						Content = internalTabView.GetTabCloseButtonTooltipText()
					});
				}
				button.Click += OnCloseButtonClick;
			}
			return button;
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		TabView parentTabView = GetParentTabView();
		if (parentTabView != null)
		{
			TabView tabView = parentTabView;
			int tabSeparatorOpacity = tabView.IndexFromContainer(this);
			tabView.SetTabSeparatorOpacity(tabSeparatorOpacity);
		}
	}

	private void OnIsSelectedPropertyChanged(DependencyObject sender, DependencyProperty args)
	{
		FrameworkElementAutomationPeer.CreatePeerForElement(this)?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementSelected);
		if (base.IsSelected)
		{
			SetValue(Canvas.ZIndexProperty, 20);
			StartBringIntoView();
		}
		else
		{
			SetValue(Canvas.ZIndexProperty, 0);
		}
		UpdateShadow();
		UpdateWidthModeVisualState();
		UpdateCloseButton();
		UpdateForeground();
	}

	private void OnForegroundPropertyChanged(DependencyObject sender, DependencyProperty property)
	{
		UpdateForeground();
	}

	private void UpdateForeground()
	{
		if (!base.IsSelected && !m_isPointerOver)
		{
			VisualStateManager.GoToState(this, (ReadLocalValue(Control.ForegroundProperty) == DependencyProperty.UnsetValue) ? "ForegroundNotSet" : "ForegroundSet", useTransitions: false);
		}
	}

	private void UpdateShadow()
	{
		if (SharedHelpers.IsThemeShadowAvailable())
		{
			if (base.IsSelected && !m_isDragging)
			{
				base.Shadow = (ThemeShadow)m_shadow;
			}
			else
			{
				base.Shadow = null;
			}
		}
	}

	private void OnTabDragStarting(object sender, TabViewTabDragStartingEventArgs args)
	{
		m_isDragging = true;
		UpdateShadow();
	}

	private void OnTabDragCompleted(object sender, TabViewTabDragCompletedEventArgs args)
	{
		m_isDragging = false;
		UpdateShadow();
		UpdateForeground();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new TabViewItemAutomationPeer(this);
	}

	internal void OnCloseButtonOverlayModeChanged(TabViewCloseButtonOverlayMode mode)
	{
		m_closeButtonOverlayMode = mode;
		UpdateCloseButton();
	}

	internal TabView GetParentTabView()
	{
		return m_parentTabView;
	}

	internal void SetParentTabView(TabView tabView)
	{
		m_parentTabView = tabView;
	}

	internal void OnTabViewWidthModeChanged(TabViewWidthMode mode)
	{
		m_tabViewWidthMode = mode;
		UpdateWidthModeVisualState();
	}

	private void UpdateCloseButton()
	{
		if (!IsClosable)
		{
			VisualStateManager.GoToState(this, "CloseButtonCollapsed", useTransitions: false);
			return;
		}
		TabViewCloseButtonOverlayMode closeButtonOverlayMode = m_closeButtonOverlayMode;
		if (closeButtonOverlayMode == TabViewCloseButtonOverlayMode.OnPointerOver)
		{
			if (base.IsSelected || m_isPointerOver)
			{
				VisualStateManager.GoToState(this, "CloseButtonVisible", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "CloseButtonCollapsed", useTransitions: false);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "CloseButtonVisible", useTransitions: false);
		}
	}

	private void UpdateWidthModeVisualState()
	{
		if (!base.IsSelected && m_tabViewWidthMode == TabViewWidthMode.Compact)
		{
			VisualStateManager.GoToState(this, "Compact", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "StandardWidth", useTransitions: false);
		}
	}

	private void RequestClose()
	{
		TabView ancestorOfType = SharedHelpers.GetAncestorOfType<TabView>(VisualTreeHelper.GetParent(this));
		if (ancestorOfType != null)
		{
			ancestorOfType?.RequestCloseTab(this, updateTabWidths: false);
		}
	}

	internal void RaiseRequestClose(TabViewTabCloseRequestedEventArgs args)
	{
		this.CloseRequested?.Invoke(this, args);
	}

	private void OnCloseButtonClick(object sender, RoutedEventArgs args)
	{
		RequestClose();
	}

	private void OnIsClosablePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateCloseButton();
	}

	private void OnHeaderPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		OnHeaderChanged();
	}

	private void OnHeaderChanged()
	{
		ContentPresenter headerContentPresenter = m_headerContentPresenter;
		if (headerContentPresenter != null)
		{
			headerContentPresenter.Content = Header;
		}
		if (m_firstTimeSettingToolTip)
		{
			m_firstTimeSettingToolTip = false;
			if (ToolTipService.GetToolTip(this) == null)
			{
				m_toolTip = CreateToolTip();
			}
		}
		ToolTip toolTip = m_toolTip;
		if (toolTip != null)
		{
			object header = Header;
			if (header is string text && !string.IsNullOrEmpty(text))
			{
				toolTip.Content = text;
				toolTip.IsEnabled = true;
			}
			else
			{
				toolTip.Content = null;
				toolTip.IsEnabled = false;
			}
		}
		ToolTip CreateToolTip()
		{
			ToolTip toolTip2 = new ToolTip
			{
				Placement = PlacementMode.Mouse
			};
			ToolTipService.SetToolTip(this, toolTip2);
			return toolTip2;
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		if (base.IsSelected && args.Pointer.PointerDeviceType == PointerDeviceType.Mouse)
		{
			PointerPoint currentPoint = args.GetCurrentPoint(this);
			if (currentPoint.Properties.IsLeftButtonPressed && (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down)
			{
				return;
			}
		}
		base.OnPointerPressed(args);
		if (args.GetCurrentPoint(null).Properties.PointerUpdateKind == PointerUpdateKind.MiddleButtonPressed && CapturePointer(args.Pointer))
		{
			m_hasPointerCapture = true;
			m_isMiddlePointerButtonPressed = true;
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		base.OnPointerReleased(args);
		if (m_hasPointerCapture && args.GetCurrentPoint(null).Properties.PointerUpdateKind == PointerUpdateKind.MiddleButtonReleased)
		{
			bool isMiddlePointerButtonPressed = m_isMiddlePointerButtonPressed;
			m_isMiddlePointerButtonPressed = false;
			ReleasePointerCapture(args.Pointer);
			if (isMiddlePointerButtonPressed && IsClosable)
			{
				RequestClose();
			}
		}
	}

	private void HideLeftAdjacentTabSeparator()
	{
		TabView parentTabView = GetParentTabView();
		if (parentTabView != null)
		{
			TabView tabView = parentTabView;
			int num = tabView.IndexFromContainer(this);
			tabView.SetTabSeparatorOpacity(num - 1, 0);
		}
	}

	private void RestoreLeftAdjacentTabSeparatorVisibility()
	{
		TabView parentTabView = GetParentTabView();
		if (parentTabView != null)
		{
			TabView tabView = parentTabView;
			int num = tabView.IndexFromContainer(this);
			tabView.SetTabSeparatorOpacity(num - 1);
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		base.OnPointerEntered(args);
		m_isPointerOver = true;
		if (m_hasPointerCapture)
		{
			m_isMiddlePointerButtonPressed = true;
		}
		UpdateCloseButton();
		HideLeftAdjacentTabSeparator();
	}

	protected override void OnPointerExited(PointerRoutedEventArgs args)
	{
		base.OnPointerExited(args);
		m_isPointerOver = false;
		m_isMiddlePointerButtonPressed = false;
		UpdateCloseButton();
		UpdateForeground();
		RestoreLeftAdjacentTabSeparatorVisibility();
	}

	protected override void OnPointerCanceled(PointerRoutedEventArgs args)
	{
		base.OnPointerCanceled(args);
		if (m_hasPointerCapture)
		{
			ReleasePointerCapture(args.Pointer);
			m_isMiddlePointerButtonPressed = false;
		}
		RestoreLeftAdjacentTabSeparatorVisibility();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs args)
	{
		base.OnPointerCaptureLost(args);
		m_hasPointerCapture = false;
		m_isMiddlePointerButtonPressed = false;
		RestoreLeftAdjacentTabSeparatorVisibility();
	}

	private void OnIconSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		OnIconSourceChanged();
	}

	private void OnIconSourceChanged()
	{
		TabViewItemTemplateSettings tabViewTemplateSettings = TabViewTemplateSettings;
		IconSource iconSource = IconSource;
		if (iconSource != null)
		{
			tabViewTemplateSettings.IconElement = SharedHelpers.MakeIconElementFrom(iconSource);
			VisualStateManager.GoToState(this, "Icon", useTransitions: false);
		}
		else
		{
			tabViewTemplateSettings.IconElement = null;
			VisualStateManager.GoToState(this, "NoIcon", useTransitions: false);
		}
	}

	private static void OnHeaderPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabViewItem tabViewItem = (TabViewItem)sender;
		tabViewItem.OnHeaderPropertyChanged(args);
	}

	private static void OnIconSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabViewItem tabViewItem = (TabViewItem)sender;
		tabViewItem.OnIconSourcePropertyChanged(args);
	}

	private static void OnIsClosablePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		TabViewItem tabViewItem = (TabViewItem)sender;
		tabViewItem.OnIsClosablePropertyChanged(args);
	}
}
