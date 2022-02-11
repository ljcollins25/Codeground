using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

public sealed class CalendarPanel : Panel, ILayoutDataInfoProvider, ICustomScrollInfo
{
	private class ContainersCache : IItemContainerMapping, IEnumerable<CacheEntry>, IEnumerable
	{
		private enum GenerationState
		{
			Before,
			InRange,
			After
		}

		private readonly List<CacheEntry> _entries = new List<CacheEntry>(45);

		private CalendarViewGeneratorHost? _host;

		private int _generationStartIndex = -1;

		private int _generationCurrentIndex = -1;

		private int _generationEndIndex = -1;

		private GenerationState _generationState;

		private (int at, int count) _generationRecyclableBefore;

		private (int at, int count) _generationUnusedInRange;

		private (int at, int count) _generationRecyclableAfter;

		internal CalendarViewGeneratorHost? Host
		{
			get
			{
				return _host;
			}
			set
			{
				_host = value;
				Clear();
			}
		}

		internal int FirstIndex { get; private set; } = -1;


		internal int LastIndex { get; private set; } = int.MinValue;


		private bool IsInRange(int itemIndex)
		{
			if (itemIndex >= FirstIndex)
			{
				return itemIndex <= LastIndex;
			}
			return false;
		}

		private int GetEntryIndex(int itemIndex)
		{
			return itemIndex - FirstIndex;
		}

		internal void Clear()
		{
			_entries.Clear();
			FirstIndex = -1;
			LastIndex = int.MinValue;
			_generationStartIndex = -1;
			_generationCurrentIndex = -1;
			_generationEndIndex = -1;
		}

		internal void BeginGeneration(int startIndex, int endIndex)
		{
			if (_host == null)
			{
				throw new InvalidOperationException("Host not set yet");
			}
			_generationStartIndex = startIndex;
			_generationCurrentIndex = startIndex;
			_generationEndIndex = endIndex;
			_generationState = GenerationState.Before;
			startIndex = Math.Max(FirstIndex, startIndex);
			endIndex = Math.Min(LastIndex, endIndex);
			if (endIndex >= 0)
			{
				int num = Math.Min(GetEntryIndex(startIndex), _entries.Count);
				int num2 = Math.Max(0, GetEntryIndex(endIndex) + 1);
				_generationRecyclableBefore = (0, num);
				_generationUnusedInRange = (num, num2 - num);
				_generationRecyclableAfter = (num2, Math.Max(0, _entries.Count - num2));
			}
		}

		internal IEnumerable<CacheEntry> CompleteGeneration(int endIndex)
		{
			int num = _generationRecyclableBefore.count + _generationUnusedInRange.count + _generationRecyclableAfter.count;
			IEnumerable<CacheEntry> result;
			if (num > 0)
			{
				CacheEntry[] array = new CacheEntry[num];
				int num2 = 0;
				if (_generationRecyclableAfter.count > 0)
				{
					_entries.CopyTo(_generationRecyclableAfter.at, array, num2, _generationRecyclableAfter.count);
					_entries.RemoveRange(_generationRecyclableAfter.at, _generationRecyclableAfter.count);
					num2 += _generationRecyclableAfter.count;
				}
				if (_generationUnusedInRange.count > 0)
				{
					_entries.CopyTo(_generationUnusedInRange.at, array, num2, _generationUnusedInRange.count);
					_entries.RemoveRange(_generationUnusedInRange.at, _generationUnusedInRange.count);
					num2 += _generationUnusedInRange.count;
				}
				if (_generationRecyclableBefore.count > 0)
				{
					_entries.CopyTo(_generationRecyclableBefore.at, array, num2, _generationRecyclableBefore.count);
					_entries.RemoveRange(_generationRecyclableBefore.at, _generationRecyclableBefore.count);
					num2 += _generationRecyclableBefore.count;
				}
				result = array;
			}
			else
			{
				result = Enumerable.Empty<CacheEntry>();
			}
			_entries.Sort(CacheEntryComparer.Instance);
			FirstIndex = _entries[0].Index;
			LastIndex = _entries[_entries.Count - 1].Index;
			_generationStartIndex = -1;
			_generationCurrentIndex = -1;
			_generationEndIndex = -1;
			return result;
		}

