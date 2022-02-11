using System;
using System.Collections.Generic;
using DirectUI;
using Uno.Extensions;
using Windows.Foundation;
using Windows.Globalization;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Controls;

internal class CalendarViewGeneratorMonthViewHost : CalendarViewGeneratorHost, ITreeBuilder
{
	private const int BUDGET_MANAGER_DEFAULT_LIMIT = 40;

	private long m_lowestPhaseInQueue;

	private bool m_isRegisteredForCallbacks;

	private uint m_budget;

	private TrackerCollection<CalendarViewDayItem> m_toBeClearedContainers;

	bool ITreeBuilder.IsRegisteredForCallbacks
	{
		get
		{
			return m_isRegisteredForCallbacks;
		}
		set
		{
			m_isRegisteredForCallbacks = value;
		}
	}

	bool ITreeBuilder.IsBuildTreeSuspended
	{
		get
		{
			CalendarView owner = base.Owner;
			return false;
		}
	}

	public CalendarViewGeneratorMonthViewHost()
	{
		m_lowestPhaseInQueue = -1L;
		m_isRegisteredForCallbacks = false;
		m_budget = 40u;
	}

	protected override CalendarViewBaseItem GetContainer(object pItem, DependencyObject pRecycledContainer)
	{
		return new CalendarViewDayItem();
	}

