using System.Collections.Generic;
using System.Collections.Specialized;
using Uno.Foundation.Logging;
using Uno.UI;

namespace Windows.UI.Xaml.Controls;

internal class CollectionChangedOperation
{
	public enum Element
	{
		Item,
		Group
	}

	public IndexPath StartingIndex { get; }

	public int Range { get; }

	public NotifyCollectionChangedAction Action { get; }

	public Element ElementType { get; }

	public IndexPath EndIndex
	{
		get
		{
			if (ElementType != 0)
			{
				return IndexPath.FromRowSection(StartingIndex.Row, StartingIndex.Section + Range - 1);
			}
			return IndexPath.FromRowSection(StartingIndex.Row + Range - 1, StartingIndex.Section);
		}
	}

	public CollectionChangedOperation(IndexPath startingIndex, int range, NotifyCollectionChangedAction action, Element elementType)
	{
		StartingIndex = startingIndex;
		Range = range;
		Action = action;
		ElementType = elementType;
	}

	public IndexPath? Offset(IndexPath indexPath)
	{
		int section = indexPath.Section;
		int num = indexPath.Row;
		if (ElementType == Element.Item && Action == NotifyCollectionChangedAction.Add && StartingIndex.Section == section && EndIndex.Row <= num)
		{
			num += Range;
		}
		else
		{
			CollectionChangedOperation collectionChangedOperation = this;
			if (collectionChangedOperation.ElementType == Element.Item && collectionChangedOperation.Action == NotifyCollectionChangedAction.Remove && collectionChangedOperation.StartingIndex.Section == section && collectionChangedOperation.EndIndex.Row < num)
			{
				num -= collectionChangedOperation.Range;
			}
			else
			{
				CollectionChangedOperation collectionChangedOperation2 = this;
				if (collectionChangedOperation2.ElementType == Element.Item && (collectionChangedOperation2.Action == NotifyCollectionChangedAction.Remove || collectionChangedOperation2.Action == NotifyCollectionChangedAction.Replace) && collectionChangedOperation2.StartingIndex.Section == section && collectionChangedOperation2.StartingIndex.Row <= num && collectionChangedOperation2.EndIndex.Row >= num)
				{
					return null;
				}
				CollectionChangedOperation collectionChangedOperation3 = this;
				if (collectionChangedOperation3.ElementType != Element.Group || collectionChangedOperation3.Action != 0 || collectionChangedOperation3.EndIndex.Section > section)
				{
					CollectionChangedOperation collectionChangedOperation4 = this;
					if (collectionChangedOperation4.ElementType != Element.Group || collectionChangedOperation4.Action != NotifyCollectionChangedAction.Remove || collectionChangedOperation4.EndIndex.Section >= section)
					{
						CollectionChangedOperation collectionChangedOperation5 = this;
						if (collectionChangedOperation5.ElementType != Element.Group || (collectionChangedOperation5.Action != NotifyCollectionChangedAction.Remove && collectionChangedOperation5.Action != NotifyCollectionChangedAction.Replace) || collectionChangedOperation5.StartingIndex.Section > section || collectionChangedOperation5.EndIndex.Section < section)
						{
							goto IL_01b5;
						}
					}
				}
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().LogWarning("Collection change not supported");
				}
			}
		}
		goto IL_01b5;
		IL_01b5:
		return IndexPath.FromRowSection(num, section);
	}

	public static IndexPath? Offset(IndexPath index, IEnumerable<CollectionChangedOperation> collectionChanges)
	{
		IndexPath? result = index;
		foreach (CollectionChangedOperation collectionChange in collectionChanges)
		{
			if (result.HasValue)
			{
				IndexPath valueOrDefault = result.GetValueOrDefault();
				result = collectionChange.Offset(valueOrDefault);
				continue;
			}
			return result;
		}
		return result;
	}

	public static int? Offset(int index, IEnumerable<CollectionChangedOperation> collectionChanges)
	{
		return Offset(IndexPath.FromRowSection(index, 0), collectionChanges)?.Row;
	}
}
