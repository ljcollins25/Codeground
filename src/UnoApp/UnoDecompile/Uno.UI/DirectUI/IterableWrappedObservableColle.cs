using System.Collections;
using System.Collections.Generic;
using Uno.Disposables;
using Windows.Foundation.Collections;

namespace DirectUI;

internal class IterableWrappedObservableCollection<T> : IterableWrappedCollection<T>, IObservableVector<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private SerialDisposable m_VectorChangedToken = new SerialDisposable();

	public event VectorChangedEventHandler<T> VectorChanged;

	public override void SetWrappedCollection(IVector<T> collection)
	{
		UnsubscribeFromCurrentCollection();
		base.SetWrappedCollection(collection);
		IObservableVector<T> spAsObservable = collection as IObservableVector<T>;
		if (spAsObservable != null)
		{
			spAsObservable.VectorChanged += OnVectorChanged;
			m_VectorChangedToken.Disposable = Disposable.Create(delegate
			{
				spAsObservable.VectorChanged -= OnVectorChanged;
			});
		}
	}

	private void OnVectorChanged(IObservableVector<T> sender, IVectorChangedEventArgs @event)
	{
		this.VectorChanged?.Invoke(this, @event);
	}

	private void UnsubscribeFromCurrentCollection()
	{
		m_VectorChangedToken.Disposable = null;
	}
}
