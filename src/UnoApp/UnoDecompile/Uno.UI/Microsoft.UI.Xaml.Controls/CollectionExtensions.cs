using System.Collections.Generic;

namespace Microsoft.UI.Xaml.Controls;

internal static class CollectionExtensions
{
	public static bool TryGetElementAt<T>(this IList<T> collection, int index, out T element) where T : class
	{
		if (index < collection.Count)
		{
			element = collection[index];
			return element != null;
		}
		element = null;
		return false;
	}

	public static void AddOrInsert<T>(this IList<T> collection, int index, T element)
	{
		if (index >= collection.Count)
		{
			collection.Add(element);
		}
		else
		{
			collection.Insert(index, element);
		}
	}
}
