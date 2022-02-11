using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class PickerFlyoutAsyncOperation<TResult> : IAsyncOperationInternal<TResult>, IAsyncOperation<TResult>, IAsyncInfo
{
	private readonly TaskCompletionSource<TResult> _tcs;

	private readonly IAsyncOperation<TResult> _asyncOperation;

	private FlyoutBase m_spPendingFlyout;

	public Exception ErrorCode => _asyncOperation.ErrorCode;

	public uint Id => _asyncOperation.Id;

	public AsyncStatus Status => _asyncOperation.Status;

	public AsyncOperationCompletedHandler<TResult> Completed { get; set; }

	public Task<TResult> Task => _tcs.Task;

	public PickerFlyoutAsyncOperation()
	{
		_tcs = new TaskCompletionSource<TResult>();
		_asyncOperation = _tcs.Task.AsAsyncOperation();
	}

	public void Cancel()
	{
		_tcs.TrySetCanceled();
		if (m_spPendingFlyout != null)
		{
			m_spPendingFlyout.Hide();
		}
	}

	public void Close()
	{
		throw new NotImplementedException();
	}

	public TResult GetResults()
	{
		return _tcs.Task.Result;
	}

	public void StartOperation(FlyoutBase pAssociatedFlyout)
	{
		m_spPendingFlyout = pAssociatedFlyout;
	}

	public void CompleteOperation(TResult result)
	{
		m_spPendingFlyout = null;
		_tcs.TrySetResult(result);
	}
}
