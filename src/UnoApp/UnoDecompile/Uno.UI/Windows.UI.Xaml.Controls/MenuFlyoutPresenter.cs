using System;
using System.Collections.Generic;
using Uno;
using Uno.UI;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class MenuFlyoutPresenter : ItemsControl, IMenuPresenter
{
	internal int m_iFocusedIndex;

	private WeakReference m_wrOwningMenu;

	private WeakReference m_wrParentMenuFlyout;

	private WeakReference m_wrOwner;

	private WeakReference m_wrSubPresenter;

	private bool m_containsToggleItems;

	private bool m_containsIconItems;

	private bool m_containsItemsWithKeyboardAcceleratorText;

	private bool m_isSubPresenter;

	private int m_depth;

	private FlyoutBase.MajorPlacementMode m_mostRecentPlacement;

	private ScrollViewer m_tpScrollViewer;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDefaultShadowEnabled
	{
		get
		{
			return (bool)GetValue(IsDefaultShadowEnabledProperty);
		}
		set
		{
			SetValue(IsDefaultShadowEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDefaultShadowEnabledProperty { get; } = DependencyProperty.Register("IsDefaultShadowEnabled", typeof(bool), typeof(MenuFlyoutPresenter), new FrameworkPropertyMetadata(false));


	public MenuFlyoutPresenterTemplateSettings TemplateSettings { get; } = new MenuFlyoutPresenterTemplateSettings();


	internal bool IsSubPresenter
	{
		get
		{
			return m_isSubPresenter;
		}
		set
		{
			m_isSubPresenter = value;
		}
	}

	ISubMenuOwner IMenuPresenter.Owner
	{
		get
		{
			return m_wrOwner?.Target as ISubMenuOwner;
		}
		set
		{
			m_wrOwner = new WeakReference(value);
		}
	}

	IMenu IMenuPresenter.OwningMenu
	{
		get
		{
			return m_wrOwningMenu?.Target as IMenu;
		}
		set
		{
			m_wrOwningMenu = new WeakReference(value);
		}
	}

	IMenuPresenter IMenuPresenter.SubPresenter
	{
		get
		{
			return m_wrSubPresenter?.Target as IMenuPresenter;
		}
		set
		{
			m_wrSubPresenter = new WeakReference(value);
		}
	}

	internal bool IsTextScaleFactorEnabledInternal { get; set; }

	public MenuFlyoutPresenter()
	{
		m_iFocusedIndex = -1;
		m_containsToggleItems = false;
		m_containsIconItems = false;
		m_containsItemsWithKeyboardAcceleratorText = false;
		m_isSubPresenter = false;
		m_mostRecentPlacement = FlyoutBase.MajorPlacementMode.Bottom;
		base.DefaultStyleKey = typeof(MenuFlyoutPresenter);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		if (!pArgs.Handled)
		{
			VirtualKey key = pArgs.Key;
			pArgs.Handled = KeyPressMenuFlyoutPresenter.KeyDown(key, this);
		}
	}

	internal void HandleUpOrDownKey(bool isDownKey)
	{
		CycleFocus(isDownKey, FocusState.Keyboard);
	}

	private void CycleFocus(bool shouldCycleDown, FocusState focusState)
	{
		EnsureInitialFocusIndex();
		int num = m_iFocusedIndex;
		MenuFlyout parentMenuFlyout = GetParentMenuFlyout();
		bool shouldWrap = parentMenuFlyout == null || parentMenuFlyout.InputDeviceTypeUsedToOpen != FocusInputDeviceKind.GameController;
		uint nCount = base.Items.Size;
		int num2 = (shouldCycleDown ? 1 : (-1));
		int indexToWrap2 = m_iFocusedIndex + num2;
		if (m_iFocusedIndex == -1)
		{
			indexToWrap2 = (int)((!shouldCycleDown) ? (nCount - 1) : 0);
			num = wrapIndexIfNeeded(indexToWrap2 - num2);
		}
		else
		{
			indexToWrap2 = wrapIndexIfNeeded(indexToWrap2);
		}
		while (0 <= indexToWrap2 && indexToWrap2 < (int)nCount)
		{
			DependencyObject dependencyObject = base.Items[indexToWrap2] as DependencyObject;
			bool flag = false;
			if (dependencyObject is MenuFlyoutItem menuFlyoutItem)
			{
				flag = menuFlyoutItem.IsFocusable;
			}
			else if (dependencyObject is MenuFlyoutSubItem menuFlyoutSubItem)
			{
				flag = menuFlyoutSubItem.IsFocusable;
			}
			if (flag && dependencyObject is Control control)
			{
				control.Focus(focusState);
				m_iFocusedIndex = indexToWrap2;
				break;
			}
			if (indexToWrap2 != num)
			{
				indexToWrap2 += num2;
				indexToWrap2 = wrapIndexIfNeeded(indexToWrap2);
				continue;
			}
			break;
		}
		int wrapIndexIfNeeded(int indexToWrap)
		{
			if (shouldWrap)
			{
				if (indexToWrap < 0)
				{
					indexToWrap = (int)(nCount - 1);
				}
				else if (indexToWrap >= (int)nCount)
				{
					indexToWrap = 0;
				}
			}
			return indexToWrap;
		}
	}

	internal void HandleKeyDownLeftOrEscape()
	{
		((IMenuPresenter)this).CloseSubMenu();
	}

	protected override void PrepareContainerForItemOverride(DependencyObject pElement, object pItem)
	{
		base.PrepareContainerForItemOverride(pElement, pItem);
		MenuFlyoutItemBase menuFlyoutItemBase = pElement as MenuFlyoutItemBase;
		menuFlyoutItemBase.SetParentMenuFlyoutPresenter(this);
	}

	protected override void ClearContainerForItemOverride(DependencyObject pElement, object pItem)
	{
		base.ClearContainerForItemOverride(pElement, pItem);
		(pElement as MenuFlyoutItemBase).SetParentMenuFlyoutPresenter(null);
	}

	internal MenuFlyout GetParentMenuFlyout()
	{
		return m_wrParentMenuFlyout?.Target as MenuFlyout;
	}

	internal void SetParentMenuFlyout(MenuFlyout pParentMenuFlyout)
	{
		m_wrParentMenuFlyout = new WeakReference(pParentMenuFlyout);
	}

	protected override void OnItemsSourceChanged(DependencyPropertyChangedEventArgs args)
	{
		base.OnItemsSourceChanged(args);
		object newValue = args.NewValue;
		m_iFocusedIndex = -1;
		m_containsToggleItems = false;
		m_containsIconItems = false;
		m_containsItemsWithKeyboardAcceleratorText = false;
		if (newValue == null)
		{
			return;
		}
		if (!(newValue is IList<MenuFlyoutItemBase> list))
		{
			throw new InvalidOperationException("Cannot use MenuFlyoutPresenter outside of a MenuFlyout");
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			MenuFlyoutItemBase menuFlyoutItemBase = list[i];
			if (menuFlyoutItemBase is MenuFlyoutItem menuFlyoutItem)
			{
				m_containsToggleItems = m_containsToggleItems || menuFlyoutItem.HasToggle();
				IconElement icon = menuFlyoutItem.Icon;
				m_containsIconItems = m_containsIconItems || icon != null;
				string keyboardAcceleratorTextOverride = menuFlyoutItem.KeyboardAcceleratorTextOverride;
				m_containsItemsWithKeyboardAcceleratorText = m_containsItemsWithKeyboardAcceleratorText || !string.IsNullOrEmpty(keyboardAcceleratorTextOverride);
			}
			else if (menuFlyoutItemBase is MenuFlyoutSubItem menuFlyoutSubItem)
			{
				IconElement icon = menuFlyoutSubItem.Icon;
				m_containsIconItems = m_containsIconItems || icon != null;
			}
			if (m_containsIconItems && m_containsToggleItems && m_containsItemsWithKeyboardAcceleratorText)
			{
				break;
			}
		}
		UpdateTemplateSettings();
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new MenuFlyoutPresenterAutomationPeer(this);
	}

	private void UpdateVisualStateForPlacement(FlyoutBase.MajorPlacementMode placement)
	{
		m_mostRecentPlacement = placement;
		UpdateVisualState(useTransitions: false);
	}

	private void ResetVisualState()
	{
		VisualStateManager.GoToState(this, "None", useTransitions: false);
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		ScrollViewer scrollViewer = (m_tpScrollViewer = GetTemplateChild("MenuFlyoutPresenterScrollViewer") as ScrollViewer);
	}

	private void DetachEntranceAnimationCompletedHandlers()
	{
	}

	private void OnEntranceAnimationCompleted(DependencyObject pSender, DependencyObject pArgs)
	{
		Focus(FocusState.Programmatic);
	}

	protected override void OnPointerExited(PointerRoutedEventArgs pArgs)
	{
		if (pArgs.Handled)
		{
			return;
		}
		Pointer pointer = pArgs.Pointer;
		PointerDeviceType pointerDeviceType = pointer.PointerDeviceType;
		if (PointerDeviceType.Mouse == pointerDeviceType && !m_isSubPresenter)
		{
			bool flag = false;
			IMenuPresenter subPresenter = ((IMenuPresenter)this).SubPresenter;
			if (subPresenter != null)
			{
				UIElement uIElement = subPresenter as UIElement;
				PointerPoint currentPoint = pArgs.GetCurrentPoint(null);
				Point position = currentPoint.Position;
				if (m_tpScrollViewer != null)
				{
					Control tpScrollViewer = m_tpScrollViewer;
					DependencyObject templateChild = tpScrollViewer.GetTemplateChild("VerticalScrollBar");
					UIElement uIElement2 = templateChild as UIElement;
					if (uIElement != null || uIElement2 != null)
					{
						IEnumerable<UIElement> enumerable = VisualTreeHelper.FindElementsInHostCoordinates(position, uIElement2, includeAllElements: true);
						foreach (UIElement item in enumerable)
						{
							DependencyObject dependencyObject = item;
							if ((dependencyObject is ScrollBar && uIElement2 == item) || uIElement == item)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							enumerable = VisualTreeHelper.FindElementsInHostCoordinates(position, uIElement, includeAllElements: true);
							foreach (UIElement item2 in enumerable)
							{
								DependencyObject dependencyObject2 = item2;
								if ((dependencyObject2 is ScrollBar && uIElement2 == item2) || uIElement == item2)
								{
									flag = true;
									break;
								}
							}
						}
					}
				}
				if (!flag && !GetSubPresenterBounds(uIElement).Contains(position))
				{
					DelayCloseMenuFlyoutSubItem();
				}
			}
		}
		pArgs.Handled = true;
	}

	internal bool GetContainsToggleItems()
	{
		return m_containsToggleItems;
	}

	internal bool GetContainsIconItems()
	{
		return m_containsIconItems;
	}

	internal bool GetContainsItemsWithKeyboardAcceleratorText()
	{
		return m_containsItemsWithKeyboardAcceleratorText;
	}

	private Rect GetSubPresenterBounds(UIElement pSubPresenterAsUIE)
	{
		GeneralTransform generalTransform = pSubPresenterAsUIE.TransformToVisual(null);
		return generalTransform.TransformBounds(pSubPresenterAsUIE.LayoutSlotWithMarginsAndAlignments);
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		base.OnPointerEntered(pArgs);
		if (pArgs.Handled)
		{
			return;
		}
		Pointer pointer = pArgs.Pointer;
		PointerDeviceType pointerDeviceType = pointer.PointerDeviceType;
		if (PointerDeviceType.Mouse == pointerDeviceType && m_isSubPresenter)
		{
			CancelCloseMenuFlyoutSubItem();
			ISubMenuOwner owner = ((IMenuPresenter)this).Owner;
			if (owner != null && owner is MenuFlyoutSubItem menuFlyoutSubItem)
			{
				menuFlyoutSubItem.GetParentMenuFlyoutPresenter()?.CancelCloseMenuFlyoutSubItem();
			}
		}
		pArgs.Handled = true;
	}

	private string GetPlainText()
	{
		string result = null;
		if (m_wrParentMenuFlyout.Target is DependencyObject element)
		{
			result = AutomationProperties.GetName(element);
		}
		return result;
	}

	void IMenuPresenter.CloseSubMenu()
	{
		if (m_wrSubPresenter?.Target is IMenuPresenter menuPresenter)
		{
			menuPresenter.CloseSubMenu();
		}
		if (m_wrOwner?.Target is ISubMenuOwner subMenuOwner)
		{
			subMenuOwner.CloseSubMenu();
		}
		m_iFocusedIndex = -1;
	}

	private void DelayCloseMenuFlyoutSubItem()
	{
		if (m_wrSubPresenter?.Target is IMenuPresenter menuPresenter)
		{
			menuPresenter.Owner?.DelayCloseSubMenu();
		}
	}

	private void CancelCloseMenuFlyoutSubItem()
	{
		if (m_wrSubPresenter?.Target is IMenuPresenter menuPresenter)
		{
			menuPresenter.Owner?.CancelCloseSubMenu();
		}
	}

	private DependencyObject GetParentMenuFlyoutSubItem(DependencyObject nativeDO)
	{
		MenuFlyoutPresenter menuFlyoutPresenter = nativeDO as MenuFlyoutPresenter;
		ISubMenuOwner owner = ((IMenuPresenter)menuFlyoutPresenter).Owner;
		if (owner is MenuFlyoutSubItem result)
		{
			return result;
		}
		return null;
	}

	internal void UpdateTemplateSettings()
	{
		MenuFlyoutPresenterTemplateSettings templateSettings = TemplateSettings;
		MenuFlyoutPresenterTemplateSettings menuFlyoutPresenterTemplateSettings = templateSettings;
		MenuFlyout parentMenuFlyout = GetParentMenuFlyout();
		if (parentMenuFlyout != null && menuFlyoutPresenterTemplateSettings != null)
		{
			double val = ResourceResolver.ResolveTopLevelResourceDouble((parentMenuFlyout.InputDeviceTypeUsedToOpen == FocusInputDeviceKind.Touch || parentMenuFlyout.InputDeviceTypeUsedToOpen == FocusInputDeviceKind.GameController) ? "FlyoutThemeTouchMinWidth" : "FlyoutThemeMinWidth");
			menuFlyoutPresenterTemplateSettings.FlyoutContentMinWidth = Math.Min(base.LayoutSlotWithMarginsAndAlignments.Width, val);
		}
		double num = 0.0;
		IObservableVector<object> items = base.Items;
		uint size = (items as ItemCollection).Size;
		for (int i = 0; i < size; i++)
		{
			MenuFlyoutItemBase menuFlyoutItemBase = base.Items[i] as MenuFlyoutItemBase;
			if (menuFlyoutItemBase is MenuFlyoutItem menuFlyoutItem)
			{
				double width = menuFlyoutItem.GetKeyboardAcceleratorTextDesiredSize().Width;
				if (width > num)
				{
					num = width;
				}
			}
		}
		for (int j = 0; j < size; j++)
		{
			MenuFlyoutItemBase menuFlyoutItemBase2 = base.Items[j] as MenuFlyoutItemBase;
			if (menuFlyoutItemBase2 is MenuFlyoutItem menuFlyoutItem2)
			{
				menuFlyoutItem2.UpdateTemplateSettings(num);
			}
		}
	}

	protected override void OnGotFocus(RoutedEventArgs pArgs)
	{
		FocusState focusState = base.FocusState;
		if (m_iFocusedIndex == -1 && focusState != 0)
		{
			CycleFocus(shouldCycleDown: true, focusState);
		}
		else if (focusState == FocusState.Unfocused && FocusManager.GetFocusedElement() is DependencyObject container)
		{
			int num = IndexFromContainer(container);
			if (num != -1)
			{
				m_iFocusedIndex = num;
			}
		}
	}

	private void EnsureInitialFocusIndex()
	{
		if (m_iFocusedIndex != -1)
		{
			return;
		}
		object focusedElement = FocusManager.GetFocusedElement();
		if (this == focusedElement)
		{
			return;
		}
		int count = base.Items.Count;
		for (int i = 0; i < count; i++)
		{
			DependencyObject dependencyObject = base.Items[i] as DependencyObject;
			MenuFlyoutItem menuFlyoutItem = dependencyObject as MenuFlyoutItem;
			if (menuFlyoutItem == focusedElement)
			{
				m_iFocusedIndex = i;
				break;
			}
		}
	}

	private int GetPositionInSetHelper(MenuFlyoutItemBase item)
	{
		int result = -1;
		MenuFlyoutPresenter parentMenuFlyoutPresenter = item.GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			int num = base.Items.IndexOf(item);
			if (num != -1)
			{
				int num2 = num;
				for (int i = 0; i < num; i++)
				{
					if (base.Items[i] is DependencyObject dependencyObject)
					{
						if (dependencyObject is MenuFlyoutSeparator)
						{
							num2--;
						}
						else if (dependencyObject is UIElement uIElement && uIElement.Visibility != 0)
						{
							num2--;
						}
					}
				}
				result = num2 + 1;
			}
		}
		return result;
	}

	private int GetSizeOfSetHelper(MenuFlyoutItemBase item)
	{
		int result = -1;
		MenuFlyoutPresenter parentMenuFlyoutPresenter = item.GetParentMenuFlyoutPresenter();
		if (parentMenuFlyoutPresenter != null)
		{
			int count = base.Items.Count;
			int num = count;
			for (int i = 0; i < count; i++)
			{
				if (base.Items[i] is DependencyObject dependencyObject)
				{
					if (dependencyObject is MenuFlyoutSeparator)
					{
						num--;
					}
					else if (dependencyObject is UIElement uIElement && uIElement.Visibility != 0)
					{
						num--;
					}
				}
			}
			result = num;
		}
		return result;
	}

	internal void SetDepth(int depth)
	{
		m_depth = depth;
	}

	internal int GetDepth()
	{
		return m_depth;
	}
}
