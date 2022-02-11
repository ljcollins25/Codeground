using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ISelectionProvider
{
	bool CanSelectMultiple { get; }

	bool IsSelectionRequired { get; }

	IRawElementProviderSimple[] GetSelection();
}
