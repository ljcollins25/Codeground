using System.Runtime.CompilerServices;
using Windows.Foundation;

namespace Uno.UI;

public static class ViewHelper
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Size PhysicalToLogicalPixels(this Size size)
	{
		return size;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Size LogicalToPhysicalPixels(this Size size)
	{
		return size;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Rect LogicalToPhysicalPixels(this Rect rect)
	{
		return rect;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Rect PhysicalToLogicalPixels(this Rect rect)
	{
		return rect;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Point PhysicalToLogicalPixels(this Point point)
	{
		return point;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Point LogicalToPhysicalPixels(this Point point)
	{
		return point;
	}
}
