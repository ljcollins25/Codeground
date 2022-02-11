using System;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal class CalendarLayoutStrategy : ILayoutStrategy
{
	private CalendarLayoutStrategyImpl _layoutStrategyImpl = new CalendarLayoutStrategyImpl();

	private ILayoutDataInfoProvider _spDataInfoProvider;

	public Orientation VirtualizationDirection
	{
		get
		{
			GetVirtualizationDirection(out var orientation);
			return orientation;
		}
		set
		{
			SetVirtualizationDirection(value);
		}
	}

	internal ILayoutDataInfoProvider LayoutDataInfoProvider
	{
		get
		{
			return _spDataInfoProvider;
		}
		set
		{
			_spDataInfoProvider = value;
			_layoutStrategyImpl.GetLayoutDataInfoProviderNoRef = value;
		}
	}

	internal void GetVirtualizationDirection(out Orientation orientation)
	{
		orientation = _layoutStrategyImpl.VirtualizationDirection;
	}

	public void SetVirtualizationDirection(Orientation direction)
	{
		_layoutStrategyImpl.VirtualizationDirection = direction;
	}

	public void SetGroupPadding(Thickness padding)
	{
		_layoutStrategyImpl.GroupPadding = padding;
	}

	public void SetViewportSize(Size size, out bool pNeedsRemeasure)
	{
		_layoutStrategyImpl.SetViewportSize(size, out pNeedsRemeasure);
	}

	public void SetItemMinimumSize(Size size, out bool pNeedsRemeasure)
	{
		_layoutStrategyImpl.SetItemMinimumSize(size, out pNeedsRemeasure);
	}

	public void SetRows(int rows)
	{
		_layoutStrategyImpl.SetRows(rows);
	}

	public void SetCols(int cols)
	{
		_layoutStrategyImpl.SetCols(cols);
	}

	internal void BeginMeasure()
	{
		_layoutStrategyImpl.BeginMeasure();
	}

	internal void EndMeasure()
	{
		_layoutStrategyImpl.EndMeasure();
	}

	internal Size GetElementMeasureSize(ElementType elementType, int elementIndex, Rect windowConstraint)
	{
		GetElementMeasureSizeImpl(elementType, elementIndex, windowConstraint, out var pReturnValue);
		return pReturnValue;
	}

	internal Rect GetElementBounds(ElementType elementType, int elementIndex, Size containerDesiredSize, LayoutReference referenceInformation, Rect windowConstraint)
	{
		GetElementBoundsImpl(elementType, elementIndex, containerDesiredSize, referenceInformation, windowConstraint, out var pReturnValue);
		return pReturnValue;
	}

	internal Rect GetElementArrangeBounds(ElementType elementType, int elementIndex, Rect containerBounds, Rect windowConstraint, Size finalSize)
	{
		GetElementArrangeBoundsImpl(elementType, elementIndex, containerBounds, windowConstraint, finalSize, out var pReturnValue);
		return pReturnValue;
	}

	internal bool ShouldContinueFillingUpSpace(ElementType elementType, int elementIndex, LayoutReference referenceInformation, Rect windowToFill)
	{
		ShouldContinueFillingUpSpaceImpl(elementType, elementIndex, referenceInformation, windowToFill, out var pReturnValue);
		return pReturnValue;
	}

	internal Point GetPositionOfFirstElement()
	{
		GetPositionOfFirstElementImpl(out var returnValue);
		return returnValue;
	}

	void ILayoutStrategy.BeginMeasure()
	{
		_layoutStrategyImpl.BeginMeasure();
	}

	void ILayoutStrategy.EndMeasure()
	{
		_layoutStrategyImpl.EndMeasure();
	}

	private void GetElementMeasureSizeImpl(ElementType elementType, int elementIndex, Rect windowConstraint, out Size pReturnValue)
	{
		pReturnValue = default(Size);
		pReturnValue = _layoutStrategyImpl.GetElementMeasureSize(elementType, elementIndex, windowConstraint);
	}

	private void GetElementBoundsImpl(ElementType elementType, int elementIndex, Size containerDesiredSize, LayoutReference referenceInformation, Rect windowConstraint, out Rect pReturnValue)
	{
		pReturnValue = default(Rect);
		pReturnValue = _layoutStrategyImpl.GetElementBounds(elementType, elementIndex, containerDesiredSize, referenceInformation, windowConstraint);
	}

	private void GetElementArrangeBoundsImpl(ElementType elementType, int elementIndex, Rect containerBounds, Rect windowConstraint, Size finalSize, out Rect pReturnValue)
	{
		pReturnValue = default(Rect);
		pReturnValue = _layoutStrategyImpl.GetElementArrangeBounds(elementType, elementIndex, containerBounds, windowConstraint, finalSize);
	}

	private void ShouldContinueFillingUpSpaceImpl(ElementType elementType, int elementIndex, LayoutReference referenceInformation, Rect windowToFill, out bool pReturnValue)
	{
		pReturnValue = false;
		pReturnValue = _layoutStrategyImpl.ShouldContinueFillingUpSpace(elementType, elementIndex, referenceInformation, windowToFill);
	}

	private void GetPositionOfFirstElementImpl(out Point returnValue)
	{
		returnValue = null;
		returnValue = _layoutStrategyImpl.GetPositionOfFirstElement();
	}

	private void GetVirtualizationDirectionImpl(out Orientation pReturnValue)
	{
		pReturnValue = _layoutStrategyImpl.VirtualizationDirection;
	}

	internal void EstimateElementIndex(ElementType elementType, EstimationReference headerReference, EstimationReference containerReference, Rect window, out Rect pTargetRect, out int pReturnValue)
	{
		pReturnValue = 0;
		_layoutStrategyImpl.EstimateElementIndex(elementType, headerReference, containerReference, window, out pTargetRect, out pReturnValue);
	}

	internal void EstimateElementBounds(ElementType elementType, int elementIndex, EstimationReference headerReference, EstimationReference containerReference, Rect window, out Rect pReturnValue)
	{
		pReturnValue = default(Rect);
		_layoutStrategyImpl.EstimateElementBounds(elementType, elementIndex, headerReference, containerReference, window, out pReturnValue);
	}

	internal void EstimatePanelExtent(EstimationReference lastHeaderReference, EstimationReference lastContainerReference, Rect windowConstraint, out Size pExtent)
	{
		pExtent = default(Size);
		_layoutStrategyImpl.EstimatePanelExtent(lastHeaderReference, lastContainerReference, windowConstraint, out pExtent);
	}

	private void EstimateIndexFromPointImpl(bool requestingInsertionIndex, Point point, EstimationReference reference, Rect windowConstraint, out IndexSearchHint pSearchHint, out ElementType pElementType, out int pElementIndex)
	{
		throw new NotImplementedException();
	}

	private void GetTargetIndexFromNavigationActionImpl(ElementType elementType, int elementIndex, KeyNavigationAction action, Rect windowConstraint, int itemIndexHintForHeaderNavigation, out ElementType targetElementType, out int targetElementIndex)
	{
		targetElementType = ElementType.ItemContainer;
		targetElementIndex = 0;
		_layoutStrategyImpl.GetTargetIndexFromNavigationAction(elementType, elementIndex, action, windowConstraint, out targetElementType, out targetElementIndex);
	}

	private void IsIndexLayoutBoundaryImpl(ElementType elementType, int elementIndex, Rect windowConstraint, out bool pIsLeftBoundary, out bool pIsTopBoundary, out bool pIsRightBoundary, out bool pIsBottomBoundary)
	{
		throw new NotImplementedException();
	}

	private void GetRegularSnapPointsImpl(out float pNearOffset, out float pFarOffset, out float pSpacing, out bool pHasRegularSnapPoints)
	{
		pHasRegularSnapPoints = false;
		pHasRegularSnapPoints = !_layoutStrategyImpl.GetRegularSnapPoints(out pNearOffset, out pFarOffset, out pSpacing);
	}

	private void HasIrregularSnapPointsImpl(ElementType elementType, out bool returnValue)
	{
		returnValue = false;
		returnValue = _layoutStrategyImpl.HasIrregularSnapPoints(elementType);
	}

	private void HasSnapPointOnElementImpl(ElementType elementType, int elementIndex, out bool returnValue)
	{
		returnValue = false;
		bool hasSnapPointOnElement = false;
		_layoutStrategyImpl.HasSnapPointOnElement(elementType, elementIndex, out hasSnapPointOnElement);
		returnValue = hasSnapPointOnElement;
	}

	private void GetIsWrappingStrategyImpl(out bool returnValue)
	{
		returnValue = false;
		returnValue = !_layoutStrategyImpl.IsWrappingStrategy;
	}

	private void GetElementTransitionsBoundsImpl(ElementType elementType, int elementIndex, Rect windowConstraint, out Rect pReturnValue)
	{
		throw new NotImplementedException();
	}

	internal bool NeedsSpecialItem()
	{
		return _layoutStrategyImpl.NeedsSpecialItem();
	}

	internal int GetSpecialItemIndex()
	{
		return _layoutStrategyImpl.GetSpecialItemIndex();
	}

	internal Size GetDesiredViewportSize()
	{
		return _layoutStrategyImpl.GetDesiredViewportSize();
	}

	internal void SetSnapPointFilterFunction(Func<int, bool> func)
	{
		_layoutStrategyImpl.SetSnapPointFilterFunction(func);
	}

	internal CalendarLayoutStrategyImpl.IndexCorrectionTable GetIndexCorrectionTable()
	{
		return _layoutStrategyImpl.GetIndexCorrectionTable();
	}
}
