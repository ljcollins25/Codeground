using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Windows.UI.Xaml.Media.Animation;

public sealed class TimelineCollection : DependencyObjectCollection<Timeline>, IList<Timeline>, ICollection<Timeline>, IEnumerable<Timeline>, IEnumerable
{
	private string[] _targetedProperties;

	internal string[] TargetedProperties
	{
		get
		{
			if (_targetedProperties == null)
			{
				_targetedProperties = base.Items.Select((Timeline i) => i.GetTimelineTargetFullName()).Distinct().ToArray();
			}
			return _targetedProperties;
		}
	}

	public TimelineCollection()
	{
	}

	internal TimelineCollection(DependencyObject owner, bool isAutoPropertyInheritanceEnabled)
	{
		base.IsAutoPropertyInheritanceEnabled = isAutoPropertyInheritanceEnabled;
		this.SetParent(owner);
	}

	private protected override void OnCollectionChanged()
	{
		base.OnCollectionChanged();
		_targetedProperties = null;
	}

	public new void Add(Timeline element)
	{
		base.Add(element);
	}
}
