using System;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal static class XYFocusAlgorithmHelper
{
	internal static double CalculatePrimaryAxisDistance(FocusNavigationDirection direction, Rect bounds, Rect candidateBounds)
	{
		double result = -1.0;
		bool flag = MathHelpers.DoRectsIntersect(bounds, candidateBounds);
		if (bounds == candidateBounds)
		{
			return -1.0;
		}
		if (IsLeft(direction) && (candidateBounds.Right <= bounds.Left || (flag && candidateBounds.Left <= bounds.Left)))
		{
			result = Math.Abs(bounds.Left - candidateBounds.Right);
		}
		else if (IsRight(direction) && (candidateBounds.Left >= bounds.Right || (flag && candidateBounds.Right >= bounds.Right)))
		{
			result = Math.Abs(candidateBounds.Left - bounds.Right);
		}
		else if (IsUp(direction) && (candidateBounds.Bottom <= bounds.Top || (flag && candidateBounds.Top <= bounds.Top)))
		{
			result = Math.Abs(bounds.Top - candidateBounds.Bottom);
		}
		else if (IsDown(direction) && (candidateBounds.Top >= bounds.Bottom || (flag && candidateBounds.Bottom >= bounds.Bottom)))
		{
			result = Math.Abs(candidateBounds.Top - bounds.Bottom);
		}
		return result;
	}

	internal static double CalculateSecondaryAxisDistance(FocusNavigationDirection direction, Rect bounds, Rect candidateBounds)
	{
		if (IsLeft(direction) || IsRight(direction))
		{
			return (candidateBounds.Top < bounds.Top) ? Math.Abs(bounds.Top - candidateBounds.Bottom) : Math.Abs(candidateBounds.Top - bounds.Bottom);
		}
		return (candidateBounds.Left < bounds.Left) ? Math.Abs(bounds.Left - candidateBounds.Right) : Math.Abs(candidateBounds.Left - bounds.Right);
	}

	internal static double CalculatePercentInShadow((double first, double second) referenceManifold, (double first, double second) potentialManifold)
	{
		if (referenceManifold.first > potentialManifold.second || referenceManifold.second <= potentialManifold.first)
		{
			return 0.0;
		}
		double value = Math.Min(referenceManifold.second, potentialManifold.second) - Math.Max(referenceManifold.first, potentialManifold.first);
		value = Math.Abs(value);
		double num = Math.Abs(potentialManifold.second - potentialManifold.first);
		double num2 = Math.Abs(referenceManifold.second - referenceManifold.first);
		double num3 = num2;
		if (num3 >= num)
		{
			num3 = num;
		}
		double result = 1.0;
		if (num3 != 0.0)
		{
			result = Math.Min(value / num3, 1.0);
		}
		return result;
	}

	internal static bool IsLeft(FocusNavigationDirection direction)
	{
		return direction == FocusNavigationDirection.Left;
	}

	internal static bool IsRight(FocusNavigationDirection direction)
	{
		return direction == FocusNavigationDirection.Right;
	}

	internal static bool IsUp(FocusNavigationDirection direction)
	{
		return direction == FocusNavigationDirection.Up;
	}

	internal static bool IsDown(FocusNavigationDirection direction)
	{
		return direction == FocusNavigationDirection.Down;
	}
}
