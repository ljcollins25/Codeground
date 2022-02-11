using System.Windows.Input;
using Microsoft.UI.Xaml.Automation.Peers;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "Content")]
public class InfoBar : Control
{
	private const string c_closeButtonName = "CloseButton";

	private const string c_iconTextBlockName = "StandardIcon";

	private const string c_contentRootName = "ContentRoot";

	private readonly long _foregroundChangedCallbackRegistration;

	private bool m_applyTemplateCalled;

	private bool m_notifyOpen;

	private bool m_isVisible;

	private FrameworkElement m_standardIconTextBlock;

	private InfoBarCloseReason m_lastCloseReason = InfoBarCloseReason.Programmatic;

	public ButtonBase ActionButton
	{
		get
		{
			return (ButtonBase)GetValue(ActionButtonProperty);
		}
		set
		{
			SetValue(ActionButtonProperty, value);
		}
	}

	public static DependencyProperty ActionButtonProperty { get; } = DependencyProperty.Register("ActionButton", typeof(ButtonBase), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public ICommand CloseButtonCommand
	{
		get
		{
			return (ICommand)GetValue(CloseButtonCommandProperty);
		}
		set
		{
			SetValue(CloseButtonCommandProperty, value);
		}
	}

	public static DependencyProperty CloseButtonCommandProperty { get; } = DependencyProperty.Register("CloseButtonCommand", typeof(ICommand), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public object CloseButtonCommandParameter
	{
		get
		{
			return GetValue(CloseButtonCommandParameterProperty);
		}
		set
		{
			SetValue(CloseButtonCommandParameterProperty, value);
		}
	}

	public static DependencyProperty CloseButtonCommandParameterProperty { get; } = DependencyProperty.Register("CloseButtonCommandParameter", typeof(object), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public Style CloseButtonStyle
	{
		get
		{
			return (Style)GetValue(CloseButtonStyleProperty);
		}
		set
		{
			SetValue(CloseButtonStyleProperty, value);
		}
	}

	public static DependencyProperty CloseButtonStyleProperty { get; } = DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(InfoBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public object Content
	{
		get
		{
			return GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(object), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public DataTemplate ContentTemplate
	{
		get
		{
			return (DataTemplate)GetValue(ContentTemplateProperty);
		}
		set
		{
			SetValue(ContentTemplateProperty, value);
		}
	}

	public static DependencyProperty ContentTemplateProperty { get; } = DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(InfoBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


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

	public static DependencyProperty IconSourceProperty { get; } = DependencyProperty.Register("IconSource", typeof(IconSource), typeof(InfoBar), new FrameworkPropertyMetadata(null, OnIconSourcePropertyChanged));


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

	public static DependencyProperty IsClosableProperty { get; } = DependencyProperty.Register("IsClosable", typeof(bool), typeof(InfoBar), new FrameworkPropertyMetadata(true, OnIsClosablePropertyChanged));


	public bool IsIconVisible
	{
		get
		{
			return (bool)GetValue(IsIconVisibleProperty);
		}
		set
		{
			SetValue(IsIconVisibleProperty, value);
		}
	}

	public static DependencyProperty IsIconVisibleProperty { get; } = DependencyProperty.Register("IsIconVisible", typeof(bool), typeof(InfoBar), new FrameworkPropertyMetadata(true, OnIsIconVisiblePropertyChanged));


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

	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(InfoBar), new FrameworkPropertyMetadata(false, OnIsOpenPropertyChanged));


	public string Message
	{
		get
		{
			return (string)GetValue(MessageProperty);
		}
		set
		{
			SetValue(MessageProperty, value);
		}
	}

	public static DependencyProperty MessageProperty { get; } = DependencyProperty.Register("Message", typeof(string), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public InfoBarSeverity Severity
	{
		get
		{
			return (InfoBarSeverity)GetValue(SeverityProperty);
		}
		set
		{
			SetValue(SeverityProperty, value);
		}
	}

	public static DependencyProperty SeverityProperty { get; } = DependencyProperty.Register("Severity", typeof(InfoBarSeverity), typeof(InfoBar), new FrameworkPropertyMetadata(InfoBarSeverity.Informational, OnSeverityPropertyChanged));


	public InfoBarTemplateSettings TemplateSettings => (InfoBarTemplateSettings)GetValue(TemplateSettingsProperty);

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(InfoBarTemplateSettings), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public string Title
	{
		get
		{
			return (string)GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	public static DependencyProperty TitleProperty { get; } = DependencyProperty.Register("Title", typeof(string), typeof(InfoBar), new FrameworkPropertyMetadata(null));


	public event TypedEventHandler<InfoBar, object> CloseButtonClick;

	public event TypedEventHandler<InfoBar, InfoBarClosingEventArgs> Closing;

	public event TypedEventHandler<InfoBar, InfoBarClosedEventArgs> Closed;

	public InfoBar()
	{
		SetValue(TemplateSettingsProperty, new InfoBarTemplateSettings());
		_foregroundChangedCallbackRegistration = RegisterPropertyChangedCallback(Control.ForegroundProperty, OnForegroundChanged);
		base.DefaultStyleKey = typeof(InfoBar);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new InfoBarAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		m_applyTemplateCalled = true;
		Button templateChild = GetTemplateChild<Button>("CloseButton");
		if (templateChild != null)
		{
			templateChild.Click += OnCloseButtonClick;
			if (string.IsNullOrEmpty(AutomationProperties.GetName(templateChild)))
			{
				string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("InfoBarCloseButtonName");
				AutomationProperties.SetName(templateChild, localizedStringResource);
			}
			ToolTip toolTip = new ToolTip();
			string text = (string)(toolTip.Content = ResourceAccessor.GetLocalizedStringResource("InfoBarCloseButtonTooltip"));
			ToolTipService.SetToolTip(templateChild, toolTip);
		}
		FrameworkElement templateChild2 = GetTemplateChild<FrameworkElement>("StandardIcon");
		if (templateChild2 != null)
		{
			m_standardIconTextBlock = templateChild2;
			AutomationProperties.SetName(templateChild2, ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)));
		}
		Button templateChild3 = GetTemplateChild<Button>("ContentRoot");
		if (templateChild3 != null)
		{
			AutomationProperties.SetLocalizedLandmarkType(templateChild3, ResourceAccessor.GetLocalizedStringResource("InfoBarCustomLandmarkName"));
		}
		UpdateVisibility(m_notifyOpen);
		m_notifyOpen = false;
		UpdateSeverity();
		UpdateIcon();
		UpdateIconVisibility();
		UpdateCloseButton();
		UpdateForeground();
	}

	private void OnCloseButtonClick(object sender, RoutedEventArgs args)
	{
		this.CloseButtonClick?.Invoke(this, null);
		m_lastCloseReason = InfoBarCloseReason.CloseButton;
		IsOpen = false;
	}

	private void RaiseClosingEvent()
	{
		InfoBarClosingEventArgs infoBarClosingEventArgs = new InfoBarClosingEventArgs(m_lastCloseReason);
		this.Closing?.Invoke(this, infoBarClosingEventArgs);
		if (!infoBarClosingEventArgs.Cancel)
		{
			UpdateVisibility();
			RaiseClosedEvent();
		}
		else
		{
			IsOpen = true;
		}
	}

	private void RaiseClosedEvent()
	{
		InfoBarClosedEventArgs args = new InfoBarClosedEventArgs(m_lastCloseReason);
		this.Closed?.Invoke(this, args);
	}

	private void OnIsOpenPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (IsOpen)
		{
			m_lastCloseReason = InfoBarCloseReason.Programmatic;
			UpdateVisibility();
		}
		else
		{
			RaiseClosingEvent();
		}
	}

	private void OnSeverityPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateSeverity();
	}

	private void OnIconSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateIcon();
		UpdateIconVisibility();
	}

	private void OnIsIconVisiblePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateIconVisibility();
	}

	private void OnIsClosablePropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateCloseButton();
	}

	private void UpdateVisibility(bool notify = true, bool force = true)
	{
		InfoBarAutomationPeer infoBarAutomationPeer = FrameworkElementAutomationPeer.FromElement(this) as InfoBarAutomationPeer;
		if (!m_applyTemplateCalled)
		{
			m_notifyOpen = true;
		}
		else
		{
			if (!force && IsOpen == m_isVisible)
			{
				return;
			}
			if (IsOpen)
			{
				if (notify && infoBarAutomationPeer != null)
				{
					string displayString = StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("InfoBarOpenedNotification"), ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)), Title, Message);
					infoBarAutomationPeer.RaiseOpenedEvent(Severity, displayString);
				}
				VisualStateManager.GoToState(this, "InfoBarVisible", useTransitions: false);
				AutomationProperties.SetAccessibilityView(this, AccessibilityView.Control);
				m_isVisible = true;
			}
			else
			{
				if (notify && infoBarAutomationPeer != null)
				{
					string localizedStringResource = ResourceAccessor.GetLocalizedStringResource("InfoBarClosedNotification");
					infoBarAutomationPeer.RaiseClosedEvent(Severity, localizedStringResource);
				}
				VisualStateManager.GoToState(this, "InfoBarCollapsed", useTransitions: false);
				AutomationProperties.SetAccessibilityView(this, AccessibilityView.Raw);
				m_isVisible = false;
			}
		}
	}

	private void UpdateSeverity()
	{
		string stateName = "Informational";
		switch (Severity)
		{
		case InfoBarSeverity.Success:
			stateName = "Success";
			break;
		case InfoBarSeverity.Warning:
			stateName = "Warning";
			break;
		case InfoBarSeverity.Error:
			stateName = "Error";
			break;
		}
		FrameworkElement standardIconTextBlock = m_standardIconTextBlock;
		if (standardIconTextBlock != null)
		{
			AutomationProperties.SetName(standardIconTextBlock, ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)));
		}
		VisualStateManager.GoToState(this, stateName, useTransitions: false);
	}

	private void UpdateIcon()
	{
		InfoBarTemplateSettings templateSettings = TemplateSettings;
		IconSource iconSource = IconSource;
		if (iconSource != null)
		{
			templateSettings.IconElement = SharedHelpers.MakeIconElementFrom(iconSource);
		}
		else
		{
			templateSettings.IconElement = null;
		}
	}

	private void UpdateIconVisibility()
	{
		VisualStateManager.GoToState(this, (!IsIconVisible) ? "NoIconVisible" : ((IconSource != null) ? "UserIconVisible" : "StandardIconVisible"), useTransitions: false);
	}

	private void UpdateCloseButton()
	{
		VisualStateManager.GoToState(this, IsClosable ? "CloseButtonVisible" : "CloseButtonCollapsed", useTransitions: false);
	}

	private void OnForegroundChanged(DependencyObject sender, DependencyProperty args)
	{
		UpdateForeground();
	}

	private void UpdateForeground()
	{
		VisualStateManager.GoToState(this, (ReadLocalValue(Control.ForegroundProperty) == DependencyProperty.UnsetValue) ? "ForegroundNotSet" : "ForegroundSet", useTransitions: false);
	}

	private string GetSeverityLevelResourceName(InfoBarSeverity severity)
	{
		return severity switch
		{
			InfoBarSeverity.Success => "InfoBarSeveritySuccessName", 
			InfoBarSeverity.Warning => "InfoBarSeverityWarningName", 
			InfoBarSeverity.Error => "InfoBarSeverityErrorName", 
			_ => "InfoBarSeverityInformationalName", 
		};
	}

	private string GetIconSeverityLevelResourceName(InfoBarSeverity severity)
	{
		return severity switch
		{
			InfoBarSeverity.Success => "InfoBarIconSeveritySuccessName", 
			InfoBarSeverity.Warning => "InfoBarIconSeverityWarningName", 
			InfoBarSeverity.Error => "InfoBarIconSeverityErrorName", 
			_ => "InfoBarIconSeverityInformationalName", 
		};
	}

	private static void OnIconSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBar infoBar = (InfoBar)sender;
		infoBar.OnIconSourcePropertyChanged(args);
	}

	private static void OnIsClosablePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBar infoBar = (InfoBar)sender;
		infoBar.OnIsClosablePropertyChanged(args);
	}

	private static void OnIsIconVisiblePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBar infoBar = (InfoBar)sender;
		infoBar.OnIsIconVisiblePropertyChanged(args);
	}

	private static void OnIsOpenPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBar infoBar = (InfoBar)sender;
		infoBar.OnIsOpenPropertyChanged(args);
	}

	private static void OnSeverityPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		InfoBar infoBar = (InfoBar)sender;
		infoBar.OnSeverityPropertyChanged(args);
	}
}
