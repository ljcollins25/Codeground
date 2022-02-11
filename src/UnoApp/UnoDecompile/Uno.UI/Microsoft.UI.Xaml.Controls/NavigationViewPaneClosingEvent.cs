using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class NavigationViewPaneClosingEventArgs
{
	private bool m_cancelled;

	private SplitViewPaneClosingEventArgs m_splitViewClosingArgs;

	public bool Cancel
	{
		get
		{
			return m_cancelled;
		}
		set
		{
			m_cancelled = value;
			SplitViewPaneClosingEventArgs splitViewClosingArgs = m_splitViewClosingArgs;
			if (splitViewClosingArgs != null)
			{
				splitViewClosingArgs.Cancel = value;
			}
		}
	}

	internal NavigationViewPaneClosingEventArgs()
	{
	}

	internal void SplitViewClosingArgs(SplitViewPaneClosingEventArgs value)
	{
		m_splitViewClosingArgs = value;
	}
}
