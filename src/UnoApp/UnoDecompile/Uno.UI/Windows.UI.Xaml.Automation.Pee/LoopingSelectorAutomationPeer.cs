using System;
using System.Collections.Generic;
using System.Linq;
using Uno;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls.Primitives;

namespace Windows.UI.Xaml.Automation.Peers;

public class LoopingSelectorAutomationPeer : FrameworkElementAutomationPeer, ISelectionProvider, IItemContainerProvider, IExpandCollapseProvider, IScrollProvider
{
	private class PeerMap : Dictionary<DependencyObject, LoopingSelectorItemDataAutomationPeer>
	{
	}

	private readonly PeerMap _peerMap = new PeerMap();

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ExpandCollapseState ExpandCollapseState
	{
		get
		{
			throw new NotImplementedException("The member ExpandCollapseState LoopingSelectorAutomationPeer.ExpandCollapseState is not implemented in Uno.");
		}
	}

	public bool CanSelectMultiple => false;

	public bool IsSelectionRequired => true;

	public bool HorizontallyScrollable => false;

	public bool VerticallyScrollable
	{
		get
		{
			LoopingSelector ppOwnerNoRef = null;
			GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
			bool pIsScrollable = false;
			ppOwnerNoRef?.AutomationGetIsScrollable(out pIsScrollable);
			return pIsScrollable;
		}
	}

	public double HorizontalScrollPercent => 0.0;

	public double VerticalScrollPercent
	{
		get
		{
			LoopingSelector ppOwnerNoRef = null;
			double pScrollPercent = 0.0;
			GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
			ppOwnerNoRef?.AutomationGetScrollPercent(out pScrollPercent);
			return pScrollPercent;
		}
	}

	public double VerticalViewSize
	{
		get
		{
			LoopingSelector ppOwnerNoRef = null;
			double pScrollPercent = 0.0;
			GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
			ppOwnerNoRef?.AutomationGetScrollViewSize(out pScrollPercent);
			return pScrollPercent;
		}
	}

	public double HorizontalViewSize => 100.0;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IRawElementProviderSimple FindItemByProperty(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, object value)
	{
		throw new NotImplementedException("The member IRawElementProviderSimple LoopingSelectorAutomationPeer.FindItemByProperty(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, object value) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Collapse()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.LoopingSelectorAutomationPeer", "void LoopingSelectorAutomationPeer.Collapse()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Expand()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.LoopingSelectorAutomationPeer", "void LoopingSelectorAutomationPeer.Expand()");
	}

	internal LoopingSelectorAutomationPeer(LoopingSelector pOwner)
		: base(pOwner)
	{
		InitializeImpl(pOwner);
	}

	private void InitializeImpl(LoopingSelector pOwner)
	{
	}

	private void GetOwnerAsInternalPtrNoRef(out LoopingSelector ppOwnerNoRef)
	{
		ppOwnerNoRef = null;
		UIElement owner = Owner;
		if (owner != null)
		{
			LoopingSelector loopingSelector = (ppOwnerNoRef = owner as LoopingSelector);
		}
	}

	internal void ClearPeerMap()
	{
		foreach (KeyValuePair<DependencyObject, LoopingSelectorItemDataAutomationPeer> item in _peerMap)
		{
		}
		_peerMap.Clear();
	}

	internal void RealizeItemAtIndex(int index)
	{
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationRealizeItemForAP((uint)index);
	}

	private void FindItemByPropertyImpl(IRawElementProviderSimple startAfter, AutomationProperty automationProperty, DependencyObject value, out IRawElementProviderSimple returnValue)
	{
		LoopingSelector ppOwnerNoRef = null;
		IList<object> list = null;
		returnValue = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		if (ppOwnerNoRef != null)
		{
			list = ppOwnerNoRef.Items;
		}
		if (list == null)
		{
			return;
		}
		int pIndex = 0;
		int num = 0;
		bool flag = false;
		string text = null;
		DependencyObject dependencyObject = null;
		AutomationHelper.AutomationPropertyEnum automationPropertyEnum = AutomationHelper.AutomationPropertyEnum.EmptyProperty;
		num = list.Count;
		FindStartIndex(startAfter, list, out pIndex);
		automationPropertyEnum = AutomationHelper.ConvertPropertyToEnum(automationProperty);
		if (automationPropertyEnum == AutomationHelper.AutomationPropertyEnum.NameProperty && value != null)
		{
			text = value.ToString();
		}
		else if (automationPropertyEnum == AutomationHelper.AutomationPropertyEnum.IsSelectedProperty && value != null)
		{
			dependencyObject = ppOwnerNoRef.SelectedItem as DependencyObject;
		}
		for (int i = pIndex + 1; i < num; i++)
		{
			bool flag2 = false;
			DependencyObject pItem = list[i] as DependencyObject;
			GetDataAutomationPeerForItem(pItem, out var ppPeer);
			switch (automationPropertyEnum)
			{
			case AutomationHelper.AutomationPropertyEnum.EmptyProperty:
				flag2 = true;
				break;
			case AutomationHelper.AutomationPropertyEnum.NameProperty:
			{
				AutomationPeer automationPeer = ppPeer;
				string name = automationPeer.GetName();
				if (name == text)
				{
					flag2 = true;
				}
				break;
			}
			case AutomationHelper.AutomationPropertyEnum.IsSelectedProperty:
			{
				ppPeer.GetItem(out var ppItem);
				if ((flag && dependencyObject == ppItem) || (!flag && dependencyObject != ppItem))
				{
					flag2 = true;
				}
				break;
			}
			}
			if (flag2)
			{
				AutomationPeer peer = ppPeer;
				returnValue = ProviderFromPeer(peer);
				break;
			}
		}
	}

