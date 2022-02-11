using System;

namespace Microsoft.UI.Xaml.Controls;

public class StackLayoutState
{
	private const int BufferSize = 100;

	private FlowLayoutAlgorithm m_flowAlgorithm;

	private double[] m_estimationBuffer = new double[100];

	private double m_totalElementSize;

	private double m_maxArrangeBounds;

	private int m_totalElementsMeasured;

	internal FlowLayoutAlgorithm FlowAlgorithm => m_flowAlgorithm;

	internal double TotalElementSize => m_totalElementSize;

	internal double MaxArrangeBounds => m_maxArrangeBounds;

	internal int TotalElementsMeasured => m_totalElementsMeasured;

	public StackLayoutState()
	{
		m_flowAlgorithm = new FlowLayoutAlgorithm();
	}

	internal void InitializeForContext(VirtualizingLayoutContext context, IFlowLayoutAlgorithmDelegates callbacks)
	{
		m_flowAlgorithm.InitializeForContext(context, callbacks);
		if (m_estimationBuffer.Length == 0)
		{
			Array.Resize(ref m_estimationBuffer, 100);
		}
		context.LayoutStateCore = this;
	}

	internal void UninitializeForContext(VirtualizingLayoutContext context)
	{
		m_flowAlgorithm.UninitializeForContext(context);
	}

	internal void OnElementMeasured(int elementIndex, double majorSize, double minorSize)
	{
		int num = elementIndex % m_estimationBuffer.Length;
		if (m_estimationBuffer[num] == 0.0)
		{
			m_totalElementsMeasured++;
		}
		m_totalElementSize -= m_estimationBuffer[num];
		m_totalElementSize += majorSize;
		m_estimationBuffer[num] = majorSize;
		m_maxArrangeBounds = Math.Max(m_maxArrangeBounds, minorSize);
	}

	internal void OnMeasureStart()
	{
		m_maxArrangeBounds = 0.0;
	}
}
