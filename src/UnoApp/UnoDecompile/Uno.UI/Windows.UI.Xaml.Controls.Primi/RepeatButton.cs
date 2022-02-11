using System;
using Windows.Devices.Input;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class RepeatButton : ButtonBase
{
	private bool _keyboardCausingRepeat;

	private bool _pointerCausingRepeat;

	private DispatcherTimer? _timer;

	public int Delay
	{
		get
		{
			return (int)GetValue(DelayProperty);
		}
		set
		{
			SetValue(DelayProperty, value);
		}
	}

	public static DependencyProperty DelayProperty { get; } = DependencyProperty.Register("Delay", typeof(int), typeof(RepeatButton), new FrameworkPropertyMetadata(250));


	public int Interval
	{
		get
		{
			return (int)GetValue(IntervalProperty);
		}
		set
		{
			SetValue(IntervalProperty, value);
		}
	}

	public static DependencyProperty IntervalProperty { get; } = DependencyProperty.Register("Interval", typeof(int), typeof(RepeatButton), new FrameworkPropertyMetadata(250));


	internal bool IgnoreTouchInput { get; set; }

	public RepeatButton()
	{
		base.DefaultStyleKey = typeof(RepeatButton);
	}

	private protected override void Initialize()
	{
		base.Initialize();
		base.ClickMode = ClickMode.Press;
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool isEnabled = base.IsEnabled;
		bool isPressed = base.IsPressed;
		bool isPointerOver = base.IsPointerOver;
		FocusState focusState = base.FocusState;
		if (!isEnabled)
		{
			GoToState(useTransitions, "Disabled");
		}
		else if (isPressed)
		{
			GoToState(useTransitions, "Pressed");
		}
		else if (isPointerOver)
		{
			GoToState(useTransitions, "PointerOver");
		}
		else
		{
			GoToState(useTransitions, "Normal");
		}
		if (focusState != FocusState.Unfocused && isEnabled)
		{
			if (focusState == FocusState.Pointer)
			{
				GoToState(useTransitions, "PointerFocused");
			}
			else
			{
				GoToState(useTransitions, "Focused");
			}
		}
		else
		{
			GoToState(useTransitions, "Unfocused");
		}
	}

	private protected override void OnClick()
	{
		if (AutomationPeer.ListenerExistsHelper(AutomationEvents.InvokePatternOnInvoked))
		{
			GetOrCreateAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.InvokePatternOnInvoked);
		}
		base.OnClick();
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == DelayProperty)
		{
			OnDelayPropertyChanged(args.NewValue);
		}
		else if (args.Property == IntervalProperty)
		{
			OnIntervalPropertyChanged(args.NewValue);
		}
	}

	private void OnDelayPropertyChanged(object pNewDelay)
	{
		int num = (int)pNewDelay;
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException("Delay", "Delay cannot be less than 0.");
		}
	}

	private void OnIntervalPropertyChanged(object pNewInterval)
	{
		int num = (int)pNewInterval;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("Interval", "Interval cannot be less than 0.");
		}
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		_keyboardCausingRepeat = false;
		_pointerCausingRepeat = false;
		UpdateRepeatState();
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		if (args.Key == VirtualKey.Space && base.ClickMode != ClickMode.Hover)
		{
			_keyboardCausingRepeat = true;
			UpdateRepeatState();
		}
		base.OnKeyDown(args);
	}

	protected override void OnKeyUp(KeyRoutedEventArgs args)
	{
		base.OnKeyUp(args);
		if (args.Key == VirtualKey.Space && base.ClickMode != ClickMode.Hover)
		{
			_keyboardCausingRepeat = false;
			UpdateRepeatState();
		}
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		base.OnLostFocus(e);
		if (base.ClickMode != ClickMode.Hover)
		{
			_keyboardCausingRepeat = false;
			_pointerCausingRepeat = false;
			UpdateRepeatState();
		}
	}

	private bool ShouldIgnoreInput(PointerRoutedEventArgs args)
	{
		bool result = false;
		if (IgnoreTouchInput)
		{
			PointerPoint currentPoint = args.GetCurrentPoint(null);
			PointerDevice pointerDevice = currentPoint.PointerDevice;
			if (pointerDevice == null || pointerDevice.PointerDeviceType == PointerDeviceType.Touch)
			{
				result = true;
			}
		}
		return result;
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		if (!ShouldIgnoreInput(args))
		{
			base.OnPointerEntered(args);
			if (base.ClickMode == ClickMode.Hover)
			{
				_pointerCausingRepeat = true;
			}
			UpdateRepeatState();
			UpdateVisualState();
		}
	}

	protected override void OnPointerMoved(PointerRoutedEventArgs args)
	{
	}

	protected override void OnPointerExited(PointerRoutedEventArgs args)
	{
		if (!ShouldIgnoreInput(args))
		{
			base.OnPointerExited(args);
			if (base.ClickMode == ClickMode.Hover)
			{
				_pointerCausingRepeat = false;
				UpdateRepeatState();
			}
			UpdateVisualState();
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		if (!args.Handled && !ShouldIgnoreInput(args))
		{
			base.OnPointerPressed(args);
			PointerPoint currentPoint = args.GetCurrentPoint(this);
			if (currentPoint.Properties.IsLeftButtonPressed && base.ClickMode != ClickMode.Hover)
			{
				_pointerCausingRepeat = true;
				UpdateRepeatState();
			}
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		if (!args.Handled && !ShouldIgnoreInput(args))
		{
			base.OnPointerReleased(args);
			if (base.ClickMode != ClickMode.Hover)
			{
				_pointerCausingRepeat = false;
				UpdateRepeatState();
			}
			UpdateVisualState();
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new RepeatButtonAutomationPeer(this);
	}

	private void StartTimer()
	{
		if (_timer == null)
		{
			_timer = new DispatcherTimer();
			_timer!.Tick += TimerCallback;
		}
		if (!_timer!.IsEnabled)
		{
			_timer!.Interval = TimeSpan.FromMilliseconds(Delay);
			_timer!.Start();
		}
	}

	private void StopTimer()
	{
		_timer?.Stop();
	}

	private void UpdateRepeatState()
	{
		if ((_pointerCausingRepeat && base.IsPointerOver) || _keyboardCausingRepeat)
		{
			StartTimer();
		}
		else
		{
			StopTimer();
		}
	}

	private void TimerCallback(object? sender, object state)
	{
		TimeSpan timeSpan = TimeSpan.FromMilliseconds(Interval);
		if (_timer!.Interval != timeSpan)
		{
			_timer!.Interval = timeSpan;
		}
		bool isPressed = base.IsPressed;
		if ((isPressed && base.IsPointerOver) || (isPressed && _keyboardCausingRepeat))
		{
			OnClick();
		}
		else
		{
			StopTimer();
		}
	}
}
