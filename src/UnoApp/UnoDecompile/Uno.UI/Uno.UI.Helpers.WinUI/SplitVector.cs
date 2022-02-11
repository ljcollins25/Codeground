using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Uno.UI.Helpers.WinUI;

internal class SplitVector<T, TVectorId>
{
	private TVectorId m_vectorID;

	private IList<T> m_vector = new ObservableCollection<T>();

	private List<int> m_indexesInOriginalVector = new List<int>();

	private Func<T, int> m_indexFunctionFromDataSource;

	public SplitVector(TVectorId id, Func<T, int> indexOfFunction)
	{
		m_vectorID = id;
		m_indexFunctionFromDataSource = indexOfFunction;
	}

	public TVectorId GetVectorIDForItem()
	{
		return m_vectorID;
	}

	public IList<T> GetVector()
	{
		return m_vector;
	}

	public void OnRawDataRemove(int indexInOriginalVector, TVectorId vectorID)
	{
		if (m_vectorID.Equals(vectorID))
		{
			RemoveAt(indexInOriginalVector);
		}
		for (int i = 0; i < m_indexesInOriginalVector.Count; i++)
		{
			if (m_indexesInOriginalVector[i] > indexInOriginalVector)
			{
				m_indexesInOriginalVector[i]--;
			}
		}
	}

	public void OnRawDataInsert(int preferIndex, int indexInOriginalVector, T value, TVectorId vectorID)
	{
		for (int i = 0; i < m_indexesInOriginalVector.Count; i++)
		{
			if (m_indexesInOriginalVector[i] > indexInOriginalVector)
			{
				m_indexesInOriginalVector[i]++;
			}
		}
		if (m_vectorID.Equals(vectorID))
		{
			InsertAt(preferIndex, indexInOriginalVector, value);
		}
	}

	public void InsertAt(int preferIndex, int indexInOriginalVector, T value)
	{
		m_vector.Insert(preferIndex, value);
		m_indexesInOriginalVector.Insert(preferIndex, indexInOriginalVector);
	}

	public void Replace(int indexInOriginalVector, T value)
	{
		int index = IndexFromIndexInOriginalVector(indexInOriginalVector);
		IList<T> vector = m_vector;
		vector.RemoveAt(index);
		vector.Insert(index, value);
	}

	public void Clear()
	{
		m_vector.Clear();
		m_indexesInOriginalVector.Clear();
	}

	public void RemoveAt(int indexInOriginalVector)
	{
		int index = IndexFromIndexInOriginalVector(indexInOriginalVector);
		m_vector.RemoveAt(index);
		m_indexesInOriginalVector.RemoveAt(index);
	}

	public int IndexOf(T value)
	{
		int indexInOriginalVector = m_indexFunctionFromDataSource(value);
		return IndexFromIndexInOriginalVector(indexInOriginalVector);
	}

	public int IndexToIndexInOriginalVector(int index)
	{
		return m_indexesInOriginalVector[index];
	}

	public int IndexFromIndexInOriginalVector(int indexInOriginalVector)
	{
		int num = m_indexesInOriginalVector.IndexOf(indexInOriginalVector);
		if (num != -1)
		{
			return num;
		}
		return -1;
	}

	public int Size()
	{
		return m_indexesInOriginalVector.Count;
	}
}
