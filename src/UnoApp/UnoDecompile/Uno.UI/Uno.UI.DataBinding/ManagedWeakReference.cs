using System;

namespace Uno.UI.DataBinding;

public class ManagedWeakReference : IDisposable
{
	private readonly ManagedGCHandle _targetHandle;

	private readonly ManagedGCHandle _ownerHandle;

	private bool _disposed;

	public object Owner => _ownerHandle?.Target;

	public object Target
	{
		get
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("ManagedWeakReference");
			}
			object obj = _targetHandle?.Target;
			if (IsNativeAlive(obj))
			{
				return obj;
			}
			return null;
		}
	}

	public bool IsAlive
	{
		get
		{
			if (_disposed)
			{
				return false;
			}
			object obj = _targetHandle?.Target;
			if (!IsNativeAlive(obj))
			{
				return false;
			}
			return obj != null;
		}
	}

	public bool IsSelfReference { get; }

	public bool IsDisposed => _disposed;

	internal ManagedWeakReference(ManagedGCHandle ownerHandle, ManagedGCHandle targetHandle, bool isSelf)
	{
		_ownerHandle = ownerHandle;
		_targetHandle = targetHandle;
		IsSelfReference = isSelf;
	}

	internal ManagedGCHandle GetUnsafeTargetHandle()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("ManagedWeakReference");
		}
		return _targetHandle;
	}

	public WeakReference CloneWeakReference()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("ManagedWeakReference");
		}
		return new WeakReference(_targetHandle?.Target);
	}

	internal ManagedGCHandle GetUnsafeOwnerHandle()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("ManagedWeakReference");
		}
		return _ownerHandle;
	}

	private static bool IsNativeAlive(object obj)
	{
		if (obj is INativeObject nativeObject)
		{
			return nativeObject.Handle != IntPtr.Zero;
		}
		return true;
	}

	public void Dispose()
	{
		_disposed = true;
	}
}
