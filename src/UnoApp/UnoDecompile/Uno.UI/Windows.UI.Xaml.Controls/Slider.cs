using System;
using Uno;
using Uno.Disposables;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls;

public class Slider : RangeBase
{
	private ContentPresenter _headerContentPresenter;

	private Thumb _horizontalThumb;

	private Thumb _verticalThumb;

	private FrameworkElement _horizontalTemplate;

	private FrameworkElement _verticalTemplate;

	private bool _isDragging;

	private bool _isInDragDelta;

	private Rectangle _horizontalDecreaseRect;

	private Rectangle _horizontalTrackRect;

	private Rectangle _verticalDecreaseRect;

	private Rectangle _verticalTrackRect;

	private FrameworkElement _sliderContainer;

	private double _horizontalInitial;

	private double _verticalInitial;

	private readonly SerialDisposable _sliderContainerSubscription = new SerialDisposable();

	private readonly SerialDisposable _eventSubscriptions = new SerialDisposable();

	private Thumb Thumb
	{
		get
		{
			if (Orientation != Orientation.Horizontal)
			{
				return _verticalThumb;
			}
			return _horizontalThumb;
		}
	}

	private bool HasXamlTemplate
	{
		get
		{
			if (_horizontalThumb == null)
			{
				return _verticalThumb != null;
			}
			return true;
		}
	}

	[UnoOnly]
	public bool IsTrackerEnabled
	{
		get
		{
			return (bool)GetValue(IsTrackerEnabledProperty);
		}
		set
		{
			SetValue(IsTrackerEnabledProperty, value);
		}
	}

	public static DependencyProperty IsTrackerEnabledProperty { get; }

	public double StepFrequency
	{
		get
		{
			return (double)GetValue(StepFrequencyProperty);
		}
		set
		{
			SetValue(StepFrequencyProperty, value);
		}
	}

	public static DependencyProperty StepFrequencyProperty { get; }

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

	public static DependencyProperty OrientationProperty { get; }

	public SliderSnapsTo SnapsTo
	{
		get
		{
			return (SliderSnapsTo)GetValue(SnapsToProperty);
		}
		set
		{
			SetValue(SnapsToProperty, value);
		}
	}

	public static DependencyProperty SnapsToProperty { get; }

	public bool IsThumbToolTipEnabled
	{
		get
		{
			return (bool)GetValue(IsThumbToolTipEnabledProperty);
		}
		set
		{
			SetValue(IsThumbToolTipEnabledProperty, value);
		}
	}

	public static DependencyProperty IsThumbToolTipEnabledProperty { get; }

	public bool IsDirectionReversed
	{
		get
		{
			return (bool)GetValue(IsDirectionReversedProperty);
		}
		set
		{
			SetValue(IsDirectionReversedProperty, value);
		}
	}

	public static DependencyProperty IsDirectionReversedProperty { get; }

	public double IntermediateValue
	{
		get
		{
			return (double)GetValue(IntermediateValueProperty);
		}
		set
		{
			SetValue(IntermediateValueProperty, value);
		}
	}

	public static DependencyProperty IntermediateValueProperty { get; }

	public TickPlacement TickPlacement
	{
		get
		{
			return (TickPlacement)GetValue(TickPlacementProperty);
		}
		set
		{
			SetValue(TickPlacementProperty, value);
		}
	}

	public static DependencyProperty TickPlacementProperty { get; }

	public double TickFrequency
	{
		get
		{
			return (double)GetValue(TickFrequencyProperty);
		}
		set
		{
			SetValue(TickFrequencyProperty, value);
		}
	}

	public static DependencyProperty TickFrequencyProperty { get; }

	public IValueConverter ThumbToolTipValueConverter
	{
		get
		{
			return (IValueConverter)GetValue(ThumbToolTipValueConverterProperty);
		}
		set
		{
			SetValue(ThumbToolTipValueConverterProperty, value);
		}
	}

