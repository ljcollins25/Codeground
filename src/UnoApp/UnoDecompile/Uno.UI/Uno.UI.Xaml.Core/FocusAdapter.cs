using Windows.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core;

internal class FocusAdapter
{
	private readonly ContentRoot _contentRoot;

	public FocusAdapter(ContentRoot contentRoot)
	{
		_contentRoot = contentRoot;
	}

	internal virtual void SetFocus()
	{
	}

	internal virtual bool ShouldDepartFocus(FocusNavigationDirection direction)
	{
		return false;
	}
}
