using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class SplineColorKeyFrame : ColorKeyFrame
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public KeySpline KeySpline
	{
		get
		{
			return (KeySpline)GetValue(KeySplineProperty);
		}
		set
		{
			SetValue(KeySplineProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeySplineProperty { get; } = DependencyProperty.Register("KeySpline", typeof(KeySpline), typeof(SplineColorKeyFrame), new FrameworkPropertyMetadata((object)null));


	internal override IEasingFunction GetEasingFunction()
	{
		return new SplineEasingFunction(KeySpline);
	}
}
