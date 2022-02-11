using System;
using System.Collections.Generic;
using DirectUI;
using Uno;
using Uno.UI.Xaml.Core;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.System;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class CalendarDatePicker : Control
{
	private static Calendar _gregorianCalendar;

	private const int DEFAULT_MIN_MAX_DATE_YEAR_OFFSET = 100;

	private const string TEXT_CALENDARDATEPICKER_DEFAULT_PLACEHOLDER_TEXT = "TEXT_CALENDARDATEPICKER_DEFAULT_PLACEHOLDER_TEXT";

	private CalendarView m_tpCalendarView;

	private ContentPresenter m_tpHeaderContentPresenter;

	private TextBlock m_tpDateText;

	private Grid m_tpRoot;

	private FlyoutBase m_tpFlyout;

	private int m_colsInYearDecadeView;

	private int m_rowsInYearDecadeView;

	private DateTimeOffset m_displayDate;

	private DateTimeFormatter m_tpDateFormatter;

	private bool m_isYearDecadeViewDimensionRequested;

	private bool m_isSetDisplayDateRequested;

	private bool m_isPointerOverMain;

	private bool m_isPressedOnMain;

	private bool m_shouldPerformActions;

	private bool m_isSelectedDatesChangingInternally;

	public static DependencyProperty CalendarIdentifierProperty { get; } = DependencyProperty.Register("CalendarIdentifier", typeof(string), typeof(CalendarDatePicker), new FrameworkPropertyMetadata("GregorianCalendar"));


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

	public static DependencyProperty CalendarViewStyleProperty { get; } = DependencyProperty.Register("CalendarViewStyle", typeof(Style), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


	public Style CalendarViewStyle
	{
		get
		{
			return (Style)GetValue(CalendarViewStyleProperty);
		}
		set
		{
			SetValue(CalendarViewStyleProperty, value);
		}
	}

	public static DependencyProperty DateProperty { get; } = DependencyProperty.Register("Date", typeof(DateTimeOffset?), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


	public DateTimeOffset? Date
	{
		get
		{
			return (DateTimeOffset?)GetValue(DateProperty);
		}
		set
		{
			SetValue(DateProperty, value);
		}
	}

	public static DependencyProperty DateFormatProperty { get; } = DependencyProperty.Register("DateFormat", typeof(string), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


	public string DateFormat
	{
		get
		{
			return (string)GetValue(DateFormatProperty);
		}
		set
		{
			SetValue(DateFormatProperty, value);
		}
	}

	public static DependencyProperty DayOfWeekFormatProperty { get; } = DependencyProperty.Register("DayOfWeekFormat", typeof(string), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


	public string DayOfWeekFormat
	{
		get
		{
			return (string)GetValue(DayOfWeekFormatProperty);
		}
		set
		{
			SetValue(DayOfWeekFormatProperty, value);
		}
	}

	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


	public object Description
	{
		get
		{
			return (string)GetValue(DescriptionProperty);
		}
		set
		{
			SetValue(DescriptionProperty, value);
		}
	}

	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(CalendarViewDisplayMode), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(CalendarViewDisplayMode.Month));


	public CalendarViewDisplayMode DisplayMode
	{
		get
		{
			return (CalendarViewDisplayMode)GetValue(DisplayModeProperty);
		}
		set
		{
			SetValue(DisplayModeProperty, value);
		}
	}

	public static DependencyProperty FirstDayOfWeekProperty { get; } = DependencyProperty.Register("FirstDayOfWeek", typeof(Windows.Globalization.DayOfWeek), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(Windows.Globalization.DayOfWeek.Sunday));


	public Windows.Globalization.DayOfWeek FirstDayOfWeek
	{
		get
		{
			return (Windows.Globalization.DayOfWeek)GetValue(FirstDayOfWeekProperty);
		}
		set
		{
			SetValue(FirstDayOfWeekProperty, value);
		}
	}

	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


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

	public static DependencyProperty IsCalendarOpenProperty { get; } = DependencyProperty.Register("IsCalendarOpen", typeof(bool), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(false));


	public bool IsCalendarOpen
	{
		get
		{
			return (bool)GetValue(IsCalendarOpenProperty);
		}
		set
		{
			SetValue(IsCalendarOpenProperty, value);
		}
	}

	public static DependencyProperty IsGroupLabelVisibleProperty { get; } = DependencyProperty.Register("IsGroupLabelVisible", typeof(bool), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(false));


	public bool IsGroupLabelVisible
	{
		get
		{
			return (bool)GetValue(IsGroupLabelVisibleProperty);
		}
		set
		{
			SetValue(IsGroupLabelVisibleProperty, value);
		}
	}

	public static DependencyProperty IsOutOfScopeEnabledProperty { get; } = DependencyProperty.Register("IsOutOfScopeEnabled", typeof(bool), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(true));


	public bool IsOutOfScopeEnabled
	{
		get
		{
			return (bool)GetValue(IsOutOfScopeEnabledProperty);
		}
		set
		{
			SetValue(IsOutOfScopeEnabledProperty, value);
		}
	}

	public static DependencyProperty IsTodayHighlightedProperty { get; } = DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(true));


	public bool IsTodayHighlighted
	{
		get
		{
			return (bool)GetValue(IsTodayHighlightedProperty);
		}
		set
		{
			SetValue(IsTodayHighlightedProperty, value);
		}
	}

	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


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

	public static DependencyProperty MaxDateProperty { get; } = DependencyProperty.Register("MaxDate", typeof(DateTimeOffset), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(default(DateTimeOffset)));


	public DateTimeOffset MaxDate
	{
		get
		{
			return (DateTimeOffset)GetValue(MaxDateProperty);
		}
		set
		{
			SetValue(MaxDateProperty, value);
		}
	}

	public static DependencyProperty MinDateProperty { get; } = DependencyProperty.Register("MinDate", typeof(DateTimeOffset), typeof(CalendarDatePicker), new FrameworkPropertyMetadata(default(DateTimeOffset)));


	public DateTimeOffset MinDate
	{
		get
		{
			return (DateTimeOffset)GetValue(MinDateProperty);
		}
		set
		{
			SetValue(MinDateProperty, value);
		}
	}

	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(CalendarDatePicker), new FrameworkPropertyMetadata((object)null));


	public string PlaceholderText
	{
		get
		{
			return (string)GetValue(PlaceholderTextProperty);
		}
		set
		{
			SetValue(PlaceholderTextProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event CalendarViewDayItemChangingEventHandler CalendarViewDayItemChanging
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.CalendarDatePicker", "event CalendarViewDayItemChangingEventHandler CalendarDatePicker.CalendarViewDayItemChanging");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.CalendarDatePicker", "event CalendarViewDayItemChangingEventHandler CalendarDatePicker.CalendarViewDayItemChanging");
		}
	}

	private event EventHandler<object> _opened;

	public event EventHandler<object> Opened
	{
		add
		{
			_opened += value;
		}
		remove
		{
			_opened -= value;
		}
	}

	private event EventHandler<object> _closed;

	public event EventHandler<object> Closed
	{
		add
		{
			_closed += value;
		}
		remove
		{
			_closed -= value;
		}
	}

	public event TypedEventHandler<CalendarDatePicker, CalendarDatePickerDateChangedEventArgs> _dateChanged;

	public event TypedEventHandler<CalendarDatePicker, CalendarDatePickerDateChangedEventArgs> DateChanged
	{
		add
		{
			_dateChanged += value;
		}
		remove
		{
			_dateChanged -= value;
		}
	}

	private protected override void OnUnloaded()
	{
		IsCalendarOpen = false;
		base.OnUnloaded();
	}

	private bool SetPropertyDefaultValue(DependencyProperty property, out object value)
	{
		if (property == MinDateProperty)
		{
			Calendar calendar = GetOrCreateGregorianCalendar();
			calendar.SetToMin();
			DateTimeOffset dateTime = calendar.GetDateTime();
			calendar.SetToMax();
			DateTimeOffset dateTime2 = calendar.GetDateTime();
			calendar.SetToday();
			calendar.AddYears(-100);
			calendar.Month = calendar.FirstMonthInThisYear;
			calendar.Day = calendar.FirstDayInThisMonth;
			DateTimeOffset dateTime3 = calendar.GetDateTime();
			value = ClampDate(dateTime3, dateTime, dateTime2);
			return true;
		}
		if (property == MaxDateProperty)
		{
			Calendar calendar2 = GetOrCreateGregorianCalendar();
			calendar2.SetToMin();
			DateTimeOffset dateTime4 = calendar2.GetDateTime();
			calendar2.SetToMax();
			DateTimeOffset dateTime5 = calendar2.GetDateTime();
			calendar2.SetToday();
			calendar2.AddYears(100);
			calendar2.Month = calendar2.LastMonthInThisYear;
			calendar2.Day = calendar2.LastDayInThisMonth;
			DateTimeOffset dateTime6 = calendar2.GetDateTime();
			value = ClampDate(dateTime6, dateTime4, dateTime5);
			return true;
		}
		value = null;
		return false;
		static DateTimeOffset ClampDate(DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
		{
			if (!(date < minDate))
			{
				if (!(date > maxDate))
				{
					return date;
				}
				return maxDate;
			}
			return minDate;
		}
		static Calendar GetOrCreateGregorianCalendar()
		{
			if (_gregorianCalendar == null)
			{
				Calendar calendar3 = new Calendar();
				_gregorianCalendar = new Calendar(calendar3.Languages, "GregorianCalendar", calendar3.GetClock());
			}
			return _gregorianCalendar;
		}
	}

	public CalendarDatePicker()
	{
		base.DefaultStyleKey = typeof(CalendarDatePicker);
		this.RegisterDefaultValueProvider(SetPropertyDefaultValue);
		m_isYearDecadeViewDimensionRequested = false;
		m_colsInYearDecadeView = 0;
		m_rowsInYearDecadeView = 0;
		m_isSetDisplayDateRequested = false;
		m_displayDate = default(DateTimeOffset);
		m_isPointerOverMain = false;
		m_isPressedOnMain = false;
		m_shouldPerformActions = false;
		m_isSelectedDatesChangingInternally = false;
		PrepareState();
	}

	private void PrepareState()
	{
		string text = (PlaceholderText = DXamlCore.Current.GetLocalizedResourceString("TEXT_CALENDARDATEPICKER_DEFAULT_PLACEHOLDER_TEXT"));
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		if (args.Property == IsCalendarOpenProperty)
		{
			UpdateCalendarVisibility();
		}
		else if (args.Property == DateProperty)
		{
			DateTimeOffset? pOldDateReference = (DateTimeOffset?)args.OldValue;
			DateTimeOffset? pNewDateReference = (DateTimeOffset?)args.NewValue;
			OnDateChanged(pOldDateReference, pNewDateReference);
		}
		else if (args.Property == FrameworkElement.LanguageProperty || args.Property == CalendarIdentifierProperty || args.Property == DateFormatProperty)
		{
			OnDateFormatChanged();
		}
		else if (args.Property == HeaderProperty || args.Property == HeaderTemplateProperty)
		{
			UpdateHeaderVisibility();
		}
		else if (args.Property == LightDismissOverlayModeProperty && m_tpFlyout != null)
		{
			LightDismissOverlayMode lightDismissOverlayMode = LightDismissOverlayMode.Off;
			lightDismissOverlayMode = LightDismissOverlayMode;
			m_tpFlyout.LightDismissOverlayMode = lightDismissOverlayMode;
		}
	}

	protected override void OnApplyTemplate()
	{
		if (m_tpFlyout != null)
		{
			m_tpFlyout.Opened -= OnFlyoutOpened;
			m_tpFlyout.Closed -= OnFlyoutClosed;
		}
		if (m_tpCalendarView != null)
		{
			m_tpCalendarView.CalendarViewDayItemChanging -= OnCalendarViewDayChanging;
			m_tpCalendarView.SelectedDatesChanged -= OnCalendarViewDatesChanged;
		}
		m_tpCalendarView = null;
		m_tpHeaderContentPresenter = null;
		m_tpDateText = null;
		m_tpFlyout = null;
		m_tpRoot = null;
		CalendarView tpCalendarView = GetTemplateChild("CalendarView") as CalendarView;
		TextBlock tpDateText = GetTemplateChild("DateText") as TextBlock;
		Grid tpRoot = GetTemplateChild("Root") as Grid;
		m_tpCalendarView = tpCalendarView;
		m_tpDateText = tpDateText;
		m_tpRoot = tpRoot;
		if (m_tpRoot != null)
		{
			FlyoutBase flyoutBase = (m_tpFlyout = FlyoutBase.GetAttachedFlyout(m_tpRoot));
			if (m_tpFlyout != null)
			{
				m_tpFlyout.DisablePresenterResizing();
				LightDismissOverlayMode lightDismissOverlayMode = LightDismissOverlayMode.Off;
				m_tpFlyout.LightDismissOverlayMode = lightDismissOverlayMode;
				m_tpFlyout.Opened += OnFlyoutOpened;
				m_tpFlyout.Closed += OnFlyoutClosed;
			}
		}
		if (m_tpCalendarView != null)
		{
			m_tpCalendarView.CalendarViewDayItemChanging += OnCalendarViewDayChanging;
			m_tpCalendarView.SelectedDatesChanged += OnCalendarViewDatesChanged;
			if (m_isYearDecadeViewDimensionRequested)
			{
				m_isYearDecadeViewDimensionRequested = false;
				m_tpCalendarView.SetYearDecadeDisplayDimensions(m_colsInYearDecadeView, m_rowsInYearDecadeView);
			}
			if (m_isSetDisplayDateRequested)
			{
				m_isSetDisplayDateRequested = false;
				m_tpCalendarView.SetDisplayDate(m_displayDate);
			}
		}
		UpdateCalendarVisibility();
		UpdateHeaderVisibility();
		FormatDate();
		UpdateVisualState();
		void OnCalendarViewDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
		{
			OnSelectedDatesChanged(sender, args);
		}
		static void OnCalendarViewDayChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
		{
		}
		void OnFlyoutClosed(object sender, object eventArgs)
		{
			IsCalendarOpen = false;
			this._closed?.Invoke(this, new object());
		}
		void OnFlyoutOpened(object sender, object eventArgs)
		{
			IsCalendarOpen = true;
			this._opened?.Invoke(this, new object());
		}
	}

	private void OnSelectedDatesChanged(CalendarView pSender, CalendarViewSelectedDatesChangedEventArgs pArgs)
	{
		if (m_isSelectedDatesChangingInternally)
		{
			return;
		}
		CalendarViewSelectionMode calendarViewSelectionMode = CalendarViewSelectionMode.None;
		calendarViewSelectionMode = m_tpCalendarView.SelectionMode;
		if (calendarViewSelectionMode == CalendarViewSelectionMode.Single)
		{
			int num = 0;
			IReadOnlyList<DateTimeOffset> addedDates = pArgs.AddedDates;
			num = addedDates.Count;
			if (num == 1)
			{
				DateTimeOffset date = addedDates[0];
				PropertyValue.CreateFromDateTime(date, out var value);
				DateTimeOffset value2 = (DateTimeOffset)value;
				IsCalendarOpen = false;
				Date = value2;
			}
			else
			{
				Date = null;
			}
		}
	}

	private void OnDateChanged(DateTimeOffset? pOldDateReference, DateTimeOffset? pNewDateReference)
	{
		if (pNewDateReference.HasValue)
		{
			DateTimeOffset value = pNewDateReference.Value;
			DateTimeOffset dateTimeOffset = new DateTimeOffset(Math.Min(val2: Math.Max(MinDate.UtcTicks, value.UtcTicks), val1: MaxDate.UtcTicks), TimeSpan.Zero);
			if (dateTimeOffset.UtcTicks != value.UtcTicks)
			{
				DateTimeOffset value2 = dateTimeOffset;
				Date = value2;
				return;
			}
		}
		SyncDate();
		RaiseDateChanged(pOldDateReference, pNewDateReference);
		FormatDate();
		UpdateVisualState();
	}

	private void RaiseDateChanged(DateTimeOffset? pOldDateReference, DateTimeOffset? pNewDateReference)
	{
		CalendarDatePickerDateChangedEventArgs args = new CalendarDatePickerDateChangedEventArgs(pNewDateReference, pOldDateReference);
		this._dateChanged?.Invoke(this, args);
	}

	public void SetYearDecadeDisplayDimensions(int columns, int rows)
	{
		if (m_tpCalendarView != null)
		{
			m_tpCalendarView.SetYearDecadeDisplayDimensions(columns, rows);
			return;
		}
		m_isYearDecadeViewDimensionRequested = true;
		m_colsInYearDecadeView = columns;
		m_rowsInYearDecadeView = rows;
	}

	public void SetDisplayDate(DateTimeOffset date)
	{
		if (m_tpCalendarView != null)
		{
			m_tpCalendarView.SetDisplayDate(date);
			return;
		}
		m_isSetDisplayDateRequested = true;
		m_displayDate = date;
	}

	private void UpdateCalendarVisibility()
	{
		if (m_tpFlyout != null && m_tpRoot != null)
		{
			bool flag = false;
			if (IsCalendarOpen)
			{
				m_tpFlyout.ShowAt(m_tpRoot);
				SyncDate();
			}
			else
			{
				m_tpFlyout.Hide();
			}
		}
	}

	private void OnDateFormatChanged()
	{
		bool isUnsetValue = false;
		object spDateFormat = ReadLocalValue(DateFormatProperty);
		DependencyPropertyFactory.IsUnsetValue(spDateFormat, out isUnsetValue);
		m_tpDateFormatter = null;
		if (!isUnsetValue)
		{
			string dateFormat = DateFormat;
			if (!string.IsNullOrEmpty(dateFormat))
			{
				string clock = "24HourClock";
				string geographicRegion = "ZZ";
				string calendarIdentifier = CalendarIdentifier;
				string language = base.Language;
				IEnumerable<string> languages = CalendarView.CreateCalendarLanguagesStatic(language);
				DateTimeFormatter dateTimeFormatter = (m_tpDateFormatter = new DateTimeFormatter(dateFormat, languages, geographicRegion, calendarIdentifier, clock));
			}
		}
		FormatDate();
	}

	private void FormatDate()
	{
		if (m_tpDateText == null)
		{
			return;
		}
		DateTimeOffset? date = Date;
		string text;
		if (date.HasValue)
		{
			DateTimeOffset value = date.Value;
			if (m_tpDateFormatter != null)
			{
				text = m_tpDateFormatter.Format(value);
			}
			else
			{
				DateTimeFormatter shortDate = DateTimeFormatter.ShortDate;
				text = shortDate.Format(value);
			}
		}
		else
		{
			text = PlaceholderText;
		}
		m_tpDateText.Text = text;
	}

	private void UpdateHeaderVisibility()
	{
		DataTemplate headerTemplate = HeaderTemplate;
		object header = Header;
		ConditionallyGetTemplatePartAndUpdateVisibility("HeaderContentPresenter", header != null || headerTemplate != null, ref m_tpHeaderContentPresenter);
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		bool flag = false;
		bool b = false;
		FocusState focusState = FocusState.Unfocused;
		flag = base.IsEnabled;
		focusState = base.FocusState;
		DateTimeOffset? date = Date;
		if (!flag)
		{
			GoToState(useTransitions, "Disabled", out b);
		}
		else if (m_isPressedOnMain)
		{
			GoToState(useTransitions, "Pressed", out b);
		}
		else if (m_isPointerOverMain)
		{
			GoToState(useTransitions, "PointerOver", out b);
		}
		else
		{
			GoToState(useTransitions, "Normal", out b);
		}
		if (focusState != FocusState.Unfocused && flag)
		{
			if (FocusState.Pointer == focusState)
			{
				GoToState(useTransitions, "PointerFocused", out b);
			}
			else
			{
				GoToState(useTransitions, "Focused", out b);
			}
		}
		else
		{
			GoToState(useTransitions, "Unfocused", out b);
		}
		if (date.HasValue && flag)
		{
			GoToState(useTransitions, "Selected", out b);
		}
		else
		{
			GoToState(useTransitions, "Unselected", out b);
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		bool flag = false;
		if (!pArgs.Handled)
		{
			VirtualKey virtualKey = VirtualKey.None;
			VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
			GetKeyboardModifiers(out virtualKeyModifiers);
			virtualKey = pArgs.Key;
			if (virtualKeyModifiers == VirtualKeyModifiers.None && (virtualKey == VirtualKey.Enter || virtualKey == VirtualKey.Space))
			{
				IsCalendarOpen = true;
			}
		}
	}

	protected override void OnPointerPressed(PointerRoutedEventArgs pArgs)
	{
		bool flag = false;
		if (pArgs.Handled)
		{
			return;
		}
		bool flag2 = false;
		if (!base.IsEnabled)
		{
			return;
		}
		bool pIsEventSourceChildOfTarget = false;
		IsEventSourceTarget(pArgs, out pIsEventSourceChildOfTarget);
		if (pIsEventSourceChildOfTarget)
		{
			bool flag3 = false;
			PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
			PointerPointProperties properties = currentPoint.Properties;
			if (properties.IsLeftButtonPressed)
			{
				pArgs.Handled = true;
				m_isPressedOnMain = true;
				UpdateVisualState();
			}
		}
	}

	protected override void OnPointerReleased(PointerRoutedEventArgs pArgs)
	{
		bool flag = false;
		if (pArgs.Handled)
		{
			return;
		}
		bool flag2 = false;
		if (!base.IsEnabled)
		{
			return;
		}
		bool pIsEventSourceChildOfTarget = false;
		IsEventSourceTarget(pArgs, out pIsEventSourceChildOfTarget);
		if (pIsEventSourceChildOfTarget)
		{
			bool flag3 = false;
			PointerPoint currentPoint = pArgs.GetCurrentPoint(this);
			PointerPointProperties properties = currentPoint.Properties;
			flag3 = properties.IsLeftButtonPressed;
			VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
			GetKeyboardModifiers(out virtualKeyModifiers);
			m_shouldPerformActions = m_isPressedOnMain && !flag3 && virtualKeyModifiers == VirtualKeyModifiers.None;
			if (m_shouldPerformActions)
			{
				m_isPressedOnMain = false;
				pArgs.Handled = true;
			}
			GestureModes gestureModes = GestureModes.None;
			gestureModes = pArgs.GestureFollowing;
			if (gestureModes != GestureModes.RightTapped)
			{
				PerformPointerUpAction();
				UpdateVisualState();
			}
		}
	}

	private protected override void OnRightTappedUnhandled(RightTappedRoutedEventArgs pArgs)
	{
		bool flag = false;
		if (!pArgs.Handled)
		{
			bool pIsEventSourceChildOfTarget = false;
			IsEventSourceTarget(pArgs, out pIsEventSourceChildOfTarget);
			if (pIsEventSourceChildOfTarget)
			{
				PerformPointerUpAction();
			}
		}
	}

	protected override void OnPointerEntered(PointerRoutedEventArgs pArgs)
	{
		bool pIsEventSourceChildOfTarget = false;
		IsEventSourceTarget(pArgs, out pIsEventSourceChildOfTarget);
		if (pIsEventSourceChildOfTarget)
		{
			m_isPointerOverMain = true;
			m_isPressedOnMain = false;
			UpdateVisualState();
		}
	}

	protected override void OnPointerMoved(PointerRoutedEventArgs pArgs)
	{
		bool pIsEventSourceChildOfTarget = false;
		IsEventSourceTarget(pArgs, out pIsEventSourceChildOfTarget);
		if (pIsEventSourceChildOfTarget)
		{
			if (!m_isPointerOverMain)
			{
				m_isPointerOverMain = true;
				UpdateVisualState();
			}
		}
		else if (m_isPointerOverMain)
		{
			m_isPointerOverMain = false;
			m_isPressedOnMain = false;
			UpdateVisualState();
		}
	}

	protected override void OnPointerExited(PointerRoutedEventArgs pArgs)
	{
		m_isPointerOverMain = false;
		m_isPressedOnMain = false;
		UpdateVisualState();
	}

	protected override void OnGotFocus(RoutedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	protected override void OnLostFocus(RoutedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	protected override void OnPointerCaptureLost(PointerRoutedEventArgs pArgs)
	{
		PointerDeviceType pointerDeviceType = PointerDeviceType.Touch;
		Pointer pointer = pArgs.Pointer;
		PointerPoint currentPoint = pArgs.GetCurrentPoint(null);
		PointerDevice pointerDevice = currentPoint.PointerDevice;
		if (pointerDevice.PointerDeviceType == PointerDeviceType.Touch)
		{
			m_isPointerOverMain = false;
		}
		m_isPressedOnMain = false;
		UpdateVisualState();
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	private void PerformPointerUpAction()
	{
		if (m_shouldPerformActions)
		{
			m_shouldPerformActions = false;
			IsCalendarOpen = true;
			ElementSoundPlayerService elementSoundPlayerServiceNoRef = DXamlCore.Current.GetElementSoundPlayerServiceNoRef();
			elementSoundPlayerServiceNoRef.RequestInteractionSoundForElement(ElementSoundKind.Invoke, this);
		}
	}

	private void IsEventSourceTarget(RoutedEventArgs pArgs, out bool pIsEventSourceChildOfTarget)
	{
		object originalSource = pArgs.OriginalSource;
		DependencyObject pChild = originalSource as DependencyObject;
		IsChildOfTarget(pChild, doCacheResult: true, out pIsEventSourceChildOfTarget);
	}

	private void IsChildOfTarget(DependencyObject pChild, bool doCacheResult, out bool pIsChildOfTarget)
	{
		DependencyObject dependencyObject = null;
		bool flag = false;
		pIsChildOfTarget = false;
		if (pChild == null)
		{
			return;
		}
		bool flag2 = flag;
		DependencyObject dependencyObject2 = pChild;
		bool flag3 = false;
		DependencyObject tpHeaderContentPresenter = m_tpHeaderContentPresenter;
		while (dependencyObject2 != null && !flag3)
		{
			if (dependencyObject2 == dependencyObject)
			{
				flag3 = true;
			}
			else if (dependencyObject2 == this)
			{
				flag2 = true;
				flag3 = true;
			}
			else if (tpHeaderContentPresenter != null && dependencyObject2 == tpHeaderContentPresenter)
			{
				flag2 = false;
				flag3 = true;
			}
			else
			{
				DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject2);
				dependencyObject2 = parent;
			}
		}
		if (!flag3)
		{
			flag2 = false;
		}
		dependencyObject = pChild;
		flag = flag2;
		pIsChildOfTarget = flag2;
	}

	private void SyncDate()
	{
		if (m_tpCalendarView == null)
		{
			return;
		}
		bool flag = false;
		if (!IsCalendarOpen)
		{
			return;
		}
		m_isSelectedDatesChangingInternally = true;
		try
		{
			DateTimeOffset? date = Date;
			IList<DateTimeOffset> selectedDates = m_tpCalendarView.SelectedDates;
			selectedDates.Clear();
			if (date.HasValue)
			{
				DateTimeOffset value = date.Value;
				SetDisplayDate(value);
				selectedDates.Add(value);
			}
		}
		finally
		{
			m_isSelectedDatesChangingInternally = false;
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new CalendarDatePickerAutomationPeer(this);
	}

	internal void GetCurrentFormattedDate(out string value)
	{
		value = null;
		if (m_tpDateText != null)
		{
			value = m_tpDateText.Text;
		}
	}
}
