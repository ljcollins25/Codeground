namespace Microsoft.UI.Xaml.Controls;

internal class IndexRange
{
	private int m_begin = -1;

	private int m_end = -1;

	internal int Begin => m_begin;

	internal int End => m_end;

	internal IndexRange()
	{
	}

	internal IndexRange(int begin, int end)
	{
		if (begin > end)
		{
			int num = begin;
			begin = end;
			end = num;
		}
		m_begin = begin;
		m_end = end;
	}

	internal bool Contains(int index)
	{
		if (index >= m_begin)
		{
			return index <= m_end;
		}
		return false;
	}

	internal bool Split(int splitIndex, ref IndexRange before, ref IndexRange after)
	{
		before = new IndexRange(m_begin, splitIndex);
		if (splitIndex < m_end)
		{
			after = new IndexRange(splitIndex + 1, m_end);
			return true;
		}
		after = new IndexRange();
		return false;
	}

	internal bool Intersects(IndexRange other)
	{
		if (m_begin <= other.End)
		{
			return m_end >= other.Begin;
		}
		return false;
	}

	public static bool operator ==(IndexRange lhs, IndexRange rhs)
	{
		if (lhs.m_begin == rhs.m_begin)
		{
			return lhs.m_end == rhs.m_end;
		}
		return false;
	}

	public static bool operator !=(IndexRange lhs, IndexRange rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		if (obj is IndexRange indexRange)
		{
			return this == indexRange;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return m_begin.GetHashCode() + 13 * m_end.GetHashCode();
	}
}
