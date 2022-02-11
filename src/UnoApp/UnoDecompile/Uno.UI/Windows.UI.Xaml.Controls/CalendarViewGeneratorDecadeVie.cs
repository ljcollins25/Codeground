using System;
using System.Collections.Generic;
using Uno.Extensions;
using Windows.Globalization;

namespace Windows.UI.Xaml.Controls;

internal class CalendarViewGeneratorDecadeViewHost : CalendarViewGeneratorHost
{
	private const int s_decade = 10;

	protected override CalendarViewBaseItem GetContainer(object pItem, DependencyObject pRecycledContainer)
	{
		return new CalendarViewItem();
	}

	internal override void PrepareItemContainer(DependencyObject pContainer, object pItem)
	{
		DateTimeOffset dateTimeOffset = (DateTimeOffset)pItem;
		CalendarViewItem calendarViewItem = (CalendarViewItem)pContainer;
		calendarViewItem.DateBase = dateTimeOffset;
		GetCalendar().SetDateTime(dateTimeOffset);
		string mainText = GetCalendar().YearAsString();
		calendarViewItem.UpdateMainText(mainText);
		Thickness thickness2 = (calendarViewItem.Margin = new Thickness(1.0, 1.0, 1.0, 1.0));
		Thickness thickness4 = (calendarViewItem.FocusVisualMargin = new Thickness(-2.0, -2.0, -2.0, -2.0));
		calendarViewItem.UseSystemFocusVisuals = true;
		base.PrepareItemContainer(pContainer, pItem);
	}

	internal override bool GetIsFirstItemInScope(int index)
	{
		bool flag = false;
		if (index == 0)
		{
			flag = true;
		}
		else
		{
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			int num = 0;
			dateTimeOffset = GetDateAt((uint)index);
			Calendar calendar = GetCalendar();
			calendar.SetDateTime(dateTimeOffset);
			num = calendar.Year;
			flag = num % 10 == 0;
			if (!flag)
			{
				int num2 = 0;
				num2 = calendar.FirstYearInThisEra;
				flag = num == num2;
			}
		}
		return flag;
	}

	protected override int GetUnit()
	{
		return GetCalendar().Year;
	}

	protected override void SetUnit(int value)
	{
		GetCalendar().Year = value;
	}

	protected override void AddUnits(int value)
	{
		GetCalendar().AddYears(value);
	}

	protected override void AddScopes(int value)
	{
		if (value == 0)
		{
			return;
		}
		Calendar calendar = GetCalendar();
		if (!base.Owner.IsMultipleEraCalendar)
		{
			calendar.AddYears(value * 10);
			return;
		}
		bool flag = value > 0;
		if (!flag)
		{
			value = -value;
		}
		while (value-- > 0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			num = calendar.Era;
			num2 = calendar.Year;
			num3 = calendar.LastYearInThisEra;
			if (num2 == 10 && !flag)
			{
				calendar.AddYears(-9);
			}
			else
			{
				calendar.AddYears(flag ? 10 : (-10));
			}
			num4 = calendar.Era;
			if (num == num4)
			{
				continue;
			}
			if (flag)
			{
				if (num2 + 10 > num3)
				{
					num5 = (calendar.Year = calendar.FirstYearInThisEra);
				}
			}
			else if (num2 < 10)
			{
				num5 = (calendar.Year = calendar.LastYearInThisEra);
			}
			num6 = (calendar.Month = calendar.FirstMonthInThisYear);
			num7 = (calendar.Day = calendar.FirstDayInThisMonth);
		}
	}

	protected override int GetFirstUnitInThisScope()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num = GetCalendar().Year;
		num3 = num - num % 10;
		num2 = GetCalendar().FirstYearInThisEra;
		if (num3 < num2)
		{
			num3 = num2;
		}
		return num3;
	}

	protected override int GetLastUnitInThisScope()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num = GetCalendar().Year;
		num3 = num - num % 10 + 10 - 1;
		num2 = GetCalendar().LastYearInThisEra;
		if (num3 > num2)
		{
			num3 = num2;
		}
		return num3;
	}

	protected override void OnScopeChanged()
	{
		string text = " - ";
		GetCalendar().SetDateTime(m_minDateOfCurrentScope);
		string text2 = GetCalendar().YearAsString();
		GetCalendar().SetDateTime(m_maxDateOfCurrentScope);
		string text3 = GetCalendar().YearAsString();
		string text4 = text2 + text;
		m_pHeaderText = text4 + text3;
	}

	internal override List<string> GetPossibleItemStrings()
	{
		List<string> possibleItemStrings = m_possibleItemStrings;
		if (m_possibleItemStrings.Empty())
		{
			Calendar calendar = GetCalendar();
			calendar.SetToNow();
			string item = calendar.YearAsString();
			m_possibleItemStrings.Add(item);
		}
		return possibleItemStrings;
	}

	internal override int CompareDate(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return base.Owner.DateComparer.CompareYear(lhs, rhs);
	}

	protected override long GetAverageTicksPerUnit()
	{
		return 315360000000000L;
	}

	protected internal override int GetMaximumScopeSize()
	{
		return 10;
	}

	internal override void UpdateLabel(CalendarViewBaseItem pItem, bool isLabelVisible)
	{
		throw new NotImplementedException();
	}
}
