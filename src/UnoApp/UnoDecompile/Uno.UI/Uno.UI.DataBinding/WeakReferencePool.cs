using System.Collections.Generic;

namespace Uno.UI.DataBinding;

public static class WeakReferencePool
{
	private static readonly Stack<ManagedGCHandle> _weakReferencePool = new Stack<ManagedGCHandle>();

	private static readonly object _gate = new object();

	public static int MaxReferences { get; set; } = 500;


	public static bool Enabled { get; set; } = true;


	internal static int PooledReferences => _weakReferencePool.Count;

	public static ManagedWeakReference RentSelfWeakReference(IWeakReferenceProvider target)
	{
		ManagedGCHandle managedGCHandle = RentFromPool(target);
		return new ManagedWeakReference(managedGCHandle, managedGCHandle, isSelf: true);
	}

	public static ManagedWeakReference RentWeakReference(object owner, object target)
	{
		if (target is IWeakReferenceProvider weakReferenceProvider)
		{
			return weakReferenceProvider.WeakReference;
		}
		if (owner is IWeakReferenceProvider weakReferenceProvider2)
		{
			return new ManagedWeakReference(weakReferenceProvider2.WeakReference.GetUnsafeTargetHandle(), RentFromPool(target), isSelf: false);
		}
		return new ManagedWeakReference(RentFromPool(owner), RentFromPool(target), isSelf: false);
	}

	public static void ReturnWeakReference(object owner, ManagedWeakReference managedWeakReference)
	{
		if (!Enabled || managedWeakReference == null || managedWeakReference.Owner != owner || managedWeakReference.IsSelfReference)
		{
			return;
		}
		lock (_gate)
		{
			if (_weakReferencePool.Count < MaxReferences)
			{
				ReturnUnsafeWeakReference(managedWeakReference.GetUnsafeTargetHandle());
				if (!(managedWeakReference.Owner is IWeakReferenceProvider))
				{
					ReturnUnsafeWeakReference(managedWeakReference.GetUnsafeOwnerHandle());
				}
				managedWeakReference.Dispose();
			}
		}
	}

	private static void ReturnUnsafeWeakReference(ManagedGCHandle handle)
	{
		if (handle != null)
		{
			_weakReferencePool.Push(handle);
		}
	}

	internal static void ClearCache()
	{
		lock (_gate)
		{
			_weakReferencePool.Clear();
		}
	}

	private static ManagedGCHandle RentFromPool(object target)
	{
		if (target == null)
		{
			return null;
		}
		lock (_gate)
		{
			if (_weakReferencePool.Count == 0)
			{
				return new ManagedGCHandle
				{
					Target = target
				};
			}
			ManagedGCHandle managedGCHandle = _weakReferencePool.Pop();
			managedGCHandle.Target = target;
			return managedGCHandle;
		}
	}
}
