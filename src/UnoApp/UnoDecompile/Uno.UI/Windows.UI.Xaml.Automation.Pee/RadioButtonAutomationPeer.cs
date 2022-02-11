using System;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class RadioButtonAutomationPeer : ToggleButtonAutomationPeer, ISelectionItemProvider
{
	public bool IsSelected
	{
		get
		{
			RadioButton obj = base.Owner as RadioButton;
			if (obj == null)
			{
				return false;
			}
			return obj.IsChecked == true;
		}
	}

	public IRawElementProviderSimple SelectionContainer => null;

	public RadioButtonAutomationPeer(RadioButton owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.SelectionItem)
		{
			return this;
		}
		return null;
	}

	protected override string GetClassNameCore()
	{
		return "RadioButton";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.RadioButton;
	}

	public void Select()
	{
		if (IsEnabled())
		{
			(base.Owner as RadioButton)?.AutomationRadioButtonOnToggle();
		}
	}

	public void AddToSelection()
	{
		RadioButton radioButton = (RadioButton)base.Owner;
		if (!radioButton.IsChecked.HasValue || !radioButton.IsChecked.Value)
		{
			throw new InvalidOperationException();
		}
	}

	public void RemoveFromSelection()
	{
		RadioButton radioButton = (RadioButton)base.Owner;
		if (radioButton.IsChecked == true)
		{
			throw new InvalidOperationException();
		}
	}

	internal void RaiseIsSelectedPropertyChangedEvent(bool bOldValue, bool bNewValue)
	{
		if (bOldValue != bNewValue)
		{
			RaisePropertyChangedEvent(SelectionItemPatternIdentifiers.IsSelectedProperty, bOldValue, bNewValue);
		}
	}
}
