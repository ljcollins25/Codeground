using Windows.Devices.Input;
using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls;

public class ToggleMenuFlyoutItem : MenuFlyoutItem
{
	public bool IsChecked
	{
		get
		{
			return (bool)GetValue(IsCheckedProperty);
		}
		set
		{
			SetValue(IsCheckedProperty, value);
		}
	}

	public static DependencyProperty IsCheckedProperty { get; } = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleMenuFlyoutItem), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ToggleMenuFlyoutItem)?.OnIsCheckedChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public ToggleMenuFlyoutItem()
	{
		base.DefaultStyleKey = typeof(ToggleMenuFlyoutItem);
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		bool isPointerPressed = base.IsPointerPressed;
		bool isPointerOver = base.IsPointerOver;
		bool isEnabled = base.IsEnabled;
		bool isChecked = IsChecked;
		bool flag = false;
		bool flag2 = false;
		bool shouldBeNarrow = GetShouldBeNarrow();
		FocusState focusState = base.FocusState;
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		bool flag3 = false;
		if (parentMenuFlyoutPresenter != null)
		{
			flag = parentMenuFlyoutPresenter.GetContainsIconItems();
			flag2 = parentMenuFlyoutPresenter.GetContainsItemsWithKeyboardAcceleratorText();
		}
		if (flag2)
		{
			flag3 = new KeyboardCapabilities().KeyboardPresent != 0;
		}
		if (!isEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", bUseTransitions);
		}
		else if (isPointerPressed)
		{
			VisualStateManager.GoToState(this, "Pressed", bUseTransitions);
		}
		else if (isPointerOver)
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
		if (isChecked && flag)
		{
			VisualStateManager.GoToState(this, "CheckedWithIcon", bUseTransitions);
		}
		else if (flag)
		{
			VisualStateManager.GoToState(this, "UncheckedWithIcon", bUseTransitions);
		}
		else if (isChecked)
		{
			VisualStateManager.GoToState(this, "Checked", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Unchecked", bUseTransitions);
		}
		if (shouldBeNarrow)
		{
			VisualStateManager.GoToState(this, "NarrowPadding", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "DefaultPadding", bUseTransitions);
		}
		if (flag2 && flag3)
		{
			VisualStateManager.GoToState(this, "KeyboardAcceleratorTextVisible", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "KeyboardAcceleratorTextCollapsed", bUseTransitions);
		}
	}

	internal override void Invoke()
	{
		IsChecked = !IsChecked;
		base.Invoke();
	}

	private void OnIsCheckedChanged(bool oldValue, bool newValue)
	{
		UpdateVisualState();
		if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			AutomationPeer automationPeer = GetAutomationPeer();
			if (automationPeer is ToggleMenuFlyoutItemAutomationPeer toggleMenuFlyoutItemAutomationPeer)
			{
				toggleMenuFlyoutItemAutomationPeer.Toggle();
			}
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ToggleMenuFlyoutItemAutomationPeer(this);
	}
}
