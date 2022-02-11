using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Uno;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class Control : FrameworkElement
{
	private protected class StateChangeSuspender : IDisposable
	{
		private readonly Control _control;

		public StateChangeSuspender(Control control)
		{
			_control = control ?? throw new ArgumentNullException("control");
			_control._suspendStateChanges = true;
		}

		public void Dispose()
		{
			_control._suspendStateChanges = false;
			_control.UpdateVisualState();
		}
	}

	private bool _suspendStateChanges;

	private UIElement _templatedRoot;

	private bool _updateTemplate;

	private ControlTemplate _controlTemplateUsedLastUpdate;

	private bool _applyTemplateShouldBeInvoked;

	private static readonly PointerEventHandler OnPointerPressedHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerPressed(args);
	};

	private static readonly PointerEventHandler OnPointerReleasedHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerReleased(args);
	};

	private static readonly PointerEventHandler OnPointerEnteredHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerEntered(args);
	};

	private static readonly PointerEventHandler OnPointerExitedHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerExited(args);
	};

	private static readonly PointerEventHandler OnPointerMovedHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerMoved(args);
	};

	private static readonly PointerEventHandler OnPointerCanceledHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerCanceled(args);
	};

	private static readonly PointerEventHandler OnPointerCaptureLostHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerCaptureLost(args);
	};

	private static readonly PointerEventHandler OnPointerWheelChangedHandler = delegate(object sender, PointerRoutedEventArgs args)
	{
		((Control)sender).OnPointerWheelChanged(args);
	};

	private static readonly ManipulationStartingEventHandler OnManipulationStartingHandler = delegate(object sender, ManipulationStartingRoutedEventArgs args)
	{
		((Control)sender).OnManipulationStarting(args);
	};

	private static readonly ManipulationStartedEventHandler OnManipulationStartedHandler = delegate(object sender, ManipulationStartedRoutedEventArgs args)
	{
		((Control)sender).OnManipulationStarted(args);
	};

	private static readonly ManipulationDeltaEventHandler OnManipulationDeltaHandler = delegate(object sender, ManipulationDeltaRoutedEventArgs args)
	{
		((Control)sender).OnManipulationDelta(args);
	};

	private static readonly ManipulationInertiaStartingEventHandler OnManipulationInertiaStartingHandler = delegate(object sender, ManipulationInertiaStartingRoutedEventArgs args)
	{
		((Control)sender).OnManipulationInertiaStarting(args);
	};

	private static readonly ManipulationCompletedEventHandler OnManipulationCompletedHandler = delegate(object sender, ManipulationCompletedRoutedEventArgs args)
	{
		((Control)sender).OnManipulationCompleted(args);
	};

	private static readonly TappedEventHandler OnTappedHandler = delegate(object sender, TappedRoutedEventArgs args)
	{
		((Control)sender).OnTapped(args);
	};

	private static readonly DoubleTappedEventHandler OnDoubleTappedHandler = delegate(object sender, DoubleTappedRoutedEventArgs args)
	{
		((Control)sender).OnDoubleTapped(args);
	};

	private static readonly RightTappedEventHandler OnRightTappedHandler = delegate(object sender, RightTappedRoutedEventArgs args)
	{
		((Control)sender).OnRightTapped(args);
	};

	private static readonly HoldingEventHandler OnHoldingHandler = delegate(object sender, HoldingRoutedEventArgs args)
	{
		((Control)sender).OnHolding(args);
	};

	private static readonly DragEventHandler OnDragEnterHandler = delegate(object sender, DragEventArgs args)
	{
		((Control)sender).OnDragEnter(args);
	};

	private static readonly DragEventHandler OnDragOverHandler = delegate(object sender, DragEventArgs args)
	{
		((Control)sender).OnDragOver(args);
	};

	private static readonly DragEventHandler OnDragLeaveHandler = delegate(object sender, DragEventArgs args)
	{
		((Control)sender).OnDragLeave(args);
	};

	private static readonly DragEventHandler OnDropHandler = delegate(object sender, DragEventArgs args)
	{
		((Control)sender).OnDrop(args);
	};

	private static readonly KeyEventHandler OnKeyDownHandler = delegate(object sender, KeyRoutedEventArgs args)
	{
		((Control)sender).OnKeyDown(args);
	};

	private static readonly KeyEventHandler OnKeyUpHandler = delegate(object sender, KeyRoutedEventArgs args)
	{
		((Control)sender).OnKeyUp(args);
	};

	private static readonly RoutedEventHandler OnGotFocusHandler = delegate(object sender, RoutedEventArgs args)
	{
		((Control)sender).OnGotFocus(args);
	};

	private static readonly RoutedEventHandler OnLostFocusHandler = delegate(object sender, RoutedEventArgs args)
	{
		((Control)sender).OnLostFocus(args);
	};

	private static readonly Dictionary<Type, RoutedEventFlag> ImplementedRoutedEvents = new Dictionary<Type, RoutedEventFlag>();

	private static readonly Type[] _pointerArgsType = new Type[1] { typeof(PointerRoutedEventArgs) };

	private static readonly Type[] _tappedArgsType = new Type[1] { typeof(TappedRoutedEventArgs) };

	private static readonly Type[] _doubleTappedArgsType = new Type[1] { typeof(DoubleTappedRoutedEventArgs) };

	private static readonly Type[] _rightTappedArgsType = new Type[1] { typeof(RightTappedRoutedEventArgs) };

	private static readonly Type[] _holdingArgsType = new Type[1] { typeof(HoldingRoutedEventArgs) };

	private static readonly Type[] _dragArgsType = new Type[1] { typeof(DragEventArgs) };

	private static readonly Type[] _keyArgsType = new Type[1] { typeof(KeyRoutedEventArgs) };

	private static readonly Type[] _routedArgsType = new Type[1] { typeof(RoutedEventArgs) };

	private static readonly Type[] _manipStartingArgsType = new Type[1] { typeof(ManipulationStartingRoutedEventArgs) };

	private static readonly Type[] _manipStartedArgsType = new Type[1] { typeof(ManipulationStartedRoutedEventArgs) };

	private static readonly Type[] _manipDeltaArgsType = new Type[1] { typeof(ManipulationDeltaRoutedEventArgs) };

	private static readonly Type[] _manipInertiaArgsType = new Type[1] { typeof(ManipulationInertiaStartingRoutedEventArgs) };

	private static readonly Type[] _manipCompletedArgsType = new Type[1] { typeof(ManipulationCompletedRoutedEventArgs) };

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	private bool _IsFocusEngagedPropertyBackingFieldSet;

	private bool _IsFocusEngagedPropertyBackingField;

	private bool _IsFocusEngagementEnabledPropertyBackingFieldSet;

	private bool _IsFocusEngagementEnabledPropertyBackingField;

	internal bool __Control_IsTemplateFocusTargetPropertyBackingFieldSet;

	internal bool __Control_IsTemplateFocusTargetPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FontStretch FontStretch
	{
		get
		{
			return (FontStretch)GetValue(FontStretchProperty);
		}
		set
		{
			SetValue(FontStretchProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int CharacterSpacing
	{
		get
		{
			return (int)GetValue(CharacterSpacingProperty);
		}
		set
		{
			SetValue(CharacterSpacingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTextScaleFactorEnabled
	{
		get
		{
			return (bool)GetValue(IsTextScaleFactorEnabledProperty);
		}
		set
		{
			SetValue(IsTextScaleFactorEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RequiresPointer RequiresPointer
	{
		get
		{
			return (RequiresPointer)GetValue(RequiresPointerProperty);
		}
		set
		{
			SetValue(RequiresPointerProperty, value);
		}
	}

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
	public Uri DefaultStyleResourceUri
	{
		get
		{
			return (Uri)GetValue(DefaultStyleResourceUriProperty);
		}
		set
		{
			SetValue(DefaultStyleResourceUriProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FontStretchProperty { get; } = DependencyProperty.Register("FontStretch", typeof(FontStretch), typeof(Control), new FrameworkPropertyMetadata(FontStretch.Undefined));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CharacterSpacingProperty { get; } = DependencyProperty.Register("CharacterSpacing", typeof(int), typeof(Control), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultStyleKeyProperty { get; } = DependencyProperty.Register("DefaultStyleKey", typeof(object), typeof(Control), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(Control), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ElementSoundModeProperty { get; } = DependencyProperty.Register("ElementSoundMode", typeof(ElementSoundMode), typeof(Control), new FrameworkPropertyMetadata(ElementSoundMode.Default));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RequiresPointerProperty { get; } = DependencyProperty.Register("RequiresPointer", typeof(RequiresPointer), typeof(Control), new FrameworkPropertyMetadata(RequiresPointer.Never));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultStyleResourceUriProperty { get; } = DependencyProperty.Register("DefaultStyleResourceUri", typeof(Uri), typeof(Control), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTemplateKeyTipTargetProperty { get; } = DependencyProperty.RegisterAttached("IsTemplateKeyTipTarget", typeof(bool), typeof(Control), new FrameworkPropertyMetadata(false));


	protected object DefaultStyleKey { get; set; }

	private protected override bool IsTabStopDefaultValue => true;

	protected override bool IsSimpleLayout => true;

	public ControlTemplate Template
	{
		get
		{
			return (ControlTemplate)GetValue(TemplateProperty);
		}
		set
		{
			SetValue(TemplateProperty, value);
		}
	}

	public static DependencyProperty TemplateProperty { get; } = DependencyProperty.Register("Template", typeof(ControlTemplate), typeof(Control), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnTemplateChanged(e);
	}));


	internal UIElement TemplatedRoot
	{
		get
		{
			return _templatedRoot;
		}
		set
		{
			if (_templatedRoot == value)
			{
				return;
			}
			CleanupView(_templatedRoot);
			UnregisterSubView();
			_templatedRoot = value;
			if (value == null)
			{
				return;
			}
			IDependencyObjectStoreProvider templatedRoot = _templatedRoot;
			templatedRoot?.Store.SetValue(templatedRoot.Store.TemplatedParentProperty, this, DependencyPropertyValuePrecedences.Local);
			RegisterSubView(value);
			if (_templatedRoot != null)
			{
				if (!base.IsLoading && !base.IsLoaded && FeatureConfiguration.Control.UseDeferredOnApplyTemplate)
				{
					_applyTemplateShouldBeInvoked = true;
				}
				else
				{
					OnApplyTemplate();
				}
			}
		}
	}

	protected virtual bool CanCreateTemplateWithoutParent { get; }

	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			SetValue(ForegroundProperty, value);
		}
	}

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(Control), new FrameworkPropertyMetadata(SolidColorBrushHelper.Black, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnForegroundColorChanged(e.OldValue as Brush, e.NewValue as Brush);
	}));


	public FontWeight FontWeight
	{
		get
		{
			return (FontWeight)GetValue(FontWeightProperty);
		}
		set
		{
			SetValue(FontWeightProperty, value);
		}
	}

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(Control), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnFontWeightChanged((FontWeight)e.OldValue, (FontWeight)e.NewValue);
	}));


	public double FontSize
	{
		get
		{
			return (double)GetValue(FontSizeProperty);
		}
		set
		{
			SetValue(FontSizeProperty, value);
		}
	}

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(Control), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnFontSizeChanged((double)e.OldValue, (double)e.NewValue);
	}));


	public FontFamily FontFamily
	{
		get
		{
			return (FontFamily)GetValue(FontFamilyProperty);
		}
		set
		{
			SetValue(FontFamilyProperty, value);
		}
	}

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(Control), new FrameworkPropertyMetadata(FontFamily.Default, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnFontFamilyChanged(e.OldValue as FontFamily, e.NewValue as FontFamily);
	}));


	public FontStyle FontStyle
	{
		get
		{
			return (FontStyle)GetValue(FontStyleProperty);
		}
		set
		{
			SetValue(FontStyleProperty, value);
		}
	}

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(Control), new FrameworkPropertyMetadata(FontStyle.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnFontStyleChanged((FontStyle)e.OldValue, (FontStyle)e.NewValue);
	}));


	public Thickness Padding
	{
		get
		{
			return (Thickness)GetValue(PaddingProperty);
		}
		set
		{
			SetValue(PaddingProperty, value);
		}
	}

	public static DependencyProperty PaddingProperty { get; } = DependencyProperty.Register("Padding", typeof(Thickness), typeof(Control), new FrameworkPropertyMetadata(Thickness.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
	}));


	public Thickness BorderThickness
	{
		get
		{
			return (Thickness)GetValue(BorderThicknessProperty);
		}
		set
		{
			SetValue(BorderThicknessProperty, value);
		}
	}

	public static DependencyProperty BorderThicknessProperty { get; } = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(Control), new FrameworkPropertyMetadata(Thickness.Empty, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnBorderThicknessChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
	}));


	public Brush BorderBrush
	{
		get
		{
			return (Brush)GetValue(BorderBrushProperty);
		}
		set
		{
			SetValue(BorderBrushProperty, value);
		}
	}

	public static DependencyProperty BorderBrushProperty { get; } = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Control), new FrameworkPropertyMetadata(SolidColorBrushHelper.Transparent, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s).OnBorderBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
	}));


	public CornerRadius CornerRadius
	{
		get
		{
			return GetCornerRadiusValue();
		}
		set
		{
			SetCornerRadiusValue(value);
		}
	}

	[GeneratedDependencyProperty]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


	public KeyboardNavigationMode TabNavigation
	{
		get
		{
			return base.TabFocusNavigation;
		}
		set
		{
			base.TabFocusNavigation = value;
		}
	}

	public static DependencyProperty TabNavigationProperty => UIElement.TabFocusNavigationProperty;

	[GeneratedDependencyProperty(DefaultValue = false, AttachedBackingFieldOwner = typeof(Control), Attached = true)]
	public static DependencyProperty IsTemplateFocusTargetProperty { get; } = CreateIsTemplateFocusTargetProperty();


	public bool IsFocusEngaged
	{
		get
		{
			return GetIsFocusEngagedValue();
		}
		set
		{
			SetIsFocusEngagedValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false, ChangedCallback = true)]
	public static DependencyProperty IsFocusEngagedProperty { get; } = CreateIsFocusEngagedProperty();


	public bool IsFocusEngagementEnabled
	{
		get
		{
			return GetIsFocusEngagementEnabledValue();
		}
		set
		{
			SetIsFocusEngagementEnabledValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false)]
	public static DependencyProperty IsFocusEngagementEnabledProperty { get; } = CreateIsFocusEngagementEnabledProperty();


	public new FocusState FocusState
	{
		get
		{
			return base.FocusState;
		}
		set
		{
			base.FocusState = value;
		}
	}

	public new static DependencyProperty FocusStateProperty => UIElement.FocusStateProperty;

	public new bool IsTabStop
	{
		get
		{
			return base.IsTabStop;
		}
		set
		{
			base.IsTabStop = value;
		}
	}

	public new static DependencyProperty IsTabStopProperty => UIElement.IsTabStopProperty;

	public new int TabIndex
	{
		get
		{
			return base.TabIndex;
		}
		set
		{
			base.TabIndex = value;
		}
	}

	public new static DependencyProperty TabIndexProperty => UIElement.TabIndexProperty;

	public new DependencyObject XYFocusUp
	{
		get
		{
			return base.XYFocusUp;
		}
		set
		{
			base.XYFocusUp = value;
		}
	}

	public new static DependencyProperty XYFocusUpProperty => UIElement.XYFocusUpProperty;

	public new DependencyObject XYFocusDown
	{
		get
		{
			return base.XYFocusDown;
		}
		set
		{
			base.XYFocusDown = value;
		}
	}

	public new static DependencyProperty XYFocusDownProperty => UIElement.XYFocusDownProperty;

	public new DependencyObject XYFocusLeft
	{
		get
		{
			return base.XYFocusLeft;
		}
		set
		{
			base.XYFocusLeft = value;
		}
	}

	public new static DependencyProperty XYFocusLeftProperty => UIElement.XYFocusLeftProperty;

	public new DependencyObject XYFocusRight
	{
		get
		{
			return base.XYFocusRight;
		}
		set
		{
			base.XYFocusRight = value;
		}
	}

	public new static DependencyProperty XYFocusRightProperty => UIElement.XYFocusRightProperty;

	public new bool UseSystemFocusVisuals
	{
		get
		{
			return base.UseSystemFocusVisuals;
		}
		set
		{
			base.UseSystemFocusVisuals = value;
		}
	}

	public new static DependencyProperty UseSystemFocusVisualsProperty => UIElement.UseSystemFocusVisualsProperty;

	internal UIElement? FocusTargetDescendant => FindFocusTargetDescendant(this);

	public new static DependencyProperty IsEnabledProperty => FrameworkElement.IsEnabledProperty;

	public BackgroundSizing BackgroundSizing
	{
		get
		{
			return (BackgroundSizing)GetValue(BackgroundSizingProperty);
		}
		set
		{
			SetValue(BackgroundSizingProperty, value);
		}
	}

	public static DependencyProperty BackgroundSizingProperty { get; } = DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(Control), new FrameworkPropertyMetadata(BackgroundSizing.InnerBorderEdge, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnBackgroundSizingChanged((BackgroundSizing)e.OldValue, (BackgroundSizing)e.NewValue);
	}));


	public HorizontalAlignment HorizontalContentAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalContentAlignmentProperty, value);
		}
	}

	public static DependencyProperty HorizontalContentAlignmentProperty { get; } = DependencyProperty.Register("HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(Control), new FrameworkPropertyMetadata((!FeatureConfiguration.Control.UseLegacyContentAlignment) ? HorizontalAlignment.Center : HorizontalAlignment.Left, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnHorizontalContentAlignmentChanged((HorizontalAlignment)e.OldValue, (HorizontalAlignment)e.NewValue);
	}));


	public VerticalAlignment VerticalContentAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalContentAlignmentProperty);
		}
		set
		{
			SetValue(VerticalContentAlignmentProperty, value);
		}
	}

	public static DependencyProperty VerticalContentAlignmentProperty { get; } = DependencyProperty.Register("VerticalContentAlignment", typeof(VerticalAlignment), typeof(Control), new FrameworkPropertyMetadata((!FeatureConfiguration.Control.UseLegacyContentAlignment) ? VerticalAlignment.Center : VerticalAlignment.Top, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Control)s)?.OnVerticalContentAlignmentChanged((VerticalAlignment)e.OldValue, (VerticalAlignment)e.NewValue);
	}));


	public event TypedEventHandler<Control, FocusDisengagedEventArgs> FocusDisengaged;

	public event TypedEventHandler<Control, FocusEngagedEventArgs> FocusEngaged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnPreviewKeyDown(KeyRoutedEventArgs e)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Control", "void Control.OnPreviewKeyDown(KeyRoutedEventArgs e)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnPreviewKeyUp(KeyRoutedEventArgs e)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Control", "void Control.OnPreviewKeyUp(KeyRoutedEventArgs e)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnCharacterReceived(CharacterReceivedRoutedEventArgs e)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Control", "void Control.OnCharacterReceived(CharacterReceivedRoutedEventArgs e)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsTemplateKeyTipTarget(DependencyObject element)
	{
		return (bool)element.GetValue(IsTemplateKeyTipTargetProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsTemplateKeyTipTarget(DependencyObject element, bool value)
	{
		element.SetValue(IsTemplateKeyTipTargetProperty, value);
	}

	private void InitializeControl()
	{
		SetDefaultForeground(ForegroundProperty);
		SubscribeToOverridenRoutedEvents();
		OnIsFocusableChanged();
		DefaultStyleKey = typeof(Control);
	}

	internal override bool IsEnabledOverride()
	{
		if (base.IsEnabled)
		{
			return base.IsEnabledOverride();
		}
		return false;
	}

	internal override void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		base.UpdateThemeBindings(updateReason);
		SetDefaultForeground(ForegroundProperty);
	}

	private protected override Type GetDefaultStyleKey()
	{
		return DefaultStyleKey as Type;
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	internal virtual void UpdateVisualState(bool useTransitions = true)
	{
		if (!_suspendStateChanges)
		{
			ChangeVisualState(useTransitions);
		}
	}

	private protected virtual void ChangeVisualState(bool useTransitions)
	{
	}

	private void UnregisterSubView()
	{
		UIElement uIElement = GetChildren()?.FirstOrDefault();
		if (uIElement != null)
		{
			RemoveChild(uIElement);
		}
	}

	private void RegisterSubView(UIElement child)
	{
		AddChild(child);
	}

	private void OnTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		_updateTemplate = true;
		SetUpdateControlTemplate();
	}

	internal void SetUpdateControlTemplate(bool forceUpdate = false)
	{
		if (!FeatureConfiguration.Control.UseLegacyLazyApplyTemplate || forceUpdate || HasParent() || CanCreateTemplateWithoutParent)
		{
			UpdateTemplate();
			InvalidateMeasure();
		}
	}

	private protected override void OnPostLoading()
	{
		base.OnPostLoading();
		TryCallOnApplyTemplate();
	}

	private void TryCallOnApplyTemplate()
	{
		if (_applyTemplateShouldBeInvoked)
		{
			_applyTemplateShouldBeInvoked = false;
			OnApplyTemplate();
		}
	}

	private void SubscribeToOverridenRoutedEvents()
	{
		RoutedEventFlag implementedRoutedEvents = GetImplementedRoutedEvents(GetType());
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerPressed))
		{
			base.PointerPressed += OnPointerPressedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerReleased))
		{
			base.PointerReleased += OnPointerReleasedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerMoved))
		{
			base.PointerMoved += OnPointerMovedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerEntered))
		{
			base.PointerEntered += OnPointerEnteredHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerExited))
		{
			base.PointerExited += OnPointerExitedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerCanceled))
		{
			base.PointerCanceled += OnPointerCanceledHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerCaptureLost))
		{
			base.PointerCaptureLost += OnPointerCaptureLostHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.PointerWheelChanged))
		{
			base.PointerWheelChanged += OnPointerWheelChangedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.ManipulationStarting))
		{
			base.ManipulationStarting += OnManipulationStartingHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.ManipulationStarted))
		{
			base.ManipulationStarted += OnManipulationStartedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.ManipulationDelta))
		{
			base.ManipulationDelta += OnManipulationDeltaHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.ManipulationInertiaStarting))
		{
			base.ManipulationInertiaStarting += OnManipulationInertiaStartingHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.ManipulationCompleted))
		{
			base.ManipulationCompleted += OnManipulationCompletedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.Tapped))
		{
			base.Tapped += OnTappedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.DoubleTapped))
		{
			base.DoubleTapped += OnDoubleTappedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.RightTapped))
		{
			base.RightTapped += OnRightTappedHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.DragEnter))
		{
			base.DragEnter += OnDragEnterHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.DragOver))
		{
			base.DragOver += OnDragOverHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.DragLeave))
		{
			base.DragLeave += OnDragLeaveHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.Drop))
		{
			base.Drop += OnDropHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.Holding))
		{
			base.Holding += OnHoldingHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.KeyDown))
		{
			base.KeyDown += OnKeyDownHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.KeyUp))
		{
			base.KeyUp += OnKeyUpHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.GotFocus))
		{
			base.GotFocus += OnGotFocusHandler;
		}
		if (implementedRoutedEvents.HasFlag(RoutedEventFlag.LostFocus))
		{
			base.LostFocus += OnLostFocusHandler;
		}
	}

	private protected override void OnLoaded()
	{
		SetUpdateControlTemplate();
		base.OnLoaded();
	}

	public bool ApplyTemplate()
	{
		UIElement templatedRoot = _templatedRoot;
		SetUpdateControlTemplate(forceUpdate: true);
		TryCallOnApplyTemplate();
		return templatedRoot != _templatedRoot;
	}

	internal void EnsureTemplate()
	{
		ApplyStyles();
		ApplyTemplate();
	}

	public DependencyObject GetTemplateChild(string childName)
	{
		return (FindNameInScope(TemplatedRoot as IFrameworkElement, childName) as DependencyObject) ?? (FindName(childName) as DependencyObject);
	}

	internal T GetTemplateChild<T>(string childName) where T : class, DependencyObject
	{
		return (FindNameInScope(TemplatedRoot as IFrameworkElement, childName) as T) ?? (FindName(childName) as T);
	}

	private static object FindNameInScope(IFrameworkElement root, string name)
	{
		if (root != null && name != null)
		{
			INameScope nameScope = NameScope.GetNameScope(root);
			if (nameScope != null && nameScope.FindName(name) is DependencyObject dependencyObject && !(dependencyObject is ElementStub))
			{
				return dependencyObject;
			}
		}
		return null;
	}

	private void CleanupView(UIElement view)
	{
		if (view != null)
		{
			((IDependencyObjectStoreProvider)view).Store.Parent = null;
			((IDependencyObjectStoreProvider)view).Store.ClearValue(((IDependencyObjectStoreProvider)view).Store.TemplatedParentProperty, DependencyPropertyValuePrecedences.Local);
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		if (oldValue == Visibility.Collapsed && newValue == Visibility.Visible)
		{
			SetUpdateControlTemplate();
		}
		OnIsFocusableChanged();
	}

	private void UpdateTemplate()
	{
		if (TemplatedRoot == null)
		{
			_controlTemplateUsedLastUpdate = null;
		}
		if (_updateTemplate && !object.Equals(Template, _controlTemplateUsedLastUpdate))
		{
			_controlTemplateUsedLastUpdate = Template;
			if (Template != null)
			{
				TemplatedRoot = Template.LoadContentCached();
			}
			else
			{
				TemplatedRoot = null;
			}
			_updateTemplate = false;
		}
	}

	protected override void OnApplyTemplate()
	{
	}

	public static CornerRadius GetCornerRadiusDefaultValue()
	{
		return default(CornerRadius);
	}

	public static bool GetIsTemplateFocusTarget(FrameworkElement element)
	{
		return GetIsTemplateFocusTargetValue(element);
	}

	public static void SetIsTemplateFocusTarget(FrameworkElement element, bool value)
	{
		SetIsTemplateFocusTargetValue(element, value);
	}

	private void OnIsFocusEngagedChanged(bool oldValue, bool newValue)
	{
		SetFocusEngagement();
	}

	private void OnIsFocusEngagementEnabledChanged(bool oldValue, bool newValue)
	{
		RemoveFocusEngagement();
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		OnDataContextChanged();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual void OnDataContextChanged()
	{
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs e)
	{
		base.OnIsEnabledChanged(e);
		OnIsFocusableChanged();
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (focusManagerForElement == null)
		{
			return;
		}
		if (IsFocusable && focusManagerForElement.FocusedElement == null)
		{
			UIElement firstFocusableElement = focusManagerForElement.GetFirstFocusableElement();
			if (this == firstFocusableElement)
			{
				Focus(FocusState.Programmatic, animateIfBringIntoView: false);
			}
		}
		if (!base.IsEnabled && !base.AllowFocusWhenDisabled && FocusProperties.HasFocusedElement(this))
		{
			focusManagerForElement.SetFocusOnNextFocusableElement(focusManagerForElement.GetRealFocusStateForFocusedElement(), shouldFireFocusedRemoved: true);
		}
	}

	private void OnIsFocusableChanged()
	{
		bool flag = IsFocusable && !IsDelegatingFocusToTemplateChild();
		SetAttribute("tabindex", flag ? "0" : "-1");
	}

	protected virtual void OnForegroundColorChanged(Brush oldValue, Brush newValue)
	{
	}

	protected virtual void OnFontWeightChanged(FontWeight oldValue, FontWeight newValue)
	{
	}

	protected virtual void OnFontFamilyChanged(FontFamily oldValue, FontFamily newValue)
	{
	}

	protected virtual void OnFontSizeChanged(double oldValue, double newValue)
	{
	}

	protected virtual void OnFontStyleChanged(FontStyle oldValue, FontStyle newValue)
	{
	}

	protected virtual void OnPaddingChanged(Thickness oldValue, Thickness newValue)
	{
	}

	protected virtual void OnBorderThicknessChanged(Thickness oldValue, Thickness newValue)
	{
	}

	protected virtual void OnBorderBrushChanged(Brush oldValue, Brush newValue)
	{
	}

	protected virtual void OnPointerPressed(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerReleased(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerEntered(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerExited(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerMoved(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerCanceled(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerCaptureLost(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnPointerWheelChanged(PointerRoutedEventArgs e)
	{
	}

	protected virtual void OnManipulationStarting(ManipulationStartingRoutedEventArgs e)
	{
	}

	protected virtual void OnManipulationStarted(ManipulationStartedRoutedEventArgs e)
	{
	}

	protected virtual void OnManipulationDelta(ManipulationDeltaRoutedEventArgs e)
	{
	}

	protected virtual void OnManipulationInertiaStarting(ManipulationInertiaStartingRoutedEventArgs e)
	{
	}

	protected virtual void OnManipulationCompleted(ManipulationCompletedRoutedEventArgs e)
	{
	}

	protected virtual void OnTapped(TappedRoutedEventArgs e)
	{
	}

	protected virtual void OnDoubleTapped(DoubleTappedRoutedEventArgs e)
	{
	}

	protected virtual void OnRightTapped(RightTappedRoutedEventArgs e)
	{
	}

	[NotImplemented]
	private protected virtual void OnRightTappedUnhandled(RightTappedRoutedEventArgs e)
	{
	}

	protected virtual void OnHolding(HoldingRoutedEventArgs e)
	{
	}

	protected virtual void OnDragEnter(DragEventArgs e)
	{
	}

	protected virtual void OnDragOver(DragEventArgs e)
	{
	}

	protected virtual void OnDragLeave(DragEventArgs e)
	{
	}

	protected virtual void OnDrop(DragEventArgs e)
	{
	}

	protected virtual void OnKeyDown(KeyRoutedEventArgs args)
	{
	}

	protected virtual void OnKeyUp(KeyRoutedEventArgs args)
	{
	}

	protected virtual void OnGotFocus(RoutedEventArgs e)
	{
	}

	protected virtual void OnLostFocus(RoutedEventArgs e)
	{
	}

	protected static RoutedEventFlag GetImplementedRoutedEvents(Type type)
	{
		if (ImplementedRoutedEvents.TryGetValue(type, out var value))
		{
			return value;
		}
		value = RoutedEventFlag.None;
		Type baseType = type.BaseType;
		if (baseType == null || type == typeof(Control) || type == typeof(UIElement))
		{
			return value;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerPressed", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerPressed;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerReleased", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerReleased;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerEntered", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerEntered;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerExited", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerExited;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerMoved", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerMoved;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerCanceled", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerCanceled;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerCaptureLost", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerCaptureLost;
		}
		if (GetIsEventOverrideImplemented(type, "OnPointerWheelChanged", _pointerArgsType))
		{
			value |= RoutedEventFlag.PointerWheelChanged;
		}
		if (GetIsEventOverrideImplemented(type, "OnManipulationStarting", _manipStartingArgsType))
		{
			value |= RoutedEventFlag.ManipulationStarting;
		}
		if (GetIsEventOverrideImplemented(type, "OnManipulationStarted", _manipStartedArgsType))
		{
			value |= RoutedEventFlag.ManipulationStarted;
		}
		if (GetIsEventOverrideImplemented(type, "OnManipulationDelta", _manipDeltaArgsType))
		{
			value |= RoutedEventFlag.ManipulationDelta;
		}
		if (GetIsEventOverrideImplemented(type, "OnManipulationInertiaStarting", _manipInertiaArgsType))
		{
			value |= RoutedEventFlag.ManipulationInertiaStarting;
		}
		if (GetIsEventOverrideImplemented(type, "OnManipulationCompleted", _manipCompletedArgsType))
		{
			value |= RoutedEventFlag.ManipulationCompleted;
		}
		if (GetIsEventOverrideImplemented(type, "OnTapped", _tappedArgsType))
		{
			value |= RoutedEventFlag.Tapped;
		}
		if (GetIsEventOverrideImplemented(type, "OnDoubleTapped", _doubleTappedArgsType))
		{
			value |= RoutedEventFlag.DoubleTapped;
		}
		if (GetIsEventOverrideImplemented(type, "OnRightTapped", _rightTappedArgsType))
		{
			value |= RoutedEventFlag.RightTapped;
		}
		if (GetIsEventOverrideImplemented(type, "OnHolding", _holdingArgsType))
		{
			value |= RoutedEventFlag.Holding;
		}
		if (GetIsEventOverrideImplemented(type, "OnDragEnter", _dragArgsType))
		{
			value |= RoutedEventFlag.DragEnter;
		}
		if (GetIsEventOverrideImplemented(type, "OnDragOver", _dragArgsType))
		{
			value |= RoutedEventFlag.DragOver;
		}
		if (GetIsEventOverrideImplemented(type, "OnDragLeave", _dragArgsType))
		{
			value |= RoutedEventFlag.DragLeave;
		}
		if (GetIsEventOverrideImplemented(type, "OnDrop", _dragArgsType))
		{
			value |= RoutedEventFlag.Drop;
		}
		if (GetIsEventOverrideImplemented(type, "OnKeyDown", _keyArgsType))
		{
			value |= RoutedEventFlag.KeyDown;
		}
		if (GetIsEventOverrideImplemented(type, "OnKeyUp", _keyArgsType))
		{
			value |= RoutedEventFlag.KeyUp;
		}
		if (GetIsEventOverrideImplemented(type, "OnLostFocus", _routedArgsType))
		{
			value |= RoutedEventFlag.LostFocus;
		}
		if (GetIsEventOverrideImplemented(type, "OnGotFocus", _routedArgsType))
		{
			value |= RoutedEventFlag.GotFocus;
		}
		return ImplementedRoutedEvents[type] = value;
	}

	private static bool GetIsEventOverrideImplemented(Type type, string name, Type[] args)
	{
		MethodInfo method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic, null, args, null);
		if (method != null && method.IsVirtual)
		{
			return method.DeclaringType != typeof(Control);
		}
		return false;
	}

	private protected void SetDefaultStyleKey<TDerived>(TDerived derivedControl) where TDerived : Control
	{
		DefaultStyleKey = typeof(TDerived);
	}

	private protected bool GoToState(bool useTransitions, string stateName)
	{
		return VisualStateManager.GoToState(this, stateName, useTransitions);
	}

	private protected void GoToState(bool useTransitions, string stateName, out bool b)
	{
		b = VisualStateManager.GoToState(this, stateName, useTransitions);
	}

	internal void ConditionallyGetTemplatePartAndUpdateVisibility<T>(string strName, bool visible, ref T element) where T : UIElement
	{
		if (element == null && visible)
		{
			element = GetTemplateChild(strName) as T;
		}
		if (element != null)
		{
			UIElement uIElement = element;
			if (uIElement != null)
			{
				uIElement.Visibility = ((!visible) ? Visibility.Collapsed : Visibility.Visible);
			}
		}
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	public new bool Focus(FocusState value)
	{
		return FocusImpl(value);
	}

	private protected override void OnUnloaded()
	{
		RemoveFocusEngagement();
		if (base.IsFocused)
		{
			CoreServices context = this.GetContext();
			if (context != null)
			{
				VisualTree.GetFocusManagerForElement(this)?.SetFocusOnNextFocusableElement(FocusState, shouldFireFocusedRemoved: true);
				UpdateFocusState(FocusState.Unfocused);
			}
		}
		base.OnUnloaded();
	}

	private UIElement? FindFocusTargetDescendant(DependencyObject? root)
	{
		if (root == null)
		{
			return null;
		}
		IEnumerable<DependencyObject> children = VisualTreeHelper.GetChildren(root);
		bool flag = default(bool);
		foreach (DependencyObject item in children)
		{
			if (item != null)
			{
				object value = item.GetValue(IsTemplateFocusTargetProperty);
				int num;
				if (value is bool)
				{
					flag = (bool)value;
					num = 1;
				}
				else
				{
					num = 0;
				}
				if (((uint)num & (flag ? 1u : 0u)) != 0)
				{
					return item as UIElement;
				}
				UIElement uIElement = FindFocusTargetDescendant(item);
				if (uIElement != null)
				{
					return uIElement;
				}
			}
		}
		return null;
	}

	private void SetFocusEngagement()
	{
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
		if (focusManagerForElement == null)
		{
			return;
		}
		if (IsFocusEngaged)
		{
			if (!FocusProperties.HasFocusedElement(this))
			{
				IsFocusEngaged = false;
				throw new InvalidOperationException("Can't engage focus when the control nor any of its descendants has focus.");
			}
			if (!IsFocusEngagementEnabled)
			{
				IsFocusEngaged = false;
				throw new InvalidOperationException("Can't engage focus when IsFocusEngagementEnabled is false on the control.");
			}
			focusManagerForElement.EngagedControl = this;
			UpdateEngagementState(engage: true);
		}
		else if (focusManagerForElement.EngagedControl != null)
		{
			focusManagerForElement.EngagedControl = null;
			UpdateEngagementState(engage: false);
			VisualTree.GetPopupRootForElement(this)?.ClearWasOpenedDuringEngagementOnAllOpenPopups();
		}
	}

	public void RemoveFocusEngagement()
	{
		if (IsFocusEngaged)
		{
			IsFocusEngaged = false;
		}
	}

	private void UpdateEngagementState(bool engage)
	{
		if (engage)
		{
			FocusEngagedEventArgs focusEngagedEventArgs = new FocusEngagedEventArgs();
			focusEngagedEventArgs.OriginalSource = this;
			focusEngagedEventArgs.Handled = false;
			this.FocusEngaged?.Invoke(this, focusEngagedEventArgs);
		}
		else
		{
			FocusDisengagedEventArgs focusDisengagedEventArgs = new FocusDisengagedEventArgs();
			focusDisengagedEventArgs.OriginalSource = this;
			this.FocusDisengaged?.Invoke(this, focusDisengagedEventArgs);
		}
	}

	internal override bool IsFocusableForFocusEngagement()
	{
		if (IsFocusEngagementEnabled)
		{
			return LastInputGamepad();
		}
		return false;
	}

	private bool LastInputGamepad()
	{
		ContentRoot contentRootForElement = VisualTree.GetContentRootForElement(this);
		if (contentRootForElement == null)
		{
			return false;
		}
		return contentRootForElement.InputManager.LastInputDeviceType == InputDeviceType.GamepadOrRemote;
	}

	[NotImplemented]
	private protected void GetKeyboardModifiers(out VirtualKeyModifiers virtualKeyModifiers)
	{
		virtualKeyModifiers = VirtualKeyModifiers.None;
	}

	public Control()
		: this("div")
	{
	}

	public Control(string htmlTag)
		: base(htmlTag)
	{
		InitializeControl();
	}

	internal IFrameworkElement GetTemplateRoot()
	{
		return GetChildren()?.FirstOrDefault() as IFrameworkElement;
	}

	protected virtual bool IsDelegatingFocusToTemplateChild()
	{
		return false;
	}

	protected virtual void OnBackgroundSizingChanged(BackgroundSizing oldBackgroundSizing, BackgroundSizing newBackgroundSizing)
	{
	}

	protected virtual void OnHorizontalContentAlignmentChanged(HorizontalAlignment oldHorizontalContentAlignment, HorizontalAlignment newHorizontalContentAlignment)
	{
	}

	protected virtual void OnVerticalContentAlignmentChanged(VerticalAlignment oldVerticalContentAlignment, VerticalAlignment newVerticalContentAlignment)
	{
	}

	private CornerRadius GetCornerRadiusValue()
	{
		if (!_CornerRadiusPropertyBackingFieldSet)
		{
			_CornerRadiusPropertyBackingField = (CornerRadius)GetValue(CornerRadiusProperty);
			_CornerRadiusPropertyBackingFieldSet = true;
		}
		return _CornerRadiusPropertyBackingField;
	}

	private void SetCornerRadiusValue(CornerRadius value)
	{
		SetValue(CornerRadiusProperty, value);
	}

	private static DependencyProperty CreateCornerRadiusProperty()
	{
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Control), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		Control control = instance as Control;
		control._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		control._CornerRadiusPropertyBackingFieldSet = true;
	}

	private static bool GetIsTemplateFocusTargetValue(FrameworkElement instance)
	{
		if (instance is Control control)
		{
			if (!control.__Control_IsTemplateFocusTargetPropertyBackingFieldSet)
			{
				control.__Control_IsTemplateFocusTargetPropertyBackingField = (bool)instance.GetValue(IsTemplateFocusTargetProperty);
				control.__Control_IsTemplateFocusTargetPropertyBackingFieldSet = true;
			}
			return control.__Control_IsTemplateFocusTargetPropertyBackingField;
		}
		return (bool)instance.GetValue(IsTemplateFocusTargetProperty);
	}

	private static void SetIsTemplateFocusTargetValue(FrameworkElement instance, bool value)
	{
		instance.SetValue(IsTemplateFocusTargetProperty, value);
	}

	private static DependencyProperty CreateIsTemplateFocusTargetProperty()
	{
		return DependencyProperty.RegisterAttached("IsTemplateFocusTarget", typeof(bool), typeof(Control), new FrameworkPropertyMetadata(false, delegate(DependencyObject instance, object newValue)
		{
			if (instance is Control control)
			{
				control.__Control_IsTemplateFocusTargetPropertyBackingField = (bool)instance.GetValue(IsTemplateFocusTargetProperty);
				control.__Control_IsTemplateFocusTargetPropertyBackingFieldSet = true;
			}
		}));
	}

	private bool GetIsFocusEngagedValue()
	{
		if (!_IsFocusEngagedPropertyBackingFieldSet)
		{
			_IsFocusEngagedPropertyBackingField = (bool)GetValue(IsFocusEngagedProperty);
			_IsFocusEngagedPropertyBackingFieldSet = true;
		}
		return _IsFocusEngagedPropertyBackingField;
	}

	private void SetIsFocusEngagedValue(bool value)
	{
		SetValue(IsFocusEngagedProperty, value);
	}

	private static DependencyProperty CreateIsFocusEngagedProperty()
	{
		return DependencyProperty.Register("IsFocusEngaged", typeof(bool), typeof(Control), new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Control)instance).OnIsFocusEngagedChanged((bool)args.OldValue, (bool)args.NewValue);
		}, (BackingFieldUpdateCallback)OnIsFocusEngagedBackingFieldUpdate));
	}

	private static void OnIsFocusEngagedBackingFieldUpdate(object instance, object newValue)
	{
		Control control = instance as Control;
		control._IsFocusEngagedPropertyBackingField = (bool)newValue;
		control._IsFocusEngagedPropertyBackingFieldSet = true;
	}

	private bool GetIsFocusEngagementEnabledValue()
	{
		if (!_IsFocusEngagementEnabledPropertyBackingFieldSet)
		{
			_IsFocusEngagementEnabledPropertyBackingField = (bool)GetValue(IsFocusEngagementEnabledProperty);
			_IsFocusEngagementEnabledPropertyBackingFieldSet = true;
		}
		return _IsFocusEngagementEnabledPropertyBackingField;
	}

	private void SetIsFocusEngagementEnabledValue(bool value)
	{
		SetValue(IsFocusEngagementEnabledProperty, value);
	}

	private static DependencyProperty CreateIsFocusEngagementEnabledProperty()
	{
		return DependencyProperty.Register("IsFocusEngagementEnabled", typeof(bool), typeof(Control), new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Control)instance).OnIsFocusEngagementEnabledChanged((bool)args.OldValue, (bool)args.NewValue);
		}, (BackingFieldUpdateCallback)OnIsFocusEngagementEnabledBackingFieldUpdate));
	}

	private static void OnIsFocusEngagementEnabledBackingFieldUpdate(object instance, object newValue)
	{
		Control control = instance as Control;
		control._IsFocusEngagementEnabledPropertyBackingField = (bool)newValue;
		control._IsFocusEngagementEnabledPropertyBackingFieldSet = true;
	}
}