	public static DependencyProperty ThumbToolTipValueConverterProperty { get; }

	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; }

	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; }

	static Slider()
	{
		IsTrackerEnabledProperty = DependencyProperty.Register("IsTrackerEnabled", typeof(bool), typeof(Slider), new FrameworkPropertyMetadata(true));
		StepFrequencyProperty = DependencyProperty.Register("StepFrequency", typeof(double), typeof(Slider), new FrameworkPropertyMetadata(1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnStepFrequencyChanged(e);
		}));
		OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Slider), new FrameworkPropertyMetadata(Orientation.Horizontal, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnOrientationChanged(e);
		}));
		SnapsToProperty = DependencyProperty.Register("SnapsTo", typeof(SliderSnapsTo), typeof(Slider), new FrameworkPropertyMetadata(SliderSnapsTo.StepValues, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnSnapsToChanged(e);
		}));
		IsThumbToolTipEnabledProperty = DependencyProperty.Register("IsThumbToolTipEnabled", typeof(bool), typeof(Slider), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnIsThumbToolTipEnabledChanged(e);
		}));
		IsDirectionReversedProperty = DependencyProperty.Register("IsDirectionReversed", typeof(bool), typeof(Slider), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnIsDirectionReversedChanged(e);
		}));
		IntermediateValueProperty = DependencyProperty.Register("IntermediateValue", typeof(double), typeof(Slider), new FrameworkPropertyMetadata(0.5, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnIntermediateValueChanged(e);
		}));
		TickPlacementProperty = DependencyProperty.Register("TickPlacement", typeof(TickPlacement), typeof(Slider), new FrameworkPropertyMetadata(TickPlacement.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnTickPlacementChanged(e);
		}));
		TickFrequencyProperty = DependencyProperty.Register("TickFrequency", typeof(double), typeof(Slider), new FrameworkPropertyMetadata(0.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnTickFrequencyChanged(e);
		}));
		ThumbToolTipValueConverterProperty = DependencyProperty.Register("ThumbToolTipValueConverter", typeof(IValueConverter), typeof(Slider), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnThumbToolTipValueConverterChanged(e);
		}));
		HeaderTemplateProperty = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Slider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnHeaderTemplateChanged(e);
		}));
		HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(Slider), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((Slider)s)?.OnHeaderChanged(e);
		}));
		RangeBase.MaximumProperty.OverrideMetadata(typeof(Slider), new FrameworkPropertyMetadata(100.0));
		RangeBase.SmallChangeProperty.OverrideMetadata(typeof(Slider), new FrameworkPropertyMetadata(1.0));
	}

	public Slider()
	{
		base.DefaultStyleKey = typeof(Slider);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_eventSubscriptions.Disposable = null;
		_headerContentPresenter = GetTemplateChild("HeaderContentPresenter") as ContentPresenter;
		if (_headerContentPresenter != null)
		{
			UpdateHeaderVisibility();
		}
		_horizontalThumb = GetTemplateChild("HorizontalThumb") as Thumb;
		_verticalThumb = GetTemplateChild("VerticalThumb") as Thumb;
		_horizontalThumb?.DisablePointersTracking();
		_verticalThumb?.DisablePointersTracking();
		_verticalTemplate = GetTemplateChild("VerticalTemplate") as FrameworkElement;
		_verticalTrackRect = GetTemplateChild("VerticalTrackRect") as Rectangle;
		_verticalDecreaseRect = GetTemplateChild("VerticalDecreaseRect") as Rectangle;
		_horizontalTemplate = GetTemplateChild("HorizontalTemplate") as FrameworkElement;
		_horizontalTrackRect = GetTemplateChild("HorizontalTrackRect") as Rectangle;
		_horizontalDecreaseRect = GetTemplateChild("HorizontalDecreaseRect") as Rectangle;
		_sliderContainer = GetTemplateChild("SliderContainer") as FrameworkElement;
		if (!base.IsLoaded)
		{
			_eventSubscriptions.Disposable = RegisterHandlers();
		}
		if (HasXamlTemplate)
		{
			base.SizeChanged += delegate
			{
				ApplyValueToSlide();
			};
			ApplyValueToSlide();
		}
		UpdateCommonState(useTransitions: false);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		if (_eventSubscriptions.Disposable == null)
		{
			_eventSubscriptions.Disposable = RegisterHandlers();
		}
		if (_sliderContainer != null)
		{
			if (_sliderContainer.Background == null)
			{
				_sliderContainer.SetValue(FrameworkElement.BackgroundProperty, SolidColorBrushHelper.Transparent, DependencyPropertyValuePrecedences.ImplicitStyle);
			}
			SubscribeSliderContainerPressed();
		}
		UpdateOrientation(Orientation);
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		_eventSubscriptions.Disposable = null;
	}

	private IDisposable RegisterHandlers()
	{
		if (_horizontalThumb != null)
		{
			_horizontalThumb.DragStarted += OnDragStarted;
			_horizontalThumb.DragDelta += OnDragDelta;
			_horizontalThumb.DragCompleted += OnDragCompleted;
		}
		if (_verticalThumb != null)
		{
			_verticalThumb.DragStarted += OnDragStarted;
			_verticalThumb.DragDelta += OnDragDelta;
			_verticalThumb.DragCompleted += OnDragCompleted;
		}
		return Disposable.Create(delegate
		{
			if (_horizontalThumb != null)
			{
				_horizontalThumb.DragStarted -= OnDragStarted;
				_horizontalThumb.DragDelta -= OnDragDelta;
				_horizontalThumb.DragCompleted -= OnDragCompleted;
			}
			if (_verticalThumb != null)
			{
				_verticalThumb.DragStarted -= OnDragStarted;
				_verticalThumb.DragDelta -= OnDragDelta;
				_verticalThumb.DragCompleted -= OnDragCompleted;
			}
		});
	}

	private void OnDragCompleted(object sender, DragCompletedEventArgs args)
	{
		ApplyValueToSlide();
		_isDragging = false;
		UpdateCommonState();
	}

	private void OnDragDelta(object sender, DragDeltaEventArgs e)
	{
		try
		{
			_isInDragDelta = true;
			if (Orientation == Orientation.Horizontal)
			{
				double num = base.ActualWidth - _horizontalThumb.ActualWidth;
				_horizontalDecreaseRect.Width = Math.Min(Math.Max(0.0, _horizontalInitial + (double)(float)e.TotalHorizontalChange), num);
				ApplySlideToValue(_horizontalDecreaseRect.Width / num);
			}
			else
			{
				double num2 = base.ActualHeight - _horizontalThumb.ActualHeight;
				_verticalDecreaseRect.Height = Math.Min(Math.Max(0.0, _verticalInitial - (double)(float)e.TotalVerticalChange), (float)num2);
				ApplySlideToValue(_verticalDecreaseRect.Height / num2);
			}
		}
		finally
		{
			_isInDragDelta = false;
		}
	}

	private void OnDragStarted(object sender, DragStartedEventArgs args)
	{
		if (HasXamlTemplate)
		{
			if (Orientation == Orientation.Horizontal)
			{
				_horizontalInitial = GetSanitizedDimension(_horizontalDecreaseRect.Width);
			}
			else
			{
				_verticalInitial = GetSanitizedDimension(_verticalDecreaseRect.Height);
			}
			_isDragging = true;
			UpdateCommonState();
		}
	}

	private void UpdateCommonState(bool useTransitions = true)
	{
		if (!base.IsEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", useTransitions);
		}
		else if (_isDragging)
		{
			VisualStateManager.GoToState(this, "Pressed", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", useTransitions);
		}
	}

	private double GetSanitizedDimension(double dimensionValue)
	{
		if (double.IsNaN(dimensionValue))
		{
			return 0.0;
		}
		return dimensionValue;
	}

	private void ApplySlideToValue(double slideFraction)
	{
		double num = slideFraction * (base.Maximum - base.Minimum) + base.Minimum;
		double snapFrequency = GetSnapFrequency();
		if (snapFrequency <= 0.0 || double.IsNaN(snapFrequency))
		{
			throw new ArgumentException("Value does not fall within the expected range.");
		}
		double num2 = (num - base.Minimum) % snapFrequency;
		num = (base.Value = ((!(num2 < snapFrequency / 2.0)) ? (num + (snapFrequency - num2)) : (num - num2)));
	}

	private void ApplyValueToSlide()
	{
		if (Orientation == Orientation.Horizontal)
		{
			if (_horizontalThumb != null && _horizontalDecreaseRect != null)
			{
				double num = base.ActualWidth - GetHorizontalThumbWidth();
				_horizontalDecreaseRect.Width = (double)(float)((base.Value - base.Minimum) / (base.Maximum - base.Minimum)) * num;
			}
		}
		else if (_verticalThumb != null && _verticalDecreaseRect != null)
		{
			double num2 = base.ActualHeight - GetVerticalThumbHeight();
			_verticalDecreaseRect.Height = (double)(float)((base.Value - base.Minimum) / (base.Maximum - base.Minimum)) * num2;
		}
	}

	private double GetHorizontalThumbWidth()
	{
		if (_horizontalThumb.ActualWidth == 0.0 && !double.IsNaN(_horizontalThumb.Width))
		{
			return _horizontalThumb.Width;
		}
		return _horizontalThumb.ActualWidth;
	}

	private double GetVerticalThumbHeight()
	{
		if (_verticalThumb.ActualHeight == 0.0 && !double.IsNaN(_verticalThumb.Height))
		{
			return _verticalThumb.Height;
		}
		return _verticalThumb.ActualHeight;
	}

	private double GetSnapFrequency()
	{
		double val = ((SnapsTo == SliderSnapsTo.StepValues) ? StepFrequency : TickFrequency);
		return Math.Min(base.Maximum - base.Minimum, val);
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		if (!_isInDragDelta && HasXamlTemplate)
		{
			ApplyValueToSlide();
		}
	}

	private void SubscribeSliderContainerPressed()
	{
		FrameworkElement container = _sliderContainer;
		if (container != null && IsTrackerEnabled)
		{
			_sliderContainerSubscription.Disposable = null;
			container.PointerPressed += OnSliderContainerPressed;
			container.PointerMoved += OnSliderContainerMoved;
			container.PointerCaptureLost += OnSliderContainerCaptureLost;
			_sliderContainerSubscription.Disposable = Disposable.Create(delegate
			{
				container.PointerPressed -= OnSliderContainerPressed;
				container.PointerMoved -= OnSliderContainerMoved;
				container.PointerCaptureLost -= OnSliderContainerCaptureLost;
			});
		}
	}

	private void OnSliderContainerPressed(object sender, PointerRoutedEventArgs args)
	{
		if (sender is FrameworkElement frameworkElement && frameworkElement.CapturePointer(args.Pointer))
		{
			Point position = args.GetCurrentPoint(frameworkElement).Position;
			double slideFraction = ((Orientation == Orientation.Horizontal) ? (position.X / frameworkElement.ActualWidth) : (1.0 - position.Y / frameworkElement.ActualHeight));
			ApplySlideToValue(slideFraction);
			Thumb?.StartDrag(args);
		}
	}

	private void OnSliderContainerMoved(object sender, PointerRoutedEventArgs args)
	{
		if (sender is FrameworkElement frameworkElement && frameworkElement.IsCaptured(args.Pointer))
		{
			Thumb?.DeltaDrag(args);
		}
	}

	private void OnSliderContainerCaptureLost(object sender, PointerRoutedEventArgs args)
	{
		ApplyValueToSlide();
		Thumb?.CompleteDrag(args);
	}

	private void UpdateHeaderVisibility()
	{
		if (_headerContentPresenter != null)
		{
			_headerContentPresenter.Visibility = ((Header == null) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private void OnStepFrequencyChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnOrientationChanged(DependencyPropertyChangedEventArgs e)
	{
		if (e.NewValue is Orientation)
		{
			Orientation newOrientation = (Orientation)e.NewValue;
			UpdateOrientation(newOrientation);
			return;
		}
		if (_horizontalTemplate != null)
		{
			_horizontalTemplate.Visibility = Visibility.Visible;
		}
		if (_verticalTemplate != null)
		{
			_verticalTemplate.Visibility = Visibility.Collapsed;
		}
	}

	private void UpdateOrientation(Orientation newOrientation)
	{
		if (_horizontalTemplate != null)
		{
			_horizontalTemplate.Visibility = ((newOrientation != Orientation.Horizontal) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (_verticalTemplate != null)
		{
			_verticalTemplate.Visibility = ((newOrientation != 0) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private void OnSnapsToChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnIsThumbToolTipEnabledChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnIsDirectionReversedChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnIntermediateValueChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnTickPlacementChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnTickFrequencyChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnThumbToolTipValueConverterChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnHeaderTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnHeaderChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateHeaderVisibility();
	}
}
