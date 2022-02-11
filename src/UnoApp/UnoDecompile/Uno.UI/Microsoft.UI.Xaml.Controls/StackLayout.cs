using System;
using System.Collections.Specialized;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class StackLayout : VirtualizingLayout, IFlowLayoutAlgorithmDelegates, OrientationBasedMeasures
{
	private double m_itemSpacing;

	private double _uno_lastKnownAverageElementSize;

	public static DependencyProperty SpacingProperty = DependencyProperty.Register("Spacing", typeof(double), typeof(StackLayout), new FrameworkPropertyMetadata(0.0, OnDependencyPropertyChanged));

	public static DependencyProperty DisableVirtualizationProperty = DependencyProperty.Register("DisableVirtualization ", typeof(bool), typeof(StackLayout), new FrameworkPropertyMetadata(false, OnDependencyPropertyChanged));

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

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(StackLayout), new FrameworkPropertyMetadata(Orientation.Vertical, OnDependencyPropertyChanged));


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

	public double Spacing
	{
		get
		{
			return (double)GetValue(SpacingProperty);
		}
		set
		{
			SetValue(SpacingProperty, value);
		}
	}

	public bool DisableVirtualization
	{
		get
		{
			return (bool)GetValue(DisableVirtualizationProperty);
		}
		set
		{
			SetValue(DisableVirtualizationProperty, value);
		}
	}

	public StackLayout()
	{
		base.LayoutId = "StackLayout";
	}

	private StackLayoutState GetAsStackState(object state)
	{
		return state as StackLayoutState;
	}

	private void InvalidateLayout()
	{
		InvalidateMeasure();
	}

	private FlowLayoutAlgorithm GetFlowAlgorithm(VirtualizingLayoutContext context)
	{
		return GetAsStackState(context.LayoutState).FlowAlgorithm;
	}

	private bool DoesRealizationWindowOverlapExtent(Rect realizationWindow, Rect extent)
	{
		if (MajorEnd(realizationWindow) >= MajorStart(extent))
		{
			return MajorStart(realizationWindow) <= MajorEnd(extent);
		}
		return false;
	}

	protected internal override void InitializeForContextCore(VirtualizingLayoutContext context)
	{
		object layoutState = context.LayoutState;
		StackLayoutState stackLayoutState = null;
		if (layoutState != null)
		{
			stackLayoutState = GetAsStackState(layoutState);
		}
		if (stackLayoutState == null)
		{
			if (layoutState != null)
			{
				throw new InvalidOperationException("LayoutState must derive from StackLayoutState.");
			}
			stackLayoutState = new StackLayoutState();
		}
		stackLayoutState.InitializeForContext(context, this);
	}

	protected internal override void UninitializeForContextCore(VirtualizingLayoutContext context)
	{
		StackLayoutState asStackState = GetAsStackState(context.LayoutState);
		asStackState.UninitializeForContext(context);
	}

	protected internal override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
	{
		GetAsStackState(context.LayoutState).OnMeasureStart();
		return GetFlowAlgorithm(context).Measure(availableSize, context, isWrapping: false, 0.0, m_itemSpacing, uint.MaxValue, ScrollOrientation, DisableVirtualization, base.LayoutId);
	}

	protected internal override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
	{
		return GetFlowAlgorithm(context).Arrange(finalSize, context, isWrapping: false, FlowLayoutLineAlignment.Start, base.LayoutId);
	}

	protected internal override void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
	{
		GetFlowAlgorithm(context).OnItemsSourceChanged(source, args, context);
		InvalidateLayout();
	}

	private FlowLayoutAnchorInfo GetAnchorForRealizationRect(Size availableSize, VirtualizingLayoutContext context)
	{
		int index = -1;
		double offset = double.NaN;
		int itemCount = context.ItemCount;
		if (itemCount > 0)
		{
			Rect realizationRect = context.RealizationRect;
			StackLayoutState asStackState = GetAsStackState(context.LayoutState);
			Rect lastExtent = asStackState.FlowAlgorithm.LastExtent;
			double num = GetAverageElementSize(availableSize, context, asStackState) + m_itemSpacing;
			double num2 = MajorStart(realizationRect) - MajorStart(lastExtent);
			double num3 = ((MajorSize(lastExtent) == 0.0) ? Math.Max(0.0, num * (double)itemCount - m_itemSpacing) : MajorSize(lastExtent));
			if (itemCount > 0 && MajorSize(realizationRect) >= 0.0 && num2 + MajorSize(realizationRect) >= 0.0 && num2 <= num3)
			{
				index = (int)(num2 / num);
				offset = (double)index * num + MajorStart(lastExtent);
				index = Math.Max(0, Math.Min(itemCount - 1, index));
			}
		}
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	private Rect GetExtent(Size availableSize, VirtualizingLayoutContext context, UIElement firstRealized, int firstRealizedItemIndex, Rect firstRealizedLayoutBounds, UIElement lastRealized, int lastRealizedItemIndex, Rect lastRealizedLayoutBounds)
	{
		Rect rect = default(Rect);
		int itemCount = context.ItemCount;
		StackLayoutState asStackState = GetAsStackState(context.LayoutState);
		double num = GetAverageElementSize(availableSize, context, asStackState) + m_itemSpacing;
		SetMinorSize(ref rect, (float)asStackState.MaxArrangeBounds);
		SetMajorSize(ref rect, Math.Max(0f, (float)((double)itemCount * num - m_itemSpacing)));
		if (itemCount > 0 && firstRealized != null)
		{
			SetMajorStart(ref rect, (float)(MajorStart(firstRealizedLayoutBounds) - (double)firstRealizedItemIndex * num));
			int num2 = itemCount - lastRealizedItemIndex - 1;
			SetMajorSize(ref rect, MajorEnd(lastRealizedLayoutBounds) - MajorStart(rect) + (double)(float)((double)num2 * num));
		}
		return rect;
	}

	private void OnElementMeasured(UIElement element, int index, Size availableSize, Size measureSize, Size desiredSize, Size provisionalArrangeSize, VirtualizingLayoutContext context)
	{
		if (context != null)
		{
			StackLayoutState asStackState = GetAsStackState(context.LayoutState);
			asStackState.OnElementMeasured(index, Major(provisionalArrangeSize), Minor(provisionalArrangeSize));
		}
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetMeasureSize(int index, Size availableSize, VirtualizingLayoutContext context)
	{
		return availableSize;
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetProvisionalArrangeSize(int index, Size measureSize, Size desiredSize, VirtualizingLayoutContext context)
	{
		double num = Minor(measureSize);
		return MinorMajorSize((float)(num.IsFinite() ? Math.Max(num, Minor(desiredSize)) : Minor(desiredSize)), (float)Major(desiredSize));
	}

	bool IFlowLayoutAlgorithmDelegates.Algorithm_ShouldBreakLine(int index, double remainingSpace)
	{
		return true;
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForRealizationRect(Size availableSize, VirtualizingLayoutContext context)
	{
		return GetAnchorForRealizationRect(availableSize, context);
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForTargetElement(int targetIndex, Size availableSize, VirtualizingLayoutContext context)
	{
		double offset = double.NaN;
		int index = -1;
		int itemCount = context.ItemCount;
		if (targetIndex >= 0 && targetIndex < itemCount)
		{
			index = targetIndex;
			StackLayoutState asStackState = GetAsStackState(context.LayoutState);
			double num = GetAverageElementSize(availableSize, context, asStackState) + m_itemSpacing;
			offset = (double)index * num + MajorStart(asStackState.FlowAlgorithm.LastExtent);
		}
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	Rect IFlowLayoutAlgorithmDelegates.Algorithm_GetExtent(Size availableSize, VirtualizingLayoutContext context, UIElement firstRealized, int firstRealizedItemIndex, Rect firstRealizedLayoutBounds, UIElement lastRealized, int lastRealizedItemIndex, Rect lastRealizedLayoutBounds)
	{
		return GetExtent(availableSize, context, firstRealized, firstRealizedItemIndex, firstRealizedLayoutBounds, lastRealized, lastRealizedItemIndex, lastRealizedLayoutBounds);
	}

	void IFlowLayoutAlgorithmDelegates.Algorithm_OnElementMeasured(UIElement element, int index, Size availableSize, Size measureSize, Size desiredSize, Size provisionalArrangeSize, VirtualizingLayoutContext context)
	{
		OnElementMeasured(element, index, availableSize, measureSize, desiredSize, provisionalArrangeSize, context);
	}

	public void Algorithm_OnLineArranged(int startIndex, int countInLine, double lineSize, VirtualizingLayoutContext context)
	{
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == OrientationProperty)
		{
			Orientation orientation = (Orientation)args.NewValue;
			ScrollOrientation scrollOrientation2 = (ScrollOrientation = ((orientation == Orientation.Horizontal) ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical));
		}
		else if (property == SpacingProperty)
		{
			m_itemSpacing = (double)args.NewValue;
		}
		InvalidateLayout();
	}

	private double GetAverageElementSize(Size availableSize, VirtualizingLayoutContext context, StackLayoutState stackLayoutState)
	{
		double uno_lastKnownAverageElementSize = 0.0;
		if (context.ItemCount > 0)
		{
			if (stackLayoutState.TotalElementsMeasured == 0)
			{
				UIElement orCreateElementAt = context.GetOrCreateElementAt(0, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
				stackLayoutState.FlowAlgorithm.MeasureElement(orCreateElementAt, 0, availableSize, context);
				context.RecycleElement(orCreateElementAt);
			}
			uno_lastKnownAverageElementSize = Math.Round(stackLayoutState.TotalElementSize / (double)stackLayoutState.TotalElementsMeasured);
		}
		return _uno_lastKnownAverageElementSize = uno_lastKnownAverageElementSize;
	}

	protected internal override bool IsSignificantViewportChange(Rect oldViewport, Rect newViewport)
	{
		double uno_lastKnownAverageElementSize = _uno_lastKnownAverageElementSize;
		if (uno_lastKnownAverageElementSize <= 0.0)
		{
			return base.IsSignificantViewportChange(oldViewport, newViewport);
		}
		double val = Math.Max(MajorSize(oldViewport), MajorSize(newViewport));
		double num = Math.Min(uno_lastKnownAverageElementSize * 5.0, val);
		if (!(Math.Abs(MajorStart(oldViewport) - MajorStart(newViewport)) > num))
		{
			return Math.Abs(MajorEnd(oldViewport) - MajorEnd(newViewport)) > num;
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

	private protected void AddMinorStart(ref Rect rect, double increment)
	{
		OrientationBasedMeasuresExtensions.AddMinorStart(this, ref rect, increment);
	}

	private static void OnDependencyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((StackLayout)sender).OnPropertyChanged(args);
	}
}
