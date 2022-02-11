using System.Collections;
using System.Collections.Generic;

namespace DirectUI;

internal class TrackerCollection<T> : List<T>, IVector<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public void RemoveAtEnd()
	{
		if (base.Count > 0)
		{
			RemoveAt(base.Count - 1);
		}
	}
}
