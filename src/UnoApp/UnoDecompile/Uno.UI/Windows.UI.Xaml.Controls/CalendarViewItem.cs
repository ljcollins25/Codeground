using System;
using DirectUI;
using Uno.UI.Xaml.Core;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Windows.UI.Xaml.Controls;

internal class CalendarViewItem : CalendarViewBaseItem
{
	internal class CalendarViewItemAutomationPeer : CalendarViewBaseItemAutomationPeer
	{
		internal CalendarViewItemAutomationPeer(CalendarViewItem owner)
			: base(owner)
		{
		}

		protected override object GetPatternCore(PatternInterface patternInterface)
		{
			object obj = null;
			if (patternInterface == PatternInterface.Invoke || patternInterface == PatternInterface.TableItem)
			{
				return this;
			}
			return base.GetPatternCore(patternInterface);
		}

		protected override string GetClassNameCore()
		{
			return "CalendarViewItem";
		}

		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Button;
		}

		private void InvokeImpl()
		{
			UIElement owner = base.Owner;
			CalendarView parentCalendarView = (owner as CalendarViewItem).GetParentCalendarView();
			parentCalendarView.OnSelectMonthYearItem(owner as CalendarViewItem, FocusState.Keyboard);
		}

		private int ColumnImpl()
		{
			int num = 0;
			UIElement owner = base.Owner;
			DateTimeOffset dateBase = (owner as CalendarViewItem).DateBase;
			CalendarView parentCalendarView = (owner as CalendarViewItem).GetParentCalendarView();
			parentCalendarView.GetActiveGeneratorHost(out var ppHost);
			CalendarPanel panel = ppHost.Panel;
			if (panel != null)
			{
				int num2 = 0;
				num2 = ppHost.CalculateOffsetFromMinDate(dateBase);
				int num3 = 1;
				num3 = panel.Cols;
				int num4 = 0;
				num4 = panel.FirstVisibleIndex;
				num = (num2 - num4) % num3;
				if (num < 0)
				{
					num += num3;
				}
			}
			return num;
		}

		private int RowImpl()
		{
			int num = 0;
			UIElement owner = base.Owner;
			DateTimeOffset dateBase = (owner as CalendarViewItem).DateBase;
			CalendarView parentCalendarView = (owner as CalendarViewItem).GetParentCalendarView();
			parentCalendarView.GetActiveGeneratorHost(out var ppHost);
			CalendarPanel panel = ppHost.Panel;
			if (panel != null)
			{
				int num2 = 0;
				num2 = ppHost.CalculateOffsetFromMinDate(dateBase);
				int num3 = 1;
				num3 = panel.Cols;
				int num4 = 0;
				num4 = panel.FirstVisibleIndex;
				num = (num2 - num4) / num3;
				if (num < 0)
				{
					throw new NotSupportedException();
				}
			}
			return num;
		}

		private void GetColumnHeaderItemsImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			pReturnValueCount = 0u;
			ppReturnValue = null;
		}

		private void GetRowHeaderItemsImpl(out uint pReturnValueCount, out IRawElementProviderSimple[] ppReturnValue)
		{
			UIElement owner = base.Owner;
			CalendarViewItem calendarViewItem = owner as CalendarViewItem;
			CalendarView parentCalendarView = calendarViewItem.GetParentCalendarView();
			DateTimeOffset dateBase = calendarViewItem.DateBase;
			parentCalendarView.GetRowHeaderForItemAutomationPeer(dateBase, CalendarViewDisplayMode.Year, out pReturnValueCount, out ppReturnValue);
		}
	}

	internal override DateTimeOffset DateBase { get; set; }

	protected override void OnTapped(TappedRoutedEventArgs pArgs)
	{
		bool flag = false;
		base.OnTapped(pArgs);
		if (!pArgs.Handled)
		{
			CalendarView parentCalendarView = GetParentCalendarView();
			if (parentCalendarView != null)
			{
				parentCalendarView.OnSelectMonthYearItem(this, FocusState.Pointer);
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
				parentCalendarView.OnSelectMonthYearItem(this, FocusState.Keyboard);
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
		return new CalendarViewItemAutomationPeer(this);
	}
}
