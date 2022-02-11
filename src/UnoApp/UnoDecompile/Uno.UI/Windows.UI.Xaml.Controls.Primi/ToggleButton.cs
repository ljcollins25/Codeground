using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls.Primitives;

public class ToggleButton : ButtonBase, IFrameworkTemplatePoolAware
{
	private bool _skipCreateAutomationPeer;

	public bool? IsChecked
	{
		get
		{
			return (bool?)GetValue(IsCheckedProperty);
		}
		set
		{
			SetValue(IsCheckedProperty, value);
		}
	}

	public static DependencyProperty IsCheckedProperty { get; } = DependencyProperty.Register("IsChecked", typeof(bool?), typeof(ToggleButton), new FrameworkPropertyMetadata(false));


	public bool IsThreeState
	{
		get
		{
			return (bool)GetValue(IsThreeStateProperty);
		}
		set
		{
			SetValue(IsThreeStateProperty, value);
		}
	}

	public static DependencyProperty IsThreeStateProperty { get; } = DependencyProperty.Register("IsThreeState", typeof(bool), typeof(ToggleButton), new FrameworkPropertyMetadata(false));


	internal bool CanRevertState { get; set; } = true;


	public event RoutedEventHandler? Checked;

	public event RoutedEventHandler? Unchecked;

	public event RoutedEventHandler? Indeterminate;

	public ToggleButton()
	{
		base.DefaultStyleKey = typeof(ToggleButton);
	}

	protected virtual void OnToggle()
	{
		OnToggleImpl();
	}

	protected virtual void OnIsCheckedChanged(bool? oldValue, bool? newValue)
	{
		if (!IsChecked.HasValue)
		{
			this.Indeterminate?.Invoke(this, new RoutedEventArgs(this));
		}
		else if (IsChecked.Value)
		{
			this.Checked?.Invoke(this, new RoutedEventArgs(this));
		}
		else
		{
			this.Unchecked?.Invoke(this, new RoutedEventArgs(this));
		}
	}

	public void OnTemplateRecycled()
	{
		IsChecked = false;
	}

	internal void AutomationPeerToggle()
	{
		OnToggle();
	}

	private protected override void Initialize()
	{
		base.Initialize();
		SetAcceptsReturn(value: true);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property != IsCheckedProperty)
		{
			return;
		}
		OnIsCheckedChanged();
		if (AutomationPeer.ListenerExistsHelper(AutomationEvents.PropertyChanged))
		{
			AutomationPeer orCreateAutomationPeer = GetOrCreateAutomationPeer();
			if (orCreateAutomationPeer != null && !(this is RadioButton))
			{
				(orCreateAutomationPeer as ToggleButtonAutomationPeer)?.RaiseToggleStatePropertyChangedEvent(args.OldValue, args.NewValue);
			}
		}
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool isEnabled = base.IsEnabled;
		bool isPressed = base.IsPressed;
		bool isPointerOver = base.IsPointerOver;
		FocusState focusState = base.FocusState;
		bool? isChecked = IsChecked;
		if (!isChecked.HasValue)
		{
			if (!isEnabled)
			{
				GoToState(useTransitions, "IndeterminateDisabled");
			}
			else if (isPressed)
			{
				GoToState(useTransitions, "IndeterminatePressed");
			}
			else if (isPointerOver)
			{
				GoToState(useTransitions, "IndeterminatePointerOver");
			}
			else
			{
				GoToState(useTransitions, "Indeterminate");
			}
		}
		else if (isChecked == true)
		{
			if (!isEnabled)
			{
				GoToState(useTransitions, "CheckedDisabled");
			}
			else if (isPressed)
			{
				GoToState(useTransitions, "CheckedPressed");
			}
			else if (isPointerOver)
			{
				GoToState(useTransitions, "CheckedPointerOver");
			}
			else
			{
				GoToState(useTransitions, "Checked");
			}
		}
		else if (!isEnabled)
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
		OnToggle();
		base.OnClick();
	}

	private protected virtual void OnChecked()
	{
		UpdateVisualState();
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Checked?.Invoke(this, routedEventArgs);
	}

	private protected virtual void OnUnchecked()
	{
		UpdateVisualState();
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Unchecked?.Invoke(this, routedEventArgs);
	}

	private protected virtual void OnIndeterminate()
	{
		UpdateVisualState();
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Indeterminate?.Invoke(this, routedEventArgs);
	}

	private void OnToggleImpl()
	{
		bool? isChecked = IsChecked;
		if (!isChecked.HasValue)
		{
			IsChecked = false;
		}
		else if (isChecked == true)
		{
			if (IsThreeState)
			{
				IsChecked = null;
			}
			else
			{
				IsChecked = false;
			}
		}
		else
		{
			IsChecked = true;
		}
	}

	private void OnIsCheckedChanged()
	{
		bool? isChecked = IsChecked;
		if (!isChecked.HasValue)
		{
			OnIndeterminate();
		}
		else if (isChecked == true)
		{
			OnChecked();
		}
		else
		{
			OnUnchecked();
		}
	}

	private void AutomationToggleButtonOnToggle()
	{
		OnClick();
	}

	protected override AutomationPeer? OnCreateAutomationPeer()
	{
		if (!_skipCreateAutomationPeer)
		{
			return new ToggleButtonAutomationPeer(this);
		}
		return null;
	}

	private void SetSkipAutomationPeerCreation()
	{
		_skipCreateAutomationPeer = true;
	}
}
