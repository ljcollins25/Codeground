using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class DatePickerFlyoutPresenterAutomationPeer : FrameworkElementAutomationPeer
{
	private const string UIA_AP_DATEPICKER_NAME = "datepicker";

	private void InitializeImpl(DatePickerFlyoutPresenter pOwner)
	{
	}

	private AutomationControlType GetAutomationControlTypeCoreImpl()
	{
		return AutomationControlType.Pane;
	}

	private string GetClassNameCoreImpl()
	{
		return "DatePickerFlyoutPresenter";
	}

	private string GetNameCoreImpl()
	{
		return "datepicker";
	}
}
