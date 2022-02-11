using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Uno.Disposables;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls;

internal class ViewManager
{
	private ItemsRepeater m_owner;

	private List<PinnedElementInfo> m_pinnedPool = new List<PinnedElementInfo>();

	private UniqueIdElementPool m_resetPool;

	private UIElement m_lastFocusedElement;

	private bool m_isDataSourceStableResetPending;

	private Phaser m_phaser;

	private ElementFactoryGetArgs m_ElementFactoryGetArgs;

	private ElementFactoryRecycleArgs m_ElementFactoryRecycleArgs;

	private int m_firstRealizedElementIndexHeldByLayout = int.MaxValue;

	private int m_lastRealizedElementIndexHeldByLayout = int.MinValue;

	private const int FirstRealizedElementIndexDefault = int.MaxValue;

	private const int LastRealizedElementIndexDefault = int.MinValue;

	private bool m_gotFocus;

	public ViewManager(ItemsRepeater owner)
	{
		m_owner = owner;
		m_resetPool = new UniqueIdElementPool(owner);
		m_lastFocusedElement = owner;
		m_phaser = new Phaser(owner);
		m_ElementFactoryGetArgs = new ElementFactoryGetArgs();
		m_ElementFactoryRecycleArgs = new ElementFactoryRecycleArgs();
	}

	public UIElement GetElement(int index, bool forceCreate, bool suppressAutoRecycle)
	{
		UIElement uIElement = (forceCreate ? null : GetElementIfAlreadyHeldByLayout(index));
		if (uIElement == null)
		{
			UIElement madeAnchor = m_owner.MadeAnchor;
			if (madeAnchor != null)
			{
				VirtualizationInfo virtualizationInfo = ItemsRepeater.TryGetVirtualizationInfo(madeAnchor);
				if (virtualizationInfo.Index == index)
				{
					uIElement = madeAnchor;
				}
			}
		}
		if (uIElement == null)
		{
			uIElement = GetElementFromUniqueIdResetPool(index);
		}
		if (uIElement == null)
		{
			uIElement = GetElementFromPinnedElements(index);
		}
		if (uIElement == null)
		{
			uIElement = GetElementFromElementFactory(index);
		}
		VirtualizationInfo virtualizationInfo2 = ItemsRepeater.TryGetVirtualizationInfo(uIElement);
		if (suppressAutoRecycle)
		{
			virtualizationInfo2.AutoRecycleCandidate = false;
		}
		else
		{
			virtualizationInfo2.AutoRecycleCandidate = true;
			virtualizationInfo2.KeepAlive = true;
		}
		return uIElement;
	}

	public void ClearElement(UIElement element, bool isClearedDueToCollectionChange)
	{
		VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(element);
		int index = virtualizationInfo.Index;
		if (!ClearElementToUniqueIdResetPool(element, virtualizationInfo) && !ClearElementToAnimator(element, virtualizationInfo) && !ClearElementToPinnedPool(element, virtualizationInfo, isClearedDueToCollectionChange))
		{
			ClearElementToElementFactory(element);
		}
		if (index == m_firstRealizedElementIndexHeldByLayout && index == m_lastRealizedElementIndexHeldByLayout)
		{
			InvalidateRealizedIndicesHeldByLayout();
		}
		else if (index == m_firstRealizedElementIndexHeldByLayout)
		{
			m_firstRealizedElementIndexHeldByLayout++;
		}
		else if (index == m_lastRealizedElementIndexHeldByLayout)
		{
			m_lastRealizedElementIndexHeldByLayout--;
		}
	}

