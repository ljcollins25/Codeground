using System.Runtime.CompilerServices;

namespace Uno.Extensions;

internal static class DoubleExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsFinite(this double value)
	{
		if (!double.IsInfinity(value))
		{
			return !double.IsNaN(value);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsFinite(this float value)
	{
		if (!float.IsInfinity(value))
		{
			return !float.IsNaN(value);
		}
		return false;
	}
}
