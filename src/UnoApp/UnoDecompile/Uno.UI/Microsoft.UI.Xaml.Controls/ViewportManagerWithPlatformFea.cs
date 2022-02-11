using System;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

internal class ViewportManagerWithPlatformFeatures : ViewportManager
{
	private const double CacheBufferPerSideInflationPixelDelta = 40.0;

	private ItemsRepeater m_owner;

	private bool m_ensuredScroller;

	private IScrollAnchorProvider m_scroller;

	private UIElement m_makeAnchorElement;

	private bool m_isAnchorOutsideRealizedRange;

	private IAsyncAction m_cacheBuildAction;

	private Rect m_visibleWindow;

	private Rect m_layoutExtent;

	private Point m_expectedViewportShift;

	private Point m_pendingViewportShift;

	private Point m_unshiftableShift;

	private double m_maximumHorizontalCacheLength = 2.0;

	private double m_maximumVerticalCacheLength = 2.0;

	private double m_horizontalCacheBufferPerSide;

	private double m_verticalCacheBufferPerSide;

	private bool m_isBringIntoViewInProgress;

	private bool m_managingViewportDisabled;

	private IDisposable m_effectiveViewportChangedRevoker;

	private IDisposable m_layoutUpdatedRevoker;

	private IDisposable m_renderingToken;

	private Rect _uno_viewportUsedInLastMeasure;

	private bool HasScroller => m_scroller != null;

	public override UIElement MadeAnchor => m_makeAnchorElement;

	public override UIElement SuggestedAnchor
	{
		get
		{
			UIElement uIElement = m_makeAnchorElement;
			UIElement owner = m_owner;
			if (uIElement == null)
			{
				UIElement uIElement2 = m_scroller?.CurrentAnchor;
				if (uIElement2 != null)
				{
					UIElement uIElement3 = uIElement2;
					for (UIElement uIElement4 = CachedVisualTreeHelpers.GetParent(uIElement3) as UIElement; uIElement4 != null; uIElement4 = CachedVisualTreeHelpers.GetParent(uIElement4) as UIElement)
					{
						if (uIElement4 == owner)
						{
							uIElement = uIElement3;
							break;
						}
						uIElement3 = uIElement4;
					}
				}
			}
			return uIElement;
		}
	}

	public override double HorizontalCacheLength
	{
		get
		{
			return m_maximumHorizontalCacheLength;
		}
		set
		{
			if (m_maximumHorizontalCacheLength != value)
			{
				ValidateCacheLength(value);
				m_maximumHorizontalCacheLength = value;
				ResetCacheBuffer();
			}
		}
	}

	public override double VerticalCacheLength
	{
		get
		{
			return m_maximumVerticalCacheLength;
		}
		set
		{
			if (m_maximumVerticalCacheLength != value)
			{
				ValidateCacheLength(value);
				m_maximumVerticalCacheLength = value;
				ResetCacheBuffer();
			}
		}
	}

	public ViewportManagerWithPlatformFeatures(ItemsRepeater owner)
	{
		m_owner = owner;
	}

	public override Rect GetLayoutExtent()
	{
		return m_layoutExtent;
	}

	public override Point GetOrigin()
	{
		return new Point(m_layoutExtent.X, m_layoutExtent.Y);
	}

	private Rect GetLayoutVisibleWindowDiscardAnchor()
	{
		Rect visibleWindow = m_visibleWindow;
		if (HasScroller)
		{
			visibleWindow.X += m_layoutExtent.X + m_expectedViewportShift.X + m_unshiftableShift.X;
			visibleWindow.Y += m_layoutExtent.Y + m_expectedViewportShift.Y + m_unshiftableShift.Y;
		}
		return visibleWindow;
	}

	public override Rect GetLayoutVisibleWindow()
	{
		Rect visibleWindow = m_visibleWindow;
		if (m_makeAnchorElement != null && m_isAnchorOutsideRealizedRange)
		{
			visibleWindow.X = 0.0;
			visibleWindow.Y = 0.0;
		}
		else if (HasScroller)
		{
			visibleWindow.X += m_layoutExtent.X + m_expectedViewportShift.X + m_unshiftableShift.X;
			visibleWindow.Y += m_layoutExtent.Y + m_expectedViewportShift.Y + m_unshiftableShift.Y;
		}
		return visibleWindow;
	}

	public override Rect GetLayoutRealizationWindow()
	{
		Rect layoutVisibleWindow = GetLayoutVisibleWindow();
		if (HasScroller)
		{
			layoutVisibleWindow.X -= (float)m_horizontalCacheBufferPerSide;
			layoutVisibleWindow.Y -= (float)m_verticalCacheBufferPerSide;
			layoutVisibleWindow.Width += (float)m_horizontalCacheBufferPerSide * 2f;
			layoutVisibleWindow.Height += (float)m_verticalCacheBufferPerSide * 2f;
		}
		return layoutVisibleWindow;
	}

