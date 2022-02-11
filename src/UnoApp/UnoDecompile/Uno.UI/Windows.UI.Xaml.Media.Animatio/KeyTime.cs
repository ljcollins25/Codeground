using System;
using System.Globalization;
using Uno.UI.Extensions;

namespace Windows.UI.Xaml.Media.Animation;

public struct KeyTime : IEquatable<KeyTime>, IComparable<KeyTime>
{
	public TimeSpan TimeSpan { get; private set; }

	public static KeyTime FromTimeSpan(TimeSpan timeSpan)
	{
		KeyTime result = default(KeyTime);
		result.TimeSpan = timeSpan;
		return result;
	}

	public static implicit operator KeyTime(string timeSpan)
	{
		return FromTimeSpan(TimeSpan.Parse(timeSpan));
	}

	public static implicit operator KeyTime(TimeSpan timeSpan)
	{
		return FromTimeSpan(timeSpan);
	}

	public override int GetHashCode()
	{
		return TimeSpan.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is KeyTime second)
		{
			return Equals(this, second);
		}
		return false;
	}

	public bool Equals(KeyTime other)
	{
		return Equals(this, other);
	}

	public static bool Equals(KeyTime first, KeyTime second)
	{
		return first.TimeSpan.Equals(second.TimeSpan);
	}

	public static bool operator ==(KeyTime t1, KeyTime t2)
	{
		return Equals(t1, t2);
	}

	public static bool operator !=(KeyTime t1, KeyTime t2)
	{
		return !Equals(t1, t2);
	}

	int IComparable<KeyTime>.CompareTo(KeyTime other)
	{
		return TimeSpan.CompareTo(other.TimeSpan);
	}

	public static bool operator <(KeyTime keytime1, KeyTime keytime2)
	{
		return keytime1.TimeSpan < keytime2.TimeSpan;
	}

	public static bool operator >(KeyTime keytime1, KeyTime keytime2)
	{
		return keytime1.TimeSpan > keytime2.TimeSpan;
	}

	public static bool operator <=(KeyTime keytime1, KeyTime keytime2)
	{
		return keytime1.TimeSpan <= keytime2.TimeSpan;
	}

	public static bool operator >=(KeyTime keytime1, KeyTime keytime2)
	{
		return keytime1.TimeSpan >= keytime2.TimeSpan;
	}

	public override string ToString()
	{
		return TimeSpan.ToXamlString(CultureInfo.InvariantCulture);
	}
}
