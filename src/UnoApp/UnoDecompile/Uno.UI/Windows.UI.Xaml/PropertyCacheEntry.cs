using System;
using System.Collections;

namespace Windows.UI.Xaml;

internal class PropertyCacheEntry
{
	internal class Comparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object? x, object? y)
		{
			if (x is PropertyCacheEntry propertyCacheEntry && y is PropertyCacheEntry propertyCacheEntry2)
			{
				if (propertyCacheEntry.Type == propertyCacheEntry2.Type)
				{
					if ((object)propertyCacheEntry.Name != propertyCacheEntry2.Name)
					{
						return string.CompareOrdinal(propertyCacheEntry.Name, propertyCacheEntry2.Name) == 0;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		int IEqualityComparer.GetHashCode(object? obj)
		{
			if (!(obj is PropertyCacheEntry propertyCacheEntry))
			{
				return 0;
			}
			return propertyCacheEntry.CachedHashCode;
		}
	}

	private readonly Type Type;

	private readonly string Name;

	private readonly int CachedHashCode;

	public static readonly Comparer DefaultComparer = new Comparer();

	public PropertyCacheEntry(Type type, string name)
	{
		Type = type;
		Name = name;
		CachedHashCode = type.GetHashCode() ^ name.GetHashCode();
	}
}
