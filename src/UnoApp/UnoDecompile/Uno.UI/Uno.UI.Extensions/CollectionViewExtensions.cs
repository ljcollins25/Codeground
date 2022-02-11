using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace Uno.UI.Extensions;

public static class CollectionViewExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IEnumerable<IEnumerable> GetCollectionGroups(this ICollectionView collectionView)
	{
		return (from ICollectionViewGroup g in collectionView.CollectionGroups
			select g.Group as IEnumerable);
	}

	public static IndexPath GetIndexPathForItem(this ICollectionView collectionView, object item)
	{
		if (collectionView.CollectionGroups == null)
		{
			return IndexPath.FromRowSection(collectionView.IndexOf(item), 0);
		}
		for (int i = 0; i < collectionView.CollectionGroups.Count; i++)
		{
			int num = (collectionView.CollectionGroups[i] as ICollectionViewGroup).GroupItems.IndexOf(item);
			if (num > -1)
			{
				return IndexPath.FromRowSection(num, i);
			}
		}
		return IndexPath.FromRowSection(-1, 0);
	}

	public static object GetItemForIndexPath(this ICollectionView collectionView, IndexPath indexPath)
	{
		if (collectionView.CollectionGroups == null)
		{
			if (indexPath.Section > 0)
			{
				return null;
			}
			return collectionView[indexPath.Row];
		}
		return (collectionView.CollectionGroups[indexPath.Section] as ICollectionViewGroup).GroupItems[indexPath.Row];
	}
}
