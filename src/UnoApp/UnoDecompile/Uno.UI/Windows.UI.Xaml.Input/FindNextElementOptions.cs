using Windows.Foundation;

namespace Windows.UI.Xaml.Input;

public class FindNextElementOptions
{
	public XYFocusNavigationStrategyOverride XYFocusNavigationStrategyOverride { get; set; }

	public DependencyObject? SearchRoot { get; set; }

	public Rect HintRect { get; set; }

	public Rect ExclusionRect { get; set; }

	internal bool IgnoreOcclusivity { get; set; }
}
