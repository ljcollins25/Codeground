using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Media.Animation;

[NotImplemented]
public class SplitOpenThemeAnimation : Timeline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string OpenedTargetName
	{
		get
		{
			return (string)GetValue(OpenedTargetNameProperty);
		}
		set
		{
			SetValue(OpenedTargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject OpenedTarget
	{
		get
		{
			return (DependencyObject)GetValue(OpenedTargetProperty);
		}
		set
		{
			SetValue(OpenedTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OpenedLength
	{
		get
		{
			return (double)GetValue(OpenedLengthProperty);
		}
		set
		{
			SetValue(OpenedLengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OffsetFromCenter
	{
		get
		{
			return (double)GetValue(OffsetFromCenterProperty);
		}
		set
		{
			SetValue(OffsetFromCenterProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ContentTranslationOffset
	{
		get
		{
			return (double)GetValue(ContentTranslationOffsetProperty);
		}
		set
		{
			SetValue(ContentTranslationOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AnimationDirection ContentTranslationDirection
	{
		get
		{
			return (AnimationDirection)GetValue(ContentTranslationDirectionProperty);
		}
		set
		{
			SetValue(ContentTranslationDirectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string ContentTargetName
	{
		get
		{
			return (string)GetValue(ContentTargetNameProperty);
		}
		set
		{
			SetValue(ContentTargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ContentTarget
	{
		get
		{
			return (DependencyObject)GetValue(ContentTargetProperty);
		}
		set
		{
			SetValue(ContentTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string ClosedTargetName
	{
		get
		{
			return (string)GetValue(ClosedTargetNameProperty);
		}
		set
		{
			SetValue(ClosedTargetNameProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject ClosedTarget
	{
		get
		{
			return (DependencyObject)GetValue(ClosedTargetProperty);
		}
		set
		{
			SetValue(ClosedTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double ClosedLength
	{
		get
		{
			return (double)GetValue(ClosedLengthProperty);
		}
		set
		{
			SetValue(ClosedLengthProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ClosedLengthProperty { get; } = DependencyProperty.Register("ClosedLength", typeof(double), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ClosedTargetNameProperty { get; } = DependencyProperty.Register("ClosedTargetName", typeof(string), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ClosedTargetProperty { get; } = DependencyProperty.Register("ClosedTarget", typeof(DependencyObject), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentTargetNameProperty { get; } = DependencyProperty.Register("ContentTargetName", typeof(string), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentTargetProperty { get; } = DependencyProperty.Register("ContentTarget", typeof(DependencyObject), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentTranslationDirectionProperty { get; } = DependencyProperty.Register("ContentTranslationDirection", typeof(AnimationDirection), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata(AnimationDirection.Left));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ContentTranslationOffsetProperty { get; } = DependencyProperty.Register("ContentTranslationOffset", typeof(double), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OffsetFromCenterProperty { get; } = DependencyProperty.Register("OffsetFromCenter", typeof(double), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OpenedLengthProperty { get; } = DependencyProperty.Register("OpenedLength", typeof(double), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OpenedTargetNameProperty { get; } = DependencyProperty.Register("OpenedTargetName", typeof(string), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OpenedTargetProperty { get; } = DependencyProperty.Register("OpenedTarget", typeof(DependencyObject), typeof(SplitOpenThemeAnimation), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SplitOpenThemeAnimation()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.SplitOpenThemeAnimation", "SplitOpenThemeAnimation.SplitOpenThemeAnimation()");
	}
}
