using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Input;

internal struct FindFocusOptions
{
	public FocusNavigationDirection Direction { get; }

	public bool QueryOnly { get; }

	public FindFocusOptions(FocusNavigationDirection direction, bool queryOnly)
	{
		Direction = direction;
		QueryOnly = queryOnly;
	}

	public FindFocusOptions(FocusNavigationDirection direction)
	{
		Direction = direction;
		QueryOnly = true;
	}
}