	public override void SetLayoutExtent(Rect extent)
	{
		if (m_layoutExtent == extent)
		{
			return;
		}
		m_expectedViewportShift.X += m_layoutExtent.X - extent.X;
		m_expectedViewportShift.Y += m_layoutExtent.Y - extent.Y;
		if ((Math.Abs(m_expectedViewportShift.X) > 1.0 || Math.Abs(m_expectedViewportShift.Y) > 1.0) && m_layoutUpdatedRevoker == null)
		{
			m_layoutUpdatedRevoker = Disposable.Create(delegate
			{
				m_owner.LayoutUpdated -= OnLayoutUpdated;
				m_layoutUpdatedRevoker = null;
			});
			m_owner.LayoutUpdated += OnLayoutUpdated;
		}
		m_layoutExtent = extent;
		m_pendingViewportShift = m_expectedViewportShift;
		if (m_scroller != null)
		{
			(m_scroller as UIElement).InvalidateArrange();
		}
	}

	public override void OnLayoutChanged(bool isVirtualizing)
	{
		m_managingViewportDisabled = !isVirtualizing;
		m_layoutExtent = default(Rect);
		m_expectedViewportShift = default(Point);
		m_pendingViewportShift = default(Point);
		if (m_managingViewportDisabled)
		{
			m_effectiveViewportChangedRevoker?.Dispose();
		}
		else if (m_effectiveViewportChangedRevoker == null)
		{
			ItemsSourceView itemsSourceView = m_owner.ItemsSourceView;
			if (itemsSourceView != null && itemsSourceView.Count > 0)
			{
				m_effectiveViewportChangedRevoker = Disposable.Create(delegate
				{
					m_owner.EffectiveViewportChanged -= new TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>(OnEffectiveViewportChanged);
					m_effectiveViewportChangedRevoker = null;
				});
				m_owner.EffectiveViewportChanged += new TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>(OnEffectiveViewportChanged);
			}
		}
		m_unshiftableShift = default(Point);
		ResetCacheBuffer();
	}

	public override void OnElementPrepared(UIElement element)
	{
		element.CanBeScrollAnchor = true;
	}

	public override void OnElementCleared(UIElement element)
	{
		element.CanBeScrollAnchor = false;
	}

	public override void OnOwnerMeasuring()
	{
		EnsureScroller();
		_uno_viewportUsedInLastMeasure = m_visibleWindow;
	}

	public override void OnOwnerArranged()
	{
		m_expectedViewportShift = default(Point);
		if (!m_managingViewportDisabled && HasScroller)
		{
			double num = m_maximumHorizontalCacheLength * m_visibleWindow.Width / 2.0;
			double num2 = m_maximumVerticalCacheLength * m_visibleWindow.Height / 2.0;
			if (m_horizontalCacheBufferPerSide < num || m_verticalCacheBufferPerSide < num2)
			{
				m_horizontalCacheBufferPerSide += 40.0;
				m_verticalCacheBufferPerSide += 40.0;
				m_horizontalCacheBufferPerSide = Math.Min(m_horizontalCacheBufferPerSide, num);
				m_verticalCacheBufferPerSide = Math.Min(m_verticalCacheBufferPerSide, num2);
				RegisterCacheBuildWork();
			}
		}
	}

	private void OnLayoutUpdated(object sender, object args)
	{
		m_layoutUpdatedRevoker?.Dispose();
		if (!m_managingViewportDisabled && (m_pendingViewportShift.X != 0.0 || m_pendingViewportShift.Y != 0.0))
		{
			m_unshiftableShift.X += m_pendingViewportShift.X;
			m_unshiftableShift.Y += m_pendingViewportShift.Y;
			m_pendingViewportShift = default(Point);
			m_expectedViewportShift = default(Point);
			TryInvalidateMeasure();
		}
	}

	public override void OnMakeAnchor(UIElement anchor, bool isAnchorOutsideRealizedRange)
	{
		m_makeAnchorElement = anchor;
		m_isAnchorOutsideRealizedRange = isAnchorOutsideRealizedRange;
	}

	public override void OnBringIntoViewRequested(BringIntoViewRequestedEventArgs args)
	{
		if (m_managingViewportDisabled)
		{
			return;
		}
		if (m_isAnchorOutsideRealizedRange)
		{
			args.AnimationDesired = false;
		}
		UIElement immediateChildOfRepeater = GetImmediateChildOfRepeater(args.TargetElement);
		foreach (UIElement child in m_owner.Children)
		{
			if (child.CanBeScrollAnchor && child != immediateChildOfRepeater)
			{
				child.CanBeScrollAnchor = false;
			}
		}
		m_isBringIntoViewInProgress = true;
		if (m_renderingToken == null)
		{
			m_renderingToken = Disposable.Create(delegate
			{
				CompositionTarget.Rendering -= OnCompositionTargetRendering;
				m_renderingToken = null;
			});
			CompositionTarget.Rendering += OnCompositionTargetRendering;
		}
	}