		internal (CacheEntry entry, CacheEntryKind kind) GetOrCreate(int index)
		{
			_generationCurrentIndex++;
			int entryIndex;
			CacheEntry item;
			switch (_generationState)
			{
			case GenerationState.Before:
				if (index >= FirstIndex)
				{
					if (index <= LastIndex)
					{
						_generationState = GenerationState.InRange;
						goto IL_0088;
					}
					_generationState = GenerationState.After;
				}
				goto case GenerationState.After;
			case GenerationState.InRange:
				if (index <= LastIndex && GetEntryIndex(index) < _generationRecyclableAfter.at + _generationRecyclableAfter.count)
				{
					goto IL_0088;
				}
				_generationState = GenerationState.After;
				goto case GenerationState.After;
			case GenerationState.After:
			{
				object obj = _host![index];
				CacheEntry cacheEntry;
				CacheEntryKind item2;
				if (_generationRecyclableBefore.count > 0)
				{
					cacheEntry = _entries[_generationRecyclableBefore.at];
					item2 = CacheEntryKind.Recycled;
					_generationRecyclableBefore.at++;
					_generationRecyclableBefore.count--;
				}
				else if (_generationRecyclableAfter.count > 0)
				{
					cacheEntry = _entries[_generationRecyclableAfter.at + _generationRecyclableAfter.count - 1];
					item2 = CacheEntryKind.Recycled;
					_generationRecyclableAfter.count--;
				}
				else
				{
					UIElement container = (UIElement)_host!.GetContainerForItem(obj, null);
					cacheEntry = new CacheEntry(container);
					item2 = CacheEntryKind.New;
					_entries.Add(cacheEntry);
				}
				cacheEntry.Index = index;
				cacheEntry.Item = obj;
				_host!.PrepareItemContainer(cacheEntry.Container, obj);
				return (cacheEntry, item2);
			}
			default:
				{
					throw new InvalidOperationException("Non reachable case.");
				}
				IL_0088:
				entryIndex = GetEntryIndex(index);
				item = _entries[entryIndex];
				if (entryIndex == _generationRecyclableAfter.at && _generationRecyclableAfter.count > 0)
				{
					_generationRecyclableAfter.at++;
					_generationRecyclableAfter.count--;
				}
				else
				{
					_generationUnusedInRange.at++;
					_generationUnusedInRange.count--;
				}
				return (item, CacheEntryKind.Kept);
			}
		}

		public object? ItemFromContainer(DependencyObject container)
		{
			UIElement elt = container as UIElement;
			if (elt == null)
			{
				return null;
			}
			return _entries.Find((CacheEntry e) => e.Container == elt)?.Container;
		}

		public DependencyObject? ContainerFromItem(object item)
		{
			object item2 = item;
			return _entries.Find((CacheEntry e) => e.Item == item2)?.Container;
		}

		public int IndexFromContainer(DependencyObject container)
		{
			UIElement elt = container as UIElement;
			if (elt == null)
			{
				return -1;
			}
			return _entries.Find((CacheEntry e) => e.Container == elt)?.Index ?? (-1);
		}

		public DependencyObject? ContainerFromIndex(int index)
		{
			if (index < 0 || !IsInRange(index))
			{
				return null;
			}
			return _entries[GetEntryIndex(index)].Container;
		}

