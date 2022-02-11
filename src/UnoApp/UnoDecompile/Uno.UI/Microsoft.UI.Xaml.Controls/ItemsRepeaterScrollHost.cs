using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Private.Controls;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

[ContentProperty(Name = "ScrollViewer")]
public class ItemsRepeaterScrollHost : FrameworkElement, IScrollAnchorProvider, IRepeaterScrollingSurface
{
	private class CandidateInfo
	{
		public static Rect InvalidBounds = new Rect(-1.0, -1.0, -1.0, -1.0);

		public UIElement Element { get; }

		public Rect RelativeBounds { get; set; }

		public bool IsRelativeBoundsSet => RelativeBounds != InvalidBounds;

		public CandidateInfo(UIElement element)
		{
			Element = element;
			RelativeBounds = InvalidBounds;
		}
	}

	private struct BringIntoViewState
	{
		public UIElement TargetElement { get; private set; }

		public double AlignmentX { get; private set; }

		public double AlignmentY { get; private set; }

		public double OffsetX { get; private set; }

		public double OffsetY { get; private set; }

		public bool Animate { get; private set; }

		public bool ChangeViewCalled { get; set; }

		public Point ChangeViewOffset { get; set; }

		public BringIntoViewState(UIElement targetElement, double alignmentX, double alignmentY, double offsetX, double offsetY, bool animate)
		{
			TargetElement = targetElement;
			AlignmentX = alignmentX;
			AlignmentY = alignmentY;
			OffsetX = offsetX;
			OffsetY = offsetY;
			Animate = animate;
			ChangeViewCalled = false;
			ChangeViewOffset = default(Point);
		}

		public void Reset()
		{
			TargetElement = null;
			double num2 = (OffsetY = 0.0);
			double num4 = (OffsetX = num2);
			double num7 = (AlignmentX = (AlignmentY = num4));
			bool animate = (ChangeViewCalled = false);
			Animate = animate;
			ChangeViewOffset = default(Point);
		}
	}

	private List<CandidateInfo> m_candidates = new List<CandidateInfo>();

	private UIElement m_anchorElement;

	private Rect m_anchorElementRelativeBounds;

	private bool m_isAnchorElementDirty = true;

	private BringIntoViewState m_pendingBringIntoView;

	private double m_pendingViewportShift;

	private IDisposable m_scrollViewerViewChanging;

	private IDisposable m_scrollViewerViewChanged;

	private IDisposable m_scrollViewerSizeChanged;

	private bool HasPendingBringIntoView => m_pendingBringIntoView.TargetElement != null;

	public UIElement CurrentAnchor
	{
		get
		{
			Rect relativeBounds;
			return GetAnchorElement(out relativeBounds);
		}
	}

