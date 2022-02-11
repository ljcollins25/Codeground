using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class ToggleButtonAutomationPeer : ButtonBaseAutomationPeer, IToggleProvider
{
	public ToggleState ToggleState
	{
		get
		{
			bool? isChecked = ((ToggleButton)base.Owner).IsChecked;
			if (isChecked.HasValue)
			{
				if (isChecked.GetValueOrDefault())
				{
					return ToggleState.On;
				}
				return ToggleState.Off;
			}
			return ToggleState.Indeterminate;
		}
	}

	public ToggleButtonAutomationPeer(ToggleButton element)
		: base(element)
	{
	}

	protected override string GetClassNameCore()
	{
		return "ToggleButton";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Button;
	}

	public void Toggle()
	{
		if (IsEnabled())
		{
			((ToggleButton)base.Owner).AutomationPeerToggle();
		}
	}

	internal void RaiseToggleStatePropertyChangedEvent(object pOldValue, object pNewValue)
	{
		ToggleState toggleState = ConvertToToggleState(pOldValue);
		ToggleState toggleState2 = ConvertToToggleState(pNewValue);
		if (toggleState != toggleState2)
		{
			RaisePropertyChangedEvent(TogglePatternIdentifiers.ToggleStateProperty, toggleState, toggleState2);
		}
	}

	internal static ToggleState ConvertToToggleState(object pValue)
	{
		ToggleState result = ToggleState.Indeterminate;
		if (pValue != null)
		{
			result = (((bool)pValue) ? ToggleState.On : ToggleState.Off);
		}
		return result;
	}
}
