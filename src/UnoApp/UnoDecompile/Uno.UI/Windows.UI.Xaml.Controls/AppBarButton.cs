using System;
using DirectUI;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

public class AppBarButton : Button, ICommandBarElement, ICommandBarElement2, ICommandBarElement3, ICommandBarOverflowElement, ICommandBarLabeledElement, ISubMenuOwner
{
	private Storyboard? m_widthAdjustmentsForLabelOnRightStyleStoryboard;

	private bool m_isWithToggleButtons;

	private bool m_isWithIcons;

	private CommandBarDefaultLabelPosition m_defaultLabelPosition;

	private TextBlock? m_tpKeyboardAcceleratorTextLabel;

	private bool m_isTemplateApplied;

	private bool m_isWithKeyboardAcceleratorText;

	private double m_maxKeyboardAcceleratorTextWidth;

	private bool m_ownsToolTip;

	private CascadingMenuHelper? m_menuHelper;

	private bool m_isFlyoutClosing;

	private SerialDisposable m_flyoutOpenedHandler = new SerialDisposable();

	private SerialDisposable m_flyoutClosedHandler = new SerialDisposable();

	private SerialDisposable _contentChangedHandler = new SerialDisposable();

	private SerialDisposable _iconChangedHandler = new SerialDisposable();

	private Point m_lastFlyoutPosition;

	internal CascadingMenuHelper? MenuHelper => m_menuHelper;

	bool ISubMenuOwner.IsSubMenuOpen => base.Flyout?.IsOpen ?? false;

	ISubMenuOwner ISubMenuOwner.ParentOwner
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	bool ISubMenuOwner.IsSubMenuPositionedAbsolutely => false;