		public IEnumerator<CacheEntry> GetEnumerator()
		{
			return _entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private class CacheEntry
	{
		public UIElement Container { get; }

		public int Index { get; set; }

		public object? Item { get; set; }

		public Rect Bounds { get; set; }

		public CacheEntry(UIElement container)
		{
			Container = container;
		}
	}

	private class CacheEntryComparer : IComparer<CacheEntry>
	{
		public static CacheEntryComparer Instance { get; } = new CacheEntryComparer();


		public int Compare(CacheEntry? x, CacheEntry? y)
		{
			if (x == null || y == null)
			{
				return -1;
			}
			return x!.Index.CompareTo(y!.Index);
		}
	}

	private enum CacheEntryKind
	{
		New,
		Kept,
		Recycled
	}

	private WeakReference<CalendarViewGeneratorHost> m_wrGeneartorHostOwner;

	private CalendarPanelType m_type;

	private bool m_isBiggestItemSizeDetermined;

	private Size m_biggestItemSize;

	private int m_suggestedRows;

	private int m_suggestedCols;

	private static readonly Size _defaultHardCodedSize = new Size(296.0, 272.0);

	private static readonly Size _minCellSize = new Size(10.0, 10.0);

	private readonly ContainersCache _cache = new ContainersCache();

	private CalendarLayoutStrategy? _layoutStrategy;

	private CalendarViewGeneratorHost? _host;

	private Rect _effectiveViewport;

	private Rect _lastLayoutedViewport = Rect.Empty;

	internal static readonly DependencyProperty CacheLengthProperty = DependencyProperty.Register("CacheLength", typeof(double), typeof(CalendarPanel), new FrameworkPropertyMetadata(0.0));

	internal static readonly DependencyProperty ColsProperty = DependencyProperty.Register("Cols", typeof(int), typeof(CalendarPanel), new FrameworkPropertyMetadata(0));

	internal static readonly DependencyProperty ItemMinHeightProperty = DependencyProperty.Register("ItemMinHeight", typeof(double), typeof(CalendarPanel), new FrameworkPropertyMetadata(0.0));

	internal static readonly DependencyProperty ItemMinWidthProperty = DependencyProperty.Register("ItemMinWidth", typeof(double), typeof(CalendarPanel), new FrameworkPropertyMetadata(0.0));

	internal static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(CalendarPanel), new FrameworkPropertyMetadata(Orientation.Vertical));

	internal static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(CalendarPanel), new FrameworkPropertyMetadata(0));

	internal static readonly DependencyProperty StartIndexProperty = DependencyProperty.Register("StartIndex", typeof(int), typeof(CalendarPanel), new FrameworkPropertyMetadata(0));

	internal int FirstCacheIndexImpl => FirstCacheIndexBase;

	internal int FirstVisibleIndexImpl => FirstVisibleIndexBase;

	internal int LastVisibleIndexImpl => LastVisibleIndexBase;

	internal int LastCacheIndexImpl => LastCacheIndexBase;

	internal PanelScrollingDirection ScrollingDirectionImpl => PanningDirectionBase;

	public double? ViewportWidth { get; private set; }

	public double? ViewportHeight { get; private set; }

	internal int FirstVisibleIndexBase { get; private set; } = -1;


	internal int LastVisibleIndexBase { get; private set; } = -1;


	internal int FirstCacheIndexBase => _cache.FirstIndex;

	internal int LastCacheIndexBase => _cache.LastIndex;

	[NotImplemented]
	internal PanelScrollingDirection PanningDirectionBase { get; }

	internal ILayoutStrategy? LayoutStrategy => _layoutStrategy;

	internal double CacheLengthBase { get; set; }

	internal ContainerManager ContainerManager { get; private set; }

	internal double CacheLength
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

	internal int Cols
	{
		get
		{
			return (int)GetValue(ColsProperty);
		}
		set
		{
			SetValue(ColsProperty, value);
		}
	}

	internal int FirstCacheIndex
	{
		get
		{
			CheckThread();
			return FirstCacheIndexImpl;
		}
	}

	internal int FirstVisibleIndex
	{
		get
		{
			CheckThread();
			return FirstVisibleIndexImpl;
		}
	}

	internal double ItemMinHeight
	{
		get
		{
			return (double)GetValue(ItemMinHeightProperty);
		}
		set
		{
			SetValue(ItemMinHeightProperty, value);
		}
	}

	internal double ItemMinWidth
	{
		get
		{
			return (double)GetValue(ItemMinWidthProperty);
		}
		set
		{
			SetValue(ItemMinWidthProperty, value);
		}
	}

	internal int LastCacheIndex
	{
		get
		{
			CheckThread();
			return LastCacheIndexImpl;
		}
	}

	internal int LastVisibleIndex
	{
		get
		{
			CheckThread();
			return LastVisibleIndexImpl;
		}
	}

	internal Orientation Orientation
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

	internal int Rows
	{
		get
		{
			return (int)GetValue(RowsProperty);
		}
		set
		{
			SetValue(RowsProperty, value);
		}
	}

	private PanelScrollingDirection ScrollingDirection
	{
		get
		{
			CheckThread();
			return ScrollingDirectionImpl;
		}
	}

	internal int StartIndex
	{
		get
		{
			return (int)GetValue(StartIndexProperty);
		}
		set
		{
			SetValue(StartIndexProperty, value);
		}
	}

	private Orientation LogicalOrientation => Orientation;

