using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

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

	public static DependencyProperty SymbolProperty { get; } = DependencyProperty.Register("Symbol", typeof(Symbol), typeof(SymbolIconSource), new FrameworkPropertyMetadata(Symbol.Emoji, IconSource.OnPropertyChanged));


	private protected override IconElement CreateIconElementCore()
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

	private protected override DependencyProperty GetIconElementPropertyCore(DependencyProperty sourceProperty)
	{
		if (sourceProperty == SymbolProperty)
		{
			return SymbolIcon.SymbolProperty;
		}
		return base.GetIconElementPropertyCore(sourceProperty);
	}
}
