using System;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class FlyoutAsyncOperationManager<TResult>
{
	private enum FlyoutState
	{
		Closed,
		Open,
		Closing
	}

	private Func<TResult> m_cancellationValueCallback;

	private FlyoutBase m_pAssociatedFlyoutNoRef;

	private FrameworkElement m_tpTargetForDeferredShowAt;

	private PickerFlyoutAsyncOperation<TResult> m_spCurrentOperation;

	private bool m_isInitialized;

	private bool m_isShowAtForCurrentOperationDeferred;

	private FlyoutState m_flyoutState;

	private DispatcherQueue m_spDispatcherQueue;

	public FlyoutAsyncOperationManager(FlyoutBase pAssociatedFlyout, Func<TResult> cancellationValueCallback)
	{
		Initialize(pAssociatedFlyout, cancellationValueCallback);
	}

	private void Initialize(FlyoutBase pAssociatedFlyout, Func<TResult> cancellationValueCallback)
	{
		if (m_isInitialized)
		{
			throw new InvalidOperationException("Already initialized");
		}
		m_pAssociatedFlyoutNoRef = pAssociatedFlyout;
		m_cancellationValueCallback = cancellationValueCallback;
		pAssociatedFlyout.Opening += OnOpening;
		pAssociatedFlyout.Closed += OnClosed;
		m_spDispatcherQueue = DispatcherQueue.GetForCurrentThread();
		m_isInitialized = true;
	}

	public IAsyncOperation<TResult> Start(FrameworkElement pTarget)
	{
		if (m_spCurrentOperation != null)
		{
			throw new InvalidOperationException("Async operation in progress.");
		}
		PickerFlyoutAsyncOperation<TResult> pickerFlyoutAsyncOperation = new PickerFlyoutAsyncOperation<TResult>();
		pickerFlyoutAsyncOperation.StartOperation(m_pAssociatedFlyoutNoRef);
		if (m_flyoutState == FlyoutState.Closed)
		{
			BeginAttemptStartDeferredOperation();
		}
		m_spCurrentOperation = pickerFlyoutAsyncOperation;
		AssertInvariants();
		return pickerFlyoutAsyncOperation;
	}

	public void Complete(TResult result)
	{
		if (m_flyoutState == FlyoutState.Open)
		{
			m_flyoutState = FlyoutState.Closing;
		}
		if (m_spCurrentOperation != null)
		{
			AsyncStatus status = m_spCurrentOperation.Status;
			if (!m_isShowAtForCurrentOperationDeferred || status == AsyncStatus.Canceled)
			{
				AssertCompleteOperationPreconditions();
				m_isShowAtForCurrentOperationDeferred = false;
				m_tpTargetForDeferredShowAt = null;
				m_spCurrentOperation.CompleteOperation(result);
				m_spCurrentOperation = null;
			}
		}
		AssertInvariants();
	}

	private void OnOpening(object sender, object eventArgs)
	{
		m_flyoutState = FlyoutState.Open;
	}

	private void OnClosed(object sender, object eventArgs)
	{
		AssertInvariants();
		AsyncStatus asyncStatus = AsyncStatus.Canceled;
		m_flyoutState = FlyoutState.Closing;
		while (m_spCurrentOperation != null && asyncStatus == AsyncStatus.Canceled)
		{
			asyncStatus = m_spCurrentOperation.Status;
			if (!m_isShowAtForCurrentOperationDeferred || asyncStatus == AsyncStatus.Canceled)
			{
				Complete(m_cancellationValueCallback());
			}
			if (m_isShowAtForCurrentOperationDeferred)
			{
				asyncStatus = m_spCurrentOperation.Status;
				if (asyncStatus != AsyncStatus.Canceled)
				{
					BeginAttemptStartDeferredOperation();
				}
			}
		}
		if (m_flyoutState == FlyoutState.Closing)
		{
			m_flyoutState = FlyoutState.Closed;
		}
	}

	private void BeginAttemptStartDeferredOperation()
	{
		m_spDispatcherQueue.TryEnqueue(AttemptStartDeferredOperation);
	}

	private void AttemptStartDeferredOperation()
	{
		AssertInvariants();
		if (m_flyoutState == FlyoutState.Closed)
		{
			AsyncStatus status = m_spCurrentOperation.Status;
			if (status == AsyncStatus.Canceled)
			{
				Complete(m_cancellationValueCallback());
			}
			else
			{
				m_pAssociatedFlyoutNoRef.ShowAt(m_tpTargetForDeferredShowAt);
				m_isShowAtForCurrentOperationDeferred = false;
				m_tpTargetForDeferredShowAt = null;
			}
		}
		AssertInvariants();
	}

	private void AssertInvariants()
	{
	}

	private void AssertCompleteOperationPreconditions()
	{
		AsyncStatus status = m_spCurrentOperation.Status;
	}
}
