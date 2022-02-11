using System;
using Uno.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

internal class UniformGridLayoutState
{
	private FlowLayoutAlgorithm m_flowAlgorithm = new FlowLayoutAlgorithm();

	private double m_effectiveItemWidth;

	private double m_effectiveItemHeight;

	public void InitializeForContext(VirtualizingLayoutContext context, IFlowLayoutAlgorithmDelegates callbacks)
	{
		m_flowAlgorithm.InitializeForContext(context, callbacks);
		context.LayoutStateCore = this;
	}

	public void UninitializeForContext(VirtualizingLayoutContext context)
	{
		m_flowAlgorithm.UninitializeForContext(context);
	}

	internal void EnsureElementSize(Size availableSize, VirtualizingLayoutContext context, double layoutItemWidth, double LayoutItemHeight, UniformGridLayoutItemsStretch stretch, Orientation orientation, double minRowSpacing, double minColumnSpacing, uint maxItemsPerLine)
	{
		if (maxItemsPerLine == 0)
		{
			maxItemsPerLine = 1u;
		}
		if (context.ItemCount <= 0)
		{
			return;
		}
		UIElement elementIfRealized = m_flowAlgorithm.GetElementIfRealized(0);
		if (elementIfRealized != null)
		{
			elementIfRealized.Measure(availableSize);
			SetSize(elementIfRealized.DesiredSize, layoutItemWidth, LayoutItemHeight, availableSize, stretch, orientation, minRowSpacing, minColumnSpacing, maxItemsPerLine);
			return;
		}
		UIElement orCreateElementAt = context.GetOrCreateElementAt(0, ElementRealizationOptions.ForceCreate);
		if (orCreateElementAt != null)
		{
			orCreateElementAt.Measure(availableSize);
			SetSize(orCreateElementAt.DesiredSize, layoutItemWidth, LayoutItemHeight, availableSize, stretch, orientation, minRowSpacing, minColumnSpacing, maxItemsPerLine);
			context.RecycleElement(orCreateElementAt);
		}
	}

	private void SetSize(Size desiredItemSize, double layoutItemWidth, double LayoutItemHeight, Size availableSize, UniformGridLayoutItemsStretch stretch, Orientation orientation, double minRowSpacing, double minColumnSpacing, uint maxItemsPerLine)
	{
		if (maxItemsPerLine == 0)
		{
			maxItemsPerLine = 1u;
		}
		m_effectiveItemWidth = (layoutItemWidth.IsNaN() ? desiredItemSize.Width : layoutItemWidth);
		m_effectiveItemHeight = (LayoutItemHeight.IsNaN() ? desiredItemSize.Height : LayoutItemHeight);
		double num = ((orientation == Orientation.Horizontal) ? availableSize.Width : availableSize.Height);
		double num2 = ((orientation == Orientation.Vertical) ? minRowSpacing : minColumnSpacing);
		double num3 = ((orientation == Orientation.Horizontal) ? m_effectiveItemWidth : m_effectiveItemHeight);
		double num4 = 0.0;
		if (num.IsFinite())
		{
			uint num5 = Math.Min(maxItemsPerLine, (uint)Math.Max(1.0, num / (num3 + num2)));
			double num6 = (double)num5 * (num3 + num2) - num2;
			int num7 = (int)(num - num6);
			num4 = num7 / (int)num5;
		}
		switch (stretch)
		{
		case UniformGridLayoutItemsStretch.Fill:
			if (orientation == Orientation.Horizontal)
			{
				m_effectiveItemWidth += num4;
			}
			else
			{
				m_effectiveItemHeight += num4;
			}
			break;
		case UniformGridLayoutItemsStretch.Uniform:
		{
			double num8 = ((orientation == Orientation.Horizontal) ? m_effectiveItemHeight : m_effectiveItemWidth);
			double num9 = num8 * (num4 / num3);
			if (orientation == Orientation.Horizontal)
			{
				m_effectiveItemWidth += num4;
				m_effectiveItemHeight += num9;
			}
			else
			{
				m_effectiveItemHeight += num4;
				m_effectiveItemWidth += num9;
			}
			break;
		}
		}
	}

	public FlowLayoutAlgorithm FlowAlgorithm()
	{
		return m_flowAlgorithm;
	}

	public double EffectiveItemWidth()
	{
		return m_effectiveItemWidth;
	}

	public double EffectiveItemHeight()
	{
		return m_effectiveItemHeight;
	}
}