	private Orientation PhysicalOrientation
	{
		get
		{
			Orientation orientation = Orientation.Horizontal;
			Orientation orientation2 = orientation;
			if (orientation == Orientation.Vertical)
			{
				return Orientation.Horizontal;
			}
			return Orientation.Vertical;
		}
	}

	internal CalendarViewGeneratorHost Owner
	{
		get
		{
			m_wrGeneartorHostOwner.TryGetTarget(out var target);
			return target;
		}
		set
		{
			m_wrGeneartorHostOwner = new WeakReference<CalendarViewGeneratorHost>(value);
		}
	}

	internal CalendarPanelType PanelType
	{
		get
		{
			return m_type;
		}
		set
		{
			if (m_type != value)
			{
				m_type = value;
				if ((m_type == CalendarPanelType.Primary || m_type == CalendarPanelType.Secondary) && m_suggestedCols != -1 && m_suggestedRows != -1)
				{
					SetPanelDimension(m_suggestedCols, m_suggestedRows);
				}
			}
		}
	}

	internal event VisibleIndicesUpdatedEventCallback VisibleIndicesUpdated;

	public CalendarPanel()
	{
		m_type = CalendarPanelType.Invalid;
		m_isBiggestItemSizeDetermined = false;
		m_biggestItemSize = default(Size);
		m_suggestedRows = -1;
		m_suggestedCols = -1;
		Initialize();
	}

	private void base_Initialize()
	{
		ContainerManager = new ContainerManager(this);
		base.VerticalAlignment = VerticalAlignment.Top;
		base.HorizontalAlignment = HorizontalAlignment.Left;
		base.EffectiveViewportChanged += new TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>(OnEffectiveViewportChanged);
	}

	internal void RegisterItemsHost(CalendarViewGeneratorHost? pHost)
	{
		_host = pHost;
		_cache.Host = pHost;
		base.Children.Clear();
		ContainerManager.Host = pHost;
	}

	internal void DisconnectItemsHost()
	{
		RegisterItemsHost(null);
	}

	internal DependencyObject? ContainerFromIndex(int index)
	{
		return _cache.ContainerFromIndex(index);
	}

	internal void ScrollItemIntoView(int index, ScrollIntoViewAlignment alignment, double offset, bool forceSynchronous)
	{
		if (_layoutStrategy == null || Owner == null)
		{
			return;
		}
		if (!m_isBiggestItemSizeDetermined)
		{
			Size size = GetLayoutViewport().Size;
			DetermineTheBiggestItemSize(Owner, size, out var pSize);
			if (pSize != m_biggestItemSize)
			{
				m_biggestItemSize = pSize;
				if (m_type == CalendarPanelType.Primary)
				{
					SetItemMinimumSize(pSize);
					Owner.OnPrimaryPanelDesiredSizeChanged();
				}
			}
			m_isBiggestItemSizeDetermined = true;
			ForceConfigViewport(size);
		}
		_layoutStrategy!.EstimateElementBounds(ElementType.ItemContainer, index, default(EstimationReference), default(EstimationReference), default(Rect), out var pReturnValue);
		ScrollViewer scrollViewer = Owner.ScrollViewer;
		if (scrollViewer != null)
		{
			double num = pReturnValue.Y + offset;
			double verticalOffset = scrollViewer.VerticalOffset;
			_effectiveViewport.Y += num - verticalOffset;
			scrollViewer.ChangeView(null, num, null, forceSynchronous);
			base_MeasureOverride(_lastLayoutedViewport.Size);
		}
	}

	private Size GetViewportSize()
	{
		return _lastLayoutedViewport.Size.AtLeast(_defaultHardCodedSize).FiniteOrDefault(_defaultHardCodedSize);
	}

	internal Size GetDesiredViewportSize()
	{
		return _layoutStrategy?.GetDesiredViewportSize() ?? default(Size);
	}

	[NotImplemented]
	internal void GetTargetIndexFromNavigationAction(int focusedIndex, ElementType elementType, KeyNavigationAction action, object o, int i, out uint newFocusedIndexUint, out ElementType newFocusedType, out bool actionValidForSourceIndex)
	{
		newFocusedIndexUint = (uint)focusedIndex;
		newFocusedType = elementType;
		actionValidForSourceIndex = true;
	}

	internal IItemContainerMapping GetItemContainerMapping()
	{
		return _cache;
	}

