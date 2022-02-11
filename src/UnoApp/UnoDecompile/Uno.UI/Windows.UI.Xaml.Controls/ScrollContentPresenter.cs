using System;
using System.Globalization;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class ScrollContentPresenter : ContentPresenter, ILayoutConstraints, IScrollContentPresenter
{
	private ManagedWeakReference _scroller;

	private bool _forceChangeToCurrentView;

	private ScrollBarVisibility _verticalScrollBarVisibility;

	private ScrollBarVisibility _horizontalScrollBarVisibility;

	private bool _eventsRegistered;

	private (double? horizontal, double? vertical)? _pendingScrollTo;

	private FrameworkElement _rootEltUsedToProcessScrollTo;

	private static readonly string[] VerticalVisibilityClasses = new string[4] { "scroll-y-auto", "scroll-y-disabled", "scroll-y-hidden", "scroll-y-visible" };

	private static readonly string[] HorizontalVisibilityClasses = new string[4] { "scroll-x-auto", "scroll-x-disabled", "scroll-x-hidden", "scroll-x-visible" };

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool SizesContentToTemplatedParent
	{
		get
		{
			return (bool)GetValue(SizesContentToTemplatedParentProperty);
		}
		set
		{
			SetValue(SizesContentToTemplatedParentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanContentRenderOutsideBounds
	{
		get
		{
			return (bool)GetValue(CanContentRenderOutsideBoundsProperty);
		}
		set
		{
			SetValue(CanContentRenderOutsideBoundsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanContentRenderOutsideBoundsProperty { get; } = DependencyProperty.Register("CanContentRenderOutsideBounds", typeof(bool), typeof(ScrollContentPresenter), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SizesContentToTemplatedParentProperty { get; } = DependencyProperty.Register("SizesContentToTemplatedParent", typeof(bool), typeof(ScrollContentPresenter), new FrameworkPropertyMetadata(false));


	public object ScrollOwner
	{
		get
		{
			return _scroller.Target;
		}
		set
		{
			ManagedWeakReference scroller = _scroller;
			if (scroller != null)
			{
				WeakReferencePool.ReturnWeakReference(this, scroller);
			}
			_scroller = WeakReferencePool.RentWeakReference(this, value);
		}
	}

	private ScrollViewer Scroller => ScrollOwner as ScrollViewer;

	bool IScrollContentPresenter.ForceChangeToCurrentView
	{
		get
		{
			return _forceChangeToCurrentView;
		}
		set
		{
			_forceChangeToCurrentView = value;
		}
	}

	public double ExtentHeight
	{
		get
		{
			if (Content is FrameworkElement frameworkElement)
			{
				double height = frameworkElement.Height;
				if (!height.IsNaN())
				{
					return height;
				}
				if (!(base.ActualHeight > 0.0) || frameworkElement.VerticalAlignment != VerticalAlignment.Stretch)
				{
					return frameworkElement.DesiredSize.Height;
				}
				return frameworkElement.ActualHeight;
			}
			return 0.0;
		}
	}

	public double ExtentWidth
	{
		get
		{
			if (Content is FrameworkElement frameworkElement)
			{
				double width = frameworkElement.Width;
				if (!width.IsNaN())
				{
					return width;
				}
				if (!(base.ActualWidth > 0.0) || frameworkElement.HorizontalAlignment != HorizontalAlignment.Stretch)
				{
					return frameworkElement.DesiredSize.Width;
				}
				return frameworkElement.ActualWidth;
			}
			return 0.0;
		}
	}

	public double ViewportHeight => base.DesiredSize.Height;

	public double ViewportWidth => base.DesiredSize.Width;

	internal Size ScrollBarSize
	{
		get
		{
			var (size, size2) = WindowManagerInterop.GetClientViewSize(base.HtmlId);
			return new Size(size2.Width - size.Width, size2.Height - size.Height);
		}
	}

	ScrollBarVisibility IScrollContentPresenter.NativeVerticalScrollBarVisibility
	{
		set
		{
			VerticalScrollBarVisibility = value;
		}
	}

	internal ScrollBarVisibility VerticalScrollBarVisibility
	{
		get
		{
			return _verticalScrollBarVisibility;
		}
		set
		{
			if (_verticalScrollBarVisibility != value)
			{
				_verticalScrollBarVisibility = value;
				SetClasses(VerticalVisibilityClasses, (int)value);
				TryRegisterEvents(value);
			}
		}
	}

	ScrollBarVisibility IScrollContentPresenter.NativeHorizontalScrollBarVisibility
	{
		set
		{
			HorizontalScrollBarVisibility = value;
		}
	}

	internal ScrollBarVisibility HorizontalScrollBarVisibility
	{
		get
		{
			return _horizontalScrollBarVisibility;
		}
		set
		{
			if (_horizontalScrollBarVisibility != value)
			{
				_horizontalScrollBarVisibility = value;
				SetClasses(HorizontalVisibilityClasses, (int)value);
				TryRegisterEvents(value);
			}
		}
	}

	public bool CanHorizontallyScroll
	{
		get
		{
			if (HorizontalScrollBarVisibility == ScrollBarVisibility.Disabled)
			{
				return _forceChangeToCurrentView;
			}
			return true;
		}
		set
		{
		}
	}

	public bool CanVerticallyScroll
	{
		get
		{
			if (VerticalScrollBarVisibility == ScrollBarVisibility.Disabled)
			{
				return _forceChangeToCurrentView;
			}
			return true;
		}
		set
		{
		}
	}

	public double HorizontalOffset { get; private set; }

	public double VerticalOffset { get; private set; }

	Size? IScrollContentPresenter.CustomContentExtent => null;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.LineUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.LineDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.LineLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void LineRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.LineRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.PageUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.PageDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.PageLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PageRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.PageRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelUp()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.MouseWheelUp()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelDown()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.MouseWheelDown()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelLeft()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.MouseWheelLeft()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MouseWheelRight()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.MouseWheelRight()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__" })]
	public void SetHorizontalOffset(double offset)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.SetHorizontalOffset(double offset)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__NETSTD_REFERENCE__" })]
	public void SetVerticalOffset(double offset)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollContentPresenter", "void ScrollContentPresenter.SetVerticalOffset(double offset)");
	}

	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Rect MakeVisible(UIElement visual, Rect rectangle)
	{
		throw new NotImplementedException("The member Rect ScrollContentPresenter.MakeVisible(UIElement visual, Rect rectangle) is not implemented in Uno.");
	}

	public ScrollContentPresenter()
	{
		UIElement.RegisterAsScrollPort(this);
	}

	private void InitializeScrollContentPresenter()
	{
		this.RegisterParentChangedCallback(this, OnParentChanged);
	}

	private void OnParentChanged(object instance, object key, DependencyObjectParentChangedEventArgs args)
	{
		if (args.NewParent == null)
		{
			Content = null;
		}
	}

	bool ILayoutConstraints.IsWidthConstrained(UIElement requester)
	{
		if (requester != null && CanHorizontallyScroll)
		{
			return false;
		}
		return this.IsWidthConstrainedSimple() ?? (base.Parent as ILayoutConstraints)?.IsWidthConstrained(this) ?? false;
	}

	bool ILayoutConstraints.IsHeightConstrained(UIElement requester)
	{
		if (requester != null && CanVerticallyScroll)
		{
			return false;
		}
		return this.IsHeightConstrainedSimple() ?? (base.Parent as ILayoutConstraints)?.IsHeightConstrained(this) ?? false;
	}

	protected override Size MeasureOverride(Size size)
	{
		if (Content is UIElement uIElement)
		{
			Size availableSize = size;
			if (CanVerticallyScroll || _forceChangeToCurrentView)
			{
				availableSize.Height = double.PositiveInfinity;
			}
			if (CanHorizontallyScroll || _forceChangeToCurrentView)
			{
				availableSize.Width = double.PositiveInfinity;
			}
			uIElement.Measure(availableSize);
			Size size2 = uIElement.DesiredSize;
			(uIElement as ICustomScrollInfo)?.ApplyViewport(ref size2);
			return new Size(Math.Min(size.Width, size2.Width), Math.Min(size.Height, size2.Height));
		}
		return new Size(0.0, 0.0);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		if (Content is UIElement uIElement)
		{
			Rect finalRect = default(Rect);
			Size desiredSize = uIElement.DesiredSize;
			finalRect.Width = Math.Max(finalSize.Width, desiredSize.Width);
			finalRect.Height = Math.Max(finalSize.Height, desiredSize.Height);
			uIElement.Arrange(finalRect);
			(uIElement as ICustomScrollInfo)?.ApplyViewport(ref finalSize);
		}
		return finalSize;
	}

	internal override bool IsViewHit()
	{
		return true;
	}

	private void TryRegisterEvents(ScrollBarVisibility visibility)
	{
		if (!_eventsRegistered && (visibility == ScrollBarVisibility.Auto || visibility == ScrollBarVisibility.Visible))
		{
			_eventsRegistered = true;
			base.PointerReleased += HandlePointerEvent;
			base.PointerPressed += HandlePointerEvent;
			base.PointerCanceled += HandlePointerEvent;
			base.PointerMoved += HandlePointerEvent;
			base.PointerEntered += HandlePointerEvent;
			base.PointerExited += HandlePointerEvent;
			base.PointerWheelChanged += HandlePointerEvent;
		}
	}

	private static void HandlePointerEvent(object sender, PointerRoutedEventArgs e)
	{
		((ScrollContentPresenter)sender).HandlePointerEvent(e);
	}

	private void HandlePointerEvent(PointerRoutedEventArgs e)
	{
		(Size clientSize, Size offsetSize) clientViewSize = WindowManagerInterop.GetClientViewSize(base.HtmlId);
		Size item = clientViewSize.clientSize;
		Size item2 = clientViewSize.offsetSize;
		bool flag = item2.Height - item.Height > 0.0;
		bool flag2 = item2.Width - item.Width > 0.0;
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"{base.HtmlId}: {item2} / {item} / {e.GetCurrentPoint(this)}");
		}
		if (flag2 || flag)
		{
			Point position = e.GetCurrentPoint(this).Position;
			bool flag3 = flag2 && position.X >= item.Width;
			bool flag4 = flag && position.Y >= item.Height;
			if (flag3 || flag4)
			{
				e.Handled = true;
			}
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		RestoreScroll();
		RegisterEventHandler("scroll", new EventHandler(OnScroll), GenericEventHandlers.RaiseEventHandler);
	}

	private void RestoreScroll()
	{
		if (base.TemplatedParent is ScrollViewer scrollViewer && (scrollViewer.HorizontalOffset > 0.0 || scrollViewer.VerticalOffset > 0.0))
		{
			ScrollTo(scrollViewer.HorizontalOffset, scrollViewer.VerticalOffset, disableAnimation: true);
		}
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		UnregisterEventHandler("scroll", new EventHandler(OnScroll), GenericEventHandlers.RaiseEventHandler);
		FrameworkElement rootEltUsedToProcessScrollTo = _rootEltUsedToProcessScrollTo;
		if (rootEltUsedToProcessScrollTo != null)
		{
			rootEltUsedToProcessScrollTo.LayoutUpdated -= TryProcessScrollTo;
			_rootEltUsedToProcessScrollTo = null;
		}
	}

	internal override void OnLayoutUpdated()
	{
		base.OnLayoutUpdated();
		TryProcessScrollTo();
	}

	public void ScrollTo(double? horizontalOffset, double? verticalOffset, bool disableAnimation)
	{
		_pendingScrollTo = new(double?, double?)?((horizontalOffset, verticalOffset));
		WindowManagerInterop.ScrollTo(base.HtmlId, horizontalOffset, verticalOffset, disableAnimation);
		if (!_pendingScrollTo.HasValue)
		{
			return;
		}
		if (_rootEltUsedToProcessScrollTo == null && Window.Current.RootElement is FrameworkElement frameworkElement)
		{
			_rootEltUsedToProcessScrollTo = frameworkElement;
			frameworkElement.LayoutUpdated += TryProcessScrollTo;
		}
		if (disableAnimation)
		{
			double nativeHorizontalOffset = GetNativeHorizontalOffset();
			double nativeVerticalOffset = GetNativeVerticalOffset();
			if ((!(horizontalOffset < 0.0) || nativeHorizontalOffset != 0.0) && (!(verticalOffset < 0.0) || nativeVerticalOffset != 0.0))
			{
				(base.TemplatedParent as ScrollViewer)?.OnPresenterScrolled(horizontalOffset ?? nativeHorizontalOffset, verticalOffset ?? nativeVerticalOffset, isIntermediate: false);
			}
		}
	}

	private void TryProcessScrollTo(object sender, object e)
	{
		TryProcessScrollTo();
	}

	private void TryProcessScrollTo()
	{
		(double?, double?)? pendingScrollTo = _pendingScrollTo;
		if (pendingScrollTo.HasValue)
		{
			(double?, double?) valueOrDefault = pendingScrollTo.GetValueOrDefault();
			WindowManagerInterop.ScrollTo(base.HtmlId, valueOrDefault.Item1, valueOrDefault.Item2, disableAnimation: true);
		}
	}

	private void OnScroll(object sender, EventArgs args)
	{
		bool isIntermediate = false;
		double nativeHorizontalOffset = GetNativeHorizontalOffset();
		double nativeVerticalOffset = GetNativeVerticalOffset();
		if (base.IsArrangeDirty)
		{
			(double?, double?)? pendingScrollTo = _pendingScrollTo;
			if (pendingScrollTo.HasValue)
			{
				(double?, double?) valueOrDefault = pendingScrollTo.GetValueOrDefault();
				double? num;
				(num, _) = valueOrDefault;
				if (num.HasValue)
				{
					double valueOrDefault2 = num.GetValueOrDefault();
					if (Math.Abs(nativeHorizontalOffset - valueOrDefault2) > 1.0)
					{
						return;
					}
				}
				num = valueOrDefault.Item2;
				if (num.HasValue)
				{
					double valueOrDefault3 = num.GetValueOrDefault();
					if (Math.Abs(nativeVerticalOffset - valueOrDefault3) > 1.0)
					{
						return;
					}
				}
			}
		}
		_pendingScrollTo = null;
		HorizontalOffset = nativeHorizontalOffset;
		VerticalOffset = nativeVerticalOffset;
		Scroller?.OnPresenterScrolled(nativeHorizontalOffset, nativeVerticalOffset, isIntermediate);
		base.ScrollOffsets = new Point(nativeHorizontalOffset, nativeVerticalOffset);
		InvalidateViewport();
	}

	private double GetNativeHorizontalOffset()
	{
		if (!double.TryParse(GetProperty("scrollLeft"), NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
		{
			return 0.0;
		}
		return result;
	}

	private double GetNativeVerticalOffset()
	{
		if (!double.TryParse(GetProperty("scrollTop"), NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
		{
			return 0.0;
		}
		return result;
	}

	void IScrollContentPresenter.OnMinZoomFactorChanged(float newValue)
	{
	}

	void IScrollContentPresenter.OnMaxZoomFactorChanged(float newValue)
	{
	}
}
