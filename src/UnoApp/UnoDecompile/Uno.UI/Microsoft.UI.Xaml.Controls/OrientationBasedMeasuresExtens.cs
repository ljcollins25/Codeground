using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

internal static class OrientationBasedMeasuresExtensions
{
	public static double Major(this OrientationBasedMeasures obm, Size size)
	{
		if (obm.ScrollOrientation != 0)
		{
			return size.Width;
		}
		return size.Height;
	}

	public static double Minor(this OrientationBasedMeasures obm, Size size)
	{
		if (obm.ScrollOrientation != 0)
		{
			return size.Height;
		}
		return size.Width;
	}

	public static double MajorSize(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.Width;
		}
		return rect.Height;
	}

	public static void SetMajorSize(this OrientationBasedMeasures obm, ref Rect rect, double value)
	{
		if (obm.ScrollOrientation == ScrollOrientation.Vertical)
		{
			rect.Height = value;
		}
		else
		{
			rect.Width = value;
		}
	}

	public static double MinorSize(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.Height;
		}
		return rect.Width;
	}

	public static void SetMinorSize(this OrientationBasedMeasures obm, ref Rect rect, double value)
	{
		if (obm.ScrollOrientation == ScrollOrientation.Vertical)
		{
			rect.Width = value;
		}
		else
		{
			rect.Height = value;
		}
	}

	public static double MajorStart(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.X;
		}
		return rect.Y;
	}

	public static void SetMajorStart(this OrientationBasedMeasures obm, ref Rect rect, double value)
	{
		if (obm.ScrollOrientation == ScrollOrientation.Vertical)
		{
			rect.Y = value;
		}
		else
		{
			rect.X = value;
		}
	}

	public static double MajorEnd(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.X + rect.Width;
		}
		return rect.Y + rect.Height;
	}

	public static double MinorStart(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.Y;
		}
		return rect.X;
	}

	public static void SetMinorStart(this OrientationBasedMeasures obm, ref Rect rect, double value)
	{
		if (obm.ScrollOrientation == ScrollOrientation.Vertical)
		{
			rect.X = value;
		}
		else
		{
			rect.Y = value;
		}
	}

	public static void AddMinorStart(this OrientationBasedMeasures obm, ref Rect rect, double increment)
	{
		if (obm.ScrollOrientation == ScrollOrientation.Vertical)
		{
			rect.X += increment;
		}
		else
		{
			rect.Y -= increment;
		}
	}

	public static double MinorEnd(this OrientationBasedMeasures obm, Rect rect)
	{
		if (obm.ScrollOrientation != 0)
		{
			return rect.Y + rect.Height;
		}
		return rect.X + rect.Width;
	}

	public static Rect MinorMajorRect(this OrientationBasedMeasures obm, float minor, float major, float minorSize, float majorSize)
	{
		if (obm.ScrollOrientation != 0)
		{
			return new Rect(major, minor, majorSize, minorSize);
		}
		return new Rect(minor, major, minorSize, majorSize);
	}

	public static Point MinorMajorPoint(this OrientationBasedMeasures obm, float minor, float major)
	{
		if (obm.ScrollOrientation != 0)
		{
			return new Point(major, minor);
		}
		return new Point(minor, major);
	}

	public static Size MinorMajorSize(this OrientationBasedMeasures obm, float minor, float major)
	{
		if (obm.ScrollOrientation != 0)
		{
			return new Size(major, minor);
		}
		return new Size(minor, major);
	}
}
