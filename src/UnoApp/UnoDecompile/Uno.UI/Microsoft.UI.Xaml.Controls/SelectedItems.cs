using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls;

internal class SelectedItems<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
{
	private class SelectedItemsEnumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly IReadOnlyList<T> m_selectedItems;

		private int m_currentIndex;

		public T Current
		{
			get
			{
				IReadOnlyList<T> selectedItems = m_selectedItems;
				if (m_currentIndex < selectedItems.Count)
				{
					return selectedItems[m_currentIndex];
				}
				throw new IndexOutOfRangeException();
			}
		}

		object IEnumerator.Current => Current;

		public SelectedItemsEnumerator(IReadOnlyList<T> selectedItems)
		{
			m_selectedItems = selectedItems;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (m_currentIndex < m_selectedItems.Count)
			{
				m_currentIndex++;
				return m_currentIndex < m_selectedItems.Count;
			}
			throw new IndexOutOfRangeException();
		}

		public void Reset()
		{
			m_currentIndex = 0;
		}
	}

	private IList<SelectedItemInfo> m_infos;

	private Func<IList<SelectedItemInfo>, int, T> m_getAtImpl;

	private int m_totalCount;

	public int Count => m_totalCount;

	public T this[int index] => m_getAtImpl(m_infos, index);

	public SelectedItems(IList<SelectedItemInfo> infos, Func<IList<SelectedItemInfo>, int, T> getAtImpl)
	{
		m_infos = infos;
		m_getAtImpl = getAtImpl;
		foreach (SelectedItemInfo info in infos)
		{
			if (info.Node.TryGetTarget(out var target))
			{
				m_totalCount += target.SelectedCount;
				continue;
			}
			throw new InvalidOperationException("Selection changed after the SelectedIndices/Items property was read.");
		}
	}

	~SelectedItems()
	{
		m_infos.Clear();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new SelectedItemsEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
