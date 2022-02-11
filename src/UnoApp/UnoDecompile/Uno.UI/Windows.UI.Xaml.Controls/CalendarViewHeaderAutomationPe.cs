using Windows.UI.Xaml.Automation.Peers;

namespace Windows.UI.Xaml.Controls;

internal class CalendarViewHeaderAutomationPeer : AutomationPeer
{
	private string m_name;

	private int m_month = -1;

	private int m_year = -1;

	private CalendarViewDisplayMode m_mode;

	protected override string GetNameCore()
	{
		return m_name;
	}

	internal void Initialize(string name, int month, int year, CalendarViewDisplayMode mode)
	{
		m_name = name;
		m_month = month;
		m_year = year;
		m_mode = mode;
	}

	internal int GetMonth()
	{
		return m_month;
	}

	internal int GetYear()
	{
		return m_year;
	}

	internal CalendarViewDisplayMode GetMode()
	{
		return m_mode;
	}
}
