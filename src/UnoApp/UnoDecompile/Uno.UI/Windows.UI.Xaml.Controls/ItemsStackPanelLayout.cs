using System;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class ItemsStackPanelLayout : VirtualizingPanelLayout
{
	public override Orientation ScrollOrientation => base.Orientation;

	protected override Line CreateLine(GeneratorDirection fillDirection, double extentOffset, double availableBreadth, IndexPath nextVisibleItem)
	{
		if (ShouldInsertReorderingView(extentOffset))
		{
			IndexPath? andUpdateReorderingIndex = GetAndUpdateReorderingIndex();
			if (andUpdateReorderingIndex.HasValue)
			{
				IndexPath valueOrDefault = andUpdateReorderingIndex.GetValueOrDefault();
				nextVisibleItem = valueOrDefault;
			}
		}
		int flatItemIndex = GetFlatItemIndex(nextVisibleItem);
		FrameworkElement frameworkElement = base.Generator.DequeueViewForItem(flatItemIndex);
		AddView(frameworkElement, fillDirection, extentOffset, 0.0);
		return new Line(flatItemIndex, (frameworkElement, nextVisibleItem));
	}

	protected override int GetItemsPerLine()
	{
		return 1;
	}

	protected override Rect GetElementArrangeBounds(int elementIndex, Rect containerBounds, Size windowConstraint, Size finalSize)
	{
		double val = Math.Max(GetBreadth(containerBounds), GetBreadth(windowConstraint));
		val = Math.Min(val, GetBreadth(finalSize));
		SetBreadth(ref containerBounds, val);
		return containerBounds;
	}
}
