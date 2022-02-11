using System;
using System.Globalization;
using Uno.UI.Extensions;

namespace Windows.UI.Xaml;

public struct Duration : IEquatable<Duration>, IComparable<Duration>
{
	private static readonly string __automatic = "Automatic";

	private static readonly string __forever = "Forever";

	public DurationType Type { get; private set; }

	public TimeSpan TimeSpan { get; private set; }

	public bool HasTimeSpan
	{
		get
		{
			if (Type == DurationType.TimeSpan)
			{
				return TimeSpan.CompareTo(TimeSpan.Zero) > 0;
			}
			return false;
		}
	}

	public static Duration Forever
	{
		get
		{
			Duration result = default(Duration);
			result.Type = DurationType.Forever;
			return result;
		}
	}

	public static Duration Automatic
	{
		get
		{
			Duration result = default(Duration);
			result.Type = DurationType.Automatic;
			return result;
		}
	}

	public Duration(TimeSpan timeSpan)
	{
		Type = DurationType.TimeSpan;
		TimeSpan = timeSpan;
	}

	public static implicit operator Duration(string timeSpan)
	{
		if (timeSpan == null)
		{
			return new Duration(TimeSpan.Zero);
		}
		return new Duration(TimeSpan.Parse(timeSpan));
	}

	public Duration Add(Duration duration)
	{
		if (Type == DurationType.TimeSpan && duration.Type == DurationType.TimeSpan)
		{
			return new Duration(TimeSpan.Add(duration.TimeSpan));
		}
		return this;
	}

	public Duration Subtract(Duration duration)
	{
		if (Type == DurationType.TimeSpan && duration.Type == DurationType.TimeSpan)
		{
			return new Duration(TimeSpan.Subtract(duration.TimeSpan));
		}
		return this;
	}

	public static bool operator ==(Duration t1, Duration t2)
	{
		return t1.Equals(t2);
	}

	public static bool operator !=(Duration t1, Duration t2)
	{
		return !Equals(t1, t2);
	}

	public static bool operator >(Duration t1, Duration t2)
	{
		return Compare(t1, t2) > 0;
	}

	public static bool operator >=(Duration t1, Duration t2)
	{
		return Compare(t1, t2) >= 0;
	}

	public static bool operator <(Duration t1, Duration t2)
	{
		return Compare(t1, t2) < 0;
	}

	public static bool operator <=(Duration t1, Duration t2)
	{
		return Compare(t1, t2) <= 0;
	}

	public static Duration operator +(Duration t1, Duration t2)
	{
		return t1.Add(t2);
	}

	public static Duration operator -(Duration t1, Duration t2)
	{
		return t1.Subtract(t2);
	}

	public static implicit operator Duration(TimeSpan timeSpan)
	{
		return new Duration(timeSpan);
	}

	public static Duration operator +(Duration duration)
	{
		Duration result = default(Duration);
		result.Type = duration.Type;
		result.TimeSpan = duration.TimeSpan;
		return result;
	}

	public override int GetHashCode()
	{
		int num = Type.GetHashCode();
		if (Type == DurationType.TimeSpan)
		{
			num ^= TimeSpan.GetHashCode();
		}
		return num;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (value is Duration)
		{
			return Equals((Duration)value);
		}
		return false;
	}

	public bool Equals(Duration duration)
	{
		if (HasTimeSpan)
		{
			if (duration.HasTimeSpan)
			{
				return TimeSpan == duration.TimeSpan;
			}
			return false;
		}
		return Type == duration.Type;
	}

	public static bool Equals(Duration first, Duration second)
	{
		return first.Equals(second);
	}

	public int CompareTo(Duration other)
	{
		return Compare(this, other);
	}

	public static int Compare(Duration first, Duration second)
	{
		if (first.Type == second.Type)
		{
			if (first.Type == DurationType.TimeSpan)
			{
				return first.TimeSpan.CompareTo(second.TimeSpan);
			}
			return 0;
		}
		if (first.Type == DurationType.Forever)
		{
			return 1;
		}
		if (first.Type == DurationType.Automatic)
		{
			return -1;
		}
		if (second.Type == DurationType.Automatic)
		{
			return 1;
		}
		return -1;
	}

	public override string ToString()
	{
		return Type switch
		{
			DurationType.Automatic => __automatic, 
			DurationType.Forever => __forever, 
			DurationType.TimeSpan => TimeSpan.ToXamlString(CultureInfo.InvariantCulture), 
			_ => throw new NotSupportedException("This Duration type is not supported."), 
		};
	}
}
