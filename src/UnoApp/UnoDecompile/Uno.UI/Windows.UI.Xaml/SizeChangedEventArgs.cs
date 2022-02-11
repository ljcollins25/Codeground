using Windows.Foundation;

namespace Windows.UI.Xaml;

public class SizeChangedEventArgs : RoutedEventArgs
{
	public Size NewSize { get; }

	public Size PreviousSize { get; }

	internal SizeChangedEventArgs(object originalSource, Size previousSize, Size newSize)
		: base(originalSource)
	{
		PreviousSize = previousSize;
		NewSize = newSize;
	}
}
