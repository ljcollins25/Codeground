using System;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public abstract class MenuFlyoutItemBase : Control
{
	private WeakReference m_wrParentMenuFlyoutPresenter;

	public MenuFlyoutItemBase()
	{
	}

	internal MenuFlyoutPresenter GetParentMenuFlyoutPresenter()
	{
		return m_wrParentMenuFlyoutPresenter?.Target as MenuFlyoutPresenter;
	}

	internal void SetParentMenuFlyoutPresenter(MenuFlyoutPresenter pParentMenuFlyoutPresenter)
	{
		m_wrParentMenuFlyoutPresenter = new WeakReference(pParentMenuFlyoutPresenter);
	}

	internal bool GetShouldBeNarrow()
	{
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		bool result = false;
		if (parentMenuFlyoutPresenter != null)
		{
			MenuFlyout parentMenuFlyout = parentMenuFlyoutPresenter.GetParentMenuFlyout();
			if (parentMenuFlyout != null)
			{
				result = parentMenuFlyout.InputDeviceTypeUsedToOpen == FocusInputDeviceKind.Mouse || parentMenuFlyout.InputDeviceTypeUsedToOpen == FocusInputDeviceKind.Pen || parentMenuFlyout.InputDeviceTypeUsedToOpen == FocusInputDeviceKind.Keyboard;
			}
		}
		return result;
	}
}
