using System;

namespace Windows.UI.Xaml.Controls;

public class ContentDialogButtonClickEventArgs
{
	private readonly Action<ContentDialogButtonClickEventArgs> _deferralAction;

	public bool Cancel { get; set; }

	internal ContentDialogButtonClickDeferral Deferral { get; private set; }

	internal ContentDialogButtonClickEventArgs(Action<ContentDialogButtonClickEventArgs> deferralAction)
	{
		_deferralAction = deferralAction;
	}

	public ContentDialogButtonClickDeferral GetDeferral()
	{
		return Deferral = new ContentDialogButtonClickDeferral(delegate
		{
			_deferralAction(this);
		});
	}
}
