using System;
using System.Collections.Generic;
using System.Linq;
using DirectUI;
using Uno.Extensions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.System;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class CalendarView : Control
{
	internal class CalendarViewAutomationPeer : CalendarViewBaseItem.CalendarViewBaseItemAutomationPeer
	{
		private const uint BulkChildrenLimit = 20u;

		private bool CanSelectMultipleImpl
		{
			get
			{
				bool result = false;
				UIElement owner = base.Owner;
				CalendarViewSelectionMode calendarViewSelectionMode = CalendarViewSelectionMode.None;
				calendarViewSelectionMode = (owner as CalendarView).SelectionMode;
				if (calendarViewSelectionMode == CalendarViewSelectionMode.Multiple)
				{
					result = true;
				}
				return result;
			}
		}

		private bool IsSelectionRequiredImpl => false;

		private bool IsReadOnlyImpl => true;

		private string ValueImpl
		{
			get
			{
				string text = null;
				UIElement owner = base.Owner;
				uint num = 0u;
				num = (owner as CalendarView).m_tpSelectedDates.Size;
				if (num == 1)
				{
					(owner as CalendarView).CreateDateTimeFormatter("day month.full year", out var ppDateTimeFormatter);
					DateTimeOffset at = (owner as CalendarView).m_tpSelectedDates.GetAt(0u);
					return ppDateTimeFormatter.Format(at);
				}
				(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
				return ppHost.GetHeaderTextOfCurrentScope();
			}
		}

		private RowOrColumnMajor RowOrColumnMajorImpl => RowOrColumnMajor.RowMajor;

		private int ColumnCountImpl
		{
			get
			{
				int result = 0;
				UIElement owner = base.Owner;
				(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
				CalendarPanel panel = ppHost.Panel;
				if (panel != null)
				{
					result = panel.Cols;
				}
				return result;
			}
		}

		private int RowCountImpl
		{
			get
			{
				int result = 0;
				UIElement owner = base.Owner;
				(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
				CalendarPanel panel = ppHost.Panel;
				if (panel != null)
				{
					result = panel.Rows;
				}
				return result;
			}
		}

		internal CalendarViewAutomationPeer(CalendarView owner)
			: base(owner)
		{
		}

		protected override object GetPatternCore(PatternInterface patternInterface)
		{
			object obj = null;
			if (patternInterface == PatternInterface.Table || patternInterface == PatternInterface.Grid || patternInterface == PatternInterface.Value || patternInterface == PatternInterface.Selection)
			{
				return this;
			}
			return base.GetPatternCore(patternInterface);
		}

		protected override string GetClassNameCore()
		{
			return "CalendarView";
		}

		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Calendar;
		}

		protected override IList<AutomationPeer> GetChildrenCore()
		{
			UIElement owner = base.Owner;
			IList<AutomationPeer> childrenCore = base.GetChildrenCore();
			if (childrenCore != null)
			{
				RemoveAPs(childrenCore);
			}
			return childrenCore;
		}

		private void RemoveAPs(IList<AutomationPeer> pAPCollection)
		{
			UIElement owner = base.Owner;
			uint num = 0u;
			num = (uint)pAPCollection.Count;
			for (int num2 = (int)(num - 1); num2 >= 0; num2--)
			{
				AutomationPeer automationPeer = pAPCollection[num2];
				if (automationPeer != null)
				{
					UIElement uIElement = (automationPeer as FrameworkElementAutomationPeer).Owner;
					while (uIElement != null && uIElement != owner)
					{
						double num3 = 1.0;
						num3 = uIElement.Opacity;
						if (num3 == 0.0)
						{
							pAPCollection.RemoveAt(num2);
							break;
						}
						DependencyObject parent = (uIElement as FrameworkElement).Parent;
						uIElement = parent as UIElement;
					}
				}
			}
		}

		private void GetSelectionImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			UIElement owner = base.Owner;
			pReturnValueCount = 0u;
			ppReturnValue = null;
			CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
			if ((owner as CalendarView).DisplayMode != 0)
			{
				return;
			}
			uint num = 0u;
			uint num2 = 0u;
			num = (owner as CalendarView).m_tpSelectedDates.Size;
			if (num == 0)
			{
				return;
			}
			(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
			IVector<AutomationPeer> vector = new TrackerCollection<AutomationPeer>();
			CalendarPanel panel = ppHost.Panel;
			if (panel == null)
			{
				return;
			}
			for (uint num3 = 0u; num3 < num; num3++)
			{
				int num4 = 0;
				DateTimeOffset at = (owner as CalendarView).m_tpSelectedDates.GetAt(num3);
				num4 = ppHost.CalculateOffsetFromMinDate(at);
				DependencyObject dependencyObject = panel.ContainerFromIndex(num4);
				if (dependencyObject != null)
				{
					CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
					AutomationPeer automationPeer = calendarViewBaseItem.GetAutomationPeer();
					vector.Add(automationPeer);
				}
			}
			num2 = (uint)vector.Count;
			if (num2 != 0)
			{
				ppReturnValue = new IRawElementProviderSimple[num2];
				for (uint num5 = 0u; num5 < num2; num5++)
				{
					AutomationPeer peer = vector[(int)num5];
					IRawElementProviderSimple rawElementProviderSimple = ProviderFromPeer(peer);
					ppReturnValue[num5] = rawElementProviderSimple;
				}
			}
			pReturnValueCount = num2;
		}

		private void SetValueImpl(string value)
		{
			throw new NotImplementedException();
		}

		private void GetColumnHeadersImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			pReturnValueCount = 0u;
			ppReturnValue = null;
			UIElement owner = base.Owner;
			CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
			if ((owner as CalendarView).DisplayMode != 0)
			{
				return;
			}
			uint num = 0u;
			Grid templateChild = (owner as CalendarView).GetTemplateChild<Grid>("WeekDayNames");
			if (templateChild != null)
			{
				IList<UIElement> children = templateChild.Children;
				num = (uint)children.Count;
				ppReturnValue = new IRawElementProviderSimple[num];
				for (uint num2 = 0u; num2 < num; num2++)
				{
					UIElement uIElement = children[(int)num2];
					AutomationPeer automationPeer = (uIElement as FrameworkElement).GetAutomationPeer();
					IRawElementProviderSimple rawElementProviderSimple = ProviderFromPeer(automationPeer);
					ppReturnValue[num2] = rawElementProviderSimple;
				}
				pReturnValueCount = num;
			}
		}

		private void GetRowHeadersImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			pReturnValueCount = 0u;
			ppReturnValue = null;
		}

		private void GetItemImpl(int row, int column, out IRawElementProviderSimple ppReturnValue)
		{
			ppReturnValue = null;
			UIElement owner = base.Owner;
			(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
			int num = 0;
			num = ColumnCountImpl;
			int num2 = 0;
			CalendarPanel panel = ppHost.Panel;
			if (panel == null)
			{
				return;
			}
			num2 = panel.FirstVisibleIndex;
			int num3 = num2 + row * num + column;
			if (num2 < num)
			{
				int num4 = 0;
				num4 = panel.StartIndex;
				num3 -= num4;
			}
			if (num3 >= 0)
			{
				DependencyObject dependencyObject = panel.ContainerFromIndex(num3);
				if (dependencyObject != null)
				{
					CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
					AutomationPeer automationPeer = calendarViewBaseItem.GetAutomationPeer();
					IRawElementProviderSimple rawElementProviderSimple = (ppReturnValue = ProviderFromPeer(automationPeer));
				}
			}
		}

		internal void RaiseSelectionEvents(CalendarViewSelectedDatesChangedEventArgs pSelectionChangedEventArgs)
		{
			UIElement owner = base.Owner;
			CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
			if ((owner as CalendarView).DisplayMode != 0)
			{
				return;
			}
			(owner as CalendarView).GetActiveGeneratorHost(out var ppHost);
			CalendarPanel panel = ppHost.Panel;
			if (panel == null)
			{
				return;
			}
			int num = 0;
			uint num2 = 0u;
			num2 = (owner as CalendarView).m_tpSelectedDates.Size;
			uint num3 = 0u;
			uint num4 = 0u;
			IReadOnlyList<DateTimeOffset> addedDates = pSelectionChangedEventArgs.AddedDates;
			num3 = (uint)addedDates.Count;
			IReadOnlyList<DateTimeOffset> removedDates = pSelectionChangedEventArgs.RemovedDates;
			num4 = (uint)removedDates.Count;
			if (num3 == 1 && num2 == 1)
			{
				DateTimeOffset date = addedDates[0];
				num = ppHost.CalculateOffsetFromMinDate(date);
				DependencyObject dependencyObject = panel.ContainerFromIndex(num);
				if (dependencyObject != null)
				{
					CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
					calendarViewBaseItem.GetAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementSelected);
				}
				if (num4 == 1)
				{
					date = removedDates[0];
					num = ppHost.CalculateOffsetFromMinDate(date);
					dependencyObject = panel.ContainerFromIndex(num);
					if (dependencyObject != null)
					{
						CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
						calendarViewBaseItem.GetAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
					}
				}
				return;
			}
			if (num3 + num4 > 20)
			{
				RaiseAutomationEvent(AutomationEvents.SelectionPatternOnInvalidated);
				return;
			}
			uint num5 = 0u;
			for (num5 = 0u; num5 < num3; num5++)
			{
				DateTimeOffset date = addedDates[(int)num5];
				num = ppHost.CalculateOffsetFromMinDate(date);
				DependencyObject dependencyObject = panel.ContainerFromIndex(num);
				if (dependencyObject != null)
				{
					CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
					calendarViewBaseItem.GetAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementAddedToSelection);
				}
			}
			for (num5 = 0u; num5 < num4; num5++)
			{
				DateTimeOffset date = removedDates[(int)num5];
				num = ppHost.CalculateOffsetFromMinDate(date);
				DependencyObject dependencyObject = panel.ContainerFromIndex(num);
				if (dependencyObject != null)
				{
					CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
					calendarViewBaseItem.GetAutomationPeer()?.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
				}
			}
		}
	}

	private const string c_strDisabledForegroundStorage = "SystemControlDisabledBaseMediumLowBrush";

	private const string c_strTodaySelectedInnerBorderBrushStorage = "SystemControlHighlightAltAltHighBrush";

	private const string c_strTodayHoverBorderBrushStorage = "SystemControlHighlightAltBaseMediumLowBrush";

	private const string c_strTodayPressedBorderBrushStorage = "SystemControlHighlightAltBaseMediumBrush";

	private const string c_strTodayBackgroundStorage = "SystemControlHighlightAccentBrush";

	private const string c_strTodayBlackoutBackgroundStorage = "SystemControlHighlightListAccentLowBrush";

	internal Brush m_pDisabledForeground;

	internal Brush m_pTodaySelectedInnerBorderBrush;

	internal Brush m_pTodayHoverBorderBrush;

	internal Brush m_pTodayPressedBorderBrush;

	internal Brush m_pTodayBlackoutBackground;

	private static Calendar _gregorianCalendar;

	private const int DEFAULT_MIN_MAX_DATE_YEAR_OFFSET = 100;

	private const string UIA_FLIPVIEW_PREVIOUS = "UIA_FLIPVIEW_PREVIOUS";

	private const string UIA_FLIPVIEW_NEXT = "UIA_FLIPVIEW_NEXT";

	private const char RTL_CHARACTER_CODE = '與';

	private TrackableDateCollection m_tpSelectedDates;

	private Button m_tpHeaderButton;

	private Button m_tpPreviousButton;

	private Button m_tpNextButton;

	private Grid m_tpViewsGrid;

	private Calendar m_tpCalendar;

	private DateTimeFormatter m_tpMonthYearFormatter;

	private DateTimeFormatter m_tpYearFormatter;

	private CalendarViewGeneratorHost m_tpMonthViewItemHost;

	private CalendarViewGeneratorHost m_tpYearViewItemHost;

	private CalendarViewGeneratorHost m_tpDecadeViewItemHost;

	private ScrollViewer m_tpMonthViewScrollViewer;

	private ScrollViewer m_tpYearViewScrollViewer;

	private ScrollViewer m_tpDecadeViewScrollViewer;

	private DateTimeOffset m_lastDisplayedDate;

	private DateTimeOffset m_today;

	private DateTimeOffset m_maxDate;

	private DateTimeOffset m_minDate;

	private Windows.Globalization.DayOfWeek m_weekDayOfMinDate;

	private CalendarViewTemplateSettings m_tpTemplateSettings;

	private RoutedEventHandler m_epHeaderButtonClickHandler;

	private RoutedEventHandler m_epPreviousButtonClickHandler;

	private RoutedEventHandler m_epNextButtonClickHandler;

	private KeyEventHandler m_epMonthViewScrollViewerKeyDownEventHandler;

	private KeyEventHandler m_epYearViewScrollViewerKeyDownEventHandler;

	private KeyEventHandler m_epDecadeViewScrollViewerKeyDownEventHandler;

	private const int s_minNumberOfWeeks = 2;

	private const int s_maxNumberOfWeeks = 8;

	private const int s_defaultNumberOfWeeks = 6;

	private const int s_numberOfDaysInWeek = 7;

	private int m_colsInYearDecadeView;

	private int m_rowsInYearDecadeView;

	private int m_monthViewStartIndex;

	private List<string> m_dayOfWeekNames = new List<string>();

	private List<string> m_dayOfWeekNamesFull = new List<string>();

	private IEnumerable<string> m_tpCalendarLanguages;

	private VectorChangedEventHandler<DateTimeOffset> m_epSelectedDatesChangedHandler;

	private WeakReference<KeyRoutedEventArgs> m_wrKeyDownEventArgsFromCalendarItem = new WeakReference<KeyRoutedEventArgs>(null);

	private FocusState m_focusStateAfterDisplayModeChanged;

	private DateComparer m_dateComparer;

	private CalendarViewHeaderAutomationPeer m_currentHeaderPeer;

	private CalendarViewHeaderAutomationPeer m_previousHeaderPeer;

	private bool m_dateSourceChanged;

	private bool m_calendarChanged;

	private bool m_itemHostsConnected;

	private bool m_areDirectManipulationStateChangeHandlersHooked;

	private bool m_isSelectedDatesChangingInternally;

	private bool m_focusItemAfterDisplayModeChanged;

	private bool m_isMultipleEraCalendar;

	private bool m_isSetDisplayDateRequested;

	private bool m_areYearDecadeViewDimensionsSet;

	private bool m_isNavigationButtonClicked;

	private const string c_samoaTimeZone = "Samoa Standard Time";

	private const string TIME_ZONE_ID_INVALID = null;

	internal Brush m_pFocusBorderBrush => FocusBorderBrush;

	internal Brush m_pSelectedHoverBorderBrush => SelectedHoverBorderBrush;

	internal Brush m_pSelectedPressedBorderBrush => SelectedPressedBorderBrush;

	internal Brush m_pSelectedBorderBrush => SelectedBorderBrush;

	internal Brush m_pHoverBorderBrush => HoverBorderBrush;

	internal Brush m_pPressedBorderBrush => PressedBorderBrush;

	internal Brush m_pCalendarItemBorderBrush => CalendarItemBorderBrush;

	internal Brush m_pOutOfScopeBackground => OutOfScopeBackground;

	internal Brush m_pCalendarItemBackground => CalendarItemBackground;

	internal Brush m_pPressedForeground => PressedForeground;

	internal Brush m_pTodayForeground => TodayForeground;

	internal Brush m_pBlackoutForeground => BlackoutForeground;

	internal Brush m_pSelectedForeground => SelectedForeground;

	internal Brush m_pOutOfScopeForeground => OutOfScopeForeground;

	internal Brush m_pCalendarItemForeground => CalendarItemForeground;

	internal FontFamily m_pDayItemFontFamily => DayItemFontFamily;

	internal float m_dayItemFontSize => (float)DayItemFontSize;

	internal FontStyle m_dayItemFontStyle => DayItemFontStyle;

	internal FontWeight m_dayItemFontWeight => DayItemFontWeight;

	internal FontWeight m_todayFontWeight => TodayFontWeight;

	internal FontFamily m_pFirstOfMonthLabelFontFamily => FirstOfMonthLabelFontFamily;

	internal float m_firstOfMonthLabelFontSize => (float)FirstOfMonthLabelFontSize;

	internal FontStyle m_firstOfMonthLabelFontStyle => FirstOfMonthLabelFontStyle;

	internal FontWeight m_firstOfMonthLabelFontWeight => FirstOfMonthLabelFontWeight;

	internal FontFamily m_pMonthYearItemFontFamily => MonthYearItemFontFamily;

	internal float m_monthYearItemFontSize => (float)MonthYearItemFontSize;

	internal FontStyle m_monthYearItemFontStyle => MonthYearItemFontStyle;

	internal FontWeight m_monthYearItemFontWeight => MonthYearItemFontWeight;

	internal FontFamily m_pFirstOfYearDecadeLabelFontFamily => FirstOfYearDecadeLabelFontFamily;

	internal float m_firstOfYearDecadeLabelFontSize => (float)FirstOfYearDecadeLabelFontSize;

	internal FontStyle m_firstOfYearDecadeLabelFontStyle => FirstOfYearDecadeLabelFontStyle;

	internal FontWeight m_firstOfYearDecadeLabelFontWeight => FirstOfYearDecadeLabelFontWeight;

	internal HorizontalAlignment m_horizontalDayItemAlignment => HorizontalDayItemAlignment;

	internal VerticalAlignment m_verticalDayItemAlignment => VerticalDayItemAlignment;

	internal HorizontalAlignment m_horizontalFirstOfMonthLabelAlignment => HorizontalFirstOfMonthLabelAlignment;

	internal VerticalAlignment m_verticalFirstOfMonthLabelAlignment => VerticalFirstOfMonthLabelAlignment;

	internal Thickness m_calendarItemBorderThickness => CalendarItemBorderThickness;

	internal Brush m_pSelectedBackground => SelectedBackground;

	internal Brush m_pTodayBackground => TodayBackground ?? (base.Resources["SystemControlHighlightAccentBrush"] as Brush);

	internal Brush m_pTodaySelectedBackground => TodaySelectedBackground;

	internal CornerRadius m_calendarItemCornerRadius => CalendarItemCornerRadius;

	internal CornerRadius m_dayItemCornerRadius => DayItemCornerRadius;

	internal DateTimeOffset Today => m_today;

	internal Calendar Calendar => m_tpCalendar;

	internal DateComparer DateComparer => m_dateComparer;

	internal bool IsMultipleEraCalendar => m_isMultipleEraCalendar;

	public HorizontalAlignment HorizontalFirstOfMonthLabelAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalFirstOfMonthLabelAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalFirstOfMonthLabelAlignmentProperty, value);
		}
	}

	public HorizontalAlignment HorizontalDayItemAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalDayItemAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalDayItemAlignmentProperty, value);
		}
	}

	public Brush FocusBorderBrush
	{
		get
		{
			return (Brush)GetValue(FocusBorderBrushProperty);
		}
		set
		{
			SetValue(FocusBorderBrushProperty, value);
		}
	}

	public FontWeight FirstOfYearDecadeLabelFontWeight
	{
		get
		{
			return (FontWeight)GetValue(FirstOfYearDecadeLabelFontWeightProperty);
		}
		set
		{
			SetValue(FirstOfYearDecadeLabelFontWeightProperty, value);
		}
	}

	public FontStyle FirstOfYearDecadeLabelFontStyle
	{
		get
		{
			return (FontStyle)GetValue(FirstOfYearDecadeLabelFontStyleProperty);
		}
		set
		{
			SetValue(FirstOfYearDecadeLabelFontStyleProperty, value);
		}
	}

	public FontFamily MonthYearItemFontFamily
	{
		get
		{
			return (FontFamily)GetValue(MonthYearItemFontFamilyProperty);
		}
		set
		{
			SetValue(MonthYearItemFontFamilyProperty, value);
		}
	}

	public FontFamily FirstOfYearDecadeLabelFontFamily
	{
		get
		{
			return (FontFamily)GetValue(FirstOfYearDecadeLabelFontFamilyProperty);
		}
		set
		{
			SetValue(FirstOfYearDecadeLabelFontFamilyProperty, value);
		}
	}

	public FontWeight FirstOfMonthLabelFontWeight
	{
		get
		{
			return (FontWeight)GetValue(FirstOfMonthLabelFontWeightProperty);
		}
		set
		{
			SetValue(FirstOfMonthLabelFontWeightProperty, value);
		}
	}

	public FontStyle FirstOfMonthLabelFontStyle
	{
		get
		{
			return (FontStyle)GetValue(FirstOfMonthLabelFontStyleProperty);
		}
		set
		{
			SetValue(FirstOfMonthLabelFontStyleProperty, value);
		}
	}

	public double FirstOfMonthLabelFontSize
	{
		get
		{
			return (double)GetValue(FirstOfMonthLabelFontSizeProperty);
		}
		set
		{
			SetValue(FirstOfMonthLabelFontSizeProperty, value);
		}
	}

	public FontFamily FirstOfMonthLabelFontFamily
	{
		get
		{
			return (FontFamily)GetValue(FirstOfMonthLabelFontFamilyProperty);
		}
		set
		{
			SetValue(FirstOfMonthLabelFontFamilyProperty, value);
		}
	}

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

	public Brush BlackoutForeground
	{
		get
		{
			return (Brush)GetValue(BlackoutForegroundProperty);
		}
		set
		{
			SetValue(BlackoutForegroundProperty, value);
		}
	}

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

	public FontWeight DayItemFontWeight
	{
		get
		{
			return (FontWeight)GetValue(DayItemFontWeightProperty);
		}
		set
		{
			SetValue(DayItemFontWeightProperty, value);
		}
	}

	public FontStyle DayItemFontStyle
	{
		get
		{
			return (FontStyle)GetValue(DayItemFontStyleProperty);
		}
		set
		{
			SetValue(DayItemFontStyleProperty, value);
		}
	}

	public double DayItemFontSize
	{
		get
		{
			return (double)GetValue(DayItemFontSizeProperty);
		}
		set
		{
			SetValue(DayItemFontSizeProperty, value);
		}
	}

	public FontFamily DayItemFontFamily
	{
		get
		{
			return (FontFamily)GetValue(DayItemFontFamilyProperty);
		}
		set
		{
			SetValue(DayItemFontFamilyProperty, value);
		}
	}

	public Brush SelectedPressedBorderBrush
	{
		get
		{
			return (Brush)GetValue(SelectedPressedBorderBrushProperty);
		}
		set
		{
			SetValue(SelectedPressedBorderBrushProperty, value);
		}
	}

	public Brush CalendarItemForeground
	{
		get
		{
			return (Brush)GetValue(CalendarItemForegroundProperty);
		}
		set
		{
			SetValue(CalendarItemForegroundProperty, value);
		}
	}

	public Thickness CalendarItemBorderThickness
	{
		get
		{
			return (Thickness)GetValue(CalendarItemBorderThicknessProperty);
		}
		set
		{
			SetValue(CalendarItemBorderThicknessProperty, value);
		}
	}

	public Brush CalendarItemBorderBrush
	{
		get
		{
			return (Brush)GetValue(CalendarItemBorderBrushProperty);
		}
		set
		{
			SetValue(CalendarItemBorderBrushProperty, value);
		}
	}

	public Brush CalendarItemBackground
	{
		get
		{
			return (Brush)GetValue(CalendarItemBackgroundProperty);
		}
		set
		{
			SetValue(CalendarItemBackgroundProperty, value);
		}
	}

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

	public Brush HoverBorderBrush
	{
		get
		{
			return (Brush)GetValue(HoverBorderBrushProperty);
		}
		set
		{
			SetValue(HoverBorderBrushProperty, value);
		}
	}

	public Brush PressedBorderBrush
	{
		get
		{
			return (Brush)GetValue(PressedBorderBrushProperty);
		}
		set
		{
			SetValue(PressedBorderBrushProperty, value);
		}
	}

	public VerticalAlignment VerticalDayItemAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalDayItemAlignmentProperty);
		}
		set
		{
			SetValue(VerticalDayItemAlignmentProperty, value);
		}
	}

	public Brush TodayForeground
	{
		get
		{
			return (Brush)GetValue(TodayForegroundProperty);
		}
		set
		{
			SetValue(TodayForegroundProperty, value);
		}
	}

	public FontWeight TodayFontWeight
	{
		get
		{
			return (FontWeight)GetValue(TodayFontWeightProperty);
		}
		set
		{
			SetValue(TodayFontWeightProperty, value);
		}
	}

	public CalendarViewSelectionMode SelectionMode
	{
		get
		{
			return (CalendarViewSelectionMode)GetValue(SelectionModeProperty);
		}
		set
		{
			SetValue(SelectionModeProperty, value);
		}
	}

	public Style CalendarViewDayItemStyle
	{
		get
		{
			return (Style)GetValue(CalendarViewDayItemStyleProperty);
		}
		set
		{
			SetValue(CalendarViewDayItemStyleProperty, value);
		}
	}

	public Brush SelectedHoverBorderBrush
	{
		get
		{
			return (Brush)GetValue(SelectedHoverBorderBrushProperty);
		}
		set
		{
			SetValue(SelectedHoverBorderBrushProperty, value);
		}
	}

	public Brush SelectedForeground
	{
		get
		{
			return (Brush)GetValue(SelectedForegroundProperty);
		}
		set
		{
			SetValue(SelectedForegroundProperty, value);
		}
	}

	public Brush SelectedBorderBrush
	{
		get
		{
			return (Brush)GetValue(SelectedBorderBrushProperty);
		}
		set
		{
			SetValue(SelectedBorderBrushProperty, value);
		}
	}

	public Brush PressedForeground
	{
		get
		{
			return (Brush)GetValue(PressedForegroundProperty);
		}
		set
		{
			SetValue(PressedForegroundProperty, value);
		}
	}

	public VerticalAlignment VerticalFirstOfMonthLabelAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalFirstOfMonthLabelAlignmentProperty);
		}
		set
		{
			SetValue(VerticalFirstOfMonthLabelAlignmentProperty, value);
		}
	}

	public Brush OutOfScopeForeground
	{
		get
		{
			return (Brush)GetValue(OutOfScopeForegroundProperty);
		}
		set
		{
			SetValue(OutOfScopeForegroundProperty, value);
		}
	}

	public Brush OutOfScopeBackground
	{
		get
		{
			return (Brush)GetValue(OutOfScopeBackgroundProperty);
		}
		set
		{
			SetValue(OutOfScopeBackgroundProperty, value);
		}
	}

	public int NumberOfWeeksInView
	{
		get
		{
			return (int)GetValue(NumberOfWeeksInViewProperty);
		}
		set
		{
			SetValue(NumberOfWeeksInViewProperty, value);
		}
	}

	public FontWeight MonthYearItemFontWeight
	{
		get
		{
			return (FontWeight)GetValue(MonthYearItemFontWeightProperty);
		}
		set
		{
			SetValue(MonthYearItemFontWeightProperty, value);
		}
	}

	public FontStyle MonthYearItemFontStyle
	{
		get
		{
			return (FontStyle)GetValue(MonthYearItemFontStyleProperty);
		}
		set
		{
			SetValue(MonthYearItemFontStyleProperty, value);
		}
	}

	public double MonthYearItemFontSize
	{
		get
		{
			return (double)GetValue(MonthYearItemFontSizeProperty);
		}
		set
		{
			SetValue(MonthYearItemFontSizeProperty, value);
		}
	}

	public double FirstOfYearDecadeLabelFontSize
	{
		get
		{
			return (double)GetValue(FirstOfYearDecadeLabelFontSizeProperty);
		}
		set
		{
			SetValue(FirstOfYearDecadeLabelFontSizeProperty, value);
		}
	}

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

	public IList<DateTimeOffset> SelectedDates
	{
		get
		{
			return (IList<DateTimeOffset>)GetValue(SelectedDatesProperty);
		}
		private set
		{
			SetValue(SelectedDatesProperty, value);
		}
	}

	public CalendarViewTemplateSettings TemplateSettings
	{
		get
		{
			return (CalendarViewTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		private set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public CornerRadius DayItemCornerRadius
	{
		get
		{
			return (CornerRadius)GetValue(DayItemCornerRadiusProperty);
		}
		set
		{
			SetValue(DayItemCornerRadiusProperty, value);
		}
	}

	public CornerRadius CalendarItemCornerRadius
	{
		get
		{
			return (CornerRadius)GetValue(CalendarItemCornerRadiusProperty);
		}
		set
		{
			SetValue(CalendarItemCornerRadiusProperty, value);
		}
	}

	public Brush SelectedBackground
	{
		get
		{
			return (Brush)GetValue(SelectedBackgroundProperty);
		}
		set
		{
			SetValue(SelectedBackgroundProperty, value);
		}
	}

	public Brush TodayBackground
	{
		get
		{
			return (Brush)GetValue(TodayBackgroundProperty);
		}
		set
		{
			SetValue(TodayBackgroundProperty, value);
		}
	}

	public Brush TodaySelectedBackground
	{
		get
		{
			return (Brush)GetValue(TodaySelectedBackgroundProperty);
		}
		set
		{
			SetValue(TodaySelectedBackgroundProperty, value);
		}
	}

	public static DependencyProperty BlackoutForegroundProperty { get; } = DependencyProperty.Register("BlackoutForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CalendarIdentifierProperty { get; } = DependencyProperty.Register("CalendarIdentifier", typeof(string), typeof(CalendarView), new FrameworkPropertyMetadata("GregorianCalendar"));


	public static DependencyProperty CalendarItemBackgroundProperty { get; } = DependencyProperty.Register("CalendarItemBackground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CalendarItemBorderBrushProperty { get; } = DependencyProperty.Register("CalendarItemBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CalendarItemBorderThicknessProperty { get; } = DependencyProperty.Register("CalendarItemBorderThickness", typeof(Thickness), typeof(CalendarView), new FrameworkPropertyMetadata(Thickness.Empty));


	public static DependencyProperty CalendarItemForegroundProperty { get; } = DependencyProperty.Register("CalendarItemForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty CalendarViewDayItemStyleProperty { get; } = DependencyProperty.Register("CalendarViewDayItemStyle", typeof(Style), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty DayItemFontFamilyProperty { get; } = DependencyProperty.Register("DayItemFontFamily", typeof(FontFamily), typeof(CalendarView), new FrameworkPropertyMetadata((FontFamily)"XamlAutoFontFamily"));


	public static DependencyProperty DayItemFontSizeProperty { get; } = DependencyProperty.Register("DayItemFontSize", typeof(double), typeof(CalendarView), new FrameworkPropertyMetadata(20.0));


	public static DependencyProperty DayItemFontStyleProperty { get; } = DependencyProperty.Register("DayItemFontStyle", typeof(FontStyle), typeof(CalendarView), new FrameworkPropertyMetadata(FontStyle.Normal));


	public static DependencyProperty DayItemFontWeightProperty { get; } = DependencyProperty.Register("DayItemFontWeight", typeof(FontWeight), typeof(CalendarView), new FrameworkPropertyMetadata(FontWeights.Normal));


	public static DependencyProperty DayOfWeekFormatProperty { get; } = DependencyProperty.Register("DayOfWeekFormat", typeof(string), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty DisplayModeProperty { get; } = DependencyProperty.Register("DisplayMode", typeof(CalendarViewDisplayMode), typeof(CalendarView), new FrameworkPropertyMetadata(CalendarViewDisplayMode.Month));


	public static DependencyProperty FirstDayOfWeekProperty { get; } = DependencyProperty.Register("FirstDayOfWeek", typeof(Windows.Globalization.DayOfWeek), typeof(CalendarView), new FrameworkPropertyMetadata(Windows.Globalization.DayOfWeek.Sunday));


	public static DependencyProperty FirstOfMonthLabelFontFamilyProperty { get; } = DependencyProperty.Register("FirstOfMonthLabelFontFamily", typeof(FontFamily), typeof(CalendarView), new FrameworkPropertyMetadata((FontFamily)"XamlAutoFontFamily"));


	public static DependencyProperty FirstOfMonthLabelFontSizeProperty { get; } = DependencyProperty.Register("FirstOfMonthLabelFontSize", typeof(double), typeof(CalendarView), new FrameworkPropertyMetadata(12.0));


	public static DependencyProperty FirstOfMonthLabelFontStyleProperty { get; } = DependencyProperty.Register("FirstOfMonthLabelFontStyle", typeof(FontStyle), typeof(CalendarView), new FrameworkPropertyMetadata(FontStyle.Normal));


	public static DependencyProperty FirstOfMonthLabelFontWeightProperty { get; } = DependencyProperty.Register("FirstOfMonthLabelFontWeight", typeof(FontWeight), typeof(CalendarView), new FrameworkPropertyMetadata(FontWeights.Normal));


	public static DependencyProperty FirstOfYearDecadeLabelFontFamilyProperty { get; } = DependencyProperty.Register("FirstOfYearDecadeLabelFontFamily", typeof(FontFamily), typeof(CalendarView), new FrameworkPropertyMetadata((FontFamily)"XamlAutoFontFamily"));


	public static DependencyProperty FirstOfYearDecadeLabelFontSizeProperty { get; } = DependencyProperty.Register("FirstOfYearDecadeLabelFontSize", typeof(double), typeof(CalendarView), new FrameworkPropertyMetadata(12.0));


	public static DependencyProperty FirstOfYearDecadeLabelFontStyleProperty { get; } = DependencyProperty.Register("FirstOfYearDecadeLabelFontStyle", typeof(FontStyle), typeof(CalendarView), new FrameworkPropertyMetadata(FontStyle.Normal));


	public static DependencyProperty FirstOfYearDecadeLabelFontWeightProperty { get; } = DependencyProperty.Register("FirstOfYearDecadeLabelFontWeight", typeof(FontWeight), typeof(CalendarView), new FrameworkPropertyMetadata(FontWeights.Normal));


	public static DependencyProperty FocusBorderBrushProperty { get; } = DependencyProperty.Register("FocusBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty HorizontalDayItemAlignmentProperty { get; } = DependencyProperty.Register("HorizontalDayItemAlignment", typeof(HorizontalAlignment), typeof(CalendarView), new FrameworkPropertyMetadata(HorizontalAlignment.Center));


	public static DependencyProperty HorizontalFirstOfMonthLabelAlignmentProperty { get; } = DependencyProperty.Register("HorizontalFirstOfMonthLabelAlignment", typeof(HorizontalAlignment), typeof(CalendarView), new FrameworkPropertyMetadata(HorizontalAlignment.Center));


	public static DependencyProperty HoverBorderBrushProperty { get; } = DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty IsGroupLabelVisibleProperty { get; } = DependencyProperty.Register("IsGroupLabelVisible", typeof(bool), typeof(CalendarView), new FrameworkPropertyMetadata(false));


	public static DependencyProperty IsOutOfScopeEnabledProperty { get; } = DependencyProperty.Register("IsOutOfScopeEnabled", typeof(bool), typeof(CalendarView), new FrameworkPropertyMetadata(true));


	public static DependencyProperty IsTodayHighlightedProperty { get; } = DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(CalendarView), new FrameworkPropertyMetadata(true));


	public static DependencyProperty MaxDateProperty { get; } = DependencyProperty.Register("MaxDate", typeof(DateTimeOffset), typeof(CalendarView), new FrameworkPropertyMetadata(GetDefaultMaxDate()));


	public static DependencyProperty MinDateProperty { get; } = DependencyProperty.Register("MinDate", typeof(DateTimeOffset), typeof(CalendarView), new FrameworkPropertyMetadata(GetDefaultMinDate()));


	public static DependencyProperty MonthYearItemFontFamilyProperty { get; } = DependencyProperty.Register("MonthYearItemFontFamily", typeof(FontFamily), typeof(CalendarView), new FrameworkPropertyMetadata((FontFamily)"XamlAutoFontFamily"));


	public static DependencyProperty MonthYearItemFontSizeProperty { get; } = DependencyProperty.Register("MonthYearItemFontSize", typeof(double), typeof(CalendarView), new FrameworkPropertyMetadata(20.0));


	public static DependencyProperty MonthYearItemFontStyleProperty { get; } = DependencyProperty.Register("MonthYearItemFontStyle", typeof(FontStyle), typeof(CalendarView), new FrameworkPropertyMetadata(FontStyle.Normal));


	public static DependencyProperty MonthYearItemFontWeightProperty { get; } = DependencyProperty.Register("MonthYearItemFontWeight", typeof(FontWeight), typeof(CalendarView), new FrameworkPropertyMetadata(FontWeights.Normal));


	public static DependencyProperty NumberOfWeeksInViewProperty { get; } = DependencyProperty.Register("NumberOfWeeksInView", typeof(int), typeof(CalendarView), new FrameworkPropertyMetadata(6));


	public static DependencyProperty OutOfScopeBackgroundProperty { get; } = DependencyProperty.Register("OutOfScopeBackground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty OutOfScopeForegroundProperty { get; } = DependencyProperty.Register("OutOfScopeForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty PressedBorderBrushProperty { get; } = DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty PressedForegroundProperty { get; } = DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedBorderBrushProperty { get; } = DependencyProperty.Register("SelectedBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedDatesProperty { get; } = DependencyProperty.Register("SelectedDates", typeof(IList<DateTimeOffset>), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedForegroundProperty { get; } = DependencyProperty.Register("SelectedForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedHoverBorderBrushProperty { get; } = DependencyProperty.Register("SelectedHoverBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectedPressedBorderBrushProperty { get; } = DependencyProperty.Register("SelectedPressedBorderBrush", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty SelectionModeProperty { get; } = DependencyProperty.Register("SelectionMode", typeof(CalendarViewSelectionMode), typeof(CalendarView), new FrameworkPropertyMetadata(CalendarViewSelectionMode.Single));


	public static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(CalendarViewTemplateSettings), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TodayFontWeightProperty { get; } = DependencyProperty.Register("TodayFontWeight", typeof(FontWeight), typeof(CalendarView), new FrameworkPropertyMetadata(FontWeights.SemiBold));


	public static DependencyProperty TodayForegroundProperty { get; } = DependencyProperty.Register("TodayForeground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty VerticalDayItemAlignmentProperty { get; } = DependencyProperty.Register("VerticalDayItemAlignment", typeof(VerticalAlignment), typeof(CalendarView), new FrameworkPropertyMetadata(VerticalAlignment.Center));


	public static DependencyProperty VerticalFirstOfMonthLabelAlignmentProperty { get; } = DependencyProperty.Register("VerticalFirstOfMonthLabelAlignment", typeof(VerticalAlignment), typeof(CalendarView), new FrameworkPropertyMetadata(VerticalAlignment.Top));


	public static DependencyProperty DayItemCornerRadiusProperty { get; } = DependencyProperty.Register("DayItemCornerRadius", typeof(CornerRadius), typeof(CalendarView), new FrameworkPropertyMetadata(CornerRadius.None));


	public static DependencyProperty CalendarItemCornerRadiusProperty { get; } = DependencyProperty.Register("CalendarItemCornerRadius", typeof(CornerRadius), typeof(CalendarView), new FrameworkPropertyMetadata(CornerRadius.None));


	public static DependencyProperty SelectedBackgroundProperty { get; } = DependencyProperty.Register("SelectedBackground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TodayBackgroundProperty { get; } = DependencyProperty.Register("TodayBackground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TodaySelectedBackgroundProperty { get; } = DependencyProperty.Register("TodaySelectedBackground", typeof(Brush), typeof(CalendarView), new FrameworkPropertyMetadata((object)null));


	public event TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> CalendarViewDayItemChanging;

	public event TypedEventHandler<CalendarView, CalendarViewSelectedDatesChangedEventArgs> SelectedDatesChanged;

	internal void SetKeyDownEventArgsFromCalendarItem(KeyRoutedEventArgs pArgs)
	{
		m_wrKeyDownEventArgsFromCalendarItem.SetTarget(pArgs);
	}

	private static Calendar GetOrCreateGregorianCalendar()
	{
		if (_gregorianCalendar == null)
		{
			Calendar calendar = new Calendar();
			_gregorianCalendar = new Calendar(calendar.Languages, "GregorianCalendar", calendar.GetClock());
		}
		return _gregorianCalendar;
	}

	private static DateTimeOffset ClampDate(DateTimeOffset date, DateTimeOffset minDate, DateTimeOffset maxDate)
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

	private static DateTimeOffset GetDefaultMaxDate()
	{
		Calendar orCreateGregorianCalendar = GetOrCreateGregorianCalendar();
		orCreateGregorianCalendar.SetToMin();
		DateTimeOffset dateTime = orCreateGregorianCalendar.GetDateTime();
		orCreateGregorianCalendar.SetToMax();
		DateTimeOffset dateTime2 = orCreateGregorianCalendar.GetDateTime();
		orCreateGregorianCalendar.SetToday();
		orCreateGregorianCalendar.AddYears(100);
		orCreateGregorianCalendar.Month = orCreateGregorianCalendar.LastMonthInThisYear;
		orCreateGregorianCalendar.Day = orCreateGregorianCalendar.LastDayInThisMonth;
		DateTimeOffset dateTime3 = orCreateGregorianCalendar.GetDateTime();
		return ClampDate(dateTime3, dateTime, dateTime2);
	}

	private static DateTimeOffset GetDefaultMinDate()
	{
		Calendar orCreateGregorianCalendar = GetOrCreateGregorianCalendar();
		orCreateGregorianCalendar.SetToMin();
		DateTimeOffset dateTime = orCreateGregorianCalendar.GetDateTime();
		orCreateGregorianCalendar.SetToMax();
		DateTimeOffset dateTime2 = orCreateGregorianCalendar.GetDateTime();
		orCreateGregorianCalendar.SetToday();
		orCreateGregorianCalendar.AddYears(-100);
		orCreateGregorianCalendar.Month = orCreateGregorianCalendar.FirstMonthInThisYear;
		orCreateGregorianCalendar.Day = orCreateGregorianCalendar.FirstDayInThisMonth;
		DateTimeOffset dateTime3 = orCreateGregorianCalendar.GetDateTime();
		return ClampDate(dateTime3, dateTime, dateTime2);
	}

	internal void GetCalendarViewDayItemChangingEventSourceNoRef(out TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> pEventSource)
	{
		pEventSource = this.CalendarViewDayItemChanging;
	}

	private void GetSelectedDatesChangedEventSourceNoRef(out TypedEventHandler<CalendarView, CalendarViewSelectedDatesChangedEventArgs> ppEventSource)
	{
		ppEventSource = this.SelectedDatesChanged;
	}

	public CalendarView()
	{
		m_pDisabledForeground = base.Resources["SystemControlDisabledBaseMediumLowBrush"] as Brush;
		m_pTodaySelectedInnerBorderBrush = base.Resources["SystemControlHighlightAltAltHighBrush"] as Brush;
		m_pTodayHoverBorderBrush = base.Resources["SystemControlHighlightAltBaseMediumLowBrush"] as Brush;
		m_pTodayPressedBorderBrush = base.Resources["SystemControlHighlightAltBaseMediumBrush"] as Brush;
		m_pTodayBlackoutBackground = base.Resources["SystemControlHighlightListAccentLowBrush"] as Brush;
		m_dateSourceChanged = true;
		m_calendarChanged = false;
		m_itemHostsConnected = false;
		m_areYearDecadeViewDimensionsSet = false;
		m_colsInYearDecadeView = 4;
		m_rowsInYearDecadeView = 4;
		m_monthViewStartIndex = 0;
		m_weekDayOfMinDate = Windows.Globalization.DayOfWeek.Sunday;
		m_isSelectedDatesChangingInternally = false;
		m_focusItemAfterDisplayModeChanged = false;
		m_focusStateAfterDisplayModeChanged = FocusState.Programmatic;
		m_isMultipleEraCalendar = false;
		m_areDirectManipulationStateChangeHandlersHooked = false;
		m_isSetDisplayDateRequested = true;
		m_isNavigationButtonClicked = false;
		m_today = default(DateTimeOffset);
		m_maxDate = default(DateTimeOffset);
		m_minDate = default(DateTimeOffset);
		m_lastDisplayedDate = default(DateTimeOffset);
		PrepareState();
		base.DefaultStyleKey = typeof(CalendarView);
	}

	~CalendarView()
	{
		m_tpSelectedDates?.SetCollectionChangingCallback(null);
	}

	private protected override void OnLoaded()
	{
		base.OnLoaded();
		AttachButtonClickedEvents();
		AttachScrollViewerKeyDownEvents();
	}

	private protected override void OnUnloaded()
	{
		base.OnUnloaded();
		DetachButtonClickedEvents();
		DetachScrollViewerKeyDownEvents();
	}

	private void PrepareState()
	{
		m_dateComparer = new DateComparer();
		TrackableDateCollection trackableDateCollection = new TrackableDateCollection();
		if (m_epSelectedDatesChangedHandler == null)
		{
			m_epSelectedDatesChangedHandler = delegate(IObservableVector<DateTimeOffset> pSender, IVectorChangedEventArgs pArgs)
			{
				OnSelectedDatesChanged(pSender, pArgs);
			};
		}
		trackableDateCollection.VectorChanged += m_epSelectedDatesChangedHandler;
		trackableDateCollection.SetCollectionChangingCallback(delegate(TrackableDateCollection.CollectionChanging action, DateTimeOffset addingDate)
		{
			OnSelectedDatesChanging(action, addingDate);
		});
		m_tpSelectedDates = trackableDateCollection;
		SelectedDates = trackableDateCollection;
		CalendarViewGeneratorMonthViewHost calendarViewGeneratorMonthViewHost = (CalendarViewGeneratorMonthViewHost)(m_tpMonthViewItemHost = new CalendarViewGeneratorMonthViewHost());
		m_tpMonthViewItemHost.Owner = this;
		CalendarViewGeneratorYearViewHost calendarViewGeneratorYearViewHost = (CalendarViewGeneratorYearViewHost)(m_tpYearViewItemHost = new CalendarViewGeneratorYearViewHost());
		m_tpYearViewItemHost.Owner = this;
		CalendarViewGeneratorDecadeViewHost calendarViewGeneratorDecadeViewHost = (CalendarViewGeneratorDecadeViewHost)(m_tpDecadeViewItemHost = new CalendarViewGeneratorDecadeViewHost());
		m_tpDecadeViewItemHost.Owner = this;
		CreateCalendarLanguages();
		CreateCalendarAndMonthYearFormatter();
		CalendarViewTemplateSettings calendarViewTemplateSettings = new CalendarViewTemplateSettings();
		calendarViewTemplateSettings.HasMoreViews = true;
		TemplateSettings = calendarViewTemplateSettings;
		m_tpTemplateSettings = calendarViewTemplateSettings;
	}

	private void OnAlignmentChanged(DependencyPropertyChangedEventArgs args)
	{
		bool flag = false;
		bool flag2 = false;
		DependencyProperty property = args.Property;
		if (property != null)
		{
			if (property != Control.HorizontalContentAlignmentProperty)
			{
				DependencyProperty dependencyProperty = property;
				if (dependencyProperty != FrameworkElement.HorizontalAlignmentProperty)
				{
					DependencyProperty dependencyProperty2 = property;
					if (dependencyProperty2 != Control.VerticalContentAlignmentProperty)
					{
						DependencyProperty dependencyProperty3 = property;
						if (dependencyProperty3 != FrameworkElement.VerticalAlignmentProperty)
						{
							goto IL_0076;
						}
					}
					flag = (VerticalAlignment)args.OldValue == VerticalAlignment.Stretch;
					flag2 = (VerticalAlignment)args.NewValue == VerticalAlignment.Stretch;
					goto IL_0076;
				}
			}
			flag = (HorizontalAlignment)args.OldValue == HorizontalAlignment.Stretch;
			flag2 = (HorizontalAlignment)args.NewValue == HorizontalAlignment.Stretch;
		}
		goto IL_0076;
		IL_0076:
		if (flag != flag2)
		{
			ForeachHost(delegate(CalendarViewGeneratorHost pHost)
			{
				pHost.Panel?.InvalidateMeasure();
			});
		}
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		DependencyProperty property = args.Property;
		if (property == null)
		{
			return;
		}
		if (property != Control.HorizontalContentAlignmentProperty)
		{
			DependencyProperty dependencyProperty = property;
			if (dependencyProperty != Control.VerticalContentAlignmentProperty)
			{
				DependencyProperty dependencyProperty2 = property;
				if (dependencyProperty2 != FrameworkElement.HorizontalAlignmentProperty)
				{
					DependencyProperty dependencyProperty3 = property;
					if (dependencyProperty3 != FrameworkElement.VerticalAlignmentProperty)
					{
						DependencyProperty dependencyProperty4 = property;
						if (dependencyProperty4 != MinDateProperty)
						{
							DependencyProperty dependencyProperty5 = property;
							if (dependencyProperty5 != MaxDateProperty)
							{
								DependencyProperty dependencyProperty6 = property;
								if (dependencyProperty6 == FrameworkElement.LanguageProperty)
								{
									CreateCalendarLanguages();
								}
								else
								{
									DependencyProperty dependencyProperty7 = property;
									if (dependencyProperty7 != CalendarIdentifierProperty)
									{
										DependencyProperty dependencyProperty8 = property;
										if (dependencyProperty8 == NumberOfWeeksInViewProperty)
										{
											int num = 0;
											num = (int)args.NewValue;
											if (num < 2 || num > 8)
											{
												throw new ArgumentOutOfRangeException("ERROR_CALENDAR_NUMBER_OF_WEEKS_OUTOFRANGE");
											}
											if (m_tpMonthViewItemHost.Panel != null)
											{
												m_tpMonthViewItemHost.Panel.SetSuggestedDimension(7, num);
											}
											return;
										}
										DependencyProperty dependencyProperty9 = property;
										if (dependencyProperty9 == DayOfWeekFormatProperty)
										{
											FormatWeekDayNames();
										}
										else
										{
											DependencyProperty dependencyProperty10 = property;
											if (dependencyProperty10 != FirstDayOfWeekProperty)
											{
												DependencyProperty dependencyProperty11 = property;
												if (dependencyProperty11 == SelectionModeProperty)
												{
													OnSelectionModeChanged();
													return;
												}
												DependencyProperty dependencyProperty12 = property;
												if (dependencyProperty12 == IsOutOfScopeEnabledProperty)
												{
													OnIsOutOfScopePropertyChanged();
													return;
												}
												DependencyProperty dependencyProperty13 = property;
												if (dependencyProperty13 == DisplayModeProperty)
												{
													CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
													CalendarViewDisplayMode calendarViewDisplayMode2 = CalendarViewDisplayMode.Month;
													calendarViewDisplayMode = (CalendarViewDisplayMode)args.OldValue;
													calendarViewDisplayMode2 = (CalendarViewDisplayMode)args.NewValue;
													OnDisplayModeChanged(calendarViewDisplayMode, calendarViewDisplayMode2);
													return;
												}
												DependencyProperty dependencyProperty14 = property;
												if (dependencyProperty14 == IsTodayHighlightedProperty)
												{
													OnIsTodayHighlightedPropertyChanged();
													return;
												}
												DependencyProperty dependencyProperty15 = property;
												if (dependencyProperty15 == IsGroupLabelVisibleProperty)
												{
													OnIsLabelVisibleChanged();
													return;
												}
												DependencyProperty dependencyProperty16 = property;
												if (dependencyProperty16 != FocusBorderBrushProperty)
												{
													DependencyProperty dependencyProperty17 = property;
													if (dependencyProperty17 != SelectedHoverBorderBrushProperty)
													{
														DependencyProperty dependencyProperty18 = property;
														if (dependencyProperty18 != SelectedPressedBorderBrushProperty)
														{
															DependencyProperty dependencyProperty19 = property;
															if (dependencyProperty19 != SelectedBorderBrushProperty)
															{
																DependencyProperty dependencyProperty20 = property;
																if (dependencyProperty20 != HoverBorderBrushProperty)
																{
																	DependencyProperty dependencyProperty21 = property;
																	if (dependencyProperty21 != PressedBorderBrushProperty)
																	{
																		DependencyProperty dependencyProperty22 = property;
																		if (dependencyProperty22 != CalendarItemBorderBrushProperty)
																		{
																			DependencyProperty dependencyProperty23 = property;
																			if (dependencyProperty23 != OutOfScopeBackgroundProperty)
																			{
																				DependencyProperty dependencyProperty24 = property;
																				if (dependencyProperty24 != CalendarItemBackgroundProperty)
																				{
																					DependencyProperty dependencyProperty25 = property;
																					if (dependencyProperty25 != PressedForegroundProperty)
																					{
																						DependencyProperty dependencyProperty26 = property;
																						if (dependencyProperty26 != TodayForegroundProperty)
																						{
																							DependencyProperty dependencyProperty27 = property;
																							if (dependencyProperty27 != BlackoutForegroundProperty)
																							{
																								DependencyProperty dependencyProperty28 = property;
																								if (dependencyProperty28 != SelectedForegroundProperty)
																								{
																									DependencyProperty dependencyProperty29 = property;
																									if (dependencyProperty29 != OutOfScopeForegroundProperty)
																									{
																										DependencyProperty dependencyProperty30 = property;
																										if (dependencyProperty30 != CalendarItemForegroundProperty)
																										{
																											DependencyProperty dependencyProperty31 = property;
																											if (dependencyProperty31 == TodayFontWeightProperty)
																											{
																												ForeachHost(delegate(CalendarViewGeneratorHost pHost)
																												{
																													CalendarPanel panel2 = pHost.Panel;
																													if (panel2 != null)
																													{
																														int num2 = -1;
																														num2 = pHost.CalculateOffsetFromMinDate(m_today);
																														if (num2 != -1)
																														{
																															DependencyObject dependencyObject = panel2.ContainerFromIndex(num2);
																															if (dependencyObject is CalendarViewBaseItem calendarViewBaseItem)
																															{
																																CalendarViewBaseItem calendarViewBaseItem2 = calendarViewBaseItem;
																																calendarViewBaseItem2.UpdateTextBlockFontProperties();
																															}
																														}
																													}
																												});
																												return;
																											}
																											DependencyProperty dependencyProperty32 = property;
																											if (dependencyProperty32 != DayItemFontFamilyProperty)
																											{
																												DependencyProperty dependencyProperty33 = property;
																												if (dependencyProperty33 != DayItemFontSizeProperty)
																												{
																													DependencyProperty dependencyProperty34 = property;
																													if (dependencyProperty34 != DayItemFontStyleProperty)
																													{
																														DependencyProperty dependencyProperty35 = property;
																														if (dependencyProperty35 != DayItemFontWeightProperty)
																														{
																															DependencyProperty dependencyProperty36 = property;
																															if (dependencyProperty36 != FirstOfMonthLabelFontFamilyProperty)
																															{
																																DependencyProperty dependencyProperty37 = property;
																																if (dependencyProperty37 != FirstOfMonthLabelFontSizeProperty)
																																{
																																	DependencyProperty dependencyProperty38 = property;
																																	if (dependencyProperty38 != FirstOfMonthLabelFontStyleProperty)
																																	{
																																		DependencyProperty dependencyProperty39 = property;
																																		if (dependencyProperty39 != FirstOfMonthLabelFontWeightProperty)
																																		{
																																			DependencyProperty dependencyProperty40 = property;
																																			if (dependencyProperty40 != MonthYearItemFontFamilyProperty)
																																			{
																																				DependencyProperty dependencyProperty41 = property;
																																				if (dependencyProperty41 != MonthYearItemFontSizeProperty)
																																				{
																																					DependencyProperty dependencyProperty42 = property;
																																					if (dependencyProperty42 != MonthYearItemFontStyleProperty)
																																					{
																																						DependencyProperty dependencyProperty43 = property;
																																						if (dependencyProperty43 != MonthYearItemFontWeightProperty)
																																						{
																																							DependencyProperty dependencyProperty44 = property;
																																							if (dependencyProperty44 != FirstOfYearDecadeLabelFontFamilyProperty)
																																							{
																																								DependencyProperty dependencyProperty45 = property;
																																								if (dependencyProperty45 != FirstOfYearDecadeLabelFontSizeProperty)
																																								{
																																									DependencyProperty dependencyProperty46 = property;
																																									if (dependencyProperty46 != FirstOfYearDecadeLabelFontStyleProperty)
																																									{
																																										DependencyProperty dependencyProperty47 = property;
																																										if (dependencyProperty47 != FirstOfYearDecadeLabelFontWeightProperty)
																																										{
																																											DependencyProperty dependencyProperty48 = property;
																																											if (dependencyProperty48 != HorizontalDayItemAlignmentProperty)
																																											{
																																												DependencyProperty dependencyProperty49 = property;
																																												if (dependencyProperty49 != VerticalDayItemAlignmentProperty)
																																												{
																																													DependencyProperty dependencyProperty50 = property;
																																													if (dependencyProperty50 != HorizontalFirstOfMonthLabelAlignmentProperty)
																																													{
																																														DependencyProperty dependencyProperty51 = property;
																																														if (dependencyProperty51 != VerticalFirstOfMonthLabelAlignmentProperty)
																																														{
																																															DependencyProperty dependencyProperty52 = property;
																																															if (dependencyProperty52 == CalendarItemBorderThicknessProperty)
																																															{
																																																ForeachHost(delegate(CalendarViewGeneratorHost pHost)
																																																{
																																																	ForeachChildInPanel(pHost.Panel, delegate(CalendarViewBaseItem pItem)
																																																	{
																																																		pItem.InvalidateMeasure();
																																																	});
																																																});
																																																return;
																																															}
																																															DependencyProperty dependencyProperty53 = property;
																																															if (dependencyProperty53 == CalendarViewDayItemStyleProperty)
																																															{
																																																Style spStyle = args.NewValue as Style;
																																																CalendarPanel panel = m_tpMonthViewItemHost.Panel;
																																																ForeachChildInPanel(panel, delegate(CalendarViewBaseItem pItem)
																																																{
																																																	SetDayItemStyle(pItem, spStyle);
																																																});
																																																panel?.SetNeedsToDetermineBiggestItemSize();
																																															}
																																															return;
																																														}
																																													}
																																												}
																																											}
																																											ForeachChildInPanel(m_tpMonthViewItemHost.Panel, delegate(CalendarViewBaseItem pItem)
																																											{
																																												pItem.UpdateTextBlockAlignments();
																																											});
																																											return;
																																										}
																																									}
																																								}
																																							}
																																							goto IL_03ea;
																																						}
																																					}
																																				}
																																			}
																																			CalendarPanel[] array = new CalendarPanel[2] { m_tpYearViewItemHost.Panel, m_tpDecadeViewItemHost.Panel };
																																			for (int i = 0; i < array.Length; i++)
																																			{
																																				if (array[i] != null)
																																				{
																																					array[i].SetNeedsToDetermineBiggestItemSize();
																																				}
																																			}
																																			goto IL_03ea;
																																		}
																																	}
																																}
																															}
																															goto IL_030f;
																														}
																													}
																												}
																											}
																											m_tpMonthViewItemHost.Panel?.SetNeedsToDetermineBiggestItemSize();
																											goto IL_030f;
																										}
																									}
																								}
																							}
																						}
																					}
																					ForeachHost(delegate(CalendarViewGeneratorHost pHost)
																					{
																						ForeachChildInPanel(pHost.Panel, delegate(CalendarViewBaseItem pItem)
																						{
																							pItem.UpdateTextBlockForeground();
																						});
																					});
																					return;
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
												ForeachHost(delegate(CalendarViewGeneratorHost pHost)
												{
													ForeachChildInPanel(pHost.Panel, delegate(CalendarViewBaseItem pItem)
													{
														pItem.InvalidateRender();
													});
												});
												return;
											}
										}
										UpdateWeekDayNames();
										return;
									}
								}
								m_calendarChanged = true;
								m_dateSourceChanged = true;
								InvalidateMeasure();
								return;
							}
						}
						m_dateSourceChanged = true;
						InvalidateMeasure();
						return;
					}
				}
			}
		}
		OnAlignmentChanged(args);
		return;
		IL_030f:
		ForeachChildInPanel(m_tpMonthViewItemHost.Panel, delegate(CalendarViewBaseItem pItem)
		{
			pItem.UpdateTextBlockFontProperties();
		});
		return;
		IL_03ea:
		CalendarPanel[] array2 = new CalendarPanel[2] { m_tpYearViewItemHost.Panel, m_tpDecadeViewItemHost.Panel };
		for (int j = 0; j < array2.Length; j++)
		{
			ForeachChildInPanel(array2[j], delegate(CalendarViewBaseItem pItem)
			{
				pItem.UpdateTextBlockFontProperties();
			});
		}
	}

	protected override void OnApplyTemplate()
	{
		DetachVisibleIndicesUpdatedEvents();
		DetachScrollViewerFocusEngagedEvents();
		DetachScrollViewerKeyDownEvents();
		DisconnectItemHosts();
		if (m_areDirectManipulationStateChangeHandlersHooked)
		{
			m_areDirectManipulationStateChangeHandlersHooked = false;
			ForeachHost(delegate(CalendarViewGeneratorHost pHost)
			{
				pHost.ScrollViewer?.SetDirectManipulationStateChangeHandler(null);
			});
		}
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.Panel = null;
			pHost.ScrollViewer = null;
		});
		m_tpHeaderButton = null;
		m_tpPreviousButton = null;
		m_tpNextButton = null;
		m_tpViewsGrid = null;
		base.OnApplyTemplate();
		CalendarPanel templateChild = GetTemplateChild<CalendarPanel>("MonthViewPanel");
		CalendarPanel templateChild2 = GetTemplateChild<CalendarPanel>("YearViewPanel");
		CalendarPanel templateChild3 = GetTemplateChild<CalendarPanel>("DecadeViewPanel");
		m_tpMonthViewItemHost.Panel = templateChild;
		m_tpYearViewItemHost.Panel = templateChild2;
		m_tpDecadeViewItemHost.Panel = templateChild3;
		if (templateChild != null)
		{
			CalendarPanel calendarPanel = templateChild;
			int num = 0;
			calendarPanel.PanelType = CalendarPanelType.Primary;
			num = NumberOfWeeksInView;
			calendarPanel.SetSuggestedDimension(7, num);
			calendarPanel.Orientation = Orientation.Horizontal;
		}
		if (templateChild2 != null)
		{
			CalendarPanel calendarPanel2 = templateChild2;
			if (!m_areYearDecadeViewDimensionsSet)
			{
				calendarPanel2.PanelType = CalendarPanelType.Secondary_SelfAdaptive;
			}
			calendarPanel2.SetSuggestedDimension(m_colsInYearDecadeView, m_rowsInYearDecadeView);
			calendarPanel2.Orientation = Orientation.Horizontal;
		}
		if (templateChild3 != null)
		{
			CalendarPanel calendarPanel3 = templateChild3;
			if (!m_areYearDecadeViewDimensionsSet)
			{
				calendarPanel3.PanelType = CalendarPanelType.Secondary_SelfAdaptive;
			}
			calendarPanel3.SetSuggestedDimension(m_colsInYearDecadeView, m_rowsInYearDecadeView);
			calendarPanel3.Orientation = Orientation.Horizontal;
		}
		Button templateChild4 = GetTemplateChild<Button>("HeaderButton");
		Button templateChild5 = GetTemplateChild<Button>("PreviousButton");
		Button templateChild6 = GetTemplateChild<Button>("NextButton");
		if (templateChild5 != null)
		{
			string name = AutomationProperties.GetName(templateChild5);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_PREVIOUS");
				AutomationProperties.SetName(templateChild5, name);
			}
		}
		if (templateChild6 != null)
		{
			string name = AutomationProperties.GetName(templateChild6);
			if (name == null)
			{
				name = DXamlCore.GetCurrentNoCreate().GetLocalizedResourceString("UIA_FLIPVIEW_NEXT");
				AutomationProperties.SetName(templateChild6, name);
			}
		}
		m_tpHeaderButton = templateChild4;
		m_tpPreviousButton = templateChild5;
		m_tpNextButton = templateChild6;
		Grid grid = (m_tpViewsGrid = GetTemplateChild<Grid>("Views"));
		ScrollViewer spMonthViewScrollViewer = GetTemplateChild<ScrollViewer>("MonthViewScrollViewer");
		ScrollViewer spYearViewScrollViewer = GetTemplateChild<ScrollViewer>("YearViewScrollViewer");
		ScrollViewer spDecadeViewScrollViewer = GetTemplateChild<ScrollViewer>("DecadeViewScrollViewer");
		m_tpMonthViewItemHost.ScrollViewer = spMonthViewScrollViewer;
		m_tpYearViewItemHost.ScrollViewer = spYearViewScrollViewer;
		m_tpDecadeViewItemHost.ScrollViewer = spDecadeViewScrollViewer;
		if (spMonthViewScrollViewer != null)
		{
			spMonthViewScrollViewer.AutomationPeerFactoryIndex = () => new CalendarScrollViewerAutomationPeer(spMonthViewScrollViewer);
			m_tpMonthViewScrollViewer = spMonthViewScrollViewer;
		}
		if (spYearViewScrollViewer != null)
		{
			spYearViewScrollViewer.AutomationPeerFactoryIndex = () => new CalendarScrollViewerAutomationPeer(spYearViewScrollViewer);
			m_tpYearViewScrollViewer = spYearViewScrollViewer;
		}
		if (spDecadeViewScrollViewer != null)
		{
			spDecadeViewScrollViewer.AutomationPeerFactoryIndex = () => new CalendarScrollViewerAutomationPeer(spDecadeViewScrollViewer);
			m_tpDecadeViewScrollViewer = spDecadeViewScrollViewer;
		}
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			ScrollViewer scrollViewer = pHost.ScrollViewer;
			if (scrollViewer != null)
			{
				scrollViewer.TemplatedParentHandlesScrolling = true;
				scrollViewer.SetDirectManipulationStateChangeHandler(pHost);
				scrollViewer.m_templatedParentHandlesMouseButton = true;
			}
		});
		m_areDirectManipulationStateChangeHandlersHooked = true;
		AttachVisibleIndicesUpdatedEvents();
		AttachButtonClickedEvents();
		AttachScrollViewerKeyDownEvents();
		RegisterItemHosts();
		AttachScrollViewerFocusEngagedEvents();
		UpdateVisualState(useTransitions: false);
		UpdateFlowDirectionForView();
	}

	private protected override void ChangeVisualState(bool bUseTransitions)
	{
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		switch (DisplayMode)
		{
		case CalendarViewDisplayMode.Month:
			GoToState(bUseTransitions, "Month");
			break;
		case CalendarViewDisplayMode.Year:
			GoToState(bUseTransitions, "Year");
			break;
		default:
			GoToState(bUseTransitions, "Decade");
			break;
		}
		bool flag = false;
		if (!base.IsEnabled)
		{
			GoToState(bUseTransitions, "Disabled");
		}
		else
		{
			GoToState(bUseTransitions, "Normal");
		}
	}

	internal void OnPrimaryPanelDesiredSizeChanged(CalendarViewGeneratorHost pHost)
	{
		CalendarPanel panel = pHost.Panel;
		Size size = default(Size);
		size = panel.GetDesiredViewportSize();
		CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
		tpTemplateSettings.MinViewWidth = size.Width;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		Size size = default(Size);
		if (m_calendarChanged)
		{
			m_calendarChanged = false;
			CreateCalendarAndMonthYearFormatter();
			FormatWeekDayNames();
			UpdateFlowDirectionForView();
		}
		if (m_dateSourceChanged)
		{
			m_dateSourceChanged = false;
			DisconnectItemHosts();
			RefreshItemHosts();
			InitializeIndexCorrectionTableIfNeeded();
			RegisterItemHosts();
			UpdateWeekDayNames();
		}
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size size = default(Size);
		size = base.ArrangeOverride(finalSize);
		if (m_tpViewsGrid != null)
		{
			double num = 0.0;
			double num2 = 0.0;
			CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
			num = m_tpViewsGrid.ActualHeight;
			num2 = m_tpViewsGrid.ActualWidth;
			Rect rect2 = (tpTemplateSettings.ClipRect = new Rect(0.0, 0.0, (float)num2, (float)num));
			tpTemplateSettings.CenterX = num2 / 2.0;
			tpTemplateSettings.CenterY = num / 2.0;
		}
		if (m_isSetDisplayDateRequested)
		{
			m_isSetDisplayDateRequested = false;
			SetDisplayDateInternal(m_lastDisplayedDate);
		}
		return size;
	}

	private void CreateCalendarLanguages()
	{
		string language = base.Language;
		IEnumerable<string> enumerable = (m_tpCalendarLanguages = CreateCalendarLanguagesStatic(language));
	}

	internal static IEnumerable<string> CreateCalendarLanguagesStatic(string language)
	{
		IEnumerable<string> enumerable = null;
		int num = 0;
		IReadOnlyList<string> languages = ApplicationLanguages.Languages;
		IList<string> list = new List<string>();
		if (language != null)
		{
			list.Add(language);
		}
		num = languages.Count;
		for (uint num2 = 0u; num2 < num; num2++)
		{
			string item = languages[(int)num2];
			list.Add(item);
		}
		return list;
	}

	private void CreateCalendarAndMonthYearFormatter()
	{
		string clock = "24HourClock";
		string calendarIdentifier = CalendarIdentifier;
		Calendar calendarForComparison = (m_tpCalendar = new Calendar(m_tpCalendarLanguages, calendarIdentifier, clock));
		m_dateComparer.SetCalendarForComparison(calendarForComparison);
		m_tpSelectedDates.SetCalendarForComparison(calendarForComparison);
		int num = 0;
		int num2 = 0;
		num = m_tpCalendar.FirstEra;
		num2 = m_tpCalendar.LastEra;
		m_isMultipleEraCalendar = num != num2;
		m_tpCalendar.SetToNow();
		m_today = m_tpCalendar.GetDateTime();
		if (m_lastDisplayedDate == default(DateTimeOffset))
		{
			m_lastDisplayedDate = m_today;
		}
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.Panel?.SetNeedsToDetermineBiggestItemSize();
			pHost.ResetPossibleItemStrings();
		});
		CreateDateTimeFormatter("month year", out var ppDateTimeFormatter);
		m_tpMonthYearFormatter = ppDateTimeFormatter;
		CreateDateTimeFormatter("year", out ppDateTimeFormatter);
		m_tpYearFormatter = ppDateTimeFormatter;
	}

	private void DisconnectItemHosts()
	{
		if (m_itemHostsConnected)
		{
			m_itemHostsConnected = false;
			ForeachHost(delegate(CalendarViewGeneratorHost pHost)
			{
				pHost.Panel?.DisconnectItemsHost();
			});
		}
	}

	private void RegisterItemHosts()
	{
		m_itemHostsConnected = true;
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.Panel?.RegisterItemsHost(pHost);
		});
	}

	private void RefreshItemHosts()
	{
		DateTimeOffset minDate = MinDate;
		DateTimeOffset maxDate = MaxDate;
		m_tpCalendar.SetToMin();
		m_minDate = new DateTimeOffset(Math.Max(val2: m_tpCalendar.GetDateTime().UtcTicks, val1: minDate.UtcTicks), TimeSpan.Zero);
		m_tpCalendar.SetToMax();
		m_maxDate = new DateTimeOffset(Math.Min(val2: m_tpCalendar.GetDateTime().UtcTicks, val1: maxDate.UtcTicks), TimeSpan.Zero);
		if (m_dateComparer.LessThan(m_maxDate, m_minDate))
		{
			throw new InvalidOperationException("ERROR_CALENDAR_INVALID_MIN_MAX_DATE");
		}
		CoerceDate(ref m_lastDisplayedDate);
		m_tpCalendar.SetDateTime(m_minDate);
		m_weekDayOfMinDate = m_tpCalendar.DayOfWeek;
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.ResetScope();
			pHost.ComputeSize();
		});
	}

	private void AttachVisibleIndicesUpdatedEvents()
	{
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.AttachVisibleIndicesUpdatedEvent();
		});
	}

	private void DetachVisibleIndicesUpdatedEvents()
	{
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.DetachVisibleIndicesUpdatedEvent();
		});
	}

	private void AttachScrollViewerFocusEngagedEvents()
	{
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.AttachScrollViewerFocusEngagedEvent();
		});
	}

	private void DetachScrollViewerFocusEngagedEvents()
	{
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			pHost.DetachScrollViewerFocusEngagedEvent();
		});
	}

	private void AttachButtonClickedEvents()
	{
		DetachButtonClickedEvents();
		if (m_tpHeaderButton != null)
		{
			if (m_epHeaderButtonClickHandler == null)
			{
				m_epHeaderButtonClickHandler = delegate
				{
					OnHeaderButtonClicked();
				};
			}
			m_tpHeaderButton.Click += m_epHeaderButtonClickHandler;
		}
		if (m_tpPreviousButton != null)
		{
			if (m_epPreviousButtonClickHandler == null)
			{
				m_epPreviousButtonClickHandler = delegate
				{
					OnNavigationButtonClicked(forward: false);
				};
			}
			m_tpPreviousButton.Click += m_epPreviousButtonClickHandler;
		}
		if (m_tpNextButton == null)
		{
			return;
		}
		if (m_epNextButtonClickHandler == null)
		{
			m_epNextButtonClickHandler = delegate
			{
				OnNavigationButtonClicked(forward: true);
			};
		}
		m_tpNextButton.Click += m_epNextButtonClickHandler;
	}

	private void DetachButtonClickedEvents()
	{
		if (m_epHeaderButtonClickHandler != null && m_tpHeaderButton != null)
		{
			m_tpHeaderButton.Click -= m_epHeaderButtonClickHandler;
			m_epHeaderButtonClickHandler = null;
		}
		if (m_epPreviousButtonClickHandler != null && m_tpPreviousButton != null)
		{
			m_tpPreviousButton.Click -= m_epPreviousButtonClickHandler;
			m_epPreviousButtonClickHandler = null;
		}
		if (m_epNextButtonClickHandler != null && m_tpNextButton != null)
		{
			m_tpNextButton.Click -= m_epNextButtonClickHandler;
			m_epNextButtonClickHandler = null;
		}
	}

	private void AttachScrollViewerKeyDownEvents()
	{
		DetachScrollViewerKeyDownEvents();
		if (m_tpMonthViewScrollViewer != null)
		{
			if (m_epMonthViewScrollViewerKeyDownEventHandler == null)
			{
				m_epMonthViewScrollViewerKeyDownEventHandler = delegate(object pSender, KeyRoutedEventArgs pArgs)
				{
					bool flag3 = false;
					if (m_tpMonthViewScrollViewer.IsFocusEngaged)
					{
						OnKeyDown(pArgs);
					}
				};
			}
			m_tpMonthViewScrollViewer.KeyDown += m_epMonthViewScrollViewerKeyDownEventHandler;
		}
		if (m_tpYearViewScrollViewer != null)
		{
			if (m_epYearViewScrollViewerKeyDownEventHandler == null)
			{
				m_epYearViewScrollViewerKeyDownEventHandler = delegate(object pSender, KeyRoutedEventArgs pArgs)
				{
					bool flag2 = false;
					if (m_tpYearViewScrollViewer.IsFocusEngaged)
					{
						OnKeyDown(pArgs);
					}
				};
			}
			m_tpYearViewScrollViewer.KeyDown += m_epYearViewScrollViewerKeyDownEventHandler;
		}
		if (m_tpDecadeViewScrollViewer == null)
		{
			return;
		}
		if (m_epDecadeViewScrollViewerKeyDownEventHandler == null)
		{
			m_epDecadeViewScrollViewerKeyDownEventHandler = delegate(object pSender, KeyRoutedEventArgs pArgs)
			{
				bool flag = false;
				if (m_tpDecadeViewScrollViewer.IsFocusEngaged)
				{
					OnKeyDown(pArgs);
				}
			};
		}
		m_tpDecadeViewScrollViewer.KeyDown += m_epDecadeViewScrollViewerKeyDownEventHandler;
	}

	private void DetachScrollViewerKeyDownEvents()
	{
		if (m_epMonthViewScrollViewerKeyDownEventHandler != null && m_tpMonthViewScrollViewer != null)
		{
			m_tpMonthViewScrollViewer.KeyDown -= m_epMonthViewScrollViewerKeyDownEventHandler;
			m_epMonthViewScrollViewerKeyDownEventHandler = null;
		}
		if (m_epYearViewScrollViewerKeyDownEventHandler != null && m_tpYearViewScrollViewer != null)
		{
			m_tpYearViewScrollViewer.KeyDown -= m_epYearViewScrollViewerKeyDownEventHandler;
			m_epYearViewScrollViewerKeyDownEventHandler = null;
		}
		if (m_epDecadeViewScrollViewerKeyDownEventHandler != null && m_tpDecadeViewScrollViewer != null)
		{
			m_tpDecadeViewScrollViewer.KeyDown -= m_epDecadeViewScrollViewerKeyDownEventHandler;
			m_epDecadeViewScrollViewerKeyDownEventHandler = null;
		}
	}

	private void UpdateHeaderText(bool withAnimation)
	{
		GetActiveGeneratorHost(out var ppHost);
		CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
		tpTemplateSettings.HeaderText = ppHost.GetHeaderTextOfCurrentScope();
		if (withAnimation)
		{
			bool flag = false;
			flag = GoToState(useTransitions: true, "ViewChanged");
			flag = GoToState(useTransitions: true, "ViewChanging");
		}
		if (m_isNavigationButtonClicked)
		{
			m_isNavigationButtonClicked = false;
			RaiseAutomationNotificationAfterNavigationButtonClicked();
		}
	}

	private void UpdateNavigationButtonStates()
	{
		GetActiveGeneratorHost(out var ppHost);
		CalendarPanel panel = ppHost.Panel;
		if (panel != null)
		{
			int num = 0;
			int num2 = 0;
			uint num3 = 0u;
			CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
			num = panel.FirstVisibleIndexBase;
			num2 = panel.LastVisibleIndexBase;
			num3 = ppHost.Size();
			tpTemplateSettings.HasMoreContentBefore = num > 0;
			tpTemplateSettings.HasMoreContentAfter = num2 + 1 < (int)num3;
		}
	}

	private void OnHeaderButtonClicked()
	{
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		switch (DisplayMode)
		{
		case CalendarViewDisplayMode.Month:
			calendarViewDisplayMode = CalendarViewDisplayMode.Year;
			break;
		default:
			calendarViewDisplayMode = CalendarViewDisplayMode.Decade;
			break;
		case CalendarViewDisplayMode.Decade:
			return;
		}
		DisplayMode = calendarViewDisplayMode;
	}

	private void RaiseAutomationNotificationAfterNavigationButtonClicked()
	{
		if (m_tpHeaderButton != null)
		{
			string text = AutomationProperties.GetName(m_tpHeaderButton);
			if (text == null)
			{
				text = m_tpHeaderButton.Content?.ToString();
			}
			if (text != null)
			{
				GetAutomationPeer()?.RaiseNotificationEvent(AutomationNotificationKind.ActionCompleted, AutomationNotificationProcessing.MostRecent, text, "CalenderViewNavigationButtonCompleted");
			}
		}
	}

	private void OnNavigationButtonClicked(bool forward)
	{
		GetActiveGeneratorHost(out var ppHost);
		CalendarPanel panel = ppHost.Panel;
		if (panel == null)
		{
			return;
		}
		bool pCanPanelShowFullScope = false;
		int num = 0;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset pFirstDateOfNextScope = default(DateTimeOffset);
		CanPanelShowFullScope(ppHost, out pCanPanelShowFullScope);
		num = panel.FirstVisibleIndexBase;
		DependencyObject dependencyObject = panel.ContainerFromIndex(num);
		if (!(dependencyObject is CalendarViewBaseItem calendarViewBaseItem))
		{
			return;
		}
		try
		{
			CalendarViewBaseItem calendarViewBaseItem2 = calendarViewBaseItem;
			dateTimeOffset = calendarViewBaseItem2.DateBase;
			if (pCanPanelShowFullScope)
			{
				ppHost.GetFirstDateOfNextScope(dateTimeOffset, forward, out pFirstDateOfNextScope);
			}
			else
			{
				int num2 = 0;
				int num3 = 0;
				num3 = panel.Rows;
				num2 = panel.Cols;
				int num4 = num2 * num3;
				int units = (forward ? num4 : (-num4));
				pFirstDateOfNextScope = dateTimeOffset;
				ppHost.AddUnits(pFirstDateOfNextScope, units);
			}
		}
		catch (Exception)
		{
			pFirstDateOfNextScope = (forward ? m_maxDate : m_minDate);
		}
		ScrollToDateWithAnimation(ppHost, pFirstDateOfNextScope);
		m_isNavigationButtonClicked = true;
	}

	public void SetYearDecadeDisplayDimensions(int columns, int rows)
	{
		m_areYearDecadeViewDimensionsSet = true;
		m_colsInYearDecadeView = columns;
		m_rowsInYearDecadeView = rows;
		CalendarPanel panel = m_tpYearViewItemHost.Panel;
		if (panel != null)
		{
			panel.PanelType = CalendarPanelType.Secondary;
			panel.SetSuggestedDimension(columns, rows);
		}
		CalendarPanel panel2 = m_tpDecadeViewItemHost.Panel;
		if (panel2 != null)
		{
			panel2.PanelType = CalendarPanelType.Secondary;
			panel2.SetSuggestedDimension(columns, rows);
		}
	}

	private void BringDisplayDateintoView(CalendarViewGeneratorHost pHost)
	{
		bool pCanPanelShowFullScope = false;
		CanPanelShowFullScope(pHost, out pCanPanelShowFullScope);
		DateTimeOffset pDate;
		if (pCanPanelShowFullScope)
		{
			m_tpCalendar.SetDateTime(m_lastDisplayedDate);
			pHost.AdjustToFirstUnitInThisScope(out pDate);
			CoerceDate(ref pDate);
		}
		else
		{
			pDate = m_lastDisplayedDate;
		}
		ScrollToDate(pHost, pDate);
	}

	private void ScrollToDate(CalendarViewGeneratorHost pHost, DateTimeOffset date)
	{
		int num = 0;
		num = pHost.CalculateOffsetFromMinDate(date);
		pHost.Panel.ScrollItemIntoView(num, ScrollIntoViewAlignment.Leading, 0.0, forceSynchronous: true);
	}

	private void ScrollToDateWithAnimation(CalendarViewGeneratorHost pHost, DateTimeOffset date)
	{
		ScrollViewer scrollViewer = pHost.ScrollViewer;
		if (scrollViewer == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		bool flag = false;
		CalendarPanel panel = pHost.Panel;
		num = pHost.CalculateOffsetFromMinDate(date);
		num3 = panel.Cols;
		if (num3 > 0)
		{
			num2 = panel.FirstVisibleIndex;
			DependencyObject dependencyObject = panel.ContainerFromIndex(num2);
			CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
			Rect bounds = calendarViewBaseItem.GetVirtualizationInformation().Bounds;
			int num4 = (num - num2) / num3;
			if ((num - num2) % num3 != 0 && num <= num2)
			{
				num4--;
			}
			else if (num4 == 0 && num > num2)
			{
				num4++;
			}
			double num5 = bounds.Y + (double)num4 * bounds.Height;
			object obj = num5;
			double? verticalOffset = num5;
			flag = scrollViewer.ChangeView(null, verticalOffset, null, disableAnimation: false);
		}
	}

	public void SetDisplayDate(DateTimeOffset date)
	{
		if (!m_dateSourceChanged)
		{
			CoerceDate(ref date);
			SetDisplayDateInternal(date);
		}
		else
		{
			m_isSetDisplayDateRequested = true;
			m_lastDisplayedDate = date;
		}
	}

	private void SetDisplayDateInternal(DateTimeOffset date)
	{
		GetActiveGeneratorHost(out var ppHost);
		m_lastDisplayedDate = date;
		if (ppHost.Panel != null)
		{
			BringDisplayDateintoView(ppHost);
		}
	}

	internal void CoerceDate(ref DateTimeOffset date)
	{
		if (m_dateComparer.LessThan(date, m_minDate))
		{
			date = m_minDate;
		}
		if (m_dateComparer.LessThan(m_maxDate, date))
		{
			date = m_maxDate;
		}
	}

	internal void OnVisibleIndicesUpdated(CalendarViewGeneratorHost pHost)
	{
		int num = 0;
		int num2 = 0;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		bool isScopeChanged = false;
		int num3 = 0;
		CalendarPanel panel = pHost.Panel;
		if (panel.PanelType != 0)
		{
			num3 = panel.StartIndex;
			int cols = panel.Cols;
			num = panel.FirstVisibleIndexBase;
			num2 = panel.LastVisibleIndexBase;
			DependencyObject dependencyObject = panel.ContainerFromIndex(num);
			CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
			dateTimeOffset = calendarViewBaseItem.DateBase;
			dependencyObject = panel.ContainerFromIndex(num2);
			calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
			dateTimeOffset2 = calendarViewBaseItem.DateBase;
			pHost.UpdateScope(dateTimeOffset, dateTimeOffset2, out isScopeChanged);
			if (isScopeChanged)
			{
				UpdateHeaderText(withAnimation: false);
			}
			UpdateNavigationButtonStates();
			UpdateItemsScopeState(pHost, ignoreWhenIsOutOfScopeDisabled: true, ignoreInDirectManipulation: true);
		}
	}

	internal void UpdateItemsScopeState(CalendarViewGeneratorHost pHost, bool ignoreWhenIsOutOfScopeDisabled, bool ignoreInDirectManipulation)
	{
		CalendarPanel panel = pHost.Panel;
		if (panel == null || panel.DesiredSize == default(Size))
		{
			return;
		}
		bool flag = false;
		flag = IsOutOfScopeEnabled;
		if (ignoreWhenIsOutOfScopeDisabled && !flag)
		{
			return;
		}
		bool flag2 = pHost.ScrollViewer != null && pHost.ScrollViewer.IsInDirectManipulation;
		if (ignoreInDirectManipulation && flag2)
		{
			return;
		}
		bool flag3 = flag && !flag2;
		int num = -1;
		int num2 = -1;
		num = panel.FirstVisibleIndex;
		num2 = panel.LastVisibleIndex;
		int[] lastVisibleIndicesPairRef = pHost.GetLastVisibleIndicesPairRef();
		if (num != -1 && num2 != -1)
		{
			for (int i = num; i <= num2; i++)
			{
				DependencyObject dependencyObject = panel.ContainerFromIndex(i);
				CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
				CalendarViewBaseItem calendarViewBaseItem2 = calendarViewBaseItem;
				DateTimeOffset dateBase = calendarViewBaseItem2.DateBase;
				bool flag4 = m_dateComparer.LessThan(dateBase, pHost.GetMinDateOfCurrentScope()) || m_dateComparer.LessThan(pHost.GetMaxDateOfCurrentScope(), dateBase);
				calendarViewBaseItem2.SetIsOutOfScope(flag3 && flag4);
			}
		}
		if (lastVisibleIndicesPairRef[0] != -1 && lastVisibleIndicesPairRef[1] != -1)
		{
			if (lastVisibleIndicesPairRef[0] < num)
			{
				for (int j = lastVisibleIndicesPairRef[0]; j <= Math.Min(lastVisibleIndicesPairRef[1], num - 1); j++)
				{
					DependencyObject dependencyObject = panel.ContainerFromIndex(j);
					if (dependencyObject is CalendarViewBaseItem calendarViewBaseItem3)
					{
						calendarViewBaseItem3.SetIsOutOfScope(state: false);
					}
				}
			}
			if (lastVisibleIndicesPairRef[1] > num2)
			{
				for (int num3 = lastVisibleIndicesPairRef[1]; num3 >= Math.Max(lastVisibleIndicesPairRef[0], num2 + 1); num3--)
				{
					DependencyObject dependencyObject = panel.ContainerFromIndex(num3);
					if (dependencyObject is CalendarViewBaseItem calendarViewBaseItem4)
					{
						calendarViewBaseItem4.SetIsOutOfScope(state: false);
					}
				}
			}
		}
		lastVisibleIndicesPairRef[0] = num;
		lastVisibleIndicesPairRef[1] = num2;
	}

	private void OnIsTodayHighlightedPropertyChanged()
	{
		ForeachHost(delegate(CalendarViewGeneratorHost pHost)
		{
			CalendarPanel panel = pHost.Panel;
			if (panel != null)
			{
				int num = -1;
				num = pHost.CalculateOffsetFromMinDate(m_today);
				if (num != -1)
				{
					DependencyObject dependencyObject = panel.ContainerFromIndex(num);
					if (dependencyObject is CalendarViewBaseItem calendarViewBaseItem)
					{
						bool flag = false;
						flag = IsTodayHighlighted;
						calendarViewBaseItem.SetIsToday(flag);
					}
				}
			}
		});
	}

	private void OnIsOutOfScopePropertyChanged()
	{
		bool isOutOfScopeEnabled = false;
		isOutOfScopeEnabled = IsOutOfScopeEnabled;
		if (m_areDirectManipulationStateChangeHandlersHooked != isOutOfScopeEnabled)
		{
			m_areDirectManipulationStateChangeHandlersHooked = !m_areDirectManipulationStateChangeHandlersHooked;
			ForeachHost(delegate(CalendarViewGeneratorHost pHost)
			{
				pHost.ScrollViewer?.SetDirectManipulationStateChangeHandler(isOutOfScopeEnabled ? pHost : null);
			});
		}
		GetActiveGeneratorHost(out var ppHost);
		UpdateItemsScopeState(ppHost, ignoreWhenIsOutOfScopeDisabled: false, ignoreInDirectManipulation: true);
	}

	internal void OnScrollViewerFocusEngaged(FocusEngagedEventArgs pArgs)
	{
		GetActiveGeneratorHost(out var ppHost);
		if (ppHost != null)
		{
			bool pFocused = false;
			m_focusItemAfterDisplayModeChanged = false;
			FocusItemByDate(ppHost, m_lastDisplayedDate, m_focusStateAfterDisplayModeChanged, out pFocused);
			pArgs.Handled = pFocused;
		}
	}

	private void OnDisplayModeChanged(CalendarViewDisplayMode oldDisplayMode, CalendarViewDisplayMode newDisplayMode)
	{
		bool flag = false;
		GetGeneratorHost(oldDisplayMode, out var ppHost);
		if (ppHost != null)
		{
			ScrollViewer scrollViewer = ppHost.ScrollViewer;
			if (scrollViewer != null)
			{
				flag = scrollViewer.IsFocusEngaged;
				if (flag)
				{
					scrollViewer.RemoveFocusEngagement();
				}
			}
		}
		UpdateLastDisplayedDate(oldDisplayMode);
		UpdateVisualState();
		GetGeneratorHost(newDisplayMode, out var ppHost2);
		CalendarPanel panel = ppHost2.Panel;
		if (panel != null)
		{
			if (newDisplayMode != 0)
			{
				panel.UpdateLayout();
			}
			if (flag)
			{
				ScrollViewer scrollViewer2 = ppHost2.ScrollViewer;
				if (scrollViewer2 != null)
				{
					bool flag2 = false;
					if (FocusManager.SetFocusedElementWithDirection(scrollViewer2, FocusState.Keyboard, animateIfBringIntoView: false, forceBringIntoView: false, FocusNavigationDirection.None))
					{
						FocusManager.SetEngagedControl(scrollViewer2);
					}
				}
			}
			if (m_focusItemAfterDisplayModeChanged)
			{
				bool pFocused = false;
				m_focusItemAfterDisplayModeChanged = false;
				FocusItemByDate(ppHost2, m_lastDisplayedDate, m_focusStateAfterDisplayModeChanged, out pFocused);
			}
			else
			{
				BringDisplayDateintoView(ppHost2);
			}
		}
		CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
		tpTemplateSettings.HasMoreViews = newDisplayMode != CalendarViewDisplayMode.Decade;
		UpdateHeaderText(withAnimation: true);
		UpdateNavigationButtonStates();
	}

	private void UpdateLastDisplayedDate(CalendarViewDisplayMode lastDisplayMode)
	{
		GetGeneratorHost(lastDisplayMode, out var ppHost);
		CalendarPanel panel = ppHost.Panel;
		if (panel == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
		num = panel.FirstVisibleIndexBase;
		num2 = panel.LastVisibleIndexBase;
		DependencyObject dependencyObject = panel.ContainerFromIndex(num);
		CalendarViewBaseItem calendarViewBaseItem = dependencyObject as CalendarViewBaseItem;
		dateTimeOffset = calendarViewBaseItem.DateBase;
		dependencyObject = panel.ContainerFromIndex(num2);
		calendarViewBaseItem = dependencyObject as CalendarViewBaseItem;
		dateTimeOffset2 = calendarViewBaseItem.DateBase;
		bool flag = false;
		int num3 = 0;
		num3 = ppHost.CompareDate(m_lastDisplayedDate, dateTimeOffset);
		if (num3 >= 0)
		{
			num3 = ppHost.CompareDate(m_lastDisplayedDate, dateTimeOffset2);
			if (num3 <= 0)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			DateTimeOffset dateTimeOffset3 = ppHost.GetMinDateOfCurrentScope();
			num3 = ppHost.CompareDate(dateTimeOffset3, dateTimeOffset);
			if (num3 < 0)
			{
				dateTimeOffset3 = dateTimeOffset;
			}
			CopyDate(lastDisplayMode, dateTimeOffset3, ref m_lastDisplayedDate);
		}
	}

	private void OnIsLabelVisibleChanged()
	{
		CalendarViewGeneratorHost[] array = new CalendarViewGeneratorHost[2] { m_tpMonthViewItemHost, m_tpYearViewItemHost };
		bool isLabelVisible = false;
		isLabelVisible = IsGroupLabelVisible;
		for (uint num = 0u; num < array.Length; num++)
		{
			CalendarViewGeneratorHost pHost = array[num];
			CalendarPanel panel = pHost.Panel;
			if (panel != null)
			{
				ForeachChildInPanel(panel, delegate(CalendarViewBaseItem pItem)
				{
					pHost.UpdateLabel(pItem, isLabelVisible);
				});
			}
		}
	}

	private void CreateDateTimeFormatter(string format, out DateTimeFormatter ppDateTimeFormatter)
	{
		string clock = "24HourClock";
		string geographicRegion = "ZZ";
		string calendarIdentifier = CalendarIdentifier;
		DateTimeFormatter dateTimeFormatter = (ppDateTimeFormatter = new DateTimeFormatter(format, m_tpCalendarLanguages, geographicRegion, calendarIdentifier, clock));
	}

	private void FormatWeekDayNames()
	{
		if (m_tpMonthViewItemHost.Panel == null)
		{
			return;
		}
		bool flag = false;
		Windows.Globalization.DayOfWeek dayOfWeek = Windows.Globalization.DayOfWeek.Sunday;
		DateTimeFormatter ppDateTimeFormatter = null;
		object obj = ReadLocalValue(DayOfWeekFormatProperty);
		flag = obj == DependencyProperty.UnsetValue;
		m_tpCalendar.SetToNow();
		dayOfWeek = m_tpCalendar.DayOfWeek;
		m_tpCalendar.AddDays((int)(7 - dayOfWeek) % 7);
		m_dayOfWeekNames.Clear();
		m_dayOfWeekNamesFull.Clear();
		if (!flag)
		{
			string dayOfWeekFormat = DayOfWeekFormat;
			if (!dayOfWeekFormat.IsNullOrEmpty())
			{
				CreateDateTimeFormatter(dayOfWeekFormat, out ppDateTimeFormatter);
			}
		}
		for (int i = 0; i < 7; i++)
		{
			string item;
			if (ppDateTimeFormatter != null)
			{
				DateTimeOffset dateTime = m_tpCalendar.GetDateTime();
				item = ppDateTimeFormatter.Format(dateTime);
			}
			else
			{
				item = m_tpCalendar.DayOfWeekAsString(1);
			}
			m_dayOfWeekNames.Add(item);
			string item2 = m_tpCalendar.DayOfWeekAsFullString();
			m_dayOfWeekNamesFull.Add(item2);
			m_tpCalendar.AddDays(1);
		}
	}

	private void UpdateWeekDayNameAPName(string str, string name)
	{
		TextBlock templateChild = GetTemplateChild<TextBlock>(str);
		AutomationProperties.SetName(templateChild, name);
	}

	private void UpdateWeekDayNames()
	{
		CalendarPanel panel = m_tpMonthViewItemHost.Panel;
		if (panel != null)
		{
			Windows.Globalization.DayOfWeek dayOfWeek = Windows.Globalization.DayOfWeek.Sunday;
			int num = 0;
			CalendarViewTemplateSettings tpTemplateSettings = m_tpTemplateSettings;
			dayOfWeek = FirstDayOfWeek;
			if (m_dayOfWeekNames.Empty())
			{
				FormatWeekDayNames();
			}
			num = (int)(dayOfWeek - 0);
			tpTemplateSettings.WeekDay1 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay1", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay2 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay2", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay3 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay3", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay4 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay4", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay5 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay5", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay6 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay6", m_dayOfWeekNamesFull[num]);
			num = (num + 1) % 7;
			tpTemplateSettings.WeekDay7 = m_dayOfWeekNames[num];
			UpdateWeekDayNameAPName("WeekDay7", m_dayOfWeekNamesFull[num]);
			m_monthViewStartIndex = (m_weekDayOfMinDate - dayOfWeek + 7) % 7;
			panel.StartIndex = m_monthViewStartIndex;
		}
	}

	internal void GetActiveGeneratorHost(out CalendarViewGeneratorHost ppHost)
	{
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		ppHost = null;
		calendarViewDisplayMode = DisplayMode;
		GetGeneratorHost(calendarViewDisplayMode, out ppHost);
	}

	private void GetGeneratorHost(CalendarViewDisplayMode mode, out CalendarViewGeneratorHost ppHost)
	{
		switch (mode)
		{
		case CalendarViewDisplayMode.Month:
			ppHost = m_tpMonthViewItemHost;
			break;
		case CalendarViewDisplayMode.Year:
			ppHost = m_tpYearViewItemHost;
			break;
		case CalendarViewDisplayMode.Decade:
			ppHost = m_tpDecadeViewItemHost;
			break;
		default:
			throw new InvalidOperationException();
		}
	}

	internal string FormatYearName(DateTimeOffset date)
	{
		return m_tpYearFormatter.Format(date);
	}

	internal string FormatMonthYearName(DateTimeOffset date)
	{
		return m_tpMonthYearFormatter.Format(date);
	}

	private void CopyDate(CalendarViewDisplayMode displayMode, DateTimeOffset source, ref DateTimeOffset target)
	{
		bool flag = true;
		bool flag2 = true;
		bool flag3 = displayMode == CalendarViewDisplayMode.Month || displayMode == CalendarViewDisplayMode.Year;
		bool flag4 = displayMode == CalendarViewDisplayMode.Month;
		if (flag && flag2 && flag3 && flag4)
		{
			target = source;
			return;
		}
		int num = 0;
		int val = 0;
		int val2 = 0;
		int val3 = 0;
		m_tpCalendar.SetDateTime(source);
		if (flag)
		{
			num = m_tpCalendar.Era;
		}
		if (flag2)
		{
			val = m_tpCalendar.Year;
		}
		if (flag3)
		{
			val2 = m_tpCalendar.Month;
		}
		if (flag4)
		{
			val3 = m_tpCalendar.Day;
		}
		m_tpCalendar.SetDateTime(target);
		if (flag2)
		{
			int num2 = 0;
			int num3 = 0;
			num2 = m_tpCalendar.FirstYearInThisEra;
			num3 = m_tpCalendar.LastYearInThisEra;
			val = Math.Min(num3, Math.Max(num2, val));
			m_tpCalendar.Year = val;
		}
		if (flag3)
		{
			int num4 = 0;
			int num5 = 0;
			num4 = m_tpCalendar.FirstMonthInThisYear;
			num5 = m_tpCalendar.LastMonthInThisYear;
			val2 = Math.Min(num5, Math.Max(num4, val2));
			m_tpCalendar.Month = val2;
		}
		if (flag4)
		{
			int num6 = 0;
			int num7 = 0;
			num6 = m_tpCalendar.FirstDayInThisMonth;
			num7 = m_tpCalendar.LastDayInThisMonth;
			val3 = Math.Min(num7, Math.Max(num6, val3));
			m_tpCalendar.Day = val3;
		}
		target = m_tpCalendar.GetDateTime();
		CoerceDate(ref target);
	}

	internal static void CanPanelShowFullScope(CalendarViewGeneratorHost pHost, out bool pCanPanelShowFullScope)
	{
		CalendarPanel panel = pHost.Panel;
		int num = 0;
		int num2 = 0;
		pCanPanelShowFullScope = false;
		num = panel.Rows;
		num2 = panel.Cols;
		pCanPanelShowFullScope = (num - 1) * num2 + 1 >= pHost.GetMaximumScopeSize();
	}

	private void ForeachChildInPanel(CalendarPanel pCalendarPanel, Action<CalendarViewBaseItem> func)
	{
		if (pCalendarPanel != null && pCalendarPanel.IsInLiveTree)
		{
			int num = 0;
			int num2 = 0;
			num = pCalendarPanel.FirstCacheIndex;
			num2 = pCalendarPanel.LastCacheIndex;
			for (int i = num; i <= num2; i++)
			{
				DependencyObject dependencyObject = pCalendarPanel.ContainerFromIndex(i);
				CalendarViewBaseItem obj = dependencyObject as CalendarViewBaseItem;
				func(obj);
			}
		}
	}

	private void ForeachHost(Action<CalendarViewGeneratorHost> func)
	{
		func(m_tpMonthViewItemHost);
		func(m_tpYearViewItemHost);
		func(m_tpDecadeViewItemHost);
	}

	internal static void SetDayItemStyle(CalendarViewBaseItem pItem, Style pStyle)
	{
		if (pStyle != null)
		{
			pItem.Style = pStyle;
		}
		else
		{
			pItem.ClearValue(FrameworkElement.StyleProperty);
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		AutomationPeer automationPeer = null;
		return new CalendarViewAutomationPeer(this);
	}

	private protected override void OnIsEnabledChanged(IsEnabledChangedEventArgs pArgs)
	{
		UpdateVisualState();
	}

	internal void GetRowHeaderForItemAutomationPeer(DateTimeOffset itemDate, CalendarViewDisplayMode displayMode, out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
	{
		pReturnValueCount = 0u;
		ppReturnValue = null;
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		calendarViewDisplayMode = DisplayMode;
		if (displayMode == calendarViewDisplayMode)
		{
			m_tpCalendar.SetDateTime(itemDate);
			int month = m_tpCalendar.Month;
			int year = m_tpCalendar.Year;
			bool flag = m_currentHeaderPeer != null && (m_currentHeaderPeer.GetMonth() == month || calendarViewDisplayMode == CalendarViewDisplayMode.Year) && m_currentHeaderPeer.GetYear() == year && m_currentHeaderPeer.GetMode() == calendarViewDisplayMode;
			bool flag2 = m_previousHeaderPeer != null && (m_previousHeaderPeer.GetMonth() == month || calendarViewDisplayMode == CalendarViewDisplayMode.Year) && m_previousHeaderPeer.GetYear() == year && m_previousHeaderPeer.GetMode() == calendarViewDisplayMode;
			if (!flag && !flag2)
			{
				CalendarViewHeaderAutomationPeer calendarViewHeaderAutomationPeer = new CalendarViewHeaderAutomationPeer();
				string name = ((calendarViewDisplayMode != 0) ? FormatYearName(itemDate) : FormatMonthYearName(itemDate));
				calendarViewHeaderAutomationPeer.Initialize(name, month, year, calendarViewDisplayMode);
				m_previousHeaderPeer = m_currentHeaderPeer;
				m_currentHeaderPeer = calendarViewHeaderAutomationPeer;
			}
			CalendarViewHeaderAutomationPeer calendarViewHeaderAutomationPeer2 = (flag2 ? m_previousHeaderPeer : m_currentHeaderPeer);
			IRawElementProviderSimple rawElementProviderSimple = calendarViewHeaderAutomationPeer2.ProviderFromPeer(calendarViewHeaderAutomationPeer2);
			ppReturnValue = new IRawElementProviderSimple[1] { rawElementProviderSimple };
			pReturnValueCount = 1u;
		}
	}

	private void UpdateFlowDirectionForView()
	{
		if (m_tpViewsGrid != null && m_tpMonthYearFormatter != null)
		{
			bool flag = false;
			IReadOnlyList<string> patterns = m_tpMonthYearFormatter.Patterns;
			string text = patterns[0];
			if (text != null)
			{
				string text2 = text;
				flag = text2[0] == '與';
			}
			FlowDirection flowDirection = (flag ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			m_tpViewsGrid.FlowDirection = flowDirection;
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		bool flag = false;
		bool flag2 = false;
		VirtualKey virtualKey = VirtualKey.None;
		VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
		base.OnKeyDown(pArgs);
		m_wrKeyDownEventArgsFromCalendarItem.TryGetTarget(out var target);
		if (target == null)
		{
			return;
		}
		if (target != pArgs)
		{
			m_wrKeyDownEventArgsFromCalendarItem.SetTarget(null);
		}
		else
		{
			if (pArgs.Handled)
			{
				return;
			}
			virtualKeyModifiers = pArgs.KeyboardModifiers;
			virtualKey = pArgs.Key;
			if (virtualKey == VirtualKey.GamepadLeftTrigger)
			{
				virtualKey = VirtualKey.PageUp;
			}
			if (virtualKey == VirtualKey.GamepadRightTrigger)
			{
				virtualKey = VirtualKey.PageDown;
			}
			switch (virtualKeyModifiers)
			{
			case VirtualKeyModifiers.None:
				if ((uint)(virtualKey - 30) <= 7u)
				{
					VirtualKey virtualKey2 = VirtualKey.None;
					virtualKey2 = pArgs.OriginalKey;
					flag2 = OnKeyboardNavigation(virtualKey, virtualKey2);
				}
				break;
			case VirtualKeyModifiers.Control:
			{
				if (virtualKey != VirtualKey.Up && virtualKey != VirtualKey.Down)
				{
					break;
				}
				CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
				calendarViewDisplayMode = DisplayMode;
				CalendarViewDisplayMode calendarViewDisplayMode2 = calendarViewDisplayMode;
				switch (calendarViewDisplayMode)
				{
				case CalendarViewDisplayMode.Month:
					if (virtualKey == VirtualKey.Up)
					{
						calendarViewDisplayMode2 = CalendarViewDisplayMode.Year;
					}
					break;
				case CalendarViewDisplayMode.Year:
					calendarViewDisplayMode2 = ((virtualKey == VirtualKey.Up) ? CalendarViewDisplayMode.Decade : CalendarViewDisplayMode.Month);
					break;
				case CalendarViewDisplayMode.Decade:
					if (virtualKey == VirtualKey.Down)
					{
						calendarViewDisplayMode2 = CalendarViewDisplayMode.Year;
					}
					break;
				}
				if (calendarViewDisplayMode2 != calendarViewDisplayMode)
				{
					flag2 = true;
					m_focusItemAfterDisplayModeChanged = true;
					m_focusStateAfterDisplayModeChanged = FocusState.Keyboard;
					DisplayMode = calendarViewDisplayMode2;
				}
				break;
			}
			}
			if (flag2)
			{
				pArgs.Handled = true;
			}
		}
	}

	private bool OnKeyboardNavigation(VirtualKey key, VirtualKey originalKey)
	{
		GetActiveGeneratorHost(out var ppHost);
		bool pFocused = false;
		CalendarPanel panel = ppHost.Panel;
		if (panel != null)
		{
			int num = -1;
			num = ppHost.CalculateOffsetFromMinDate(m_lastDisplayedDate);
			int num2 = num;
			DateTimeOffset dateTimeOffset;
			DateTimeOffset date;
			switch (key)
			{
			case VirtualKey.End:
				dateTimeOffset = ppHost.GetMaxDateOfCurrentScope();
				goto IL_006a;
			case VirtualKey.Home:
				dateTimeOffset = ppHost.GetMinDateOfCurrentScope();
				goto IL_006a;
			case VirtualKey.PageUp:
			case VirtualKey.PageDown:
			{
				DateTimeOffset date2 = m_lastDisplayedDate;
				try
				{
					ppHost.AddScopes(date2, (key != VirtualKey.PageUp) ? 1 : (-1));
					CoerceDate(ref date2);
					num2 = ppHost.CalculateOffsetFromMinDate(date2);
				}
				catch
				{
					if (key == VirtualKey.PageUp)
					{
						num2 = 0;
						break;
					}
					uint num3 = 0u;
					num3 = ppHost.Size();
					num2 = (int)(num3 - 1);
				}
				break;
			}
			case VirtualKey.Left:
			case VirtualKey.Up:
			case VirtualKey.Right:
			case VirtualKey.Down:
				{
					KeyNavigationAction pNavAction = KeyNavigationAction.Up;
					uint newFocusedIndexUint = 0u;
					ElementType newFocusedType = ElementType.ItemContainer;
					bool pIsValidKey = false;
					bool actionValidForSourceIndex = false;
					TranslateKeyToKeyNavigationAction(key, out pNavAction, out pIsValidKey);
					panel.GetTargetIndexFromNavigationAction(num, ElementType.ItemContainer, pNavAction, false, -1, out newFocusedIndexUint, out newFocusedType, out actionValidForSourceIndex);
					if (actionValidForSourceIndex)
					{
						num2 = (int)newFocusedIndexUint;
					}
					break;
				}
				IL_006a:
				date = dateTimeOffset;
				num2 = ppHost.CalculateOffsetFromMinDate(date);
				break;
			}
			if (num2 != num)
			{
				FocusItemByIndex(ppHost, num2, FocusState.Keyboard, out pFocused);
			}
		}
		return pFocused;
	}

	private void TranslateKeyToKeyNavigationAction(VirtualKey key, out KeyNavigationAction pNavAction, out bool pIsValidKey)
	{
		FlowDirection flowDirection = FlowDirection.LeftToRight;
		pIsValidKey = false;
		pNavAction = KeyNavigationAction.Up;
		flowDirection = ((m_tpViewsGrid == null) ? base.FlowDirection : m_tpViewsGrid.FlowDirection);
		KeyboardNavigation.TranslateKeyToKeyNavigationAction(flowDirection, key, out pNavAction, out pIsValidKey);
	}

	internal void OnItemFocused(CalendarViewBaseItem pItem)
	{
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		DateTimeOffset dateBase = pItem.DateBase;
		calendarViewDisplayMode = DisplayMode;
		CopyDate(calendarViewDisplayMode, dateBase, ref m_lastDisplayedDate);
	}

	private void FocusItemByIndex(CalendarViewGeneratorHost pHost, int index, FocusState focusState, out bool pFocused)
	{
		pFocused = false;
		DateTimeOffset dateAt = pHost.GetDateAt((uint)index);
		FocusItem(pHost, dateAt, index, focusState, out pFocused);
	}

	private void FocusItemByDate(CalendarViewGeneratorHost pHost, DateTimeOffset date, FocusState focusState, out bool pFocused)
	{
		int num = -1;
		pFocused = false;
		num = pHost.CalculateOffsetFromMinDate(date);
		FocusItem(pHost, date, num, focusState, out pFocused);
	}

	private void FocusItem(CalendarViewGeneratorHost pHost, DateTimeOffset date, int index, FocusState focusState, out bool pFocused)
	{
		pFocused = false;
		SetDisplayDateInternal(date);
		DependencyObject dependencyObject = pHost.Panel.ContainerFromIndex(index);
		if (dependencyObject != null)
		{
			CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)dependencyObject;
			pFocused = calendarViewBaseItem.FocusSelfOrChild(focusState);
		}
	}

	private void ProcessCandidateTabStopOverride(DependencyObject pFocusedElement, DependencyObject pCandidateTabStopElement, DependencyObject pOverriddenCandidateTabStopElement, bool isBackward, out DependencyObject ppNewTabStop, out bool pIsCandidateTabStopOverridden)
	{
		CalendarViewBaseItem calendarViewBaseItem = pCandidateTabStopElement as CalendarViewBaseItem;
		ppNewTabStop = null;
		pIsCandidateTabStopOverridden = false;
		if (calendarViewBaseItem == null)
		{
			return;
		}
		CalendarViewBaseItem calendarViewBaseItem2 = pFocusedElement as CalendarViewBaseItem;
		if (calendarViewBaseItem2 != null)
		{
			return;
		}
		GetActiveGeneratorHost(out var ppHost);
		ScrollViewer scrollViewer = ppHost.ScrollViewer;
		if (scrollViewer == null)
		{
			return;
		}
		KeyboardNavigationMode keyboardNavigationMode = KeyboardNavigationMode.Local;
		keyboardNavigationMode = scrollViewer.TabNavigation;
		if (keyboardNavigationMode != KeyboardNavigationMode.Once)
		{
			return;
		}
		bool flag = false;
		if (scrollViewer.IsAncestorOf(pCandidateTabStopElement))
		{
			CalendarPanel panel = ppHost.Panel;
			if (panel != null)
			{
				int num = -1;
				GetActiveGeneratorHost(out ppHost);
				num = ppHost.CalculateOffsetFromMinDate(m_lastDisplayedDate);
				panel.ScrollItemIntoView(num, ScrollIntoViewAlignment.Default, 0.0, forceSynchronous: true);
				DependencyObject dependencyObject = (ppNewTabStop = panel.ContainerFromIndex(num));
				pIsCandidateTabStopOverridden = true;
			}
		}
	}

	private CalendarViewDayItem GetContainerByDate(DateTimeOffset datetime)
	{
		CalendarViewDayItem result = null;
		CalendarPanel panel = m_tpMonthViewItemHost.Panel;
		if (panel != null)
		{
			int num = -1;
			num = m_tpMonthViewItemHost.CalculateOffsetFromMinDate(datetime);
			if (num >= 0)
			{
				DependencyObject dependencyObject = panel.ContainerFromIndex(num);
				if (dependencyObject != null)
				{
					CalendarViewDayItem calendarViewDayItem = (CalendarViewDayItem)dependencyObject;
					result = calendarViewDayItem;
				}
			}
		}
		return result;
	}

	internal void OnSelectDayItem(CalendarViewDayItem pItem)
	{
		try
		{
			CalendarViewSelectionMode calendarViewSelectionMode = CalendarViewSelectionMode.None;
			calendarViewSelectionMode = SelectionMode;
			if (calendarViewSelectionMode == CalendarViewSelectionMode.None)
			{
				return;
			}
			bool flag = false;
			if (pItem.IsBlackout)
			{
				return;
			}
			uint num = 0u;
			uint index = 0u;
			bool flag2 = false;
			num = m_tpSelectedDates.Size;
			m_isSelectedDatesChangingInternally = true;
			DateTimeOffset date = pItem.Date;
			if (m_tpSelectedDates.IndexOf(date, out index))
			{
				m_tpSelectedDates.RemoveAll(date);
			}
			else
			{
				if (calendarViewSelectionMode == CalendarViewSelectionMode.Single && num == 1)
				{
					m_tpSelectedDates.Clear();
				}
				m_tpSelectedDates.Append(date);
			}
			RaiseSelectionChangedEventIfChanged();
		}
		finally
		{
			m_isSelectedDatesChangingInternally = false;
		}
	}

	internal void OnSelectMonthYearItem(CalendarViewItem pItem, FocusState focusState)
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		CalendarViewDisplayMode calendarViewDisplayMode = CalendarViewDisplayMode.Month;
		calendarViewDisplayMode = DisplayMode;
		dateTimeOffset = pItem.DateBase;
		m_focusStateAfterDisplayModeChanged = focusState;
		if (calendarViewDisplayMode == CalendarViewDisplayMode.Year && m_tpMonthViewItemHost.Panel != null)
		{
			CopyDate(calendarViewDisplayMode, dateTimeOffset, ref m_lastDisplayedDate);
			DisplayMode = CalendarViewDisplayMode.Month;
		}
		else if (calendarViewDisplayMode == CalendarViewDisplayMode.Decade && m_tpYearViewItemHost.Panel != null)
		{
			CopyDate(calendarViewDisplayMode, dateTimeOffset, ref m_lastDisplayedDate);
			DisplayMode = CalendarViewDisplayMode.Year;
		}
	}

	private void OnSelectionModeChanged()
	{
		CalendarViewSelectionMode calendarViewSelectionMode = CalendarViewSelectionMode.None;
		calendarViewSelectionMode = SelectionMode;
		try
		{
			m_isSelectedDatesChangingInternally = true;
			switch (calendarViewSelectionMode)
			{
			case CalendarViewSelectionMode.None:
				m_tpSelectedDates.Clear();
				break;
			case CalendarViewSelectionMode.Single:
			{
				int num = 0;
				for (num = m_tpSelectedDates.Count; num > 1; num--)
				{
					m_tpSelectedDates.RemoveAt(num - 1);
				}
				break;
			}
			}
			RaiseSelectionChangedEventIfChanged();
		}
		finally
		{
			m_isSelectedDatesChangingInternally = false;
		}
	}

	private void RaiseSelectionChangedEventIfChanged()
	{
		Func<DateTimeOffset, DateTimeOffset, bool> lessThanComparer = m_dateComparer.LessThanComparer;
		TrackableDateCollection.DateSetType dateSetType = new TrackableDateCollection.DateSetType(lessThanComparer);
		TrackableDateCollection.DateSetType dateSetType2 = new TrackableDateCollection.DateSetType(lessThanComparer);
		TrackableDateCollection tpSelectedDates = m_tpSelectedDates;
		tpSelectedDates.FetchAndResetChange(dateSetType, dateSetType2);
		if (dateSetType.Count == 1)
		{
			uint pCount = 0u;
			DateTimeOffset dateTimeOffset = dateSetType.First();
			tpSelectedDates.CountOf(dateTimeOffset, out pCount);
			switch (pCount)
			{
			default:
				dateSetType.Remove(dateTimeOffset);
				break;
			case 1u:
				GetContainerByDate(dateTimeOffset)?.SetIsSelected(state: true);
				break;
			case 0u:
				break;
			}
		}
		if (dateSetType2.Count > 0)
		{
			uint num = 0u;
			num = tpSelectedDates.Size;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				DateTimeOffset dateTimeOffset2 = default(DateTimeOffset);
				dateTimeOffset2 = tpSelectedDates.GetAt(num2);
				dateSetType2.Remove(dateTimeOffset2);
			}
			foreach (DateTimeOffset item in dateSetType2)
			{
				GetContainerByDate(item)?.SetIsSelected(state: false);
			}
		}
		m_isSelectedDatesChangingInternally = false;
		if (dateSetType.Empty() && dateSetType2.Empty())
		{
			return;
		}
		TypedEventHandler<CalendarView, CalendarViewSelectedDatesChangedEventArgs> ppEventSource = null;
		ValueTypeCollection<DateTimeOffset> valueTypeCollection = new ValueTypeCollection<DateTimeOffset>();
		ValueTypeCollection<DateTimeOffset> valueTypeCollection2 = new ValueTypeCollection<DateTimeOffset>();
		foreach (DateTimeOffset item2 in dateSetType)
		{
			valueTypeCollection.Append(item2);
		}
		foreach (DateTimeOffset item3 in dateSetType2)
		{
			valueTypeCollection2.Append(item3);
		}
		CalendarViewSelectedDatesChangedEventArgs calendarViewSelectedDatesChangedEventArgs = new CalendarViewSelectedDatesChangedEventArgs();
		calendarViewSelectedDatesChangedEventArgs.AddedDates = valueTypeCollection;
		calendarViewSelectedDatesChangedEventArgs.RemovedDates = valueTypeCollection2;
		GetSelectedDatesChangedEventSourceNoRef(out ppEventSource);
		ppEventSource?.Invoke(this, calendarViewSelectedDatesChangedEventArgs);
		if (false)
		{
			AutomationPeer automationPeer = GetAutomationPeer();
			if (automationPeer != null)
			{
				(automationPeer as CalendarViewAutomationPeer).RaiseSelectionEvents(calendarViewSelectedDatesChangedEventArgs);
			}
		}
	}

	internal void OnDayItemBlackoutChanged(CalendarViewDayItem pItem, bool isBlackOut)
	{
		try
		{
			if (isBlackOut)
			{
				uint index = 0u;
				bool found = false;
				DateTimeOffset date = pItem.Date;
				m_tpSelectedDates.IndexOf(date, out index, out found);
				if (found)
				{
					m_isSelectedDatesChangingInternally = true;
					m_tpSelectedDates.RemoveAll(date);
					RaiseSelectionChangedEventIfChanged();
				}
			}
		}
		finally
		{
			m_isSelectedDatesChangingInternally = false;
		}
	}

	internal void IsSelected(DateTimeOffset date, out bool pIsSelected)
	{
		uint index = 0u;
		bool flag = false;
		flag = (pIsSelected = m_tpSelectedDates.IndexOf(date, out index));
	}

	private void OnSelectedDatesChanged(IObservableVector<DateTimeOffset> pSender, IVectorChangedEventArgs e)
	{
		if (!m_isSelectedDatesChangingInternally)
		{
			RaiseSelectionChangedEventIfChanged();
		}
	}

	private void OnSelectedDatesChanging(TrackableDateCollection.CollectionChanging action, DateTimeOffset addingDate)
	{
		switch (action)
		{
		case TrackableDateCollection.CollectionChanging.ItemInserting:
		{
			ValidateSelectingDateIsNotBlackout(addingDate);
			uint num = 0u;
			CalendarViewSelectionMode calendarViewSelectionMode = CalendarViewSelectionMode.None;
			calendarViewSelectionMode = SelectionMode;
			num = (uint)m_tpSelectedDates.Count;
			if ((calendarViewSelectionMode == CalendarViewSelectionMode.Single && num != 0) || calendarViewSelectionMode == CalendarViewSelectionMode.None)
			{
				throw new InvalidOperationException("ERROR_CALENDAR_CANNOT_SELECT_MORE_DATES");
			}
			break;
		}
		case TrackableDateCollection.CollectionChanging.ItemChanging:
			ValidateSelectingDateIsNotBlackout(addingDate);
			break;
		}
	}

	private void ValidateSelectingDateIsNotBlackout(DateTimeOffset date)
	{
		CalendarViewDayItem containerByDate = GetContainerByDate(date);
		if (containerByDate != null)
		{
			bool flag = false;
			if (containerByDate.IsBlackout)
			{
				throw new InvalidOperationException("ERROR_CALENDAR_CANNOT_SELECT_BLACKOUT_DATE");
			}
		}
	}

	private void InitializeIndexCorrectionTableIfNeeded()
	{
		CalendarPanel panel = m_tpMonthViewItemHost.Panel;
		if (panel == null)
		{
			return;
		}
		TimeZoneInfo timeZoneInfo = null;
		TimeZoneInfo timeZoneInfo2 = (timeZoneInfo = TimeZoneInfo.Local);
		uint index = 0u;
		uint correction = 0u;
		if (timeZoneInfo2 != null && timeZoneInfo2.Id != null && StringComparer.InvariantCultureIgnoreCase.Compare(timeZoneInfo.StandardName, "Samoa Standard Time") == 0)
		{
			bool flag = false;
			try
			{
				m_tpCalendar.Year = 2012;
				m_tpCalendar.Month = 1;
				m_tpCalendar.Day = 2;
				flag = true;
			}
			catch
			{
			}
			if (flag)
			{
				int num = -1;
				DateTimeOffset dateTime = m_tpCalendar.GetDateTime();
				num = m_tpMonthViewItemHost.CalculateOffsetFromMinDate(dateTime);
				if (num > 0)
				{
					index = (uint)num;
					correction = 1u;
				}
			}
		}
		ILayoutStrategy layoutStrategy = panel.LayoutStrategy;
		(layoutStrategy as CalendarLayoutStrategy).GetIndexCorrectionTable().SetCorrectionEntryForSkippedDay((int)index, (int)correction);
	}
}
