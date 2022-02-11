using System;

namespace Windows.UI.Xaml.Controls;

public class DatePickerValueChangedEventArgs
{
	public DateTimeOffset NewDate { get; }

	public DateTimeOffset OldDate { get; }

	internal DatePickerValueChangedEventArgs(DateTimeOffset newDate, DateTimeOffset oldDate)
	{
		NewDate = newDate;
		OldDate = oldDate;
	}
}
