namespace Windows.UI.Xaml.Controls;

public class SymbolIconSource : IconSource
{
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

	public static DependencyProperty SymbolProperty { get; } = DependencyProperty.Register("Symbol", typeof(Symbol), typeof(SymbolIconSource), new FrameworkPropertyMetadata(Symbol.Emoji));


	public override IconElement CreateIconElement()
	{
		SymbolIcon symbolIcon = new SymbolIcon
		{
			Symbol = Symbol
		};
		if (base.Foreground != null)
		{
			symbolIcon.Foreground = base.Foreground;
		}
		return symbolIcon;
	}
}
