using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Uno;
using Uno.Disposables;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class DatePicker : Control
{
	internal const long DEFAULT_DATE_TICKS = 504910368000000000L;

	private const int DATEPICKER_RTL_CHARACTER_CODE = 8207;

	private const int DATEPICKER_MIN_MAX_YEAR_DEAFULT_OFFSET = 100;

	private const int DATEPICKER_SENTINELTIME_HOUR = 12;

	private const int DATEPICKER_SENTINELTIME_MINUTE = 0;

	private const int DATEPICKER_SENTINELTIME_SECOND = 0;

	private const int DATEPICKER_WRAP_AROUND_MONTHS_FIRST_INDEX = 1;

	private ButtonBase m_tpFlyoutButton;

	private TextBlock m_tpYearTextBlock;

	private TextBlock m_tpMonthTextBlock;

	private TextBlock m_tpDayTextBlock;

	private ObservableCollection<string> m_tpDaySource;

	private ObservableCollection<string> m_tpMonthSource;

	private ObservableCollection<string> m_tpYearSource;

	private Selector m_tpDayPicker;

	private Selector m_tpMonthPicker;

	private Selector m_tpYearPicker;

	private UIElement m_tpHeaderPresenter;

	private Border m_tpFirstPickerHost;

	private Border m_tpSecondPickerHost;

	private Border m_tpThirdPickerHost;

	private ColumnDefinition m_tpDayColumn;

	private ColumnDefinition m_tpMonthColumn;

	private ColumnDefinition m_tpYearColumn;

	private ColumnDefinition m_tpFirstSpacerColumn;

	private ColumnDefinition m_tpSecondSpacerColumn;

	private Grid m_tpFlyoutButtonContentGrid;

	private UIElement m_tpFirstPickerSpacing;

	private UIElement m_tpSecondPickerSpacing;

	private FrameworkElement m_tpLayoutRoot;

	private Calendar m_tpCalendar;

	private DateTimeFormatter m_tpDateFormatter;

	private string m_strDateCalendarIdentifier;

	private Calendar m_tpGregorianCalendar;

	private DateTimeFormatter m_tpYearFormatter;

	private string m_strYearFormat;

	private string m_strYearCalendarIdentifier;

	private DateTimeFormatter m_tpMonthFormatter;

	private string m_strMonthFormat;

	private string m_strMonthCalendarIdentifier;

	private DateTimeFormatter m_tpDayFormatter;

	private string m_strDayFormat;

	private string m_strDayCalendarIdentifier;

	private DateTimeOffset m_startDate;

	private DateTimeOffset m_endDate;

	private SerialDisposable m_epDaySelectionChangedHandler = new SerialDisposable();

	private SerialDisposable m_epMonthSelectionChangedHandler = new SerialDisposable();

	private SerialDisposable m_epYearSelectionChangedHandler = new SerialDisposable();

	private SerialDisposable m_epFlyoutButtonClickHandler = new SerialDisposable();

	private SerialDisposable m_epWindowActivatedHandler = new SerialDisposable();

	private bool m_reactionToSelectionChangeAllowed;

	private bool m_isInitializing;

	private bool m_hasValidYearRange;

	private int m_numberOfYears;

	private DateTimeOffset? m_defaultDate;

	private DateTimeOffset m_todaysDate;

	private IAsyncInfo m_tpAsyncSelectionInfo;

	private bool m_isPropagatingDate;

	private const bool DEFAULT_NATIVE_STYLE = false;

	private Lazy<DatePickerFlyout> _lazyFlyout;

	private static DateTimeOffset NullDateSentinel { get; } = new DateTimeOffset(504910368000000000L, TimeSpan.Zero);


	private static DateTimeOffset NullDateSentinelValue { get; } = new DateTimeOffset(504910368000000000L, TimeSpan.Zero);


	[UnoOnly]
	public static DependencyProperty UseNativeStyleProperty { get; } = DependencyProperty.Register("UseNativeStyle", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata(false));


	[UnoOnly]
	public bool UseNativeStyle
	{
		get
		{
			return (bool)GetValue(UseNativeStyleProperty);
		}
		set
		{
			SetValue(UseNativeStyleProperty, value);
		}
	}

	[UnoOnly]
	public static DependencyProperty UseNativeMinMaxDatesProperty { get; } = DependencyProperty.Register("UseNativeMinMaxDates", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata(false));


	[UnoOnly]
	public bool UseNativeMinMaxDates
	{
		get
		{
			return (bool)GetValue(UseNativeMinMaxDatesProperty);
		}
		set
		{
			SetValue(UseNativeMinMaxDatesProperty, value);
		}
	}

	[UnoOnly]
	public Style FlyoutPresenterStyle
	{
		get
		{
			return (Style)GetValue(FlyoutPresenterStyleProperty);
		}
		set
		{
			SetValue(FlyoutPresenterStyleProperty, value);
		}
	}

	[UnoOnly]
	public static DependencyProperty FlyoutPresenterStyleProperty { get; } = DependencyProperty.Register("FlyoutPresenterStyle", typeof(Style), typeof(DatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	private DatePickerFlyout _flyout => _lazyFlyout.Value;

	public DateTimeOffset Date
	{
		get
		{
			return (DateTimeOffset)GetValue(DateProperty);
		}
		set
		{
			SetValue(DateProperty, value);
		}
	}

	public static DependencyProperty DateProperty { get; } = DependencyProperty.Register("Date", typeof(DateTimeOffset), typeof(DatePicker), new FrameworkPropertyMetadata(DateTimeOffset.MinValue, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePicker)s).OnDatePropertyChanged((DateTimeOffset)e.NewValue, (DateTimeOffset)e.OldValue);
	}));


	public bool DayVisible
	{
		get
		{
			return (bool)GetValue(DayVisibleProperty);
		}
		set
		{
			SetValue(DayVisibleProperty, value);
		}
	}

	public static DependencyProperty DayVisibleProperty { get; } = DependencyProperty.Register("DayVisible", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate
	{
	}));


	public bool MonthVisible
	{
		get
		{
			return (bool)GetValue(MonthVisibleProperty);
		}
		set
		{
			SetValue(MonthVisibleProperty, value);
		}
	}

	public static DependencyProperty MonthVisibleProperty { get; } = DependencyProperty.Register("MonthVisible", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate
	{
	}));


	public bool YearVisible
	{
		get
		{
			return (bool)GetValue(YearVisibleProperty);
		}
		set
		{
			SetValue(YearVisibleProperty, value);
		}
	}

	public static DependencyProperty YearVisibleProperty { get; } = DependencyProperty.Register("YearVisible", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate
	{
	}));


	public DateTimeOffset MaxYear
	{
		get
		{
			return (DateTimeOffset)GetValue(MaxYearProperty);
		}
		set
		{
			SetValue(MaxYearProperty, value);
		}
	}

	public static DependencyProperty MaxYearProperty { get; } = DependencyProperty.Register("MaxYear", typeof(DateTimeOffset), typeof(DatePicker), new FrameworkPropertyMetadata((object)DateTimeOffset.MaxValue, (PropertyChangedCallback)delegate
	{
	}));


	public DateTimeOffset MinYear
	{
		get
		{
			return (DateTimeOffset)GetValue(MinYearProperty);
		}
		set
		{
			SetValue(MinYearProperty, value);
		}
	}

	public static DependencyProperty MinYearProperty { get; } = DependencyProperty.Register("MinYear", typeof(DateTimeOffset), typeof(DatePicker), new FrameworkPropertyMetadata((object)DateTimeOffset.MinValue, (PropertyChangedCallback)delegate
	{
	}));


	public string YearFormat
	{
		get
		{
			return (string)GetValue(YearFormatProperty);
		}
		set
		{
			SetValue(YearFormatProperty, value);
		}
	}

	public static DependencyProperty YearFormatProperty { get; } = DependencyProperty.Register("YearFormat", typeof(string), typeof(DatePicker), new FrameworkPropertyMetadata("year.full"));


	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(DatePicker), new FrameworkPropertyMetadata(Orientation.Vertical));


	public string MonthFormat
	{
		get
		{
			return (string)GetValue(MonthFormatProperty);
		}
		set
		{
			SetValue(MonthFormatProperty, value);
		}
	}

	public static DependencyProperty MonthFormatProperty { get; } = DependencyProperty.Register("MonthFormat", typeof(string), typeof(DatePicker), new FrameworkPropertyMetadata("{month.full}"));


	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(DatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(DatePicker), new FrameworkPropertyMetadata((object)null));


	public string DayFormat
	{
		get
		{
			return (string)GetValue(DayFormatProperty);
		}
		set
		{
			SetValue(DayFormatProperty, value);
		}
	}

	public static DependencyProperty DayFormatProperty { get; } = DependencyProperty.Register("DayFormat", typeof(string), typeof(DatePicker), new FrameworkPropertyMetadata("day"));


	public string CalendarIdentifier
	{
		get
		{
			return (string)GetValue(CalendarIdentifierProperty);
		}
		set
		{
			SetValue(CalendarIdentifierProperty, value);
		}
	}

	public static DependencyProperty CalendarIdentifierProperty { get; } = DependencyProperty.Register("CalendarIdentifier", typeof(string), typeof(DatePicker), new FrameworkPropertyMetadata("GregorianCalendar"));


	public DateTimeOffset? SelectedDate
	{
		get
		{
			return (DateTimeOffset?)GetValue(SelectedDateProperty);
		}
		set
		{
			SetValue(SelectedDateProperty, value);
		}
	}

	public static DependencyProperty SelectedDateProperty { get; } = DependencyProperty.Register("SelectedDate", typeof(DateTimeOffset?), typeof(DatePicker), new FrameworkPropertyMetadata((object)null));


	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(DatePicker), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	public event EventHandler<DatePickerValueChangedEventArgs> DateChanged;

	public event TypedEventHandler<DatePicker, DatePickerSelectedValueChangedEventArgs> SelectedDateChanged;

	private void AllowReactionToSelectionChange()
	{
		m_reactionToSelectionChangeAllowed = true;
	}

	private void PreventReactionToSelectionChange()
	{
		m_reactionToSelectionChangeAllowed = false;
	}

	private bool IsReactionToSelectionChangeAllowed()
	{
		return m_reactionToSelectionChangeAllowed;
	}

	public DatePicker()
	{
		this.RegisterDefaultValueProvider(GetDefaultValue2);
		m_numberOfYears = 0;
		m_reactionToSelectionChangeAllowed = true;
		m_isInitializing = true;
		m_hasValidYearRange = false;
		m_startDate = NullDateSentinelValue;
		m_endDate = NullDateSentinelValue;
		m_defaultDate = NullDateSentinelValue;
		m_todaysDate = NullDateSentinelValue;
		base.DefaultStyleKey = typeof(DatePicker);
		InitPartial();
		PrepareState();
	}

	~DatePicker()
	{
		if (m_tpAsyncSelectionInfo != null)
		{
			m_tpAsyncSelectionInfo.Cancel();
		}
		m_epWindowActivatedHandler.Disposable = null;
	}

	private void PrepareState()
	{
		Window current = Window.Current;
		UpdateState();
		if (current == null)
		{
			return;
		}
		WeakReference wrWeakThis = new WeakReference(this);
		current.Activated += delegate(object s, WindowActivatedEventArgs pArgs)
		{
			if (wrWeakThis.Target is DatePicker datePicker)
			{
				CoreWindowActivationState coreWindowActivationState = CoreWindowActivationState.CodeActivated;
				coreWindowActivationState = pArgs.WindowActivationState;
				if (coreWindowActivationState == CoreWindowActivationState.CodeActivated || coreWindowActivationState == CoreWindowActivationState.PointerActivated)
				{
					datePicker.RefreshSetup();
				}
			}
		};
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		if (!base.IsEnabled)
		{
			VisualStateManager.GoToState(this, "Disabled", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "Normal", useTransitions);
		}
		if (SelectedDate.HasValue)
		{
			VisualStateManager.GoToState(this, "HasDate", useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, "HasNoDate", useTransitions);
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		base.OnKeyDown(pArgs);
	}

	protected override void OnApplyTemplate()
	{
		try
		{
			if (m_tpDayPicker != null)
			{
				m_epDaySelectionChangedHandler.Disposable = null;
			}
			if (m_tpMonthPicker != null)
			{
				m_epMonthSelectionChangedHandler.Disposable = null;
			}
			if (m_tpYearPicker != null)
			{
				m_epYearSelectionChangedHandler.Disposable = null;
			}
			if (m_tpFlyoutButton != null)
			{
				m_epFlyoutButtonClickHandler.Disposable = null;
			}
			m_tpDayPicker = null;
			m_tpMonthPicker = null;
			m_tpYearPicker = null;
			m_tpFirstPickerHost = null;
			m_tpSecondPickerHost = null;
			m_tpThirdPickerHost = null;
			m_tpDayColumn = null;
			m_tpMonthColumn = null;
			m_tpYearColumn = null;
			m_tpFirstSpacerColumn = null;
			m_tpSecondSpacerColumn = null;
			m_tpFirstPickerSpacing = null;
			m_tpSecondPickerSpacing = null;
			m_tpLayoutRoot = null;
			m_tpHeaderPresenter = null;
			m_tpFlyoutButton = null;
			m_tpFlyoutButtonContentGrid = null;
			m_tpYearTextBlock = null;
			m_tpMonthTextBlock = null;
			m_tpDayTextBlock = null;
			GetTemplatePart<Selector>("DayPicker", out var element);
			GetTemplatePart<Selector>("MonthPicker", out var element2);
			GetTemplatePart<Selector>("YearPicker", out var element3);
			GetTemplatePart<Border>("FirstPickerHost", out var element4);
			GetTemplatePart<Border>("SecondPickerHost", out var element5);
			GetTemplatePart<Border>("ThirdPickerHost", out var element6);
			GetTemplatePart<ColumnDefinition>("DayColumn", out var element7);
			GetTemplatePart<ColumnDefinition>("MonthColumn", out var element8);
			GetTemplatePart<ColumnDefinition>("YearColumn", out var element9);
			GetTemplatePart<ColumnDefinition>("FirstSpacerColumn", out var element10);
			GetTemplatePart<ColumnDefinition>("SecondSpacerColumn", out var element11);
			GetTemplatePart<TextBlock>("YearTextBlock", out var element12);
			GetTemplatePart<TextBlock>("MonthTextBlock", out var element13);
			GetTemplatePart<TextBlock>("DayTextBlock", out var element14);
			GetTemplatePart<Grid>("FlyoutButtonContentGrid", out var element15);
			GetTemplatePart<UIElement>("FirstPickerSpacing", out var element16);
			GetTemplatePart<UIElement>("SecondPickerSpacing", out var element17);
			GetTemplatePart<FrameworkElement>("LayoutRoot", out var element18);
			GetTemplatePart<ButtonBase>("FlyoutButton", out var element19);
			m_tpDayPicker = element;
			m_tpMonthPicker = element2;
			m_tpYearPicker = element3;
			m_tpFirstPickerSpacing = element16;
			m_tpSecondPickerSpacing = element17;
			m_tpFirstPickerHost = element4;
			m_tpSecondPickerHost = element5;
			m_tpThirdPickerHost = element6;
			m_tpDayColumn = element7;
			m_tpMonthColumn = element8;
			m_tpYearColumn = element9;
			m_tpFirstSpacerColumn = element10;
			m_tpSecondSpacerColumn = element11;
			m_tpLayoutRoot = element18;
			m_tpYearTextBlock = element12;
			m_tpMonthTextBlock = element13;
			m_tpDayTextBlock = element14;
			m_tpFlyoutButton = element19;
			m_tpFlyoutButtonContentGrid = element15;
			UpdateHeaderPresenterVisibility();
			string name = AutomationProperties.GetName(this);
			if (string.IsNullOrEmpty(name))
			{
				object header = Header;
			}
			if (m_tpDayPicker != null)
			{
				m_tpDayPicker.SelectionChanged += OnSelectorSelectionChanged;
				m_epDaySelectionChangedHandler.Disposable = Disposable.Create(delegate
				{
					m_tpDayPicker.SelectionChanged -= OnSelectorSelectionChanged;
				});
				string name2 = AutomationProperties.GetName(m_tpDayPicker);
			}
			if (m_tpMonthPicker != null)
			{
				m_tpMonthPicker.SelectionChanged += OnSelectorSelectionChanged;
				m_epMonthSelectionChangedHandler.Disposable = Disposable.Create(delegate
				{
					m_tpMonthPicker.SelectionChanged -= OnSelectorSelectionChanged;
				});
				string name2 = AutomationProperties.GetName(m_tpMonthPicker as ComboBox);
			}
			if (m_tpYearPicker != null)
			{
				m_tpYearPicker.SelectionChanged += OnSelectorSelectionChanged;
				m_epYearSelectionChangedHandler.Disposable = Disposable.Create(delegate
				{
					m_tpYearPicker.SelectionChanged -= OnSelectorSelectionChanged;
				});
				string name2 = AutomationProperties.GetName(m_tpYearPicker as ComboBox);
			}
			if (m_tpFlyoutButton != null)
			{
				m_tpFlyoutButton.Click += OnFlyoutButtonClick;
				m_epFlyoutButtonClickHandler.Disposable = Disposable.Create(delegate
				{
					m_tpFlyoutButton.Click -= OnFlyoutButtonClick;
				});
				RefreshFlyoutButtonAutomationName();
			}
			if (m_tpYearSource == null && m_tpMonthSource == null && m_tpDaySource == null)
			{
				m_tpYearSource = new ObservableCollection<string>();
				m_tpMonthSource = new ObservableCollection<string>();
				m_tpDaySource = new ObservableCollection<string>();
			}
			RefreshSetup();
		}
		finally
		{
			m_isInitializing = false;
		}
	}

	private void GetTemplatePart<T>(string name, out T element) where T : class
	{
		element = GetTemplateChild(name) as T;
	}

	private void ClearSelectors(bool clearDay, bool clearMonth, bool clearYear)
	{
		DependencyProperty dependencyProperty = null;
		DependencyProperty dependencyProperty2 = null;
		dependencyProperty = Selector.SelectedItemProperty;
		dependencyProperty2 = ItemsControl.ItemsSourceProperty;
		if (m_tpDayPicker != null && clearDay)
		{
			m_tpDayPicker.ClearValue(dependencyProperty2);
		}
		if (m_tpMonthPicker != null && clearMonth)
		{
			m_tpMonthPicker.ClearValue(dependencyProperty2);
		}
		if (m_tpYearPicker != null && clearYear)
		{
			m_tpYearPicker.ClearValue(dependencyProperty2);
		}
	}

	private void GetIndices(ref int yearIndex, ref int monthIndex, ref int dayIndex)
	{
		DateTimeOffset? date = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		GetSelectedDateOrTodaysDateIfNull(out date);
		string calendarIdentifier = CalendarIdentifier;
		CreateNewCalendar(calendarIdentifier, out var ppCalendar);
		ppCalendar.SetDateTime(ClampDate(date.Value, m_startDate, m_endDate));
		m_tpCalendar.SetDateTime(m_startDate);
		GetYearDifference(m_tpCalendar, ppCalendar, out yearIndex);
		num2 = ppCalendar.FirstMonthInThisYear;
		num = ppCalendar.Month;
		num3 = ppCalendar.NumberOfMonthsInThisYear;
		if (num - num2 >= 0)
		{
			monthIndex = num - num2;
		}
		else
		{
			monthIndex = num - num2 + num3;
		}
		num2 = ppCalendar.FirstDayInThisMonth;
		num = ppCalendar.Day;
		dayIndex = num - num2;
	}

	private void RefreshSetup()
	{
		PreventReactionToSelectionChange();
		UpdateState();
		if (!m_hasValidYearRange)
		{
			return;
		}
		RefreshSources(refreshDay: true, refreshMonth: true, refreshYear: true);
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		dateTimeOffset = Date;
		if (dateTimeOffset != NullDateSentinelValue)
		{
			int yearIndex = 0;
			int monthIndex = 0;
			int dayIndex = 0;
			DateTimeOffset date = default(DateTimeOffset);
			GetIndices(ref yearIndex, ref monthIndex, ref dayIndex);
			GetDateFromIndices(yearIndex, monthIndex, dayIndex, out date);
			if (dateTimeOffset != date)
			{
				Date = date;
			}
		}
	}

	private void RefreshSources(bool refreshDay, bool refreshMonth, bool refreshYear)
	{
		int yearIndex = 0;
		int monthIndex = 0;
		int dayIndex = 0;
		PreventReactionToSelectionChange();
		GetIndices(ref yearIndex, ref monthIndex, ref dayIndex);
		ClearSelectors(refreshDay, refreshMonth, refreshYear);
		if (m_tpYearPicker != null)
		{
			if (refreshYear)
			{
				GenerateYears();
				m_tpYearPicker.ItemsSource = m_tpYearSource;
			}
			m_tpYearPicker.SelectedIndex = yearIndex;
		}
		if (m_tpMonthPicker != null)
		{
			if (refreshMonth)
			{
				GenerateMonths(yearIndex);
				m_tpMonthPicker.ItemsSource = m_tpMonthSource;
			}
			m_tpMonthPicker.SelectedIndex = monthIndex;
		}
		if (m_tpDayPicker != null)
		{
			if (refreshDay)
			{
				GenerateDays(yearIndex, monthIndex);
				m_tpDayPicker.ItemsSource = m_tpDaySource;
			}
			m_tpDayPicker.SelectedIndex = dayIndex;
		}
		if (m_tpFlyoutButton != null)
		{
			UpdateFlyoutButtonContent();
		}
	}

	private void GenerateYears()
	{
		string calendarIdentifier = CalendarIdentifier;
		string yearFormat = YearFormat;
		GetYearFormatter(yearFormat, calendarIdentifier, out var ppDateTimeFormatter);
		m_tpYearSource = null;
		for (int i = 0; i < m_numberOfYears; i++)
		{
			m_tpCalendar.SetDateTime(m_startDate);
			m_tpCalendar.AddYears(i);
			DateTimeOffset dateTime = m_tpCalendar.GetDateTime();
			string item = ppDateTimeFormatter.Format(dateTime);
			m_tpYearSource.Add(item);
		}
	}

	private void GenerateMonths(int yearOffset)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string calendarIdentifier = CalendarIdentifier;
		string monthFormat = MonthFormat;
		GetMonthFormatter(monthFormat, calendarIdentifier, out var ppDateTimeFormatter);
		m_tpCalendar.SetDateTime(m_startDate);
		m_tpCalendar.AddYears(yearOffset);
		num2 = m_tpCalendar.NumberOfMonthsInThisYear;
		num3 = m_tpCalendar.FirstMonthInThisYear;
		m_tpMonthSource.Clear();
		for (num = 0; num < num2; num++)
		{
			m_tpCalendar.Month = num3;
			m_tpCalendar.AddMonths(num);
			DateTimeOffset dateTime = m_tpCalendar.GetDateTime();
			string item = ppDateTimeFormatter.Format(dateTime);
			m_tpMonthSource.Add(item);
		}
	}

	private void GenerateDays(int yearOffset, int monthOffset)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string calendarIdentifier = CalendarIdentifier;
		string dayFormat = DayFormat;
		GetDayFormatter(dayFormat, calendarIdentifier, out var ppDateTimeFormatter);
		m_tpCalendar.SetDateTime(m_startDate);
		m_tpCalendar.AddYears(yearOffset);
		num4 = m_tpCalendar.FirstMonthInThisYear;
		m_tpCalendar.Month = num4;
		m_tpCalendar.AddMonths(monthOffset);
		num2 = m_tpCalendar.NumberOfDaysInThisMonth;
		num3 = m_tpCalendar.FirstDayInThisMonth;
		m_tpDaySource.Clear();
		for (num = 0; num < num2; num++)
		{
			m_tpCalendar.Day = num3 + num;
			DateTimeOffset dateTime = m_tpCalendar.GetDateTime();
			string item = ppDateTimeFormatter.Format(dateTime);
			m_tpDaySource.Add(item);
		}
	}

	private void OnSelectorSelectionChanged(object pSender, SelectionChangedEventArgs pArgs)
	{
		if (IsReactionToSelectionChangeAllowed())
		{
			int yearIndex = 0;
			int monthIndex = 0;
			int dayIndex = 0;
			DateTimeOffset date = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			if (m_tpYearPicker != null)
			{
				yearIndex = m_tpYearPicker.SelectedIndex;
			}
			if (m_tpMonthPicker != null)
			{
				monthIndex = m_tpMonthPicker.SelectedIndex;
			}
			if (m_tpDayPicker != null)
			{
				dayIndex = m_tpDayPicker.SelectedIndex;
			}
			GetDateFromIndices(yearIndex, monthIndex, dayIndex, out date);
			if (Date.ToUniversalTime() != date.ToUniversalTime())
			{
				Date = date;
			}
		}
	}

	private void OnFlyoutButtonClick(object pSender, RoutedEventArgs pArgs)
	{
		_flyout.CalendarIdentifier = CalendarIdentifier;
		_flyout.DayFormat = DayFormat;
		_flyout.MonthFormat = MonthFormat;
		_flyout.YearFormat = YearFormat;
		_flyout.DayVisible = DayVisible;
		_flyout.MonthVisible = MonthVisible;
		_flyout.YearVisible = YearVisible;
		_flyout.MinYear = MinYear;
		_flyout.MaxYear = MaxYear;
		_flyout.Date = SelectedDate ?? Date;
		ShowPickerFlyout();
	}

	private async void ShowPickerFlyout()
	{
		if (m_tpAsyncSelectionInfo == null)
		{
			IAsyncOperation<DateTimeOffset?> asyncOperation = (IAsyncOperation<DateTimeOffset?>)(m_tpAsyncSelectionInfo = _flyout.ShowAtAsync(this));
			Task<DateTimeOffset?> getOperation = asyncOperation.AsTask();
			await getOperation;
			OnGetDatePickerSelectionAsyncCompleted(getOperation, asyncOperation.Status);
		}
	}

	private void OnGetDatePickerSelectionAsyncCompleted(Task<DateTimeOffset?> getOperation, AsyncStatus status)
	{
		m_tpAsyncSelectionInfo = null;
		if (status == AsyncStatus.Completed)
		{
			DateTimeOffset? result = getOperation.Result;
			if (result.HasValue)
			{
				SelectedDate = result;
			}
		}
	}

	private void GetDateFromIndices(int yearIndex, int monthIndex, int dayIndex, out DateTimeOffset date)
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
		dateTimeOffset = Date;
		dateTimeOffset = ClampDate(dateTimeOffset, m_startDate, m_endDate);
		m_tpCalendar.SetDateTime(dateTimeOffset);
		num4 = m_tpCalendar.Period;
		num5 = m_tpCalendar.Hour;
		num6 = m_tpCalendar.Minute;
		num7 = m_tpCalendar.Second;
		num8 = m_tpCalendar.Nanosecond;
		num11 = m_tpCalendar.Year;
		num12 = m_tpCalendar.Month;
		num13 = m_tpCalendar.Day;
		m_tpCalendar.SetDateTime(m_startDate);
		m_tpCalendar.Period = num4;
		m_tpCalendar.Hour = num5;
		m_tpCalendar.Minute = num6;
		m_tpCalendar.Second = num7;
		m_tpCalendar.Nanosecond = num8;
		m_tpCalendar.AddYears(yearIndex);
		num9 = m_tpCalendar.Year;
		num2 = m_tpCalendar.FirstMonthInThisYear;
		num3 = m_tpCalendar.NumberOfMonthsInThisYear;
		num14 = m_tpCalendar.LastMonthInThisYear;
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
		m_tpCalendar.Month = num;
		num10 = m_tpCalendar.Month;
		num2 = m_tpCalendar.FirstDayInThisMonth;
		num3 = m_tpCalendar.NumberOfDaysInThisMonth;
		num = Math.Max(Math.Min(dayIndex + num2, num2 + num3 - 1), num2);
		if (num11 != num9 || num12 != num10)
		{
			num = Math.Max(Math.Min(num13, num2 + num3 - 1), num2);
		}
		m_tpCalendar.Day = num;
		date = m_tpCalendar.GetDateTime();
	}

	private bool GetDefaultValue2(DependencyProperty pDP, out object pValue)
	{
		Calendar ppCalendar;
		if (pDP == MinYearProperty)
		{
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset3 = default(DateTimeOffset);
			if (m_tpGregorianCalendar == null)
			{
				CreateNewCalendar("GregorianCalendar", out ppCalendar);
				m_tpGregorianCalendar = ppCalendar;
			}
			m_tpCalendar.SetToMin();
			dateTimeOffset2 = m_tpCalendar.GetDateTime();
			m_tpCalendar.SetToMax();
			dateTimeOffset3 = m_tpCalendar.GetDateTime();
			m_tpGregorianCalendar.SetToNow();
			m_tpGregorianCalendar.AddYears(-100);
			dateTimeOffset = m_tpGregorianCalendar.GetDateTime();
			pValue = ClampDate(dateTimeOffset, dateTimeOffset2, dateTimeOffset3);
			return true;
		}
		if (pDP == MaxYearProperty)
		{
			DateTimeOffset dateTimeOffset4 = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset5 = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset6 = default(DateTimeOffset);
			if (m_tpGregorianCalendar == null)
			{
				CreateNewCalendar("GregorianCalendar", out ppCalendar);
				m_tpGregorianCalendar = ppCalendar;
			}
			m_tpCalendar.SetToMin();
			dateTimeOffset5 = m_tpCalendar.GetDateTime();
			m_tpCalendar.SetToMax();
			dateTimeOffset6 = m_tpCalendar.GetDateTime();
			m_tpGregorianCalendar.SetToNow();
			m_tpGregorianCalendar.AddYears(100);
			dateTimeOffset4 = m_tpGregorianCalendar.GetDateTime();
			pValue = ClampDate(dateTimeOffset4, dateTimeOffset5, dateTimeOffset6);
			return true;
		}
		if (pDP == DateProperty)
		{
			pValue = m_defaultDate;
			return true;
		}
		pValue = null;
		return false;
	}

	private void OnStringTypePropertyChanged(DependencyProperty property, string strOldValue, string strNewValue)
	{
		try
		{
			RefreshSetup();
		}
		catch (Exception)
		{
			if (property == CalendarIdentifierProperty)
			{
				CalendarIdentifier = strOldValue;
			}
			else if (property == DayFormatProperty)
			{
				DayFormat = strOldValue;
			}
			else if (property == MonthFormatProperty)
			{
				MonthFormat = strOldValue;
			}
			else if (property == YearFormatProperty)
			{
				YearFormat = strOldValue;
			}
		}
	}

	private void OnDateChanged(DateTimeOffset oldValue, DateTimeOffset newValue)
	{
		UpdateVisualState();
		if (m_hasValidYearRange)
		{
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
			dateTimeOffset = ((newValue.ToUniversalTime() != NullDateSentinelValue) ? ClampDate(newValue, m_startDate, m_endDate) : newValue);
			dateTimeOffset2 = ((oldValue.ToUniversalTime() != NullDateSentinelValue) ? ClampDate(oldValue, m_startDate, m_endDate) : oldValue);
			if (dateTimeOffset.ToUniversalTime() != newValue.ToUniversalTime())
			{
				Date = dateTimeOffset;
				return;
			}
			bool flag = false;
			bool flag2 = false;
			if (dateTimeOffset.ToUniversalTime() == dateTimeOffset2.ToUniversalTime() || dateTimeOffset2.ToUniversalTime() == NullDateSentinelValue || dateTimeOffset.ToUniversalTime() == NullDateSentinelValue)
			{
				flag = true;
				flag2 = true;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				m_tpCalendar.SetDateTime(dateTimeOffset2);
				num2 = m_tpCalendar.Year;
				num4 = m_tpCalendar.Month;
				m_tpCalendar.SetDateTime(dateTimeOffset);
				num = m_tpCalendar.Year;
				num3 = m_tpCalendar.Month;
				if (num2 != num)
				{
					flag = true;
					flag2 = true;
				}
				else if (num4 != num3)
				{
					flag2 = true;
				}
			}
			if (flag2 || flag)
			{
				RefreshSources(flag2, flag, refreshYear: false);
			}
			else
			{
				int yearIndex = 0;
				int monthIndex = 0;
				int dayIndex = 0;
				GetIndices(ref yearIndex, ref monthIndex, ref dayIndex);
				if (m_tpYearPicker != null)
				{
					m_tpYearPicker.SelectedIndex = yearIndex;
				}
				if (m_tpMonthPicker != null)
				{
					m_tpMonthPicker.SelectedIndex = monthIndex;
				}
				if (m_tpDayPicker != null)
				{
					m_tpDayPicker.SelectedIndex = dayIndex;
				}
			}
			if (m_tpFlyoutButton != null)
			{
				UpdateFlyoutButtonContent();
			}
		}
		DatePickerValueChangedEventArgs e = new DatePickerValueChangedEventArgs(newValue, oldValue);
		this.DateChanged?.Invoke(this, e);
		DatePickerSelectedValueChangedEventArgs datePickerSelectedValueChangedEventArgs = new DatePickerSelectedValueChangedEventArgs();
		if (oldValue.ToUniversalTime() != NullDateSentinelValue)
		{
			datePickerSelectedValueChangedEventArgs.OldDate = oldValue;
		}
		else
		{
			datePickerSelectedValueChangedEventArgs.OldDate = null;
		}
		if (newValue.ToUniversalTime() != NullDateSentinelValue)
		{
			datePickerSelectedValueChangedEventArgs.NewDate = newValue;
		}
		else
		{
			datePickerSelectedValueChangedEventArgs.NewDate = null;
		}
		this.SelectedDateChanged?.Invoke(this, datePickerSelectedValueChangedEventArgs);
	}

	private void UpdateHeaderPresenterVisibility()
	{
		DataTemplate headerTemplate = HeaderTemplate;
		object header = Header;
		ConditionallyGetTemplatePartAndUpdateVisibility("HeaderContentPresenter", header != null || headerTemplate != null, ref m_tpHeaderPresenter);
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == DateProperty && !m_isPropagatingDate)
		{
			DateTimeOffset date = Date;
			if (date.ToUniversalTime() != NullDateSentinelValue)
			{
				try
				{
					m_isPropagatingDate = true;
					SelectedDate = date;
				}
				finally
				{
					m_isPropagatingDate = false;
				}
			}
			else
			{
				m_isPropagatingDate = true;
				try
				{
					SelectedDate = null;
				}
				finally
				{
					m_isPropagatingDate = false;
				}
			}
		}
		if (args.Property == SelectedDateProperty && !m_isPropagatingDate)
		{
			if (SelectedDate.HasValue)
			{
				try
				{
					m_isPropagatingDate = true;
					Date = SelectedDate.Value;
				}
				finally
				{
					m_isPropagatingDate = false;
				}
			}
			else
			{
				try
				{
					m_isPropagatingDate = true;
					Date = NullDateSentinel;
				}
				finally
				{
					m_isPropagatingDate = false;
				}
			}
		}
		if (!m_isInitializing)
		{
			if (args.Property == DateProperty)
			{
				OnDateChanged((DateTimeOffset)args.OldValue, (DateTimeOffset)args.NewValue);
			}
			if (args.Property == SelectedDateProperty && m_tpFlyoutButton != null)
			{
				UpdateFlyoutButtonContent();
			}
			if (args.Property == CalendarIdentifierProperty || args.Property == DayFormatProperty || args.Property == MonthFormatProperty || args.Property == YearFormatProperty || args.Property == MinYearProperty || args.Property == MaxYearProperty)
			{
				OnStringTypePropertyChanged(args.Property, args.OldValue as string, args.NewValue as string);
			}
			if (args.Property == DayVisibleProperty || args.Property == MonthVisibleProperty || args.Property == YearVisibleProperty)
			{
				UpdateOrderAndLayout();
			}
			if (args.Property == HeaderProperty || args.Property == HeaderTemplateProperty)
			{
				UpdateHeaderPresenterVisibility();
			}
		}
	}

	private void GetYearFormatter(string strFormat, string strCalendarIdentifier, out DateTimeFormatter ppDateTimeFormatter)
	{
		if (m_tpYearFormatter == null || !(strFormat == m_strYearFormat) || !(strCalendarIdentifier == m_strYearCalendarIdentifier))
		{
			m_tpYearFormatter = null;
			CreateNewFormatter(strFormat, strCalendarIdentifier, out var ppDateTimeFormatter2);
			m_tpYearFormatter = ppDateTimeFormatter2;
			m_strYearFormat = strFormat;
			m_strYearCalendarIdentifier = strCalendarIdentifier;
		}
		ppDateTimeFormatter = m_tpYearFormatter;
	}

	private void GetMonthFormatter(string strFormat, string strCalendarIdentifier, out DateTimeFormatter ppDateTimeFormatter)
	{
		if (m_tpMonthFormatter == null || !(strFormat == m_strMonthFormat) || !(strCalendarIdentifier == m_strMonthCalendarIdentifier))
		{
			m_tpMonthFormatter = null;
			CreateNewFormatter(strFormat, strCalendarIdentifier, out var ppDateTimeFormatter2);
			m_tpMonthFormatter = ppDateTimeFormatter2;
			m_strMonthFormat = strFormat;
			m_strMonthCalendarIdentifier = strCalendarIdentifier;
		}
		ppDateTimeFormatter = m_tpMonthFormatter;
	}

	private void GetDayFormatter(string strFormat, string strCalendarIdentifier, out DateTimeFormatter ppDateTimeFormatter)
	{
		if (m_tpDayFormatter == null || !(strFormat == m_strDayFormat) || !(strCalendarIdentifier == m_strDayCalendarIdentifier))
		{
			m_tpDayFormatter = null;
			CreateNewFormatter(strFormat, strCalendarIdentifier, out var ppDateTimeFormatter2);
			m_tpDayFormatter = ppDateTimeFormatter2;
			m_strDayFormat = strFormat;
			m_strDayCalendarIdentifier = strCalendarIdentifier;
		}
		ppDateTimeFormatter = m_tpDayFormatter;
	}

	private void CreateNewFormatter(string strFormat, string strCalendarIdentifier, out DateTimeFormatter ppDateTimeFormatter)
	{
		DateTimeFormatter dateTimeFormatter = new DateTimeFormatter(strFormat);
		string geographicRegion = dateTimeFormatter.GeographicRegion;
		IReadOnlyList<string> languages = dateTimeFormatter.Languages;
		string clock = dateTimeFormatter.Clock;
		dateTimeFormatter = (ppDateTimeFormatter = new DateTimeFormatter(strFormat, languages, geographicRegion, strCalendarIdentifier, clock));
	}

	private void CreateNewCalendar(string strCalendarIdentifier, out Calendar ppCalendar)
	{
		ppCalendar = null;
		Calendar calendar = new Calendar();
		IReadOnlyList<string> languages = calendar.Languages;
		string clock = calendar.GetClock();
		calendar = new Calendar();
		calendar = (ppCalendar = new Calendar(languages, strCalendarIdentifier, clock));
	}

	private void GetDateFormatter(string strCalendarIdentifier, out DateTimeFormatter ppDateFormatter)
	{
		if (m_tpDateFormatter == null || !(strCalendarIdentifier == m_strDateCalendarIdentifier))
		{
			m_tpDateFormatter = null;
			CreateNewFormatter("shortdate", strCalendarIdentifier, out var ppDateTimeFormatter);
			m_tpDateFormatter = ppDateTimeFormatter;
			m_strDateCalendarIdentifier = strCalendarIdentifier;
		}
		ppDateFormatter = m_tpDateFormatter;
	}

	private void UpdateFlyoutButtonContent()
	{
		DateTimeOffset? todaysDate = null;
		string calendarIdentifier = CalendarIdentifier;
		GetDateFormatter(calendarIdentifier, out var ppDateFormatter);
		DateTimeOffset? selectedDate = SelectedDate;
		if (selectedDate.HasValue)
		{
			todaysDate = selectedDate.Value;
		}
		else
		{
			GetTodaysDate(out todaysDate);
		}
		todaysDate = ClampDate(todaysDate.Value, m_startDate, m_endDate);
		if (m_tpFlyoutButton != null && m_tpYearTextBlock == null && m_tpMonthTextBlock == null && m_tpDayTextBlock == null)
		{
			string content = ppDateFormatter.Format(todaysDate.Value);
			(m_tpFlyoutButton as Button).Content = content;
		}
		if (m_tpYearTextBlock != null)
		{
			if (selectedDate.HasValue)
			{
				GetYearFormatter(YearFormat, calendarIdentifier, out var ppDateTimeFormatter);
				string text = ppDateTimeFormatter.Format(todaysDate.Value);
				m_tpYearTextBlock.Text = text;
			}
			else
			{
				m_tpYearTextBlock.Text = ResourceLoader.GetForCurrentView().GetString("TEXT_DATEPICKER_YEAR_PLACEHOLDER");
			}
		}
		if (m_tpMonthTextBlock != null)
		{
			if (selectedDate.HasValue)
			{
				GetMonthFormatter(MonthFormat, calendarIdentifier, out var ppDateTimeFormatter2);
				string text2 = ppDateTimeFormatter2.Format(todaysDate.Value);
				m_tpMonthTextBlock.Text = text2;
			}
			else
			{
				m_tpMonthTextBlock.Text = ResourceLoader.GetForCurrentView().GetString("TEXT_DATEPICKER_MONTH_PLACEHOLDER");
			}
		}
		if (m_tpDayTextBlock != null)
		{
			if (selectedDate.HasValue)
			{
				string dayFormat = DayFormat;
				GetDayFormatter(dayFormat, calendarIdentifier, out var ppDateTimeFormatter3);
				string text3 = ppDateTimeFormatter3.Format(todaysDate.Value);
				m_tpDayTextBlock.Text = text3;
			}
			else
			{
				m_tpDayTextBlock.Text = ResourceLoader.GetForCurrentView().GetString("TEXT_DATEPICKER_DAY_PLACEHOLDER");
			}
		}
		RefreshFlyoutButtonAutomationName();
	}

	private void GetYearDifference(Calendar pStartCalendar, Calendar pEndCalendar, out int difference)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string calendarSystem = pStartCalendar.GetCalendarSystem();
		string calendarSystem2 = pEndCalendar.GetCalendarSystem();
		difference = 0;
		num = pStartCalendar.Era;
		num2 = pEndCalendar.Era;
		num3 = pStartCalendar.Year;
		num4 = pEndCalendar.Year;
		while (num != num2 || num3 != num4)
		{
			pStartCalendar.AddYears(1);
			difference++;
			num = pStartCalendar.Era;
			num3 = pStartCalendar.Year;
		}
	}

	private DateTimeOffset ClampDate(DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
	{
		if (date < minDate)
		{
			return minDate;
		}
		if (date > maxDate)
		{
			return maxDate;
		}
		return date;
	}

	private void GetOrder(out int yearOrder, out int monthOrder, out int dayOrder, out bool isRTL)
	{
		string calendarIdentifier = CalendarIdentifier;
		CreateNewFormatter("day month.full year", calendarIdentifier, out var ppDateTimeFormatter);
		IReadOnlyList<string> patterns = ppDateTimeFormatter.Patterns;
		string text = patterns[0];
		if (text != null)
		{
			string text2 = text;
			isRTL = text2[0] == '\u200f';
			int num = text2.IndexOf("{day");
			int num2 = text2.IndexOf("{month");
			int num3 = text2.IndexOf("{year");
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
		else
		{
			dayOrder = 0;
			monthOrder = 1;
			yearOrder = 2;
			isRTL = false;
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
		bool flag5 = false;
		bool flag6 = false;
		ColumnDefinitionCollection columnDefinitionCollection = new ColumnDefinitionCollection();
		int num = 0;
		ColumnDefinition columnDefinition = null;
		ColumnDefinition columnDefinition2 = null;
		ColumnDefinition columnDefinition3 = null;
		GetOrder(out yearOrder, out monthOrder, out dayOrder, out isRTL);
		if (m_tpLayoutRoot != null)
		{
			m_tpLayoutRoot.FlowDirection = (isRTL ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
		if (m_tpFirstPickerHost != null)
		{
			m_tpFirstPickerHost.Child = null;
		}
		if (m_tpSecondPickerHost != null)
		{
			m_tpSecondPickerHost.Child = null;
		}
		if (m_tpThirdPickerHost != null)
		{
			m_tpThirdPickerHost.Child = null;
		}
		if (m_tpFlyoutButtonContentGrid != null)
		{
			columnDefinitionCollection = m_tpFlyoutButtonContentGrid.ColumnDefinitions;
			columnDefinitionCollection.Clear();
		}
		flag = DayVisible;
		flag2 = MonthVisible;
		flag3 = YearVisible;
		switch (yearOrder)
		{
		case 0:
			if (m_tpFirstPickerHost != null && m_tpYearPicker != null && flag3)
			{
				m_tpFirstPickerHost.Child = m_tpYearPicker;
				flag4 = true;
			}
			else if (m_tpYearTextBlock != null && flag3)
			{
				flag4 = true;
				columnDefinition = m_tpYearColumn;
			}
			break;
		case 1:
			if (m_tpSecondPickerHost != null && m_tpYearPicker != null && flag3)
			{
				m_tpSecondPickerHost.Child = m_tpYearPicker;
				flag5 = true;
			}
			else if (m_tpYearTextBlock != null && flag3)
			{
				flag5 = true;
				columnDefinition2 = m_tpYearColumn;
			}
			break;
		case 2:
			if (m_tpThirdPickerHost != null && m_tpYearPicker != null && flag3)
			{
				m_tpThirdPickerHost.Child = m_tpYearPicker;
				flag6 = true;
			}
			else if (m_tpYearTextBlock != null && flag3)
			{
				flag6 = true;
				columnDefinition3 = m_tpYearColumn;
			}
			break;
		}
		switch (monthOrder)
		{
		case 0:
			if (m_tpFirstPickerHost != null && m_tpMonthPicker != null && flag2)
			{
				m_tpFirstPickerHost.Child = m_tpMonthPicker;
				flag4 = true;
			}
			else if (m_tpMonthTextBlock != null && flag2)
			{
				flag4 = true;
				columnDefinition = m_tpMonthColumn;
			}
			break;
		case 1:
			if (m_tpSecondPickerHost != null && m_tpMonthPicker != null && flag2)
			{
				m_tpSecondPickerHost.Child = m_tpMonthPicker;
				flag5 = true;
			}
			else if (m_tpMonthTextBlock != null && flag2)
			{
				flag5 = true;
				columnDefinition2 = m_tpMonthColumn;
			}
			break;
		case 2:
			if (m_tpThirdPickerHost != null && m_tpMonthPicker != null && flag2)
			{
				m_tpThirdPickerHost.Child = m_tpMonthPicker;
				flag6 = true;
			}
			else if (m_tpMonthTextBlock != null && flag2)
			{
				flag6 = true;
				columnDefinition3 = m_tpMonthColumn;
			}
			break;
		}
		switch (dayOrder)
		{
		case 0:
			if (m_tpFirstPickerHost != null && m_tpDayPicker != null && flag)
			{
				m_tpFirstPickerHost.Child = m_tpDayPicker;
				flag4 = true;
			}
			else if (m_tpDayTextBlock != null && flag)
			{
				flag4 = true;
				columnDefinition = m_tpDayColumn;
			}
			break;
		case 1:
			if (m_tpSecondPickerHost != null && m_tpDayPicker != null && flag)
			{
				m_tpSecondPickerHost.Child = m_tpDayPicker;
				flag5 = true;
			}
			else if (m_tpDayTextBlock != null && flag)
			{
				flag5 = true;
				columnDefinition2 = m_tpDayColumn;
			}
			break;
		case 2:
			if (m_tpThirdPickerHost != null && m_tpDayPicker != null && flag)
			{
				m_tpThirdPickerHost.Child = m_tpDayPicker;
				flag6 = true;
			}
			else if (m_tpDayTextBlock != null && flag)
			{
				flag6 = true;
				columnDefinition3 = m_tpDayColumn;
			}
			break;
		}
		if (columnDefinitionCollection != null)
		{
			if (columnDefinition != null)
			{
				columnDefinitionCollection.Add(columnDefinition);
			}
			if (m_tpFirstSpacerColumn != null)
			{
				columnDefinitionCollection.Add(m_tpFirstSpacerColumn);
			}
			if (columnDefinition2 != null)
			{
				columnDefinitionCollection.Add(columnDefinition2);
			}
			if (m_tpSecondSpacerColumn != null)
			{
				columnDefinitionCollection.Add(m_tpSecondSpacerColumn);
			}
			if (columnDefinition3 != null)
			{
				columnDefinitionCollection.Add(columnDefinition3);
			}
		}
		if (m_tpYearTextBlock != null && m_tpYearColumn != null && flag3 && columnDefinitionCollection != null)
		{
			num = columnDefinitionCollection.IndexOf(m_tpYearColumn);
			Grid.SetColumn(m_tpYearTextBlock, num);
		}
		if (m_tpMonthTextBlock != null && m_tpMonthColumn != null && flag2 && columnDefinitionCollection != null)
		{
			num = columnDefinitionCollection.IndexOf(m_tpMonthColumn);
			Grid.SetColumn(m_tpMonthTextBlock, num);
		}
		if (m_tpDayTextBlock != null && m_tpDayColumn != null && flag && columnDefinitionCollection != null)
		{
			num = columnDefinitionCollection.IndexOf(m_tpDayColumn);
			Grid.SetColumn(m_tpDayTextBlock, num);
		}
		if (m_tpDayTextBlock != null)
		{
			m_tpDayTextBlock.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpMonthTextBlock != null)
		{
			m_tpMonthTextBlock.Visibility = ((!flag2) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpYearTextBlock != null)
		{
			m_tpYearTextBlock.Visibility = ((!flag3) ? Visibility.Collapsed : Visibility.Visible);
		}
		if (m_tpFirstPickerSpacing != null)
		{
			m_tpFirstPickerSpacing.Visibility = ((!flag4 || !(flag5 || flag6)) ? Visibility.Collapsed : Visibility.Visible);
			if (m_tpFirstSpacerColumn != null && columnDefinitionCollection != null)
			{
				num = columnDefinitionCollection.IndexOf(m_tpFirstSpacerColumn);
				Grid.SetColumn(m_tpFirstPickerSpacing, num);
			}
		}
		if (m_tpSecondPickerSpacing != null)
		{
			m_tpSecondPickerSpacing.Visibility = ((!(flag5 && flag6)) ? Visibility.Collapsed : Visibility.Visible);
			if (m_tpSecondSpacerColumn != null && columnDefinitionCollection != null)
			{
				num = columnDefinitionCollection.IndexOf(m_tpSecondSpacerColumn);
				Grid.SetColumn(m_tpSecondPickerSpacing, num);
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
		m_tpCalendar = null;
		string calendarIdentifier = CalendarIdentifier;
		CreateNewCalendar(calendarIdentifier, out var ppCalendar);
		m_tpCalendar = ppCalendar;
		dateTimeOffset = MinYear;
		dateTimeOffset2 = MaxYear;
		m_hasValidYearRange = dateTimeOffset.ToUniversalTime() <= dateTimeOffset2.ToUniversalTime();
		if (m_hasValidYearRange)
		{
			m_tpCalendar.SetToMin();
			dateTimeOffset4 = m_tpCalendar.GetDateTime();
			m_tpCalendar.SetToMax();
			dateTimeOffset3 = m_tpCalendar.GetDateTime();
			dateTimeOffset = ClampDate(dateTimeOffset, dateTimeOffset4, dateTimeOffset3);
			dateTimeOffset2 = ClampDate(dateTimeOffset2, dateTimeOffset4, dateTimeOffset3);
			m_tpCalendar.SetDateTime(dateTimeOffset);
			num = m_tpCalendar.FirstMonthInThisYear;
			m_tpCalendar.Month = num;
			num2 = m_tpCalendar.FirstDayInThisMonth;
			m_tpCalendar.Day = num2;
			dateTimeOffset = m_tpCalendar.GetDateTime();
			m_tpCalendar.SetDateTime(dateTimeOffset2);
			num = m_tpCalendar.LastMonthInThisYear;
			m_tpCalendar.Month = num;
			num2 = m_tpCalendar.LastDayInThisMonth;
			m_tpCalendar.Day = num2;
			dateTimeOffset2 = m_tpCalendar.GetDateTime();
			m_tpCalendar.SetDateTime(dateTimeOffset);
			m_tpCalendar.Hour = 12;
			m_tpCalendar.Minute = 0;
			m_tpCalendar.Second = 0;
			m_startDate = m_tpCalendar.GetDateTime();
			m_endDate = dateTimeOffset2;
			m_tpCalendar.SetDateTime(m_startDate);
			CreateNewCalendar(calendarIdentifier, out ppCalendar);
			ppCalendar.SetDateTime(m_endDate);
			GetYearDifference(m_tpCalendar, ppCalendar, out m_numberOfYears);
			m_numberOfYears++;
		}
		else
		{
			ClearSelectors(clearDay: true, clearMonth: true, clearYear: true);
		}
		UpdateOrderAndLayout();
	}

	private void GetSelectedDateAsString(out string strPlainText)
	{
		DateTimeOffset? date = null;
		GetSelectedDateOrTodaysDateIfNull(out date);
		string calendarIdentifier = CalendarIdentifier;
		CreateNewFormatter("day month.full year", calendarIdentifier, out var ppDateTimeFormatter);
		strPlainText = ppDateTimeFormatter.Format(date.Value);
	}

	private void RefreshFlyoutButtonAutomationName()
	{
	}

	private void GetTodaysDate(out DateTimeOffset? todaysDate)
	{
		if (m_todaysDate.ToUniversalTime() == NullDateSentinelValue)
		{
			string calendarIdentifier = CalendarIdentifier;
			CreateNewCalendar(calendarIdentifier, out var ppCalendar);
			ppCalendar.SetToNow();
			m_todaysDate = ppCalendar.GetDateTime();
			m_todaysDate = ClampDate(m_todaysDate, m_startDate, m_endDate);
		}
		todaysDate = m_todaysDate;
	}

	private void GetSelectedDateOrTodaysDateIfNull(out DateTimeOffset? date)
	{
		DateTimeOffset? selectedDate = SelectedDate;
		if (selectedDate.HasValue)
		{
			date = selectedDate;
		}
		else
		{
			GetTodaysDate(out date);
		}
	}

	private void InitPartial()
	{
		_lazyFlyout = new Lazy<DatePickerFlyout>(new Func<DatePickerFlyout>(CreateManagedDatePickerFlyout));
		DatePickerFlyout CreateManagedDatePickerFlyout()
		{
			DatePickerFlyout datePickerFlyout = new DatePickerFlyout
			{
				DatePickerFlyoutPresenterStyle = FlyoutPresenterStyle
			};
			datePickerFlyout.DatePicked += OnPicked;
			return datePickerFlyout;
		}
		void OnPicked(DatePickerFlyout snd, DatePickedEventArgs evt)
		{
			SelectedDate = evt.NewDate;
			Date = evt.NewDate;
			if (evt.NewDate != evt.OldDate)
			{
				this.DateChanged?.Invoke(this, new DatePickerValueChangedEventArgs(evt.NewDate, evt.OldDate));
			}
		}
	}

	private void OnDatePropertyChanged(DateTimeOffset newValue, DateTimeOffset oldValue)
	{
	}
}
