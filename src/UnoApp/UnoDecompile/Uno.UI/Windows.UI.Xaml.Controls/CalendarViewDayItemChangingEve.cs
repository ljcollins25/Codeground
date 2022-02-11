using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

public class CalendarViewDayItemChangingEventArgs
{
	private bool m_inRecycleQueue;

	private CalendarViewDayItem m_pItem;

	private uint m_phase;

	public bool InRecycleQueue
	{
		get
		{
			return m_inRecycleQueue;
		}
		internal set
		{
			m_inRecycleQueue = value;
		}
	}

	public CalendarViewDayItem Item
	{
		get
		{
			return m_pItem;
		}
		internal set
		{
			m_pItem = value;
		}
	}

	public uint Phase
	{
		get
		{
			return m_phase;
		}
		internal set
		{
			m_phase = value;
		}
	}

	internal TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> Callback { get; set; }

	internal bool WantsCallBack { get; set; }

	internal CalendarViewDayItemChangingEventArgs()
	{
	}

	public void RegisterUpdateCallback(TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> callback)
	{
		RegisterUpdateCallbackImpl(callback);
	}

	public void RegisterUpdateCallback(uint callbackPhase, TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> callback)
	{
		RegisterUpdateCallbackWithPhaseImpl(callbackPhase, callback);
	}

	private void ResetLifetimeImpl()
	{
		Callback = null;
		Item = null;
	}

	private void RegisterUpdateCallbackImpl(TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> pCallback)
	{
		RegisterUpdateCallbackWithPhaseImpl(m_phase + 1, pCallback);
	}

	private void RegisterUpdateCallbackWithPhaseImpl(uint callbackPhase, TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> pCallback)
	{
		m_phase = callbackPhase;
		Callback = pCallback;
		WantsCallBack = true;
	}

	public void ResetLifetime()
	{
		ResetLifetimeImpl();
	}
}
public delegate void CalendarViewDayItemChangingEventHandler(CalendarView sender, CalendarViewDayItemChangingEventArgs e);
