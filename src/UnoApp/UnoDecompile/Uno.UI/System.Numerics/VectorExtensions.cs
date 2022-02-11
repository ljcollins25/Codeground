using Windows.Foundation;

namespace System.Numerics;

public static class VectorExtensions
{
	public static Point ToPoint(this Vector2 vector)
	{
		return new Point(vector.X, vector.Y);
	}

	public static Size ToSize(this Vector2 vector)
	{
		return new Size(vector.X, vector.Y);
	}

	public static Vector2 ToVector2(this Point point)
	{
		return new Vector2((float)point.X, (float)point.Y);
	}

	public static Vector2 ToVector2(this Size size)
	{
		return new Vector2((float)size.Width, (float)size.Height);
	}
}
