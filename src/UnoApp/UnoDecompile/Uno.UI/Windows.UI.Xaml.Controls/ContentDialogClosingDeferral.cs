using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public class ContentDialogClosingDeferral
{
	private readonly DeferralCompletedHandler _handler;

	internal ContentDialogClosingDeferral(DeferralCompletedHandler handler)
	{
		_handler = handler;
	}

	public void Complete()
	{
		_handler?.Invoke();
	}
}
