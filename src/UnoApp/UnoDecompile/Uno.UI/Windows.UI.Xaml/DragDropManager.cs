using System.Collections.Generic;
using System.Linq;
using Uno.Foundation.Extensibility;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml;

internal sealed class DragDropManager : CoreDragDropManager.IDragDropManager
{
	private readonly Window _window;

	private readonly List<DragOperation> _dragOperations = new List<DragOperation>();

	private readonly IDragDropExtension? _hostExtension;

	private bool _areWindowEventsRegistered;

	public bool AreConcurrentOperationsEnabled { get; set; }

	public DragDropManager(Window window)
	{
		_window = window;
		if (ApiExtensibility.CreateInstance<IDragDropExtension>(this, out var instance))
		{
			_hostExtension = instance;
		}
	}

	public void BeginDragAndDrop(CoreDragInfo info, ICoreDropOperationTarget? target = null)
	{
		CoreDragInfo info2 = info;
		ICoreDropOperationTarget target2 = target;
		if (_window.Dispatcher.IsThreadingSupported && !_window.Dispatcher.HasThreadAccess)
		{
			_window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
			{
				BeginDragAndDrop(info2, target2);
			});
			return;
		}
		if (!AreConcurrentOperationsEnabled)
		{
			DragOperation[] array = _dragOperations.ToArray();
			foreach (DragOperation dragOperation in array)
			{
				dragOperation.Abort();
			}
		}
		RegisterWindowHandlers();
		DragOperation op = new DragOperation(_window, _hostExtension, info2, target2);
		_dragOperations.Add(op);
		info2.RegisterCompletedCallback(delegate
		{
			_dragOperations.Remove(op);
		});
	}

	public DataPackageOperation ProcessMoved(IDragEventSource src)
	{
		return FindOperation(src)?.Moved(src) ?? DataPackageOperation.None;
	}

	public DataPackageOperation ProcessDropped(IDragEventSource src)
	{
		return FindOperation(src)?.Dropped(src) ?? DataPackageOperation.None;
	}

	public DataPackageOperation ProcessAborted(IDragEventSource src)
	{
		return FindOperation(src)?.Aborted(src) ?? DataPackageOperation.None;
	}

	private DragOperation? FindOperation(IDragEventSource src)
	{
		IDragEventSource src2 = src;
		return _dragOperations.FirstOrDefault((DragOperation drag) => drag.Info.SourceId == src2.Id);
	}

	private void RegisterWindowHandlers()
	{
		if (!_areWindowEventsRegistered)
		{
			UIElement rootElement = _window.RootElement;
			rootElement.AddHandler(UIElement.PointerEnteredEvent, new PointerEventHandler(OnPointerMoved), handledEventsToo: true);
			rootElement.AddHandler(UIElement.PointerExitedEvent, new PointerEventHandler(OnPointerMoved), handledEventsToo: true);
			rootElement.AddHandler(UIElement.PointerMovedEvent, new PointerEventHandler(OnPointerMoved), handledEventsToo: true);
			rootElement.AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(OnPointerReleased), handledEventsToo: true);
			rootElement.AddHandler(UIElement.PointerCanceledEvent, new PointerEventHandler(OnPointerCanceled), handledEventsToo: true);
			_areWindowEventsRegistered = true;
		}
	}

	private static void OnPointerMoved(object snd, PointerRoutedEventArgs e)
	{
		Window.Current.DragDrop.ProcessMoved(e);
	}

	private static void OnPointerReleased(object snd, PointerRoutedEventArgs e)
	{
		Window.Current.DragDrop.ProcessDropped(e);
	}

	private static void OnPointerCanceled(object snd, PointerRoutedEventArgs e)
	{
		Window.Current.DragDrop.ProcessAborted(e);
	}
}
