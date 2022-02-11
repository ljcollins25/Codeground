using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DirectUI;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Helpers.WinUI;
using Uno.UI.Xaml.Controls;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class ScrollViewer : ContentControl, IScrollAnchorProvider, IFrameworkTemplatePoolAware, ICustomClippingElement
{
	private class ConstantVelocityScroller
	{
		private readonly DispatcherTimer _timer = new DispatcherTimer();

		private readonly ScrollViewer parent;

		private bool _isStarted;

		private long? _previousTick;

		private float _horizontalVelocity;

		private float _verticalVelocity;

		private const int FrameIntervalMS = 25;

		public float HorizontalVelocity
		{
			get
			{
				return _horizontalVelocity;
			}
			set
			{
				_horizontalVelocity = value;
				StartOrStopTimer();
			}
		}

		public float VerticalVelocity
		{
			get
			{
				return _verticalVelocity;
			}
			set
			{
				_verticalVelocity = value;
				StartOrStopTimer();
			}
		}

		public ConstantVelocityScroller(ScrollViewer _parent)
		{
			parent = _parent;
			_timer.Tick += UpdateScrollPosition;
			_timer.Interval = TimeSpan.FromMilliseconds(25.0);
		}

		private void StartOrStopTimer()
		{
			bool flag = HorizontalVelocity != 0f || VerticalVelocity != 0f;
			if (flag && !_isStarted)
			{
				_timer.Start();
			}
			else if (!flag && _isStarted)
			{
				_previousTick = null;
				_timer.Stop();
			}
			_isStarted = flag;
		}

		private void UpdateScrollPosition(object? sender, object e)
		{
			long ticks = DateTimeOffset.Now.Ticks;
			long? previousTick = _previousTick;
			if (previousTick.HasValue)
			{
				long valueOrDefault = previousTick.GetValueOrDefault();
				double num = (double)(ticks - valueOrDefault) / 10000000.0;
				double? num2 = ((HorizontalVelocity != 0f) ? new double?((double)HorizontalVelocity * num) : null);
				double? num3 = ((VerticalVelocity != 0f) ? new double?((double)VerticalVelocity * num) : null);
				if (num2 >= 1.0 || num3 >= 1.0 || num2 <= 1.0 || num3 <= 1.0)
				{
					parent.ChangeView(MathEx.Max(0.0, parent.HorizontalOffset + num2), MathEx.Max(0.0, parent.VerticalOffset + num3), null, disableAnimation: true);
					_previousTick = ticks;
				}
			}
			else
			{
				_previousTick = ticks;
			}
		}
	}

	private static class Parts
	{
		public static class Uwp
		{
			public const string ScrollContentPresenter = "ScrollContentPresenter";

			public const string VerticalScrollBar = "VerticalScrollBar";

			public const string HorizontalScrollBar = "HorizontalScrollBar";
		}

		public static class WinUI3
		{
			public const string Scroller = "PART_Scroller";

			public const string VerticalScrollBar = "PART_VerticalScrollBar";

			public const string HorizontalScrollBar = "PART_HorizontalScrollBar";
		}
	}

	private static class VisualStates
	{
		public static class ScrollingIndicator
		{
			public const string None = "NoIndicator";

			public const string Touch = "TouchIndicator";

			public const string Mouse = "MouseIndicator";
		}

		public static class ScrollBarsSeparator
		{
			public const string Collapsed = "ScrollBarSeparatorCollapsed";

			public const string Expanded = "ScrollBarSeparatorExpanded";

			public const string ExpandedWithoutAnimation = "ScrollBarSeparatorExpandedWithoutAnimation";

			public const string CollapsedWithoutAnimation = "ScrollBarSeparatorCollapsedWithoutAnimation";
		}
	}

	private ConstantVelocityScroller? _constantVelocityScroller;

	private bool m_isInConstantVelocityPan;

	private static PropertyChangedCallback OnHorizontalScrollabilityPropertyChanged;

	private static PropertyChangedCallback OnVerticalScrollabilityPropertyChanged;

	private readonly SerialDisposable _sizeChangedSubscription = new SerialDisposable();

	private IScrollContentPresenter? _presenter;

	private bool _isTemplateApplied;

	private ScrollBar? _verticalScrollbar;

	private ScrollBar? _horizontalScrollbar;

	private bool _isVerticalScrollBarMaterialized;

	private bool _isHorizontalScrollBarMaterialized;

	private bool _hasPendingUpdate;

	private double _pendingHorizontalOffset;

	private double _pendingVerticalOffset;

	private DispatcherQueueTimer? _snapPointsTimer;

	private double? _horizontalOffsetForSnapPoints;

	private double? _verticalOffsetForSnapPoints;

	private static readonly TimeSpan _indicatorResetDelay;

	private static readonly bool _indicatorResetDisabled;

	private DispatcherQueueTimer? _indicatorResetTimer;

	private string? _indicatorState;

	private IDisposable? _directManipulationHandlerSubscription;

	internal bool m_templatedParentHandlesMouseButton;

	private const float ScrollViewerSnapPointLocationTolerance = 0.0001f;

	private IScrollSnapPointsInfo _snapPointsInfo;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsVerticalRailEnabled
	{
		get
		{
			return (bool)GetValue(IsVerticalRailEnabledProperty);
		}
		set
		{
			SetValue(IsVerticalRailEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsScrollInertiaEnabled
	{
		get
		{
			return (bool)GetValue(IsScrollInertiaEnabledProperty);
		}
		set
		{
			SetValue(IsScrollInertiaEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHorizontalScrollChainingEnabled
	{
		get
		{
			return (bool)GetValue(IsHorizontalScrollChainingEnabledProperty);
		}
		set
		{
			SetValue(IsHorizontalScrollChainingEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHorizontalRailEnabled
	{
		get
		{
			return (bool)GetValue(IsHorizontalRailEnabledProperty);
		}
		set
		{
			SetValue(IsHorizontalRailEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDeferredScrollingEnabled
	{
		get
		{
			return (bool)GetValue(IsDeferredScrollingEnabledProperty);
		}
		set
		{
			SetValue(IsDeferredScrollingEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomInertiaEnabled
	{
		get
		{
			return (bool)GetValue(IsZoomInertiaEnabledProperty);
		}
		set
		{
			SetValue(IsZoomInertiaEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomChainingEnabled
	{
		get
		{
			return (bool)GetValue(IsZoomChainingEnabledProperty);
		}
		set
		{
			SetValue(IsZoomChainingEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsVerticalScrollChainingEnabled
	{
		get
		{
			return (bool)GetValue(IsVerticalScrollChainingEnabledProperty);
		}
		set
		{
			SetValue(IsVerticalScrollChainingEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SnapPointsType ZoomSnapPointsType
	{
		get
		{
			return (SnapPointsType)GetValue(ZoomSnapPointsTypeProperty);
		}
		set
		{
			SetValue(ZoomSnapPointsTypeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<float> ZoomSnapPoints => (IList<float>)GetValue(ZoomSnapPointsProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement TopLeftHeader
	{
		get
		{
			return (UIElement)GetValue(TopLeftHeaderProperty);
		}
		set
		{
			SetValue(TopLeftHeaderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement TopHeader
	{
		get
		{
			return (UIElement)GetValue(TopHeaderProperty);
		}
		set
		{
			SetValue(TopHeaderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement LeftHeader
	{
		get
		{
			return (UIElement)GetValue(LeftHeaderProperty);
		}
		set
		{
			SetValue(LeftHeaderProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalAnchorRatio
	{
		get
		{
			return (double)GetValue(VerticalAnchorRatioProperty);
		}
		set
		{
			SetValue(VerticalAnchorRatioProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ReduceViewportForCoreInputViewOcclusions
	{
		get
		{
			return (bool)GetValue(ReduceViewportForCoreInputViewOcclusionsProperty);
		}
		set
		{
			SetValue(ReduceViewportForCoreInputViewOcclusionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalAnchorRatio
	{
		get
		{
			return (double)GetValue(HorizontalAnchorRatioProperty);
		}
		set
		{
			SetValue(HorizontalAnchorRatioProperty, value);
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
	public static DependencyProperty IsScrollInertiaEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ZoomSnapPointsProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDeferredScrollingEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHorizontalRailEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHorizontalScrollChainingEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ZoomSnapPointsTypeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsVerticalRailEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsVerticalScrollChainingEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomChainingEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomInertiaEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LeftHeaderProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TopHeaderProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TopLeftHeaderProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalAnchorRatioProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ReduceViewportForCoreInputViewOcclusionsProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalAnchorRatioProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanContentRenderOutsideBoundsProperty { get; }

	private static bool IsAnimationEnabled => SharedHelpers.IsAnimationsEnabled();

	public ScrollBarVisibility HorizontalScrollBarVisibility
	{
		get
		{
			return (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
		}
		set
		{
			SetValue(HorizontalScrollBarVisibilityProperty, value);
		}
	}

	public static DependencyProperty HorizontalScrollBarVisibilityProperty { get; }

	public ScrollBarVisibility VerticalScrollBarVisibility
	{
		get
		{
			return (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
		}
		set
		{
			SetValue(VerticalScrollBarVisibilityProperty, value);
		}
	}

	public static DependencyProperty VerticalScrollBarVisibilityProperty { get; }

	public ScrollMode HorizontalScrollMode
	{
		get
		{
			return (ScrollMode)GetValue(HorizontalScrollModeProperty);
		}
		set
		{
			SetValue(HorizontalScrollModeProperty, value);
		}
	}

	public static DependencyProperty HorizontalScrollModeProperty { get; }

	public ScrollMode VerticalScrollMode
	{
		get
		{
			return (ScrollMode)GetValue(VerticalScrollModeProperty);
		}
		set
		{
			SetValue(VerticalScrollModeProperty, value);
		}
	}

	public static DependencyProperty VerticalScrollModeProperty { get; }

	public bool BringIntoViewOnFocusChange
	{
		get
		{
			return (bool)GetValue(BringIntoViewOnFocusChangeProperty);
		}
		set
		{
			SetValue(BringIntoViewOnFocusChangeProperty, value);
		}
	}

	public static DependencyProperty BringIntoViewOnFocusChangeProperty { get; }

	public ZoomMode ZoomMode
	{
		get
		{
			return (ZoomMode)GetValue(ZoomModeProperty);
		}
		set
		{
			SetValue(ZoomModeProperty, value);
		}
	}

	public static DependencyProperty ZoomModeProperty { get; }

	public float MinZoomFactor
	{
		get
		{
			return (float)GetValue(MinZoomFactorProperty);
		}
		set
		{
			SetValue(MinZoomFactorProperty, value);
		}
	}

	public static DependencyProperty MinZoomFactorProperty { get; }

	public float MaxZoomFactor
	{
		get
		{
			return (float)GetValue(MaxZoomFactorProperty);
		}
		set
		{
			SetValue(MaxZoomFactorProperty, value);
		}
	}

	public static DependencyProperty MaxZoomFactorProperty { get; }

	public float ZoomFactor
	{
		get
		{
			return (float)GetValue(ZoomFactorProperty);
		}
		private set
		{
			SetValue(ZoomFactorProperty, value);
		}
	}

	public static DependencyProperty ZoomFactorProperty { get; }

	public SnapPointsType HorizontalSnapPointsType
	{
		get
		{
			return (SnapPointsType)GetValue(HorizontalSnapPointsTypeProperty);
		}
		set
		{
			SetValue(HorizontalSnapPointsTypeProperty, value);
		}
	}

	public static DependencyProperty HorizontalSnapPointsTypeProperty { get; }

	public SnapPointsAlignment HorizontalSnapPointsAlignment
	{
		get
		{
			return (SnapPointsAlignment)GetValue(HorizontalSnapPointsAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalSnapPointsAlignmentProperty, value);
		}
	}

	public static DependencyProperty HorizontalSnapPointsAlignmentProperty { get; }

	public SnapPointsType VerticalSnapPointsType
	{
		get
		{
			return (SnapPointsType)GetValue(VerticalSnapPointsTypeProperty);
		}
		set
		{
			SetValue(VerticalSnapPointsTypeProperty, value);
		}
	}

	public static DependencyProperty VerticalSnapPointsTypeProperty { get; }

	public SnapPointsAlignment VerticalSnapPointsAlignment
	{
		get
		{
			return (SnapPointsAlignment)GetValue(VerticalSnapPointsAlignmentProperty);
		}
		set
		{
			SetValue(VerticalSnapPointsAlignmentProperty, value);
		}
	}

	public static DependencyProperty VerticalSnapPointsAlignmentProperty { get; }

	public double ExtentHeight
	{
		get
		{
			return (double)GetValue(ExtentHeightProperty);
		}
		private set
		{
			SetValue(ExtentHeightProperty, value);
		}
	}

	public static DependencyProperty ExtentHeightProperty { get; }

	public double ExtentWidth
	{
		get
		{
			return (double)GetValue(ExtentWidthProperty);
		}
		private set
		{
			SetValue(ExtentWidthProperty, value);
		}
	}

	public static DependencyProperty ExtentWidthProperty { get; }

	public double ViewportHeight
	{
		get
		{
			return (double)GetValue(ViewportHeightProperty);
		}
		private set
		{
			SetValue(ViewportHeightProperty, value);
		}
	}

	public static DependencyProperty ViewportHeightProperty { get; }

	public double ViewportWidth
	{
		get
		{
			return (double)GetValue(ViewportWidthProperty);
		}
		private set
		{
			SetValue(ViewportWidthProperty, value);
		}
	}

	public static DependencyProperty ViewportWidthProperty { get; }

	public static DependencyProperty ComputedHorizontalScrollBarVisibilityProperty { get; }

	public Visibility ComputedHorizontalScrollBarVisibility
	{
		get
		{
			return (Visibility)GetValue(ComputedHorizontalScrollBarVisibilityProperty);
		}
		private set
		{
			SetValue(ComputedHorizontalScrollBarVisibilityProperty, value);
		}
	}

	public static DependencyProperty ComputedVerticalScrollBarVisibilityProperty { get; }

	public Visibility ComputedVerticalScrollBarVisibility
	{
		get
		{
			return (Visibility)GetValue(ComputedVerticalScrollBarVisibilityProperty);
		}
		private set
		{
			SetValue(ComputedVerticalScrollBarVisibilityProperty, value);
		}
	}

	public double ScrollableHeight
	{
		get
		{
			return (double)GetValue(ScrollableHeightProperty);
		}
		private set
		{
			SetValue(ScrollableHeightProperty, value);
		}
	}

	public static DependencyProperty ScrollableHeightProperty { get; }

	public double ScrollableWidth
	{
		get
		{
			return (double)GetValue(ScrollableWidthProperty);
		}
		private set
		{
			SetValue(ScrollableWidthProperty, value);
		}
	}

	public static DependencyProperty ScrollableWidthProperty { get; }

	public double VerticalOffset
	{
		get
		{
			return (double)GetValue(VerticalOffsetProperty);
		}
		private set
		{
			SetValue(VerticalOffsetProperty, value);
		}
	}

	public static DependencyProperty VerticalOffsetProperty { get; }

	public double HorizontalOffset
	{
		get
		{
			return (double)GetValue(HorizontalOffsetProperty);
		}
		private set
		{
			SetValue(HorizontalOffsetProperty, value);
		}
	}

	public static DependencyProperty HorizontalOffsetProperty { get; }

	internal ScrollContentPresenter? Presenter { get; private set; }

	internal Size ViewportMeasureSize { get; private set; }

	internal Size ViewportArrangeSize { get; private set; }

	[NotImplemented]
	public UIElement? CurrentAnchor => null;

	internal ScrollViewerUpdatesMode UpdatesMode { get; set; }

	[UnoOnly]
	public bool ShouldReportNegativeOffsets { get; set; }

	internal bool ComputedIsHorizontalScrollEnabled { get; private set; }

	internal bool ComputedIsVerticalScrollEnabled { get; private set; }

	internal double MinHorizontalOffset => 0.0;

	internal double MinVerticalOffset => 0.0;

	internal bool ArePointerWheelEventsIgnored { get; set; }

	internal bool IsInManipulation
	{
		get
		{
			if (!IsInDirectManipulation)
			{
				return m_isInConstantVelocityPan;
			}
			return true;
		}
	}

	internal bool ForceChangeToCurrentView { get; set; }

	internal bool IsInDirectManipulation { get; }

	internal bool TemplatedParentHandlesScrolling { get; set; }

	internal Func<AutomationPeer>? AutomationPeerFactoryIndex { get; set; }

	internal Size ScrollBarSize => (_presenter as ScrollContentPresenter)?.ScrollBarSize ?? default(Size);

	bool ICustomClippingElement.AllowClippingToLayoutSlot => true;

	bool ICustomClippingElement.ForceClippingToLayoutSlot => true;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<ScrollViewerViewChangingEventArgs> ViewChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<ScrollViewerViewChangingEventArgs> ScrollViewer.ViewChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<ScrollViewerViewChangingEventArgs> ScrollViewer.ViewChanging");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> DirectManipulationCompleted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<object> ScrollViewer.DirectManipulationCompleted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<object> ScrollViewer.DirectManipulationCompleted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event EventHandler<object> DirectManipulationStarted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<object> ScrollViewer.DirectManipulationStarted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event EventHandler<object> ScrollViewer.DirectManipulationStarted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<ScrollViewer, AnchorRequestedEventArgs> AnchorRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event TypedEventHandler<ScrollViewer, AnchorRequestedEventArgs> ScrollViewer.AnchorRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "event TypedEventHandler<ScrollViewer, AnchorRequestedEventArgs> ScrollViewer.AnchorRequested");
		}
	}

	public event EventHandler<ScrollViewerViewChangedEventArgs>? ViewChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ZoomToFactor(float factor)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "void ScrollViewer.ZoomToFactor(float factor)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void InvalidateScrollInfo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "void ScrollViewer.InvalidateScrollInfo()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RegisterAnchorCandidate(UIElement element)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "void ScrollViewer.RegisterAnchorCandidate(UIElement element)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void UnregisterAnchorCandidate(UIElement element)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ScrollViewer", "void ScrollViewer.UnregisterAnchorCandidate(UIElement element)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetCanContentRenderOutsideBounds(DependencyObject element)
	{
		return (bool)element.GetValue(CanContentRenderOutsideBoundsProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetCanContentRenderOutsideBounds(DependencyObject element, bool canContentRenderOutsideBounds)
	{
		element.SetValue(CanContentRenderOutsideBoundsProperty, canContentRenderOutsideBounds);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsHorizontalRailEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsHorizontalRailEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsHorizontalRailEnabled(DependencyObject element, bool isHorizontalRailEnabled)
	{
		element.SetValue(IsHorizontalRailEnabledProperty, isHorizontalRailEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsVerticalRailEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsVerticalRailEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsVerticalRailEnabled(DependencyObject element, bool isVerticalRailEnabled)
	{
		element.SetValue(IsVerticalRailEnabledProperty, isVerticalRailEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsHorizontalScrollChainingEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsHorizontalScrollChainingEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsHorizontalScrollChainingEnabled(DependencyObject element, bool isHorizontalScrollChainingEnabled)
	{
		element.SetValue(IsHorizontalScrollChainingEnabledProperty, isHorizontalScrollChainingEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsVerticalScrollChainingEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsVerticalScrollChainingEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsVerticalScrollChainingEnabled(DependencyObject element, bool isVerticalScrollChainingEnabled)
	{
		element.SetValue(IsVerticalScrollChainingEnabledProperty, isVerticalScrollChainingEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsZoomChainingEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsZoomChainingEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsZoomChainingEnabled(DependencyObject element, bool isZoomChainingEnabled)
	{
		element.SetValue(IsZoomChainingEnabledProperty, isZoomChainingEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsScrollInertiaEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsScrollInertiaEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsScrollInertiaEnabled(DependencyObject element, bool isScrollInertiaEnabled)
	{
		element.SetValue(IsScrollInertiaEnabledProperty, isScrollInertiaEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsZoomInertiaEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsZoomInertiaEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsZoomInertiaEnabled(DependencyObject element, bool isZoomInertiaEnabled)
	{
		element.SetValue(IsZoomInertiaEnabledProperty, isZoomInertiaEnabled);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsDeferredScrollingEnabled(DependencyObject element)
	{
		return (bool)element.GetValue(IsDeferredScrollingEnabledProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsDeferredScrollingEnabled(DependencyObject element, bool isDeferredScrollingEnabled)
	{
		element.SetValue(IsDeferredScrollingEnabledProperty, isDeferredScrollingEnabled);
	}

	internal void SetConstantVelocities(float horizontalVelocity, float verticalVelocity)
	{
		if (_constantVelocityScroller == null)
		{
			_constantVelocityScroller = new ConstantVelocityScroller(this);
		}
		_constantVelocityScroller!.HorizontalVelocity = 0f - horizontalVelocity;
		_constantVelocityScroller!.VerticalVelocity = 0f - verticalVelocity;
	}

	static ScrollViewer()
	{
		IsScrollInertiaEnabledProperty = DependencyProperty.RegisterAttached("IsScrollInertiaEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		ZoomSnapPointsProperty = DependencyProperty.Register("ZoomSnapPoints", typeof(IList<float>), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)null));
		IsDeferredScrollingEnabledProperty = DependencyProperty.RegisterAttached("IsDeferredScrollingEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		IsHorizontalRailEnabledProperty = DependencyProperty.RegisterAttached("IsHorizontalRailEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		IsHorizontalScrollChainingEnabledProperty = DependencyProperty.RegisterAttached("IsHorizontalScrollChainingEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		ZoomSnapPointsTypeProperty = DependencyProperty.Register("ZoomSnapPointsType", typeof(SnapPointsType), typeof(ScrollViewer), new FrameworkPropertyMetadata(SnapPointsType.None));
		IsVerticalRailEnabledProperty = DependencyProperty.RegisterAttached("IsVerticalRailEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		IsVerticalScrollChainingEnabledProperty = DependencyProperty.RegisterAttached("IsVerticalScrollChainingEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		IsZoomChainingEnabledProperty = DependencyProperty.RegisterAttached("IsZoomChainingEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		IsZoomInertiaEnabledProperty = DependencyProperty.RegisterAttached("IsZoomInertiaEnabled", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		LeftHeaderProperty = DependencyProperty.Register("LeftHeader", typeof(UIElement), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)null));
		TopHeaderProperty = DependencyProperty.Register("TopHeader", typeof(UIElement), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)null));
		TopLeftHeaderProperty = DependencyProperty.Register("TopLeftHeader", typeof(UIElement), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)null));
		HorizontalAnchorRatioProperty = DependencyProperty.Register("HorizontalAnchorRatio", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ReduceViewportForCoreInputViewOcclusionsProperty = DependencyProperty.Register("ReduceViewportForCoreInputViewOcclusions", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		VerticalAnchorRatioProperty = DependencyProperty.Register("VerticalAnchorRatio", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		CanContentRenderOutsideBoundsProperty = DependencyProperty.RegisterAttached("CanContentRenderOutsideBounds", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(false));
		OnHorizontalScrollabilityPropertyChanged = delegate(DependencyObject obj, DependencyPropertyChangedEventArgs _)
		{
			(obj as ScrollViewer)?.UpdateComputedHorizontalScrollability(invalidate: true);
		};
		OnVerticalScrollabilityPropertyChanged = delegate(DependencyObject obj, DependencyPropertyChangedEventArgs _)
		{
			(obj as ScrollViewer)?.UpdateComputedVerticalScrollability(invalidate: true);
		};
		HorizontalScrollBarVisibilityProperty = DependencyProperty.RegisterAttached("HorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(ScrollViewer), new FrameworkPropertyMetadata(ScrollBarVisibility.Disabled, FrameworkPropertyMetadataOptions.Inherits, OnHorizontalScrollabilityPropertyChanged));
		VerticalScrollBarVisibilityProperty = DependencyProperty.RegisterAttached("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(ScrollViewer), new FrameworkPropertyMetadata(ScrollBarVisibility.Auto, FrameworkPropertyMetadataOptions.Inherits, OnVerticalScrollabilityPropertyChanged));
		HorizontalScrollModeProperty = DependencyProperty.RegisterAttached("HorizontalScrollMode", typeof(ScrollMode), typeof(ScrollViewer), new FrameworkPropertyMetadata(ScrollMode.Enabled, FrameworkPropertyMetadataOptions.Inherits, OnHorizontalScrollabilityPropertyChanged));
		VerticalScrollModeProperty = DependencyProperty.RegisterAttached("VerticalScrollMode", typeof(ScrollMode), typeof(ScrollViewer), new FrameworkPropertyMetadata(ScrollMode.Enabled, FrameworkPropertyMetadataOptions.Inherits, OnVerticalScrollabilityPropertyChanged));
		BringIntoViewOnFocusChangeProperty = DependencyProperty.RegisterAttached("BringIntoViewOnFocusChange", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits, OnBringIntoViewOnFocusChangeChanged));
		ZoomModeProperty = DependencyProperty.RegisterAttached("ZoomMode", typeof(ZoomMode), typeof(ScrollViewer), new FrameworkPropertyMetadata(ZoomMode.Disabled, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((ScrollViewer)o).OnZoomModeChanged((ZoomMode)e.NewValue);
		}));
		MinZoomFactorProperty = DependencyProperty.Register("MinZoomFactor", typeof(float), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.1f, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((ScrollViewer)o).OnMinZoomFactorChanged(e);
		}));
		MaxZoomFactorProperty = DependencyProperty.Register("MaxZoomFactor", typeof(float), typeof(ScrollViewer), new FrameworkPropertyMetadata(10f, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((ScrollViewer)o).OnMaxZoomFactorChanged(e);
		}));
		ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(float), typeof(ScrollViewer), new FrameworkPropertyMetadata(1f));
		HorizontalSnapPointsTypeProperty = DependencyProperty.Register("HorizontalSnapPointsType", typeof(SnapPointsType), typeof(ScrollViewer), new FrameworkPropertyMetadata(SnapPointsType.None));
		HorizontalSnapPointsAlignmentProperty = DependencyProperty.Register("HorizontalSnapPointsAlignment", typeof(SnapPointsAlignment), typeof(ScrollViewer), new FrameworkPropertyMetadata(SnapPointsAlignment.Near));
		VerticalSnapPointsTypeProperty = DependencyProperty.Register("VerticalSnapPointsType", typeof(SnapPointsType), typeof(ScrollViewer), new FrameworkPropertyMetadata(SnapPointsType.None));
		VerticalSnapPointsAlignmentProperty = DependencyProperty.Register("VerticalSnapPointsAlignment", typeof(SnapPointsAlignment), typeof(ScrollViewer), new FrameworkPropertyMetadata(SnapPointsAlignment.Near));
		ExtentHeightProperty = DependencyProperty.Register("ExtentHeight", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ExtentWidthProperty = DependencyProperty.Register("ExtentWidth", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ViewportHeightProperty = DependencyProperty.Register("ViewportHeight", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ViewportWidthProperty = DependencyProperty.Register("ViewportWidth", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ComputedHorizontalScrollBarVisibilityProperty = DependencyProperty.Register("ComputedHorizontalScrollBarVisibility", typeof(Visibility), typeof(ScrollViewer), new FrameworkPropertyMetadata(Visibility.Collapsed));
		ComputedVerticalScrollBarVisibilityProperty = DependencyProperty.Register("ComputedVerticalScrollBarVisibility", typeof(Visibility), typeof(ScrollViewer), new FrameworkPropertyMetadata(Visibility.Collapsed));
		ScrollableHeightProperty = DependencyProperty.Register("ScrollableHeight", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		ScrollableWidthProperty = DependencyProperty.Register("ScrollableWidth", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata(0.0));
		VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)0.0, (PropertyChangedCallback)null));
		HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(ScrollViewer), new FrameworkPropertyMetadata((object)0.0, (PropertyChangedCallback)null));
		_indicatorResetDelay = FeatureConfiguration.ScrollViewer.DefaultAutoHideDelay ?? TimeSpan.FromSeconds(4.0);
		_indicatorResetDisabled = _indicatorResetDelay == TimeSpan.MaxValue;
		Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(ScrollViewer), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
		Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(ScrollViewer), new FrameworkPropertyMetadata(VerticalAlignment.Top));
	}

	public ScrollViewer()
	{
		base.DefaultStyleKey = typeof(ScrollViewer);
		UpdatesMode = Uno.UI.Xaml.Controls.ScrollViewer.GetUpdatesMode(this);
		base.Loaded += AttachScrollBars;
		base.Unloaded += DetachScrollBars;
		base.Unloaded += ResetScrollIndicator;
	}

	public static ScrollBarVisibility GetHorizontalScrollBarVisibility(DependencyObject obj)
	{
		return (ScrollBarVisibility)obj.GetValue(HorizontalScrollBarVisibilityProperty);
	}

	public static void SetHorizontalScrollBarVisibility(DependencyObject obj, ScrollBarVisibility value)
	{
		obj.SetValue(HorizontalScrollBarVisibilityProperty, value);
	}

	public static ScrollBarVisibility GetVerticalScrollBarVisibility(DependencyObject obj)
	{
		return (ScrollBarVisibility)obj.GetValue(VerticalScrollBarVisibilityProperty);
	}

	public static void SetVerticalScrollBarVisibility(DependencyObject obj, ScrollBarVisibility value)
	{
		obj.SetValue(VerticalScrollBarVisibilityProperty, value);
	}

	public static ScrollMode GetHorizontalScrollMode(DependencyObject obj)
	{
		return (ScrollMode)obj.GetValue(HorizontalScrollModeProperty);
	}

	public static void SetHorizontalScrollMode(DependencyObject obj, ScrollMode value)
	{
		obj.SetValue(HorizontalScrollModeProperty, value);
	}

	public static ScrollMode GetVerticalScrollMode(DependencyObject obj)
	{
		return (ScrollMode)obj.GetValue(VerticalScrollModeProperty);
	}

	public static void SetVerticalScrollMode(DependencyObject obj, ScrollMode value)
	{
		obj.SetValue(VerticalScrollModeProperty, value);
	}

	public static bool GetBringIntoViewOnFocusChange(DependencyObject element)
	{
		return (bool)element.GetValue(BringIntoViewOnFocusChangeProperty);
	}

	public static void SetBringIntoViewOnFocusChange(DependencyObject element, bool bringIntoViewOnFocusChange)
	{
		element.SetValue(BringIntoViewOnFocusChangeProperty, bringIntoViewOnFocusChange);
	}

	private static void OnBringIntoViewOnFocusChangeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		ScrollViewer scrollViewer = dependencyObject as ScrollViewer;
	}

	public static ZoomMode GetZoomMode(DependencyObject element)
	{
		return (ZoomMode)element.GetValue(ZoomModeProperty);
	}

	public static void SetZoomMode(DependencyObject element, ZoomMode zoomMode)
	{
		element.SetValue(ZoomModeProperty, zoomMode);
	}

	private void OnZoomModeChanged(ZoomMode zoomMode)
	{
	}

	private void OnMinZoomFactorChanged(DependencyPropertyChangedEventArgs args)
	{
		_presenter?.OnMinZoomFactorChanged((float)args.NewValue);
	}

	private void OnMaxZoomFactorChanged(DependencyPropertyChangedEventArgs args)
	{
		_presenter?.OnMaxZoomFactorChanged((float)args.NewValue);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		ViewportMeasureSize = availableSize;
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		ViewportArrangeSize = finalSize;
		Size result = base.ArrangeOverride(finalSize);
		TrimOverscroll(Orientation.Horizontal);
		TrimOverscroll(Orientation.Vertical);
		return result;
	}

	private void TrimOverscroll(Orientation orientation)
	{
		if (_presenter is ContentPresenter contentPresenter && contentPresenter.Content is FrameworkElement element)
		{
			double actualExtent = GetActualExtent(contentPresenter, orientation);
			double actualExtent2 = GetActualExtent(element, orientation);
			double offsetForOrientation = GetOffsetForOrientation(orientation);
			double num = offsetForOrientation + actualExtent;
			double num2 = actualExtent2 - num;
			if (offsetForOrientation > 0.0 && num2 < -0.5)
			{
				ChangeViewForOrientation(orientation, num2);
			}
		}
	}

	internal override void OnLayoutUpdated()
	{
		base.OnLayoutUpdated();
		UpdateDimensionProperties();
		UpdateZoomedContentAlignment();
	}

	private void UpdateDimensionProperties()
	{
		if (this.Log().IsEnabled(LogLevel.Debug) && (base.ActualHeight != ViewportHeight || base.ActualWidth != ViewportWidth))
		{
			this.Log().LogDebug($"ScrollViewer setting ViewportHeight={base.ActualHeight}, ViewportWidth={base.ActualWidth}");
		}
		if (base.ActualWidth == 0.0 || base.ActualHeight == 0.0)
		{
			return;
		}
		ViewportHeight = (_presenter as IFrameworkElement)?.ActualHeight ?? base.ActualHeight;
		ViewportWidth = (_presenter as IFrameworkElement)?.ActualWidth ?? base.ActualWidth;
		Size? size = _presenter?.CustomContentExtent;
		if (size.HasValue)
		{
			Size valueOrDefault = size.GetValueOrDefault();
			ExtentHeight = valueOrDefault.Height;
			ExtentWidth = valueOrDefault.Width;
		}
		else if (Content is FrameworkElement frameworkElement)
		{
			double height = frameworkElement.Height;
			if (height.IsFinite())
			{
				ExtentHeight = height;
			}
			else
			{
				bool flag = frameworkElement.ActualHeight > 0.0 && frameworkElement.VerticalAlignment == VerticalAlignment.Stretch;
				ExtentHeight = (flag ? frameworkElement.ActualHeight : frameworkElement.DesiredSize.Height);
			}
			double width = frameworkElement.Width;
			if (width.IsFinite())
			{
				ExtentWidth = width;
			}
			else
			{
				bool flag2 = frameworkElement.ActualWidth > 0.0 && frameworkElement.HorizontalAlignment == HorizontalAlignment.Stretch;
				ExtentWidth = (flag2 ? frameworkElement.ActualWidth : frameworkElement.DesiredSize.Width);
			}
		}
		else
		{
			ExtentHeight = 0.0;
			ExtentWidth = 0.0;
		}
		ScrollableHeight = Math.Max(ExtentHeight - ViewportHeight, 0.0);
		if (ScrollableHeight < 0.1)
		{
			ScrollableHeight = 0.0;
		}
		ScrollableWidth = Math.Max(ExtentWidth - ViewportWidth, 0.0);
		if (ScrollableWidth < 0.1)
		{
			ScrollableWidth = 0.0;
		}
		UpdateComputedVerticalScrollability(invalidate: false);
		UpdateComputedHorizontalScrollability(invalidate: false);
	}

	private void UpdateComputedVerticalScrollability(bool invalidate)
	{
		double scrollableHeight = ScrollableHeight;
		ScrollBarVisibility verticalScrollBarVisibility = VerticalScrollBarVisibility;
		ScrollMode verticalScrollMode = VerticalScrollMode;
		bool canVerticallyScroll = ComputeIsScrollAllowed(verticalScrollBarVisibility, verticalScrollMode);
		Visibility visibility = ComputeScrollBarVisibility(scrollableHeight, verticalScrollBarVisibility);
		bool computedIsVerticalScrollEnabled = ComputeIsScrollEnabled(scrollableHeight, verticalScrollBarVisibility, verticalScrollMode);
		if (_presenter == null)
		{
			ComputedVerticalScrollBarVisibility = visibility;
			ComputedIsVerticalScrollEnabled = computedIsVerticalScrollEnabled;
			return;
		}
		_presenter!.CanVerticallyScroll = canVerticallyScroll;
		MaterializeVerticalScrollBarIfNeeded(visibility);
		ComputedVerticalScrollBarVisibility = visibility;
		ComputedIsVerticalScrollEnabled = computedIsVerticalScrollEnabled;
		_presenter!.NativeVerticalScrollBarVisibility = ComputeNativeScrollBarVisibility(scrollableHeight, verticalScrollBarVisibility, verticalScrollMode, _verticalScrollbar);
		if (invalidate && _verticalScrollbar == null)
		{
			InvalidateMeasure();
		}
	}

	private void UpdateComputedHorizontalScrollability(bool invalidate)
	{
		double scrollableWidth = ScrollableWidth;
		ScrollBarVisibility horizontalScrollBarVisibility = HorizontalScrollBarVisibility;
		ScrollMode horizontalScrollMode = HorizontalScrollMode;
		bool canHorizontallyScroll = ComputeIsScrollAllowed(horizontalScrollBarVisibility, horizontalScrollMode);
		Visibility visibility = ComputeScrollBarVisibility(scrollableWidth, horizontalScrollBarVisibility);
		bool computedIsHorizontalScrollEnabled = ComputeIsScrollEnabled(scrollableWidth, horizontalScrollBarVisibility, horizontalScrollMode);
		if (_presenter == null)
		{
			ComputedHorizontalScrollBarVisibility = visibility;
			ComputedIsHorizontalScrollEnabled = computedIsHorizontalScrollEnabled;
			return;
		}
		_presenter!.CanHorizontallyScroll = canHorizontallyScroll;
		MaterializeHorizontalScrollBarIfNeeded(visibility);
		ComputedHorizontalScrollBarVisibility = visibility;
		ComputedIsHorizontalScrollEnabled = computedIsHorizontalScrollEnabled;
		_presenter!.NativeHorizontalScrollBarVisibility = ComputeNativeScrollBarVisibility(scrollableWidth, horizontalScrollBarVisibility, horizontalScrollMode, _horizontalScrollbar);
		if (invalidate && _horizontalScrollbar == null)
		{
			InvalidateMeasure();
		}
	}

	private static bool ComputeIsScrollAllowed(ScrollBarVisibility visibility, ScrollMode mode)
	{
		if (visibility != ScrollBarVisibility.Disabled)
		{
			return mode != ScrollMode.Disabled;
		}
		return false;
	}

	private static Visibility ComputeScrollBarVisibility(double scrollable, ScrollBarVisibility visibility)
	{
		if (visibility != 0)
		{
			if (visibility == ScrollBarVisibility.Visible)
			{
				goto IL_0017;
			}
		}
		else if (scrollable > 0.0)
		{
			goto IL_0017;
		}
		return Visibility.Collapsed;
		IL_0017:
		return Visibility.Visible;
	}

	private static bool ComputeIsScrollEnabled(double scrollable, ScrollBarVisibility visibility, ScrollMode mode)
	{
		if (scrollable > 0.0 && visibility != ScrollBarVisibility.Disabled)
		{
			return mode != ScrollMode.Disabled;
		}
		return false;
	}

	private ScrollBarVisibility ComputeNativeScrollBarVisibility(double scrollable, ScrollBarVisibility visibility, ScrollMode mode, ScrollBar? managedScrollbar)
	{
		if (mode != 0)
		{
			if (scrollable == 0.0)
			{
				if (visibility == ScrollBarVisibility.Auto)
				{
					if (managedScrollbar != null)
					{
						goto IL_004a;
					}
					return ScrollBarVisibility.Hidden;
				}
				if (managedScrollbar != null)
				{
					goto IL_002c;
				}
			}
			else if (managedScrollbar != null)
			{
				goto IL_002c;
			}
			if (Uno.UI.Xaml.Controls.ScrollViewer.GetShouldFallBackToNativeScrollBars(this))
			{
				return visibility;
			}
			goto IL_002c;
		}
		return ScrollBarVisibility.Disabled;
		IL_004a:
		return ScrollBarVisibility.Hidden;
		IL_002c:
		if (visibility != ScrollBarVisibility.Disabled)
		{
			goto IL_004a;
		}
		return ScrollBarVisibility.Disabled;
	}

	public void Add(UIElement view)
	{
		Content = view;
	}

	protected override void OnApplyTemplate()
	{
		DetachScrollBars();
		base.OnApplyTemplate();
		DependencyObject dependencyObject = GetTemplateChild("PART_Scroller") ?? GetTemplateChild("ScrollContentPresenter");
		_presenter = dependencyObject as IScrollContentPresenter;
		_isTemplateApplied = _presenter != null;
		if (_presenter != null && ForceChangeToCurrentView)
		{
			_presenter!.ForceChangeToCurrentView = ForceChangeToCurrentView;
		}
		_verticalScrollbar = null;
		_isVerticalScrollBarMaterialized = false;
		_horizontalScrollbar = null;
		_isHorizontalScrollBarMaterialized = false;
		if (dependencyObject is ScrollContentPresenter scrollContentPresenter)
		{
			scrollContentPresenter.ScrollOwner = this;
			Presenter = scrollContentPresenter;
		}
		else
		{
			Presenter = null;
		}
		UpdateComputedVerticalScrollability(invalidate: false);
		UpdateComputedHorizontalScrollability(invalidate: false);
		ApplyScrollContentPresenterContent(Content);
		OnZoomModeChanged(ZoomMode);
		PrepareScrollIndicator();
	}

	void IFrameworkTemplatePoolAware.OnTemplateRecycled()
	{
		if (VerticalOffset != 0.0 || HorizontalOffset != 0.0 || ZoomFactor != 1f)
		{
			ChangeView(0.0, 0.0, 1f, disableAnimation: true);
		}
	}

	protected override void OnContentChanged(object oldValue, object newValue)
	{
		base.OnContentChanged(oldValue, newValue);
		if (_presenter != null)
		{
			ClearContentTemplatedParent(oldValue);
			ApplyScrollContentPresenterContent(newValue);
		}
		UpdateSizeChangedSubscription();
		_snapPointsInfo = newValue as IScrollSnapPointsInfo;
	}

	private void ApplyScrollContentPresenterContent(object content)
	{
		if (content is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			object value = dependencyObjectStoreProvider.Store.GetValue(dependencyObjectStoreProvider.Store.TemplatedParentProperty);
			if (value == null || value != base.TemplatedParent)
			{
				dependencyObjectStoreProvider.Store.SetValue(dependencyObjectStoreProvider.Store.TemplatedParentProperty, null, DependencyPropertyValuePrecedences.Local);
			}
		}
		if (_presenter != null)
		{
			_presenter!.Content = content as UIElement;
		}
		SynchronizeContentTemplatedParent(base.TemplatedParent);
	}

	private void UpdateSizeChangedSubscription(bool isCleanupRequired = false)
	{
		if (!isCleanupRequired)
		{
			object content = Content;
			IFrameworkElement element = content as IFrameworkElement;
			if (element != null)
			{
				_sizeChangedSubscription.Disposable = Disposable.Create(delegate
				{
					element.SizeChanged -= OnElementSizeChanged;
				});
				element.SizeChanged += OnElementSizeChanged;
				return;
			}
		}
		_sizeChangedSubscription.Disposable = null;
		void OnElementSizeChanged(object sender, SizeChangedEventArgs args)
		{
			UpdateDimensionProperties();
		}
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		SynchronizeContentTemplatedParent(e.NewValue as DependencyObject);
	}

	private void SynchronizeContentTemplatedParent(DependencyObject? templatedParent)
	{
		if (Content is UIElement && Content is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			dependencyObjectStoreProvider.Store.SetValue(dependencyObjectStoreProvider.Store.TemplatedParentProperty, templatedParent, DependencyPropertyValuePrecedences.Local);
		}
	}

	private void ClearContentTemplatedParent(object oldContent)
	{
		if (oldContent is IDependencyObjectStoreProvider dependencyObjectStoreProvider)
		{
			dependencyObjectStoreProvider.Store.ClearValue(dependencyObjectStoreProvider.Store.TemplatedParentProperty, DependencyPropertyValuePrecedences.Local);
		}
	}

	private void MaterializeVerticalScrollBarIfNeeded(Visibility computedVisibility)
	{
		if (_isTemplateApplied && !_isVerticalScrollBarMaterialized && computedVisibility == Visibility.Visible)
		{
			using (ScrollBar.MaterializingFixed(Orientation.Vertical))
			{
				_verticalScrollbar = (GetTemplateChild("PART_VerticalScrollBar") ?? GetTemplateChild("VerticalScrollBar")) as ScrollBar;
				_isVerticalScrollBarMaterialized = true;
			}
			if (_verticalScrollbar != null)
			{
				_verticalScrollbar!.IsFixedOrientation = true;
				DetachScrollBars();
				AttachScrollBars();
			}
		}
	}

	private void MaterializeHorizontalScrollBarIfNeeded(Visibility computedVisibility)
	{
		if (_isTemplateApplied && !_isHorizontalScrollBarMaterialized && computedVisibility == Visibility.Visible)
		{
			using (ScrollBar.MaterializingFixed(Orientation.Horizontal))
			{
				_horizontalScrollbar = (GetTemplateChild("PART_HorizontalScrollBar") ?? GetTemplateChild("HorizontalScrollBar")) as ScrollBar;
				_isHorizontalScrollBarMaterialized = true;
			}
			if (_horizontalScrollbar != null)
			{
				_horizontalScrollbar!.IsFixedOrientation = true;
				DetachScrollBars();
				AttachScrollBars();
			}
		}
	}

	private static void DetachScrollBars(object sender, RoutedEventArgs e)
	{
		(sender as ScrollViewer)?.DetachScrollBars();
	}

	private void DetachScrollBars()
	{
		if (_verticalScrollbar != null)
		{
			_verticalScrollbar!.Scroll -= OnVerticalScrollBarScrolled;
			_verticalScrollbar!.PointerEntered -= ShowScrollBarSeparator;
			_verticalScrollbar!.PointerExited -= HideScrollBarSeparator;
		}
		if (_horizontalScrollbar != null)
		{
			_horizontalScrollbar!.Scroll -= OnHorizontalScrollBarScrolled;
			_horizontalScrollbar!.PointerEntered -= ShowScrollBarSeparator;
			_horizontalScrollbar!.PointerExited -= HideScrollBarSeparator;
		}
		base.PointerMoved -= ShowScrollIndicator;
	}

	private static void AttachScrollBars(object sender, RoutedEventArgs e)
	{
		if (sender is ScrollViewer scrollViewer)
		{
			scrollViewer.DetachScrollBars();
			scrollViewer.AttachScrollBars();
		}
	}

	private void AttachScrollBars()
	{
		ScrollBar verticalScrollbar = _verticalScrollbar;
		bool flag;
		if (verticalScrollbar != null)
		{
			verticalScrollbar.Scroll += OnVerticalScrollBarScrolled;
			flag = true;
			base.PointerMoved += ShowScrollIndicator;
		}
		else
		{
			flag = false;
		}
		ScrollBar horizontalScrollbar = _horizontalScrollbar;
		bool flag2;
		if (horizontalScrollbar != null)
		{
			horizontalScrollbar.Scroll += OnHorizontalScrollBarScrolled;
			flag2 = true;
			if (!flag)
			{
				base.PointerMoved += ShowScrollIndicator;
			}
		}
		else
		{
			flag2 = false;
		}
		if (flag && flag2)
		{
			_verticalScrollbar!.PointerEntered += ShowScrollBarSeparator;
			_horizontalScrollbar!.PointerEntered += ShowScrollBarSeparator;
			_verticalScrollbar!.PointerExited += HideScrollBarSeparator;
			_horizontalScrollbar!.PointerExited += HideScrollBarSeparator;
		}
	}

	private void OnVerticalScrollBarScrolled(object sender, ScrollEventArgs e)
	{
		bool disableAnimation = e.ScrollEventType switch
		{
			ScrollEventType.LargeIncrement => false, 
			ScrollEventType.LargeDecrement => false, 
			ScrollEventType.SmallIncrement => false, 
			ScrollEventType.SmallDecrement => false, 
			_ => true, 
		};
		ChangeViewCore(null, e.NewValue, null, disableAnimation, shouldSnap: true);
	}

	private void OnHorizontalScrollBarScrolled(object sender, ScrollEventArgs e)
	{
		bool disableAnimation = e.ScrollEventType switch
		{
			ScrollEventType.LargeIncrement => false, 
			ScrollEventType.LargeDecrement => false, 
			ScrollEventType.SmallIncrement => false, 
			ScrollEventType.SmallDecrement => false, 
			_ => true, 
		};
		ChangeViewCore(e.NewValue, null, null, disableAnimation, shouldSnap: true);
	}

	internal void OnPresenterScrolled(double horizontalOffset, double verticalOffset, bool isIntermediate)
	{
		double? num = ((horizontalOffset == HorizontalOffset) ? null : new double?(horizontalOffset));
		double? num2 = ((verticalOffset == VerticalOffset) ? null : new double?(verticalOffset));
		_pendingHorizontalOffset = horizontalOffset;
		_pendingVerticalOffset = verticalOffset;
		if (isIntermediate && UpdatesMode != 0)
		{
			RequestUpdate();
			return;
		}
		Update(isIntermediate);
		if (isIntermediate || (HorizontalSnapPointsType == SnapPointsType.None && VerticalSnapPointsType == SnapPointsType.None))
		{
			return;
		}
		if (_snapPointsTimer == null)
		{
			_snapPointsTimer = DispatcherQueue.GetForCurrentThread().CreateTimer();
			_snapPointsTimer!.IsRepeating = false;
			_snapPointsTimer!.Interval = TimeSpan.FromMilliseconds(250.0);
			_snapPointsTimer!.Tick += delegate
			{
				DelayedMoveToSnapPoint();
			};
		}
		_horizontalOffsetForSnapPoints = num ?? horizontalOffset;
		_verticalOffsetForSnapPoints = num2 ?? verticalOffset;
		_snapPointsTimer!.Start();
	}

	internal void OnPresenterZoomed(float zoomFactor)
	{
		ZoomFactor = zoomFactor;
		Update(isIntermediate: false);
		UpdateZoomedContentAlignment();
	}

	private void RequestUpdate()
	{
		if (_hasPendingUpdate)
		{
			return;
		}
		base.Dispatcher.RunIdleAsync(delegate
		{
			if (_hasPendingUpdate)
			{
				Update(isIntermediate: true);
			}
		});
		_hasPendingUpdate = true;
	}

	private void Update(bool isIntermediate)
	{
		_hasPendingUpdate = false;
		HorizontalOffset = _pendingHorizontalOffset;
		VerticalOffset = _pendingVerticalOffset;
		UpdatePartial(isIntermediate);
		this.ViewChanged?.Invoke(this, new ScrollViewerViewChangedEventArgs
		{
			IsIntermediate = isIntermediate
		});
	}

	private void UpdatePartial(bool isIntermediate)
	{
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMXamlProperty("HorizontalOffset", HorizontalOffset);
			UpdateDOMXamlProperty("VerticalOffset", VerticalOffset);
		}
	}

	private void DelayedMoveToSnapPoint()
	{
		double? horizontalOffset = _horizontalOffsetForSnapPoints;
		double? verticalOffset = _verticalOffsetForSnapPoints;
		AdjustOffsetsForSnapPoints(ref horizontalOffset, ref verticalOffset, ZoomFactor);
		if ((horizontalOffset.HasValue && horizontalOffset != HorizontalOffset) || (verticalOffset.HasValue && verticalOffset != VerticalOffset))
		{
			ChangeViewCore(horizontalOffset, verticalOffset, null, disableAnimation: false, shouldSnap: false);
			_horizontalOffsetForSnapPoints = null;
			_verticalOffsetForSnapPoints = null;
		}
	}

	public void ScrollToHorizontalOffset(double offset)
	{
		ChangeView(offset, null, null, disableAnimation: false);
	}

	public void ScrollToVerticalOffset(double offset)
	{
		ChangeView(null, offset, null, disableAnimation: false);
	}

	public bool ChangeView(double? horizontalOffset, double? verticalOffset, float? zoomFactor)
	{
		return ChangeView(horizontalOffset, verticalOffset, zoomFactor, disableAnimation: false);
	}

	public bool ChangeView(double? horizontalOffset, double? verticalOffset, float? zoomFactor, bool disableAnimation)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"ChangeView(horizontalOffset={horizontalOffset}, verticalOffset={verticalOffset}, zoomFactor={zoomFactor}, disableAnimation={disableAnimation})");
		}
		if (!horizontalOffset.HasValue && !verticalOffset.HasValue && !zoomFactor.HasValue)
		{
			return true;
		}
		bool flag = verticalOffset.HasValue && verticalOffset != VerticalOffset;
		bool flag2 = horizontalOffset.HasValue && horizontalOffset != HorizontalOffset;
		bool flag3 = zoomFactor.HasValue && zoomFactor != ZoomFactor;
		if (flag || flag2 || flag3)
		{
			return ChangeViewCore(horizontalOffset, verticalOffset, zoomFactor, disableAnimation, shouldSnap: true);
		}
		return false;
	}

	private bool ChangeViewCore(double? horizontalOffset, double? verticalOffset, float? zoomFactor, bool disableAnimation, bool shouldSnap)
	{
		if (!horizontalOffset.HasValue && !verticalOffset.HasValue && !zoomFactor.HasValue)
		{
			return false;
		}
		if (shouldSnap)
		{
			AdjustOffsetsForSnapPoints(ref horizontalOffset, ref verticalOffset, zoomFactor);
		}
		return ChangeViewNative(horizontalOffset, verticalOffset, zoomFactor, disableAnimation);
	}

	private void PrepareScrollIndicator()
	{
		if (_indicatorResetDisabled)
		{
			ShowScrollIndicator(PointerDeviceType.Mouse, forced: true);
		}
		else
		{
			ResetScrollIndicator(forced: true);
		}
	}

	private static void ShowScrollIndicator(object sender, PointerRoutedEventArgs e)
	{
		(sender as ScrollViewer)?.ShowScrollIndicator(e.Pointer.PointerDeviceType);
	}

	private void ShowScrollIndicator(PointerDeviceType type, bool forced = false)
	{
		if (!forced && !ComputedIsVerticalScrollEnabled && !ComputedIsHorizontalScrollEnabled)
		{
			return;
		}
		string text = ((type != 0) ? "MouseIndicator" : "TouchIndicator");
		string text2 = text;
		if (_indicatorState != text2)
		{
			VisualStateManager.GoToState(this, text2, useTransitions: true);
			_indicatorState = text2;
		}
		if (_indicatorResetDisabled)
		{
			return;
		}
		if (_indicatorResetTimer == null)
		{
			ManagedWeakReference weakRef = WeakReferencePool.RentSelfWeakReference(this);
			_indicatorResetTimer = new DispatcherQueueTimer
			{
				Interval = _indicatorResetDelay,
				IsRepeating = false
			};
			_indicatorResetTimer!.Tick += delegate
			{
				(weakRef.Target as ScrollViewer)?.ResetScrollIndicator();
			};
		}
		_indicatorResetTimer!.Start();
	}

	private static void ResetScrollIndicator(object sender, RoutedEventArgs _)
	{
		(sender as ScrollViewer)?.ResetScrollIndicator(forced: true);
	}

	private void ResetScrollIndicator(bool forced = false)
	{
		if (_indicatorResetDisabled)
		{
			return;
		}
		_indicatorResetTimer?.Stop();
		if (!forced)
		{
			ScrollBar? horizontalScrollbar = _horizontalScrollbar;
			if (horizontalScrollbar != null && horizontalScrollbar!.IsPointerOver)
			{
				return;
			}
			ScrollBar? verticalScrollbar = _verticalScrollbar;
			if (verticalScrollbar != null && verticalScrollbar!.IsPointerOver)
			{
				return;
			}
		}
		VisualStateManager.GoToState(this, "NoIndicator", useTransitions: true);
		_indicatorState = "NoIndicator";
		VisualStateManager.GoToState(this, "ScrollBarSeparatorCollapsed", useTransitions: true);
	}

	private void ShowScrollBarSeparator(object sender, PointerRoutedEventArgs e)
	{
		if (e.Pointer.PointerDeviceType != 0 && (IsAnimationEnabled || !VisualStateManager.GoToState(this, "ScrollBarSeparatorExpandedWithoutAnimation", useTransitions: true)))
		{
			VisualStateManager.GoToState(this, "ScrollBarSeparatorExpanded", useTransitions: true);
		}
	}

	private void HideScrollBarSeparator(object sender, PointerRoutedEventArgs e)
	{
		if (IsAnimationEnabled || !VisualStateManager.GoToState(this, "ScrollBarSeparatorCollapsedWithoutAnimation", useTransitions: true))
		{
			VisualStateManager.GoToState(this, "ScrollBarSeparatorCollapsed", useTransitions: true);
		}
	}

	internal void DisableOverpan()
	{
	}

	internal void EnableOverpan()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool ChangeViewWithOptionalAnimation(double? horizontalOffset, double verticalOffset, float? zoomFactor, bool disableAnimation)
	{
		return ChangeView(horizontalOffset, verticalOffset, zoomFactor, disableAnimation);
	}

	internal bool BringIntoViewport(Rect bounds, bool skipDuringTouchContact, bool skipAnimationWhileRunning, bool animate)
	{
		return ChangeView(bounds.X, bounds.Y, null, disableAnimation: true);
	}

	internal void SetDirectManipulationStateChangeHandler(IDirectManipulationStateChangeHandler? handler)
	{
		_directManipulationHandlerSubscription?.Dispose();
		ManagedWeakReference weakHandler;
		if (handler != null)
		{
			weakHandler = WeakReferencePool.RentWeakReference(this, handler);
			UpdatesMode = ScrollViewerUpdatesMode.Synchronous;
			ViewChanged += new EventHandler<ScrollViewerViewChangedEventArgs>(OnViewChanged);
			_directManipulationHandlerSubscription = Disposable.Create(delegate
			{
				ViewChanged -= new EventHandler<ScrollViewerViewChangedEventArgs>(OnViewChanged);
				WeakReferencePool.ReturnWeakReference(this, weakHandler);
			});
		}
		void OnViewChanged(object? sender, ScrollViewerViewChangedEventArgs args)
		{
			if (!args.IsIntermediate && weakHandler.Target is IDirectManipulationStateChangeHandler directManipulationStateChangeHandler)
			{
				directManipulationStateChangeHandler.NotifyStateChange(DMManipulationState.DMManipulationCompleted, 0f, 0f, 0f, 0f, 0f, isInertial: false, isTouchConfigurationActivated: false, isBringIntoViewportConfigurationActivated: false);
			}
		}
	}

	private void AdjustOffsetsForSnapPoints(ref double? horizontalOffset, ref double? verticalOffset, float? zoomFactor)
	{
		double? num = horizontalOffset;
		if (num.HasValue)
		{
			double targetOffset = num.GetValueOrDefault();
			double maxOffset = Math.Max(0.0, ExtentWidth - ViewportWidth);
			AdjustOffsetWithMandatorySnapPoints(isForHorizontalOffset: true, 0.0, maxOffset, targetOffset, ExtentWidth, ViewportWidth, zoomFactor ?? ZoomFactor, ref targetOffset);
			horizontalOffset = targetOffset;
		}
		num = verticalOffset;
		if (num.HasValue)
		{
			double targetOffset2 = num.GetValueOrDefault();
			double maxOffset2 = Math.Max(0.0, ExtentHeight - ViewportHeight);
			AdjustOffsetWithMandatorySnapPoints(isForHorizontalOffset: false, 0.0, maxOffset2, targetOffset2, ExtentHeight, ViewportHeight, zoomFactor ?? ZoomFactor, ref targetOffset2);
			verticalOffset = targetOffset2;
		}
	}

	private void AdjustOffsetWithMandatorySnapPoints(bool isForHorizontalOffset, double minOffset, double maxOffset, double currentOffset, double targetExtentDimension, double viewportDimension, float targetZoomFactor, ref double targetOffset)
	{
		if (_snapPointsInfo == null)
		{
			return;
		}
		SnapPointsType snapPointsType = (isForHorizontalOffset ? HorizontalSnapPointsType : VerticalSnapPointsType);
		if (snapPointsType != SnapPointsType.Mandatory && snapPointsType != SnapPointsType.MandatorySingle)
		{
			return;
		}
		GetScrollSnapPoints(isForHorizontalOffset, snapPointsType, targetZoomFactor, targetZoomFactor, targetExtentDimension, viewportDimension, out var _, out var _, out var areSnapPointsRegular, out var regularOffset, out var regularInterval, out var resultSnapPoints);
		bool flag = snapPointsType == SnapPointsType.MandatorySingle && targetOffset != currentOffset;
		double num = ((targetOffset > currentOffset) ? 1.0 : (-1.0));
		double num2 = 0.0;
		double num3 = double.MaxValue;
		if (areSnapPointsRegular && regularInterval > 0f)
		{
			if (flag)
			{
				targetOffset = currentOffset + num * (double)regularInterval;
			}
			num2 = ((!(targetOffset <= (double)regularOffset)) ? (Math.Round((targetOffset - (double)regularOffset) / (double)regularInterval, 0) * (double)regularInterval + (double)regularOffset) : ((double)regularOffset));
			if (num2 > maxOffset)
			{
				num2 -= (double)regularInterval;
			}
			if (num2 >= minOffset && num2 <= maxOffset)
			{
				targetOffset = num2;
			}
		}
		else
		{
			if (resultSnapPoints == null || resultSnapPoints.Count <= 0)
			{
				return;
			}
			if (flag)
			{
				for (int i = 0; i < resultSnapPoints.Count; i++)
				{
					float num4 = resultSnapPoints[i];
					if ((double)num4 >= minOffset && (double)num4 <= maxOffset && num * ((double)num4 - currentOffset) > 0.0 && num * ((double)num4 - currentOffset) < num3)
					{
						num3 = num * ((double)num4 - currentOffset);
						num2 = num4;
					}
				}
				if (num3 == double.MaxValue)
				{
					for (int j = 0; j < resultSnapPoints.Count; j++)
					{
						if (num3 == 0.0)
						{
							break;
						}
						float num5 = resultSnapPoints[j];
						if ((double)num5 >= minOffset && (double)num5 <= maxOffset && num * (currentOffset - (double)num5) >= 0.0 && num * (currentOffset - (double)num5) < num3)
						{
							num3 = num * (currentOffset - (double)num5);
							num2 = num5;
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < resultSnapPoints.Count; k++)
				{
					if ((double)resultSnapPoints[k] >= minOffset && (double)resultSnapPoints[k] <= maxOffset && Math.Abs(targetOffset - (double)resultSnapPoints[k]) < num3)
					{
						num3 = Math.Abs(targetOffset - (double)resultSnapPoints[k]);
						num2 = resultSnapPoints[k];
					}
				}
			}
			targetOffset = num2;
		}
	}

	private void GetScrollSnapPoints(bool isForHorizontalSnapPoints, SnapPointsType snapPointsType, float zoomFactor, float staticZoomFactor, double targetExtentDimension, double viewportDimension, out bool areSnapPointsOptional, out bool areSnapPointsSingle, out bool areSnapPointsRegular, out float regularOffset, out float regularInterval, out IReadOnlyList<float> resultSnapPoints)
	{
		bool flag = false;
		SnapPointsAlignment snapPointsAlignment = SnapPointsAlignment.Near;
		float offset = 0f;
		float num = 0f;
		IReadOnlyList<float> snapPoints = null;
		areSnapPointsOptional = false;
		areSnapPointsSingle = false;
		regularOffset = 0f;
		regularInterval = 0f;
		resultSnapPoints = null;
		if (isForHorizontalSnapPoints)
		{
			if (snapPointsType != 0)
			{
				snapPointsAlignment = HorizontalSnapPointsAlignment;
				areSnapPointsRegular = _snapPointsInfo.AreHorizontalSnapPointsRegular;
				if (areSnapPointsRegular)
				{
					num = _snapPointsInfo.GetRegularSnapPoints(Orientation.Horizontal, snapPointsAlignment, out offset);
					snapPoints = null;
				}
				else
				{
					_ = 0.0;
					snapPoints = _snapPointsInfo.GetIrregularSnapPoints(Orientation.Horizontal, snapPointsAlignment);
					regularInterval = 0f;
					regularOffset = 0f;
				}
				flag = true;
			}
			else
			{
				areSnapPointsRegular = false;
			}
		}
		else if (snapPointsType != 0)
		{
			snapPointsAlignment = VerticalSnapPointsAlignment;
			areSnapPointsRegular = _snapPointsInfo.AreVerticalSnapPointsRegular;
			if (areSnapPointsRegular)
			{
				num = _snapPointsInfo.GetRegularSnapPoints(Orientation.Vertical, snapPointsAlignment, out offset);
				snapPoints = null;
			}
			else
			{
				_ = 0.0;
				snapPoints = _snapPointsInfo.GetIrregularSnapPoints(Orientation.Vertical, snapPointsAlignment);
				regularInterval = 0f;
				regularOffset = 0f;
			}
			flag = true;
		}
		else
		{
			areSnapPointsRegular = false;
		}
		if (!flag)
		{
			return;
		}
		if (areSnapPointsRegular)
		{
			switch (snapPointsAlignment)
			{
			case SnapPointsAlignment.Near:
				regularOffset = offset * staticZoomFactor;
				break;
			case SnapPointsAlignment.Center:
				if (num <= 0f)
				{
					num = 0f;
					break;
				}
				if (viewportDimension >= (double)(num * zoomFactor))
				{
					offset *= zoomFactor;
					offset -= (float)(viewportDimension / 2.0);
					if (staticZoomFactor == 1f)
					{
						offset /= zoomFactor;
					}
					for (; offset < 0f; offset += num * staticZoomFactor)
					{
					}
				}
				else
				{
					offset -= (float)(viewportDimension / (double)(2f * zoomFactor));
					offset *= staticZoomFactor;
				}
				regularOffset = offset;
				break;
			case SnapPointsAlignment.Far:
				regularOffset = offset * staticZoomFactor;
				break;
			}
			regularInterval = num * staticZoomFactor;
			areSnapPointsRegular = true;
		}
		else
		{
			areSnapPointsRegular = false;
			resultSnapPoints = CopyMotionSnapPoints(isForZoomSnapPoints: false, snapPoints, snapPointsAlignment, viewportDimension, targetExtentDimension, zoomFactor, staticZoomFactor);
		}
		areSnapPointsOptional = snapPointsType == SnapPointsType.Optional || snapPointsType == SnapPointsType.OptionalSingle;
	}

	private IReadOnlyList<float> CopyMotionSnapPoints(bool isForZoomSnapPoints, IReadOnlyList<float> snapPoints, SnapPointsAlignment alignment, double viewportDimension, double extentDimension, float zoomFactor, float staticZoomFactor)
	{
		List<float> list = new List<float>(snapPoints.Count);
		if (snapPoints.Count > 0)
		{
			foreach (float snapPoint in snapPoints)
			{
				float num = snapPoint;
				if (isForZoomSnapPoints)
				{
					list.Add(num * staticZoomFactor);
				}
				else
				{
					num *= zoomFactor;
					float num2 = alignment switch
					{
						SnapPointsAlignment.Near => num, 
						SnapPointsAlignment.Center => (float)((double)num - viewportDimension / 2.0), 
						SnapPointsAlignment.Far => (float)((double)num - viewportDimension), 
						_ => throw new IndexOutOfRangeException("alignment"), 
					};
					float num3 = (float)(extentDimension - viewportDimension - (double)num2);
					if (num3 < 0f && (double)num3 >= -1.0 * (double)(0.0001f * Math.Max(1f, zoomFactor)))
					{
						num2 = (float)(extentDimension - viewportDimension);
						num3 = 0f;
					}
					if (num2 >= 0f && num3 >= 0f)
					{
						if (staticZoomFactor == 1f)
						{
							num2 /= zoomFactor;
						}
						list.Add(num2);
					}
				}
			}
			return list;
		}
		return list;
	}

	private void UpdateZoomedContentAlignment()
	{
	}

	private bool ChangeViewNative(double? horizontalOffset, double? verticalOffset, float? zoomFactor, bool disableAnimation)
	{
		if (zoomFactor.HasValue)
		{
			_log.Warn("ZoomFactor not supported yet on WASM target.");
		}
		if (_presenter != null)
		{
			_presenter!.ScrollTo(horizontalOffset, verticalOffset, disableAnimation);
			return true;
		}
		if (_log.IsEnabled(LogLevel.Warning))
		{
			_log.Warn("Cannot ChangeView as ScrollContentPresenter is not ready yet.");
		}
		return false;
	}

	private double GetOffsetForOrientation(Orientation orientation)
	{
		if (orientation != Orientation.Horizontal)
		{
			return VerticalOffset;
		}
		return HorizontalOffset;
	}

	private void ChangeViewForOrientation(Orientation orientation, double scrollAdjustment)
	{
		if (orientation == Orientation.Vertical)
		{
			ChangeView(null, VerticalOffset + scrollAdjustment, null, disableAnimation: true);
		}
		else
		{
			ChangeView(HorizontalOffset + scrollAdjustment, null, null, disableAnimation: true);
		}
	}

	private static double GetActualExtent(FrameworkElement element, Orientation orientation)
	{
		if (orientation != Orientation.Horizontal)
		{
			return element.ActualHeight;
		}
		return element.ActualWidth;
	}
}