	private void SetLayoutStrategyBase(CalendarLayoutStrategy spLayoutStrategy)
	{
		_layoutStrategy = spLayoutStrategy;
		spLayoutStrategy.LayoutDataInfoProvider = this;
	}

	private void CacheFirstVisibleElementBeforeOrientationChange()
	{
	}

	private void ProcessOrientationChange()
	{
	}

	int ILayoutDataInfoProvider.GetTotalItemCount()
	{
		return ContainerManager.TotalItemsCount;
	}

	int ILayoutDataInfoProvider.GetTotalGroupCount()
	{
		return ContainerManager.TotalGroupCount;
	}

	private Rect GetLayoutViewport(Size availableSize = default(Size))
	{
		if (_host == null)
		{
			return default(Rect);
		}
		CalendarView owner = _host!.Owner;
		Rect result = new Rect(_effectiveViewport.Location.FiniteOrDefault(default(Point)), _effectiveViewport.Size.AtLeast(availableSize).AtLeast(_defaultHardCodedSize).FiniteOrDefault(_defaultHardCodedSize));
		if (owner.HorizontalAlignment != HorizontalAlignment.Stretch && double.IsNaN(owner.Width) && owner.MinWidth <= 0.0)
		{
			result.Width = _defaultHardCodedSize.Width;
		}
		if (owner.VerticalAlignment != VerticalAlignment.Stretch && double.IsNaN(owner.Height) && owner.MinHeight <= 0.0)
		{
			result.Height = _defaultHardCodedSize.Height;
		}
		return result;
	}

	private Size base_MeasureOverride(Size availableSize)
	{
		if (_host == null || _layoutStrategy == null)
		{
			return default(Size);
		}
		Rect rect = (_lastLayoutedViewport = GetLayoutViewport(availableSize));
		ForceConfigViewport(rect.Size);
		_layoutStrategy!.BeginMeasure();
		base.ShouldInterceptInvalidate = true;
		int i = -1;
		int pReturnValue = 0;
		int num = -1;
		int val = -1;
		double num2 = 0.0;
		try
		{
			Rect rect2 = rect;
			if (Rows > 0)
			{
				double num3 = rect.Height / (double)Rows;
				rect2.Y = Math.Max(0.0, rect2.Y - 1.5 * num3);
				rect2.Height += 3.0 * num3;
			}
			_layoutStrategy!.EstimateElementIndex(ElementType.ItemContainer, default(EstimationReference), default(EstimationReference), rect, out var pTargetRect, out pReturnValue);
			pTargetRect.Size = rect2.Size;
			pReturnValue = Math.Max(0, pReturnValue - StartIndex);
			int num4 = LastVisibleIndex - FirstVisibleIndex;
			_cache.BeginGeneration(pReturnValue, pReturnValue + num4);
			i = pReturnValue;
			int count = _host!.Count;
			LayoutReference layoutReference = default(LayoutReference);
			layoutReference.RelativeLocation = ReferenceIdentity.Myself;
			LayoutReference referenceInformation = layoutReference;
			(double, int) tuple = (double.MinValue, 0);
			for (; i < count; i++)
			{
				if (!(referenceInformation.ReferenceBounds.Bottom < pTargetRect.Bottom) && tuple.Item2 >= Cols)
				{
					break;
				}
				var (cacheEntry, cacheEntryKind) = _cache.GetOrCreate(i);
				if (cacheEntryKind == CacheEntryKind.New)
				{
					base.Children.Add(cacheEntry.Container);
				}
				Size elementMeasureSize = _layoutStrategy!.GetElementMeasureSize(ElementType.ItemContainer, i, pTargetRect);
				Rect elementBounds = _layoutStrategy!.GetElementBounds(ElementType.ItemContainer, i + StartIndex, elementMeasureSize, referenceInformation, pTargetRect);
				num2 = elementBounds.Bottom;
				if ((elementMeasureSize.Width < _minCellSize.Width && elementMeasureSize.Height < _minCellSize.Height) || Cols == 0 || Rows == 0)
				{
					i++;
					return _defaultHardCodedSize;
				}
				cacheEntry.Bounds = elementBounds;
				cacheEntry.Container.Measure(elementMeasureSize);
				cacheEntry.Container.GetVirtualizationInformation().MeasureSize = elementMeasureSize;
				switch (cacheEntryKind)
				{
				case CacheEntryKind.New:
					_host!.SetupContainerContentChangingAfterPrepare(cacheEntry.Container, cacheEntry.Item, cacheEntry.Index, elementMeasureSize);
					break;
				case CacheEntryKind.Recycled:
					_host!.RaiseContainerContentChangingOnRecycle(cacheEntry.Container, cacheEntry.Item);
					break;
				}
				bool flag = elementBounds.IsIntersecting(rect);
				if (num == -1 && flag)
				{
					num = i;
					val = i;
				}
				else if (flag)
				{
					val = i;
				}
				referenceInformation.RelativeLocation = ReferenceIdentity.AfterMe;
				referenceInformation.ReferenceBounds = elementBounds;
				if (tuple.Item1 < elementBounds.Y)
				{
					tuple = (elementBounds.Y, 1);
				}
				else
				{
					tuple.Item2++;
				}
			}
		}
		finally
		{
			try
			{
				FirstVisibleIndexBase = Math.Max(num, pReturnValue);
				LastVisibleIndexBase = Math.Max(FirstVisibleIndexBase, val);
				foreach (CacheEntry item in _cache.CompleteGeneration(i - 1))
				{
					base.Children.Remove(item.Container);
				}
			}
			catch
			{
				_cache.Clear();
				base.Children.Clear();
				InvalidateMeasure();
			}
			ViewportHeight = rect.Height;
			base.ShouldInterceptInvalidate = false;
			_layoutStrategy!.EndMeasure();
		}
		this.VisibleIndicesUpdated?.Invoke(this, null);
		_layoutStrategy!.EstimatePanelExtent(default(EstimationReference), default(EstimationReference), default(Rect), out var pExtent);
		if (pExtent.Height < num2)
		{
			pExtent.Height = num2;
		}
		return pExtent;
	}

