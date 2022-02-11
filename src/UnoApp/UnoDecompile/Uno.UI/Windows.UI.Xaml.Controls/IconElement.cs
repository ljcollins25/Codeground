using System;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class IconElement : FrameworkElement
{
	private Brush _foregroundStrongref;

	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			SetValue(ForegroundProperty, value);
			_foregroundStrongref = value;
		}
	}

	public static DependencyProperty ForegroundProperty { get; } = DependencyProperty.Register("Foreground", typeof(Brush), typeof(IconElement), new FrameworkPropertyMetadata(SolidColorBrushHelper.White, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((IconElement)s).OnForegroundChanged(e);
	}));


	private void UnregisterSubView()
	{
		ClearChildren();
	}

	private void RegisterSubView(UIElement child)
	{
		AddChild(child);
	}

	protected virtual void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	internal void AddIconElementView(UIElement child)
	{
		RegisterSubView(child);
	}

	public static implicit operator IconElement(string symbol)
	{
		SymbolIcon symbolIcon = new SymbolIcon();
		symbolIcon.Symbol = (Symbol)Enum.Parse(typeof(Symbol), symbol, ignoreCase: true);
		return symbolIcon;
	}

	internal override bool CanHaveChildren()
	{
		return true;
	}
}
