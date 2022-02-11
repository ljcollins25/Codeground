using System;
using System.Collections.Specialized;
using System.Linq;
using Uno;
using Uno.Disposables;
using Uno.Extensions;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Shapes;

[ContentProperty(Name = "SvgChildren")]
public abstract class Shape : FrameworkElement
{
	private const double DefaultStrokeThicknessWhenNoStrokeDefined = 0.0;

	private readonly SerialDisposable _brushChanged = new SerialDisposable();

	private readonly SerialDisposable _strokeBrushChanged = new SerialDisposable();

	private Brush _fillStrongref;

	private readonly SerialDisposable _fillBrushSubscription = new SerialDisposable();

	private readonly SerialDisposable _strokeBrushSubscription = new SerialDisposable();

	private DefsSvgElement _defs;

	private static readonly NotifyCollectionChangedEventHandler OnSvgChildrenChanged = delegate(object sender, NotifyCollectionChangedEventArgs args)
	{
		if (sender is UIElementCollection uIElementCollection && uIElementCollection.Owner is Shape shape)
		{
			shape.OnChildrenChanged();
		}
	};

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PenLineCap StrokeStartLineCap
	{
		get
		{
			return (PenLineCap)GetValue(StrokeStartLineCapProperty);
		}
		set
		{
			SetValue(StrokeStartLineCapProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double StrokeMiterLimit
	{
		get
		{
			return (double)GetValue(StrokeMiterLimitProperty);
		}
		set
		{
			SetValue(StrokeMiterLimitProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PenLineJoin StrokeLineJoin
	{
		get
		{
			return (PenLineJoin)GetValue(StrokeLineJoinProperty);
		}
		set
		{
			SetValue(StrokeLineJoinProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PenLineCap StrokeEndLineCap
	{
		get
		{
			return (PenLineCap)GetValue(StrokeEndLineCapProperty);
		}
		set
		{
			SetValue(StrokeEndLineCapProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double StrokeDashOffset
	{
		get
		{
			return (double)GetValue(StrokeDashOffsetProperty);
		}
		set
		{
			SetValue(StrokeDashOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PenLineCap StrokeDashCap
	{
		get
		{
			return (PenLineCap)GetValue(StrokeDashCapProperty);
		}
		set
		{
			SetValue(StrokeDashCapProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Transform GeometryTransform
	{
		get
		{
			throw new NotImplementedException("The member Transform Shape.GeometryTransform is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeDashCapProperty { get; } = DependencyProperty.Register("StrokeDashCap", typeof(PenLineCap), typeof(Shape), new FrameworkPropertyMetadata(PenLineCap.Flat));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeDashOffsetProperty { get; } = DependencyProperty.Register("StrokeDashOffset", typeof(double), typeof(Shape), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeEndLineCapProperty { get; } = DependencyProperty.Register("StrokeEndLineCap", typeof(PenLineCap), typeof(Shape), new FrameworkPropertyMetadata(PenLineCap.Flat));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeLineJoinProperty { get; } = DependencyProperty.Register("StrokeLineJoin", typeof(PenLineJoin), typeof(Shape), new FrameworkPropertyMetadata(PenLineJoin.Miter));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeMiterLimitProperty { get; } = DependencyProperty.Register("StrokeMiterLimit", typeof(double), typeof(Shape), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StrokeStartLineCapProperty { get; } = DependencyProperty.Register("StrokeStartLineCap", typeof(PenLineCap), typeof(Shape), new FrameworkPropertyMetadata(PenLineCap.Flat));


	private protected double ActualStrokeThickness
	{
		get
		{
			if (Stroke != null)
			{
				return LayoutRound(StrokeThickness);
			}
			return 0.0;
		}
	}

	public Brush Fill
	{
		get
		{
			return (Brush)GetValue(FillProperty);
		}
		set
		{
			SetValue(FillProperty, value);
			_fillStrongref = value;
		}
	}

	public static DependencyProperty FillProperty { get; } = DependencyProperty.Register("Fill", typeof(Brush), typeof(Shape), new FrameworkPropertyMetadata(SolidColorBrushHelper.Transparent, FrameworkPropertyMetadataOptions.ValueInheritsDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Shape)s).OnFillChanged((Brush)e.NewValue);
	}));


	public Brush Stroke
	{
		get
		{
			return (Brush)GetValue(StrokeProperty);
		}
		set
		{
			SetValue(StrokeProperty, value);
		}
	}

	public static DependencyProperty StrokeProperty { get; } = DependencyProperty.Register("Stroke", typeof(Brush), typeof(Shape), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Shape)s).OnStrokeUpdated((Brush)e.NewValue);
	}));


	public double StrokeThickness
	{
		get
		{
			return (double)GetValue(StrokeThicknessProperty);
		}
		set
		{
			SetValue(StrokeThicknessProperty, value);
		}
	}

	public static DependencyProperty StrokeThicknessProperty { get; } = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(Shape), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Shape)s).OnStrokeThicknessUpdated((double)e.NewValue);
	}));


	public Stretch Stretch
	{
		get
		{
			return (Stretch)GetValue(StretchProperty);
		}
		set
		{
			SetValue(StretchProperty, value);
		}
	}

	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(Shape), new FrameworkPropertyMetadata(Stretch.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Shape)s).OnStretchUpdated((Stretch)e.NewValue);
	}));


	public DoubleCollection StrokeDashArray
	{
		get
		{
			return (DoubleCollection)GetValue(StrokeDashArrayProperty);
		}
		set
		{
			SetValue(StrokeDashArrayProperty, value);
		}
	}

	public static DependencyProperty StrokeDashArrayProperty { get; } = DependencyProperty.Register("StrokeDashArray", typeof(DoubleCollection), typeof(Shape), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Shape)s).OnStrokeDashArrayUpdated((DoubleCollection)e.NewValue);
	}));


	public UIElementCollection SvgChildren { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositionBrush GetAlphaMask()
	{
		throw new NotImplementedException("The member CompositionBrush Shape.GetAlphaMask() is not implemented in Uno.");
	}

	private void InvalidateForFillChanged()
	{
	}

	protected virtual void OnFillChanged(Brush newValue)
	{
		_brushChanged.Disposable = null;
		if (newValue != null && newValue.SupportsAssignAndObserveBrush)
		{
			_brushChanged.Disposable = Brush.AssignAndObserveBrush(newValue, delegate
			{
				OnFillUpdatedPartial();
			});
		}
		OnFillUpdated(newValue);
	}

	protected virtual void OnFillUpdated(Brush newValue)
	{
		OnFillUpdatedPartial();
		RefreshShape();
	}

	private void OnFillUpdatedPartial()
	{
		Brush fill = Fill;
		foreach (UIElement svgChild in SvgChildren)
		{
			svgChild.IsHitTestVisible = fill != null;
		}
		SvgElement mainSvgElement = GetMainSvgElement();
		if (!(fill is SolidColorBrush solidColorBrush))
		{
			if (!(fill is ImageBrush imageBrush))
			{
				if (!(fill is GradientBrush gradientBrush))
				{
					if (!(fill is AcrylicBrush acrylicBrush))
					{
						if (fill == null)
						{
							mainSvgElement.SetStyle("fill", "transparent");
							_fillBrushSubscription.Disposable = null;
						}
						else
						{
							mainSvgElement.ResetStyle("fill");
							_fillBrushSubscription.Disposable = null;
						}
					}
					else
					{
						mainSvgElement.SetStyle("fill", acrylicBrush.FallbackColorWithOpacity.ToHexString());
						_fillBrushSubscription.Disposable = null;
					}
				}
				else
				{
					UIElement gradient = gradientBrush.ToSvgElement();
					IntPtr htmlId = gradient.HtmlId;
					GetDefs().Add(gradient);
					mainSvgElement.SetStyle("fill", $"url(#{htmlId})");
					_fillBrushSubscription.Disposable = new DisposableAction(delegate
					{
						GetDefs().Remove(gradient);
					});
				}
			}
			else
			{
				(UIElement, IDisposable) tuple = imageBrush.ToSvgElement(this);
				UIElement imageFill = tuple.Item1;
				IDisposable item = tuple.Item2;
				IntPtr htmlId2 = imageFill.HtmlId;
				GetDefs().Add(imageFill);
				mainSvgElement.SetStyle("fill", $"url(#{htmlId2})");
				DisposableAction disposableAction = new DisposableAction(delegate
				{
					GetDefs().Remove(imageFill);
				});
				_fillBrushSubscription.Disposable = new CompositeDisposable(disposableAction, item);
			}
		}
		else
		{
			mainSvgElement.SetStyle("fill", solidColorBrush.ColorWithOpacity.ToHexString());
			_fillBrushSubscription.Disposable = null;
		}
	}

	protected virtual void OnStrokeUpdated(Brush newValue)
	{
		_strokeBrushChanged.Disposable = null;
		if (newValue != null && newValue.SupportsAssignAndObserveBrush)
		{
			_strokeBrushChanged.Disposable = Brush.AssignAndObserveBrush(newValue, delegate
			{
				OnStrokeUpdatedPartial();
			});
		}
		OnStrokeUpdatedPartial();
		RefreshShape();
	}

	private void OnStrokeUpdatedPartial()
	{
		SvgElement mainSvgElement = GetMainSvgElement();
		Brush stroke = Stroke;
		if (!(stroke is SolidColorBrush solidColorBrush))
		{
			if (!(stroke is ImageBrush imageBrush))
			{
				if (!(stroke is GradientBrush gradientBrush))
				{
					if (stroke is AcrylicBrush acrylicBrush)
					{
						mainSvgElement.SetStyle("stroke", acrylicBrush.FallbackColorWithOpacity.ToHexString());
						_strokeBrushSubscription.Disposable = null;
					}
					else
					{
						mainSvgElement.ResetStyle("stroke");
						_strokeBrushSubscription.Disposable = null;
					}
				}
				else
				{
					UIElement gradient = gradientBrush.ToSvgElement();
					IntPtr htmlId = gradient.HtmlId;
					GetDefs().Add(gradient);
					mainSvgElement.SetStyle("stroke", $"url(#{htmlId})");
					_strokeBrushSubscription.Disposable = new DisposableAction(delegate
					{
						GetDefs().Remove(gradient);
					});
				}
			}
			else
			{
				(UIElement, IDisposable) tuple = imageBrush.ToSvgElement(this);
				UIElement imageFill = tuple.Item1;
				IDisposable item = tuple.Item2;
				IntPtr htmlId2 = imageFill.HtmlId;
				GetDefs().Add(imageFill);
				mainSvgElement.SetStyle("stroke", $"url(#{htmlId2})");
				DisposableAction disposableAction = new DisposableAction(delegate
				{
					GetDefs().Remove(imageFill);
				});
				_fillBrushSubscription.Disposable = new CompositeDisposable(disposableAction, item);
			}
		}
		else
		{
			mainSvgElement.SetStyle("stroke", solidColorBrush.ColorWithOpacity.ToHexString());
			_strokeBrushSubscription.Disposable = null;
		}
		OnStrokeThicknessUpdatedPartial();
	}

	protected virtual void OnStrokeThicknessUpdated(double newValue)
	{
		OnStrokeThicknessUpdatedPartial();
		RefreshShape();
	}

	private void OnStrokeThicknessUpdatedPartial()
	{
		SvgElement mainSvgElement = GetMainSvgElement();
		double actualStrokeThickness = ActualStrokeThickness;
		if (Stroke == null)
		{
			mainSvgElement.SetStyle("stroke-width", $"{0.0}px");
			return;
		}
		if (actualStrokeThickness != 1.0)
		{
			mainSvgElement.SetStyle("stroke-width", $"{actualStrokeThickness}px");
			return;
		}
		mainSvgElement.ResetStyle("stroke-width");
	}

	protected virtual void OnStrokeDashArrayUpdated(DoubleCollection newValue)
	{
		OnStrokeDashArrayUpdatedPartial();
		RefreshShape();
	}

	private void OnStrokeDashArrayUpdatedPartial()
	{
		SvgElement mainSvgElement = GetMainSvgElement();
		if (StrokeDashArray == null)
		{
			mainSvgElement.ResetStyle("stroke-dasharray");
			return;
		}
		string value = string.Join(",", StrokeDashArray.Select((double d) => d.ToStringInvariant() + "px"));
		mainSvgElement.SetStyle("stroke-dasharray", value);
	}

	protected virtual void OnStretchUpdated(Stretch newValue)
	{
		RefreshShape();
	}

	protected virtual void RefreshShape(bool forceRefresh = false)
	{
	}

	internal override bool IsViewHit()
	{
		return Fill != null;
	}

	protected Shape()
		: base("svg", isSvg: true)
	{
		SvgChildren = new UIElementCollection(this);
		SvgChildren.CollectionChanged += OnSvgChildrenChanged;
	}

	protected void InitCommonShapeProperties()
	{
		OnFillUpdatedPartial();
	}

	protected abstract SvgElement GetMainSvgElement();

	protected virtual void OnChildrenChanged()
	{
	}

	private protected override void OnHitTestVisibilityChanged(HitTestability oldValue, HitTestability newValue)
	{
	}

	private UIElementCollection GetDefs()
	{
		if (_defs == null)
		{
			_defs = new DefsSvgElement();
			SvgChildren.Add(_defs);
		}
		return _defs.Defs;
	}
}
