namespace Microsoft.UI.Xaml.Controls;

public class InfoBarClosedEventArgs
{
	public InfoBarCloseReason Reason { get; }

	internal InfoBarClosedEventArgs(InfoBarCloseReason reason)
	{
		Reason = reason;
	}
}
