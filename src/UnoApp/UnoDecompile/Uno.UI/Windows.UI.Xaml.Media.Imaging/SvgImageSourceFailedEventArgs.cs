namespace Windows.UI.Xaml.Media.Imaging;

public class SvgImageSourceFailedEventArgs
{
	public SvgImageSourceLoadStatus Status { get; }

	internal SvgImageSourceFailedEventArgs(SvgImageSourceLoadStatus status)
	{
		Status = status;
	}
}
