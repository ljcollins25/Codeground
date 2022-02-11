using System;
using System.Collections.Generic;
using System.Linq;
using DirectUI;
using Uno;
using Uno.UI.Xaml.Core;
using Windows.Foundation.Metadata;
using Windows.Globalization;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

public class CalendarViewDayItem : CalendarViewBaseItem
{
	internal class CalendarViewDayItemAutomationPeer : CalendarViewBaseItemAutomationPeer
	{
		private bool IsSelectedImpl
		{
			get
			{
				bool result = false;
				UIElement owner = base.Owner;
				DateTimeOffset date = (owner as CalendarViewDayItem).Date;
				bool pIsSelected = false;
				CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
				parentCalendarView.IsSelected(date, out pIsSelected);
				if (pIsSelected)
				{
					result = true;
				}
				return result;
			}
		}

		private int ColumnImpl
		{
			get
			{
				int num = 0;
				UIElement owner = base.Owner;
				DateTimeOffset date = (owner as CalendarViewDayItem).Date;
				CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
				parentCalendarView.GetActiveGeneratorHost(out var ppHost);
				CalendarPanel panel = ppHost.Panel;
				if (panel != null)
				{
					int num2 = 0;
					num2 = ppHost.CalculateOffsetFromMinDate(date);
					int num3 = 1;
					num3 = panel.Cols;
					int num4 = 0;
					num4 = panel.FirstVisibleIndex;
					int num5 = num2 - num4;
					if (num4 < num3)
					{
						int num6 = 0;
						num6 = panel.StartIndex;
						num5 += num6;
					}
					num = num5 % num3;
					if (num < 0)
					{
						num += num3;
					}
				}
				return num;
			}
		}

		private int RowImpl
		{
			get
			{
				int num = 0;
				UIElement owner = base.Owner;
				DateTimeOffset date = (owner as CalendarViewDayItem).Date;
				CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
				parentCalendarView.GetActiveGeneratorHost(out var ppHost);
				CalendarPanel panel = ppHost.Panel;
				if (panel != null)
				{
					int num2 = 0;
					num2 = ppHost.CalculateOffsetFromMinDate(date);
					int num3 = 1;
					num3 = panel.Cols;
					int num4 = 0;
					num4 = panel.FirstVisibleIndex;
					Windows.Globalization.DayOfWeek dayOfWeek = Windows.Globalization.DayOfWeek.Sunday;
					dayOfWeek = parentCalendarView.FirstDayOfWeek;
					int num5 = num2 - num4;
					if (num4 < num3)
					{
						int num6 = 0;
						num6 = panel.StartIndex;
						num5 += num6;
					}
					num = num5 / num3;
					if (num < 0)
					{
						throw new NotSupportedException();
					}
				}
				return num;
			}
		}

		public CalendarViewDayItemAutomationPeer(CalendarViewDayItem owner)
			: base(owner)
		{
		}

		protected override object GetPatternCore(PatternInterface patternInterface)
		{
			object obj = null;
			if (patternInterface == PatternInterface.TableItem || patternInterface == PatternInterface.SelectionItem)
			{
				return this;
			}
			return base.GetPatternCore(patternInterface);
		}

		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.DataItem;
		}

		protected override string GetClassNameCore()
		{
			return "CalendarViewDayItem";
		}

		protected override bool IsEnabledCore()
		{
			UIElement owner = base.Owner;
			bool flag = false;
			if (((CalendarViewDayItem)owner).IsBlackout)
			{
				return false;
			}
			return base.IsEnabledCore();
		}

		private void GetColumnHeaderItemsImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			pReturnValueCount = 0u;
			ppReturnValue = null;
			UIElement owner = base.Owner;
			DateTimeOffset date = ((CalendarViewDayItem)owner).Date;
			CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
			uint num = 0u;
			if (!(parentCalendarView.GetTemplateChild("WeekDayNames") is Grid grid))
			{
				return;
			}
			IList<UIElement> children = grid.Children;
			num = (uint)children.Count;
			int num2 = 0;
			num2 = ColumnImpl;
			UIElement uIElement = children.ElementAtOrDefault(num2);
			if (uIElement != null)
			{
				AutomationPeer automationPeer = (uIElement as FrameworkElement).GetAutomationPeer();
				if (automationPeer != null)
				{
					ppReturnValue = new IRawElementProviderSimple[1];
					IRawElementProviderSimple rawElementProviderSimple = ProviderFromPeer(automationPeer);
					ppReturnValue[0] = rawElementProviderSimple;
					pReturnValueCount = 1u;
				}
			}
		}

		private void GetRowHeaderItemsImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			UIElement owner = base.Owner;
			CalendarViewDayItem calendarViewDayItem = owner as CalendarViewDayItem;
			CalendarView parentCalendarView = calendarViewDayItem.GetParentCalendarView();
			DateTimeOffset date = calendarViewDayItem.Date;
			parentCalendarView.GetRowHeaderForItemAutomationPeer(date, CalendarViewDisplayMode.Month, out pReturnValueCount, out ppReturnValue);
		}

		private void SelectionContainerImpl(out IRawElementProviderSimple ppValue)
		{
			ppValue = ContainingGridImpl();
		}

		private void AddToSelectionImpl()
		{
			UIElement owner = base.Owner;
			DateTimeOffset date = (owner as CalendarViewDayItem).Date;
			CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
			bool pIsSelected = false;
			parentCalendarView.IsSelected(date, out pIsSelected);
			if (!pIsSelected)
			{
				parentCalendarView.OnSelectDayItem(owner as CalendarViewDayItem);
			}
		}

		private void RemoveFromSelectionImpl()
		{
			UIElement owner = base.Owner;
			DateTimeOffset date = (owner as CalendarViewDayItem).Date;
			CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
			bool pIsSelected = false;
			parentCalendarView.IsSelected(date, out pIsSelected);
			if (pIsSelected)
			{
				parentCalendarView.OnSelectDayItem(owner as CalendarViewDayItem);
			}
		}

		private void SelectImpl()
		{
			UIElement owner = base.Owner;
			DateTimeOffset date = (owner as CalendarViewDayItem).Date;
			CalendarView parentCalendarView = (owner as CalendarViewDayItem).GetParentCalendarView();
			IList<DateTimeOffset> selectedDates = parentCalendarView.SelectedDates;
			selectedDates.Clear();
			parentCalendarView.OnSelectDayItem(owner as CalendarViewDayItem);
		}
	}

	private CalendarViewDayItemChangingEventArgs m_tpBuildTreeArgs;

	public bool IsBlackout
	{
		get
		{
			return (bool)GetValue(IsBlackoutProperty);
		}
		set
		{
			SetValue(IsBlackoutProperty, value);
		}
	}

	internal override DateTimeOffset DateBase
	{
		get
		{
			return Date;
		}
		set
		{
			Date = value;
		}
	}

	public DateTimeOffset Date
	{
		get
		{
			return (DateTimeOffset)GetValue(DateProperty);
		}
		internal set
		{
			SetValue(DateProperty, value);
		}
	}

	public static DependencyProperty DateProperty { get; } = DependencyProperty.Register("Date", typeof(DateTimeOffset), typeof(CalendarViewDayItem), new FrameworkPropertyMetadata(default(DateTimeOffset)));


	public static DependencyProperty IsBlackoutProperty { get; } = DependencyProperty.Register("IsBlackout", typeof(bool), typeof(CalendarViewDayItem), new FrameworkPropertyMetadata(false));


	private protected override bool GetTextBlockFontProperties(bool isLabel, out TextBlockFontProperties pProperties)
	{
		pProperties = default(TextBlockFontProperties);
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			pProperties.fontSize = (isLabel ? owner.m_firstOfMonthLabelFontSize : owner.m_dayItemFontSize);
			pProperties.fontStyle = (isLabel ? owner.m_firstOfMonthLabelFontStyle : owner.m_dayItemFontStyle);
			if (isLabel)
			{
				pProperties.fontWeight = owner.m_firstOfMonthLabelFontWeight;
			}
			else if (m_isToday)
			{
				pProperties.fontWeight = owner.m_todayFontWeight;
			}
			else
			{
				pProperties.fontWeight = owner.m_dayItemFontWeight;
			}
			pProperties.pFontFamilyNoRef = (isLabel ? owner.m_pFirstOfMonthLabelFontFamily : owner.m_pDayItemFontFamily);
		}
		return owner != null;
	}

	private protected override bool GetTextBlockAlignments(bool isLabel, out TextBlockAlignments pProperties)
	{
		pProperties = default(TextBlockAlignments);
		CalendarView owner = GetOwner();
		if (owner != null)
		{
			pProperties.horizontalAlignment = (isLabel ? owner.m_horizontalFirstOfMonthLabelAlignment : owner.m_horizontalDayItemAlignment);
			pProperties.verticalAlignment = (isLabel ? owner.m_verticalFirstOfMonthLabelAlignment : owner.m_verticalDayItemAlignment);
		}
		return owner != null;
	}

	private protected override CornerRadius GetItemCornerRadius()
	{
		return GetOwner()?.m_dayItemCornerRadius ?? CornerRadius.None;
	}

	internal override void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
		base.OnPropertyChanged2(args);
		if (args.Property == IsBlackoutProperty)
		{
			bool flag = false;
			flag = (bool)args.NewValue;
			SetIsBlackout(flag);
			if (flag)
			{
				GetParentCalendarView()?.OnDayItemBlackoutChanged(this, flag);
			}
		}
	}

	private void SetDensityColorsImpl(IIterable<Color> pColors)
	{
		GetHandle().SetDensityColors(pColors);
	}

	internal CalendarViewDayItemChangingEventArgs GetBuildTreeArgs()
	{
		if (m_tpBuildTreeArgs == null)
		{
			return m_tpBuildTreeArgs = new CalendarViewDayItemChangingEventArgs();
		}
		return m_tpBuildTreeArgs;
	}

	protected override void OnTapped(TappedRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnTapped(pArgs);
		if (!pArgs.Handled)
		{
			CalendarView parentCalendarView = GetParentCalendarView();
			if (parentCalendarView != null)
			{
				bool flag2 = false;
				flag2 = FocusSelfOrChild(FocusState.Pointer);
				parentCalendarView.OnSelectDayItem(this);
				pArgs.Handled = true;
				ElementSoundPlayerService elementSoundPlayerServiceNoRef = DXamlCore.Current.GetElementSoundPlayerServiceNoRef();
				elementSoundPlayerServiceNoRef.RequestInteractionSoundForElement(ElementSoundKind.Invoke, this);
			}
		}
	}

	protected override void OnKeyDown(KeyRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnKeyDown(pArgs);
		if (pArgs.Handled)
		{
			return;
		}
		CalendarView parentCalendarView = GetParentCalendarView();
		if (parentCalendarView != null)
		{
			VirtualKey virtualKey = VirtualKey.None;
			virtualKey = pArgs.Key;
			if (virtualKey == VirtualKey.Space || virtualKey == VirtualKey.Enter)
			{
				parentCalendarView.OnSelectDayItem(this);
				pArgs.Handled = true;
				SetIsKeyboardFocused(state: true);
				ElementSoundPlayerService elementSoundPlayerServiceNoRef = DXamlCore.Current.GetElementSoundPlayerServiceNoRef();
				elementSoundPlayerServiceNoRef.RequestInteractionSoundForElement(ElementSoundKind.Invoke, this);
			}
			else
			{
				parentCalendarView.SetKeyDownEventArgsFromCalendarItem(pArgs);
			}
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		AutomationPeer automationPeer = null;
		return new CalendarViewDayItemAutomationPeer(this);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetDensityColors(IEnumerable<Color> colors)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.CalendarViewDayItem", "void CalendarViewDayItem.SetDensityColors(IEnumerable<Color> colors)");
	}
}
