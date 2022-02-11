using System;
using Uno.Helpers;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public class ContentDialogClosingEventArgs
{
	private DeferralManager<ContentDialogClosingDeferral> _deferralManager;

	private readonly Action<ContentDialogClosingEventArgs> _complete;

	internal bool IsDeferred => _deferralManager != null;

	public bool Cancel { get; set; }

	public ContentDialogResult Result { get; }

	internal ContentDialogClosingEventArgs(Action<ContentDialogClosingEventArgs> complete, ContentDialogResult result)
	{
		_complete = complete;
		Result = result;
	}

	public ContentDialogClosingDeferral GetDeferral()
	{
		if (_deferralManager == null)
		{
			_deferralManager = new DeferralManager<ContentDialogClosingDeferral>((DeferralCompletedHandler h) => new ContentDialogClosingDeferral(h));
			_deferralManager.Completed += delegate
			{
				_complete(this);
			};
		}
		return _deferralManager.GetDeferral();
	}

	internal void EventRaiseCompleted()
	{
		_deferralManager?.EventRaiseCompleted();
	}
}
