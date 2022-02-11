using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Controls;

public class CalendarViewSelectedDatesChangedEventArgs
{
	public IReadOnlyList<DateTimeOffset> AddedDates { get; internal set; }

	public IReadOnlyList<DateTimeOffset> RemovedDates { get; internal set; }

	internal CalendarViewSelectedDatesChangedEventArgs()
	{
	}
}
