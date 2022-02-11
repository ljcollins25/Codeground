using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class CheckBox : ToggleButton
{
	public CheckBox()
	{
		base.DefaultStyleKey = typeof(CheckBox);
	}

	private protected override void Initialize()
	{
		base.Initialize();
		SetAcceptsReturn(value: false);
	}

	private protected override bool OnKeyDownInternal(VirtualKey key)
	{
		bool result = base.OnKeyDownInternal(key);
		bool isThreeState = base.IsThreeState;
		bool isEnabled = base.IsEnabled;
		if (!isThreeState && isEnabled)
		{
			switch (key)
			{
			case VirtualKey.Add:
				result = true;
				base.IsPressed = false;
				base.IsChecked = true;
				break;
			case VirtualKey.Subtract:
				result = true;
				base.IsPressed = false;
				base.IsChecked = false;
				break;
			}
		}
		return result;
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		DependencyObject templateChild = GetTemplateChild("CheckGlyph");
		if (templateChild is UIElement uIElement && !uIElement.IsDependencyPropertySet(UIElement.HighContrastAdjustmentProperty))
		{
			uIElement.SetValue(UIElement.HighContrastAdjustmentProperty, ElementHighContrastAdjustment.None);
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new CheckBoxAutomationPeer(this);
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool isEnabled = base.IsEnabled;
		bool isPressed = base.IsPressed;
		bool isPointerOver = base.IsPointerOver;
		FocusState focusState = base.FocusState;
		bool flag = false;
		bool? isChecked = base.IsChecked;
		if (isChecked.HasValue)
		{
			flag = isChecked.Value;
		}
		bool flag2 = false;
		if (!((!isChecked.HasValue) ? ((!isEnabled) ? GoToState(useTransitions, "IndeterminateDisabled") : (isPressed ? GoToState(useTransitions, "IndeterminatePressed") : ((!isPointerOver) ? GoToState(useTransitions, "IndeterminateNormal") : GoToState(useTransitions, "IndeterminatePointerOver")))) : (flag ? ((!isEnabled) ? GoToState(useTransitions, "CheckedDisabled") : (isPressed ? GoToState(useTransitions, "CheckedPressed") : ((!isPointerOver) ? GoToState(useTransitions, "CheckedNormal") : GoToState(useTransitions, "CheckedPointerOver")))) : ((!isEnabled) ? GoToState(useTransitions, "UncheckedDisabled") : (isPressed ? GoToState(useTransitions, "UncheckedPressed") : ((!isPointerOver) ? GoToState(useTransitions, "UncheckedNormal") : GoToState(useTransitions, "UncheckedPointerOver")))))))
		{
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
			if (!isChecked.HasValue)
			{
				GoToState(useTransitions, "Indeterminate");
			}
			else if (flag)
			{
				GoToState(useTransitions, "Checked");
			}
			else
			{
				GoToState(useTransitions, "Unchecked");
			}
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
}
