using System;
using System.Collections.Generic;
using Uno;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class DatePickerFlyoutPresenter : Control, IDatePickerFlyoutPresenter
{
	private const long DEFAULT_DATE_TICKS = 504910368000000000L;

	private const bool PICKER_SHOULD_LOOP = true;

	private const int DATEPICKER_RTL_CHARACTER_CODE = 8207;

	private const int DATEPICKER_MIN_MAX_YEAR_DEAFULT_OFFSET = 100;

	private const int DATEPICKER_SENTINELTIME_HOUR = 12;

	private const int DATEPICKER_SENTINELTIME_MINUTE = 0;

	private const int DATEPICKER_SENTINELTIME_SECOND = 0;

	private const int DATEPICKER_WRAP_AROUND_MONTHS_FIRST_INDEX = 1;

	private const string _dayLoopingSelectorAutomationId = "DayLoopingSelector";

	private const string _monthLoopingSelectorAutomationId = "MonthLoopingSelector";

	private const string _yearLoopingSelectorAutomationId = "YearLoopingSelector";

	private const string _firstPickerHostName = "FirstPickerHost";

	private const string _secondPickerHostName = "SecondPickerHost";

	private const string _thirdPickerHostName = "ThirdPickerHost";

	private const string _backgroundName = "Background";

	private const string _contentPanelName = "ContentPanel";

	private const string _titlePresenterName = "TitlePresenter";

	private IList<object> _tpDaySource;

	private IList<object> _tpMonthSource;

	private IList<object> _tpYearSource;

	private LoopingSelector _tpDayPicker;

	private LoopingSelector _tpMonthPicker;

	private LoopingSelector _tpYearPicker;

	private Control _tpFirstPickerAsControl;

	private Control _tpSecondPickerAsControl;

	private Control _tpThirdPickerAsControl;

	private Border _tpFirstPickerHost;

	private Border _tpSecondPickerHost;

	private Border _tpThirdPickerHost;

	private Grid _tpPickerHostGrid;

	private ColumnDefinition _tpDayColumn;

	private ColumnDefinition _tpMonthColumn;

	private ColumnDefinition _tpYearColumn;

	private ColumnDefinition _tpFirstSpacerColumn;

	private ColumnDefinition _tpSecondSpacerColumn;

	private UIElement _tpFirstPickerSpacing;

	private UIElement _tpSecondPickerSpacing;

	private Border _tpBackgroundBorder;

	private TextBlock _tpTitlePresenter;

	private FrameworkElement _tpContentPanel;

	private UIElement _tpAcceptDismissHostGrid;

	private UIElement _tpAcceptButton;

	private UIElement _tpDismissButton;

	private bool _acceptDismissButtonsVisible;

	private Calendar _tpCalendar;

	private Calendar _tpBaselineCalendar;

	private DateTimeFormatter _tpPrimaryYearFormatter;

	private string _strYearCalendarIdentifier;

	private DateTimeFormatter _tpPrimaryMonthFormatter;

	private string _strMonthCalendarIdentifier;

	private DateTimeFormatter _tpPrimaryDayFormatter;

	private string _strDayCalendarIdentifier;

	private DateTimeOffset _startDate;

	private DateTimeOffset _endDate;

	private bool _reactionToSelectionChangeAllowed;

	private bool _hasValidYearRange;

	private int _numberOfYears;

	private string _calendarIdentifier;

	private string _title;

	private bool _dayVisible;

	private bool _monthVisible;

	private bool _yearVisible;

	private DateTimeOffset _minYear;

	private DateTimeOffset _maxYear;

	private DateTimeOffset _date;

	private string _dayFormat;

	private string _monthFormat;

	private string _yearFormat;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDefaultShadowEnabled
	{
		get
		{
			return (bool)GetValue(IsDefaultShadowEnabledProperty);
		}
		set
		{
			SetValue(IsDefaultShadowEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDefaultShadowEnabledProperty { get; } = DependencyProperty.Register("IsDefaultShadowEnabled", typeof(bool), typeof(DatePickerFlyoutPresenter), new FrameworkPropertyMetadata(false));


	public DatePickerFlyoutPresenter()
	{
		_dayVisible = true;
		_monthVisible = true;
		_yearVisible = true;
		_minYear = default(DateTimeOffset);
		_maxYear = default(DateTimeOffset);
		_acceptDismissButtonsVisible = true;
		base.DefaultStyleKey = typeof(DatePickerFlyoutPresenter);
	}

	protected override void OnApplyTemplate()
	{
		UIElementCollection uIElementCollection = null;
		if (_tpDayPicker != null)
		{
			_tpDayPicker.SelectionChanged -= OnSelectorSelectionChanged;
		}
		if (_tpMonthPicker != null)
		{
			_tpMonthPicker.SelectionChanged -= OnSelectorSelectionChanged;
		}
		if (_tpYearPicker != null)
		{
			_tpYearPicker.SelectionChanged -= OnSelectorSelectionChanged;
		}
		_tpBackgroundBorder = null;
		_tpTitlePresenter = null;
		_tpDayPicker = null;
		_tpMonthPicker = null;
		_tpYearPicker = null;
		_tpFirstPickerHost = null;
		_tpSecondPickerHost = null;
		_tpThirdPickerHost = null;
		_tpContentPanel = null;
		_tpAcceptDismissHostGrid = null;
		_tpAcceptButton = null;
		_tpDismissButton = null;
		Border border = (_tpBackgroundBorder = GetTemplateChild<Border>("Background"));
		if ((_tpTitlePresenter = GetTemplateChild<TextBlock>("TitlePresenter")) != null)
		{
			UIElement tpTitlePresenter = _tpTitlePresenter;
			tpTitlePresenter.Visibility = (string.IsNullOrWhiteSpace(_title) ? Visibility.Collapsed : Visibility.Visible);
			_tpTitlePresenter.Text = _title;
		}
		Border border2 = (_tpFirstPickerHost = GetTemplateChild<Border>("FirstPickerHost"));
		Border border3 = (_tpSecondPickerHost = GetTemplateChild<Border>("SecondPickerHost"));
		Border border4 = (_tpThirdPickerHost = GetTemplateChild<Border>("ThirdPickerHost"));
		FrameworkElement frameworkElement = (_tpContentPanel = GetTemplateChild<FrameworkElement>("ContentPanel"));
		ColumnDefinition columnDefinition = (_tpDayColumn = GetTemplateChild<ColumnDefinition>("DayColumn"));
		ColumnDefinition columnDefinition2 = (_tpMonthColumn = GetTemplateChild<ColumnDefinition>("MonthColumn"));
		ColumnDefinition columnDefinition3 = (_tpYearColumn = GetTemplateChild<ColumnDefinition>("YearColumn"));
		ColumnDefinition columnDefinition4 = (_tpFirstSpacerColumn = GetTemplateChild<ColumnDefinition>("FirstSpacerColumn"));
		ColumnDefinition columnDefinition5 = (_tpSecondSpacerColumn = GetTemplateChild<ColumnDefinition>("SecondSpacerColumn"));
		UIElement uIElement = (_tpFirstPickerSpacing = GetTemplateChild<UIElement>("FirstPickerSpacing"));
		UIElement uIElement2 = (_tpSecondPickerSpacing = GetTemplateChild<UIElement>("SecondPickerSpacing"));
		Grid grid = (_tpPickerHostGrid = GetTemplateChild<Grid>("PickerHostGrid"));
		UIElement uIElement3 = (_tpAcceptDismissHostGrid = GetTemplateChild<UIElement>("AcceptDismissHostGrid"));
		UIElement uIElement4 = (_tpAcceptButton = GetTemplateChild<UIElement>("AcceptButton"));
		UIElement uIElement5 = (_tpDismissButton = GetTemplateChild<UIElement>("DismissButton"));
		Panel tpPickerHostGrid = _tpPickerHostGrid;
		if (tpPickerHostGrid != null)
		{
			uIElementCollection = tpPickerHostGrid.Children;
		}
		object value;
		int itemHeight = ((!Application.Current.Resources.TryGetValue("DatePickerFlyoutPresenterItemHeight", out value) || !(value is double num)) ? 44 : ((int)num));
		object value2;
		Thickness padding = ((!Application.Current.Resources.TryGetValue("DatePickerFlyoutPresenterItemPadding", out value2) || !(value2 is Thickness)) ? new Thickness(0.0, 3.0, 0.0, 5.0) : ((Thickness)value2));
		object value3;
		Thickness padding2 = ((!Application.Current.Resources.TryGetValue("DatePickerFlyoutPresenterMonthPadding", out value3) || !(value3 is Thickness)) ? new Thickness(9.0, 3.0, 0.0, 5.0) : ((Thickness)value3));
		if (_tpFirstPickerHost != null || _tpPickerHostGrid != null)
		{
			LoopingSelector loopingSelector = (_tpMonthPicker = new LoopingSelector
			{
				ShouldLoop = true
			});
			Control control = loopingSelector;
			loopingSelector.ItemHeight = itemHeight;
			control.HorizontalContentAlignment = HorizontalAlignment.Left;
			control.Padding = padding2;
			loopingSelector.Name = "MonthLoopingSelector";
			if (_tpFirstPickerHost != null)
			{
				_tpFirstPickerHost.Child = loopingSelector;
			}
			else
			{
				uIElementCollection?.Add(loopingSelector);
			}
		}
		if (_tpSecondPickerHost != null || _tpPickerHostGrid != null)
		{
			LoopingSelector loopingSelector2 = (_tpDayPicker = new LoopingSelector
			{
				ShouldLoop = true
			});
			Control control2 = loopingSelector2;
			loopingSelector2.ItemHeight = itemHeight;
			control2.HorizontalContentAlignment = HorizontalAlignment.Center;
			control2.Padding = padding;
			control2.Name = "DayLoopingSelector";
			if (_tpSecondPickerHost != null)
			{
				_tpSecondPickerHost.Child = loopingSelector2;
			}
			else
			{
				uIElementCollection?.Add(loopingSelector2);
			}
		}
		if (_tpThirdPickerHost != null || _tpPickerHostGrid != null)
		{
			LoopingSelector loopingSelector3 = (_tpYearPicker = new LoopingSelector
			{
				ShouldLoop = true
			});
			Control control3 = loopingSelector3;
			loopingSelector3.ItemHeight = itemHeight;
			control3.HorizontalContentAlignment = HorizontalAlignment.Center;
			control3.Padding = padding;
			control3.Name = "YearLoopingSelector";
			if (_tpSecondPickerHost != null)
			{
				_tpThirdPickerHost.Child = loopingSelector3;
			}
			else
			{
				uIElementCollection?.Add(loopingSelector3);
			}
		}
		if (_tpDayPicker != null)
		{
			_tpDayPicker.SelectionChanged += OnSelectorSelectionChanged;
		}
		if (_tpMonthPicker != null)
		{
			_tpMonthPicker.SelectionChanged += OnSelectorSelectionChanged;
		}
		if (_tpYearPicker != null)
		{
			_tpYearPicker.SelectionChanged += OnSelectorSelectionChanged;
		}
		if (_tpYearSource == null || _tpMonthSource == null || _tpDaySource == null)
		{
			IList<object> list = (_tpDaySource = new List<object>());
			list = (_tpMonthSource = new List<object>());
			list = (_tpYearSource = new List<object>());
		}
		if (_calendarIdentifier != null)
		{
			RefreshSetup();
		}
		((IDatePickerFlyoutPresenter)this).SetAcceptDismissButtonsVisibility(_acceptDismissButtonsVisible);
		bool isDefaultShadowEnabled = IsDefaultShadowEnabled;
	}

	void IDatePickerFlyoutPresenter.PullPropertiesFromOwner(DatePickerFlyout pOwner)
	{
		string title = null;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset3 = default(DateTimeOffset);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string calendarIdentifier = _calendarIdentifier;
		string calendarIdentifier2 = pOwner.CalendarIdentifier;
		flag = pOwner.MonthVisible;
		flag2 = pOwner.YearVisible;
		flag3 = pOwner.DayVisible;
		dateTimeOffset2 = pOwner.MinYear;
		dateTimeOffset3 = pOwner.MaxYear;
		dateTimeOffset = pOwner.Date;
		string dayFormat = pOwner.DayFormat;
		string monthFormat = pOwner.MonthFormat;
		string yearFormat = pOwner.YearFormat;
		num4 = StringComparer.Ordinal.Compare(calendarIdentifier, calendarIdentifier2);
		num = StringComparer.Ordinal.Compare(_dayFormat, dayFormat);
		num2 = StringComparer.Ordinal.Compare(_monthFormat, monthFormat);
		num3 = StringComparer.Ordinal.Compare(_yearFormat, yearFormat);
		bool flag4 = num != 0;
		bool flag5 = num2 != 0;
		bool flag6 = num3 != 0;
		bool flag7 = flag3 != _dayVisible || flag != _monthVisible || flag2 != _yearVisible;
		bool flag8 = dateTimeOffset3 != _maxYear || dateTimeOffset2 != _minYear;
		_calendarIdentifier = calendarIdentifier2;
		_title = title;
		if (_tpTitlePresenter != null)
		{
			_tpTitlePresenter.Visibility = (string.IsNullOrWhiteSpace(_title) ? Visibility.Collapsed : Visibility.Visible);
			_tpTitlePresenter.Text = _title;
		}
		_dayVisible = flag3;
		_monthVisible = flag;
		_yearVisible = flag2;
		_minYear = dateTimeOffset2;
		_maxYear = dateTimeOffset3;
		_dayFormat = dayFormat;
		_monthFormat = monthFormat;
		_yearFormat = yearFormat;
		if (num4 != 0)
		{
			OnCalendarIdentifierPropertyChanged(calendarIdentifier);
		}
		if (flag4)
		{
			_tpPrimaryDayFormatter = null;
		}
		if (flag5)
		{
			_tpPrimaryMonthFormatter = null;
		}
		if (flag6)
		{
			_tpPrimaryYearFormatter = null;
		}
		if (flag8 || flag4 || flag5 || flag6)
		{
			RefreshSetup();
		}
		if (flag7)
		{
			UpdateOrderAndLayout();
		}
		SetDate(dateTimeOffset);
	}

	void IDatePickerFlyoutPresenter.SetAcceptDismissButtonsVisibility(bool isVisible)
	{
		if (_tpAcceptDismissHostGrid != null)
		{
			_tpAcceptDismissHostGrid.Visibility = ((!isVisible) ? Visibility.Collapsed : Visibility.Visible);
		}
		else if (_tpAcceptButton != null && _tpDismissButton != null)
		{
			_tpAcceptButton.Visibility = ((!isVisible) ? Visibility.Collapsed : Visibility.Visible);
			_tpDismissButton.Visibility = ((!isVisible) ? Visibility.Collapsed : Visibility.Visible);
		}
		_acceptDismissButtonsVisible = isVisible;
	}

	DateTimeOffset IDatePickerFlyoutPresenter.GetDate()
	{
		return _date;
	}

	private void SetDate(DateTimeOffset newDate)
	{
		if (newDate.Ticks == 504910368000000000L)
		{
			Calendar calendar = CreateNewCalendar(_calendarIdentifier);
			calendar.SetToNow();
			newDate = calendar.GetDateTime();
		}
		if (newDate != _date)
		{
			DateTimeOffset date = _date;
			_date = newDate;
			OnDateChanged(date, _date);
		}
	}

	private void OnKeyDownImpl(KeyRoutedEventArgs pEventArgs)
	{
		DateTimePickerFlyoutHelper.OnKeyDownImpl(pEventArgs, _tpFirstPickerAsControl, _tpSecondPickerAsControl, _tpThirdPickerAsControl, _tpContentPanel);
	}

	private void ClearSelectors(bool clearDay, bool clearMonth, bool clearYear)
	{
		if (_tpDayPicker != null && clearDay)
		{
			_tpDayPicker.Items = null;
		}
		if (_tpMonthPicker != null && clearMonth)
		{
			_tpMonthPicker.Items = null;
		}
		if (_tpYearPicker != null && clearYear)
		{
			_tpYearPicker.Items = null;
		}
	}

	private void GetIndices(out int yearIndex, out int monthIndex, out int dayIndex)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		_tpBaselineCalendar.SetDateTime(ClampDate(_date, _startDate, _endDate));
		_tpCalendar.SetDateTime(_startDate);
		yearIndex = GetYearDifference(_tpCalendar, _tpBaselineCalendar);
		num2 = _tpBaselineCalendar.FirstMonthInThisYear;
		num = _tpBaselineCalendar.Month;
		num3 = _tpBaselineCalendar.NumberOfMonthsInThisYear;
		if (num - num2 >= 0)
		{
			monthIndex = num - num2;
		}
		else
		{
			monthIndex = num - num2 + num3;
		}
		num2 = _tpBaselineCalendar.FirstDayInThisMonth;
		num = _tpBaselineCalendar.Day;
		dayIndex = num - num2;
	}

	private void RefreshSetup()
	{
		PreventReactionToSelectionChange();
		UpdateState();
		if (_hasValidYearRange)
		{
			int yearIndex = 0;
			int monthIndex = 0;
			int dayIndex = 0;
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			RefreshSourcesAndSetSelectedIndices(refreshDay: true, refreshMonth: true, refreshYear: true);
			GetIndices(out yearIndex, out monthIndex, out dayIndex);
			dateTimeOffset = GetDateFromIndices(yearIndex, monthIndex, dayIndex);
			SetDate(dateTimeOffset);
		}
		AllowReactionToSelectionChange();
	}

	private void RefreshSourcesAndSetSelectedIndices(bool refreshDay, bool refreshMonth, bool refreshYear)
	{
		int yearIndex = 0;
		int monthIndex = 0;
		int dayIndex = 0;
		PreventReactionToSelectionChange();
		GetIndices(out yearIndex, out monthIndex, out dayIndex);
		if (_tpYearPicker != null)
		{
			if (refreshYear)
			{
				GenerateYears();
				_tpYearPicker.Items = _tpYearSource;
			}
			_tpYearPicker.SelectedIndex = yearIndex;
		}
		if (_tpMonthPicker != null)
		{
			if (refreshMonth)
			{
				GenerateMonths(yearIndex);
				_tpMonthPicker.Items = _tpMonthSource;
			}
			_tpMonthPicker.SelectedIndex = monthIndex;
		}
		if (_tpDayPicker != null)
		{
			if (refreshDay)
			{
				GenerateDays(yearIndex, monthIndex);
				_tpDayPicker.Items = _tpDaySource;
			}
			_tpDayPicker.SelectedIndex = dayIndex;
		}
		AllowReactionToSelectionChange();
	}

	private void GenerateYears()
	{
		DateTimeFormatter yearFormatter = GetYearFormatter(_calendarIdentifier);
		IList<object> tpYearSource = _tpYearSource;
		object[] array = new object[_numberOfYears];
		for (int i = 0; i < _numberOfYears; i++)
		{
			_tpCalendar.SetDateTime(_startDate);
			_tpCalendar.AddYears(i);
			_tpCalendar.Hour = 12;
			_tpCalendar.Minute = 0;
			_tpCalendar.Second = 0;
			DateTimeOffset dateTime = _tpCalendar.GetDateTime();
			DatePickerFlyoutItem datePickerFlyoutItem = ((tpYearSource.Count > i) ? (tpYearSource[i] as DatePickerFlyoutItem) : null) ?? new DatePickerFlyoutItem();
			string text2 = (datePickerFlyoutItem.PrimaryText = yearFormatter.Format(dateTime));
			datePickerFlyoutItem.SecondaryText = "";
			array[i] = datePickerFlyoutItem;
		}
		_tpYearSource = new List<object>(array);
	}

	private void GenerateMonths(int yearOffset)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		DateTimeFormatter monthFormatter = GetMonthFormatter(_calendarIdentifier);
		_tpCalendar.SetDateTime(_startDate);
		_tpCalendar.AddYears(yearOffset);
		_tpCalendar.Hour = 12;
		_tpCalendar.Minute = 0;
		_tpCalendar.Second = 0;
		num2 = _tpCalendar.NumberOfMonthsInThisYear;
		num3 = _tpCalendar.FirstMonthInThisYear;
		IList<object> tpMonthSource = _tpMonthSource;
		object[] array = new object[num2];
		for (num = 0; num < num2; num++)
		{
			_tpCalendar.Month = num3;
			_tpCalendar.AddMonths(num);
			DateTimeOffset dateTime = _tpCalendar.GetDateTime();
			DatePickerFlyoutItem datePickerFlyoutItem = ((tpMonthSource.Count > num) ? (tpMonthSource[num] as DatePickerFlyoutItem) : null) ?? new DatePickerFlyoutItem();
			string text2 = (datePickerFlyoutItem.PrimaryText = monthFormatter.Format(dateTime));
			array[num] = datePickerFlyoutItem;
		}
		_tpMonthSource = new List<object>(array);
	}

	private void GenerateDays(int yearOffset, int monthOffset)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		DateTimeFormatter dayFormatter = GetDayFormatter(_calendarIdentifier);
		_tpCalendar.SetDateTime(_startDate);
		_tpCalendar.AddYears(yearOffset);
		num4 = _tpCalendar.FirstMonthInThisYear;
		_tpCalendar.Month = num4;
		_tpCalendar.AddMonths(monthOffset);
		num2 = _tpCalendar.NumberOfDaysInThisMonth;
		num3 = _tpCalendar.FirstDayInThisMonth;
		_tpCalendar.Hour = 12;
		_tpCalendar.Minute = 0;
		_tpCalendar.Second = 0;
		IList<object> tpDaySource = _tpDaySource;
		object[] array = new object[num2];
		for (num = 0; num < num2; num++)
		{
			_tpCalendar.Day = num3 + num;
			DateTimeOffset dateTime = _tpCalendar.GetDateTime();
			DatePickerFlyoutItem datePickerFlyoutItem = ((tpDaySource.Count > num) ? (tpDaySource[num] as DatePickerFlyoutItem) : null) ?? new DatePickerFlyoutItem();
			string text2 = (datePickerFlyoutItem.PrimaryText = dayFormatter.Format(dateTime));
			array[num] = datePickerFlyoutItem;
		}
		_tpDaySource = new List<object>(array);
	}

	private void OnSelectorSelectionChanged(object sender, SelectionChangedEventArgs pArgs)
	{
		if (IsReactionToSelectionChangeAllowed())
		{
			int yearIndex = 0;
			int monthIndex = 0;
			int dayIndex = 0;
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			if (_tpYearPicker != null)
			{
				yearIndex = _tpYearPicker.SelectedIndex;
			}
			if (_tpMonthPicker != null)
			{
				monthIndex = _tpMonthPicker.SelectedIndex;
			}
			if (_tpDayPicker != null)
			{
				dayIndex = _tpDayPicker.SelectedIndex;
			}
			dateTimeOffset = GetDateFromIndices(yearIndex, monthIndex, dayIndex);
			SetDate(dateTimeOffset);
		}
	}

	private DateTimeOffset GetDateFromIndices(int yearIndex, int monthIndex, int dayIndex)
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		int num13 = 0;
		int num14 = 0;
		dateTimeOffset = ClampDate(_date, _startDate, _endDate);
		_tpCalendar.SetDateTime(dateTimeOffset);
		num4 = _tpCalendar.Period;
		num5 = _tpCalendar.Hour;
		num6 = _tpCalendar.Minute;
		num7 = _tpCalendar.Second;
		num8 = _tpCalendar.Nanosecond;
		num11 = _tpCalendar.Year;
		num12 = _tpCalendar.Month;
		num13 = _tpCalendar.Day;
		_tpCalendar.SetDateTime(_startDate);
		_tpCalendar.Period = num4;
		_tpCalendar.Hour = num5;
		_tpCalendar.Minute = num6;
		_tpCalendar.Second = num7;
		_tpCalendar.Nanosecond = num8;
		_tpCalendar.AddYears(yearIndex);
		num9 = _tpCalendar.Year;
		num2 = _tpCalendar.FirstMonthInThisYear;
		num3 = _tpCalendar.NumberOfMonthsInThisYear;
		num14 = _tpCalendar.LastMonthInThisYear;
		if (num2 <= num14)
		{
			num = ((num11 != num9) ? Math.Max(Math.Min(num12, num2 + num3 - 1), num2) : Math.Max(Math.Min(monthIndex + num2, num2 + num3 - 1), num2));
		}
		else
		{
			num = ((monthIndex + num2 <= num3) ? (monthIndex + num2) : (monthIndex + num2 - num3));
			if (num11 != num9)
			{
				num = Math.Max(Math.Min(num12, num3), 1);
			}
		}
		_tpCalendar.Month = num;
		num10 = _tpCalendar.Month;
		num2 = _tpCalendar.FirstDayInThisMonth;
		num3 = _tpCalendar.NumberOfDaysInThisMonth;
		num = Math.Max(Math.Min(dayIndex + num2, num2 + num3 - 1), num2);
		if (num11 != num9 || num12 != num10)
		{
			num = Math.Max(Math.Min(num13, num2 + num3 - 1), num2);
		}
		_tpCalendar.Day = num;
		return _tpCalendar.GetDateTime();
	}

	private void OnCalendarIdentifierPropertyChanged(string oldValue)
	{
		try
		{
			RefreshSetup();
		}
		catch
		{
			_calendarIdentifier = null;
			RefreshSetup();
		}
	}

	private void OnDateChanged(DateTimeOffset oldValue, DateTimeOffset newValue)
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		if (!_hasValidYearRange)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool refreshMonth = false;
		bool refreshDay = false;
		dateTimeOffset = ClampDate(newValue, _startDate, _endDate);
		dateTimeOffset2 = ClampDate(oldValue, _startDate, _endDate);
		if (dateTimeOffset.ToUniversalTime() != newValue.ToUniversalTime())
		{
			SetDate(dateTimeOffset);
			return;
		}
		if (dateTimeOffset.ToUniversalTime() == dateTimeOffset2.ToUniversalTime())
		{
			refreshMonth = true;
			refreshDay = true;
		}
		else
		{
			_tpCalendar.SetDateTime(dateTimeOffset2);
			num2 = _tpCalendar.Year;
			num4 = _tpCalendar.Month;
			_tpCalendar.SetDateTime(dateTimeOffset);
			num = _tpCalendar.Year;
			num3 = _tpCalendar.Month;
			if (num2 != num)
			{
				refreshMonth = true;
				refreshDay = true;
			}
			else if (num4 != num3)
			{
				refreshDay = true;
			}
		}
		RefreshSourcesAndSetSelectedIndices(refreshDay, refreshMonth, refreshYear: false);
	}

	private DateTimeFormatter GetYearFormatter(string strCalendarIdentifier)
	{
		if (_tpPrimaryYearFormatter == null || !(strCalendarIdentifier == _strYearCalendarIdentifier))
		{
			_tpPrimaryYearFormatter = null;
			DateTimeFormatter dateTimeFormatter = (_tpPrimaryYearFormatter = CreateNewFormatter(_yearFormat, strCalendarIdentifier));
			_strYearCalendarIdentifier = strCalendarIdentifier;
		}
		return _tpPrimaryYearFormatter;
	}

	private DateTimeFormatter GetMonthFormatter(string strCalendarIdentifier)
	{
		if (_tpPrimaryMonthFormatter == null || !(strCalendarIdentifier == _strMonthCalendarIdentifier))
		{
			_tpPrimaryMonthFormatter = null;
			DateTimeFormatter dateTimeFormatter = (_tpPrimaryMonthFormatter = CreateNewFormatter(_monthFormat, strCalendarIdentifier));
			_strMonthCalendarIdentifier = strCalendarIdentifier;
		}
		return _tpPrimaryMonthFormatter;
	}

	private DateTimeFormatter GetDayFormatter(string strCalendarIdentifier)
	{
		if (_tpPrimaryDayFormatter == null || !(strCalendarIdentifier == _strDayCalendarIdentifier))
		{
			_tpPrimaryDayFormatter = null;
			DateTimeFormatter dateTimeFormatter = (_tpPrimaryDayFormatter = CreateNewFormatter(_dayFormat, strCalendarIdentifier));
			_strDayCalendarIdentifier = strCalendarIdentifier;
		}
		return _tpPrimaryDayFormatter;
	}

	private DateTimeFormatter CreateNewFormatter(string strFormat, string strCalendarIdentifier)
	{
		DateTimeFormatter dateTimeFormatter = new DateTimeFormatter(strFormat);
		string geographicRegion = dateTimeFormatter.GeographicRegion;
		IReadOnlyList<string> languages = dateTimeFormatter.Languages;
		string clock = dateTimeFormatter.Clock;
		return new DateTimeFormatter(strFormat, languages, geographicRegion, strCalendarIdentifier, clock);
	}

	private Calendar CreateNewCalendar(string strCalendarIdentifier)
	{
		Calendar calendar = new Calendar();
		IReadOnlyList<string> languages = calendar.Languages;
		string clock = calendar.GetClock();
		return new Calendar(languages, strCalendarIdentifier, clock);
	}

	private int GetYearDifference(Calendar pStartCalendar, Calendar pEndCalendar)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string calendarSystem = pStartCalendar.GetCalendarSystem();
		string calendarSystem2 = pEndCalendar.GetCalendarSystem();
		if (calendarSystem != calendarSystem2)
		{
			throw new InvalidOperationException("Different calendar system");
		}
		int num5 = 0;
		num = pStartCalendar.Era;
		num2 = pEndCalendar.Era;
		num3 = pStartCalendar.Year;
		num4 = pEndCalendar.Year;
		while (num != num2 || num3 != num4)
		{
			pStartCalendar.AddYears(1);
			num5++;
			num = pStartCalendar.Era;
			num3 = pStartCalendar.Year;
		}
		return num5;
	}

	private DateTimeOffset ClampDate(DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
	{
		if (date.ToUniversalTime() < minDate.ToUniversalTime())
		{
			return minDate;
		}
		if (date.ToUniversalTime() > maxDate.ToUniversalTime())
		{
			return maxDate;
		}
		return date;
	}

	private void GetOrder(out int yearOrder, out int monthOrder, out int dayOrder, out bool isRTL)
	{
		yearOrder = 2;
		monthOrder = 0;
		dayOrder = 1;
		isRTL = false;
		DateTimeFormatter dateTimeFormatter = CreateNewFormatter("day month.full year", _calendarIdentifier);
		IReadOnlyList<string> patterns = dateTimeFormatter.Patterns;
		string text = patterns[0];
		if (text == null)
		{
			return;
		}
		string text2 = text;
		isRTL = text2[0] == '\u200f';
		uint num = (uint)text2.IndexOf("{day", StringComparison.Ordinal);
		uint num2 = (uint)text2.IndexOf("{month", StringComparison.Ordinal);
		uint num3 = (uint)text2.IndexOf("{year", StringComparison.Ordinal);
		if (num < num2)
		{
			if (num < num3)
			{
				dayOrder = 0;
				if (num2 < num3)
				{
					monthOrder = 1;
					yearOrder = 2;
				}
				else
				{
					monthOrder = 2;
					yearOrder = 1;
				}
			}
			else
			{
				dayOrder = 1;
				monthOrder = 2;
				yearOrder = 0;
			}
		}
		else if (num < num3)
		{
			dayOrder = 1;
			monthOrder = 0;
			yearOrder = 2;
		}
		else
		{
			dayOrder = 2;
			if (num2 < num3)
			{
				monthOrder = 0;
				yearOrder = 1;
			}
			else
			{
				monthOrder = 1;
				yearOrder = 0;
			}
		}
	}

	private void UpdateOrderAndLayout()
	{
		int yearOrder = 0;
		int monthOrder = 0;
		int dayOrder = 0;
		bool isRTL = false;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num = 0;
		ColumnDefinitionCollection columnDefinitionCollection = null;
		ColumnDefinition columnDefinition = null;
		ColumnDefinition columnDefinition2 = null;
		ColumnDefinition columnDefinition3 = null;
		Control tpFirstPickerAsControl = null;
		Control tpSecondPickerAsControl = null;
		Control tpThirdPickerAsControl = null;
		_tpFirstPickerAsControl = null;
		_tpSecondPickerAsControl = null;
		_tpThirdPickerAsControl = null;
		GetOrder(out yearOrder, out monthOrder, out dayOrder, out isRTL);
		if (_tpContentPanel != null)
		{
			_tpContentPanel.FlowDirection = (isRTL ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
		if (_tpFirstPickerHost != null)
		{
			_tpFirstPickerHost.Child = null;
		}
		if (_tpSecondPickerHost != null)
		{
			_tpSecondPickerHost.Child = null;
		}
		if (_tpThirdPickerHost != null)
		{
			_tpThirdPickerHost.Child = null;
		}
		if (_tpPickerHostGrid != null)
		{
			columnDefinitionCollection = _tpPickerHostGrid.ColumnDefinitions;
			columnDefinitionCollection.Clear();
		}
		switch (yearOrder)
		{
		case 0:
			if (_tpFirstPickerHost != null && _tpYearPicker != null && _yearVisible)
			{
				UIElement tpYearPicker3 = _tpYearPicker;
				_tpFirstPickerHost.Child = tpYearPicker3;
				flag = true;
			}
			else if (_tpYearColumn != null && _tpYearPicker != null && _yearVisible)
			{
				flag = true;
				columnDefinition = _tpYearColumn;
			}
			if (flag)
			{
				tpFirstPickerAsControl = _tpYearPicker;
			}
			break;
		case 1:
			if (_tpSecondPickerHost != null && _tpYearPicker != null && _yearVisible)
			{
				UIElement tpYearPicker2 = _tpYearPicker;
				_tpSecondPickerHost.Child = tpYearPicker2;
				flag2 = true;
			}
			else if (_tpYearColumn != null && _tpYearPicker != null && _yearVisible)
			{
				flag2 = true;
				columnDefinition2 = _tpYearColumn;
			}
			if (flag2)
			{
				tpSecondPickerAsControl = _tpYearPicker;
			}
			break;
		case 2:
			if (_tpThirdPickerHost != null && _tpYearPicker != null && _yearVisible)
			{
				UIElement tpYearPicker = _tpYearPicker;
				_tpThirdPickerHost.Child = tpYearPicker;
				flag3 = true;
			}
			else if (_tpYearColumn != null && _tpYearPicker != null && _yearVisible)
			{
				flag3 = true;
				columnDefinition3 = _tpYearColumn;
			}
			if (flag3)
			{
				tpThirdPickerAsControl = _tpYearPicker;
			}
			break;
		}
		switch (monthOrder)
		{
		case 0:
			if (_tpFirstPickerHost != null && _tpMonthPicker != null && _monthVisible)
			{
				UIElement tpMonthPicker3 = _tpMonthPicker;
				_tpFirstPickerHost.Child = tpMonthPicker3;
				flag = true;
			}
			else if (_tpMonthColumn != null && _tpMonthPicker != null && _monthVisible)
			{
				flag = true;
				columnDefinition = _tpMonthColumn;
			}
			if (flag)
			{
				tpFirstPickerAsControl = _tpMonthPicker;
			}
			break;
		case 1:
			if (_tpSecondPickerHost != null && _tpMonthPicker != null && _monthVisible)
			{
				UIElement tpMonthPicker2 = _tpMonthPicker;
				_tpSecondPickerHost.Child = tpMonthPicker2;
				flag2 = true;
			}
			else if (_tpMonthColumn != null && _tpMonthPicker != null && _monthVisible)
			{
				flag2 = true;
				columnDefinition2 = _tpMonthColumn;
			}
			if (flag2)
			{
				tpSecondPickerAsControl = _tpMonthPicker;
			}
			break;
		case 2:
			if (_tpThirdPickerHost != null && _tpMonthPicker != null && _monthVisible)
			{
				UIElement tpMonthPicker = _tpMonthPicker;
				_tpThirdPickerHost.Child = tpMonthPicker;
				flag3 = true;
			}
			else if (_tpMonthColumn != null && _tpMonthPicker != null && _monthVisible)
			{
				flag3 = true;
				columnDefinition3 = _tpMonthColumn;
			}
			if (flag3)
			{
				tpThirdPickerAsControl = _tpMonthPicker;
			}
			break;
		}
		switch (dayOrder)
		{
		case 0:
			if (_tpFirstPickerHost != null && _tpDayPicker != null && _dayVisible)
			{
				UIElement tpDayPicker3 = _tpDayPicker;
				_tpFirstPickerHost.Child = tpDayPicker3;
				flag = true;
			}
			else if (_tpDayColumn != null && _tpDayPicker != null && _dayVisible)
			{
				flag = true;
				columnDefinition = _tpDayColumn;
			}
			if (flag)
			{
				tpFirstPickerAsControl = _tpDayPicker;
			}
			break;
		case 1:
			if (_tpSecondPickerHost != null && _tpDayPicker != null && _dayVisible)
			{
				UIElement tpDayPicker2 = _tpDayPicker;
				_tpSecondPickerHost.Child = tpDayPicker2;
				flag2 = true;
			}
			else if (_tpDayColumn != null && _tpDayPicker != null && _dayVisible)
			{
				flag2 = true;
				columnDefinition2 = _tpDayColumn;
			}
			if (flag2)
			{
				tpSecondPickerAsControl = _tpDayPicker;
			}
			break;
		case 2:
			if (_tpThirdPickerHost != null && _tpDayPicker != null && _dayVisible)
			{
				UIElement tpDayPicker = _tpDayPicker;
				_tpThirdPickerHost.Child = tpDayPicker;
				flag3 = true;
			}
			else if (_tpDayColumn != null && _tpDayPicker != null && _dayVisible)
			{
				flag3 = true;
				columnDefinition3 = _tpDayColumn;
			}
			if (flag3)
			{
				tpThirdPickerAsControl = _tpDayPicker;
			}
			break;
		}
		_tpFirstPickerAsControl = tpFirstPickerAsControl;
		_tpSecondPickerAsControl = tpSecondPickerAsControl;
		_tpThirdPickerAsControl = tpThirdPickerAsControl;
		if (columnDefinitionCollection != null)
		{
			if (columnDefinition != null)
			{
				columnDefinitionCollection.Add(columnDefinition);
			}
			if (_tpFirstSpacerColumn != null)
			{
				columnDefinitionCollection.Add(_tpFirstSpacerColumn);
			}
			if (columnDefinition2 != null)
			{
				columnDefinitionCollection.Add(columnDefinition2);
			}
			if (_tpSecondSpacerColumn != null)
			{
				columnDefinitionCollection.Add(_tpSecondSpacerColumn);
			}
			if (columnDefinition3 != null)
			{
				columnDefinitionCollection.Add(columnDefinition3);
			}
		}
		if (_tpYearPicker != null && _tpYearColumn != null && _yearVisible && columnDefinitionCollection != null)
		{
			flag4 = (num = columnDefinitionCollection.IndexOf(_tpYearColumn)) >= 0;
			FrameworkElement tpYearPicker4 = _tpYearPicker;
			Grid.SetColumn(tpYearPicker4, num);
		}
		if (_tpMonthPicker != null && _tpMonthColumn != null && _monthVisible && columnDefinitionCollection != null)
		{
			flag4 = (num = columnDefinitionCollection.IndexOf(_tpMonthColumn)) >= 0;
			FrameworkElement tpYearPicker4 = _tpMonthPicker;
			Grid.SetColumn(tpYearPicker4, num);
		}
		if (_tpDayPicker != null && _tpDayColumn != null && _dayVisible && columnDefinitionCollection != null)
		{
			flag4 = (num = columnDefinitionCollection.IndexOf(_tpDayColumn)) >= 0;
			FrameworkElement tpYearPicker4 = _tpDayPicker;
			Grid.SetColumn(tpYearPicker4, num);
		}
		if (_tpDayPicker != null)
		{
			UIElement tpDayPicker4 = _tpDayPicker;
			tpDayPicker4.Visibility = ((!_dayVisible) ? Visibility.Collapsed : Visibility.Visible);
			(tpDayPicker4 as Control).TabIndex = dayOrder;
		}
		if (_tpMonthPicker != null)
		{
			UIElement tpDayPicker4 = _tpMonthPicker;
			tpDayPicker4.Visibility = ((!_monthVisible) ? Visibility.Collapsed : Visibility.Visible);
			(tpDayPicker4 as Control).TabIndex = monthOrder;
		}
		if (_tpYearPicker != null)
		{
			UIElement tpDayPicker4 = _tpYearPicker;
			tpDayPicker4.Visibility = ((!_yearVisible) ? Visibility.Collapsed : Visibility.Visible);
			(tpDayPicker4 as Control).TabIndex = yearOrder;
		}
		if (_tpFirstPickerSpacing is FrameworkElement view)
		{
			UIElement tpDayPicker4 = _tpFirstPickerSpacing;
			tpDayPicker4.Visibility = ((!flag || !(flag2 || flag3)) ? Visibility.Collapsed : Visibility.Visible);
			if (_tpFirstSpacerColumn != null && columnDefinitionCollection != null)
			{
				flag4 = (num = columnDefinitionCollection.IndexOf(_tpFirstSpacerColumn)) >= 0;
				Grid.SetColumn(view, num);
			}
		}
		if (_tpSecondPickerSpacing is FrameworkElement view2)
		{
			UIElement tpDayPicker4 = _tpSecondPickerSpacing;
			tpDayPicker4.Visibility = ((!(flag2 && flag3)) ? Visibility.Collapsed : Visibility.Visible);
			if (_tpSecondSpacerColumn != null && columnDefinitionCollection != null)
			{
				flag4 = (num = columnDefinitionCollection.IndexOf(_tpSecondSpacerColumn)) >= 0;
				Grid.SetColumn(view2, num);
			}
		}
	}

	private void UpdateState()
	{
		int num = 0;
		int num2 = 0;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset3 = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset4 = default(DateTimeOffset);
		Calendar tpCalendar = CreateNewCalendar(_calendarIdentifier);
		Calendar tpBaselineCalendar = CreateNewCalendar(_calendarIdentifier);
		_tpCalendar = tpCalendar;
		_tpBaselineCalendar = tpBaselineCalendar;
		_hasValidYearRange = _minYear.ToUniversalTime() <= _maxYear.ToUniversalTime();
		if (_hasValidYearRange)
		{
			_tpCalendar.SetToMin();
			dateTimeOffset4 = _tpCalendar.GetDateTime();
			_tpCalendar.SetToMax();
			dateTimeOffset3 = _tpCalendar.GetDateTime();
			dateTimeOffset = ClampDate(_minYear, dateTimeOffset4, dateTimeOffset3);
			dateTimeOffset2 = ClampDate(_maxYear, dateTimeOffset4, dateTimeOffset3);
			_tpCalendar.SetDateTime(dateTimeOffset);
			num = _tpCalendar.FirstMonthInThisYear;
			_tpCalendar.Month = num;
			num2 = _tpCalendar.FirstDayInThisMonth;
			_tpCalendar.Day = num2;
			dateTimeOffset = _tpCalendar.GetDateTime();
			_tpCalendar.SetDateTime(dateTimeOffset2);
			num = _tpCalendar.LastMonthInThisYear;
			_tpCalendar.Month = num;
			num2 = _tpCalendar.LastDayInThisMonth;
			_tpCalendar.Day = num2;
			dateTimeOffset2 = _tpCalendar.GetDateTime();
			_tpCalendar.SetDateTime(dateTimeOffset);
			_tpCalendar.Hour = 12;
			_tpCalendar.Minute = 0;
			_tpCalendar.Second = 0;
			_startDate = _tpCalendar.GetDateTime();
			_endDate = dateTimeOffset2;
			_tpCalendar.SetDateTime(_startDate);
			_tpBaselineCalendar.SetDateTime(_endDate);
			_numberOfYears = GetYearDifference(_tpCalendar, _tpBaselineCalendar);
			_numberOfYears++;
		}
		else
		{
			ClearSelectors(clearDay: true, clearMonth: true, clearYear: true);
		}
		UpdateOrderAndLayout();
	}

	private void AllowReactionToSelectionChange()
	{
		_reactionToSelectionChangeAllowed = true;
	}

	private void PreventReactionToSelectionChange()
	{
		_reactionToSelectionChangeAllowed = false;
	}

	private bool IsReactionToSelectionChangeAllowed()
	{
		return _reactionToSelectionChangeAllowed;
	}
}
