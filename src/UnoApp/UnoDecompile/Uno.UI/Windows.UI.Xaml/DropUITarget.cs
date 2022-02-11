using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml;

internal class DropUITarget : ICoreDropOperationTarget
{
	private static GetHitTestability? _getDropHitTestability;

	private readonly Dictionary<UIElement, (DragUIOverride uiOverride, DataPackageOperation acceptedOperation)> _pendingDropTargets = new Dictionary<UIElement, (DragUIOverride, DataPackageOperation)>();

	private readonly Window _window;

	private static GetHitTestability GetDropHitTestability => delegate(UIElement elt)
	{
		HitTestability hitTestVisibility = elt.GetHitTestVisibility();
		if (hitTestVisibility == HitTestability.Collapsed)
		{
			return (HitTestability.Collapsed, _getDropHitTestability);
		}
		return elt.AllowDrop ? (hitTestVisibility, VisualTreeHelper.DefaultGetTestability) : (HitTestability.Invisible, _getDropHitTestability);
	};

	public DropUITarget(Window window)
	{
		_window = window;
	}

	public IAsyncOperation<DataPackageOperation> EnterAsync(CoreDragInfo dragInfo, CoreDragUIOverride dragUIOverride)
	{
		return EnterOrOverAsync(dragInfo, dragUIOverride);
	}

	public IAsyncOperation<DataPackageOperation> OverAsync(CoreDragInfo dragInfo, CoreDragUIOverride dragUIOverride)
	{
		return EnterOrOverAsync(dragInfo, dragUIOverride);
	}

	private IAsyncOperation<DataPackageOperation> EnterOrOverAsync(CoreDragInfo dragInfo, CoreDragUIOverride dragUIOverride)
	{
		CoreDragInfo dragInfo2 = dragInfo;
		CoreDragUIOverride dragUIOverride2 = dragUIOverride;
		return AsyncOperation.FromTask(async delegate(CancellationToken ct)
		{
			(UIElement, DragEventArgs)? tuple = await UpdateTarget(dragInfo2, dragUIOverride2, ct);
			if (!tuple.HasValue)
			{
				return DataPackageOperation.None;
			}
			var (uIElement, args) = tuple.Value;
			uIElement.RaiseDragEnterOrOver(args);
			DragOperationDeferral deferral = args.Deferral;
			if (deferral != null)
			{
				await deferral.Completed(ct);
			}
			UpdateState(args);
			return args.AcceptedOperation;
		});
	}

	public IAsyncAction LeaveAsync(CoreDragInfo dragInfo)
	{
		CoreDragInfo dragInfo2 = dragInfo;
		return AsyncAction.FromTask(async delegate(CancellationToken ct)
		{
			IEnumerable<Task> tasks = _pendingDropTargets.ToArray().Select(new Func<KeyValuePair<UIElement, (DragUIOverride, DataPackageOperation)>, Task>(RaiseLeave));
			_pendingDropTargets.Clear();
			Task.WhenAll(tasks);
			async Task RaiseLeave(KeyValuePair<UIElement, (DragUIOverride uiOverride, DataPackageOperation acceptedOperation)> target)
			{
				DragEventArgs dragEventArgs = new DragEventArgs(target.Key, dragInfo2, target.Value.uiOverride);
				target.Key.RaiseDragLeave(dragEventArgs);
				DragOperationDeferral deferral = dragEventArgs.Deferral;
				if (deferral != null)
				{
					await deferral.Completed(ct);
				}
			}
		});
	}

	public IAsyncOperation<DataPackageOperation> DropAsync(CoreDragInfo dragInfo)
	{
		CoreDragInfo dragInfo2 = dragInfo;
		return AsyncOperation.FromTask(async delegate(CancellationToken ct)
		{
			(UIElement, DragEventArgs)? tuple = await UpdateTarget(dragInfo2, null, ct);
			if (!tuple.HasValue)
			{
				return DataPackageOperation.None;
			}
			var (uIElement, args) = tuple.Value;
			uIElement.RaiseDrop(args);
			DragOperationDeferral deferral = args.Deferral;
			if (deferral != null)
			{
				await deferral.Completed(ct);
			}
			return args.AcceptedOperation;
		});
	}

	private async Task<(UIElement element, DragEventArgs args)?> UpdateTarget(CoreDragInfo dragInfo, CoreDragUIOverride? dragUIOverride, CancellationToken ct)
	{
		CoreDragInfo dragInfo2 = dragInfo;
		(UIElement? element, VisualTreeHelper.Branch? stale) target = VisualTreeHelper.HitTest(dragInfo2.Position, GetDropHitTestability, (UIElement elt) => elt.IsDragOver(dragInfo2.SourceId));
		VisualTreeHelper.Branch? item = target.stale;
		if (item.HasValue)
		{
			VisualTreeHelper.Branch staleBranch = item.GetValueOrDefault();
			(DragUIOverride, DataPackageOperation) value2;
			(bool, UIElement, (DragUIOverride, DataPackageOperation)) tuple = (from elt in staleBranch.EnumerateLeafToRoot()
				select (_pendingDropTargets.TryGetValue(staleBranch.Leaf, out value2), elt, value2)).FirstOrDefault<(bool, UIElement, (DragUIOverride, DataPackageOperation))>(((bool isDragOver, UIElement elt, (DragUIOverride uiOverride, DataPackageOperation acceptedOperation) dragState) t) => t.isDragOver);
			DragEventArgs dragEventArgs = ((tuple.Item2 == null) ? new DragEventArgs(staleBranch.Leaf, dragInfo2, new DragUIOverride(new CoreDragUIOverride())) : new DragEventArgs(tuple.Item2, dragInfo2, tuple.Item3.Item1));
			staleBranch.Leaf.RaiseDragLeave(dragEventArgs, staleBranch.Root);
			DragOperationDeferral deferral = dragEventArgs.Deferral;
			if (deferral != null)
			{
				await deferral.Completed(ct);
			}
		}
		if (target.element == null)
		{
			return null;
		}
		(DragUIOverride, DataPackageOperation) value;
		return new(UIElement, DragEventArgs)?(new ValueTuple<UIElement, DragEventArgs>(item2: (target.element == null || !_pendingDropTargets.TryGetValue(target.element, out value)) ? new DragEventArgs(target.element, dragInfo2, new DragUIOverride(dragUIOverride ?? new CoreDragUIOverride())) : new DragEventArgs(target.element, dragInfo2, value.Item1)
		{
			AcceptedOperation = value.Item2
		}, item1: target.element));
	}

	private void UpdateState(DragEventArgs args)
	{
		_pendingDropTargets[(UIElement)args.OriginalSource] = (args.DragUIOverride, args.AcceptedOperation);
	}
}
