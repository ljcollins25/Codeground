using System.Collections.Generic;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Controls;

public class ExpanderAutomationPeer : AutomationPeer, IExpandCollapseProvider
{
	private readonly Expander _owner;

	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			ExpandCollapseState result = ExpandCollapseState.Collapsed;
			Expander owner = _owner;
			if (owner != null)
			{
				result = (owner.IsExpanded ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			}
			return result;
		}
	}

	public ExpanderAutomationPeer(Expander owner)
	{
		_owner = owner;
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.ExpandCollapse)
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override string GetClassNameCore()
	{
		return "Expander";
	}

	protected override string GetNameCore()
	{
		return base.GetNameCore();
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Group;
	}

	protected override bool HasKeyboardFocusCore()
	{
		return false;
	}

	protected override AutomationPeer GetPeerFromPointCore(Point point)
	{
		return base.GetPeerFromPointCore(point);
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		return new List<AutomationPeer>();
	}

	public void Expand()
	{
		Expander owner = _owner;
		if (owner != null)
		{
			owner.IsExpanded = true;
			RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Expanded);
		}
	}

	public void Collapse()
	{
		Expander owner = _owner;
		if (owner != null)
		{
			owner.IsExpanded = false;
			RaiseExpandCollapseAutomationEvent(ExpandCollapseState.Collapsed);
		}
	}

	public void RaiseExpandCollapseAutomationEvent(ExpandCollapseState newState)
	{
		if (ApiInformation.IsEnumNamedValuePresent("Windows.UI.Xaml.Automation.Peers.AutomationEvents", "PropertyChanged") && AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
		{
			ExpandCollapseState expandCollapseState = ((newState != ExpandCollapseState.Expanded) ? ExpandCollapseState.Expanded : ExpandCollapseState.Collapsed);
			RaisePropertyChangedEvent(ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty, expandCollapseState, newState);
		}
	}

	private Expander GetImpl()
	{
		Expander result = null;
		Expander owner = _owner;
		if (owner != null)
		{
			result = owner;
		}
		return result;
	}
}
