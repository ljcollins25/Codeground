namespace Windows.UI.Xaml;

internal interface IFrameworkElementInternal : IFrameworkElement, IDataContextProvider, DependencyObject, IDependencyObjectParse
{
	bool HasLayouter { get; }
}
