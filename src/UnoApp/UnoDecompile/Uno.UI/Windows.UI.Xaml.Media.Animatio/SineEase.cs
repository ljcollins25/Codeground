using System;

namespace Windows.UI.Xaml.Media.Animation;

public class SineEase : EasingFunctionBase
{
	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			return (0.0 - finalValue) * Math.Cos(currentTime / duration * (Math.PI / 2.0)) + finalValue + startValue;
		case EasingMode.EaseOut:
			return finalValue * Math.Sin(currentTime / duration * (Math.PI / 2.0)) + startValue;
		case EasingMode.EaseInOut:
			if ((currentTime /= duration / 2.0) < 1.0)
			{
				return finalValue / 2.0 * Math.Sin(Math.PI * currentTime / 2.0) + startValue;
			}
			return (0.0 - finalValue) / 2.0 * (Math.Cos(Math.PI * (currentTime -= 1.0) / 2.0) - 2.0) + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
