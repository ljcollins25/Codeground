using System.Linq;

namespace Uno.Extensions;

internal static class ObservableCollectionUpdateResultsExtensions
{
	internal static bool HasChanged<T>(this ObservableCollectionUpdateResults<T> observableCollection)
	{
		if (!observableCollection.Moved.Any() && !observableCollection.Added.Any())
		{
			return observableCollection.Removed.Any();
		}
		return true;
	}
}
