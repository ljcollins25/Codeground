using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITableItemProvider
{
	IRawElementProviderSimple[] GetColumnHeaderItems();

	IRawElementProviderSimple[] GetRowHeaderItems();
}
