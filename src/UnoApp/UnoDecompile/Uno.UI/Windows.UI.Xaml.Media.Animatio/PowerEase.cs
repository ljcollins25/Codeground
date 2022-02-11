namespace Windows.UI.Xaml.Media.Animation;

public class PowerEase : EasingFunctionBase
{
	public int Power
	{
		get
		{
			return (int)GetValue(PowerProperty);
		}
		set
		{
			SetValue(PowerProperty, value);
		}
	}

	public static DependencyProperty PowerProperty { get; } = DependencyProperty.Register("Power", typeof(int), typeof(PowerEase), new FrameworkPropertyMetadata(2));


	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		double num2 = 1.0;
		if (Power == 1)
		{
			return num * currentTime / duration + startValue;
		}
		if (Power == 2)
		{
			QuadraticEase quadraticEase = new QuadraticEase();
			return quadraticEase.Ease(currentTime, startValue, finalValue, duration);
		}
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
		{
			currentTime /= duration;
			for (int k = 0; k < Power; k++)
			{
				num2 *= currentTime;
			}
			return num * num2 + startValue;
		}
		case EasingMode.EaseOut:
		{
			currentTime /= duration;
			for (int j = 0; j < Power; j++)
			{
				num2 *= currentTime;
			}
			if (Power % 2 == 0)
			{
				return (0.0 - num) * (num2 - 1.0) + startValue;
			}
			return num * (num2 + 1.0) + startValue;
		}
		case EasingMode.EaseInOut:
		{
			currentTime /= duration / 2.0;
			for (int i = 0; i <= Power; i++)
			{
				num2 *= currentTime;
			}
			if (currentTime < 1.0)
			{
				return num / 2.0 * num2 + startValue;
			}
			currentTime -= 2.0;
			if (Power % 2 == 0)
			{
				return num / 2.0 * (num2 + 2.0) + startValue;
			}
			return (0.0 - num) / 2.0 * (num2 - 2.0) + startValue;
		}
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
