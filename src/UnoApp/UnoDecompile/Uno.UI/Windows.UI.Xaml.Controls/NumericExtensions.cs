using System;
using System.Runtime.InteropServices;

namespace Windows.UI.Xaml.Controls;

internal static class NumericExtensions
{
	[StructLayout(LayoutKind.Explicit)]
	private struct NanUnion
	{
		[FieldOffset(0)]
		internal double FloatingValue;

		[FieldOffset(0)]
		internal ulong IntegerValue;
	}

	public static bool IsZero(this double value)
	{
		return Math.Abs(value) < 2.2204460492503131E-15;
	}

	public static bool IsNaN(this double value)
	{
		NanUnion nanUnion = default(NanUnion);
		nanUnion.FloatingValue = value;
		NanUnion nanUnion2 = nanUnion;
		ulong num = nanUnion2.IntegerValue & 0xFFF0000000000000uL;
		if (num != 9218868437227405312L && num != 18442240474082181120uL)
		{
			return false;
		}
		ulong num2 = nanUnion2.IntegerValue & 0xFFFFFFFFFFFFFuL;
		return num2 != 0;
	}

	public static bool IsGreaterThan(double left, double right)
	{
		if (left > right)
		{
			return !AreClose(left, right);
		}
		return false;
	}

	public static bool IsLessThanOrClose(double left, double right)
	{
		if (!(left < right))
		{
			return AreClose(left, right);
		}
		return true;
	}

	public static bool AreClose(double left, double right)
	{
		if (left == right)
		{
			return true;
		}
		double num = (Math.Abs(left) + Math.Abs(right) + 10.0) * 2.2204460492503131E-16;
		double num2 = left - right;
		if (0.0 - num < num2)
		{
			return num > num2;
		}
		return false;
	}
}
