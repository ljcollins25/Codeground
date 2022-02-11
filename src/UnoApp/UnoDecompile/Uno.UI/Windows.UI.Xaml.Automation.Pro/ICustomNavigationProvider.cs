using Uno;
using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface ICustomNavigationProvider
{
	object NavigateCustom(AutomationNavigationDirection direction);
}
