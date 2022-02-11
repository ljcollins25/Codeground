using Uno;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class RatingItemFontInfo : RatingItemInfo
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string UnsetGlyph
	{
		get
		{
			return (string)GetValue(UnsetGlyphProperty);
		}
		set
		{
			SetValue(UnsetGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string PointerOverPlaceholderGlyph
	{
		get
		{
			return (string)GetValue(PointerOverPlaceholderGlyphProperty);
		}
		set
		{
			SetValue(PointerOverPlaceholderGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string PointerOverGlyph
	{
		get
		{
			return (string)GetValue(PointerOverGlyphProperty);
		}
		set
		{
			SetValue(PointerOverGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string PlaceholderGlyph
	{
		get
		{
			return (string)GetValue(PlaceholderGlyphProperty);
		}
		set
		{
			SetValue(PlaceholderGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Glyph
	{
		get
		{
			return (string)GetValue(GlyphProperty);
		}
		set
		{
			SetValue(GlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string DisabledGlyph
	{
		get
		{
			return (string)GetValue(DisabledGlyphProperty);
		}
		set
		{
			SetValue(DisabledGlyphProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DisabledGlyphProperty { get; } = DependencyProperty.Register("DisabledGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty GlyphProperty { get; } = DependencyProperty.Register("Glyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderGlyphProperty { get; } = DependencyProperty.Register("PlaceholderGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PointerOverGlyphProperty { get; } = DependencyProperty.Register("PointerOverGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PointerOverPlaceholderGlyphProperty { get; } = DependencyProperty.Register("PointerOverPlaceholderGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty UnsetGlyphProperty { get; } = DependencyProperty.Register("UnsetGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public RatingItemFontInfo()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.RatingItemFontInfo", "RatingItemFontInfo.RatingItemFontInfo()");
	}
}
