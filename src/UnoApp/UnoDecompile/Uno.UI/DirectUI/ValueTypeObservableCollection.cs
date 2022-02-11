using System.Collections;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace DirectUI;

internal class ValueTypeObservableCollection<T> : ValueTypeCollection<T>, IObservableVector<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private List<VectorChangedEventHandler<T>> m_handlers = new List<VectorChangedEventHandler<T>>();

	public event VectorChangedEventHandler<T> VectorChanged
	{
		add
		{
			m_handlers.Add(value);
		}
		remove
		{
			m_handlers.Remove(value);
		}
	}

	internal ValueTypeObservableCollection()
	{
	}

	~ValueTypeObservableCollection()
	{
		ClearHandlers();
	}

	private protected override void RaiseVectorChanged(CollectionChange action, uint index)
	{
		VectorChangedEventArgs vectorChangedEventArgs = null;
		vectorChangedEventArgs = new VectorChangedEventArgs(action, index);
		foreach (VectorChangedEventHandler<T> handler in m_handlers)
		{
			handler(this, vectorChangedEventArgs);
		}
	}

	private void ClearHandlers()
	{
		m_handlers.Clear();
	}
}
