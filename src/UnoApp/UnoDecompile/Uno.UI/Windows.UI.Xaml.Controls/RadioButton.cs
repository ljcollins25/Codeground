using System;
using System.Collections.Generic;
using DirectUI;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class RadioButton : ToggleButton
{
	public string GroupName
	{
		get
		{
			return ((string)GetValue(GroupNameProperty)) ?? string.Empty;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			SetValue(GroupNameProperty, value);
		}
	}

	public static DependencyProperty GroupNameProperty { get; } = DependencyProperty.Register("GroupName", typeof(string), typeof(RadioButton), new FrameworkPropertyMetadata(null));


	public RadioButton()
	{
		base.CanRevertState = false;
		base.DefaultStyleKey = typeof(RadioButton);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		UnregisterSafe(this);
		Register(((string)GetValue(GroupNameProperty)) ?? "", this);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		Unregister(((string)GetValue(GroupNameProperty)) ?? "", this);
	}

	private protected override void Initialize()
	{
		base.Initialize();
		SetAcceptsReturn(value: false);
		Register("", this);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == GroupNameProperty)
		{
			OnGroupNamePropertyChanged(args.OldValue, args.NewValue);
		}
		else
		{
			if (args.Property != ToggleButton.IsCheckedProperty)
			{
				return;
			}
			AutomationPeer automationPeer = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = AutomationPeer.ListenerExistsHelper(AutomationEvents.PropertyChanged);
			bool flag4 = AutomationPeer.ListenerExistsHelper(AutomationEvents.SelectionItemPatternOnElementSelected);
			bool flag5 = AutomationPeer.ListenerExistsHelper(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
			if (flag3 || flag4 || flag5)
			{
				automationPeer = GetOrCreateAutomationPeer();
				bool? flag6 = (bool?)args.OldValue;
				bool? flag7 = (bool?)args.NewValue;
				if (flag6.HasValue)
				{
					flag = flag6.Value;
				}
				if (flag7.HasValue)
				{
					flag2 = flag7.Value;
				}
			}
			if (automationPeer == null)
			{
				return;
			}
			if (flag3 && automationPeer is RadioButtonAutomationPeer radioButtonAutomationPeer)
			{
				radioButtonAutomationPeer.RaiseIsSelectedPropertyChangedEvent(flag, flag2);
			}
			if (flag != flag2)
			{
				if (flag4 && flag2)
				{
					automationPeer.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementSelected);
				}
				if (flag5 && !flag2)
				{
					automationPeer.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
				}
			}
		}
	}

	private void OnGroupNamePropertyChanged(object pOldValue, object pNewValue)
	{
		string text = pOldValue as string;
		string text2 = pNewValue as string;
		Unregister(text ?? "", this);
		Register(text2 ?? "", this);
	}

	private protected override void OnChecked()
	{
		UpdateRadioButtonGroup();
		base.OnChecked();
	}

	protected override void OnToggle()
	{
		base.IsChecked = true;
	}

	private static void Register(string groupName, RadioButton radioButton)
	{
		if (radioButton == null)
		{
			throw new ArgumentNullException("radioButton");
		}
		Dictionary<string, List<WeakReference<RadioButton>>> radioButtonGroupsByName = DXamlCore.Current.GetRadioButtonGroupsByName(ensure: true);
		if (!radioButtonGroupsByName.TryGetValue(groupName, out var value))
		{
			value = new List<WeakReference<RadioButton>>();
			radioButtonGroupsByName.Add(groupName, value);
		}
		WeakReference<RadioButton> item = new WeakReference<RadioButton>(radioButton);
		value.Add(item);
	}

	private static void UnregisterSafe(RadioButton radioButton)
	{
		if (radioButton == null)
		{
			throw new ArgumentNullException("radioButton");
		}
		Dictionary<string, List<WeakReference<RadioButton>>> radioButtonGroupsByName = DXamlCore.Current.GetRadioButtonGroupsByName(ensure: false);
		if (radioButtonGroupsByName == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, List<WeakReference<RadioButton>>> item in radioButtonGroupsByName)
		{
			bool flag = UnregisterFromGroup(item.Value, radioButton);
			if (item.Value.Count == 0)
			{
				list.Add(item.Key);
			}
			if (flag)
			{
				break;
			}
		}
		foreach (string item2 in list)
		{
			radioButtonGroupsByName.Remove(item2);
		}
	}

	private static void Unregister(string groupName, RadioButton radioButton)
	{
		if (radioButton == null)
		{
			throw new ArgumentNullException("radioButton");
		}
		bool flag = false;
		Dictionary<string, List<WeakReference<RadioButton>>> radioButtonGroupsByName = DXamlCore.Current.GetRadioButtonGroupsByName(ensure: false);
		if (radioButtonGroupsByName != null && radioButtonGroupsByName.TryGetValue(groupName, out var value))
		{
			flag = UnregisterFromGroup(value, radioButton);
			if (value.Count == 0)
			{
				radioButtonGroupsByName.Remove(groupName);
			}
		}
	}

	private static bool UnregisterFromGroup(List<WeakReference<RadioButton>> groupElements, RadioButton radioButton)
	{
		bool result = false;
		bool flag = false;
		for (int num = 0; num < groupElements.Count; num = ((!flag) ? (num + 1) : 0))
		{
			flag = false;
			groupElements[num].TryGetTarget(out var target);
			if (target == null || target == radioButton)
			{
				groupElements.RemoveAt(num);
				if (target == radioButton)
				{
					result = true;
					break;
				}
				flag = true;
			}
		}
		return result;
	}

	private void UpdateRadioButtonGroup()
	{
		RadioButton radioButton = null;
		bool flag = false;
		bool groupNameExists = false;
		GetGroupName(out groupNameExists, out var groupName);
		Dictionary<string, List<WeakReference<RadioButton>>> radioButtonGroupsByName = DXamlCore.Current.GetRadioButtonGroupsByName(ensure: false);
		if (radioButtonGroupsByName == null || radioButtonGroupsByName.Count <= 0)
		{
			return;
		}
		if (radioButtonGroupsByName.TryGetValue(groupName, out var value))
		{
			DependencyObject parentForGroup = GetParentForGroup(groupNameExists, this);
			{
				foreach (WeakReference<RadioButton> item in value)
				{
					if (!item.TryGetTarget(out var target))
					{
						continue;
					}
					radioButton = target;
					bool? isChecked = radioButton.IsChecked;
					if (isChecked.HasValue)
					{
						flag = isChecked.Value;
					}
					if (radioButton != this && (!isChecked.HasValue || flag))
					{
						DependencyObject parentForGroup2 = GetParentForGroup(groupNameExists, radioButton);
						if (parentForGroup == parentForGroup2)
						{
							radioButton.IsChecked = false;
						}
					}
				}
				return;
			}
		}
		if (!groupNameExists)
		{
			throw new InvalidOperationException("Trying to update RadioButton group which does not exist.");
		}
	}

	private void GetGroupName(out bool groupNameExists, out string groupName)
	{
		groupNameExists = false;
		groupName = "";
		string groupName2 = GroupName;
		if (!string.IsNullOrEmpty(groupName2))
		{
			groupName = groupName2;
			groupNameExists = true;
		}
	}

	private DependencyObject? GetParentForGroup(bool groupNameExists, RadioButton radioButton)
	{
		DependencyObject result = null;
		DependencyObject dependencyObject = (groupNameExists ? VisualTree.GetRootForElement(radioButton) : radioButton.Parent);
		if (dependencyObject != null)
		{
			result = dependencyObject;
		}
		return result;
	}

	internal void AutomationRadioButtonOnToggle()
	{
		OnClick();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new RadioButtonAutomationPeer(this);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		bool flag = args.Handled;
		if (!flag)
		{
			VirtualKey originalKey = args.OriginalKey;
			bool flag2 = false;
			switch (originalKey)
			{
			case VirtualKey.Right:
			case VirtualKey.Down:
				flag2 = FocusNextElementInGroup(moveForward: true);
				flag = true;
				break;
			case VirtualKey.Left:
			case VirtualKey.Up:
				flag2 = FocusNextElementInGroup(moveForward: false);
				flag = true;
				break;
			}
			args.Handled = flag;
		}
	}

	private bool FocusNextElementInGroup(bool moveForward)
	{
		bool result = false;
		GetGroupName(out var groupNameExists, out var groupName);
		DependencyObject parentForGroup = GetParentForGroup(groupNameExists, this);
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (parentForGroup != null && focusManagerForElement != null)
		{
			DependencyObject dependencyObject = null;
			DependencyObject firstFocusableElement = focusManagerForElement.GetFirstFocusableElement(parentForGroup);
			DependencyObject lastFocusableElement = focusManagerForElement.GetLastFocusableElement(parentForGroup);
			FocusNavigationDirection focusNavigationDirection = FocusNavigationDirection.None;
			if (moveForward)
			{
				dependencyObject = ((this == lastFocusableElement) ? firstFocusableElement : focusManagerForElement.GetNextTabStop(this));
				focusNavigationDirection = FocusNavigationDirection.Next;
			}
			else
			{
				dependencyObject = ((this == firstFocusableElement) ? lastFocusableElement : focusManagerForElement.GetPreviousTabStop(this));
				focusNavigationDirection = FocusNavigationDirection.Previous;
			}
			while (dependencyObject != null && dependencyObject != this)
			{
				if (dependencyObject is RadioButton radioButton)
				{
					bool flag = false;
					DependencyObject descendant = dependencyObject;
					if (parentForGroup != null)
					{
						flag = parentForGroup.IsAncestorOf(descendant);
					}
					if (flag)
					{
						bool groupNameExists2 = false;
						radioButton.GetGroupName(out groupNameExists2, out var groupName2);
						if (groupName == groupName2)
						{
							focusManagerForElement.SetFocusedElement(new FocusMovement(dependencyObject, focusNavigationDirection, FocusState.Keyboard));
							result = true;
							break;
						}
					}
				}
				if (moveForward)
				{
					dependencyObject = focusManagerForElement.GetNextTabStop(dependencyObject);
					focusNavigationDirection = FocusNavigationDirection.Next;
				}
				else
				{
					dependencyObject = focusManagerForElement.GetPreviousTabStop(dependencyObject);
					focusNavigationDirection = FocusNavigationDirection.Previous;
				}
			}
		}
		return result;
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool isEnabled = base.IsEnabled;
		bool isPressed = base.IsPressed;
		bool isPointerOver = base.IsPointerOver;
		FocusState focusState = base.FocusState;
		bool? isChecked = base.IsChecked;
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
		else if (isChecked == true)
		{
			GoToState(useTransitions, "Checked");
		}
		else
		{
			GoToState(useTransitions, "Unchecked");
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
