using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class RatingItemImageInfo : RatingItemInfo
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource UnsetImage
	{
		get
		{
			return (ImageSource)GetValue(UnsetImageProperty);
		}
		set
		{
			SetValue(UnsetImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource PointerOverPlaceholderImage
	{
		get
		{
			return (ImageSource)GetValue(PointerOverPlaceholderImageProperty);
		}
		set
		{
			SetValue(PointerOverPlaceholderImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource PointerOverImage
	{
		get
		{
			return (ImageSource)GetValue(PointerOverImageProperty);
		}
		set
		{
			SetValue(PointerOverImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource PlaceholderImage
	{
		get
		{
			return (ImageSource)GetValue(PlaceholderImageProperty);
		}
		set
		{
			SetValue(PlaceholderImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource Image
	{
		get
		{
			return (ImageSource)GetValue(ImageProperty);
		}
		set
		{
			SetValue(ImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ImageSource DisabledImage
	{
		get
		{
			return (ImageSource)GetValue(DisabledImageProperty);
		}
		set
		{
			SetValue(DisabledImageProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DisabledImageProperty { get; } = DependencyProperty.Register("DisabledImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ImageProperty { get; } = DependencyProperty.Register("Image", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderImageProperty { get; } = DependencyProperty.Register("PlaceholderImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PointerOverImageProperty { get; } = DependencyProperty.Register("PointerOverImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PointerOverPlaceholderImageProperty { get; } = DependencyProperty.Register("PointerOverPlaceholderImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty UnsetImageProperty { get; } = DependencyProperty.Register("UnsetImage", typeof(ImageSource), typeof(RatingItemImageInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RatingItemImageInfo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RatingItemImageInfo", "RatingItemImageInfo.RatingItemImageInfo()");
	}
}
