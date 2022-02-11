using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

internal class NavigationViewItemsFactory : ElementFactory
{
	private IElementFactoryShim m_itemTemplateWrapper;

	private NavigationViewItemBase m_settingsItem;

	private List<NavigationViewItem> navigationViewItemPool;

	internal void UserElementFactory(object newValue)
	{
		m_itemTemplateWrapper = newValue as IElementFactoryShim;
		if (m_itemTemplateWrapper == null)
		{
			if (newValue is DataTemplate dataTemplate)
			{
				m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplate);
			}
			else if (newValue is DataTemplateSelector dataTemplateSelector)
			{
				m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplateSelector);
			}
		}
		navigationViewItemPool = new List<NavigationViewItem>();
	}

	internal void SettingsItem(NavigationViewItemBase settingsItem)
	{
		m_settingsItem = settingsItem;
	}

	protected override UIElement GetElementCore(ElementFactoryGetArgs args)
	{
		object obj = GetNewContent(m_itemTemplateWrapper, m_settingsItem);
		if (obj is NavigationViewItemBase result)
		{
			return result;
		}
		if (obj is Windows.UI.Xaml.Controls.NavigationViewItemBase)
		{
			throw new InvalidOperationException("A NavigationView instance contains a Windows.UI.Xaml.Controls.NavigationViewItem. This control requires that its NavigationViewItems be of type Microsoft.UI.Xaml.Controls.NavigationViewItem.");
		}
		NavigationViewItem navigationViewItem = GetNavigationViewItem();
		NavigationViewItem navigationViewItem2 = navigationViewItem;
		navigationViewItem2.CreatedByNavigationViewItemsFactory = true;
		if (m_itemTemplateWrapper != null && m_itemTemplateWrapper is ItemTemplateWrapper itemTemplateWrapper2)
		{
			ElementFactoryRecycleArgs elementFactoryRecycleArgs = new ElementFactoryRecycleArgs();
			elementFactoryRecycleArgs.Element = obj as UIElement;
			m_itemTemplateWrapper.RecycleElement(elementFactoryRecycleArgs);
			navigationViewItem2.Content = args.Data;
			navigationViewItem2.ContentTemplate = itemTemplateWrapper2.Template;
			navigationViewItem2.ContentTemplateSelector = itemTemplateWrapper2.TemplateSelector;
			return navigationViewItem2;
		}
		navigationViewItem2.Content = obj;
		return navigationViewItem2;
		NavigationViewItem GetNavigationViewItem()
		{
			if (navigationViewItemPool.Count > 0)
			{
				NavigationViewItem result2 = navigationViewItemPool[navigationViewItemPool.Count - 1];
				navigationViewItemPool.RemoveAt(navigationViewItemPool.Count - 1);
				return result2;
			}
			return new NavigationViewItem();
		}
		object GetNewContent(IElementFactoryShim itemTemplateWrapper, NavigationViewItemBase settingsItem)
		{
			if (settingsItem != null && settingsItem == args.Data)
			{
				return args.Data;
			}
			if (itemTemplateWrapper != null)
			{
				return itemTemplateWrapper.GetElement(args);
			}
			return args.Data;
		}
	}

	protected override void RecycleElementCore(ElementFactoryRecycleArgs args)
	{
		UIElement element = args.Element;
		if (element == null)
		{
			return;
		}
		if (element is NavigationViewItem navigationViewItem)
		{
			NavigationViewItem navigationViewItem2 = navigationViewItem;
			if (navigationViewItem2.CreatedByNavigationViewItemsFactory)
			{
				navigationViewItem2.CreatedByNavigationViewItemsFactory = false;
				UnlinkElementFromParent(args);
				args.Element = null;
				navigationViewItemPool.Add(navigationViewItem);
				_ = m_itemTemplateWrapper;
			}
		}
		bool flag = m_settingsItem != null && m_settingsItem == args.Element;
		if (m_itemTemplateWrapper != null && !flag)
		{
			m_itemTemplateWrapper.RecycleElement(args);
		}
		else
		{
			UnlinkElementFromParent(args);
		}
	}

	private void UnlinkElementFromParent(ElementFactoryRecycleArgs args)
	{
		if (args.Parent is Panel panel)
		{
			UIElementCollection children = panel.Children;
			int num = children.IndexOf(args.Element);
			if (num >= 0)
			{
				children.RemoveAt(num);
			}
		}
	}
}
