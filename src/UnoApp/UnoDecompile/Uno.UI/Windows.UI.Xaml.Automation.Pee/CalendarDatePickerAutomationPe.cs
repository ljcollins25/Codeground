using System;
using DirectUI;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class CalendarDatePickerAutomationPeer : FrameworkElementAutomationPeer, IInvokeProvider, IValueProvider
{
	private const string UIA_AP_CALENDARDATEPICKER = "UIA_AP_CALENDARDATEPICKER";

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsReadOnly
	{
		get
		{
			throw new NotImplementedException("The member bool CalendarDatePickerAutomationPeer.IsReadOnly is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string Value
	{
		get
		{
			throw new NotImplementedException("The member string CalendarDatePickerAutomationPeer.Value is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetValue(string value)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.CalendarDatePickerAutomationPeer", "void CalendarDatePickerAutomationPeer.SetValue(string value)");
	}

	public CalendarDatePickerAutomationPeer(CalendarDatePicker owner)
		: base(owner)
	{
	}

	private void GetPatternCore(PatternInterface patternInterface, out DependencyObject ppReturnValue)
	{
		ppReturnValue = null;
		if (patternInterface == PatternInterface.Invoke || patternInterface == PatternInterface.Value)
		{
			ppReturnValue = this;
		}
		else
		{
			ppReturnValue = base.GetPatternCore(patternInterface) as DependencyObject;
		}
	}

	protected override string GetClassNameCore()
	{
		return "CalendarDatePicker";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Button;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_AP_CALENDARDATEPICKER");
	}

	public void Invoke()
	{
		UIElement uIElement = null;
		if (!IsEnabled())
		{
			throw new ElementNotEnabledException();
		}
		uIElement = base.Owner;
		((CalendarDatePicker)uIElement).IsCalendarOpen = true;
	}

	private void get_IsReadOnlyImpl(out bool value)
	{
		value = true;
	}

	private void get_ValueImpl(out string value)
	{
		UIElement owner = base.Owner;
		if (!(owner is CalendarDatePicker calendarDatePicker))
		{
			throw new ArgumentNullException();
		}
		calendarDatePicker.GetCurrentFormattedDate(out value);
	}

	public void SetValueImpl(string value)
	{
		throw new NotImplementedException();
	}
}
