using Uno.UI.Helpers.WinUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls.Primitives;

public class TabViewListView : ListView
{
	private ScrollViewer m_scrollViewer;

	public TabViewListView()
	{
		base.DefaultStyleKey = typeof(TabViewListView);
		base.ContainerContentChanging += OnContainerContentChanging;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new TabViewItem();
	}

	protected override bool IsItemItsOwnContainerOverride(object args)
	{
		bool result = false;
		if (args is TabViewItem)
		{
			result = true;
		}
		return result;
	}

	protected override void OnItemsChanged(object item)
	{
		base.OnItemsChanged(item);
		TabView ancestorOfType = SharedHelpers.GetAncestorOfType<TabView>(VisualTreeHelper.GetParent(this));
		if (ancestorOfType != null)
		{
			TabView tabView = ancestorOfType;
			tabView.OnItemsChanged(item, this);
		}
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		TabViewItem tabViewItem = (TabViewItem)element;
		TabViewItem tabViewItem2 = tabViewItem;
		if (tabViewItem2.GetParentTabView() == null)
		{
			TabView ancestorOfType = SharedHelpers.GetAncestorOfType<TabView>(VisualTreeHelper.GetParent(this));
			if (ancestorOfType != null)
			{
				tabViewItem2.OnTabViewWidthModeChanged(ancestorOfType.TabWidthMode);
				tabViewItem2.SetParentTabView(ancestorOfType);
			}
		}
		base.PrepareContainerForItemOverride(element, item);
	}

	private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
	{
		TabView ancestorOfType = SharedHelpers.GetAncestorOfType<TabView>(VisualTreeHelper.GetParent(this));
		if (ancestorOfType != null)
		{
			TabView tabView = ancestorOfType;
			tabView.UpdateTabContent();
		}
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		m_scrollViewer = GetTemplateChild<ScrollViewer>("ScrollViewer");
	}

	internal void SetHorizontalScrollBarVisibility(ScrollBarVisibility scrollBarVisibility)
	{
		if (m_scrollViewer != null)
		{
			ScrollViewer.SetHorizontalScrollBarVisibility(m_scrollViewer, scrollBarVisibility);
		}
	}
}
