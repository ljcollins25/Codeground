using System;

namespace DirectUI;

internal class DoubleUtil
{
	public static bool AreClose(double value1, double value2)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (value1 == value2)
		{
			return true;
		}
		num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * double.Epsilon;
		num2 = value1 - value2;
		if (0.0 - num < num2)
		{
			return num > num2;
		}
		return false;
	}

	public static bool LessThanOrClose(double value1, double value2)
	{
		if (!(value1 < value2))
		{
			return AreClose(value1, value2);
		}
		return true;
	}

	public static bool AreWithinTolerance(double a, double b, double tolerance)
	{
		return LessThanOrClose(Math.Abs(a - b), tolerance);
	}

	public static bool IsZero(double value)
	{
		return Math.Abs(value) < 4.94065645841247E-323;
	}
}
