using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Input;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls.Primitives;

[Windows.UI.Xaml.Data.Bindable]
public class FlyoutBase : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	internal enum MajorPlacementMode
	{
		Top,
		Bottom,
		Left,
		Right,
		Full
	}

	internal enum PreferredJustification
	{
		Center,
		Top,
		Bottom,
		Left,
		Right
	}

	private bool _isOpen;

	internal bool m_isPositionedAtPoint;

	protected internal Popup _popup;

	private bool _isLightDismissEnabled = true;

	private readonly SerialDisposable _sizeChangedDisposable = new SerialDisposable();

	private bool m_hasPlacementOverride;

	private FlyoutPlacementMode m_placementOverride;

	private bool m_isTargetPositionSet;

	private Point m_targetPoint;

	private bool m_isPositionedForDateTimePicker;

	[NotImplemented]
	private InputDeviceType m_inputDeviceTypeUsedToOpen;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private bool _AllowFocusWhenDisabledPropertyBackingFieldSet;

	private bool _AllowFocusWhenDisabledPropertyBackingField;

	private bool _AllowFocusOnInteractionPropertyBackingFieldSet;

	private bool _AllowFocusOnInteractionPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ElementSoundMode ElementSoundMode
	{
		get
		{
			return (ElementSoundMode)GetValue(ElementSoundModeProperty);
		}
		set
		{
			SetValue(ElementSoundModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject OverlayInputPassThroughElement
	{
		get
		{
			return (DependencyObject)GetValue(OverlayInputPassThroughElementProperty);
		}
		set
		{
			SetValue(OverlayInputPassThroughElementProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlyoutShowMode ShowMode
	{
		get
		{
			return (FlyoutShowMode)GetValue(ShowModeProperty);
		}
		set
		{
			SetValue(ShowModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool AreOpenCloseAnimationsEnabled
	{
		get
		{
			return (bool)GetValue(AreOpenCloseAnimationsEnabledProperty);
		}
		set
		{
			SetValue(AreOpenCloseAnimationsEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool InputDevicePrefersPrimaryCommands => (bool)GetValue(InputDevicePrefersPrimaryCommandsProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsOpen => (bool)GetValue(IsOpenProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public XamlRoot XamlRoot
	{
		get
		{
			throw new NotImplementedException("The member XamlRoot FlyoutBase.XamlRoot is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.FlyoutBase", "XamlRoot FlyoutBase.XamlRoot");
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
			throw new NotImplementedException("The member bool FlyoutBase.IsConstrainedToRootBounds is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AttachedFlyoutProperty { get; } = DependencyProperty.RegisterAttached("AttachedFlyout", typeof(FlyoutBase), typeof(FlyoutBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ElementSoundModeProperty { get; } = DependencyProperty.Register("ElementSoundMode", typeof(ElementSoundMode), typeof(FlyoutBase), new FrameworkPropertyMetadata(ElementSoundMode.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OverlayInputPassThroughElementProperty { get; } = DependencyProperty.Register("OverlayInputPassThroughElement", typeof(DependencyObject), typeof(FlyoutBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AreOpenCloseAnimationsEnabledProperty { get; } = DependencyProperty.Register("AreOpenCloseAnimationsEnabled", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty InputDevicePrefersPrimaryCommandsProperty { get; } = DependencyProperty.Register("InputDevicePrefersPrimaryCommands", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsOpenProperty { get; } = DependencyProperty.Register("IsOpen", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShowModeProperty { get; } = DependencyProperty.Register("ShowMode", typeof(FlyoutShowMode), typeof(FlyoutBase), new FrameworkPropertyMetadata(FlyoutShowMode.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetProperty { get; } = DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(FlyoutBase), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShouldConstrainToRootBoundsProperty { get; } = DependencyProperty.Register("ShouldConstrainToRootBounds", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata(false));


	internal bool IsTargetPositionSet => m_isTargetPositionSet;

	internal FlyoutPlacementMode EffectivePlacement
	{
		get
		{
			if (!m_hasPlacementOverride)
			{
				return Placement;
			}
			return m_placementOverride;
		}
	}

	public bool UseNativePopup { get; set; } = !FeatureConfiguration.Style.UseUWPDefaultStyles;


	private protected bool IsLightDismissOverlayEnabled
	{
		get
		{
			return _isLightDismissEnabled;
		}
		set
		{
			_isLightDismissEnabled = value;
			if (_popup != null)
			{
				_popup.IsLightDismissEnabled = value;
			}
		}
	}

	public FlyoutPlacementMode Placement
	{
		get
		{
			return (FlyoutPlacementMode)GetValue(PlacementProperty);
		}
		set
		{
			SetValue(PlacementProperty, value);
		}
	}

	public static DependencyProperty PlacementProperty { get; } = DependencyProperty.Register("Placement", typeof(FlyoutPlacementMode), typeof(FlyoutBase), new FrameworkPropertyMetadata(FlyoutPlacementMode.Top));


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

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(FlyoutBase), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


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

	internal static DependencyProperty LightDismissOverlayBackgroundProperty { get; } = DependencyProperty.Register("LightDismissOverlayBackground", typeof(Brush), typeof(FlyoutBase), new FrameworkPropertyMetadata(null));


	public bool AllowFocusWhenDisabled
	{
		get
		{
			return GetAllowFocusWhenDisabledValue();
		}
		set
		{
			SetAllowFocusWhenDisabledValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false, Options = FrameworkPropertyMetadataOptions.Inherits, ChangedCallback = true)]
	public static DependencyProperty AllowFocusWhenDisabledProperty { get; } = CreateAllowFocusWhenDisabledProperty();


	public bool AllowFocusOnInteraction
	{
		get
		{
			return GetAllowFocusOnInteractionValue();
		}
		set
		{
			SetAllowFocusOnInteractionValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = true, Options = FrameworkPropertyMetadataOptions.Inherits, ChangedCallback = true)]
	public static DependencyProperty AllowFocusOnInteractionProperty { get; } = CreateAllowFocusOnInteractionProperty();


	public FrameworkElement Target { get; private set; }

	internal Point? PopupPositionInTarget
	{
		get
		{
			if (!m_isPositionedAtPoint)
			{
				return null;
			}
			return m_targetPoint;
		}
	}

	internal bool UsePickerFlyoutTheme { get; set; }

	public CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(FlyoutBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FlyoutBase)s).OnDataContextChanged(e);
	}));


	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(FlyoutBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FlyoutBase)s).OnTemplatedParentChanged(e);
	}));


	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	public event EventHandler<object> Opened;

	public event EventHandler<object> Closed;

	public event EventHandler<object> Opening;

	public event TypedEventHandler<FlyoutBase, FlyoutBaseClosingEventArgs> Closing;

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void TryInvokeKeyboardAccelerator(ProcessKeyboardAcceleratorEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.FlyoutBase", "void FlyoutBase.TryInvokeKeyboardAccelerator(ProcessKeyboardAcceleratorEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnProcessKeyboardAccelerators(ProcessKeyboardAcceleratorEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Primitives.FlyoutBase", "void FlyoutBase.OnProcessKeyboardAccelerators(ProcessKeyboardAcceleratorEventArgs args)");
	}

	protected FlyoutBase()
	{
	}

	private void EnsurePopupCreated()
	{
		if (_popup == null)
		{
			ResourceResolver.ApplyResource(this, LightDismissOverlayBackgroundProperty, "FlyoutLightDismissOverlayBackground", isThemeResourceExtension: true, isHotReloadSupported: true);
			Control child = CreatePresenter();
			_popup = new Popup
			{
				Child = child,
				IsLightDismissEnabled = _isLightDismissEnabled,
				IsForFlyout = true
			};
			SynchronizePropertyToPopup(UIElement.TemplatedParentProperty, TemplatedParent);
			_popup.Opened += OnPopupOpened;
			_popup.Closed += OnPopupClosed;
			_popup.BindToEquivalentProperty(this, "LightDismissOverlayMode");
			_popup.BindToEquivalentProperty(this, "LightDismissOverlayBackground");
			InitializePopupPanel();
			SynchronizePropertyToPopup(UIElement.DataContextProperty, DataContext);
			SynchronizePropertyToPopup(FrameworkElement.AllowFocusOnInteractionProperty, AllowFocusOnInteraction);
			SynchronizePropertyToPopup(FrameworkElement.AllowFocusWhenDisabledProperty, AllowFocusWhenDisabled);
		}
	}

	protected virtual void InitializePopupPanel()
	{
		InitializePopupPanelPartial();
	}

	private void InitializePopupPanelPartial()
	{
		_popup.PopupPanel = new FlyoutBasePopupPanel(this)
		{
			Visibility = Visibility.Collapsed,
			Background = SolidColorBrushHelper.Transparent
		};
	}

	private void OnPopupOpened(object sender, object e)
	{
		UIElement child2 = _popup.Child;
		FrameworkElement child = child2 as FrameworkElement;
		if (child != null)
		{
			SizeChangedEventHandler handler = delegate
			{
				SetPopupPositionPartial(Target, PopupPositionInTarget);
			};
			child.SizeChanged += handler;
			_sizeChangedDisposable.Disposable = Disposable.Create(delegate
			{
				child.SizeChanged -= handler;
			});
		}
	}

	private void OnAllowFocusWhenDisabledChanged(bool oldValue, bool newValue)
	{
		SynchronizePropertyToPopup(FrameworkElement.AllowFocusWhenDisabledProperty, AllowFocusWhenDisabled);
	}

	private void OnAllowFocusOnInteractionChanged(bool oldValue, bool newValue)
	{
		SynchronizePropertyToPopup(FrameworkElement.AllowFocusOnInteractionProperty, AllowFocusOnInteraction);
	}

	public void Hide()
	{
		Hide(canCancel: true);
	}

	internal void Hide(bool canCancel)
	{
		if (!_isOpen)
		{
			return;
		}
		if (canCancel)
		{
			bool cancel = false;
			OnClosing(ref cancel);
			FlyoutBaseClosingEventArgs flyoutBaseClosingEventArgs = new FlyoutBaseClosingEventArgs();
			this.Closing?.Invoke(this, flyoutBaseClosingEventArgs);
			if (cancel || flyoutBaseClosingEventArgs.Cancel)
			{
				return;
			}
		}
		Close();
		_isOpen = false;
		OnClosed();
		this.Closed?.Invoke(this, EventArgs.Empty);
	}

	public void ShowAt(FrameworkElement placementTarget)
	{
		ShowAtCore(placementTarget, null);
	}

	public void ShowAt(DependencyObject placementTarget, FlyoutShowOptions showOptions)
	{
		if (placementTarget is FrameworkElement placementTarget2)
		{
			ShowAtCore(placementTarget2, showOptions);
		}
	}

	private protected virtual void ShowAtCore(FrameworkElement placementTarget, FlyoutShowOptions showOptions)
	{
		EnsurePopupCreated();
		m_hasPlacementOverride = false;
		if (_isOpen)
		{
			if (placementTarget == Target)
			{
				return;
			}
			Hide(canCancel: false);
		}
		Target = placementTarget;
		if (showOptions != null)
		{
			Point? position = showOptions.Position;
			if (position.HasValue)
			{
				Point point = position.GetValueOrDefault();
				m_isPositionedAtPoint = true;
				if (placementTarget != null)
				{
					UIElement visual = null;
					GeneralTransform generalTransform = placementTarget.TransformToVisual(visual);
					point = generalTransform.TransformPoint(point);
				}
				if (double.IsNaN(point.X) || double.IsNaN(point.Y))
				{
					throw new ArgumentException("Invalid flyout position");
				}
				SetTargetPosition(point);
			}
			if (showOptions.Placement != FlyoutPlacementMode.Auto)
			{
				m_hasPlacementOverride = true;
				m_placementOverride = showOptions.Placement;
			}
		}
		OnOpening();
		this.Opening?.Invoke(this, EventArgs.Empty);
		Open();
		_isOpen = true;
		Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			if (_isOpen)
			{
				OnOpened();
				this.Opened?.Invoke(this, EventArgs.Empty);
			}
		});
	}

	private void SetTargetPosition(Point targetPoint)
	{
		m_isTargetPositionSet = true;
		m_targetPoint = targetPoint;
	}

	private void ApplyTargetPosition()
	{
		if (m_isTargetPositionSet && _popup != null)
		{
			_popup.HorizontalOffset = m_targetPoint.X;
			_popup.VerticalOffset = m_targetPoint.Y;
		}
	}

	private protected virtual void OnOpening()
	{
	}

	private protected virtual void OnClosing(ref bool cancel)
	{
	}

	private protected virtual void OnClosed()
	{
		m_isTargetPositionSet = false;
	}

	private protected virtual void OnOpened()
	{
	}

	protected virtual Control CreatePresenter()
	{
		return null;
	}

	private void OnPopupClosed(object sender, object e)
	{
		Hide(canCancel: false);
		_sizeChangedDisposable.Disposable = null;
	}

	protected internal virtual void Close()
	{
		if (_popup != null)
		{
			_popup.IsOpen = false;
		}
	}

	protected internal virtual void Open()
	{
		EnsurePopupCreated();
		SetPopupPositionPartial(Target, PopupPositionInTarget);
		ApplyTargetPosition();
		_popup.IsOpen = true;
	}

	private void SetPopupPositionPartial(UIElement placementTarget, Point? positionInTarget)
	{
		_popup.Anchor = placementTarget;
		if (positionInTarget.HasValue)
		{
			Point valueOrDefault = positionInTarget.GetValueOrDefault();
			_popup.HorizontalOffset = valueOrDefault.X;
			_popup.VerticalOffset = valueOrDefault.Y;
		}
	}

	private void SynchronizePropertyToPopup(DependencyProperty property, object value)
	{
		_popup?.SetValue(property, value, DependencyPropertyValuePrecedences.Local);
	}

	public static FlyoutBase GetAttachedFlyout(FrameworkElement element)
	{
		return (FlyoutBase)element.GetValue(AttachedFlyoutProperty);
	}

	public static void SetAttachedFlyout(FrameworkElement element, FlyoutBase value)
	{
		element.SetValue(AttachedFlyoutProperty, value);
	}

	public static void ShowAttachedFlyout(FrameworkElement flyoutOwner)
	{
		GetAttachedFlyout(flyoutOwner)?.ShowAt(flyoutOwner);
	}

	internal static Rect CalculateAvailableWindowRect(bool isMenuFlyout, Popup popup, object placementTarget, bool hasTargetPosition, Point positionPoint, bool isFull)
	{
		return ApplicationView.GetForCurrentView().VisibleBounds;
	}

	internal void SetPresenterStyle(Control pPresenter, Style pStyle)
	{
		if (pStyle != null)
		{
			pPresenter.Style = pStyle;
		}
		else
		{
			pPresenter.ClearValue(FrameworkElement.StyleProperty);
		}
	}

	internal Control GetPresenter()
	{
		return _popup?.Child as Control;
	}

	internal Rect UpdateTargetPosition(Rect availableWindowRect, Size presenterSize, Rect presenterRect)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = double.NaN;
		double num4 = double.NaN;
		FlowDirection flowDirection = FlowDirection.LeftToRight;
		bool flag = this is MenuFlyout;
		bool flag2 = false;
		num = m_targetPoint.X;
		num2 = m_targetPoint.Y;
		FlyoutPlacementMode effectivePlacement = EffectivePlacement;
		if (!flag && !m_isPositionedForDateTimePicker)
		{
			switch (effectivePlacement)
			{
			case FlyoutPlacementMode.Top:
				num -= presenterSize.Width / 2.0;
				num2 -= presenterSize.Height;
				break;
			case FlyoutPlacementMode.Bottom:
				num -= presenterSize.Width / 2.0;
				break;
			case FlyoutPlacementMode.Left:
				num -= presenterSize.Width;
				num2 -= presenterSize.Height / 2.0;
				break;
			case FlyoutPlacementMode.Right:
				num2 -= presenterSize.Height / 2.0;
				break;
			case FlyoutPlacementMode.TopEdgeAlignedLeft:
			case FlyoutPlacementMode.RightEdgeAlignedBottom:
				num2 -= presenterSize.Height;
				break;
			case FlyoutPlacementMode.TopEdgeAlignedRight:
			case FlyoutPlacementMode.LeftEdgeAlignedBottom:
				num -= presenterSize.Width;
				num2 -= presenterSize.Height;
				break;
			case FlyoutPlacementMode.BottomEdgeAlignedRight:
			case FlyoutPlacementMode.LeftEdgeAlignedTop:
				num -= presenterSize.Width;
				break;
			}
		}
		flag2 = m_inputDeviceTypeUsedToOpen == InputDeviceType.Touch && flag;
		if (flag2)
		{
			num2 -= presenterSize.Height;
		}
		FrameworkElement popup = _popup;
		num3 = GetPresenter().MaxWidth;
		num4 = GetPresenter().MaxHeight;
		if (flowDirection == FlowDirection.LeftToRight)
		{
			if (num + presenterSize.Width > availableWindowRect.X + availableWindowRect.Width)
			{
				if (m_isPositionedAtPoint)
				{
					num -= Math.Min(presenterSize.Width, num);
				}
				else
				{
					num = availableWindowRect.X + availableWindowRect.Width - presenterSize.Width;
					num = Math.Max(availableWindowRect.X, num);
				}
			}
		}
		else if (num - presenterSize.Width < availableWindowRect.X)
		{
			if (m_isPositionedAtPoint)
			{
				num += Math.Min(presenterSize.Width, availableWindowRect.Width + availableWindowRect.X - num);
			}
			else
			{
				num = presenterSize.Width + availableWindowRect.X;
				num = Math.Min(availableWindowRect.Width + availableWindowRect.X, num);
			}
		}
		if (flag2 && num2 < availableWindowRect.Y)
		{
			num2 += presenterSize.Height;
		}
		if (num2 + presenterSize.Height > availableWindowRect.Y + availableWindowRect.Height)
		{
			num2 = ((!m_isPositionedAtPoint) ? (availableWindowRect.Y + availableWindowRect.Height - presenterSize.Height) : (num2 - Math.Min(presenterSize.Height, num2)));
		}
		num2 = Math.Max(availableWindowRect.Y, num2);
		double num6 = (presenterRect.X = ((flowDirection == FlowDirection.LeftToRight) ? num : (num - presenterSize.Width)));
		presenterRect.Y = num2;
		presenterRect.Width = presenterSize.Width;
		presenterRect.Height = presenterSize.Height;
		return presenterRect;
	}

	internal static PreferredJustification GetJustificationFromPlacementMode(FlyoutPlacementMode placement)
	{
		switch (placement)
		{
		case FlyoutPlacementMode.Top:
		case FlyoutPlacementMode.Bottom:
		case FlyoutPlacementMode.Left:
		case FlyoutPlacementMode.Right:
		case FlyoutPlacementMode.Full:
			return PreferredJustification.Center;
		case FlyoutPlacementMode.TopEdgeAlignedLeft:
		case FlyoutPlacementMode.BottomEdgeAlignedLeft:
			return PreferredJustification.Left;
		case FlyoutPlacementMode.TopEdgeAlignedRight:
		case FlyoutPlacementMode.BottomEdgeAlignedRight:
			return PreferredJustification.Right;
		case FlyoutPlacementMode.LeftEdgeAlignedTop:
		case FlyoutPlacementMode.RightEdgeAlignedTop:
			return PreferredJustification.Top;
		case FlyoutPlacementMode.LeftEdgeAlignedBottom:
		case FlyoutPlacementMode.RightEdgeAlignedBottom:
			return PreferredJustification.Bottom;
		default:
			if (typeof(FlyoutBase).Log().IsEnabled(LogLevel.Error))
			{
				typeof(FlyoutBase).Log().LogError("Unsupported FlyoutPlacementMode");
			}
			return PreferredJustification.Center;
		}
	}

	internal static MajorPlacementMode GetMajorPlacementFromPlacement(FlyoutPlacementMode placement)
	{
		switch (placement)
		{
		case FlyoutPlacementMode.Full:
			return MajorPlacementMode.Full;
		case FlyoutPlacementMode.Top:
		case FlyoutPlacementMode.TopEdgeAlignedLeft:
		case FlyoutPlacementMode.TopEdgeAlignedRight:
			return MajorPlacementMode.Top;
		case FlyoutPlacementMode.Bottom:
		case FlyoutPlacementMode.BottomEdgeAlignedLeft:
		case FlyoutPlacementMode.BottomEdgeAlignedRight:
			return MajorPlacementMode.Bottom;
		case FlyoutPlacementMode.Left:
		case FlyoutPlacementMode.LeftEdgeAlignedTop:
		case FlyoutPlacementMode.LeftEdgeAlignedBottom:
			return MajorPlacementMode.Left;
		case FlyoutPlacementMode.Right:
		case FlyoutPlacementMode.RightEdgeAlignedTop:
		case FlyoutPlacementMode.RightEdgeAlignedBottom:
			return MajorPlacementMode.Right;
		default:
			if (typeof(FlyoutBase).Log().IsEnabled(LogLevel.Error))
			{
				typeof(FlyoutBase).Log().LogError("Unsupported FlyoutPlacementMode");
			}
			return MajorPlacementMode.Full;
		}
	}

	internal void PlaceFlyoutForDateTimePicker(Point point)
	{
		m_isPositionedForDateTimePicker = true;
		Rect rect = new Rect(point, ((FrameworkElement)_popup.Child).GetAbsoluteBoundsRect().Size);
		Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
		if (rect.Right > visibleBounds.Right)
		{
			rect.X = visibleBounds.Right - rect.Width;
		}
		if (rect.Bottom > visibleBounds.Bottom)
		{
			rect.Y = visibleBounds.Bottom - rect.Height;
		}
		if (rect.Top < visibleBounds.Top)
		{
			rect.Y = visibleBounds.Top;
		}
		if (rect.Left < visibleBounds.Left)
		{
			rect.X = visibleBounds.Left;
		}
		FrameworkElement target = Target;
		GeneralTransform inverse = target.TransformToVisual(null).Inverse;
		Point value = inverse.TransformPoint(rect.Location);
		SetPopupPositionPartial(target, value);
	}

	internal void DisablePresenterResizing()
	{
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		OnDataContextChangedPartial(e);
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
		OnTemplatedParentChangedPartial(e);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	private void OnDataContextChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		SynchronizePropertyToPopup(UIElement.DataContextProperty, DataContext);
	}

	private void OnTemplatedParentChangedPartial(DependencyPropertyChangedEventArgs e)
	{
		SynchronizePropertyToPopup(UIElement.TemplatedParentProperty, TemplatedParent);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}

	private bool GetAllowFocusWhenDisabledValue()
	{
		if (!_AllowFocusWhenDisabledPropertyBackingFieldSet)
		{
			_AllowFocusWhenDisabledPropertyBackingField = (bool)GetValue(AllowFocusWhenDisabledProperty);
			_AllowFocusWhenDisabledPropertyBackingFieldSet = true;
		}
		return _AllowFocusWhenDisabledPropertyBackingField;
	}

	private void SetAllowFocusWhenDisabledValue(bool value)
	{
		SetValue(AllowFocusWhenDisabledProperty, value);
	}

	private static DependencyProperty CreateAllowFocusWhenDisabledProperty()
	{
		return DependencyProperty.Register("AllowFocusWhenDisabled", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((FlyoutBase)instance).OnAllowFocusWhenDisabledChanged((bool)args.OldValue, (bool)args.NewValue);
		}, (BackingFieldUpdateCallback)OnAllowFocusWhenDisabledBackingFieldUpdate));
	}

	private static void OnAllowFocusWhenDisabledBackingFieldUpdate(object instance, object newValue)
	{
		FlyoutBase flyoutBase = instance as FlyoutBase;
		flyoutBase._AllowFocusWhenDisabledPropertyBackingField = (bool)newValue;
		flyoutBase._AllowFocusWhenDisabledPropertyBackingFieldSet = true;
	}

	private bool GetAllowFocusOnInteractionValue()
	{
		if (!_AllowFocusOnInteractionPropertyBackingFieldSet)
		{
			_AllowFocusOnInteractionPropertyBackingField = (bool)GetValue(AllowFocusOnInteractionProperty);
			_AllowFocusOnInteractionPropertyBackingFieldSet = true;
		}
		return _AllowFocusOnInteractionPropertyBackingField;
	}

	private void SetAllowFocusOnInteractionValue(bool value)
	{
		SetValue(AllowFocusOnInteractionProperty, value);
	}

	private static DependencyProperty CreateAllowFocusOnInteractionProperty()
	{
		return DependencyProperty.Register("AllowFocusOnInteraction", typeof(bool), typeof(FlyoutBase), new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((FlyoutBase)instance).OnAllowFocusOnInteractionChanged((bool)args.OldValue, (bool)args.NewValue);
		}, (BackingFieldUpdateCallback)OnAllowFocusOnInteractionBackingFieldUpdate));
	}

	private static void OnAllowFocusOnInteractionBackingFieldUpdate(object instance, object newValue)
	{
		FlyoutBase flyoutBase = instance as FlyoutBase;
		flyoutBase._AllowFocusOnInteractionPropertyBackingField = (bool)newValue;
		flyoutBase._AllowFocusOnInteractionPropertyBackingFieldSet = true;
	}
}
