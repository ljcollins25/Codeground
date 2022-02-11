using System;
using System.Collections.Specialized;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class FlowLayoutAlgorithm : OrientationBasedMeasures
{
	private enum GenerateDirection
	{
		Forward,
		Backward
	}

	private ElementManager m_elementManager = new ElementManager();

	private Size m_lastAvailableSize;

	private double m_lastItemSpacing;

	private bool m_collectionChangePending;

	private VirtualizingLayoutContext m_context;

	private IFlowLayoutAlgorithmDelegates m_algorithmCallbacks;

	private Rect m_lastExtent;

	private int m_firstRealizedDataIndexInsideRealizationWindow = -1;

	private int m_lastRealizedDataIndexInsideRealizationWindow = -1;

	private bool m_scrollOrientationSameAsFlow;

	public Rect LastExtent => m_lastExtent;

	private bool IsReflowRequired
	{
		get
		{
			if (m_elementManager.GetRealizedElementCount > 0 && m_elementManager.GetDataIndexFromRealizedRangeIndex(0) == 0)
			{
				if (ScrollOrientation != 0)
				{
					return m_elementManager.GetLayoutBoundsForRealizedIndex(0).Y != 0.0;
				}
				return m_elementManager.GetLayoutBoundsForRealizedIndex(0).X != 0.0;
			}
			return false;
		}
	}

	private Rect RealizationRect
	{
		get
		{
			if (!IsVirtualizingContext)
			{
				return new Rect(0.0, 0.0, double.PositiveInfinity, double.PositiveInfinity);
			}
			return m_context.RealizationRect;
		}
	}

	private bool IsVirtualizingContext
	{
		get
		{
			if (m_context != null)
			{
				Rect realizationRect = m_context.RealizationRect;
				bool flag = double.IsInfinity(realizationRect.Height) || double.IsInfinity(realizationRect.Width);
				return !flag;
			}
			return false;
		}
	}

	private ScrollOrientation ScrollOrientation { get; set; }

	ScrollOrientation OrientationBasedMeasures.ScrollOrientation
	{
		get
		{
			return ScrollOrientation;
		}
		set
		{
			ScrollOrientation = value;
		}
	}

	public void InitializeForContext(VirtualizingLayoutContext context, IFlowLayoutAlgorithmDelegates callbacks)
	{
		m_algorithmCallbacks = callbacks;
		m_context = context;
		m_elementManager.SetContext(context);
	}

	public void UninitializeForContext(VirtualizingLayoutContext context)
	{
		if (IsVirtualizingContext)
		{
			m_elementManager.ClearRealizedRange();
		}
		context.LayoutStateCore = null;
	}

	internal Size Measure(Size availableSize, VirtualizingLayoutContext context, bool isWrapping, double minItemSpacing, double lineSpacing, uint maxItemsPerLine, ScrollOrientation orientation, bool disableVirtualization, string layoutId)
	{
		ScrollOrientation = orientation;
		m_scrollOrientationSameAsFlow = Minor(availableSize) == double.PositiveInfinity;
		Rect realizationRect = RealizationRect;
		int recommendedAnchorIndex = m_context.RecommendedAnchorIndex;
		if (m_elementManager.IsIndexValidInData(recommendedAnchorIndex) && !m_elementManager.IsDataIndexRealized(recommendedAnchorIndex))
		{
			MakeAnchor(m_context, recommendedAnchorIndex, availableSize);
		}
		m_elementManager.OnBeginMeasure(orientation);
		int anchorIndex = GetAnchorIndex(availableSize, isWrapping, minItemSpacing, layoutId);
		Generate(GenerateDirection.Forward, anchorIndex, availableSize, minItemSpacing, lineSpacing, maxItemsPerLine, disableVirtualization, layoutId);
		Generate(GenerateDirection.Backward, anchorIndex, availableSize, minItemSpacing, lineSpacing, maxItemsPerLine, disableVirtualization, layoutId);
		if (isWrapping && IsReflowRequired)
		{
			Rect rect = m_elementManager.GetLayoutBoundsForRealizedIndex(0);
			SetMinorStart(ref rect, 0.0);
			m_elementManager.SetLayoutBoundsForRealizedIndex(0, rect);
			Generate(GenerateDirection.Forward, 0, availableSize, minItemSpacing, lineSpacing, maxItemsPerLine, disableVirtualization, layoutId);
		}
		RaiseLineArranged();
		m_collectionChangePending = false;
		m_lastExtent = EstimateExtent(availableSize, layoutId);
		SetLayoutOrigin();
		return m_lastExtent.Size;
	}

	public Size Arrange(Size finalSize, VirtualizingLayoutContext context, bool isWrapping, FlowLayoutLineAlignment lineAlignment, string layoutId)
	{
		ArrangeVirtualizingLayout(finalSize, lineAlignment, isWrapping, layoutId);
		return new Size(Math.Max(finalSize.Width, m_lastExtent.Width), Math.Max(finalSize.Height, m_lastExtent.Height));
	}

	private void MakeAnchor(VirtualizingLayoutContext context, int index, Size availableSize)
	{
		m_elementManager.ClearRealizedRange();
		for (int i = m_algorithmCallbacks.Algorithm_GetAnchorForTargetElement(index, availableSize, context).Index; i < index + 1; i++)
		{
			UIElement orCreateElementAt = context.GetOrCreateElementAt(i, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
			orCreateElementAt.Measure(m_algorithmCallbacks.Algorithm_GetMeasureSize(i, availableSize, context));
			m_elementManager.Add(orCreateElementAt, i);
		}
	}

	public void OnItemsSourceChanged(object source, NotifyCollectionChangedEventArgs args, VirtualizingLayoutContext context)
	{
		m_elementManager.DataSourceChanged(source, args);
		m_collectionChangePending = true;
	}

	public Size MeasureElement(UIElement element, int index, Size availableSize, VirtualizingLayoutContext context)
	{
		Size size = m_algorithmCallbacks.Algorithm_GetMeasureSize(index, availableSize, context);
		element.Measure(size);
		Size size2 = m_algorithmCallbacks.Algorithm_GetProvisionalArrangeSize(index, size, element.DesiredSize, context);
		m_algorithmCallbacks.Algorithm_OnElementMeasured(element, index, availableSize, size, element.DesiredSize, size2, context);
		return size2;
	}

	private int GetAnchorIndex(Size availableSize, bool isWrapping, double minItemSpacing, string layoutId)
	{
		int num = -1;
		Point point = default(Point);
		VirtualizingLayoutContext context = m_context;
		if (!IsVirtualizingContext)
		{
			num = ((context.ItemCount <= 0) ? (-1) : 0);
		}
		else
		{
			bool flag = m_elementManager.IsWindowConnected(RealizationRect, ScrollOrientation, m_scrollOrientationSameAsFlow);
			bool flag2 = isWrapping && (Minor(m_lastAvailableSize) != Minor(availableSize) || m_lastItemSpacing != minItemSpacing || m_collectionChangePending);
			int recommendedAnchorIndex = m_context.RecommendedAnchorIndex;
			if (recommendedAnchorIndex >= 0 && m_elementManager.IsDataIndexRealized(recommendedAnchorIndex))
			{
				num = m_algorithmCallbacks.Algorithm_GetAnchorForTargetElement(recommendedAnchorIndex, availableSize, context).Index;
				if (m_elementManager.IsDataIndexRealized(num))
				{
					Rect layoutBoundsForDataIndex = m_elementManager.GetLayoutBoundsForDataIndex(num);
					point = ((!flag2) ? new Point(layoutBoundsForDataIndex.X, layoutBoundsForDataIndex.Y) : MinorMajorPoint(0f, (float)MajorStart(layoutBoundsForDataIndex)));
				}
				else
				{
					int dataIndexFromRealizedRangeIndex = m_elementManager.GetDataIndexFromRealizedRangeIndex(0);
					for (int num2 = dataIndexFromRealizedRangeIndex - 1; num2 >= num; num2--)
					{
						m_elementManager.EnsureElementRealized(forward: false, num2, layoutId);
					}
					Rect layoutBoundsForDataIndex2 = m_elementManager.GetLayoutBoundsForDataIndex(recommendedAnchorIndex);
					point = MinorMajorPoint(0f, (float)MajorStart(layoutBoundsForDataIndex2));
				}
			}
			else if (flag2 || !flag)
			{
				FlowLayoutAnchorInfo flowLayoutAnchorInfo = m_algorithmCallbacks.Algorithm_GetAnchorForRealizationRect(availableSize, context);
				num = flowLayoutAnchorInfo.Index;
				point = MinorMajorPoint(0f, (float)flowLayoutAnchorInfo.Offset);
			}
			else
			{
				num = m_elementManager.GetDataIndexFromRealizedRangeIndex(0);
				Rect layoutBoundsForRealizedIndex = m_elementManager.GetLayoutBoundsForRealizedIndex(0);
				point = new Point(layoutBoundsForRealizedIndex.X, layoutBoundsForRealizedIndex.Y);
			}
		}
		m_firstRealizedDataIndexInsideRealizationWindow = (m_lastRealizedDataIndexInsideRealizationWindow = num);
		if (m_elementManager.IsIndexValidInData(num))
		{
			if (!m_elementManager.IsDataIndexRealized(num))
			{
				m_elementManager.ClearRealizedRange();
				UIElement orCreateElementAt = m_context.GetOrCreateElementAt(num, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
				m_elementManager.Add(orCreateElementAt, num);
			}
			UIElement realizedElement = m_elementManager.GetRealizedElement(num);
			Size size = MeasureElement(realizedElement, num, availableSize, m_context);
			Rect bounds = new Rect(point.X, point.Y, size.Width, size.Height);
			m_elementManager.SetLayoutBoundsForDataIndex(num, bounds);
		}
		else
		{
			m_elementManager.ClearRealizedRange();
		}
		m_lastAvailableSize = availableSize;
		m_lastItemSpacing = minItemSpacing;
		return num;
	}

	private void Generate(GenerateDirection direction, int anchorIndex, Size availableSize, double minItemSpacing, double lineSpacing, uint maxItemsPerLine, bool disableVirtualization, string layoutId)
	{
		if (anchorIndex == -1)
		{
			return;
		}
		int num = ((direction == GenerateDirection.Forward) ? 1 : (-1));
		int num2 = anchorIndex;
		int i = anchorIndex + num;
		Rect layoutBoundsForDataIndex = m_elementManager.GetLayoutBoundsForDataIndex(anchorIndex);
		double num3 = MajorStart(layoutBoundsForDataIndex);
		double num4 = MajorSize(layoutBoundsForDataIndex);
		int num5 = 1;
		bool flag = false;
		for (; m_elementManager.IsIndexValidInData(i); i += num)
		{
			if (!disableVirtualization && !ShouldContinueFillingUpSpace(num2, direction))
			{
				break;
			}
			m_elementManager.EnsureElementRealized(direction == GenerateDirection.Forward, i, layoutId);
			UIElement realizedElement = m_elementManager.GetRealizedElement(i);
			Size size = MeasureElement(realizedElement, i, availableSize, m_context);
			UIElement realizedElement2 = m_elementManager.GetRealizedElement(num2);
			Rect rect = new Rect(0.0, 0.0, size.Width, size.Height);
			Rect layoutBoundsForDataIndex2 = m_elementManager.GetLayoutBoundsForDataIndex(num2);
			if (direction == GenerateDirection.Forward)
			{
				double remainingSpace = Minor(availableSize) - (MinorStart(layoutBoundsForDataIndex2) + MinorSize(layoutBoundsForDataIndex2) + minItemSpacing + Minor(size));
				if (num5 >= maxItemsPerLine || m_algorithmCallbacks.Algorithm_ShouldBreakLine(i, remainingSpace))
				{
					SetMinorStart(ref rect, 0.0);
					SetMajorStart(ref rect, MajorStart(layoutBoundsForDataIndex2) + num4 + (double)(float)lineSpacing);
					if (flag)
					{
						for (int j = 0; j < num5; j++)
						{
							int dataIndex = i - 1 - j;
							Rect rect2 = m_elementManager.GetLayoutBoundsForDataIndex(dataIndex);
							SetMajorSize(ref rect2, num4);
							m_elementManager.SetLayoutBoundsForDataIndex(dataIndex, rect2);
						}
					}
					num4 = MajorSize(rect);
					num3 = MajorStart(rect);
					flag = false;
					num5 = 1;
				}
				else
				{
					SetMinorStart(ref rect, MinorStart(layoutBoundsForDataIndex2) + MinorSize(layoutBoundsForDataIndex2) + (double)(float)minItemSpacing);
					SetMajorStart(ref rect, num3);
					num4 = Math.Max(num4, MajorSize(rect));
					flag = MajorSize(layoutBoundsForDataIndex2) != MajorSize(rect);
					num5++;
				}
			}
			else
			{
				double remainingSpace2 = MinorStart(layoutBoundsForDataIndex2) - (Minor(size) + (double)(float)minItemSpacing);
				if (num5 >= maxItemsPerLine || m_algorithmCallbacks.Algorithm_ShouldBreakLine(i, remainingSpace2))
				{
					double num6 = Minor(availableSize);
					SetMinorStart(ref rect, num6.IsFinite() ? (num6 - Minor(size)) : (MinorSize(LastExtent) - Minor(size)));
					SetMajorStart(ref rect, num3 - Major(size) - (double)(float)lineSpacing);
					if (flag)
					{
						double num7 = MajorStart(m_elementManager.GetLayoutBoundsForDataIndex(i + num5 + 1));
						for (uint num8 = 0u; num8 < num5; num8++)
						{
							int num9 = i + 1 + (int)num8;
							if (num9 != anchorIndex)
							{
								Rect rect3 = m_elementManager.GetLayoutBoundsForDataIndex(num9);
								SetMajorStart(ref rect3, num7 - num4 - (double)(float)lineSpacing);
								SetMajorSize(ref rect3, num4);
								m_elementManager.SetLayoutBoundsForDataIndex(num9, rect3);
							}
						}
					}
					num4 = MajorSize(rect);
					num3 = MajorStart(rect);
					flag = false;
					num5 = 1;
				}
				else
				{
					SetMinorStart(ref rect, MinorStart(layoutBoundsForDataIndex2) - Minor(size) - (double)(float)minItemSpacing);
					SetMajorStart(ref rect, num3);
					num4 = Math.Max(num4, MajorSize(rect));
					flag = MajorSize(layoutBoundsForDataIndex2) != MajorSize(rect);
					num5++;
				}
			}
			m_elementManager.SetLayoutBoundsForDataIndex(i, rect);
			num2 = i;
		}
		if (direction == GenerateDirection.Forward)
		{
			int itemCount = m_context.ItemCount;
			m_lastRealizedDataIndexInsideRealizationWindow = ((num2 == itemCount - 1) ? (itemCount - 1) : (num2 - 1));
			m_lastRealizedDataIndexInsideRealizationWindow = Math.Max(0, m_lastRealizedDataIndexInsideRealizationWindow);
		}
		else
		{
			int itemCount2 = m_context.ItemCount;
			m_firstRealizedDataIndexInsideRealizationWindow = ((num2 != 0) ? (num2 + 1) : 0);
			m_firstRealizedDataIndexInsideRealizationWindow = Math.Min(itemCount2 - 1, m_firstRealizedDataIndexInsideRealizationWindow);
		}
		m_elementManager.DiscardElementsOutsideWindow(direction == GenerateDirection.Forward, i);
	}

	private bool ShouldContinueFillingUpSpace(int index, GenerateDirection direction)
	{
		bool flag = false;
		if (!IsVirtualizingContext)
		{
			return true;
		}
		Rect realizationRect = m_context.RealizationRect;
		Rect layoutBoundsForDataIndex = m_elementManager.GetLayoutBoundsForDataIndex(index);
		double num = MajorStart(layoutBoundsForDataIndex);
		double num2 = MajorEnd(layoutBoundsForDataIndex);
		double num3 = MajorStart(realizationRect);
		double num4 = MajorEnd(realizationRect);
		double num5 = MinorStart(layoutBoundsForDataIndex);
		double num6 = MinorEnd(layoutBoundsForDataIndex);
		double num7 = MinorStart(realizationRect);
		double num8 = MinorEnd(realizationRect);
		return (direction != 0) ? (num2 > num3 && num6 > num7) : (num < num4 && num5 < num8);
	}

	private Rect EstimateExtent(Size availableSize, string layoutId)
	{
		UIElement firstRealized = null;
		Rect firstRealizedLayoutBounds = default(Rect);
		UIElement lastRealized = null;
		Rect lastRealizedLayoutBounds = default(Rect);
		int firstRealizedItemIndex = -1;
		int lastRealizedItemIndex = -1;
		if (m_elementManager.GetRealizedElementCount > 0)
		{
			firstRealized = m_elementManager.GetAt(0);
			firstRealizedLayoutBounds = m_elementManager.GetLayoutBoundsForRealizedIndex(0);
			firstRealizedItemIndex = m_elementManager.GetDataIndexFromRealizedRangeIndex(0);
			int num = m_elementManager.GetRealizedElementCount - 1;
			lastRealized = m_elementManager.GetAt(num);
			lastRealizedItemIndex = m_elementManager.GetDataIndexFromRealizedRangeIndex(num);
			lastRealizedLayoutBounds = m_elementManager.GetLayoutBoundsForRealizedIndex(num);
		}
		return m_algorithmCallbacks.Algorithm_GetExtent(availableSize, m_context, firstRealized, firstRealizedItemIndex, firstRealizedLayoutBounds, lastRealized, lastRealizedItemIndex, lastRealizedLayoutBounds);
	}

	private void RaiseLineArranged()
	{
		Rect realizationRect = RealizationRect;
		if (realizationRect.Width == 0.0 && realizationRect.Height == 0.0)
		{
			return;
		}
		int getRealizedElementCount = m_elementManager.GetRealizedElementCount;
		if (getRealizedElementCount <= 0)
		{
			return;
		}
		int num = 0;
		Rect layoutBoundsForDataIndex = m_elementManager.GetLayoutBoundsForDataIndex(m_firstRealizedDataIndexInsideRealizationWindow);
		double num2 = MajorStart(layoutBoundsForDataIndex);
		double num3 = MajorSize(layoutBoundsForDataIndex);
		for (int i = m_firstRealizedDataIndexInsideRealizationWindow; i <= m_lastRealizedDataIndexInsideRealizationWindow; i++)
		{
			Rect layoutBoundsForDataIndex2 = m_elementManager.GetLayoutBoundsForDataIndex(i);
			if (MajorStart(layoutBoundsForDataIndex2) != num2)
			{
				m_algorithmCallbacks.Algorithm_OnLineArranged(i - num, num, num3, m_context);
				num = 0;
				num2 = MajorStart(layoutBoundsForDataIndex2);
				num3 = 0.0;
			}
			num3 = Math.Max((float)num3, MajorSize(layoutBoundsForDataIndex2));
			num++;
			layoutBoundsForDataIndex = layoutBoundsForDataIndex2;
		}
		m_algorithmCallbacks.Algorithm_OnLineArranged(m_lastRealizedDataIndexInsideRealizationWindow - num + 1, num, num3, m_context);
	}

	private void ArrangeVirtualizingLayout(Size finalSize, FlowLayoutLineAlignment lineAlignment, bool isWrapping, string layoutId)
	{
		int getRealizedElementCount = m_elementManager.GetRealizedElementCount;
		if (getRealizedElementCount <= 0)
		{
			return;
		}
		int num = 1;
		Rect rect = m_elementManager.GetLayoutBoundsForRealizedIndex(0);
		double num2 = MajorStart(rect);
		double num3 = MinorStart(rect);
		double num4 = 0.0;
		double num5 = MajorSize(rect);
		for (int i = 1; i < getRealizedElementCount; i++)
		{
			Rect layoutBoundsForRealizedIndex = m_elementManager.GetLayoutBoundsForRealizedIndex(i);
			if (MajorStart(layoutBoundsForRealizedIndex) != num2)
			{
				num4 = Minor(finalSize) - MinorStart(rect) - MinorSize(rect);
				PerformLineAlignment(i - num, num, (float)num3, (float)num4, (float)num5, lineAlignment, isWrapping, finalSize, layoutId);
				num3 = MinorStart(layoutBoundsForRealizedIndex);
				num = 0;
				num2 = MajorStart(layoutBoundsForRealizedIndex);
				num5 = 0.0;
			}
			num++;
			num5 = Math.Max(num5, MajorSize(layoutBoundsForRealizedIndex));
			rect = layoutBoundsForRealizedIndex;
		}
		if (num > 0)
		{
			double num6 = Minor(finalSize) - MinorStart(rect) - MinorSize(rect);
			PerformLineAlignment(getRealizedElementCount - num, num, (float)num3, (float)num6, (float)num5, lineAlignment, isWrapping, finalSize, layoutId);
		}
	}

	private void PerformLineAlignment(int lineStartIndex, int countInLine, float spaceAtLineStart, float spaceAtLineEnd, float lineSize, FlowLayoutLineAlignment lineAlignment, bool isWrapping, Size finalSize, string layoutId)
	{
		for (int i = lineStartIndex; i < lineStartIndex + countInLine; i++)
		{
			Rect rect = m_elementManager.GetLayoutBoundsForRealizedIndex(i);
			SetMajorSize(ref rect, lineSize);
			if (!m_scrollOrientationSameAsFlow && (spaceAtLineStart != 0f || spaceAtLineEnd != 0f))
			{
				float num = spaceAtLineStart + spaceAtLineEnd;
				switch (lineAlignment)
				{
				case FlowLayoutLineAlignment.Start:
					AddMinorStart(ref rect, 0f - spaceAtLineStart);
					break;
				case FlowLayoutLineAlignment.End:
					AddMinorStart(ref rect, spaceAtLineEnd);
					break;
				case FlowLayoutLineAlignment.Center:
					AddMinorStart(ref rect, 0f - spaceAtLineStart);
					AddMinorStart(ref rect, num / 2f);
					break;
				case FlowLayoutLineAlignment.SpaceAround:
				{
					float num3 = ((countInLine >= 1) ? (num / (float)(countInLine * 2)) : 0f);
					AddMinorStart(ref rect, 0f - spaceAtLineStart);
					AddMinorStart(ref rect, num3 * (float)((i - lineStartIndex + 1) * 2 - 1));
					break;
				}
				case FlowLayoutLineAlignment.SpaceBetween:
				{
					float num4 = ((countInLine > 1) ? (num / (float)(countInLine - 1)) : 0f);
					AddMinorStart(ref rect, 0f - spaceAtLineStart);
					AddMinorStart(ref rect, num4 * (float)(i - lineStartIndex));
					break;
				}
				case FlowLayoutLineAlignment.SpaceEvenly:
				{
					float num2 = ((countInLine >= 1) ? (num / (float)(countInLine + 1)) : 0f);
					AddMinorStart(ref rect, 0f - spaceAtLineStart);
					AddMinorStart(ref rect, num2 * (float)(i - lineStartIndex + 1));
					break;
				}
				}
			}
			rect.X -= m_lastExtent.X;
			rect.Y -= m_lastExtent.Y;
			if (!isWrapping)
			{
				SetMinorSize(ref rect, Math.Max(MinorSize(rect), Minor(finalSize)));
			}
			UIElement at = m_elementManager.GetAt(i);
			at.Arrange(rect);
		}
	}

	private void SetLayoutOrigin()
	{
		if (IsVirtualizingContext)
		{
			m_context.LayoutOrigin = new Point(m_lastExtent.X, m_lastExtent.Y);
		}
	}

	internal UIElement GetElementIfRealized(int dataIndex)
	{
		if (m_elementManager.IsDataIndexRealized(dataIndex))
		{
			return m_elementManager.GetRealizedElement(dataIndex);
		}
		return null;
	}

	private bool TryAddElement0(UIElement element)
	{
		if (m_elementManager.GetRealizedElementCount == 0)
		{
			m_elementManager.Add(element, 0);
			return true;
		}
		return false;
	}

	private protected double Major(Size size)
	{
		return OrientationBasedMeasuresExtensions.Major(this, size);
	}

	private protected double Minor(Size size)
	{
		return OrientationBasedMeasuresExtensions.Minor(this, size);
	}

	private protected double MajorSize(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MajorSize(this, rect);
	}

	private protected double MinorSize(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MinorSize(this, rect);
	}

	private protected double MajorStart(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MajorStart(this, rect);
	}

	private protected double MajorEnd(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MajorEnd(this, rect);
	}

	private protected double MinorStart(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MinorStart(this, rect);
	}

	private protected double MinorEnd(Rect rect)
	{
		return OrientationBasedMeasuresExtensions.MinorEnd(this, rect);
	}

	private protected Rect MinorMajorRect(float minor, float major, float minorSize, float majorSize)
	{
		return OrientationBasedMeasuresExtensions.MinorMajorRect(this, minor, major, minorSize, majorSize);
	}

	private protected Point MinorMajorPoint(float minor, float major)
	{
		return OrientationBasedMeasuresExtensions.MinorMajorPoint(this, minor, major);
	}

	private protected Size MinorMajorSize(float minor, float major)
	{
		return OrientationBasedMeasuresExtensions.MinorMajorSize(this, minor, major);
	}

	private protected void SetMajorSize(ref Rect rect, double value)
	{
		OrientationBasedMeasuresExtensions.SetMajorSize(this, ref rect, value);
	}

	private protected void SetMajorStart(ref Rect rect, double value)
	{
		OrientationBasedMeasuresExtensions.SetMajorStart(this, ref rect, value);
	}

	private protected void SetMinorSize(ref Rect rect, double value)
	{
		OrientationBasedMeasuresExtensions.SetMinorSize(this, ref rect, value);
	}

	private protected void SetMinorStart(ref Rect rect, double value)
	{
		OrientationBasedMeasuresExtensions.SetMinorStart(this, ref rect, value);
	}

	private protected void AddMinorStart(ref Rect rect, double increment)
	{
		OrientationBasedMeasuresExtensions.AddMinorStart(this, ref rect, increment);
	}
}
