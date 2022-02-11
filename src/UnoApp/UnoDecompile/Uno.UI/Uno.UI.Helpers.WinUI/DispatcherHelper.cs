using System;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers.WinUI;

internal class DispatcherHelper
{
	private DispatcherQueue dispatcherQueue;

	private CoreDispatcher coreDispatcher;

	public DispatcherHelper(DependencyObject dependencyObject = null)
	{
		if (SharedHelpers.IsDispatcherQueueAvailable())
		{
			dispatcherQueue = DispatcherQueue.GetForCurrentThread();
		}
		if (dispatcherQueue != null)
		{
			return;
		}
		try
		{
			if (dependencyObject != null)
			{
				coreDispatcher = dependencyObject.Dispatcher;
				return;
			}
			CoreApplicationView currentView = CoreApplication.GetCurrentView();
			if (currentView != null)
			{
				coreDispatcher = currentView.Dispatcher;
			}
		}
		catch (Exception)
		{
		}
	}

	public void RunAsync(Action func, bool fallbackToThisThread = false)
	{
		if (coreDispatcher != null)
		{
			IAsyncOperation<bool> asyncOperation = coreDispatcher.TryRunAsync(CoreDispatcherPriority.Normal, delegate
			{
				func();
			});
			asyncOperation.Completed = delegate(IAsyncOperation<bool> asyncInfo, AsyncStatus asyncStatus)
			{
				bool flag = false;
				if (asyncStatus == AsyncStatus.Completed && !asyncInfo.GetResults() && fallbackToThisThread)
				{
					flag = true;
				}
				if (flag)
				{
					func();
				}
			};
		}
		else if (fallbackToThisThread)
		{
			func();
		}
	}
}
