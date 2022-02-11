using System;
using System.Globalization;
using Uno.UI.Extensions;

namespace Windows.UI.Xaml.Media.Animation;

public struct RepeatBehavior : IEquatable<RepeatBehavior>
{
	private static readonly string __forever = "Forever";

	private static readonly string __count = "Count";

	public static RepeatBehavior Forever
	{
		get
		{
			RepeatBehavior result = default(RepeatBehavior);
			result.Type = RepeatBehaviorType.Forever;
			return result;
		}
	}

	public double Count { get; set; }

	public TimeSpan Duration { get; set; }

	public RepeatBehaviorType Type { get; set; }

	public bool HasCount => Type == RepeatBehaviorType.Count;

	public bool HasDuration => Type == RepeatBehaviorType.Duration;

	public RepeatBehavior(double count)
	{
		if (count <= 0.0)
		{
			throw new ArgumentOutOfRangeException("count", "Count must be greater than zero.");
		}
		Type = RepeatBehaviorType.Count;
		Duration = default(TimeSpan);
		Count = count;
	}

	public RepeatBehavior(TimeSpan duration)
	{
		Type = RepeatBehaviorType.Duration;
		Duration = duration;
		Count = 0.0;
	}

	internal bool ShouldRepeat(TimeSpan elapsed, int count)
	{
		switch (Type)
		{
		case RepeatBehaviorType.Count:
			if (!double.IsNaN(Count))
			{
				return Count > (double)count;
			}
			break;
		case RepeatBehaviorType.Duration:
			return Duration > elapsed;
		case RepeatBehaviorType.Forever:
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Count.GetHashCode() ^ Duration.GetHashCode() ^ Type.GetHashCode();
	}

	public override bool Equals(object value)
	{
		if (value is RepeatBehavior second)
		{
			return Equals(this, second);
		}
		return false;
	}

	public bool Equals(RepeatBehavior other)
	{
		return Equals(this, other);
	}

	public static bool operator ==(RepeatBehavior first, RepeatBehavior second)
	{
		return Equals(first, second);
	}

	public static bool operator !=(RepeatBehavior first, RepeatBehavior second)
	{
		return !Equals(first, second);
	}

	public static bool Equals(RepeatBehavior first, RepeatBehavior second)
	{
		if (first.Type.Equals(second.Type) && first.Count.Equals(second.Count))
		{
			return first.Duration.Equals(second.Duration);
		}
		return false;
	}

	public override string ToString()
	{
		return ToString(CultureInfo.InvariantCulture);
	}

	public string ToString(IFormatProvider provider)
	{
		return Type switch
		{
			RepeatBehaviorType.Count => Count.ToString(provider), 
			RepeatBehaviorType.Duration => Duration.ToXamlString(provider), 
			RepeatBehaviorType.Forever => __forever, 
			_ => throw new NotSupportedException("this RepeatBehavior type is not supported."), 
		};
	}

	public static implicit operator RepeatBehavior(string str)
	{
		RepeatBehaviorType type = RepeatBehaviorType.Duration;
		if (string.Equals(str, __forever, StringComparison.InvariantCultureIgnoreCase))
		{
			type = RepeatBehaviorType.Forever;
		}
		else if (string.Equals(str, __count, StringComparison.InvariantCultureIgnoreCase))
		{
			type = RepeatBehaviorType.Count;
		}
		RepeatBehavior result = default(RepeatBehavior);
		result.Type = type;
		return result;
	}
}
