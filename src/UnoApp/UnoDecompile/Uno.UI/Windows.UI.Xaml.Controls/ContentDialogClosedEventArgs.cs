namespace Windows.UI.Xaml.Controls;

public class ContentDialogClosedEventArgs
{
	public ContentDialogResult Result { get; }

	internal ContentDialogClosedEventArgs(ContentDialogResult result)
	{
		Result = result;
	}
}
