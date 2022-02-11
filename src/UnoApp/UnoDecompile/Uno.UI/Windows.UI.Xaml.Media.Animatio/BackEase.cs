namespace Windows.UI.Xaml.Media.Animation;

public class BackEase : EasingFunctionBase
{
	public double Amplitude
	{
		get
		{
			return (double)GetValue(AmplitudeProperty);
		}
		set
		{
			SetValue(AmplitudeProperty, value);
		}
	}

	public static DependencyProperty AmplitudeProperty { get; } = DependencyProperty.Register("Amplitude", typeof(double), typeof(BackEase), new FrameworkPropertyMetadata(1.0));


	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = 1.70158 * Amplitude;
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			return finalValue * (currentTime /= duration) * currentTime * ((num + 1.0) * currentTime - num) + startValue;
		case EasingMode.EaseOut:
			return finalValue * ((currentTime = currentTime / duration - 1.0) * currentTime * ((num + 1.0) * currentTime + num) + 1.0) + startValue;
		case EasingMode.EaseInOut:
			if ((currentTime /= duration / 2.0) < 1.0)
			{
				return finalValue / 2.0 * (currentTime * currentTime * (((num *= 1.525) + 1.0) * currentTime - num)) + startValue;
			}
			return finalValue / 2.0 * ((currentTime -= 2.0) * currentTime * (((num *= 1.525) + 1.0) * currentTime + num) + 2.0) + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
