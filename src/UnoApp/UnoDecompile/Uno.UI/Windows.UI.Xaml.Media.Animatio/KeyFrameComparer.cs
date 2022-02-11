using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Media.Animation;

internal class KeyFrameComparer : IComparer<IKeyFrame>
{
	public static KeyFrameComparer Instance { get; } = new KeyFrameComparer();


	private KeyFrameComparer()
	{
	}

	public int Compare(IKeyFrame? x, IKeyFrame? y)
	{
		return CompareCore(x, y);
	}

	public static int CompareCore(IKeyFrame? x, IKeyFrame? y)
	{
		if (x == null)
		{
			if (y != null)
			{
				return int.MinValue;
			}
			return 0;
		}
		if (y == null)
		{
			return int.MaxValue;
		}
		return ((IComparable<KeyTime>)x!.KeyTime).CompareTo(y!.KeyTime);
	}
}
internal class KeyFrameComparer<TValue> : IComparer<IKeyFrame<TValue>>
{
	public static KeyFrameComparer<TValue> Instance { get; } = new KeyFrameComparer<TValue>();


	private KeyFrameComparer()
	{
	}

	public int Compare(IKeyFrame<TValue>? x, IKeyFrame<TValue>? y)
	{
		return KeyFrameComparer.CompareCore(x, y);
	}
}
