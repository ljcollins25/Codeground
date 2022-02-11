using DirectUI;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class AppBarToggleButtonAutomationPeer : ToggleButtonAutomationPeer
{
	public new ToggleState ToggleState
	{
		get
		{
			AppBarToggleButton owningAppBarToggleButton = GetOwningAppBarToggleButton();
			bool? isChecked = owningAppBarToggleButton.IsChecked;
			if (!isChecked.HasValue)
			{
				return ToggleState.Indeterminate;
			}
			if (isChecked.Value)
			{
				return ToggleState.On;
			}
			return ToggleState.Off;
		}
	}

	public AppBarToggleButtonAutomationPeer(AppBarToggleButton owner)
		: base(owner)
	{
	}

	protected override string GetClassNameCore()
	{
		return "AppBarToggleButton";
	}

	protected override string GetNameCore()
	{
		string text = base.GetNameCore();
		if (string.IsNullOrWhiteSpace(text))
		{
			AppBarToggleButton owningAppBarToggleButton = GetOwningAppBarToggleButton();
			text = owningAppBarToggleButton.Label;
		}
		return text;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_AP_APPBAR_TOGGLEBUTTON");
	}

	protected override string GetAcceleratorKeyCore()
	{
		string text = base.GetAcceleratorKeyCore();
		if (string.IsNullOrWhiteSpace(text))
		{
			AppBarToggleButton owningAppBarToggleButton = GetOwningAppBarToggleButton();
			text = owningAppBarToggleButton.KeyboardAcceleratorTextOverride?.Trim();
		}
		return text;
	}

	public new void Toggle()
	{
		if (!IsEnabled())
		{
			throw new ElementNotEnabledException();
		}
		AppBarToggleButton owningAppBarToggleButton = GetOwningAppBarToggleButton();
		owningAppBarToggleButton.AutomationPeerToggle();
	}

	private AppBarToggleButton GetOwningAppBarToggleButton()
	{
		UIElement owner = base.Owner;
		return owner as AppBarToggleButton;
	}
}
