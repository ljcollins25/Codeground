namespace Windows.UI.Xaml.Controls;

internal interface ISelector : IItemsControl, IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	object SelectedItem { get; set; }

	event SelectionChangedEventHandler SelectionChanged;
}
