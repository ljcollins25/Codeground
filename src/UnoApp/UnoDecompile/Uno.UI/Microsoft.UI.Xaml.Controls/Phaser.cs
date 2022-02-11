using System;
using System.Collections.Generic;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls;

internal class Phaser
{
	private struct ElementInfo
	{
		public UIElement Element { get; }

		public VirtualizationInfo VirtInfo { get; }

		public ElementInfo(UIElement element, VirtualizationInfo virtInfo)
		{
			Element = element;
			VirtInfo = virtInfo;
		}
	}

	private readonly ItemsRepeater m_owner;

	private List<ElementInfo> m_pendingElements = new List<ElementInfo>();

	private bool m_registeredForCallback;

	public Phaser(ItemsRepeater owner)
	{
		m_owner = owner;
	}

	public void PhaseElement(UIElement element, VirtualizationInfo virtInfo)
	{
		IDataTemplateComponent dataTemplateComponent = virtInfo.DataTemplateComponent;
		int phase = virtInfo.Phase;
		bool flag = false;
		if (phase > 0)
		{
			if (dataTemplateComponent == null)
			{
				throw new InvalidOperationException("Phase was set on virtualization info, but dataTemplateComponent was not.");
			}
			flag = true;
		}
		else if (phase == int.MinValue)
		{
			dataTemplateComponent = XamlBindingHelper.GetDataTemplateComponent(element);
			if (dataTemplateComponent != null)
			{
				dataTemplateComponent.Recycle();
				phase = -1;
				int index = virtInfo.Index;
				object at = m_owner.ItemsSourceView.GetAt(index);
				dataTemplateComponent.ProcessBindings(at, index, 0, out phase);
				virtInfo.UpdatePhasingInfo(phase, (phase > 0) ? at : null, (phase > 0) ? dataTemplateComponent : null);
				flag = phase > 0;
			}
		}
		if (flag)
		{
			m_pendingElements.Insert(0, new ElementInfo(element, virtInfo));
			RegisterForCallback();
		}
	}

	public void StopPhasing(UIElement element, VirtualizationInfo virtInfo)
	{
		if (virtInfo.DataTemplateComponent != null)
		{
			int num = m_pendingElements.FindIndex((ElementInfo info) => info.Element == element);
			if (num != -1)
			{
				m_pendingElements.RemoveAt(num);
			}
		}
		virtInfo.UpdatePhasingInfo(int.MinValue, null, null);
	}

	private void DoPhasedWorkCallback()
	{
		MarkCallbackRecieved();
		if (m_pendingElements.Count > 0 && !BuildTreeScheduler.ShouldYield())
		{
			Rect visibleWindow = m_owner.VisibleWindow;
			SortElements(visibleWindow);
			int num = m_pendingElements.Count - 1;
			do
			{
				ElementInfo elementInfo = m_pendingElements[num];
				UIElement element = elementInfo.Element;
				VirtualizationInfo virtInfo = elementInfo.VirtInfo;
				int index = virtInfo.Index;
				int phase = virtInfo.Phase;
				if (phase > 0)
				{
					int nextPhase = -1;
					virtInfo.DataTemplateComponent.ProcessBindings(virtInfo.Data, -1, phase, out nextPhase);
					ValidatePhaseOrdering(phase, nextPhase);
					Size availableSize = LayoutInformation.GetAvailableSize(element);
					element.Measure(availableSize);
					if (nextPhase > 0)
					{
						virtInfo.Phase = nextPhase;
						if (num == 0 || virtInfo.Phase > m_pendingElements[num - 1].VirtInfo.Phase)
						{
							num--;
						}
					}
					else
					{
						m_pendingElements.RemoveAt(num);
						num--;
					}
					int count = m_pendingElements.Count;
					if (num == -1)
					{
						num = count - 1;
					}
					else if (num > -1 && num < count - 1 && !SharedHelpers.DoRectsIntersect(visibleWindow, m_pendingElements[num].VirtInfo.ArrangeBounds) && SharedHelpers.DoRectsIntersect(visibleWindow, m_pendingElements[count - 1].VirtInfo.ArrangeBounds))
					{
						num = count - 1;
					}
					continue;
				}
				throw new InvalidOperationException("Cleared element found in pending list which is not expected");
			}
			while (m_pendingElements.Count > 0 && !BuildTreeScheduler.ShouldYield());
		}
		if (m_pendingElements.Count > 0)
		{
			RegisterForCallback();
		}
	}

	private void RegisterForCallback()
	{
		if (!m_registeredForCallback)
		{
			m_registeredForCallback = true;
			BuildTreeScheduler.RegisterWork(m_pendingElements[m_pendingElements.Count - 1].VirtInfo.Phase, DoPhasedWorkCallback);
		}
	}

	private void MarkCallbackRecieved()
	{
		m_registeredForCallback = false;
	}

	private void ValidatePhaseOrdering(int currentPhase, int nextPhase)
	{
		if (nextPhase > 0 && nextPhase <= currentPhase)
		{
			throw new InvalidOperationException("Phases are required to be monotonically increasing.");
		}
	}

	private void SortElements(Rect visibleWindow)
	{
		m_pendingElements.Sort(delegate(ElementInfo lhs, ElementInfo rhs)
		{
			Rect arrangeBounds = lhs.VirtInfo.ArrangeBounds;
			bool flag = SharedHelpers.DoRectsIntersect(arrangeBounds, visibleWindow);
			Rect arrangeBounds2 = rhs.VirtInfo.ArrangeBounds;
			bool flag2 = SharedHelpers.DoRectsIntersect(arrangeBounds2, visibleWindow);
			if ((flag && flag2) || (!flag && !flag2))
			{
				return lhs.VirtInfo.Phase - rhs.VirtInfo.Phase;
			}
			return (!flag) ? 1 : (-1);
		});
	}
}
