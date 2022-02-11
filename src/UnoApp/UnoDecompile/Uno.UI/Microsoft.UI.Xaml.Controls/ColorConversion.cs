using System;
using System.Globalization;
using Windows.UI;

namespace Microsoft.UI.Xaml.Controls;

internal static class ColorConversion
{
	public static ulong? TryParseInt(string s)
	{
		return TryParseInt(s, 10);
	}

	public static ulong? TryParseInt(string str, int numBase)
	{
		if (string.IsNullOrEmpty(str))
		{
			return null;
		}
		switch (numBase)
		{
		case 10:
		{
			if (ulong.TryParse(str, out var result2))
			{
				return result2;
			}
			break;
		}
		case 16:
		{
			if (ulong.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			break;
		}
		}
		return null;
	}

	public static Hsv RgbToHsv(Rgb rgb)
	{
		double num = ((!(rgb.R >= rgb.G)) ? ((rgb.G >= rgb.B) ? rgb.G : rgb.B) : ((rgb.R >= rgb.B) ? rgb.R : rgb.B));
		double num2 = ((!(rgb.R <= rgb.G)) ? ((rgb.G <= rgb.B) ? rgb.G : rgb.B) : ((rgb.R <= rgb.B) ? rgb.R : rgb.B));
		double num3 = num;
		double num4 = num - num2;
		double num5;
		double s;
		if (num4 == 0.0)
		{
			num5 = 0.0;
			s = 0.0;
		}
		else
		{
			num5 = ((rgb.R == num) ? (60.0 * (rgb.G - rgb.B) / num4) : ((rgb.G != num) ? (240.0 + 60.0 * (rgb.R - rgb.G) / num4) : (120.0 + 60.0 * (rgb.B - rgb.R) / num4)));
			if (num5 < 0.0)
			{
				num5 += 360.0;
			}
			s = num4 / num3;
		}
		return new Hsv(num5, s, num3);
	}

	public static Rgb HsvToRgb(Hsv hsv)
	{
		double num = hsv.H;
		double s = hsv.S;
		double v = hsv.V;
		while (num >= 360.0)
		{
			num -= 360.0;
		}
		for (; num < 0.0; num += 360.0)
		{
		}
		s = ((s < 0.0) ? 0.0 : s);
		s = ((s > 1.0) ? 1.0 : s);
		v = ((v < 0.0) ? 0.0 : v);
		v = ((v > 1.0) ? 1.0 : v);
		double num2 = s * v;
		double num3 = v - num2;
		if (num2 == 0.0)
		{
			return new Rgb(num3, num3, num3);
		}
		int num4 = (int)(num / 60.0);
		double num5 = num / 60.0 - (double)num4;
		double num6 = num2 + num3;
		double r = 0.0;
		double g = 0.0;
		double b = 0.0;
		switch (num4)
		{
		case 0:
			r = num6;
			g = num3 + num2 * num5;
			b = num3;
			break;
		case 1:
			r = num3 + num2 * (1.0 - num5);
			g = num6;
			b = num3;
			break;
		case 2:
			r = num3;
			g = num6;
			b = num3 + num2 * num5;
			break;
		case 3:
			r = num3;
			g = num3 + num2 * (1.0 - num5);
			b = num6;
			break;
		case 4:
			r = num3 + num2 * num5;
			g = num3;
			b = num6;
			break;
		case 5:
			r = num6;
			g = num3;
			b = num3 + num2 * (1.0 - num5);
			break;
		}
		return new Rgb(r, g, b);
	}

	public static Rgb HexToRgb(string input)
	{
		var (result, num) = HexToRgba(input);
		return result;
	}

	public static string RgbToHex(Rgb rgb)
	{
		byte b = (byte)Math.Round(rgb.R * 255.0);
		byte b2 = (byte)Math.Round(rgb.G * 255.0);
		byte b3 = (byte)Math.Round(rgb.B * 255.0);
		ulong num = ((ulong)b << 16) + ((ulong)b2 << 8) + b3;
		return string.Format(CultureInfo.InvariantCulture, "#{0:X6}", num);
	}

	public static (Rgb, double) HexToRgba(string input)
	{
		input = ((input == null || input.Length <= 1) ? input : input?.Substring(1));
		ulong? num = TryParseInt(input, 16);
		if (!num.HasValue)
		{
			return (new Rgb(-1.0, -1.0, -1.0), -1.0);
		}
		ulong value = num.Value;
		byte b = (byte)((value & 0xFF000000u) >> 24);
		byte b2 = (byte)((value & 0xFF0000) >> 16);
		byte b3 = (byte)((value & 0xFF00) >> 8);
		byte b4 = (byte)(value & 0xFF);
		return (new Rgb((double)(int)b2 / 255.0, (double)(int)b3 / 255.0, (double)(int)b4 / 255.0), (double)(int)b / 255.0);
	}

	public static string RgbaToHex(Rgb rgb, double alpha)
	{
		byte b = (byte)Math.Round(alpha * 255.0);
		byte b2 = (byte)Math.Round(rgb.R * 255.0);
		byte b3 = (byte)Math.Round(rgb.G * 255.0);
		byte b4 = (byte)Math.Round(rgb.B * 255.0);
		ulong num = ((ulong)b << 24) + ((ulong)b2 << 16) + ((ulong)b3 << 8) + ((ulong)b4 & 0xFFuL);
		return string.Format(CultureInfo.InvariantCulture, "#{0:X8}", num);
	}

	public static Color ColorFromRgba(Rgb rgb, double alpha = 1.0)
	{
		return Color.FromArgb((byte)Math.Round(alpha * 255.0), (byte)Math.Round(rgb.R * 255.0), (byte)Math.Round(rgb.G * 255.0), (byte)Math.Round(rgb.B * 255.0));
	}

	public static Rgb RgbFromColor(Color color)
	{
		return new Rgb((double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0);
	}
}
