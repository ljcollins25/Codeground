using System;
using System.Windows.Input;
using Uno.Client;
using Uno.Disposables;
using Uno.Foundation.Logging;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class ButtonBase : ContentControl
{
	private static class KeyProcess
	{
		internal static bool IsPress(VirtualKey key, bool acceptsReturn)
		{
			if (key != VirtualKey.Space && !(key == VirtualKey.Enter && acceptsReturn))
			{
				return key == VirtualKey.GamepadA;
			}
			return true;
		}

		internal static void KeyDown(VirtualKey key, out bool handled, bool acceptsReturn, ButtonBase control)
		{
			handled = false;
			bool isEnabled = control.IsEnabled;
			ClickMode clickMode = control.ClickMode;
			if (!isEnabled || clickMode == ClickMode.Hover)
			{
				return;
			}
			if (IsPress(key, acceptsReturn))
			{
				if (!control._isPointerCaptured && !control._isSpaceOrEnterKeyDown && !control._isNavigationAcceptOrGamepadAKeyDown)
				{
					if (key == VirtualKey.Space || (key == VirtualKey.Enter && acceptsReturn))
					{
						control._isSpaceOrEnterKeyDown = true;
					}
					else if (key == VirtualKey.GamepadA)
					{
						control._isNavigationAcceptOrGamepadAKeyDown = true;
					}
					control.IsPressed = true;
					if (control.ClickMode == ClickMode.Press)
					{
						control.OnClick();
					}
					handled = true;
					KeyPress.StartFocusPress(control);
				}
			}
			else if (control._isSpaceOrEnterKeyDown || control._isNavigationAcceptOrGamepadAKeyDown)
			{
				control.IsPressed = false;
				control._isSpaceOrEnterKeyDown = false;
				control._isNavigationAcceptOrGamepadAKeyDown = false;
			}
		}

		internal static void KeyUp(VirtualKey key, out bool handled, bool acceptsReturn, ButtonBase control)
		{
			handled = false;
			bool isEnabled = control.IsEnabled;
			ClickMode clickMode = control.ClickMode;
			if (!isEnabled || clickMode == ClickMode.Hover || !IsPress(key, acceptsReturn))
			{
				return;
			}
			if (key == VirtualKey.Space || (key == VirtualKey.Enter && acceptsReturn))
			{
				control._isSpaceOrEnterKeyDown = false;
			}
			else if (key == VirtualKey.GamepadA)
			{
				control._isNavigationAcceptOrGamepadAKeyDown = false;
			}
			if (!control._isPointerLeftButtonDown)
			{
				if (control.IsPressed && clickMode == ClickMode.Release)
				{
					control.OnClick();
				}
				control.IsPressed = false;
			}
			handled = true;
			KeyPress.EndFocusPress(control);
		}
	}

	private readonly SerialDisposable _commandCanExecute = new SerialDisposable();

	private Point _pointerPosition = Point.Zero;

	private bool _isSpaceOrEnterKeyDown;

	private bool _isNavigationAcceptOrGamepadAKeyDown;

	private bool _isPointerLeftButtonDown;

	private bool _keyboardNavigationAcceptsReturn;

	private bool _shouldPerformActions;

	private bool _handlesKeyboardInput = true;

	private readonly SerialDisposable _canExecuteChangedHandler = new SerialDisposable();

	private Pointer? _pointerForPendingRightTapped;

	private bool _isPointerCaptured;

	public new bool IsPointerOver
	{
		get
		{
			return base.IsPointerOver;
		}
		set
		{
			base.IsPointerOver = value;
		}
	}

	public static DependencyProperty CommandProperty { get; }

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

	public static DependencyProperty CommandParameterProperty { get; }

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

	public ClickMode ClickMode
	{
		get
		{
			return (ClickMode)GetValue(ClickModeProperty);
		}
		set
		{
			SetValue(ClickModeProperty, value);
		}
	}

	public new bool IsPressed
	{
		get
		{
			return (bool)GetValue(IsPressedProperty);
		}
		internal set
		{
			SetValue(IsPressedProperty, value);
		}
	}

	public static DependencyProperty ClickModeProperty { get; }

	public static DependencyProperty IsPointerOverProperty { get; }

	public static DependencyProperty IsPressedProperty { get; }

	public override UIElement ContentTemplateRoot
	{
		get
		{
			return base.ContentTemplateRoot;
		}
		protected set
		{
			base.ContentTemplateRoot = value;
		}
	}

	public event RoutedEventHandler Click;

	static ButtonBase()
	{
		CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(ButtonBase), new FrameworkPropertyMetadata((object)null));
		CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(ButtonBase), new FrameworkPropertyMetadata(null, OnCommandParameterChanged));
		ClickModeProperty = DependencyProperty.Register("ClickMode", typeof(ClickMode), typeof(ButtonBase), new FrameworkPropertyMetadata(ClickMode.Release));
		IsPointerOverProperty = DependencyProperty.Register("IsPointerOver", typeof(bool), typeof(ButtonBase), new FrameworkPropertyMetadata(false));
		IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(ButtonBase), new FrameworkPropertyMetadata(false));
		Control.IsEnabledProperty.OverrideMetadata(typeof(ButtonBase), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)null, (CoerceValueCallback)CoerceIsEnabled));
	}

	public ButtonBase()
	{
		Initialize();
		InitializeProperties();
		base.Unloaded += delegate
		{
			IsPressed = false;
		};
		base.DefaultStyleKey = typeof(ButtonBase);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
	}

	private void InitializeProperties()
	{
		PartialInitializeProperties();
	}

	private void PartialInitializeProperties()
	{
		base.Tapped += delegate
		{
		};
	}

	private static void OnCommandParameterChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		((ButtonBase)dependencyObject)?.CoerceValue(Control.IsEnabledProperty);
	}

	private void OnCanExecuteChanged()
	{
		this.CoerceValue(Control.IsEnabledProperty);
	}

	private static object CoerceIsEnabled(DependencyObject dependencyObject, object baseValue)
	{
		if (dependencyObject is ButtonBase buttonBase && buttonBase.Command != null && !buttonBase.Command.CanExecute(buttonBase.CommandParameter))
		{
			return false;
		}
		return baseValue;
	}

	internal override bool IsViewHit()
	{
		return true;
	}

	internal void RaiseClick(PointerRoutedEventArgs args = null)
	{
		OnClick();
	}

	internal void AutomationPeerClick()
	{
		OnClick();
	}

	private void OnClick(PointerRoutedEventArgs args = null)
	{
		this.Click?.Invoke(this, new RoutedEventArgs(args?.OriginalSource ?? this));
		InvokeCommand();
	}

	internal void InvokeCommand()
	{
		try
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Executing command");
			}
			Command.ExecuteIfPossible(CommandParameter);
		}
		catch (Exception ex)
		{
			this.Log().Error("Failed to execute command", ex);
		}
	}

	private void OnKeyDown(object sender, KeyRoutedEventArgs args)
	{
		if (!base.IsEnabled || ClickMode == ClickMode.Hover)
		{
			return;
		}
		if (IsPressKey(args.Key))
		{
			if (!base.HasPointerCapture)
			{
				IsPressed = true;
				if (ClickMode == ClickMode.Press)
				{
					OnClick();
				}
				args.Handled = true;
			}
		}
		else
		{
			IsPressed = false;
		}
	}

	private void OnKeyUp(object sender, KeyRoutedEventArgs args)
	{
		if (!base.IsEnabled || ClickMode == ClickMode.Hover || !IsPressKey(args.Key))
		{
			return;
		}
		if (!base.HasPointerCapture)
		{
			if (IsPressed && ClickMode == ClickMode.Release)
			{
				OnClick();
			}
			IsPressed = false;
		}
		args.Handled = true;
	}

	private bool IsPressKey(VirtualKey key)
	{
		if (key != VirtualKey.Space && key != VirtualKey.Enter && key != VirtualKey.Execute)
		{
			return key == VirtualKey.GamepadA;
		}
		return true;
	}

	private protected virtual void Initialize()
	{
		SetAcceptsReturn(value: true);
		base.Loaded += OnLoaded;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == ClickModeProperty)
		{
			OnClickModeChanged((ClickMode)args.NewValue);
		}
		else if (args.Property == IsPressedProperty)
		{
			OnIsPressedChanged();
		}
		else if (args.Property == CommandProperty)
		{
			OnCommandChanged(args.OldValue, args.NewValue);
		}
		else if (args.Property == CommandParameterProperty)
		{
			UpdateCanExecute();
		}
		else if (args.Property == UIElement.VisibilityProperty)
		{
			OnVisibilityChanged();
		}
	}

	private void OnClickModeChanged(ClickMode newClickMode)
	{
		if (!Enum.IsDefined(typeof(ClickMode), newClickMode))
		{
			throw new ArgumentException("Invalid ClickMode set.", "newClickMode");
		}
	}

	private void OnIsPressedChanged()
	{
		UpdateVisualState();
	}

	private void OnVisibilityChanged()
	{
		if (base.Visibility != 0)
		{
			ClearStateFlags();
		}
		UpdateVisualState();
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		if (!base.IsEnabled)
		{
			ClearStateFlags();
		}
		UpdateVisualState();
	}

	private void EnterImpl()
	{
		if (_canExecuteChangedHandler.Disposable != null)
		{
			return;
		}
		ICommand command = Command;
		if (command != null)
		{
			command.CanExecuteChanged += new EventHandler(CanExecuteChangedHandler);
			_canExecuteChangedHandler.Disposable = Disposable.Create(delegate
			{
				command.CanExecuteChanged -= new EventHandler(CanExecuteChangedHandler);
			});
		}
		UpdateCanExecute();
		void CanExecuteChangedHandler(object? sender, object args)
		{
			UpdateCanExecute();
		}
	}

	private void LeaveImpl()
	{
		if (_canExecuteChangedHandler.Disposable != null)
		{
			_canExecuteChangedHandler.Disposable = null;
		}
	}

	private void ClearStateFlags()
	{
		using (new StateChangeSuspender(this))
		{
			IsPressed = false;
			IsPointerOver = false;
			_isPointerCaptured = false;
			_isSpaceOrEnterKeyDown = false;
			_isPointerLeftButtonDown = false;
			_isNavigationAcceptOrGamepadAKeyDown = false;
		}
	}

	private protected virtual void OnCommandChanged(object oldValue, object newValue)
	{
		if (_canExecuteChangedHandler.Disposable != null)
		{
			_canExecuteChangedHandler.Disposable = null;
		}
		if (oldValue != null && oldValue is XamlUICommand uiCommand)
		{
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, ContentControl.ContentProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, UIElement.KeyboardAcceleratorsProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, UIElement.AccessKeyProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, AutomationProperties.HelpTextProperty);
			CommandingHelpers.ClearBindingIfSet(uiCommand, this, ToolTipService.ToolTipProperty);
		}
		if (newValue != null)
		{
			ICommand newCommand = newValue as ICommand;
			if (newCommand != null)
			{
				newCommand.CanExecuteChanged += new EventHandler(CanExecuteChangedHandler);
				_canExecuteChangedHandler.Disposable = Disposable.Create(delegate
				{
					newCommand.CanExecuteChanged -= new EventHandler(CanExecuteChangedHandler);
				});
			}
			if (newCommand is XamlUICommand uiCommand2)
			{
				CommandingHelpers.BindToLabelPropertyIfUnset(uiCommand2, this, ContentControl.ContentProperty);
				CommandingHelpers.BindToKeyboardAcceleratorsIfUnset(uiCommand2, this);
				CommandingHelpers.BindToAccessKeyIfUnset(uiCommand2, this);
				CommandingHelpers.BindToDescriptionPropertiesIfUnset(uiCommand2, this);
			}
		}
		UpdateCanExecute();
		void CanExecuteChangedHandler(object? sender, object args)
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
		bool suppress = !flag;
		SuppressIsEnabled(suppress);
	}

	private void ExecuteCommand()
	{
		ICommand command = Command;
		if (command != null)
		{
			object commandParameter = CommandParameter;
			if (command.CanExecute(CommandParameter))
			{
				command.Execute(commandParameter);
			}
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs args)
	{
		UpdateVisualState(useTransitions: false);
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		UpdateVisualState();
		base.OnGotFocus(e);
	}

	private void ReleasePointerCaptureInternal(Pointer? pointer)
	{
		if (pointer == null)
		{
			ReleasePointerCaptures();
		}
		else
		{
			ReleasePointerCapture(pointer);
		}
		_isPointerCaptured = false;
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		if (base.FocusState == FocusState.Unfocused)
		{
			using (new StateChangeSuspender(this))
			{
				if (ClickMode != ClickMode.Hover)
				{
					IsPressed = false;
					ReleasePointerCaptureInternal(null);
				}
			}
		}
		base.OnLostFocus(e);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		KeyRoutedEventArgs args2 = args;
		if (args2.Handled || !_handlesKeyboardInput)
		{
			Cleanup();
			return;
		}
		VirtualKey key = args2.Key;
		if (OnKeyDownInternal(key))
		{
			args2.Handled = true;
		}
		Cleanup();
		void Cleanup()
		{
			base.OnKeyDown(args2);
		}
	}

	private protected virtual bool OnKeyDownInternal(VirtualKey key)
	{
		KeyProcess.KeyDown(key, out var handled, _keyboardNavigationAcceptsReturn, this);
		return handled;
	}

	protected override void OnKeyUp(KeyRoutedEventArgs args)
	{
		KeyRoutedEventArgs args2 = args;
		if (args2.Handled || !_handlesKeyboardInput)
		{
			Cleanup();
			return;
		}
		VirtualKey key = args2.Key;
		if (OnKeyUpInternal(key))
		{
			args2.Handled = true;
		}
		Cleanup();
		void Cleanup()
		{
			base.OnKeyUp(args2);
		}
	}

	private bool OnKeyUpInternal(VirtualKey key)
	{
		KeyProcess.KeyUp(key, out var handled, _keyboardNavigationAcceptsReturn, this);
		return handled;
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		IsPointerOver = true;
		using (new StateChangeSuspender(this))
		{
			if (ClickMode == ClickMode.Hover && base.IsEnabled)
			{
				IsPressed = true;
				RaiseClick(args);
			}
		}
		base.OnPointerEntered(args);
	}

	protected override void OnPointerExited(PointerRoutedEventArgs e)
	{
		IsPointerOver = false;
		using (new StateChangeSuspender(this))
		{
			if (ClickMode == ClickMode.Hover && base.IsEnabled)
			{
				IsPressed = false;
			}
		}
		base.OnPointerExited(e);
	}

	private bool IsValidPointerPosition()
	{
		if (-0.05 <= _pointerPosition.X && _pointerPosition.X <= base.ActualWidth + 0.05 && -0.05 <= _pointerPosition.Y)
		{
			return _pointerPosition.Y <= base.ActualHeight + 0.05;
		}
		return false;
	}

	protected override void OnPointerMoved(PointerRoutedEventArgs args)
	{
		PointerPoint currentPoint = args.GetCurrentPoint(this);
		_pointerPosition = currentPoint.Position;
		if (_isPointerLeftButtonDown && base.IsEnabled && ClickMode != ClickMode.Hover && _isPointerCaptured && !_isSpaceOrEnterKeyDown && !_isNavigationAcceptOrGamepadAKeyDown)
		{
			bool flag2 = (IsPressed = IsValidPointerPosition());
		}
		base.OnPointerMoved(args);
	}

	private void CapturePointerInternal(Pointer pointer)
	{
		if (!_isPointerCaptured)
		{
			_isPointerCaptured = CapturePointer(pointer);
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		PointerRoutedEventArgs args2 = args;
		if (args2.Handled)
		{
			Cleanup();
			return;
		}
		PointerPoint currentPoint = args2.GetCurrentPoint(this);
		PointerPointProperties properties = currentPoint.Properties;
		if (properties.IsLeftButtonPressed)
		{
			_isPointerLeftButtonDown = true;
			if (!base.IsEnabled || ClickMode == ClickMode.Hover)
			{
				Cleanup();
				return;
			}
			args2.Handled = true;
			using (new StateChangeSuspender(this))
			{
				Focus(FocusState.Pointer);
				CapturePointerInternal(args2.Pointer);
				if (_isPointerCaptured)
				{
					IsPressed = true;
				}
			}
			if (ClickMode == ClickMode.Press)
			{
				RaiseClick(args2);
			}
		}
		Cleanup();
		void Cleanup()
		{
			base.OnPointerPressed(args2);
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		PointerRoutedEventArgs args2 = args;
		if (args2.Handled)
		{
			Cleanup();
			return;
		}
		_isPointerLeftButtonDown = false;
		if (!base.IsEnabled || ClickMode == ClickMode.Hover)
		{
			Cleanup();
			return;
		}
		_shouldPerformActions = IsPressed && !_isSpaceOrEnterKeyDown && !_isNavigationAcceptOrGamepadAKeyDown;
		_pointerForPendingRightTapped = null;
		if (!_isSpaceOrEnterKeyDown && !_isNavigationAcceptOrGamepadAKeyDown)
		{
			IsPressed = false;
			_pointerForPendingRightTapped = args2.Pointer;
		}
		GestureModes gestureFollowing = args2.GestureFollowing;
		if (gestureFollowing == GestureModes.RightTapped)
		{
			Cleanup();
			return;
		}
		args2.Handled = true;
		PerformPointerUpAction();
		if (!_isSpaceOrEnterKeyDown && !_isNavigationAcceptOrGamepadAKeyDown)
		{
			Pointer pointer = args2.Pointer;
			ReleasePointerCaptureInternal(pointer);
			args2.Handled = true;
		}
		Cleanup();
		void Cleanup()
		{
			base.OnPointerReleased(args2);
		}
	}

	private void PerformPointerUpAction()
	{
		if (ClickMode == ClickMode.Release && _shouldPerformActions)
		{
			OnClick();
		}
		_shouldPerformActions = false;
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs args)
	{
		base.OnPointerCaptureLost(args);
		Pointer pointer = args.Pointer;
		ReleasePointerCaptureInternal(pointer);
		PointerPoint currentPoint = args.GetCurrentPoint(null);
		PointerDeviceType pointerDeviceType = currentPoint.PointerDevice?.PointerDeviceType ?? PointerDeviceType.Touch;
		using (new StateChangeSuspender(this))
		{
			IsPressed = false;
		}
	}

	private protected override void OnRightTappedUnhandled(RightTappedRoutedEventArgs args)
	{
		base.OnRightTappedUnhandled(args);
		if (args.Handled)
		{
			Cleanup();
			return;
		}
		PerformPointerUpAction();
		ReleasePointerCaptureInternal(_pointerForPendingRightTapped);
		Cleanup();
		void Cleanup()
		{
			_pointerForPendingRightTapped = null;
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UpdateVisualState(useTransitions: false);
	}

	private protected virtual void OnClick()
	{
		ElementSoundPlayerService.RequestInteractionSoundForElementStatic(ElementSoundKind.Invoke, this);
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Click?.Invoke(this, routedEventArgs);
		ExecuteCommand();
	}

	private void ProgrammaticClick()
	{
		OnClick();
	}

	private protected void SetAcceptsReturn(bool value)
	{
		_keyboardNavigationAcceptsReturn = value;
	}

	private UIElement GetUIControl()
	{
		return ContentTemplateRoot ?? base.TemplatedRoot;
	}
}
