namespace Windows.UI.Xaml.Media.Animation;

public class EntranceNavigationTransitionInfo : NavigationTransitionInfo
{
	public static DependencyProperty IsTargetElementProperty { get; } = DependencyProperty.RegisterAttached("IsTargetElement", typeof(bool), typeof(EntranceNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	public static bool GetIsTargetElement(UIElement element)
	{
		return (bool)element.GetValue(IsTargetElementProperty);
	}

	public static void SetIsTargetElement(UIElement element, bool value)
	{
		element.SetValue(IsTargetElementProperty, value);
	}
}