	~LoopingSelectorAutomationPeer()
	{
		ClearPeerMap();
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		if (patternInterface == PatternInterface.Scroll || patternInterface == PatternInterface.Selection || patternInterface == PatternInterface.ItemContainer)
		{
			return this;
		}
		return null;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.List;
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		IList<AutomationPeer> list = new List<AutomationPeer>();
		if (ppOwnerNoRef != null)
		{
			int num = 0;
			IList<object> items = ppOwnerNoRef.Items;
			num = items.Count;
			for (int i = 0; i < num; i++)
			{
				DependencyObject pItem = items[i] as DependencyObject;
				GetDataAutomationPeerForItem(pItem, out var ppPeer);
				if (ppPeer != null)
				{
					ppPeer.SetItemIndex(i);
					GetContainerAutomationPeerForItem(pItem, out var ppPeer2);
					if (ppPeer2 != null && ppPeer != null)
					{
						ppPeer2.SetEventSource(ppPeer);
					}
				}
				AutomationPeer item = ppPeer;
				list.Add(item);
			}
		}
		return list;
	}

	private void GetClassNameCoreImpl(out string returnValue)
	{
		returnValue = "LoopingSelector";
	}

	public IRawElementProviderSimple[] GetSelection()
	{
		LoopingSelector ppOwnerNoRef = null;
		IRawElementProviderSimple[] result = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationTryGetSelectionUIAPeer(out var _);
		return result;
	}

	public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
	{
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationScroll(verticalAmount);
	}

	public void SetScrollPercent(double horizontalPercent, double verticalPercent)
	{
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationSetScrollPercent(verticalPercent);
	}

	public void GetDataAutomationPeerForItem(DependencyObject pItem, out LoopingSelectorItemDataAutomationPeer ppPeer)
	{
		if (!_peerMap.TryGetValue(pItem, out var value))
		{
			ppPeer = null;
		}
		else if (value == _peerMap.LastOrDefault()!.Value)
		{
			LoopingSelectorItemDataAutomationPeer loopingSelectorItemDataAutomationPeer = new LoopingSelectorItemDataAutomationPeer(pItem, this);
			_peerMap[pItem] = loopingSelectorItemDataAutomationPeer;
			ppPeer = loopingSelectorItemDataAutomationPeer;
		}
		else
		{
			ppPeer = value;
		}
	}

	internal void GetContainerAutomationPeerForItem(DependencyObject pItem, out LoopingSelectorItemAutomationPeer ppPeer)
	{
		ppPeer = null;
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationGetContainerUIAPeerForItem(pItem, out ppPeer);
	}

	private void FindStartIndex(IRawElementProviderSimple pStartAfter, IList<object> pItems, out int pIndex)
	{
		LoopingSelectorItemDataAutomationPeer loopingSelectorItemDataAutomationPeer = null;
		pIndex = -1;
		if (pStartAfter != null)
		{
			AutomationPeer automationPeer = PeerFromProvider(pStartAfter);
			LoopingSelectorItemDataAutomationPeer loopingSelectorItemDataAutomationPeer2 = automationPeer as LoopingSelectorItemDataAutomationPeer;
			loopingSelectorItemDataAutomationPeer = loopingSelectorItemDataAutomationPeer2;
		}
		if (loopingSelectorItemDataAutomationPeer != null)
		{
			DependencyObject ppItem = null;
			bool flag = false;
			int num = 0;
			loopingSelectorItemDataAutomationPeer.GetItem(out ppItem);
			num = pItems.IndexOf(ppItem);
			if (num >= 0)
			{
				pIndex = num;
			}
		}
	}

	private void TryScrollItemIntoView(DependencyObject pItem)
	{
		LoopingSelector ppOwnerNoRef = null;
		GetOwnerAsInternalPtrNoRef(out ppOwnerNoRef);
		ppOwnerNoRef?.AutomationTryScrollItemIntoView(pItem);
	}
}
