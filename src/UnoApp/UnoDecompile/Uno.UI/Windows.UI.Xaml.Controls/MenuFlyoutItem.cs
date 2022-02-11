using System;
using System.Windows.Input;
using Uno.Client;
using Uno.Disposables;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class MenuFlyoutItem : MenuFlyoutItemBase
{
	private bool m_bIsPointerOver = true;

	internal bool m_bIsPressed = true;

	internal bool m_bIsPointerLeftButtonDown = true;

	internal bool m_bIsSpaceOrEnterKeyDown = true;

	internal bool m_bIsNavigationAcceptOrGamepadAKeyDown = true;

	private bool m_shouldPerformActions = true;

	private IDisposable m_epCanExecuteChangedHandler;

	private double m_maxKeyboardAcceleratorTextWidth;

	private TextBlock m_tpKeyboardAcceleratorTextBlock;

	private bool m_isTemplateApplied;

	public object CommandParameter
	{
		get
		{
			return GetValue(CommandParameterProperty);
		}
		set
		{
			SetValue(CommandParameterProperty, value);
		}
	}

	public static DependencyProperty CommandParameterProperty { get; } = DependencyProperty.Register("CommandParameter", typeof(object), typeof(MenuFlyoutItem), new FrameworkPropertyMetadata((object)null));


	public ICommand Command
	{
		get
		{
			return (ICommand)GetValue(CommandProperty);
		}
		set
		{
			SetValue(CommandProperty, value);
		}
	}

	public static DependencyProperty CommandProperty { get; } = DependencyProperty.Register("Command", typeof(ICommand), typeof(MenuFlyoutItem), new FrameworkPropertyMetadata((object)null));


	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(MenuFlyoutItem), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(MenuFlyoutItem), new FrameworkPropertyMetadata((object)null));


	public string KeyboardAcceleratorTextOverride
	{
		get
		{
			return (string)GetValue(KeyboardAcceleratorTextOverrideProperty);
		}
		set
		{
			SetValue(KeyboardAcceleratorTextOverrideProperty, value);
		}
	}

	public static DependencyProperty KeyboardAcceleratorTextOverrideProperty { get; } = DependencyProperty.Register("KeyboardAcceleratorTextOverride", typeof(string), typeof(MenuFlyoutItem), new FrameworkPropertyMetadata((object)null));


	public MenuFlyoutItemTemplateSettings TemplateSettings { get; internal set; }

	internal string KeyboardAcceleratorTextOverrideImpl
	{
		get
		{
			string text = KeyboardAcceleratorTextOverride;
			if (text == null)
			{
				text = KeyboardAccelerator.GetStringRepresentationForUIElement(this);
				if (text != null)
				{
					KeyboardAcceleratorTextOverrideImpl = text;
				}
			}
			return text;
		}
		set
		{
			KeyboardAcceleratorTextOverride = value;
		}
	}

	public event RoutedEventHandler Click;

	internal void InvokeClick()
	{
		this.Click?.Invoke(this, new RoutedEventArgs(this));
		Command.ExecuteIfPossible(CommandParameter);
	}

	public MenuFlyoutItem()
	{
		m_bIsPointerOver = false;
		m_bIsPressed = false;
		m_bIsPointerLeftButtonDown = false;
		m_bIsSpaceOrEnterKeyDown = false;
		m_bIsNavigationAcceptOrGamepadAKeyDown = false;
		m_shouldPerformActions = false;
		base.DefaultStyleKey = typeof(MenuFlyoutItem);
		Initialize();
	}

	private void Initialize()
	{
		base.Loaded += delegate
		{
			ClearStateFlags();
		};
		this.RegisterDisposablePropertyChangedCallback(delegate(ManagedWeakReference s, DependencyProperty e, DependencyPropertyChangedEventArgs args)
		{
			OnPropertyChanged2(args);
		});
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		TextBlock textBlock = (m_tpKeyboardAcceleratorTextBlock = GetTemplateChild("KeyboardAcceleratorTextBlock") as TextBlock);
		SuppressIsEnabled(suppress: false);
		UpdateCanExecute();
		UpdateVisualState();
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerPressed(pArgs);
		if (!pArgs.Handled)
		{
			PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
			PointerPointProperties properties = currentPoint.Properties;
			if (properties.IsLeftButtonPressed)
			{
				m_bIsPointerLeftButtonDown = true;
				m_bIsPressed = true;
				pArgs.Handled = true;
				UpdateVisualState();
			}
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerReleased(pArgs);
		bool flag = false;
		if (!pArgs.Handled)
		{
			m_bIsPointerLeftButtonDown = false;
			m_shouldPerformActions = m_bIsPressed && !m_bIsSpaceOrEnterKeyDown && !m_bIsNavigationAcceptOrGamepadAKeyDown;
			PerformPointerUpAction();
		}
	}

	private protected override void OnRightTappedUnhandled(RightTappedRoutedEventArgs pArgs)
	{
		if (!pArgs.Handled)
		{
			PerformPointerUpAction();
			pArgs.Handled = true;
		}
	}

	private void PerformPointerUpAction()
	{
		if (m_shouldPerformActions)
		{
			Focus(FocusState.Pointer);
			Invoke();
		}
	}

	internal virtual void Invoke()
	{
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Click?.Invoke(this, routedEventArgs);
		ExecuteCommand();
		if (0 == 0)
		{
			MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
			if (parentMenuFlyoutPresenter != null)
			{
				IMenu owningMenu = ((IMenuPresenter)parentMenuFlyoutPresenter).OwningMenu;
				if (owningMenu != null)
				{
					((IMenuPresenter)parentMenuFlyoutPresenter).CloseSubMenu();
					owningMenu.Close();
				}
			}
		}
		ElementSoundPlayer.RequestInteractionSoundForElement(ElementSoundKind.Invoke, this);
	}

	private void ExecuteCommand()
	{
		ICommand command = Command;
		if (command != null)
		{
			object commandParameter = CommandParameter;
			if (command.CanExecute(commandParameter))
			{
				command.Execute(commandParameter);
			}
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerEntered(pArgs);
		m_bIsPointerOver = true;
		((IMenuPresenter)GetParentMenuFlyoutPresenter())?.SubPresenter?.Owner?.DelayCloseSubMenu();
		UpdateVisualState();
	}

	protected override void OnPointerExited(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerExited(pArgs);
		m_bIsPressed = false;
		m_bIsPointerLeftButtonDown = false;
		m_bIsPointerOver = false;
		UpdateVisualState();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerCaptureLost(pArgs);
		m_bIsPressed = false;
		m_bIsPointerLeftButtonDown = false;
		m_bIsPointerOver = false;
		UpdateVisualState();
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		if (!e.NewValue)
		{
			ClearStateFlags();
		}
		else
		{
			UpdateVisualState();
		}
		base.OnIsEnabledChanged(e);
	}

	protected override void OnGotFocus(RoutedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	protected override void OnLostFocus(RoutedEventArgs pArgs)
	{
		if (!m_bIsPointerLeftButtonDown)
		{
			m_bIsSpaceOrEnterKeyDown = false;
			m_bIsNavigationAcceptOrGamepadAKeyDown = false;
			m_bIsPressed = false;
		}
		UpdateVisualState();
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		if (!pArgs.Handled)
		{
			VirtualKey key = pArgs.Key;
			bool flag2 = (pArgs.Handled = KeyPressMenuFlyout.KeyDown(key, this));
		}
	}

	protected override void OnKeyUp(KeyRoutedEventArgs pArgs)
	{
		if (!pArgs.Handled)
		{
			VirtualKey key = pArgs.Key;
			KeyPressMenuFlyout.KeyUp(key, this);
			pArgs.Handled = true;
		}
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == UIElement.VisibilityProperty)
		{
			OnVisibilityChanged();
		}
		else if (args.Property == CommandProperty)
		{
			OnCommandChanged(args.OldValue, args.NewValue);
		}
		else if (args.Property == CommandParameterProperty)
		{
			UpdateCanExecute();
		}
	}

	private void OnVisibilityChanged()
	{
		if (base.Visibility != 0)
		{
			ClearStateFlags();
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (m_epCanExecuteChangedHandler != null)
		{
			return;
		}
		ICommand spCommand = Command;
		if (spCommand != null)
		{
			spCommand.CanExecuteChanged += new EventHandler(OnCanExecuteChanged);
			m_epCanExecuteChangedHandler = Disposable.Create(delegate
			{
				spCommand.CanExecuteChanged -= new EventHandler(OnCanExecuteChanged);
			});
		}
		UpdateCanExecute();
		void OnCanExecuteChanged(object sender, object args)
		{
			UpdateCanExecute();
		}
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		if (m_epCanExecuteChangedHandler != null)
		{
			ICommand command = Command;
			if (command != null)
			{
				m_epCanExecuteChangedHandler.Dispose();
			}
		}
	}

	private void OnCommandChanged(object pOldValue, object pNewValue)
	{
		m_epCanExecuteChangedHandler?.Dispose();
		if (pOldValue != null && pOldValue is XamlUICommand uiCommand)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, TextProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, IconProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, UIElement.KeyboardAcceleratorsProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, UIElement.AccessKeyProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, AutomationProperties.HelpTextProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, ToolTipService.ToolTipProperty);
		}
		if (pNewValue != null)
		{
			ICommand spNewCommand = pNewValue as ICommand;
			spNewCommand.CanExecuteChanged += new EventHandler(OnCanExecuteUpdated);
			m_epCanExecuteChangedHandler = Disposable.Create(delegate
			{
				spNewCommand.CanExecuteChanged -= new EventHandler(OnCanExecuteUpdated);
			});
			if (spNewCommand is XamlUICommand uiCommand2)
			{
				CommandingHelpers.BindToLabelPropertyIfUnset(uiCommand2, this, TextProperty);
				CommandingHelpers.BindToIconPropertyIfUnset(uiCommand2, this, IconProperty);
				CommandingHelpers.BindToKeyboardAcceleratorsIfUnset(uiCommand2, this);
				CommandingHelpers.BindToAccessKeyIfUnset(uiCommand2, this);
				CommandingHelpers.BindToDescriptionPropertiesIfUnset(uiCommand2, this);
			}
		}
		UpdateCanExecute();
		void OnCanExecuteUpdated(object sender, object args)
		{
			UpdateCanExecute();
		}
	}

	private void UpdateCanExecute()
	{
		bool flag = true;
		ICommand command = Command;
		if (command != null)
		{
			object commandParameter = CommandParameter;
			flag = command.CanExecute(commandParameter);
		}
		SuppressIsEnabled(!flag);
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			flag = parentMenuFlyoutPresenter.GetContainsToggleItems();
			flag2 = parentMenuFlyoutPresenter.GetContainsIconItems();
			flag3 = parentMenuFlyoutPresenter.GetContainsItemsWithKeyboardAcceleratorText();
		}
		bool isEnabled = base.IsEnabled;
		FocusState focusState = base.FocusState;
		bool shouldBeNarrow = GetShouldBeNarrow();
		if (flag3)
		{
			flag4 = true;
		}
		if (!isEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", bUseTransitions);
		}
		else if (m_bIsPressed)
		{
			VisualStateManager.GoToState(this, "Pressed", bUseTransitions);
		}
		else if (m_bIsPointerOver)
		{
			VisualStateManager.GoToState(this, "PointerOver", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", bUseTransitions);
		}
		if (focusState != FocusState.Unfocused && isEnabled)
		{
			if (FocusState.Pointer == focusState)
			{
				VisualStateManager.GoToState(this, "PointerFocused", bUseTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "Focused", bUseTransitions);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "Unfocused", bUseTransitions);
		}
		if (flag && flag2)
		{
			VisualStateManager.GoToState(this, "CheckAndIconPlaceholder", bUseTransitions);
		}
		else if (flag)
		{
			VisualStateManager.GoToState(this, "CheckPlaceholder", bUseTransitions);
		}
		else if (flag2)
		{
			VisualStateManager.GoToState(this, "IconPlaceholder", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "NoPlaceholder", bUseTransitions);
		}
		if (shouldBeNarrow)
		{
			VisualStateManager.GoToState(this, "NarrowPadding", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "DefaultPadding", bUseTransitions);
		}
		if (flag3 && flag4)
		{
			VisualStateManager.GoToState(this, "KeyboardAcceleratorTextVisible", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "KeyboardAcceleratorTextCollapsed", bUseTransitions);
		}
	}

	private void ClearStateFlags()
	{
		m_bIsPressed = false;
		m_bIsPointerLeftButtonDown = false;
		m_bIsPointerOver = false;
		m_bIsSpaceOrEnterKeyDown = false;
		m_bIsNavigationAcceptOrGamepadAKeyDown = false;
		UpdateVisualState();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new MenuFlyoutItemAutomationPeer(this);
	}

	private string GetPlainText()
	{
		return Text;
	}

	internal Size GetKeyboardAcceleratorTextDesiredSize()
	{
		Size result = new Size(0.0, 0.0);
		if (!m_isTemplateApplied)
		{
			bool flag = (m_isTemplateApplied = ApplyTemplate());
		}
		if (m_tpKeyboardAcceleratorTextBlock != null)
		{
			m_tpKeyboardAcceleratorTextBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			result = m_tpKeyboardAcceleratorTextBlock.DesiredSize;
			Thickness margin = m_tpKeyboardAcceleratorTextBlock.Margin;
			result.Width -= (float)(margin.Left + margin.Right);
			result.Height -= (float)(margin.Top + margin.Bottom);
		}
		return result;
	}

	internal void UpdateTemplateSettings(double maxKeyboardAcceleratorTextWidth)
	{
		if (m_maxKeyboardAcceleratorTextWidth != maxKeyboardAcceleratorTextWidth)
		{
			m_maxKeyboardAcceleratorTextWidth = maxKeyboardAcceleratorTextWidth;
			MenuFlyoutItemTemplateSettings menuFlyoutItemTemplateSettings = TemplateSettings;
			if (menuFlyoutItemTemplateSettings == null)
			{
				MenuFlyoutItemTemplateSettings menuFlyoutItemTemplateSettings3 = (TemplateSettings = new MenuFlyoutItemTemplateSettings());
				menuFlyoutItemTemplateSettings = menuFlyoutItemTemplateSettings3;
			}
			menuFlyoutItemTemplateSettings.KeyboardAcceleratorTextMinWidth = m_maxKeyboardAcceleratorTextWidth;
		}
	}

	internal virtual bool HasToggle()
	{
		return false;
	}
}
