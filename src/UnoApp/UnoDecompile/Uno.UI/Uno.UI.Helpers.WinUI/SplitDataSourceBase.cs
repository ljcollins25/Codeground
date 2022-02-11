using System.Collections.Generic;

namespace Uno.UI.Helpers.WinUI;

internal abstract class SplitDataSourceBase<T, TVectorId, AttachedDataType>
{
	private List<TVectorId> m_flags = new List<TVectorId>();

	private List<AttachedDataType> m_attachedData = new List<AttachedDataType>();

	private SplitVector<T, TVectorId>[] m_splitVectors;

	public SplitDataSourceBase(int vectorIdSize)
	{
		m_splitVectors = new SplitVector<T, TVectorId>[vectorIdSize];
	}

	public TVectorId GetVectorIDForItem(int index)
	{
		return m_flags[index];
	}

	public AttachedDataType AttachedData(int index)
	{
		return m_attachedData[index];
	}

	public void AttachedData(int index, AttachedDataType attachedData)
	{
		m_attachedData[index] = attachedData;
	}

	public void ResetAttachedData()
	{
		ResetAttachedData(DefaultAttachedData());
	}

	public void ResetAttachedData(AttachedDataType attachedData)
	{
		for (int i = 0; i < RawDataSize(); i++)
		{
			m_attachedData[i] = attachedData;
		}
	}

	public SplitVector<T, TVectorId> GetVectorForItem(int index)
	{
		if (index >= 0 && index < RawDataSize())
		{
			return m_splitVectors[(int)(object)m_flags[index]];
		}
		return null;
	}

	public void MoveItemsToVector(TVectorId newVectorID)
	{
		MoveItemsToVector(0, RawDataSize(), newVectorID);
	}

	public void MoveItemsToVector(int start, int end, TVectorId newVectorID)
	{
		for (int i = start; i < end; i++)
		{
			MoveItemToVector(i, newVectorID);
		}
	}

	public void MoveItemToVector(int index, TVectorId newVectorID)
	{
		if (!m_flags[index].Equals(newVectorID))
		{
			GetVectorForItem(index)?.RemoveAt(index);
			m_flags[index] = newVectorID;
			SplitVector<T, TVectorId> splitVector = m_splitVectors[(int)(object)newVectorID];
			if (splitVector != null)
			{
				int preferIndex = GetPreferIndex(index, newVectorID);
				T at = GetAt(index);
				splitVector.InsertAt(preferIndex, index, at);
			}
		}
	}

	public abstract int IndexOf(T value);

	public abstract T GetAt(int index);

	public abstract int Size();

	protected abstract TVectorId DefaultVectorIDOnInsert();

	protected abstract AttachedDataType DefaultAttachedData();

	protected int IndexOfImpl(T value, TVectorId vectorID)
	{
		int num = IndexOf(value);
		int result = -1;
		if (num != -1)
		{
			SplitVector<T, TVectorId> vectorForItem = GetVectorForItem(num);
			if (vectorForItem != null && vectorForItem.GetVectorIDForItem().Equals(vectorID))
			{
				result = vectorForItem.IndexFromIndexInOriginalVector(num);
			}
		}
		return result;
	}

	protected void InitializeSplitVectors(params SplitVector<T, TVectorId>[] vectors)
	{
		foreach (SplitVector<T, TVectorId> splitVector in vectors)
		{
			m_splitVectors[(int)(object)splitVector.GetVectorIDForItem()] = splitVector;
		}
	}

	protected SplitVector<T, TVectorId> GetVector(TVectorId vectorID)
	{
		return m_splitVectors[(int)(object)vectorID];
	}

	protected void OnClear()
	{
		SplitVector<T, TVectorId>[] splitVectors = m_splitVectors;
		for (int i = 0; i < splitVectors.Length; i++)
		{
			splitVectors[i]?.Clear();
		}
		m_flags.Clear();
		m_attachedData.Clear();
	}

	protected void OnRemoveAt(int startIndex, int count)
	{
		for (int num = startIndex + count - 1; num >= startIndex; num--)
		{
			OnRemoveAt(num);
		}
	}

	protected void OnInsertAt(int startIndex, int count)
	{
		for (int i = startIndex; i < startIndex + count; i++)
		{
			OnInsertAt(i);
		}
	}

	protected int RawDataSize()
	{
		return m_flags.Count;
	}

	protected void SyncAndInitVectorFlagsWithID(TVectorId defaultID, AttachedDataType defaultAttachedData)
	{
		for (int i = 0; i < Size(); i++)
		{
			m_flags.Add(defaultID);
			m_attachedData.Add(defaultAttachedData);
		}
	}

	protected void Clear()
	{
		OnClear();
	}

	private void OnRemoveAt(int index)
	{
		TVectorId vectorID = m_flags[index];
		SplitVector<T, TVectorId>[] splitVectors = m_splitVectors;
		for (int i = 0; i < splitVectors.Length; i++)
		{
			splitVectors[i]?.OnRawDataRemove(index, vectorID);
		}
		m_flags.RemoveAt(index);
		m_attachedData.RemoveAt(index);
	}

	private void OnReplace(int index)
	{
		SplitVector<T, TVectorId> vectorForItem = GetVectorForItem(index);
		if (vectorForItem != null)
		{
			T at = GetAt(index);
			vectorForItem.Replace(index, at);
		}
	}

	private void OnInsertAt(int index)
	{
		TVectorId val = DefaultVectorIDOnInsert();
		AttachedDataType item = DefaultAttachedData();
		int preferIndex = GetPreferIndex(index, val);
		T at = GetAt(index);
		SplitVector<T, TVectorId>[] splitVectors = m_splitVectors;
		for (int i = 0; i < splitVectors.Length; i++)
		{
			splitVectors[i]?.OnRawDataInsert(preferIndex, index, at, val);
		}
		m_flags.Insert(index, val);
		m_attachedData.Insert(index, item);
	}

	private int GetPreferIndex(int index, TVectorId vectorID)
	{
		return RangeCount(0, index, vectorID);
	}

	private int RangeCount(int start, int end, TVectorId vectorID)
	{
		int num = 0;
		for (int i = start; i < end; i++)
		{
			if (m_flags[i].Equals(vectorID))
			{
				num++;
			}
		}
		return num;
	}
}
