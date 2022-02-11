using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class PopupThemeTransition : Transition
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double FromVerticalOffset
	{
		get
		{
			return (double)GetValue(FromVerticalOffsetProperty);
		}
		set
		{
			SetValue(FromVerticalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double FromHorizontalOffset
	{
		get
		{
			return (double)GetValue(FromHorizontalOffsetProperty);
		}
		set
		{
			SetValue(FromHorizontalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FromHorizontalOffsetProperty { get; } = DependencyProperty.Register("FromHorizontalOffset", typeof(double), typeof(PopupThemeTransition), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FromVerticalOffsetProperty { get; } = DependencyProperty.Register("FromVerticalOffset", typeof(double), typeof(PopupThemeTransition), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PopupThemeTransition()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.PopupThemeTransition", "PopupThemeTransition.PopupThemeTransition()");
	}
}