	private Size base_ArrangeOverride(Size finalSize)
	{
		if (_host == null || _layoutStrategy == null)
		{
			return default(Size);
		}
		LayoutReference referenceInformation = default(LayoutReference);
		Rect windowConstraint = new Rect(default(Point), finalSize);
		int num = 0;
		foreach (CacheEntry item in _cache)
		{
			num++;
			Rect elementArrangeBounds = _layoutStrategy!.GetElementArrangeBounds(ElementType.ItemContainer, item.Index + StartIndex, item.Bounds, windowConstraint, finalSize);
			item.Container.Arrange(elementArrangeBounds);
			item.Container.GetVirtualizationInformation().Bounds = elementArrangeBounds;
		}
		if (num != base.Children.Count)
		{
			this.Log().Error("Invalid count of children ... fall-backing to slow arrange algorithm!");
			{
				foreach (UIElement child in base.Children)
				{
					int num2 = _cache.IndexFromContainer(child);
					Rect elementBounds = _layoutStrategy!.GetElementBounds(ElementType.ItemContainer, num2 + StartIndex, child.DesiredSize, referenceInformation, windowConstraint);
					child.Arrange(elementBounds);
					child.GetVirtualizationInformation().Bounds = elementBounds;
				}
				return finalSize;
			}
		}
		return finalSize;
	}

