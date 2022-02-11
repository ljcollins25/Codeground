using System;
using System.Collections;
using System.Collections.Generic;
using Uno.Extensions;
using Windows.UI.Xaml;

namespace Microsoft.UI.Xaml.Controls;

internal class VirtualLayoutContextAdapter : NonVirtualizingLayoutContext
{
	private class ChildrenCollection : IReadOnlyList<UIElement>, IEnumerable<UIElement>, IEnumerable, IReadOnlyCollection<UIElement>
	{
		private VirtualizingLayoutContext m_context;

		public int Count => m_context.ItemCount;

		public UIElement this[int index] => m_context.GetOrCreateElementAt(index, ElementRealizationOptions.None);

		public ChildrenCollection(VirtualizingLayoutContext context)
		{
			m_context = context;
		}

		public IEnumerator<UIElement> GetEnumerator()
		{
			return new Iterator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private class Iterator : IEnumerator<UIElement>, IEnumerator, IDisposable
	{
		private readonly IReadOnlyList<UIElement> m_childCollection;

		private int m_currentIndex = -1;

		object IEnumerator.Current => Current;

		public UIElement Current
		{
			get
			{
				if (m_currentIndex < m_childCollection.Count)
				{
					return m_childCollection[m_currentIndex];
				}
				throw new IndexOutOfRangeException();
			}
		}

		public Iterator(IReadOnlyList<UIElement> childCollection)
		{
			m_childCollection = childCollection;
		}

		public bool MoveNext()
		{
			if (m_currentIndex < m_childCollection.Count)
			{
				m_currentIndex++;
				return m_currentIndex < m_childCollection.Count;
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

	private readonly WeakReference<VirtualizingLayoutContext> m_virtualizingContext;

	private IReadOnlyList<UIElement> m_children;

	protected internal override object LayoutStateCore
	{
		get
		{
			if (!m_virtualizingContext.TryGetTarget(out var target))
			{
				return null;
			}
			return target.LayoutState;
		}
		set
		{
			if (m_virtualizingContext.TryGetTarget(out var target))
			{
				target.LayoutState = value;
			}
		}
	}

	public override IReadOnlyList<UIElement> ChildrenCore
	{
		get
		{
			if (m_children == null)
			{
				m_children = new ChildrenCollection(m_virtualizingContext.GetTarget());
			}
			return m_children;
		}
	}

	public VirtualLayoutContextAdapter(VirtualizingLayoutContext virtualizingContext)
	{
		m_virtualizingContext = new WeakReference<VirtualizingLayoutContext>(virtualizingContext);
	}
}
