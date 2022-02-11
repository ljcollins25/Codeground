using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class SplitButtonAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider, IInvokeProvider
{
	private readonly SplitButton _owner;

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			ExpandCollapseState result = ExpandCollapseState.Collapsed;
			SplitButton impl = GetImpl();
			if (impl != null && impl.IsFlyoutOpen)
			{
				result = ExpandCollapseState.Expanded;
			}
			return result;
		}
	}

	public SplitButtonAutomationPeer(SplitButton owner)
		: base(owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse || patternInterface == PatternInterface.Invoke)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "SplitButton";
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.SplitButton;
	}

	private SplitButton GetImpl()
	{
		return _owner;
	}

	public void Expand()
	{
		GetImpl()?.OpenFlyout();
	}

	public void Collapse()
	{
		GetImpl()?.CloseFlyout();
	}

	public void Invoke()
	{
		GetImpl()?.OnClickPrimary(null, null);
	}
}
