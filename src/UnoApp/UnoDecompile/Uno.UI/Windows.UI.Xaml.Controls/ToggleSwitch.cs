using System;
using DirectUI;
using Uno.Disposables;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class ToggleSwitch : Control, IFrameworkTemplatePoolAware
{
	private static class KeyProcess
	{
		internal static bool KeyDown(VirtualKey key, ToggleSwitch control)
		{
			if (control.HandlesKey(key))
			{
				return true;
			}
			return false;
		}

		internal static bool KeyUp(VirtualKey key, ToggleSwitch control)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			FlowDirection flowDirection = control.FlowDirection;
			bool flag7 = flowDirection == FlowDirection.LeftToRight;
			flag4 = control.HandlesKey(key);
			if (flag4)
			{
				flag5 = control._handledKeyDown;
				control._handledKeyDown = false;
			}
			if (key == VirtualKey.GamepadA)
			{
				control.Toggle();
				flag = true;
			}
			if (flag4 && flag5 && !flag && !control._isDragging)
			{
				flag6 = control.IsOn;
				if ((key == VirtualKey.Left && flag7) || (key == VirtualKey.Right && !flag7) || key == VirtualKey.Down || key == VirtualKey.Home)
				{
					flag2 = true;
				}
				else if ((key == VirtualKey.Right && flag7) || (key == VirtualKey.Left && !flag7) || key == VirtualKey.Up || key == VirtualKey.End)
				{
					flag3 = true;
				}
				if ((!flag6 && flag3) || (flag6 && flag2) || key == VirtualKey.Space)
				{
					control.Toggle();
					flag = true;
				}
			}
			return flag;
		}
	}

	private bool _isDragging;

	private bool _wasDragged;

	private bool _isPointerOver;

	private double _knobTranslation;

	private double _minKnobTranslation;

	private double _maxKnobTranslation;

	private double _curtainTranslation;

	private double _minCurtainTranslation;

	private double _maxCurtainTranslation;

	private bool _handledKeyDown;

	private UIElement? _tpCurtainClip;

	private FrameworkElement? _tpKnob;

	private FrameworkElement? _tpKnobBounds;

	private FrameworkElement? _tpCurtainBounds;

	private Thumb? _tpThumb;

	private UIElement? _tpHeaderPresenter;

	private TranslateTransform? _spKnobTransform;

	private TranslateTransform? _spCurtainTransform;

	private SerialDisposable _dragStarted = new SerialDisposable();

	private SerialDisposable _dragDelta = new SerialDisposable();

	private SerialDisposable _dragCompleted = new SerialDisposable();

	private SerialDisposable _tap = new SerialDisposable();

	private SerialDisposable _knobSizeChanged = new SerialDisposable();

	private SerialDisposable _knobBoundsSizeChanged = new SerialDisposable();

	private bool IsNativeTemplate => false;

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

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public bool IsOn
	{
		get
		{
			return (bool)GetValue(IsOnProperty);
		}
		set
		{
			SetValue(IsOnProperty, value);
		}
	}

	public static DependencyProperty IsOnProperty { get; } = DependencyProperty.Register("IsOn", typeof(bool), typeof(ToggleSwitch), new FrameworkPropertyMetadata(false));


	public object OffContent
	{
		get
		{
			return GetValue(OffContentProperty);
		}
		set
		{
			SetValue(OffContentProperty, value);
		}
	}

	public static DependencyProperty OffContentProperty { get; } = DependencyProperty.Register("OffContent", typeof(object), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null));


	public DataTemplate OffContentTemplate
	{
		get
		{
			return (DataTemplate)GetValue(OffContentTemplateProperty);
		}
		set
		{
			SetValue(OffContentTemplateProperty, value);
		}
	}

	public static DependencyProperty OffContentTemplateProperty { get; } = DependencyProperty.Register("OffContentTemplate", typeof(DataTemplate), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public object OnContent
	{
		get
		{
			return GetValue(OnContentProperty);
		}
		set
		{
			SetValue(OnContentProperty, value);
		}
	}

	public static DependencyProperty OnContentProperty { get; } = DependencyProperty.Register("OnContent", typeof(object), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null));


	public DataTemplate OnContentTemplate
	{
		get
		{
			return (DataTemplate)GetValue(OnContentTemplateProperty);
		}
		set
		{
			SetValue(OnContentTemplateProperty, value);
		}
	}

	public static DependencyProperty OnContentTemplateProperty { get; } = DependencyProperty.Register("OnContentTemplate", typeof(DataTemplate), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public ToggleSwitchTemplateSettings TemplateSettings { get; private set; }

	public event RoutedEventHandler Toggled;

	public ToggleSwitch()
	{
		base.DefaultStyleKey = typeof(ToggleSwitch);
		this.RegisterDefaultValueProvider(GetDefaultValue2);
		PrepareState();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
	}

	private double GetEndAbsoluteOffset()
	{
		int num = 0;
		double maxOffset = GetMaxOffset();
		double num2 = (IsOn ? maxOffset : 0.0);
		double val = num2;
		val = Math.Max(num, val);
		return Math.Min(maxOffset, val);
	}

	private double GetMaxOffset()
	{
		if (_tpKnobBounds == null || _tpKnob == null)
		{
			return 0.0;
		}
		return _tpKnobBounds!.ActualWidth - _tpKnob!.ActualWidth;
	}

	private void ForceSwitchKnobEndPosition()
	{
		if (_spKnobTransform != null)
		{
			_spKnobTransform!.X = GetEndAbsoluteOffset();
		}
	}

	public void OnTemplateRecycled()
	{
		IsOn = false;
	}

	internal void AutomationPeerToggle()
	{
		IsOn = !IsOn;
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool flag = false;
		bool flag2 = false;
		FocusState focusState = FocusState.Unfocused;
		base.ChangeVisualState(useTransitions);
		flag2 = base.IsEnabled;
		focusState = base.FocusState;
		if (!flag2)
		{
			GoToState(useTransitions, "Disabled");
		}
		else if (_isDragging)
		{
			GoToState(useTransitions, "Pressed");
		}
		else if (_isPointerOver)
		{
			GoToState(useTransitions, "PointerOver");
		}
		else
		{
			GoToState(useTransitions, "Normal");
		}
		if (focusState != FocusState.Unfocused && flag2)
		{
			if (focusState == FocusState.Pointer)
			{
				GoToState(useTransitions, "PointerFocused");
			}
			else
			{
				GoToState(useTransitions, "Focused");
			}
		}
		else
		{
			GoToState(useTransitions, "Unfocused");
		}
		if (_isDragging)
		{
			GoToState(useTransitions, "Dragging");
			return;
		}
		flag = IsOn;
		GoToState(useTransitions, flag ? "On" : "Off");
		GoToState(useTransitions, flag ? "OnContent" : "OffContent");
		ForceSwitchKnobEndPosition();
	}

	protected override void OnApplyTemplate()
	{
		if (_tpThumb != null)
		{
			_dragStarted.Disposable = null;
			_dragDelta.Disposable = null;
			_dragCompleted.Disposable = null;
			_tap.Disposable = null;
		}
		if (_tpKnob != null)
		{
			_knobSizeChanged.Disposable = null;
		}
		if (_tpKnobBounds != null)
		{
			_knobBoundsSizeChanged.Disposable = null;
		}
		_tpCurtainBounds = null;
		_tpCurtainClip = null;
		_spCurtainTransform = null;
		_tpKnob = null;
		_tpKnobBounds = null;
		_spKnobTransform = null;
		_tpThumb = null;
		_tpHeaderPresenter = null;
		base.OnApplyTemplate();
		DependencyObject templateChild = GetTemplateChild("SwitchCurtain");
		DependencyObject templateChild2 = GetTemplateChild("SwitchCurtainBounds");
		DependencyObject templateChild3 = GetTemplateChild("SwitchCurtainClip");
		DependencyObject templateChild4 = GetTemplateChild("SwitchKnob");
		DependencyObject templateChild5 = GetTemplateChild("SwitchKnobBounds");
		DependencyObject templateChild6 = GetTemplateChild("SwitchThumb");
		_tpCurtainBounds = templateChild2 as FrameworkElement;
		_tpCurtainClip = templateChild3 as UIElement;
		_tpKnob = templateChild4 as FrameworkElement;
		_tpKnobBounds = templateChild5 as FrameworkElement;
		_tpThumb = templateChild6 as Thumb;
		UIElement spThumbIUIElement = _tpThumb;
		if (templateChild is UIElement uIElement)
		{
			Transform renderTransform = uIElement.RenderTransform;
			_spCurtainTransform = renderTransform as TranslateTransform;
		}
		if (templateChild4 is UIElement uIElement2)
		{
			Transform renderTransform2 = uIElement2.RenderTransform;
			_spKnobTransform = renderTransform2 as TranslateTransform;
		}
		if (spThumbIUIElement != null && _tpThumb != null)
		{
			_tpThumb!.DragStarted += DragStartedHandler;
			_dragStarted.Disposable = Disposable.Create(delegate
			{
				_tpThumb!.DragStarted -= DragStartedHandler;
			});
			_tpThumb!.DragDelta += DragDeltaHandler;
			_dragDelta.Disposable = Disposable.Create(delegate
			{
				_tpThumb!.DragDelta -= DragDeltaHandler;
			});
			_tpThumb!.DragCompleted += DragCompletedHandler;
			_dragCompleted.Disposable = Disposable.Create(delegate
			{
				_tpThumb!.DragCompleted -= DragCompletedHandler;
			});
			spThumbIUIElement.Tapped += TapHandler;
			_tap.Disposable = Disposable.Create(delegate
			{
				spThumbIUIElement.Tapped -= TapHandler;
			});
		}
		if (_tpKnob != null || _tpKnobBounds != null)
		{
			if (_tpKnob != null)
			{
				_tpKnob!.SizeChanged += SizeChangedHandler;
				_knobSizeChanged.Disposable = Disposable.Create(delegate
				{
					_tpKnob!.SizeChanged -= SizeChangedHandler;
				});
			}
			if (_tpKnobBounds != null)
			{
				_tpKnobBounds!.SizeChanged += SizeChangedHandler;
				_knobBoundsSizeChanged.Disposable = Disposable.Create(delegate
				{
					_tpKnobBounds!.SizeChanged -= SizeChangedHandler;
				});
			}
		}
		UpdateHeaderPresenterVisibility();
		UpdateVisualState(useTransitions: false);
	}

	private void PrepareState()
	{
		TemplateSettings = new ToggleSwitchTemplateSettings();
	}

	private bool GetDefaultValue2(DependencyProperty dependencyProperty, out object? value)
	{
		DXamlCore current = DXamlCore.Current;
		if (dependencyProperty == OnContentProperty)
		{
			string text = (string)(value = current.GetLocalizedResourceString("ToggleSwitchOnContent"));
			return true;
		}
		if (dependencyProperty == OffContentProperty)
		{
			string text2 = (string)(value = current.GetLocalizedResourceString("ToggleSwitchOffContent"));
			return true;
		}
		value = null;
		return false;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		bool flag = false;
		base.OnPropertyChanged2(args);
		if (args.Property == IsOnProperty)
		{
			OnToggled();
			if (AutomationPeer.ListenerExistsHelper(AutomationEvents.PropertyChanged))
			{
				AutomationPeer orCreateAutomationPeer = GetOrCreateAutomationPeer();
				if (orCreateAutomationPeer != null && orCreateAutomationPeer is ToggleSwitchAutomationPeer toggleSwitchAutomationPeer)
				{
					toggleSwitchAutomationPeer.RaiseToggleStatePropertyChangedEvent(args.OldValue, args.NewValue);
				}
			}
		}
		else if (args.Property == HeaderProperty)
		{
			UpdateHeaderPresenterVisibility();
			OnHeaderChanged(args.OldValue, args.NewValue);
		}
		else if (args.Property == HeaderTemplateProperty)
		{
			UpdateHeaderPresenterVisibility();
		}
		else if (args.Property == OffContentProperty)
		{
			OnOffContentChanged(args.OldValue, args.NewValue);
		}
		else if (args.Property == OnContentProperty)
		{
			OnOnContentChanged(args.OldValue, args.NewValue);
		}
		else if (args.Property == UIElement.VisibilityProperty)
		{
			OnVisibilityChanged();
		}
	}

	private void GetTranslations()
	{
		if (_spKnobTransform != null)
		{
			_knobTranslation = _spKnobTransform!.X;
		}
		if (_spCurtainTransform != null)
		{
			_curtainTranslation = _spCurtainTransform!.X;
		}
	}

	private void SetTranslations()
	{
		double num = 0.0;
		ToggleSwitchTemplateSettings templateSettings = TemplateSettings;
		if (_spKnobTransform != null)
		{
			num = Math.Min(_knobTranslation, _maxKnobTranslation);
			num = Math.Max(num, _minKnobTranslation);
			_spKnobTransform!.X = num;
			if (templateSettings != null)
			{
				templateSettings.KnobCurrentToOffOffset = num - _minKnobTranslation;
				templateSettings.KnobCurrentToOnOffset = num - _maxKnobTranslation;
			}
		}
		if (_spCurtainTransform != null)
		{
			num = Math.Min(_curtainTranslation, _maxCurtainTranslation);
			num = Math.Max(num, _minCurtainTranslation);
			_spCurtainTransform!.X = num;
			if (templateSettings != null)
			{
				templateSettings.CurtainCurrentToOffOffset = num - _minCurtainTranslation;
				templateSettings.CurtainCurrentToOnOffset = num - _maxCurtainTranslation;
			}
		}
	}

	private void ClearTranslations()
	{
		if (_spKnobTransform != null)
		{
			_spKnobTransform!.ClearValue(TranslateTransform.XProperty);
		}
		if (_spCurtainTransform != null)
		{
			_spCurtainTransform!.ClearValue(TranslateTransform.XProperty);
		}
	}

	private void Toggle()
	{
		bool isOn = IsOn;
		IsOn = !isOn;
		ElementSoundPlayerService.RequestInteractionSoundForElementStatic(ElementSoundKind.Invoke, this);
	}

	private void AutomationToggleSwitchOnToggle()
	{
		Toggle();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new ToggleSwitchAutomationPeer(this);
	}

	private void MoveDelta(double translationDelta)
	{
		_curtainTranslation += translationDelta;
		_knobTranslation += translationDelta;
		SetTranslations();
	}

	private void MoveCompleted(bool wasMoved)
	{
		bool flag = false;
		if (wasMoved)
		{
			double num = (_maxKnobTranslation - _minKnobTranslation) / 2.0;
			flag = (IsOn ? (_knobTranslation <= num) : (_knobTranslation >= num));
		}
		ClearTranslations();
		if (flag)
		{
			Toggle();
		}
		else
		{
			UpdateVisualState();
		}
	}

	protected virtual void OnToggled()
	{
		RoutedEventArgs routedEventArgs = new RoutedEventArgs();
		routedEventArgs.OriginalSource = this;
		this.Toggled?.Invoke(this, routedEventArgs);
		if (!_isDragging)
		{
			UpdateVisualState();
		}
	}

	protected virtual void OnHeaderChanged(object oldContent, object newContent)
	{
	}

	protected virtual void OnOffContentChanged(object oldContent, object newContent)
	{
	}

	protected virtual void OnOnContentChanged(object oldContent, object newContent)
	{
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		base.OnGotFocus(e);
		FocusChanged();
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		base.OnLostFocus(e);
		FocusChanged();
	}

	private void FocusChanged()
	{
		UpdateVisualState();
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs e)
	{
		base.OnPointerEntered(e);
		_isPointerOver = true;
		UpdateVisualState();
	}

	protected override void OnPointerExited(PointerRoutedEventArgs e)
	{
		base.OnPointerExited(e);
		_isPointerOver = false;
		UpdateVisualState();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs e)
	{
		base.OnPointerCaptureLost(e);
		if (!_isDragging)
		{
			_isPointerOver = false;
		}
		UpdateVisualState();
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		if (!args.Handled && !_isDragging)
		{
			VirtualKey originalKey = args.OriginalKey;
			bool handledKeyDown = (args.Handled = KeyProcess.KeyDown(originalKey, this));
			_handledKeyDown = handledKeyDown;
		}
	}

	protected override void OnKeyUp(KeyRoutedEventArgs args)
	{
		base.OnKeyUp(args);
		VirtualKey originalKey = args.OriginalKey;
		bool handled = args.Handled;
		handled = (args.Handled = KeyProcess.KeyUp(originalKey, this));
	}

	private void DragStartedHandler(object sender, DragStartedEventArgs args)
	{
		bool flag = false;
		_isDragging = true;
		_wasDragged = false;
		flag = Focus(FocusState.Pointer);
		GetTranslations();
		UpdateVisualState();
		SetTranslations();
	}

	private void DragDeltaHandler(object sender, DragDeltaEventArgs args)
	{
		double horizontalChange = args.HorizontalChange;
		if (horizontalChange != 0.0)
		{
			_wasDragged = true;
			MoveDelta(horizontalChange);
		}
	}

	private void DragCompletedHandler(object sender, DragCompletedEventArgs args)
	{
		if (!args.Canceled)
		{
			_isDragging = false;
			MoveCompleted(_wasDragged);
		}
	}

	private void TapHandler(object sender, TappedRoutedEventArgs args)
	{
		if (!args.Handled)
		{
			Toggle();
			args.Handled = true;
		}
	}

	private void SizeChangedHandler(object sender, SizeChangedEventArgs args)
	{
		double num = 0.0;
		double num2 = 0.0;
		Rect rect = default(Rect);
		if (_tpCurtainBounds != null)
		{
			RectangleGeometry rectangleGeometry = new RectangleGeometry();
			num = _tpCurtainBounds!.ActualWidth;
			if (_tpCurtainClip != null)
			{
				num2 = _tpCurtainBounds!.ActualHeight;
				double num5 = (rect.X = (rect.Y = 0.0));
				rect.Width = num;
				rect.Height = num2;
				rectangleGeometry.Rect = rect;
				_tpCurtainClip!.Clip = rectangleGeometry;
			}
		}
		bool isOn = IsOn;
		if (_tpKnob != null && _tpKnobBounds != null && _spKnobTransform != null)
		{
			double x = _spKnobTransform!.X;
			double actualWidth = _tpKnobBounds!.ActualWidth;
			double actualWidth2 = _tpKnob!.ActualWidth;
			Thickness margin = _tpKnob!.Margin;
			if (isOn)
			{
				_maxKnobTranslation = x;
				_minKnobTranslation = _maxKnobTranslation - actualWidth + actualWidth2;
			}
			else
			{
				_minKnobTranslation = x;
				_maxKnobTranslation = _minKnobTranslation + actualWidth - actualWidth2;
			}
			if (margin.Left < 0.0)
			{
				_maxKnobTranslation -= margin.Left;
			}
			if (margin.Right < 0.0)
			{
				_maxKnobTranslation -= margin.Right;
			}
		}
		if (_tpCurtainBounds != null && _spCurtainTransform != null)
		{
			double x2 = _spCurtainTransform!.X;
			if (isOn)
			{
				_maxCurtainTranslation = x2;
				_minCurtainTranslation = _maxCurtainTranslation - num;
			}
			else
			{
				_minCurtainTranslation = x2;
				_maxCurtainTranslation = _minCurtainTranslation + num;
			}
		}
		ToggleSwitchTemplateSettings templateSettings = TemplateSettings;
		if (templateSettings != null)
		{
			ToggleSwitchTemplateSettings toggleSwitchTemplateSettings = templateSettings;
			toggleSwitchTemplateSettings.KnobOffToOnOffset = _minKnobTranslation - _maxKnobTranslation;
			toggleSwitchTemplateSettings.KnobOnToOffOffset = _maxKnobTranslation - _minKnobTranslation;
			toggleSwitchTemplateSettings.CurtainOffToOnOffset = _minCurtainTranslation - _maxCurtainTranslation;
			toggleSwitchTemplateSettings.CurtainOnToOffOffset = _maxCurtainTranslation - _minCurtainTranslation;
		}
	}

	private bool HandlesKey(VirtualKey key)
	{
		if (key != VirtualKey.Space)
		{
			return key == VirtualKey.GamepadA;
		}
		return true;
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		if (!base.IsEnabled)
		{
			_isDragging = false;
			_isPointerOver = false;
		}
		UpdateVisualState();
	}

	private void OnVisibilityChanged()
	{
		if (base.Visibility != 0)
		{
			_isDragging = false;
			_isPointerOver = false;
		}
		UpdateVisualState();
	}

	private void UpdateHeaderPresenterVisibility()
	{
		DataTemplate headerTemplate = HeaderTemplate;
		object header = Header;
		ConditionallyGetTemplatePartAndUpdateVisibility("HeaderContentPresenter", header != null || headerTemplate != null, ref _tpHeaderPresenter);
	}
}
