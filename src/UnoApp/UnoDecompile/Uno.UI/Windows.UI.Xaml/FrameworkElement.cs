using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml;

public class FrameworkElement : UIElement, IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse, IFrameworkElementInternal, ILayoutConstraints, IFrameworkElement_EffectiveViewport, IEnumerable
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{DDDCCA61-5CB7-4585-95D7-58C5528AABE6}");

		public const int FrameworkElement_MeasureStart = 1;

		public const int FrameworkElement_MeasureStop = 2;

		public const int FrameworkElement_ArrangeStart = 3;

		public const int FrameworkElement_ArrangeStop = 4;

		public const int FrameworkElement_InvalidateMeasure = 5;
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private bool _constraintsChanged;

	private bool _suppressIsEnabled;

	private bool _defaultStyleApplied;

	private Style _activeStyle;

	private SpecializedResourceDictionary.ResourceKey _thisTypeResourceKey;

	private bool _isParsing;

	private bool _focusVisualBrushesInitialized;

	[ThreadStatic]
	private static IsEnabledChangedEventArgs _isEnabledChangedEventArgs;

	private AutomationPeer _automationPeer;

	private static readonly RoutedEventHandler ReconfigureViewportPropagationOnLoad = delegate(object snd, RoutedEventArgs e)
	{
		((FrameworkElement)snd).ReconfigureViewportPropagation();
	};

	private bool _hasNewHandler;

	private int _childrenInterestedInViewportUpdates;

	private IDisposable? _parentViewportUpdatesSubscription;

	private ViewportInfo _parentViewport = ViewportInfo.Empty;

	private ViewportInfo _lastEffectiveViewport;

	private bool _isLayouted;

	private Size _unclippedDesiredSize;

	private Point _visualOffset;

	private const double SIZE_EPSILON = 0.05;

	private readonly Size MaxSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

	private SerialDisposable _backgroundSubscription;

	private protected new readonly Logger _log;

	private protected new readonly Logger _logDebug;

	private static readonly Uri DefaultBaseUri = new Uri("ms-appx://local");

	private bool _TagPropertyBackingFieldSet;

	private object _TagPropertyBackingField;

	private bool _FocusVisualSecondaryThicknessPropertyBackingFieldSet;

	private Thickness _FocusVisualSecondaryThicknessPropertyBackingField;

	private bool _FocusVisualSecondaryBrushPropertyBackingFieldSet;

	private Brush _FocusVisualSecondaryBrushPropertyBackingField;

	private bool _FocusVisualPrimaryThicknessPropertyBackingFieldSet;

	private Thickness _FocusVisualPrimaryThicknessPropertyBackingField;

	private bool _FocusVisualPrimaryBrushPropertyBackingFieldSet;

	private Brush _FocusVisualPrimaryBrushPropertyBackingField;

	private bool _FocusVisualMarginPropertyBackingFieldSet;

	private Thickness _FocusVisualMarginPropertyBackingField;

	private bool _AllowFocusWhenDisabledPropertyBackingFieldSet;

	private bool _AllowFocusWhenDisabledPropertyBackingField;

	private bool _AllowFocusOnInteractionPropertyBackingFieldSet;

	private bool _AllowFocusOnInteractionPropertyBackingField;

	private bool _IsEnabledPropertyBackingFieldSet;

	private bool _IsEnabledPropertyBackingField;

	private bool _TransitionsPropertyBackingFieldSet;

	private TransitionCollection _TransitionsPropertyBackingField;

	private bool _BackgroundPropertyBackingFieldSet;

	private Brush _BackgroundPropertyBackingField;

	private bool _MarginPropertyBackingFieldSet;

	private Thickness _MarginPropertyBackingField;

	private bool _HorizontalAlignmentPropertyBackingFieldSet;

	private HorizontalAlignment _HorizontalAlignmentPropertyBackingField;

	private bool _VerticalAlignmentPropertyBackingFieldSet;

	private VerticalAlignment _VerticalAlignmentPropertyBackingField;

	private bool _WidthPropertyBackingFieldSet;

	private double _WidthPropertyBackingField;

	private bool _HeightPropertyBackingFieldSet;

	private double _HeightPropertyBackingField;

	private bool _MinWidthPropertyBackingFieldSet;

	private double _MinWidthPropertyBackingField;

	private bool _MinHeightPropertyBackingFieldSet;

	private double _MinHeightPropertyBackingField;

	private bool _MaxWidthPropertyBackingFieldSet;

	private double _MaxWidthPropertyBackingField;

	private bool _MaxHeightPropertyBackingFieldSet;

	private double _MaxHeightPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Language
	{
		get
		{
			return (string)GetValue(LanguageProperty);
		}
		set
		{
			SetValue(LanguageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlowDirection FlowDirection
	{
		get
		{
			return (FlowDirection)GetValue(FlowDirectionProperty);
		}
		set
		{
			SetValue(FlowDirectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TriggerCollection Triggers
	{
		get
		{
			throw new NotImplementedException("The member TriggerCollection FrameworkElement.Triggers is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ActualHeightProperty { get; } = DependencyProperty.Register("ActualHeight", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ActualWidthProperty { get; } = DependencyProperty.Register("ActualWidth", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FlowDirectionProperty { get; } = DependencyProperty.Register("FlowDirection", typeof(FlowDirection), typeof(FrameworkElement), new FrameworkPropertyMetadata(FlowDirection.LeftToRight));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LanguageProperty { get; } = DependencyProperty.Register("Language", typeof(string), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__" })]
	public static DependencyProperty NameProperty { get; } = DependencyProperty.Register("Name", typeof(string), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ActualThemeProperty { get; } = DependencyProperty.Register("ActualTheme", typeof(ElementTheme), typeof(FrameworkElement), new FrameworkPropertyMetadata(ElementTheme.Default));


	private protected bool IsDefaultStyleApplied => _defaultStyleApplied;

	public static bool UseConstraintOptimizations { get; set; } = false;


	public bool? AreDimensionsConstrained { get; set; }

	protected virtual bool IsSimpleLayout => false;

	internal bool IsStyleSetFromItemsControl { get; set; }

	public object Tag
	{
		get
		{
			return GetTagValue();
		}
		set
		{
			SetTagValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty TagProperty { get; } = CreateTagProperty();


	internal BackgroundSizing InternalBackgroundSizing { get; set; }

	public ResourceDictionary Resources { get; set; }

	public DependencyObject Parent => LogicalParentOverride ?? (((IDependencyObjectStoreProvider)this).Store.Parent as DependencyObject);

	internal DependencyObject LogicalParentOverride { get; set; }

	internal UIElement VisualParent => ((IDependencyObjectStoreProvider)this).Store.Parent as UIElement;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsParsing
	{
		get
		{
			return _isParsing;
		}
		set
		{
			if (!value)
			{
				throw new InvalidOperationException("IsParsing should never be set from user code.");
			}
			_isParsing = value;
			if (_isParsing)
			{
				ResourceResolver.PushSourceToScope(this);
			}
		}
	}

	public Style Style
	{
		get
		{
			return (Style)GetValue(StyleProperty);
		}
		set
		{
			SetValue(StyleProperty, value);
		}
	}

	public static DependencyProperty StyleProperty { get; } = DependencyProperty.Register("Style", typeof(Style), typeof(FrameworkElement), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FrameworkElement)s)?.OnStyleChanged((Style)e.OldValue, (Style)e.NewValue);
	}));


	private SpecializedResourceDictionary.ResourceKey ThisTypeResourceKey
	{
		get
		{
			if (_thisTypeResourceKey.IsEmpty)
			{
				_thisTypeResourceKey = GetType();
			}
			return _thisTypeResourceKey;
		}
	}

	public ElementTheme RequestedTheme
	{
		get
		{
			return (ElementTheme)GetValue(RequestedThemeProperty);
		}
		set
		{
			SetValue(RequestedThemeProperty, value);
		}
	}

	public static DependencyProperty RequestedThemeProperty { get; } = DependencyProperty.Register("RequestedTheme", typeof(ElementTheme), typeof(FrameworkElement), new FrameworkPropertyMetadata(ElementTheme.Default, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((FrameworkElement)o).OnRequestedThemeChanged((ElementTheme)e.OldValue, (ElementTheme)e.NewValue);
	}));


	public ElementTheme ActualTheme
	{
		get
		{
			if (RequestedTheme != 0)
			{
				return RequestedTheme;
			}
			return Application.Current?.ActualElementTheme ?? ElementTheme.Light;
		}
	}

	[GeneratedDependencyProperty]
	public static DependencyProperty FocusVisualSecondaryThicknessProperty { get; } = CreateFocusVisualSecondaryThicknessProperty();


	public Thickness FocusVisualSecondaryThickness
	{
		get
		{
			return GetFocusVisualSecondaryThicknessValue();
		}
		set
		{
			SetFocusVisualSecondaryThicknessValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty FocusVisualSecondaryBrushProperty { get; } = CreateFocusVisualSecondaryBrushProperty();


	public Brush FocusVisualSecondaryBrush
	{
		get
		{
			EnsureFocusVisualBrushDefaults();
			return GetFocusVisualSecondaryBrushValue();
		}
		set
		{
			SetFocusVisualSecondaryBrushValue(value);
		}
	}

	[GeneratedDependencyProperty]
	public static DependencyProperty FocusVisualPrimaryThicknessProperty { get; } = CreateFocusVisualPrimaryThicknessProperty();


	public Thickness FocusVisualPrimaryThickness
	{
		get
		{
			return GetFocusVisualPrimaryThicknessValue();
		}
		set
		{
			SetFocusVisualPrimaryThicknessValue(value);
		}
	}

	public Brush FocusVisualPrimaryBrush
	{
		get
		{
			EnsureFocusVisualBrushDefaults();
			return GetFocusVisualPrimaryBrushValue();
		}
		set
		{
			SetFocusVisualPrimaryBrushValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty FocusVisualPrimaryBrushProperty { get; } = CreateFocusVisualPrimaryBrushProperty();


	public Thickness FocusVisualMargin
	{
		get
		{
			return GetFocusVisualMarginValue();
		}
		set
		{
			SetFocusVisualMarginValue(value);
		}
	}

	[GeneratedDependencyProperty]
	public static DependencyProperty FocusVisualMarginProperty { get; } = CreateFocusVisualMarginProperty();


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

	[GeneratedDependencyProperty(DefaultValue = false, Options = FrameworkPropertyMetadataOptions.Inherits)]
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

	[GeneratedDependencyProperty(DefaultValue = true, Options = FrameworkPropertyMetadataOptions.Inherits)]
	public static DependencyProperty AllowFocusOnInteractionProperty { get; } = CreateAllowFocusOnInteractionProperty();


	[GeneratedDependencyProperty(DefaultValue = true, ChangedCallback = true, CoerceCallback = true, Options = FrameworkPropertyMetadataOptions.Inherits)]
	public static DependencyProperty IsEnabledProperty { get; } = CreateIsEnabledProperty();


	public bool IsEnabled
	{
		get
		{
			return GetIsEnabledValue();
		}
		set
		{
			SetIsEnabledValue(value);
		}
	}

	internal int[] DataTemplateRenderPhases { get; set; }

	private bool IsEffectiveViewportEnabled
	{
		get
		{
			if (_childrenInterestedInViewportUpdates <= 0)
			{
				return this._effectiveViewportChanged != null;
			}
			return true;
		}
	}

	internal Point RelativePosition => _visualOffset;

	private protected string DepthIndentation
	{
		get
		{
			int depth = base.Depth;
			return (Parent as FrameworkElement)?.DepthIndentation + $"-{depth}>";
		}
	}

	public new bool IsLoaded => base.IsLoaded;

	public Uri BaseUri { get; internal set; } = DefaultBaseUri;


	[GeneratedDependencyProperty(DefaultValue = null, ChangedCallback = true)]
	public static DependencyProperty TransitionsProperty { get; } = CreateTransitionsProperty();


	public TransitionCollection Transitions
	{
		get
		{
			return GetTransitionsValue();
		}
		set
		{
			SetTransitionsValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null, ChangedCallback = true)]
	public static DependencyProperty BackgroundProperty { get; } = CreateBackgroundProperty();


	public Brush Background
	{
		get
		{
			return GetBackgroundValue();
		}
		set
		{
			SetBackgroundValue(value);
		}
	}

	public int? RenderPhase
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	bool IFrameworkElementInternal.HasLayouter => true;

	public double ActualWidth => GetActualWidth();

	public double ActualHeight => GetActualHeight();

	[GeneratedDependencyProperty(Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty MarginProperty { get; } = CreateMarginProperty();


	public virtual Thickness Margin
	{
		get
		{
			return GetMarginValue();
		}
		set
		{
			SetMarginValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = HorizontalAlignment.Stretch, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty HorizontalAlignmentProperty { get; } = CreateHorizontalAlignmentProperty();


	public HorizontalAlignment HorizontalAlignment
	{
		get
		{
			return GetHorizontalAlignmentValue();
		}
		set
		{
			SetHorizontalAlignmentValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = HorizontalAlignment.Stretch, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty VerticalAlignmentProperty { get; } = CreateVerticalAlignmentProperty();


	public VerticalAlignment VerticalAlignment
	{
		get
		{
			return GetVerticalAlignmentValue();
		}
		set
		{
			SetVerticalAlignmentValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.NaN, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty WidthProperty { get; } = CreateWidthProperty();


	public double Width
	{
		get
		{
			return GetWidthValue();
		}
		set
		{
			SetWidthValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.NaN, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty HeightProperty { get; } = CreateHeightProperty();


	public double Height
	{
		get
		{
			return GetHeightValue();
		}
		set
		{
			SetHeightValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty MinWidthProperty { get; } = CreateMinWidthProperty();


	public double MinWidth
	{
		get
		{
			return GetMinWidthValue();
		}
		set
		{
			SetMinWidthValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 0.0, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty MinHeightProperty { get; } = CreateMinHeightProperty();


	public double MinHeight
	{
		get
		{
			return GetMinHeightValue();
		}
		set
		{
			SetMinHeightValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.PositiveInfinity, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty MaxWidthProperty { get; } = CreateMaxWidthProperty();


	public double MaxWidth
	{
		get
		{
			return GetMaxWidthValue();
		}
		set
		{
			SetMaxWidthValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = double.PositiveInfinity, Options = (FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty MaxHeightProperty { get; } = CreateMaxHeightProperty();


	public double MaxHeight
	{
		get
		{
			return GetMaxHeightValue();
		}
		set
		{
			SetMaxHeightValue(value);
		}
	}

	public event TypedEventHandler<FrameworkElement, object> ActualThemeChanged;

	public event DependencyPropertyChangedEventHandler IsEnabledChanged;

	public event EventHandler<object> LayoutUpdated;

	private event TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs>? _effectiveViewportChanged;

	public event TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs> EffectiveViewportChanged
	{
		add
		{
			_hasNewHandler = true;
			_effectiveViewportChanged += value;
			ReconfigureViewportPropagation(isInternal: true);
		}
		remove
		{
			_effectiveViewportChanged -= value;
			ReconfigureViewportPropagation(isInternal: true);
		}
	}

	public event SizeChangedEventHandler SizeChanged;

	private event TypedEventHandler<FrameworkElement, object> _loading;

	public event TypedEventHandler<FrameworkElement, object> Loading
	{
		add
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_loading += value;
			}
			else
			{
				RegisterEventHandler("loading", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
		remove
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_loading -= value;
			}
			else
			{
				UnregisterEventHandler("loading", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
	}

	private event RoutedEventHandler _loaded;

	public event RoutedEventHandler Loaded
	{
		add
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_loaded += value;
			}
			else
			{
				RegisterEventHandler("loaded", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
		remove
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_loaded -= value;
			}
			else
			{
				UnregisterEventHandler("loaded", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
	}

	private event RoutedEventHandler _unloaded;

	public event RoutedEventHandler Unloaded
	{
		add
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_unloaded += value;
			}
			else
			{
				RegisterEventHandler("unloaded", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
		remove
		{
			if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				_unloaded -= value;
			}
			else
			{
				UnregisterEventHandler("unloaded", value, GenericEventHandlers.RaiseRoutedEventHandler);
			}
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void DeferTree(DependencyObject element)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.FrameworkElement", "void FrameworkElement.DeferTree(DependencyObject element)");
	}

	private protected virtual void OnBackgroundSizingChangedInner(DependencyPropertyChangedEventArgs e)
	{
		InternalBackgroundSizing = (BackgroundSizing)e.NewValue;
		OnBackgroundSizingChangedPartial(e);
	}

	private void OnBackgroundSizingChangedPartial(DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
	{
		object newValue = dependencyPropertyChangedEventArgs.NewValue;
		if (newValue is BackgroundSizing)
		{
			BackgroundSizing backgroundSizing = (BackgroundSizing)newValue;
			SetStyle("background-clip", (backgroundSizing == BackgroundSizing.InnerBorderEdge) ? "padding-box" : "border-box");
		}
	}

	protected virtual Size MeasureOverride(Size availableSize)
	{
		UIElement uIElement = FindFirstChild();
		if (uIElement == null)
		{
			return new Size(0.0, 0.0);
		}
		return MeasureElement(uIElement, availableSize);
	}

	protected virtual Size ArrangeOverride(Size finalSize)
	{
		UIElement uIElement = FindFirstChild();
		if (uIElement != null)
		{
			uIElement.Arrange(new Rect(0.0, 0.0, finalSize.Width, finalSize.Height));
			return finalSize;
		}
		return finalSize;
	}

	protected Size MeasureElement(UIElement view, Size availableSize)
	{
		view.Measure(availableSize);
		return view.DesiredSize;
	}

	protected void ArrangeElement(UIElement view, Rect finalRect)
	{
		Thickness borderThickness = GetBorderThickness();
		Rect finalRect2 = new Rect(finalRect.X - borderThickness.Left, finalRect.Y - borderThickness.Top, finalRect.Width, finalRect.Height);
		view.Arrange(finalRect2);
	}

	protected Size GetElementDesiredSize(UIElement view)
	{
		return view.DesiredSize;
	}

	private protected void ApplyStyles()
	{
		ApplyStyle();
		ApplyDefaultStyle();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void CreationComplete()
	{
		if (!IsParsing)
		{
			throw new InvalidOperationException("Called without matching IsParsing call. This method should never be called from user code.");
		}
		ApplyStyles();
		_isParsing = false;
		ResourceResolver.PopSourceFromScope();
	}

	private void OnStyleChanged(Style oldStyle, Style newStyle)
	{
		if (!IsParsing)
		{
			ApplyStyle();
		}
	}

	private void ApplyStyle()
	{
		Style activeStyle = _activeStyle;
		UpdateActiveStyle();
		OnStyleChanged(activeStyle, _activeStyle, DependencyPropertyValuePrecedences.ExplicitStyle);
	}

	private void UpdateActiveStyle()
	{
		if (this.IsDependencyPropertySet(StyleProperty))
		{
			_activeStyle = Style;
		}
		else
		{
			_activeStyle = ResolveImplicitStyle();
		}
	}

	private Style ResolveImplicitStyle()
	{
		SpecializedResourceDictionary.ResourceKey styleKey = ThisTypeResourceKey;
		return this.StoreGetImplicitStyle(in styleKey);
	}

	private void OnRequestedThemeChanged(ElementTheme oldValue, ElementTheme newValue)
	{
		if (base.IsWindowRoot)
		{
			Application.Current.SetExplicitRequestedTheme(newValue.ToApplicationThemeOrDefault());
		}
		if (this.ActualThemeChanged == null)
		{
			return;
		}
		if (oldValue == ElementTheme.Default)
		{
			Application current = Application.Current;
			if (current == null || current.ActualElementTheme != newValue)
			{
				goto IL_0055;
			}
		}
		if (oldValue == ElementTheme.Default || oldValue == ActualTheme)
		{
			return;
		}
		goto IL_0055;
		IL_0055:
		this.ActualThemeChanged?.Invoke(this, null);
	}

	private static Thickness GetFocusVisualSecondaryThicknessDefaultValue()
	{
		return new Thickness(1.0);
	}

	private static Thickness GetFocusVisualPrimaryThicknessDefaultValue()
	{
		return new Thickness(2.0);
	}

	private static Thickness GetFocusVisualMarginDefaultValue()
	{
		return Thickness.Empty;
	}

	internal void EnsureFocusVisualBrushDefaults()
	{
		if (!_focusVisualBrushesInitialized)
		{
			ResourceResolver.ApplyResource(this, FocusVisualPrimaryBrushProperty, new SpecializedResourceDictionary.ResourceKey("SystemControlFocusVisualPrimaryBrush"), ResourceUpdateReason.ThemeResource, null, DependencyPropertyValuePrecedences.DefaultValue);
			ResourceResolver.ApplyResource(this, FocusVisualSecondaryBrushProperty, new SpecializedResourceDictionary.ResourceKey("SystemControlFocusVisualSecondaryBrush"), ResourceUpdateReason.ThemeResource, null, DependencyPropertyValuePrecedences.DefaultValue);
			_focusVisualBrushesInitialized = true;
		}
	}

	private void OnStyleChanged(Style oldStyle, Style newStyle, DependencyPropertyValuePrecedences precedence)
	{
		if (oldStyle != newStyle)
		{
			oldStyle?.ClearInvalidProperties(this, newStyle, precedence);
			newStyle?.ApplyTo(this, precedence);
		}
	}

	private protected void ApplyDefaultStyle()
	{
		if (!_defaultStyleApplied)
		{
			_defaultStyleApplied = true;
			((IDependencyObjectStoreProvider)this).Store.SetLastUsedTheme(Application.Current?.RequestedThemeForResources);
			Style defaultStyleForType = Style.GetDefaultStyleForType(GetDefaultStyleKey());
			OnStyleChanged(null, defaultStyleForType, DependencyPropertyValuePrecedences.ImplicitStyle);
		}
	}

	private protected virtual Type GetDefaultStyleKey()
	{
		return null;
	}

	protected virtual void OnApplyTemplate()
	{
	}

	private void OnIsEnabledChanged(DependencyPropertyChangedEventArgs args)
	{
		UpdateHitTest();
		if (_isEnabledChangedEventArgs == null)
		{
			_isEnabledChangedEventArgs = new IsEnabledChangedEventArgs();
		}
		_isEnabledChangedEventArgs.SourceEvent = args;
		OnIsEnabledChanged(_isEnabledChangedEventArgs);
		this.IsEnabledChanged?.Invoke(this, args);
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMProperties();
		}
	}

	private protected virtual void OnIsEnabledChanged(IsEnabledChangedEventArgs pArgs)
	{
	}

	private protected void SuppressIsEnabled(bool suppress)
	{
		_suppressIsEnabled = suppress;
		this.CoerceValue(IsEnabledProperty);
	}

	private object CoerceIsEnabled(object baseValue)
	{
		if (!_suppressIsEnabled)
		{
			return baseValue;
		}
		return false;
	}

	private bool ShouldPropagateLayoutRequest()
	{
		if (!UseConstraintOptimizations && !AreDimensionsConstrained.HasValue)
		{
			return true;
		}
		if (_constraintsChanged)
		{
			return true;
		}
		if (!IsLoaded)
		{
			return true;
		}
		if (AreDimensionsConstrained.HasValue)
		{
			return !AreDimensionsConstrained.Value;
		}
		bool flag = IsWidthConstrained(null);
		bool flag2 = IsHeightConstrained(null);
		return !(flag && flag2);
	}

	bool ILayoutConstraints.IsWidthConstrained(UIElement requester)
	{
		return IsWidthConstrained(requester);
	}

	private bool IsWidthConstrained(UIElement requester)
	{
		bool? flag = IsWidthConstrainedInner(requester);
		if (!flag.HasValue)
		{
			ILayoutConstraints obj = Parent as ILayoutConstraints;
			if (obj == null)
			{
				if (requester != null)
				{
					return IsTopLevelXamlView();
				}
				return false;
			}
			return obj.IsWidthConstrained(this);
		}
		return flag.GetValueOrDefault();
	}

	protected virtual bool? IsWidthConstrainedInner(UIElement requester)
	{
		if (!IsSimpleLayout)
		{
			return false;
		}
		return this.IsWidthConstrainedSimple();
	}

	bool ILayoutConstraints.IsHeightConstrained(UIElement requester)
	{
		return IsHeightConstrained(requester);
	}

	private bool IsHeightConstrained(UIElement requester)
	{
		return IsHeightConstrainedInner(requester) ?? (Parent as ILayoutConstraints)?.IsHeightConstrained(this) ?? IsTopLevelXamlView();
	}

	protected virtual bool? IsHeightConstrainedInner(UIElement requester)
	{
		if (!IsSimpleLayout)
		{
			return false;
		}
		return this.IsHeightConstrainedSimple();
	}

	internal override bool IsViewHit()
	{
		return Background != null;
	}

	internal bool GoToElementState(string stateName, bool useTransitions)
	{
		return GoToElementStateCore(stateName, useTransitions);
	}

	protected virtual bool GoToElementStateCore(string stateName, bool useTransitions)
	{
		return false;
	}

	internal virtual void OnLayoutUpdated()
	{
		this.LayoutUpdated?.Invoke(this, new RoutedEventArgs(this));
	}

	private protected virtual Thickness GetBorderThickness()
	{
		return Thickness.Empty;
	}

	internal virtual void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		Resources?.UpdateThemeBindings(updateReason);
		((IDependencyObjectStoreProvider)this).Store.UpdateResourceBindings(updateReason);
		_focusVisualBrushesInitialized = false;
		if (updateReason == ResourceUpdateReason.ThemeResource && this.ActualThemeChanged != null && RequestedTheme == ElementTheme.Default)
		{
			this.ActualThemeChanged?.Invoke(this, null);
		}
	}

	private protected void SetDefaultForeground(DependencyProperty foregroundProperty)
	{
		this.SetValue(foregroundProperty, (Application.Current == null || Application.Current.RequestedTheme == ApplicationTheme.Light) ? SolidColorBrushHelper.Black : SolidColorBrushHelper.White, DependencyPropertyValuePrecedences.DefaultValue);
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		string name = AutomationProperties.GetName(this);
		if (name != null && !string.IsNullOrEmpty(name))
		{
			return new FrameworkElementAutomationPeer(this);
		}
		return null;
	}

	public virtual string GetAccessibilityInnerText()
	{
		return null;
	}

	public AutomationPeer GetAutomationPeer()
	{
		if (_automationPeer == null)
		{
			_automationPeer = OnCreateAutomationPeer();
		}
		return _automationPeer;
	}

	void IFrameworkElement_EffectiveViewport.InitializeEffectiveViewport()
	{
		Loaded += ReconfigureViewportPropagationOnLoad;
		Unloaded += ReconfigureViewportPropagationOnLoad;
	}

	private void ReconfigureViewportPropagation(bool isInternal = false, IFrameworkElement_EffectiveViewport? child = null)
	{
		if (IsLoaded && IsEffectiveViewportEnabled)
		{
			if (IsLoaded)
			{
				_isLayouted = true;
			}
			if (_parentViewportUpdatesSubscription == null)
			{
				UIElement visualTreeParent = this.GetVisualTreeParent();
				if (visualTreeParent is IFrameworkElement_EffectiveViewport frameworkElement_EffectiveViewport)
				{
					_parentViewportUpdatesSubscription = frameworkElement_EffectiveViewport.RequestViewportUpdates(isInternal, this);
				}
				else
				{
					PropagateEffectiveViewportChange(isInitial: true, isInternal);
				}
			}
			else if (child != null)
			{
				ViewportInfo parentViewport = GetParentViewport();
				ViewportInfo effectiveViewport = GetEffectiveViewport(parentViewport);
				child!.OnParentViewportChanged(isInitial: true, isInternal: true, this, effectiveViewport);
			}
		}
		else
		{
			if (!IsLoaded)
			{
				_isLayouted = false;
			}
			if (_parentViewportUpdatesSubscription != null)
			{
				_parentViewportUpdatesSubscription!.Dispose();
				_parentViewportUpdatesSubscription = null;
				_parentViewport = ViewportInfo.Empty;
			}
		}
	}

	IDisposable IFrameworkElement_EffectiveViewport.RequestViewportUpdates(bool isInternalUpdate, IFrameworkElement_EffectiveViewport? child)
	{
		_childrenInterestedInViewportUpdates++;
		ReconfigureViewportPropagation(isInternalUpdate, child);
		return Disposable.Create(delegate
		{
			_childrenInterestedInViewportUpdates--;
			ReconfigureViewportPropagation();
		});
	}

	void IFrameworkElement_EffectiveViewport.OnParentViewportChanged(bool isInitial, bool isInternal, IFrameworkElement_EffectiveViewport parent, ViewportInfo viewport)
	{
		if (IsEffectiveViewportEnabled && (isInitial || !(viewport == _parentViewport)))
		{
			_parentViewport = viewport;
			PropagateEffectiveViewportChange(isInitial, isInternal);
		}
	}

	void IFrameworkElement_EffectiveViewport.OnLayoutUpdated()
	{
	}

	private protected sealed override void OnViewportUpdated(Rect viewport)
	{
		_isLayouted = true;
		PropagateEffectiveViewportChange();
	}

	[NotImplemented]
	protected void InvalidateViewport()
	{
		if (!base.IsScrollPort)
		{
			throw new InvalidOperationException("InvalidateViewport can only be called on elements that have been registered as scroll ports.");
		}
		PropagateEffectiveViewportChange();
	}

	private ViewportInfo GetEffectiveViewport(ViewportInfo parentViewport)
	{
		if (base.IsVisualTreeRoot)
		{
			Rect layoutSlot = LayoutInformation.GetLayoutSlot(this);
			return new ViewportInfo(this, layoutSlot, Rect.Infinite);
		}
		if (base.IsScrollPort)
		{
			Rect viewport = parentViewport.Clip;
			if (viewport.Right <= 0.0 || viewport.Bottom <= 0.0)
			{
				return new ViewportInfo(this, Rect.Empty);
			}
			Rect rect = new Rect(new Point(base.ScrollOffsets.X, base.ScrollOffsets.Y), LayoutInformation.GetLayoutSlot(this).Size);
			if (viewport.IsInfinite)
			{
				viewport = rect;
			}
			else
			{
				viewport.Intersect(rect);
			}
			return new ViewportInfo(this, viewport);
		}
		return parentViewport;
	}

	private ViewportInfo GetParentViewport()
	{
		return _parentViewport.GetRelativeTo(this);
	}

	private void PropagateEffectiveViewportChange(bool isInitial = false, bool isInternal = false)
	{
		if (!IsEffectiveViewportEnabled || !_isLayouted)
		{
			return;
		}
		ViewportInfo parentViewport = GetParentViewport();
		ViewportInfo effectiveViewport = GetEffectiveViewport(parentViewport);
		bool flag = _lastEffectiveViewport != effectiveViewport;
		_lastEffectiveViewport = effectiveViewport;
		if (flag && (!isInternal || _hasNewHandler))
		{
			_hasNewHandler = false;
			this._effectiveViewportChanged?.Invoke(this, new EffectiveViewportChangedEventArgs(parentViewport.Effective));
		}
		if (_childrenInterestedInViewportUpdates <= 0 || !(isInitial || flag))
		{
			return;
		}
		IEnumerable<DependencyObject> children = Uno.UI.Extensions.DependencyObjectExtensions.GetChildren(this);
		foreach (DependencyObject item in children)
		{
			if (item is IFrameworkElement_EffectiveViewport frameworkElement_EffectiveViewport)
			{
				frameworkElement_EffectiveViewport.OnParentViewportChanged(isInitial, isInternal, this, effectiveViewport);
			}
		}
	}

	[Conditional("TRACE_EFFECTIVE_VIEWPORT")]
	private void TRACE_EFFECTIVE_VIEWPORT(string text)
	{
	}

	internal sealed override void MeasureCore(Size availableSize)
	{
		if (_trace.IsEnabled)
		{
			MeasureCoreWithTrace(availableSize);
		}
		else
		{
			InnerMeasureCore(availableSize);
		}
		void MeasureCoreWithTrace(Size availableSize)
		{
			EventProviderExtensions.DisposableEventActivity disposableEventActivity = _trace.WriteEventActivity(1, 2, new object[4]
			{
				GetType().Name,
				this.GetDependencyObjectId(),
				base.Name,
				availableSize.ToString()
			});
			using (disposableEventActivity)
			{
				InnerMeasureCore(availableSize);
			}
		}
	}

	private void InnerMeasureCore(Size availableSize)
	{
		(Size min, Size max) minMax = this.GetMinMax();
		Size item = minMax.min;
		Size item2 = minMax.max;
		Size marginSize = this.GetMarginSize();
		availableSize = availableSize.NumberOrDefault(MaxSize);
		Size size = availableSize.Subtract(marginSize).AtLeastZero().AtMost(item2);
		Size size2 = MeasureOverride(size);
		_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}.MeasureOverride(availableSize={size}): desiredSize={size2} minSize={item} maxSize={item2} marginSize={marginSize}");
		if (double.IsNaN(size2.Width) || double.IsNaN(size2.Height) || double.IsInfinity(size2.Width) || double.IsInfinity(size2.Height))
		{
			throw new InvalidOperationException($"{FormatDebugName()}: Invalid measured size {size2}. NaN or Infinity are invalid desired size.");
		}
		Size size3 = (_unclippedDesiredSize = size2.AtLeast(item).AtLeastZero()).AtMost(availableSize).Add(marginSize).AtLeastZero();
		LayoutInformation.SetDesiredSize(this, size3);
		_logDebug?.Debug($"{DepthIndentation}[{FormatDebugName()}] Measure({base.Name}/{availableSize}/{Margin}) = {size3} _unclippedDesiredSize={_unclippedDesiredSize}");
	}

	private string FormatDebugName()
	{
		return $"[{this}/{base.Name}";
	}

	internal sealed override void ArrangeCore(Rect finalRect)
	{
		if (_trace.IsEnabled)
		{
			ArrangeCoreWithTrace(finalRect);
		}
		else
		{
			InnerArrangeCore(finalRect);
		}
		void ArrangeCoreWithTrace(Rect finalRect)
		{
			EventProviderExtensions.DisposableEventActivity disposableEventActivity = _trace.WriteEventActivity(3, 4, new object[4]
			{
				GetType().Name,
				this.GetDependencyObjectId(),
				base.Name,
				finalRect.ToString()
			});
			using (disposableEventActivity)
			{
				InnerArrangeCore(finalRect);
			}
		}
	}

	private static bool IsLessThanAndNotCloseTo(double a, double b)
	{
		return a < b - 0.05;
	}

	private void InnerArrangeCore(Rect finalRect)
	{
		_logDebug?.Debug($"{DepthIndentation}{FormatDebugName()}: InnerArrangeCore({finalRect})");
		Size size = finalRect.Size;
		Size item = this.GetMinMax().max;
		Size marginSize = this.GetMarginSize();
		size = size.Subtract(marginSize).AtLeastZero();
		ICustomClippingElement customClippingElement = this as ICustomClippingElement;
		bool flag = customClippingElement?.AllowClippingToLayoutSlot ?? true;
		bool flag2 = customClippingElement?.ForceClippingToLayoutSlot ?? false;
		_logDebug?.Debug($"{DepthIndentation}{FormatDebugName()}: InnerArrangeCore({finalRect}) - allowClip={flag}, arrangeSize={size}, _unclippedDesiredSize={_unclippedDesiredSize}, forcedClipping={flag2}");
		if (flag && !flag2)
		{
			if (IsLessThanAndNotCloseTo(size.Width, _unclippedDesiredSize.Width))
			{
				_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}: (arrangeSize.Width) {size.Width} < {_unclippedDesiredSize.Width}: NEEDS CLIPPING.");
				flag2 = true;
			}
			else if (IsLessThanAndNotCloseTo(size.Height, _unclippedDesiredSize.Height))
			{
				_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}: (arrangeSize.Height) {size.Height} < {_unclippedDesiredSize.Height}: NEEDS CLIPPING.");
				flag2 = true;
			}
		}
		if (HorizontalAlignment != HorizontalAlignment.Stretch)
		{
			size.Width = _unclippedDesiredSize.Width;
		}
		if (VerticalAlignment != VerticalAlignment.Stretch)
		{
			size.Height = _unclippedDesiredSize.Height;
		}
		Size size2 = LayoutHelper.Max(_unclippedDesiredSize, item);
		_logDebug?.Debug($"{DepthIndentation}{FormatDebugName()}: InnerArrangeCore({finalRect}) - effectiveMaxSize={size2}, maxSize={item}, _unclippedDesiredSize={_unclippedDesiredSize}, forcedClipping={flag2}");
		if (flag)
		{
			if (IsLessThanAndNotCloseTo(size2.Width, size.Width))
			{
				_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}: (effectiveMaxSize.Width) {size2.Width} < {size.Width}: NEEDS CLIPPING.");
				flag2 = true;
				size.Width = size2.Width;
			}
			if (IsLessThanAndNotCloseTo(size2.Height, size.Height))
			{
				_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}: (effectiveMaxSize.Height) {size2.Height} < {size.Height}: NEEDS CLIPPING.");
				flag2 = true;
				size.Height = size2.Height;
			}
		}
		Size renderSize = base.RenderSize;
		Size size3 = ArrangeOverride(size);
		Size size4 = size3.AtMost(item);
		base.RenderSize = (flag2 ? size4 : size3);
		_logDebug?.Debug($"{DepthIndentation}{FormatDebugName()}: ArrangeOverride({size})={size3}, clipped={size4} (max={item}) needsClipToSlot={flag2}");
		Size clientSize = finalRect.Size.Subtract(marginSize).AtLeastZero();
		size4 = AdjustArrange(size4);
		(Point offset, bool overflow) alignmentOffset = this.GetAlignmentOffset(clientSize, size4);
		Point item2 = alignmentOffset.offset;
		bool item3 = alignmentOffset.overflow;
		Thickness margin = Margin;
		item2 = new Point(item2.X + finalRect.X + margin.Left, item2.Y + finalRect.Y + margin.Top);
		if (item3)
		{
			flag2 = true;
		}
		_logDebug?.Debug($"{DepthIndentation}[{FormatDebugName()}] ArrangeChild(offset={item2}, margin={margin}) [oldRenderSize={renderSize}] [RenderSize={base.RenderSize}] [clippedInkSize={size4}] [RequiresClipping={flag2}]");
		base.NeedsClipToSlot = flag2;
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMXamlProperty("NeedsClipToSlot", base.NeedsClipToSlot);
		}
		if (flag2)
		{
			Rect rect = new Rect(item2, size4);
			Rect rect2 = rect.IntersectWith(finalRect.DeflateBy(margin)) ?? Rect.Empty;
			Rect clippedFrame = new Rect(rect2.X - rect.X, rect2.Y - rect.Y, rect2.Width, rect2.Height);
			ArrangeNative(item2, needsClipToSlot: true, clippedFrame);
		}
		else
		{
			ArrangeNative(item2, needsClipToSlot: false);
		}
		OnLayoutUpdated();
	}

	private void ArrangeNative(Point offset, bool needsClipToSlot, Rect clippedFrame = default(Rect))
	{
		_visualOffset = offset;
		Rect rect = new Rect(offset, base.RenderSize);
		if (rect.Width < 0.0 || rect.Height < 0.0 || double.IsNaN(rect.Width) || double.IsNaN(rect.Height) || double.IsNaN(rect.X) || double.IsNaN(rect.Y))
		{
			throw new InvalidOperationException($"{FormatDebugName()}: Invalid frame size {rect}. No dimension should be NaN or negative value.");
		}
		RectangleGeometry clip = base.Clip;
		Rect? rect2 = ((clip != null) ? new Rect?(clip.Rect) : (needsClipToSlot ? new Rect?(clippedFrame) : null));
		_logDebug?.Trace($"{DepthIndentation}{FormatDebugName()}.ArrangeElementNative({rect}, clip={rect2} (NeedsClipToSlot={base.NeedsClipToSlot})");
		ArrangeVisual(rect, rect2);
	}

	private protected sealed override void OnFwEltLoading()
	{
		OnLoadingPartial();
		ApplyCompiledBindings();
		if (FeatureConfiguration.FrameworkElement.HandleLoadUnloadExceptions)
		{
			InvokeLoadingWithTry();
		}
		else
		{
			InvokeLoading();
		}
		OnPostLoading();
		void InvokeLoading()
		{
			OnLoading();
			this._loading?.Invoke(this, new RoutedEventArgs(this));
		}
		void InvokeLoadingWithTry()
		{
			try
			{
				InvokeLoading();
			}
			catch (Exception ex)
			{
				_log.Error("OnElementLoading failed in FrameworkElement", ex);
				Application.Current.RaiseRecoverableUnhandledException(ex);
			}
		}
	}

	private void OnLoadingPartial()
	{
		this.StoreTryEnableHardReferences();
		ApplyStyles();
	}

	private protected virtual void OnLoading()
	{
	}

	private protected virtual void OnPostLoading()
	{
	}

	private protected sealed override void OnFwEltLoaded()
	{
		if (FeatureConfiguration.FrameworkElement.HandleLoadUnloadExceptions)
		{
			InvokeLoadedWithTry();
		}
		else
		{
			InvokeLoaded();
		}
		void InvokeLoaded()
		{
			OnLoaded();
			this._loaded?.Invoke(this, new RoutedEventArgs(this));
		}
		void InvokeLoadedWithTry()
		{
			try
			{
				InvokeLoaded();
			}
			catch (Exception ex)
			{
				_log.Error("OnElementLoaded failed in FrameworkElement", ex);
				Application.Current.RaiseRecoverableUnhandledException(ex);
			}
		}
	}

	private protected virtual void OnLoaded()
	{
	}

	private protected sealed override void OnFwEltUnloaded()
	{
		if (FeatureConfiguration.FrameworkElement.HandleLoadUnloadExceptions)
		{
			InvokeUnloadedWithTry();
		}
		else
		{
			InvokeUnloaded();
		}
		void InvokeUnloaded()
		{
			OnUnloaded();
			this._unloaded?.Invoke(this, new RoutedEventArgs(this));
			OnUnloadedPartial();
		}
		void InvokeUnloadedWithTry()
		{
			try
			{
				InvokeUnloaded();
			}
			catch (Exception ex)
			{
				_log.Error("OnElementUnloaded failed in FrameworkElement", ex);
				Application.Current.RaiseRecoverableUnhandledException(ex);
			}
		}
	}

	private void OnUnloadedPartial()
	{
		this.StoreDisableHardReferences();
	}

	private protected virtual void OnUnloaded()
	{
	}

	public T FindFirstParent<T>() where T : class
	{
		return FindFirstParent<T>(includeCurrent: false);
	}

	public T FindFirstParent<T>(bool includeCurrent) where T : class
	{
		object obj;
		if (!includeCurrent)
		{
			obj = Parent;
		}
		else
		{
			obj = this;
		}
		for (DependencyObject dependencyObject = (DependencyObject)obj; dependencyObject != null; dependencyObject = dependencyObject.GetParent() as DependencyObject)
		{
			if (dependencyObject is T result)
			{
				return result;
			}
		}
		return null;
	}

	private void Initialize()
	{
		Resources = new ResourceDictionary();
		IFrameworkElementHelper.Initialize(this);
	}

	public FrameworkElement()
		: this("div", isSvg: false)
	{
	}

	public FrameworkElement(string htmlTag)
		: this(htmlTag, isSvg: false)
	{
	}

	public FrameworkElement(string htmlTag, bool isSvg)
		: base(htmlTag, isSvg)
	{
		Initialize();
		if (!FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
		{
			Loading += NativeOnLoading;
			Loaded += NativeOnLoaded;
			Unloaded += NativeOnUnloaded;
		}
		_log = this.Log();
		_logDebug = (_log.IsEnabled(LogLevel.Debug) ? _log : null);
	}

	private void OnTransitionsChanged(DependencyPropertyChangedEventArgs args)
	{
	}

	public object FindName(string name)
	{
		return IFrameworkElementHelper.FindName(this, GetChildren(), name);
	}

	public void Dispose()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Size AdjustArrange(Size finalSize)
	{
		return finalSize;
	}

	protected virtual void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
		SetAndObserveBackgroundBrush(e.NewValue as Brush);
	}

	private protected void SetAndObserveBackgroundBrush(Brush brush)
	{
		SerialDisposable serialDisposable = _backgroundSubscription ?? (_backgroundSubscription = new SerialDisposable());
		serialDisposable.Disposable = null;
		serialDisposable.Disposable = BorderLayerRenderer.SetAndObserveBackgroundBrush(this, brush);
	}

	public void ApplyBindingPhase(int phase)
	{
		throw new NotImplementedException();
	}

	private void NativeOnLoading(FrameworkElement sender, object args)
	{
		OnLoadingPartial();
		foreach (UIElement child in _children)
		{
			(child as FrameworkElement)?.InternalDispatchEvent("loading", args as EventArgs);
		}
	}

	private void NativeOnLoaded(object sender, RoutedEventArgs args)
	{
		base.IsLoaded = true;
		foreach (UIElement child in _children)
		{
			(child as FrameworkElement)?.InternalDispatchEvent("loaded", args);
		}
		RaiseOnLoadedSafe();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void RaiseOnLoadedSafe()
	{
		try
		{
			OnLoaded();
		}
		catch (Exception ex)
		{
			_log.Error("NativeOnLoaded failed in FrameworkElement", ex);
			Application.Current.RaiseRecoverableUnhandledException(ex);
		}
	}

	private void NativeOnUnloaded(object sender, RoutedEventArgs args)
	{
		base.IsLoaded = false;
		foreach (UIElement child in _children)
		{
			(child as FrameworkElement)?.InternalDispatchEvent("unloaded", args);
		}
		RaiseOnUnloadedSafe();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void RaiseOnUnloadedSafe()
	{
		try
		{
			OnUnloaded();
		}
		catch (Exception ex)
		{
			_log.Error("NativeOnUnloaded failed in FrameworkElement", ex);
			Application.Current.RaiseRecoverableUnhandledException(ex);
		}
	}

	public bool HasParent()
	{
		return Parent != null;
	}

	internal void RaiseSizeChanged(SizeChangedEventArgs args)
	{
		this.SizeChanged?.Invoke(this, args);
		_renderTransform?.UpdateSize(args.NewSize);
	}

	internal void SetActualSize(Size size)
	{
		base.AssignedActualSize = size;
	}

	private void OnGenericPropertyUpdatedPartial(DependencyPropertyChangedEventArgs args)
	{
		_constraintsChanged = true;
	}

	private bool IsTopLevelXamlView()
	{
		throw new NotSupportedException();
	}

	internal void SuspendRendering()
	{
		throw new NotSupportedException();
	}

	internal void ResumeRendering()
	{
		throw new NotSupportedException();
	}

	public IEnumerator GetEnumerator()
	{
		return _children.GetEnumerator();
	}

	protected void SetCornerRadius(CornerRadius cornerRadius)
	{
		BorderLayerRenderer.SetCornerRadius(this, cornerRadius);
	}

	protected void SetBorder(Thickness thickness, Brush brush)
	{
		BorderLayerRenderer.SetBorder(this, thickness, brush);
	}

	internal override bool IsEnabledOverride()
	{
		if (IsEnabled)
		{
			return base.IsEnabledOverride();
		}
		return false;
	}

	private static Thickness GetMarginDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnGenericPropertyUpdated(DependencyPropertyChangedEventArgs args)
	{
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMProperties();
		}
	}

	private protected override void UpdateDOMProperties()
	{
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties && IsLoaded)
		{
			UpdateDOMXamlProperty("Margin", Margin);
			UpdateDOMXamlProperty("HorizontalAlignment", HorizontalAlignment);
			UpdateDOMXamlProperty("VerticalAlignment", VerticalAlignment);
			UpdateDOMXamlProperty("Width", Width);
			UpdateDOMXamlProperty("Height", Height);
			UpdateDOMXamlProperty("MinWidth", MinWidth);
			UpdateDOMXamlProperty("MinHeight", MinHeight);
			UpdateDOMXamlProperty("MaxWidth", MaxWidth);
			UpdateDOMXamlProperty("MaxHeight", MaxHeight);
			UpdateDOMXamlProperty("IsEnabled", IsEnabled);
			if (this.TryGetPadding(out var padding))
			{
				UpdateDOMXamlProperty("Padding", padding);
			}
			base.UpdateDOMProperties();
		}
	}

	public override string ToString()
	{
		if (FeatureConfiguration.UIElement.RenderToStringWithId && !base.Name.IsNullOrEmpty())
		{
			return base.ToString() + "\"" + base.Name + "\"";
		}
		return base.ToString();
	}

	private object GetTagValue()
	{
		if (!_TagPropertyBackingFieldSet)
		{
			_TagPropertyBackingField = GetValue(TagProperty);
			_TagPropertyBackingFieldSet = true;
		}
		return _TagPropertyBackingField;
	}

	private void SetTagValue(object value)
	{
		SetValue(TagProperty, value);
	}

	private static DependencyProperty CreateTagProperty()
	{
		return DependencyProperty.Register("Tag", typeof(object), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnTagBackingFieldUpdate));
	}

	private static void OnTagBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._TagPropertyBackingField = newValue;
		frameworkElement._TagPropertyBackingFieldSet = true;
	}

	private Thickness GetFocusVisualSecondaryThicknessValue()
	{
		if (!_FocusVisualSecondaryThicknessPropertyBackingFieldSet)
		{
			_FocusVisualSecondaryThicknessPropertyBackingField = (Thickness)GetValue(FocusVisualSecondaryThicknessProperty);
			_FocusVisualSecondaryThicknessPropertyBackingFieldSet = true;
		}
		return _FocusVisualSecondaryThicknessPropertyBackingField;
	}

	private void SetFocusVisualSecondaryThicknessValue(Thickness value)
	{
		SetValue(FocusVisualSecondaryThicknessProperty, value);
	}

	private static DependencyProperty CreateFocusVisualSecondaryThicknessProperty()
	{
		return DependencyProperty.Register("FocusVisualSecondaryThickness", typeof(Thickness), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)GetFocusVisualSecondaryThicknessDefaultValue(), (BackingFieldUpdateCallback)OnFocusVisualSecondaryThicknessBackingFieldUpdate));
	}

	private static void OnFocusVisualSecondaryThicknessBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._FocusVisualSecondaryThicknessPropertyBackingField = (Thickness)newValue;
		frameworkElement._FocusVisualSecondaryThicknessPropertyBackingFieldSet = true;
	}

	private Brush GetFocusVisualSecondaryBrushValue()
	{
		if (!_FocusVisualSecondaryBrushPropertyBackingFieldSet)
		{
			_FocusVisualSecondaryBrushPropertyBackingField = (Brush)GetValue(FocusVisualSecondaryBrushProperty);
			_FocusVisualSecondaryBrushPropertyBackingFieldSet = true;
		}
		return _FocusVisualSecondaryBrushPropertyBackingField;
	}

	private void SetFocusVisualSecondaryBrushValue(Brush value)
	{
		SetValue(FocusVisualSecondaryBrushProperty, value);
	}

	private static DependencyProperty CreateFocusVisualSecondaryBrushProperty()
	{
		return DependencyProperty.Register("FocusVisualSecondaryBrush", typeof(Brush), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnFocusVisualSecondaryBrushBackingFieldUpdate));
	}

	private static void OnFocusVisualSecondaryBrushBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._FocusVisualSecondaryBrushPropertyBackingField = (Brush)newValue;
		frameworkElement._FocusVisualSecondaryBrushPropertyBackingFieldSet = true;
	}

	private Thickness GetFocusVisualPrimaryThicknessValue()
	{
		if (!_FocusVisualPrimaryThicknessPropertyBackingFieldSet)
		{
			_FocusVisualPrimaryThicknessPropertyBackingField = (Thickness)GetValue(FocusVisualPrimaryThicknessProperty);
			_FocusVisualPrimaryThicknessPropertyBackingFieldSet = true;
		}
		return _FocusVisualPrimaryThicknessPropertyBackingField;
	}

	private void SetFocusVisualPrimaryThicknessValue(Thickness value)
	{
		SetValue(FocusVisualPrimaryThicknessProperty, value);
	}

	private static DependencyProperty CreateFocusVisualPrimaryThicknessProperty()
	{
		return DependencyProperty.Register("FocusVisualPrimaryThickness", typeof(Thickness), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)GetFocusVisualPrimaryThicknessDefaultValue(), (BackingFieldUpdateCallback)OnFocusVisualPrimaryThicknessBackingFieldUpdate));
	}

	private static void OnFocusVisualPrimaryThicknessBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._FocusVisualPrimaryThicknessPropertyBackingField = (Thickness)newValue;
		frameworkElement._FocusVisualPrimaryThicknessPropertyBackingFieldSet = true;
	}

	private Brush GetFocusVisualPrimaryBrushValue()
	{
		if (!_FocusVisualPrimaryBrushPropertyBackingFieldSet)
		{
			_FocusVisualPrimaryBrushPropertyBackingField = (Brush)GetValue(FocusVisualPrimaryBrushProperty);
			_FocusVisualPrimaryBrushPropertyBackingFieldSet = true;
		}
		return _FocusVisualPrimaryBrushPropertyBackingField;
	}

	private void SetFocusVisualPrimaryBrushValue(Brush value)
	{
		SetValue(FocusVisualPrimaryBrushProperty, value);
	}

	private static DependencyProperty CreateFocusVisualPrimaryBrushProperty()
	{
		return DependencyProperty.Register("FocusVisualPrimaryBrush", typeof(Brush), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnFocusVisualPrimaryBrushBackingFieldUpdate));
	}

	private static void OnFocusVisualPrimaryBrushBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._FocusVisualPrimaryBrushPropertyBackingField = (Brush)newValue;
		frameworkElement._FocusVisualPrimaryBrushPropertyBackingFieldSet = true;
	}

	private Thickness GetFocusVisualMarginValue()
	{
		if (!_FocusVisualMarginPropertyBackingFieldSet)
		{
			_FocusVisualMarginPropertyBackingField = (Thickness)GetValue(FocusVisualMarginProperty);
			_FocusVisualMarginPropertyBackingFieldSet = true;
		}
		return _FocusVisualMarginPropertyBackingField;
	}

	private void SetFocusVisualMarginValue(Thickness value)
	{
		SetValue(FocusVisualMarginProperty, value);
	}

	private static DependencyProperty CreateFocusVisualMarginProperty()
	{
		return DependencyProperty.Register("FocusVisualMargin", typeof(Thickness), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)GetFocusVisualMarginDefaultValue(), (BackingFieldUpdateCallback)OnFocusVisualMarginBackingFieldUpdate));
	}

	private static void OnFocusVisualMarginBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._FocusVisualMarginPropertyBackingField = (Thickness)newValue;
		frameworkElement._FocusVisualMarginPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("AllowFocusWhenDisabled", typeof(bool), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.Inherits, (BackingFieldUpdateCallback)OnAllowFocusWhenDisabledBackingFieldUpdate));
	}

	private static void OnAllowFocusWhenDisabledBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._AllowFocusWhenDisabledPropertyBackingField = (bool)newValue;
		frameworkElement._AllowFocusWhenDisabledPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("AllowFocusOnInteraction", typeof(bool), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.Inherits, (BackingFieldUpdateCallback)OnAllowFocusOnInteractionBackingFieldUpdate));
	}

	private static void OnAllowFocusOnInteractionBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._AllowFocusOnInteractionPropertyBackingField = (bool)newValue;
		frameworkElement._AllowFocusOnInteractionPropertyBackingFieldSet = true;
	}

	private bool GetIsEnabledValue()
	{
		if (!_IsEnabledPropertyBackingFieldSet)
		{
			_IsEnabledPropertyBackingField = (bool)GetValue(IsEnabledProperty);
			_IsEnabledPropertyBackingFieldSet = true;
		}
		return _IsEnabledPropertyBackingField;
	}

	private void SetIsEnabledValue(bool value)
	{
		SetValue(IsEnabledProperty, value);
	}

	private static DependencyProperty CreateIsEnabledProperty()
	{
		return DependencyProperty.Register("IsEnabled", typeof(bool), typeof(FrameworkElement), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((FrameworkElement)instance).OnIsEnabledChanged(args);
		}, (DependencyObject instance, object baseValue) => ((FrameworkElement)instance).CoerceIsEnabled(baseValue), OnIsEnabledBackingFieldUpdate));
	}

	private static void OnIsEnabledBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._IsEnabledPropertyBackingField = (bool)newValue;
		frameworkElement._IsEnabledPropertyBackingFieldSet = true;
	}

	private TransitionCollection GetTransitionsValue()
	{
		if (!_TransitionsPropertyBackingFieldSet)
		{
			_TransitionsPropertyBackingField = (TransitionCollection)GetValue(TransitionsProperty);
			_TransitionsPropertyBackingFieldSet = true;
		}
		return _TransitionsPropertyBackingField;
	}

	private void SetTransitionsValue(TransitionCollection value)
	{
		SetValue(TransitionsProperty, value);
	}

	private static DependencyProperty CreateTransitionsProperty()
	{
		return DependencyProperty.Register("Transitions", typeof(TransitionCollection), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((FrameworkElement)instance).OnTransitionsChanged(args);
		}, (BackingFieldUpdateCallback)OnTransitionsBackingFieldUpdate));
	}

	private static void OnTransitionsBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._TransitionsPropertyBackingField = (TransitionCollection)newValue;
		frameworkElement._TransitionsPropertyBackingFieldSet = true;
	}

	private Brush GetBackgroundValue()
	{
		if (!_BackgroundPropertyBackingFieldSet)
		{
			_BackgroundPropertyBackingField = (Brush)GetValue(BackgroundProperty);
			_BackgroundPropertyBackingFieldSet = true;
		}
		return _BackgroundPropertyBackingField;
	}

	private void SetBackgroundValue(Brush value)
	{
		SetValue(BackgroundProperty, value);
	}

	private static DependencyProperty CreateBackgroundProperty()
	{
		return DependencyProperty.Register("Background", typeof(Brush), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((FrameworkElement)instance).OnBackgroundChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundBackingFieldUpdate));
	}

	private static void OnBackgroundBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._BackgroundPropertyBackingField = (Brush)newValue;
		frameworkElement._BackgroundPropertyBackingFieldSet = true;
	}

	private Thickness GetMarginValue()
	{
		if (!_MarginPropertyBackingFieldSet)
		{
			_MarginPropertyBackingField = (Thickness)GetValue(MarginProperty);
			_MarginPropertyBackingFieldSet = true;
		}
		return _MarginPropertyBackingField;
	}

	private void SetMarginValue(Thickness value)
	{
		SetValue(MarginProperty, value);
	}

	private static DependencyProperty CreateMarginProperty()
	{
		return DependencyProperty.Register("Margin", typeof(Thickness), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)GetMarginDefaultValue(), FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnMarginBackingFieldUpdate));
	}

	private static void OnMarginBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._MarginPropertyBackingField = (Thickness)newValue;
		frameworkElement._MarginPropertyBackingFieldSet = true;
	}

	private HorizontalAlignment GetHorizontalAlignmentValue()
	{
		if (!_HorizontalAlignmentPropertyBackingFieldSet)
		{
			_HorizontalAlignmentPropertyBackingField = (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
			_HorizontalAlignmentPropertyBackingFieldSet = true;
		}
		return _HorizontalAlignmentPropertyBackingField;
	}

	private void SetHorizontalAlignmentValue(HorizontalAlignment value)
	{
		SetValue(HorizontalAlignmentProperty, value);
	}

	private static DependencyProperty CreateHorizontalAlignmentProperty()
	{
		return DependencyProperty.Register("HorizontalAlignment", typeof(HorizontalAlignment), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)HorizontalAlignment.Stretch, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnHorizontalAlignmentBackingFieldUpdate));
	}

	private static void OnHorizontalAlignmentBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._HorizontalAlignmentPropertyBackingField = (HorizontalAlignment)newValue;
		frameworkElement._HorizontalAlignmentPropertyBackingFieldSet = true;
	}

	private VerticalAlignment GetVerticalAlignmentValue()
	{
		if (!_VerticalAlignmentPropertyBackingFieldSet)
		{
			_VerticalAlignmentPropertyBackingField = (VerticalAlignment)GetValue(VerticalAlignmentProperty);
			_VerticalAlignmentPropertyBackingFieldSet = true;
		}
		return _VerticalAlignmentPropertyBackingField;
	}

	private void SetVerticalAlignmentValue(VerticalAlignment value)
	{
		SetValue(VerticalAlignmentProperty, value);
	}

	private static DependencyProperty CreateVerticalAlignmentProperty()
	{
		return DependencyProperty.Register("VerticalAlignment", typeof(VerticalAlignment), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)VerticalAlignment.Stretch, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnVerticalAlignmentBackingFieldUpdate));
	}

	private static void OnVerticalAlignmentBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._VerticalAlignmentPropertyBackingField = (VerticalAlignment)newValue;
		frameworkElement._VerticalAlignmentPropertyBackingFieldSet = true;
	}

	private double GetWidthValue()
	{
		if (!_WidthPropertyBackingFieldSet)
		{
			_WidthPropertyBackingField = (double)GetValue(WidthProperty);
			_WidthPropertyBackingFieldSet = true;
		}
		return _WidthPropertyBackingField;
	}

	private void SetWidthValue(double value)
	{
		SetValue(WidthProperty, value);
	}

	private static DependencyProperty CreateWidthProperty()
	{
		return DependencyProperty.Register("Width", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnWidthBackingFieldUpdate));
	}

	private static void OnWidthBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._WidthPropertyBackingField = (double)newValue;
		frameworkElement._WidthPropertyBackingFieldSet = true;
	}

	private double GetHeightValue()
	{
		if (!_HeightPropertyBackingFieldSet)
		{
			_HeightPropertyBackingField = (double)GetValue(HeightProperty);
			_HeightPropertyBackingFieldSet = true;
		}
		return _HeightPropertyBackingField;
	}

	private void SetHeightValue(double value)
	{
		SetValue(HeightProperty, value);
	}

	private static DependencyProperty CreateHeightProperty()
	{
		return DependencyProperty.Register("Height", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)double.NaN, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnHeightBackingFieldUpdate));
	}

	private static void OnHeightBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._HeightPropertyBackingField = (double)newValue;
		frameworkElement._HeightPropertyBackingFieldSet = true;
	}

	private double GetMinWidthValue()
	{
		if (!_MinWidthPropertyBackingFieldSet)
		{
			_MinWidthPropertyBackingField = (double)GetValue(MinWidthProperty);
			_MinWidthPropertyBackingFieldSet = true;
		}
		return _MinWidthPropertyBackingField;
	}

	private void SetMinWidthValue(double value)
	{
		SetValue(MinWidthProperty, value);
	}

	private static DependencyProperty CreateMinWidthProperty()
	{
		return DependencyProperty.Register("MinWidth", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnMinWidthBackingFieldUpdate));
	}

	private static void OnMinWidthBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._MinWidthPropertyBackingField = (double)newValue;
		frameworkElement._MinWidthPropertyBackingFieldSet = true;
	}

	private double GetMinHeightValue()
	{
		if (!_MinHeightPropertyBackingFieldSet)
		{
			_MinHeightPropertyBackingField = (double)GetValue(MinHeightProperty);
			_MinHeightPropertyBackingFieldSet = true;
		}
		return _MinHeightPropertyBackingField;
	}

	private void SetMinHeightValue(double value)
	{
		SetValue(MinHeightProperty, value);
	}

	private static DependencyProperty CreateMinHeightProperty()
	{
		return DependencyProperty.Register("MinHeight", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnMinHeightBackingFieldUpdate));
	}

	private static void OnMinHeightBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._MinHeightPropertyBackingField = (double)newValue;
		frameworkElement._MinHeightPropertyBackingFieldSet = true;
	}

	private double GetMaxWidthValue()
	{
		if (!_MaxWidthPropertyBackingFieldSet)
		{
			_MaxWidthPropertyBackingField = (double)GetValue(MaxWidthProperty);
			_MaxWidthPropertyBackingFieldSet = true;
		}
		return _MaxWidthPropertyBackingField;
	}

	private void SetMaxWidthValue(double value)
	{
		SetValue(MaxWidthProperty, value);
	}

	private static DependencyProperty CreateMaxWidthProperty()
	{
		return DependencyProperty.Register("MaxWidth", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnMaxWidthBackingFieldUpdate));
	}

	private static void OnMaxWidthBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._MaxWidthPropertyBackingField = (double)newValue;
		frameworkElement._MaxWidthPropertyBackingFieldSet = true;
	}

	private double GetMaxHeightValue()
	{
		if (!_MaxHeightPropertyBackingFieldSet)
		{
			_MaxHeightPropertyBackingField = (double)GetValue(MaxHeightProperty);
			_MaxHeightPropertyBackingFieldSet = true;
		}
		return _MaxHeightPropertyBackingField;
	}

	private void SetMaxHeightValue(double value)
	{
		SetValue(MaxHeightProperty, value);
	}

	private static DependencyProperty CreateMaxHeightProperty()
	{
		return DependencyProperty.Register("MaxHeight", typeof(double), typeof(FrameworkElement), new FrameworkPropertyMetadata((object)double.PositiveInfinity, FrameworkPropertyMetadataOptions.AutoConvert | FrameworkPropertyMetadataOptions.AffectsMeasure, (BackingFieldUpdateCallback)OnMaxHeightBackingFieldUpdate));
	}

	private static void OnMaxHeightBackingFieldUpdate(object instance, object newValue)
	{
		FrameworkElement frameworkElement = instance as FrameworkElement;
		frameworkElement._MaxHeightPropertyBackingField = (double)newValue;
		frameworkElement._MaxHeightPropertyBackingFieldSet = true;
	}
}
