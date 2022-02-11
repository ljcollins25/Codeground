namespace Windows.UI.Xaml.Automation.Provider;

public interface IWindowProvider
{
	WindowInteractionState InteractionState { get; }

	bool IsModal { get; }

	bool IsTopmost { get; }

	bool Maximizable { get; }

	bool Minimizable { get; }

	WindowVisualState VisualState { get; }

	void Close();

	void SetVisualState(WindowVisualState state);

	bool WaitForInputIdle(int milliseconds);
}
