using System;
using Windows.Globalization;

namespace Windows.UI.Xaml.Controls;

public class TimePickerSelector : ContentControl
{
	public TimeSpan Time
	{
		get
		{
			return (TimeSpan)GetValue(TimeProperty);
		}
		set
		{
			SetValue(TimeProperty, value);
		}
	}

	public static DependencyProperty TimeProperty { get; } = DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimePickerSelector), new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerSelector)s)?.OnTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
	}));


	public int MinuteIncrement
	{
		get
		{
			return (int)GetValue(MinuteIncrementProperty);
		}
		set
		{
			SetValue(MinuteIncrementProperty, value);
		}
	}

	public static DependencyProperty MinuteIncrementProperty { get; } = DependencyProperty.Register("MinuteIncrement", typeof(int), typeof(TimePickerSelector), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerSelector)s)?.OnMinuteIncrementChanged((int)e.OldValue, (int)e.NewValue);
	}));


	public string ClockIdentifier
	{
		get
		{
			return (string)GetValue(ClockIdentifierProperty);
		}
		set
		{
			SetValue(ClockIdentifierProperty, value);
		}
	}

	public static DependencyProperty ClockIdentifierProperty { get; } = DependencyProperty.Register("ClockIdentifier", typeof(string), typeof(TimePickerSelector), new FrameworkPropertyMetadata(ClockIdentifiers.TwelveHour, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimePickerSelector)s)?.OnClockIdentifierChanged((string)e.OldValue, (string)e.NewValue);
	}));


	public TimePickerSelector()
	{
		base.DefaultStyleKey = typeof(TimePickerSelector);
	}

	protected virtual void OnTimeChanged(TimeSpan oldTime, TimeSpan newTime)
	{
	}

	protected virtual void OnMinuteIncrementChanged(int oldMinuteIncrement, int newMinuteIncrement)
	{
	}

	protected virtual void OnClockIdentifierChanged(string oldClockIdentifier, string newClockIdentifier)
	{
	}
}
