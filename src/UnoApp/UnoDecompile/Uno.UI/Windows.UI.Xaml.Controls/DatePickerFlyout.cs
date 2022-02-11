using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Globalization;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class DatePickerFlyout : PickerFlyoutBase
{
	protected TypedEventHandler<DatePickerFlyout, DatePickedEventArgs> _datePicked;

	private const int _deltaYears = 50;

	private static Calendar s_spCalendar;

	private protected IDatePickerFlyoutPresenter _tpPresenter;

	private FrameworkElement _tpTarget;

	private FlyoutAsyncOperationManager<DateTimeOffset?> _asyncOperationManager;

	private ButtonBase _tpAcceptButton;

	private ButtonBase _tpDismissButton;

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

	public static DependencyProperty DateProperty { get; } = DependencyProperty.Register("Date", typeof(DateTimeOffset), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultDate(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty DayFormatProperty { get; } = DependencyProperty.Register("DayFormat", typeof(string), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultDayFormat(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty MonthFormatProperty { get; } = DependencyProperty.Register("MonthFormat", typeof(string), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultMonthFormat(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty YearFormatProperty { get; } = DependencyProperty.Register("YearFormat", typeof(string), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultYearFormat(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty CalendarIdentifierProperty { get; } = DependencyProperty.Register("CalendarIdentifier", typeof(string), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultCalendarIdentifier(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty MinYearProperty { get; } = DependencyProperty.Register("MinYear", typeof(DateTimeOffset), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultMinYear(), FrameworkPropertyMetadataOptions.None));


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

	public static DependencyProperty MaxYearProperty { get; } = DependencyProperty.Register("MaxYear", typeof(DateTimeOffset), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(GetDefaultMaxYear(), FrameworkPropertyMetadataOptions.None));


	public Style DatePickerFlyoutPresenterStyle
	{
		get
		{
			return (Style)GetValue(DatePickerFlyoutPresenterStyleProperty);
		}
		set
		{
			SetValue(DatePickerFlyoutPresenterStyleProperty, value);
		}
	}

	public static DependencyProperty DatePickerFlyoutPresenterStyleProperty { get; } = DependencyProperty.Register("DatePickerFlyoutPresenterStyle", typeof(Style), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));


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

	public static DependencyProperty DayVisibleProperty { get; } = DependencyProperty.Register("DayVisible", typeof(bool), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerFlyout)s)?.OnDayVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
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

	public static DependencyProperty MonthVisibleProperty { get; } = DependencyProperty.Register("MonthVisible", typeof(bool), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerFlyout)s)?.OnMonthVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
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

	public static DependencyProperty YearVisibleProperty { get; } = DependencyProperty.Register("YearVisible", typeof(bool), typeof(DatePickerFlyout), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((DatePickerFlyout)s)?.OnYearVisibleChanged((bool)e.OldValue, (bool)e.NewValue);
	}));


	public event TypedEventHandler<DatePickerFlyout, DatePickedEventArgs> DatePicked
	{
		add
		{
			_datePicked = (TypedEventHandler<DatePickerFlyout, DatePickedEventArgs>)Delegate.Combine(_datePicked, value);
		}
		remove
		{
			_datePicked = (TypedEventHandler<DatePickerFlyout, DatePickedEventArgs>)Delegate.Remove(_datePicked, value);
		}
	}

	public DatePickerFlyout()
	{
		InitializeImpl();
	}

	private void InitializeImpl()
	{
		base.Placement = FlyoutPlacementMode.Right;
		base.UsePickerFlyoutTheme = true;
		_asyncOperationManager = new FlyoutAsyncOperationManager<DateTimeOffset?>(this, () => null);
	}

	protected override bool ShouldShowConfirmationButtons()
	{
		return false;
	}

	protected override void OnConfirmed()
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		dateTimeOffset = Date;
		dateTimeOffset2 = (Date = _tpPresenter.GetDate());
		_asyncOperationManager.Complete(dateTimeOffset2);
		_datePicked?.Invoke(this, new DatePickedEventArgs(dateTimeOffset2, dateTimeOffset));
		Close();
	}

	protected override Control CreatePresenter()
	{
		DatePickerFlyoutPresenter datePickerFlyoutPresenter = (DatePickerFlyoutPresenter)(_tpPresenter = new DatePickerFlyoutPresenter
		{
			Style = DatePickerFlyoutPresenterStyle
		});
		return _tpPresenter as Control;
	}

	private protected override void ShowAtCore(FrameworkElement placementTarget, FlyoutShowOptions showOptions)
	{
		_tpTarget = placementTarget;
		base.ShowAtCore(placementTarget, showOptions);
	}

	public IAsyncOperation<DateTimeOffset?> ShowAtAsync(FrameworkElement target)
	{
		_tpTarget = target;
		base.ShowAtCore(target, null);
		return _asyncOperationManager.Start(target);
	}

	private protected override void OnOpening()
	{
		if (_tpPresenter != null)
		{
			_tpPresenter.PullPropertiesFromOwner(this);
			_tpPresenter.SetAcceptDismissButtonsVisibility(isVisible: true);
			FrameworkElement tpTarget = _tpTarget;
			if (tpTarget != null && _tpPresenter is FrameworkElement frameworkElement)
			{
				double num = (frameworkElement.MinWidth = tpTarget.ActualWidth);
			}
		}
	}

	private protected override void OnOpened()
	{
		Control control = _tpPresenter as Control;
		if (_tpTarget != null)
		{
			Point point = DateTimePickerFlyoutHelper.CalculatePlacementPosition(_tpTarget, control);
			PlaceFlyoutForDateTimePicker(point);
		}
		DependencyObject dependencyObject = control?.GetTemplateChild("DismissButton");
		if (dependencyObject is ButtonBase tpDismissButton)
		{
			_tpDismissButton = tpDismissButton;
		}
		DependencyObject dependencyObject2 = control?.GetTemplateChild("AcceptButton");
		if (dependencyObject2 is ButtonBase tpAcceptButton)
		{
			_tpAcceptButton = tpAcceptButton;
		}
		if (_tpAcceptButton != null)
		{
			_tpAcceptButton.Click += OnAcceptClick;
		}
		if (_tpDismissButton != null)
		{
			_tpDismissButton.Click += OnDismissClick;
		}
		control.KeyDown += OnKeyDown;
	}

	private protected override void OnClosed()
	{
		base.OnClosed();
		if (_tpAcceptButton != null)
		{
			_tpAcceptButton.Click -= OnAcceptClick;
			_tpAcceptButton = null;
		}
		if (_tpDismissButton != null)
		{
			_tpDismissButton.Click -= OnDismissClick;
			_tpDismissButton = null;
		}
		if (_tpPresenter is Control control)
		{
			control.KeyDown -= OnKeyDown;
		}
	}

	private void OnAcceptClick(object sender, RoutedEventArgs pArgs)
	{
		OnConfirmed();
	}

	private void OnDismissClick(object sender, RoutedEventArgs pArgs)
	{
		Hide();
	}

	private void OnKeyDown(object sender, KeyRoutedEventArgs pEventArgs)
	{
		bool flag = false;
		bool flag2 = false;
		VirtualKey virtualKey = VirtualKey.None;
		if (pEventArgs == null)
		{
			throw new ArgumentNullException("sender");
		}
		if (pEventArgs.Handled)
		{
			return;
		}
		switch (pEventArgs.Key)
		{
		case VirtualKey.Up:
		case VirtualKey.Down:
		{
			VirtualKeyModifiers keyboardModifiers = PlatformHelpers.GetKeyboardModifiers();
			if (keyboardModifiers.HasFlag(VirtualKeyModifiers.Menu))
			{
				flag2 = true;
			}
			break;
		}
		case VirtualKey.Enter:
		case VirtualKey.Space:
			flag2 = true;
			break;
		}
		if (flag2)
		{
			pEventArgs.Handled = true;
			OnConfirmed();
		}
	}

	private static string GetDefaultCalendarIdentifier()
	{
		return "GregorianCalendar";
	}

	private static DateTimeOffset GetDefaultDate()
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		EnsureCalendar();
		s_spCalendar.SetToNow();
		return s_spCalendar.GetDateTime();
	}

	private static DateTimeOffset GetDefaultMinYear()
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		EnsureCalendar();
		s_spCalendar.SetToNow();
		s_spCalendar.AddYears(-50);
		return s_spCalendar.GetDateTime();
	}

	private static DateTimeOffset GetDefaultMaxYear()
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		EnsureCalendar();
		s_spCalendar.SetToNow();
		s_spCalendar.AddYears(50);
		return s_spCalendar.GetDateTime();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string GetDefaultDayFormat()
	{
		return "day";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string GetDefaultMonthFormat()
	{
		return "{month.full}";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string GetDefaultYearFormat()
	{
		return "year.full";
	}

	private static void EnsureCalendar()
	{
		if (s_spCalendar == null)
		{
			Calendar calendar = new Calendar();
			IReadOnlyList<string> languages = calendar.Languages;
			string clock = calendar.GetClock();
			calendar = (s_spCalendar = new Calendar(languages, "GregorianCalendar", clock));
		}
	}

	protected virtual void OnDayVisibleChanged(bool oldDayVisible, bool newDayVisible)
	{
	}

	protected virtual void OnMonthVisibleChanged(bool oldMonthVisible, bool newMonthVisible)
	{
	}

	protected virtual void OnYearVisibleChanged(bool oldYearVisible, bool newYearVisible)
	{
	}
}
