namespace Windows.UI.Xaml.Controls;

public interface IItemContainerMapping
{
	object ItemFromContainer(DependencyObject container);

	DependencyObject ContainerFromItem(object item);

	int IndexFromContainer(DependencyObject container);

	DependencyObject ContainerFromIndex(int index);
}
