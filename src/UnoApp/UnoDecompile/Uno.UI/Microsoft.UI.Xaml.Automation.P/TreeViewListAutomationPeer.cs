using System;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;

namespace Microsoft.UI.Xaml.Automation.Peers;

public class TreeViewListAutomationPeer : ListViewAutomationPeer, ISelectionProvider, IDropTargetProvider
{
	string IDropTargetProvider.DropEffect => ((TreeViewList)base.Owner).GetDropTargetDropEffect();

	string[] IDropTargetProvider.DropEffects
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	bool ISelectionProvider.CanSelectMultiple
	{
		get
		{
			if (!IsMultiselect)
			{
				return base.CanSelectMultiple;
			}
			return true;
		}
	}

	bool ISelectionProvider.IsSelectionRequired
	{
		get
		{
			if (!IsMultiselect)
			{
				return base.CanSelectMultiple;
			}
			return false;
		}
	}

	private bool IsMultiselect => ((TreeViewList)base.Owner).IsMultiselect;

	public TreeViewListAutomationPeer(TreeViewList owner)
		: base(owner)
	{
	}

	protected override ItemAutomationPeer OnCreateItemAutomationPeer(object item)
	{
		return new TreeViewItemDataAutomationPeer(item, this);
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.DropTarget || (patternInterface == PatternInterface.Selection && IsMultiselect))
		{
			return this;
		}
		return base.GetPatternCore(patternInterface);
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Tree;
	}

	IRawElementProviderSimple[] ISelectionProvider.GetSelection()
	{
		return Array.Empty<IRawElementProviderSimple>();
	}
}
