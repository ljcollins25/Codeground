using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

public class GridViewItem : SelectorItem
{
	public GridViewItemTemplateSettings TemplateSettings { get; } = new GridViewItemTemplateSettings();


	public GridViewItem()
	{
		base.DefaultStyleKey = typeof(GridViewItem);
	}
}