	public AppBarButtonTemplateSettings TemplateSettings
	{
		get
		{
			return (AppBarButtonTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(AppBarButtonTemplateSettings), typeof(AppBarButton), new FrameworkPropertyMetadata(null));


	public string Label
	{
		get
		{
			return (string)GetValue(LabelProperty);
		}
		set
		{
			SetValue(LabelProperty, value);
		}
	}

	public static DependencyProperty LabelProperty { get; } = DependencyProperty.Register("Label", typeof(string), typeof(AppBarButton), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(AppBarButton), new FrameworkPropertyMetadata((object)null));


	public bool IsInOverflow
	{
		get
		{
			return CommandBar.IsCommandBarElementInOverflow(this);
		}
		internal set
		{
			SetValue(IsInOverflowProperty, value);
		}
	}

	bool ICommandBarElement3.IsInOverflow
	{
		get
		{
			return IsInOverflow;
		}
		set
		{
			IsInOverflow = value;
		}
	}

	public static DependencyProperty IsInOverflowProperty { get; } = DependencyProperty.Register("IsInOverflow", typeof(bool), typeof(AppBarButton), new FrameworkPropertyMetadata(false));


	public CommandBarLabelPosition LabelPosition
	{
		get
		{
			return (CommandBarLabelPosition)GetValue(LabelPositionProperty);
		}
		set
		{
			SetValue(LabelPositionProperty, value);
		}
	}

	public static DependencyProperty LabelPositionProperty { get; } = DependencyProperty.Register("LabelPosition", typeof(CommandBarLabelPosition), typeof(AppBarButton), new FrameworkPropertyMetadata(CommandBarLabelPosition.Default));


	public bool IsCompact
	{
		get
		{
			return (bool)GetValue(IsCompactProperty);
		}
		set
		{
			SetValue(IsCompactProperty, value);
		}
	}

	public static DependencyProperty IsCompactProperty { get; } = DependencyProperty.Register("IsCompact", typeof(bool), typeof(AppBarButton), new FrameworkPropertyMetadata(false));


	public int DynamicOverflowOrder
	{
		get
		{
			return (int)GetValue(DynamicOverflowOrderProperty);
		}
		set
		{
			SetValue(DynamicOverflowOrderProperty, value);
		}
	}

	public static DependencyProperty DynamicOverflowOrderProperty { get; } = DependencyProperty.Register("DynamicOverflowOrder", typeof(int), typeof(AppBarButton), new FrameworkPropertyMetadata(0));


	internal bool UseOverflowStyle
	{
		get
		{
			return (bool)GetValue(UseOverflowStyleProperty);
		}
		set
		{
			SetValue(UseOverflowStyleProperty, value);
		}
	}

	bool ICommandBarOverflowElement.UseOverflowStyle
	{
		get
		{
			return UseOverflowStyle;
		}
		set
		{
			UseOverflowStyle = value;
		}
	}

	internal static DependencyProperty UseOverflowStyleProperty { get; } = DependencyProperty.Register("UseOverflowStyle", typeof(bool), typeof(AppBarButton), new FrameworkPropertyMetadata(false));


	public string KeyboardAcceleratorTextOverride
	{
		get
		{
			return GetKeyboardAcceleratorText();
		}
		set
		{
			PutKeyboardAcceleratorText(value);
		}
	}

	public static DependencyProperty KeyboardAcceleratorTextOverrideProperty { get; } = DependencyProperty.Register("KeyboardAcceleratorTextOverride", typeof(string), typeof(AppBarButton), new FrameworkPropertyMetadata((object)null));


	public AppBarButton()
	{
		m_isWithToggleButtons = false;
		m_isWithIcons = false;
		m_isTemplateApplied = false;
		m_ownsToolTip = true;
		m_menuHelper = new CascadingMenuHelper();
		m_menuHelper!.Initialize(this);
		base.Click += OnClick;
		base.DefaultStyleKey = typeof(AppBarButton);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		m_flyoutOpenedHandler.Disposable = null;
		m_flyoutClosedHandler.Disposable = null;
		m_menuHelper = null;
		_contentChangedHandler.Disposable = null;
		_iconChangedHandler.Disposable = null;
	}

	internal void SetOverflowStyleParams(bool hasIcons, bool hasToggleButtons, bool hasKeyboardAcceleratorText)
	{
		bool flag = false;
		if (m_isWithIcons != hasIcons)
		{
			m_isWithIcons = hasIcons;
			flag = true;
		}
		if (m_isWithToggleButtons != hasToggleButtons)
		{
			m_isWithToggleButtons = hasToggleButtons;
			flag = true;
		}
		if (m_isWithKeyboardAcceleratorText != hasKeyboardAcceleratorText)
		{
			m_isWithKeyboardAcceleratorText = hasKeyboardAcceleratorText;
			flag = true;
		}
		if (flag)
		{
			UpdateVisualState();
		}
	}

	void ICommandBarLabeledElement.SetDefaultLabelPosition(CommandBarDefaultLabelPosition defaultLabelPosition)
	{
		if (m_defaultLabelPosition != defaultLabelPosition)
		{
			m_defaultLabelPosition = defaultLabelPosition;
			UpdateInternalStyles();
			UpdateVisualState();
		}
	}

	bool ICommandBarLabeledElement.GetHasBottomLabel()
	{
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		string label = Label;
		if (effectiveLabelPosition == CommandBarDefaultLabelPosition.Bottom)
		{
			return label != null;
		}
		return false;
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		base.OnPointerEntered(args);
		bool flag = false;
		if (IsInOverflow && m_menuHelper != null)
		{
			m_menuHelper!.OnPointerEntered(args);
		}
		CloseSubMenusOnPointerEntered(this);
	}

	protected override void OnPointerExited(PointerRoutedEventArgs e)
	{
		base.OnPointerExited(e);
		bool flag = false;
		if (IsInOverflow && m_menuHelper != null)
		{
			m_menuHelper!.OnPointerExited(e, parentIsSubMenu: false);
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		bool flag = false;
		if (IsInOverflow && m_menuHelper != null)
		{
			m_menuHelper!.OnKeyDown(args);
		}
	}

	protected override void OnKeyUp(KeyRoutedEventArgs args)
	{
		base.OnKeyUp(args);
		bool flag = false;
		if (IsInOverflow && m_menuHelper != null)
		{
			m_menuHelper!.OnKeyUp(args);
		}
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == Button.FlyoutProperty)
		{
			FlyoutBase flyoutBase = args.OldValue as FlyoutBase;
			FlyoutBase newFlyout = args.NewValue as FlyoutBase;
			if (flyoutBase != null)
			{
				m_flyoutOpenedHandler.Disposable = null;
				m_flyoutClosedHandler.Disposable = null;
				m_menuHelper = null;
			}
			if (newFlyout != null)
			{
				m_menuHelper = new CascadingMenuHelper();
				m_menuHelper!.Initialize(this);
				newFlyout.Opened += OnFlyoutOpened;
				m_flyoutOpenedHandler.Disposable = Disposable.Create(delegate
				{
					newFlyout.Opened -= OnFlyoutOpened;
				});
				newFlyout.Closed += OnFlyoutClosed;
				m_flyoutClosedHandler.Disposable = Disposable.Create(delegate
				{
					newFlyout.Closed -= OnFlyoutClosed;
				});
			}
		}
		OnPropertyChanged(args);
	}

	private void OnFlyoutClosed(object? sender, object e)
	{
		m_isFlyoutClosing = false;
		UpdateVisualState();
	}

	private void OnFlyoutOpened(object? sender, object e)
	{
		m_isFlyoutClosing = false;
		UpdateVisualState();
	}

	protected override void OnApplyTemplate()
	{
		OnBeforeApplyTemplate();
		base.OnApplyTemplate();
		OnAfterApplyTemplate();
		SetupContentUpdate();
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool flag = false;
		base.ChangeVisualState(useTransitions);
		if (UseOverflowStyle)
		{
			if (m_isWithToggleButtons && m_isWithIcons)
			{
				GoToState(useTransitions, "OverflowWithToggleButtonsAndMenuIcons");
			}
			else if (m_isWithToggleButtons)
			{
				GoToState(useTransitions, "OverflowWithToggleButtons");
			}
			else if (m_isWithIcons)
			{
				GoToState(useTransitions, "OverflowWithMenuIcons");
			}
			else
			{
				GoToState(useTransitions, "Overflow");
			}
			if (m_isWithIcons)
			{
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				flag2 = base.IsEnabled;
				flag3 = base.IsPressed;
				flag4 = base.IsPointerOver;
				if (((ISubMenuOwner)this).IsSubMenuOpen && !m_isFlyoutClosing)
				{
					GoToState(useTransitions, "OverflowSubMenuOpened");
				}
				else if (flag3)
				{
					GoToState(useTransitions, "OverflowPressed");
				}
				else if (flag4)
				{
					GoToState(useTransitions, "OverflowPointerOver");
				}
				else if (flag2)
				{
					GoToState(useTransitions, "OverflowNormal");
				}
			}
		}
		FlyoutBase flyout = base.Flyout;
		if (flyout != null)
		{
			GoToState(useTransitions, "HasFlyout");
		}
		else
		{
			GoToState(useTransitions, "NoFlyout");
		}
		ChangeCommonVisualStates(useTransitions);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new AppBarButtonAutomationPeer(this);
	}

	private void OnClick(object sender, RoutedEventArgs e)
	{
		FlyoutBase flyout = base.Flyout;
		if (flyout == null)
		{
			CommandBar.OnCommandExecutionStatic(this);
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		CommandBar.OnCommandBarElementVisibilityChanged(this);
	}

	private protected override void OnCommandChanged(object oldValue, object newValue)
	{
		base.OnCommandChanged(oldValue, newValue);
		OnCommandChangedHelper(oldValue, newValue);
	}

	private protected override void OpenAssociatedFlyout()
	{
		bool flag = false;
		flag = IsInOverflow;
		if (m_menuHelper != null && flag)
		{
			m_menuHelper!.OpenSubMenu();
		}
		else
		{
			base.OpenAssociatedFlyout();
		}
	}

	private CommandBarDefaultLabelPosition GetEffectiveLabelPosition()
	{
		CommandBarLabelPosition labelPosition = LabelPosition;
		if (labelPosition != CommandBarLabelPosition.Collapsed)
		{
			return m_defaultLabelPosition;
		}
		return CommandBarDefaultLabelPosition.Collapsed;
	}

	private void UpdateInternalStyles()
	{
		if (!m_isTemplateApplied)
		{
			return;
		}
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		bool useOverflowStyle = UseOverflowStyle;
		bool flag = effectiveLabelPosition == CommandBarDefaultLabelPosition.Right && !useOverflowStyle;
		if (flag && !this.IsDependencyPropertyLocallySet(FrameworkElement.WidthProperty))
		{
			if (m_widthAdjustmentsForLabelOnRightStyleStoryboard == null)
			{
				Storyboard storyboard = (m_widthAdjustmentsForLabelOnRightStyleStoryboard = CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle());
			}
			StartAnimationForWidthAdjustments();
		}
		else if (!flag && m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			StopAnimationForWidthAdjustments();
		}
		UpdateToolTip();
	}

	private Storyboard CreateStoryboardForWidthAdjustmentsForLabelOnRightStyle()
	{
		Storyboard storyboard = new Storyboard();
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
		Storyboard.SetTarget(objectAnimationUsingKeyFrames, this);
		Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames, "Width");
		DiscreteObjectKeyFrame discreteObjectKeyFrame = new DiscreteObjectKeyFrame();
		KeyTime keyTime2 = (discreteObjectKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero));
		discreteObjectKeyFrame.Value = double.NaN;
		objectAnimationUsingKeyFrames.KeyFrames.Add(discreteObjectKeyFrame);
		storyboard.Children.Add(objectAnimationUsingKeyFrames);
		return storyboard;
	}

	private void StartAnimationForWidthAdjustments()
	{
		if (m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			StopAnimationForWidthAdjustments();
			m_widthAdjustmentsForLabelOnRightStyleStoryboard!.Begin();
			m_widthAdjustmentsForLabelOnRightStyleStoryboard!.SkipToFill();
		}
	}

	private void StopAnimationForWidthAdjustments()
	{
		if (m_widthAdjustmentsForLabelOnRightStyleStoryboard != null)
		{
			ClockState currentState = m_widthAdjustmentsForLabelOnRightStyleStoryboard!.GetCurrentState();
			if (currentState == ClockState.Active || currentState == ClockState.Filling)
			{
				m_widthAdjustmentsForLabelOnRightStyleStoryboard!.Stop();
			}
		}
	}

	void ISubMenuOwner.PrepareSubMenu()
	{
		FlyoutBase flyout = base.Flyout;
		if (flyout == null)
		{
			return;
		}
		UIElement uIElement = (UIElement)(flyout.OverlayInputPassThroughElement = Window.Current.Content);
		if (flyout is IMenu menu)
		{
			CommandBar.FindParentCommandBarForElement(this, out var parentCmdBar);
			if (parentCmdBar != null)
			{
				menu.ParentMenu = parentCmdBar;
			}
		}
	}

	void ISubMenuOwner.OpenSubMenu(Point position)
	{
		FlyoutBase flyout = base.Flyout;
		if (flyout != null)
		{
			FlyoutShowOptions flyoutShowOptions = new FlyoutShowOptions();
			if (!IsInOverflow)
			{
				return;
			}
			flyoutShowOptions.Placement = FlyoutPlacementMode.RightEdgeAlignedTop;
			double actualWidth = base.ActualWidth;
			flyoutShowOptions.Position = position;
			flyout.ShowAt(this, flyoutShowOptions);
			if (m_menuHelper != null)
			{
				m_menuHelper!.SetSubMenuPresenter(flyout.GetPresenter());
			}
		}
		m_lastFlyoutPosition = position;
	}

	void ISubMenuOwner.PositionSubMenu(Point position)
	{
		((ISubMenuOwner)this).CloseSubMenu();
		if (double.IsNegativeInfinity(position.X))
		{
			position.X = m_lastFlyoutPosition.X;
		}
		if (double.IsNegativeInfinity(position.Y))
		{
			position.Y = m_lastFlyoutPosition.Y;
		}
		((ISubMenuOwner)this).OpenSubMenu(position);
	}

	void ISubMenuOwner.ClosePeerSubMenus()
	{
		CommandBar.FindParentCommandBarForElement(this, out var parentCmdBar);
		parentCmdBar?.CloseSubMenus(this, closeOnDelay: false);
	}

	void ISubMenuOwner.CloseSubMenu()
	{
		FlyoutBase flyout = base.Flyout;
		if (flyout != null)
		{
			flyout.Hide();
			m_isFlyoutClosing = true;
			UpdateVisualState();
		}
	}

	void ISubMenuOwner.CloseSubMenuTree()
	{
		if (m_menuHelper != null)
		{
			m_menuHelper!.CloseChildSubMenus();
		}
	}

	void ISubMenuOwner.DelayCloseSubMenu()
	{
		if (m_menuHelper != null)
		{
			m_menuHelper!.DelayCloseSubMenu();
		}
	}

	void ISubMenuOwner.CancelCloseSubMenu()
	{
		if (m_menuHelper != null)
		{
			m_menuHelper!.CancelCloseSubMenu();
		}
	}

	void ISubMenuOwner.RaiseAutomationPeerExpandCollapse(bool isOpen)
	{
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			AutomationPeer automationPeer = GetAutomationPeer();
			if (automationPeer is AppBarButtonAutomationPeer appBarButtonAutomationPeer)
			{
				appBarButtonAutomationPeer.RaiseExpandCollapseAutomationEvent(isOpen);
			}
		}
	}

