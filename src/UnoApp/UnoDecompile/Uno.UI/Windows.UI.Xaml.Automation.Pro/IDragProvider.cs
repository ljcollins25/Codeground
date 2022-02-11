using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IDragProvider
{
	string DropEffect { get; }

	string[] DropEffects { get; }

	bool IsGrabbed { get; }

	IRawElementProviderSimple[] GetGrabbedItems();
}
