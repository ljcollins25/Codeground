namespace Windows.UI.Xaml.Data;

public sealed class BindingOperations
{
	public static void SetBinding(DependencyObject target, DependencyProperty dp, BindingBase binding)
	{
		(target as IDependencyObjectStoreProvider)?.Store.SetBinding(dp, binding);
	}
}
