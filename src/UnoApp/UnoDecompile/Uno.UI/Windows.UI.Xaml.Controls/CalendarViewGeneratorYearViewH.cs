using System;
using System.Collections.Generic;
using Uno.Extensions;
using Windows.Globalization;
using Windows.UI.Xaml.Automation;

namespace Windows.UI.Xaml.Controls;

internal class CalendarViewGeneratorYearViewHost : CalendarViewGeneratorHost
{
	protected override CalendarViewBaseItem GetContainer(object pItem, DependencyObject pRecycledContainer)
	{
		return new CalendarViewItem();
	}

	internal override void PrepareItemContainer(DependencyObject pContainer, object pItem)
	{
		CalendarViewItem calendarViewItem = (CalendarViewItem)pContainer;
		DateTimeOffset dateTimeOffset = (DateTimeOffset)pItem;
		GetCalendar().SetDateTime(dateTimeOffset);
		calendarViewItem.DateBase = dateTimeOffset;
		string value = GetCalendar().MonthAsFullString();
		AutomationProperties.SetName(calendarViewItem, value);
		string mainText = GetCalendar().MonthAsString(0);
		calendarViewItem.UpdateMainText(mainText);
		bool flag = false;
		flag = base.Owner.IsGroupLabelVisible;
		UpdateLabel(calendarViewItem, flag);
		Thickness thickness2 = (calendarViewItem.Margin = new Thickness(1.0, 1.0, 1.0, 1.0));
		Thickness thickness4 = (calendarViewItem.FocusVisualMargin = new Thickness(-2.0, -2.0, -2.0, -2.0));
		calendarViewItem.UseSystemFocusVisuals = true;
		base.PrepareItemContainer(pContainer, pItem);
	}

	internal override void UpdateLabel(CalendarViewBaseItem pItem, bool isLabelVisible)
	{
		bool flag = false;
		if (isLabelVisible)
		{
			Calendar calendar = GetCalendar();
			int num = 0;
			int num2 = 0;
			DateTimeOffset dateBase = pItem.DateBase;
			calendar.SetDateTime(dateBase);
			num2 = calendar.FirstMonthInThisYear;
			num = calendar.Month;
			flag = num2 == num;
			if (flag)
			{
				string labelText = calendar.YearAsString();
				pItem.UpdateLabelText(labelText);
			}
		}
		pItem.ShowLabelText(flag);
	}

	internal override bool GetIsFirstItemInScope(int index)
	{
		bool flag = false;
		if (index == 0)
		{
			return true;
		}
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		int num = 0;
		int num2 = 0;
		dateTimeOffset = GetDateAt((uint)index);
		Calendar calendar = GetCalendar();
		calendar.SetDateTime(dateTimeOffset);
		num = calendar.Month;
		num2 = calendar.FirstMonthInThisYear;
		return num == num2;
	}

	protected override int GetUnit()
	{
		return GetCalendar().Month;
	}

	protected override void SetUnit(int value)
	{
		GetCalendar().Month = value;
	}

	protected override void AddUnits(int value)
	{
		GetCalendar().AddMonths(value);
	}

	protected override void AddScopes(int value)
	{
		GetCalendar().AddYears(value);
	}

	protected override int GetFirstUnitInThisScope()
	{
		return GetCalendar().FirstMonthInThisYear;
	}

	protected override int GetLastUnitInThisScope()
	{
		return GetCalendar().LastMonthInThisYear;
	}

	protected override void OnScopeChanged()
	{
		m_pHeaderText = base.Owner.FormatYearName(m_maxDateOfCurrentScope);
	}

	internal override List<string> GetPossibleItemStrings()
	{
		List<string> possibleItemStrings = m_possibleItemStrings;
		if (m_possibleItemStrings.Empty())
		{
			int num = 3;
			DateTimeOffset dateTime = default(DateTimeOffset);
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			Calendar calendar = GetCalendar();
			calendar.SetToMin();
			for (int i = 0; i < num; i++)
			{
				num3 = calendar.NumberOfMonthsInThisYear;
				if (num3 > num2)
				{
					num2 = num3;
					dateTime = calendar.GetDateTime();
				}
				calendar.AddYears(1);
			}
			calendar.SetDateTime(dateTime);
			num4 = (calendar.Month = calendar.FirstMonthInThisYear);
			for (int j = 0; j < num2; j++)
			{
				string item = calendar.MonthAsString(0);
				m_possibleItemStrings.Add(item);
				calendar.AddMonths(1);
			}
		}
		return m_possibleItemStrings;
	}

	internal override int CompareDate(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return base.Owner.DateComparer.CompareMonth(lhs, rhs);
	}

	protected override long GetAverageTicksPerUnit()
	{
		return 26280000000000L;
	}

	protected internal override int GetMaximumScopeSize()
	{
		return 13;
	}
}
