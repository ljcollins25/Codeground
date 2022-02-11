using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation.Peers;

public class AppBarAutomationPeer : FrameworkElementAutomationPeer, IToggleProvider, IExpandCollapseProvider, IWindowProvider
{
	public ToggleState ToggleState
	{
		get
		{
			bool flag = false;
			AppBar appBar = base.Owner as AppBar;
			if (!appBar.IsOpen)
			{
				return ToggleState.Off;
			}
			return ToggleState.On;
		}
	}

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			bool flag = false;
			AppBar appBar = base.Owner as AppBar;
			if (!appBar.IsOpen)
			{
				return ExpandCollapseState.Collapsed;
			}
			return ExpandCollapseState.Expanded;
		}
	}

	public bool IsModal => true;

	public bool IsTopmost => true;

	public bool Maximizable => false;

	public bool Minimizable => false;

	public WindowInteractionState InteractionState => WindowInteractionState.Running;

	public WindowVisualState VisualState => WindowVisualState.Normal;

	public AppBarAutomationPeer(AppBar owner)
		: base(owner)
	{
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		bool flag = false;
		object obj = null;
		if (patternInterface == PatternInterface.Window)
		{
			AppBar appBar = base.Owner as AppBar;
			bool isOpen = appBar.IsOpen;
			flag = isOpen;
		}
		if (patternInterface == PatternInterface.ExpandCollapse || patternInterface == PatternInterface.Toggle || flag)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "ApplicationBar";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.AppBar;
	}

	public void Toggle()
	{
		bool flag = false;
		if (!IsEnabled())
		{
			throw new ElementNotEnabledException();
		}
		AppBar appBar = base.Owner as AppBar;
		flag = appBar.IsOpen;
		appBar.IsOpen = !flag;
	}

	public void RaiseToggleStatePropertyChangedEvent(object pOldValue, object pNewValue)
	{
	}

	public void RaiseExpandCollapseAutomationEvent(bool isOpen)
	{
	}

	public void Expand()
	{
		if (!IsEnabled())
		{
			throw new ElementNotEnabledException();
		}
		AppBar appBar = base.Owner as AppBar;
		appBar.IsOpen = true;
	}

	public void Collapse()
	{
		if (!IsEnabled())
		{
			throw new ElementNotEnabledException();
		}
		AppBar appBar = base.Owner as AppBar;
		appBar.IsOpen = false;
	}

	public void Close()
	{
	}

	public void SetVisualState(WindowVisualState state)
	{
	}

	public bool WaitForInputIdle(int milliseconds)
	{
		return false;
	}
}
