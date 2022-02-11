using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class LayoutContextAdapter : VirtualizingLayoutContext
{
	private readonly WeakReference<NonVirtualizingLayoutContext> m_nonVirtualizingContext;

	protected internal override object LayoutStateCore
	{
		get
		{
			if (!m_nonVirtualizingContext.TryGetTarget(out var target))
			{
				return null;
			}
			return target.LayoutState;
		}
		set
		{
			if (m_nonVirtualizingContext.TryGetTarget(out var target))
			{
				target.LayoutState = value;
			}
		}
	}

	protected override int RecommendedAnchorIndexCore => -1;

	protected override Point LayoutOriginCore
	{
		get
		{
			return new Point(0.0, 0.0);
		}
		set
		{
			if (value != new Point(0.0, 0.0))
			{
				throw new ArgumentException("LayoutOrigin must be at (0,0) when RealizationRect is infinite sized.");
			}
		}
	}

	public LayoutContextAdapter(NonVirtualizingLayoutContext nonVirtualizingContext)
	{
		m_nonVirtualizingContext = new WeakReference<NonVirtualizingLayoutContext>(nonVirtualizingContext);
	}

	protected override int ItemCountCore()
	{
		if (!m_nonVirtualizingContext.TryGetTarget(out var target))
		{
			return 0;
		}
		return target.Children.Count;
	}

	protected override object GetItemAtCore(int index)
	{
		if (!m_nonVirtualizingContext.TryGetTarget(out var target))
		{
			return null;
		}
		return target.Children[index];
	}

	protected override UIElement GetOrCreateElementAtCore(int index, ElementRealizationOptions options)
	{
		if (!m_nonVirtualizingContext.TryGetTarget(out var target))
		{
			return null;
		}
		return target.Children[index];
	}

	protected override void RecycleElementCore(UIElement element)
	{
	}

	private int GetElementIndexCore(UIElement element)
	{
		if (m_nonVirtualizingContext.TryGetTarget(out var target))
		{
			IReadOnlyList<UIElement> children = target.Children;
			for (int i = 0; i < children.Count; i++)
			{
				if (children[i] == element)
				{
					return i;
				}
			}
		}
		return -1;
	}

	protected override Rect RealizationRectCore()
	{
		return new Rect(0.0, 0.0, double.PositiveInfinity, double.PositiveInfinity);
	}
}
