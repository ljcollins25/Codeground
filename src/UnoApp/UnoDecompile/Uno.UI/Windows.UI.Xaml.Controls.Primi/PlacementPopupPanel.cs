using System;
using System.Collections.Generic;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace Windows.UI.Xaml.Controls.Primitives;

internal abstract class PlacementPopupPanel : PopupPanel
{
	private static readonly Dictionary<FlyoutBase.MajorPlacementMode, Memory<FlyoutBase.MajorPlacementMode>> PlacementsToTry = new Dictionary<FlyoutBase.MajorPlacementMode, Memory<FlyoutBase.MajorPlacementMode>>
	{
		{
			FlyoutBase.MajorPlacementMode.Top,
			new FlyoutBase.MajorPlacementMode[5]
			{
				FlyoutBase.MajorPlacementMode.Top,
				FlyoutBase.MajorPlacementMode.Bottom,
				FlyoutBase.MajorPlacementMode.Left,
				FlyoutBase.MajorPlacementMode.Right,
				FlyoutBase.MajorPlacementMode.Top
			}
		},
		{
			FlyoutBase.MajorPlacementMode.Bottom,
			new FlyoutBase.MajorPlacementMode[5]
			{
				FlyoutBase.MajorPlacementMode.Bottom,
				FlyoutBase.MajorPlacementMode.Top,
				FlyoutBase.MajorPlacementMode.Left,
				FlyoutBase.MajorPlacementMode.Right,
				FlyoutBase.MajorPlacementMode.Bottom
			}
		},
		{
			FlyoutBase.MajorPlacementMode.Left,
			new FlyoutBase.MajorPlacementMode[5]
			{
				FlyoutBase.MajorPlacementMode.Left,
				FlyoutBase.MajorPlacementMode.Right,
				FlyoutBase.MajorPlacementMode.Top,
				FlyoutBase.MajorPlacementMode.Bottom,
				FlyoutBase.MajorPlacementMode.Left
			}
		},
		{
			FlyoutBase.MajorPlacementMode.Right,
			new FlyoutBase.MajorPlacementMode[5]
			{
				FlyoutBase.MajorPlacementMode.Right,
				FlyoutBase.MajorPlacementMode.Left,
				FlyoutBase.MajorPlacementMode.Top,
				FlyoutBase.MajorPlacementMode.Bottom,
				FlyoutBase.MajorPlacementMode.Right
			}
		}
	};

	protected virtual int PopupPlacementTargetMargin => 5;

	protected abstract FlyoutPlacementMode PopupPlacement { get; }

	protected abstract FrameworkElement AnchorControl { get; }

	protected abstract Point? PositionInAnchorControl { get; }

	internal virtual FlyoutBase Flyout => null;

	protected PlacementPopupPanel(Popup popup)
		: base(popup)
	{
		base.Loaded += delegate
		{
			Window.Current.SizeChanged += Current_SizeChanged;
		};
		base.Unloaded += delegate
		{
			Window.Current.SizeChanged -= Current_SizeChanged;
		};
	}

	private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
	{
		InvalidateMeasure();
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		foreach (UIElement child in base.Children)
		{
			if (child != null)
			{
				UIElement uIElement = child;
				Size desiredSize = uIElement.DesiredSize;
				Size maxSize = (uIElement as FrameworkElement).GetMaxSize();
				Rect rect = CalculateFlyoutPlacement(desiredSize, maxSize);
				FlyoutBase flyout = Flyout;
				if (flyout != null && flyout.IsTargetPositionSet)
				{
					rect = Flyout.UpdateTargetPosition(ApplicationView.GetForCurrentView().VisibleBounds, desiredSize, rect);
				}
				uIElement.Arrange(rect);
			}
		}
		return finalSize;
	}

	private Rect? GetAnchorRect()
	{
		return AnchorControl?.GetBoundsRectRelativeTo(this);
	}

