using System;
using Uno;
using Uno.Disposables;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Helpers;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Child")]
public class Border : FrameworkElement, ICustomClippingElement
{
	private SerialDisposable _borderBrushColorChanged = new SerialDisposable();

	private SerialDisposable _borderBrushOpacityChanged = new SerialDisposable();

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	private bool _PaddingPropertyBackingFieldSet;

	private Thickness _PaddingPropertyBackingField;

	private bool _BackgroundSizingPropertyBackingFieldSet;

	private BackgroundSizing _BackgroundSizingPropertyBackingField;

	private bool _BorderThicknessPropertyBackingFieldSet;

	private Thickness _BorderThicknessPropertyBackingField;

	private bool _BorderBrushPropertyBackingFieldSet;

	private Brush _BorderBrushPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public BrushTransition BackgroundTransition
	{
		get
		{
			throw new NotImplementedException("The member BrushTransition Border.BackgroundTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Border", "BrushTransition Border.BackgroundTransition");
		}
	}

	protected override bool IsSimpleLayout => true;

	public virtual UIElement Child
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

	public static DependencyProperty ChildProperty { get; } = DependencyProperty.Register("Child", typeof(UIElement), typeof(Border), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Border)s)?.OnChildChanged((UIElement)e.OldValue, (UIElement)e.NewValue);
	}));


	[GeneratedDependencyProperty(ChangedCallback = true, Options = (FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure))]
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

	public static DependencyProperty ChildTransitionsProperty { get; } = DependencyProperty.Register("ChildTransitions", typeof(TransitionCollection), typeof(Border), new FrameworkPropertyMetadata(null));


	[GeneratedDependencyProperty(ChangedCallback = true, Options = (FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty PaddingProperty { get; } = CreatePaddingProperty();


	public Thickness Padding
	{
		get
		{
			return GetPaddingValue();
		}
		set
		{
			SetPaddingValue(value);
		}
	}

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

	[GeneratedDependencyProperty(ChangedCallback = true, Options = (FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure))]
	public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();


	public Thickness BorderThickness
	{
		get
		{
			return GetBorderThicknessValue();
		}
		set
		{
			SetBorderThicknessValue(value);
		}
	}

	public Brush BorderBrush
	{
		get
		{
			return GetBorderBrushValue();
		}
		set
		{
			SetBorderBrushValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallback = true, Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
	public static DependencyProperty BorderBrushProperty { get; } = CreateBorderBrushProperty();


	bool ICustomClippingElement.AllowClippingToLayoutSlot
	{
		get
		{
			UIElement child = Child;
			if (child != null)
			{
				return child.RenderTransform == null;
			}
			return true;
		}
	}

	bool ICustomClippingElement.ForceClippingToLayoutSlot => CornerRadius != CornerRadius.None;

	public void Add(UIElement view)
	{
		Child = VisualTreeHelper.TryAdaptNative(view);
	}

	private protected override Thickness GetBorderThickness()
	{
		return BorderThickness;
	}

	protected void OnChildChanged(UIElement oldValue, UIElement newValue)
	{
		ReAttachChildTransitions(oldValue, newValue);
		OnChildChangedPartial(oldValue, newValue);
	}

	private void OnChildChangedPartial(UIElement previousValue, UIElement newValue)
	{
		if (previousValue != null)
		{
			RemoveChild(previousValue);
		}
		AddChild(newValue);
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		OnCornerRadiusUpdatedPartial(oldValue, newValue);
	}

	private void OnCornerRadiusUpdatedPartial(CornerRadius oldValue, CornerRadius newValue)
	{
		SetCornerRadius(newValue);
	}

	private void ReAttachChildTransitions(UIElement originalChild, UIElement child)
	{
		if (ChildTransitions == null || !(originalChild is IFrameworkElement element))
		{
			return;
		}
		foreach (Transition childTransition in ChildTransitions)
		{
			childTransition.DetachFromElement(element);
		}
		if (!(child is IFrameworkElement element2))
		{
			return;
		}
		foreach (Transition childTransition2 in ChildTransitions)
		{
			childTransition2.AttachToElement(element2);
		}
	}

	private static Thickness GetPaddingDefaultValue()
	{
		return Thickness.Empty;
	}

	protected virtual void OnPaddingChanged(Thickness oldValue, Thickness newValue)
	{
		OnPaddingChangedPartial(oldValue, newValue);
	}

	private void OnPaddingChangedPartial(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnBackgroundSizingChangedInner(e);
	}

	private static Thickness GetBorderThicknessDefaultValue()
	{
		return Thickness.Empty;
	}

	protected virtual void OnBorderThicknessChanged(Thickness oldValue, Thickness newValue)
	{
		OnBorderThicknessChangedPartial(oldValue, newValue);
	}

	private void OnBorderThicknessChangedPartial(Thickness oldValue, Thickness newValue)
	{
		UpdateBorder();
	}

	private static Brush GetBorderBrushDefaultValue()
	{
		return SolidColorBrushHelper.Transparent;
	}

	protected virtual void OnBorderBrushChanged(Brush oldValue, Brush newValue)
	{
		if (newValue is SolidColorBrush instance)
		{
			_borderBrushColorChanged.Disposable = instance.RegisterDisposablePropertyChangedCallback(SolidColorBrush.ColorProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
			_borderBrushOpacityChanged.Disposable = instance.RegisterDisposablePropertyChangedCallback(Brush.OpacityProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
		}
		else if (newValue is GradientBrush instance2)
		{
			_borderBrushColorChanged.Disposable = instance2.RegisterDisposablePropertyChangedCallback(GradientBrush.FallbackColorProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
			_borderBrushOpacityChanged.Disposable = instance2.RegisterDisposablePropertyChangedCallback(Brush.OpacityProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
		}
		else if (newValue is AcrylicBrush instance3)
		{
			_borderBrushColorChanged.Disposable = instance3.RegisterDisposablePropertyChangedCallback(XamlCompositionBrushBase.FallbackColorProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
			_borderBrushOpacityChanged.Disposable = instance3.RegisterDisposablePropertyChangedCallback(Brush.OpacityProperty, delegate
			{
				OnBorderBrushChangedPartial();
			});
		}
		else
		{
			_borderBrushColorChanged.Disposable = null;
			_borderBrushOpacityChanged.Disposable = null;
		}
		OnBorderBrushChangedPartial();
	}

	private void OnBorderBrushChangedPartial()
	{
		UpdateBorder();
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}

	internal static Size HelperGetCombinedThickness(FrameworkElement element)
	{
		Thickness thickness = element.GetBorderThickness();
		if (UseLayoutRoundingForBorderThickness(element))
		{
			thickness = GetLayoutRoundedThickness(element);
		}
		Size size = HelperCollapseThickness(thickness);
		Size size2 = HelperCollapseThickness(element.GetPadding());
		return new Size(size.Width + size2.Width, size.Height + size2.Height);
	}

	private static Size HelperCollapseThickness(Thickness thickness)
	{
		return new Size(thickness.Left + thickness.Right, thickness.Top + thickness.Bottom);
	}

	internal static bool UseLayoutRoundingForBorderThickness(FrameworkElement element)
	{
		if (RootScale.GetRasterizationScaleForElement(element) != 1.0 && element.GetUseLayoutRounding())
		{
			return !HasNonZeroCornerRadius(element.GetCornerRadius());
		}
		return false;
	}

	internal static bool HasNonZeroCornerRadius(CornerRadius cornerRadius)
	{
		if (!(cornerRadius.TopLeft > 0.0) && !(cornerRadius.TopRight > 0.0) && !(cornerRadius.BottomRight > 0.0))
		{
			return cornerRadius.BottomLeft > 0.0;
		}
		return true;
	}

	internal static Thickness GetLayoutRoundedThickness(FrameworkElement element)
	{
		Thickness result = default(Thickness);
		Thickness borderThickness = element.GetBorderThickness();
		result.Left = element.LayoutRound(borderThickness.Left);
		result.Right = element.LayoutRound(borderThickness.Right);
		result.Top = element.LayoutRound(borderThickness.Top);
		result.Bottom = element.LayoutRound(borderThickness.Bottom);
		return result;
	}

	internal static Rect HelperGetInnerRect(FrameworkElement element, Size outerSize)
	{
		Thickness thickness = element.GetBorderThickness();
		Rect rect = new Rect(0.0, 0.0, outerSize.Width, outerSize.Height);
		if (UseLayoutRoundingForBorderThickness(element))
		{
			rect.Width = element.LayoutRound(rect.Width);
			rect.Height = element.LayoutRound(rect.Height);
			thickness = GetLayoutRoundedThickness(element);
		}
		HelperDeflateRect(rect, thickness, out var innerRect);
		HelperDeflateRect(innerRect, element.GetPadding(), out var innerRect2);
		return innerRect2;
	}

	internal static void HelperDeflateRect(Rect rect, Thickness thickness, out Rect innerRect)
	{
		innerRect = rect.DeflateBy(thickness);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Thickness padding = Padding;
		Thickness borderThickness = BorderThickness;
		Size size = base.MeasureOverride(new Size(availableSize.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right, availableSize.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom));
		return new Size(size.Width + padding.Left + padding.Right + borderThickness.Left + borderThickness.Right, size.Height + padding.Top + padding.Bottom + borderThickness.Top + borderThickness.Bottom);
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

	private void UpdateBorder()
	{
		SetBorder(BorderThickness, BorderBrush);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		UpdateBorder();
	}

	protected override void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnBackgroundChanged(e);
		UpdateHitTest();
	}

	internal override bool IsViewHit()
	{
		if (base.Background == null)
		{
			return base.IsViewHit();
		}
		return true;
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
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Border), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Border)instance).OnCornerRadiusChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
		}, (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		Border border = instance as Border;
		border._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		border._CornerRadiusPropertyBackingFieldSet = true;
	}

	private Thickness GetPaddingValue()
	{
		if (!_PaddingPropertyBackingFieldSet)
		{
			_PaddingPropertyBackingField = (Thickness)GetValue(PaddingProperty);
			_PaddingPropertyBackingFieldSet = true;
		}
		return _PaddingPropertyBackingField;
	}

	private void SetPaddingValue(Thickness value)
	{
		SetValue(PaddingProperty, value);
	}

	private static DependencyProperty CreatePaddingProperty()
	{
		return DependencyProperty.Register("Padding", typeof(Thickness), typeof(Border), new FrameworkPropertyMetadata((object)GetPaddingDefaultValue(), FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Border)instance).OnPaddingChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnPaddingBackingFieldUpdate));
	}

	private static void OnPaddingBackingFieldUpdate(object instance, object newValue)
	{
		Border border = instance as Border;
		border._PaddingPropertyBackingField = (Thickness)newValue;
		border._PaddingPropertyBackingFieldSet = true;
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
		return DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(Border), new FrameworkPropertyMetadata((object)BackgroundSizing.InnerBorderEdge, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Border)instance).OnBackgroundSizingChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundSizingBackingFieldUpdate));
	}

	private static void OnBackgroundSizingBackingFieldUpdate(object instance, object newValue)
	{
		Border border = instance as Border;
		border._BackgroundSizingPropertyBackingField = (BackgroundSizing)newValue;
		border._BackgroundSizingPropertyBackingFieldSet = true;
	}

	private Thickness GetBorderThicknessValue()
	{
		if (!_BorderThicknessPropertyBackingFieldSet)
		{
			_BorderThicknessPropertyBackingField = (Thickness)GetValue(BorderThicknessProperty);
			_BorderThicknessPropertyBackingFieldSet = true;
		}
		return _BorderThicknessPropertyBackingField;
	}

	private void SetBorderThicknessValue(Thickness value)
	{
		SetValue(BorderThicknessProperty, value);
	}

	private static DependencyProperty CreateBorderThicknessProperty()
	{
		return DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(Border), new FrameworkPropertyMetadata((object)GetBorderThicknessDefaultValue(), FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Border)instance).OnBorderThicknessChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderThicknessBackingFieldUpdate));
	}

	private static void OnBorderThicknessBackingFieldUpdate(object instance, object newValue)
	{
		Border border = instance as Border;
		border._BorderThicknessPropertyBackingField = (Thickness)newValue;
		border._BorderThicknessPropertyBackingFieldSet = true;
	}

	private Brush GetBorderBrushValue()
	{
		if (!_BorderBrushPropertyBackingFieldSet)
		{
			_BorderBrushPropertyBackingField = (Brush)GetValue(BorderBrushProperty);
			_BorderBrushPropertyBackingFieldSet = true;
		}
		return _BorderBrushPropertyBackingField;
	}

	private void SetBorderBrushValue(Brush value)
	{
		SetValue(BorderBrushProperty, value);
	}

	private static DependencyProperty CreateBorderBrushProperty()
	{
		return DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Border), new FrameworkPropertyMetadata((object)GetBorderBrushDefaultValue(), FrameworkPropertyMetadataOptions.ValueInheritsDataContext, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Border)instance).OnBorderBrushChanged((Brush)args.OldValue, (Brush)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderBrushBackingFieldUpdate));
	}

	private static void OnBorderBrushBackingFieldUpdate(object instance, object newValue)
	{
		Border border = instance as Border;
		border._BorderBrushPropertyBackingField = (Brush)newValue;
		border._BorderBrushPropertyBackingFieldSet = true;
	}
}
