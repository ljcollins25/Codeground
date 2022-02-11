using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITextChildProvider
{
	IRawElementProviderSimple TextContainer { get; }

	ITextRangeProvider TextRange { get; }
}
