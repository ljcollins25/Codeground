using System;
using System.ComponentModel;
using System.Globalization;
using Uno.Extensions;

namespace Windows.UI.Xaml;

[TypeConverter(typeof(CornerRadiusConverter))]
public struct CornerRadius : IEquatable<CornerRadius>
{
	public static readonly CornerRadius None = new CornerRadius(0.0);

	public double TopLeft { get; set; }

	public double TopRight { get; set; }

	public double BottomRight { get; set; }

	public double BottomLeft { get; set; }

	public CornerRadius(double uniformRadius)
	{
		this = default(CornerRadius);
		TopLeft = uniformRadius;
		TopRight = uniformRadius;
		BottomLeft = uniformRadius;
		BottomRight = uniformRadius;
	}

	public CornerRadius(double topLeft, double topRight, double bottomRight, double bottomLeft)
	{
		this = default(CornerRadius);
		TopLeft = topLeft;
		TopRight = topRight;
		BottomLeft = bottomLeft;
		BottomRight = bottomRight;
	}

	private static bool Equals(CornerRadius left, CornerRadius right)
	{
		if (left.TopLeft == right.TopLeft && left.TopRight == right.TopRight && left.BottomLeft == right.BottomLeft)
		{
			return left.BottomRight == right.BottomRight;
		}
		return false;
	}

	public bool Equals(CornerRadius other)
	{
		return Equals(this, other);
	}

	public override bool Equals(object obj)
	{
		if (obj is CornerRadius right)
		{
			return Equals(this, right);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return TopLeft.GetHashCode() ^ TopRight.GetHashCode() ^ BottomLeft.GetHashCode() ^ BottomRight.GetHashCode();
	}

	public override string ToString()
	{
		return "TopLeft: {0}, TopRight: {1}, BottomRight: {2}, BottomLeft: {3}".InvariantCultureFormat(TopLeft, TopRight, BottomRight, BottomLeft);
	}

	internal string ToStringCompact()
	{
		return string.Format(CultureInfo.InvariantCulture, "[CornerRadius: {0}-{1}-{2}-{3}]", TopLeft, TopRight, BottomRight, BottomLeft);
	}

	public static implicit operator CornerRadius(double uniformRadius)
	{
		return new CornerRadius(uniformRadius);
	}

	public static bool operator ==(CornerRadius cr1, CornerRadius cr2)
	{
		return Equals(cr1, cr2);
	}

	public static bool operator !=(CornerRadius cr1, CornerRadius cr2)
	{
		return !Equals(cr1, cr2);
	}
}
