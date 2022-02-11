namespace Windows.UI.Xaml;

internal interface IShareableDependencyObject
{
	bool IsClone { get; }

	DependencyObject Clone();
}
