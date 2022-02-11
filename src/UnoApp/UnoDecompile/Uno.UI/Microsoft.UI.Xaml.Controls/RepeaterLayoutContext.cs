using System;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class RepeaterLayoutContext : VirtualizingLayoutContext
{
	private readonly WeakReference<ItemsRepeater> m_owner;

	protected internal override object LayoutStateCore
	{
		get
		{
			return GetOwner().LayoutState;
		}
		set
		{
			GetOwner().LayoutState = value;
		}
	}

	protected override int RecommendedAnchorIndexCore
	{
		get
		{
			int result = -1;
			ItemsRepeater owner = GetOwner();
			UIElement suggestedAnchor = owner.SuggestedAnchor;
			if (suggestedAnchor != null)
			{
				result = owner.GetElementIndex(suggestedAnchor);
			}
			return result;
		}
	}

	protected override Point LayoutOriginCore
	{
		get
		{
			return GetOwner().LayoutOrigin;
		}
		set
		{
			GetOwner().LayoutOrigin = value;
		}
	}

	public RepeaterLayoutContext(ItemsRepeater owner)
	{
		m_owner = new WeakReference<ItemsRepeater>(owner);
	}

	protected override int ItemCountCore()
	{
		return GetOwner().ItemsSourceView?.Count ?? 0;
	}

	protected override UIElement GetOrCreateElementAtCore(int index, ElementRealizationOptions options)
	{
		return GetOwner().GetElementImpl(index, (options & ElementRealizationOptions.ForceCreate) == ElementRealizationOptions.ForceCreate, (options & ElementRealizationOptions.SuppressAutoRecycle) == ElementRealizationOptions.SuppressAutoRecycle);
	}

	protected override object GetItemAtCore(int index)
	{
		return GetOwner().ItemsSourceView.GetAt(index);
	}

	protected override void RecycleElementCore(UIElement element)
	{
		ItemsRepeater owner = GetOwner();
		owner.ClearElementImpl(element);
	}

	protected override Rect RealizationRectCore()
	{
		return GetOwner().RealizationWindow;
	}

	private ItemsRepeater GetOwner()
	{
		if (!m_owner.TryGetTarget(out var target))
		{
			throw new InvalidOperationException("Owning ItemsRepeater has been collected");
		}
		return target;
	}
}
