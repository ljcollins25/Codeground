namespace Windows.UI.Xaml.Controls;

public sealed class SymbolIcon : IconElement
{
	private FontIcon _icon;

	public Symbol Symbol
	{
		get
		{
			return (Symbol)GetValue(SymbolProperty);
		}
		set
		{
			SetValue(SymbolProperty, value);
		}
	}

	public static DependencyProperty SymbolProperty { get; } = DependencyProperty.Register("Symbol", typeof(Symbol), typeof(SymbolIcon), new FrameworkPropertyMetadata(Symbol.Emoji, OnSymbolChanged));


	public SymbolIcon()
		: this(Symbol.Emoji)
	{
	}

	public SymbolIcon(Symbol symbol)
	{
		_icon = new FontIcon();
		AddIconElementView(_icon);
		_icon.Glyph = new string((char)symbol, 1);
	}

	private static void OnSymbolChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is SymbolIcon symbolIcon)
		{
			symbolIcon._icon.Glyph = new string((char)symbolIcon.Symbol, 1);
		}
	}
}
