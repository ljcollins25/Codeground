using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITextEditProvider : ITextProvider
{
	ITextRangeProvider GetActiveComposition();

	ITextRangeProvider GetConversionTarget();
}
