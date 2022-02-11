using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DirectUI;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Controls;

[Windows.UI.Xaml.Data.Bindable]
internal abstract class CalendarViewGeneratorHost : DependencyObject, IDirectManipulationStateChangeHandler, IVector<object>, IList<object>, ICollection<object>, IEnumerable<object>, IEnumerable, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private ScrollViewer m_tpScrollViewer;

	private VisibleIndicesUpdatedEventCallback m_epVisibleIndicesUpdatedHandler;

	private TypedEventHandler<Control, FocusEngagedEventArgs> m_epScrollViewerFocusEngagedEventHandler;

	private int[] m_lastVisibleIndicesPair = new int[2];

	protected DateTimeOffset m_minDateOfCurrentScope;

	protected DateTimeOffset m_maxDateOfCurrentScope;

	protected (DateTimeOffset first, int second) m_lastVisitedDateAndIndex;

	protected string m_pHeaderText;

	protected uint m_size;

	protected CalendarView m_pOwnerNoRef;

	protected CalendarPanel m_tpPanel;

	protected List<string> m_possibleItemStrings = new List<string>();

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private IVector<DependencyObject> View => new TrackerCollection<DependencyObject> { this };

	private ICollectionView CollectionView => null;

	internal CalendarPanel Panel
	{
		get
		{
			return m_tpPanel;
		}
		set
		{
			if (value != null)
			{
				m_tpPanel = value;
				m_tpPanel.Owner = this;
			}
			else if (m_tpPanel != null)
			{
				m_tpPanel.Owner = null;
				m_tpPanel = null;
			}
		}
	}

	internal ScrollViewer ScrollViewer
	{
		get
		{
			return m_tpScrollViewer;
		}
		set
		{
			if (value != null)
			{
				m_tpScrollViewer = value;
			}
			else
			{
				m_tpScrollViewer = null;
			}
		}
	}

	public CalendarView Owner
	{
		get
		{
			return m_pOwnerNoRef;
		}
		set
		{
			m_pOwnerNoRef = value;
		}
	}

	public bool IsReadOnly { get; }

	public int Count => (int)Size();

	public object this[int index]
	{
		get
		{
			return GetAt((uint)index);
		}
		set
		{
			SetAt((uint)index, value);
		}
	}

	public CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(CalendarViewGeneratorHost), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CalendarViewGeneratorHost)s).OnDataContextChanged(e);
	}));


	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(CalendarViewGeneratorHost), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CalendarViewGeneratorHost)s).OnTemplatedParentChanged(e);
	}));


	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	protected internal void ResetPossibleItemStrings()
	{
		m_possibleItemStrings.Clear();
	}

	internal abstract bool GetIsFirstItemInScope(int index);

	internal abstract void UpdateLabel(CalendarViewBaseItem pItem, bool isLabelVisible);

	internal abstract int CompareDate(DateTimeOffset lhs, DateTimeOffset rhs);

	protected abstract CalendarViewBaseItem GetContainer(object pItem, DependencyObject pRecycledContainer);

	protected abstract long GetAverageTicksPerUnit();

	protected internal abstract int GetMaximumScopeSize();

	protected abstract int GetUnit();

	protected abstract void SetUnit(int value);

	protected abstract void AddUnits(int value);

	protected abstract void AddScopes(int value);

	protected abstract int GetFirstUnitInThisScope();

	protected abstract int GetLastUnitInThisScope();

	protected abstract void OnScopeChanged();

	private bool IsItemItsOwnContainer(DependencyObject pItem)
	{
		return false;
	}

	internal virtual DependencyObject GetContainerForItem(object pItem, DependencyObject pRecycledContainer)
	{
		CalendarViewBaseItem container = GetContainer(pItem, pRecycledContainer);
		container.SetParentCalendarView(Owner);
		return container;
	}

	internal virtual void PrepareItemContainer(DependencyObject pContainer, object pItem)
	{
		CalendarViewBaseItem calendarViewBaseItem = (CalendarViewBaseItem)pContainer;
		calendarViewBaseItem.SetIsOutOfScope(state: false);
		bool isToday = false;
		int num = 0;
		DateTimeOffset lhs = (DateTimeOffset)pItem;
		if (CompareDate(lhs, Owner.Today) == 0)
		{
			bool flag = false;
			flag = Owner.IsTodayHighlighted;
			isToday = flag;
		}
		calendarViewBaseItem.SetIsToday(isToday);
	}

	internal virtual void ClearContainerForItem(DependencyObject pContainer, object pItem)
	{
	}

	private bool IsHostForItemContainer(DependencyObject pContainer)
	{
		throw new NotImplementedException();
	}

	private GroupStyle GetGroupStyle(CollectionViewGroup pGroup, uint level)
	{
		return null;
	}

	private void SetIsGrouping(bool isGrouping)
	{
	}

	private DependencyObject GetHeaderForGroup(DependencyObject pGroup)
	{
		throw new NotImplementedException();
	}

	private void PrepareGroupContainer(DependencyObject pContainer, CollectionViewGroup pGroup)
	{
		throw new NotImplementedException();
	}

	private void ClearGroupContainerForGroup(DependencyObject pContainer, CollectionViewGroup pItem)
	{
		throw new NotImplementedException();
	}

	internal bool CanRecycleContainer(DependencyObject pContainer)
	{
		return true;
	}

	private DependencyObject SuggestContainerForContainerFromItemLookup()
	{
		return null;
	}

	public CalendarViewGeneratorHost()
	{
		m_size = 0u;
		m_pOwnerNoRef = null;
		ResetScope();
	}

	~CalendarViewGeneratorHost()
	{
		DetachScrollViewerFocusEngagedEvent();
		DetachVisibleIndicesUpdatedEvent();
		CalendarPanel tpPanel = m_tpPanel;
		if (tpPanel != null)
		{
			tpPanel.Owner = null;
			tpPanel.SetSnapPointFilterFunction(null);
		}
		m_tpScrollViewer?.SetDirectManipulationStateChangeHandler(null);
	}

	internal Calendar GetCalendar()
	{
		return Owner.Calendar;
	}

	internal void ResetScope()
	{
		m_minDateOfCurrentScope = default(DateTimeOffset);
		m_maxDateOfCurrentScope = default(DateTimeOffset);
		m_pHeaderText = null;
		m_lastVisibleIndicesPair[0] = -1;
		m_lastVisibleIndicesPair[1] = -1;
		m_lastVisitedDateAndIndex.first = default(DateTimeOffset);
		m_lastVisitedDateAndIndex.second = -1;
	}

	internal void ComputeSize()
	{
		int num = 0;
		m_lastVisitedDateAndIndex.first = Owner.MinDate;
		m_lastVisitedDateAndIndex.second = 0;
		num = CalculateOffsetFromMinDate(Owner.MaxDate);
		m_size = (uint)(num + 1);
	}

	internal void AddScopes(DateTimeOffset date, int scopes)
	{
		Calendar calendar = GetCalendar();
		calendar.SetDateTime(date);
		AddScopes(scopes);
		date = calendar.GetDateTime();
	}

	internal void AddUnits(DateTimeOffset date, int units)
	{
		Calendar calendar = GetCalendar();
		calendar.SetDateTime(date);
		AddUnits(units);
		date = calendar.GetDateTime();
	}

	internal DateTimeOffset GetDateAt(uint index)
	{
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		Calendar calendar = GetCalendar();
		calendar.SetDateTime(m_lastVisitedDateAndIndex.first);
		AddUnits((int)index - m_lastVisitedDateAndIndex.second);
		dateTimeOffset = calendar.GetDateTime();
		m_lastVisitedDateAndIndex.first = dateTimeOffset;
		m_lastVisitedDateAndIndex.second = (int)index;
		return dateTimeOffset.ToUniversalTime();
	}

	internal int CalculateOffsetFromMinDate(DateTimeOffset date)
	{
		int num = 0;
		DateTimeOffset dateTimeOffset = m_lastVisitedDateAndIndex.first.ToUniversalTime();
		Calendar calendar = GetCalendar();
		int num2 = 0;
		long num3 = 0L;
		int num4 = 0;
		int num5 = 3;
		calendar.SetDateTime(dateTimeOffset);
		long averageTicksPerUnit = GetAverageTicksPerUnit();
		while (true)
		{
			num3 = date.ToUniversalTime().Ticks - dateTimeOffset.ToUniversalTime().Ticks;
			num4 = (int)(num3 / averageTicksPerUnit);
			if (Math.Abs(num4) < num5)
			{
				break;
			}
			while (true)
			{
				try
				{
					AddUnits(num4);
				}
				catch (Exception)
				{
					goto IL_0079;
				}
				break;
				IL_0079:
				calendar.SetDateTime(dateTimeOffset);
				num4 = num4 * 99 / 100;
			}
			num2 += num4;
			dateTimeOffset = calendar.GetDateTime();
		}
		int num6 = 0;
		while (true)
		{
			int num7 = 0;
			int num8 = 1;
			num7 = CompareDate(dateTimeOffset, date);
			if (num7 == 0)
			{
				break;
			}
			if (num7 > 0)
			{
				num8 = -1;
			}
			AddUnits(num8);
			num6 += num8;
			dateTimeOffset = calendar.GetDateTime();
		}
		return m_lastVisitedDateAndIndex.second + num2 + num6;
	}

	internal void GetFirstDateOfNextScope(DateTimeOffset dateOfFirstVisibleItem, bool forward, out DateTimeOffset pFirstDateOfNextScope)
	{
		int num = 0;
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		GetCalendar().SetDateTime(m_minDateOfCurrentScope);
		num = (Owner.DateComparer.LessThan(m_minDateOfCurrentScope, dateOfFirstVisibleItem) ? (forward ? 1 : 0) : (forward ? 1 : (-1)));
		if (num != 0)
		{
			AddScopes(num);
			int num2 = 0;
			num2 = GetFirstUnitInThisScope();
			SetUnit(num2);
		}
		dateTimeOffset = (pFirstDateOfNextScope = GetCalendar().GetDateTime());
	}

	internal void UpdateScope(DateTimeOffset firstDate, DateTimeOffset lastDate, out bool isScopeChanged)
	{
		int num = 0;
		int num2 = 0;
		int pUnit = 0;
		isScopeChanged = false;
		Calendar calendar = GetCalendar();
		calendar.SetDateTime(firstDate);
		num = GetUnit();
		AdjustToLastUnitInThisScope(out var pDate, ref pUnit);
		DateTimeOffset date;
		DateTimeOffset pDate2;
		if (!Owner.DateComparer.LessThan(pDate, lastDate))
		{
			date = pDate;
			AdjustToFirstUnitInThisScope(out pDate2);
		}
		else
		{
			int num3 = pUnit - num + 1;
			int num4 = 0;
			int num5 = 0;
			int pUnit2 = 0;
			num2 = GetFirstUnitInThisScope();
			AddUnits(1);
			num5 = GetFirstUnitInThisScope();
			AdjustToLastUnitInThisScope(out var pDate3, ref pUnit2);
			if (!Owner.DateComparer.LessThan(lastDate, pDate3))
			{
				num4 = pUnit2 - num5 + 1;
			}
			else
			{
				int num6 = 0;
				calendar.SetDateTime(lastDate);
				num6 = GetUnit();
				num4 = num6 - num5 + 1;
			}
			double num7 = (double)num3 / (double)(pUnit - num2 + 1);
			double num8 = (double)num4 / (double)(pUnit2 - num5 + 1);
			DateTimeOffset dateTime = ((!(num7 < num8)) ? firstDate : pDate3);
			calendar.SetDateTime(dateTime);
			AdjustToFirstUnitInThisScope(out pDate2);
			AdjustToLastUnitInThisScope(out date);
		}
		Owner.CoerceDate(ref pDate2);
		Owner.CoerceDate(ref date);
		if (pDate2.ToUniversalTime() != m_minDateOfCurrentScope.ToUniversalTime() || date.ToUniversalTime() != m_maxDateOfCurrentScope.ToUniversalTime())
		{
			m_minDateOfCurrentScope = pDate2;
			m_maxDateOfCurrentScope = date;
			isScopeChanged = true;
			OnScopeChanged();
		}
	}

	internal void AdjustToFirstUnitInThisScope(out DateTimeOffset pDate)
	{
		int pUnit = 0;
		AdjustToFirstUnitInThisScope(out pDate, ref pUnit);
	}

	private void AdjustToFirstUnitInThisScope(out DateTimeOffset pDate, ref int pUnit)
	{
		int num = 0;
		pDate = default(DateTimeOffset);
		num = GetFirstUnitInThisScope();
		SetUnit(num);
		pDate = GetCalendar().GetDateTime();
	}

	private void AdjustToLastUnitInThisScope(out DateTimeOffset pDate)
	{
		int pUnit = 0;
		AdjustToLastUnitInThisScope(out pDate, ref pUnit);
	}

	private void AdjustToLastUnitInThisScope(out DateTimeOffset pDate, ref int pUnit)
	{
		int num = 0;
		pDate = default(DateTimeOffset);
		num = GetLastUnitInThisScope();
		SetUnit(num);
		pDate = GetCalendar().GetDateTime();
		pUnit = num;
	}

	void IDirectManipulationStateChangeHandler.NotifyStateChange(DMManipulationState state, float xCumulativeTranslation, float yCumulativeTranslation, float zCumulativeFactor, float xCenter, float yCenter, bool isInertial, bool isTouchConfigurationActivated, bool isBringIntoViewportConfigurationActivated)
	{
		switch (state)
		{
		case DMManipulationState.DMManipulationStarted:
			Owner.UpdateItemsScopeState(this, ignoreWhenIsOutOfScopeDisabled: true, ignoreInDirectManipulation: false);
			break;
		case DMManipulationState.DMManipulationCompleted:
			Owner.UpdateItemsScopeState(this, ignoreWhenIsOutOfScopeDisabled: false, ignoreInDirectManipulation: false);
			break;
		}
	}

	internal void AttachVisibleIndicesUpdatedEvent()
	{
		if (m_tpPanel == null)
		{
			return;
		}
		if (m_epVisibleIndicesUpdatedHandler == null)
		{
			m_epVisibleIndicesUpdatedHandler = delegate
			{
				Owner.OnVisibleIndicesUpdated(this);
			};
		}
		m_tpPanel.VisibleIndicesUpdated += m_epVisibleIndicesUpdatedHandler;
	}

	internal void DetachVisibleIndicesUpdatedEvent()
	{
		if (m_epVisibleIndicesUpdatedHandler != null && m_tpPanel != null)
		{
			m_tpPanel.VisibleIndicesUpdated -= m_epVisibleIndicesUpdatedHandler;
		}
	}

	internal void AttachScrollViewerFocusEngagedEvent()
	{
		if (m_tpPanel == null || m_tpScrollViewer == null)
		{
			return;
		}
		ScrollViewer tpScrollViewer = m_tpScrollViewer;
		if (m_epScrollViewerFocusEngagedEventHandler == null)
		{
			m_epScrollViewerFocusEngagedEventHandler = delegate(Control pSender, FocusEngagedEventArgs pArgs)
			{
				Owner.OnScrollViewerFocusEngaged(pArgs);
			};
		}
		tpScrollViewer.FocusEngaged += m_epScrollViewerFocusEngagedEventHandler;
	}

	internal void DetachScrollViewerFocusEngagedEvent()
	{
		if (m_epScrollViewerFocusEngagedEventHandler != null && m_tpScrollViewer != null)
		{
			m_tpScrollViewer.FocusEngaged -= m_epScrollViewerFocusEngagedEventHandler;
		}
	}

	internal void OnPrimaryPanelDesiredSizeChanged()
	{
		Owner.OnPrimaryPanelDesiredSizeChanged(this);
	}

	internal int[] GetLastVisibleIndicesPairRef()
	{
		return m_lastVisibleIndicesPair;
	}

	internal DateTimeOffset GetMinDateOfCurrentScope()
	{
		return m_minDateOfCurrentScope;
	}

	internal DateTimeOffset GetMaxDateOfCurrentScope()
	{
		return m_maxDateOfCurrentScope;
	}

	internal string GetHeaderTextOfCurrentScope()
	{
		return m_pHeaderText;
	}

	internal virtual void SetupContainerContentChangingAfterPrepare(DependencyObject pContainer, object pItem, int itemIndex, Size measureSize)
	{
	}

	internal virtual void RaiseContainerContentChangingOnRecycle(UIElement pContainer, object pItem)
	{
	}

	internal abstract List<string> GetPossibleItemStrings();

	public object GetAt(uint index)
	{
		DateTimeOffset dateAt = GetDateAt(index);
		return PropertyValue.CreateDateTime(dateAt);
	}

	public uint Size()
	{
		return m_size;
	}

	public IVectorView<object> GetView()
	{
		CoreDispatcher.CheckThreadAccess();
		IVectorView<object> vectorView = new TrackerView<object>();
		(vectorView as TrackerView<object>).SetCollection(this);
		return vectorView;
	}

	public void IndexOf(object value, out uint index, out bool found)
	{
		throw new NotImplementedException();
	}

	public void SetAt(uint index, object item)
	{
		throw new NotImplementedException();
	}

	public void InsertAt(uint index, object item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(uint index)
	{
		throw new NotImplementedException();
	}

	public void Append(object item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAtEnd()
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public void Add(object item)
	{
		Append(item);
	}

	public void Insert(int index, object item)
	{
		InsertAt((uint)index, item);
	}

	public bool Contains(object item)
	{
		uint index;
		return IndexOf(item, out index);
	}

	public int IndexOf(object item)
	{
		if (!IndexOf(item, out var index))
		{
			return -1;
		}
		return (int)index;
	}

	public void CopyTo(object[] array, int arrayIndex)
	{
		throw new NotSupportedException();
	}

	public void RemoveAt(int index)
	{
		RemoveAt((uint)index);
	}

	public bool Remove(object item)
	{
		if (IndexOf(item, out var index))
		{
			RemoveAt(index);
			return true;
		}
		return false;
	}

	public IEnumerator<object> GetEnumerator()
	{
		throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private bool IndexOf(object item, out uint index)
	{
		IndexOf(item, out index, out var found);
		return found;
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}
}
