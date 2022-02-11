namespace Windows.UI.Xaml.Media.Animation;

public class CommonNavigationTransitionInfo : NavigationTransitionInfo
{
	public bool IsStaggeringEnabled
	{
		get
		{
			return (bool)GetValue(IsStaggeringEnabledProperty);
		}
		set
		{
			SetValue(IsStaggeringEnabledProperty, value);
		}
	}

	public static DependencyProperty IsStaggeringEnabledProperty { get; } = DependencyProperty.Register("IsStaggeringEnabled", typeof(bool), typeof(CommonNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	public static DependencyProperty IsStaggerElementProperty { get; } = DependencyProperty.RegisterAttached("IsStaggerElement", typeof(bool), typeof(CommonNavigationTransitionInfo), new FrameworkPropertyMetadata(false));


	public static bool GetIsStaggerElement(UIElement element)
	{
		return (bool)element.GetValue(IsStaggerElementProperty);
	}

	public static void SetIsStaggerElement(UIElement element, bool value)
	{
		element.SetValue(IsStaggerElementProperty, value);
	}
}
