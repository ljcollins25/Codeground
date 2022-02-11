using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Content")]
public class SplitView : Control
{
	private CompositeDisposable _subscriptions;

	private readonly SerialDisposable _runningSubscription = new SerialDisposable();

	private FrameworkElement _lightDismissLayer;

	private bool _isViewReady;

	private bool _needsVisualStateUpdate;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(SplitView), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	public double CompactPaneLength
	{
		get
		{
			return (double)GetValue(CompactPaneLengthProperty);
		}
		set
		{
			SetValue(CompactPaneLengthProperty, value);
		}
	}

	public static DependencyProperty CompactPaneLengthProperty { get; } = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(SplitView), new FrameworkPropertyMetadata(48.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnCompactPaneLengthChanged(e);
	}));


	public UIElement Content
	{
		get
		{
			return (UIElement)GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(UIElement), typeof(SplitView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnContentChanged(e);
	}));


	public UIElement Pane
	{
		get
		{
			return (UIElement)GetValue(PaneProperty);
		}
		set
		{
			SetValue(PaneProperty, value);
		}
	}

	public static DependencyProperty PaneProperty { get; } = DependencyProperty.Register("Pane", typeof(UIElement), typeof(SplitView), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnPaneChanged(e);
	}));


	public SplitViewDisplayMode DisplayMode
	{
		get
		{
			return (SplitViewDisplayMode)GetValue(DisplayModeProperty);
		}
		set
		{
			SetValue(DisplayModeProperty, value);
		}
	}

	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(SplitViewDisplayMode), typeof(SplitView), new FrameworkPropertyMetadata(SplitViewDisplayMode.Overlay, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnDisplayModeChanged(e);
	}));


	public bool IsPaneOpen
	{
		get
		{
			return (bool)GetValue(IsPaneOpenProperty);
		}
		set
		{
			SetValue(IsPaneOpenProperty, value);
		}
	}

	public static DependencyProperty IsPaneOpenProperty { get; } = DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(SplitView), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnIsPaneOpenChanged(e);
	}));


	public double OpenPaneLength
	{
		get
		{
			return (double)GetValue(OpenPaneLengthProperty);
		}
		set
		{
			SetValue(OpenPaneLengthProperty, value);
		}
	}

	public static DependencyProperty OpenPaneLengthProperty { get; } = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(SplitView), new FrameworkPropertyMetadata(320.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnOpenPaneLengthChanged(e);
	}));


	public Brush PaneBackground
	{
		get
		{
			return (Brush)GetValue(PaneBackgroundProperty);
		}
		set
		{
			SetValue(PaneBackgroundProperty, value);
		}
	}

	public static DependencyProperty PaneBackgroundProperty { get; } = DependencyProperty.Register("PaneBackground", typeof(Brush), typeof(SplitView), new FrameworkPropertyMetadata(SolidColorBrushHelper.Transparent, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnPaneBackgroundChanged(e);
	}));


	public SplitViewPanePlacement PanePlacement
	{
		get
		{
			return (SplitViewPanePlacement)GetValue(PanePlacementProperty);
		}
		set
		{
			SetValue(PanePlacementProperty, value);
		}
	}

	public static DependencyProperty PanePlacementProperty { get; } = DependencyProperty.Register("PanePlacement", typeof(SplitViewPanePlacement), typeof(SplitView), new FrameworkPropertyMetadata(SplitViewPanePlacement.Left, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnPanePlacementChanged(e);
	}));


	public SplitViewTemplateSettings TemplateSettings
	{
		get
		{
			return (SplitViewTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		private set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(SplitViewTemplateSettings), typeof(SplitView), new FrameworkPropertyMetadata(new SplitViewTemplateSettings(null), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SplitView)s)?.OnTemplateSettingsPropertyChanged(e);
	}));


	public event TypedEventHandler<SplitView, object> PaneClosed;

	public event TypedEventHandler<SplitView, SplitViewPaneClosingEventArgs> PaneClosing;

	public event TypedEventHandler<SplitView, object> PaneOpened;

	public event TypedEventHandler<SplitView, object> PaneOpening;

	public SplitView()
	{
		base.DefaultStyleKey = typeof(SplitView);
	}

	private void OnCompactPaneLengthChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateTemplateSettings();
	}

	private void OnContentChanged(DependencyPropertyChangedEventArgs e)
	{
		SynchronizeContentTemplatedParent();
	}

	private void OnPaneChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnDisplayModeChanged(DependencyPropertyChangedEventArgs e)
	{
		SetNeedsUpdateVisualStates();
	}

	private void OnIsPaneOpenChanged(DependencyPropertyChangedEventArgs e)
	{
		SetNeedsUpdateVisualStates();
	}

	private void OnOpenPaneLengthChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateTemplateSettings();
	}

	private void OnPaneBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private void OnPanePlacementChanged(DependencyPropertyChangedEventArgs e)
	{
		SetNeedsUpdateVisualStates();
	}

	private void OnTemplateSettingsPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UpdateTemplateSettings();
		_lightDismissLayer = FindName("LightDismissLayer") as FrameworkElement;
		_isViewReady = true;
		UpdateControl();
		SetNeedsUpdateVisualStates();
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		SynchronizeContentTemplatedParent();
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		_subscriptions = new CompositeDisposable();
		_runningSubscription.Disposable = _subscriptions;
		UpdateControl();
		SynchronizeContentTemplatedParent();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		_runningSubscription.Disposable = null;
	}

	private void SynchronizeContentTemplatedParent()
	{
		if (Content is IFrameworkElement frameworkElement)
		{
			frameworkElement.TemplatedParent = base.TemplatedParent;
		}
		if (Pane is IFrameworkElement frameworkElement2)
		{
			frameworkElement2.TemplatedParent = base.TemplatedParent;
		}
	}

	private void UpdateControl()
	{
		if (_isViewReady && _runningSubscription.Disposable != null)
		{
			RegisterEvents();
		}
	}

	private void RegisterEvents()
	{
		if (_lightDismissLayer == null)
		{
			return;
		}
		FrameworkElement lightDismissLayer = _lightDismissLayer;
		ButtonBase button = lightDismissLayer as ButtonBase;
		if (button != null)
		{
			RoutedEventHandler handler2 = delegate
			{
				IsPaneOpen = false;
			};
			button.Click += handler2;
			_subscriptions.Add(delegate
			{
				button.Click -= handler2;
			});
		}
		else
		{
			PointerEventHandler handler = delegate
			{
				IsPaneOpen = false;
			};
			_lightDismissLayer.PointerReleased += handler;
			_subscriptions.Add(delegate
			{
				_lightDismissLayer.PointerReleased -= handler;
			});
		}
	}

	private void UpdateTemplateSettings()
	{
		TemplateSettings = new SplitViewTemplateSettings(this);
	}

	private void UpdateVisualStates(bool useTransitons)
	{
		string stateName = GetStateName();
		if (!IsPaneOpen)
		{
			this.PaneClosing?.Invoke(this, new SplitViewPaneClosingEventArgs());
		}
		else
		{
			this.PaneOpening?.Invoke(this, null);
		}
		VisualStateManager.GoToState(this, stateName, useTransitons);
		if (!IsPaneOpen)
		{
			this.PaneClosed?.Invoke(this, null);
		}
		else
		{
			this.PaneOpened?.Invoke(this, null);
		}
	}

	private void SetNeedsUpdateVisualStates()
	{
		if (!_needsVisualStateUpdate)
		{
			_needsVisualStateUpdate = true;
			base.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				UpdateVisualStates(useTransitons: true);
				_needsVisualStateUpdate = false;
			});
		}
	}

	private string GetStateName()
	{
		string text = (IsPaneOpen ? "Open" : "Closed");
		string text2 = string.Empty;
		switch (PanePlacement)
		{
		case SplitViewPanePlacement.Left:
			text2 = "Left";
			break;
		case SplitViewPanePlacement.Right:
			text2 = "Right";
			break;
		}
		string text3 = string.Empty;
		switch (DisplayMode)
		{
		case SplitViewDisplayMode.Overlay:
			text3 = (IsPaneOpen ? "Overlay" : string.Empty);
			break;
		case SplitViewDisplayMode.Inline:
			text3 = (IsPaneOpen ? "Inline" : string.Empty);
			break;
		case SplitViewDisplayMode.CompactOverlay:
			text3 = (IsPaneOpen ? "CompactOverlay" : "Compact");
			break;
		case SplitViewDisplayMode.CompactInline:
			text3 = (IsPaneOpen ? "Inline" : "Compact");
			break;
		}
		if (text == "Closed" && text3.IsNullOrWhiteSpace())
		{
			text2 = "";
		}
		return text + text3 + text2;
	}
}
