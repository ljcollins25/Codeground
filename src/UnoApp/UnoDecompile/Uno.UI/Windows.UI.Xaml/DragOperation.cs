using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;

namespace Windows.UI.Xaml;

internal class DragOperation
{
	private enum State
	{
		None,
		Over,
		Completing,
		Completed
	}

	private struct TargetAsyncTask
	{
		private readonly Func<CancellationToken, Task> _action;

		public bool IsIgnorable { get; }

		public TargetAsyncTask(Func<CancellationToken, Task> action, bool isIgnorable)
		{
			IsIgnorable = isIgnorable;
			_action = action;
		}

		public Task Invoke(CancellationToken ct)
		{
			return _action(ct);
		}
	}

	private static readonly TimeSpan _deferralTimeout = TimeSpan.FromSeconds(30.0);

	private readonly IDragDropExtension? _extension;

	private readonly ICoreDropOperationTarget _target;

	private readonly DragView _view;

	private readonly IDisposable _viewHandle;

	private readonly CoreDragUIOverride _viewOverride;

	private readonly LinkedList<TargetAsyncTask> _queue = new LinkedList<TargetAsyncTask>();

	private bool _isRunning;

	private bool _isOverWindow;

	private State _state;

	private uint _lastFrameId;

	private bool _hasRequestedNativeDrag;

	private DataPackageOperation _acceptedOperation;

	public CoreDragInfo Info { get; }

	public DragOperation(Window window, IDragDropExtension? extension, CoreDragInfo info, ICoreDropOperationTarget? target = null)
	{
		_extension = extension;
		Info = info;
		_target = target ?? new DropUITarget(window);
		_view = new DragView(info.DragUI as DragUI);
		_viewHandle = window.OpenDragAndDrop(_view);
		_viewOverride = new CoreDragUIOverride();
	}

	internal DataPackageOperation Moved(IDragEventSource src)
	{
		if (_state >= State.Completing || src.FrameId <= _lastFrameId)
		{
			return _acceptedOperation;
		}
		bool isOverWindow = _isOverWindow;
		_isOverWindow = Window.Current.Bounds.Contains(src.GetPosition(null));
		Update(src);
		if (isOverWindow && !_isOverWindow)
		{
			Enqueue(new Func<CancellationToken, Task>(RaiseRecoverableLeave));
		}
		else
		{
			Enqueue(new Func<CancellationToken, Task>(RaiseEnterOrOver), _state == State.Over);
		}
		return _acceptedOperation;
	}

	internal DataPackageOperation Aborted(IDragEventSource src)
	{
		if (_state >= State.Completing)
		{
			return _acceptedOperation;
		}
		Update(src);
		Enqueue(new Func<CancellationToken, Task>(RaiseFinalLeave));
		return _acceptedOperation;
	}

	internal DataPackageOperation Dropped(IDragEventSource src)
	{
		if (_state >= State.Completing)
		{
			return _acceptedOperation;
		}
		Update(src);
		Enqueue(new Func<CancellationToken, Task>(RaiseDrop));
		return _acceptedOperation;
	}

	internal void Abort()
	{
		if (_state == State.None)
		{
			Complete(DataPackageOperation.None);
		}
		else
		{
			Enqueue(new Func<CancellationToken, Task>(RaiseFinalLeave));
		}
	}

	private async Task RaiseEnterOrOver(CancellationToken ct)
	{
		if (_state < State.Completing)
		{
			bool flag = _state == State.Over;
			_state = State.Over;
			DataPackageOperation dataPackageOperation = ((!flag) ? (await _target.EnterAsync(Info, _viewOverride).AsTask(ct)) : (await _target.OverAsync(Info, _viewOverride).AsTask(ct)));
			DataPackageOperation dataPackageOperation2 = dataPackageOperation;
			dataPackageOperation2 = (_acceptedOperation = dataPackageOperation2 & Info.AllowedOperations);
			_view.Update(dataPackageOperation2, _viewOverride);
		}
	}

	private async Task RaiseRecoverableLeave(CancellationToken ct)
	{
		if (_state == State.Over)
		{
			_state = State.None;
			_acceptedOperation = DataPackageOperation.None;
			_viewOverride.Clear();
			await _target.LeaveAsync(Info).AsTask(ct);
			_view.Hide();
			if (!_hasRequestedNativeDrag)
			{
				_extension?.StartNativeDrag(Info);
				_hasRequestedNativeDrag = true;
			}
		}
	}

	private async Task RaiseFinalLeave(CancellationToken ct)
	{
		try
		{
			if (_state == State.Over)
			{
				_state = State.Completing;
				_acceptedOperation = DataPackageOperation.None;
				await _target.LeaveAsync(Info).AsTask(ct);
			}
		}
		finally
		{
			Complete(DataPackageOperation.None);
		}
	}

	private async Task RaiseDrop(CancellationToken ct)
	{
		DataPackageOperation result = DataPackageOperation.None;
		try
		{
			if (_state == State.Over)
			{
				_state = State.Completing;
				result = await _target.DropAsync(Info).AsTask(ct);
				result = (_acceptedOperation = result & Info.AllowedOperations);
			}
		}
		finally
		{
			Complete(result);
		}
	}

	private void Update(IDragEventSource src)
	{
		Info.UpdateSource(src);
		_view.SetLocation(Info.Position);
		_lastFrameId = src.FrameId;
	}

	private void Enqueue(Func<CancellationToken, Task> action, bool isIgnorable = false)
	{
		LinkedListNode<TargetAsyncTask>? last = _queue.Last;
		if (last != null && last!.Value.IsIgnorable)
		{
			_queue.RemoveLast();
		}
		_queue.AddLast(new TargetAsyncTask(action, isIgnorable));
		Run();
	}

	private async void Run()
	{
		if (_isRunning || _state == State.Completed)
		{
			return;
		}
		try
		{
			_isRunning = true;
			while (_state != State.Completed)
			{
				LinkedListNode<TargetAsyncTask> first = _queue.First;
				if (first == null)
				{
					break;
				}
				_queue.RemoveFirst();
				try
				{
					using CancellationTokenSource ct = new CancellationTokenSource(_deferralTimeout);
					await first.Value.Invoke(ct.Token);
					ct.Cancel();
				}
				catch (OperationCanceledException)
				{
					Application.Current.RaiseRecoverableUnhandledException(new Exception("A Drag async took too long and has been cancelled"));
				}
				catch (Exception innerException)
				{
					Application.Current.RaiseRecoverableUnhandledException(new Exception("Drag async callback failed", innerException));
				}
			}
		}
		catch (Exception innerException2)
		{
			Application.Current.RaiseRecoverableUnhandledException(new Exception("Drag event dispatch process failed", innerException2));
		}
		finally
		{
			_isRunning = false;
		}
	}

	private void Complete(DataPackageOperation result)
	{
		if (_state != State.Completed)
		{
			_state = State.Completed;
			_viewHandle.Dispose();
			Info.Complete(result);
		}
	}
}
