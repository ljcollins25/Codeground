using System;

namespace Windows.UI.Xaml.Media.Animation;

public class ExponentialEase : EasingFunctionBase
{
	public double Exponent
	{
		get
		{
			return (double)GetValue(ExponentProperty);
		}
		set
		{
			SetValue(ExponentProperty, value);
		}
	}

	public static DependencyProperty ExponentProperty { get; } = DependencyProperty.Register("Exponent", typeof(double), typeof(ExponentialEase), new FrameworkPropertyMetadata(1.0, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as ExponentialEase)?.OnExponentChanged((double)e.OldValue, (double)e.NewValue);
	}));


	internal virtual void OnExponentChanged(double oldValue, double newValue)
	{
	}

	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = currentTime / duration;
		double exponent = Exponent;
		double num2 = (Math.Exp(exponent * num) - 1.0) / (Math.Exp(exponent) - 1.0);
		return startValue + (finalValue - startValue) * num2;
	}
}
