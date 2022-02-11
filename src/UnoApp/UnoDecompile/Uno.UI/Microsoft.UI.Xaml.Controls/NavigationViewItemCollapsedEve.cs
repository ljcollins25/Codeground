namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItemCollapsedEventArgs
{
	private readonly NavigationView? m_navigationView;

	private object? m_collapsedItem;

	public object? CollapsedItem
	{
		get
		{
			object collapsedItem = m_collapsedItem;
			if (collapsedItem != null)
			{
				return collapsedItem;
			}
			NavigationView navigationView = m_navigationView;
			if (navigationView != null)
			{
				m_collapsedItem = navigationView.MenuItemFromContainer(CollapsedItemContainer);
				return m_collapsedItem;
			}
			return null;
		}
	}

	public NavigationViewItemBase? CollapsedItemContainer { get; internal set; }

	internal NavigationViewItemCollapsedEventArgs(NavigationView? navigationView)
	{
		m_navigationView = navigationView;
	}
}
