using System.Collections.Generic;

namespace Windows.UI.Xaml.Controls.Primitives;

internal static class VisualStatesHelper
{
	internal static IEnumerable<string> GetValidVisualStatesListViewBaseItem(ListViewBaseItemVisualStatesCriteria criteria)
	{
		int num = 0;
		int num2 = 1;
		string[] array = new string[num2];
		if ((criteria.isDragging || criteria.isHolding) && criteria.isInsideListView)
		{
			if (criteria.isDraggedOver && criteria.isEnabled && !criteria.isItemDragPrimary && !criteria.isSelected)
			{
				array[num] = "DragOver";
			}
			else if (criteria.dragItemsCount > 1)
			{
				if (criteria.isItemDragPrimary)
				{
					if (criteria.isDragVisualCaptured)
					{
						if (criteria.canReorder)
						{
							array[num] = "ReorderedPlaceholder";
						}
						else
						{
							array[num] = "DraggedPlaceholder";
						}
					}
					else if (criteria.canReorder)
					{
						array[num] = "MultipleReorderingPrimary";
					}
					else
					{
						array[num] = "MultipleDraggingPrimary";
					}
				}
				else if (criteria.isSelected)
				{
					if (criteria.canReorder)
					{
						array[num] = "ReorderingTarget";
					}
					else
					{
						array[num] = "MultipleDraggingSecondary";
					}
				}
				else if (criteria.canReorder)
				{
					array[num] = "ReorderingTarget";
				}
				else
				{
					array[num] = "DraggingTarget";
				}
			}
			else if (criteria.isItemDragPrimary)
			{
				if (criteria.isDragVisualCaptured)
				{
					if (criteria.canReorder)
					{
						array[num] = "ReorderedPlaceholder";
					}
					else
					{
						array[num] = "DraggedPlaceholder";
					}
				}
				else if (criteria.canReorder)
				{
					array[num] = "Reordering";
				}
				else
				{
					array[num] = "Dragging";
				}
			}
			else if (criteria.canReorder)
			{
				array[num] = "ReorderingTarget";
			}
			else
			{
				array[num] = "DraggingTarget";
			}
		}
		else
		{
			array[num] = "NotDragging";
		}
		return array;
	}
}
