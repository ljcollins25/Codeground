using System;
using System.Numerics;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public struct Matrix : IFormattable
{
	internal Matrix3x2 Inner;

	public static Matrix Identity { get; } = new Matrix(Matrix3x2.Identity);


	public bool IsIdentity => Equals(Identity);

	public double M11
	{
		get
		{
			return Inner.M11;
		}
		set
		{
			Inner.M11 = (float)value;
		}
	}

	public double M12
	{
		get
		{
			return Inner.M12;
		}
		set
		{
			Inner.M12 = (float)value;
		}
	}

	public double M21
	{
		get
		{
			return Inner.M21;
		}
		set
		{
			Inner.M21 = (float)value;
		}
	}

	public double M22
	{
		get
		{
			return Inner.M22;
		}
		set
		{
			Inner.M22 = (float)value;
		}
	}

	public double OffsetX
	{
		get
		{
			return Inner.M31;
		}
		set
		{
			Inner.M31 = (float)value;
		}
	}

	public double OffsetY
	{
		get
		{
			return Inner.M32;
		}
		set
		{
			Inner.M32 = (float)value;
		}
	}

	internal Matrix(Matrix3x2 matrix)
	{
		Inner = matrix;
	}

	public Matrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
	{
		Inner = new Matrix3x2((float)m11, (float)m12, (float)m21, (float)m22, (float)offsetX, (float)offsetY);
	}

	public bool Equals(Matrix value)
	{
		return Inner == value.Inner;
	}

	public override bool Equals(object o)
	{
		if (!(o is Matrix matrix))
		{
			return false;
		}
		return Inner.Equals(matrix.Inner);
	}

	public override int GetHashCode()
	{
		return Inner.GetHashCode();
	}

	public override string ToString()
	{
		return Inner.ToString();
	}

	public string ToString(IFormatProvider provider)
	{
		return Inner.ToString();
	}

	public string ToString(string format, IFormatProvider provider)
	{
		return Inner.ToString();
	}

	public Point Transform(Point point)
	{
		Vector2 vector = Vector2.Transform(new Vector2((float)point.X, (float)point.Y), Inner);
		return new Point(vector.X, vector.Y);
	}

	public static bool operator ==(Matrix matrix1, Matrix matrix2)
	{
		return matrix1.Inner.Equals(matrix2.Inner);
	}

	public static bool operator !=(Matrix matrix1, Matrix matrix2)
	{
		return !matrix1.Inner.Equals(matrix2.Inner);
	}
}
