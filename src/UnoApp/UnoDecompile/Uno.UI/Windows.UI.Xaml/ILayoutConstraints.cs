namespace Windows.UI.Xaml;

public interface ILayoutConstraints
{
	bool IsWidthConstrained(UIElement requester);

	bool IsHeightConstrained(UIElement requester);
}
