namespace Windows.UI.Xaml.Controls;

public class ListView : ListViewBase, IListView, IItemsControl, IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	public ListView()
	{
		base.DefaultStyleKey = typeof(ListView);
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is ListViewItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new ListViewItem
		{
			IsGeneratedContainer = true
		};
	}

	internal override ContentControl GetGroupHeaderContainer(object groupHeader)
	{
		return new ListViewHeaderItem
		{
			IsGeneratedContainer = true
		};
	}
}
