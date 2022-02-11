using Uno;
using Windows.UI.Xaml.Automation.Text;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ITextRangeProvider
{
	ITextRangeProvider Clone();

	bool Compare(ITextRangeProvider textRangeProvider);

	int CompareEndpoints(TextPatternRangeEndpoint endpoint, ITextRangeProvider textRangeProvider, TextPatternRangeEndpoint targetEndpoint);

	void ExpandToEnclosingUnit(TextUnit unit);

	ITextRangeProvider FindAttribute(int attributeId, object value, bool backward);

	ITextRangeProvider FindText(string text, bool backward, bool ignoreCase);

	object GetAttributeValue(int attributeId);

	void GetBoundingRectangles(out double[] returnValue);

	IRawElementProviderSimple GetEnclosingElement();

	string GetText(int maxLength);

	int Move(TextUnit unit, int count);

	int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count);

	void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, ITextRangeProvider textRangeProvider, TextPatternRangeEndpoint targetEndpoint);

	void Select();

	void AddToSelection();

	void RemoveFromSelection();

	void ScrollIntoView(bool alignToTop);

	IRawElementProviderSimple[] GetChildren();
}
