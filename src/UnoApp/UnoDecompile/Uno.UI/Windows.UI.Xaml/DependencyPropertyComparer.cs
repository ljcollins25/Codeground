using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml;

internal class DependencyPropertyComparer : IEqualityComparer<DependencyProperty>, IEqualityComparer
{
	public static readonly DependencyPropertyComparer Default = new DependencyPropertyComparer();

	private DependencyPropertyComparer()
	{
	}

	public bool Equals(DependencyProperty x, DependencyProperty y)
	{
		return x == y;
	}

	public int GetHashCode(DependencyProperty obj)
	{
		return obj.CachedHashCode;
	}

	bool IEqualityComparer.Equals(object x, object y)
	{
		return x == y;
	}

	int IEqualityComparer.GetHashCode(object obj)
	{
		if (!(obj is DependencyProperty dependencyProperty))
		{
			return 0;
		}
		return dependencyProperty.CachedHashCode;
	}
}
