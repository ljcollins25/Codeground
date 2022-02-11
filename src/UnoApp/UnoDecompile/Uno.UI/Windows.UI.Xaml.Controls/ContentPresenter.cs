using System;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Content")]
public class ContentPresenter : FrameworkElement, ICustomClippingElement
{
	private bool _firstLoadResetDone;

	private UIElement _contentTemplateRoot;

	private DataTemplate _dataTemplateUsedLastUpdate;

	private bool _isBoundImplicitelyToContent;

	private bool _BackgroundSizingPropertyBackingFieldSet;

	private BackgroundSizing _BackgroundSizingPropertyBackingField;

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

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
	public TextLineBounds TextLineBounds
	{
		get
		{
			return (TextLineBounds)GetValue(TextLineBoundsProperty);
		}
		set
		{
			SetValue(TextLineBoundsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public OpticalMarginAlignment OpticalMarginAlignment
	{
		get
		{
			return (OpticalMarginAlignment)GetValue(OpticalMarginAlignmentProperty);
		}
		set
		{
			SetValue(OpticalMarginAlignmentProperty, value);
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
	public LineStackingStrategy LineStackingStrategy
	{
		get
		{
			return (LineStackingStrategy)GetValue(LineStackingStrategyProperty);
		}
		set
		{
			SetValue(LineStackingStrategyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double LineHeight
	{
		get
		{
			return (double)GetValue(LineHeightProperty);
		}
		set
		{
			SetValue(LineHeightProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public BrushTransition BackgroundTransition
	{
		get
		{
			throw new NotImplementedException("The member BrushTransition ContentPresenter.BackgroundTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ContentPresenter", "BrushTransition ContentPresenter.BackgroundTransition");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CharacterSpacingProperty { get; } = DependencyProperty.Register("CharacterSpacing", typeof(int), typeof(ContentPresenter), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FontStretchProperty { get; } = DependencyProperty.Register("FontStretch", typeof(FontStretch), typeof(ContentPresenter), new FrameworkPropertyMetadata(FontStretch.Undefined));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OpticalMarginAlignmentProperty { get; } = DependencyProperty.Register("OpticalMarginAlignment", typeof(OpticalMarginAlignment), typeof(ContentPresenter), new FrameworkPropertyMetadata(OpticalMarginAlignment.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TextLineBoundsProperty { get; } = DependencyProperty.Register("TextLineBounds", typeof(TextLineBounds), typeof(ContentPresenter), new FrameworkPropertyMetadata(TextLineBounds.Full));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(ContentPresenter), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LineHeightProperty { get; } = DependencyProperty.Register("LineHeight", typeof(double), typeof(ContentPresenter), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LineStackingStrategyProperty { get; } = DependencyProperty.Register("LineStackingStrategy", typeof(LineStackingStrategy), typeof(ContentPresenter), new FrameworkPropertyMetadata(LineStackingStrategy.MaxHeight));


	internal bool SynchronizeContentWithOuterTemplatedParent { get; set; } = true;


	internal bool IsUsingDefaultTemplate { get; private set; }

	internal bool IsNativeHost { get; set; }

	protected override bool IsSimpleLayout => true;

	public virtual object Content
	{
		get
		{
			return GetValue(ContentProperty);
		}
		set
		{
			SetValue(ContentProperty, value);
		}
	}

	public static DependencyProperty ContentProperty { get; } = DependencyProperty.Register("Content", typeof(object), typeof(ContentPresenter), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnContentChanged(e.OldValue, e.NewValue);
	}));


	public DataTemplate ContentTemplate
	{
		get
		{
			return (DataTemplate)GetValue(ContentTemplateProperty);
		}
		set
		{
			SetValue(ContentTemplateProperty, value);
		}
	}

	public static DependencyProperty ContentTemplateProperty { get; } = DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(ContentPresenter), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnContentTemplateChanged(e.OldValue as DataTemplate, e.NewValue as DataTemplate);
	}));


	public DataTemplateSelector ContentTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty);
		}
		set
		{
			SetValue(ContentTemplateSelectorProperty, value);
		}
	}

	public static DependencyProperty ContentTemplateSelectorProperty { get; } = DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(ContentPresenter), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnContentTemplateSelectorChanged(e.OldValue as DataTemplateSelector, e.NewValue as DataTemplateSelector);
	}));


	public TransitionCollection ContentTransitions
	{
		get
		{
			return (TransitionCollection)GetValue(ContentTransitionsProperty);
		}
		set
		{
			SetValue(ContentTransitionsProperty, value);
		}
	}

	public static DependencyProperty ContentTransitionsProperty { get; } = DependencyProperty.Register("ContentTransitions", typeof(TransitionCollection), typeof(ContentPresenter), new FrameworkPropertyMetadata(null, OnContentTransitionsChanged));


	[GeneratedDependencyProperty(DefaultValue = BackgroundSizing.InnerBorderEdge, ChangedCallback = true)]
	public static DependencyProperty BackgroundSizingProperty { get; } = CreateBackgroundSizingProperty();


	public BackgroundSizing BackgroundSizing
	{
		get
		{
			return GetBackgroundSizingValue();
		}
		set
		{
			SetBackgroundSizingValue(value);
		}
	}

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

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(ContentPresenter), new FrameworkPropertyMetadata(SolidColorBrushHelper.Black, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnForegroundColorChanged(e.OldValue as Brush, e.NewValue as Brush);
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

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(ContentPresenter), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnFontWeightChanged((FontWeight)e.OldValue, (FontWeight)e.NewValue);
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

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(ContentPresenter), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnFontSizeChanged((double)e.OldValue, (double)e.NewValue);
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

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(ContentPresenter), new FrameworkPropertyMetadata(FontFamily.Default, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnFontFamilyChanged(e.OldValue as FontFamily, e.NewValue as FontFamily);
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

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(ContentPresenter), new FrameworkPropertyMetadata(FontStyle.Normal, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnFontStyleChanged((FontStyle)e.OldValue, (FontStyle)e.NewValue);
	}));


	public TextWrapping TextWrapping
	{
		get
		{
			return (TextWrapping)GetValue(TextWrappingProperty);
		}
		set
		{
			SetValue(TextWrappingProperty, value);
		}
	}

	public static DependencyProperty TextWrappingProperty { get; } = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(ContentPresenter), new FrameworkPropertyMetadata(TextWrapping.NoWrap, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s).OnTextWrappingChanged();
	}));


	public int MaxLines
	{
		get
		{
			return (int)GetValue(MaxLinesProperty);
		}
		set
		{
			SetValue(MaxLinesProperty, value);
		}
	}

	public static DependencyProperty MaxLinesProperty { get; } = DependencyProperty.Register("MaxLines", typeof(int), typeof(ContentPresenter), new FrameworkPropertyMetadata(0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s).OnMaxLinesChanged();
	}));


	public TextTrimming TextTrimming
	{
		get
		{
			return (TextTrimming)GetValue(TextTrimmingProperty);
		}
		set
		{
			SetValue(TextTrimmingProperty, value);
		}
	}

	public static DependencyProperty TextTrimmingProperty { get; } = DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(ContentPresenter), new FrameworkPropertyMetadata(TextTrimming.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s).OnTextTrimmingChanged();
	}));


	public TextAlignment TextAlignment
	{
		get
		{
			return (TextAlignment)GetValue(TextAlignmentProperty);
		}
		set
		{
			SetValue(TextAlignmentProperty, value);
		}
	}

	public static DependencyProperty TextAlignmentProperty { get; } = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(ContentPresenter), new FrameworkPropertyMetadata(TextAlignment.Left, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s).OnTextAlignmentChanged();
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

	public static DependencyProperty HorizontalContentAlignmentProperty { get; } = DependencyProperty.Register("HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(ContentPresenter), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnHorizontalContentAlignmentChanged((HorizontalAlignment)e.OldValue, (HorizontalAlignment)e.NewValue);
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

	public static DependencyProperty VerticalContentAlignmentProperty { get; } = DependencyProperty.Register("VerticalContentAlignment", typeof(VerticalAlignment), typeof(ContentPresenter), new FrameworkPropertyMetadata(VerticalAlignment.Stretch, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnVerticalContentAlignmentChanged((VerticalAlignment)e.OldValue, (VerticalAlignment)e.NewValue);
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

	public static DependencyProperty PaddingProperty { get; } = DependencyProperty.Register("Padding", typeof(Thickness), typeof(ContentPresenter), new FrameworkPropertyMetadata(Thickness.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnPaddingChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
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

	public static DependencyProperty BorderThicknessProperty { get; } = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ContentPresenter), new FrameworkPropertyMetadata(Thickness.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnBorderThicknessChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
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

	public static DependencyProperty BorderBrushProperty { get; } = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ContentPresenter), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ContentPresenter)s)?.OnBorderBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
	}));


	[GeneratedDependencyProperty(ChangedCallback = true)]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


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

	public virtual UIElement ContentTemplateRoot
	{
		get
		{
			return _contentTemplateRoot;
		}
		protected set
		{
			UIElement contentTemplateRoot = _contentTemplateRoot;
			if (contentTemplateRoot != null)
			{
				CleanupView(contentTemplateRoot);
				UnregisterContentTemplateRoot();
				UpdateContentTransitions(ContentTransitions, null);
			}
			_contentTemplateRoot = value;
			SynchronizeContentTemplatedParent();
			SynchronizeVerticalContentAlignment();
			SynchronizeHorizontalContentAlignment();
			if (_contentTemplateRoot != null)
			{
				RegisterContentTemplateRoot();
				UpdateContentTransitions(null, ContentTransitions);
			}
		}
	}

	bool ICustomClippingElement.AllowClippingToLayoutSlot => true;

	bool ICustomClippingElement.ForceClippingToLayoutSlot => CornerRadius != CornerRadius.None;

	private void InitializeContentPresenter()
	{
	}

	private static void OnContentTransitionsChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is ContentPresenter contentPresenter)
		{
			TransitionCollection oldValue = (TransitionCollection)args.OldValue;
			TransitionCollection newValue = (TransitionCollection)args.NewValue;
			contentPresenter.UpdateContentTransitions(oldValue, newValue);
		}
	}

	private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnBackgroundSizingChangedInner(e);
	}

	private void OnTextWrappingChanged()
	{
	}

	private void OnMaxLinesChanged()
	{
	}

	private void OnTextTrimmingChanged()
	{
	}

	private void OnTextAlignmentChanged()
	{
	}

	protected virtual void OnHorizontalContentAlignmentChanged(HorizontalAlignment oldHorizontalContentAlignment, HorizontalAlignment newHorizontalContentAlignment)
	{
		SynchronizeHorizontalContentAlignment(newHorizontalContentAlignment);
	}

	protected virtual void OnVerticalContentAlignmentChanged(VerticalAlignment oldVerticalContentAlignment, VerticalAlignment newVerticalContentAlignment)
	{
		SynchronizeVerticalContentAlignment(newVerticalContentAlignment);
	}

	private void OnPaddingChanged(Thickness oldValue, Thickness newValue)
	{
		OnPaddingChangedPartial(oldValue, newValue);
	}

	private void OnPaddingChangedPartial(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	private void OnBorderThicknessChanged(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	private void OnBorderBrushChanged(Brush oldValue, Brush newValue)
	{
		UpdateBorder();
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		UpdateCornerRadius(newValue);
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

	protected virtual void OnContentChanged(object oldValue, object newValue)
	{
		if (oldValue != null && newValue == null)
		{
			ContentTemplateRoot = null;
		}
		else if (oldValue is UIElement || newValue is UIElement)
		{
			ContentTemplateRoot = null;
		}
		if (newValue != null)
		{
			TrySetDataContextFromContent(newValue);
			SetUpdateTemplate();
		}
	}

	private void TrySetDataContextFromContent(object value)
	{
		if (value != null)
		{
			if (!(value is UIElement))
			{
				base.DataContext = value;
			}
			else
			{
				this.ClearValue(UIElement.DataContextProperty, DependencyPropertyValuePrecedences.Local);
			}
		}
	}

	protected internal override void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnTemplatedParentChanged(e);
		SetImplicitContent();
	}

	protected virtual void OnContentTemplateChanged(DataTemplate oldTemplate, DataTemplate newTemplate)
	{
		if (ContentTemplateRoot != null)
		{
			ContentTemplateRoot = null;
		}
		SetUpdateTemplate();
	}

	private void OnContentTemplateSelectorChanged(DataTemplateSelector dataTemplateSelector1, DataTemplateSelector dataTemplateSelector2)
	{
	}

	private void UnregisterContentTemplateRoot()
	{
		RemoveChild(ContentTemplateRoot);
	}

	private void SynchronizeContentTemplatedParent()
	{
		if (IsNativeHost)
		{
			if (_contentTemplateRoot is IFrameworkElement frameworkElement)
			{
				frameworkElement.TemplatedParent = base.TemplatedParent;
			}
		}
		else if (_contentTemplateRoot is IFrameworkElement frameworkElement2)
		{
			frameworkElement2.TemplatedParent = FindTemplatedParent();
		}
		else
		{
			_contentTemplateRoot?.SetParent(this);
		}
		DependencyObject FindTemplatedParent()
		{
			if (_contentTemplateRoot is ImplicitTextBlock)
			{
				return this;
			}
			if (!SynchronizeContentWithOuterTemplatedParent && _dataTemplateUsedLastUpdate == null)
			{
				return base.TemplatedParent;
			}
			return (base.TemplatedParent as IFrameworkElement)?.TemplatedParent;
		}
	}

	private void UpdateContentTransitions(TransitionCollection oldValue, TransitionCollection newValue)
	{
		if (!(ContentTemplateRoot is IFrameworkElement element))
		{
			return;
		}
		if (oldValue != null)
		{
			foreach (Transition item in oldValue)
			{
				item.DetachFromElement(element);
			}
		}
		if (newValue == null)
		{
			return;
		}
		foreach (Transition item2 in newValue)
		{
			item2.AttachToElement(element);
		}
	}

	private void CleanupView(UIElement previousValue)
	{
		if (!(previousValue is IFrameworkElement))
		{
			previousValue?.SetParent(null);
		}
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		ResetDataContextOnFirstLoad();
		SetUpdateTemplate();
		SynchronizeContentTemplatedParent();
		UpdateBorder();
	}

	private void ResetDataContextOnFirstLoad()
	{
		if (!_firstLoadResetDone)
		{
			_firstLoadResetDone = true;
			this.ClearValue(UIElement.DataContextProperty, DependencyPropertyValuePrecedences.Local);
			TrySetDataContextFromContent(Content);
		}
	}

	protected override void OnVisibilityChanged(Visibility oldValue, Visibility newValue)
	{
		base.OnVisibilityChanged(oldValue, newValue);
		if (oldValue == Visibility.Collapsed && newValue == Visibility.Visible)
		{
			SetUpdateTemplate();
		}
	}

	public void UpdateContentTemplateRoot()
	{
		if (base.Visibility == Visibility.Collapsed)
		{
			return;
		}
		if (ContentTemplateRoot == null)
		{
			_dataTemplateUsedLastUpdate = null;
		}
		DataTemplate dataTemplate = this.ResolveContentTemplate();
		if (!object.Equals(dataTemplate, _dataTemplateUsedLastUpdate))
		{
			_dataTemplateUsedLastUpdate = dataTemplate;
			ContentTemplateRoot = dataTemplate?.LoadContentCached() ?? (Content as UIElement);
			if (ContentTemplateRoot != null)
			{
				IsUsingDefaultTemplate = false;
			}
		}
		if (Content != null && !(Content is UIElement) && ContentTemplateRoot == null)
		{
			SetContentTemplateRootToPlaceholder();
		}
		if (ContentTemplateRoot == null && Content is UIElement contentTemplateRoot && dataTemplate == null)
		{
			ContentTemplateRoot = contentTemplateRoot;
		}
		IsUsingDefaultTemplate = ContentTemplateRoot is ImplicitTextBlock;
	}

	private void SetContentTemplateRootToPlaceholder()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().DebugFormat("No ContentTemplate was specified for {0} and content is not a UIView, defaulting to TextBlock.", GetType().Name);
		}
		ImplicitTextBlock textBlock = new ImplicitTextBlock(this);
		setBinding(TextBlock.TextProperty, "Content");
		setBinding(FrameworkElement.HorizontalAlignmentProperty, "HorizontalContentAlignment");
		setBinding(FrameworkElement.VerticalAlignmentProperty, "VerticalContentAlignment");
		setBinding(TextBlock.TextWrappingProperty, "TextWrapping");
		setBinding(TextBlock.MaxLinesProperty, "MaxLines");
		setBinding(TextBlock.TextAlignmentProperty, "TextAlignment");
		ContentTemplateRoot = textBlock;
		IsUsingDefaultTemplate = true;
		void setBinding(DependencyProperty property, string path)
		{
			textBlock.SetBinding(property, new Binding
			{
				Path = new PropertyPath(path),
				Source = this,
				Mode = BindingMode.OneWay
			});
		}
	}

	private void SetImplicitContent()
	{
		if (!FeatureConfiguration.ContentPresenter.UseImplicitContentFromTemplatedParent)
		{
			return;
		}
		if (!(base.TemplatedParent is ContentControl))
		{
			ClearImplicitBindinds();
			return;
		}
		if (this.GetValueUnderPrecedence(ContentProperty, DependencyPropertyValuePrecedences.DefaultValue).precedence != DependencyPropertyValuePrecedences.DefaultValue)
		{
			ClearImplicitBindinds();
			return;
		}
		BindingExpression bindingExpression = GetBindingExpression(ContentProperty);
		if (bindingExpression != null)
		{
			ClearImplicitBindinds();
			return;
		}
		Binding binding = new Binding(new PropertyPath("Content"))
		{
			RelativeSource = RelativeSource.TemplatedParent
		};
		SetBinding(ContentProperty, binding);
		_isBoundImplicitelyToContent = true;
		void ClearImplicitBindinds()
		{
			if (_isBoundImplicitelyToContent)
			{
				SetBinding(ContentProperty, new Binding());
			}
		}
	}

	private void RegisterContentTemplateRoot()
	{
		AddChild(ContentTemplateRoot);
	}

	private void SynchronizeHorizontalContentAlignment(HorizontalAlignment? alignment = null)
	{
		if (ContentTemplateRoot is FrameworkElement instance)
		{
			instance.SetValue(FrameworkElement.HorizontalAlignmentProperty, alignment ?? HorizontalContentAlignment, DependencyPropertyValuePrecedences.Inheritance);
		}
		else if (ContentTemplateRoot is IFrameworkElement instance2)
		{
			DependencyProperty property = DependencyProperty.GetProperty(ContentTemplateRoot.GetType(), "HorizontalAlignment");
			if (property == null)
			{
				throw new InvalidOperationException($"The property HorizontalAlignment should exist on type {ContentTemplateRoot.GetType()}");
			}
			instance2.SetValue(property, alignment ?? HorizontalContentAlignment, DependencyPropertyValuePrecedences.Inheritance);
		}
	}

	private void SynchronizeVerticalContentAlignment(VerticalAlignment? alignment = null)
	{
		if (ContentTemplateRoot is FrameworkElement instance)
		{
			instance.SetValue(FrameworkElement.VerticalAlignmentProperty, alignment ?? VerticalContentAlignment, DependencyPropertyValuePrecedences.Inheritance);
		}
		else if (ContentTemplateRoot is IFrameworkElement instance2)
		{
			DependencyProperty property = DependencyProperty.GetProperty(ContentTemplateRoot.GetType(), "VerticalAlignment");
			if (property == null)
			{
				throw new InvalidOperationException($"The property VerticalAlignment should exist on type {ContentTemplateRoot.GetType()}");
			}
			instance2.SetValue(property, alignment ?? VerticalContentAlignment, DependencyPropertyValuePrecedences.Inheritance);
		}
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateBorder();
	}

	internal override void UpdateThemeBindings(ResourceUpdateReason updateReason)
	{
		base.UpdateThemeBindings(updateReason);
		SetDefaultForeground(ForegroundProperty);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		UIElement uIElement = FindFirstChild();
		if (uIElement != null)
		{
			Thickness padding = Padding;
			Thickness borderThickness = BorderThickness;
			Rect finalRect = new Rect(padding.Left + borderThickness.Left, padding.Top + borderThickness.Top, finalSize.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right, finalSize.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom);
			ArrangeElement(uIElement, finalRect);
		}
		return finalSize;
	}

	protected override Size MeasureOverride(Size size)
	{
		Thickness padding = Padding;
		Thickness borderThickness = BorderThickness;
		Size size2 = base.MeasureOverride(new Size(size.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right, size.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom));
		return new Size(size2.Width + padding.Left + padding.Right + borderThickness.Left + borderThickness.Right, size2.Height + padding.Top + padding.Bottom + borderThickness.Top + borderThickness.Bottom);
	}

	private protected override Thickness GetBorderThickness()
	{
		return BorderThickness;
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	public ContentPresenter()
	{
		InitializeContentPresenter();
	}

	private void SetUpdateTemplate()
	{
		UpdateContentTemplateRoot();
	}

	private void UpdateCornerRadius(CornerRadius radius)
	{
		SetCornerRadius(radius);
	}

	private void UpdateBorder()
	{
		SetBorder(BorderThickness, BorderBrush);
		SetAndObserveBackgroundBrush(base.Background);
	}

	private BackgroundSizing GetBackgroundSizingValue()
	{
		if (!_BackgroundSizingPropertyBackingFieldSet)
		{
			_BackgroundSizingPropertyBackingField = (BackgroundSizing)GetValue(BackgroundSizingProperty);
			_BackgroundSizingPropertyBackingFieldSet = true;
		}
		return _BackgroundSizingPropertyBackingField;
	}

	private void SetBackgroundSizingValue(BackgroundSizing value)
	{
		SetValue(BackgroundSizingProperty, value);
	}

	private static DependencyProperty CreateBackgroundSizingProperty()
	{
		return DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(ContentPresenter), new FrameworkPropertyMetadata((object)BackgroundSizing.InnerBorderEdge, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((ContentPresenter)instance).OnBackgroundSizingChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundSizingBackingFieldUpdate));
	}

	private static void OnBackgroundSizingBackingFieldUpdate(object instance, object newValue)
	{
		ContentPresenter contentPresenter = instance as ContentPresenter;
		contentPresenter._BackgroundSizingPropertyBackingField = (BackgroundSizing)newValue;
		contentPresenter._BackgroundSizingPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ContentPresenter), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((ContentPresenter)instance).OnCornerRadiusChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
		}, (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		ContentPresenter contentPresenter = instance as ContentPresenter;
		contentPresenter._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		contentPresenter._CornerRadiusPropertyBackingFieldSet = true;
	}
}
