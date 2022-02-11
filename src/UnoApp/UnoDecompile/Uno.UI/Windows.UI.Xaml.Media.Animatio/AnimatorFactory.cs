using System;

namespace Windows.UI.Xaml.Media.Animation;

internal static class AnimatorFactory
{
	internal static IValueAnimator Create<T>(Timeline timeline, T startingValue, T targetValue) where T : struct
	{
		if (startingValue is float)
		{
			object obj = startingValue;
			float num = (float)((obj is float) ? obj : null);
			if (targetValue is float)
			{
				object obj2 = targetValue;
				float num2 = (float)((obj2 is float) ? obj2 : null);
				return CreateDouble(timeline, num, num2);
			}
		}
		if (startingValue is double)
		{
			object obj3 = startingValue;
			double startingValue2 = (double)((obj3 is double) ? obj3 : null);
			if (targetValue is double)
			{
				object obj4 = targetValue;
				double targetValue2 = (double)((obj4 is double) ? obj4 : null);
				return CreateDouble(timeline, startingValue2, targetValue2);
			}
		}
		if (startingValue is ColorOffset)
		{
			object obj5 = startingValue;
			ColorOffset startingValue3 = (ColorOffset)((obj5 is ColorOffset) ? obj5 : null);
			if (targetValue is ColorOffset)
			{
				object obj6 = targetValue;
				ColorOffset targetValue3 = (ColorOffset)((obj6 is ColorOffset) ? obj6 : null);
				return CreateColor(timeline, startingValue3, targetValue3);
			}
		}
		throw new NotSupportedException();
	}

	private static IValueAnimator CreateDouble(Timeline timeline, double startingValue, double targetValue)
	{
		if (timeline.GetIsDurationZero())
		{
			return new ImmediateAnimator<double>(startingValue, targetValue);
		}
		return new RenderingLoopFloatAnimator((float)startingValue, (float)targetValue);
	}

	private static IValueAnimator CreateColor(Timeline timeline, ColorOffset startingValue, ColorOffset targetValue)
	{
		if (timeline.GetIsDurationZero())
		{
			return new ImmediateAnimator<ColorOffset>(startingValue, targetValue);
		}
		return new RenderingLoopColorAnimator(startingValue, targetValue);
	}
}
