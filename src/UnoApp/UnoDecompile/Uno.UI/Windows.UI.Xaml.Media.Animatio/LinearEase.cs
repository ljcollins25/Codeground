namespace Windows.UI.Xaml.Media.Animation;

internal sealed class LinearEase : IEasingFunction
{
	public static LinearEase Instance { get; } = new LinearEase();


	private LinearEase()
	{
	}

	public double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		double num2 = currentTime / duration;
		double num3 = num * num2;
		return num3 + startValue;
	}
}
