using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class RatingItemFontInfo : RatingItemInfo
{
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

	public static DependencyProperty DisabledGlyphProperty { get; } = DependencyProperty.Register("DisabledGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty GlyphProperty { get; } = DependencyProperty.Register("Glyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty PlaceholderGlyphProperty { get; } = DependencyProperty.Register("PlaceholderGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty PointerOverGlyphProperty { get; } = DependencyProperty.Register("PointerOverGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty PointerOverPlaceholderGlyphProperty { get; } = DependencyProperty.Register("PointerOverPlaceholderGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));


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

	public static DependencyProperty UnsetGlyphProperty { get; } = DependencyProperty.Register("UnsetGlyph", typeof(string), typeof(RatingItemFontInfo), new FrameworkPropertyMetadata(null));

}
