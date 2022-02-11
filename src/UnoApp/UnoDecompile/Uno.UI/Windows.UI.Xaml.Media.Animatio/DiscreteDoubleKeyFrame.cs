namespace Windows.UI.Xaml.Media.Animation;

public class DiscreteDoubleKeyFrame : DoubleKeyFrame
{
	internal class DiscreteDoubleKeyFrameEasingFunction : IEasingFunction
	{
		public double Ease(double currentTime, double startValue, double finalValue, double duration)
		{
			if (currentTime < duration)
			{
				return startValue;
			}
			return finalValue;
		}
	}

	private static readonly IEasingFunction _easingFunction = new DiscreteDoubleKeyFrameEasingFunction();

	public DiscreteDoubleKeyFrame()
	{
	}

	public DiscreteDoubleKeyFrame(double value)
		: base(value)
	{
	}

	public DiscreteDoubleKeyFrame(double value, KeyTime keyTime)
		: base(value, keyTime)
	{
	}

	internal override IEasingFunction GetEasingFunction()
	{
		return _easingFunction;
	}
}
