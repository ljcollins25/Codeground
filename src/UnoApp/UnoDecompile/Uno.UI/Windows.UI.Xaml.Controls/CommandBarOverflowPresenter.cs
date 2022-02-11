namespace Windows.UI.Xaml.Controls;

public class CommandBarOverflowPresenter : ItemsControl
{
	private bool m_useFullWidth;

	private bool m_shouldOpenUp;

	public CommandBarOverflowPresenter()
	{
		m_useFullWidth = false;
		m_shouldOpenUp = false;
	}

	public void SetDisplayModeState(bool isFullWidth, bool isOpenUp)
	{
		m_useFullWidth = isFullWidth;
		m_shouldOpenUp = isOpenUp;
		UpdateVisualState(useTransitions: false);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UpdateVisualState(useTransitions: false);
	}

	private protected override void ChangeVisualState(bool useTransitions)
	{
		base.ChangeVisualState(useTransitions);
		if (m_useFullWidth && m_shouldOpenUp)
		{
			GoToState(useTransitions, "FullWidthOpenUp");
		}
		else if (m_useFullWidth && !m_shouldOpenUp)
		{
			GoToState(useTransitions, "FullWidthOpenDown");
		}
		else
		{
			GoToState(useTransitions, "DisplayModeDefault");
		}
	}

	protected override void ClearContainerForItemOverride(DependencyObject element, object item)
	{
		base.ClearContainerForItemOverride(element, item);
		element.ClearValue(FrameworkElement.StyleProperty);
	}
}
