using System;

namespace Windows.UI.Xaml.Controls;

public sealed class DatePickerSelectedValueChangedEventArgs
{
	public DateTimeOffset? NewDate { get; internal set; }

	public DateTimeOffset? OldDate { get; internal set; }

	internal DatePickerSelectedValueChangedEventArgs(DateTimeOffset? newDate = null, DateTimeOffset? oldDate = null)
	{
		NewDate = newDate;
		OldDate = oldDate;
	}
}
