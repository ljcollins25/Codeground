using System;
using System.Collections.Generic;
using Uno.Disposables;
using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class MenuFlyoutSubItem : MenuFlyoutItemBase, ISubMenuOwner
{
	private Popup m_tpPopup;

	private Control m_tpPresenter;

	private IDisposable m_epPresenterSizeChangedHandler;

	private CascadingMenuHelper m_menuHelper;

	private WeakReference m_wrParentOwner;

	private DependencyObjectCollection<MenuFlyoutItemBase> m_tpItems;

	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	public IList<MenuFlyoutItemBase> Items => m_tpItems;

	public IconElement Icon
	{
		get
		{
			return (IconElement)GetValue(IconProperty);
		}
		set
		{
			SetValue(IconProperty, value);
		}
	}

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(MenuFlyoutSubItem), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty IconProperty { get; } = DependencyProperty.Register("Icon", typeof(IconElement), typeof(MenuFlyoutSubItem), new FrameworkPropertyMetadata((object)null));


	private bool IsOpen => m_tpPopup?.IsOpen ?? false;

	bool ISubMenuOwner.IsSubMenuOpen => IsOpen;

	ISubMenuOwner ISubMenuOwner.ParentOwner
	{
		get
		{
			return m_wrParentOwner?.Target as ISubMenuOwner;
		}
		set
		{
			m_wrParentOwner = new WeakReference(value);
		}
	}

	bool ISubMenuOwner.IsSubMenuPositionedAbsolutely => true;

	public MenuFlyoutSubItem()
	{
		PrepareState();
		base.DefaultStyleKey = typeof(MenuFlyoutSubItem);
	}

	private void PrepareState()
	{
		m_tpItems = new DependencyObjectCollection<MenuFlyoutItemBase>(this);
		m_menuHelper = new CascadingMenuHelper();
		m_menuHelper.Initialize(this);
	}

	private void DisconnectFrameworkPeerCore()
	{
	}

	protected override void OnApplyTemplate()
	{
		m_menuHelper.OnApplyTemplate();
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs args)
	{
		base.OnPointerEntered(args);
		UpdateParentOwner(null);
		m_menuHelper.OnPointerEntered(args);
	}

	protected override void OnPointerExited(PointerRoutedEventArgs args)
	{
		base.OnPointerExited(args);
		bool parentIsSubMenu = false;
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			parentIsSubMenu = parentMenuFlyoutPresenter.IsSubPresenter;
		}
		m_menuHelper.OnPointerExited(args, parentIsSubMenu);
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs args)
	{
		base.OnPointerPressed(args);
		m_menuHelper.OnPointerPressed(args);
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs args)
	{
		base.OnPointerReleased(args);
		m_menuHelper.OnPointerReleased(args);
	}

	protected override void OnGotFocus(RoutedEventArgs args)
	{
		base.OnGotFocus(args);
		m_menuHelper.OnGotFocus(args);
	}

	protected override void OnLostFocus(RoutedEventArgs args)
	{
		base.OnLostFocus(args);
		m_menuHelper.OnLostFocus(args);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs args)
	{
		base.OnKeyDown(args);
		bool handled = args.Handled;
		bool handled2 = false;
		if (!handled)
		{
			MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
			if (parentMenuFlyoutPresenter != null)
			{
				VirtualKey key = args.Key;
				if (key == VirtualKey.Down || key == VirtualKey.Up)
				{
					parentMenuFlyoutPresenter.HandleUpOrDownKey(key == VirtualKey.Down);
					UpdateVisualState();
					handled2 = true;
				}
			}
		}
		m_menuHelper.OnKeyDown(args);
		args.Handled = handled2;
	}

	protected override void OnKeyUp(KeyRoutedEventArgs args)
	{
		base.OnKeyUp(args);
		m_menuHelper.OnKeyUp(args);
	}

	private void EnsurePopupAndPresenter()
	{
		if (m_tpPopup == null)
		{
			MenuFlyoutPresenter menuFlyoutPresenter = null;
			Popup popup = new Popup();
			popup.IsSubMenu = true;
			popup.IsLightDismissEnabled = false;
			menuFlyoutPresenter = GetParentMenuFlyoutPresenter();
			Control control = CreateSubPresenter();
			UIElement uIElement = control;
			if (menuFlyoutPresenter != null)
			{
				int depth = menuFlyoutPresenter.GetDepth();
				(control as MenuFlyoutPresenter).SetDepth(depth + 1);
			}
			popup.Child = uIElement as FrameworkElement;
			m_tpPresenter = control;
			m_tpPopup = popup;
			((ItemsControl)m_tpPresenter).ItemsSource = m_tpItems;
			FrameworkElement spPresenterAsFE = control;
			spPresenterAsFE.SizeChanged += OnPresenterSizeChanged;
			m_epPresenterSizeChangedHandler = Disposable.Create(delegate
			{
				spPresenterAsFE.SizeChanged -= OnPresenterSizeChanged;
			});
			m_menuHelper.SetSubMenuPresenter(control);
		}
	}

	private void ForwardPresenterProperties(MenuFlyout pOwnerMenuFlyout, MenuFlyoutPresenter pParentMenuFlyoutPresenter, MenuFlyoutPresenter pSubMenuFlyoutPresenter)
	{
		Style menuFlyoutPresenterStyle = pOwnerMenuFlyout.MenuFlyoutPresenterStyle;
		if (menuFlyoutPresenterStyle != null)
		{
			pSubMenuFlyoutPresenter.Style = menuFlyoutPresenterStyle;
		}
		else
		{
			pSubMenuFlyoutPresenter.ClearValue(FrameworkElement.StyleProperty);
		}
		ElementTheme elementTheme = (pSubMenuFlyoutPresenter.RequestedTheme = pParentMenuFlyoutPresenter.RequestedTheme);
		object obj = (pSubMenuFlyoutPresenter.DataContext = pParentMenuFlyoutPresenter.DataContext);
		FlowDirection flowDirection2 = (pSubMenuFlyoutPresenter.FlowDirection = base.FlowDirection);
		FrameworkElement tpPopup = m_tpPopup;
		tpPopup.FlowDirection = flowDirection2;
		pSubMenuFlyoutPresenter.Language = pParentMenuFlyoutPresenter.Language;
		bool flag = (pSubMenuFlyoutPresenter.IsTextScaleFactorEnabledInternal = pParentMenuFlyoutPresenter.IsTextScaleFactorEnabledInternal);
		ElementSoundMode elementSoundMode = (pSubMenuFlyoutPresenter.ElementSoundMode = ElementSoundPlayerService.GetEffectiveSoundMode(this));
	}

	private void EnsureCloseExistingSubItems()
	{
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter == null)
		{
			return;
		}
		IMenuPresenter subPresenter = ((IMenuPresenter)parentMenuFlyoutPresenter).SubPresenter;
		if (subPresenter != null)
		{
			ISubMenuOwner owner = subPresenter.Owner;
			if (owner != null && owner != this)
			{
				subPresenter.CloseSubMenu();
			}
		}
	}

	private Control CreateSubPresenter()
	{
		MenuFlyoutPresenter menuFlyoutPresenter = new MenuFlyoutPresenter();
		menuFlyoutPresenter.IsSubPresenter = true;
		((IMenuPresenter)menuFlyoutPresenter).Owner = this;
		return menuFlyoutPresenter;
	}

	private void UpdateParentOwner(MenuFlyoutPresenter parentMenuFlyoutPresenter)
	{
		MenuFlyoutPresenter menuFlyoutPresenter = parentMenuFlyoutPresenter;
		if (menuFlyoutPresenter == null)
		{
			menuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		}
		if (menuFlyoutPresenter != null)
		{
			ISubMenuOwner owner = ((IMenuPresenter)menuFlyoutPresenter).Owner;
			if (owner != null)
			{
				((ISubMenuOwner)this).ParentOwner = owner;
			}
		}
	}

	private void SetIsOpen(bool isOpen)
	{
		bool flag = false;
		flag = m_tpPopup.IsOpen;
		if (isOpen == flag)
		{
			return;
		}
		(m_tpPresenter as IMenuPresenter).Owner = (isOpen ? this : null);
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			((IMenuPresenter)parentMenuFlyoutPresenter).SubPresenter = (isOpen ? (m_tpPresenter as MenuFlyoutPresenter) : null);
			IMenu owningMenu = ((IMenuPresenter)parentMenuFlyoutPresenter).OwningMenu;
			if (owningMenu != null)
			{
				(m_tpPresenter as IMenuPresenter).OwningMenu = (isOpen ? owningMenu : null);
			}
			UpdateParentOwner(parentMenuFlyoutPresenter);
		}
		m_tpPopup.IsOpen = isOpen;
		if (isOpen)
		{
			m_tpPresenter.Focus(FocusState.Programmatic);
		}
		else
		{
			Focus(FocusState.Programmatic);
		}
		UpdateVisualState();
	}

	private void Open()
	{
		m_menuHelper.OpenSubMenu();
	}

	private void Close()
	{
		m_menuHelper.CloseSubMenu();
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool isEnabled = base.IsEnabled;
		FocusState focusState = base.FocusState;
		bool shouldBeNarrow = GetShouldBeNarrow();
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			flag = parentMenuFlyoutPresenter.GetContainsToggleItems();
			flag2 = parentMenuFlyoutPresenter.GetContainsIconItems();
		}
		if (m_tpPopup != null)
		{
			flag3 = m_tpPopup.IsOpen;
		}
		if (!isEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", bUseTransitions);
		}
		else if (flag3)
		{
			VisualStateManager.GoToState(this, "SubMenuOpened", bUseTransitions);
		}
		else if (m_menuHelper.IsPressed)
		{
			VisualStateManager.GoToState(this, "Pressed", bUseTransitions);
		}
		else if (m_menuHelper.IsPointerOver)
		{
			VisualStateManager.GoToState(this, "PointerOver", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", bUseTransitions);
		}
		if (focusState != FocusState.Unfocused && isEnabled)
		{
			if (FocusState.Pointer == focusState)
			{
				VisualStateManager.GoToState(this, "PointerFocused", bUseTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, "Focused", bUseTransitions);
			}
		}
		else
		{
			VisualStateManager.GoToState(this, "Unfocused", bUseTransitions);
		}
		if (flag && flag2)
		{
			VisualStateManager.GoToState(this, "CheckAndIconPlaceholder", bUseTransitions);
		}
		else if (flag)
		{
			VisualStateManager.GoToState(this, "CheckPlaceholder", bUseTransitions);
		}
		else if (flag2)
		{
			VisualStateManager.GoToState(this, "IconPlaceholder", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "NoPlaceholder", bUseTransitions);
		}
		if (shouldBeNarrow)
		{
			VisualStateManager.GoToState(this, "NarrowPadding", bUseTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "DefaultPadding", bUseTransitions);
		}
	}

	private void OnPresenterSizeChanged(object pSender, SizeChangedEventArgs args)
	{
		m_menuHelper.OnPresenterSizeChanged(pSender, args, m_tpPopup);
	}

	private void ClearStateFlags()
	{
		m_menuHelper.ClearStateFlags();
	}

	private void OnIsEnabledChanged()
	{
		m_menuHelper.OnIsEnabledChanged();
	}

	private void OnVisibilityChanged()
	{
		m_menuHelper.OnVisibilityChanged();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return null;
	}

	private string GetPlainText()
	{
		return Text;
	}

	void ISubMenuOwner.PrepareSubMenu()
	{
		EnsurePopupAndPresenter();
	}

	void ISubMenuOwner.OpenSubMenu(Point position)
	{
		EnsurePopupAndPresenter();
		EnsureCloseExistingSubItems();
		MenuFlyoutPresenter parentMenuFlyoutPresenter = GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			IMenu owningMenu = ((IMenuPresenter)parentMenuFlyoutPresenter).OwningMenu;
			(m_tpPresenter as IMenuPresenter).OwningMenu = owningMenu;
			MenuFlyout parentMenuFlyout = parentMenuFlyoutPresenter.GetParentMenuFlyout();
			if (parentMenuFlyout != null)
			{
				(m_tpPresenter as MenuFlyoutPresenter).SetParentMenuFlyout(parentMenuFlyout);
				(m_tpPresenter as MenuFlyoutPresenter).UpdateTemplateSettings();
				ForwardPresenterProperties(parentMenuFlyout, parentMenuFlyoutPresenter, m_tpPresenter as MenuFlyoutPresenter);
			}
		}
		m_tpPopup.HorizontalOffset = position.X;
		m_tpPopup.VerticalOffset = position.Y;
		SetIsOpen(isOpen: true);
	}

	void ISubMenuOwner.PositionSubMenu(Point position)
	{
		if (position.X != double.NegativeInfinity)
		{
			m_tpPopup.HorizontalOffset = position.X;
		}
		if (position.Y != double.NegativeInfinity)
		{
			m_tpPopup.VerticalOffset = position.Y;
		}
	}

	void ISubMenuOwner.ClosePeerSubMenus()
	{
		EnsureCloseExistingSubItems();
	}

	void ISubMenuOwner.CloseSubMenu()
	{
		SetIsOpen(isOpen: false);
	}

	void ISubMenuOwner.CloseSubMenuTree()
	{
		m_menuHelper.CloseChildSubMenus();
	}

	void ISubMenuOwner.DelayCloseSubMenu()
	{
		m_menuHelper.DelayCloseSubMenu();
	}

	void ISubMenuOwner.CancelCloseSubMenu()
	{
		m_menuHelper.CancelCloseSubMenu();
	}

	void ISubMenuOwner.RaiseAutomationPeerExpandCollapse(bool isOpen)
	{
	}
}
