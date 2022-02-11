namespace Windows.UI.Xaml.Controls;

public interface IThemableAnimatedVisualSource : IAnimatedVisualSource
{
	void SetColorThemeProperty(string propertyName, Color? color);

	Color? GetColorThemeProperty(string propertyName);
}
