namespace Windows.UI.Xaml;

public static class VisiblityExtensions
{
	public static bool IsHidden(this Visibility visibility)
	{
		return visibility == Visibility.Collapsed;
	}
}
