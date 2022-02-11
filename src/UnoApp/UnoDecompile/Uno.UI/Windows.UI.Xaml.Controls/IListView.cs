namespace Windows.UI.Xaml.Controls;

internal interface IListView : IItemsControl, IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	bool IsItemClickEnabled { get; set; }

	ItemsPanelTemplate ItemsPanel { get; set; }

	object SelectedItem { get; set; }
}
