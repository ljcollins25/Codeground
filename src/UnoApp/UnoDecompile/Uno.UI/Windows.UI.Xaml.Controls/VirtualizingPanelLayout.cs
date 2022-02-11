using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DirectUI;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Extensions;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
public abstract class VirtualizingPanelLayout : IScrollSnapPointsInfo, DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	protected enum RelativeHeaderPlacement
	{
		Inline,
		Adjacent
	}

	protected class Line
	{
		public (FrameworkElement container, IndexPath index)[] Items { get; }

		public IndexPath FirstItem { get; }

		public IndexPath LastItem { get; }

		public int FirstItemFlat { get; }

		public FrameworkElement FirstView => Items[0].container;

		public FrameworkElement LastView => Items[Items.Length - 1].container;

		public Line(int firstItemFlat, params (FrameworkElement container, IndexPath index)[] items)
		{
			if (items.Length == 0)
			{
				throw new InvalidOperationException("Line must contain at least one view");
			}
			Items = items;
			FirstItem = items[0].index;
			LastItem = items.Last().index;
			FirstItemFlat = firstItemFlat;
		}

		public bool Contains(IndexPath index)
		{
			return Items.Any(((FrameworkElement container, IndexPath index) i) => i.index == index);
		}
	}

	private Panel? _ownerPanel;

	private VirtualizingPanelGenerator? _generator;

	private readonly Deque<Line> _materializedLines = new Deque<Line>();

	private Size _availableSize;

	private Size _lastMeasuredSize;

	private double _lastScrollOffset;

	private double _averageLineHeight;

	private IndexPath? _dynamicSeedIndex;

	private double? _dynamicSeedStart;

	private readonly Queue<CollectionChangedOperation> _pendingCollectionChanges = new Queue<CollectionChangedOperation>();

	private double? _scrollAdjustmentForCollectionChanges;

	private (double offset, double extent, object item, IndexPath? index)? _pendingReorder;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private bool IsInsidePopup { get; set; }

	public abstract Orientation ScrollOrientation { get; }

	private double GroupPaddingExtentStart
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return GroupPadding.Left;
			}
			return GroupPadding.Top;
		}
	}

	private double GroupPaddingExtentEnd
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return GroupPadding.Right;
			}
			return GroupPadding.Bottom;
		}
	}

	private double GroupPaddingBreadthStart
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return GroupPadding.Top;
			}
			return GroupPadding.Left;
		}
	}

	private double GroupPaddingBreadthEnd
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return GroupPadding.Bottom;
			}
			return GroupPadding.Right;
		}
	}

	public int FirstVisibleIndex => XamlParent?.GetIndexFromIndexPath(GetFirstVisibleIndexPath()) ?? (-1);

	public int LastVisibleIndex => XamlParent?.GetIndexFromIndexPath(GetLastVisibleIndexPath()) ?? (-1);

	protected RelativeHeaderPlacement RelativeGroupHeaderPlacement
	{
		get
		{
			if (ScrollOrientation == Orientation.Vertical && GroupHeaderPlacement == GroupHeaderPlacement.Top)
			{
				return RelativeHeaderPlacement.Inline;
			}
			if (ScrollOrientation == Orientation.Horizontal && GroupHeaderPlacement == GroupHeaderPlacement.Left)
			{
				return RelativeHeaderPlacement.Inline;
			}
			return RelativeHeaderPlacement.Adjacent;
		}
	}

	public bool AreHorizontalSnapPointsRegular => false;

	public bool AreVerticalSnapPointsRegular => false;

	internal SnapPointsType SnapPointsType
	{
		get
		{
			if (!(XamlParent is ListViewBase listViewBase))
			{
				return SnapPointsType.None;
			}
			if (ScrollOrientation == Orientation.Vertical)
			{
				return listViewBase.ScrollViewer.VerticalSnapPointsType;
			}
			return listViewBase.ScrollViewer.HorizontalSnapPointsType;
		}
	}

	internal SnapPointsAlignment SnapPointsAlignment
	{
		get
		{
			if (!(XamlParent is ListViewBase listViewBase))
			{
				return SnapPointsAlignment.Near;
			}
			if (ScrollOrientation == Orientation.Vertical)
			{
				return listViewBase.ScrollViewer.VerticalSnapPointsAlignment;
			}
			return listViewBase.ScrollViewer.HorizontalSnapPointsAlignment;
		}
	}

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

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(Orientation.Vertical, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)o).OnOrientationChanged((Orientation)e.NewValue);
	}));


	public bool ShouldBreadthStretch
	{
		get
		{
			FrameworkElement frameworkElement = (IsInsidePopup ? ((FrameworkElement)OwnerPanel) : ((FrameworkElement)XamlParent));
			if (frameworkElement == null)
			{
				return true;
			}
			if (ScrollOrientation == Orientation.Vertical)
			{
				return frameworkElement.HorizontalAlignment == HorizontalAlignment.Stretch;
			}
			return frameworkElement.VerticalAlignment == VerticalAlignment.Stretch;
		}
	}

	internal bool ShouldApplyChildStretch { get; set; } = true;


	private Panel OwnerPanel
	{
		get
		{
			return _ownerPanel ?? throw new InvalidOperationException("Initialize() was not called properly.");
		}
		set
		{
			_ownerPanel = value;
		}
	}

	private protected VirtualizingPanelGenerator Generator
	{
		get
		{
			return _generator ?? throw new InvalidOperationException("Initialize() was not called properly.");
		}
		private set
		{
			_generator = value;
		}
	}

	private ScrollViewer? ScrollViewer { get; set; }

	internal ItemsControl? ItemsControl { get; set; }

	internal ItemsControl? XamlParent => ItemsControl;

	private double AvailableBreadth
	{
		get
		{
			if (ScrollOrientation != 0)
			{
				return _availableSize.Height;
			}
			return _availableSize.Width;
		}
	}

	private double ScrollOffset
	{
		get
		{
			if (ScrollViewer == null)
			{
				return 0.0;
			}
			if (ScrollOrientation != 0)
			{
				return ScrollViewer!.HorizontalOffset;
			}
			return ScrollViewer!.VerticalOffset;
		}
	}

	private Size ViewportSize { get; set; }

	private double ViewportExtent
	{
		get
		{
			if (ScrollViewer == null)
			{
				return 1.7976931348623156E+305;
			}
			if (ScrollOrientation != 0)
			{
				return ViewportSize.Width;
			}
			return ViewportSize.Height;
		}
	}

	private double ViewportStart => ScrollOffset;

	private double ViewportEnd => ScrollOffset + ViewportExtent;

	private double ViewportExtension => CacheLength * ViewportExtent * 0.5;

	private double ExtendedViewportStart
	{
		get
		{
			double val = ViewportStart - ViewportExtension;
			return Math.Max(val, 0.0);
		}
	}

	private double ExtendedViewportEnd => ViewportEnd + ViewportExtension;

	private bool ShouldMeasuredBreadthStretch
	{
		get
		{
			if (ShouldBreadthStretch)
			{
				return GetBreadth(_availableSize) < 8.9884656743115785E+307;
			}
			return false;
		}
	}

	private double PositionOfFirstElement => 0.0;

	public bool AreStickyGroupHeadersEnabled
	{
		get
		{
			return (bool)GetValue(AreStickyGroupHeadersEnabledProperty);
		}
		set
		{
			SetValue(AreStickyGroupHeadersEnabledProperty, value);
		}
	}

	public static DependencyProperty AreStickyGroupHeadersEnabledProperty { get; } = DependencyProperty.Register("AreStickyGroupHeadersEnabled", typeof(bool), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s)?.OnAreStickyGroupHeadersEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public GroupHeaderPlacement GroupHeaderPlacement
	{
		get
		{
			return (GroupHeaderPlacement)GetValue(GroupHeaderPlacementProperty);
		}
		set
		{
			SetValue(GroupHeaderPlacementProperty, value);
		}
	}

	public static DependencyProperty GroupHeaderPlacementProperty { get; } = DependencyProperty.Register("GroupHeaderPlacement", typeof(GroupHeaderPlacement), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(GroupHeaderPlacement.Top, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s)?.OnGroupHeaderPlacementChanged((GroupHeaderPlacement)e.OldValue, (GroupHeaderPlacement)e.NewValue);
	}));


	public Thickness GroupPadding
	{
		get
		{
			return (Thickness)GetValue(GroupPaddingProperty);
		}
		set
		{
			SetValue(GroupPaddingProperty, value);
		}
	}

	public static DependencyProperty GroupPaddingProperty { get; } = DependencyProperty.Register("GroupPadding", typeof(Thickness), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(Thickness.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s)?.OnGroupPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
	}));


	public double CacheLength
	{
		get
		{
			return (double)GetValue(CacheLengthProperty);
		}
		set
		{
			SetValue(CacheLengthProperty, value);
		}
	}

	public static DependencyProperty CacheLengthProperty { get; } = DependencyProperty.Register("CacheLength", typeof(double), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s)?.OnCacheLengthChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s).OnDataContextChanged(e);
	}));


	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(VirtualizingPanelLayout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VirtualizingPanelLayout)s).OnTemplatedParentChanged(e);
	}));


	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	[NotImplemented]
	public event EventHandler<object>? HorizontalSnapPointsChanged;

	[NotImplemented]
	public event EventHandler<object>? VerticalSnapPointsChanged;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	public IReadOnlyList<float>? GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		if (orientation != ScrollOrientation)
		{
			return null;
		}
		return (from f in GetSnapPointsInner(alignment).Distinct()
			orderby f
			select f).ToList().AsReadOnly();
	}

	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		throw new NotSupportedException("Regular snap points are not supported.");
	}

	internal float? GetSnapTo(float scrollVelocity, float currentScrollOffset)
	{
		if (SnapPointsType == SnapPointsType.MandatorySingle)
		{
			IReadOnlyList<float> irregularSnapPoints = GetIrregularSnapPoints(ScrollOrientation, SnapPointsAlignment);
			if (irregularSnapPoints == null || irregularSnapPoints.Count == 0)
			{
				return null;
			}
			float adjustedOffset = AdjustOffsetForSnapPointsAlignment(currentScrollOffset);
			if (scrollVelocity == 0f)
			{
				return MinWithSelector(irregularSnapPoints, (float sp) => Math.Abs(adjustedOffset - sp)).Item;
			}
			float num = 0f;
			int num2 = ((scrollVelocity > 0f) ? 1 : (-1));
			int num3 = ((!(scrollVelocity > 0f)) ? (irregularSnapPoints.Count - 1) : 0);
			for (int i = num3; i >= 0 && i < irregularSnapPoints.Count; i += num2)
			{
				num = irregularSnapPoints[i];
				if ((scrollVelocity > 0f) ? (num > adjustedOffset) : (num < adjustedOffset))
				{
					break;
				}
			}
			return num;
		}
		return null;
	}

	protected IndexPath? GetNextUnmaterializedItem(GeneratorDirection fillDirection, IndexPath? currentMaterializedItem)
	{
		int direction = ((fillDirection == GeneratorDirection.Forward) ? 1 : (-1));
		IndexPath? indexPath = XamlParent?.GetNextItemIndex(currentMaterializedItem, direction);
		if (indexPath.HasValue)
		{
			IndexPath? andUpdateReorderingIndex = GetAndUpdateReorderingIndex();
			if (andUpdateReorderingIndex.HasValue)
			{
				IndexPath valueOrDefault = andUpdateReorderingIndex.GetValueOrDefault();
				if (indexPath == valueOrDefault)
				{
					indexPath = XamlParent?.GetNextItemIndex(indexPath, direction);
				}
			}
		}
		return indexPath;
	}

	public static (TSource Item, TComparable Value) MinWithSelector<TSource, TComparable>(IEnumerable<TSource> source, Func<TSource, TComparable> selector)
	{
		Comparer<TComparable> @default = Comparer<TComparable>.Default;
		IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			throw new InvalidOperationException("Source must contain at least one element.");
		}
		TSource val = enumerator.Current;
		TComparable val2 = selector(val);
		while (enumerator.MoveNext())
		{
			TSource current = enumerator.Current;
			TComparable val3 = selector(current);
			if (@default.Compare(val3, val2) < 0)
			{
				val = current;
				val2 = val3;
			}
		}
		return (val, val2);
	}

	internal void Initialize(Panel owner)
	{
		OwnerPanel = owner ?? throw new ArgumentNullException("owner");
		OwnerPanel.Loaded += OnLoaded;
		OwnerPanel.Unloaded += OnUnloaded;
		Generator = new VirtualizingPanelGenerator(this);
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		foreach (UIElement item in OwnerPanel.GetVisualAncestry())
		{
			if (item is ScrollViewer scrollViewer && ScrollViewer == null)
			{
				ScrollViewer = scrollViewer;
				ScrollViewer!.ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollChanged);
			}
			else if (item is ItemsControl itemsControl)
			{
				ItemsControl = itemsControl;
				break;
			}
		}
		bool flag = OwnerPanel.FindFirstParent<PopupPanel>() != null;
		bool flag2 = OwnerPanel.FindFirstParent<ListViewBase>() != null;
		IsInsidePopup = flag && !flag2;
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Calling {0} hasPopupPanelParent={1} hasListViewParent={2}", GetMethodTag("OnLoaded"), flag, flag2));
		}
		if (ItemsControl == null && OwnerPanel.TemplatedParent is ItemsControl itemsControl2)
		{
			ItemsControl = itemsControl2;
		}
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		if (ScrollViewer != null)
		{
			ScrollViewer!.ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollChanged);
		}
		ScrollViewer = null;
		ItemsControl = null;
	}

	private void OnScrollChanged(object? sender, ScrollViewerViewChangedEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Calling {0} _lastScrollOffset={1} ScrollOffset={2}", GetMethodTag("OnScrollChanged"), _lastScrollOffset, ScrollOffset));
		}
		double value = ScrollOffset - _lastScrollOffset;
		int num = Math.Sign(value);
		double num2 = Math.Abs(value);
		GeneratorDirection fillDirection = ((num <= 0) ? GeneratorDirection.Backward : GeneratorDirection.Forward);
		while (num2 > 0.0)
		{
			double num3 = (_scrollAdjustmentForCollectionChanges.HasValue ? Math.Abs(_scrollAdjustmentForCollectionChanges.Value) : GetScrollConsumptionIncrement(fillDirection));
			_scrollAdjustmentForCollectionChanges = null;
			if (num3 == 0.0)
			{
				break;
			}
			num2 -= num3;
			num2 = Math.Max(0.0, num2);
			UpdateLayout((double)num * (0.0 - num2), isScroll: true);
		}
		ArrangeElements(_availableSize, ViewportSize);
		UpdateCompleted();
		_lastScrollOffset = ScrollOffset;
	}

	private double GetScrollConsumptionIncrement(GeneratorDirection fillDirection)
	{
		FrameworkElement frameworkElement = ((fillDirection != 0) ? GetLastMaterializedLine()?.LastView : GetFirstMaterializedLine()?.FirstView);
		if (frameworkElement == null)
		{
			return _averageLineHeight;
		}
		return GetActualExtent(frameworkElement);
	}

	internal Size MeasureOverride(Size availableSize)
	{
		if (ItemsControl == null)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug("Measured without an ItemsControl: simply return size(0,0) for now...");
			}
			return new Size(0.0, 0.0);
		}
		ViewportSize = ScrollViewer?.ViewportMeasureSize ?? default(Size);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Calling {0}, availableSize={1}, _availableSize={2} {3}", GetMethodTag("MeasureOverride"), availableSize, _availableSize, GetDebugInfo()));
		}
		_availableSize = availableSize;
		UpdateAverageLineHeight();
		ScrapLayout();
		ApplyCollectionChanges();
		UpdateLayout(_scrollAdjustmentForCollectionChanges, isScroll: false);
		return _lastMeasuredSize = EstimatePanelSize(isMeasure: true);
	}

	internal Size ArrangeOverride(Size finalSize)
	{
		if (ItemsControl == null)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug("Arranged without an ItemsControl: simply return size(0,0) for now...");
			}
			return new Size(0.0, 0.0);
		}
		ViewportSize = ScrollViewer?.ViewportArrangeSize ?? default(Size);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Calling {0}, finalSize={1}, {2}", GetMethodTag("ArrangeOverride"), finalSize, GetDebugInfo()));
		}
		_availableSize = finalSize;
		Size viewportSize = ViewportSize;
		ArrangeElements(finalSize, viewportSize);
		return EstimatePanelSize(isMeasure: false);
	}

	private void ArrangeElements(Size finalSize, Size adjustedVisibleWindow)
	{
		foreach (Line materializedLine in _materializedLines)
		{
			int num = -1;
			(FrameworkElement, IndexPath)[] items = materializedLine.Items;
			for (int i = 0; i < items.Length; i++)
			{
				(FrameworkElement, IndexPath) tuple = items[i];
				num++;
				Rect boundsForElement = GetBoundsForElement(tuple.Item1);
				Rect elementArrangeBounds = GetElementArrangeBounds(materializedLine.FirstItemFlat + num, boundsForElement, adjustedVisibleWindow, finalSize);
				tuple.Item1.Arrange(elementArrangeBounds);
			}
		}
	}

	private void UpdateLayout(double? extentAdjustment, bool isScroll)
	{
		ResetReorderingIndex();
		OwnerPanel.ShouldInterceptInvalidate = true;
		UnfillLayout(extentAdjustment.GetValueOrDefault());
		FillLayout(extentAdjustment.GetValueOrDefault());
		CorrectForEstimationErrors();
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("Called {0}, {1} extentAdjustment={2}", GetMethodTag("UpdateLayout"), GetDebugInfo(), extentAdjustment));
		}
		if (!isScroll)
		{
			UpdateCompleted();
		}
		OwnerPanel.ShouldInterceptInvalidate = false;
	}

	private void UpdateCompleted()
	{
		OwnerPanel.ShouldInterceptInvalidate = ShouldMeasuredBreadthStretch;
		Generator.ClearScrappedViews();
		Generator.UpdateVisibilities();
		OwnerPanel.ShouldInterceptInvalidate = false;
	}

	private void FillLayout(double extentAdjustment)
	{
		if (!_dynamicSeedStart.HasValue)
		{
			FillBackward();
		}
		FillForward();
		IndexPath? andUpdateReorderingIndex = GetAndUpdateReorderingIndex();
		if (andUpdateReorderingIndex.HasValue)
		{
			IndexPath reorderIndex = andUpdateReorderingIndex.GetValueOrDefault();
			if (_materializedLines.None((Line line) => line.Contains(reorderIndex)))
			{
				AddLine(GeneratorDirection.Forward, reorderIndex);
			}
		}
		_dynamicSeedIndex = null;
		_dynamicSeedStart = null;
		void FillBackward()
		{
			if (GetItemsStart() > ExtendedViewportStart + extentAdjustment)
			{
				IndexPath? nextUnmaterializedItem2 = GetNextUnmaterializedItem(GeneratorDirection.Backward, GetFirstMaterializedIndexPath());
				while (nextUnmaterializedItem2.HasValue && GetItemsStart() > ExtendedViewportStart + extentAdjustment)
				{
					AddLine(GeneratorDirection.Backward, nextUnmaterializedItem2.Value);
					nextUnmaterializedItem2 = GetNextUnmaterializedItem(GeneratorDirection.Backward, GetFirstMaterializedIndexPath());
				}
			}
		}
		void FillForward()
		{
			if (GetItemsEnd().GetValueOrDefault() < ExtendedViewportEnd + extentAdjustment)
			{
				IndexPath? nextUnmaterializedItem = GetNextUnmaterializedItem(GeneratorDirection.Forward, _dynamicSeedIndex ?? GetLastMaterializedIndexPath());
				while (nextUnmaterializedItem.HasValue && GetItemsEnd().GetValueOrDefault() < ExtendedViewportEnd + extentAdjustment)
				{
					AddLine(GeneratorDirection.Forward, nextUnmaterializedItem.Value);
					nextUnmaterializedItem = GetNextUnmaterializedItem(GeneratorDirection.Forward, GetLastMaterializedIndexPath());
				}
			}
		}
	}

	private void UnfillLayout(double extentAdjustment)
	{
		UnfillBackward();
		UnfillForward();
		void UnfillBackward()
		{
			Line firstMaterializedLine = GetFirstMaterializedLine();
			while (firstMaterializedLine != null && GetMeasuredEnd(firstMaterializedLine.FirstView) < ExtendedViewportStart + extentAdjustment)
			{
				RecycleLine(firstMaterializedLine);
				_materializedLines.RemoveFromFront();
				firstMaterializedLine = GetFirstMaterializedLine();
			}
		}
		void UnfillForward()
		{
			Line lastMaterializedLine = GetLastMaterializedLine();
			while (lastMaterializedLine != null && GetMeasuredStart(lastMaterializedLine.FirstView) > ExtendedViewportEnd + extentAdjustment)
			{
				RecycleLine(lastMaterializedLine);
				_materializedLines.RemoveFromBack();
				lastMaterializedLine = GetLastMaterializedLine();
			}
		}
	}

	private void RecycleLine(Line line)
	{
		for (int i = 0; i < line.Items.Length; i++)
		{
			Generator.RecycleViewForItem(line.Items[i].container, line.FirstItemFlat + i);
		}
	}

	private void ScrapLine(Line line)
	{
		for (int i = 0; i < line.Items.Length; i++)
		{
			Generator.ScrapViewForItem(line.Items[i].container, line.FirstItemFlat + i);
		}
	}

	private void CorrectForEstimationErrors()
	{
		Line firstMaterializedLine = GetFirstMaterializedLine();
		if (firstMaterializedLine == null)
		{
			return;
		}
		double num = 0.0;
		double measuredStart = GetMeasuredStart(firstMaterializedLine.FirstView);
		if (firstMaterializedLine.FirstItemFlat == 0)
		{
			num = 0.0 - measuredStart;
		}
		else if (measuredStart < PositionOfFirstElement)
		{
			num = 0.0 - measuredStart;
		}
		if (DoubleUtil.IsZero(num))
		{
			return;
		}
		foreach (Line materializedLine in _materializedLines)
		{
			(FrameworkElement, IndexPath)[] items = materializedLine.Items;
			for (int i = 0; i < items.Length; i++)
			{
				(FrameworkElement, IndexPath) tuple = items[i];
				Rect rect = GetBoundsForElement(tuple.Item1);
				IncrementStart(ref rect, num);
				SetBounds(tuple.Item1, rect);
			}
		}
	}

	private void ApplyCollectionChanges()
	{
		if (_pendingCollectionChanges.Count == 0)
		{
			return;
		}
		Generator.UpdateForCollectionChanges(_pendingCollectionChanges);
		IndexPath? dynamicSeedIndex = _dynamicSeedIndex;
		if (dynamicSeedIndex.HasValue)
		{
			IndexPath valueOrDefault = dynamicSeedIndex.GetValueOrDefault();
			IndexPath? dynamicSeedIndex2 = CollectionChangedOperation.Offset(valueOrDefault, _pendingCollectionChanges);
			if (dynamicSeedIndex2.HasValue)
			{
				IndexPath valueOrDefault2 = dynamicSeedIndex2.GetValueOrDefault();
				_dynamicSeedIndex = dynamicSeedIndex2;
				int num = valueOrDefault2.Row - valueOrDefault.Row;
				double scrollAdjustment = (double)num * _averageLineHeight;
				ApplyScrollAdjustmentForCollectionChange(scrollAdjustment);
			}
		}
		_pendingCollectionChanges.Clear();
	}

	private void ApplyScrollAdjustmentForCollectionChange(double scrollAdjustment)
	{
		if (scrollAdjustment == 0.0)
		{
			return;
		}
		_dynamicSeedStart += scrollAdjustment;
		if ((!(scrollAdjustment < 0.0) || !IsScrolledToStart()) && (!(scrollAdjustment > 0.0) || !IsScrolledToEnd()))
		{
			_scrollAdjustmentForCollectionChanges = scrollAdjustment;
			if (ScrollOrientation == Orientation.Vertical)
			{
				ScrollViewer?.ChangeView(null, ScrollViewer!.VerticalOffset + scrollAdjustment, null, disableAnimation: true);
			}
			else
			{
				ScrollViewer?.ChangeView(ScrollViewer!.HorizontalOffset + scrollAdjustment, null, null, disableAnimation: true);
			}
		}
	}

	private bool IsScrolledToStart()
	{
		if (ScrollViewer == null)
		{
			return true;
		}
		if (ScrollOrientation != 0)
		{
			return ScrollViewer!.HorizontalOffset <= 0.0;
		}
		return ScrollViewer!.VerticalOffset <= 0.0;
	}

	private bool IsScrolledToEnd()
	{
		if (ScrollViewer == null)
		{
			return true;
		}
		if (ScrollOrientation != 0)
		{
			return ScrollViewer!.HorizontalOffset >= ScrollViewer!.ScrollableWidth;
		}
		return ScrollViewer!.VerticalOffset >= ScrollViewer!.ScrollableHeight;
	}

	private Size EstimatePanelSize(bool isMeasure)
	{
		double num = EstimatePanelExtent();
		Size size = ((ScrollOrientation == Orientation.Vertical) ? new Size(isMeasure ? CalculatePanelMeasureBreadth() : CalculatePanelArrangeBreadth(), double.IsInfinity(_availableSize.Height) ? num : Math.Max(num, _availableSize.Height)) : new Size(double.IsInfinity(_availableSize.Width) ? num : Math.Max(num, _availableSize.Width), isMeasure ? CalculatePanelMeasureBreadth() : CalculatePanelArrangeBreadth()));
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0} => {1} -> {2} {3} {4} {5} ShouldBreadthStretch:{6} XamlParent:{7} AvailableBreadth:{8}", GetMethodTag("EstimatePanelSize"), num, size, ScrollOrientation, _availableSize.Height, double.IsInfinity(_availableSize.Height), ShouldBreadthStretch, XamlParent, AvailableBreadth));
		}
		return size;
	}

	private double EstimatePanelExtent()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(GetMethodTag("EstimatePanelExtent") + " Begin");
		}
		IndexPath? lastMaterializedIndexPath = GetLastMaterializedIndexPath();
		if (!lastMaterializedIndexPath.HasValue)
		{
			return 0.0;
		}
		int flatItemIndex = GetFlatItemIndex(lastMaterializedIndexPath.Value);
		ItemsControl? itemsControl = ItemsControl;
		int num = ((itemsControl != null) ? (itemsControl!.NumberOfItems - flatItemIndex - 1) : 0);
		UpdateAverageLineHeight();
		int itemsPerLine = GetItemsPerLine();
		int num2 = num / itemsPerLine + num % itemsPerLine;
		double num3 = GetContentEnd() + (double)num2 * _averageLineHeight;
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0}=>{1}, GetContentEnd()={2}, remainingLines={3}, averageLineHeight={4}", GetMethodTag("EstimatePanelExtent"), num3, GetContentEnd(), num2, _averageLineHeight));
		}
		return num3;
	}

	private void UpdateAverageLineHeight()
	{
		_averageLineHeight = ((_materializedLines.Count > 0) ? _materializedLines.Select((Line l) => GetMeasuredExtent(l.FirstView)).Average() : 0.0);
	}

	private double CalculatePanelMeasureBreadth()
	{
		return _materializedLines.Select((Line l) => GetDesiredBreadth(l.FirstView)).MaxOrDefault() + GetBreadth(XamlParent?.ScrollViewer.ScrollBarSize ?? default(Size));
	}

	private double CalculatePanelArrangeBreadth()
	{
		if (!ShouldMeasuredBreadthStretch)
		{
			return _materializedLines.Select((Line l) => GetActualBreadth(l.FirstView)).MaxOrDefault();
		}
		return AvailableBreadth;
	}

	internal void AddItems(int firstItem, int count, int section)
	{
		_pendingCollectionChanges.Enqueue(new CollectionChangedOperation(IndexPath.FromRowSection(firstItem, section), count, NotifyCollectionChangedAction.Add, CollectionChangedOperation.Element.Item));
		LightRefresh();
	}

	internal void RemoveItems(int firstItem, int count, int section)
	{
		_pendingCollectionChanges.Enqueue(new CollectionChangedOperation(IndexPath.FromRowSection(firstItem, section), count, NotifyCollectionChangedAction.Remove, CollectionChangedOperation.Element.Item));
		LightRefresh();
	}

	private void LightRefresh()
	{
		OwnerPanel?.InvalidateMeasure();
	}

	internal void Refresh()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(GetMethodTag("Refresh") ?? "");
		}
		ClearLines();
		UpdateCompleted();
		Generator.ClearIdCache();
		_pendingCollectionChanges.Clear();
		OwnerPanel?.InvalidateMeasure();
	}

	private void ClearLines()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(GetMethodTag("ClearLines") ?? "");
		}
		foreach (Line materializedLine in _materializedLines)
		{
			RecycleLine(materializedLine);
		}
		_materializedLines.Clear();
	}

	private void ScrapLayout()
	{
		IndexPath? indexPath = GetFirstMaterializedIndexPath();
		IndexPath? andUpdateReorderingIndex = GetAndUpdateReorderingIndex();
		if (andUpdateReorderingIndex.HasValue && andUpdateReorderingIndex.GetValueOrDefault() == indexPath)
		{
			indexPath = _materializedLines.SelectMany((Line line) => line.Items).Skip(1).FirstOrDefault()
				.index;
		}
		_dynamicSeedIndex = GetDynamicSeedIndex(indexPath);
		_dynamicSeedStart = GetContentStart();
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0} seed index={1} seed start={2}", GetMethodTag("ScrapLayout"), _dynamicSeedIndex, _dynamicSeedStart));
		}
		foreach (Line materializedLine in _materializedLines)
		{
			ScrapLine(materializedLine);
		}
		_materializedLines.Clear();
	}

	protected virtual IndexPath? GetDynamicSeedIndex(IndexPath? firstVisibleItem)
	{
		IndexPath? indexPath = ItemsControl?.GetLastItem();
		if (!indexPath.HasValue || (firstVisibleItem.HasValue && firstVisibleItem.Value > indexPath.Value))
		{
			return null;
		}
		return GetNextUnmaterializedItem(GeneratorDirection.Backward, firstVisibleItem);
	}

	private void OnOrientationChanged(Orientation newValue)
	{
		Refresh();
	}

	private IndexPath GetFirstVisibleIndexPath()
	{
		throw new NotImplementedException();
	}

	private IndexPath GetLastVisibleIndexPath()
	{
		throw new NotImplementedException();
	}

	private IEnumerable<float> GetSnapPointsInner(SnapPointsAlignment alignment)
	{
		throw new NotImplementedException();
	}

	private float AdjustOffsetForSnapPointsAlignment(float offset)
	{
		throw new NotImplementedException();
	}

	private void AddLine(GeneratorDirection fillDirection, IndexPath nextVisibleItem)
	{
		double extentOffset = ((fillDirection == GeneratorDirection.Backward) ? GetContentStart() : GetContentEnd());
		Line line = CreateLine(fillDirection, extentOffset, AvailableBreadth, nextVisibleItem);
		if (fillDirection == GeneratorDirection.Backward)
		{
			_materializedLines.AddToFront(line);
		}
		else
		{
			_materializedLines.AddToBack(line);
		}
		if (!line.Contains(nextVisibleItem))
		{
			AddLine(fillDirection, nextVisibleItem);
		}
	}

	protected abstract Line CreateLine(GeneratorDirection fillDirection, double extentOffset, double availableBreadth, IndexPath nextVisibleItem);

	protected abstract int GetItemsPerLine();

	protected int GetFlatItemIndex(IndexPath indexPath)
	{
		return ItemsControl?.GetIndexFromIndexPath(indexPath) ?? (-1);
	}

	protected void AddView(FrameworkElement view, GeneratorDirection fillDirection, double extentOffset, double breadthOffset)
	{
		if (view.Parent == null)
		{
			OwnerPanel.Children.Add(view);
		}
		Size availableSize = ((ScrollOrientation == Orientation.Vertical) ? new Size(AvailableBreadth, double.PositiveInfinity) : new Size(double.PositiveInfinity, AvailableBreadth));
		view.Measure(availableSize);
		double num = ((fillDirection == GeneratorDirection.Forward) ? 0.0 : (0.0 - GetExtent(view.DesiredSize)));
		Point point = ((ScrollOrientation == Orientation.Vertical) ? new Point(breadthOffset, extentOffset + num) : new Point(extentOffset + num, breadthOffset));
		Rect rect = new Rect(point, view.DesiredSize);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug(string.Format("{0} finalRect={1} AvailableBreadth={2} DesiredSize={3} DC={4}", GetMethodTag("AddView"), rect, AvailableBreadth, view.DesiredSize, view.DataContext));
		}
		SetBounds(view, rect);
	}

	protected abstract Rect GetElementArrangeBounds(int elementIndex, Rect containerBounds, Size windowConstraint, Size finalSize);

	private void SetBounds(FrameworkElement view, Rect bounds)
	{
		if (view is ContentControl contentControl)
		{
			contentControl.GetVirtualizationInformation().Bounds = bounds;
		}
		else if (this.Log().IsEnabled(LogLevel.Warning))
		{
			this.Log().LogWarning("Non-ContentControl containers aren't supported for virtualizing panel types.");
		}
	}

	private Line? GetFirstMaterializedLine()
	{
		if (_materializedLines.Count <= 0)
		{
			return null;
		}
		return _materializedLines[0];
	}

	private Line? GetLastMaterializedLine()
	{
		if (_materializedLines.Count <= 0)
		{
			return null;
		}
		return _materializedLines[_materializedLines.Count - 1];
	}

	private IndexPath? GetFirstMaterializedIndexPath()
	{
		return GetFirstMaterializedLine()?.FirstItem;
	}

	private IndexPath? GetLastMaterializedIndexPath()
	{
		return GetLastMaterializedLine()?.LastItem;
	}

	private double? GetItemsStart()
	{
		FrameworkElement frameworkElement = GetFirstMaterializedLine()?.FirstView;
		if (frameworkElement != null)
		{
			return GetMeasuredStart(frameworkElement);
		}
		return null;
	}

	private double? GetItemsEnd()
	{
		FrameworkElement frameworkElement = GetLastMaterializedLine()?.LastView;
		if (frameworkElement != null)
		{
			return GetMeasuredEnd(frameworkElement);
		}
		return _dynamicSeedStart;
	}

	private double GetContentStart()
	{
		return GetItemsStart().GetValueOrDefault();
	}

	private double GetContentEnd()
	{
		return GetItemsEnd().GetValueOrDefault();
	}

	private double GetMeasuredStart(FrameworkElement child)
	{
		Rect boundsForElement = GetBoundsForElement(child);
		if (ScrollOrientation != 0)
		{
			return boundsForElement.Left;
		}
		return boundsForElement.Top;
	}

	private double GetMeasuredEnd(FrameworkElement child)
	{
		Rect boundsForElement = GetBoundsForElement(child);
		if (ScrollOrientation != 0)
		{
			return boundsForElement.Right;
		}
		return boundsForElement.Bottom;
	}

	private double GetMeasuredExtent(FrameworkElement child)
	{
		Rect boundsForElement = GetBoundsForElement(child);
		if (ScrollOrientation != 0)
		{
			return boundsForElement.Width;
		}
		return boundsForElement.Height;
	}

	private double GetActualExtent(FrameworkElement child)
	{
		if (ScrollOrientation != 0)
		{
			return child.ActualWidth;
		}
		return child.ActualHeight;
	}

	private Rect GetBoundsForElement(FrameworkElement child)
	{
		if (!(child is ContentControl contentControl))
		{
			if (this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().LogWarning("Non-ContentControl containers aren't supported for virtualizing panel types.");
			}
			return default(Rect);
		}
		return contentControl.GetVirtualizationInformation().Bounds;
	}

	private double GetExtent(Size size)
	{
		if (ScrollOrientation != 0)
		{
			return size.Width;
		}
		return size.Height;
	}

	protected double GetBreadth(Size size)
	{
		if (ScrollOrientation != 0)
		{
			return size.Height;
		}
		return size.Width;
	}

	protected double GetBreadth(Rect rect)
	{
		if (ScrollOrientation != 0)
		{
			return rect.Height;
		}
		return rect.Width;
	}

	protected void SetBreadth(ref Rect rect, double breadth)
	{
		if (ScrollOrientation == Orientation.Vertical)
		{
			rect.Width = breadth;
		}
		else
		{
			rect.Height = breadth;
		}
	}

	private void IncrementStart(ref Rect rect, double startIncrement)
	{
		if (ScrollOrientation == Orientation.Vertical)
		{
			rect.Y += startIncrement;
		}
		else
		{
			rect.X += startIncrement;
		}
	}

	private double GetActualBreadth(FrameworkElement view)
	{
		if (ScrollOrientation != 0)
		{
			return view.ActualHeight;
		}
		return view.ActualWidth;
	}

	private double GetDesiredBreadth(FrameworkElement view)
	{
		return GetBreadth(view.DesiredSize);
	}

	private string GetMethodTag([CallerMemberName] string? caller = null)
	{
		return "VirtualizingPanelLayout." + caller + "()";
	}

	private string GetDebugInfo()
	{
		return $"Parent ItemsControl={ItemsControl} ItemsSource={ItemsControl?.ItemsSource} NoOfItems={ItemsControl?.NumberOfItems} FirstMaterialized={GetFirstMaterializedIndexPath()} LastMaterialized={GetLastMaterializedIndexPath()} ExtendedViewportStart={ExtendedViewportStart} ExtendedViewportEnd={ExtendedViewportEnd} GetItemsStart()={GetItemsStart()} GetItemsEnd()={GetItemsEnd()}";
	}

	private static Point GetRelativePosition(FrameworkElement child)
	{
		return child.RelativePosition;
	}

	internal void UpdateReorderingItem(Point location, FrameworkElement element, object item)
	{
		_pendingReorder = new(double, double, object, IndexPath?)?(((double, double, object, IndexPath?))((ScrollOrientation == Orientation.Horizontal) ? (location.X + ScrollOffset, element.ActualWidth, item, null) : (location.Y + ScrollOffset, element.ActualHeight, item, null)));
		LightRefresh();
	}

	internal IndexPath? CompleteReorderingItem(FrameworkElement element, object item)
	{
		IndexPath? result = null;
		IndexPath? indexPath = _pendingReorder?.index;
		if (indexPath.HasValue)
		{
			IndexPath index = indexPath.GetValueOrDefault();
			(FrameworkElement, IndexPath) tuple = _materializedLines.SelectMany((Line line) => line.Items).SkipWhile<(FrameworkElement, IndexPath)>(((FrameworkElement container, IndexPath index) i) => i.index != index).Skip(1)
				.FirstOrDefault();
			result = ((tuple.Item1 == null) ? IndexPath.FromRowSection(int.MaxValue, int.MaxValue) : tuple.Item2);
		}
		_pendingReorder = null;
		Refresh();
		return result;
	}

	protected bool ShouldInsertReorderingView(double extentOffset)
	{
		(double, double, object, IndexPath?)? pendingReorder = _pendingReorder;
		if (pendingReorder.HasValue)
		{
			(double, double, object, IndexPath?) valueOrDefault = pendingReorder.GetValueOrDefault();
			if (valueOrDefault.Item1 > extentOffset)
			{
				return valueOrDefault.Item1 <= extentOffset + valueOrDefault.Item2;
			}
		}
		return false;
	}

	protected IndexPath? GetAndUpdateReorderingIndex()
	{
		(double, double, object, IndexPath?)? pendingReorder = _pendingReorder;
		if (pendingReorder.HasValue)
		{
			(double, double, object, IndexPath?) valueOrDefault = pendingReorder.GetValueOrDefault();
			IndexPath? item = valueOrDefault.Item4;
			if (!item.HasValue)
			{
				IndexPath indexPathFromItem = ItemsControl!.GetIndexPathFromItem(valueOrDefault.Item3);
				if (indexPathFromItem.Row >= 0)
				{
					valueOrDefault.Item4 = indexPathFromItem;
					_pendingReorder = new(double, double, object, IndexPath?)?(valueOrDefault);
				}
			}
			return valueOrDefault.Item4;
		}
		return null;
	}

	private void ResetReorderingIndex()
	{
		(double, double, object, IndexPath?)? pendingReorder = _pendingReorder;
		if (pendingReorder.HasValue)
		{
			(double, double, object, IndexPath?) valueOrDefault = pendingReorder.GetValueOrDefault();
			_pendingReorder = new(double, double, object, IndexPath?)?((valueOrDefault.Item1, valueOrDefault.Item2, valueOrDefault.Item3, null));
		}
	}

	protected virtual void OnAreStickyGroupHeadersEnabledChanged(bool oldAreStickyGroupHeadersEnabled, bool newAreStickyGroupHeadersEnabled)
	{
	}

	protected virtual void OnGroupHeaderPlacementChanged(GroupHeaderPlacement oldGroupHeaderPlacement, GroupHeaderPlacement newGroupHeaderPlacement)
	{
	}

	protected virtual void OnGroupPaddingChanged(Thickness oldGroupPadding, Thickness newGroupPadding)
	{
	}

	protected virtual void OnCacheLengthChanged(double oldCacheLength, double newCacheLength)
	{
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}
}
