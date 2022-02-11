using System;
using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class ElasticEase : EasingFunctionBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Springiness
	{
		get
		{
			return (double)GetValue(SpringinessProperty);
		}
		set
		{
			SetValue(SpringinessProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int Oscillations
	{
		get
		{
			return (int)GetValue(OscillationsProperty);
		}
		set
		{
			SetValue(OscillationsProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OscillationsProperty { get; } = DependencyProperty.Register("Oscillations", typeof(int), typeof(ElasticEase), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SpringinessProperty { get; } = DependencyProperty.Register("Springiness", typeof(double), typeof(ElasticEase), new FrameworkPropertyMetadata(0.0));


	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = duration * 0.3;
		double num2 = num / 4.0;
		switch (base.EasingMode)
		{
		case EasingMode.EaseIn:
			if ((currentTime /= duration) == 1.0)
			{
				return startValue + finalValue;
			}
			return 0.0 - finalValue * Math.Pow(2.0, 10.0 * (currentTime -= 1.0)) * Math.Sin((currentTime * duration - num2) * (Math.PI * 2.0) / num) + startValue;
		case EasingMode.EaseOut:
			if ((currentTime /= duration) == 1.0)
			{
				return startValue + finalValue;
			}
			return finalValue * Math.Pow(2.0, -10.0 * currentTime) * Math.Sin((currentTime * duration - num2) * (Math.PI * 2.0) / num) + finalValue + startValue;
		case EasingMode.EaseInOut:
			if ((currentTime /= duration / 2.0) == 2.0)
			{
				return startValue + finalValue;
			}
			num = duration * 0.44999999999999996;
			if (currentTime < 1.0)
			{
				return -0.5 * (finalValue * Math.Pow(2.0, 10.0 * (currentTime -= 1.0)) * Math.Sin((currentTime * duration - num2) * (Math.PI * 2.0) / num)) + startValue;
			}
			return finalValue * Math.Pow(2.0, -10.0 * (currentTime -= 1.0)) * Math.Sin((currentTime * duration - num2) * (Math.PI * 2.0) / num) * 0.5 + finalValue + startValue;
		default:
			return finalValue * currentTime / duration + startValue;
		}
	}
}
