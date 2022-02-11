using System;
using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class NavigationViewItemBase : ListViewItem
{
	private NavigationViewListPosition m_position;

	public NavigationViewItemBase()
	{
		base.Loaded += NavigationViewItemBase_Loaded;
	}

	private void NavigationViewItemBase_Loaded(object sender, RoutedEventArgs e)
	{
		if (GetValue(ItemsControl.ItemsControlForItemContainerProperty) == DependencyProperty.UnsetValue)
		{
			ItemsControl itemsControl = FindFirstParent<ItemsControl>();
			if (itemsControl != null)
			{
				SetValue(ItemsControl.ItemsControlForItemContainerProperty, new WeakReference<ItemsControl>(itemsControl));
				SelectorItem source = FindFirstParent<SelectorItem>();
				SetBinding(SelectorItem.IsSelectedProperty, new Binding
				{
					Path = "IsSelected",
					Source = source,
					Mode = BindingMode.TwoWay
				});
			}
		}
	}

	protected virtual void OnNavigationViewListPositionChanged()
	{
	}

	internal NavigationViewListPosition Position()
	{
		return m_position;
	}

	internal void Position(NavigationViewListPosition value)
	{
		if (m_position != value)
		{
			m_position = value;
			OnNavigationViewListPositionChanged();
		}
	}

	internal NavigationView GetNavigationView()
	{
		NavigationView navigationView = null;
		NavigationViewList navigationViewList = GetNavigationViewList();
		if (navigationViewList != null)
		{
			return navigationViewList.GetNavigationViewParent();
		}
		return SharedHelpers.GetAncestorOfType<NavigationView>(VisualTreeHelper.GetParent(this));
	}

	internal SplitView GetSplitView()
	{
		SplitView result = null;
		NavigationView navigationView = GetNavigationView();
		if (navigationView != null)
		{
			result = navigationView.GetSplitView();
		}
		return result;
	}

	internal NavigationViewList GetNavigationViewList()
	{
		return SharedHelpers.GetAncestorOfType<NavigationViewList>(VisualTreeHelper.GetParent(this));
	}
}
