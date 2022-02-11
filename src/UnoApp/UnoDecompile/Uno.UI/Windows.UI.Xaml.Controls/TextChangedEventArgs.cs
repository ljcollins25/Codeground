namespace Windows.UI.Xaml.Controls;

public sealed class TextChangedEventArgs : RoutedEventArgs
{
	internal TextChangedEventArgs(object originalSource)
		: base(originalSource)
	{
	}
}
