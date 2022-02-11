using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;

namespace Microsoft.UI.Private.Controls;

internal static class RadioButtonsTestHooks
{
	internal static TypedEventHandler<RadioButtons, object> LayoutChanged;

	internal static void SetTestHooksEnabled(RadioButtons radioButtons, bool enabled)
	{
		radioButtons?.SetTestHooksEnabled(enabled);
	}

	internal static void NotifyLayoutChanged(RadioButtons sender)
	{
		LayoutChanged?.Invoke(sender, null);
	}

	internal static int GetRows(RadioButtons radioButtons)
	{
		return radioButtons?.GetRows() ?? (-1);
	}

	internal static int GetColumns(RadioButtons radioButtons)
	{
		return radioButtons?.GetColumns() ?? (-1);
	}

	internal static int GetLargerColumns(RadioButtons radioButtons)
	{
		return radioButtons?.GetLargerColumns() ?? (-1);
	}
}
