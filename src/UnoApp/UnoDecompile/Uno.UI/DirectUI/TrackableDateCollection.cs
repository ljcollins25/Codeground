using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Globalization;

namespace DirectUI;

internal class TrackableDateCollection : ValueTypeObservableCollection<DateTimeOffset>
{
	public enum CollectionChanging
	{
		Resetting,
		ItemInserting,
		ItemRemoving,
		ItemChanging
	}

	public class DateSetType : SortedSet<DateTimeOffset>
	{
		private class ComparerAdapter : IComparer<DateTimeOffset>
		{
			private readonly Func<DateTimeOffset, DateTimeOffset, bool> _compare;

			public ComparerAdapter(Func<DateTimeOffset, DateTimeOffset, bool> compare)
			{
				_compare = compare;
			}

			public int Compare(DateTimeOffset x, DateTimeOffset y)
			{
				if (!_compare(x, y))
				{
					return 1;
				}
				return -1;
			}
		}

		public DateSetType(Func<DateTimeOffset, DateTimeOffset, bool> comparer)
			: base((IComparer<DateTimeOffset>?)new ComparerAdapter(comparer))
		{
		}
	}

	public delegate void CollectionChangingCallback(CollectionChanging action, DateTimeOffset addingDate);

	private DateComparer m_dateComparer;

	private Func<DateTimeOffset, DateTimeOffset, bool> m_lessThanComparer;

	private Func<DateTimeOffset, DateTimeOffset, bool> m_areEquivalentComparer;

	private DateSetType m_addedDates;

	private DateSetType m_removedDates;

	private CollectionChangingCallback m_collectionChanging;

	public TrackableDateCollection()
	{
		m_dateComparer = new DateComparer();
		m_lessThanComparer = m_dateComparer.LessThanComparer;
		m_areEquivalentComparer = m_dateComparer.AreEquivalentComparer;
		m_addedDates = new DateSetType(m_lessThanComparer);
		m_removedDates = new DateSetType(m_lessThanComparer);
	}

	internal void SetCalendarForComparison(Calendar pCalendar)
	{
		m_dateComparer.SetCalendarForComparison(pCalendar);
	}

	public void FetchAndResetChange(DateSetType addedDates, DateSetType removedDates)
	{
		foreach (DateTimeOffset addedDate in m_addedDates)
		{
			addedDates.Add(addedDate);
		}
		m_addedDates.Clear();
		foreach (DateTimeOffset removedDate in m_removedDates)
		{
			removedDates.Add(removedDate);
		}
		m_removedDates.Clear();
	}

	public override void RemoveAt(uint index)
	{
		RaiseCollectionChanging(CollectionChanging.ItemRemoving, default(DateTimeOffset));
		DateTimeOffset at = GetAt(index);
		m_removedDates.Add(at);
		base.RemoveAt(index);
	}

	public override void Clear()
	{
		RaiseCollectionChanging(CollectionChanging.Resetting, default(DateTimeOffset));
		int count = base.Count;
		for (uint num = 0u; num < count; num++)
		{
			DateTimeOffset at = GetAt(num);
			m_removedDates.Add(at);
		}
		base.Clear();
	}

	public override void Append(DateTimeOffset item)
	{
		RaiseCollectionChanging(CollectionChanging.ItemInserting, item);
		m_addedDates.Add(item);
		base.Append(item);
	}

	public override void SetAt(uint index, DateTimeOffset item)
	{
		RaiseCollectionChanging(CollectionChanging.ItemChanging, item);
		DateTimeOffset at = GetAt(index);
		if (!m_areEquivalentComparer(at, item))
		{
			m_addedDates.Add(item);
			m_removedDates.Add(at);
		}
		base.SetAt(index, item);
	}

	public override void InsertAt(uint index, DateTimeOffset item)
	{
		RaiseCollectionChanging(CollectionChanging.ItemInserting, item);
		m_addedDates.Add(item);
		base.InsertAt(index, item);
	}

	internal void CountOf(DateTimeOffset value, out uint pCount)
	{
		uint num = 0u;
		pCount = 0u;
		for (uint num2 = 0u; num2 < m_vector.Count(); num2++)
		{
			if (m_areEquivalentComparer(m_vector[(int)num2], value))
			{
				num++;
			}
		}
		pCount = num;
	}

	internal void RemoveAll(DateTimeOffset value, uint? pFromHint = null)
	{
		int value2 = (int)(pFromHint ?? new uint?(0u)).Value;
		for (int num = m_vector.Count() - 1; num >= value2; num--)
		{
			if (m_areEquivalentComparer(m_vector[num], value))
			{
				RemoveAt(num);
			}
		}
	}

	private void RaiseCollectionChanging(CollectionChanging action, DateTimeOffset addingDate)
	{
		if (m_collectionChanging != null)
		{
			m_collectionChanging(action, addingDate);
		}
	}

	public void SetCollectionChangingCallback(CollectionChangingCallback callback)
	{
		m_collectionChanging = callback;
	}
}
