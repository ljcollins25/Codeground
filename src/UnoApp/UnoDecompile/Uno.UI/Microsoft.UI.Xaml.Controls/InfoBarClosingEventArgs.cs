namespace Microsoft.UI.Xaml.Controls;

public class InfoBarClosingEventArgs
{
	public InfoBarCloseReason Reason { get; }

	public bool Cancel { get; set; }

	internal InfoBarClosingEventArgs(InfoBarCloseReason reason)
	{
		Reason = reason;
	}
}
