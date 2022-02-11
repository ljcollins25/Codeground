using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal static class ProximityStrategy
{
	internal static double GetScore(FocusNavigationDirection direction, Rect bounds, Rect candidateBounds, double maxDistance, bool considerSecondaryAxis)
	{
		double result = 0.0;
		double num = XYFocusAlgorithmHelper.CalculatePrimaryAxisDistance(direction, bounds, candidateBounds);
		double num2 = XYFocusAlgorithmHelper.CalculateSecondaryAxisDistance(direction, bounds, candidateBounds);
		if (num >= 0.0)
		{
			(double, double) referenceManifold = default((double, double));
			(double, double) potentialManifold = default((double, double));
			if (XYFocusAlgorithmHelper.IsLeft(direction) || XYFocusAlgorithmHelper.IsRight(direction))
			{
				referenceManifold.Item1 = bounds.Top;
				referenceManifold.Item2 = bounds.Bottom;
				potentialManifold.Item1 = candidateBounds.Top;
				potentialManifold.Item2 = candidateBounds.Bottom;
			}
			else
			{
				referenceManifold.Item1 = bounds.Left;
				referenceManifold.Item2 = bounds.Right;
				potentialManifold.Item1 = candidateBounds.Left;
				potentialManifold.Item2 = candidateBounds.Right;
			}
			if (!considerSecondaryAxis || XYFocusAlgorithmHelper.CalculatePercentInShadow(referenceManifold, potentialManifold) != 0.0)
			{
				num2 = 0.0;
			}
			result = maxDistance - (num + num2);
		}
		return result;
	}
}
