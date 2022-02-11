using System;
using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class PointAnimationUsingKeyFrames : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool EnableDependentAnimation
	{
		get
		{
			return (bool)GetValue(EnableDependentAnimationProperty);
		}
		set
		{
			SetValue(EnableDependentAnimationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PointKeyFrameCollection KeyFrames
	{
		get
		{
			throw new NotImplementedException("The member PointKeyFrameCollection PointAnimationUsingKeyFrames.KeyFrames is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty EnableDependentAnimationProperty { get; } = DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(PointAnimationUsingKeyFrames), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PointAnimationUsingKeyFrames()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.PointAnimationUsingKeyFrames", "PointAnimationUsingKeyFrames.PointAnimationUsingKeyFrames()");
	}
}
