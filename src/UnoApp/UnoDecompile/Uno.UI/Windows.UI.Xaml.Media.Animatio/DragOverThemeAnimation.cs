using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class DragOverThemeAnimation : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ToOffset
	{
		get
		{
			return (double)GetValue(ToOffsetProperty);
		}
		set
		{
			SetValue(ToOffsetProperty, value);
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
	public AnimationDirection Direction
	{
		get
		{
			return (AnimationDirection)GetValue(DirectionProperty);
		}
		set
		{
			SetValue(DirectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DirectionProperty { get; } = DependencyProperty.Register("Direction", typeof(AnimationDirection), typeof(DragOverThemeAnimation), new FrameworkPropertyMetadata(AnimationDirection.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TargetNameProperty { get; } = DependencyProperty.Register("TargetName", typeof(string), typeof(DragOverThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ToOffsetProperty { get; } = DependencyProperty.Register("ToOffset", typeof(double), typeof(DragOverThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DragOverThemeAnimation()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.DragOverThemeAnimation", "DragOverThemeAnimation.DragOverThemeAnimation()");
	}
}