	private void OnBeforeApplyTemplate()
	{
		if (m_isTemplateApplied)
		{
			StopAnimationForWidthAdjustments();
			m_isTemplateApplied = false;
		}
	}

	private void OnAfterApplyTemplate()
	{
		GetTemplatePart<TextBlock>("KeyboardAcceleratorTextLabel", out var element);
		m_tpKeyboardAcceleratorTextLabel = element;
		m_isTemplateApplied = true;
		UpdateInternalStyles();
		UpdateVisualState();
	}

	private void CloseSubMenusOnPointerEntered(ISubMenuOwner pMenuToLeaveOpen)
	{
		if (IsInOverflow)
		{
			CommandBar.FindParentCommandBarForElement(this, out var parentCmdBar);
			parentCmdBar?.CloseSubMenus(pMenuToLeaveOpen, closeOnDelay: true);
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsCompactProperty || args.Property == UseOverflowStyleProperty || args.Property == LabelPositionProperty)
		{
			UpdateInternalStyles();
			UpdateVisualState();
		}
		if (args.Property == ToolTipService.ToolTipProperty)
		{
			object value = GetValue(ToolTipService.ToolTipProperty);
			if (value != null)
			{
				m_ownsToolTip = false;
			}
			else
			{
				m_ownsToolTip = true;
			}
		}
	}

