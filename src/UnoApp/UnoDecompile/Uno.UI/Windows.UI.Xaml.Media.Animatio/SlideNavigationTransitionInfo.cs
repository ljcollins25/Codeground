using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class SlideNavigationTransitionInfo : NavigationTransitionInfo
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SlideNavigationTransitionEffect Effect
	{
		get
		{
			return (SlideNavigationTransitionEffect)GetValue(EffectProperty);
		}
		set
		{
			SetValue(EffectProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EffectProperty { get; } = DependencyProperty.Register("Effect", typeof(SlideNavigationTransitionEffect), typeof(SlideNavigationTransitionInfo), new FrameworkPropertyMetadata(SlideNavigationTransitionEffect.FromBottom));

}
