using System.Collections;
using System.Collections.Generic;
using DirectUI;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Controls;

internal class CommandBarElementCollection : IObservableVector<ICommandBarElement>, IList<ICommandBarElement>, ICollection<ICommandBarElement>, IEnumerable<ICommandBarElement>, IEnumerable, IVector<ICommandBarElement>
{
	private readonly List<ICommandBarElement> _list = new List<ICommandBarElement>();

	private bool m_notifyCollectionChanging;

	private CommandBar? m_parent;

	public ICommandBarElement this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			SetAt(index, value);
		}
	}

	public int Count => _list.Count;

	public bool IsReadOnly => ((ICollection<ICommandBarElement>)_list).IsReadOnly;

	public event VectorChangedEventHandler<ICommandBarElement>? VectorChanged;

	public void Init(CommandBar parent, bool notifyCollectionChanging)
	{
		m_parent = parent;
		m_notifyCollectionChanging = notifyCollectionChanging;
	}

	public void SetAt(int index, ICommandBarElement item)
	{
		RaiseVectorChanging(CollectionChange.ItemChanged, index);
		_list[index] = item;
		RaiseVectorChanged(CollectionChange.ItemChanged, index);
	}

	public void Add(ICommandBarElement item)
	{
		Append(item);
	}

	public void Append(ICommandBarElement item)
	{
		Insert(Count, item);
	}

	public void Clear()
	{
		RaiseVectorChanging(CollectionChange.Reset, 0);
		_list.Clear();
		RaiseVectorChanged(CollectionChange.Reset, 0);
	}

	public bool Contains(ICommandBarElement item)
	{
		return _list.Contains(item);
	}

	public void CopyTo(ICommandBarElement[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	public IEnumerator<ICommandBarElement> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	public int IndexOf(ICommandBarElement item)
	{
		return _list.IndexOf(item);
	}

	public void Insert(int index, ICommandBarElement item)
	{
		RaiseVectorChanging(CollectionChange.ItemInserted, index);
		_list.Insert(index, item);
		RaiseVectorChanged(CollectionChange.ItemInserted, index);
	}

	public bool Remove(ICommandBarElement item)
	{
		int num = _list.IndexOf(item);
		if (num != -1)
		{
			RemoveAt(num);
			return true;
		}
		return false;
	}

	public void RemoveAt(int index)
	{
		RaiseVectorChanging(CollectionChange.ItemRemoved, index);
		_list.RemoveAt(index);
		RaiseVectorChanged(CollectionChange.ItemRemoved, index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private void RaiseVectorChanged(CollectionChange change, int changeIndex)
	{
		VectorChangedEventArgs @event = new VectorChangedEventArgs(change, (uint)changeIndex);
		this.VectorChanged?.Invoke(this, @event);
	}

	private void RaiseVectorChanging(CollectionChange change, int changeIndex)
	{
		if (m_notifyCollectionChanging && m_parent != null)
		{
			m_parent!.NotifyElementVectorChanging(this, change, changeIndex);
		}
	}
}
