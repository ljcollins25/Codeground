using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Media3D;

[NotImplemented]
public class PerspectiveTransform3D : Transform3D
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OffsetY
	{
		get
		{
			return (double)GetValue(OffsetYProperty);
		}
		set
		{
			SetValue(OffsetYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OffsetX
	{
		get
		{
			return (double)GetValue(OffsetXProperty);
		}
		set
		{
			SetValue(OffsetXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Depth
	{
		get
		{
			return (double)GetValue(DepthProperty);
		}
		set
		{
			SetValue(DepthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DepthProperty { get; } = DependencyProperty.Register("Depth", typeof(double), typeof(PerspectiveTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OffsetXProperty { get; } = DependencyProperty.Register("OffsetX", typeof(double), typeof(PerspectiveTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OffsetYProperty { get; } = DependencyProperty.Register("OffsetY", typeof(double), typeof(PerspectiveTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PerspectiveTransform3D()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Media3D.PerspectiveTransform3D", "PerspectiveTransform3D.PerspectiveTransform3D()");
	}
}
