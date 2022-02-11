using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.UI.Private.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

internal class BuildTreeScheduler
{
	private struct WorkInfo
	{
		private readonly Action _workFunc;

		public int Priority { get; }

		public WorkInfo(int priority, Action workFunc)
		{
			Priority = priority;
			_workFunc = workFunc;
		}

		public void InvokeWorkFunc()
		{
			_workFunc();
		}
	}

	private const double m_budgetInMs = 40.0;

	[ThreadStatic]
	private static Stopwatch m_timer;

	[ThreadStatic]
	private static List<WorkInfo> m_pendingWork;

	[ThreadStatic]
	private static bool m_renderingToken;

	public static void RegisterWork(int priority, Action workFunc)
	{
		QueueTick();
		if (m_pendingWork == null)
		{
			m_pendingWork = new List<WorkInfo>();
			m_timer = new Stopwatch();
			m_timer.Start();
		}
		m_pendingWork.Add(new WorkInfo(priority, workFunc));
	}

	public static bool ShouldYield()
	{
		return (double)m_timer.ElapsedMilliseconds > 40.0;
	}

	public static void OnRendering(object snd, object args)
	{
		if (!ShouldYield() && m_pendingWork.Count > 0)
		{
			m_pendingWork.Sort((WorkInfo lhs, WorkInfo rhs) => lhs.Priority - rhs.Priority);
			int num = m_pendingWork.Count - 1;
			do
			{
				m_pendingWork[num].InvokeWorkFunc();
				m_pendingWork.RemoveAt(num);
			}
			while (--num >= 0 && !ShouldYield());
		}
		if (m_pendingWork.Count == 0)
		{
			m_renderingToken = false;
			CompositionTarget.Rendering -= OnRendering;
			RepeaterTestHooks.NotifyBuildTreeCompleted();
		}
		m_timer.Reset();
	}

	private static void QueueTick()
	{
		if (!m_renderingToken)
		{
			CompositionTarget.Rendering += OnRendering;
			m_renderingToken = true;
		}
	}
}
