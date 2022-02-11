using System;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

internal static class DateTimePickerFlyoutHelper
{
	internal static Point CalculatePlacementPosition(FrameworkElement pTargetElement, Control pFlyoutPresenter)
	{
		double num = 0.0;
		double num2 = 0.0;
		Point point = default(Point);
		FlowDirection flowDirection = FlowDirection.LeftToRight;
		if (pTargetElement == null)
		{
			throw new ArgumentNullException("pTargetElement");
		}
		if (pFlyoutPresenter == null)
		{
			throw new ArgumentNullException("pFlyoutPresenter");
		}
		DependencyObject templateChild = pFlyoutPresenter.GetTemplateChild("HighlightRect");
		if (templateChild is FrameworkElement frameworkElement)
		{
			GeneralTransform generalTransform = pFlyoutPresenter.TransformToVisual(frameworkElement);
			point = generalTransform.TransformPoint(point);
			num = frameworkElement.ActualWidth;
			num2 = frameworkElement.ActualHeight;
			point.X -= (float)(num / 2.0);
			point.Y -= (float)(num2 / 2.0);
		}
		GeneralTransform generalTransform2 = pTargetElement.TransformToVisual(null);
		point = generalTransform2.TransformPoint(point);
		num = pTargetElement.ActualWidth;
		num2 = pTargetElement.ActualHeight;
		flowDirection = pTargetElement.FlowDirection;
		point.X = ((flowDirection == FlowDirection.LeftToRight) ? (point.X + (double)(float)(num / 2.0)) : (point.X - (double)(float)(num / 2.0)));
		point.Y += (float)(num2 / 2.0);
		return point;
	}

	internal static bool ShouldInvertKeyDirection(FrameworkElement contentPanel)
	{
		FlowDirection flowDirection = FlowDirection.LeftToRight;
		if (contentPanel != null)
		{
			flowDirection = contentPanel.FlowDirection;
		}
		return flowDirection == FlowDirection.RightToLeft;
	}

	internal static bool ShouldFirstToThirdDirection(VirtualKey key, bool invert)
	{
		if (key != VirtualKey.Left || invert)
		{
			return key == VirtualKey.Right && invert;
		}
		return true;
	}

	internal static bool ShouldThirdToFirstDirection(VirtualKey key, bool invert)
	{
		if (!(key == VirtualKey.Left && invert))
		{
			if (key == VirtualKey.Right)
			{
				return !invert;
			}
			return false;
		}
		return true;
	}

	internal static void OnKeyDownImpl(KeyRoutedEventArgs pEventArgs, Control tpFirstPickerAsControl, Control tpSecondPickerAsControl, Control tpThirdPickerAsControl, FrameworkElement tpContentPanel)
	{
		bool flag = false;
		VirtualKey virtualKey = VirtualKey.None;
		if (pEventArgs.Handled)
		{
			return;
		}
		virtualKey = pEventArgs.Key;
		if (virtualKey != VirtualKey.Left && virtualKey != VirtualKey.Right)
		{
			return;
		}
		FocusState focusState = FocusState.Unfocused;
		FocusState focusState2 = FocusState.Unfocused;
		FocusState focusState3 = FocusState.Unfocused;
		bool handled = false;
		if (tpFirstPickerAsControl != null)
		{
			focusState = tpFirstPickerAsControl.FocusState;
		}
		if (tpSecondPickerAsControl != null)
		{
			focusState2 = tpSecondPickerAsControl.FocusState;
		}
		if (tpThirdPickerAsControl != null)
		{
			focusState3 = tpThirdPickerAsControl.FocusState;
		}
		bool flag2 = false;
		flag2 = ShouldInvertKeyDirection(tpContentPanel);
		bool flag3 = ShouldFirstToThirdDirection(virtualKey, flag2);
		bool flag4 = ShouldThirdToFirstDirection(virtualKey, flag2);
		if (flag3)
		{
			if (focusState2 != 0)
			{
				if (tpFirstPickerAsControl != null)
				{
					handled = tpFirstPickerAsControl.Focus(FocusState.Keyboard);
				}
			}
			else if (focusState3 != 0)
			{
				if (tpSecondPickerAsControl != null)
				{
					handled = tpSecondPickerAsControl.Focus(FocusState.Keyboard);
				}
				else if (tpFirstPickerAsControl != null)
				{
					handled = tpFirstPickerAsControl.Focus(FocusState.Keyboard);
				}
			}
		}
		else if (flag4)
		{
			if (focusState != 0)
			{
				if (tpSecondPickerAsControl != null)
				{
					handled = tpSecondPickerAsControl.Focus(FocusState.Keyboard);
				}
				else if (tpThirdPickerAsControl != null)
				{
					handled = tpThirdPickerAsControl.Focus(FocusState.Keyboard);
				}
			}
			else if (focusState2 != 0 && tpThirdPickerAsControl != null)
			{
				handled = tpThirdPickerAsControl.Focus(FocusState.Keyboard);
			}
		}
		pEventArgs.Handled = handled;
	}
}
