using System;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal class CalendarLayoutStrategyImpl : LayoutStrategyBase
{
	public struct IndexCorrectionTable
	{
		private (int first, int second)[] uno_m_indexCorrectionTable;

		private (int first, int second)[] m_indexCorrectionTable => uno_m_indexCorrectionTable ?? (uno_m_indexCorrectionTable = new(int, int)[2]);

		public void SetCorrectionEntryForSkippedDay(int index, int correction)
		{
			m_indexCorrectionTable[1].first = index;
			m_indexCorrectionTable[1].second = correction;
		}

		public void SetCorrectionEntryForElementStartAt(int correction)
		{
			m_indexCorrectionTable[0].first = 0;
			m_indexCorrectionTable[0].second = correction;
		}

		public int VisualIndexToActualIndex(int visualIndex)
		{
			int num = visualIndex;
			(int, int)[] indexCorrectionTable = m_indexCorrectionTable;
			for (int i = 0; i < indexCorrectionTable.Length; i++)
			{
				(int, int) tuple = indexCorrectionTable[i];
				if (num < tuple.Item1)
				{
					break;
				}
				num -= tuple.Item2;
			}
			return num;
		}

		public int ActualIndexToVisualIndex(int actualIndex)
		{
			int num = actualIndex;
			(int, int)[] indexCorrectionTable = m_indexCorrectionTable;
			for (int i = 0; i < indexCorrectionTable.Length; i++)
			{
				(int, int) tuple = indexCorrectionTable[i];
				if (actualIndex < tuple.Item1)
				{
					break;
				}
				num += tuple.Item2;
			}
			return num;
		}
	}

	private Size m_cellSize;

	private Size m_cellMinSize;

	private int m_rows;

	private int m_cols;

	private Func<int, bool> m_snapPointFilterFunction;

	private IndexCorrectionTable m_indexCorrectionTable;

	public CalendarLayoutStrategyImpl()
		: base(useFullWidthHeaders: false, isWrapping: true)
	{
		m_cellSize = new Size(1.0, 1.0);
		m_cellMinSize = new Size(0.0, 0.0);
		m_rows = 1;
		m_cols = 1;
	}

	public Size GetElementMeasureSize(ElementType elementType, int elementIndex, Rect windowConstraint)
	{
		if (elementType == ElementType.ItemContainer)
		{
			return m_cellSize;
		}
		return new Size(-1.0, -1.0);
	}

	public Rect GetElementBounds(ElementType elementType, int elementIndex, Size containerDesiredSize, LayoutReference referenceInformation, Rect windowConstraint)
	{
		return GetItemBounds(elementIndex);
	}

	public Rect GetElementArrangeBounds(ElementType elementType, int elementIndex, Rect containerBounds, Rect windowConstraint, Size finalSize)
	{
		return containerBounds;
	}

	public bool ShouldContinueFillingUpSpace(ElementType elementType, int elementIndex, LayoutReference referenceInformation, Rect windowToFill)
	{
		bool flag = false;
		if (referenceInformation.RelativeLocation == ReferenceIdentity.Myself)
		{
			return true;
		}
		int pStackingLines = 0;
		int pVirtualizingLine = 0;
		int pStackingLine = 0;
		int visualIndex = m_indexCorrectionTable.ActualIndexToVisualIndex(elementIndex);
		DetermineLineInformation(visualIndex, out pStackingLines, out pVirtualizingLine, out pStackingLine);
		if (referenceInformation.RelativeLocation == ReferenceIdentity.BeforeMe)
		{
			if (pStackingLine == 0)
			{
				return PointFromRectInVirtualizingDirection(windowToFill) + SizeFromRectInVirtualizingDirection(windowToFill) > PointFromRectInVirtualizingDirection(referenceInformation.ReferenceBounds) + SizeFromRectInVirtualizingDirection(referenceInformation.ReferenceBounds);
			}
			return PointFromRectInVirtualizingDirection(windowToFill) + SizeFromRectInVirtualizingDirection(windowToFill) > PointFromRectInVirtualizingDirection(referenceInformation.ReferenceBounds);
		}
		if (pStackingLine == pStackingLines - 1)
		{
			return PointFromRectInVirtualizingDirection(windowToFill) < PointFromRectInVirtualizingDirection(referenceInformation.ReferenceBounds);
		}
		return PointFromRectInVirtualizingDirection(windowToFill) < PointFromRectInVirtualizingDirection(referenceInformation.ReferenceBounds) + SizeInVirtualizingDirection(m_cellSize);
	}

	public void EstimateElementIndex(ElementType elementType, EstimationReference headerReference, EstimationReference containerReference, Rect window, out Rect pTargetRect, out int pReturnValue)
	{
		pTargetRect = default(Rect);
		pReturnValue = -1;
		int num = 0;
		num = GetLayoutDataInfoProviderNoRef.GetTotalItemCount();
		int num2 = ((num <= 0) ? 1 : DetermineMaxStackingLine());
		float num3 = Math.Max(0f, PointFromRectInVirtualizingDirection(window));
		int num4 = (int)(num3 / SizeInVirtualizingDirection(m_cellSize));
		float num5 = Math.Max(0f, PointFromRectInNonVirtualizingDirection(window));
		int num6 = (int)(num5 / SizeInNonVirtualizingDirection(m_cellSize));
		int val = num4 * num2 + num6;
		int val2 = m_indexCorrectionTable.ActualIndexToVisualIndex(0);
		int val3 = m_indexCorrectionTable.ActualIndexToVisualIndex(num - 1);
		val = Math.Min(val, val3);
		val = Math.Max(val, val2);
		DetermineLineInformation(val, out var _, out var pVirtualizingLine, out var pStackingLine);
		pReturnValue = m_indexCorrectionTable.VisualIndexToActualIndex(val);
		SetPointFromRectInVirtualizingDirection(ref pTargetRect, (float)pVirtualizingLine * SizeInVirtualizingDirection(m_cellSize));
		SetPointFromRectInNonVirtualizingDirection(ref pTargetRect, GetItemStackingPosition(pStackingLine));
	}

	public void EstimateElementBounds(ElementType elementType, int elementIndex, EstimationReference headerReference, EstimationReference containerReference, Rect window, out Rect pReturnValue)
	{
		pReturnValue = default(Rect);
		int totalItemCount = GetLayoutDataInfoProviderNoRef.GetTotalItemCount();
		int visualIndex = m_indexCorrectionTable.ActualIndexToVisualIndex(elementIndex);
		DetermineLineInformation(visualIndex, out var _, out var pVirtualizingLine, out var pStackingLine);
		SetPointFromRectInVirtualizingDirection(ref pReturnValue, (float)pVirtualizingLine * SizeInVirtualizingDirection(m_cellSize));
		SetPointFromRectInNonVirtualizingDirection(ref pReturnValue, GetItemStackingPosition(pStackingLine));
		pReturnValue.Width = m_cellSize.Width;
		pReturnValue.Height = m_cellSize.Height;
	}

	public void EstimatePanelExtent(EstimationReference lastHeaderReference, EstimationReference lastContainerReference, Rect windowConstraint, out Size pExtent)
	{
		pExtent = default(Size);
		int num = 0;
		num = GetLayoutDataInfoProviderNoRef.GetTotalItemCount();
		int num2 = DetermineMaxStackingLine();
		SetSizeInVirtualizingDirection(ref pExtent, GetVirtualizedExtentOfItems(num, num2));
		SetSizeInNonVirtualizingDirection(ref pExtent, GetItemStackingPosition(Math.Min(num2, num)));
	}

	public void GetTargetIndexFromNavigationAction(ElementType elementType, int elementIndex, KeyNavigationAction action, Rect windowConstraint, out ElementType pTargetElementType, out int pTargetElementIndex)
	{
		int totalItemCount = GetLayoutDataInfoProviderNoRef.GetTotalItemCount();
		int totalGroupCount = GetLayoutDataInfoProviderNoRef.GetTotalGroupCount();
		pTargetElementType = ElementType.ItemContainer;
		if (action != KeyNavigationAction.Left && action != KeyNavigationAction.Right && action != KeyNavigationAction.Up && action != KeyNavigationAction.Down)
		{
			throw new ArgumentException("action");
		}
		int num = ((action != KeyNavigationAction.Left && action != KeyNavigationAction.Up) ? 1 : (-1));
		pTargetElementIndex = elementIndex;
		if ((base.VirtualizationDirection == Orientation.Vertical && (action == KeyNavigationAction.Left || action == KeyNavigationAction.Right)) || (base.VirtualizationDirection == Orientation.Horizontal && (action == KeyNavigationAction.Up || action == KeyNavigationAction.Down)))
		{
			pTargetElementIndex = Math.Min(Math.Max(elementIndex + num, 0), totalItemCount - 1);
			return;
		}
		int num2 = DetermineMaxStackingLine();
		int num3 = elementIndex + num * num2;
		if (0 <= num3 && num3 < totalItemCount)
		{
			pTargetElementIndex = num3;
		}
	}

	public bool GetRegularSnapPoints(out float pNearOffset, out float pFarOffset, out float pSpacing)
	{
		pNearOffset = 0f;
		pFarOffset = 0f;
		pSpacing = SizeInVirtualizingDirection(m_cellSize);
		return m_snapPointFilterFunction == null;
	}

	public bool HasIrregularSnapPoints(ElementType elementType)
	{
		return m_snapPointFilterFunction == null;
	}

	public void HasSnapPointOnElement(ElementType elementType, int elementIndex, out bool hasSnapPointOnElement)
	{
		hasSnapPointOnElement = false;
		hasSnapPointOnElement = m_snapPointFilterFunction(elementIndex);
	}

	private void DetermineLineInformation(int visualIndex, out int pStackingLines, out int pVirtualizingLine, out int pStackingLine)
	{
		int num = DetermineMaxStackingLine();
		int num2 = visualIndex / num;
		int num3 = visualIndex - num2 * num;
		pStackingLines = num;
		pVirtualizingLine = num2;
		pStackingLine = num3;
	}

	private int DetermineMaxStackingLine()
	{
		return base.VirtualizationDirection switch
		{
			Orientation.Horizontal => m_rows, 
			Orientation.Vertical => m_cols, 
			_ => 0, 
		};
	}

	private float GetVirtualizedExtentOfItems(int itemCount, int maxStackingLine)
	{
		float num = 0f;
		if (itemCount > 0)
		{
			int actualIndex = itemCount - 1;
			int num2 = m_indexCorrectionTable.ActualIndexToVisualIndex(actualIndex);
			int num3 = num2 / maxStackingLine + 1;
			num += SizeInVirtualizingDirection(m_cellSize) * (float)num3;
		}
		return num;
	}

	private float GetItemStackingPosition(int stackingLine)
	{
		return (float)stackingLine * SizeInNonVirtualizingDirection(m_cellSize);
	}

	public void SetViewportSize(Size size, out bool pNeedsRemeasure)
	{
		pNeedsRemeasure = false;
		float num = (float)size.Width / (float)m_cols;
		float num2 = (float)size.Height / (float)m_rows;
		float num3 = 0.0001f;
		if ((double)num != m_cellSize.Width || (double)num2 != m_cellSize.Height)
		{
			m_cellSize.Width = ((num == 0f) ? m_cellMinSize.Width : ((double)num));
			m_cellSize.Height = ((num2 == 0f) ? m_cellMinSize.Height : ((double)num2));
			pNeedsRemeasure = true;
		}
	}

	public Size GetDesiredViewportSize()
	{
		return new Size(m_cellMinSize.Width * (double)m_cols, m_cellMinSize.Height * (double)m_rows);
	}

	public void SetItemMinimumSize(Size size, out bool pNeedsRemeasure)
	{
		pNeedsRemeasure = false;
		if (m_cellMinSize.Width != size.Width || m_cellMinSize.Height != size.Height)
		{
			m_cellMinSize = size;
			m_cellSize = m_cellMinSize;
			pNeedsRemeasure = true;
		}
	}

	public Rect GetItemBounds(int index)
	{
		Rect rect = default(Rect);
		int pStackingLines = 0;
		int pStackingLine = 0;
		int pVirtualizingLine = 0;
		int visualIndex = m_indexCorrectionTable.ActualIndexToVisualIndex(index);
		DetermineLineInformation(visualIndex, out pStackingLines, out pVirtualizingLine, out pStackingLine);
		SetPointFromRectInVirtualizingDirection(ref rect, (float)pVirtualizingLine * SizeInVirtualizingDirection(m_cellSize));
		SetPointFromRectInNonVirtualizingDirection(ref rect, GetItemStackingPosition(pStackingLine));
		rect.Width = m_cellSize.Width;
		rect.Height = m_cellSize.Height;
		return rect;
	}

	public void BeginMeasure()
	{
	}

	public void EndMeasure()
	{
	}

	public Point GetPositionOfFirstElement()
	{
		return new Point(0.0, 0.0);
	}

	public bool NeedsSpecialItem()
	{
		return false;
	}

	public int GetSpecialItemIndex()
	{
		return LayoutStrategyBase.c_specialItemIndex;
	}

	public void SetRows(int rows)
	{
		m_rows = rows;
	}

	public void SetCols(int cols)
	{
		m_cols = cols;
	}

	public void SetSnapPointFilterFunction(Func<int, bool> func)
	{
		m_snapPointFilterFunction = func;
	}

	public IndexCorrectionTable GetIndexCorrectionTable()
	{
		return m_indexCorrectionTable;
	}
}
