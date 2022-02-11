using System;
using Uno;
using Uno.Disposables;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls.Primitives;

[ContentProperty(Name = "Child")]
public class Popup : FrameworkElement, IPopup
{
	internal interface IDynamicPopupLayouter
	{
		Size Measure(Size available, Size visibleSize);

		void Arrange(Size finalSize, Rect visibleBounds, Size desiredSize, Point? upperLeftOffset = null);
	}

	private ManagedWeakReference _lastFocusedElement;

	private FocusState _lastFocusState;

	private IDisposable _openPopupRegistration;

	private bool _childHasOwnDataContext;

	private static readonly PointerEventHandler _handleIfOpened = delegate(object snd, PointerRoutedEventArgs e)
	{
		Popup popup2 = ((PopupPanel)snd).Popup;
		if (popup2.IsOpen && popup2.IsLightDismissEnabled)
		{
			e.Handled = true;
		}
	};

	private static readonly PointerEventHandler _handleIfOpenedAndTryDismiss = delegate(object snd, PointerRoutedEventArgs e)
	{
		Popup popup = ((PopupPanel)snd).Popup;
		if (popup.IsOpen && popup.IsLightDismissEnabled)
		{
			e.Handled = true;
			if (popup.Child is FrameworkElement frameworkElement)
			{
				Point position = e.GetCurrentPoint(frameworkElement).Position;
				if (position.X < 0.0 || position.X > frameworkElement.ActualWidth || position.Y < 0.0 || position.Y > frameworkElement.ActualHeight)
				{
					popup.IsOpen = false;
				}
			}
			else if (popup.Child == null)
			{
				popup.Log().Warn("Dismiss is not supported if the 'Child' is null.");
			}
			else
			{
				popup.Log().Warn($"Dismiss is not supported if the 'Child' ({popup.Child?.GetType()}) of the 'Popup' is not a 'FrameworkElement'.");
			}
		}
	};

