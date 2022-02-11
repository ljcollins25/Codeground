using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IGridProvider
{
	int ColumnCount { get; }

	int RowCount { get; }

	IRawElementProviderSimple GetItem(int row, int column);
}
