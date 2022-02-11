using System.Collections;
using System.Runtime.CompilerServices;

namespace Uno.UI.Helpers;

internal class FastTypeComparer : IEqualityComparer
{
	public static FastTypeComparer Default { get; } = new FastTypeComparer();


	public new bool Equals(object? x, object? y)
	{
		return x == y;
	}

	public int GetHashCode(object? obj)
	{
		return RuntimeHelpers.GetHashCode(obj);
	}
}
