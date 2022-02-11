using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DirectUI;

internal class KeyboardNavigation
{
	public static void TranslateKeyToKeyNavigationAction(FlowDirection flowDirection, VirtualKey key, out KeyNavigationAction pNavAction, out bool pIsValidKey)
	{
		pIsValidKey = true;
		pNavAction = KeyNavigationAction.Up;
		bool flag = flowDirection == FlowDirection.RightToLeft;
		switch (key)
		{
		case VirtualKey.PageUp:
			pNavAction = KeyNavigationAction.Previous;
			break;
		case VirtualKey.PageDown:
			pNavAction = KeyNavigationAction.Next;
			break;
		case VirtualKey.Down:
			pNavAction = KeyNavigationAction.Down;
			break;
		case VirtualKey.Up:
			pNavAction = KeyNavigationAction.Up;
			break;
		case VirtualKey.Left:
			pNavAction = (flag ? KeyNavigationAction.Right : KeyNavigationAction.Left);
			break;
		case VirtualKey.Right:
			pNavAction = (flag ? KeyNavigationAction.Left : KeyNavigationAction.Right);
			break;
		case VirtualKey.Home:
			pNavAction = KeyNavigationAction.First;
			break;
		case VirtualKey.End:
			pNavAction = KeyNavigationAction.Last;
			break;
		default:
			pIsValidKey = false;
			break;
		}
	}
}
