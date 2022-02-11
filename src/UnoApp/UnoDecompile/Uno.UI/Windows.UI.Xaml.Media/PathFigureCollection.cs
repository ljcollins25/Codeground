using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public class PathFigureCollection : DependencyObjectCollection<PathFigure>, IList<PathFigure>, ICollection<PathFigure>, IEnumerable<PathFigure>, IEnumerable
{
	private protected override void OnCollectionChanged()
	{
		base.OnCollectionChanged();
		this.InvalidateMeasure();
	}
}
