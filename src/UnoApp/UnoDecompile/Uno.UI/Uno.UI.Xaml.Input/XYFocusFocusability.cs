using Windows.UI.Xaml;

namespace Uno.UI.Xaml.Input;

internal static class XYFocusFocusability
{
	internal static bool IsValidCandidate(DependencyObject element)
	{
		bool flag = FocusProperties.IsFocusable(element);
		bool flag2 = FocusProperties.IsGamepadFocusCandidate(element);
		bool flag3 = FocusProperties.IsPotentialTabStop(element);
		return flag && flag2 && flag3;
	}
}
