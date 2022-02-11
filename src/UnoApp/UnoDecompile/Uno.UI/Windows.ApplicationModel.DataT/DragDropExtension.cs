using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Uno;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Foundation.Interop;
using Uno.Foundation.Logging;
using Uno.Helpers.Serialization;
using Uno.Storage.Internal;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Windows.ApplicationModel.DataTransfer.DragDrop.Core;

internal class DragDropExtension : IDragDropExtension
{
	private class NativeDrop : IDragEventSource
	{
		private DragDropExtensionEventArgs _args;

		public long Id => _args.id;

		public uint FrameId => PointerRoutedEventArgs.ToFrameId(_args.timestamp);

		public NativeDrop(DragDropExtensionEventArgs args)
		{
			_args = args;
		}

		public (Point location, DragDropModifiers modifier) GetState()
		{
			Point item = new Point(_args.x, _args.y);
			DragDropModifiers dragDropModifiers = DragDropModifiers.None;
			WindowManagerInterop.HtmlPointerButtonsState buttons = (WindowManagerInterop.HtmlPointerButtonsState)_args.buttons;
			if (buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Left))
			{
				dragDropModifiers |= DragDropModifiers.LeftButton;
			}
			if (buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Middle))
			{
				dragDropModifiers |= DragDropModifiers.MiddleButton;
			}
			if (buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Right))
			{
				dragDropModifiers |= DragDropModifiers.RightButton;
			}
			if (_args.shift)
			{
				dragDropModifiers |= DragDropModifiers.Shift;
			}
			if (_args.ctrl)
			{
				dragDropModifiers |= DragDropModifiers.Control;
			}
			if (_args.alt)
			{
				dragDropModifiers |= DragDropModifiers.Alt;
			}
			return (item, dragDropModifiers);
		}

		public Point GetPosition(object? relativeTo)
		{
			return PointerRoutedEventArgs.ToRelativePosition(new Point(_args.x, _args.y), relativeTo as UIElement);
		}

		public void Update(DragDropExtensionEventArgs args)
		{
			if (_log.IsEnabled(LogLevel.Trace))
			{
				_log.Trace($"Updating native drop operation #{Id} ({args.eventName})");
			}
			_args = args;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct DragDropExtensionEventArgs
	{
		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string eventName;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string allowedOperations;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string acceptedOperation;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string dataItems;

		public double timestamp;

		public double x;

		public double y;

		public int id;

		public int buttons;

		public bool shift;

		public bool ctrl;

		public bool alt;

		public override string ToString()
		{
			return $"[{eventName}] {timestamp:F0} @({x:F2},{y:F2})" + $" | buttons: {(WindowManagerInterop.HtmlPointerButtonsState)buttons}" + " | modifiers: " + string.Join(", ", GetModifiers(this)) + $" | allowed: {allowedOperations} ({ToDataPackageOperation(allowedOperations)})" + " | accepted: " + acceptedOperation + " | entries: " + dataItems + " (" + (dataItems.HasValueTrimmed() ? string.Join(", ", JsonHelper.Deserialize<DataEntry[]>(dataItems)) : "") + ")";
			static IEnumerable<string> GetModifiers(DragDropExtensionEventArgs that)
			{
				if (that.shift)
				{
					yield return "shift";
				}
				if (that.ctrl)
				{
					yield return "ctrl";
				}
				if (that.alt)
				{
					yield return "alt";
				}
				if (!that.shift && !that.ctrl && !that.alt)
				{
					yield return "none";
				}
			}
		}
	}

	[DataContract]
	private struct DataEntry
	{
		[DataMember]
		public int id;

		[DataMember]
		public string kind;

		[DataMember]
		public string type;

		public override string ToString()
		{
			return $"[#{id}: {kind} {type}]";
		}
	}

	private const long _textReadTimeoutTicks = 100000000L;

	private const string _jsType = "Windows.ApplicationModel.DataTransfer.DragDrop.Core.DragDropExtension";

	private static readonly Logger _log = typeof(DragDropExtension).Log();

	private static DragDropExtension? _current;

	private readonly CoreDragDropManager _manager;

	private int _isInitialized;

	private TSInteropMarshaller.HandleRef<DragDropExtensionEventArgs>? _args;

	private NativeDrop? _pendingNativeDrop;

	public static DragDropExtension GetForCurrentView()
	{
		if (_current == null && Interlocked.CompareExchange(ref _current, new DragDropExtension(), null) == null)
		{
			_current!.Enable();
		}
		return _current;
	}

	private DragDropExtension()
	{
		_manager = CoreDragDropManager.GetForCurrentView() ?? throw new InvalidOperationException("No CoreDragDropManager available for current thread.");
	}

	private void Enable()
	{
		if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) == 0)
		{
			_args = TSInteropMarshaller.Allocate<DragDropExtensionEventArgs>("UnoStatic_Windows_ApplicationModel_DataTransfer_DragDrop_Core_DragDropExtension:enable", "UnoStatic_Windows_ApplicationModel_DataTransfer_DragDrop_Core_DragDropExtension:disable");
			return;
		}
		throw new InvalidOperationException("Multiple DragDropExtension is not supported yet.");
	}

	void IDragDropExtension.StartNativeDrag(CoreDragInfo info)
	{
	}

	[Preserve]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static string OnNativeDropEvent()
	{
		try
		{
			if (_log.IsEnabled(LogLevel.Trace))
			{
				_log.Trace("Receiving native drop event.");
			}
			TSInteropMarshaller.HandleRef<DragDropExtensionEventArgs> handleRef = _current?._args;
			if (handleRef != null)
			{
				handleRef.Value = _current!.OnNativeDropEvent(handleRef.Value);
				return "true";
			}
			if (_log.IsEnabled(LogLevel.Error))
			{
				_log.Error($"DragDropExtension not ready to process native drop event (current={_current} | args={_current?._args}).");
			}
			return "false";
		}
		catch (Exception arg)
		{
			if (_log.IsEnabled(LogLevel.Error))
			{
				_log.Error($"Failed to dispatch native drop event: {arg}");
			}
			return "false";
		}
	}

	private DragDropExtensionEventArgs OnNativeDropEvent(DragDropExtensionEventArgs args)
	{
		if (_log.IsEnabled(LogLevel.Trace))
		{
			_log.Trace($"Received native drop event: {args}");
		}
		DataPackageOperation? dataPackageOperation = DataPackageOperation.None;
		switch (args.eventName)
		{
		case "dragenter":
		{
			if (_pendingNativeDrop != null)
			{
				if (_pendingNativeDrop!.Id == args.id)
				{
					_log.Error($"The native drop operation (#{_pendingNativeDrop!.Id}) has already been started in managed code " + "and should have been ignored by native code. Ignoring that redundant dragenter.");
					dataPackageOperation = null;
					break;
				}
				_log.Error($"A native drop operation (#{_pendingNativeDrop!.Id}) is already pending. " + "Only one native drop operation is supported on wasm currently.Aborting previous operation and beginning a new one.");
				_manager.ProcessAborted(_pendingNativeDrop);
			}
			NativeDrop drop = new NativeDrop(args);
			DataPackageOperation allowedOperations = ToDataPackageOperation(args.allowedOperations);
			DataPackage dataPackage = CreateDataPackage(args.dataItems);
			CoreDragInfo coreDragInfo = new CoreDragInfo(drop, dataPackage.GetView(), allowedOperations);
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.Debug($"Starting new native drop operation {drop.Id}");
			}
			_pendingNativeDrop = drop;
			coreDragInfo.RegisterCompletedCallback(delegate(DataPackageOperation result)
			{
				if (_log.IsEnabled(LogLevel.Debug))
				{
					_log.Debug($"Completed native drop operation #{drop.Id}: {result}");
				}
				if (_pendingNativeDrop == drop)
				{
					_pendingNativeDrop = null;
				}
			});
			_manager.DragStarted(coreDragInfo);
			break;
		}
		case "dragover":
			if (_pendingNativeDrop != null)
			{
				_pendingNativeDrop!.Update(args);
				dataPackageOperation = _manager.ProcessMoved(_pendingNativeDrop);
			}
			break;
		case "dragleave":
			if (_pendingNativeDrop != null)
			{
				_pendingNativeDrop!.Update(args);
				dataPackageOperation = _manager.ProcessAborted(_pendingNativeDrop);
				_pendingNativeDrop = null;
			}
			break;
		case "drop":
			if (_pendingNativeDrop != null)
			{
				_pendingNativeDrop!.Update(args);
				dataPackageOperation = _manager.ProcessDropped(_pendingNativeDrop);
				_pendingNativeDrop = null;
			}
			break;
		}
		DragDropExtensionEventArgs result2 = default(DragDropExtensionEventArgs);
		result2.id = args.id;
		result2.eventName = "result";
		result2.acceptedOperation = (dataPackageOperation.HasValue ? ToNativeOperation(dataPackageOperation.Value) : args.acceptedOperation);
		result2.allowedOperations = "";
		result2.dataItems = "";
		return result2;
	}

	private DataPackage CreateDataPackage(string dataItems)
	{
		if (dataItems == null)
		{
			throw new ArgumentNullException("dataItems", "The dataItems is full-filled only for selected events!");
		}
		DataPackage dataPackage = new DataPackage();
		DataEntry[] source = JsonHelper.Deserialize<DataEntry[]>(dataItems);
		List<DataEntry> source2 = source.Where((DataEntry entry) => entry.kind.Equals("file", StringComparison.OrdinalIgnoreCase)).ToList();
		List<DataEntry> list = source.Where((DataEntry entry) => entry.kind.Equals("string", StringComparison.OrdinalIgnoreCase)).ToList();
		if (source2.Any())
		{
			int[] ids = source2.Select((DataEntry item) => item.id).ToArray();
			dataPackage.SetDataProvider(StandardDataFormats.StorageItems, async (CancellationToken ct) => await RetrieveFiles(ct, ids));
			DataEntry image = source2.FirstOrDefault((DataEntry file) => file.type.StartsWith("image/", StringComparison.OrdinalIgnoreCase));
			if (image.type != null)
			{
				dataPackage.SetDataProvider(StandardDataFormats.Bitmap, async (CancellationToken ct) => RandomAccessStreamReference.CreateFromFile((IStorageFile)(await RetrieveFiles(ct, image.id)).Single()));
			}
		}
		if (list.Any())
		{
			foreach (DataEntry item in list)
			{
				var (formatId, delayRenderer) = GetTextProvider(item.id, item.type);
				dataPackage.SetDataProvider(formatId, delayRenderer);
			}
			return dataPackage;
		}
		return dataPackage;
	}

	private static (string formatId, FuncAsync<object> provider) GetTextProvider(int id, string type)
	{
		return type switch
		{
			"text/uri-list" => (StandardDataFormats.WebLink, async (CancellationToken ct) => new Uri((from line in (await RetrieveText(ct, id)).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
				where !line.StartsWith("#")
				select line).First())), 
			"text/plain" => (StandardDataFormats.Text, async (CancellationToken ct) => await RetrieveText(ct, id)), 
			"text/html" => (StandardDataFormats.Html, async (CancellationToken ct) => await RetrieveText(ct, id)), 
			"text/rtf" => (StandardDataFormats.Rtf, async (CancellationToken ct) => await RetrieveText(ct, id)), 
			_ => (type, async (CancellationToken ct) => await RetrieveText(ct, id)), 
		};
	}

	private static async Task<IReadOnlyList<IStorageItem>> RetrieveFiles(CancellationToken ct, params int[] itemsIds)
	{
		string text = string.Join(", ", itemsIds.Select((int id) => id.ToStringInvariant()));
		NativeStorageItemInfo[] source = JsonHelper.Deserialize<NativeStorageItemInfo[]>(await WebAssemblyRuntime.InvokeAsync("Windows.ApplicationModel.DataTransfer.DragDrop.Core.DragDropExtension.retrieveFiles(" + text + ")", ct));
		return source.Select(new Func<NativeStorageItemInfo, StorageFile>(StorageFile.GetFromNativeInfo)).ToList();
	}

	private static async Task<string> RetrieveText(CancellationToken ct, int itemId)
	{
		using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(ct, new CancellationTokenSource(TimeSpan.FromTicks(100000000L)).Token);
		return await WebAssemblyRuntime.InvokeAsync("Windows.ApplicationModel.DataTransfer.DragDrop.Core.DragDropExtension.retrieveText(" + itemId.ToStringInvariant() + ")", cts.Token);
	}

	private static DataPackageOperation ToDataPackageOperation(string allowedOperations)
	{
		return allowedOperations?.ToLowerInvariant() switch
		{
			"none" => DataPackageOperation.None, 
			"copy" => DataPackageOperation.Copy, 
			"copyLink" => DataPackageOperation.Copy | DataPackageOperation.Link, 
			"copyMove" => DataPackageOperation.Copy | DataPackageOperation.Move, 
			"link" => DataPackageOperation.Link, 
			"linkMove" => DataPackageOperation.Move | DataPackageOperation.Link, 
			"move" => DataPackageOperation.Move, 
			"all" => DataPackageOperation.Copy | DataPackageOperation.Move | DataPackageOperation.Link, 
			"uninitialized" => DataPackageOperation.Copy | DataPackageOperation.Move | DataPackageOperation.Link, 
			null => DataPackageOperation.Copy | DataPackageOperation.Move | DataPackageOperation.Link, 
			_ => DataPackageOperation.None, 
		};
	}

	private static string ToNativeOperation(DataPackageOperation acceptedOperation)
	{
		if (acceptedOperation.HasFlag(DataPackageOperation.Link))
		{
			return "link";
		}
		if (acceptedOperation.HasFlag(DataPackageOperation.Copy))
		{
			return "copy";
		}
		if (acceptedOperation.HasFlag(DataPackageOperation.Move))
		{
			return "move";
		}
		return "none";
	}
}
