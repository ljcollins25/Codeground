using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class PointerDownThemeAnimation : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string TargetName
	{
		get
		{
			return (string)GetValue(TargetNameProperty);
		}
		set
		{
			SetValue(TargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.Register("TargetName", typeof(string), typeof(PointerDownThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PointerDownThemeAnimation()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.PointerDownThemeAnimation", "PointerDownThemeAnimation.PointerDownThemeAnimation()");
	}
}
