using System;

namespace Windows.UI.Xaml;

public class DurationHelper
{
	public static Duration Automatic => Duration.Automatic;

	public static Duration Forever => Duration.Forever;

	public static int Compare(Duration duration1, Duration duration2)
	{
		return Duration.Compare(duration1, duration2);
	}

	public static Duration FromTimeSpan(TimeSpan timeSpan)
	{
		return new Duration(timeSpan);
	}

	public static bool GetHasTimeSpan(Duration target)
	{
		return target.HasTimeSpan;
	}

	public static Duration Add(Duration target, Duration duration)
	{
		return target.Add(duration);
	}

	public static bool Equals(Duration target, Duration value)
	{
		return Duration.Equals(target, value);
	}

	public static Duration Subtract(Duration target, Duration duration)
	{
		return target.Subtract(duration);
	}
}
