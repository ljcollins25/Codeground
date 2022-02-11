using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IGridItemProvider
{
	int Column { get; }

	int ColumnSpan { get; }

	IRawElementProviderSimple ContainingGrid { get; }

	int Row { get; }

	int RowSpan { get; }
}
