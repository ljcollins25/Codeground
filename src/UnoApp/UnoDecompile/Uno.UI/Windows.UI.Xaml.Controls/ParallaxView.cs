using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class ParallaxView : FrameworkElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalSourceStartOffset
	{
		get
		{
			return (double)GetValue(VerticalSourceStartOffsetProperty);
		}
		set
		{
			SetValue(VerticalSourceStartOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ParallaxSourceOffsetKind VerticalSourceOffsetKind
	{
		get
		{
			return (ParallaxSourceOffsetKind)GetValue(VerticalSourceOffsetKindProperty);
		}
		set
		{
			SetValue(VerticalSourceOffsetKindProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalSourceEndOffset
	{
		get
		{
			return (double)GetValue(VerticalSourceEndOffsetProperty);
		}
		set
		{
			SetValue(VerticalSourceEndOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double VerticalShift
	{
		get
		{
			return (double)GetValue(VerticalShiftProperty);
		}
		set
		{
			SetValue(VerticalShiftProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Source
	{
		get
		{
			return (UIElement)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MaxVerticalShiftRatio
	{
		get
		{
			return (double)GetValue(MaxVerticalShiftRatioProperty);
		}
		set
		{
			SetValue(MaxVerticalShiftRatioProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double MaxHorizontalShiftRatio
	{
		get
		{
			return (double)GetValue(MaxHorizontalShiftRatioProperty);
		}
		set
		{
			SetValue(MaxHorizontalShiftRatioProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsVerticalShiftClamped
	{
		get
		{
			return (bool)GetValue(IsVerticalShiftClampedProperty);
		}
		set
		{
			SetValue(IsVerticalShiftClampedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHorizontalShiftClamped
	{
		get
		{
			return (bool)GetValue(IsHorizontalShiftClampedProperty);
		}
		set
		{
			SetValue(IsHorizontalShiftClampedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalSourceStartOffset
	{
		get
		{
			return (double)GetValue(HorizontalSourceStartOffsetProperty);
		}
		set
		{
			SetValue(HorizontalSourceStartOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ParallaxSourceOffsetKind HorizontalSourceOffsetKind
	{
		get
		{
			return (ParallaxSourceOffsetKind)GetValue(HorizontalSourceOffsetKindProperty);
		}
		set
		{
			SetValue(HorizontalSourceOffsetKindProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalSourceEndOffset
	{
		get
		{
			return (double)GetValue(HorizontalSourceEndOffsetProperty);
		}
		set
		{
			SetValue(HorizontalSourceEndOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double HorizontalShift
	{
		get
		{
			return (double)GetValue(HorizontalShiftProperty);
		}
		set
		{
			SetValue(HorizontalShiftProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIElement Child
	{
		get
		{
			return (UIElement)GetValue(ChildProperty);
		}
		set
		{
			SetValue(ChildProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ChildProperty { get; } = DependencyProperty.Register("Child", typeof(UIElement), typeof(ParallaxView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalShiftProperty { get; } = DependencyProperty.Register("HorizontalShift", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalSourceEndOffsetProperty { get; } = DependencyProperty.Register("HorizontalSourceEndOffset", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalSourceOffsetKindProperty { get; } = DependencyProperty.Register("HorizontalSourceOffsetKind", typeof(ParallaxSourceOffsetKind), typeof(ParallaxView), new FrameworkPropertyMetadata(ParallaxSourceOffsetKind.Absolute));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HorizontalSourceStartOffsetProperty { get; } = DependencyProperty.Register("HorizontalSourceStartOffset", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHorizontalShiftClampedProperty { get; } = DependencyProperty.Register("IsHorizontalShiftClamped", typeof(bool), typeof(ParallaxView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsVerticalShiftClampedProperty { get; } = DependencyProperty.Register("IsVerticalShiftClamped", typeof(bool), typeof(ParallaxView), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxHorizontalShiftRatioProperty { get; } = DependencyProperty.Register("MaxHorizontalShiftRatio", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MaxVerticalShiftRatioProperty { get; } = DependencyProperty.Register("MaxVerticalShiftRatio", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(UIElement), typeof(ParallaxView), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalShiftProperty { get; } = DependencyProperty.Register("VerticalShift", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalSourceEndOffsetProperty { get; } = DependencyProperty.Register("VerticalSourceEndOffset", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalSourceOffsetKindProperty { get; } = DependencyProperty.Register("VerticalSourceOffsetKind", typeof(ParallaxSourceOffsetKind), typeof(ParallaxView), new FrameworkPropertyMetadata(ParallaxSourceOffsetKind.Absolute));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty VerticalSourceStartOffsetProperty { get; } = DependencyProperty.Register("VerticalSourceStartOffset", typeof(double), typeof(ParallaxView), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ParallaxView()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ParallaxView", "ParallaxView.ParallaxView()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RefreshAutomaticHorizontalOffsets()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ParallaxView", "void ParallaxView.RefreshAutomaticHorizontalOffsets()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RefreshAutomaticVerticalOffsets()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.ParallaxView", "void ParallaxView.RefreshAutomaticVerticalOffsets()");
	}
}
