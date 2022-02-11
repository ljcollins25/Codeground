using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media.Animation;

public class DoubleKeyFrameCollection : DependencyObjectCollection<DoubleKeyFrame>, IList<DoubleKeyFrame>, ICollection<DoubleKeyFrame>, IEnumerable<DoubleKeyFrame>, IEnumerable
{
	public DoubleKeyFrameCollection()
		: base((DependencyObject)null, isAutoPropertyInheritanceEnabled: false)
	{
	}

	internal DoubleKeyFrameCollection(DependencyObject owner, bool isAutoPropertyInheritanceEnabled)
		: base(owner, isAutoPropertyInheritanceEnabled)
	{
	}
}
