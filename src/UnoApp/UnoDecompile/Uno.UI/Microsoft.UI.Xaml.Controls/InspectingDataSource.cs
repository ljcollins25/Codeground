using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Uno.Disposables;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Interop;

namespace Microsoft.UI.Xaml.Controls;

internal class InspectingDataSource : ItemsSourceView
{
	private readonly IList<object> m_vector;

	private readonly IKeyIndexMapping m_uniqueIdMaping;

	private IDisposable _collectionChangedListener;

	public InspectingDataSource(object source)
		: base(source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("Argument 'source' is null.");
		}
		if (source is IList<object> vector)
		{
			m_vector = vector;
			ListenToCollectionChanges(vector);
		}
		else if (source is IList list)
		{
			m_vector = ListAdapter.ToGeneric(list);
			ListenToCollectionChanges(list);
		}
		else if (source is IEnumerable<object> iterable)
		{
			m_vector = WrapIterable(iterable);
		}
		else
		{
			if (!(source is IEnumerable iterable2))
			{
				throw new ArgumentException("Argument 'source' is not a supported vector.");
			}
			m_vector = WrapIterable(iterable2);
		}
		m_uniqueIdMaping = source as IKeyIndexMapping;
	}

	~InspectingDataSource()
	{
		UnListenToCollectionChanges();
	}

	private protected override int GetSizeCore()
	{
		return m_vector.Count;
	}

	private protected override object GetAtCore(int index)
	{
		return m_vector[index];
	}

	private protected override bool HasKeyIndexMappingCore()
	{
		return m_uniqueIdMaping != null;
	}

	private protected override string KeyFromIndexCore(int index)
	{
		if (m_uniqueIdMaping != null)
		{
			return m_uniqueIdMaping.KeyFromIndex(index);
		}
		throw new NotImplementedException();
	}

	private protected override int IndexFromKeyCore(string id)
	{
		if (m_uniqueIdMaping != null)
		{
			return m_uniqueIdMaping.IndexFromKey(id);
		}
		throw new NotImplementedException();
	}

	private protected override int IndexOfCore(object value)
	{
		return m_vector?.IndexOf(value) ?? (-1);
	}

	private IList<object> WrapIterable(IEnumerable iterable)
	{
		return iterable.Cast<object>().ToList();
	}

	private IList<object> WrapIterable(IEnumerable<object> iterable)
	{
		return new List<object>(iterable);
	}

	private void UnListenToCollectionChanges()
	{
		_collectionChangedListener?.Dispose();
	}

	private void ListenToCollectionChanges(object vector)
	{
		INotifyCollectionChanged notifyCollectionChanged = vector as INotifyCollectionChanged;
		if (notifyCollectionChanged == null)
		{
			IBindableObservableVector bindableObservableVector = vector as IBindableObservableVector;
			if (bindableObservableVector == null)
			{
				IObservableVector<object> observableVector = vector as IObservableVector<object>;
				if (observableVector != null)
				{
					_collectionChangedListener = Disposable.Create(delegate
					{
						observableVector.VectorChanged -= OnVectorChanged;
					});
					observableVector.VectorChanged += OnVectorChanged;
				}
			}
			else
			{
				_collectionChangedListener = Disposable.Create(delegate
				{
					bindableObservableVector.VectorChanged -= OnBindableVectorChanged;
				});
				bindableObservableVector.VectorChanged += OnBindableVectorChanged;
			}
		}
		else
		{
			_collectionChangedListener = Disposable.Create(delegate
			{
				notifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnCollectionChanged);
			});
			notifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
		}
	}

	private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		OnItemsSourceChanged(e);
	}

	private void OnBindableVectorChanged(IBindableObservableVector sender, object e)
	{
		OnVectorChanged(null, (IVectorChangedEventArgs)e);
	}

	private void OnVectorChanged(IObservableVector<object> _, IVectorChangedEventArgs e)
	{
		switch (e.CollectionChange)
		{
		case CollectionChange.ItemInserted:
			OnItemsSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new object[1], (int)e.Index));
			break;
		case CollectionChange.ItemRemoved:
			OnItemsSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new object[1], (int)e.Index));
			break;
		case CollectionChange.ItemChanged:
			OnItemsSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new object[1], new object[1], (int)e.Index));
			break;
		case CollectionChange.Reset:
			OnItemsSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			break;
		default:
			OnItemsSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			break;
		}
	}
}
