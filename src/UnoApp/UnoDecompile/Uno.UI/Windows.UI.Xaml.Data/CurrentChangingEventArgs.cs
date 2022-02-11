using System;

namespace Windows.UI.Xaml.Data;

public class CurrentChangingEventArgs
{
	private bool _cancel;

	public bool Cancel
	{
		get
		{
			return _cancel;
		}
		set
		{
			if (!IsCancelable)
			{
				throw new InvalidOperationException();
			}
			_cancel = value;
		}
	}

	public bool IsCancelable { get; } = true;


	public CurrentChangingEventArgs()
	{
	}

	public CurrentChangingEventArgs(bool isCancelable)
	{
		IsCancelable = isCancelable;
	}
}
