using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Media3D;

namespace Windows.UI.Xaml.Media;

[NotImplemented]
public class Matrix3DProjection : Projection
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Matrix3D ProjectionMatrix
	{
		get
		{
			return (Matrix3D)GetValue(ProjectionMatrixProperty);
		}
		set
		{
			SetValue(ProjectionMatrixProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProjectionMatrixProperty { get; } = DependencyProperty.Register("ProjectionMatrix", typeof(Matrix3D), typeof(Matrix3DProjection), new FrameworkPropertyMetadata(default(Matrix3D)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Matrix3DProjection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Matrix3DProjection", "Matrix3DProjection.Matrix3DProjection()");
	}
}
