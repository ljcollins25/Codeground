using System;
using Uno.Disposables;
using Uno.Extensions;
using Uno.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Shapes;

internal class BorderLayerRenderer
{
	private Brush _background;

	private (Brush, Thickness) _border;

	private CornerRadius _cornerRadius;

	private SerialDisposable _backgroundSubscription;

	private static readonly SizeChangedEventHandler _onSizeChangedForBrushCalculation = delegate(object sender, SizeChangedEventArgs args)
	{
		FrameworkElement frameworkElement = sender as FrameworkElement;
		SetBackgroundBrush(frameworkElement, frameworkElement.Background);
	};

	public void UpdateLayer(UIElement element, Brush background, BackgroundSizing backgroundSizing, Thickness borderThickness, Brush borderBrush, CornerRadius cornerRadius, object image)
	{
		if (_background != background && element is FrameworkElement element2)
		{
			_background = background;
			SerialDisposable serialDisposable = _backgroundSubscription ?? (_backgroundSubscription = new SerialDisposable());
			serialDisposable.Disposable = null;
			serialDisposable.Disposable = SetAndObserveBackgroundBrush(element2, background);
		}
		(Brush, Thickness) border = _border;
		Brush item = border.Item1;
		Thickness item2 = border.Item2;
		if (item != borderBrush || item2 != borderThickness)
		{
			_border = (borderBrush, borderThickness);
			SetBorder(element, borderThickness, borderBrush);
		}
		if (_cornerRadius != cornerRadius)
		{
			_cornerRadius = cornerRadius;
			SetCornerRadius(element, cornerRadius);
		}
	}

	public static void SetCornerRadius(UIElement element, CornerRadius cornerRadius)
	{
		if (cornerRadius == CornerRadius.None)
		{
			element.ResetStyle("border-radius", "overflow");
			return;
		}
		string item = cornerRadius.TopLeft.ToStringInvariant() + "px " + cornerRadius.TopRight.ToStringInvariant() + "px " + cornerRadius.BottomRight.ToStringInvariant() + "px " + cornerRadius.BottomLeft.ToStringInvariant() + "px";
		element.SetStyle(("border-radius", item), ("overflow", "hidden"));
	}

	public static void SetBorder(UIElement element, Thickness thickness, Brush brush)
	{
		if (thickness == Thickness.Empty)
		{
			element.SetStyle(("border-style", "none"), ("border-color", ""), ("border-width", ""));
			return;
		}
		string item = thickness.Top.ToStringInvariant() + "px " + thickness.Right.ToStringInvariant() + "px " + thickness.Bottom.ToStringInvariant() + "px " + thickness.Left.ToStringInvariant() + "px";
		if (!(brush is SolidColorBrush solidColorBrush))
		{
			if (!(brush is GradientBrush gradientBrush))
			{
				if (brush is AcrylicBrush acrylicBrush)
				{
					Color fallbackColorWithOpacity = acrylicBrush.FallbackColorWithOpacity;
					element.SetStyle(("border", ""), ("border-style", "solid"), ("border-color", fallbackColorWithOpacity.ToHexString()), ("border-width", item));
				}
				else
				{
					element.ResetStyle("border-style", "border-color", "border-image", "border-width");
				}
			}
			else
			{
				string item2 = gradientBrush.ToCssString(element.RenderSize);
				element.SetStyle(("border-style", "solid"), ("border-color", ""), ("border-image", item2), ("border-width", item), ("border-image-slice", "1"));
			}
		}
		else
		{
			Color colorWithOpacity = solidColorBrush.ColorWithOpacity;
			element.SetStyle(("border", ""), ("border-style", "solid"), ("border-color", colorWithOpacity.ToHexString()), ("border-width", item));
		}
	}

	public static IDisposable SetAndObserveBackgroundBrush(FrameworkElement element, Brush brush)
	{
		SetBackgroundBrush(element, brush);
		ImageBrush imgBrush = brush as ImageBrush;
		if (imgBrush != null)
		{
			RecalculateBrushOnSizeChanged(element, shouldRecalculate: false);
			return imgBrush.Subscribe(delegate(ImageData img)
			{
				switch (img.Kind)
				{
				case ImageDataKind.Empty:
				case ImageDataKind.Error:
					element.ResetStyle("background-color", "background-image", "background-size");
					break;
				default:
					element.SetStyle(("background-color", ""), ("background-origin", "content-box"), ("background-position", imgBrush.ToCssPosition()), ("background-size", imgBrush.ToCssBackgroundSize()), ("background-image", "url(" + img.Value + ")"));
					break;
				}
			});
		}
		if (brush is AcrylicBrush acrylicBrush)
		{
			return acrylicBrush.Subscribe(element);
		}
		return Brush.AssignAndObserveBrush(brush, delegate
		{
			SetBackgroundBrush(element, brush);
		});
	}

	public static void SetBackgroundBrush(FrameworkElement element, Brush brush)
	{
		if (!(brush is SolidColorBrush solidColorBrush))
		{
			if (!(brush is GradientBrush gradientBrush))
			{
				if (brush is XamlCompositionBrushBase xamlCompositionBrushBase)
				{
					Color fallbackColorWithOpacity = xamlCompositionBrushBase.FallbackColorWithOpacity;
					WindowManagerInterop.SetElementBackgroundColor(element.HtmlId, fallbackColorWithOpacity);
					RecalculateBrushOnSizeChanged(element, shouldRecalculate: false);
				}
				else
				{
					WindowManagerInterop.ResetElementBackground(element.HtmlId);
					RecalculateBrushOnSizeChanged(element, shouldRecalculate: false);
				}
			}
			else
			{
				WindowManagerInterop.SetElementBackgroundGradient(element.HtmlId, gradientBrush.ToCssString(element.RenderSize));
				RecalculateBrushOnSizeChanged(element, shouldRecalculate: true);
			}
		}
		else
		{
			Color colorWithOpacity = solidColorBrush.ColorWithOpacity;
			WindowManagerInterop.SetElementBackgroundColor(element.HtmlId, colorWithOpacity);
			RecalculateBrushOnSizeChanged(element, shouldRecalculate: false);
		}
	}

	private static void RecalculateBrushOnSizeChanged(FrameworkElement element, bool shouldRecalculate)
	{
		if (shouldRecalculate)
		{
			element.SizeChanged -= _onSizeChangedForBrushCalculation;
			element.SizeChanged += _onSizeChangedForBrushCalculation;
		}
		else
		{
			element.SizeChanged -= _onSizeChangedForBrushCalculation;
		}
	}
}
