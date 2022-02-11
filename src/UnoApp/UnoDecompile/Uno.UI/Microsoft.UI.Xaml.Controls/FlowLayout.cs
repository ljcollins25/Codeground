using System;
using System.Collections.Specialized;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class FlowLayout : VirtualizingLayout, IFlowLayoutAlgorithmDelegates, OrientationBasedMeasures
{
	private double m_minRowSpacing;

	private double m_minColumnSpacing;

	private FlowLayoutLineAlignment m_lineAlignment;

	private double _uno_lastKnownAverageLineSize;

	private double LineSpacing
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return m_minColumnSpacing;
			}
			return m_minRowSpacing;
		}
	}

	private double MinItemSpacing
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return m_minRowSpacing;
			}
			return m_minColumnSpacing;
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

	public static DependencyProperty LineAlignmentProperty { get; } = DependencyProperty.Register("LineAlignment", typeof(FlowLayoutLineAlignment), typeof(FlowLayout), new FrameworkPropertyMetadata(FlowLayoutLineAlignment.Start, OnDependencyPropertyChanged));


	public FlowLayoutLineAlignment LineAlignment
	{
		get
		{
			return (FlowLayoutLineAlignment)GetValue(LineAlignmentProperty);
		}
		set
		{
			SetValue(LineAlignmentProperty, value);
		}
	}

	public static DependencyProperty MinColumnSpacingProperty { get; } = DependencyProperty.Register("MinColumnSpacing", typeof(double), typeof(FlowLayout), new FrameworkPropertyMetadata(0.0, OnDependencyPropertyChanged));


	public double MinColumnSpacing
	{
		get
		{
			return (double)GetValue(MinColumnSpacingProperty);
		}
		set
		{
			SetValue(MinColumnSpacingProperty, value);
		}
	}

	public static DependencyProperty MinRowSpacingProperty { get; } = DependencyProperty.Register("MinRowSpacing", typeof(double), typeof(FlowLayout), new FrameworkPropertyMetadata(0.0, OnDependencyPropertyChanged));


	public double MinRowSpacing
	{
		get
		{
			return (double)GetValue(MinRowSpacingProperty);
		}
		set
		{
			SetValue(MinRowSpacingProperty, value);
		}
	}

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(FlowLayout), new FrameworkPropertyMetadata(Orientation.Vertical, OnDependencyPropertyChanged));


	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	private FlowLayoutState GetAsFlowState(object state)
	{
		return state as FlowLayoutState;
	}

	private void InvalidateLayout()
	{
		InvalidateMeasure();
	}

	private FlowLayoutAlgorithm GetFlowAlgorithm(VirtualizingLayoutContext context)
	{
		return GetAsFlowState(context.LayoutState).FlowAlgorithm;
	}

	private bool DoesRealizationWindowOverlapExtent(Rect realizationWindow, Rect extent)
	{
		if (MajorEnd(realizationWindow) >= MajorStart(extent))
		{
			return MajorStart(realizationWindow) <= MajorEnd(extent);
		}
		return false;
	}

	public FlowLayout()
	{
		base.LayoutId = "FlowLayout";
	}

	protected internal override void InitializeForContextCore(VirtualizingLayoutContext context)
	{
		object layoutState = context.LayoutState;
		FlowLayoutState flowLayoutState = null;
		if (layoutState != null)
		{
			flowLayoutState = GetAsFlowState(layoutState);
		}
		if (flowLayoutState == null)
		{
			if (layoutState != null)
			{
				throw new InvalidOperationException("LayoutState must derive from FlowLayoutState.");
			}
			flowLayoutState = new FlowLayoutState();
		}
		flowLayoutState.InitializeForContext(context, this);
	}

	protected internal override void UninitializeForContextCore(VirtualizingLayoutContext context)
	{
		FlowLayoutState asFlowState = GetAsFlowState(context.LayoutState);
		asFlowState.UninitializeForContext(context);
	}

	protected internal override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
	{
		return GetFlowAlgorithm(context).Measure(availableSize, context, isWrapping: true, MinItemSpacing, LineSpacing, uint.MaxValue, ScrollOrientation, disableVirtualization: false, base.LayoutId);
	}

	protected internal override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
	{
		return GetFlowAlgorithm(context).Arrange(finalSize, context, isWrapping: true, m_lineAlignment, base.LayoutId);
	}

	protected internal override void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
	{
		GetFlowAlgorithm(context).OnItemsSourceChanged(source, args, context);
		InvalidateLayout();
	}

	protected virtual Size GetMeasureSize(int index, Size availableSize)
	{
		return availableSize;
	}

	protected virtual Size GetProvisionalArrangeSize(int index, Size measureSize, Size desiredSize)
	{
		return desiredSize;
	}

	protected virtual bool ShouldBreakLine(int index, double remainingSpace)
	{
		return remainingSpace < 0.0;
	}

	protected virtual FlowLayoutAnchorInfo GetAnchorForRealizationRect(Size availableSize, VirtualizingLayoutContext context)
	{
		int index = -1;
		double offset = double.NaN;
		int itemCount = context.ItemCount;
		if (itemCount > 0)
		{
			Rect realizationRect = context.RealizationRect;
			object layoutState = context.LayoutState;
			FlowLayoutState asFlowState = GetAsFlowState(layoutState);
			Rect lastExtent = asFlowState.FlowAlgorithm.LastExtent;
			double avgCountInLine = 0.0;
			double num = GetAverageLineInfo(availableSize, context, asFlowState, out avgCountInLine) + LineSpacing;
			double num2 = ((MajorSize(lastExtent) == 0.0) ? ((double)itemCount / avgCountInLine * num) : MajorSize(lastExtent));
			if (itemCount > 0 && MajorSize(realizationRect) > 0.0 && DoesRealizationWindowOverlapExtent(realizationRect, MinorMajorRect((float)MinorStart(lastExtent), (float)MajorStart(lastExtent), (float)Minor(availableSize), (float)num2)))
			{
				double num3 = MajorStart(realizationRect) - MajorStart(lastExtent);
				int num4 = Math.Max(0, (int)(num3 / num));
				index = (int)((double)num4 * avgCountInLine);
				index = Math.Max(0, Math.Min(itemCount - 1, index));
				offset = (double)num4 * num + MajorStart(lastExtent);
			}
		}
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	protected virtual FlowLayoutAnchorInfo GetAnchorForTargetElement(int targetIndex, Size availableSize, VirtualizingLayoutContext context)
	{
		double offset = double.NaN;
		int index = -1;
		int itemCount = context.ItemCount;
		if (targetIndex >= 0 && targetIndex < itemCount)
		{
			index = targetIndex;
			object layoutState = context.LayoutState;
			FlowLayoutState asFlowState = GetAsFlowState(layoutState);
			double avgCountInLine = 0.0;
			double num = GetAverageLineInfo(availableSize, context, asFlowState, out avgCountInLine) + LineSpacing;
			int num2 = (int)((double)targetIndex / avgCountInLine);
			offset = (double)num2 * num + MajorStart(asFlowState.FlowAlgorithm.LastExtent);
		}
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	protected virtual Rect GetExtent(Size availableSize, VirtualizingLayoutContext context, UIElement firstRealized, int firstRealizedItemIndex, Rect firstRealizedLayoutBounds, UIElement lastRealized, int lastRealizedItemIndex, Rect lastRealizedLayoutBounds)
	{
		Rect rect = default(Rect);
		int itemCount = context.ItemCount;
		if (itemCount > 0)
		{
			float num = (float)Minor(availableSize);
			object layoutState = context.LayoutState;
			FlowLayoutState asFlowState = GetAsFlowState(layoutState);
			double avgCountInLine = 0.0;
			double num2 = GetAverageLineInfo(availableSize, context, asFlowState, out avgCountInLine) + LineSpacing;
			if (firstRealized == null)
			{
				double lineSpacing = LineSpacing;
				double minItemSpacing = MinItemSpacing;
				int num3 = (int)Math.Ceiling((double)itemCount / avgCountInLine);
				return num.IsFinite() ? MinorMajorRect(0f, 0f, num, Math.Max(0f, (float)((double)num3 * num2 - lineSpacing))) : MinorMajorRect(0f, 0f, Math.Max(0f, (float)((Minor(asFlowState.SpecialElementDesiredSize) + minItemSpacing) * (double)itemCount - minItemSpacing)), Math.Max(0f, (float)(num2 - lineSpacing)));
			}
			int num4 = (int)((double)firstRealizedItemIndex / avgCountInLine);
			double value = MajorStart(firstRealizedLayoutBounds) - (double)num4 * num2;
			SetMajorStart(ref rect, value);
			int num5 = itemCount - lastRealizedItemIndex - 1;
			int num6 = (int)((double)num5 / avgCountInLine);
			double value2 = MajorEnd(lastRealizedLayoutBounds) - MajorStart(rect) + (double)num6 * num2;
			SetMajorSize(ref rect, value2);
			SetMinorSize(ref rect, num.IsFinite() ? ((double)num) : Math.Max(0.0, MinorEnd(lastRealizedLayoutBounds)));
		}
		return rect;
	}

	protected virtual void OnElementMeasured(UIElement element, int index, Size availableSize, Size measureSize, Size desiredSize, Size provisionalArrangeSize, VirtualizingLayoutContext context)
	{
	}

	protected virtual void OnLineArranged(int startIndex, int countInLine, double lineSize, VirtualizingLayoutContext context)
	{
		FlowLayoutState asFlowState = GetAsFlowState(context.LayoutState);
		asFlowState.OnLineArranged(startIndex, countInLine, lineSize, context);
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetMeasureSize(int index, Size availableSize, VirtualizingLayoutContext context)
	{
		return GetMeasureSize(index, availableSize);
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetProvisionalArrangeSize(int index, Size measureSize, Size desiredSize, VirtualizingLayoutContext context)
	{
		return GetProvisionalArrangeSize(index, measureSize, desiredSize);
	}

	bool IFlowLayoutAlgorithmDelegates.Algorithm_ShouldBreakLine(int index, double remainingSpace)
	{
		return ShouldBreakLine(index, remainingSpace);
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForRealizationRect(Size availableSize, VirtualizingLayoutContext context)
	{
		return GetAnchorForRealizationRect(availableSize, context);
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForTargetElement(int targetIndex, Size availableSize, VirtualizingLayoutContext context)
	{
		return GetAnchorForTargetElement(targetIndex, availableSize, context);
	}

	Rect IFlowLayoutAlgorithmDelegates.Algorithm_GetExtent(Size availableSize, VirtualizingLayoutContext context, UIElement firstRealized, int firstRealizedItemIndex, Rect firstRealizedLayoutBounds, UIElement lastRealized, int lastRealizedItemIndex, Rect lastRealizedLayoutBounds)
	{
		return GetExtent(availableSize, context, firstRealized, firstRealizedItemIndex, firstRealizedLayoutBounds, lastRealized, lastRealizedItemIndex, lastRealizedLayoutBounds);
	}

	void IFlowLayoutAlgorithmDelegates.Algorithm_OnElementMeasured(UIElement element, int index, Size availableSize, Size measureSize, Size desiredSize, Size provisionalArrangeSize, VirtualizingLayoutContext context)
	{
		OnElementMeasured(element, index, availableSize, measureSize, desiredSize, provisionalArrangeSize, context);
	}

	void IFlowLayoutAlgorithmDelegates.Algorithm_OnLineArranged(int startIndex, int countInLine, double lineSize, VirtualizingLayoutContext context)
	{
		OnLineArranged(startIndex, countInLine, lineSize, context);
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == OrientationProperty)
		{
			Orientation orientation = (Orientation)args.NewValue;
			ScrollOrientation scrollOrientation2 = (ScrollOrientation = ((orientation != Orientation.Horizontal) ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical));
		}
		else if (property == MinColumnSpacingProperty)
		{
			m_minColumnSpacing = (double)args.NewValue;
		}
		else if (property == MinRowSpacingProperty)
		{
			m_minRowSpacing = (double)args.NewValue;
		}
		else if (property == LineAlignmentProperty)
		{
			m_lineAlignment = (FlowLayoutLineAlignment)args.NewValue;
		}
		InvalidateLayout();
	}

	private double GetAverageLineInfo(Size availableSize, VirtualizingLayoutContext context, FlowLayoutState flowState, out double avgCountInLine)
	{
		double num = 0.0;
		avgCountInLine = 1.0;
		if (flowState.TotalLinesMeasured == 0)
		{
			UIElement orCreateElementAt = context.GetOrCreateElementAt(0, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
			Size size = flowState.FlowAlgorithm.MeasureElement(orCreateElementAt, 0, availableSize, context);
			context.RecycleElement(orCreateElementAt);
			int countInLine = Math.Max(1, (int)(Minor(availableSize) / Minor(size)));
			flowState.OnLineArranged(0, countInLine, Major(size), context);
			flowState.SpecialElementDesiredSize = size;
		}
		avgCountInLine = Math.Max(1.0, flowState.TotalItemsPerLine / (double)flowState.TotalLinesMeasured);
		num = Math.Round(flowState.TotalLineSize / (double)flowState.TotalLinesMeasured);
		return _uno_lastKnownAverageLineSize = num;
	}

	protected internal override bool IsSignificantViewportChange(Rect oldViewport, Rect newViewport)
	{
		double uno_lastKnownAverageLineSize = _uno_lastKnownAverageLineSize;
		if (uno_lastKnownAverageLineSize <= 0.0)
		{
			return base.IsSignificantViewportChange(oldViewport, newViewport);
		}
		if (!(Math.Abs(MajorStart(oldViewport) - MajorStart(newViewport)) > uno_lastKnownAverageLineSize * 1.5))
		{
			return Math.Abs(MajorEnd(oldViewport) - MajorEnd(newViewport)) > uno_lastKnownAverageLineSize * 1.5;
		}
		return true;
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

	private static void OnDependencyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((FlowLayout)sender).OnPropertyChanged(args);
	}
}
