namespace Windows.UI.Xaml;

public sealed class GridLengthHelper
{
	public static GridLength Auto { get; } = new GridLength(1.0, GridUnitType.Auto);


	internal static GridLength OneStar { get; } = new GridLength(1.0, GridUnitType.Star);


	public static GridLength FromPixels(double pixels)
	{
		return new GridLength((float)pixels, GridUnitType.Pixel);
	}

	public static GridLength FromValueAndType(double value, GridUnitType type)
	{
		return new GridLength((float)value, type);
	}

	public static bool GetIsAbsolute(GridLength target)
	{
		return target.IsAbsolute;
	}

	public static bool GetIsAuto(GridLength target)
	{
		return target.IsAuto;
	}

	public static bool GetIsStar(GridLength target)
	{
		return target.IsStar;
	}

	public static bool Equals(GridLength target, GridLength value)
	{
		return target.Equals(value);
	}
}
