using Uno.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class FontIconSource : IconSource
{
	public bool MirroredWhenRightToLeft
	{
		get
		{
			return (bool)GetValue(MirroredWhenRightToLeftProperty);
		}
		set
		{
			SetValue(MirroredWhenRightToLeftProperty, value);
		}
	}

	public static DependencyProperty MirroredWhenRightToLeftProperty { get; } = DependencyProperty.Register("MirroredWhenRightToLeft", typeof(bool), typeof(FontIconSource), new FrameworkPropertyMetadata(false));


	public bool IsTextScaleFactorEnabled
	{
		get
		{
			return (bool)GetValue(IsTextScaleFactorEnabledProperty);
		}
		set
		{
			SetValue(IsTextScaleFactorEnabledProperty, value);
		}
	}

	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(FontIconSource), new FrameworkPropertyMetadata(true));


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

	public static DependencyProperty GlyphProperty { get; } = DependencyProperty.Register("Glyph", typeof(string), typeof(FontIconSource), new FrameworkPropertyMetadata(string.Empty));


	public FontWeight FontWeight
	{
		get
		{
			return (FontWeight)GetValue(FontWeightProperty);
		}
		set
		{
			SetValue(FontWeightProperty, value);
		}
	}

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(FontIconSource), new FrameworkPropertyMetadata(new FontWeight(400)));


	public FontStyle FontStyle
	{
		get
		{
			return (FontStyle)GetValue(FontStyleProperty);
		}
		set
		{
			SetValue(FontStyleProperty, value);
		}
	}

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIconSource), new FrameworkPropertyMetadata(FontStyle.Normal));


	public double FontSize
	{
		get
		{
			return (double)GetValue(FontSizeProperty);
		}
		set
		{
			SetValue(FontSizeProperty, value);
		}
	}

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(FontIconSource), new FrameworkPropertyMetadata(20.0));


	public FontFamily FontFamily
	{
		get
		{
			return (FontFamily)GetValue(FontFamilyProperty);
		}
		set
		{
			SetValue(FontFamilyProperty, value);
		}
	}

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(FontIconSource), new FrameworkPropertyMetadata(new FontFamily(FeatureConfiguration.Font.SymbolsFont)));


	public override IconElement CreateIconElement()
	{
		FontIcon fontIcon = new FontIcon
		{
			Glyph = Glyph,
			FontSize = FontSize,
			FontWeight = FontWeight,
			FontStyle = FontStyle,
			IsTextScaleFactorEnabled = IsTextScaleFactorEnabled,
			MirroredWhenRightToLeft = MirroredWhenRightToLeft
		};
		if (FontFamily != null)
		{
			fontIcon.FontFamily = FontFamily;
		}
		if (base.Foreground != null)
		{
			fontIcon.Foreground = base.Foreground;
		}
		return fontIcon;
	}
}
