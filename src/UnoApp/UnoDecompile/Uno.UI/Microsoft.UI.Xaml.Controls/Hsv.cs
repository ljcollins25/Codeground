using System.Numerics;

namespace Microsoft.UI.Xaml.Controls;

internal struct Hsv
{
	public double H;

	public double S;

	public double V;

	public Hsv(double h, double s, double v)
	{
		H = h;
		S = s;
		V = v;
	}

	public static float GetHue(Vector4 hsva)
	{
		return hsva.X;
	}

	public static void SetHue(Vector4 hsva, float hue)
	{
		hsva.X = hue;
	}

	public static float GetSaturation(Vector4 hsva)
	{
		return hsva.Y;
	}

	public static void SetSaturation(Vector4 hsva, float saturation)
	{
		hsva.Y = saturation;
	}

	public static float GetValue(Vector4 hsva)
	{
		return hsva.Z;
	}

	public static void SetValue(Vector4 hsva, float value)
	{
		hsva.Z = value;
	}

	public static float GetAlpha(Vector4 hsva)
	{
		return hsva.W;
	}

	public static void SetAlpha(Vector4 hsva, float alpha)
	{
		hsva.W = alpha;
	}
}
