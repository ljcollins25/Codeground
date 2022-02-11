using System;
using System.Collections;
using System.Collections.Generic;
using Windows.System;

namespace DirectUI;

internal abstract class IteratorBase<T> : IEnumerator<T>, IEnumerator, IDisposable
{
	private IVectorView<T> m_tpView;

	private uint m_nCurrentIndex;

	object IEnumerator.Current => Current;

	public T Current
	{
		get
		{
			CheckThread();
			return GetCurrent();
		}
	}

	public bool HasCurrent
	{
		get
		{
			CheckThread();
			uint size = m_tpView.Size;
			return m_nCurrentIndex != 0 && m_nCurrentIndex <= size;
		}
	}

	protected void CheckThread()
	{
		DispatcherQueue.CheckThreadAccess();
	}

	public void SetView(IVectorView<T> pView)
	{
		m_tpView = pView;
		bool flag = MoveNext();
	}

	public void Reset()
	{
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		CheckThread();
		uint size = m_tpView.Size;
		bool result = false;
		ClearCurrent();
		if (m_nCurrentIndex >= 0 && m_nCurrentIndex < size)
		{
			T at = m_tpView.GetAt(m_nCurrentIndex);
			SetCurrent(at);
			m_nCurrentIndex++;
			result = true;
		}
		else
		{
			m_nCurrentIndex = size + 1;
		}
		return result;
	}

	protected IteratorBase()
	{
		m_nCurrentIndex = 0u;
	}

	~IteratorBase()
	{
	}

	protected abstract T GetCurrent();

	protected abstract void SetCurrent(T current);

	protected abstract void ClearCurrent();
}
