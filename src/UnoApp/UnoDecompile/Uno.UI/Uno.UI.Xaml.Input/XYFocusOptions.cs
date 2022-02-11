using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal struct XYFocusOptions
{
	public static XYFocusOptions Default
	{
		get
		{
			XYFocusOptions result = default(XYFocusOptions);
			result.IgnoreClipping = true;
			result.ConsiderEngagement = true;
			result.UpdateManifold = true;
			return result;
		}
	}

	internal DependencyObject? SearchRoot { get; set; }

	internal Rect? ExclusionRect { get; set; }

	internal Rect FocusedElementBounds { get; set; }

	internal Rect? FocusHintRectangle { get; set; }

	internal bool IgnoreClipping { get; set; }

	internal bool IgnoreCone { get; set; }

	internal bool ShouldConsiderXYFocusKeyboardNavigation { get; set; }

	internal bool ConsiderEngagement { get; set; }

	internal bool UpdateManifold { get; set; }

	internal XYFocusNavigationStrategyOverride NavigationStrategyOverride { get; set; }

	internal bool UpdateManifoldsFromFocusHintRectangle { get; set; }

	internal bool IgnoreOcclusivity { get; set; }

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 23 + (SearchRoot?.GetHashCode() ?? 0);
		num = num * 23 + NavigationStrategyOverride.GetHashCode();
		num = num * 23 + IgnoreClipping.GetHashCode();
		num = num * 23 + IgnoreCone.GetHashCode();
		num = num * 23 + (ExclusionRect?.GetHashCode() ?? 0);
		num = num * 23 + (FocusHintRectangle?.GetHashCode() ?? 0);
		num = num * 23 + IgnoreOcclusivity.GetHashCode();
		return num * 23 + UpdateManifoldsFromFocusHintRectangle.GetHashCode();
	}
}
