using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITextProvider2 : ITextProvider
{
	ITextRangeProvider RangeFromAnnotation(IRawElementProviderSimple annotationElement);

	ITextRangeProvider GetCaretRange(out bool isActive);
}
