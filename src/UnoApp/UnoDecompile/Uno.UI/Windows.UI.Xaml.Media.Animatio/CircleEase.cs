using System;

namespace Windows.UI.Xaml.Media.Animation;

public class CircleEase : EasingFunctionBase
{
	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		double num2 = currentTime;
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			num2 /= duration;
			return (0.0 - num) * (Math.Sqrt(1.0 - num2 * num2) - 1.0) + startValue;
		case EasingMode.EaseOut:
			num2 /= duration;
			num2 -= 1.0;
			return num * Math.Sqrt(1.0 - num2 * num2) + startValue;
		case EasingMode.EaseInOut:
			num2 /= duration / 2.0;
			if (num2 < 1.0)
			{
				return (0.0 - num) / 2.0 * (Math.Sqrt(1.0 - num2 * num2) - 1.0) + startValue;
			}
			num2 -= 2.0;
			return num / 2.0 * (Math.Sqrt(1.0 - num2 * num2) + 1.0) + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