	private UIElement GetImmediateChildOfRepeater(UIElement descendant)
	{
		UIElement result = descendant;
		UIElement uIElement = CachedVisualTreeHelpers.GetParent(descendant) as UIElement;
		while (uIElement != null && uIElement != m_owner)
		{
			result = uIElement;
			uIElement = CachedVisualTreeHelpers.GetParent(uIElement) as UIElement;
		}
		if (uIElement == null)
		{
			throw new InvalidOperationException("OnBringIntoViewRequested called with args.target element not under the ItemsRepeater that recieved the call");
		}
		return result;
	}

	private void OnCompositionTargetRendering(object sender, object args)
	{
		m_renderingToken?.Dispose();
		m_isBringIntoViewInProgress = false;
		m_makeAnchorElement = null;
		foreach (UIElement child in m_owner.Children)
		{
			if (!child.CanBeScrollAnchor)
			{
				VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(child);
				if (virtualizationInfo.IsRealized && virtualizationInfo.IsHeldByLayout)
				{
					child.CanBeScrollAnchor = true;
				}
			}
		}
	}

	public override void ResetScrollers()
	{
		m_scroller = null;
		m_effectiveViewportChangedRevoker?.Dispose();
		m_ensuredScroller = false;
	}

	private void OnCacheBuildActionCompleted()
	{
		m_cacheBuildAction = null;
		if (!m_managingViewportDisabled)
		{
			m_owner.InvalidateMeasure();
		}
	}

	private void OnEffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args)
	{
		UpdateViewport(args.EffectiveViewport);
		m_pendingViewportShift = default(Point);
		m_unshiftableShift = default(Point);
		if (m_visibleWindow == default(Rect))
		{
			m_layoutExtent = default(Rect);
		}
		m_layoutUpdatedRevoker?.Dispose();
	}

	private void EnsureScroller()
	{
		if (m_ensuredScroller)
		{
			return;
		}
		ResetScrollers();
		ItemsSourceView itemsSourceView = m_owner.ItemsSourceView;
		if (itemsSourceView != null && itemsSourceView.Count <= 0)
		{
			return;
		}
		for (DependencyObject parent = CachedVisualTreeHelpers.GetParent(m_owner); parent != null; parent = CachedVisualTreeHelpers.GetParent(parent))
		{
			if (parent is IScrollAnchorProvider scroller)
			{
				m_scroller = scroller;
				break;
			}
		}
		if (!m_managingViewportDisabled)
		{
			m_effectiveViewportChangedRevoker = Disposable.Create(delegate
			{
				m_owner.EffectiveViewportChanged -= new TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>(OnEffectiveViewportChanged);
				m_effectiveViewportChangedRevoker = null;
			});
			m_owner.EffectiveViewportChanged += new TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>(OnEffectiveViewportChanged);
		}
		m_ensuredScroller = true;
	}

	private void UpdateViewport(Rect viewport)
	{
		Rect visibleWindow = m_visibleWindow;
		Rect visibleWindow2 = viewport;
		if (0.0 - visibleWindow2.X <= ItemsRepeater.ClearedElementsArrangePosition.X && 0.0 - visibleWindow2.Y <= ItemsRepeater.ClearedElementsArrangePosition.Y)
		{
			m_visibleWindow = default(Rect);
		}
		else
		{
			m_visibleWindow = visibleWindow2;
		}
		if (m_owner.Layout is VirtualizingLayout virtualizingLayout && virtualizingLayout.IsSignificantViewportChange(_uno_viewportUsedInLastMeasure, m_visibleWindow))
		{
			TryInvalidateMeasure();
		}
	}

	private void ResetCacheBuffer()
	{
		m_horizontalCacheBufferPerSide = 0.0;
		m_verticalCacheBufferPerSide = 0.0;
		if (!m_managingViewportDisabled)
		{
			RegisterCacheBuildWork();
		}
	}

	private void ValidateCacheLength(double cacheLength)
	{
		if (cacheLength < 0.0 || double.IsInfinity(cacheLength) || double.IsInfinity(cacheLength))
		{
			throw new ArgumentOutOfRangeException("The maximum cache length must be equal or superior to zero.");
		}
	}

	private void RegisterCacheBuildWork()
	{
		if (m_owner.Layout != null && m_cacheBuildAction == null)
		{
			ItemsRepeater owner = m_owner;
			m_cacheBuildAction = m_owner.Dispatcher.RunIdleAsync(delegate
			{
				OnCacheBuildActionCompleted();
			});
		}
	}

	private void TryInvalidateMeasure()
	{
		if (m_visibleWindow != default(Rect))
		{
			ItemsSourceView itemsSourceView = m_owner.ItemsSourceView;
			if (itemsSourceView != null && itemsSourceView.Count > 0)
			{
				m_owner.InvalidateMeasure();
			}
		}
	}

	private string GetLayoutId()
	{
		return m_owner.Layout?.LayoutId;
	}
}
