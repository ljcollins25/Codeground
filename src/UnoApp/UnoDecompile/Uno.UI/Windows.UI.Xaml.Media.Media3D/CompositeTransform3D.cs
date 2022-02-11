using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Media.Media3D;

[NotImplemented]
public class CompositeTransform3D : Transform3D
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double TranslateZ
	{
		get
		{
			return (double)GetValue(TranslateZProperty);
		}
		set
		{
			SetValue(TranslateZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double TranslateY
	{
		get
		{
			return (double)GetValue(TranslateYProperty);
		}
		set
		{
			SetValue(TranslateYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double TranslateX
	{
		get
		{
			return (double)GetValue(TranslateXProperty);
		}
		set
		{
			SetValue(TranslateXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ScaleZ
	{
		get
		{
			return (double)GetValue(ScaleZProperty);
		}
		set
		{
			SetValue(ScaleZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ScaleY
	{
		get
		{
			return (double)GetValue(ScaleYProperty);
		}
		set
		{
			SetValue(ScaleYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ScaleX
	{
		get
		{
			return (double)GetValue(ScaleXProperty);
		}
		set
		{
			SetValue(ScaleXProperty, value);
		}
	}

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
	public double CenterZ
	{
		get
		{
			return (double)GetValue(CenterZProperty);
		}
		set
		{
			SetValue(CenterZProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CenterY
	{
		get
		{
			return (double)GetValue(CenterYProperty);
		}
		set
		{
			SetValue(CenterYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double CenterX
	{
		get
		{
			return (double)GetValue(CenterXProperty);
		}
		set
		{
			SetValue(CenterXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterXProperty { get; } = DependencyProperty.Register("CenterX", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterYProperty { get; } = DependencyProperty.Register("CenterY", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CenterZProperty { get; } = DependencyProperty.Register("CenterZ", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationXProperty { get; } = DependencyProperty.Register("RotationX", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationYProperty { get; } = DependencyProperty.Register("RotationY", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty RotationZProperty { get; } = DependencyProperty.Register("RotationZ", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ScaleXProperty { get; } = DependencyProperty.Register("ScaleX", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ScaleYProperty { get; } = DependencyProperty.Register("ScaleY", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ScaleZProperty { get; } = DependencyProperty.Register("ScaleZ", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TranslateXProperty { get; } = DependencyProperty.Register("TranslateX", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TranslateYProperty { get; } = DependencyProperty.Register("TranslateY", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty TranslateZProperty { get; } = DependencyProperty.Register("TranslateZ", typeof(double), typeof(CompositeTransform3D), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositeTransform3D()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Media3D.CompositeTransform3D", "CompositeTransform3D.CompositeTransform3D()");
	}
}
