using System;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls;

public class FlowLayoutState
{
	private const int BufferSize = 100;

	private readonly FlowLayoutAlgorithm m_flowAlgorithm = new FlowLayoutAlgorithm();

	private double[] m_lineSizeEstimationBuffer = new double[100];

	private double[] m_itemsPerLineEstimationBuffer = new double[100];

	private double m_totalLineSize;

	private int m_totalLinesMeasured;

	private double m_totalItemsPerLine;

	private Size m_specialElementDesiredSize;

	internal FlowLayoutAlgorithm FlowAlgorithm => m_flowAlgorithm;

	internal double TotalLineSize => m_totalLineSize;

	internal int TotalLinesMeasured => m_totalLinesMeasured;

	internal double TotalItemsPerLine => m_totalItemsPerLine;

	internal Size SpecialElementDesiredSize
	{
		get
		{
			return m_specialElementDesiredSize;
		}
		set
		{
			m_specialElementDesiredSize = value;
		}
	}

	internal void InitializeForContext(VirtualizingLayoutContext context, IFlowLayoutAlgorithmDelegates callbacks)
	{
		m_flowAlgorithm.InitializeForContext(context, callbacks);
		if (m_lineSizeEstimationBuffer.Length == 0)
		{
			Array.Resize(ref m_lineSizeEstimationBuffer, 100);
			Array.Resize(ref m_itemsPerLineEstimationBuffer, 100);
		}
		context.LayoutStateCore = this;
	}

	internal void UninitializeForContext(VirtualizingLayoutContext context)
	{
		m_flowAlgorithm.UninitializeForContext(context);
	}

	internal void OnLineArranged(int startIndex, int countInLine, double lineSize, VirtualizingLayoutContext context)
	{
		if (m_totalLinesMeasured == 0 || startIndex + countInLine != context.ItemCount)
		{
			int num = startIndex % m_lineSizeEstimationBuffer.Length;
			if (m_lineSizeEstimationBuffer[num] == 0.0)
			{
				m_totalLinesMeasured++;
			}
			m_totalLineSize -= m_lineSizeEstimationBuffer[num];
			m_totalLineSize += lineSize;
			m_lineSizeEstimationBuffer[num] = lineSize;
			m_totalItemsPerLine -= m_itemsPerLineEstimationBuffer[num];
			m_totalItemsPerLine += countInLine;
			m_itemsPerLineEstimationBuffer[num] = countInLine;
		}
	}
}
