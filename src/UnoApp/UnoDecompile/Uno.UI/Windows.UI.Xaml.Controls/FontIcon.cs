using Uno;
using Uno.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class FontIcon : IconElement
{
	private readonly TextBlock _textBlock;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty MirroredWhenRightToLeftProperty { get; } = DependencyProperty.Register("MirroredWhenRightToLeft", typeof(bool), typeof(FontIcon), new FrameworkPropertyMetadata(false));


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

	public static DependencyProperty GlyphProperty { get; } = DependencyProperty.Register("Glyph", typeof(string), typeof(FontIcon), new FrameworkPropertyMetadata(string.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FontIcon)s).OnGlyphChanged((string)e.NewValue);
	}));


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

	public static DependencyProperty FontFamilyProperty { get; } = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(FontIcon), new FrameworkPropertyMetadata(new FontFamily(FeatureConfiguration.Font.SymbolsFont), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FontIcon)s).OnFontFamilyChanged((FontFamily)e.NewValue);
	}));


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

	public static DependencyProperty FontStyleProperty { get; } = DependencyProperty.Register("FontStyle", typeof(FontStyle), typeof(FontIcon), new FrameworkPropertyMetadata(FontStyle.Normal, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FontIcon)s).OnFontStyleChanged((FontStyle)e.NewValue);
	}));


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

	public static DependencyProperty FontSizeProperty { get; } = DependencyProperty.Register("FontSize", typeof(double), typeof(FontIcon), new FrameworkPropertyMetadata(20.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FontIcon)s).OnFontSizeChanged((double)e.NewValue);
	}));


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

	public static DependencyProperty FontWeightProperty { get; } = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(FontIcon), new FrameworkPropertyMetadata(new FontWeight(400), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((FontIcon)s).OnFontWeightChanged((FontWeight)e.NewValue);
	}));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTextScaleFactorEnabledProperty { get; } = DependencyProperty.Register("IsTextScaleFactorEnabled", typeof(bool), typeof(FontIcon), new FrameworkPropertyMetadata(true));


	public FontIcon()
	{
		_textBlock = new TextBlock();
		AddIconElementView(_textBlock);
		base.Loaded += FontIcon_Loaded;
	}

	private void FontIcon_Loaded(object sender, RoutedEventArgs e)
	{
		SynchronizeProperties();
	}

	private void SynchronizeProperties()
	{
		_textBlock.Text = Glyph;
		_textBlock.FontSize = FontSize;
		_textBlock.FontStyle = FontStyle;
		_textBlock.FontFamily = FontFamily;
		_textBlock.Foreground = base.Foreground;
		_textBlock.VerticalAlignment = VerticalAlignment.Center;
		_textBlock.HorizontalAlignment = HorizontalAlignment.Center;
		_textBlock.TextAlignment = TextAlignment.Center;
	}

	private void OnGlyphChanged(string newValue)
	{
		if (_textBlock != null)
		{
			_textBlock.Text = newValue;
		}
	}

	private void OnFontFamilyChanged(FontFamily newValue)
	{
		if (_textBlock != null)
		{
			_textBlock.FontFamily = newValue;
		}
	}

	private void OnFontStyleChanged(FontStyle newValue)
	{
		if (_textBlock != null)
		{
			_textBlock.FontStyle = newValue;
		}
	}

	private void OnFontSizeChanged(double newValue)
	{
		if (_textBlock != null)
		{
			_textBlock.FontSize = newValue;
		}
	}

	private void OnFontWeightChanged(FontWeight newValue)
	{
		if (_textBlock != null)
		{
			_textBlock.FontWeight = newValue;
		}
	}

	protected override void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
	{
		SolidColorBrush solidColorBrush = e.NewValue as SolidColorBrush;
		if (solidColorBrush != null && _textBlock != null)
		{
			_textBlock.Foreground = solidColorBrush;
		}
	}
}
