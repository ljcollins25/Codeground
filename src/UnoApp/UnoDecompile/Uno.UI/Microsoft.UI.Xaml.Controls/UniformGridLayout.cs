using System;
using System.Collections.Specialized;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class UniformGridLayout : VirtualizingLayout, IFlowLayoutAlgorithmDelegates, OrientationBasedMeasures
{
	private double m_minItemWidth = double.NaN;

	private double m_minItemHeight = double.NaN;

	private double m_minRowSpacing;

	private double m_minColumnSpacing;

	private UniformGridLayoutItemsJustification m_itemsJustification;

	private UniformGridLayoutItemsStretch m_itemsStretch;

	private uint m_maximumRowsOrColumns = uint.MaxValue;

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

	public static DependencyProperty ItemsJustificationProperty { get; } = DependencyProperty.Register("ItemsJustification", typeof(UniformGridLayoutItemsJustification), typeof(UniformGridLayout), new FrameworkPropertyMetadata(UniformGridLayoutItemsJustification.Start));


	public UniformGridLayoutItemsJustification ItemsJustification
	{
		get
		{
			return (UniformGridLayoutItemsJustification)GetValue(ItemsJustificationProperty);
		}
		set
		{
			SetValue(ItemsJustificationProperty, value);
		}
	}

	public static DependencyProperty ItemsStretchProperty { get; } = DependencyProperty.Register("ItemsStretch", typeof(UniformGridLayoutItemsStretch), typeof(UniformGridLayout), new FrameworkPropertyMetadata(UniformGridLayoutItemsStretch.None));


	public UniformGridLayoutItemsStretch ItemsStretch
	{
		get
		{
			return (UniformGridLayoutItemsStretch)GetValue(ItemsStretchProperty);
		}
		set
		{
			SetValue(ItemsStretchProperty, value);
		}
	}

	public static DependencyProperty MaximumRowsOrColumnsProperty { get; } = DependencyProperty.Register("MaximumRowsOrColumns", typeof(int), typeof(UniformGridLayout), new FrameworkPropertyMetadata(-1));


	public int MaximumRowsOrColumns
	{
		get
		{
			return (int)GetValue(MaximumRowsOrColumnsProperty);
		}
		set
		{
			SetValue(MaximumRowsOrColumnsProperty, value);
		}
	}

	public static DependencyProperty MinColumnSpacingProperty { get; } = DependencyProperty.Register("MinColumnSpacing", typeof(double), typeof(UniformGridLayout), new FrameworkPropertyMetadata(0.0));


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

	public static DependencyProperty MinItemHeightProperty { get; } = DependencyProperty.Register("MinItemHeight", typeof(double), typeof(UniformGridLayout), new FrameworkPropertyMetadata(0.0));


	public double MinItemHeight
	{
		get
		{
			return (double)GetValue(MinItemHeightProperty);
		}
		set
		{
			SetValue(MinItemHeightProperty, value);
		}
	}

	public static DependencyProperty MinItemWidthProperty { get; } = DependencyProperty.Register("MinItemWidth", typeof(double), typeof(UniformGridLayout), new FrameworkPropertyMetadata(0.0));


	public double MinItemWidth
	{
		get
		{
			return (double)GetValue(MinItemWidthProperty);
		}
		set
		{
			SetValue(MinItemWidthProperty, value);
		}
	}

	public static DependencyProperty MinRowSpacingProperty { get; } = DependencyProperty.Register("MinRowSpacing", typeof(double), typeof(UniformGridLayout), new FrameworkPropertyMetadata(0.0));


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

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(UniformGridLayout), new FrameworkPropertyMetadata(Orientation.Horizontal));


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

	public UniformGridLayout()
	{
		this.RegisterDisposablePropertyChangedCallback(delegate(ManagedWeakReference i, DependencyProperty s, DependencyPropertyChangedEventArgs e)
		{
			OnPropertyChanged(e);
		});
		base.LayoutId = "UniformGridLayout";
	}

	protected internal override void InitializeForContextCore(VirtualizingLayoutContext context)
	{
		object layoutState = context.LayoutState;
		UniformGridLayoutState uniformGridLayoutState = null;
		if (layoutState != null)
		{
			uniformGridLayoutState = GetAsGridState(layoutState);
		}
		if (uniformGridLayoutState == null)
		{
			if (layoutState != null)
			{
				throw new InvalidOperationException("LayoutState must derive from UniformGridLayoutState.");
			}
			uniformGridLayoutState = new UniformGridLayoutState();
		}
		uniformGridLayoutState.InitializeForContext(context, this);
	}

	protected internal override void UninitializeForContextCore(VirtualizingLayoutContext context)
	{
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		asGridState.UninitializeForContext(context);
	}

	protected internal override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
	{
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		asGridState.EnsureElementSize(availableSize, context, m_minItemWidth, m_minItemHeight, m_itemsStretch, Orientation, MinRowSpacing, MinColumnSpacing, m_maximumRowsOrColumns);
		Size size = GetFlowAlgorithm(context).Measure(availableSize, context, isWrapping: true, MinItemSpacing(), LineSpacing(), m_maximumRowsOrColumns, ScrollOrientation, disableVirtualization: false, base.LayoutId);
		return new Size(size.Width, size.Height);
	}

	protected internal override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
	{
		Size size = GetFlowAlgorithm(context).Arrange(finalSize, context, isWrapping: true, (FlowLayoutLineAlignment)m_itemsJustification, base.LayoutId);
		return new Size(size.Width, size.Height);
	}

	protected internal override void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
	{
		GetFlowAlgorithm(context).OnItemsSourceChanged(source, args, context);
		InvalidateLayout();
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetMeasureSize(int index, Size availableSize, VirtualizingLayoutContext context)
	{
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		return new Size((float)asGridState.EffectiveItemWidth(), (float)asGridState.EffectiveItemHeight());
	}

	Size IFlowLayoutAlgorithmDelegates.Algorithm_GetProvisionalArrangeSize(int index, Size measureSize, Size desiredSize, VirtualizingLayoutContext context)
	{
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		return new Size((float)asGridState.EffectiveItemWidth(), (float)asGridState.EffectiveItemHeight());
	}

	bool IFlowLayoutAlgorithmDelegates.Algorithm_ShouldBreakLine(int index, double remainingSpace)
	{
		return remainingSpace < 0.0;
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForRealizationRect(Size availableSize, VirtualizingLayoutContext context)
	{
		Rect rect = new Rect(double.NaN, double.NaN, double.NaN, double.NaN);
		int index = -1;
		int itemCount = context.ItemCount;
		Rect realizationRect = context.RealizationRect;
		if ((itemCount > 0) & (MajorSize(realizationRect) > 0.0))
		{
			UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
			Rect lastExtent = asGridState.FlowAlgorithm().LastExtent;
			uint itemsPerLine = GetItemsPerLine(availableSize, context);
			double num = (double)((long)itemCount / (long)itemsPerLine) * (double)GetMajorSizeWithSpacing(context);
			double num2 = MajorStart(realizationRect) - MajorStart(lastExtent);
			if (num2 + MajorSize(realizationRect) >= 0.0 && num2 <= num)
			{
				double num3 = Math.Max(0.0, MajorStart(realizationRect) - MajorStart(lastExtent));
				int num4 = (int)(num3 / (double)GetMajorSizeWithSpacing(context));
				index = (int)Math.Max(0L, Math.Min(itemCount - 1, num4 * itemsPerLine));
				rect = GetLayoutRectForDataIndex(availableSize, (uint)index, lastExtent, context);
			}
		}
		double offset = MajorStart(rect);
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	FlowLayoutAnchorInfo IFlowLayoutAlgorithmDelegates.Algorithm_GetAnchorForTargetElement(int targetIndex, Size availableSize, VirtualizingLayoutContext context)
	{
		int index = -1;
		double offset = double.NaN;
		int itemCount = context.ItemCount;
		if (targetIndex >= 0 && targetIndex < itemCount)
		{
			uint itemsPerLine = GetItemsPerLine(availableSize, context);
			long num = (long)targetIndex / (long)itemsPerLine * itemsPerLine;
			index = (int)num;
			UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
			offset = MajorStart(GetLayoutRectForDataIndex(availableSize, (uint)index, asGridState.FlowAlgorithm().LastExtent, context));
		}
		return new FlowLayoutAnchorInfo(in index, in offset);
	}

	Rect IFlowLayoutAlgorithmDelegates.Algorithm_GetExtent(Size availableSize, VirtualizingLayoutContext context, UIElement firstRealized, int firstRealizedItemIndex, Rect firstRealizedLayoutBounds, UIElement lastRealized, int lastRealizedItemIndex, Rect lastRealizedLayoutBounds)
	{
		Rect rect = default(Rect);
		uint itemCount = (uint)context.ItemCount;
		double num = Minor(availableSize);
		uint num2 = Math.Min(Math.Max(1u, num.IsFinite() ? ((uint)((num + MinItemSpacing()) / (double)GetMinorSizeWithSpacing(context))) : itemCount), Math.Max(1u, m_maximumRowsOrColumns));
		float majorSizeWithSpacing = GetMajorSizeWithSpacing(context);
		if (itemCount != 0)
		{
			SetMinorSize(ref rect, (num.IsFinite() && m_itemsStretch == UniformGridLayoutItemsStretch.Fill) ? num : ((double)Math.Max(0f, (float)num2 * GetMinorSizeWithSpacing(context) - (float)MinItemSpacing())));
			SetMajorSize(ref rect, Math.Max(0f, (float)(itemCount / num2) * majorSizeWithSpacing - (float)LineSpacing()));
			if (firstRealized != null)
			{
				SetMajorStart(ref rect, MajorStart(firstRealizedLayoutBounds) - (double)((float)((long)firstRealizedItemIndex / (long)num2) * majorSizeWithSpacing));
				long num3 = itemCount - lastRealizedItemIndex - 1;
				SetMajorSize(ref rect, MajorEnd(lastRealizedLayoutBounds) - MajorStart(rect) + (double)((float)(num3 / (long)num2) * majorSizeWithSpacing));
			}
		}
		return rect;
	}

	void IFlowLayoutAlgorithmDelegates.Algorithm_OnElementMeasured(UIElement element, int index, Size availableSize, Size measureSize, Size desiredSize, Size provisionalArrangeSize, VirtualizingLayoutContext context)
	{
	}

	void IFlowLayoutAlgorithmDelegates.Algorithm_OnLineArranged(int startIndex, int countInLine, double lineSize, VirtualizingLayoutContext context)
	{
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
		else if (property == ItemsJustificationProperty)
		{
			m_itemsJustification = (UniformGridLayoutItemsJustification)args.NewValue;
		}
		else if (property == ItemsStretchProperty)
		{
			m_itemsStretch = (UniformGridLayoutItemsStretch)args.NewValue;
		}
		else if (property == MinItemWidthProperty)
		{
			m_minItemWidth = (double)args.NewValue;
		}
		else if (property == MinItemHeightProperty)
		{
			m_minItemHeight = (double)args.NewValue;
		}
		else if (property == MaximumRowsOrColumnsProperty)
		{
			m_maximumRowsOrColumns = (uint)(int)args.NewValue;
		}
		InvalidateLayout();
	}

	private uint GetItemsPerLine(Size availableSize, VirtualizingLayoutContext context)
	{
		return Math.Min(Math.Max(1u, (uint)((Minor(availableSize) + MinItemSpacing()) / (double)GetMinorSizeWithSpacing(context))), Math.Max(1u, m_maximumRowsOrColumns));
	}

	private float GetMinorSizeWithSpacing(VirtualizingLayoutContext context)
	{
		double num = MinItemSpacing();
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		if (ScrollOrientation != 0)
		{
			return (float)(asGridState.EffectiveItemHeight() + num);
		}
		return (float)(asGridState.EffectiveItemWidth() + num);
	}

	private float GetMajorSizeWithSpacing(VirtualizingLayoutContext context)
	{
		double num = LineSpacing();
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		if (ScrollOrientation != 0)
		{
			return (float)(asGridState.EffectiveItemWidth() + num);
		}
		return (float)(asGridState.EffectiveItemHeight() + num);
	}

	private Rect GetLayoutRectForDataIndex(Size availableSize, uint index, Rect lastExtent, VirtualizingLayoutContext context)
	{
		uint itemsPerLine = GetItemsPerLine(availableSize, context);
		uint num = index / itemsPerLine;
		uint num2 = index - num * itemsPerLine;
		UniformGridLayoutState asGridState = GetAsGridState(context.LayoutState);
		return MinorMajorRect((double)((float)num2 * GetMinorSizeWithSpacing(context)) + MinorStart(lastExtent), (double)((float)num * GetMajorSizeWithSpacing(context)) + MajorStart(lastExtent), (ScrollOrientation == ScrollOrientation.Vertical) ? ((float)asGridState.EffectiveItemWidth()) : ((float)asGridState.EffectiveItemHeight()), (ScrollOrientation == ScrollOrientation.Vertical) ? ((float)asGridState.EffectiveItemHeight()) : ((float)asGridState.EffectiveItemWidth()));
	}

	private UniformGridLayoutState GetAsGridState(object state)
	{
		return state as UniformGridLayoutState;
	}

	private FlowLayoutAlgorithm GetFlowAlgorithm(VirtualizingLayoutContext context)
	{
		return GetAsGridState(context.LayoutState).FlowAlgorithm();
	}

	private void InvalidateLayout()
	{
		InvalidateMeasure();
	}

	private double LineSpacing()
	{
		if (Orientation != Orientation.Horizontal)
		{
			return m_minColumnSpacing;
		}
		return m_minRowSpacing;
	}

	private double MinItemSpacing()
	{
		if (Orientation != Orientation.Horizontal)
		{
			return m_minRowSpacing;
		}
		return m_minColumnSpacing;
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

	private protected Rect MinorMajorRect(double minor, double major, double minorSize, double majorSize)
	{
		return MinorMajorRect((float)minor, (float)major, (float)minorSize, (float)majorSize);
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
