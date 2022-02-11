using Windows.UI.Xaml;

namespace Uno.UI.Extensions;

internal static class ThicknessExtensions
{
	public static bool IsUniform(this Thickness thickness)
	{
		if (thickness.Left == thickness.Top && thickness.Left == thickness.Right)
		{
			return thickness.Left == thickness.Bottom;
		}
		return false;
	}

	public static Thickness Minus(this Thickness x, Thickness y)
	{
		return new Thickness(x.Left - y.Left, x.Top - y.Top, x.Right - y.Right, x.Bottom - y.Bottom);
	}

	public static double Horizontal(this Thickness thickness)
	{
		return thickness.Left + thickness.Right;
	}

	public static double Vertical(this Thickness thickness)
	{
		return thickness.Top + thickness.Bottom;
	}
}
