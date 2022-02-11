using System;
using Windows.Globalization;

namespace DirectUI;

internal class DateComparer
{
	private Calendar m_spCalendar;

	public Func<DateTimeOffset, DateTimeOffset, bool> LessThanComparer => (DateTimeOffset lhs, DateTimeOffset rhs) => LessThan(lhs, rhs);

	public Func<DateTimeOffset, DateTimeOffset, bool> AreEquivalentComparer => (DateTimeOffset lhs, DateTimeOffset rhs) => AreEquivalent(lhs, rhs);

	internal bool AreEquivalent(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return CompareDay(lhs, rhs) == 0;
	}

	internal bool LessThan(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return CompareDay(lhs, rhs) == -1;
	}

	public void SetCalendarForComparison(Calendar pCalendar)
	{
		m_spCalendar = pCalendar.Clone();
	}

	internal int CompareDay(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return CompareDate(lhs, rhs, 900000000000L, (Calendar c) => c.Day);
	}

	internal int CompareMonth(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return CompareDate(lhs, rhs, 26820000000000L, (Calendar c) => c.Month);
	}

	internal int CompareYear(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return CompareDate(lhs, rhs, 316260000000000L, (Calendar c) => c.Year);
	}

	private int CompareDate(DateTimeOffset lhs, DateTimeOffset rhs, long threshold, Func<Calendar, int> getUnit)
	{
		int num = 1;
		int num2 = 1;
		lhs = lhs.ToUniversalTime();
		rhs = rhs.ToUniversalTime();
		long num3 = lhs.Ticks - rhs.Ticks;
		if (num3 < 0)
		{
			num3 = -num3;
			num = -1;
		}
		if (num3 < threshold)
		{
			int num4 = 0;
			int num5 = 0;
			m_spCalendar.SetDateTime(lhs);
			num4 = getUnit(m_spCalendar);
			m_spCalendar.SetDateTime(rhs);
			num5 = getUnit(m_spCalendar);
			if (num4 == num5)
			{
				num2 = 0;
			}
		}
		return num2 * num;
	}
}
