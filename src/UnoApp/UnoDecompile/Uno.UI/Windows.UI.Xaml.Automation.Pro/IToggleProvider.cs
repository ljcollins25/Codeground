namespace Windows.UI.Xaml.Automation.Provider;

public interface IToggleProvider
{
	ToggleState ToggleState { get; }

	void Toggle();
}
