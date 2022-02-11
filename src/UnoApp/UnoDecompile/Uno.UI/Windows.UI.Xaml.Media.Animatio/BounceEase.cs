using Uno;

namespace Windows.UI.Xaml.Media.Animation;

public class BounceEase : EasingFunctionBase
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double Bounciness
	{
		get
		{
			return (double)GetValue(BouncinessProperty);
		}
		set
		{
			SetValue(BouncinessProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int Bounces
	{
		get
		{
			return (int)GetValue(BouncesProperty);
		}
		set
		{
			SetValue(BouncesProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BouncesProperty { get; } = DependencyProperty.Register("Bounces", typeof(int), typeof(BounceEase), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty BouncinessProperty { get; } = DependencyProperty.Register("Bounciness", typeof(double), typeof(BounceEase), new FrameworkPropertyMetadata(0.0));


	public override double Ease(double currentTime, double startValue, double finalValue, double duration)
	{
		double num = finalValue - startValue;
		double progress = currentTime / duration;
		double num2 = EaseCore(progress);
		return startValue + num2 * num;
	}

	internal double EaseCore(double progress)
	{
		return base.EasingMode switch
		{
			EasingMode.EaseIn => BounceEaseIn(progress), 
			EasingMode.EaseOut => BounceEaseOut(progress), 
			_ => BounceEaseInOut(progress), 
		};
	}

	private static double BounceEaseIn(double progress)
	{
		return 1.0 - BounceEaseOut(1.0 - progress);
	}

	private static double BounceEaseOut(double progress)
	{
		if (progress < 0.36363636363636365)
		{
			return 7.5625 * progress * progress;
		}
		if (progress < 0.72727272727272729)
		{
			return 7.5625 * (progress -= 0.54545454545454541) * progress + 0.75;
		}
		if (progress < 0.90909090909090906)
		{
			return 7.5625 * (progress -= 0.81818181818181823) * progress + 0.9375;
		}
		return 7.5625 * (progress -= 21.0 / 22.0) * progress + 63.0 / 64.0;
	}

	private static double BounceEaseInOut(double progress)
	{
		if (!(progress < 0.5))
		{
			return (1.0 + BounceEaseOut(2.0 * progress - 1.0)) / 2.0;
		}
		return (1.0 - BounceEaseOut(1.0 - 2.0 * progress)) / 2.0;
	}
}
