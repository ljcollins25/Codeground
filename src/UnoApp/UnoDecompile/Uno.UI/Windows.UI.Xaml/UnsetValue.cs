using System;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

[Bindable]
internal class UnsetValue : IEquatable<UnsetValue>
{
	internal static UnsetValue Instance { get; } = new UnsetValue();


	private UnsetValue()
	{
	}

	public bool Equals(UnsetValue other)
	{
		return (object)other != null;
	}

	public override bool Equals(object obj)
	{
		return obj == this;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator ==(UnsetValue left, UnsetValue right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(UnsetValue left, UnsetValue right)
	{
		return !object.Equals(left, right);
	}
}
