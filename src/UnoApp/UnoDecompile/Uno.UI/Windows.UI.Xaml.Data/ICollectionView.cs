using System;
using System.Collections;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml.Data;

public interface ICollectionView : IEnumerable<object>, IEnumerable, IObservableVector<object>, IList<object>, ICollection<object>
{
	IObservableVector<object> CollectionGroups { get; }

	object CurrentItem { get; }

	int CurrentPosition { get; }

	bool HasMoreItems { get; }

	bool IsCurrentAfterLast { get; }

	bool IsCurrentBeforeFirst { get; }

	event EventHandler<object> CurrentChanged;

	event CurrentChangingEventHandler CurrentChanging;

	bool MoveCurrentTo(object item);

	bool MoveCurrentToPosition(int index);

	bool MoveCurrentToFirst();

	bool MoveCurrentToLast();

	bool MoveCurrentToNext();

	bool MoveCurrentToPrevious();

	IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count);
}
