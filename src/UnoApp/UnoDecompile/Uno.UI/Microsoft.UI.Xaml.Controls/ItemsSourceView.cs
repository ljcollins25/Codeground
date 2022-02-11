using System;
using System.Collections.Specialized;

namespace Microsoft.UI.Xaml.Controls;

public class ItemsSourceView : INotifyCollectionChanged
{
	private int m_cachedSize = -1;

	public int Count
	{
		get
		{
			if (m_cachedSize == -1)
			{
				m_cachedSize = GetSizeCore();
			}
			return m_cachedSize;
		}
	}

	public bool HasKeyIndexMapping => HasKeyIndexMappingCore();

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	public ItemsSourceView(object source)
	{
	}

	public object GetAt(int index)
	{
		return GetAtCore(index);
	}

	public int IndexFromKey(string id)
	{
		return IndexFromKeyCore(id);
	}

	public string KeyFromIndex(int index)
	{
		return KeyFromIndexCore(index);
	}

	internal int IndexOf(object value)
	{
		return IndexOfCore(value);
	}

	private protected void OnItemsSourceChanged(NotifyCollectionChangedEventArgs args)
	{
		m_cachedSize = GetSizeCore();
		this.CollectionChanged?.Invoke(this, args);
	}

	private protected virtual int GetSizeCore()
	{
		throw new NotImplementedException();
	}

	private protected virtual object GetAtCore(int index)
	{
		throw new NotImplementedException();
	}

	private protected virtual bool HasKeyIndexMappingCore()
	{
		throw new NotImplementedException();
	}

	private protected virtual string KeyFromIndexCore(int index)
	{
		throw new NotImplementedException();
	}

	private protected virtual int IndexFromKeyCore(string id)
	{
		throw new NotImplementedException();
	}

	private protected virtual int IndexOfCore(object value)
	{
		throw new NotImplementedException();
	}
}
