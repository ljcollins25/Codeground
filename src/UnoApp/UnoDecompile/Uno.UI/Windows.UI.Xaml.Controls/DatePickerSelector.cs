using System;

namespace Windows.UI.Xaml.Controls;

public class DatePickerSelector : ContentControl
{
	public DateTimeOffset Date
	{
		get
		{
			return (DateTimeOffset)GetValue(DateProperty);
		}
		set
		{
			SetValue(DateProperty, value);
		}
	}

	public static DependencyProperty DateProperty { get; } = DependencyProperty.Register("Date", typeof(DateTimeOffset), typeof(DatePickerSelector), new FrameworkPropertyMetadata(DateTimeOffset.MinValue, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnDateChanged((DateTimeOffset)e.OldValue, (DateTimeOffset)e.NewValue);
	}));


	public bool DayVisible
	{
		get
		{
			return (bool)GetValue(DayVisibleProperty);
		}
		set
		{
			SetValue(DayVisibleProperty, value);
		}
	}

	public static DependencyProperty DayVisibleProperty { get; } = DependencyProperty.Register("DayVisible", typeof(bool), typeof(DatePickerSelector), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnDayVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public bool MonthVisible
	{
		get
		{
			return (bool)GetValue(MonthVisibleProperty);
		}
		set
		{
			SetValue(MonthVisibleProperty, value);
		}
	}

	public static DependencyProperty MonthVisibleProperty { get; } = DependencyProperty.Register("MonthVisible", typeof(bool), typeof(DatePickerSelector), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnMonthVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public bool YearVisible
	{
		get
		{
			return (bool)GetValue(YearVisibleProperty);
		}
		set
		{
			SetValue(YearVisibleProperty, value);
		}
	}

	public static DependencyProperty YearVisibleProperty { get; } = DependencyProperty.Register("YearVisible", typeof(bool), typeof(DatePickerSelector), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnYearVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public DateTimeOffset MaxYear
	{
		get
		{
			return (DateTimeOffset)GetValue(MaxYearProperty);
		}
		set
		{
			SetValue(MaxYearProperty, value);
		}
	}

	public static DependencyProperty MaxYearProperty { get; } = DependencyProperty.Register("MaxYear", typeof(DateTimeOffset), typeof(DatePickerSelector), new FrameworkPropertyMetadata(DateTimeOffset.MaxValue, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnMaxYearChanged((DateTimeOffset)e.OldValue, (DateTimeOffset)e.NewValue);
	}));


	public DateTimeOffset MinYear
	{
		get
		{
			return (DateTimeOffset)GetValue(MinYearProperty);
		}
		set
		{
			SetValue(MinYearProperty, value);
		}
	}

	public static DependencyProperty MinYearProperty { get; } = DependencyProperty.Register("MinYear", typeof(DateTimeOffset), typeof(DatePickerSelector), new FrameworkPropertyMetadata(DateTimeOffset.MinValue, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerSelector)s)?.OnMinYearChanged((DateTimeOffset)e.OldValue, (DateTimeOffset)e.NewValue);
	}));


	public DatePickerSelector()
	{
		base.DefaultStyleKey = typeof(DatePickerSelector);
	}

	protected virtual void OnDateChanged(DateTimeOffset oldDate, DateTimeOffset newDate)
	{
	}

	protected virtual void OnDayVisibleChanged(bool oldDayVisible, bool newDayVisible)
	{
	}

	protected virtual void OnMonthVisibleChanged(bool oldMonthVisible, bool newMonthVisible)
	{
	}

	protected virtual void OnYearVisibleChanged(bool oldYearVisible, bool newYearVisible)
	{
	}

	protected virtual void OnMaxYearChanged(DateTimeOffset oldMaxYear, DateTimeOffset newMaxYear)
	{
	}

	protected virtual void OnMinYearChanged(DateTimeOffset oldMinYear, DateTimeOffset newMinYear)
	{
	}
}
