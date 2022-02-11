using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Media3D;

namespace Windows.UI.Xaml.Media;

[NotImplemented]
public class PlaneProjection : Projection
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RotationZ
	{
		get
		{
			return (double)GetValue(RotationZProperty);
		}
		set
		{
			SetValue(RotationZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RotationY
	{
		get
		{
			return (double)GetValue(RotationYProperty);
		}
		set
		{
			SetValue(RotationYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double RotationX
	{
		get
		{
			return (double)GetValue(RotationXProperty);
		}
		set
		{
			SetValue(RotationXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double LocalOffsetZ
	{
		get
		{
			return (double)GetValue(LocalOffsetZProperty);
		}
		set
		{
			SetValue(LocalOffsetZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double LocalOffsetY
	{
		get
		{
			return (double)GetValue(LocalOffsetYProperty);
		}
		set
		{
			SetValue(LocalOffsetYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double LocalOffsetX
	{
		get
		{
			return (double)GetValue(LocalOffsetXProperty);
		}
		set
		{
			SetValue(LocalOffsetXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double GlobalOffsetZ
	{
		get
		{
			return (double)GetValue(GlobalOffsetZProperty);
		}
		set
		{
			SetValue(GlobalOffsetZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double GlobalOffsetY
	{
		get
		{
			return (double)GetValue(GlobalOffsetYProperty);
		}
		set
		{
			SetValue(GlobalOffsetYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double GlobalOffsetX
	{
		get
		{
			return (double)GetValue(GlobalOffsetXProperty);
		}
		set
		{
			SetValue(GlobalOffsetXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CenterOfRotationZ
	{
		get
		{
			return (double)GetValue(CenterOfRotationZProperty);
		}
		set
		{
			SetValue(CenterOfRotationZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CenterOfRotationY
	{
		get
		{
			return (double)GetValue(CenterOfRotationYProperty);
		}
		set
		{
			SetValue(CenterOfRotationYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CenterOfRotationX
	{
		get
		{
			return (double)GetValue(CenterOfRotationXProperty);
		}
		set
		{
			SetValue(CenterOfRotationXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Matrix3D ProjectionMatrix => (Matrix3D)GetValue(ProjectionMatrixProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterOfRotationXProperty { get; } = DependencyProperty.Register("CenterOfRotationX", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterOfRotationYProperty { get; } = DependencyProperty.Register("CenterOfRotationY", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterOfRotationZProperty { get; } = DependencyProperty.Register("CenterOfRotationZ", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlobalOffsetXProperty { get; } = DependencyProperty.Register("GlobalOffsetX", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlobalOffsetYProperty { get; } = DependencyProperty.Register("GlobalOffsetY", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlobalOffsetZProperty { get; } = DependencyProperty.Register("GlobalOffsetZ", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocalOffsetXProperty { get; } = DependencyProperty.Register("LocalOffsetX", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocalOffsetYProperty { get; } = DependencyProperty.Register("LocalOffsetY", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocalOffsetZProperty { get; } = DependencyProperty.Register("LocalOffsetZ", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProjectionMatrixProperty { get; } = DependencyProperty.Register("ProjectionMatrix", typeof(Matrix3D), typeof(PlaneProjection), new FrameworkPropertyMetadata(default(Matrix3D)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationXProperty { get; } = DependencyProperty.Register("RotationX", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationYProperty { get; } = DependencyProperty.Register("RotationY", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationZProperty { get; } = DependencyProperty.Register("RotationZ", typeof(double), typeof(PlaneProjection), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PlaneProjection()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.PlaneProjection", "PlaneProjection.PlaneProjection()");
	}
}
