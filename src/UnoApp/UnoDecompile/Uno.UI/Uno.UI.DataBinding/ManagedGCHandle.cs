using System;
using System.Runtime.InteropServices;

namespace Uno.UI.DataBinding;

internal class ManagedGCHandle : IDisposable
{
	private GCHandle _handle;

	private bool _isDisposed;

	public object Target
	{
		get
		{
			if (!_handle.IsAllocated)
			{
				return null;
			}
			return _handle.Target;
		}
		set
		{
			if (!_handle.IsAllocated)
			{
				_handle = GCHandle.Alloc(value, GCHandleType.Weak);
			}
			else
			{
				_handle.Target = value;
			}
		}
	}

	internal GCHandle Handle => _handle;

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (_handle.IsAllocated)
			{
				_handle.Free();
			}
			_isDisposed = true;
		}
	}

	~ManagedGCHandle()
	{
		Dispose(disposing: false);
	}
}
