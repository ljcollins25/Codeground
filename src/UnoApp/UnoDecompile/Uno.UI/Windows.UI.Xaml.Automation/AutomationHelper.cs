using Windows.Foundation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Automation;

internal class AutomationHelper
{
	internal enum AutomationPropertyEnum
	{
		EmptyProperty,
		NameProperty,
		IsSelectedProperty,
		NotSupported
	}

	internal static void RaiseEventIfListener(UIElement element, AutomationEvents eventId)
	{
		CreatePeerForElement(element)?.RaiseAutomationEvent(eventId);
	}

	internal static void SetAutomationFocusIfListener(UIElement element)
	{
		if (ListenerExistsHelper(AutomationEvents.AutomationFocusChanged))
		{
			CreatePeerForElement(element)?.SetFocus();
		}
	}

	internal static AutomationPropertyEnum ConvertPropertyToEnum(AutomationProperty property)
	{
		if (property == null)
		{
			return AutomationPropertyEnum.EmptyProperty;
		}
		if (property == AutomationElementIdentifiers.NameProperty)
		{
			return AutomationPropertyEnum.NameProperty;
		}
		if (property == SelectionItemPatternIdentifiers.IsSelectedProperty)
		{
			return AutomationPropertyEnum.IsSelectedProperty;
		}
		return AutomationPropertyEnum.NotSupported;
	}

	internal static void RaisePropertyChanged<T>(UIElement element, AutomationProperty automationProperty, T oldValue, T newValue, bool checkIfListenerExists = false)
	{
		if (!checkIfListenerExists || ListenerExistsHelper(AutomationEvents.PropertyChanged))
		{
			CreatePeerForElement(element)?.RaisePropertyChangedEvent(automationProperty, oldValue, newValue);
		}
	}

	internal static void RaisePropertyChangedIfListener<T>(UIElement element, AutomationProperty automationProperty, T oldValue, T newValue)
	{
		RaisePropertyChanged(element, automationProperty, oldValue, newValue, checkIfListenerExists: true);
	}

	internal static AutomationPeer CreatePeerForElement(UIElement element)
	{
		return FrameworkElementAutomationPeer.CreatePeerForElement(element);
	}

	private static bool ListenerExistsHelper(AutomationEvents eventId)
	{
		return AutomationPeer.ListenerExists(eventId);
	}

	public static string GetPlainText(DependencyObject obj)
	{
		if (obj is IStringable stringable)
		{
			return stringable.ToString();
		}
		if (obj is IPropertyValue propertyValue)
		{
			return propertyValue.GetString();
		}
		if (obj is ICustomPropertyProvider customPropertyProvider)
		{
			return customPropertyProvider.GetStringRepresentation();
		}
		return null;
	}
}
