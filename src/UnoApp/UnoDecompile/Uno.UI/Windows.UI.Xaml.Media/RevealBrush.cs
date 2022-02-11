using Uno;

namespace Windows.UI.Xaml.Media;

public class RevealBrush : XamlCompositionBrushBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ApplicationTheme TargetTheme
	{
		get
		{
			return (ApplicationTheme)GetValue(TargetThemeProperty);
		}
		set
		{
			SetValue(TargetThemeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AlwaysUseFallbackProperty { get; } = DependencyProperty.Register("AlwaysUseFallback", typeof(bool), typeof(RevealBrush), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StateProperty { get; } = DependencyProperty.RegisterAttached("State", typeof(RevealBrushState), typeof(RevealBrush), new FrameworkPropertyMetadata(RevealBrushState.Normal));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetThemeProperty { get; } = DependencyProperty.Register("TargetTheme", typeof(ApplicationTheme), typeof(RevealBrush), new FrameworkPropertyMetadata(ApplicationTheme.Light));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorProperty { get; } = DependencyProperty.Register("Color", typeof(Color), typeof(RevealBrush), new FrameworkPropertyMetadata(default(Color)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetState(UIElement element, RevealBrushState value)
	{
		element.SetValue(StateProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RevealBrushState GetState(UIElement element)
	{
		return (RevealBrushState)element.GetValue(StateProperty);
	}
}
