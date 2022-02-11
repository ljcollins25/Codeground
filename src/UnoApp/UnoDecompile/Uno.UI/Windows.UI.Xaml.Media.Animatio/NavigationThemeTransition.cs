using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class NavigationThemeTransition : Transition
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public NavigationTransitionInfo DefaultNavigationTransitionInfo
	{
		get
		{
			return (NavigationTransitionInfo)GetValue(DefaultNavigationTransitionInfoProperty);
		}
		set
		{
			SetValue(DefaultNavigationTransitionInfoProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultNavigationTransitionInfoProperty { get; } = DependencyProperty.Register("DefaultNavigationTransitionInfo", typeof(NavigationTransitionInfo), typeof(NavigationThemeTransition), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public NavigationThemeTransition()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.NavigationThemeTransition", "NavigationThemeTransition.NavigationThemeTransition()");
	}
}
