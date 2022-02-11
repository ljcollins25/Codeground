namespace Windows.UI.Xaml.Media.Animation;

internal class SplineEasingFunction : IEasingFunction
{
	public KeySpline KeySpline { get; }

	public SplineEasingFunction(KeySpline keySpline)
	{
		KeySpline = keySpline;
	}

	public double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double linearProgress = currentTime / duration;
		double splineProgress = KeySpline.GetSplineProgress(linearProgress);
		return startValue + (finalValue - startValue) * splineProgress;
	}
}
