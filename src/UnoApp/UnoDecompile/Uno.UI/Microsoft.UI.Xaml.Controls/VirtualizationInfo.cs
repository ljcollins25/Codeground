using System;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls;

internal class VirtualizationInfo
{
	public const int PhaseNotSpecified = int.MinValue;

	public const int PhaseReachedEnd = -1;

	private uint m_pinCounter;

	private int m_index = -1;

	private string m_uniqueId;

	private ElementOwner m_owner;

	private Rect m_arrangeBounds;

	private int m_phase = int.MinValue;

	private bool m_keepAlive;

	private bool m_autoRecycleCandidate;

	private WeakReference<object> m_data;

	private WeakReference<IDataTemplateComponent> m_dataTemplateComponent;

	public Rect ArrangeBounds
	{
		get
		{
			return m_arrangeBounds;
		}
		set
		{
			m_arrangeBounds = value;
		}
	}

	public string UniqueId => m_uniqueId;

	public bool KeepAlive
	{
		get
		{
			return m_keepAlive;
		}
		set
		{
			m_keepAlive = value;
		}
	}

	public bool AutoRecycleCandidate
	{
		get
		{
			return m_autoRecycleCandidate;
		}
		set
		{
			m_autoRecycleCandidate = value;
		}
	}

	public ElementOwner Owner => m_owner;

	public int Index => m_index;

	public bool IsPinned => m_pinCounter != 0;

	public bool IsHeldByLayout => m_owner == ElementOwner.Layout;

	public bool IsRealized
	{
		get
		{
			if (!IsHeldByLayout)
			{
				return m_owner == ElementOwner.PinnedPool;
			}
			return true;
		}
	}

	public bool IsInUniqueIdResetPool => m_owner == ElementOwner.UniqueIdResetPool;

	public int Phase
	{
		get
		{
			return m_phase;
		}
		set
		{
			m_phase = value;
		}
	}

	public object Data => m_data?.GetTarget();

	public IDataTemplateComponent DataTemplateComponent => m_dataTemplateComponent?.GetTarget();

	public VirtualizationInfo()
	{
		m_arrangeBounds = ItemsRepeater.InvalidRect;
	}

	public void UpdatePhasingInfo(int phase, object data, IDataTemplateComponent component)
	{
		m_phase = phase;
		m_data = new WeakReference<object>(data);
		m_dataTemplateComponent = new WeakReference<IDataTemplateComponent>(component);
	}

	public void MoveOwnershipToLayoutFromElementFactory(int index, string uniqueId)
	{
		m_owner = ElementOwner.Layout;
		m_index = index;
		m_uniqueId = uniqueId;
	}

	public void MoveOwnershipToLayoutFromUniqueIdResetPool()
	{
		m_owner = ElementOwner.Layout;
	}

	public void MoveOwnershipToLayoutFromPinnedPool()
	{
		m_owner = ElementOwner.Layout;
	}

	public void MoveOwnershipToElementFactory()
	{
		m_owner = ElementOwner.ElementFactory;
		m_pinCounter = 0u;
		m_index = -1;
		m_uniqueId = null;
		m_arrangeBounds = ItemsRepeater.InvalidRect;
	}

	public void MoveOwnershipToUniqueIdResetPoolFromLayout()
	{
		m_owner = ElementOwner.UniqueIdResetPool;
	}

	public void MoveOwnershipToAnimator()
	{
		m_owner = ElementOwner.Animator;
		m_index = -1;
		m_pinCounter = 0u;
	}

	public void MoveOwnershipToPinnedPool()
	{
		m_owner = ElementOwner.PinnedPool;
	}

	public uint AddPin()
	{
		if (!IsRealized)
		{
			throw new InvalidOperationException("You can't pin an unrealized element.");
		}
		return ++m_pinCounter;
	}

	public uint RemovePin()
	{
		if (!IsRealized)
		{
			throw new InvalidOperationException("You can't unpin an unrealized element.");
		}
		if (!IsPinned)
		{
			throw new InvalidOperationException("UnpinElement was called more often than PinElement.");
		}
		return --m_pinCounter;
	}

	public void UpdateIndex(int newIndex)
	{
		m_index = newIndex;
	}
}