	public void ClearElementToElementFactory(UIElement element)
	{
		m_owner.OnElementClearing(element);
		if (m_owner.ItemTemplateShim != null)
		{
			if (m_ElementFactoryRecycleArgs == null)
			{
				m_ElementFactoryRecycleArgs = new ElementFactoryRecycleArgs();
			}
			ElementFactoryRecycleArgs elementFactoryRecycleArgs = m_ElementFactoryRecycleArgs;
			elementFactoryRecycleArgs.Element = element;
			elementFactoryRecycleArgs.Parent = m_owner;
			m_owner.ItemTemplateShim.RecycleElement(elementFactoryRecycleArgs);
			elementFactoryRecycleArgs.Element = null;
			elementFactoryRecycleArgs.Parent = null;
		}
		else
		{
			IList<UIElement> children = m_owner.Children;
			int num = 0;
			num = children.IndexOf(element);
			if (num < 0)
			{
				throw new InvalidOperationException("ItemsRepeater's child not found in its Children collection.");
			}
			children.RemoveAt(num);
		}
		VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(element);
		virtualizationInfo.MoveOwnershipToElementFactory();
		m_phaser.StopPhasing(element, virtualizationInfo);
		if (m_lastFocusedElement == element)
		{
			int index = virtualizationInfo.Index;
			MoveFocusFromClearedIndex(index);
		}
	}

	private void MoveFocusFromClearedIndex(int clearedIndex)
	{
		UIElement uIElement = null;
		Control control = FindFocusCandidate(clearedIndex, uIElement);
		if (control != null)
		{
			FocusState focusState = FocusState.Programmatic;
			if (m_lastFocusedElement is Control control2)
			{
				focusState = control2.FocusState;
			}
			focusState = ((focusState == FocusState.Unfocused) ? FocusState.Programmatic : focusState);
			control.Focus(focusState);
			m_lastFocusedElement = uIElement;
			UpdatePin(uIElement, addPin: true);
		}
		else
		{
			m_lastFocusedElement = null;
		}
	}

	private Control FindFocusCandidate(int clearedIndex, UIElement focusedChild)
	{
		int num = int.MinValue;
		int num2 = int.MaxValue;
		UIElement uIElement = null;
		UIElement uIElement2 = null;
		IList<UIElement> children = m_owner.Children;
		for (int i = 0; i < children.Count; i++)
		{
			UIElement uIElement3 = children[i];
			VirtualizationInfo virtualizationInfo = ItemsRepeater.TryGetVirtualizationInfo(uIElement3);
			if (virtualizationInfo == null || !virtualizationInfo.IsHeldByLayout)
			{
				continue;
			}
			int index = virtualizationInfo.Index;
			if (index < clearedIndex)
			{
				if (index > num)
				{
					num = index;
					uIElement2 = uIElement3;
				}
			}
			else if (index >= clearedIndex && index < num2)
			{
				num2 = index;
				uIElement = uIElement3;
			}
		}
		Control control = null;
		if (uIElement != null)
		{
			control = uIElement as Control;
			if (control == null)
			{
				DependencyObject dependencyObject = FocusManager.FindFirstFocusableElement(uIElement);
				if (dependencyObject != null)
				{
					control = dependencyObject as Control;
				}
			}
		}
		return control;
	}

	public int GetElementIndex(VirtualizationInfo virtInfo)
	{
		if (virtInfo == null)
		{
			return -1;
		}
		if (!virtInfo.IsRealized && !virtInfo.IsInUniqueIdResetPool)
		{
			return -1;
		}
		return virtInfo.Index;
	}

	public void PrunePinnedElements()
	{
		EnsureEventSubscriptions();
		for (int i = 0; i < m_pinnedPool.Count; i++)
		{
			PinnedElementInfo pinnedElementInfo = m_pinnedPool[i];
			VirtualizationInfo virtualizationInfo = pinnedElementInfo.VirtualizationInfo;
			if (!virtualizationInfo.IsPinned)
			{
				m_pinnedPool.RemoveAt(i);
				i--;
				ClearElementToElementFactory(pinnedElementInfo.PinnedElement);
			}
		}
	}