	public ScrollViewer ScrollViewer
	{
		get
		{
			ScrollViewer result = null;
			List<DependencyObject> list = VisualTreeHelper.GetChildren(this).ToList();
			if (list.Count > 0)
			{
				result = list[0] as ScrollViewer;
			}
			return result;
		}
		set
		{
			m_scrollViewerViewChanging?.Dispose();
			m_scrollViewerViewChanged?.Dispose();
			m_scrollViewerSizeChanged?.Dispose();
			VisualTreeHelper.ClearChildren(this);
			VisualTreeHelper.AddChild(this, value);
			value.ViewChanging += OnScrollViewerViewChanging;
			m_scrollViewerViewChanging = Disposable.Create(delegate
			{
				value.ViewChanging -= OnScrollViewerViewChanging;
			});
			value.ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
			m_scrollViewerViewChanged = Disposable.Create(delegate
			{
				value.ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnScrollViewerViewChanged);
			});
			value.SizeChanged += OnScrollViewerSizeChanged;
			m_scrollViewerSizeChanged = Disposable.Create(delegate
			{
				value.SizeChanged -= OnScrollViewerSizeChanged;
			});
		}
	}

	internal double HorizontalAnchorRatio { get; set; }

	internal double VerticalAnchorRatio { get; set; }

	UIElement IRepeaterScrollingSurface.AnchorElement
	{
		get
		{
			Rect relativeBounds;
			return GetAnchorElement(out relativeBounds);
		}
	}

	bool IRepeaterScrollingSurface.IsHorizontallyScrollable => true;

	bool IRepeaterScrollingSurface.IsVerticallyScrollable => true;

	private event ViewportChangedEventHandler _viewportChanged;

	event ViewportChangedEventHandler IRepeaterScrollingSurface.ViewportChanged
	{
		add
		{
			_viewportChanged += value;
		}
		remove
		{
			_viewportChanged -= value;
		}
	}

	private event PostArrangeEventHandler _postArrange;

	event PostArrangeEventHandler IRepeaterScrollingSurface.PostArrange
	{
		add
		{
			_postArrange += value;
		}
		remove
		{
			_postArrange -= value;
		}
	}

	private event ConfigurationChangedEventHandler _configurationChanged;

	event ConfigurationChangedEventHandler IRepeaterScrollingSurface.ConfigurationChanged
	{
		add
		{
			_configurationChanged += value;
		}
		remove
		{
			_configurationChanged -= value;
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size result = default(Size);
		ScrollViewer scrollViewer = ScrollViewer;
		if (scrollViewer != null)
		{
			scrollViewer.Measure(availableSize);
			return scrollViewer.DesiredSize;
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size result = finalSize;
		ScrollViewer scrollViewer = ScrollViewer;
		if (scrollViewer != null)
		{
			bool flag = scrollViewer != null && HasPendingBringIntoView && !m_pendingBringIntoView.ChangeViewCalled;
			Rect relativeBounds = default(Rect);
			UIElement uIElement = (flag ? null : GetAnchorElement(out relativeBounds));
			scrollViewer.Arrange(new Rect(0.0, 0.0, finalSize.Width, finalSize.Height));
			m_pendingViewportShift = 0.0;
			if (flag)
			{
				ApplyPendingChangeView(scrollViewer);
			}
			else if (uIElement != null)
			{
				m_pendingViewportShift = TrackElement(uIElement, relativeBounds, scrollViewer);
			}
			else if (scrollViewer != null)
			{
				m_pendingBringIntoView.Reset();
			}
			m_candidates.Clear();
			m_isAnchorElementDirty = true;
			this._postArrange?.Invoke(this);
		}
		return result;
	}

	internal void StartBringIntoView(UIElement element, double alignmentX, double alignmentY, double offsetX, double offsetY, bool animate)
	{
		m_pendingBringIntoView = new BringIntoViewState(element, alignmentX, alignmentY, offsetX, offsetY, animate);
	}

	void IScrollAnchorProvider.RegisterAnchorCandidate(UIElement element)
	{
		RegisterAnchorCandidate(element);
	}

	void IRepeaterScrollingSurface.RegisterAnchorCandidate(UIElement element)
	{
		RegisterAnchorCandidate(element);
	}

	internal void RegisterAnchorCandidate(UIElement element)
	{
		if (!double.IsNaN(HorizontalAnchorRatio) || !double.IsNaN(VerticalAnchorRatio))
		{
			ScrollViewer scrollViewer = ScrollViewer;
			if (scrollViewer != null)
			{
				m_candidates.Add(new CandidateInfo(element));
				m_isAnchorElementDirty = true;
			}
		}
	}

	void IScrollAnchorProvider.UnregisterAnchorCandidate(UIElement element)
	{
		UnregisterAnchorCandidate(element);
	}

	void IRepeaterScrollingSurface.UnregisterAnchorCandidate(UIElement element)
	{
		UnregisterAnchorCandidate(element);
	}

	internal void UnregisterAnchorCandidate(UIElement element)
	{
		int num = m_candidates.FindIndex((CandidateInfo c) => c.Element == element);
		if (num != -1)
		{
			m_candidates.RemoveAt(num);
			m_isAnchorElementDirty = true;
		}
	}

	Rect IRepeaterScrollingSurface.GetRelativeViewport(UIElement element)
	{
		ScrollViewer scrollViewer = ScrollViewer;
		if (scrollViewer != null)
		{
			bool hasPendingBringIntoView = HasPendingBringIntoView;
			GeneralTransform generalTransform = element.TransformToVisual(hasPendingBringIntoView ? scrollViewer.ContentTemplateRoot : scrollViewer);
			double num = scrollViewer.ZoomFactor;
			double num2 = scrollViewer.ViewportWidth / num;
			double num3 = scrollViewer.ViewportHeight / num;
			Point point = generalTransform.TransformPoint(default(Point));
			point.X = 0.0 - point.X;
			point.Y = 0.0 - point.Y + (double)(float)m_pendingViewportShift;
			if (hasPendingBringIntoView)
			{
				point.X += m_pendingBringIntoView.ChangeViewOffset.X;
				point.Y += m_pendingBringIntoView.ChangeViewOffset.Y;
			}
			return new Rect(point.X, point.Y, (float)num2, (float)num3);
		}
		return default(Rect);
	}

	private void ApplyPendingChangeView(ScrollViewer scrollViewer)
	{
		BringIntoViewState pendingBringIntoView = m_pendingBringIntoView;
		pendingBringIntoView.ChangeViewCalled = true;
		Rect layoutSlot = CachedVisualTreeHelpers.GetLayoutSlot(pendingBringIntoView.TargetElement as FrameworkElement);
		Rect rect = pendingBringIntoView.TargetElement.TransformToVisual(scrollViewer.ContentTemplateRoot).TransformBounds(new Rect(0.0, 0.0, layoutSlot.Width, layoutSlot.Height));
		Point point = new Point((float)(scrollViewer.ViewportWidth - rect.Width), (float)(scrollViewer.ViewportHeight - rect.Height));
		Point point3 = (pendingBringIntoView.ChangeViewOffset = new Point(Math.Max(0f, (float)Math.Min(rect.X + pendingBringIntoView.OffsetX - point.X * pendingBringIntoView.AlignmentX, scrollViewer.ExtentWidth - scrollViewer.ViewportWidth)), Math.Max(0f, (float)Math.Min(rect.Y + pendingBringIntoView.OffsetY - point.Y * pendingBringIntoView.AlignmentY, scrollViewer.ExtentHeight - scrollViewer.ViewportHeight))));
		scrollViewer.ChangeView(point3.X, point3.Y, null, !pendingBringIntoView.Animate);
		m_pendingBringIntoView = pendingBringIntoView;
	}

	private double TrackElement(UIElement element, Rect previousBounds, ScrollViewer scrollViewer)
	{
		Rect layoutSlot = LayoutInformation.GetLayoutSlot(element as FrameworkElement);
		GeneralTransform generalTransform = element.TransformToVisual(scrollViewer.ContentTemplateRoot);
		Rect rect = generalTransform.TransformBounds(new Rect(0.0, 0.0, layoutSlot.Width, layoutSlot.Height));
		double num = previousBounds.Y + HorizontalAnchorRatio * previousBounds.Height;
		double num2 = rect.Y + HorizontalAnchorRatio * rect.Height;
		double num3 = num2 - num;
		double num4 = num3;
		double num5 = ((HasPendingBringIntoView && !m_pendingBringIntoView.Animate) ? m_pendingBringIntoView.ChangeViewOffset.Y : scrollViewer.VerticalOffset);
		if (num5 + num4 < 0.0)
		{
			num4 = 0.0 - num5;
		}
		else if (num5 + scrollViewer.ViewportHeight + num4 > scrollViewer.ExtentHeight)
		{
			num4 = scrollViewer.ExtentHeight - scrollViewer.ViewportHeight - num5;
		}
		if (Math.Abs(num4) > 1.0)
		{
			scrollViewer.ChangeView(null, num5 + num4, null, disableAnimation: true);
		}
		else
		{
			num4 = 0.0;
			if (Math.Abs(num3) > 1.0)
			{
				this._viewportChanged?.Invoke(this, isFinal: true);
			}
		}
		return num4;
	}

	private UIElement GetAnchorElement(out Rect relativeBounds)
	{
		if (m_isAnchorElementDirty)
		{
			ScrollViewer scrollViewer = ScrollViewer;
			if (scrollViewer != null)
			{
				double num = ((HasPendingBringIntoView && !m_pendingBringIntoView.Animate) ? m_pendingBringIntoView.ChangeViewOffset.Y : scrollViewer.VerticalOffset);
				double num2 = num + HorizontalAnchorRatio * scrollViewer.ViewportHeight + m_pendingViewportShift;
				CandidateInfo candidateInfo = null;
				double num3 = 3.4028234663852886E+38;
				foreach (CandidateInfo candidate in m_candidates)
				{
					UIElement element = candidate.Element;
					if (!candidate.IsRelativeBoundsSet)
					{
						Rect layoutSlot = LayoutInformation.GetLayoutSlot(element as FrameworkElement);
						GeneralTransform generalTransform = element.TransformToVisual(scrollViewer.ContentTemplateRoot);
						candidate.RelativeBounds = generalTransform.TransformBounds(new Rect(0.0, 0.0, layoutSlot.Width, layoutSlot.Height));
					}
					double num4 = candidate.RelativeBounds.Y + HorizontalAnchorRatio * candidate.RelativeBounds.Height;
					double num5 = Math.Abs(num4 - num2);
					if (num5 < num3)
					{
						candidateInfo = candidate;
						num3 = num5;
					}
				}
				if (candidateInfo != null)
				{
					m_anchorElement = candidateInfo.Element;
					m_anchorElementRelativeBounds = candidateInfo.RelativeBounds;
				}
				else
				{
					m_anchorElement = null;
					m_anchorElementRelativeBounds = CandidateInfo.InvalidBounds;
				}
			}
			m_isAnchorElementDirty = false;
		}
		relativeBounds = m_anchorElementRelativeBounds;
		return m_anchorElement;
	}

	private void OnScrollViewerViewChanging(object sender, ScrollViewerViewChangingEventArgs args)
	{
		this._viewportChanged?.Invoke(this, isFinal: false);
	}

	private void OnScrollViewerViewChanged(object _, ScrollViewerViewChangedEventArgs args)
	{
		bool flag = !args.IsIntermediate;
		if (flag)
		{
			m_pendingViewportShift = 0.0;
			if (HasPendingBringIntoView && m_pendingBringIntoView.ChangeViewCalled)
			{
				m_pendingBringIntoView.Reset();
			}
		}
		this._viewportChanged?.Invoke(this, flag);
	}

	private void OnScrollViewerSizeChanged(object sender, SizeChangedEventArgs args)
	{
		this._viewportChanged?.Invoke(this, isFinal: true);
	}
}
