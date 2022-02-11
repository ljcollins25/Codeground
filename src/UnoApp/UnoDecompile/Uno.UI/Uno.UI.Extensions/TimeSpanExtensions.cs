using System;
using System.Text;

namespace Uno.UI.Extensions;

public static class TimeSpanExtensions
{
	public static string ToXamlString(this TimeSpan timeSpan, IFormatProvider provider)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (timeSpan.Days > 0)
		{
			stringBuilder.AppendFormat(provider, "{0}.", timeSpan.Days);
		}
		stringBuilder.AppendFormat(provider, "{0:D2}:{1:D2}:{2:d2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		if (timeSpan.Milliseconds > 0)
		{
			stringBuilder.AppendFormat(provider, ".{0:D3}", timeSpan.Milliseconds);
		}
		return stringBuilder.ToString();
	}

	internal static TimeSpan RoundToPreviousMinuteInterval(this TimeSpan time, int interval)
	{
		if (interval > 0 && time != TimeSpan.Zero)
		{
			double value = Math.Floor(Math.Truncate(time.TotalMinutes) / (double)interval) * (double)interval;
			return TimeSpan.FromMinutes(value);
		}
		return time;
	}

	internal static TimeSpan RoundToNextMinuteInterval(this TimeSpan time, int interval)
	{
		if (interval > 0 && time != TimeSpan.Zero)
		{
			double value = Math.Ceiling(Math.Truncate(time.TotalMinutes) / (double)interval) * (double)interval;
			return TimeSpan.FromMinutes(value);
		}
		return time;
	}

	internal static TimeSpan RoundToMinuteInterval(this TimeSpan time, int interval)
	{
		if (interval > 0 && time != TimeSpan.Zero)
		{
			double value = Math.Round(Math.Truncate(time.TotalMinutes) / (double)interval) * (double)interval;
			return TimeSpan.FromMinutes(value);
		}
		return time;
	}

	internal static TimeSpan NormalizeToDay(this TimeSpan value)
	{
		TimeSpan timeSpan = TimeSpan.FromDays(1.0);
		while (value < TimeSpan.Zero)
		{
			value += timeSpan;
		}
		while (value > timeSpan)
		{
			value -= timeSpan;
		}
		return value;
	}
}
