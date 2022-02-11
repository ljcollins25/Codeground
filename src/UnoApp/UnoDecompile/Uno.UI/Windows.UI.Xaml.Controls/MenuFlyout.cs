using System;
using System.Collections.Generic;
using Uno.Extensions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class MenuFlyout : FlyoutBase, IMenu
{
	private readonly ObservableVector<MenuFlyoutItemBase> m_tpItems;

	private WeakReference m_wrParentMenu;

	private bool m_openWindowed = true;

	private bool m_openingWindowedInProgress;

	internal FocusInputDeviceKind InputDeviceTypeUsedToOpen { get; set; }

	public IList<MenuFlyoutItemBase> Items
	{
		get
		{
			return (IList<MenuFlyoutItemBase>)GetValue(ItemsProperty);
		}
		private set
		{
			SetValue(ItemsProperty, value);
		}
	}

	public static DependencyProperty ItemsProperty { get; } = DependencyProperty.Register("Items", typeof(IList<MenuFlyoutItemBase>), typeof(MenuFlyout), new FrameworkPropertyMetadata((object)null));


	public Style MenuFlyoutPresenterStyle
	{
		get
		{
			return (Style)GetValue(MenuFlyoutPresenterStyleProperty);
		}
		set
		{
			SetValue(MenuFlyoutPresenterStyleProperty, value);
		}
	}

	public static DependencyProperty MenuFlyoutPresenterStyleProperty { get; } = DependencyProperty.Register("MenuFlyoutPresenterStyle", typeof(Style), typeof(MenuFlyout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as MenuFlyout).OnPropertyChanged2(s, e);
	}));


	IMenu IMenu.ParentMenu
	{
		get
		{
			return m_wrParentMenu?.Target as IMenu;
		}
		set
		{
			m_wrParentMenu = new WeakReference(value);
			base.IsLightDismissOverlayEnabled = value == null;
			Control presenter = GetPresenter();
			if (presenter is MenuFlyoutPresenter menuFlyoutPresenter)
			{
				menuFlyoutPresenter.IsSubPresenter = value != null;
			}
		}
	}

	public MenuFlyout()
	{
		m_isPositionedAtPoint = true;
		InputDeviceTypeUsedToOpen = FocusInputDeviceKind.None;
		m_tpItems = new ObservableVector<MenuFlyoutItemBase>();
		Items = m_tpItems;
	}

	protected internal override void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		base.OnDataContextChanged(e);
		SetFlyoutItemsDataContext();
	}

	private void SetFlyoutItemsDataContext()
	{
		Items?.ForEach(delegate(MenuFlyoutItemBase item)
		{
			item?.SetValue(UIElement.DataContextProperty, base.DataContext, DependencyPropertyValuePrecedences.Inheritance);
		});
	}

	public void ShowAt(UIElement targetElement, Point point)
	{
		ShowAtCore((FrameworkElement)targetElement, new FlyoutShowOptions
		{
			Position = point
		});
	}

	private void OnPropertyChanged2(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		if (e.Property == MenuFlyoutPresenterStyleProperty && GetPresenter() != null)
		{
			SetPresenterStyle(GetPresenter(), e.NewValue as Style);
		}
	}

	protected override Control CreatePresenter()
	{
		MenuFlyoutPresenter menuFlyoutPresenter = new MenuFlyoutPresenter();
		menuFlyoutPresenter.SetParentMenuFlyout(this);
		Style menuFlyoutPresenterStyle = MenuFlyoutPresenterStyle;
		SetPresenterStyle(menuFlyoutPresenter, menuFlyoutPresenterStyle);
		return menuFlyoutPresenter;
	}

	private protected override void ShowAtCore(FrameworkElement pPlacementTarget, FlyoutShowOptions showOptions)
	{
		m_openWindowed = false;
		base.ShowAtCore(pPlacementTarget, showOptions);
		if (!m_openWindowed)
		{
			m_openWindowed = true;
		}
		CacheInputDeviceTypeUsedToOpen(pPlacementTarget);
	}

	private protected override void OnOpening()
	{
		Control presenter = GetPresenter();
		if (presenter is MenuFlyoutPresenter menuFlyoutPresenter)
		{
			IMenu parentMenu = ((IMenu)this).ParentMenu;
			object owningMenu;
			if (parentMenu == null)
			{
				owningMenu = this;
			}
			else
			{
				owningMenu = parentMenu;
			}
			((IMenuPresenter)menuFlyoutPresenter).OwningMenu = (IMenu)owningMenu;
			menuFlyoutPresenter.UpdateTemplateSettings();
			menuFlyoutPresenter.ItemsSource = m_tpItems;
			AutomationPeer.RaiseEventIfListener(menuFlyoutPresenter, AutomationEvents.MenuOpened);
		}
	}

	private protected override void OnClosing(ref bool cancel)
	{
		base.OnClosing(ref cancel);
		if (!cancel)
		{
			CloseSubMenu();
		}
	}

	private protected override void OnClosed()
	{
		base.OnClosed();
		CloseSubMenu();
		AutomationPeer.RaiseEventIfListener(GetPresenter(), AutomationEvents.MenuClosed);
		((MenuFlyoutPresenter)GetPresenter()).m_iFocusedIndex = -1;
		((ItemsControl)GetPresenter()).ItemsSource = null;
	}

	private void CloseSubMenu()
	{
		((IMenuPresenter)(MenuFlyoutPresenter)GetPresenter())?.SubPresenter?.CloseSubMenu();
	}

	private void PreparePopupTheme(Popup pPopup, MajorPlacementMode placementMode, FrameworkElement pPlacementTarget)
	{
		bool flag = false;
		if (base.AreOpenCloseAnimationsEnabled)
		{
			double num = 0.0;
			num = GetPresenter().ActualHeight;
			AnimationDirection animationDirection = ((placementMode != 0) ? AnimationDirection.Top : AnimationDirection.Bottom);
		}
	}

	private void AutoAdjustPlacement(MajorPlacementMode pPlacement)
	{
	}

	private void ShowAtImpl(UIElement pTargetElement, Point targetPoint)
	{
		FlyoutShowOptions flyoutShowOptions = new FlyoutShowOptions();
		flyoutShowOptions.Position = targetPoint;
		try
		{
			m_openingWindowedInProgress = true;
			ShowAt(pTargetElement, flyoutShowOptions);
		}
		finally
		{
			m_openingWindowedInProgress = false;
		}
	}

	private void CacheInputDeviceTypeUsedToOpen(UIElement pTargetElement)
	{
	}

	private void ShowAtStatic(MenuFlyout pCoreMenuFlyout, UIElement pCoreTarget, Point point)
	{
		pCoreMenuFlyout.ShowAtImpl(pCoreTarget as FrameworkElement, point);
	}

	private void OnProcessKeyboardAcceleratorsImpl(ProcessKeyboardAcceleratorEventArgs pArgs)
	{
		if (m_tpItems != null)
		{
			int count = m_tpItems.Count;
			for (int i = 0; i < count; i++)
			{
				MenuFlyoutItemBase menuFlyoutItemBase = m_tpItems[i];
				menuFlyoutItemBase.TryInvokeKeyboardAccelerator(pArgs);
			}
		}
	}

	void IMenu.Close()
	{
		Hide();
	}

	private bool IsWindowedPopup()
	{
		return false;
	}
}
