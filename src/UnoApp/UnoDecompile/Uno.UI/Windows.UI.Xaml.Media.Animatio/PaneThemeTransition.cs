using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class PaneThemeTransition : Transition
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public EdgeTransitionLocation Edge
	{
		get
		{
			return (EdgeTransitionLocation)GetValue(EdgeProperty);
		}
		set
		{
			SetValue(EdgeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EdgeProperty { get; } = DependencyProperty.Register("Edge", typeof(EdgeTransitionLocation), typeof(PaneThemeTransition), new FrameworkPropertyMetadata(EdgeTransitionLocation.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PaneThemeTransition()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.PaneThemeTransition", "PaneThemeTransition.PaneThemeTransition()");
	}
}
