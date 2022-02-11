using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Automation.Provider;

namespace Windows.UI.Xaml.Automation.Peers;

public class LoopingSelectorItemDataAutomationPeer : AutomationPeer, IVirtualizedItemProvider
{
	private DependencyObject _tpItem;

	private WeakReference<LoopingSelectorAutomationPeer> _wrParent;

	private int _itemIndex;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void Realize()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.LoopingSelectorItemDataAutomationPeer", "void LoopingSelectorItemDataAutomationPeer.Realize()");
	}

	internal LoopingSelectorItemDataAutomationPeer(DependencyObject pItem, LoopingSelectorAutomationPeer pOwner)
	{
		_itemIndex = -1;
		InitializeImpl(pItem, pOwner);
	}

	private void InitializeImpl(DependencyObject pItem, LoopingSelectorAutomationPeer pOwner)
	{
		SetParent(pOwner);
		SetItem(pItem);
	}

	private void SetParent(LoopingSelectorAutomationPeer pOwner)
	{
		_wrParent = new WeakReference<LoopingSelectorAutomationPeer>(pOwner);
		if (pOwner != null)
		{
			SetParent((AutomationPeer)pOwner);
		}
		else
		{
			SetParent((AutomationPeer)null);
		}
	}

	public void SetItem(DependencyObject pItem)
	{
		_tpItem = pItem;
	}

	internal void GetItem(out DependencyObject ppItem)
	{
		ppItem = null;
		ppItem = _tpItem;
	}

	public void SetItemIndex(int index)
	{
		_itemIndex = index;
	}

	private void ThrowElementNotAvailableException()
	{
		throw new InvalidOperationException();
	}

	private void GetContainerAutomationPeer(out AutomationPeer ppContainer)
	{
		ppContainer = null;
		LoopingSelectorAutomationPeer target = null;
		WeakReference<LoopingSelectorAutomationPeer> wrParent = _wrParent;
		if (wrParent != null && wrParent.TryGetTarget(out target))
		{
			target.GetContainerAutomationPeerForItem(_tpItem, out var ppPeer);
			if (ppPeer == null)
			{
				Realize();
				target.GetContainerAutomationPeerForItem(_tpItem, out ppPeer);
			}
			if (ppPeer != null)
			{
				ppContainer = ppPeer;
			}
		}
	}

	private void RealizeImpl()
	{
		LoopingSelectorAutomationPeer target = null;
		WeakReference<LoopingSelectorAutomationPeer> wrParent = _wrParent;
		if (wrParent != null && wrParent.TryGetTarget(out target))
		{
			target.RealizeItemAtIndex(_itemIndex);
		}
	}

	protected override object GetPatternCore(PatternInterface patternInterface)
	{
		DependencyObject result = null;
		if (patternInterface == PatternInterface.VirtualizedItem)
		{
			result = this;
		}
		else
		{
			GetContainerAutomationPeer(out var ppContainer);
			if (ppContainer != null)
			{
				result = ppContainer.GetPattern(patternInterface) as DependencyObject;
			}
		}
		return result;
	}

	protected override string GetAcceleratorKeyCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetAcceleratorKey();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetAccessKeyCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetAccessKey();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		GetContainerAutomationPeer(out var ppContainer);
		return ppContainer?.GetAutomationControlType() ?? AutomationControlType.ListItem;
	}

	protected override string GetAutomationIdCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetAutomationId();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override Rect GetBoundingRectangleCore()
	{
		Rect result = default(Rect);
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			return ppContainer.GetBoundingRectangle();
		}
		ThrowElementNotAvailableException();
		return result;
	}

	protected override IList<AutomationPeer> GetChildrenCore()
	{
		GetContainerAutomationPeer(out var ppContainer);
		return ppContainer?.GetChildren();
	}

	protected override string GetClassNameCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetClassName();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override Point GetClickablePointCore()
	{
		Point result = default(Point);
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			return ppContainer.GetClickablePoint();
		}
		ThrowElementNotAvailableException();
		return result;
	}

	protected override string GetHelpTextCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetHelpText();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetItemStatusCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetItemStatus();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetItemTypeCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetItemType();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override AutomationPeer GetLabeledByCore()
	{
		AutomationPeer result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLabeledBy();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLocalizedControlType();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetNameCore()
	{
		string result = null;
		if (_tpItem != null)
		{
			result = AutomationHelper.GetPlainText(_tpItem);
		}
		return result;
	}

	protected override AutomationOrientation GetOrientationCore()
	{
		AutomationOrientation result = AutomationOrientation.None;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetOrientation();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override AutomationLiveSetting GetLiveSettingCore()
	{
		AutomationLiveSetting result = AutomationLiveSetting.Off;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLiveSetting();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override IReadOnlyList<AutomationPeer> GetControlledPeersCore()
	{
		return null;
	}

	protected override bool HasKeyboardFocusCore()
	{
		GetContainerAutomationPeer(out var ppContainer);
		return ppContainer?.HasKeyboardFocus() ?? false;
	}

	protected override bool IsContentElementCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsContentElement();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override bool IsControlElementCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsControlElement();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override bool IsEnabledCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsEnabled();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override bool IsKeyboardFocusableCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsKeyboardFocusable();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override bool IsOffscreenCore()
	{
		GetContainerAutomationPeer(out var ppContainer);
		return ppContainer?.IsOffscreen() ?? true;
	}

	protected override bool IsPasswordCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsPassword();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override bool IsRequiredForFormCore()
	{
		bool result = false;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.IsRequiredForForm();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override void SetFocusCore()
	{
		GetContainerAutomationPeer(out var ppContainer);
		ppContainer?.SetFocus();
	}

	protected override IList<AutomationPeerAnnotation> GetAnnotationsCore()
	{
		IList<AutomationPeerAnnotation> result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetAnnotations();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override int GetPositionInSetCore()
	{
		int result = -1;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetPositionInSet();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override int GetSizeOfSetCore()
	{
		int result = 0;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetSizeOfSet();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override int GetLevelCore()
	{
		int result = 0;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLevel();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override AutomationLandmarkType GetLandmarkTypeCore()
	{
		AutomationLandmarkType result = AutomationLandmarkType.None;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLandmarkType();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}

	protected override string GetLocalizedLandmarkTypeCore()
	{
		string result = null;
		GetContainerAutomationPeer(out var ppContainer);
		if (ppContainer != null)
		{
			result = ppContainer.GetLocalizedLandmarkType();
		}
		else
		{
			ThrowElementNotAvailableException();
		}
		return result;
	}
}
