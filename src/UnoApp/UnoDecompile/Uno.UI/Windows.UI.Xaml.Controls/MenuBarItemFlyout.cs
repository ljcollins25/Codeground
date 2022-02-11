namespace Windows.UI.Xaml.Controls;

public class MenuBarItemFlyout : MenuFlyout
{
	internal Control m_presenter;

	protected override Control CreatePresenter()
	{
		m_presenter = base.CreatePresenter();
		return m_presenter;
	}
}