	protected virtual Rect CalculateFlyoutPlacement(Size desiredSize, Size maxSize)
	{
		Rect? anchorRect = GetAnchorRect();
		if (anchorRect.HasValue)
		{
			Rect valueOrDefault = anchorRect.GetValueOrDefault();
			Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;
			desiredSize.Width = Math.Min(desiredSize.Width, visibleBounds.Width);
			desiredSize.Height = Math.Min(desiredSize.Height, visibleBounds.Height);
			FlyoutBase.MajorPlacementMode majorPlacementFromPlacement = FlyoutBase.GetMajorPlacementFromPlacement(PopupPlacement);
			Memory<FlyoutBase.MajorPlacementMode> value;
			Memory<FlyoutBase.MajorPlacementMode> memory = (PlacementsToTry.TryGetValue(majorPlacementFromPlacement, out value) ? value : ((Memory<FlyoutBase.MajorPlacementMode>)new FlyoutBase.MajorPlacementMode[1] { majorPlacementFromPlacement }));
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Calculating actual placement for preferredPlacement={majorPlacementFromPlacement} with justification={FlyoutBase.GetJustificationFromPlacementMode(PopupPlacement)} from PopupPlacement={PopupPlacement}, for desiredSize={desiredSize}, maxSize={maxSize}");
			}
			double num = valueOrDefault.Width / 2.0;
			double num2 = valueOrDefault.Height / 2.0;
			double num3 = desiredSize.Width / 2.0;
			double num4 = desiredSize.Height / 2.0;
			Rect rect = default(Rect);
			for (int i = 0; i < memory.Length; i++)
			{
				FlyoutBase.MajorPlacementMode majorPlacementMode = memory.Span[i];
				Point point;
				switch (majorPlacementMode)
				{
				case FlyoutBase.MajorPlacementMode.Top:
					point = new Point(valueOrDefault.Left + num - num3, valueOrDefault.Top - (double)PopupPlacementTargetMargin - desiredSize.Height);
					break;
				case FlyoutBase.MajorPlacementMode.Bottom:
					point = new Point(valueOrDefault.Left + num - num3, valueOrDefault.Bottom + (double)PopupPlacementTargetMargin);
					break;
				case FlyoutBase.MajorPlacementMode.Left:
					point = new Point(valueOrDefault.Left - (double)PopupPlacementTargetMargin - desiredSize.Width, valueOrDefault.Top + num2 - num4);
					break;
				case FlyoutBase.MajorPlacementMode.Right:
					point = new Point(valueOrDefault.Right + (double)PopupPlacementTargetMargin, valueOrDefault.Top + num2 - num4);
					break;
				case FlyoutBase.MajorPlacementMode.Full:
					desiredSize = visibleBounds.Size.AtMost(maxSize);
					point = new Point((visibleBounds.Width - desiredSize.Width) / 2.0, (visibleBounds.Height - desiredSize.Height) / 2.0);
					break;
				default:
					point = new Point((visibleBounds.Width - desiredSize.Width) / 2.0, (visibleBounds.Height - desiredSize.Height) / 2.0);
					break;
				}
				FlyoutBase.PreferredJustification justificationFromPlacementMode = FlyoutBase.GetJustificationFromPlacementMode(PopupPlacement);
				bool flag = true;
				if (PopupPlacement != FlyoutPlacementMode.Full)
				{
					if (IsPlacementModeVertical(majorPlacementMode))
					{
						double controlPos = point.X;
						flag = TestAndCenterAlignWithinLimits(valueOrDefault.X, valueOrDefault.Width, desiredSize.Width, visibleBounds.Left, visibleBounds.Right, justificationFromPlacementMode, ref controlPos);
						point.X = controlPos;
					}
					else
					{
						double controlPos2 = point.Y;
						flag = TestAndCenterAlignWithinLimits(valueOrDefault.Y, valueOrDefault.Height, desiredSize.Height, visibleBounds.Top, visibleBounds.Bottom, justificationFromPlacementMode, ref controlPos2);
						point.Y = controlPos2;
					}
				}
				rect = new Rect(point, desiredSize);
				if (flag && RectHelper.Union(visibleBounds, rect).Equals(visibleBounds))
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Accepted placement {majorPlacementMode} (choice {i}) with finalRect={rect} in visibleBounds={visibleBounds}");
					}
					break;
				}
			}
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug($"Calculated placement, finalRect={rect}");
			}
			return rect;
		}
		return default(Rect);
	}

	private static bool IsPlacementModeVertical(FlyoutBase.MajorPlacementMode placementMode)
	{
		if (placementMode != 0)
		{
			return placementMode == FlyoutBase.MajorPlacementMode.Bottom;
		}
		return true;
	}

	private static bool TestAndCenterAlignWithinLimits(double anchorPos, double anchorSize, double controlSize, double lowLimit, double highLimit, FlyoutBase.PreferredJustification justification, ref double controlPos)
	{
		bool result = true;
		if (anchorSize == 0.0 && typeof(PlacementPopupPanel).Log().IsEnabled(LogLevel.Warning))
		{
			typeof(PlacementPopupPanel).Log().LogWarning("anchorSize is 0");
		}
		if (controlSize == 0.0 && typeof(PlacementPopupPanel).Log().IsEnabled(LogLevel.Warning))
		{
			typeof(PlacementPopupPanel).Log().LogWarning("anchorSize is 0");
		}
		if (highLimit - lowLimit > controlSize && anchorSize >= 0.0 && controlSize >= 0.0)
		{
			switch (justification)
			{
			case FlyoutBase.PreferredJustification.Center:
				controlPos = anchorPos + 0.5 * (anchorSize - controlSize);
				break;
			case FlyoutBase.PreferredJustification.Top:
			case FlyoutBase.PreferredJustification.Left:
				controlPos = anchorPos;
				break;
			case FlyoutBase.PreferredJustification.Bottom:
			case FlyoutBase.PreferredJustification.Right:
				controlPos = anchorPos + (anchorSize - controlSize);
				break;
			default:
				throw new InvalidOperationException("Unsupported FlyoutBase.PreferredJustification");
			}
			if (controlPos < lowLimit)
			{
				controlPos = lowLimit;
			}
			else if (controlPos + controlSize > highLimit)
			{
				controlPos = highLimit - controlSize;
			}
		}
		else
		{
			controlPos = lowLimit;
			result = false;
		}
		return result;
	}
}
