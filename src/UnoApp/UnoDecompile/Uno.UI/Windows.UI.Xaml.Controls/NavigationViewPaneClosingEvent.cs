namespace Windows.UI.Xaml.Controls;

public class NavigationViewPaneClosingEventArgs
{
	private bool _cancel;

	public bool Cancel
	{
		get
		{
			return _cancel;
		}
		set
		{
			_cancel = value;
			if (SplitViewClosingArgs != null)
			{
				SplitViewClosingArgs.Cancel = value;
			}
		}
	}

	internal SplitViewPaneClosingEventArgs SplitViewClosingArgs { get; set; }
}
