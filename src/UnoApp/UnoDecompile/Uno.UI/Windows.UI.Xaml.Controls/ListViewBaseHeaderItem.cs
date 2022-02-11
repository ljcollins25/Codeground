namespace Windows.UI.Xaml.Controls;

public class ListViewBaseHeaderItem : ContentControl
{
	protected override bool CanCreateTemplateWithoutParent { get; } = true;


	public ListViewBaseHeaderItem()
	{
		base.DefaultStyleKey = typeof(ListViewBaseHeaderItem);
	}
}