	private readonly SerialDisposable _closePopup = new SerialDisposable();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TransitionCollection ChildTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(ChildTransitionsProperty);
		}
		set
		{
			SetValue(ChildTransitionsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ShouldConstrainToRootBounds
	{
		get
		{
			return (bool)GetValue(ShouldConstrainToRootBoundsProperty);
		}
		set
		{
			SetValue(ShouldConstrainToRootBoundsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsConstrainedToRootBounds
	{
		get
		{
			throw new NotImplementedException("The member bool Popup.IsConstrainedToRootBounds is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ChildTransitionsProperty { get; } = DependencyProperty.Register("ChildTransitions", typeof(TransitionCollection), typeof(Popup), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShouldConstrainToRootBoundsProperty { get; } = DependencyProperty.Register("ShouldConstrainToRootBounds", typeof(bool), typeof(Popup), new FrameworkPropertyMetadata(false));


	internal IDynamicPopupLayouter CustomLayouter { get; set; }

	bool IPopup.IsOpen
	{
		get
		{
			return IsOpen;
		}
		set
		{
			IsOpen = value;
		}
	}

	UIElement IPopup.Child
	{
		get
		{
			return Child;
		}
		set
		{
			Child = value;
		}
	}

	internal UIElement Anchor { get; set; }

	internal bool IsSubMenu { get; set; }

	internal bool IsForFlyout { get; set; }

	private protected override bool IsTabStopDefaultValue => true;

	private bool ShouldShowLightDismissOverlay => LightDismissOverlayMode switch
	{
		LightDismissOverlayMode.Auto => false, 
		LightDismissOverlayMode.On => true, 
		LightDismissOverlayMode.Off => false, 
		_ => throw new InvalidOperationException(string.Format("Invalid value {0} for {1}", LightDismissOverlayMode, "LightDismissOverlayMode")), 
	};

	internal PopupPanel PopupPanel
	{
		get
		{
			return (PopupPanel)GetValue(PopupPanelProperty);
		}
		set
		{
			SetValue(PopupPanelProperty, value);
		}
	}

	public static DependencyProperty PopupPanelProperty { get; } = DependencyProperty.Register("PopupPanel", typeof(PopupPanel), typeof(Popup), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnPopupPanelChanged((PopupPanel)e.OldValue, (PopupPanel)e.NewValue);
	}));


	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(Popup), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Popup)o).ApplyLightDismissOverlayMode();
	}));


	internal Brush LightDismissOverlayBackground
	{
		get
		{
			return (Brush)GetValue(LightDismissOverlayBackgroundProperty);
		}
		set
		{
			SetValue(LightDismissOverlayBackgroundProperty, value);
		}
	}

	internal static DependencyProperty LightDismissOverlayBackgroundProperty { get; } = DependencyProperty.Register("LightDismissOverlayBackground", typeof(Brush), typeof(Popup), new FrameworkPropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((Popup)o).ApplyLightDismissOverlayMode();
	}));


	public bool IsOpen
	{
		get
		{
			return (bool)GetValue(IsOpenProperty);
		}
		set
		{
			SetValue(IsOpenProperty, value);
		}
	}

	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(Popup), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public UIElement Child
	{
		get
		{
			return (UIElement)GetValue(ChildProperty);
		}
		set
		{
			SetValue(ChildProperty, value);
		}
	}

	public static DependencyProperty ChildProperty { get; } = DependencyProperty.Register("Child", typeof(UIElement), typeof(Popup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueInheritsDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnChildChanged((UIElement)e.OldValue, (UIElement)e.NewValue);
	}));


	public bool IsLightDismissEnabled
	{
		get
		{
			return (bool)GetValue(IsLightDismissEnabledProperty);
		}
		set
		{
			SetValue(IsLightDismissEnabledProperty, value);
		}
	}

	public static DependencyProperty IsLightDismissEnabledProperty { get; } = DependencyProperty.Register("IsLightDismissEnabled", typeof(bool), typeof(Popup), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnIsLightDismissEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public double HorizontalOffset
	{
		get
		{
			return (double)GetValue(HorizontalOffsetProperty);
		}
		set
		{
			SetValue(HorizontalOffsetProperty, value);
		}
	}

	public static DependencyProperty HorizontalOffsetProperty { get; } = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(Popup), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnHorizontalOffsetChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public double VerticalOffset
	{
		get
		{
			return (double)GetValue(VerticalOffsetProperty);
		}
		set
		{
			SetValue(VerticalOffsetProperty, value);
		}
	}

	public static DependencyProperty VerticalOffsetProperty { get; } = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(Popup), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Popup)s)?.OnVerticalOffsetChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public event EventHandler<object> Closed;

	public event EventHandler<object> Opened;

	event EventHandler<object> IPopup.Closed
	{
		add
		{
			Closed += value;
		}
		remove
		{
			Closed -= value;
		}
	}

	event EventHandler<object> IPopup.Opened
	{
		add
		{
			Opened += value;
		}
		remove
		{
			Opened -= value;
		}
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == FrameworkElement.AllowFocusOnInteractionProperty || args.Property == FrameworkElement.AllowFocusWhenDisabledProperty)
		{
			PropagateFocusProperties();
		}
		base.OnPropertyChanged2(args);
	}

	private protected override void OnUnloaded()
	{
		IsOpen = false;
		base.OnUnloaded();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		return new Size(base.Width, base.Height).FiniteOrDefault(default(Size));
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		return finalSize;
	}

	private void HandlePointerEvent(object sender, PointerRoutedEventArgs e)
	{
		e.Handled = true;
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		UpdateDataContext(e);
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		UpdateTemplatedParent();
	}

	private void UpdateDataContext(DependencyPropertyChangedEventArgs e)
	{
		_childHasOwnDataContext = false;
		IDependencyObjectStoreProvider child = Child;
		if (child != null)
		{
			object obj = child.Store.ReadLocalValue(child.Store.DataContextProperty);
			if (e != null && e.NewValue == null && obj == e.OldValue)
			{
				child.Store.ClearValue(child.Store.DataContextProperty, DependencyPropertyValuePrecedences.Local);
			}
			else if (obj != null && obj != DependencyProperty.UnsetValue)
			{
				_childHasOwnDataContext = true;
			}
			else
			{
				child.Store.SetValue(child.Store.DataContextProperty, base.DataContext, DependencyPropertyValuePrecedences.Local);
			}
		}
	}

	private void UpdateTemplatedParent()
	{
		IDependencyObjectStoreProvider child = Child;
		child?.Store.SetValue(child.Store.TemplatedParentProperty, base.TemplatedParent, DependencyPropertyValuePrecedences.Local);
	}

	private void PropagateFocusProperties()
	{
		IDependencyObjectStoreProvider child = Child;
		if (child != null)
		{
			child.Store.SetValue(FrameworkElement.AllowFocusOnInteractionProperty, base.AllowFocusOnInteraction, DependencyPropertyValuePrecedences.Local);
			child.Store.SetValue(FrameworkElement.AllowFocusWhenDisabledProperty, base.AllowFocusWhenDisabled, DependencyPropertyValuePrecedences.Local);
		}
	}

	public Popup()
	{
		Initialize();
	}

	private void Initialize()
	{
		InitializePartial();
		ResourceResolver.ApplyResource(this, LightDismissOverlayBackgroundProperty, "PopupLightDismissOverlayBackground", isThemeResourceExtension: true, isHotReloadSupported: true);
		ApplyLightDismissOverlayMode();
	}

	private void InitializePartial()
	{
		PopupPanel = new PopupPanel(this);
	}

	private void OnPopupPanelChanged(PopupPanel oldHost, PopupPanel newHost)
	{
		if (oldHost != null)
		{
			oldHost.PointerPressed -= _handleIfOpenedAndTryDismiss;
			oldHost.PointerEntered -= _handleIfOpened;
			oldHost.PointerExited -= _handleIfOpened;
			oldHost.PointerMoved -= _handleIfOpened;
			oldHost.PointerReleased -= _handleIfOpened;
			oldHost.PointerCanceled -= _handleIfOpened;
			oldHost.PointerCaptureLost -= _handleIfOpened;
			oldHost.PointerWheelChanged -= _handleIfOpened;
		}
		if (newHost != null)
		{
			newHost.PointerPressed += _handleIfOpenedAndTryDismiss;
			newHost.PointerEntered += _handleIfOpened;
			newHost.PointerExited += _handleIfOpened;
			newHost.PointerMoved += _handleIfOpened;
			newHost.PointerReleased += _handleIfOpened;
			newHost.PointerCanceled += _handleIfOpened;
			newHost.PointerCaptureLost += _handleIfOpened;
			newHost.PointerWheelChanged += _handleIfOpened;
		}
		OnPopupPanelChangedPartial(oldHost, newHost);
		ApplyLightDismissOverlayMode();
	}

	private void OnPopupPanelChangedPartial(PopupPanel previousPanel, PopupPanel newPanel)
	{
		previousPanel?.Children.Clear();
		if (newPanel != null)
		{
			if (Child != null)
			{
				newPanel.Children.Add(Child);
			}
			newPanel.Background = GetPanelBackground();
		}
	}

	internal override void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		base.UpdateThemeBindings(updateReason);
		Application.PropagateResourcesChanged(Child, updateReason);
	}

	private void ApplyLightDismissOverlayMode()
	{
		if (PopupPanel != null)
		{
			PopupPanel.Background = GetPanelBackground();
		}
	}

	private Brush GetPanelBackground()
	{
		if (ShouldShowLightDismissOverlay)
		{
			return LightDismissOverlayBackground;
		}
		if (IsLightDismissEnabled)
		{
			return SolidColorBrushHelper.Transparent;
		}
		return null;
	}

	internal bool OnClosing()
	{
		return false;
	}

	protected virtual void OnIsOpenChanged(bool oldIsOpen, bool newIsOpen)
	{
		OnIsOpenChangedPartial(oldIsOpen, newIsOpen);
		OnIsOpenChangedPartialNative(oldIsOpen, newIsOpen);
	}

	private void OnIsOpenChangedPartial(bool oldIsOpen, bool newIsOpen)
	{
		if (newIsOpen)
		{
			_openPopupRegistration = VisualTreeHelper.RegisterOpenPopup(this);
			if (IsLightDismissEnabled)
			{
				FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
				UIElement uIElement = focusManagerForElement?.FocusedElement as UIElement;
				FocusState focusState = focusManagerForElement?.GetRealFocusStateForFocusedElement() ?? FocusState.Unfocused;
				if (uIElement != null && focusState != 0)
				{
					_lastFocusedElement = WeakReferencePool.RentWeakReference(this, uIElement);
					_lastFocusState = focusState;
				}
				if (Child is FrameworkElement frameworkElement && frameworkElement.AllowFocusOnInteraction)
				{
					Focus(FocusState.Programmatic);
				}
			}
			this.Opened?.Invoke(this, newIsOpen);
		}
		else
		{
			_openPopupRegistration?.Dispose();
			if (IsLightDismissEnabled && _lastFocusedElement != null && _lastFocusedElement.Target is UIElement uIElement2)
			{
				uIElement2.Focus(_lastFocusState);
				_lastFocusedElement = null;
			}
			this.Closed?.Invoke(this, newIsOpen);
		}
	}

	private void OnIsOpenChangedPartialNative(bool oldIsOpen, bool newIsOpen)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Popup.IsOpenChanged({oldIsOpen}, {newIsOpen})");
		}
		if (newIsOpen)
		{
			_closePopup.Disposable = Window.Current.OpenPopup(this);
			PopupPanel.Visibility = Visibility.Visible;
		}
		else
		{
			_closePopup.Disposable = null;
			PopupPanel.Visibility = Visibility.Collapsed;
		}
	}

	protected virtual void OnChildChanged(UIElement oldChild, UIElement newChild)
	{
		OnChildChangedPartial(oldChild, newChild);
		OnChildChangedPartialNative(oldChild, newChild);
	}

	private void OnChildChangedPartial(UIElement oldChild, UIElement newChild)
	{
		if (oldChild != null && !_childHasOwnDataContext)
		{
			((IDependencyObjectStoreProvider)oldChild).Store.ClearValue(((IDependencyObjectStoreProvider)oldChild).Store.DataContextProperty, DependencyPropertyValuePrecedences.Local);
			((IDependencyObjectStoreProvider)oldChild).Store.ClearValue(((IDependencyObjectStoreProvider)oldChild).Store.TemplatedParentProperty, DependencyPropertyValuePrecedences.Local);
			((IDependencyObjectStoreProvider)oldChild).Store.ClearValue(FrameworkElement.AllowFocusOnInteractionProperty, DependencyPropertyValuePrecedences.Local);
			((IDependencyObjectStoreProvider)oldChild).Store.ClearValue(FrameworkElement.AllowFocusWhenDisabledProperty, DependencyPropertyValuePrecedences.Local);
		}
		UpdateDataContext(null);
		UpdateTemplatedParent();
		PropagateFocusProperties();
		if (oldChild is FrameworkElement frameworkElement)
		{
			frameworkElement.PointerPressed -= HandlePointerEvent;
			frameworkElement.PointerReleased -= HandlePointerEvent;
		}
		if (newChild is FrameworkElement frameworkElement2)
		{
			frameworkElement2.PointerPressed += HandlePointerEvent;
			frameworkElement2.PointerReleased += HandlePointerEvent;
		}
	}

	private void OnChildChangedPartialNative(UIElement oldChild, UIElement newChild)
	{
		PopupPanel.Children.Remove(oldChild);
		if (newChild != null)
		{
			PopupPanel.Children.Add(newChild);
		}
	}

	protected virtual void OnIsLightDismissEnabledChanged(bool oldIsLightDismissEnabled, bool newIsLightDismissEnabled)
	{
		OnIsLightDismissEnabledChangedPartial(oldIsLightDismissEnabled, newIsLightDismissEnabled);
		OnIsLightDismissEnabledChangedPartialNative(oldIsLightDismissEnabled, newIsLightDismissEnabled);
	}

	private void OnIsLightDismissEnabledChangedPartial(bool oldIsLightDismissEnabled, bool newIsLightDismissEnabled)
	{
	}

	private void OnIsLightDismissEnabledChangedPartialNative(bool oldIsLightDismissEnabled, bool newIsLightDismissEnabled)
	{
		if (PopupPanel != null)
		{
			PopupPanel.Background = GetPanelBackground();
		}
	}

	protected virtual void OnHorizontalOffsetChanged(double oldHorizontalOffset, double newHorizontalOffset)
	{
		OnHorizontalOffsetChangedPartial(oldHorizontalOffset, newHorizontalOffset);
	}

	private void OnHorizontalOffsetChangedPartial(double oldHorizontalOffset, double newHorizontalOffset)
	{
		PopupPanel?.InvalidateMeasure();
	}

	protected virtual void OnVerticalOffsetChanged(double oldVerticalOffset, double newVerticalOffset)
	{
		OnVerticalOffsetChangedPartial(oldVerticalOffset, newVerticalOffset);
	}

	private void OnVerticalOffsetChangedPartial(double oldVerticalOffset, double newVerticalOffset)
	{
		PopupPanel?.InvalidateMeasure();
	}
}
