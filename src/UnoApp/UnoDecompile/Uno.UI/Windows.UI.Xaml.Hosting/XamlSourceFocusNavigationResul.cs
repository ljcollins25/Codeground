namespace Windows.UI.Xaml.Hosting;

public class XamlSourceFocusNavigationResult
{
	public bool WasFocusMoved { get; }

	public XamlSourceFocusNavigationResult(bool focusMoved)
	{
		WasFocusMoved = focusMoved;
	}
}
