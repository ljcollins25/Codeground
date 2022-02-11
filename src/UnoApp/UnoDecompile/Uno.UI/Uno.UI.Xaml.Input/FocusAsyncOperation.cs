using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class FocusAsyncOperation
{
	private FocusMovementResult? _focusMovementResult;

	private TaskCompletionSource<FocusMovementResult> _completionSource = new TaskCompletionSource<FocusMovementResult>();

	public Guid CorrelationId { get; set; }

	public FocusAsyncOperation(Guid correlationId)
	{
		CorrelationId = correlationId;
	}

	public IAsyncOperation<FocusMovementResult> CreateAsyncOperation()
	{
		return AsyncOperation.FromTask(delegate(CancellationToken ct)
		{
			ct.Register(delegate
			{
				_completionSource.TrySetCanceled(ct);
			});
			return _completionSource.Task;
		});
	}

	internal void CoreSetResults(FocusMovementResult coreFocusMovementResult)
	{
		if (_focusMovementResult == null)
		{
			_focusMovementResult = new FocusMovementResult();
		}
		bool succeeded = coreFocusMovementResult.WasMoved && !coreFocusMovementResult.WasCanceled;
		_focusMovementResult!.Succeeded = succeeded;
	}

	internal void CoreFireCompletion()
	{
		_completionSource.SetResult(_focusMovementResult ?? new FocusMovementResult());
	}
}
