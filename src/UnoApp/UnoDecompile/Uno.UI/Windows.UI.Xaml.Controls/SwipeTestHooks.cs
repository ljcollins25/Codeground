using Windows.Foundation;

namespace Windows.UI.Xaml.Controls;

internal class SwipeTestHooks
{
	private static SwipeTestHooks s_testHooks;

	public event TypedEventHandler<DependencyObject, DependencyObject> LastInteractedWithSwipeControlChanged
	{
		add
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_lastInteractedWithSwipeControlChangedEventSource += value;
		}
		remove
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_lastInteractedWithSwipeControlChangedEventSource -= value;
		}
	}

	public event TypedEventHandler<SwipeControl, DependencyObject> OpenedStatusChanged
	{
		add
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_openedStatusChangedEventSource += value;
		}
		remove
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_openedStatusChangedEventSource -= value;
		}
	}

	public event TypedEventHandler<SwipeControl, DependencyObject> IdleStatusChanged
	{
		add
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_idleStatusChangedEventSource += value;
		}
		remove
		{
			SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
			swipeTestHooks.m_idleStatusChangedEventSource -= value;
		}
	}

	private event TypedEventHandler<DependencyObject, DependencyObject> m_lastInteractedWithSwipeControlChangedEventSource;

	private event TypedEventHandler<SwipeControl, DependencyObject> m_openedStatusChangedEventSource;

	private event TypedEventHandler<SwipeControl, DependencyObject> m_idleStatusChangedEventSource;

	public static SwipeTestHooks EnsureGlobalTestHooks()
	{
		return s_testHooks ?? new SwipeTestHooks();
	}

	public SwipeControl GetLastInteractedWithSwipeControl()
	{
		return SwipeControl.GetLastInteractedWithSwipeControl();
	}

	public bool GetIsOpen(SwipeControl swipeControl)
	{
		return swipeControl?.GetIsOpen() ?? SwipeControl.GetLastInteractedWithSwipeControl()?.GetIsOpen() ?? false;
	}

	public bool GetIsIdle(SwipeControl swipeControl)
	{
		return swipeControl?.GetIsIdle() ?? SwipeControl.GetLastInteractedWithSwipeControl()?.GetIsIdle() ?? false;
	}

	public void NotifyLastInteractedWithSwipeControlChanged()
	{
		SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
		if (swipeTestHooks.m_lastInteractedWithSwipeControlChangedEventSource != null)
		{
			swipeTestHooks.m_lastInteractedWithSwipeControlChangedEventSource(null, null);
		}
	}

	public void NotifyOpenedStatusChanged(SwipeControl sender)
	{
		SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
		if (swipeTestHooks.m_openedStatusChangedEventSource != null)
		{
			swipeTestHooks.m_openedStatusChangedEventSource(sender, null);
		}
	}

	public void NotifyIdleStatusChanged(SwipeControl sender)
	{
		SwipeTestHooks swipeTestHooks = EnsureGlobalTestHooks();
		if (swipeTestHooks.m_idleStatusChangedEventSource != null)
		{
			swipeTestHooks.m_idleStatusChangedEventSource(sender, null);
		}
	}

	public static SwipeTestHooks GetGlobalTestHooks()
	{
		return s_testHooks;
	}

	static SwipeTestHooks()
	{
		s_testHooks = new SwipeTestHooks();
	}
}
