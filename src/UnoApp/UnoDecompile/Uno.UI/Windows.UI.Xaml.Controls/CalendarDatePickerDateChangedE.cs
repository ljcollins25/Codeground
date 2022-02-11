using System;

namespace Windows.UI.Xaml.Controls;

public sealed class CalendarDatePickerDateChangedEventArgs
{
	public DateTimeOffset? NewDate { get; }

	public DateTimeOffset? OldDate { get; }

	internal CalendarDatePickerDateChangedEventArgs(DateTimeOffset? newDate, DateTimeOffset? oldDate)
	{
		NewDate = newDate;
		OldDate = oldDate;
	}
}
