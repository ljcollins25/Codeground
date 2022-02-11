namespace Windows.UI.Xaml.Automation.Provider;

public interface ISelectionItemProvider
{
	bool IsSelected { get; }

	IRawElementProviderSimple SelectionContainer { get; }

	void AddToSelection();

	void RemoveFromSelection();

	void Select();
}
