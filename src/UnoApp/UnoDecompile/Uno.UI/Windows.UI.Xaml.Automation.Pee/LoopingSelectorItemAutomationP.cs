using System;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class LoopingSelectorItemAutomationPeer : FrameworkElementAutomationPeer, IScrollItemProvider, ISelectionItemProvider
{
	public bool IsSelected
	{
		get
		{
			bool value = false;
			LoopingSelectorItem ppOwnerNoRef = null;
			GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
			ppOwnerNoRef?.AutomationGetIsSelected(out value);
			return value;
		}
	}

	public IRawElementProviderSimple SelectionContainer
	{
		get
		{
			LoopingSelectorItem ppOwnerNoRef = null;
			IRawElementProviderSimple result = null;
			GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
			if (ppOwnerNoRef != null)
			{
				ppOwnerNoRef.AutomationGetSelectionContainerUIAPeer(out var ppPeer);
				if (ppPeer != null)
				{
					IRawElementProviderSimple rawElementProviderSimple = null;
					result = rawElementProviderSimple;
				}
			}
			return result;
		}
	}

	internal LoopingSelectorItemAutomationPeer(LoopingSelectorItem pOwner)
	{
		InitializeImpl(pOwner);
	}

	private void InitializeImpl(LoopingSelectorItem pOwner)
	{
		UpdateEventSource();
	}

	internal void UpdateEventSource()
	{
		GetDataAutomationPeer(out var ppLSIDAP);
		if (ppLSIDAP != null)
		{
			SetEventSource(ppLSIDAP);
		}
	}

	internal void UpdateItemIndex(int itemIndex)
	{
		GetDataAutomationPeer(out var ppLSIDAP);
		ppLSIDAP?.SetItemIndex(itemIndex);
	}

	internal void SetEventSource(LoopingSelectorItemDataAutomationPeer pLSIDAP)
	{
		EventsSource = pLSIDAP;
	}

	private void GetDataAutomationPeer(out LoopingSelectorItemDataAutomationPeer ppLSIDAP)
	{
		LoopingSelectorItem ppOwnerNoRef = null;
		LoopingSelector ppValue = null;
		LoopingSelectorAutomationPeer loopingSelectorAutomationPeer = null;
		ppLSIDAP = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		if (ppOwnerNoRef != null)
		{
			ContentControl contentControl = ppOwnerNoRef;
			if (contentControl.Content is DependencyObject pItem)
			{
				ppOwnerNoRef.GetParentNoRef(out ppValue);
				UIElement element = ppValue;
				AutomationPeer automationPeer = FrameworkElementAutomationPeer.CreatePeerForElement(element);
				LoopingSelectorAutomationPeer loopingSelectorAutomationPeer2 = automationPeer as LoopingSelectorAutomationPeer;
				loopingSelectorAutomationPeer = loopingSelectorAutomationPeer2;
				loopingSelectorAutomationPeer.GetDataAutomationPeerForItem(pItem, out ppLSIDAP);
			}
		}
	}

	private void GetOwnerAsInternalPtrNoRef(out LoopingSelectorItem ppOwnerNoRef)
	{
		ppOwnerNoRef = null;
		UIElement owner = Owner;
		if (owner != null)
		{
			LoopingSelectorItem loopingSelectorItem = (ppOwnerNoRef = owner as LoopingSelectorItem);
		}
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		DependencyObject result = null;
		if (patternInterface == PatternInterface.ScrollItem || patternInterface == PatternInterface.SelectionItem)
		{
			result = this;
		}
		return result;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		AutomationControlType automationControlType = AutomationControlType.Button;
		return AutomationControlType.ListItem;
	}

	protected override string GetClassNameCore()
	{
		return "LoopingSelectorItem";
	}

	protected override bool IsKeyboardFocusableCore()
	{
		bool flag = false;
		flag = false;
		GetParentAutomationPeer(out var parentAutomationPeer);
		if (parentAutomationPeer != null)
		{
			flag = parentAutomationPeer.IsKeyboardFocusable();
		}
		return flag;
	}

	protected override bool HasKeyboardFocusCore()
	{
		bool result = false;
		GetParentAutomationPeer(out var parentAutomationPeer);
		if (parentAutomationPeer != null)
		{
			bool flag = false;
			if (parentAutomationPeer.HasKeyboardFocus())
			{
				result = IsSelected;
			}
		}
		return result;
	}

	public void ScrollIntoView()
	{
		LoopingSelectorItem ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		if (ppOwnerNoRef != null)
		{
			LoopingSelector ppValue = null;
			ppOwnerNoRef.GetParentNoRef(out ppValue);
			if (ppValue != null)
			{
				ContentControl contentControl = ppOwnerNoRef;
				DependencyObject pItem = contentControl.Content as DependencyObject;
				ppValue.AutomationTryScrollItemIntoView(pItem);
			}
		}
	}

	public void AddToSelection()
	{
		throw new InvalidOperationException();
	}

	public void RemoveFromSelection()
	{
		throw new InvalidOperationException();
	}

	public void Select()
	{
		LoopingSelectorItem ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationSelect();
	}

	private void GetParentAutomationPeer(out AutomationPeer parentAutomationPeer)
	{
		LoopingSelectorItem ppOwnerNoRef = null;
		parentAutomationPeer = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		if (ppOwnerNoRef == null)
		{
			return;
		}
		LoopingSelector ppValue = null;
		ppOwnerNoRef.GetParentNoRef(out ppValue);
		if (ppValue != null)
		{
			LoopingSelector loopingSelector = ppValue;
			UIElement uIElement = loopingSelector;
			if (uIElement != null)
			{
				AutomationPeer automationPeer = (parentAutomationPeer = AutomationHelper.CreatePeerForElement(uIElement));
			}
		}
	}

	~LoopingSelectorItemAutomationPeer()
	{
	}
}
