using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno;
using Uno.Extensions;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media;

public class PointCollection : IList<Point>, ICollection<Point>, IEnumerable<Point>, IEnumerable
{
	private readonly List<Point> _points;

	private readonly List<Action> _changedCallbacks = new List<Action>(1);

	private static readonly char[] pointsParsingSeparators = new char[2] { ',', ' ' };

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public uint Size
	{
		get
		{
			throw new NotImplementedException("The member uint PointCollection.Size is not implemented in Uno.");
		}
	}

	public int Count => _points.Count;

	public bool IsReadOnly => false;

	public Point this[int i]
	{
		get
		{
			return _points[i];
		}
		set
		{
			_points[i] = value;
			NotifyChanged();
		}
	}

	public PointCollection()
	{
		_points = new List<Point>();
	}

	public PointCollection(IEnumerable<Point> coordinates)
	{
		_points = coordinates.ToList();
	}

	private PointCollection(List<Point> points)
	{
		_points = points;
	}

	public IEnumerator<Point> GetEnumerator()
	{
		return ((IEnumerable<Point>)_points).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<Point>)_points).GetEnumerator();
	}

	public int IndexOf(Point item)
	{
		return _points.IndexOf(item);
	}

	public bool Contains(Point item)
	{
		return _points.Contains(item);
	}

	public void CopyTo(Point[] array, int arrayIndex)
	{
		_points.CopyTo(array, arrayIndex);
	}

	public void Insert(int index, Point item)
	{
		_points.Insert(index, item);
		NotifyChanged();
	}

	public void RemoveAt(int index)
	{
		_points.RemoveAt(index);
		NotifyChanged();
	}

	public void Add(Point item)
	{
		_points.Add(item);
		NotifyChanged();
	}

	public void Clear()
	{
		if (_points.Count > 0)
		{
			_points.Clear();
			NotifyChanged();
		}
	}

	public bool Remove(Point item)
	{
		if (_points.Remove(item))
		{
			NotifyChanged();
			return true;
		}
		return false;
	}

	internal void RegisterChangedListener(Action listener)
	{
		_changedCallbacks.Add(listener);
	}

	internal void UnRegisterChangedListener(Action listener)
	{
		_changedCallbacks.Remove(listener);
	}

	private void NotifyChanged()
	{
		foreach (Action changedCallback in _changedCallbacks)
		{
			changedCallback();
		}
	}

	public static implicit operator PointCollection(string s)
	{
		string[] array = s.Split(pointsParsingSeparators, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length % 2 != 0)
		{
			return null;
		}
		bool successfulConversion = true;
		float[] array2 = array.SelectToArray(delegate(string strVal)
		{
			successfulConversion &= float.TryParse(strVal, out var result);
			return result;
		});
		if (!successfulConversion)
		{
			return null;
		}
		List<Point> list = new List<Point>(array2.Length);
		for (int i = 0; i < array2.Length; i += 2)
		{
			list.Add(new Point
			{
				X = array2[i],
				Y = array2[i + 1]
			});
		}
		return new PointCollection(list);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		foreach (Point point in _points)
		{
			stringBuilder.Append(point.X + "," + point.Y + " ");
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	internal string ToCssString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Point point in _points)
		{
			stringBuilder.Append(point.X.ToStringInvariant());
			stringBuilder.Append(',');
			stringBuilder.Append(point.Y.ToStringInvariant());
			stringBuilder.Append(' ');
		}
		return stringBuilder.ToString();
	}
}
