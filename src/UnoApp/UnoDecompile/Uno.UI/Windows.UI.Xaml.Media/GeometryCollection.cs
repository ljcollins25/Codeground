using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class GeometryCollection : DependencyObjectCollection<Geometry>, IList<Geometry>, ICollection<Geometry>, IEnumerable<Geometry>, IEnumerable
{
	private protected override void OnCollectionChanged()
	{
		base.OnCollectionChanged();
		this.InvalidateMeasure();
	}
}
