namespace Windows.UI.Xaml.Media.Animation;

public class CubicEase : EasingFunctionBase
{
	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			currentTime /= duration;
			return num * currentTime * currentTime * currentTime + startValue;
		case EasingMode.EaseOut:
			currentTime /= duration;
			currentTime -= 1.0;
			return num * (currentTime * currentTime * currentTime + 1.0) + startValue;
		case EasingMode.EaseInOut:
			currentTime /= duration / 2.0;
			if (currentTime < 1.0)
			{
				return num / 2.0 * currentTime * currentTime * currentTime + startValue;
			}
			currentTime -= 2.0;
			return num / 2.0 * (currentTime * currentTime * currentTime + 2.0) + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
