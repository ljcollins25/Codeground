namespace Windows.UI.Xaml.Media.Animation;

internal static class ColorOffsetEasingExtensions
{
	public static ColorOffset Ease(this IEasingFunction easing, long frame, ColorOffset from, ColorOffset to, long duration)
	{
		int a = (int)easing.Ease(frame, from.A, to.A, duration);
		int r = (int)easing.Ease(frame, from.R, to.R, duration);
		int g = (int)easing.Ease(frame, from.G, to.G, duration);
		int b = (int)easing.Ease(frame, from.B, to.B, duration);
		return ColorOffset.FromArgb(a, r, g, b);
	}
}
