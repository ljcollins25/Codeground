using Uno;
using Windows.Foundation;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITextProvider
{
	ITextRangeProvider DocumentRange { get; }

	SupportedTextSelection SupportedTextSelection { get; }

	ITextRangeProvider[] GetSelection();

	ITextRangeProvider[] GetVisibleRanges();

	ITextRangeProvider RangeFromChild(IRawElementProviderSimple childElement);

	ITextRangeProvider RangeFromPoint(Point screenLocation);
}
