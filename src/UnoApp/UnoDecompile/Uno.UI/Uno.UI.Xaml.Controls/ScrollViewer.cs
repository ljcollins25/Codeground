using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Xaml.Controls;

public static class ScrollViewer
{
	public static readonly DependencyProperty ShouldFallBackToNativeScrollBarsProperty = DependencyProperty.RegisterAttached("ShouldFallBackToNativeScrollBars", typeof(bool), typeof(ScrollViewer), new FrameworkPropertyMetadata(true));

	public static DependencyProperty UpdatesModeProperty { get; } = DependencyProperty.RegisterAttached("UpdatesMode", typeof(ScrollViewerUpdatesMode), typeof(ScrollViewer), new FrameworkPropertyMetadata(FeatureConfiguration.ScrollViewer.DefaultUpdatesMode, delegate(DependencyObject snd, DependencyPropertyChangedEventArgs e)
	{
		((Windows.UI.Xaml.Controls.ScrollViewer)snd).UpdatesMode = (ScrollViewerUpdatesMode)e.NewValue;
	}));


	public static void SetUpdatesMode(Windows.UI.Xaml.Controls.ScrollViewer scrollViewer, ScrollViewerUpdatesMode mode)
	{
		scrollViewer.SetValue(UpdatesModeProperty, mode);
	}

	public static ScrollViewerUpdatesMode GetUpdatesMode(Windows.UI.Xaml.Controls.ScrollViewer scrollViewer)
	{
		return (ScrollViewerUpdatesMode)scrollViewer.GetValue(UpdatesModeProperty);
	}

	public static bool GetShouldFallBackToNativeScrollBars(Windows.UI.Xaml.Controls.ScrollViewer scrollViewer)
	{
		return (bool)scrollViewer.GetValue(ShouldFallBackToNativeScrollBarsProperty);
	}

	public static void SetShouldFallBackToNativeScrollBars(Windows.UI.Xaml.Controls.ScrollViewer scrollViewer, bool value)
	{
		scrollViewer.SetValue(ShouldFallBackToNativeScrollBarsProperty, value);
	}
}