	public void UpdatePin(UIElement element, bool addPin)
	{
		DependencyObject parent = CachedVisualTreeHelpers.GetParent(element);
		DependencyObject dependencyObject = element;
		while (parent != null)
		{
			if (parent is ItemsRepeater itemsRepeater)
			{
				VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(dependencyObject as UIElement);
				if (virtualizationInfo.IsRealized)
				{
					if (addPin)
					{
						virtualizationInfo.AddPin();
					}
					else if (virtualizationInfo.IsPinned && virtualizationInfo.RemovePin() == 0)
					{
						itemsRepeater.InvalidateMeasure();
					}
				}
			}
			dependencyObject = parent;
			parent = CachedVisualTreeHelpers.GetParent(dependencyObject);
		}
	}

	public void OnItemsSourceChanged(object _, NotifyCollectionChangedEventArgs args)
	{
		switch (args.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			int newStartingIndex = args.NewStartingIndex;
			int count = args.NewItems!.Count;
			EnsureFirstLastRealizedIndices();
			if (newStartingIndex <= m_lastRealizedElementIndexHeldByLayout)
			{
				m_lastRealizedElementIndexHeldByLayout += count;
				IList<UIElement> children2 = m_owner.Children;
				int count2 = children2.Count;
				for (int j = 0; j < count2; j++)
				{
					UIElement element2 = children2[j];
					VirtualizationInfo virtualizationInfo2 = ItemsRepeater.GetVirtualizationInfo(element2);
					int index = virtualizationInfo2.Index;
					if (virtualizationInfo2.IsRealized && index >= newStartingIndex)
					{
						UpdateElementIndex(element2, virtualizationInfo2, index + count);
					}
				}
				break;
			}
			for (int k = 0; k < m_pinnedPool.Count; k++)
			{
				PinnedElementInfo pinnedElementInfo = m_pinnedPool[k];
				VirtualizationInfo virtualizationInfo3 = pinnedElementInfo.VirtualizationInfo;
				int index2 = virtualizationInfo3.Index;
				if (virtualizationInfo3.IsRealized && index2 >= newStartingIndex)
				{
					UIElement pinnedElement = pinnedElementInfo.PinnedElement;
					UpdateElementIndex(pinnedElement, virtualizationInfo3, index2 + count);
				}
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		{
			int oldStartingIndex = args.OldStartingIndex;
			int newStartingIndex2 = args.NewStartingIndex;
			int count3 = args.OldItems!.Count;
			int count4 = args.NewItems!.Count;
			if (oldStartingIndex != newStartingIndex2)
			{
				throw new InvalidOperationException("Replace is only allowed with OldStartingIndex equals to NewStartingIndex.");
			}
			if (count3 == 0)
			{
				throw new InvalidOperationException("Replace notification with args.OldItemsCount value of 0 is not allowed. Use Insert action instead.");
			}
			if (count4 == 0)
			{
				throw new InvalidOperationException("Replace notification with args.NewItemCount value of 0 is not allowed. Use Remove action instead.");
			}
			int num = count4 - count3;
			if (num == 0)
			{
				break;
			}
			IList<UIElement> children3 = m_owner.Children;
			for (int l = 0; l < children3.Count; l++)
			{
				UIElement element3 = children3[l];
				VirtualizationInfo virtualizationInfo4 = ItemsRepeater.GetVirtualizationInfo(element3);
				int index3 = virtualizationInfo4.Index;
				if (virtualizationInfo4.IsRealized && index3 >= oldStartingIndex + count3)
				{
					UpdateElementIndex(element3, virtualizationInfo4, index3 + num);
				}
			}
			EnsureFirstLastRealizedIndices();
			m_lastRealizedElementIndexHeldByLayout += num;
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			int oldStartingIndex2 = args.OldStartingIndex;
			int count5 = args.OldItems!.Count;
			IList<UIElement> children4 = m_owner.Children;
			for (int m = 0; m < children4.Count; m++)
			{
				UIElement element4 = children4[m];
				VirtualizationInfo virtualizationInfo5 = ItemsRepeater.GetVirtualizationInfo(element4);
				int index4 = virtualizationInfo5.Index;
				if (virtualizationInfo5.IsRealized)
				{
					if (virtualizationInfo5.AutoRecycleCandidate && oldStartingIndex2 <= index4 && index4 < oldStartingIndex2 + count5)
					{
						m_owner.ClearElementImpl(element4);
					}
					else if (index4 >= oldStartingIndex2 + count5)
					{
						UpdateElementIndex(element4, virtualizationInfo5, index4 - count5);
					}
				}
			}
			InvalidateRealizedIndicesHeldByLayout();
			break;
		}
		case NotifyCollectionChangedAction.Reset:
			if (!m_isDataSourceStableResetPending)
			{
				if (m_owner.ItemsSourceView.HasKeyIndexMapping)
				{
					m_isDataSourceStableResetPending = true;
				}
				IList<UIElement> children = m_owner.Children;
				for (int i = 0; i < children.Count; i++)
				{
					UIElement element = children[i];
					VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(element);
					if (virtualizationInfo.IsRealized && virtualizationInfo.AutoRecycleCandidate)
					{
						m_owner.ClearElementImpl(element);
					}
				}
			}
			InvalidateRealizedIndicesHeldByLayout();
			break;
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	private void EnsureFirstLastRealizedIndices()
	{
		if (m_firstRealizedElementIndexHeldByLayout == int.MaxValue)
		{
			UIElement elementIfAlreadyHeldByLayout = GetElementIfAlreadyHeldByLayout(0);
		}
	}

	public void OnLayoutChanging()
	{
		if (m_owner.ItemsSourceView != null && m_owner.ItemsSourceView.HasKeyIndexMapping)
		{
			m_isDataSourceStableResetPending = true;
		}
	}

	public void OnOwnerArranged()
	{
		if (!m_isDataSourceStableResetPending)
		{
			return;
		}
		m_isDataSourceStableResetPending = false;
		foreach (KeyValuePair<string, UIElement> item in m_resetPool)
		{
			ClearElement(item.Value, isClearedDueToCollectionChange: true);
		}
		m_resetPool.Clear();
		InvalidateRealizedIndicesHeldByLayout();
	}

	private UIElement GetElementIfAlreadyHeldByLayout(int index)
	{
		UIElement result = null;
		bool flag = m_firstRealizedElementIndexHeldByLayout == int.MaxValue;
		bool flag2 = m_firstRealizedElementIndexHeldByLayout <= index && index <= m_lastRealizedElementIndexHeldByLayout;
		if (flag || flag2)
		{
			IList<UIElement> children = m_owner.Children;
			for (int i = 0; i < children.Count; i++)
			{
				UIElement uIElement = children[i];
				VirtualizationInfo virtualizationInfo = ItemsRepeater.TryGetVirtualizationInfo(uIElement);
				if (virtualizationInfo == null || !virtualizationInfo.IsHeldByLayout)
				{
					continue;
				}
				int index2 = virtualizationInfo.Index;
				m_firstRealizedElementIndexHeldByLayout = Math.Min(m_firstRealizedElementIndexHeldByLayout, index2);
				m_lastRealizedElementIndexHeldByLayout = Math.Max(m_lastRealizedElementIndexHeldByLayout, index2);
				if (virtualizationInfo.Index == index)
				{
					result = uIElement;
					if (!flag)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	private UIElement GetElementFromUniqueIdResetPool(int index)
	{
		UIElement uIElement = null;
		if (m_isDataSourceStableResetPending)
		{
			uIElement = m_resetPool.Remove(index);
			if (uIElement != null)
			{
				VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(uIElement);
				virtualizationInfo.MoveOwnershipToLayoutFromUniqueIdResetPool();
				UpdateElementIndex(uIElement, virtualizationInfo, index);
				m_firstRealizedElementIndexHeldByLayout = Math.Min(m_firstRealizedElementIndexHeldByLayout, index);
				m_lastRealizedElementIndexHeldByLayout = Math.Max(m_lastRealizedElementIndexHeldByLayout, index);
			}
		}
		return uIElement;
	}

	private UIElement GetElementFromPinnedElements(int index)
	{
		UIElement result = null;
		for (int i = 0; i < m_pinnedPool.Count; i++)
		{
			PinnedElementInfo pinnedElementInfo = m_pinnedPool[i];
			VirtualizationInfo virtualizationInfo = pinnedElementInfo.VirtualizationInfo;
			if (virtualizationInfo.Index == index)
			{
				m_pinnedPool.RemoveAt(i);
				result = pinnedElementInfo.PinnedElement;
				pinnedElementInfo.VirtualizationInfo.MoveOwnershipToLayoutFromPinnedPool();
				m_firstRealizedElementIndexHeldByLayout = Math.Min(m_firstRealizedElementIndexHeldByLayout, index);
				m_lastRealizedElementIndexHeldByLayout = Math.Max(m_lastRealizedElementIndexHeldByLayout, index);
				break;
			}
		}
		return result;
	}

	private UIElement GetElementFromElementFactory(int index)
	{
		object data = m_owner.ItemsSourceView.GetAt(index);
		UIElement uIElement = GetElement();
		VirtualizationInfo virtualizationInfo = ItemsRepeater.TryGetVirtualizationInfo(uIElement);
		if (virtualizationInfo == null)
		{
			virtualizationInfo = ItemsRepeater.CreateAndInitializeVirtualizationInfo(uIElement);
		}
		if (data != uIElement)
		{
			IDataTemplateComponent dataTemplateComponent = CachedVisualTreeHelpers.GetDataTemplateComponent(uIElement);
			if (dataTemplateComponent != null)
			{
				dataTemplateComponent.Recycle();
				int nextPhase = -1;
				dataTemplateComponent.ProcessBindings(data, index, 0, out nextPhase);
				virtualizationInfo.UpdatePhasingInfo(nextPhase, (nextPhase > 0) ? data : null, (nextPhase > 0) ? dataTemplateComponent : null);
			}
			else if (uIElement is FrameworkElement frameworkElement)
			{
				object dataContext = data;
				if (data is FrameworkElement frameworkElement2)
				{
					object dataContext2 = frameworkElement2.DataContext;
					if (dataContext2 != null)
					{
						dataContext = dataContext2;
					}
				}
				frameworkElement.DataContext = dataContext;
			}
		}
		virtualizationInfo.MoveOwnershipToLayoutFromElementFactory(index, m_owner.ItemsSourceView.HasKeyIndexMapping ? m_owner.ItemsSourceView.KeyFromIndex(index) : null);
		ItemsRepeater owner = m_owner;
		owner.OnUnoBeforeElementPrepared(uIElement, index);
		IList<UIElement> children = owner.Children;
		if (CachedVisualTreeHelpers.GetParent(uIElement) != owner)
		{
			children.Add(uIElement);
		}
		owner.AnimationManager.OnElementPrepared(uIElement);
		owner.OnElementPrepared(uIElement, index);
		if (data != uIElement)
		{
			m_phaser.PhaseElement(uIElement, virtualizationInfo);
		}
		m_firstRealizedElementIndexHeldByLayout = Math.Min(m_firstRealizedElementIndexHeldByLayout, index);
		m_lastRealizedElementIndexHeldByLayout = Math.Max(m_lastRealizedElementIndexHeldByLayout, index);
		return uIElement;
		UIElement GetElement()
		{
			IElementFactoryShim itemTemplateShim = m_owner.ItemTemplateShim;
			if (itemTemplateShim == null)
			{
				if (data is UIElement result)
				{
					return result;
				}
				DataTemplate itemTemplate = new DataTemplate(delegate
				{
					TextBlock textBlock = new TextBlock();
					textBlock.SetBinding(TextBlock.TextProperty, new Binding());
					return textBlock;
				});
				m_owner.ItemTemplate = itemTemplate;
				itemTemplateShim = m_owner.ItemTemplateShim;
			}
			if (m_ElementFactoryGetArgs == null)
			{
				m_ElementFactoryGetArgs = new ElementFactoryGetArgs();
			}
			ElementFactoryGetArgs args = m_ElementFactoryGetArgs;
			using (Disposable.Create(delegate
			{
				args.Data = null;
				args.Parent = null;
			}))
			{
				args.Data = data;
				args.Parent = m_owner;
				args.Index = index;
				return itemTemplateShim.GetElement(args);
			}
		}
	}

	private bool ClearElementToUniqueIdResetPool(UIElement element, VirtualizationInfo virtInfo)
	{
		if (m_isDataSourceStableResetPending)
		{
			m_resetPool.Add(element);
			virtInfo.MoveOwnershipToUniqueIdResetPoolFromLayout();
		}
		return m_isDataSourceStableResetPending;
	}

	private bool ClearElementToAnimator(UIElement element, VirtualizationInfo virtInfo)
	{
		bool flag = m_owner.AnimationManager.ClearElement(element);
		if (flag)
		{
			int index = virtInfo.Index;
			virtInfo.MoveOwnershipToAnimator();
			if (m_lastFocusedElement == element)
			{
				MoveFocusFromClearedIndex(index);
			}
		}
		return flag;
	}

	private bool ClearElementToPinnedPool(UIElement element, VirtualizationInfo virtInfo, bool isClearedDueToCollectionChange)
	{
		bool flag = !isClearedDueToCollectionChange && virtInfo.IsPinned;
		if (flag)
		{
			m_pinnedPool.Add(new PinnedElementInfo(element));
			virtInfo.MoveOwnershipToPinnedPool();
		}
		return flag;
	}

	private void UpdateFocusedElement()
	{
		UIElement uIElement = null;
		DependencyObject dependencyObject = FocusManager.GetFocusedElement() as DependencyObject;
		if (dependencyObject != null)
		{
			DependencyObject parent = CachedVisualTreeHelpers.GetParent(dependencyObject);
			UIElement owner = m_owner;
			while (parent != null)
			{
				if (parent is ItemsRepeater itemsRepeater)
				{
					UIElement uIElement2 = dependencyObject as UIElement;
					if (itemsRepeater == owner && ItemsRepeater.GetVirtualizationInfo(uIElement2).IsRealized)
					{
						uIElement = uIElement2;
					}
					break;
				}
				dependencyObject = parent;
				parent = CachedVisualTreeHelpers.GetParent(dependencyObject);
			}
		}
		if (m_lastFocusedElement != uIElement)
		{
			if (m_lastFocusedElement != null)
			{
				UpdatePin(m_lastFocusedElement, addPin: false);
			}
			if (uIElement != null)
			{
				UpdatePin(uIElement, addPin: true);
			}
			m_lastFocusedElement = uIElement;
		}
	}

	private void OnFocusChanged(object _, RoutedEventArgs args)
	{
		UpdateFocusedElement();
	}

	private void EnsureEventSubscriptions()
	{
		if (!m_gotFocus)
		{
			m_owner.GotFocus += OnFocusChanged;
			m_owner.LostFocus += OnFocusChanged;
			m_gotFocus = true;
		}
	}

	private void UpdateElementIndex(UIElement element, VirtualizationInfo virtInfo, int index)
	{
		int index2 = virtInfo.Index;
		if (index2 != index)
		{
			virtInfo.UpdateIndex(index);
			m_owner.OnElementIndexChanged(element, index2, index);
		}
	}

	private void InvalidateRealizedIndicesHeldByLayout()
	{
		m_firstRealizedElementIndexHeldByLayout = int.MaxValue;
		m_lastRealizedElementIndexHeldByLayout = int.MinValue;
	}
}
