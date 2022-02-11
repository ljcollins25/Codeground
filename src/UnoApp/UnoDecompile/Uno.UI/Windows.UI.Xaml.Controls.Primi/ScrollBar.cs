using System;
using Uno.Disposables;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public class ScrollBar : RangeBase
{
	[ThreadStatic]
	private static Orientation? _fixedOrientation;

	private bool m_isIgnoringUserInput;

	private bool m_isPointerOver;

	private bool m_suspendVisualStateUpdates = true;

	private double m_dragValue;

	private FrameworkElement m_tpElementHorizontalTemplate;

	private RepeatButton m_tpElementHorizontalLargeIncrease;

	private RepeatButton m_tpElementHorizontalLargeDecrease;

	private RepeatButton m_tpElementHorizontalSmallIncrease;

	private RepeatButton m_tpElementHorizontalSmallDecrease;

	private Thumb m_tpElementHorizontalThumb;

	private FrameworkElement m_tpElementVerticalTemplate;

	private RepeatButton m_tpElementVerticalLargeIncrease;

	private RepeatButton m_tpElementVerticalLargeDecrease;

	private RepeatButton m_tpElementVerticalSmallIncrease;

	private RepeatButton m_tpElementVerticalSmallDecrease;

	private Thumb m_tpElementVerticalThumb;

	private FrameworkElement m_tpElementHorizontalPanningRoot;

	private FrameworkElement m_tpElementHorizontalPanningThumb;

	private FrameworkElement m_tpElementVerticalPanningRoot;

	private FrameworkElement m_tpElementVerticalPanningThumb;

	private SerialDisposable m_ElementHorizontalThumbDragStartedToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalThumbDragDeltaToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalThumbDragCompletedToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalLargeDecreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalLargeIncreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalSmallDecreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementHorizontalSmallIncreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalThumbDragStartedToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalThumbDragDeltaToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalThumbDragCompletedToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalLargeDecreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalLargeIncreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalSmallDecreaseClickToken = new SerialDisposable();

	private SerialDisposable m_ElementVerticalSmallIncreaseClickToken = new SerialDisposable();

	private bool m_blockIndicators;

	private bool m_isUsingActualSizeAsExtent;

	private static bool IsAnimationEnabled => SharedHelpers.IsAnimationsEnabled();

	internal bool IsFixedOrientation { get; set; }

	private bool IsDragging
	{
		get
		{
			Orientation orientation = Orientation;
			if (orientation == Orientation.Horizontal && m_tpElementHorizontalThumb != null)
			{
				return m_tpElementHorizontalThumb.IsDragging;
			}
			if (orientation == Orientation.Vertical && m_tpElementVerticalThumb != null)
			{
				return m_tpElementVerticalThumb.IsDragging;
			}
			return false;
		}
	}

	private bool IsIgnoringUserInput
	{
		get
		{
			return m_isIgnoringUserInput;
		}
		set
		{
			m_isIgnoringUserInput = value;
		}
	}

	private UIElement ElementHorizontalTemplate => m_tpElementHorizontalTemplate;

	private UIElement ElementVerticalTemplate => m_tpElementVerticalTemplate;

	public double ViewportSize
	{
		get
		{
			return (double)GetValue(ViewportSizeProperty);
		}
		set
		{
			SetValue(ViewportSizeProperty, value);
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

	public ScrollingIndicatorMode IndicatorMode
	{
		get
		{
			return (ScrollingIndicatorMode)GetValue(IndicatorModeProperty);
		}
		set
		{
			SetValue(IndicatorModeProperty, value);
		}
	}

	public static DependencyProperty IndicatorModeProperty { get; } = DependencyProperty.Register("IndicatorMode", typeof(ScrollingIndicatorMode), typeof(ScrollBar), new FrameworkPropertyMetadata(ScrollingIndicatorMode.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ScrollBar).RefreshTrackLayout();
	}));


	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ScrollBar), new FrameworkPropertyMetadata(Orientation.Vertical, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ScrollBar).OnOrientationChanged();
	}));


	public static DependencyProperty ViewportSizeProperty { get; } = DependencyProperty.Register("ViewportSize", typeof(double), typeof(ScrollBar), new FrameworkPropertyMetadata(0.0));


	public event ScrollEventHandler Scroll;

	internal static IDisposable MaterializingFixed(Orientation orientation)
	{
		_fixedOrientation = orientation;
		return Disposable.Create(delegate
		{
			_fixedOrientation = null;
		});
	}

	private static bool IsConscious()
	{
		return SharedHelpers.ShouldUseDynamicScrollbars();
	}

	public ScrollBar()
	{
		m_isIgnoringUserInput = false;
		m_isPointerOver = false;
		m_suspendVisualStateUpdates = false;
		m_dragValue = 0.0;
		m_blockIndicators = false;
		m_isUsingActualSizeAsExtent = false;
		Orientation? fixedOrientation = _fixedOrientation;
		if (fixedOrientation.HasValue)
		{
			Orientation valueOrDefault = fixedOrientation.GetValueOrDefault();
			IsFixedOrientation = true;
			Orientation = valueOrDefault;
		}
		Initialize();
	}

	private void Initialize()
	{
		base.DefaultStyleKey = typeof(ScrollBar);
		base.SizeChanged += OnSizeChanged;
		base.LayoutUpdated += OnLayoutUpdated;
		base.Loaded += ReAttachEvents;
		base.Unloaded += DetachEvents;
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		if (base.Visibility == Visibility.Visible)
		{
			UpdateVisualState();
		}
		else
		{
			m_isPointerOver = false;
		}
	}

	protected override void OnApplyTemplate()
	{
		m_suspendVisualStateUpdates = true;
		DetachEvents();
		base.OnApplyTemplate();
		if (!IsFixedOrientation || Orientation == Orientation.Horizontal)
		{
			FrameworkElement frameworkElement = (m_tpElementHorizontalTemplate = GetTemplateChildHelper<FrameworkElement>("HorizontalRoot"));
			RepeatButton repeatButton = (m_tpElementHorizontalLargeIncrease = GetTemplateChildHelper<RepeatButton>("HorizontalLargeIncrease"));
			if (m_tpElementHorizontalLargeIncrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementHorizontalLargeIncrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementHorizontalLargeIncrease, name);
				}
			}
			RepeatButton repeatButton2 = (m_tpElementHorizontalSmallIncrease = GetTemplateChildHelper<RepeatButton>("HorizontalSmallIncrease"));
			if (m_tpElementHorizontalSmallIncrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementHorizontalSmallIncrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementHorizontalSmallIncrease, name);
				}
			}
			RepeatButton repeatButton3 = (m_tpElementHorizontalLargeDecrease = GetTemplateChildHelper<RepeatButton>("HorizontalLargeDecrease"));
			if (m_tpElementHorizontalLargeDecrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementHorizontalLargeDecrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementHorizontalLargeDecrease, name);
				}
			}
			RepeatButton repeatButton4 = (m_tpElementHorizontalSmallDecrease = GetTemplateChildHelper<RepeatButton>("HorizontalSmallDecrease"));
			if (m_tpElementHorizontalSmallDecrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementHorizontalSmallDecrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementHorizontalSmallDecrease, name);
				}
			}
			Thumb thumb = (m_tpElementHorizontalThumb = GetTemplateChildHelper<Thumb>("HorizontalThumb"));
			if (m_tpElementHorizontalThumb != null)
			{
				string name = AutomationProperties.GetName(m_tpElementHorizontalThumb);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementHorizontalThumb, name);
				}
			}
		}
		if (!IsFixedOrientation || Orientation == Orientation.Vertical)
		{
			FrameworkElement frameworkElement2 = (m_tpElementVerticalTemplate = GetTemplateChildHelper<FrameworkElement>("VerticalRoot"));
			RepeatButton repeatButton5 = (m_tpElementVerticalLargeIncrease = GetTemplateChildHelper<RepeatButton>("VerticalLargeIncrease"));
			if (m_tpElementVerticalLargeIncrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementVerticalLargeIncrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementVerticalLargeIncrease, name);
				}
			}
			RepeatButton repeatButton6 = (m_tpElementVerticalSmallIncrease = GetTemplateChildHelper<RepeatButton>("VerticalSmallIncrease"));
			if (m_tpElementVerticalSmallIncrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementVerticalSmallIncrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementVerticalSmallIncrease, name);
				}
			}
			RepeatButton repeatButton7 = (m_tpElementVerticalLargeDecrease = GetTemplateChildHelper<RepeatButton>("VerticalLargeDecrease"));
			if (m_tpElementVerticalLargeDecrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementVerticalLargeDecrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementVerticalLargeDecrease, name);
				}
			}
			RepeatButton repeatButton8 = (m_tpElementVerticalSmallDecrease = GetTemplateChildHelper<RepeatButton>("VerticalSmallDecrease"));
			if (m_tpElementVerticalSmallDecrease != null)
			{
				string name = AutomationProperties.GetName(m_tpElementVerticalSmallDecrease);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementVerticalSmallDecrease, name);
				}
			}
			Thumb thumb2 = (m_tpElementVerticalThumb = GetTemplateChildHelper<Thumb>("VerticalThumb"));
			if (m_tpElementVerticalThumb != null)
			{
				string name = AutomationProperties.GetName(m_tpElementVerticalThumb);
				if (name == null)
				{
					AutomationProperties.SetName(m_tpElementVerticalThumb, name);
				}
			}
			FrameworkElement frameworkElement3 = (m_tpElementHorizontalPanningRoot = GetTemplateChildHelper<FrameworkElement>("HorizontalPanningRoot"));
			FrameworkElement frameworkElement4 = (m_tpElementHorizontalPanningThumb = GetTemplateChildHelper<FrameworkElement>("HorizontalPanningThumb"));
			FrameworkElement frameworkElement5 = (m_tpElementVerticalPanningRoot = GetTemplateChildHelper<FrameworkElement>("VerticalPanningRoot"));
			FrameworkElement frameworkElement6 = (m_tpElementVerticalPanningThumb = GetTemplateChildHelper<FrameworkElement>("VerticalPanningThumb"));
		}
		AttachEvents();
		UpdateScrollBarVisibility();
		m_suspendVisualStateUpdates = false;
		ChangeVisualState(bUseTransitions: false);
	}

	private static void DetachEvents(object snd, RoutedEventArgs args)
	{
		(snd as ScrollBar)?.DetachEvents();
	}

	private void DetachEvents()
	{
		if (m_tpElementHorizontalThumb != null)
		{
			m_ElementHorizontalThumbDragStartedToken.Disposable = null;
			m_ElementHorizontalThumbDragDeltaToken.Disposable = null;
			m_ElementHorizontalThumbDragCompletedToken.Disposable = null;
		}
		if (m_tpElementHorizontalLargeDecrease != null)
		{
			m_ElementHorizontalLargeDecreaseClickToken.Disposable = null;
		}
		if (m_tpElementHorizontalLargeIncrease != null)
		{
			m_ElementHorizontalLargeIncreaseClickToken.Disposable = null;
		}
		if (m_tpElementHorizontalSmallDecrease != null)
		{
			m_ElementHorizontalSmallDecreaseClickToken.Disposable = null;
		}
		if (m_tpElementHorizontalSmallIncrease != null)
		{
			m_ElementHorizontalSmallIncreaseClickToken.Disposable = null;
		}
		if (m_tpElementVerticalThumb != null)
		{
			m_ElementVerticalThumbDragStartedToken.Disposable = null;
			m_ElementVerticalThumbDragDeltaToken.Disposable = null;
			m_ElementVerticalThumbDragCompletedToken.Disposable = null;
		}
		if (m_tpElementVerticalLargeDecrease != null)
		{
			m_ElementVerticalLargeDecreaseClickToken.Disposable = null;
		}
		if (m_tpElementVerticalLargeIncrease != null)
		{
			m_ElementVerticalLargeIncreaseClickToken.Disposable = null;
		}
		if (m_tpElementVerticalSmallDecrease != null)
		{
			m_ElementVerticalSmallDecreaseClickToken.Disposable = null;
		}
		if (m_tpElementVerticalSmallIncrease != null)
		{
			m_ElementVerticalSmallIncreaseClickToken.Disposable = null;
		}
	}

	private static void ReAttachEvents(object snd, RoutedEventArgs args)
	{
		if (snd is ScrollBar scrollBar)
		{
			scrollBar.DetachEvents();
			scrollBar.AttachEvents();
		}
	}

	private void AttachEvents()
	{
		if (m_tpElementHorizontalThumb != null || m_tpElementVerticalThumb != null)
		{
			if (m_tpElementHorizontalThumb != null)
			{
				m_tpElementHorizontalThumb.DragStarted += OnThumbDragStarted;
				m_ElementHorizontalThumbDragStartedToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalThumb.DragStarted -= OnThumbDragStarted;
				});
				m_tpElementHorizontalThumb.DragDelta += OnThumbDragDelta;
				m_ElementHorizontalThumbDragDeltaToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalThumb.DragDelta -= OnThumbDragDelta;
				});
				m_tpElementHorizontalThumb.DragCompleted += OnThumbDragCompleted;
				m_ElementHorizontalThumbDragCompletedToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalThumb.DragCompleted -= OnThumbDragCompleted;
				});
				m_tpElementHorizontalThumb.IgnoreTouchInput = true;
			}
			if (m_tpElementVerticalThumb != null)
			{
				m_tpElementVerticalThumb.DragStarted += OnThumbDragStarted;
				m_ElementVerticalThumbDragStartedToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalThumb.DragStarted -= OnThumbDragStarted;
				});
				m_tpElementVerticalThumb.DragDelta += OnThumbDragDelta;
				m_ElementVerticalThumbDragDeltaToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalThumb.DragDelta -= OnThumbDragDelta;
				});
				m_tpElementVerticalThumb.DragCompleted += OnThumbDragCompleted;
				m_ElementVerticalThumbDragCompletedToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalThumb.DragCompleted -= OnThumbDragCompleted;
				});
				m_tpElementVerticalThumb.IgnoreTouchInput = true;
			}
		}
		if (m_tpElementHorizontalLargeDecrease != null || m_tpElementVerticalLargeDecrease != null)
		{
			if (m_tpElementHorizontalLargeDecrease != null)
			{
				m_tpElementHorizontalLargeDecrease.Click += LargeDecrement;
				m_ElementHorizontalLargeDecreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalLargeDecrease.Click -= LargeDecrement;
				});
				m_tpElementHorizontalLargeDecrease.IgnoreTouchInput = true;
			}
			if (m_tpElementVerticalLargeDecrease != null)
			{
				m_tpElementVerticalLargeDecrease.Click += LargeDecrement;
				m_ElementVerticalLargeDecreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalLargeDecrease.Click -= LargeDecrement;
				});
				m_tpElementVerticalLargeDecrease.IgnoreTouchInput = true;
			}
		}
		if (m_tpElementHorizontalLargeIncrease != null || m_tpElementVerticalLargeIncrease != null)
		{
			if (m_tpElementHorizontalLargeIncrease != null)
			{
				m_tpElementHorizontalLargeIncrease.Click += LargeIncrement;
				m_ElementHorizontalLargeIncreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalLargeIncrease.Click -= LargeIncrement;
				});
				m_tpElementHorizontalLargeIncrease.IgnoreTouchInput = true;
			}
			if (m_tpElementVerticalLargeIncrease != null)
			{
				m_tpElementVerticalLargeIncrease.Click += LargeIncrement;
				m_ElementVerticalLargeIncreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalLargeIncrease.Click -= LargeIncrement;
				});
				m_tpElementVerticalLargeIncrease.IgnoreTouchInput = true;
			}
		}
		if (m_tpElementHorizontalSmallDecrease != null || m_tpElementVerticalSmallDecrease != null)
		{
			if (m_tpElementHorizontalSmallDecrease != null)
			{
				m_tpElementHorizontalSmallDecrease.Click += SmallDecrement;
				m_ElementHorizontalSmallDecreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementHorizontalSmallDecrease.Click -= SmallDecrement;
				});
				m_tpElementHorizontalSmallDecrease.IgnoreTouchInput = true;
			}
			if (m_tpElementVerticalSmallDecrease != null)
			{
				m_tpElementVerticalSmallDecrease.Click += SmallDecrement;
				m_ElementVerticalSmallDecreaseClickToken.Disposable = Disposable.Create(delegate
				{
					m_tpElementVerticalSmallDecrease.Click -= SmallDecrement;
				});
				m_tpElementVerticalSmallDecrease.IgnoreTouchInput = true;
			}
		}
		if (m_tpElementHorizontalSmallIncrease == null && m_tpElementVerticalSmallIncrease == null)
		{
			return;
		}
		if (m_tpElementHorizontalSmallIncrease != null)
		{
			m_tpElementHorizontalSmallIncrease.Click += SmallIncrement;
			m_ElementHorizontalSmallIncreaseClickToken.Disposable = Disposable.Create(delegate
			{
				m_tpElementHorizontalSmallIncrease.Click -= SmallIncrement;
			});
			m_tpElementHorizontalSmallIncrease.IgnoreTouchInput = true;
		}
		if (m_tpElementVerticalSmallIncrease != null)
		{
			m_tpElementVerticalSmallIncrease.Click += SmallIncrement;
			m_ElementVerticalSmallIncreaseClickToken.Disposable = Disposable.Create(delegate
			{
				m_tpElementVerticalSmallIncrease.Click -= SmallIncrement;
			});
			m_tpElementVerticalSmallIncrease.IgnoreTouchInput = true;
		}
	}

	private T GetTemplateChildHelper<T>(string childName) where T : class
	{
		return GetTemplateChild(childName) as T;
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		if (!e.NewValue)
		{
			m_isPointerOver = false;
		}
		UpdateVisualState();
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		m_isPointerOver = true;
		if (!IsDragging)
		{
			UpdateVisualState();
		}
	}

	protected override void OnPointerExited(PointerRoutedEventArgs pArgs)
	{
		m_isPointerOver = false;
		if (!IsDragging)
		{
			UpdateVisualState();
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs pArgs)
	{
		bool handled = pArgs.Handled;
		PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
		PointerPointProperties properties = currentPoint.Properties;
		if (properties.IsLeftButtonPressed && !handled)
		{
			pArgs.Handled = true;
			Pointer pointer = pArgs.Pointer;
			bool flag = CapturePointer(pointer);
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs pArgs)
	{
		if (!pArgs.Handled)
		{
			pArgs.Handled = true;
		}
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	protected override void OnDoubleTapped(DoubleTappedRoutedEventArgs pArgs)
	{
		pArgs.Handled = true;
	}

	protected override void OnTapped(TappedRoutedEventArgs pArgs)
	{
		pArgs.Handled = true;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ScrollBarAutomationPeer(this);
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		if (m_suspendVisualStateUpdates)
		{
			return;
		}
		string text = (IsFixedOrientation ? $"{Orientation}_" : "");
		ScrollingIndicatorMode indicatorMode = IndicatorMode;
		bool isEnabled = base.IsEnabled;
		if (!isEnabled)
		{
			VisualStateManager.GoToState(this, text + "Disabled", bUseTransitions);
		}
		else if (m_isPointerOver)
		{
			if (!VisualStateManager.GoToState(this, text + "PointerOver", bUseTransitions))
			{
				VisualStateManager.GoToState(this, text + "Normal", bUseTransitions);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, text + "Normal", bUseTransitions);
		}
		if (!m_blockIndicators && (!IsConscious() || indicatorMode == ScrollingIndicatorMode.MouseIndicator))
		{
			VisualStateManager.GoToState(this, text + "MouseIndicator", bUseTransitions);
		}
		else if (!m_blockIndicators && indicatorMode == ScrollingIndicatorMode.TouchIndicator)
		{
			if (!VisualStateManager.GoToState(this, text + "TouchIndicator", bUseTransitions))
			{
				VisualStateManager.GoToState(this, text + "MouseIndicator", bUseTransitions);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, text + "NoIndicator", bUseTransitions);
		}
		if (!IsConscious())
		{
			VisualStateManager.GoToState(this, text + (isEnabled ? "Expanded" : "Collapsed"), useTransitions: true);
			return;
		}
		bool flag = false;
		bool isAnimationEnabled = IsAnimationEnabled;
		if (isEnabled && m_isPointerOver)
		{
			if (!isAnimationEnabled)
			{
				flag = VisualStateManager.GoToState(this, text + "ExpandedWithoutAnimation", useTransitions: true);
			}
			if (!flag)
			{
				VisualStateManager.GoToState(this, text + "Expanded", useTransitions: true);
			}
		}
		else
		{
			if (!isAnimationEnabled)
			{
				flag = VisualStateManager.GoToState(this, text + "CollapsedWithoutAnimation", useTransitions: true);
			}
			if (!flag)
			{
				VisualStateManager.GoToState(this, text + "Collapsed", useTransitions: true);
			}
		}
	}

	private double GetTrackLength()
	{
		Orientation orientation = Orientation;
		double num = ((orientation != Orientation.Horizontal) ? base.ActualHeight : base.ActualWidth);
		if (m_isUsingActualSizeAsExtent && (base.IsMeasureDirty || base.IsArrangeDirty))
		{
			double viewportSize = ViewportSize;
			if (!double.IsNaN(viewportSize) && !double.IsNaN(num) && num != 0.0 && num > viewportSize)
			{
				return 0.0;
			}
		}
		if (!double.IsNaN(num))
		{
			return num;
		}
		return 0.0;
	}

	private double GetRepeatButtonsLength()
	{
		double num = 0.0;
		Orientation orientation = Orientation;
		if (orientation == Orientation.Horizontal)
		{
			if (m_tpElementHorizontalSmallDecrease != null)
			{
				double actualWidth = m_tpElementHorizontalSmallDecrease.ActualWidth;
				Thickness margin = m_tpElementHorizontalSmallDecrease.Margin;
				num = actualWidth + margin.Left + margin.Right;
			}
			if (m_tpElementHorizontalSmallIncrease != null)
			{
				double actualWidth = m_tpElementHorizontalSmallIncrease.ActualWidth;
				Thickness margin2 = m_tpElementHorizontalSmallIncrease.Margin;
				num += actualWidth + margin2.Left + margin2.Right;
			}
		}
		else
		{
			if (m_tpElementVerticalSmallDecrease != null)
			{
				double actualWidth = m_tpElementVerticalSmallDecrease.ActualHeight;
				Thickness margin = m_tpElementVerticalSmallDecrease.Margin;
				num = actualWidth + margin.Top + margin.Bottom;
			}
			if (m_tpElementVerticalSmallIncrease != null)
			{
				double actualWidth = m_tpElementVerticalSmallIncrease.ActualHeight;
				Thickness margin2 = m_tpElementVerticalSmallIncrease.Margin;
				num += actualWidth + margin2.Top + margin2.Bottom;
			}
		}
		return num;
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		UpdateTrackLayout();
		base.OnValueChanged(oldValue, newValue);
	}

	protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
	{
		UpdateTrackLayout();
	}

	protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
	{
		UpdateTrackLayout();
	}

	private void OnThumbDragStarted(object pSender, DragStartedEventArgs pArgs)
	{
		m_dragValue = base.Value;
	}

	private void OnThumbDragDelta(object pSender, DragDeltaEventArgs pArgs)
	{
		double num = 0.0;
		double num2 = 1.0;
		double maximum = base.Maximum;
		double minimum = base.Minimum;
		Orientation orientation = Orientation;
		if (orientation == Orientation.Horizontal && m_tpElementHorizontalThumb != null)
		{
			double horizontalChange = pArgs.HorizontalChange;
			double trackLength = GetTrackLength();
			double repeatButtonsLength = GetRepeatButtonsLength();
			trackLength -= repeatButtonsLength;
			double actualWidth = m_tpElementHorizontalThumb.ActualWidth;
			num = num2 * horizontalChange / (trackLength - actualWidth) * (maximum - minimum);
		}
		else if (orientation == Orientation.Vertical && m_tpElementVerticalThumb != null)
		{
			double horizontalChange = pArgs.VerticalChange;
			double trackLength = GetTrackLength();
			double repeatButtonsLength = GetRepeatButtonsLength();
			trackLength -= repeatButtonsLength;
			double actualWidth = m_tpElementVerticalThumb.ActualHeight;
			num = num2 * horizontalChange / (trackLength - actualWidth) * (maximum - minimum);
		}
		if (!double.IsNaN(num) && !double.IsInfinity(num))
		{
			m_dragValue += num;
			double num3 = Math.Min(maximum, Math.Max(minimum, m_dragValue));
			double value = base.Value;
			if (num3 != value)
			{
				base.Value = num3;
				RaiseScrollEvent(ScrollEventType.ThumbTrack);
			}
		}
	}

	private void OnThumbDragCompleted(object pSender, DragCompletedEventArgs pArgs)
	{
		RaiseScrollEvent(ScrollEventType.EndScroll);
	}

	private static void OnSizeChanged(object pSender, SizeChangedEventArgs pArgs)
	{
		(pSender as ScrollBar)?.UpdateTrackLayout();
	}

	private static void OnLayoutUpdated(object pSender, object pArgs)
	{
		(pSender as ScrollBar)?.UpdateTrackLayout();
	}

	private void SmallDecrement(object pSender, RoutedEventArgs pArgs)
	{
		double value = base.Value;
		double smallChange = base.SmallChange;
		double minimum = base.Minimum;
		double num = Math.Max(value - smallChange, minimum);
		if (num != value)
		{
			base.Value = num;
			RaiseScrollEvent(ScrollEventType.SmallDecrement);
		}
	}

	private void SmallIncrement(object pSender, RoutedEventArgs pArgs)
	{
		double value = base.Value;
		double smallChange = base.SmallChange;
		double maximum = base.Maximum;
		double num = Math.Min(value + smallChange, maximum);
		if (num != value)
		{
			base.Value = num;
			RaiseScrollEvent(ScrollEventType.SmallIncrement);
		}
	}

	private void LargeDecrement(object pSender, RoutedEventArgs pArgs)
	{
		double value = base.Value;
		double largeChange = base.LargeChange;
		double minimum = base.Minimum;
		double num = Math.Max(value - largeChange, minimum);
		if (num != value)
		{
			base.Value = num;
			RaiseScrollEvent(ScrollEventType.LargeDecrement);
		}
	}

	private void LargeIncrement(object pSender, RoutedEventArgs pArgs)
	{
		double value = base.Value;
		double largeChange = base.LargeChange;
		double maximum = base.Maximum;
		double num = Math.Min(value + largeChange, maximum);
		if (num != value)
		{
			base.Value = num;
			RaiseScrollEvent(ScrollEventType.LargeIncrement);
		}
	}

	private void RaiseScrollEvent(ScrollEventType scrollEventType)
	{
		ScrollEventArgs scrollEventArgs = new ScrollEventArgs();
		scrollEventArgs.ScrollEventType = scrollEventType;
		scrollEventArgs.NewValue = base.Value;
		scrollEventArgs.OriginalSource = this;
		this.Scroll?.Invoke(this, scrollEventArgs);
	}

	private void OnOrientationChanged()
	{
		Orientation orientation = Orientation;
		if (m_tpElementVerticalTemplate != null)
		{
			m_tpElementVerticalTemplate.Visibility = ((orientation == Orientation.Horizontal) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpElementVerticalPanningRoot != null)
		{
			m_tpElementVerticalPanningRoot.Visibility = ((orientation == Orientation.Horizontal) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpElementHorizontalTemplate != null)
		{
			m_tpElementHorizontalTemplate.Visibility = ((orientation != Orientation.Horizontal) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpElementHorizontalPanningRoot != null)
		{
			m_tpElementHorizontalPanningRoot.Visibility = ((orientation != Orientation.Horizontal) ? Visibility.Collapsed : Visibility.Visible);
		}
		UpdateTrackLayout();
	}

	private void RefreshTrackLayout()
	{
		UpdateTrackLayout();
		ChangeVisualState(bUseTransitions: true);
	}

	private void UpdateScrollBarVisibility()
	{
		OnOrientationChanged();
		RefreshTrackLayout();
	}

	private void UpdateTrackLayout()
	{
		double maximum = base.Maximum;
		double minimum = base.Minimum;
		double value = base.Value;
		Orientation orientation = Orientation;
		double trackLength = GetTrackLength();
		UpdateIndicatorLengths(trackLength, out var pMouseIndicatorLength, out var pTouchIndicatorLength);
		double num = maximum - minimum;
		double num2 = ((num != 0.0) ? ((value - minimum) / num) : 0.0);
		double repeatButtonsLength = GetRepeatButtonsLength();
		double num3 = Math.Max(0.0, num2 * (trackLength - repeatButtonsLength - pMouseIndicatorLength));
		double num4 = Math.Max(0.0, num2 * (trackLength - pTouchIndicatorLength));
		if (orientation == Orientation.Horizontal && m_tpElementHorizontalLargeDecrease != null && m_tpElementHorizontalThumb != null)
		{
			m_tpElementHorizontalLargeDecrease.Width = num3;
		}
		else if (orientation == Orientation.Vertical && m_tpElementVerticalLargeDecrease != null && m_tpElementVerticalThumb != null)
		{
			m_tpElementVerticalLargeDecrease.Height = num3;
		}
		if (orientation == Orientation.Horizontal && m_tpElementHorizontalPanningRoot != null)
		{
			Thickness margin = m_tpElementHorizontalPanningRoot.Margin;
			margin.Left = num4;
			m_tpElementHorizontalPanningRoot.Margin = margin;
		}
		else if (orientation == Orientation.Vertical && m_tpElementVerticalPanningRoot != null)
		{
			Thickness margin = m_tpElementVerticalPanningRoot.Margin;
			margin.Top = num4;
			m_tpElementVerticalPanningRoot.Margin = margin;
		}
	}

	private void ConvertViewportSizeToDisplayUnits(double trackLength, out double pThumbSize)
	{
		double maximum = base.Maximum;
		double minimum = base.Minimum;
		double viewportSize = ViewportSize;
		pThumbSize = Math.Round(trackLength * viewportSize / Math.Max(1.0, viewportSize + maximum - minimum), 0);
	}

	private void UpdateIndicatorLengths(double trackLength, out double pMouseIndicatorLength, out double pTouchIndicatorLength)
	{
		double num = double.NaN;
		bool flag = trackLength <= 0.0;
		bool flag2 = false;
		bool flag3 = false;
		pMouseIndicatorLength = 0.0;
		pTouchIndicatorLength = 0.0;
		double? num2 = null;
		double? num3 = null;
		double? num4 = null;
		double? num5 = null;
		Visibility? visibility = null;
		Visibility? visibility2 = null;
		Visibility? visibility3 = null;
		Visibility? visibility4 = null;
		if (!flag)
		{
			double num6 = 0.0;
			Orientation orientation = Orientation;
			double maximum = base.Maximum;
			double minimum = base.Minimum;
			double repeatButtonsLength = GetRepeatButtonsLength();
			double num7 = trackLength - repeatButtonsLength;
			ConvertViewportSizeToDisplayUnits(num7, out var pThumbSize);
			if (orientation == Orientation.Horizontal && m_tpElementHorizontalThumb != null)
			{
				if (maximum - minimum != 0.0)
				{
					num6 = m_tpElementHorizontalThumb.MinWidth;
					num = Math.Max(num6, pThumbSize);
				}
				double actualWidth = base.ActualWidth;
				double num8 = actualWidth - repeatButtonsLength;
				if (maximum - minimum == 0.0 || num > num8 || num7 <= num6)
				{
					flag = true;
				}
				else
				{
					visibility = Visibility.Visible;
					num2 = num;
					flag2 = true;
				}
			}
			else if (orientation == Orientation.Vertical && m_tpElementVerticalThumb != null)
			{
				if (maximum - minimum != 0.0)
				{
					num6 = m_tpElementVerticalThumb.MinHeight;
					num = Math.Max(num6, pThumbSize);
				}
				double actualWidth = base.ActualHeight;
				double num8 = actualWidth - repeatButtonsLength;
				if (maximum - minimum == 0.0 || num > num8 || num7 <= num6)
				{
					flag = true;
				}
				else
				{
					visibility2 = Visibility.Visible;
					num3 = num;
					flag2 = true;
				}
			}
			if (flag2)
			{
				pMouseIndicatorLength = (double.IsNaN(num) ? 0.0 : num);
			}
			ConvertViewportSizeToDisplayUnits(trackLength, out pThumbSize);
			if (orientation == Orientation.Horizontal && m_tpElementHorizontalPanningThumb != null)
			{
				if (maximum - minimum != 0.0)
				{
					num6 = m_tpElementHorizontalPanningThumb.MinWidth;
					num = Math.Max(num6, pThumbSize);
				}
				double actualWidth = base.ActualWidth;
				if (maximum - minimum == 0.0 || num > actualWidth || trackLength <= num6)
				{
					flag = true;
				}
				else
				{
					visibility3 = Visibility.Visible;
					num4 = num;
					flag3 = true;
				}
			}
			else if (orientation == Orientation.Vertical && m_tpElementVerticalPanningThumb != null)
			{
				if (maximum - minimum != 0.0)
				{
					num6 = m_tpElementVerticalPanningThumb.MinHeight;
					num = Math.Max(num6, pThumbSize);
				}
				double actualWidth = base.ActualHeight;
				if (maximum - minimum == 0.0 || num > actualWidth || trackLength <= num6)
				{
					flag = true;
				}
				else
				{
					visibility4 = Visibility.Visible;
					num5 = num;
					flag3 = true;
				}
			}
			if (flag3)
			{
				pTouchIndicatorLength = (double.IsNaN(num) ? 0.0 : num);
			}
		}
		if (flag)
		{
			if (m_tpElementHorizontalThumb != null)
			{
				m_tpElementHorizontalThumb.Visibility = Visibility.Collapsed;
			}
			if (m_tpElementVerticalThumb != null)
			{
				m_tpElementVerticalThumb.Visibility = Visibility.Collapsed;
			}
			if (m_tpElementHorizontalPanningThumb != null)
			{
				m_tpElementHorizontalPanningThumb.Visibility = Visibility.Collapsed;
			}
			if (m_tpElementVerticalPanningThumb != null)
			{
				m_tpElementVerticalPanningThumb.Visibility = Visibility.Collapsed;
			}
			return;
		}
		if (num2.HasValue)
		{
			m_tpElementHorizontalThumb.Width = num2.Value;
		}
		if (num3.HasValue)
		{
			m_tpElementVerticalThumb.Height = num3.Value;
		}
		if (num4.HasValue)
		{
			m_tpElementHorizontalPanningThumb.Width = num4.Value;
		}
		if (num5.HasValue)
		{
			m_tpElementVerticalPanningThumb.Height = num5.Value;
		}
		if (visibility.HasValue)
		{
			m_tpElementHorizontalThumb.Visibility = visibility.Value;
		}
		if (visibility2.HasValue)
		{
			m_tpElementVerticalThumb.Visibility = visibility2.Value;
		}
		if (visibility3.HasValue)
		{
			m_tpElementHorizontalPanningThumb.Visibility = visibility3.Value;
		}
		if (visibility4.HasValue)
		{
			m_tpElementVerticalPanningThumb.Visibility = visibility4.Value;
		}
	}

	private void BlockIndicatorFromShowing()
	{
		if (!m_blockIndicators)
		{
			m_blockIndicators = true;
			ChangeVisualState(bUseTransitions: false);
		}
	}

	private void ResetBlockIndicatorFromShowing()
	{
		m_blockIndicators = false;
	}

	private void AdjustDragValue(double delta)
	{
		bool isDragging = IsDragging;
		m_dragValue += delta;
	}
}