	internal override void PrepareItemContainer(DependencyObject pContainer, object pItem)
	{
		CalendarViewDayItem calendarViewDayItem = (CalendarViewDayItem)pContainer;
		RemoveToBeClearedContainer(calendarViewDayItem);
		DateTimeOffset dateTimeOffset = (DateTimeOffset)pItem;
		GetCalendar().SetDateTime(dateTimeOffset);
		calendarViewDayItem.Date = dateTimeOffset;
		string mainText = GetCalendar().DayAsString();
		calendarViewDayItem.UpdateMainText(mainText);
		bool flag = false;
		flag = base.Owner.IsGroupLabelVisible;
		UpdateLabel(calendarViewDayItem, flag);
		calendarViewDayItem.IsBlackout = false;
		bool pIsSelected = false;
		base.Owner.IsSelected(dateTimeOffset, out pIsSelected);
		calendarViewDayItem.SetIsSelected(pIsSelected);
		Style calendarViewDayItemStyle = base.Owner.CalendarViewDayItemStyle;
		CalendarView.SetDayItemStyle(calendarViewDayItem, calendarViewDayItemStyle);
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
			num2 = calendar.FirstDayInThisMonth;
			num = calendar.Day;
			flag = num2 == num;
			if (flag)
			{
				string labelText = calendar.MonthAsString(0);
				pItem.UpdateLabelText(labelText);
			}
		}
		pItem.ShowLabelText(flag);
	}

	internal override void ClearContainerForItem(DependencyObject pContainer, object pItem)
	{
		CalendarViewDayItem item = (CalendarViewDayItem)pContainer;
		m_toBeClearedContainers.Add(item);
		if (!m_isRegisteredForCallbacks)
		{
			BuildTreeService buildTreeService = DXamlCore.Current.GetBuildTreeService();
			buildTreeService.RegisterWork(this);
		}
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
		num = calendar.Day;
		num2 = calendar.FirstDayInThisMonth;
		return num == num2;
	}

	protected override int GetUnit()
	{
		return GetCalendar().Day;
	}

	protected override void SetUnit(int value)
	{
		GetCalendar().Day = value;
	}

	protected override void AddUnits(int value)
	{
		GetCalendar().AddDays(value);
	}

	protected override void AddScopes(int value)
	{
		GetCalendar().AddMonths(value);
	}

	protected override int GetFirstUnitInThisScope()
	{
		return GetCalendar().FirstDayInThisMonth;
	}

	protected override int GetLastUnitInThisScope()
	{
		return GetCalendar().LastDayInThisMonth;
	}

	protected override void OnScopeChanged()
	{
		m_pHeaderText = base.Owner.FormatMonthYearName(m_minDateOfCurrentScope);
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
				num3 = calendar.NumberOfDaysInThisMonth;
				if (num3 > num2)
				{
					num2 = num3;
					dateTime = calendar.GetDateTime();
				}
				calendar.AddMonths(1);
			}
			calendar.SetDateTime(dateTime);
			num4 = (calendar.Day = calendar.FirstDayInThisMonth);
			for (int j = 0; j < num2; j++)
			{
				string item = calendar.DayAsString();
				m_possibleItemStrings.Add(item);
				calendar.AddDays(1);
			}
		}
		return possibleItemStrings;
	}

	internal override int CompareDate(DateTimeOffset lhs, DateTimeOffset rhs)
	{
		return base.Owner.DateComparer.CompareDay(lhs, rhs);
	}

	protected override long GetAverageTicksPerUnit()
	{
		return 864000000000L;
	}

	protected internal override int GetMaximumScopeSize()
	{
		return 31;
	}

	internal override void SetupContainerContentChangingAfterPrepare(DependencyObject pContainer, object pItem, int itemIndex, Size measureSize)
	{
		CalendarViewDayItemChangingEventArgs calendarViewDayItemChangingEventArgs = null;
		VirtualizationInformation virtualizationInformation = null;
		CalendarViewDayItem calendarViewDayItem = (CalendarViewDayItem)pContainer;
		if (calendarViewDayItem != null)
		{
			virtualizationInformation = calendarViewDayItem.GetVirtualizationInformation();
			CalendarViewDayItemChangingEventArgs buildTreeArgs = calendarViewDayItem.GetBuildTreeArgs();
			calendarViewDayItemChangingEventArgs = buildTreeArgs;
		}
		if (virtualizationInformation != null && calendarViewDayItemChangingEventArgs != null)
		{
			virtualizationInformation.MeasureSize = measureSize;
			calendarViewDayItemChangingEventArgs.WantsCallBack = false;
			calendarViewDayItemChangingEventArgs.Item = calendarViewDayItem;
			calendarViewDayItemChangingEventArgs.InRecycleQueue = false;
			calendarViewDayItemChangingEventArgs.Phase = 0u;
			TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> pEventSource = null;
			base.Owner.GetCalendarViewDayItemChangingEventSourceNoRef(out pEventSource);
			if (base.Owner.ShouldRaiseEvent(pEventSource))
			{
				calendarViewDayItem?.Measure(measureSize);
				pEventSource(base.Owner, calendarViewDayItemChangingEventArgs);
			}
			RegisterWorkFromCICArgs(calendarViewDayItemChangingEventArgs);
		}
	}

	private void RegisterWorkForContainer(UIElement pContainer)
	{
		CalendarViewDayItem calendarViewDayItem = (CalendarViewDayItem)pContainer;
		CalendarViewDayItemChangingEventArgs buildTreeArgs = calendarViewDayItem.GetBuildTreeArgs();
		RegisterWorkFromCICArgs(buildTreeArgs);
	}

	private void RemoveToBeClearedContainer(CalendarViewDayItem pContainer)
	{
		uint num = 0u;
		EnsureToBeClearedContainers();
		num = (uint)m_toBeClearedContainers.Count;
		uint num2 = num - 1;
		while (num2 >= 0 && num != 0)
		{
			CalendarViewDayItem calendarViewDayItem = m_toBeClearedContainers[(int)num2];
			if (calendarViewDayItem == pContainer)
			{
				m_toBeClearedContainers.RemoveAt((int)num2);
				break;
			}
			if (num2 != 0)
			{
				num2--;
				continue;
			}
			break;
		}
	}

	bool ITreeBuilder.BuildTree()
	{
		int num = 0;
		bool result = true;
		BudgetManager budgetManager = DXamlCore.Current.GetBudgetManager();
		num = budgetManager.GetElapsedMilliSecondsSinceLastUITick();
		if ((uint)num <= m_budget)
		{
			CalendarPanel panel = base.Panel;
			if (panel != null)
			{
				if (base.Owner.IsInLiveTree && panel.IsInLiveTree)
				{
					ProcessIncrementalVisualization(budgetManager, panel);
				}
				ClearContainers(budgetManager);
				uint num2 = 0u;
				num2 = (uint)m_toBeClearedContainers.Count;
				result = m_lowestPhaseInQueue != -1 || num2 != 0;
			}
		}
		return result;
	}

	internal override void RaiseContainerContentChangingOnRecycle(UIElement pContainer, object? pItem)
	{
		CalendarViewDayItem calendarViewDayItem = (CalendarViewDayItem)pContainer;
		CalendarViewDayItemChangingEventArgs buildTreeArgs = calendarViewDayItem.GetBuildTreeArgs();
		CalendarViewDayItemChangingEventArgs calendarViewDayItemChangingEventArgs = buildTreeArgs;
		TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> pEventSource = null;
		base.Owner.GetCalendarViewDayItemChangingEventSourceNoRef(out pEventSource);
		if (base.Owner.ShouldRaiseEvent(pEventSource))
		{
			bool flag = false;
			calendarViewDayItemChangingEventArgs.InRecycleQueue = true;
			calendarViewDayItemChangingEventArgs.Phase = 0u;
			calendarViewDayItemChangingEventArgs.WantsCallBack = false;
			calendarViewDayItemChangingEventArgs.Callback = null;
			calendarViewDayItemChangingEventArgs.Item = calendarViewDayItem;
			pEventSource(base.Owner, buildTreeArgs);
			if (buildTreeArgs.WantsCallBack)
			{
				if (m_lowestPhaseInQueue == -1)
				{
					uint num = 0u;
					num = buildTreeArgs.Phase;
					m_lowestPhaseInQueue = num;
					if (!m_isRegisteredForCallbacks)
					{
						BuildTreeService buildTreeService = DXamlCore.Current.GetBuildTreeService();
						buildTreeService.RegisterWork(this);
					}
				}
			}
			else
			{
				calendarViewDayItemChangingEventArgs.ResetLifetime();
			}
		}
		else
		{
			calendarViewDayItemChangingEventArgs.ResetLifetime();
		}
	}

	private void ProcessIncrementalVisualization(BudgetManager spBudget, CalendarPanel pCalendarPanel)
	{
		if (m_lowestPhaseInQueue <= -1)
		{
			return;
		}
		int num = 0;
		PanelScrollingDirection direction = PanelScrollingDirection.None;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		IItemContainerMapping itemContainerMapping = pCalendarPanel.GetItemContainerMapping();
		num2 = pCalendarPanel.FirstCacheIndexBase;
		num3 = pCalendarPanel.FirstVisibleIndexBase;
		num4 = pCalendarPanel.LastVisibleIndexBase;
		num5 = pCalendarPanel.LastCacheIndexBase;
		int visibleStartInVector = -1;
		int visibleEndInVector = -1;
		int cacheEndInVector = -1;
		if (num5 > -1)
		{
			visibleStartInVector = ((num3 > -1) ? (num3 - num2) : 0);
			visibleEndInVector = ((num4 > -1) ? (num4 - num2) : visibleStartInVector);
			cacheEndInVector = num5 - num2;
		}
		else
		{
			m_lowestPhaseInQueue = -1L;
		}
		int currentPositionInVector = -1;
		direction = pCalendarPanel.PanningDirectionBase;
		long processingPhase = m_lowestPhaseInQueue;
		long nextLowest = long.MaxValue;
		long[] array = new long[cacheEndInVector + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = -1L;
		}
		ProcessCurrentPosition();
		while (processingPhase != long.MaxValue && (uint)num < m_budget && array.Length != 0)
		{
			long num6 = 0L;
			CalendarViewDayItem calendarViewDayItem = null;
			VirtualizationInformation virtualizationInformation = null;
			CalendarViewDayItemChangingEventArgs calendarViewDayItemChangingEventArgs = null;
			bool flag = true;
			num6 = array[currentPositionInVector];
			if (num6 == -1)
			{
				uint num7 = 0u;
				DependencyObject dependencyObject = itemContainerMapping.ContainerFromIndex(num2 + currentPositionInVector);
				if (dependencyObject == null)
				{
					ProcessCurrentPosition();
					continue;
				}
				calendarViewDayItem = (CalendarViewDayItem)dependencyObject;
				virtualizationInformation = (dependencyObject as UIElement)?.GetVirtualizationInformation();
				calendarViewDayItemChangingEventArgs = calendarViewDayItem.GetBuildTreeArgs();
				num7 = calendarViewDayItemChangingEventArgs.Phase;
				num6 = num7;
				array[currentPositionInVector] = num6;
			}
			if (calendarViewDayItemChangingEventArgs == null)
			{
				DependencyObject dependencyObject = itemContainerMapping.ContainerFromIndex(num2 + currentPositionInVector);
				calendarViewDayItem = (CalendarViewDayItem)dependencyObject;
				virtualizationInformation = (dependencyObject as UIElement)?.GetVirtualizationInformation();
				calendarViewDayItemChangingEventArgs = calendarViewDayItem.GetBuildTreeArgs();
			}
			CalendarViewDayItemChangingEventArgs calendarViewDayItemChangingEventArgs2 = calendarViewDayItemChangingEventArgs;
			if (num6 == processingPhase)
			{
				bool flag2 = false;
				Size size = default(Size);
				size = virtualizationInformation.MeasureSize;
				TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> callback = calendarViewDayItemChangingEventArgs2.Callback;
				if (callback != null)
				{
					calendarViewDayItemChangingEventArgs2.WantsCallBack = false;
					calendarViewDayItemChangingEventArgs2.Callback = null;
					callback(base.Owner, calendarViewDayItemChangingEventArgs);
					flag2 = calendarViewDayItemChangingEventArgs2.WantsCallBack;
				}
				calendarViewDayItem?.Measure(size);
				if (flag2)
				{
					uint num8 = 0u;
					num8 = calendarViewDayItemChangingEventArgs2.Phase;
					num6 = num8;
					array[currentPositionInVector] = num6;
					if (num6 < processingPhase)
					{
						nextLowest = processingPhase;
						processingPhase = num6;
						m_lowestPhaseInQueue = processingPhase;
						flag = false;
					}
					else
					{
						nextLowest = Math.Min(nextLowest, num6);
					}
				}
				else
				{
					calendarViewDayItemChangingEventArgs2.ResetLifetime();
				}
			}
			else
			{
				bool flag3 = false;
				if (calendarViewDayItemChangingEventArgs2.WantsCallBack)
				{
					nextLowest = Math.Min(nextLowest, num6);
				}
			}
			if (flag)
			{
				ProcessCurrentPosition();
			}
			num = spBudget.GetElapsedMilliSecondsSinceLastUITick();
		}
		if (processingPhase == long.MaxValue)
		{
			m_lowestPhaseInQueue = -1L;
		}
		else
		{
			m_lowestPhaseInQueue = (int)processingPhase;
		}
		void ProcessCurrentPosition()
		{
			bool flag4 = false;
			bool flag5 = direction != PanelScrollingDirection.Backward;
			if (currentPositionInVector == -1)
			{
				currentPositionInVector = (flag5 ? visibleStartInVector : visibleEndInVector);
			}
			else
			{
				if (flag5)
				{
					if (currentPositionInVector < visibleStartInVector)
					{
						currentPositionInVector--;
					}
					else
					{
						currentPositionInVector++;
						if (currentPositionInVector > cacheEndInVector)
						{
							currentPositionInVector = visibleStartInVector - 1;
						}
					}
					if (currentPositionInVector < 0)
					{
						currentPositionInVector = visibleStartInVector;
						flag4 = true;
					}
				}
				else
				{
					if (currentPositionInVector > visibleEndInVector)
					{
						currentPositionInVector++;
					}
					else
					{
						currentPositionInVector--;
						if (currentPositionInVector < 0)
						{
							currentPositionInVector = visibleEndInVector + 1;
						}
					}
					if (currentPositionInVector > cacheEndInVector)
					{
						currentPositionInVector = visibleEndInVector;
						flag4 = true;
					}
				}
				if (flag4)
				{
					processingPhase = nextLowest;
					nextLowest = long.MaxValue;
				}
			}
		}
	}

	private void EnsureToBeClearedContainers()
	{
		if (m_toBeClearedContainers == null)
		{
			TrackerCollection<CalendarViewDayItem> trackerCollection = (m_toBeClearedContainers = new TrackerCollection<CalendarViewDayItem>());
		}
	}

	private void ClearContainers(BudgetManager spBudget)
	{
		uint num = 0u;
		int num2 = 0;
		EnsureToBeClearedContainers();
		num = (uint)m_toBeClearedContainers.Count;
		uint num3 = num - 1;
		while (num3 >= 0 && num != 0)
		{
			num2 = spBudget.GetElapsedMilliSecondsSinceLastUITick();
			if ((uint)num2 <= m_budget)
			{
				CalendarViewDayItem calendarViewDayItem = m_toBeClearedContainers[(int)num3];
				m_toBeClearedContainers.RemoveAtEnd();
				ClearContainerForItem(calendarViewDayItem, null);
				if (calendarViewDayItem != null)
				{
					RaiseContainerContentChangingOnRecycle(calendarViewDayItem, null);
				}
				if (num3 != 0)
				{
					num3--;
					continue;
				}
				break;
			}
			break;
		}
	}

	private void ShutDownDeferredWork()
	{
		CalendarPanel panel = base.Panel;
		if (panel == null)
		{
			return;
		}
		int num = 0;
		int firstCacheIndexBase = panel.FirstCacheIndexBase;
		num = panel.LastCacheIndexBase;
		IItemContainerMapping itemContainerMapping = panel.GetItemContainerMapping();
		for (int i = firstCacheIndexBase; i < num; i++)
		{
			DependencyObject dependencyObject = itemContainerMapping.ContainerFromIndex(i);
			if (dependencyObject != null)
			{
				CalendarViewDayItemChangingEventArgs buildTreeArgs = (dependencyObject as CalendarViewDayItem).GetBuildTreeArgs();
				buildTreeArgs.ResetLifetime();
			}
		}
	}

	private void RegisterWorkFromCICArgs(CalendarViewDayItemChangingEventArgs pArgs)
	{
		bool flag = false;
		flag = pArgs.WantsCallBack;
		CalendarViewDayItem item = pArgs.Item;
		if (flag)
		{
			uint num = 0u;
			num = pArgs.Phase;
			if (m_lowestPhaseInQueue == -1)
			{
				m_lowestPhaseInQueue = num;
				if (!m_isRegisteredForCallbacks)
				{
					BuildTreeService buildTreeService = DXamlCore.Current.GetBuildTreeService();
					buildTreeService.RegisterWork(this);
				}
			}
			else if (m_lowestPhaseInQueue > num)
			{
				m_lowestPhaseInQueue = num;
			}
		}
		else
		{
			pArgs.ResetLifetime();
		}
	}
}
