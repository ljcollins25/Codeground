using Uno.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

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

	public static DependencyProperty MirroredWhenRightToLeftProperty { get; } = DependencyProperty.Register("MirroredWhenRightToLeft", typeof(bool), typeof(FontIconSource), new FrameworkPropertyMetadata(false, IconSource.OnPropertyChanged));


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

	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(FontIconSource), new FrameworkPropertyMetadata(true, IconSource.OnPropertyChanged));


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

	public static DependencyProperty GlyphProperty { get; } = DependencyProperty.Register("Glyph", typeof(string), typeof(FontIconSource), new FrameworkPropertyMetadata(string.Empty, IconSource.OnPropertyChanged));


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

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(FontIconSource), new FrameworkPropertyMetadata(new FontWeight(400), IconSource.OnPropertyChanged));


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

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIconSource), new FrameworkPropertyMetadata(FontStyle.Normal, IconSource.OnPropertyChanged));


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

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(FontIconSource), new FrameworkPropertyMetadata(20.0, IconSource.OnPropertyChanged));


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

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(FontIconSource), new FrameworkPropertyMetadata(new FontFamily(FeatureConfiguration.Font.SymbolsFont), IconSource.OnPropertyChanged));


	private protected override IconElement CreateIconElementCore()
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

	private protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty sourceProperty)
	{
		if (sourceProperty == FontFamilyProperty)
		{
			return FontIcon.FontFamilyProperty;
		}
		if (sourceProperty == FontSizeProperty)
		{
			return FontIcon.FontSizeProperty;
		}
		if (sourceProperty == FontStyleProperty)
		{
			return FontIcon.FontStyleProperty;
		}
		if (sourceProperty == FontWeightProperty)
		{
			return FontIcon.FontWeightProperty;
		}
		if (sourceProperty == GlyphProperty)
		{
			return FontIcon.GlyphProperty;
		}
		if (sourceProperty == IsTextScaleFactorEnabledProperty)
		{
			return FontIcon.IsTextScaleFactorEnabledProperty;
		}
		if (sourceProperty == MirroredWhenRightToLeftProperty)
		{
			return FontIcon.MirroredWhenRightToLeftProperty;
		}
		return base.GetIconElementPropertyCore(sourceProperty);
	}
}
