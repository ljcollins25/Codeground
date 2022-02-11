using System.Collections.Generic;
using Uno.UI;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class DisplayRegionHelper
{
	private bool m_simulateDisplayRegions;

	private TwoPaneViewMode m_simulateMode;

	private static readonly Rect m_simulateWide0 = new Rect(0.0, 0.0, 300.0, 400.0);

	private static readonly Rect m_simulateWide1 = new Rect(312.0, 0.0, 300.0, 400.0);

	private static readonly Rect m_simulateTall0 = new Rect(0.0, 0.0, 400.0, 300.0);

	private static readonly Rect m_simulateTall1 = new Rect(0.0, 312.0, 400.0, 300.0);

	internal static DisplayRegionHelperInfo GetRegionInfo()
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		DisplayRegionHelperInfo result = new DisplayRegionHelperInfo();
		result.Mode = TwoPaneViewMode.SinglePane;
		if (displayRegionHelperInstance.m_simulateDisplayRegions)
		{
			if (displayRegionHelperInstance.m_simulateMode == TwoPaneViewMode.Wide)
			{
				result.Regions[0] = m_simulateWide0;
				result.Regions[1] = m_simulateWide1;
				result.Mode = TwoPaneViewMode.Wide;
			}
			else if (displayRegionHelperInstance.m_simulateMode == TwoPaneViewMode.Tall)
			{
				result.Regions[0] = m_simulateTall0;
				result.Regions[1] = m_simulateTall1;
				result.Mode = TwoPaneViewMode.Tall;
			}
			else
			{
				result.Regions[0] = m_simulateWide0;
			}
		}
		else
		{
			ApplicationView applicationView = null;
			try
			{
				applicationView = ApplicationView.GetForCurrentView();
			}
			catch
			{
			}
			if (applicationView != null && applicationView.ViewMode == ApplicationViewMode.Spanning)
			{
				IApplicationViewSpanningRects applicationViewSpanningRects = applicationView;
				if (applicationViewSpanningRects != null)
				{
					IReadOnlyList<Rect> spanningRects = applicationViewSpanningRects.GetSpanningRects();
					if (spanningRects.Count == 2)
					{
						result.Regions = new Rect[spanningRects.Count];
						result.Regions[0] = new Rect(spanningRects[0].Location.PhysicalToLogicalPixels(), spanningRects[0].Size.PhysicalToLogicalPixels());
						result.Regions[1] = new Rect(spanningRects[1].Location.PhysicalToLogicalPixels(), spanningRects[1].Size.PhysicalToLogicalPixels());
						if (result.Regions[0].X < result.Regions[1].X && result.Regions[0].Y == result.Regions[1].Y)
						{
							result.Mode = TwoPaneViewMode.Wide;
						}
						else if (result.Regions[0].X == result.Regions[1].X && result.Regions[0].Y < result.Regions[1].Y)
						{
							result.Mode = TwoPaneViewMode.Tall;
						}
					}
				}
			}
		}
		return result;
	}

	internal static UIElement WindowElement()
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		if (displayRegionHelperInstance.m_simulateDisplayRegions)
		{
			UIElement result = null;
			if (Window.Current.Content is FrameworkElement parent)
			{
				result = SharedHelpers.FindInVisualTreeByName(parent, "SimulatedWindow");
			}
			return result;
		}
		return Window.Current.Content;
	}

	internal static Rect WindowRect()
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		if (displayRegionHelperInstance.m_simulateDisplayRegions)
		{
			FrameworkElement frameworkElement = WindowElement() as FrameworkElement;
			return new Rect(0.0, 0.0, (float)frameworkElement.ActualWidth, (float)frameworkElement.ActualHeight);
		}
		return Window.Current.Bounds;
	}

	internal static void SimulateDisplayRegions(bool value)
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		displayRegionHelperInstance.m_simulateDisplayRegions = value;
	}

	internal static bool SimulateDisplayRegions()
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		return displayRegionHelperInstance.m_simulateDisplayRegions;
	}

	internal static void SimulateMode(TwoPaneViewMode value)
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		displayRegionHelperInstance.m_simulateMode = value;
	}

	internal static TwoPaneViewMode SimulateMode()
	{
		DisplayRegionHelper displayRegionHelperInstance = LifetimeHandler.GetDisplayRegionHelperInstance();
		return displayRegionHelperInstance.m_simulateMode;
	}
}
