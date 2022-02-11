using System;
using System.ComponentModel;
using System.Globalization;

namespace Windows.UI.Xaml;

[TypeConverter(typeof(ThicknessConverter))]
public struct Thickness : IEquatable<Thickness>
{
	public static readonly Thickness Empty;

	public double Left { get; set; }

	public double Top { get; set; }

	public double Right { get; set; }

	public double Bottom { get; set; }

	public Thickness(double uniformLength)
	{
		this = default(Thickness);
		double num2 = (Bottom = uniformLength);
		double num4 = (Right = num2);
		double num7 = (Left = (Top = num4));
	}

	public Thickness(double left, double top, double right, double bottom)
	{
		this = default(Thickness);
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	public Thickness(double leftRight, double topBottom)
	{
		this = default(Thickness);
		Left = leftRight;
		Top = topBottom;
		Right = leftRight;
		Bottom = topBottom;
	}

	internal Thickness GetInverse()
	{
		return new Thickness(0.0 - Left, 0.0 - Top, 0.0 - Right, 0.0 - Bottom);
	}

	public bool Equals(Thickness other)
	{
		if (Math.Abs(Left - other.Left) < double.Epsilon && Math.Abs(Top - other.Top) < double.Epsilon && Math.Abs(Right - other.Right) < double.Epsilon)
		{
			return Math.Abs(Bottom - other.Bottom) < double.Epsilon;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is Thickness)
		{
			return Equals((Thickness)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Left.GetHashCode() ^ Top.GetHashCode() ^ Right.GetHashCode() ^ Bottom.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[Thickness: {0}-{1}-{2}-{3}]", Left, Top, Right, Bottom);
	}

	public static bool operator ==(Thickness t1, Thickness t2)
	{
		return t1.Equals(t2);
	}

	public static bool operator !=(Thickness t1, Thickness t2)
	{
		return !t1.Equals(t2);
	}
}
