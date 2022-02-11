using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class ChildrenInTabFocusOrderIterable : IEnumerable<DependencyObject>, IEnumerable
{
	private class ChildrenInTabFocusOrderIterator : IEnumerator<DependencyObject>, IEnumerator, IDisposable
	{
		private readonly List<KeyValuePair<int, UIElement>> m_realizedChildren;

		private int m_index;

		object IEnumerator.Current => Current;

		public DependencyObject Current
		{
			get
			{
				if (m_index < m_realizedChildren.Count)
				{
					return m_realizedChildren[m_index].Value;
				}
				throw new IndexOutOfRangeException();
			}
		}

		public ChildrenInTabFocusOrderIterator(ItemsRepeater repeater)
		{
			IList<UIElement> children = repeater.Children;
			m_realizedChildren = new List<KeyValuePair<int, UIElement>>(children.Count);
			for (int i = 0; i < children.Count; i++)
			{
				UIElement uIElement = children[i];
				VirtualizationInfo virtualizationInfo = ItemsRepeater.GetVirtualizationInfo(uIElement);
				if (virtualizationInfo.IsRealized)
				{
					m_realizedChildren.Add(new KeyValuePair<int, UIElement>(virtualizationInfo.Index, uIElement));
				}
			}
			m_realizedChildren.Sort((KeyValuePair<int, UIElement> lhs, KeyValuePair<int, UIElement> rhs) => lhs.Key - rhs.Key);
		}

		public bool MoveNext()
		{
			if (m_index < m_realizedChildren.Count)
			{
				m_index++;
				return m_index < m_realizedChildren.Count;
			}
			throw new IndexOutOfRangeException();
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}

	private readonly ItemsRepeater m_repeater;

	public ChildrenInTabFocusOrderIterable(ItemsRepeater repeater)
	{
		m_repeater = repeater;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<DependencyObject> GetEnumerator()
	{
		return new ChildrenInTabFocusOrderIterator(m_repeater);
	}
}
