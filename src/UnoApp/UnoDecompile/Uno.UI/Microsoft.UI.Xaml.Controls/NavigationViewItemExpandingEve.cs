namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewItemExpandingEventArgs
{
	private readonly NavigationView? m_navigationView;

	private object? m_expandingItem;

	public object? ExpandingItem
	{
		get
		{
			object expandingItem = m_expandingItem;
			if (expandingItem != null)
			{
				return expandingItem;
			}
			NavigationView navigationView = m_navigationView;
			if (navigationView != null)
			{
				m_expandingItem = navigationView.MenuItemFromContainer(ExpandingItemContainer);
				return m_expandingItem;
			}
			return null;
		}
	}

	public NavigationViewItemBase? ExpandingItemContainer { get; internal set; }

	internal NavigationViewItemExpandingEventArgs(NavigationView? navigationView)
	{
		m_navigationView = navigationView;
	}
}
