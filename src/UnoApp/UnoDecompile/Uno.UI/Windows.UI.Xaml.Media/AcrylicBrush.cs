using System;
using Uno;
using Uno.Disposables;
using Uno.UI.Xaml;

namespace Windows.UI.Xaml.Media;

public class AcrylicBrush : XamlCompositionBrushBase
{
	private const string BlurSize = "20px";

	private const string CssSupportCondition = "(backdrop-filter: blur(20px)) or (-webkit-backdrop-filter: blur(20px))";

	private static bool? _isBackdropFilterSupported = null;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public TimeSpan TintTransitionDuration
	{
		get
		{
			return (TimeSpan)GetValue(TintTransitionDurationProperty);
		}
		set
		{
			SetValue(TintTransitionDurationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TintTransitionDurationProperty { get; } = DependencyProperty.Register("TintTransitionDuration", typeof(TimeSpan), typeof(AcrylicBrush), new FrameworkPropertyMetadata(default(TimeSpan)));


	public Color TintColor
	{
		get
		{
			return (Color)GetValue(TintColorProperty);
		}
		set
		{
			SetValue(TintColorProperty, value);
		}
	}

	public double TintOpacity
	{
		get
		{
			return (double)GetValue(TintOpacityProperty);
		}
		set
		{
			SetValue(TintOpacityProperty, value);
		}
	}

	public double? TintLuminosityOpacity
	{
		get
		{
			return (double?)GetValue(TintLuminosityOpacityProperty);
		}
		set
		{
			SetValue(TintLuminosityOpacityProperty, value);
		}
	}

	public AcrylicBackgroundSource BackgroundSource
	{
		get
		{
			return (AcrylicBackgroundSource)GetValue(BackgroundSourceProperty);
		}
		set
		{
			SetValue(BackgroundSourceProperty, value);
		}
	}

	public bool AlwaysUseFallback
	{
		get
		{
			return (bool)GetValue(AlwaysUseFallbackProperty);
		}
		set
		{
			SetValue(AlwaysUseFallbackProperty, value);
		}
	}

	public static DependencyProperty TintColorProperty { get; } = DependencyProperty.Register("TintColor", typeof(Color), typeof(AcrylicBrush), new FrameworkPropertyMetadata(default(Color)));


	public static DependencyProperty TintOpacityProperty { get; } = DependencyProperty.Register("TintOpacity", typeof(double), typeof(AcrylicBrush), new FrameworkPropertyMetadata(0.5));


	public static DependencyProperty TintLuminosityOpacityProperty { get; } = DependencyProperty.Register("TintLuminosityOpacity", typeof(double?), typeof(AcrylicBrush), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty BackgroundSourceProperty { get; } = DependencyProperty.Register("BackgroundSource", typeof(AcrylicBackgroundSource), typeof(AcrylicBrush), new FrameworkPropertyMetadata(AcrylicBackgroundSource.Backdrop));


	public static DependencyProperty AlwaysUseFallbackProperty { get; } = DependencyProperty.Register("AlwaysUseFallback", typeof(bool), typeof(AcrylicBrush), new FrameworkPropertyMetadata(false));


	internal Color TintColorWithTintOpacity => TintColor.WithOpacity(TintOpacity);

	internal IDisposable Subscribe(UIElement uiElement)
	{
		CompositeDisposable compositeDisposable = new CompositeDisposable(6);
		this.RegisterDisposablePropertyChangedCallback(AlwaysUseFallbackProperty, delegate
		{
			Apply(uiElement);
		}).DisposeWith(compositeDisposable);
		this.RegisterDisposablePropertyChangedCallback(XamlCompositionBrushBase.FallbackColorProperty, delegate
		{
			Apply(uiElement);
		}).DisposeWith(compositeDisposable);
		this.RegisterDisposablePropertyChangedCallback(TintColorProperty, delegate
		{
			Apply(uiElement);
		}).DisposeWith(compositeDisposable);
		this.RegisterDisposablePropertyChangedCallback(TintOpacityProperty, delegate
		{
			Apply(uiElement);
		}).DisposeWith(compositeDisposable);
		this.RegisterDisposablePropertyChangedCallback(Brush.OpacityProperty, delegate
		{
			Apply(uiElement);
		}).DisposeWith(compositeDisposable);
		Apply(uiElement);
		Disposable.Create(delegate
		{
			ResetStyle(uiElement);
		}).DisposeWith(compositeDisposable);
		return compositeDisposable;
	}

	internal void Apply(UIElement uiElement)
	{
		bool flag = IsBackdropFilterSupported();
		ResetStyle(uiElement);
		if (AlwaysUseFallback || !flag)
		{
			uiElement.SetStyle("background-color", base.FallbackColorWithOpacity.ToCssString());
			return;
		}
		uiElement.SetStyle(("-webkit-backdrop-filter", "blur(20px)"), ("backdrop-filter", "blur(20px)"), ("background-color", TintColorWithTintOpacity.ToCssString()));
	}

	internal static void ResetStyle(UIElement element)
	{
		element.ResetStyle("-webkit-backdrop-filter", "backdrop-filter", "background-color");
	}

	private static bool IsBackdropFilterSupported()
	{
		bool valueOrDefault = _isBackdropFilterSupported.GetValueOrDefault();
		if (!_isBackdropFilterSupported.HasValue)
		{
			valueOrDefault = WindowManagerInterop.IsCssFeatureSupported("(backdrop-filter: blur(20px)) or (-webkit-backdrop-filter: blur(20px))");
			_isBackdropFilterSupported = valueOrDefault;
			return valueOrDefault;
		}
		return valueOrDefault;
	}
}
