using System.Collections.Generic;
using Uno;

namespace Windows.UI.Xaml.Data;

[NotImplemented]
public interface ISelectionInfo
{
	void SelectRange(ItemIndexRange itemIndexRange);

	void DeselectRange(ItemIndexRange itemIndexRange);

	bool IsSelected(int index);

	IReadOnlyList<ItemIndexRange> GetSelectedRanges();
}
