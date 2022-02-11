using Uno.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core;

internal class InputManager
{
	private ContentRoot _contentRoot;

	internal InputDeviceType LastInputDeviceType { get; set; }

	internal FocusInputDeviceKind LastFocusInputDeviceKind { get; set; }

	public InputManager(ContentRoot contentRoot)
	{
		_contentRoot = contentRoot;
	}

	internal bool ShouldRequestFocusSound()
	{
		return false;
	}

	internal void NotifyFocusChanged(DependencyObject? focusedElement, bool bringIntoView, bool animateIfBringIntoView)
	{
	}

	internal bool LastInputWasNonFocusNavigationKeyFromSIP()
	{
		return false;
	}
}
