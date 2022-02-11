using Uno.UI.Xaml.Input;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;

namespace Windows.UI.Xaml;

public class DragEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs
{
	private readonly CoreDragInfo _info;

	public bool Handled { get; set; }

	public DataPackage Data { get; set; } = new DataPackage();


	public DataPackageView DataView => _info.Data;

	public DataPackageOperation AllowedOperations => _info.AllowedOperations;

	public DragDropModifiers Modifiers => _info.Modifiers;

	internal long SourceId => _info.SourceId;

	public DataPackageOperation AcceptedOperation { get; set; }

	public DragUIOverride DragUIOverride { get; }

	internal DragOperationDeferral? Deferral { get; private set; }

	internal DragEventArgs(UIElement originalSource, CoreDragInfo info, DragUIOverride uiOverride)
		: base(originalSource)
	{
		base.CanBubbleNatively = false;
		_info = info;
		DragUIOverride = uiOverride;
	}

	public Point GetPosition(UIElement relativeTo)
	{
		return _info.GetPosition(relativeTo);
	}

	public DragOperationDeferral GetDeferral()
	{
		return Deferral ?? (Deferral = new DragOperationDeferral());
	}
}
