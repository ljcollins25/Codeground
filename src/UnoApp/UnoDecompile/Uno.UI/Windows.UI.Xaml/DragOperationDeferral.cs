using System.Threading;
using System.Threading.Tasks;

namespace Windows.UI.Xaml;

public class DragOperationDeferral
{
	private readonly TaskCompletionSource<object> _completion = new TaskCompletionSource<object>();

	internal DragOperationDeferral()
	{
	}

	public void Complete()
	{
		_completion.TrySetResult(new object());
	}

	internal async Task Completed(CancellationToken ct)
	{
		using (ct.Register(delegate
		{
			_completion.TrySetCanceled(ct);
		}))
		{
			await _completion.Task;
		}
	}
}
