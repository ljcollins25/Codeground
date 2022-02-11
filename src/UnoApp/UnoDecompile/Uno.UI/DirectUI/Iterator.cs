namespace DirectUI;

internal class Iterator<T> : IteratorBase<T>
{
	private T m_current;

	protected override T GetCurrent()
	{
		return m_current;
	}

	protected override void ClearCurrent()
	{
		m_current = default(T);
	}

	protected override void SetCurrent(T current)
	{
		m_current = current;
	}
}
