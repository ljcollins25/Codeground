using System;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal class XYFocusAlgorithms
{
	private const double InShadowThreshold = 0.25;

	private const double InShadowThresholdForSecondaryAxis = 0.02;

	private const double ConeAngle = Math.PI / 4.0;

	private int _primaryAxisDistanceWeight;

	private int _secondaryAxisDistanceWeight;

	private int _percentInManifoldShadowWeight;

	private int _percentInShadowWeight;

	internal XYFocusAlgorithms()
	{
		_primaryAxisDistanceWeight = 15;
		_secondaryAxisDistanceWeight = 1;
		_percentInManifoldShadowWeight = 10000;
		_percentInShadowWeight = 50;
	}

	internal double GetScore(FocusNavigationDirection direction, Rect bounds, Rect candidateBounds, (double first, double second) hManifold, (double first, double second) vManifold, double maxDistance)
	{
		double result = 0.0;
		double num = maxDistance;
		double num2 = maxDistance;
		double percentInManifoldShadow = 0.0;
		double num3 = 0.0;
		(double, double) referenceManifold = default((double, double));
		(double, double) referenceManifold2;
		(double, double) potentialManifold = default((double, double));
		if (XYFocusAlgorithmHelper.IsLeft(direction) || XYFocusAlgorithmHelper.IsRight(direction))
		{
			referenceManifold.Item1 = bounds.Top;
			referenceManifold.Item2 = bounds.Bottom;
			referenceManifold2 = hManifold;
			potentialManifold.Item1 = candidateBounds.Top;
			potentialManifold.Item2 = candidateBounds.Bottom;
		}
		else
		{
			referenceManifold.Item1 = bounds.Left;
			referenceManifold.Item2 = bounds.Right;
			referenceManifold2 = vManifold;
			potentialManifold.Item1 = candidateBounds.Left;
			potentialManifold.Item2 = candidateBounds.Right;
		}
		num = XYFocusAlgorithmHelper.CalculatePrimaryAxisDistance(direction, bounds, candidateBounds);
		num2 = XYFocusAlgorithmHelper.CalculateSecondaryAxisDistance(direction, bounds, candidateBounds);
		if (num >= 0.0)
		{
			num3 = XYFocusAlgorithmHelper.CalculatePercentInShadow(referenceManifold, potentialManifold);
			if (num3 >= 0.02)
			{
				percentInManifoldShadow = XYFocusAlgorithmHelper.CalculatePercentInShadow(referenceManifold2, potentialManifold);
				num2 = maxDistance;
			}
			num = maxDistance - num;
			num2 = maxDistance - num2;
			if (num3 >= 0.25)
			{
				num3 = 1.0;
				num *= 2.0;
			}
			result = CalculateScore(num3, num, num2, percentInManifoldShadow);
		}
		return result;
	}

	internal static void UpdateManifolds(FocusNavigationDirection direction, Rect bounds, Rect newFocusBounds, ref (double first, double second) hManifold, ref (double first, double second) vManifold)
	{
		if (vManifold.second < 0.0)
		{
			vManifold = (bounds.Left, bounds.Right);
		}
		if (hManifold.second < 0.0)
		{
			hManifold = (bounds.Top, bounds.Bottom);
		}
		if (XYFocusAlgorithmHelper.IsLeft(direction) || XYFocusAlgorithmHelper.IsRight(direction))
		{
			hManifold.first = Math.Max(Math.Max((float)newFocusBounds.Top, (float)bounds.Top), (float)hManifold.first);
			hManifold.second = Math.Min(Math.Min((float)newFocusBounds.Bottom, (float)bounds.Bottom), (float)hManifold.second);
			if (hManifold.second <= hManifold.first)
			{
				hManifold.first = newFocusBounds.Top;
				hManifold.second = newFocusBounds.Bottom;
			}
			vManifold.first = newFocusBounds.Left;
			vManifold.second = newFocusBounds.Right;
		}
		else if (XYFocusAlgorithmHelper.IsUp(direction) || XYFocusAlgorithmHelper.IsDown(direction))
		{
			vManifold.first = Math.Max(Math.Max((float)newFocusBounds.Left, (float)bounds.Left), (float)vManifold.first);
			vManifold.second = Math.Min(Math.Min((float)newFocusBounds.Right, (float)bounds.Right), (float)vManifold.second);
			if (vManifold.second <= vManifold.first)
			{
				vManifold.first = newFocusBounds.Left;
				vManifold.second = newFocusBounds.Right;
			}
			hManifold.first = newFocusBounds.Top;
			hManifold.second = newFocusBounds.Bottom;
		}
	}

	private double CalculateScore(double percentInShadow, double primaryAxisDistance, double secondaryAxisDistance, double percentInManifoldShadow)
	{
		return percentInShadow * (double)_percentInShadowWeight + primaryAxisDistance * (double)_primaryAxisDistanceWeight + secondaryAxisDistance * (double)_secondaryAxisDistanceWeight + percentInManifoldShadow * (double)_percentInManifoldShadowWeight;
	}

	internal static bool ShouldCandidateBeConsideredForRanking(Rect bounds, Rect candidateBounds, double maxDistance, FocusNavigationDirection direction, Rect exclusionRect, bool ignoreCone = false)
	{
		if (MathHelpers.IsEmptyRect(candidateBounds) || MathHelpers.DoesRectContainRect(candidateBounds, bounds) || MathHelpers.DoRectsIntersect(exclusionRect, candidateBounds) || MathHelpers.DoesRectContainRect(exclusionRect, candidateBounds))
		{
			return false;
		}
		if (ignoreCone || XYFocusAlgorithmHelper.IsDown(direction) || XYFocusAlgorithmHelper.IsUp(direction))
		{
			return true;
		}
		Point zero = Point.Zero;
		Point zero2 = Point.Zero;
		zero.Y = bounds.Top;
		zero2.Y = bounds.Bottom;
		Point[] array = MathHelpers.RectToPoints(candidateBounds);
		maxDistance *= 2.0;
		Point[] array2 = new Point[4];
		if (XYFocusAlgorithmHelper.IsLeft(direction))
		{
			zero.X = bounds.Left - 1.0;
			zero2.X = bounds.Left - 1.0;
			Point[] array3 = new Point[2];
			array3[0].X = (float)(zero.X + maxDistance * Math.Cos(3.9269908169872414));
			array3[0].Y = (float)(zero.Y + maxDistance * Math.Sin(3.9269908169872414));
			array3[1].X = (float)(zero2.X + maxDistance * Math.Cos(Math.PI * 3.0 / 4.0));
			array3[1].Y = (float)(zero2.Y + maxDistance * Math.Sin(Math.PI * 3.0 / 4.0));
			array2[0] = zero;
			array2[1] = array3[0];
			array2[2] = array3[1];
			array2[3] = zero2;
		}
		else if (XYFocusAlgorithmHelper.IsRight(direction))
		{
			zero.X = bounds.Right + 1.0;
			zero2.X = bounds.Right + 1.0;
			Point[] array4 = new Point[2];
			array4[0].X = (float)(zero.X + maxDistance * Math.Cos(Math.PI / 4.0));
			array4[0].Y = (float)(zero.Y + maxDistance * Math.Sin(Math.PI / 4.0));
			array4[1].X = (float)(zero2.X + maxDistance * Math.Cos(-Math.PI / 4.0));
			array4[1].Y = (float)(zero2.Y + maxDistance * Math.Sin(-Math.PI / 4.0));
			array2[0] = zero2;
			array2[1] = array4[0];
			array2[2] = array4[1];
			array2[3] = zero;
		}
		if (!MathHelpers.DoPolygonsIntersect(array2, array) && !MathHelpers.IsEntirelyContained(array, array2))
		{
			return MathHelpers.IsEntirelyContained(array2, array);
		}
		return true;
	}

	internal void SetPrimaryAxisDistanceWeight(int primaryAxisDistanceWeight)
	{
		_primaryAxisDistanceWeight = primaryAxisDistanceWeight;
	}

	internal void SetSecondaryAxisDistanceWeight(int secondaryAxisDistanceWeight)
	{
		_secondaryAxisDistanceWeight = secondaryAxisDistanceWeight;
	}

	internal void SetPercentInManifoldShadowWeight(int percentInManifoldShadowWeight)
	{
		_percentInManifoldShadowWeight = percentInManifoldShadowWeight;
	}

	internal void SetPercentInShadowWeight(int percentInShadowWeight)
	{
		_percentInShadowWeight = percentInShadowWeight;
	}
}
