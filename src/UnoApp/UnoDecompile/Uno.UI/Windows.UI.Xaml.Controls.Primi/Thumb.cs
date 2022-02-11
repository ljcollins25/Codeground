using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls.Primitives;

public sealed class Thumb : Control
{
	private int _disableCapturePointers;

	private Point _startLocation;

	private Point _lastLocation;

	public bool IsDragging
	{
		get
		{
			return (bool)GetValue(IsDraggingProperty);
		}
		set
		{
			SetValue(IsDraggingProperty, value);
		}
	}

	internal bool IgnoreTouchInput { get; set; }

	public static DependencyProperty IsDraggingProperty { get; } = DependencyProperty.Register("IsDragging", typeof(bool), typeof(Thumb), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Thumb)s)?.OnIsDraggingChanged(e);
	}));


	public event DragCompletedEventHandler DragCompleted;

	public event DragDeltaEventHandler DragDelta;

	public event DragStartedEventHandler DragStarted;

	private void OnIsDraggingChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	public Thumb()
	{
		base.DefaultStyleKey = typeof(Thumb);
	}

	internal void DisablePointersTracking()
	{
		_disableCapturePointers = 4;
	}

	internal void DisableMouseTracking()
	{
		_disableCapturePointers |= 2;
	}

	private bool ShouldCapture(PointerDeviceType type)
	{
		return ((uint)_disableCapturePointers & (uint)((PointerDeviceType)4 | type)) == 0;
	}

	public void CancelDrag()
	{
	}

	internal void StartDrag(PointerRoutedEventArgs args)
	{
		Point position = args.GetCurrentPoint(null).Position;
		_startLocation = (_lastLocation = position);
		IsDragging = true;
		DragStartedEventHandler dragStarted = this.DragStarted;
		if (base.Parent is UIElement relativeTo && dragStarted != null)
		{
			Point position2 = args.GetCurrentPoint(relativeTo).Position;
			this.DragStarted?.Invoke(this, new DragStartedEventArgs(this, position2.X, position2.Y));
		}
	}

	internal void DeltaDrag(PointerRoutedEventArgs args)
	{
		Point position = args.GetCurrentPoint(null).Position;
		double horizontalChange = position.X - _lastLocation.X;
		double verticalChange = position.Y - _lastLocation.Y;
		double totalHorizontalChange = position.X - _startLocation.X;
		double totalVerticalChange = position.Y - _startLocation.Y;
		_lastLocation = position;
		this.DragDelta?.Invoke(this, new DragDeltaEventArgs(this, horizontalChange, verticalChange, totalHorizontalChange, totalVerticalChange));
	}

	internal void CompleteDrag(PointerRoutedEventArgs args)
	{
		IsDragging = false;
		Point position = args.GetCurrentPoint(null).Position;
		double horizontalChange = position.X - _lastLocation.X;
		double verticalChange = position.Y - _lastLocation.Y;
		double totalHorizontalChange = position.X - _startLocation.X;
		double totalVerticalChange = position.Y - _startLocation.Y;
		this.DragCompleted?.Invoke(this, new DragCompletedEventArgs(this, horizontalChange, verticalChange, totalHorizontalChange, totalVerticalChange, canceled: false));
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		base.OnPointerPressed(args);
		if (ShouldCapture(args.Pointer.PointerDeviceType))
		{
			PointerPoint currentPoint = args.GetCurrentPoint(null);
			if (currentPoint.Properties.IsLeftButtonPressed && CapturePointer(args.Pointer))
			{
				args.Handled = true;
				StartDrag(args);
			}
		}
	}

	protected override void OnPointerMoved(PointerRoutedEventArgs args)
	{
		base.OnPointerMoved(args);
		if (IsCaptured(args.Pointer))
		{
			DeltaDrag(args);
		}
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs args)
	{
		base.OnPointerCaptureLost(args);
		CompleteDrag(args);
	}
}
