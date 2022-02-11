using System;
using System.Collections.Generic;
using Uno;

namespace Windows.UI.Xaml.Data;

[NotImplemented]
public interface IItemsRangeInfo : IDisposable
{
	void RangesChanged(ItemIndexRange visibleRange, IReadOnlyList<ItemIndexRange> trackedItems);
}
