using Uno;

namespace Windows.UI.Xaml.Automation.Provider;

[NotImplemented]
public interface IItemContainerProvider
{
	IRawElementProviderSimple FindItemByProperty(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, object value);
}
