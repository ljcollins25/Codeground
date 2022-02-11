using System;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

public class VirtualizingLayoutContext : LayoutContext
{
	private NonVirtualizingLayoutContext m_contextAdapter;

	public int ItemCount => ItemCountCore();

	public Point LayoutOrigin
	{
		get
		{
			return LayoutOriginCore;
		}
		set
		{
			LayoutOriginCore = value;
		}
	}

	public Rect RealizationRect => RealizationRectCore();

	public int RecommendedAnchorIndex => RecommendedAnchorIndexCore;

	protected virtual Point LayoutOriginCore
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	protected virtual int RecommendedAnchorIndexCore
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public object GetItemAt(int index)
	{
		return GetItemAtCore(index);
	}

	public UIElement GetOrCreateElementAt(int index)
	{
		return GetOrCreateElementAtCore(index, ElementRealizationOptions.None);
	}

	public UIElement GetOrCreateElementAt(int index, ElementRealizationOptions options)
	{
		return GetOrCreateElementAtCore(index, options);
	}

	public void RecycleElement(UIElement element)
	{
		RecycleElementCore(element);
	}

	protected virtual object GetItemAtCore(int index)
	{
		throw new NotImplementedException();
	}

	protected virtual UIElement GetOrCreateElementAtCore(int index, ElementRealizationOptions options)
	{
		throw new NotImplementedException();
	}

	protected virtual void RecycleElementCore(UIElement element)
	{
		throw new NotImplementedException();
	}

	protected virtual Rect RealizationRectCore()
	{
		throw new NotImplementedException();
	}

	protected virtual int ItemCountCore()
	{
		throw new NotImplementedException();
	}

	internal NonVirtualizingLayoutContext GetNonVirtualizingContextAdapter()
	{
		if (m_contextAdapter == null)
		{
			m_contextAdapter = new VirtualLayoutContextAdapter(this);
		}
		return m_contextAdapter;
	}
}
