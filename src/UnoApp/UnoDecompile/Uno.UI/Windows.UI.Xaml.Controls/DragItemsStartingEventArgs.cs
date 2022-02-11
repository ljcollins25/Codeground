using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;

namespace Windows.UI.Xaml.Controls;

public class DragItemsStartingEventArgs
{
	private readonly DragStartingEventArgs? _inner;

	public bool Cancel
	{
		get
		{
			return _inner?.Cancel ?? false;
		}
		set
		{
			if (_inner != null)
			{
				_inner!.Cancel = value;
			}
		}
	}

	public DataPackage Data { get; }

	public IList<object> Items { get; }

	public DragItemsStartingEventArgs()
	{
		Data = new DataPackage();
		Items = new List<object>();
	}

	internal DragItemsStartingEventArgs(DragStartingEventArgs inner, IList<object> items)
	{
		_inner = inner;
		Data = _inner!.Data;
		Items = items;
	}
}