	private void ChangeCommonVisualStates(bool useTransitions)
	{
		bool isCompact = IsCompact;
		bool useOverflowStyle = UseOverflowStyle;
		CommandBarDefaultLabelPosition effectiveLabelPosition = GetEffectiveLabelPosition();
		bool flag = false;
		if (m_isWithKeyboardAcceleratorText)
		{
			flag = true;
		}
		if (!useOverflowStyle)
		{
			switch (effectiveLabelPosition)
			{
			case CommandBarDefaultLabelPosition.Right:
				GoToState(useTransitions, "LabelOnRight");
				break;
			case CommandBarDefaultLabelPosition.Collapsed:
				GoToState(useTransitions, "LabelCollapsed");
				break;
			default:
				if (isCompact)
				{
					GoToState(useTransitions, "Compact");
				}
				else
				{
					GoToState(useTransitions, "FullSize");
				}
				break;
			}
		}
		GoToState(useTransitions, "InputModeDefault");
		if (m_isWithKeyboardAcceleratorText && flag && useOverflowStyle)
		{
			GoToState(useTransitions, "KeyboardAcceleratorTextVisible");
		}
		else
		{
			GoToState(useTransitions, "KeyboardAcceleratorTextCollapsed");
		}
	}

	private void OnCommandChangedHelper(object pOldValue, object pNewValue)
	{
		if (pOldValue != null && pOldValue is XamlUICommand uiCommand)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, LabelProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, IconProperty);
		}
		if (pNewValue != null && pNewValue is XamlUICommand uiCommand2)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand2, this, ContentControl.ContentProperty);
			CommandingHelpers.BindToLabelPropertyIfUnset(uiCommand2, this, LabelProperty);
			CommandingHelpers.BindToIconPropertyIfUnset(uiCommand2, this, IconProperty);
		}
	}

	internal void UpdateTemplateSettings(double maxKeyboardAcceleratorTextWidth)
	{
		if (m_maxKeyboardAcceleratorTextWidth != maxKeyboardAcceleratorTextWidth)
		{
			m_maxKeyboardAcceleratorTextWidth = maxKeyboardAcceleratorTextWidth;
			AppBarButtonTemplateSettings appBarButtonTemplateSettings = TemplateSettings;
			if (appBarButtonTemplateSettings == null)
			{
				appBarButtonTemplateSettings = (TemplateSettings = new AppBarButtonTemplateSettings());
			}
			appBarButtonTemplateSettings.KeyboardAcceleratorTextMinWidth = m_maxKeyboardAcceleratorTextWidth;
		}
	}

	private void UpdateToolTip()
	{
		if (m_ownsToolTip)
		{
			bool useOverflowStyle = UseOverflowStyle;
			string keyboardAcceleratorTextOverride = KeyboardAcceleratorTextOverride;
			if (!useOverflowStyle && !string.IsNullOrWhiteSpace(keyboardAcceleratorTextOverride))
			{
				string label = Label;
				string localizedResourceString = DXamlCore.Current.GetLocalizedResourceString("KEYBOARD_ACCELERATOR_TEXT_TOOLTIP");
				SetValue(ToolTipService.ToolTipProperty, string.Format(localizedResourceString, label, keyboardAcceleratorTextOverride));
			}
			else
			{
				ClearValue(ToolTipService.ToolTipProperty);
			}
			m_ownsToolTip = true;
		}
	}

	internal Size GetKeyboardAcceleratorTextDesiredSize()
	{
		Size result = new Size(0.0, 0.0);
		if (m_tpKeyboardAcceleratorTextLabel != null)
		{
			m_tpKeyboardAcceleratorTextLabel!.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			result = m_tpKeyboardAcceleratorTextLabel!.DesiredSize;
			Thickness margin = m_tpKeyboardAcceleratorTextLabel!.Margin;
			result.Width -= margin.Left + margin.Right;
			result.Height -= margin.Top + margin.Bottom;
		}
		return result;
	}

	private string GetKeyboardAcceleratorText()
	{
		string text = GetValue(KeyboardAcceleratorTextOverrideProperty) as string;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = KeyboardAccelerator.GetStringRepresentationForUIElement(this);
			if (!string.IsNullOrWhiteSpace(text))
			{
				PutKeyboardAcceleratorText(text);
			}
		}
		return text ?? string.Empty;
	}

	private void SetupContentUpdate()
	{
		GetTemplatePart<ContentPresenter>("Content", out var contentPresenter);
		_contentChangedHandler.Disposable = this.RegisterDisposablePropertyChangedCallback(ContentControl.ContentProperty, delegate
		{
			UpdateContent();
		});
		_iconChangedHandler.Disposable = this.RegisterDisposablePropertyChangedCallback(IconProperty, delegate
		{
			UpdateContent();
		});
		UpdateContent();
		void UpdateContent()
		{
			if (contentPresenter != null)
			{
				contentPresenter.Content = Icon ?? Content;
			}
		}
	}

	private void PutKeyboardAcceleratorText(string keyboardAcceleratorText)
	{
		SetValue(KeyboardAcceleratorTextOverrideProperty, keyboardAcceleratorText);
	}

	private void GetTemplatePart<T>(string name, out T? element) where T : class
	{
		element = GetTemplateChild(name) as T;
	}
}
