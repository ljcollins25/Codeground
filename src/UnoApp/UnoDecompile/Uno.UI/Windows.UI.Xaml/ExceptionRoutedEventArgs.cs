namespace Windows.UI.Xaml;

public class ExceptionRoutedEventArgs : RoutedEventArgs
{
	public string ErrorMessage { get; }

	internal ExceptionRoutedEventArgs(object originalSource, string errorMessage)
		: base(originalSource)
	{
		ErrorMessage = errorMessage;
	}
}
