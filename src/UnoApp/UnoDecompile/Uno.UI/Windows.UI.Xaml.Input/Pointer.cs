using System;
using System.Threading;
using Windows.Devices.Input;

namespace Windows.UI.Xaml.Input;

public sealed class Pointer : IEquatable<Pointer>
{
	private static int _unknownId;

	internal PointerIdentifier UniqueId { get; }

	public uint PointerId { get; }

	public PointerDeviceType PointerDeviceType { get; }

	public bool IsInContact { get; }

	public bool IsInRange { get; }

	internal static long CreateUniqueIdForUnknownPointer()
	{
		return long.MinValue | Interlocked.Increment(ref _unknownId);
	}

	public Pointer(uint id, PointerDeviceType type, bool isInContact, bool isInRange)
	{
		PointerId = id;
		PointerDeviceType = type;
		IsInContact = isInContact;
		IsInRange = isInRange;
		UniqueId = new PointerIdentifier(type, id);
	}

	internal Pointer(uint id, PointerDeviceType type)
	{
		PointerId = id;
		PointerDeviceType = type;
		UniqueId = new PointerIdentifier(type, id);
	}

	public override string ToString()
	{
		return $"{PointerDeviceType}/{PointerId}";
	}

	public bool Equals(Pointer other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		return UniqueId == other.UniqueId;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Pointer pointer))
		{
			return false;
		}
		return UniqueId == pointer.UniqueId;
	}

	public override int GetHashCode()
	{
		return ((int)PointerDeviceType * 397) ^ (int)PointerId;
	}
}
