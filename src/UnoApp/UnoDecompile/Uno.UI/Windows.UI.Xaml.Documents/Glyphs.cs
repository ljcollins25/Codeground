using System;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Documents;

[NotImplemented]
public class Glyphs : FrameworkElement
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string UnicodeString
	{
		get
		{
			return (string)GetValue(UnicodeStringProperty);
		}
		set
		{
			SetValue(UnicodeStringProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public StyleSimulations StyleSimulations
	{
		get
		{
			return (StyleSimulations)GetValue(StyleSimulationsProperty);
		}
		set
		{
			SetValue(StyleSimulationsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OriginY
	{
		get
		{
			return (double)GetValue(OriginYProperty);
		}
		set
		{
			SetValue(OriginYProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double OriginX
	{
		get
		{
			return (double)GetValue(OriginXProperty);
		}
		set
		{
			SetValue(OriginXProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Indices
	{
		get
		{
			return (string)GetValue(IndicesProperty);
		}
		set
		{
			SetValue(IndicesProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Uri FontUri
	{
		get
		{
			return (Uri)GetValue(FontUriProperty);
		}
		set
		{
			SetValue(FontUriProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double FontRenderingEmSize
	{
		get
		{
			return (double)GetValue(FontRenderingEmSizeProperty);
		}
		set
		{
			SetValue(FontRenderingEmSizeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Brush Fill
	{
		get
		{
			return (Brush)GetValue(FillProperty);
		}
		set
		{
			SetValue(FillProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsColorFontEnabled
	{
		get
		{
			return (bool)GetValue(IsColorFontEnabledProperty);
		}
		set
		{
			SetValue(IsColorFontEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int ColorFontPaletteIndex
	{
		get
		{
			return (int)GetValue(ColorFontPaletteIndexProperty);
		}
		set
		{
			SetValue(ColorFontPaletteIndexProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FillProperty { get; } = DependencyProperty.Register("Fill", typeof(Brush), typeof(Glyphs), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FontRenderingEmSizeProperty { get; } = DependencyProperty.Register("FontRenderingEmSize", typeof(double), typeof(Glyphs), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FontUriProperty { get; } = DependencyProperty.Register("FontUri", typeof(Uri), typeof(Glyphs), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IndicesProperty { get; } = DependencyProperty.Register("Indices", typeof(string), typeof(Glyphs), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OriginXProperty { get; } = DependencyProperty.Register("OriginX", typeof(double), typeof(Glyphs), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OriginYProperty { get; } = DependencyProperty.Register("OriginY", typeof(double), typeof(Glyphs), new FrameworkPropertyMetadata(0.0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty StyleSimulationsProperty { get; } = DependencyProperty.Register("StyleSimulations", typeof(StyleSimulations), typeof(Glyphs), new FrameworkPropertyMetadata(StyleSimulations.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty UnicodeStringProperty { get; } = DependencyProperty.Register("UnicodeString", typeof(string), typeof(Glyphs), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ColorFontPaletteIndexProperty { get; } = DependencyProperty.Register("ColorFontPaletteIndex", typeof(int), typeof(Glyphs), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsColorFontEnabledProperty { get; } = DependencyProperty.Register("IsColorFontEnabled", typeof(bool), typeof(Glyphs), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Glyphs()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Documents.Glyphs", "Glyphs.Glyphs()");
	}
}
