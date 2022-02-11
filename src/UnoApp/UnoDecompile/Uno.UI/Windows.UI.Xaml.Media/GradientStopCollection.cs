using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media;

public sealed class GradientStopCollection : DependencyObjectCollection<GradientStop>, IList<GradientStop>, ICollection<GradientStop>, IEnumerable<GradientStop>, IEnumerable
{
	private protected override void OnCollectionChanged()
	{
		base.OnCollectionChanged();
		this.InvalidateArrange();
	}
}
