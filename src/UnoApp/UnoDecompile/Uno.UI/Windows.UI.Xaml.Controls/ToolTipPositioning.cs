using System;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal static class ToolTipPositioning
{
	private static bool IsLefthandedUser()
	{
		return true;
	}

	private static Size ConstrainSize(Size size, double xMax, double yMax)
	{
		Size result = size;
		if (size.Width > xMax)
		{
			result.Width = xMax;
		}
		if (size.Height > yMax)
		{
			result.Height = yMax;
		}
		return result;
	}

	private static Rect HorizontallyCenterRect(Rect container, Rect rcToCenter)
	{
		double dx = (container.Left - rcToCenter.Left + (container.Right - rcToCenter.Right)) / 2.0;
		return rcToCenter.OffsetRect(dx, 0.0);
	}

	private static Rect VerticallyCenterRect(Rect container, Rect rcToCenter)
	{
		double dy = (container.Top - rcToCenter.Top + (container.Bottom - rcToCenter.Bottom)) / 2.0;
		return rcToCenter.OffsetRect(0.0, dy);
	}

	private static Rect MoveNearRect(Rect rcWindow, Rect rcWindowToTract, PlacementMode nSide)
	{
		Point offset = default(Point);
		switch (nSide)
		{
		case PlacementMode.Left:
			offset.Y = 0.0;
			offset.X = rcWindowToTract.Left - rcWindow.Right;
			break;
		case PlacementMode.Right:
			offset.Y = 0.0;
			offset.X = rcWindowToTract.Right - rcWindow.Left;
			break;
		case PlacementMode.Top:
			offset.Y = rcWindowToTract.Top - rcWindow.Bottom;
			offset.X = 0.0;
			break;
		case PlacementMode.Bottom:
			offset.Y = rcWindowToTract.Bottom - rcWindow.Top;
			offset.X = 0.0;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return rcWindow.OffsetRect(offset);
	}

	private static bool IsContainedInRect(Rect container, Rect rc)
	{
		bool result = true;
		if (rc.Left > rc.Right || rc.Top > rc.Bottom)
		{
			typeof(ToolTipPositioning).Log().LogError("This rect is ill formed.", false);
			result = false;
		}
		if (rc.Left < container.Left || rc.Right > container.Right || rc.Top < container.Top || rc.Bottom > container.Bottom)
		{
			result = false;
		}
		return result;
	}

	private static Rect MoveRectToPoint(Rect rc, double x, double y)
	{
		return rc.OffsetRect(x - rc.Left, y - rc.Top);
	}

	private static Rect ShiftRectIntoContainer(Rect container, Rect rcToShift)
	{
		Rect rect = rcToShift;
		if (rect.Left < container.Left)
		{
			rect = MoveRectToPoint(rect, container.Left, rect.Top);
		}
		else if (rect.Right > container.Right)
		{
			rect = MoveRectToPoint(rect, container.Right - rect.Width, rect.Top);
		}
		if (rect.Top < container.Top)
		{
			rect = MoveRectToPoint(rect, rect.Left, container.Top);
		}
		else if (rect.Bottom > container.Bottom)
		{
			rect = MoveRectToPoint(rect, rect.Left, container.Bottom - rect.Height);
		}
		return rect;
	}

	private static bool CanPositionRelativeOnSide(Rect windowToTrack, Rect rcWindow, PlacementMode nSide, Rect constraint)
	{
		double num = 0.0;
		double num2 = 0.0;
		switch (nSide)
		{
		case PlacementMode.Left:
			num = windowToTrack.Left - constraint.Left;
			num2 = constraint.Height;
			break;
		case PlacementMode.Top:
			num = constraint.Width;
			num2 = windowToTrack.Top - constraint.Top;
			break;
		case PlacementMode.Right:
			num = constraint.Right - windowToTrack.Right;
			num2 = constraint.Height;
			break;
		case PlacementMode.Bottom:
			num = constraint.Width;
			num2 = constraint.Bottom - windowToTrack.Bottom;
			break;
		}
		if (num >= rcWindow.Width)
		{
			return num2 >= rcWindow.Height;
		}
		return false;
	}

	private static Rect PositionRelativeOnSide(Rect windowToTrack, Rect rcWindow, PlacementMode nSide, Rect constraint)
	{
		Rect rect = default(Rect);
		switch (nSide)
		{
		case PlacementMode.Right:
		case PlacementMode.Left:
			rect = VerticallyCenterRect(windowToTrack, MoveNearRect(rcWindow, windowToTrack, nSide));
			break;
		case PlacementMode.Bottom:
		case PlacementMode.Top:
			rect = HorizontallyCenterRect(windowToTrack, MoveNearRect(rcWindow, windowToTrack, nSide));
			break;
		}
		if (!IsContainedInRect(constraint, rect))
		{
			rect = ShiftRectIntoContainer(constraint, rect);
		}
		return rect;
	}

	internal static (Rect rect, PlacementMode sideChosen) QueryRelativePosition(Rect constraint, Size sizeFlyout, Rect rcDockTo, PlacementMode nSidePreferred)
	{
		Rect rect = constraint;
		PlacementMode placementMode = PlacementMode.Top;
		Size size = ConstrainSize(sizeFlyout, rect.Width, rect.Height);
		Rect rect2 = new Rect(0.0, 0.0, size.Width, size.Height);
		Rect rcToShift = default(Rect);
		if (CanPositionRelativeOnSide(rcDockTo, rect2, nSidePreferred, rect))
		{
			rcToShift = PositionRelativeOnSide(rcDockTo, rect2, nSidePreferred, rect);
			placementMode = nSidePreferred;
		}
		else
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			PlacementMode placementMode2 = PlacementMode.Top;
			switch (nSidePreferred)
			{
			case PlacementMode.Top:
				placementMode2 = PlacementMode.Bottom;
				flag2 = true;
				flag3 = true;
				break;
			case PlacementMode.Bottom:
				placementMode2 = PlacementMode.Top;
				flag2 = true;
				flag3 = true;
				break;
			case PlacementMode.Left:
				placementMode2 = PlacementMode.Right;
				flag = true;
				break;
			case PlacementMode.Right:
				placementMode2 = PlacementMode.Left;
				flag = true;
				break;
			}
			if (CanPositionRelativeOnSide(rcDockTo, rect2, placementMode2, rect))
			{
				rcToShift = PositionRelativeOnSide(rcDockTo, rect2, placementMode2, rect);
				placementMode = placementMode2;
			}
			else
			{
				PlacementMode placementMode3;
				if (nSidePreferred == PlacementMode.Left || nSidePreferred == PlacementMode.Right)
				{
					placementMode3 = PlacementMode.Top;
					flag2 = true;
				}
				else if (IsLefthandedUser())
				{
					placementMode3 = PlacementMode.Right;
				}
				else
				{
					placementMode3 = PlacementMode.Left;
					flag = true;
				}
				if (CanPositionRelativeOnSide(rcDockTo, rect2, placementMode3, rect))
				{
					rcToShift = PositionRelativeOnSide(rcDockTo, rect2, placementMode3, rect);
					placementMode = placementMode3;
				}
				else
				{
					PlacementMode placementMode4 = ((!flag2) ? PlacementMode.Top : ((!flag3) ? PlacementMode.Bottom : (flag ? PlacementMode.Right : PlacementMode.Left)));
					if (CanPositionRelativeOnSide(rcDockTo, rect2, placementMode4, rect))
					{
						rcToShift = PositionRelativeOnSide(rcDockTo, rect2, placementMode4, rect);
						placementMode = placementMode4;
					}
					else
					{
						switch (nSidePreferred)
						{
						case PlacementMode.Left:
						{
							Point point4 = default(Point);
							point4.X = rect.Left;
							point4.Y = rect2.Top;
							rcToShift = MoveRectToPoint(rect2, point4.X, point4.Y);
							rcToShift = VerticallyCenterRect(rcDockTo, rcToShift);
							break;
						}
						case PlacementMode.Top:
						{
							Point point3 = default(Point);
							point3.X = rect2.Left;
							point3.Y = rect.Top;
							rcToShift = MoveRectToPoint(rect2, point3.X, point3.Y);
							rcToShift = HorizontallyCenterRect(rcDockTo, rcToShift);
							break;
						}
						case PlacementMode.Right:
						{
							Point point2 = default(Point);
							point2.X = rect.Right - rect2.Width;
							point2.Y = rect2.Top;
							rcToShift = MoveRectToPoint(rect2, point2.X, point2.Y);
							rcToShift = VerticallyCenterRect(rcDockTo, rcToShift);
							break;
						}
						case PlacementMode.Bottom:
						{
							Point point = default(Point);
							point.X = rect2.Left;
							point.Y = rect.Bottom - rect2.Height;
							rcToShift = MoveRectToPoint(rect2, point.X, point.Y);
							rcToShift = HorizontallyCenterRect(rcDockTo, rcToShift);
							break;
						}
						}
						rcToShift = ShiftRectIntoContainer(rect, rcToShift);
						placementMode = nSidePreferred;
					}
				}
			}
		}
		return (rcToShift, placementMode);
	}
}
