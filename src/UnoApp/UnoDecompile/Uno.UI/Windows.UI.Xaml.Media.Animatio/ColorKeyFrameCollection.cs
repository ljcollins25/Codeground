using System;
using System.Collections;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media.Animation;

public class ColorKeyFrameCollection : DependencyObjectCollection<ColorKeyFrame>, IList<ColorKeyFrame>, ICollection<ColorKeyFrame>, IEnumerable<ColorKeyFrame>, IEnumerable
{
	public new uint Size => base.Size;

	public new int Count
	{
		get
		{
			return base.Count;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public new bool IsReadOnly
	{
		get
		{
			return base.IsReadOnly;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public new ColorKeyFrame this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			base[index] = value;
		}
	}

	public ColorKeyFrameCollection()
		: base((DependencyObject)null, isAutoPropertyInheritanceEnabled: false)
	{
	}

	internal ColorKeyFrameCollection(DependencyObject owner, bool isAutoPropertyInheritanceEnabled)
		: base(owner, isAutoPropertyInheritanceEnabled)
	{
	}

	public new IEnumerator<ColorKeyFrame> GetEnumerator()
	{
		return base.GetEnumerator();
	}

	public new void Add(ColorKeyFrame item)
	{
		base.Add(item);
	}

	public new void Clear()
	{
		base.Clear();
	}

	public new bool Contains(ColorKeyFrame item)
	{
		return base.Contains(item);
	}

	public new void CopyTo(ColorKeyFrame[] array, int arrayIndex)
	{
		base.CopyTo(array, arrayIndex);
	}

	public new bool Remove(ColorKeyFrame item)
	{
		return base.Remove(item);
	}

	public new int IndexOf(ColorKeyFrame item)
	{
		return base.IndexOf(item);
	}

	public new void Insert(int index, ColorKeyFrame item)
	{
		base.Insert(index, item);
	}

	public new void RemoveAt(int index)
	{
		base.RemoveAt(index);
	}
}