	private static void OnEffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args)
	{
		(sender as CalendarPanel)?.OnEffectiveViewportChanged(args);
	}

	private void OnEffectiveViewportChanged(EffectiveViewportChangedEventArgs args)
	{
		_effectiveViewport = args.EffectiveViewport;
		if (_host != null && _layoutStrategy != null && (ForceConfigViewport(GetLayoutViewport().Size) || Math.Abs(_effectiveViewport.Y - _lastLayoutedViewport.Y) > _lastLayoutedViewport.Height / (double)Rows * 0.75))
		{
			InvalidateMeasure();
		}
	}

	private bool ForceConfigViewport(Size viewportSize)
	{
		if (m_isBiggestItemSizeDetermined && m_type == CalendarPanelType.Secondary_SelfAdaptive)
		{
			int val = (int)(viewportSize.Width / m_biggestItemSize.Width);
			int val2 = (int)(viewportSize.Height / m_biggestItemSize.Height);
			val = Math.Max(1, Math.Min(val, m_suggestedCols));
			val2 = Math.Max(1, Math.Min(val2, m_suggestedRows));
			SetPanelDimension(val, val2);
		}
		if (Rows == 0 || Cols == 0)
		{
			return false;
		}
		_layoutStrategy!.SetViewportSize(viewportSize, out var pNeedsRemeasure);
		return pNeedsRemeasure;
	}

	private void CheckThread()
	{
		CoreDispatcher.CheckThreadAccess();
	}

	internal override bool IsViewHit()
	{
		return true;
	}

	private void Initialize()
	{
		base_Initialize();
		CalendarLayoutStrategy layoutStrategyBase = new CalendarLayoutStrategy();
		SetLayoutStrategyBase(layoutStrategyBase);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		if (m_type != 0 && m_type != CalendarPanelType.Secondary && !m_isBiggestItemSizeDetermined)
		{
			CalendarViewGeneratorHost owner = Owner;
			if (owner != null)
			{
				Size pSize = default(Size);
				DetermineTheBiggestItemSize(owner, availableSize, out pSize);
				if (pSize.Width != m_biggestItemSize.Width || pSize.Height != m_biggestItemSize.Height)
				{
					m_biggestItemSize = pSize;
					if (m_type == CalendarPanelType.Primary)
					{
						SetItemMinimumSize(pSize);
						owner.OnPrimaryPanelDesiredSizeChanged();
					}
				}
			}
			m_isBiggestItemSizeDetermined = true;
		}
		return base_MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size result = default(Size);
		bool pNeedsRemeasure = false;
		if (m_type != 0)
		{
			Size size = new Size(0.0, 0.0);
			size = GetViewportSize();
			if (m_type == CalendarPanelType.Secondary_SelfAdaptive)
			{
				int val = (int)(size.Width / m_biggestItemSize.Width);
				int val2 = (int)(size.Height / m_biggestItemSize.Height);
				val = Math.Max(1, Math.Min(val, m_suggestedCols));
				val2 = Math.Max(1, Math.Min(val2, m_suggestedRows));
				SetPanelDimension(val, val2);
			}
			ILayoutStrategy layoutStrategy = LayoutStrategy;
			((CalendarLayoutStrategy)layoutStrategy).SetViewportSize(size, out pNeedsRemeasure);
		}
		if (pNeedsRemeasure)
		{
			InvalidateMeasure();
			return result;
		}
		return base_ArrangeOverride(finalSize);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		DependencyProperty property = args.Property;
		if (property == null)
		{
			return;
		}
		if (property == OrientationProperty)
		{
			Orientation orientation = (Orientation)args.NewValue;
			ILayoutStrategy layoutStrategy = LayoutStrategy;
			CacheFirstVisibleElementBeforeOrientationChange();
			if (orientation == Orientation.Horizontal)
			{
				((CalendarLayoutStrategy)layoutStrategy).SetVirtualizationDirection(Orientation.Vertical);
			}
			else
			{
				((CalendarLayoutStrategy)layoutStrategy).SetVirtualizationDirection(Orientation.Horizontal);
			}
			ProcessOrientationChange();
			return;
		}
		DependencyProperty dependencyProperty = property;
		if (dependencyProperty == RowsProperty)
		{
			int num = 0;
			num = (int)args.NewValue;
			ILayoutStrategy layoutStrategy2 = LayoutStrategy;
			((CalendarLayoutStrategy)layoutStrategy2).SetRows(num);
			OnRowsOrColsChanged(Orientation.Vertical);
			return;
		}
		DependencyProperty dependencyProperty2 = property;
		if (dependencyProperty2 == ColsProperty)
		{
			int num2 = 0;
			num2 = (int)args.NewValue;
			ILayoutStrategy layoutStrategy3 = LayoutStrategy;
			((CalendarLayoutStrategy)layoutStrategy3).SetCols(num2);
			OnRowsOrColsChanged(Orientation.Horizontal);
			return;
		}
		DependencyProperty dependencyProperty3 = property;
		if (dependencyProperty3 == CacheLengthProperty)
		{
			double num4 = (CacheLengthBase = (double)args.NewValue);
			return;
		}
		DependencyProperty dependencyProperty4 = property;
		if (dependencyProperty4 == StartIndexProperty)
		{
			int num5 = 0;
			num5 = (int)args.NewValue;
			ILayoutStrategy layoutStrategy4 = LayoutStrategy;
			((CalendarLayoutStrategy)layoutStrategy4).GetIndexCorrectionTable().SetCorrectionEntryForElementStartAt(num5);
			InvalidateMeasure();
		}
	}

	private void DesiredViewportSize(out Size pSize)
	{
		pSize = default(Size);
		pSize.Width = 0.0;
		pSize.Height = 0.0;
		ILayoutStrategy layoutStrategy = LayoutStrategy;
		pSize = ((CalendarLayoutStrategy)layoutStrategy).GetDesiredViewportSize();
	}

	private void SetItemMinimumSize(Size size)
	{
		bool pNeedsRemeasure = false;
		ILayoutStrategy layoutStrategy = LayoutStrategy;
		((CalendarLayoutStrategy)layoutStrategy).SetItemMinimumSize(size, out pNeedsRemeasure);
		if (pNeedsRemeasure)
		{
			InvalidateMeasure();
		}
	}

	internal void SetSnapPointFilterFunction(Func<int, bool> func)
	{
		ILayoutStrategy layoutStrategy = LayoutStrategy;
		((CalendarLayoutStrategy)layoutStrategy).SetSnapPointFilterFunction(func);
	}

	private void OnRowsOrColsChanged(Orientation orientation)
	{
		if (m_type == CalendarPanelType.Primary)
		{
			Orientation orientation2 = Orientation.Horizontal;
			ILayoutStrategy layoutStrategy = LayoutStrategy;
			orientation2 = layoutStrategy.VirtualizationDirection;
			if (orientation2 == orientation)
			{
				DependencyObject parent = VisualTreeHelper.GetParent(this);
				if (parent is ScrollContentPresenter scrollContentPresenter)
				{
					scrollContentPresenter.InvalidateMeasure();
				}
			}
		}
		else
		{
			InvalidateArrange();
		}
	}

	internal void SetNeedsToDetermineBiggestItemSize()
	{
		m_isBiggestItemSizeDetermined = false;
		InvalidateMeasure();
	}

	private void DetermineTheBiggestItemSize(CalendarViewGeneratorHost pOwner, Size availableSize, out Size pSize)
	{
		pSize = default(Size);
		pSize.Height = 0.0;
		pSize.Width = 0.0;
		DependencyObject dependencyObject = ContainerFromIndex(ContainerManager.StartOfContainerVisualSection());
		if (dependencyObject == null)
		{
			Size size = default(Size);
			size = base_MeasureOverride(availableSize);
			dependencyObject = ContainerFromIndex(ContainerManager.StartOfContainerVisualSection());
		}
		if (!(dependencyObject is CalendarViewBaseItem calendarViewBaseItem))
		{
			return;
		}
		CalendarViewBaseItem calendarViewBaseItem2 = calendarViewBaseItem;
		string mainText = calendarViewBaseItem2.GetMainText();
		List<string> list = null;
		list = pOwner.GetPossibleItemStrings();
		foreach (string item in list)
		{
			Size size2 = default(Size);
			calendarViewBaseItem2.UpdateMainText(item);
			calendarViewBaseItem2.InvalidateMeasure();
			calendarViewBaseItem2.Measure(availableSize);
			size2 = calendarViewBaseItem2.DesiredSize;
			pSize.Width = Math.Max(pSize.Width, size2.Width);
			pSize.Height = Math.Max(pSize.Height, size2.Height);
		}
		calendarViewBaseItem2.UpdateMainText(mainText);
	}

	internal void SetSuggestedDimension(int cols, int rows)
	{
		if (m_type == CalendarPanelType.Primary || m_type == CalendarPanelType.Secondary)
		{
			SetPanelDimension(cols, rows);
			return;
		}
		m_suggestedRows = rows;
		m_suggestedCols = cols;
	}

	private void SetPanelDimension(int col, int row)
	{
		int num = 0;
		int num2 = 0;
		num = Rows;
		num2 = Cols;
		if (row == num && col == num2)
		{
			return;
		}
		Rows = row;
		Cols = col;
		CalendarViewGeneratorHost owner = Owner;
		if (owner == null)
		{
			return;
		}
		bool pCanPanelShowFullScope = false;
		CalendarView.CanPanelShowFullScope(owner, out pCanPanelShowFullScope);
		if (!pCanPanelShowFullScope)
		{
			SetSnapPointFilterFunction(null);
			return;
		}
		CalendarViewGeneratorHost pHost = owner;
		SetSnapPointFilterFunction((int itemIndex) => pHost.GetIsFirstItemInScope(itemIndex));
	}
}
