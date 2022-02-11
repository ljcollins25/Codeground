using System;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewList : ListView
{
	private NavigationViewListPosition m_navigationViewListPosition;

	private bool m_showFocusVisual = true;

	private WeakReference<NavigationView> m_navigationView;

	private NavigationViewItemBase m_lastItemCalledInIsItemItsOwnContainerOverride;

	private bool _isTemplateOwnContainer;

	private bool IsTemplateOwnContainer => _isTemplateOwnContainer;

	protected override DependencyObject GetContainerForItemOverride()
	{
		if (!IsTemplateOwnContainer)
		{
			return new NavigationViewItem
			{
				IsGeneratedContainer = true
			};
		}
		return CreateOwnContainer();
	}

	protected override bool IsItemItsOwnContainerOverride(object args)
	{
		bool result = false;
		if (args != null)
		{
			NavigationViewItemBase navigationViewItemBase = args as NavigationViewItemBase;
			if (navigationViewItemBase != null && navigationViewItemBase != m_lastItemCalledInIsItemItsOwnContainerOverride)
			{
				m_lastItemCalledInIsItemItsOwnContainerOverride = navigationViewItemBase;
			}
			result = navigationViewItemBase != null;
		}
		return result;
	}

	protected override void ClearContainerForItemOverride(DependencyObject element, object item)
	{
		if (element is NavigationViewItem navigationViewItem)
		{
			navigationViewItem.ClearIsContentChangeHandlingDelayedForTopNavFlag();
		}
		base.PrepareContainerForItemOverride(element, item);
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		if (element is NavigationViewItemBase navigationViewItemBase)
		{
			navigationViewItemBase.Position(m_navigationViewListPosition);
		}
		if (element is NavigationViewItem navigationViewItem)
		{
			navigationViewItem.UseSystemFocusVisuals = m_showFocusVisual;
			navigationViewItem.ClearIsContentChangeHandlingDelayedForTopNavFlag();
		}
		base.PrepareContainerForItemOverride(element, item);
	}

	internal void SetNavigationViewListPosition(NavigationViewListPosition navigationViewListPosition)
	{
		m_navigationViewListPosition = navigationViewListPosition;
		PropagateChangeToAllContainers(delegate(NavigationViewItemBase container)
		{
			container.Position(navigationViewListPosition);
		});
	}

	internal void SetShowFocusVisual(bool showFocus)
	{
		m_showFocusVisual = showFocus;
		PropagateChangeToAllContainers(delegate(NavigationViewItem container)
		{
			container.UseSystemFocusVisuals = showFocus;
		});
	}

	internal void SetNavigationViewParent(NavigationView navigationView)
	{
		m_navigationView = new WeakReference<NavigationView>(navigationView);
	}

	protected override void OnKeyDown(KeyRoutedEventArgs eventArgs)
	{
		VirtualKey key = eventArgs.Key;
		if (key != VirtualKey.GamepadLeftShoulder && key != VirtualKey.GamepadRightShoulder && key != VirtualKey.GamepadLeftTrigger && key != VirtualKey.GamepadRightTrigger)
		{
			base.OnKeyDown(eventArgs);
		}
	}

	internal NavigationView GetNavigationViewParent()
	{
		NavigationView target = null;
		WeakReference<NavigationView> navigationView = m_navigationView;
		if (navigationView != null && navigationView.TryGetTarget(out target))
		{
			return target;
		}
		return null;
	}

	internal NavigationViewItemBase GetLastItemCalledInIsItemItsOwnContainerOverride()
	{
		return m_lastItemCalledInIsItemItsOwnContainerOverride;
	}

	private void PropagateChangeToAllContainers<T>(Action<T> function) where T : class
	{
		ItemCollection items = base.Items;
		if (items == null)
		{
			return;
		}
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			DependencyObject dependencyObject = ContainerFromIndex(i);
			if (dependencyObject != null && dependencyObject is T obj)
			{
				function(obj);
			}
		}
	}

	protected override void OnItemTemplateChanged(DataTemplate oldItemTemplate, DataTemplate newItemTemplate)
	{
		base.OnItemTemplateChanged(oldItemTemplate, newItemTemplate);
		_isTemplateOwnContainer = base.ItemTemplate?.LoadContent() is NavigationViewItemBase;
	}

	private DependencyObject CreateOwnContainer()
	{
		return new ListViewItem
		{
			Padding = Thickness.Empty,
			VerticalContentAlignment = VerticalAlignment.Stretch,
			HorizontalContentAlignment = HorizontalAlignment.Stretch
		};
	}

	internal override int IndexFromContainerInner(DependencyObject container)
	{
		int num = base.IndexFromContainerInner(container);
		if (num == -1 && container is FrameworkElement frameworkElement)
		{
			SelectorItem selectorItem = frameworkElement.FindFirstParent<SelectorItem>();
			if (selectorItem != null)
			{
				num = base.IndexFromContainerInner(selectorItem);
			}
		}
		return num;
	}
}
