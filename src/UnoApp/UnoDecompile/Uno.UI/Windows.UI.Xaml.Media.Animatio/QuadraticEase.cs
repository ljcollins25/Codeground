namespace Windows.UI.Xaml.Media.Animation;

public class QuadraticEase : EasingFunctionBase
{
	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			currentTime /= duration;
			return num * currentTime * currentTime + startValue;
		case EasingMode.EaseOut:
			currentTime /= duration;
			return (0.0 - num) * currentTime * (currentTime - 2.0) + startValue;
		case EasingMode.EaseInOut:
			currentTime /= duration / 2.0;
			if (currentTime < 1.0)
			{
				return num / 2.0 * currentTime * currentTime + startValue;
			}
			currentTime -= 1.0;
			return (0.0 - num) / 2.0 * (currentTime * (currentTime - 2.0) - 1.0) + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
