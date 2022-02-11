namespace Windows.UI.Xaml.Media.Animation;

public class DiscreteColorKeyFrame : ColorKeyFrame
{
	internal class DiscreteDoubleKeyFrameEasingFunction : IEasingFunction
	{
		public double Ease(double currentTime, double startValue, double finalValue, double duration)
		{
			if (!(currentTime < duration))
			{
				return finalValue;
			}
			return startValue;
		}
	}

	private static readonly IEasingFunction _easingFunction = new DiscreteDoubleKeyFrame.DiscreteDoubleKeyFrameEasingFunction();

	internal override IEasingFunction GetEasingFunction()
	{
		return _easingFunction;
	}
}
