namespace Windows.UI.Xaml.Controls;

public class GridView : ListViewBase
{
	public GridView()
	{
		base.DefaultStyleKey = typeof(GridView);
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is GridViewItem;
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return new GridViewItem
		{
			IsGeneratedContainer = true
		};
	}

	internal override ContentControl GetGroupHeaderContainer(object groupHeader)
	{
		return new GridViewHeaderItem
		{
			IsGeneratedContainer = true
		};
	}
}
