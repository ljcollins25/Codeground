using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media.Animation;

public sealed class ObjectKeyFrameCollection : DependencyObjectCollection<ObjectKeyFrame>, IList<ObjectKeyFrame>, ICollection<ObjectKeyFrame>, IEnumerable<ObjectKeyFrame>, IEnumerable
{
	internal ObjectKeyFrameCollection(DependencyObject owner, bool isAutoPropertyInheritanceEnabled)
		: base(owner, isAutoPropertyInheritanceEnabled)
	{
	}
}
