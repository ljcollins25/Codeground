using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class PathSegmentCollection : DependencyObjectCollection<PathSegment>, IList<PathSegment>, ICollection<PathSegment>, IEnumerable<PathSegment>, IEnumerable
{
	private protected override void OnCollectionChanged()
	{
		base.OnCollectionChanged();
		this.InvalidateMeasure();
	}
}
