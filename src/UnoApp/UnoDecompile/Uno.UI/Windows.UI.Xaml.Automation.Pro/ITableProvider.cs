using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITableProvider
{
	RowOrColumnMajor RowOrColumnMajor { get; }

	IRawElementProviderSimple[] GetColumnHeaders();

	IRawElementProviderSimple[] GetRowHeaders();
}
