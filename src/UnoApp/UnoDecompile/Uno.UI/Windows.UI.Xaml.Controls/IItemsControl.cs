namespace Windows.UI.Xaml.Controls;

internal interface IItemsControl : IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	object ItemsSource { get; set; }

	DataTemplate ItemTemplate { get; set; }

	DataTemplateSelector ItemTemplateSelector { get; set; }

	string DisplayMemberPath { get; set; }
}
