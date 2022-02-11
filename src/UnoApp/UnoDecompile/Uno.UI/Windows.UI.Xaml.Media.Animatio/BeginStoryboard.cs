using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class BeginStoryboard : TriggerAction
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Storyboard Storyboard
	{
		get
		{
			return (Storyboard)GetValue(StoryboardProperty);
		}
		set
		{
			SetValue(StoryboardProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StoryboardProperty { get; } = DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(BeginStoryboard), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public BeginStoryboard()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.BeginStoryboard", "BeginStoryboard.BeginStoryboard()");
	}
}
