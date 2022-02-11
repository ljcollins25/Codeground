using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class SwipeHintThemeAnimation : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ToVerticalOffset
	{
		get
		{
			return (double)GetValue(ToVerticalOffsetProperty);
		}
		set
		{
			SetValue(ToVerticalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ToHorizontalOffset
	{
		get
		{
			return (double)GetValue(ToHorizontalOffsetProperty);
		}
		set
		{
			SetValue(ToHorizontalOffsetProperty, value);
		}
	}

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
	public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.Register("TargetName", typeof(string), typeof(SwipeHintThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ToHorizontalOffsetProperty { get; } = DependencyProperty.Register("ToHorizontalOffset", typeof(double), typeof(SwipeHintThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ToVerticalOffsetProperty { get; } = DependencyProperty.Register("ToVerticalOffset", typeof(double), typeof(SwipeHintThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SwipeHintThemeAnimation()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.SwipeHintThemeAnimation", "SwipeHintThemeAnimation.SwipeHintThemeAnimation()");
	}
}
