using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IMultipleViewProvider
{
	int CurrentView { get; }

	int[] GetSupportedViews();

	string GetViewName(int viewId);

	void SetCurrentView(int viewId);
}
